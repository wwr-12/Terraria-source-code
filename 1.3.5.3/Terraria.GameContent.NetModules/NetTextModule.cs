using System.IO;
using Microsoft.Xna.Framework;
using Terraria.Chat;
using Terraria.GameContent.UI.Chat;
using Terraria.Localization;
using Terraria.Net;
using Terraria.UI.Chat;

namespace Terraria.GameContent.NetModules
{
	public class NetTextModule : NetModule
	{
		public static NetPacket SerializeClientMessage(ChatMessage message)
		{
			NetPacket result = NetModule.CreatePacket<NetTextModule>(message.GetMaxSerializedSize());
			message.Serialize(result.Writer);
			return result;
		}

		public static NetPacket SerializeServerMessage(NetworkText text, Color color)
		{
			return SerializeServerMessage(text, color, byte.MaxValue);
		}

		public static NetPacket SerializeServerMessage(NetworkText text, Color color, byte authorId)
		{
			NetPacket result = NetModule.CreatePacket<NetTextModule>(1 + text.GetMaxSerializedSize() + 3);
			result.Writer.Write(authorId);
			text.Serialize(result.Writer);
			result.Writer.WriteRGB(color);
			return result;
		}

		private bool DeserializeAsClient(BinaryReader reader, int senderPlayerId)
		{
			byte b = reader.ReadByte();
			string text = NetworkText.Deserialize(reader).ToString();
			Color c = reader.ReadRGB();
			if (b < byte.MaxValue)
			{
				Main.player[b].chatOverhead.NewMessage(text, Main.chatLength / 2);
				text = NameTagHandler.GenerateTag(Main.player[b].name) + " " + text;
			}
			Main.NewTextMultiline(text, force: false, c);
			return true;
		}

		private bool DeserializeAsServer(BinaryReader reader, int senderPlayerId)
		{
			ChatMessage message = ChatMessage.Deserialize(reader);
			ChatManager.Commands.ProcessReceivedMessage(message, senderPlayerId);
			return true;
		}

		private void BroadcastRawMessage(ChatMessage message, byte author, Color messageColor)
		{
			NetManager.Instance.Broadcast(SerializeServerMessage(NetworkText.FromLiteral(message.Text), messageColor));
		}

		public override bool Deserialize(BinaryReader reader, int senderPlayerId)
		{
			return DeserializeAsClient(reader, senderPlayerId);
		}
	}
}
