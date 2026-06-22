using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Effects;
using Terraria.Localization;

namespace Terraria.GameContent.Events
{
	public class BirthdayParty
	{
		public static bool ManualParty = false;

		public static bool GenuineParty = false;

		public static int PartyDaysOnCooldown = 0;

		public static List<int> CelebratingNPCs = new List<int>();

		private static bool _wasCelebrating = false;

		public static bool PartyIsUp
		{
			get
			{
				if (!GenuineParty)
				{
					return ManualParty;
				}
				return true;
			}
		}

		public static void CheckMorning()
		{
			NaturalAttempt();
		}

		public static void CheckNight()
		{
			bool flag = false;
			if (GenuineParty)
			{
				flag = true;
				GenuineParty = false;
				CelebratingNPCs.Clear();
			}
			if (ManualParty)
			{
				flag = true;
				ManualParty = false;
			}
			if (flag)
			{
				WorldGen.BroadcastText(color: new Color(255, 0, 160), text: NetworkText.FromKey(Lang.misc[99].Key));
			}
		}

		private static void NaturalAttempt()
		{
			if (Main.netMode == 1)
			{
				return;
			}
			if (PartyDaysOnCooldown > 0)
			{
				PartyDaysOnCooldown--;
			}
			else
			{
				if (Main.rand.Next(10) != 0)
				{
					return;
				}
				List<NPC> list = new List<NPC>();
				for (int i = 0; i < 200; i++)
				{
					NPC nPC = Main.npc[i];
					if (nPC.active && nPC.townNPC && nPC.type != 37 && nPC.type != 453 && nPC.aiStyle != 0)
					{
						list.Add(nPC);
					}
				}
				if (list.Count >= 5)
				{
					GenuineParty = true;
					PartyDaysOnCooldown = Main.rand.Next(5, 11);
					CelebratingNPCs.Clear();
					List<int> list2 = new List<int>();
					int num = 1;
					if (Main.rand.Next(5) == 0 && list.Count > 12)
					{
						num = 3;
					}
					else if (Main.rand.Next(3) == 0)
					{
						num = 2;
					}
					list = list.OrderBy((NPC nPC2) => Main.rand.Next()).ToList();
					for (int num2 = 0; num2 < num; num2++)
					{
						list2.Add(num2);
					}
					for (int num3 = 0; num3 < list2.Count; num3++)
					{
						CelebratingNPCs.Add(list[list2[num3]].whoAmI);
					}
					Color color = new Color(255, 0, 160);
					if (CelebratingNPCs.Count == 3)
					{
						WorldGen.BroadcastText(NetworkText.FromKey("Game.BirthdayParty_3", Main.npc[CelebratingNPCs[0]].GetGivenOrTypeNetName(), Main.npc[CelebratingNPCs[1]].GetGivenOrTypeNetName(), Main.npc[CelebratingNPCs[2]].GetGivenOrTypeNetName()), color);
					}
					else if (CelebratingNPCs.Count == 2)
					{
						WorldGen.BroadcastText(NetworkText.FromKey("Game.BirthdayParty_2", Main.npc[CelebratingNPCs[0]].GetGivenOrTypeNetName(), Main.npc[CelebratingNPCs[1]].GetGivenOrTypeNetName()), color);
					}
					else
					{
						WorldGen.BroadcastText(NetworkText.FromKey("Game.BirthdayParty_1", Main.npc[CelebratingNPCs[0]].GetGivenOrTypeNetName()), color);
					}
				}
			}
		}

		public static void ToggleManualParty()
		{
			bool partyIsUp = PartyIsUp;
			if (Main.netMode != 1)
			{
				ManualParty = !ManualParty;
			}
			else
			{
				NetMessage.SendData(111);
			}
			if (partyIsUp != PartyIsUp && Main.netMode == 2)
			{
				NetMessage.SendData(7);
			}
		}

		public static void WorldClear()
		{
			ManualParty = false;
			GenuineParty = false;
			PartyDaysOnCooldown = 0;
			CelebratingNPCs.Clear();
			_wasCelebrating = false;
		}

		public static void UpdateTime()
		{
			if (_wasCelebrating != PartyIsUp)
			{
				if (Main.netMode != 2)
				{
					if (PartyIsUp)
					{
						SkyManager.Instance.Activate("Party", default(Vector2));
					}
					else
					{
						SkyManager.Instance.Deactivate("Party");
					}
				}
				if (Main.netMode != 1 && CelebratingNPCs.Count > 0)
				{
					for (int i = 0; i < CelebratingNPCs.Count; i++)
					{
						NPC nPC = Main.npc[CelebratingNPCs[i]];
						if (!nPC.active || !nPC.townNPC || nPC.type == 37 || nPC.type == 453 || nPC.aiStyle == 0)
						{
							CelebratingNPCs.RemoveAt(i);
						}
					}
					if (CelebratingNPCs.Count == 0)
					{
						GenuineParty = false;
						if (!ManualParty)
						{
							WorldGen.BroadcastText(color: new Color(255, 0, 160), text: NetworkText.FromKey(Lang.misc[99].Key));
							NetMessage.SendData(7);
						}
					}
				}
			}
			_wasCelebrating = PartyIsUp;
		}
	}
}
