using System;
using Terraria.GameContent.NetModules;
using Terraria.Localization;
using Terraria.Net;

namespace Terraria.Chat.Commands
{
	[ChatCommand("Say")]
	public class SayChatCommand : IChatCommand
	{
		public void ProcessMessage(string text, byte clientId)
		{
			NetPacket packet = NetTextModule.SerializeServerMessage(NetworkText.FromLiteral(text), Main.player[clientId].ChatColor(), clientId);
			NetManager.Instance.Broadcast(packet);
			Console.WriteLine("<{0}> {1}", Main.player[clientId].name, text);
		}
	}
}
