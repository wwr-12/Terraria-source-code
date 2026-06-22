using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Terraria.Chat.Commands
{
	[ChatCommand("Roll")]
	public class RollCommand : IChatCommand
	{
		private static readonly Color RESPONSE_COLOR = new Color(255, 240, 20);

		public string InternalName => "roll";

		public void ProcessMessage(string text, byte clientId)
		{
			int num = Main.rand.Next(1, 101);
			NetMessage.BroadcastChatMessage(NetworkText.FromFormattable("*{0} {1} {2}", Main.player[clientId].name, Lang.mp[9].ToNetworkText(), num), RESPONSE_COLOR);
		}
	}
}
