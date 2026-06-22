using Microsoft.Xna.Framework;

namespace Terraria
{
	public class Chest
	{
		public const int MaxNameLength = 20;

		public static int maxChestTypes = 48;

		public static int[] typeToIcon = new int[maxChestTypes];

		public static int[] itemSpawn = new int[maxChestTypes];

		public static int maxItems = 40;

		public Item[] item;

		public int x;

		public int y;

		public bool bankChest;

		public string name;

		public Chest(bool bank = false)
		{
			item = new Item[maxItems];
			bankChest = bank;
			name = string.Empty;
		}

		public override string ToString()
		{
			int num = 0;
			for (int i = 0; i < item.Length; i++)
			{
				if (item[i].stack > 0)
				{
					num++;
				}
			}
			return $"{{X: {x}, Y: {y}, Count: {num}}}";
		}

		public static void Initialize()
		{
			typeToIcon[0] = (itemSpawn[0] = 48);
			typeToIcon[1] = (itemSpawn[1] = 306);
			typeToIcon[2] = 327;
			itemSpawn[2] = 306;
			typeToIcon[3] = (itemSpawn[3] = 328);
			typeToIcon[4] = 329;
			itemSpawn[4] = 328;
			typeToIcon[5] = (itemSpawn[5] = 343);
			typeToIcon[6] = (itemSpawn[6] = 348);
			typeToIcon[7] = (itemSpawn[7] = 625);
			typeToIcon[8] = (itemSpawn[8] = 626);
			typeToIcon[9] = (itemSpawn[9] = 627);
			typeToIcon[10] = (itemSpawn[10] = 680);
			typeToIcon[11] = (itemSpawn[11] = 681);
			typeToIcon[12] = (itemSpawn[12] = 831);
			typeToIcon[13] = (itemSpawn[13] = 838);
			typeToIcon[14] = (itemSpawn[14] = 914);
			typeToIcon[15] = (itemSpawn[15] = 952);
			typeToIcon[16] = (itemSpawn[16] = 1142);
			typeToIcon[17] = (itemSpawn[17] = 1298);
			typeToIcon[18] = (itemSpawn[18] = 1528);
			typeToIcon[19] = (itemSpawn[19] = 1529);
			typeToIcon[20] = (itemSpawn[20] = 1530);
			typeToIcon[21] = (itemSpawn[21] = 1531);
			typeToIcon[22] = (itemSpawn[22] = 1532);
			typeToIcon[23] = 1533;
			itemSpawn[23] = 1528;
			typeToIcon[24] = 1534;
			itemSpawn[24] = 1529;
			typeToIcon[25] = 1535;
			itemSpawn[25] = 1530;
			typeToIcon[26] = 1536;
			itemSpawn[26] = 1531;
			typeToIcon[27] = 1537;
			itemSpawn[27] = 1532;
			typeToIcon[28] = (itemSpawn[28] = 2230);
			typeToIcon[29] = (itemSpawn[29] = 2249);
			typeToIcon[30] = (itemSpawn[30] = 2250);
			typeToIcon[31] = (itemSpawn[31] = 2526);
			typeToIcon[32] = (itemSpawn[32] = 2544);
			typeToIcon[33] = (itemSpawn[33] = 2559);
			typeToIcon[34] = (itemSpawn[34] = 2574);
			typeToIcon[35] = (itemSpawn[35] = 2612);
			typeToIcon[36] = 327;
			itemSpawn[36] = 2612;
			typeToIcon[37] = (itemSpawn[37] = 2613);
			typeToIcon[38] = 327;
			itemSpawn[38] = 2613;
			typeToIcon[39] = (itemSpawn[39] = 2614);
			typeToIcon[40] = 327;
			itemSpawn[40] = 2614;
			typeToIcon[41] = (itemSpawn[41] = 2615);
			typeToIcon[42] = (itemSpawn[42] = 2616);
			typeToIcon[43] = (itemSpawn[43] = 2617);
			typeToIcon[44] = (itemSpawn[44] = 2618);
			typeToIcon[45] = (itemSpawn[45] = 2619);
			typeToIcon[46] = (itemSpawn[46] = 2620);
			typeToIcon[47] = (itemSpawn[47] = 2748);
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public static void Unlock(int X, int Y)
		{
			if (Main.tile[X, Y] == null)
			{
				return;
			}
			short num;
			int type;
			switch (Main.tile[X, Y].frameX / 36)
			{
			case 2:
			case 4:
				num = 36;
				type = 11;
				break;
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
				num = 180;
				type = 11;
				break;
			case 36:
			case 38:
			case 40:
				num = 36;
				type = 11;
				break;
			default:
				return;
			}
			Main.PlaySound(22, X * 16, Y * 16);
			for (int i = X; i <= X + 1; i++)
			{
				for (int j = Y; j <= Y + 1; j++)
				{
					Main.tile[i, j].frameX -= num;
					for (int k = 0; k < 4; k++)
					{
						Dust.NewDust(new Vector2(i * 16, j * 16), 16, 16, type);
					}
				}
			}
		}

		public static int UsingChest(int i)
		{
			if (Main.chest[i] != null)
			{
				for (int j = 0; j < 255; j++)
				{
					if (Main.player[j].active && Main.player[j].chest == i)
					{
						return j;
					}
				}
			}
			return -1;
		}

		public static int FindChest(int X, int Y)
		{
			for (int i = 0; i < 1000; i++)
			{
				if (Main.chest[i] != null && Main.chest[i].x == X && Main.chest[i].y == Y)
				{
					return i;
				}
			}
			return -1;
		}

		public static int CreateChest(int X, int Y, int id = -1)
		{
			int num = id;
			if (num == -1)
			{
				for (int i = 0; i < 1000; i++)
				{
					if (Main.chest[i] != null)
					{
						if (Main.chest[i].x == X && Main.chest[i].y == Y)
						{
							return -1;
						}
					}
					else if (num == -1)
					{
						num = i;
					}
				}
				if (num == -1)
				{
					return -1;
				}
				if (Main.netMode == 1)
				{
					return num;
				}
			}
			Main.chest[num] = new Chest();
			Main.chest[num].x = X;
			Main.chest[num].y = Y;
			for (int j = 0; j < maxItems; j++)
			{
				Main.chest[num].item[j] = new Item();
			}
			return num;
		}

		public static bool DestroyChest(int X, int Y)
		{
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest == null || chest.x != X || chest.y != Y)
				{
					continue;
				}
				for (int j = 0; j < maxItems; j++)
				{
					if (chest.item[j] != null && chest.item[j].type > 0 && chest.item[j].stack > 0)
					{
						return false;
					}
				}
				Main.chest[i] = null;
				return true;
			}
			return true;
		}

		public static void DestroyChestDirect(int X, int Y, int id)
		{
			Chest chest = Main.chest[id];
			if (chest != null && chest.x == X && chest.y == Y)
			{
				Main.chest[id] = null;
			}
		}

		public void AddShop(Item newItem)
		{
			for (int i = 0; i < 39; i++)
			{
				if (item[i] != null && item[i].type != 0)
				{
					continue;
				}
				item[i] = newItem.Clone();
				item[i].buyOnce = true;
				if (item[i].value > 0)
				{
					item[i].value = item[i].value / 5;
					if (item[i].value < 1)
					{
						item[i].value = 1;
					}
				}
				break;
			}
		}

		public static void SetupTravelShop()
		{
			for (int i = 0; i < maxItems; i++)
			{
				Main.travelShop[i] = 0;
			}
			int num = Main.rand.Next(4, 7);
			if (Main.rand.Next(5) == 0)
			{
				num++;
			}
			if (Main.rand.Next(10) == 0)
			{
				num++;
			}
			if (Main.rand.Next(20) == 0)
			{
				num++;
			}
			if (Main.rand.Next(40) == 0)
			{
				num++;
			}
			int num2 = 0;
			int num3 = 0;
			int[] array = new int[6] { 100, 200, 300, 400, 500, 800 };
			while (num3 < num)
			{
				int num4 = 0;
				if (Main.rand.Next(array[5]) == 0)
				{
					num4 = 1987;
				}
				if (Main.rand.Next(array[4]) == 0 && Main.hardMode)
				{
					num4 = 2270;
				}
				if (Main.rand.Next(array[4]) == 0)
				{
					num4 = 2278;
				}
				if (Main.rand.Next(array[4]) == 0)
				{
					num4 = 2271;
				}
				if (Main.rand.Next(array[3]) == 0 && Main.hardMode && NPC.downedPlantBoss)
				{
					num4 = 2223;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num4 = 2272;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num4 = 2219;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num4 = 2276;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num4 = 2284;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num4 = 2285;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num4 = 2286;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num4 = 2287;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num4 = 2296;
				}
				if (Main.rand.Next(array[2]) == 0 && WorldGen.shadowOrbSmashed)
				{
					num4 = 2269;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num4 = 2177;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num4 = 1988;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num4 = 2275;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num4 = 2279;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num4 = 2277;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num4 = 2214;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num4 = 2215;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num4 = 2216;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num4 = 2217;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num4 = 2273;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num4 = 2274;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num4 = 2266;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num4 = 2267;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num4 = 2268;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num4 = 2281 + Main.rand.Next(3);
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num4 = 2258;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num4 = 2242;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num4 = 2260;
				}
				if (num4 != 0)
				{
					for (int j = 0; j < maxItems; j++)
					{
						if (Main.travelShop[j] == num4)
						{
							num4 = 0;
							break;
						}
					}
				}
				if (num4 != 0)
				{
					num3++;
					Main.travelShop[num2] = num4;
					num2++;
					if (num4 == 2260)
					{
						Main.travelShop[num2] = 2261;
						num2++;
						Main.travelShop[num2] = 2262;
						num2++;
					}
				}
			}
		}

		public void SetupShop(int type)
		{
			for (int i = 0; i < maxItems; i++)
			{
				item[i] = new Item();
			}
			int num = 0;
			switch (type)
			{
			case 1:
			{
				item[num].SetDefaults("Mining Helmet");
				num++;
				item[num].SetDefaults("Piggy Bank");
				num++;
				item[num].SetDefaults("Iron Anvil");
				num++;
				item[num].SetDefaults(1991);
				num++;
				item[num].SetDefaults("Copper Pickaxe");
				num++;
				item[num].SetDefaults("Copper Axe");
				num++;
				item[num].SetDefaults("Torch");
				num++;
				item[num].SetDefaults("Lesser Healing Potion");
				num++;
				item[num].SetDefaults("Lesser Mana Potion");
				num++;
				item[num].SetDefaults("Wooden Arrow");
				num++;
				item[num].SetDefaults("Shuriken");
				num++;
				item[num].SetDefaults("Rope");
				num++;
				if (Main.player[Main.myPlayer].zoneSnow)
				{
					item[num].SetDefaults(967);
					num++;
				}
				if (Main.bloodMoon)
				{
					item[num].SetDefaults("Throwing Knife");
					num++;
				}
				if (!Main.dayTime)
				{
					item[num].SetDefaults("Glowstick");
					num++;
				}
				if (NPC.downedBoss3)
				{
					item[num].SetDefaults("Safe");
					num++;
				}
				if (Main.hardMode)
				{
					item[num].SetDefaults(488);
					num++;
				}
				for (int num6 = 0; num6 < 58; num6++)
				{
					if (Main.player[Main.myPlayer].inventory[num6].type == 930)
					{
						item[num].SetDefaults(931);
						num++;
						item[num].SetDefaults(1614);
						num++;
						break;
					}
				}
				if (Main.halloween)
				{
					item[num].SetDefaults(1786);
					num++;
				}
				if (Main.hardMode)
				{
					item[num].SetDefaults(1348);
					num++;
				}
				break;
			}
			case 2:
				item[num].SetDefaults("Musket Ball");
				num++;
				if (Main.bloodMoon || Main.hardMode)
				{
					item[num].SetDefaults("Silver Bullet");
					num++;
				}
				if ((NPC.downedBoss2 && !Main.dayTime) || Main.hardMode)
				{
					item[num].SetDefaults(47);
					num++;
				}
				item[num].SetDefaults("Flintlock Pistol");
				num++;
				item[num].SetDefaults("Minishark");
				num++;
				if (!Main.dayTime)
				{
					item[num].SetDefaults(324);
					num++;
				}
				if (Main.hardMode)
				{
					item[num].SetDefaults(534);
					num++;
				}
				if (Main.hardMode)
				{
					item[num].SetDefaults(1432);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1258))
				{
					item[num].SetDefaults(1261);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1835))
				{
					item[num].SetDefaults(1836);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1782))
				{
					item[num].SetDefaults(1783);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1784))
				{
					item[num].SetDefaults(1785);
					num++;
				}
				if (Main.halloween)
				{
					item[num].SetDefaults(1736);
					num++;
					item[num].SetDefaults(1737);
					num++;
					item[num].SetDefaults(1738);
					num++;
				}
				break;
			case 3:
				if (Main.bloodMoon)
				{
					if (WorldGen.crimson)
					{
						item[num].SetDefaults(2171);
						num++;
					}
					else
					{
						item[num].SetDefaults(67);
						num++;
						item[num].SetDefaults(59);
						num++;
					}
				}
				else
				{
					item[num].SetDefaults("Purification Powder");
					num++;
					item[num].SetDefaults("Grass Seeds");
					num++;
					item[num].SetDefaults("Sunflower");
					num++;
				}
				item[num].SetDefaults("Acorn");
				num++;
				item[num].SetDefaults(114);
				num++;
				item[num].SetDefaults(1828);
				num++;
				item[num].SetDefaults(745);
				num++;
				item[num].SetDefaults(747);
				num++;
				if (Main.hardMode)
				{
					item[num].SetDefaults(746);
					num++;
				}
				if (Main.hardMode)
				{
					item[num].SetDefaults(369);
					num++;
				}
				if (Main.shroomTiles > 50)
				{
					item[num].SetDefaults(194);
					num++;
				}
				if (Main.halloween)
				{
					item[num].SetDefaults(1853);
					num++;
					item[num].SetDefaults(1854);
					num++;
				}
				break;
			case 4:
				item[num].SetDefaults("Grenade");
				num++;
				item[num].SetDefaults("Bomb");
				num++;
				item[num].SetDefaults("Dynamite");
				num++;
				if (Main.hardMode)
				{
					item[num].SetDefaults("Hellfire Arrow");
					num++;
				}
				if (Main.hardMode && NPC.downedPlantBoss && NPC.downedPirates)
				{
					item[num].SetDefaults(937);
					num++;
				}
				if (Main.hardMode)
				{
					item[num].SetDefaults(1347);
					num++;
				}
				break;
			case 5:
				item[num].SetDefaults(254);
				num++;
				item[num].SetDefaults(981);
				num++;
				if (Main.dayTime)
				{
					item[num].SetDefaults(242);
					num++;
				}
				if (Main.moonPhase == 0)
				{
					item[num].SetDefaults(245);
					num++;
					item[num].SetDefaults(246);
					num++;
				}
				else if (Main.moonPhase == 1)
				{
					item[num].SetDefaults(325);
					num++;
					item[num].SetDefaults(326);
					num++;
				}
				item[num].SetDefaults(269);
				num++;
				item[num].SetDefaults(270);
				num++;
				item[num].SetDefaults(271);
				num++;
				if (NPC.downedClown)
				{
					item[num].SetDefaults(503);
					num++;
					item[num].SetDefaults(504);
					num++;
					item[num].SetDefaults(505);
					num++;
				}
				if (Main.bloodMoon)
				{
					item[num].SetDefaults(322);
					num++;
				}
				if (Main.player[Main.myPlayer].zoneSnow)
				{
					item[num].SetDefaults(1429);
					num++;
				}
				if (Main.halloween)
				{
					item[num].SetDefaults(1740);
					num++;
				}
				if (Main.hardMode)
				{
					if (Main.moonPhase == 2)
					{
						item[num].SetDefaults(869);
						num++;
					}
					if (Main.moonPhase == 4)
					{
						item[num].SetDefaults(864);
						num++;
						item[num].SetDefaults(865);
						num++;
					}
					if (Main.moonPhase == 6)
					{
						item[num].SetDefaults(873);
						num++;
						item[num].SetDefaults(874);
						num++;
						item[num].SetDefaults(875);
						num++;
					}
				}
				if (NPC.downedFrost)
				{
					item[num].SetDefaults(1275);
					num++;
					item[num].SetDefaults(1276);
					num++;
				}
				break;
			case 6:
				item[num].SetDefaults(128);
				num++;
				item[num].SetDefaults(486);
				num++;
				item[num].SetDefaults(398);
				num++;
				item[num].SetDefaults(84);
				num++;
				item[num].SetDefaults(407);
				num++;
				item[num].SetDefaults(161);
				num++;
				break;
			case 7:
				item[num].SetDefaults(487);
				num++;
				item[num].SetDefaults(496);
				num++;
				item[num].SetDefaults(500);
				num++;
				item[num].SetDefaults(507);
				num++;
				item[num].SetDefaults(508);
				num++;
				item[num].SetDefaults(531);
				num++;
				item[num].SetDefaults(576);
				num++;
				if (Main.halloween)
				{
					item[num].SetDefaults(1739);
					num++;
				}
				break;
			case 8:
				item[num].SetDefaults(509);
				num++;
				item[num].SetDefaults(850);
				num++;
				item[num].SetDefaults(851);
				num++;
				item[num].SetDefaults(510);
				num++;
				item[num].SetDefaults(530);
				num++;
				item[num].SetDefaults(513);
				num++;
				item[num].SetDefaults(538);
				num++;
				item[num].SetDefaults(529);
				num++;
				item[num].SetDefaults(541);
				num++;
				item[num].SetDefaults(542);
				num++;
				item[num].SetDefaults(543);
				num++;
				item[num].SetDefaults(852);
				num++;
				item[num].SetDefaults(853);
				num++;
				item[num].SetDefaults(2739);
				num++;
				item[num].SetDefaults(849);
				num++;
				if (NPC.AnyNPCs(369) && Main.hardMode && Main.moonPhase == 3)
				{
					item[num].SetDefaults(2295);
					num++;
				}
				break;
			case 9:
			{
				item[num].SetDefaults(588);
				num++;
				item[num].SetDefaults(589);
				num++;
				item[num].SetDefaults(590);
				num++;
				item[num].SetDefaults(597);
				num++;
				item[num].SetDefaults(598);
				num++;
				item[num].SetDefaults(596);
				num++;
				for (int k = 1873; k < 1906; k++)
				{
					item[num].SetDefaults(k);
					num++;
				}
				break;
			}
			case 10:
				if (NPC.downedMechBossAny)
				{
					item[num].SetDefaults(756);
					num++;
					item[num].SetDefaults(787);
					num++;
				}
				item[num].SetDefaults(868);
				num++;
				if (NPC.downedPlantBoss)
				{
					item[num].SetDefaults(1551);
					num++;
				}
				item[num].SetDefaults(1181);
				num++;
				item[num].SetDefaults(783);
				num++;
				break;
			case 11:
				item[num].SetDefaults(779);
				num++;
				if (Main.moonPhase >= 4)
				{
					item[num].SetDefaults(748);
					num++;
				}
				else
				{
					item[num].SetDefaults(839);
					num++;
					item[num].SetDefaults(840);
					num++;
					item[num].SetDefaults(841);
					num++;
				}
				if (Main.dayTime)
				{
					item[num].SetDefaults(998);
					num++;
				}
				else
				{
					item[num].SetDefaults(995);
					num++;
				}
				if (NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3)
				{
					item[num].SetDefaults(2203);
					num++;
				}
				if (WorldGen.crimson)
				{
					item[num].SetDefaults(2193);
					num++;
				}
				item[num].SetDefaults(1263);
				num++;
				if (Main.eclipse || Main.bloodMoon)
				{
					if (WorldGen.crimson)
					{
						item[num].SetDefaults(784);
						num++;
					}
					else
					{
						item[num].SetDefaults(782);
						num++;
					}
				}
				else if (Main.player[Main.myPlayer].zoneHoly)
				{
					item[num].SetDefaults(781);
					num++;
				}
				else
				{
					item[num].SetDefaults(780);
					num++;
				}
				if (Main.hardMode)
				{
					item[num].SetDefaults(1344);
					num++;
				}
				if (Main.halloween)
				{
					item[num].SetDefaults(1742);
					num++;
				}
				break;
			case 12:
				item[num].SetDefaults(1037);
				num++;
				item[num].SetDefaults(1120);
				num++;
				if (Main.netMode == 1)
				{
					item[num].SetDefaults(1969);
				}
				num++;
				if (Main.halloween)
				{
					item[num].SetDefaults(1741);
					num++;
				}
				break;
			case 13:
				item[num].SetDefaults(1000);
				num++;
				item[num].SetDefaults(1168);
				num++;
				item[num].SetDefaults(1449);
				num++;
				item[num].SetDefaults(1345);
				num++;
				item[num].SetDefaults(1450);
				num++;
				item[num++].SetDefaults(2700);
				item[num++].SetDefaults(2738);
				if (Main.hardMode)
				{
					item[num].SetDefaults(970);
					num++;
					item[num].SetDefaults(971);
					num++;
					item[num].SetDefaults(972);
					num++;
					item[num].SetDefaults(973);
					num++;
				}
				break;
			case 14:
				item[num].SetDefaults(771);
				num++;
				if (Main.bloodMoon)
				{
					item[num].SetDefaults(772);
					num++;
				}
				if (!Main.dayTime || Main.eclipse)
				{
					item[num].SetDefaults(773);
					num++;
				}
				if (Main.eclipse)
				{
					item[num].SetDefaults(774);
					num++;
				}
				if (Main.hardMode)
				{
					item[num].SetDefaults(760);
					num++;
				}
				if (Main.hardMode)
				{
					item[num].SetDefaults(1346);
					num++;
				}
				if (Main.halloween)
				{
					item[num].SetDefaults(1743);
					num++;
					item[num].SetDefaults(1744);
					num++;
					item[num].SetDefaults(1745);
					num++;
				}
				break;
			case 15:
			{
				item[num].SetDefaults(1071);
				num++;
				item[num].SetDefaults(1072);
				num++;
				item[num].SetDefaults(1100);
				num++;
				for (int m = 1073; m <= 1084; m++)
				{
					item[num].SetDefaults(m);
					num++;
				}
				item[num].SetDefaults(1097);
				num++;
				item[num].SetDefaults(1099);
				num++;
				item[num].SetDefaults(1098);
				num++;
				item[num].SetDefaults(1966);
				num++;
				if (Main.hardMode)
				{
					item[num].SetDefaults(1967);
					num++;
					item[num].SetDefaults(1968);
					num++;
				}
				item[num].SetDefaults(1490);
				num++;
				if (Main.moonPhase <= 1)
				{
					item[num].SetDefaults(1481);
					num++;
				}
				else if (Main.moonPhase <= 3)
				{
					item[num].SetDefaults(1482);
					num++;
				}
				else if (Main.moonPhase <= 5)
				{
					item[num].SetDefaults(1483);
					num++;
				}
				else
				{
					item[num].SetDefaults(1484);
					num++;
				}
				if (Main.player[Main.myPlayer].zoneBlood)
				{
					item[num].SetDefaults(1492);
					num++;
				}
				if (Main.player[Main.myPlayer].zoneEvil)
				{
					item[num].SetDefaults(1488);
					num++;
				}
				if (Main.player[Main.myPlayer].zoneHoly)
				{
					item[num].SetDefaults(1489);
					num++;
				}
				if (Main.player[Main.myPlayer].zoneJungle)
				{
					item[num].SetDefaults(1486);
					num++;
				}
				if (Main.player[Main.myPlayer].zoneSnow)
				{
					item[num].SetDefaults(1487);
					num++;
				}
				if (Main.sandTiles > 1000)
				{
					item[num].SetDefaults(1491);
					num++;
				}
				if (Main.bloodMoon)
				{
					item[num].SetDefaults(1493);
					num++;
				}
				if ((double)(Main.player[Main.myPlayer].position.Y / 16f) < Main.worldSurface * 0.3499999940395355)
				{
					item[num].SetDefaults(1485);
					num++;
				}
				if ((double)(Main.player[Main.myPlayer].position.Y / 16f) < Main.worldSurface * 0.3499999940395355 && Main.hardMode)
				{
					item[num].SetDefaults(1494);
					num++;
				}
				if (Main.xMas)
				{
					for (int n = 1948; n <= 1957; n++)
					{
						item[num].SetDefaults(n);
						num++;
					}
				}
				for (int num3 = 2158; num3 <= 2160; num3++)
				{
					if (num < 39)
					{
						item[num].SetDefaults(num3);
					}
					num++;
				}
				for (int num4 = 2008; num4 <= 2014; num4++)
				{
					if (num < 39)
					{
						item[num].SetDefaults(num4);
					}
					num++;
				}
				break;
			}
			case 16:
				item[num].SetDefaults(1430);
				num++;
				item[num].SetDefaults(986);
				num++;
				if (Main.hardMode && NPC.downedPlantBoss)
				{
					if (Main.player[Main.myPlayer].HasItem(1157))
					{
						item[num].SetDefaults(1159);
						num++;
						item[num].SetDefaults(1160);
						num++;
						item[num].SetDefaults(1161);
						num++;
						if (!Main.dayTime)
						{
							item[num].SetDefaults(1158);
							num++;
						}
						if (Main.player[Main.myPlayer].zoneJungle)
						{
							item[num].SetDefaults(1167);
							num++;
						}
					}
					item[num].SetDefaults(1339);
					num++;
				}
				if (Main.hardMode && Main.player[Main.myPlayer].zoneJungle)
				{
					item[num].SetDefaults(1171);
					num++;
					if (!Main.dayTime)
					{
						item[num].SetDefaults(1162);
						num++;
					}
				}
				if (Main.hardMode && NPC.downedPlantBoss)
				{
					item[num].SetDefaults(909);
					num++;
					item[num].SetDefaults(910);
					num++;
					item[num].SetDefaults(940);
					num++;
					item[num].SetDefaults(941);
					num++;
					item[num].SetDefaults(942);
					num++;
					item[num].SetDefaults(943);
					num++;
					item[num].SetDefaults(944);
					num++;
					item[num].SetDefaults(945);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1835))
				{
					item[num].SetDefaults(1836);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1258))
				{
					item[num].SetDefaults(1261);
					num++;
				}
				if (Main.halloween)
				{
					item[num].SetDefaults(1791);
					num++;
				}
				break;
			case 17:
			{
				item[num].SetDefaults(928);
				num++;
				item[num].SetDefaults(929);
				num++;
				item[num].SetDefaults(876);
				num++;
				item[num].SetDefaults(877);
				num++;
				item[num].SetDefaults(878);
				num++;
				item[num].SetDefaults(2434);
				num++;
				int num5 = (int)((Main.screenPosition.X + (float)(Main.screenWidth / 2)) / 16f);
				if ((double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 10.0 && (num5 < 380 || num5 > Main.maxTilesX - 380))
				{
					item[num].SetDefaults(1180);
					num++;
				}
				if (Main.hardMode && NPC.downedMechBossAny && NPC.AnyNPCs(208))
				{
					item[num].SetDefaults(1337);
					num++;
				}
				break;
			}
			case 18:
			{
				item[num].SetDefaults(1990);
				num++;
				item[num].SetDefaults(1979);
				num++;
				if (Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					item[num].SetDefaults(1977);
					num++;
				}
				if (Main.player[Main.myPlayer].statManaMax >= 200)
				{
					item[num].SetDefaults(1978);
					num++;
				}
				long num2 = 0L;
				for (int l = 0; l < 54; l++)
				{
					if (Main.player[Main.myPlayer].inventory[l].type == 71)
					{
						num2 += Main.player[Main.myPlayer].inventory[l].stack;
					}
					if (Main.player[Main.myPlayer].inventory[l].type == 72)
					{
						num2 += Main.player[Main.myPlayer].inventory[l].stack * 100;
					}
					if (Main.player[Main.myPlayer].inventory[l].type == 73)
					{
						num2 += Main.player[Main.myPlayer].inventory[l].stack * 10000;
					}
					if (Main.player[Main.myPlayer].inventory[l].type == 74)
					{
						num2 += Main.player[Main.myPlayer].inventory[l].stack * 1000000;
					}
				}
				if (num2 >= 1000000)
				{
					item[num].SetDefaults(1980);
					num++;
				}
				if ((Main.moonPhase % 2 == 0 && Main.dayTime) || (Main.moonPhase % 2 == 1 && !Main.dayTime))
				{
					item[num].SetDefaults(1981);
					num++;
				}
				if (Main.player[Main.myPlayer].team != 0)
				{
					item[num].SetDefaults(1982);
					num++;
				}
				if (Main.hardMode)
				{
					item[num].SetDefaults(1983);
					num++;
				}
				if (NPC.AnyNPCs(208))
				{
					item[num].SetDefaults(1984);
					num++;
				}
				if (Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
				{
					item[num].SetDefaults(1985);
					num++;
				}
				if (Main.hardMode && NPC.downedMechBossAny)
				{
					item[num].SetDefaults(1986);
					num++;
				}
				break;
			}
			case 19:
			{
				for (int j = 0; j < maxItems; j++)
				{
					if (Main.travelShop[j] != 0)
					{
						item[num].netDefaults(Main.travelShop[j]);
						num++;
					}
				}
				break;
			}
			}
			if (Main.player[Main.myPlayer].discount)
			{
				for (int num7 = 0; num7 < num; num7++)
				{
					item[num7].value = (int)((float)item[num7].value * 0.8f);
				}
			}
		}
	}
}
