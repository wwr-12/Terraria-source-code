using System.IO;
using System.Text;
using Terraria.Chat.Commands;

namespace Terraria.Chat
{
	public class ChatMessage
	{
		public ChatCommandId CommandId { get; private set; }

		public string Text { get; set; }

		public ChatMessage(string message)
		{
			CommandId = ChatCommandId.FromType<SayChatCommand>();
			Text = message;
		}

		private ChatMessage(string message, ChatCommandId commandId)
		{
			CommandId = commandId;
			Text = message;
		}

		public void Serialize(BinaryWriter writer)
		{
			CommandId.Serialize(writer);
			writer.Write(Text);
		}

		public int GetMaxSerializedSize()
		{
			return 0 + CommandId.GetMaxSerializedSize() + (4 + Encoding.UTF8.GetByteCount(Text));
		}

		public static ChatMessage Deserialize(BinaryReader reader)
		{
			ChatCommandId commandId = ChatCommandId.Deserialize(reader);
			return new ChatMessage(reader.ReadString(), commandId);
		}

		public void SetCommand(ChatCommandId commandId)
		{
			CommandId = commandId;
		}

		public void SetCommand<T>() where T : IChatCommand
		{
			CommandId = ChatCommandId.FromType<T>();
		}
	}
}
