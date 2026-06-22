using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ObjectData;

namespace Terraria
{
	public class Chest
	{
		public const int maxChestTypes = 52;

		public static int[] chestTypeToIcon = new int[52];

		public static int[] chestItemSpawn = new int[52];

		public const int maxChestTypes2 = 2;

		public static int[] chestTypeToIcon2 = new int[2];

		public static int[] chestItemSpawn2 = new int[2];

		public const int maxDresserTypes = 32;

		public static int[] dresserTypeToIcon = new int[32];

		public static int[] dresserItemSpawn = new int[32];

		public const int maxItems = 40;

		public const int MaxNameLength = 20;

		public Item[] item;

		public int x;

		public int y;

		public bool bankChest;

		public string name;

		public int frameCounter;

		public int frame;

		public Chest(bool bank = false)
		{
			item = new Item[40];
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
			int[] array = chestItemSpawn;
			int[] array2 = chestTypeToIcon;
			array2[0] = (array[0] = 48);
			array2[1] = (array[1] = 306);
			array2[2] = 327;
			array[2] = 306;
			array2[3] = (array[3] = 328);
			array2[4] = 329;
			array[4] = 328;
			array2[5] = (array[5] = 343);
			array2[6] = (array[6] = 348);
			array2[7] = (array[7] = 625);
			array2[8] = (array[8] = 626);
			array2[9] = (array[9] = 627);
			array2[10] = (array[10] = 680);
			array2[11] = (array[11] = 681);
			array2[12] = (array[12] = 831);
			array2[13] = (array[13] = 838);
			array2[14] = (array[14] = 914);
			array2[15] = (array[15] = 952);
			array2[16] = (array[16] = 1142);
			array2[17] = (array[17] = 1298);
			array2[18] = (array[18] = 1528);
			array2[19] = (array[19] = 1529);
			array2[20] = (array[20] = 1530);
			array2[21] = (array[21] = 1531);
			array2[22] = (array[22] = 1532);
			array2[23] = 1533;
			array[23] = 1528;
			array2[24] = 1534;
			array[24] = 1529;
			array2[25] = 1535;
			array[25] = 1530;
			array2[26] = 1536;
			array[26] = 1531;
			array2[27] = 1537;
			array[27] = 1532;
			array2[28] = (array[28] = 2230);
			array2[29] = (array[29] = 2249);
			array2[30] = (array[30] = 2250);
			array2[31] = (array[31] = 2526);
			array2[32] = (array[32] = 2544);
			array2[33] = (array[33] = 2559);
			array2[34] = (array[34] = 2574);
			array2[35] = (array[35] = 2612);
			array2[36] = 327;
			array[36] = 2612;
			array2[37] = (array[37] = 2613);
			array2[38] = 327;
			array[38] = 2613;
			array2[39] = (array[39] = 2614);
			array2[40] = 327;
			array[40] = 2614;
			array2[41] = (array[41] = 2615);
			array2[42] = (array[42] = 2616);
			array2[43] = (array[43] = 2617);
			array2[44] = (array[44] = 2618);
			array2[45] = (array[45] = 2619);
			array2[46] = (array[46] = 2620);
			array2[47] = (array[47] = 2748);
			array2[48] = (array[48] = 2814);
			array2[49] = (array[49] = 3180);
			array2[50] = (array[50] = 3125);
			array2[51] = (array[51] = 3181);
			int[] array3 = chestItemSpawn2;
			int[] array4 = chestTypeToIcon2;
			array4[0] = (array3[0] = 3884);
			array4[1] = (array3[1] = 3885);
			dresserTypeToIcon[0] = (dresserItemSpawn[0] = 334);
			dresserTypeToIcon[1] = (dresserItemSpawn[1] = 647);
			dresserTypeToIcon[2] = (dresserItemSpawn[2] = 648);
			dresserTypeToIcon[3] = (dresserItemSpawn[3] = 649);
			dresserTypeToIcon[4] = (dresserItemSpawn[4] = 918);
			dresserTypeToIcon[5] = (dresserItemSpawn[5] = 2386);
			dresserTypeToIcon[6] = (dresserItemSpawn[6] = 2387);
			dresserTypeToIcon[7] = (dresserItemSpawn[7] = 2388);
			dresserTypeToIcon[8] = (dresserItemSpawn[8] = 2389);
			dresserTypeToIcon[9] = (dresserItemSpawn[9] = 2390);
			dresserTypeToIcon[10] = (dresserItemSpawn[10] = 2391);
			dresserTypeToIcon[11] = (dresserItemSpawn[11] = 2392);
			dresserTypeToIcon[12] = (dresserItemSpawn[12] = 2393);
			dresserTypeToIcon[13] = (dresserItemSpawn[13] = 2394);
			dresserTypeToIcon[14] = (dresserItemSpawn[14] = 2395);
			dresserTypeToIcon[15] = (dresserItemSpawn[15] = 2396);
			dresserTypeToIcon[16] = (dresserItemSpawn[16] = 2529);
			dresserTypeToIcon[17] = (dresserItemSpawn[17] = 2545);
			dresserTypeToIcon[18] = (dresserItemSpawn[18] = 2562);
			dresserTypeToIcon[19] = (dresserItemSpawn[19] = 2577);
			dresserTypeToIcon[20] = (dresserItemSpawn[20] = 2637);
			dresserTypeToIcon[21] = (dresserItemSpawn[21] = 2638);
			dresserTypeToIcon[22] = (dresserItemSpawn[22] = 2639);
			dresserTypeToIcon[23] = (dresserItemSpawn[23] = 2640);
			dresserTypeToIcon[24] = (dresserItemSpawn[24] = 2816);
			dresserTypeToIcon[25] = (dresserItemSpawn[25] = 3132);
			dresserTypeToIcon[26] = (dresserItemSpawn[26] = 3134);
			dresserTypeToIcon[27] = (dresserItemSpawn[27] = 3133);
			dresserTypeToIcon[28] = (dresserItemSpawn[28] = 3911);
			dresserTypeToIcon[29] = (dresserItemSpawn[29] = 3912);
			dresserTypeToIcon[30] = (dresserItemSpawn[30] = 3913);
			dresserTypeToIcon[31] = (dresserItemSpawn[31] = 3914);
		}

		private static bool IsPlayerInChest(int i)
		{
			for (int j = 0; j < 255; j++)
			{
				if (Main.player[j].chest == i)
				{
					return true;
				}
			}
			return false;
		}

		public static bool isLocked(int x, int y)
		{
			if (Main.tile[x, y] == null)
			{
				return true;
			}
			if ((Main.tile[x, y].frameX >= 72 && Main.tile[x, y].frameX <= 106) || (Main.tile[x, y].frameX >= 144 && Main.tile[x, y].frameX <= 178) || (Main.tile[x, y].frameX >= 828 && Main.tile[x, y].frameX <= 1006) || (Main.tile[x, y].frameX >= 1296 && Main.tile[x, y].frameX <= 1330) || (Main.tile[x, y].frameX >= 1368 && Main.tile[x, y].frameX <= 1402) || (Main.tile[x, y].frameX >= 1440 && Main.tile[x, y].frameX <= 1474))
			{
				return true;
			}
			return false;
		}

		public static void ServerPlaceItem(int plr, int slot)
		{
			Main.player[plr].inventory[slot] = PutItemInNearbyChest(Main.player[plr].inventory[slot], Main.player[plr].Center);
			NetMessage.SendData(5, -1, -1, null, plr, slot, (int)Main.player[plr].inventory[slot].prefix);
		}

		public static Item PutItemInNearbyChest(Item item, Vector2 position)
		{
			if (Main.netMode == 1)
			{
				return item;
			}
			for (int i = 0; i < 1000; i++)
			{
				bool flag = false;
				bool flag2 = false;
				if (Main.chest[i] == null || IsPlayerInChest(i) || isLocked(Main.chest[i].x, Main.chest[i].y) || !((new Vector2(Main.chest[i].x * 16 + 16, Main.chest[i].y * 16 + 16) - position).Length() < 200f))
				{
					continue;
				}
				for (int j = 0; j < Main.chest[i].item.Length; j++)
				{
					if (Main.chest[i].item[j].type > 0 && Main.chest[i].item[j].stack > 0)
					{
						if (!item.IsTheSameAs(Main.chest[i].item[j]))
						{
							continue;
						}
						flag = true;
						int num = Main.chest[i].item[j].maxStack - Main.chest[i].item[j].stack;
						if (num > 0)
						{
							if (num > item.stack)
							{
								num = item.stack;
							}
							item.stack -= num;
							Main.chest[i].item[j].stack += num;
							if (item.stack <= 0)
							{
								item.SetDefaults();
								return item;
							}
						}
					}
					else
					{
						flag2 = true;
					}
				}
				if (!(flag && flag2) || item.stack <= 0)
				{
					continue;
				}
				for (int k = 0; k < Main.chest[i].item.Length; k++)
				{
					if (Main.chest[i].item[k].type == 0 || Main.chest[i].item[k].stack == 0)
					{
						Main.chest[i].item[k] = item.Clone();
						item.SetDefaults();
						return item;
					}
				}
			}
			return item;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public static bool Unlock(int X, int Y)
		{
			if (Main.tile[X, Y] == null)
			{
				return false;
			}
			short num;
			int type;
			switch (Main.tile[X, Y].frameX / 36)
			{
			case 2:
				num = 36;
				type = 11;
				AchievementsHelper.NotifyProgressionEvent(19);
				break;
			case 4:
				num = 36;
				type = 11;
				break;
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
				if (!NPC.downedPlantBoss)
				{
					return false;
				}
				num = 180;
				type = 11;
				AchievementsHelper.NotifyProgressionEvent(20);
				break;
			case 36:
			case 38:
			case 40:
				num = 36;
				type = 11;
				break;
			default:
				return false;
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
			return true;
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

		public static int FindChestByGuessing(int X, int Y)
		{
			for (int i = 0; i < 1000; i++)
			{
				if (Main.chest[i] != null && Main.chest[i].x >= X && Main.chest[i].x < X + 2 && Main.chest[i].y >= Y && Main.chest[i].y < Y + 2)
				{
					return i;
				}
			}
			return -1;
		}

		public static int FindEmptyChest(int x, int y, int type = 21, int style = 0, int direction = 1)
		{
			int num = -1;
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest != null)
				{
					if (chest.x == x && chest.y == y)
					{
						return -1;
					}
				}
				else if (num == -1)
				{
					num = i;
				}
			}
			return num;
		}

		public static bool NearOtherChests(int x, int y)
		{
			for (int i = x - 25; i < x + 25; i++)
			{
				for (int j = y - 8; j < y + 8; j++)
				{
					Tile tileSafely = Framing.GetTileSafely(i, j);
					if (tileSafely.active() && TileID.Sets.BasicChest[tileSafely.type])
					{
						return true;
					}
				}
			}
			return false;
		}

		public static int AfterPlacement_Hook(int x, int y, int type = 21, int style = 0, int direction = 1)
		{
			Point16 baseCoords = new Point16(x, y);
			TileObjectData.OriginToTopLeft(type, style, ref baseCoords);
			int num = FindEmptyChest(baseCoords.X, baseCoords.Y);
			if (num == -1)
			{
				return -1;
			}
			if (Main.netMode != 1)
			{
				Chest chest = new Chest();
				chest.x = baseCoords.X;
				chest.y = baseCoords.Y;
				for (int i = 0; i < 40; i++)
				{
					chest.item[i] = new Item();
				}
				Main.chest[num] = chest;
			}
			else
			{
				switch (type)
				{
				case 21:
					NetMessage.SendData(34, -1, -1, null, 0, x, y, style);
					break;
				case 467:
					NetMessage.SendData(34, -1, -1, null, 4, x, y, style);
					break;
				default:
					NetMessage.SendData(34, -1, -1, null, 2, x, y, style);
					break;
				}
			}
			return num;
		}

		public static int CreateChest(int X, int Y, int id = -1)
		{
			int num = id;
			if (num == -1)
			{
				num = FindEmptyChest(X, Y);
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
			for (int i = 0; i < 40; i++)
			{
				Main.chest[num].item[i] = new Item();
			}
			return num;
		}

		public static bool CanDestroyChest(int X, int Y)
		{
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest == null || chest.x != X || chest.y != Y)
				{
					continue;
				}
				for (int j = 0; j < 40; j++)
				{
					if (chest.item[j] != null && chest.item[j].type > 0 && chest.item[j].stack > 0)
					{
						return false;
					}
				}
				return true;
			}
			return true;
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
				for (int j = 0; j < 40; j++)
				{
					if (chest.item[j] != null && chest.item[j].type > 0 && chest.item[j].stack > 0)
					{
						return false;
					}
				}
				Main.chest[i] = null;
				if (Main.player[Main.myPlayer].chest == i)
				{
					Main.player[Main.myPlayer].chest = -1;
				}
				Recipe.FindRecipes();
				return true;
			}
			return true;
		}

		public static void DestroyChestDirect(int X, int Y, int id)
		{
			if (id < 0 || id >= Main.chest.Length)
			{
				return;
			}
			try
			{
				Chest chest = Main.chest[id];
				if (chest != null && chest.x == X && chest.y == Y)
				{
					Main.chest[id] = null;
					if (Main.player[Main.myPlayer].chest == id)
					{
						Main.player[Main.myPlayer].chest = -1;
					}
					Recipe.FindRecipes();
				}
			}
			catch
			{
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
				item[i].favorited = false;
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
			for (int i = 0; i < 40; i++)
			{
				Main.travelShop[i] = 0;
			}
			int num = Main.rand.Next(4, 7);
			if (Main.rand.Next(4) == 0)
			{
				num++;
			}
			if (Main.rand.Next(8) == 0)
			{
				num++;
			}
			if (Main.rand.Next(16) == 0)
			{
				num++;
			}
			if (Main.rand.Next(32) == 0)
			{
				num++;
			}
			if (Main.expertMode && Main.rand.Next(2) == 0)
			{
				num++;
			}
			int num2 = 0;
			int num3 = 0;
			int[] array = new int[6] { 100, 200, 300, 400, 500, 600 };
			while (num3 < num)
			{
				int num4 = 0;
				if (Main.rand.Next(array[4]) == 0)
				{
					num4 = 3309;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num4 = 3314;
				}
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
				if (Main.rand.Next(array[3]) == 0)
				{
					num4 = 3628;
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
				if (Main.rand.Next(array[2]) == 0 && NPC.downedBoss1)
				{
					num4 = 3262;
				}
				if (Main.rand.Next(array[2]) == 0 && NPC.downedMechBossAny)
				{
					num4 = 3284;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.hardMode && NPC.downedMoonlord)
				{
					num4 = 3596;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.hardMode && NPC.downedMartians)
				{
					num4 = 2865;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.hardMode && NPC.downedMartians)
				{
					num4 = 2866;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.hardMode && NPC.downedMartians)
				{
					num4 = 2867;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.xMas)
				{
					num4 = 3055;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.xMas)
				{
					num4 = 3056;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.xMas)
				{
					num4 = 3057;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.xMas)
				{
					num4 = 3058;
				}
				if (Main.rand.Next(array[2]) == 0 && Main.xMas)
				{
					num4 = 3059;
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
					num4 = 3624;
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
				if (Main.rand.Next(array[0]) == 0)
				{
					num4 = 3637;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num4 = 3119;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num4 = 3118;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num4 = 3099;
				}
				if (num4 != 0)
				{
					for (int j = 0; j < 40; j++)
					{
						if (Main.travelShop[j] == num4)
						{
							num4 = 0;
							break;
						}
						if (num4 == 3637)
						{
							int num5 = Main.travelShop[j];
							if ((uint)(num5 - 3621) <= 1u || (uint)(num5 - 3633) <= 9u)
							{
								num4 = 0;
							}
							if (num4 == 0)
							{
								break;
							}
						}
					}
				}
				if (num4 == 0)
				{
					continue;
				}
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
				if (num4 == 3637)
				{
					num2--;
					switch (Main.rand.Next(6))
					{
					case 0:
						Main.travelShop[num2++] = 3637;
						Main.travelShop[num2++] = 3642;
						break;
					case 1:
						Main.travelShop[num2++] = 3621;
						Main.travelShop[num2++] = 3622;
						break;
					case 2:
						Main.travelShop[num2++] = 3634;
						Main.travelShop[num2++] = 3639;
						break;
					case 3:
						Main.travelShop[num2++] = 3633;
						Main.travelShop[num2++] = 3638;
						break;
					case 4:
						Main.travelShop[num2++] = 3635;
						Main.travelShop[num2++] = 3640;
						break;
					case 5:
						Main.travelShop[num2++] = 3636;
						Main.travelShop[num2++] = 3641;
						break;
					}
				}
			}
		}

		public void SetupShop(int type)
		{
			for (int i = 0; i < 40; i++)
			{
				item[i] = new Item();
			}
			int num = 0;
			switch (type)
			{
			case 1:
			{
				item[num].SetDefaults(88);
				num++;
				item[num].SetDefaults(87);
				num++;
				item[num].SetDefaults(35);
				num++;
				item[num].SetDefaults(1991);
				num++;
				item[num].SetDefaults(3509);
				num++;
				item[num].SetDefaults(3506);
				num++;
				item[num].SetDefaults(8);
				num++;
				item[num].SetDefaults(28);
				num++;
				item[num].SetDefaults(110);
				num++;
				item[num].SetDefaults(40);
				num++;
				item[num].SetDefaults(42);
				num++;
				item[num].SetDefaults(965);
				num++;
				if (Main.player[Main.myPlayer].ZoneSnow)
				{
					item[num].SetDefaults(967);
					num++;
				}
				if (Main.bloodMoon)
				{
					item[num].SetDefaults(279);
					num++;
				}
				if (!Main.dayTime)
				{
					item[num].SetDefaults(282);
					num++;
				}
				if (NPC.downedBoss3)
				{
					item[num].SetDefaults(346);
					num++;
				}
				if (Main.hardMode)
				{
					item[num].SetDefaults(488);
					num++;
				}
				for (int n = 0; n < 58; n++)
				{
					if (Main.player[Main.myPlayer].inventory[n].type == 930)
					{
						item[num].SetDefaults(931);
						num++;
						item[num].SetDefaults(1614);
						num++;
						break;
					}
				}
				item[num].SetDefaults(1786);
				num++;
				if (Main.hardMode)
				{
					item[num].SetDefaults(1348);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(3107))
				{
					item[num].SetDefaults(3108);
					num++;
				}
				if (Main.halloween)
				{
					item[num++].SetDefaults(3242);
					item[num++].SetDefaults(3243);
					item[num++].SetDefaults(3244);
				}
				break;
			}
			case 2:
				item[num].SetDefaults(97);
				num++;
				if (Main.bloodMoon || Main.hardMode)
				{
					item[num].SetDefaults(278);
					num++;
				}
				if ((NPC.downedBoss2 && !Main.dayTime) || Main.hardMode)
				{
					item[num].SetDefaults(47);
					num++;
				}
				item[num].SetDefaults(95);
				num++;
				item[num].SetDefaults(98);
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
				if (Main.player[Main.myPlayer].HasItem(3107))
				{
					item[num].SetDefaults(3108);
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
						item[num].SetDefaults(2886);
						num++;
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
					item[num].SetDefaults(66);
					num++;
					item[num].SetDefaults(62);
					num++;
					item[num].SetDefaults(63);
					num++;
				}
				item[num].SetDefaults(27);
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
				if (NPC.downedSlimeKing)
				{
					item[num].SetDefaults(3215);
					num++;
				}
				if (NPC.downedQueenBee)
				{
					item[num].SetDefaults(3216);
					num++;
				}
				if (NPC.downedBoss1)
				{
					item[num].SetDefaults(3219);
					num++;
				}
				if (NPC.downedBoss2)
				{
					if (WorldGen.crimson)
					{
						item[num].SetDefaults(3218);
						num++;
					}
					else
					{
						item[num].SetDefaults(3217);
						num++;
					}
				}
				if (NPC.downedBoss3)
				{
					item[num].SetDefaults(3220);
					num++;
					item[num].SetDefaults(3221);
					num++;
				}
				if (Main.hardMode)
				{
					item[num].SetDefaults(3222);
					num++;
				}
				break;
			case 4:
				item[num].SetDefaults(168);
				num++;
				item[num].SetDefaults(166);
				num++;
				item[num].SetDefaults(167);
				num++;
				if (Main.hardMode)
				{
					item[num].SetDefaults(265);
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
					if (!Main.dayTime)
					{
						item[num++].SetDefaults(1288);
						item[num++].SetDefaults(1289);
					}
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
					if (!Main.dayTime)
					{
						item[num++].SetDefaults(3362);
						item[num++].SetDefaults(3363);
					}
				}
				if (NPC.downedAncientCultist)
				{
					if (Main.dayTime)
					{
						item[num++].SetDefaults(2856);
						item[num++].SetDefaults(2858);
					}
					else
					{
						item[num++].SetDefaults(2857);
						item[num++].SetDefaults(2859);
					}
				}
				if (NPC.AnyNPCs(441))
				{
					item[num++].SetDefaults(3242);
					item[num++].SetDefaults(3243);
					item[num++].SetDefaults(3244);
				}
				if (Main.player[Main.myPlayer].ZoneSnow)
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
				if (Main.halloween)
				{
					item[num++].SetDefaults(3246);
					item[num++].SetDefaults(3247);
				}
				if (BirthdayParty.PartyIsUp)
				{
					item[num++].SetDefaults(3730);
					item[num++].SetDefaults(3731);
					item[num++].SetDefaults(3733);
					item[num++].SetDefaults(3734);
					item[num++].SetDefaults(3735);
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
				item[num].SetDefaults(3186);
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
				item[num].SetDefaults(3612);
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
				item[num++].SetDefaults(3707);
				item[num].SetDefaults(2739);
				num++;
				item[num].SetDefaults(849);
				num++;
				item[num++].SetDefaults(3616);
				item[num++].SetDefaults(2799);
				item[num++].SetDefaults(3619);
				item[num++].SetDefaults(3627);
				item[num++].SetDefaults(3629);
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
				for (int num5 = 1873; num5 < 1906; num5++)
				{
					item[num].SetDefaults(num5);
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
				if (NPC.downedGolemBoss)
				{
					item[num].SetDefaults(948);
					num++;
				}
				item[num++].SetDefaults(3623);
				item[num++].SetDefaults(3603);
				item[num++].SetDefaults(3604);
				item[num++].SetDefaults(3607);
				item[num++].SetDefaults(3605);
				item[num++].SetDefaults(3606);
				item[num++].SetDefaults(3608);
				item[num++].SetDefaults(3618);
				item[num++].SetDefaults(3602);
				item[num++].SetDefaults(3663);
				item[num++].SetDefaults(3609);
				item[num++].SetDefaults(3610);
				item[num].SetDefaults(995);
				num++;
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
				else if (Main.player[Main.myPlayer].ZoneHoly)
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
				item[num].SetDefaults(2874);
				num++;
				item[num].SetDefaults(1120);
				num++;
				if (Main.netMode == 1)
				{
					item[num].SetDefaults(1969);
					num++;
				}
				if (Main.halloween)
				{
					item[num].SetDefaults(3248);
					num++;
					item[num].SetDefaults(1741);
					num++;
				}
				if (Main.moonPhase == 0)
				{
					item[num].SetDefaults(2871);
					num++;
					item[num].SetDefaults(2872);
					num++;
				}
				break;
			case 13:
				item[num].SetDefaults(859);
				num++;
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
				item[num++].SetDefaults(3253);
				item[num++].SetDefaults(2700);
				item[num++].SetDefaults(2738);
				if (Main.player[Main.myPlayer].HasItem(3548))
				{
					item[num].SetDefaults(3548);
					num++;
				}
				if (NPC.AnyNPCs(229))
				{
					item[num++].SetDefaults(3369);
				}
				if (Main.hardMode)
				{
					item[num].SetDefaults(3214);
					num++;
					item[num].SetDefaults(2868);
					num++;
					item[num].SetDefaults(970);
					num++;
					item[num].SetDefaults(971);
					num++;
					item[num].SetDefaults(972);
					num++;
					item[num].SetDefaults(973);
					num++;
				}
				item[num++].SetDefaults(3747);
				item[num++].SetDefaults(3732);
				item[num++].SetDefaults(3742);
				if (BirthdayParty.PartyIsUp)
				{
					item[num++].SetDefaults(3749);
					item[num++].SetDefaults(3746);
					item[num++].SetDefaults(3739);
					item[num++].SetDefaults(3740);
					item[num++].SetDefaults(3741);
					item[num++].SetDefaults(3737);
					item[num++].SetDefaults(3738);
					item[num++].SetDefaults(3736);
					item[num++].SetDefaults(3745);
					item[num++].SetDefaults(3744);
					item[num++].SetDefaults(3743);
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
				if (NPC.downedMartians)
				{
					item[num++].SetDefaults(2862);
					item[num++].SetDefaults(3109);
				}
				if (Main.player[Main.myPlayer].HasItem(3384) || Main.player[Main.myPlayer].HasItem(3664))
				{
					item[num].SetDefaults(3664);
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
				for (int j = 1073; j <= 1084; j++)
				{
					item[num].SetDefaults(j);
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
				if (Main.player[Main.myPlayer].ZoneCrimson)
				{
					item[num].SetDefaults(1492);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneCorrupt)
				{
					item[num].SetDefaults(1488);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneHoly)
				{
					item[num].SetDefaults(1489);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneJungle)
				{
					item[num].SetDefaults(1486);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneSnow)
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
					for (int k = 1948; k <= 1957; k++)
					{
						item[num].SetDefaults(k);
						num++;
					}
				}
				for (int l = 2158; l <= 2160; l++)
				{
					if (num < 39)
					{
						item[num].SetDefaults(l);
					}
					num++;
				}
				for (int m = 2008; m <= 2014; m++)
				{
					if (num < 39)
					{
						item[num].SetDefaults(m);
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
				if (NPC.AnyNPCs(108))
				{
					item[num++].SetDefaults(2999);
				}
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
						if (Main.player[Main.myPlayer].ZoneJungle)
						{
							item[num].SetDefaults(1167);
							num++;
						}
					}
					item[num].SetDefaults(1339);
					num++;
				}
				if (Main.hardMode && Main.player[Main.myPlayer].ZoneJungle)
				{
					item[num].SetDefaults(1171);
					num++;
					if (!Main.dayTime)
					{
						item[num].SetDefaults(1162);
						num++;
					}
				}
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
				int num3 = (int)((Main.screenPosition.X + (float)(Main.screenWidth / 2)) / 16f);
				if ((double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 10.0 && (num3 < 380 || num3 > Main.maxTilesX - 380))
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
				long num6 = 0L;
				for (int num7 = 0; num7 < 54; num7++)
				{
					if (Main.player[Main.myPlayer].inventory[num7].type == 71)
					{
						num6 += Main.player[Main.myPlayer].inventory[num7].stack;
					}
					if (Main.player[Main.myPlayer].inventory[num7].type == 72)
					{
						num6 += Main.player[Main.myPlayer].inventory[num7].stack * 100;
					}
					if (Main.player[Main.myPlayer].inventory[num7].type == 73)
					{
						num6 += Main.player[Main.myPlayer].inventory[num7].stack * 10000;
					}
					if (Main.player[Main.myPlayer].inventory[num7].type == 74)
					{
						num6 += Main.player[Main.myPlayer].inventory[num7].stack * 1000000;
					}
				}
				if (num6 >= 1000000)
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
				if (Main.hardMode && NPC.downedMartians)
				{
					item[num].SetDefaults(2863);
					num++;
					item[num].SetDefaults(3259);
					num++;
				}
				break;
			}
			case 19:
			{
				for (int num4 = 0; num4 < 40; num4++)
				{
					if (Main.travelShop[num4] != 0)
					{
						item[num].netDefaults(Main.travelShop[num4]);
						num++;
					}
				}
				break;
			}
			case 20:
				if (Main.moonPhase % 2 == 0)
				{
					item[num].SetDefaults(3001);
				}
				else
				{
					item[num].SetDefaults(28);
				}
				num++;
				if (!Main.dayTime || Main.moonPhase == 0)
				{
					item[num].SetDefaults(3002);
				}
				else
				{
					item[num].SetDefaults(282);
				}
				num++;
				if (Main.time % 60.0 * 60.0 * 6.0 <= 10800.0)
				{
					item[num].SetDefaults(3004);
				}
				else
				{
					item[num].SetDefaults(8);
				}
				num++;
				if (Main.moonPhase == 0 || Main.moonPhase == 1 || Main.moonPhase == 4 || Main.moonPhase == 5)
				{
					item[num].SetDefaults(3003);
				}
				else
				{
					item[num].SetDefaults(40);
				}
				num++;
				if (Main.moonPhase % 4 == 0)
				{
					item[num].SetDefaults(3310);
				}
				else if (Main.moonPhase % 4 == 1)
				{
					item[num].SetDefaults(3313);
				}
				else if (Main.moonPhase % 4 == 2)
				{
					item[num].SetDefaults(3312);
				}
				else
				{
					item[num].SetDefaults(3311);
				}
				num++;
				item[num].SetDefaults(166);
				num++;
				item[num].SetDefaults(965);
				num++;
				if (Main.hardMode)
				{
					if (Main.moonPhase < 4)
					{
						item[num].SetDefaults(3316);
					}
					else
					{
						item[num].SetDefaults(3315);
					}
					num++;
					item[num].SetDefaults(3334);
					num++;
					if (Main.bloodMoon)
					{
						item[num].SetDefaults(3258);
						num++;
					}
				}
				if (Main.moonPhase == 0 && !Main.dayTime)
				{
					item[num].SetDefaults(3043);
					num++;
				}
				break;
			case 21:
			{
				bool flag = Main.hardMode && NPC.downedMechBossAny;
				bool num2 = Main.hardMode && NPC.downedGolemBoss;
				item[num].SetDefaults(353);
				num++;
				item[num].SetDefaults(3828);
				if (num2)
				{
					item[num].shopCustomPrice = Item.buyPrice(0, 4);
				}
				else if (flag)
				{
					item[num].shopCustomPrice = Item.buyPrice(0, 1);
				}
				else
				{
					item[num].shopCustomPrice = Item.buyPrice(0, 0, 25);
				}
				num++;
				item[num].SetDefaults(3816);
				num++;
				item[num].SetDefaults(3813);
				item[num].shopCustomPrice = 75;
				item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				num++;
				num = 10;
				item[num].SetDefaults(3818);
				item[num].shopCustomPrice = 5;
				item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				num++;
				item[num].SetDefaults(3824);
				item[num].shopCustomPrice = 5;
				item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				num++;
				item[num].SetDefaults(3832);
				item[num].shopCustomPrice = 5;
				item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				num++;
				item[num].SetDefaults(3829);
				item[num].shopCustomPrice = 5;
				item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				if (flag)
				{
					num = 20;
					item[num].SetDefaults(3819);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3825);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3833);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3830);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				}
				if (num2)
				{
					num = 30;
					item[num].SetDefaults(3820);
					item[num].shopCustomPrice = 100;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3826);
					item[num].shopCustomPrice = 100;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3834);
					item[num].shopCustomPrice = 100;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3831);
					item[num].shopCustomPrice = 100;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
				}
				if (flag)
				{
					num = 4;
					item[num].SetDefaults(3800);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3801);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3802);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					num = 14;
					item[num].SetDefaults(3797);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3798);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3799);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					num = 24;
					item[num].SetDefaults(3803);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3804);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3805);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					num = 34;
					item[num].SetDefaults(3806);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3807);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3808);
					item[num].shopCustomPrice = 25;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
				}
				if (num2)
				{
					num = 7;
					item[num].SetDefaults(3871);
					item[num].shopCustomPrice = 75;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3872);
					item[num].shopCustomPrice = 75;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3873);
					item[num].shopCustomPrice = 75;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					num = 17;
					item[num].SetDefaults(3874);
					item[num].shopCustomPrice = 75;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3875);
					item[num].shopCustomPrice = 75;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3876);
					item[num].shopCustomPrice = 75;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					num = 27;
					item[num].SetDefaults(3877);
					item[num].shopCustomPrice = 75;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3878);
					item[num].shopCustomPrice = 75;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3879);
					item[num].shopCustomPrice = 75;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					num = 37;
					item[num].SetDefaults(3880);
					item[num].shopCustomPrice = 75;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3881);
					item[num].shopCustomPrice = 75;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
					item[num].SetDefaults(3882);
					item[num].shopCustomPrice = 75;
					item[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
					num++;
				}
				break;
			}
			}
			if (Main.player[Main.myPlayer].discount)
			{
				for (int num8 = 0; num8 < num; num8++)
				{
					item[num8].value = (int)((float)item[num8].value * 0.8f);
				}
			}
		}

		public static void UpdateChestFrames()
		{
			bool[] array = new bool[1000];
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active && Main.player[i].chest >= 0 && Main.player[i].chest < 1000)
				{
					array[Main.player[i].chest] = true;
				}
			}
			Chest chest = null;
			for (int j = 0; j < 1000; j++)
			{
				chest = Main.chest[j];
				if (chest != null)
				{
					if (array[j])
					{
						chest.frameCounter++;
					}
					else
					{
						chest.frameCounter--;
					}
					if (chest.frameCounter < 0)
					{
						chest.frameCounter = 0;
					}
					if (chest.frameCounter > 10)
					{
						chest.frameCounter = 10;
					}
					if (chest.frameCounter == 0)
					{
						chest.frame = 0;
					}
					else if (chest.frameCounter == 10)
					{
						chest.frame = 2;
					}
					else
					{
						chest.frame = 1;
					}
				}
			}
		}
	}
}
