using Microsoft.Xna.Framework;
using Terraria.GameContent.NetModules;
using Terraria.Localization;
using Terraria.Net;

namespace Terraria.Chat.Commands
{
	[ChatCommand("Party")]
	public class PartyChatCommand : IChatCommand
	{
		private static readonly Color ERROR_COLOR = new Color(255, 240, 20);

		public void ProcessMessage(string text, byte clientId)
		{
			int team = Main.player[clientId].team;
			Color color = Main.teamColor[team];
			if (team == 0)
			{
				SendNoTeamError(clientId);
			}
			else
			{
				if (text == "")
				{
					return;
				}
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].team == team)
					{
						NetPacket packet = NetTextModule.SerializeServerMessage(NetworkText.FromLiteral(text), color, clientId);
						NetManager.Instance.SendToClient(packet, i);
					}
				}
			}
		}

		private void SendNoTeamError(byte clientId)
		{
			NetPacket packet = NetTextModule.SerializeServerMessage(Lang.mp[10].ToNetworkText(), ERROR_COLOR);
			NetManager.Instance.SendToClient(packet, clientId);
		}
	}
}
