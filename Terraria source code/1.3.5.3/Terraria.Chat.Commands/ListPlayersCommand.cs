using System.Linq;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Terraria.Chat.Commands
{
	[ChatCommand("Playing")]
	public class ListPlayersCommand : IChatCommand
	{
		private static readonly Color RESPONSE_COLOR = new Color(255, 240, 20);

		public void ProcessMessage(string text, byte clientId)
		{
			NetMessage.SendChatMessageToClient(NetworkText.FromLiteral(string.Join(", ", from player in Main.player
				where player.active
				select player.name)), RESPONSE_COLOR, clientId);
		}
	}
}
