using System.Collections.Generic;
using System.Linq;
using ReLogic.Utilities;
using Terraria.Chat.Commands;
using Terraria.Localization;

namespace Terraria.Chat
{
	public class ChatCommandProcessor : IChatProcessor
	{
		private Dictionary<LocalizedText, ChatCommandId> _localizedCommands = new Dictionary<LocalizedText, ChatCommandId>();

		private Dictionary<ChatCommandId, IChatCommand> _commands = new Dictionary<ChatCommandId, IChatCommand>();

		private IChatCommand _defaultCommand;

		public ChatCommandProcessor AddCommand<T>() where T : IChatCommand, new()
		{
			ChatCommandAttribute cacheableAttribute = AttributeUtilities.GetCacheableAttribute<T, ChatCommandAttribute>();
			string commandKey = "ChatCommand." + cacheableAttribute.Name;
			ChatCommandId chatCommandId = ChatCommandId.FromType<T>();
			_commands[chatCommandId] = new T();
			if (Language.Exists(commandKey))
			{
				_localizedCommands.Add(Language.GetText(commandKey), chatCommandId);
			}
			else
			{
				commandKey += "_";
				LocalizedText[] array = Language.FindAll((string text2, LocalizedText text) => text2.StartsWith(commandKey));
				foreach (LocalizedText key in array)
				{
					_localizedCommands.Add(key, chatCommandId);
				}
			}
			return this;
		}

		public ChatCommandProcessor AddDefaultCommand<T>() where T : IChatCommand, new()
		{
			AddCommand<T>();
			ChatCommandId key = ChatCommandId.FromType<T>();
			_defaultCommand = _commands[key];
			return this;
		}

		private static bool HasLocalizedCommand(ChatMessage message, LocalizedText command)
		{
			string text = message.Text.ToLower();
			string value = command.Value;
			if (!text.StartsWith(value))
			{
				return false;
			}
			if (text.Length == value.Length)
			{
				return true;
			}
			return text[value.Length] == ' ';
		}

		private static string RemoveCommandPrefix(string messageText, LocalizedText command)
		{
			string value = command.Value;
			if (!messageText.StartsWith(value))
			{
				return "";
			}
			if (messageText.Length == value.Length)
			{
				return "";
			}
			if (messageText[value.Length] == ' ')
			{
				return messageText.Substring(value.Length + 1);
			}
			return "";
		}

		public bool ProcessOutgoingMessage(ChatMessage message)
		{
			KeyValuePair<LocalizedText, ChatCommandId> keyValuePair = _localizedCommands.FirstOrDefault((KeyValuePair<LocalizedText, ChatCommandId> pair) => HasLocalizedCommand(message, pair.Key));
			ChatCommandId value = keyValuePair.Value;
			if (keyValuePair.Key != null)
			{
				message.SetCommand(value);
				message.Text = RemoveCommandPrefix(message.Text, keyValuePair.Key);
				return true;
			}
			return false;
		}

		public bool ProcessReceivedMessage(ChatMessage message, int clientId)
		{
			if (_commands.TryGetValue(message.CommandId, out var value))
			{
				value.ProcessMessage(message.Text, (byte)clientId);
				return true;
			}
			if (_defaultCommand != null)
			{
				_defaultCommand.ProcessMessage(message.Text, (byte)clientId);
				return true;
			}
			return false;
		}
	}
}
