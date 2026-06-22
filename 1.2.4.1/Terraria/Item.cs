using System;
using Microsoft.Xna.Framework;

namespace Terraria
{
	public class Item
	{
		public const int maxPrefixes = 84;

		public static int potionDelay = 3600;

		public bool questItem;

		public static int[] headType = new int[169];

		public static int[] bodyType = new int[175];

		public static int[] legType = new int[110];

		public bool flame;

		public bool mech;

		public bool wet;

		public bool honeyWet;

		public byte wetCount;

		public bool lavaWet;

		public Vector2 position;

		public Vector2 velocity;

		public int width;

		public int height;

		public bool active;

		public int noGrabDelay;

		public bool beingGrabbed;

		public int spawnTime;

		public int tileWand = -1;

		public bool wornArmor;

		public byte dye;

		public int fishingPole = 1;

		public int bait;

		public static int manaGrabRange = 300;

		public static int lifeGrabRange = 250;

		public short makeNPC;

		public short hairDye = -1;

		public byte paint;

		public int ownIgnore = -1;

		public int ownTime;

		public int keepTime;

		public int type;

		public string name;

		public int holdStyle;

		public int useStyle;

		public bool channel;

		public bool accessory;

		public int useAnimation;

		public int useTime;

		public int stack;

		public int maxStack;

		public int pick;

		public int axe;

		public int hammer;

		public int tileBoost;

		public int createTile = -1;

		public int createWall = -1;

		public int placeStyle;

		public int damage;

		public float knockBack;

		public int healLife;

		public int healMana;

		public bool potion;

		public bool consumable;

		public bool autoReuse;

		public bool useTurn;

		public Color color;

		public int alpha;

		public float scale = 1f;

		public int useSound;

		public int defense;

		public int headSlot = -1;

		public int bodySlot = -1;

		public int legSlot = -1;

		public sbyte handOnSlot = -1;

		public sbyte handOffSlot = -1;

		public sbyte backSlot = -1;

		public sbyte frontSlot = -1;

		public sbyte shoeSlot = -1;

		public sbyte waistSlot = -1;

		public sbyte wingSlot = -1;

		public sbyte shieldSlot = -1;

		public sbyte neckSlot = -1;

		public sbyte faceSlot = -1;

		public sbyte balloonSlot = -1;

		public string toolTip;

		public string toolTip2;

		public int owner = 255;

		public int rare;

		public int shoot;

		public float shootSpeed;

		public int ammo;

		public bool notAmmo;

		public int useAmmo;

		public int lifeRegen;

		public int manaIncrease;

		public bool buyOnce;

		public int mana;

		public bool noUseGraphic;

		public bool noMelee;

		public int release;

		public int value;

		public bool buy;

		public bool social;

		public bool vanity;

		public bool material;

		public bool noWet;

		public int buffType;

		public int buffTime;

		public int mountType = -1;

		public bool cartTrack;

		public bool uniqueStack;

		public int netID;

		public int crit;

		public byte prefix;

		public bool melee;

		public bool magic;

		public bool ranged;

		public bool summon;

		public int reuseDelay;

		public override string ToString()
		{
			return $"{{Name: \"{name}\" NetID: {netID} Stack: {stack}";
		}

		public bool Prefix(int pre)
		{
			if (pre == 0 || type == 0)
			{
				return false;
			}
			if (Main.rand == null)
			{
				Main.rand = new Random();
			}
			int num = pre;
			float num2 = 1f;
			float num3 = 1f;
			float num4 = 1f;
			float num5 = 1f;
			float num6 = 1f;
			float num7 = 1f;
			int num8 = 0;
			bool flag = true;
			while (flag)
			{
				num2 = 1f;
				num3 = 1f;
				num4 = 1f;
				num5 = 1f;
				num6 = 1f;
				num7 = 1f;
				num8 = 0;
				flag = false;
				if (num == -1 && Main.rand.Next(4) == 0)
				{
					num = 0;
				}
				if (pre < -1)
				{
					num = -1;
				}
				if (num == -1 || num == -2 || num == -3)
				{
					if (type == 1 || type == 4 || type == 6 || type == 7 || type == 10 || type == 24 || type == 45 || type == 46 || type == 65 || type == 103 || type == 104 || type == 121 || type == 122 || type == 155 || type == 190 || type == 196 || type == 198 || type == 199 || type == 200 || type == 201 || type == 202 || type == 203 || type == 204 || type == 213 || type == 217 || type == 273 || type == 367 || type == 368 || type == 426 || type == 482 || type == 483 || type == 484 || type == 653 || type == 654 || type == 656 || type == 657 || type == 659 || type == 660 || type == 671 || type == 672 || type == 674 || type == 675 || type == 676 || type == 723 || type == 724 || type == 757 || type == 776 || type == 777 || type == 778 || type == 787 || type == 795 || type == 797 || type == 798 || type == 799 || type == 881 || type == 882 || type == 921 || type == 922 || type == 989 || type == 990 || type == 991 || type == 992 || type == 993 || type == 1123 || type == 1166 || type == 1185 || type == 1188 || type == 1192 || type == 1195 || type == 1199 || type == 1202 || type == 1222 || type == 1223 || type == 1224 || type == 1226 || type == 1227 || type == 1230 || type == 1233 || type == 1234 || type == 1294 || type == 1304 || type == 1305 || type == 1306 || type == 1320 || type == 1327 || type == 1506 || type == 1507 || type == 1786 || type == 1826 || type == 1827 || type == 1909 || type == 1917 || type == 1928 || type == 2176 || type == 2273 || type == 2608 || type == 2341 || type == 2330 || type == 2320 || type == 2516 || type == 2517 || type == 2746 || type == 2745)
					{
						int num9 = Main.rand.Next(40);
						if (num9 == 0)
						{
							num = 1;
						}
						if (num9 == 1)
						{
							num = 2;
						}
						if (num9 == 2)
						{
							num = 3;
						}
						if (num9 == 3)
						{
							num = 4;
						}
						if (num9 == 4)
						{
							num = 5;
						}
						if (num9 == 5)
						{
							num = 6;
						}
						if (num9 == 6)
						{
							num = 7;
						}
						if (num9 == 7)
						{
							num = 8;
						}
						if (num9 == 8)
						{
							num = 9;
						}
						if (num9 == 9)
						{
							num = 10;
						}
						if (num9 == 10)
						{
							num = 11;
						}
						if (num9 == 11)
						{
							num = 12;
						}
						if (num9 == 12)
						{
							num = 13;
						}
						if (num9 == 13)
						{
							num = 14;
						}
						if (num9 == 14)
						{
							num = 15;
						}
						if (num9 == 15)
						{
							num = 36;
						}
						if (num9 == 16)
						{
							num = 37;
						}
						if (num9 == 17)
						{
							num = 38;
						}
						if (num9 == 18)
						{
							num = 53;
						}
						if (num9 == 19)
						{
							num = 54;
						}
						if (num9 == 20)
						{
							num = 55;
						}
						if (num9 == 21)
						{
							num = 39;
						}
						if (num9 == 22)
						{
							num = 40;
						}
						if (num9 == 23)
						{
							num = 56;
						}
						if (num9 == 24)
						{
							num = 41;
						}
						if (num9 == 25)
						{
							num = 57;
						}
						if (num9 == 26)
						{
							num = 42;
						}
						if (num9 == 27)
						{
							num = 43;
						}
						if (num9 == 28)
						{
							num = 44;
						}
						if (num9 == 29)
						{
							num = 45;
						}
						if (num9 == 30)
						{
							num = 46;
						}
						if (num9 == 31)
						{
							num = 47;
						}
						if (num9 == 32)
						{
							num = 48;
						}
						if (num9 == 33)
						{
							num = 49;
						}
						if (num9 == 34)
						{
							num = 50;
						}
						if (num9 == 35)
						{
							num = 51;
						}
						if (num9 == 36)
						{
							num = 59;
						}
						if (num9 == 37)
						{
							num = 60;
						}
						if (num9 == 38)
						{
							num = 61;
						}
						if (num9 == 39)
						{
							num = 81;
						}
					}
					else if (type == 162 || type == 160 || type == 163 || type == 220 || type == 274 || type == 277 || type == 280 || type == 383 || type == 384 || type == 385 || type == 386 || type == 387 || type == 388 || type == 389 || type == 390 || type == 406 || type == 537 || type == 550 || type == 579 || type == 756 || type == 759 || type == 801 || type == 802 || type == 1186 || type == 1189 || type == 1190 || type == 1193 || type == 1196 || type == 1197 || type == 1200 || type == 1203 || type == 1204 || type == 1228 || type == 1231 || type == 1232 || type == 1259 || type == 1262 || type == 1297 || type == 1314 || type == 1325 || type == 1947 || type == 2332 || type == 2331 || type == 2342 || type == 2424 || type == 2611)
					{
						int num10 = Main.rand.Next(14);
						if (num10 == 0)
						{
							num = 36;
						}
						if (num10 == 1)
						{
							num = 37;
						}
						if (num10 == 2)
						{
							num = 38;
						}
						if (num10 == 3)
						{
							num = 53;
						}
						if (num10 == 4)
						{
							num = 54;
						}
						if (num10 == 5)
						{
							num = 55;
						}
						if (num10 == 6)
						{
							num = 39;
						}
						if (num10 == 7)
						{
							num = 40;
						}
						if (num10 == 8)
						{
							num = 56;
						}
						if (num10 == 9)
						{
							num = 41;
						}
						if (num10 == 10)
						{
							num = 57;
						}
						if (num10 == 11)
						{
							num = 59;
						}
						if (num10 == 12)
						{
							num = 60;
						}
						if (num10 == 13)
						{
							num = 61;
						}
					}
					else if (type == 39 || type == 44 || type == 95 || type == 96 || type == 98 || type == 99 || type == 120 || type == 164 || type == 197 || type == 219 || type == 266 || type == 281 || type == 434 || type == 435 || type == 436 || type == 481 || type == 506 || type == 533 || type == 534 || type == 578 || type == 655 || type == 658 || type == 661 || type == 679 || type == 682 || type == 725 || type == 758 || type == 759 || type == 760 || type == 796 || type == 800 || type == 905 || type == 923 || type == 964 || type == 986 || type == 1156 || type == 1187 || type == 1194 || type == 1201 || type == 1229 || type == 1254 || type == 1255 || type == 1258 || type == 1265 || type == 1319 || type == 1553 || type == 1782 || type == 1784 || type == 1835 || type == 1870 || type == 1910 || type == 1929 || type == 1946 || type == 2223 || type == 2269 || type == 2270 || type == 2624 || type == 2515 || type == 2747)
					{
						int num11 = Main.rand.Next(36);
						if (num11 == 0)
						{
							num = 16;
						}
						if (num11 == 1)
						{
							num = 17;
						}
						if (num11 == 2)
						{
							num = 18;
						}
						if (num11 == 3)
						{
							num = 19;
						}
						if (num11 == 4)
						{
							num = 20;
						}
						if (num11 == 5)
						{
							num = 21;
						}
						if (num11 == 6)
						{
							num = 22;
						}
						if (num11 == 7)
						{
							num = 23;
						}
						if (num11 == 8)
						{
							num = 24;
						}
						if (num11 == 9)
						{
							num = 25;
						}
						if (num11 == 10)
						{
							num = 58;
						}
						if (num11 == 11)
						{
							num = 36;
						}
						if (num11 == 12)
						{
							num = 37;
						}
						if (num11 == 13)
						{
							num = 38;
						}
						if (num11 == 14)
						{
							num = 53;
						}
						if (num11 == 15)
						{
							num = 54;
						}
						if (num11 == 16)
						{
							num = 55;
						}
						if (num11 == 17)
						{
							num = 39;
						}
						if (num11 == 18)
						{
							num = 40;
						}
						if (num11 == 19)
						{
							num = 56;
						}
						if (num11 == 20)
						{
							num = 41;
						}
						if (num11 == 21)
						{
							num = 57;
						}
						if (num11 == 22)
						{
							num = 42;
						}
						if (num11 == 23)
						{
							num = 43;
						}
						if (num11 == 24)
						{
							num = 44;
						}
						if (num11 == 25)
						{
							num = 45;
						}
						if (num11 == 26)
						{
							num = 46;
						}
						if (num11 == 27)
						{
							num = 47;
						}
						if (num11 == 28)
						{
							num = 48;
						}
						if (num11 == 29)
						{
							num = 49;
						}
						if (num11 == 30)
						{
							num = 50;
						}
						if (num11 == 31)
						{
							num = 51;
						}
						if (num11 == 32)
						{
							num = 59;
						}
						if (num11 == 33)
						{
							num = 60;
						}
						if (num11 == 34)
						{
							num = 61;
						}
						if (num11 == 35)
						{
							num = 82;
						}
					}
					else if (type == 64 || type == 112 || type == 113 || type == 127 || type == 157 || type == 165 || type == 218 || type == 272 || type == 494 || type == 495 || type == 496 || type == 514 || type == 517 || type == 518 || type == 519 || type == 683 || type == 726 || type == 739 || type == 740 || type == 741 || type == 742 || type == 743 || type == 744 || type == 788 || type == 1121 || type == 1155 || type == 1157 || type == 1178 || type == 1244 || type == 1256 || type == 1260 || type == 1264 || type == 1266 || type == 1295 || type == 1296 || type == 1308 || type == 1309 || type == 1313 || type == 1336 || type == 1444 || type == 1445 || type == 1446 || type == 1572 || type == 1801 || type == 1802 || type == 1930 || type == 1931 || type == 2188 || type == 2622 || type == 2621 || type == 2584 || type == 2551 || type == 2366 || type == 2535 || type == 2365 || type == 2364 || type == 2623)
					{
						int num12 = Main.rand.Next(36);
						if (num12 == 0)
						{
							num = 26;
						}
						if (num12 == 1)
						{
							num = 27;
						}
						if (num12 == 2)
						{
							num = 28;
						}
						if (num12 == 3)
						{
							num = 29;
						}
						if (num12 == 4)
						{
							num = 30;
						}
						if (num12 == 5)
						{
							num = 31;
						}
						if (num12 == 6)
						{
							num = 32;
						}
						if (num12 == 7)
						{
							num = 33;
						}
						if (num12 == 8)
						{
							num = 34;
						}
						if (num12 == 9)
						{
							num = 35;
						}
						if (num12 == 10)
						{
							num = 52;
						}
						if (num12 == 11)
						{
							num = 36;
						}
						if (num12 == 12)
						{
							num = 37;
						}
						if (num12 == 13)
						{
							num = 38;
						}
						if (num12 == 14)
						{
							num = 53;
						}
						if (num12 == 15)
						{
							num = 54;
						}
						if (num12 == 16)
						{
							num = 55;
						}
						if (num12 == 17)
						{
							num = 39;
						}
						if (num12 == 18)
						{
							num = 40;
						}
						if (num12 == 19)
						{
							num = 56;
						}
						if (num12 == 20)
						{
							num = 41;
						}
						if (num12 == 21)
						{
							num = 57;
						}
						if (num12 == 22)
						{
							num = 42;
						}
						if (num12 == 23)
						{
							num = 43;
						}
						if (num12 == 24)
						{
							num = 44;
						}
						if (num12 == 25)
						{
							num = 45;
						}
						if (num12 == 26)
						{
							num = 46;
						}
						if (num12 == 27)
						{
							num = 47;
						}
						if (num12 == 28)
						{
							num = 48;
						}
						if (num12 == 29)
						{
							num = 49;
						}
						if (num12 == 30)
						{
							num = 50;
						}
						if (num12 == 31)
						{
							num = 51;
						}
						if (num12 == 32)
						{
							num = 59;
						}
						if (num12 == 33)
						{
							num = 60;
						}
						if (num12 == 34)
						{
							num = 61;
						}
						if (num12 == 35)
						{
							num = 83;
						}
					}
					else if (type == 55 || type == 119 || type == 191 || type == 284 || type == 670 || type == 1122 || type == 1513 || type == 1569 || type == 1571 || type == 1825 || type == 1918)
					{
						int num13 = Main.rand.Next(14);
						if (num13 == 0)
						{
							num = 36;
						}
						if (num13 == 1)
						{
							num = 37;
						}
						if (num13 == 2)
						{
							num = 38;
						}
						if (num13 == 3)
						{
							num = 53;
						}
						if (num13 == 4)
						{
							num = 54;
						}
						if (num13 == 5)
						{
							num = 55;
						}
						if (num13 == 6)
						{
							num = 39;
						}
						if (num13 == 7)
						{
							num = 40;
						}
						if (num13 == 8)
						{
							num = 56;
						}
						if (num13 == 9)
						{
							num = 41;
						}
						if (num13 == 10)
						{
							num = 57;
						}
						if (num13 == 11)
						{
							num = 59;
						}
						if (num13 == 12)
						{
							num = 60;
						}
						if (num13 == 13)
						{
							num = 61;
						}
					}
					else
					{
						if (!accessory || type == 267 || type == 562 || type == 563 || type == 564 || type == 565 || type == 566 || type == 567 || type == 568 || type == 569 || type == 570 || type == 571 || type == 572 || type == 573 || type == 574 || type == 576 || type == 1307 || (type >= 1596 && type < 1610) || vanity)
						{
							return false;
						}
						num = Main.rand.Next(62, 81);
					}
				}
				switch (pre)
				{
				case -3:
					return true;
				case -1:
					if ((num == 7 || num == 8 || num == 9 || num == 10 || num == 11 || num == 22 || num == 23 || num == 24 || num == 29 || num == 30 || num == 31 || num == 39 || num == 40 || num == 56 || num == 41 || num == 47 || num == 48 || num == 49) && Main.rand.Next(3) != 0)
					{
						num = 0;
					}
					break;
				}
				switch (num)
				{
				case 1:
					num5 = 1.12f;
					break;
				case 2:
					num5 = 1.18f;
					break;
				case 3:
					num2 = 1.05f;
					num8 = 2;
					num5 = 1.05f;
					break;
				case 4:
					num2 = 1.1f;
					num5 = 1.1f;
					num3 = 1.1f;
					break;
				case 5:
					num2 = 1.15f;
					break;
				case 6:
					num2 = 1.1f;
					break;
				case 81:
					num3 = 1.15f;
					num2 = 1.15f;
					num8 = 5;
					num4 = 0.9f;
					num5 = 1.1f;
					break;
				case 7:
					num5 = 0.82f;
					break;
				case 8:
					num3 = 0.85f;
					num2 = 0.85f;
					num5 = 0.87f;
					break;
				case 9:
					num5 = 0.9f;
					break;
				case 10:
					num2 = 0.85f;
					break;
				case 11:
					num4 = 1.1f;
					num3 = 0.9f;
					num5 = 0.9f;
					break;
				case 12:
					num3 = 1.1f;
					num2 = 1.05f;
					num5 = 1.1f;
					num4 = 1.15f;
					break;
				case 13:
					num3 = 0.8f;
					num2 = 0.9f;
					num5 = 1.1f;
					break;
				case 14:
					num3 = 1.15f;
					num4 = 1.1f;
					break;
				case 15:
					num3 = 0.9f;
					num4 = 0.85f;
					break;
				case 16:
					num2 = 1.1f;
					num8 = 3;
					break;
				case 17:
					num4 = 0.85f;
					num6 = 1.1f;
					break;
				case 18:
					num4 = 0.9f;
					num6 = 1.15f;
					break;
				case 19:
					num3 = 1.15f;
					num6 = 1.05f;
					break;
				case 20:
					num3 = 1.05f;
					num6 = 1.05f;
					num2 = 1.1f;
					num4 = 0.95f;
					num8 = 2;
					break;
				case 21:
					num3 = 1.15f;
					num2 = 1.1f;
					break;
				case 82:
					num3 = 1.15f;
					num2 = 1.15f;
					num8 = 5;
					num4 = 0.9f;
					num6 = 1.1f;
					break;
				case 22:
					num3 = 0.9f;
					num6 = 0.9f;
					num2 = 0.85f;
					break;
				case 23:
					num4 = 1.15f;
					num6 = 0.9f;
					break;
				case 24:
					num4 = 1.1f;
					num3 = 0.8f;
					break;
				case 25:
					num4 = 1.1f;
					num2 = 1.15f;
					num8 = 1;
					break;
				case 58:
					num4 = 0.85f;
					num2 = 0.85f;
					break;
				case 26:
					num7 = 0.85f;
					num2 = 1.1f;
					break;
				case 27:
					num7 = 0.85f;
					break;
				case 28:
					num7 = 0.85f;
					num2 = 1.15f;
					num3 = 1.05f;
					break;
				case 83:
					num3 = 1.15f;
					num2 = 1.15f;
					num8 = 5;
					num4 = 0.9f;
					num7 = 0.9f;
					break;
				case 29:
					num7 = 1.1f;
					break;
				case 30:
					num7 = 1.2f;
					num2 = 0.9f;
					break;
				case 31:
					num3 = 0.9f;
					num2 = 0.9f;
					break;
				case 32:
					num7 = 1.15f;
					num2 = 1.1f;
					break;
				case 33:
					num7 = 1.1f;
					num3 = 1.1f;
					num4 = 0.9f;
					break;
				case 34:
					num7 = 0.9f;
					num3 = 1.1f;
					num4 = 1.1f;
					num2 = 1.1f;
					break;
				case 35:
					num7 = 1.2f;
					num2 = 1.15f;
					num3 = 1.15f;
					break;
				case 52:
					num7 = 0.9f;
					num2 = 0.9f;
					num4 = 0.9f;
					break;
				case 36:
					num8 = 3;
					break;
				case 37:
					num2 = 1.1f;
					num8 = 3;
					num3 = 1.1f;
					break;
				case 38:
					num3 = 1.15f;
					break;
				case 53:
					num2 = 1.1f;
					break;
				case 54:
					num3 = 1.15f;
					break;
				case 55:
					num3 = 1.15f;
					num2 = 1.05f;
					break;
				case 59:
					num3 = 1.15f;
					num2 = 1.15f;
					num8 = 5;
					break;
				case 60:
					num2 = 1.15f;
					num8 = 5;
					break;
				case 61:
					num8 = 5;
					break;
				case 39:
					num2 = 0.7f;
					num3 = 0.8f;
					break;
				case 40:
					num2 = 0.85f;
					break;
				case 56:
					num3 = 0.8f;
					break;
				case 41:
					num3 = 0.85f;
					num2 = 0.9f;
					break;
				case 57:
					num3 = 0.9f;
					num2 = 1.18f;
					break;
				case 42:
					num4 = 0.9f;
					break;
				case 43:
					num2 = 1.1f;
					num4 = 0.9f;
					break;
				case 44:
					num4 = 0.9f;
					num8 = 3;
					break;
				case 45:
					num4 = 0.95f;
					break;
				case 46:
					num8 = 3;
					num4 = 0.94f;
					num2 = 1.07f;
					break;
				case 47:
					num4 = 1.15f;
					break;
				case 48:
					num4 = 1.2f;
					break;
				case 49:
					num4 = 1.08f;
					break;
				case 50:
					num2 = 0.8f;
					num4 = 1.15f;
					break;
				case 51:
					num3 = 0.9f;
					num4 = 0.9f;
					num2 = 1.05f;
					num8 = 2;
					break;
				}
				if (num2 != 1f && Math.Round((float)damage * num2) == (double)damage)
				{
					flag = true;
					num = -1;
				}
				if (num4 != 1f && Math.Round((float)useAnimation * num4) == (double)useAnimation)
				{
					flag = true;
					num = -1;
				}
				if (num7 != 1f && Math.Round((float)mana * num7) == (double)mana)
				{
					flag = true;
					num = -1;
				}
				if (num3 != 1f && knockBack == 0f)
				{
					flag = true;
					num = -1;
				}
				if (pre == -2 && num == 0)
				{
					num = -1;
					flag = true;
				}
			}
			damage = (int)Math.Round((float)damage * num2);
			useAnimation = (int)Math.Round((float)useAnimation * num4);
			useTime = (int)Math.Round((float)useTime * num4);
			reuseDelay = (int)Math.Round((float)reuseDelay * num4);
			mana = (int)Math.Round((float)mana * num7);
			knockBack *= num3;
			scale *= num5;
			shootSpeed *= num6;
			crit += num8;
			float num14 = 1f * num2 * (2f - num4) * (2f - num7) * num5 * num3 * num6 * (1f + (float)crit * 0.02f);
			if (num == 62 || num == 69 || num == 73 || num == 77)
			{
				num14 *= 1.05f;
			}
			if (num == 63 || num == 70 || num == 74 || num == 78 || num == 67)
			{
				num14 *= 1.1f;
			}
			if (num == 64 || num == 71 || num == 75 || num == 79 || num == 66)
			{
				num14 *= 1.15f;
			}
			if (num == 65 || num == 72 || num == 76 || num == 80 || num == 68)
			{
				num14 *= 1.2f;
			}
			if ((double)num14 >= 1.2)
			{
				rare += 2;
			}
			else if ((double)num14 >= 1.05)
			{
				rare++;
			}
			else if ((double)num14 <= 0.8)
			{
				rare -= 2;
			}
			else if ((double)num14 <= 0.95)
			{
				rare--;
			}
			if (rare < -1)
			{
				rare = -1;
			}
			if (rare > 9)
			{
				rare = 9;
			}
			num14 *= num14;
			value = (int)((float)value * num14);
			prefix = (byte)num;
			return true;
		}

		public string AffixName()
		{
			if (Lang.lang <= 1)
			{
				if (Lang.prefix[prefix] != "")
				{
					return Lang.prefix[prefix] + " " + name;
				}
				return name;
			}
			if (Lang.prefix[prefix] != "")
			{
				return name + " (" + Lang.prefix[prefix] + ")";
			}
			return name;
		}

		public string AffixName_Old()
		{
			string text = "";
			if (Lang.lang <= 1)
			{
				if (prefix == 1)
				{
					text = "Large";
				}
				if (prefix == 2)
				{
					text = "Massive";
				}
				if (prefix == 3)
				{
					text = "Dangerous";
				}
				if (prefix == 4)
				{
					text = "Savage";
				}
				if (prefix == 5)
				{
					text = "Sharp";
				}
				if (prefix == 6)
				{
					text = "Pointy";
				}
				if (prefix == 7)
				{
					text = "Tiny";
				}
				if (prefix == 8)
				{
					text = "Terrible";
				}
				if (prefix == 9)
				{
					text = "Small";
				}
				if (prefix == 10)
				{
					text = "Dull";
				}
				if (prefix == 11)
				{
					text = "Unhappy";
				}
				if (prefix == 12)
				{
					text = "Bulky";
				}
				if (prefix == 13)
				{
					text = "Shameful";
				}
				if (prefix == 14)
				{
					text = "Heavy";
				}
				if (prefix == 15)
				{
					text = "Light";
				}
				if (prefix == 16)
				{
					text = "Sighted";
				}
				if (prefix == 17)
				{
					text = "Rapid";
				}
				if (prefix == 18)
				{
					text = "Hasty";
				}
				if (prefix == 19)
				{
					text = "Intimidating";
				}
				if (prefix == 20)
				{
					text = "Deadly";
				}
				if (prefix == 21)
				{
					text = "Staunch";
				}
				if (prefix == 22)
				{
					text = "Awful";
				}
				if (prefix == 23)
				{
					text = "Lethargic";
				}
				if (prefix == 24)
				{
					text = "Awkward";
				}
				if (prefix == 25)
				{
					text = "Powerful";
				}
				if (prefix == 58)
				{
					text = "Frenzying";
				}
				if (prefix == 26)
				{
					text = "Mystic";
				}
				if (prefix == 27)
				{
					text = "Adept";
				}
				if (prefix == 28)
				{
					text = "Masterful";
				}
				if (prefix == 29)
				{
					text = "Inept";
				}
				if (prefix == 30)
				{
					text = "Ignorant";
				}
				if (prefix == 31)
				{
					text = "Deranged";
				}
				if (prefix == 32)
				{
					text = "Intense";
				}
				if (prefix == 33)
				{
					text = "Taboo";
				}
				if (prefix == 34)
				{
					text = "Celestial";
				}
				if (prefix == 35)
				{
					text = "Furious";
				}
				if (prefix == 52)
				{
					text = "Manic";
				}
				if (prefix == 36)
				{
					text = "Keen";
				}
				if (prefix == 37)
				{
					text = "Superior";
				}
				if (prefix == 38)
				{
					text = "Forceful";
				}
				if (prefix == 53)
				{
					text = "Hurtful";
				}
				if (prefix == 54)
				{
					text = "Strong";
				}
				if (prefix == 55)
				{
					text = "Unpleasant";
				}
				if (prefix == 39)
				{
					text = "Broken";
				}
				if (prefix == 40)
				{
					text = "Damaged";
				}
				if (prefix == 56)
				{
					text = "Weak";
				}
				if (prefix == 41)
				{
					text = "Shoddy";
				}
				if (prefix == 57)
				{
					text = "Ruthless";
				}
				if (prefix == 42)
				{
					text = "Quick";
				}
				if (prefix == 43)
				{
					text = "Deadly";
				}
				if (prefix == 44)
				{
					text = "Agile";
				}
				if (prefix == 45)
				{
					text = "Nimble";
				}
				if (prefix == 46)
				{
					text = "Murderous";
				}
				if (prefix == 47)
				{
					text = "Slow";
				}
				if (prefix == 48)
				{
					text = "Sluggish";
				}
				if (prefix == 49)
				{
					text = "Lazy";
				}
				if (prefix == 50)
				{
					text = "Annoying";
				}
				if (prefix == 51)
				{
					text = "Nasty";
				}
				if (prefix == 59)
				{
					text = "Godly";
				}
				if (prefix == 60)
				{
					text = "Demonic";
				}
				if (prefix == 61)
				{
					text = "Zealous";
				}
				if (prefix == 62)
				{
					text = "Hard";
				}
				if (prefix == 63)
				{
					text = "Guarding";
				}
				if (prefix == 64)
				{
					text = "Armored";
				}
				if (prefix == 65)
				{
					text = "Warding";
				}
				if (prefix == 66)
				{
					text = "Arcane";
				}
				if (prefix == 67)
				{
					text = "Precise";
				}
				if (prefix == 68)
				{
					text = "Lucky";
				}
				if (prefix == 69)
				{
					text = "Jagged";
				}
				if (prefix == 70)
				{
					text = "Spiked";
				}
				if (prefix == 71)
				{
					text = "Angry";
				}
				if (prefix == 72)
				{
					text = "Menacing";
				}
				if (prefix == 73)
				{
					text = "Brisk";
				}
				if (prefix == 74)
				{
					text = "Fleeting";
				}
				if (prefix == 75)
				{
					text = "Hasty";
				}
				if (prefix == 76)
				{
					text = "Quick";
				}
				if (prefix == 77)
				{
					text = "Wild";
				}
				if (prefix == 78)
				{
					text = "Rash";
				}
				if (prefix == 79)
				{
					text = "Intrepid";
				}
				if (prefix == 80)
				{
					text = "Violent";
				}
				if (prefix == 81)
				{
					text = "Legendary";
				}
				if (prefix == 82)
				{
					text = "Unreal";
				}
				if (prefix == 83)
				{
					text = "Mythical";
				}
			}
			else if (Lang.lang == 2)
			{
				if (prefix == 1)
				{
					text = "Gross";
				}
				if (prefix == 2)
				{
					text = "Massiv";
				}
				if (prefix == 3)
				{
					text = "Gefährlich";
				}
				if (prefix == 4)
				{
					text = "Barbarisch";
				}
				if (prefix == 5)
				{
					text = "Scharf";
				}
				if (prefix == 6)
				{
					text = "Spitze";
				}
				if (prefix == 7)
				{
					text = "Winzig";
				}
				if (prefix == 8)
				{
					text = "Schrecklicher";
				}
				if (prefix == 9)
				{
					text = "Klein";
				}
				if (prefix == 10)
				{
					text = "Stumpf";
				}
				if (prefix == 11)
				{
					text = "Unglücklich";
				}
				if (prefix == 12)
				{
					text = "Sperrig";
				}
				if (prefix == 13)
				{
					text = "Beschämend";
				}
				if (prefix == 14)
				{
					text = "Schwer";
				}
				if (prefix == 15)
				{
					text = "Locker";
				}
				if (prefix == 16)
				{
					text = "Gesichtet";
				}
				if (prefix == 17)
				{
					text = "Schnell";
				}
				if (prefix == 18)
				{
					text = "Hastig";
				}
				if (prefix == 19)
				{
					text = "Einschüchternd";
				}
				if (prefix == 20)
				{
					text = "Tödlich";
				}
				if (prefix == 21)
				{
					text = "Stillen";
				}
				if (prefix == 22)
				{
					text = "Schrecklich";
				}
				if (prefix == 23)
				{
					text = "Lethargisch";
				}
				if (prefix == 24)
				{
					text = "Unbeholfen";
				}
				if (prefix == 25)
				{
					text = "Mächtig";
				}
				if (prefix == 26)
				{
					text = "Mystisch";
				}
				if (prefix == 27)
				{
					text = "Geschickt";
				}
				if (prefix == 28)
				{
					text = "Meisterhaft";
				}
				if (prefix == 29)
				{
					text = "Ungeschickt";
				}
				if (prefix == 30)
				{
					text = "Unwissend";
				}
				if (prefix == 31)
				{
					text = "Gestört";
				}
				if (prefix == 32)
				{
					text = "Intensiv";
				}
				if (prefix == 33)
				{
					text = "Tabu";
				}
				if (prefix == 34)
				{
					text = "Himmlisch";
				}
				if (prefix == 35)
				{
					text = "Wütend";
				}
				if (prefix == 36)
				{
					text = "Scharf";
				}
				if (prefix == 37)
				{
					text = "Überlegen";
				}
				if (prefix == 38)
				{
					text = "Kraftvoll";
				}
				if (prefix == 39)
				{
					text = "Gebrochen";
				}
				if (prefix == 40)
				{
					text = "Beschädigt";
				}
				if (prefix == 41)
				{
					text = "Schäbig";
				}
				if (prefix == 42)
				{
					text = "Rasch";
				}
				if (prefix == 43)
				{
					text = "Tödlich";
				}
				if (prefix == 44)
				{
					text = "Agil";
				}
				if (prefix == 45)
				{
					text = "Wendig";
				}
				if (prefix == 46)
				{
					text = "Mörderisch";
				}
				if (prefix == 47)
				{
					text = "Langsam";
				}
				if (prefix == 48)
				{
					text = "Träge";
				}
				if (prefix == 49)
				{
					text = "Faul";
				}
				if (prefix == 50)
				{
					text = "Lästig";
				}
				if (prefix == 51)
				{
					text = "Böse";
				}
				if (prefix == 52)
				{
					text = "Manisch";
				}
				if (prefix == 53)
				{
					text = "Verletzend";
				}
				if (prefix == 54)
				{
					text = "Stark";
				}
				if (prefix == 55)
				{
					text = "Unangenehm";
				}
				if (prefix == 56)
				{
					text = "Schwach";
				}
				if (prefix == 57)
				{
					text = "Rücksichtslos";
				}
				if (prefix == 58)
				{
					text = "Rasend";
				}
				if (prefix == 59)
				{
					text = "Fromm";
				}
				if (prefix == 60)
				{
					text = "Dämonisch";
				}
				if (prefix == 61)
				{
					text = "Eifrig";
				}
				if (prefix == 62)
				{
					text = "Schwer";
				}
				if (prefix == 63)
				{
					text = "Schutz-";
				}
				if (prefix == 64)
				{
					text = "Gepanzert";
				}
				if (prefix == 65)
				{
					text = "Defensiv";
				}
				if (prefix == 66)
				{
					text = "Geheimnisvoll";
				}
				if (prefix == 67)
				{
					text = "Präzise";
				}
				if (prefix == 68)
				{
					text = "Glücklich";
				}
				if (prefix == 69)
				{
					text = "Gezackt";
				}
				if (prefix == 70)
				{
					text = "Spike";
				}
				if (prefix == 71)
				{
					text = "Wütend";
				}
				if (prefix == 72)
				{
					text = "Bedrohlich";
				}
				if (prefix == 73)
				{
					text = "Rege";
				}
				if (prefix == 74)
				{
					text = "Flüchtig";
				}
				if (prefix == 75)
				{
					text = "Hastig";
				}
				if (prefix == 76)
				{
					text = "Rasch";
				}
				if (prefix == 77)
				{
					text = "Wild";
				}
				if (prefix == 78)
				{
					text = "Voreilig";
				}
				if (prefix == 79)
				{
					text = "Unerschrocken";
				}
				if (prefix == 80)
				{
					text = "Gewalttätig";
				}
				if (prefix == 81)
				{
					text = "Legendär";
				}
				if (prefix == 82)
				{
					text = "Unwirklich";
				}
				if (prefix == 83)
				{
					text = "Mythisch";
				}
			}
			else if (Lang.lang == 3)
			{
				if (prefix == 1)
				{
					text = "Grande";
				}
				if (prefix == 2)
				{
					text = "Massiccio";
				}
				if (prefix == 3)
				{
					text = "Pericoloso";
				}
				if (prefix == 4)
				{
					text = "Selvaggio";
				}
				if (prefix == 5)
				{
					text = "Appuntito";
				}
				if (prefix == 6)
				{
					text = "Tagliente";
				}
				if (prefix == 7)
				{
					text = "Minuto";
				}
				if (prefix == 8)
				{
					text = "Terribile";
				}
				if (prefix == 9)
				{
					text = "Piccolo";
				}
				if (prefix == 10)
				{
					text = "Opaco";
				}
				if (prefix == 11)
				{
					text = "Infelice";
				}
				if (prefix == 12)
				{
					text = "Ingombrante";
				}
				if (prefix == 13)
				{
					text = "Vergognoso";
				}
				if (prefix == 14)
				{
					text = "Pesante";
				}
				if (prefix == 15)
				{
					text = "Luce";
				}
				if (prefix == 16)
				{
					text = "Avvistato";
				}
				if (prefix == 17)
				{
					text = "Rapido";
				}
				if (prefix == 18)
				{
					text = "Frettoloso";
				}
				if (prefix == 19)
				{
					text = "Intimidatorio";
				}
				if (prefix == 20)
				{
					text = "Mortale";
				}
				if (prefix == 21)
				{
					text = "Convinto";
				}
				if (prefix == 22)
				{
					text = "Orribile";
				}
				if (prefix == 23)
				{
					text = "Letargico";
				}
				if (prefix == 24)
				{
					text = "Scomodo";
				}
				if (prefix == 25)
				{
					text = "Potente";
				}
				if (prefix == 26)
				{
					text = "Mistico";
				}
				if (prefix == 27)
				{
					text = "Esperto";
				}
				if (prefix == 28)
				{
					text = "Magistrale";
				}
				if (prefix == 29)
				{
					text = "Inetto";
				}
				if (prefix == 30)
				{
					text = "Ignorante";
				}
				if (prefix == 31)
				{
					text = "Squilibrato";
				}
				if (prefix == 32)
				{
					text = "Intenso";
				}
				if (prefix == 33)
				{
					text = "Tabù";
				}
				if (prefix == 34)
				{
					text = "Celeste";
				}
				if (prefix == 35)
				{
					text = "Furioso";
				}
				if (prefix == 36)
				{
					text = "Appassionato";
				}
				if (prefix == 37)
				{
					text = "Superiore";
				}
				if (prefix == 38)
				{
					text = "Forte";
				}
				if (prefix == 39)
				{
					text = "Rotto";
				}
				if (prefix == 40)
				{
					text = "Danneggiato";
				}
				if (prefix == 41)
				{
					text = "Scadente";
				}
				if (prefix == 42)
				{
					text = "Veloce";
				}
				if (prefix == 43)
				{
					text = "Mortale";
				}
				if (prefix == 44)
				{
					text = "Agile";
				}
				if (prefix == 45)
				{
					text = "Lesto";
				}
				if (prefix == 46)
				{
					text = "Omicida";
				}
				if (prefix == 47)
				{
					text = "Lento";
				}
				if (prefix == 48)
				{
					text = "Pigro";
				}
				if (prefix == 49)
				{
					text = "Indolente";
				}
				if (prefix == 50)
				{
					text = "Fastidioso";
				}
				if (prefix == 51)
				{
					text = "Brutto";
				}
				if (prefix == 52)
				{
					text = "Maniaco";
				}
				if (prefix == 53)
				{
					text = "Offensivo";
				}
				if (prefix == 54)
				{
					text = "Robusto";
				}
				if (prefix == 55)
				{
					text = "Sgradevole";
				}
				if (prefix == 56)
				{
					text = "Debole";
				}
				if (prefix == 57)
				{
					text = "Spietato";
				}
				if (prefix == 58)
				{
					text = "Frenetico";
				}
				if (prefix == 59)
				{
					text = "Devoto";
				}
				if (prefix == 60)
				{
					text = "Demonico";
				}
				if (prefix == 61)
				{
					text = "Zelante";
				}
				if (prefix == 62)
				{
					text = "Duro";
				}
				if (prefix == 63)
				{
					text = "Protettivo";
				}
				if (prefix == 64)
				{
					text = "Corazzato";
				}
				if (prefix == 65)
				{
					text = "Difensivo";
				}
				if (prefix == 66)
				{
					text = "Arcano";
				}
				if (prefix == 67)
				{
					text = "Preciso";
				}
				if (prefix == 68)
				{
					text = "Fortunato";
				}
				if (prefix == 69)
				{
					text = "Frastagliato";
				}
				if (prefix == 70)
				{
					text = "Spillo";
				}
				if (prefix == 71)
				{
					text = "Arrabbiato";
				}
				if (prefix == 72)
				{
					text = "Minaccioso";
				}
				if (prefix == 73)
				{
					text = "Vivace";
				}
				if (prefix == 74)
				{
					text = "Fugace";
				}
				if (prefix == 75)
				{
					text = "Frettoloso";
				}
				if (prefix == 76)
				{
					text = "Veloce";
				}
				if (prefix == 77)
				{
					text = "Selvaggio";
				}
				if (prefix == 78)
				{
					text = "Temerario";
				}
				if (prefix == 79)
				{
					text = "Intrepido";
				}
				if (prefix == 80)
				{
					text = "Violento";
				}
				if (prefix == 81)
				{
					text = "Leggendario";
				}
				if (prefix == 82)
				{
					text = "Irreale";
				}
				if (prefix == 83)
				{
					text = "Mitico";
				}
			}
			else if (Lang.lang == 4)
			{
				if (prefix == 1)
				{
					text = "Grand";
				}
				if (prefix == 2)
				{
					text = "Massif";
				}
				if (prefix == 3)
				{
					text = "Dangereuses";
				}
				if (prefix == 4)
				{
					text = "Sauvages";
				}
				if (prefix == 5)
				{
					text = "Coupante";
				}
				if (prefix == 6)
				{
					text = "Pointues";
				}
				if (prefix == 7)
				{
					text = "Minuscules";
				}
				if (prefix == 8)
				{
					text = "Terrible";
				}
				if (prefix == 9)
				{
					text = "Petit";
				}
				if (prefix == 10)
				{
					text = "Terne";
				}
				if (prefix == 11)
				{
					text = "Malheureux";
				}
				if (prefix == 12)
				{
					text = "Volumineux";
				}
				if (prefix == 13)
				{
					text = "Honteux";
				}
				if (prefix == 14)
				{
					text = "Lourds";
				}
				if (prefix == 15)
				{
					text = "Léger";
				}
				if (prefix == 16)
				{
					text = "Voyants";
				}
				if (prefix == 17)
				{
					text = "Rapide";
				}
				if (prefix == 18)
				{
					text = "Hâtif";
				}
				if (prefix == 19)
				{
					text = "Intimidant";
				}
				if (prefix == 20)
				{
					text = "Mortelle";
				}
				if (prefix == 21)
				{
					text = "Dévoué";
				}
				if (prefix == 22)
				{
					text = "Affreux";
				}
				if (prefix == 23)
				{
					text = "Léthargique";
				}
				if (prefix == 24)
				{
					text = "Scomodo";
				}
				if (prefix == 25)
				{
					text = "Puissante";
				}
				if (prefix == 26)
				{
					text = "Mystique";
				}
				if (prefix == 27)
				{
					text = "Expert";
				}
				if (prefix == 28)
				{
					text = "Magistrale";
				}
				if (prefix == 29)
				{
					text = "Inepte";
				}
				if (prefix == 30)
				{
					text = "Ignorants";
				}
				if (prefix == 31)
				{
					text = "Dérangé";
				}
				if (prefix == 32)
				{
					text = "Intenses";
				}
				if (prefix == 33)
				{
					text = "Tabou";
				}
				if (prefix == 34)
				{
					text = "Célestes";
				}
				if (prefix == 35)
				{
					text = "Furieux";
				}
				if (prefix == 36)
				{
					text = "Vif";
				}
				if (prefix == 37)
				{
					text = "Supérieure";
				}
				if (prefix == 38)
				{
					text = "Énergique";
				}
				if (prefix == 39)
				{
					text = "Rompu";
				}
				if (prefix == 40)
				{
					text = "Endommagés";
				}
				if (prefix == 41)
				{
					text = "Mesquin";
				}
				if (prefix == 42)
				{
					text = "Prompt";
				}
				if (prefix == 43)
				{
					text = "Mortelle";
				}
				if (prefix == 44)
				{
					text = "Agile";
				}
				if (prefix == 45)
				{
					text = "Leste";
				}
				if (prefix == 46)
				{
					text = "Meurtrier";
				}
				if (prefix == 47)
				{
					text = "Lente";
				}
				if (prefix == 48)
				{
					text = "Paresseux";
				}
				if (prefix == 49)
				{
					text = "Fainéant";
				}
				if (prefix == 50)
				{
					text = "Ennuyeux";
				}
				if (prefix == 51)
				{
					text = "Méchant";
				}
				if (prefix == 52)
				{
					text = "Maniaco";
				}
				if (prefix == 53)
				{
					text = "Blessant";
				}
				if (prefix == 54)
				{
					text = "Robuste";
				}
				if (prefix == 55)
				{
					text = "Désagréables";
				}
				if (prefix == 56)
				{
					text = "Faibles";
				}
				if (prefix == 57)
				{
					text = "Impitoyable";
				}
				if (prefix == 58)
				{
					text = "Frénétique";
				}
				if (prefix == 59)
				{
					text = "Pieux";
				}
				if (prefix == 60)
				{
					text = "Démoniaque";
				}
				if (prefix == 61)
				{
					text = "Zélé";
				}
				if (prefix == 62)
				{
					text = "Durs";
				}
				if (prefix == 63)
				{
					text = "Protecteur";
				}
				if (prefix == 64)
				{
					text = "Blindés";
				}
				if (prefix == 65)
				{
					text = "Défensif";
				}
				if (prefix == 66)
				{
					text = "Ésotérique";
				}
				if (prefix == 67)
				{
					text = "Précise";
				}
				if (prefix == 68)
				{
					text = "Chanceux";
				}
				if (prefix == 69)
				{
					text = "Déchiqueté";
				}
				if (prefix == 70)
				{
					text = "Pointes";
				}
				if (prefix == 71)
				{
					text = "Fâché";
				}
				if (prefix == 72)
				{
					text = "Menaçant";
				}
				if (prefix == 73)
				{
					text = "Brusque";
				}
				if (prefix == 74)
				{
					text = "Fugace";
				}
				if (prefix == 75)
				{
					text = "Hâtif";
				}
				if (prefix == 76)
				{
					text = "Prompt";
				}
				if (prefix == 77)
				{
					text = "Sauvages";
				}
				if (prefix == 78)
				{
					text = "Téméraire";
				}
				if (prefix == 79)
				{
					text = "Intrépide";
				}
				if (prefix == 80)
				{
					text = "Violent";
				}
				if (prefix == 81)
				{
					text = "Légendaire";
				}
				if (prefix == 82)
				{
					text = "Irréel";
				}
				if (prefix == 83)
				{
					text = "Mythique";
				}
			}
			else if (Lang.lang == 5)
			{
				if (prefix == 1)
				{
					text = "Grande";
				}
				if (prefix == 2)
				{
					text = "Masivo";
				}
				if (prefix == 3)
				{
					text = "Peligroso";
				}
				if (prefix == 4)
				{
					text = "Salvaje";
				}
				if (prefix == 5)
				{
					text = "Puntiagudo";
				}
				if (prefix == 6)
				{
					text = "Agudo";
				}
				if (prefix == 7)
				{
					text = "Diminuto";
				}
				if (prefix == 8)
				{
					text = "Mala ";
				}
				if (prefix == 9)
				{
					text = "Pequeño";
				}
				if (prefix == 10)
				{
					text = "Aburrido";
				}
				if (prefix == 11)
				{
					text = "Infeliz";
				}
				if (prefix == 12)
				{
					text = "Voluminoso";
				}
				if (prefix == 13)
				{
					text = "Vergonzoso";
				}
				if (prefix == 14)
				{
					text = "Pesado";
				}
				if (prefix == 15)
				{
					text = "Ligero";
				}
				if (prefix == 16)
				{
					text = "Ámbito";
				}
				if (prefix == 17)
				{
					text = "Rápido";
				}
				if (prefix == 18)
				{
					text = "Precipitado";
				}
				if (prefix == 19)
				{
					text = "Intimidante";
				}
				if (prefix == 20)
				{
					text = "Mortal";
				}
				if (prefix == 21)
				{
					text = "Firme";
				}
				if (prefix == 22)
				{
					text = "Atroz";
				}
				if (prefix == 23)
				{
					text = "Letárgico";
				}
				if (prefix == 24)
				{
					text = "Torpe";
				}
				if (prefix == 25)
				{
					text = "Poderoso";
				}
				if (prefix == 26)
				{
					text = "Místico";
				}
				if (prefix == 27)
				{
					text = "Experto";
				}
				if (prefix == 28)
				{
					text = "Maestro";
				}
				if (prefix == 29)
				{
					text = "Inepto";
				}
				if (prefix == 30)
				{
					text = "Ignorante";
				}
				if (prefix == 31)
				{
					text = "Trastornado";
				}
				if (prefix == 32)
				{
					text = "Intenso";
				}
				if (prefix == 33)
				{
					text = "Tabú";
				}
				if (prefix == 34)
				{
					text = "Celeste";
				}
				if (prefix == 35)
				{
					text = "Furioso";
				}
				if (prefix == 36)
				{
					text = "Afilado";
				}
				if (prefix == 37)
				{
					text = "Superior";
				}
				if (prefix == 38)
				{
					text = "Fuerte";
				}
				if (prefix == 39)
				{
					text = "Roto";
				}
				if (prefix == 40)
				{
					text = "Estropeado";
				}
				if (prefix == 41)
				{
					text = "Regenerado";
				}
				if (prefix == 42)
				{
					text = "Pronto";
				}
				if (prefix == 43)
				{
					text = "Mortal";
				}
				if (prefix == 44)
				{
					text = "Ágil";
				}
				if (prefix == 45)
				{
					text = "Listo";
				}
				if (prefix == 46)
				{
					text = "Asesino";
				}
				if (prefix == 47)
				{
					text = "Lento";
				}
				if (prefix == 48)
				{
					text = "Perezoso";
				}
				if (prefix == 49)
				{
					text = "Gandul";
				}
				if (prefix == 50)
				{
					text = "Molesto";
				}
				if (prefix == 51)
				{
					text = "Feo";
				}
				if (prefix == 52)
				{
					text = "Maníacos";
				}
				if (prefix == 53)
				{
					text = "Hiriente";
				}
				if (prefix == 54)
				{
					text = "Vigoroso";
				}
				if (prefix == 55)
				{
					text = "Desagradable";
				}
				if (prefix == 56)
				{
					text = "Débil";
				}
				if (prefix == 57)
				{
					text = "Despiadado";
				}
				if (prefix == 58)
				{
					text = "Frenético";
				}
				if (prefix == 59)
				{
					text = "Piadoso";
				}
				if (prefix == 60)
				{
					text = "Demoníaco";
				}
				if (prefix == 61)
				{
					text = "Celoso";
				}
				if (prefix == 62)
				{
					text = "Duro";
				}
				if (prefix == 63)
				{
					text = "Protector";
				}
				if (prefix == 64)
				{
					text = "Blindado";
				}
				if (prefix == 65)
				{
					text = "Defensivo";
				}
				if (prefix == 66)
				{
					text = "Arcano";
				}
				if (prefix == 67)
				{
					text = "Preciso";
				}
				if (prefix == 68)
				{
					text = "Afortunado";
				}
				if (prefix == 69)
				{
					text = "Dentado";
				}
				if (prefix == 70)
				{
					text = "Claveteado";
				}
				if (prefix == 71)
				{
					text = "Enojado";
				}
				if (prefix == 72)
				{
					text = "Amenazador";
				}
				if (prefix == 73)
				{
					text = "Enérgico";
				}
				if (prefix == 74)
				{
					text = "Fugaz";
				}
				if (prefix == 75)
				{
					text = "Precipitado";
				}
				if (prefix == 76)
				{
					text = "Pronto";
				}
				if (prefix == 77)
				{
					text = "Salvaje";
				}
				if (prefix == 78)
				{
					text = "Temerario";
				}
				if (prefix == 79)
				{
					text = "Intrépido";
				}
				if (prefix == 80)
				{
					text = "Violento";
				}
				if (prefix == 81)
				{
					text = "Legendario";
				}
				if (prefix == 82)
				{
					text = "Irreal";
				}
				if (prefix == 83)
				{
					text = "Mítico";
				}
			}
			if (Lang.lang <= 1)
			{
				string result = name;
				if (text != "")
				{
					result = text + " " + name;
				}
				return result;
			}
			if (Lang.lang == 2)
			{
				string result2 = name;
				if (text != "")
				{
					result2 = name + " (" + text + ")";
				}
				return result2;
			}
			if (Lang.lang == 3)
			{
				string result3 = name;
				if (text != "")
				{
					result3 = name + " (" + text + ")";
				}
				return result3;
			}
			if (Lang.lang == 4)
			{
				string result4 = name;
				if (text != "")
				{
					result4 = name + " (" + text + ")";
				}
				return result4;
			}
			string result5 = name;
			if (text != "")
			{
				result5 = name + " (" + text + ")";
			}
			return result5;
		}

		public void CheckTip()
		{
			if (toolTip != "")
			{
				toolTip = Lang.toolTip(netID);
			}
			if (toolTip2 != "")
			{
				toolTip2 = Lang.toolTip2(netID);
			}
		}

		public void SetDefaults(string ItemName)
		{
			name = "";
			bool flag = false;
			switch (ItemName)
			{
			case "Gold Pickaxe":
				SetDefaults(1);
				color = new Color(210, 190, 0, 100);
				useTime = 17;
				pick = 55;
				useAnimation = 20;
				scale = 1.05f;
				damage = 6;
				value = 10000;
				toolTip = "Can mine Meteorite";
				netID = -1;
				break;
			case "Gold Broadsword":
				SetDefaults(4);
				color = new Color(210, 190, 0, 100);
				useAnimation = 20;
				damage = 13;
				scale = 1.05f;
				value = 9000;
				netID = -2;
				break;
			case "Gold Shortsword":
				SetDefaults(6);
				color = new Color(210, 190, 0, 100);
				damage = 11;
				useAnimation = 11;
				scale = 0.95f;
				value = 7000;
				netID = -3;
				break;
			case "Gold Axe":
				SetDefaults(10);
				color = new Color(210, 190, 0, 100);
				useTime = 18;
				axe = 11;
				useAnimation = 26;
				scale = 1.15f;
				damage = 7;
				value = 8000;
				netID = -4;
				break;
			case "Gold Hammer":
				SetDefaults(7);
				color = new Color(210, 190, 0, 100);
				useAnimation = 28;
				useTime = 23;
				scale = 1.25f;
				damage = 9;
				hammer = 55;
				value = 8000;
				netID = -5;
				break;
			case "Gold Bow":
				SetDefaults(99);
				useAnimation = 26;
				useTime = 26;
				color = new Color(210, 190, 0, 100);
				damage = 11;
				value = 7000;
				netID = -6;
				break;
			case "Silver Pickaxe":
				SetDefaults(1);
				color = new Color(180, 180, 180, 100);
				useTime = 11;
				pick = 45;
				useAnimation = 19;
				scale = 1.05f;
				damage = 6;
				value = 5000;
				netID = -7;
				break;
			case "Silver Broadsword":
				SetDefaults(4);
				color = new Color(180, 180, 180, 100);
				useAnimation = 21;
				damage = 11;
				value = 4500;
				netID = -8;
				break;
			case "Silver Shortsword":
				SetDefaults(6);
				color = new Color(180, 180, 180, 100);
				damage = 9;
				useAnimation = 12;
				scale = 0.95f;
				value = 3500;
				netID = -9;
				break;
			case "Silver Axe":
				SetDefaults(10);
				color = new Color(180, 180, 180, 100);
				useTime = 18;
				axe = 10;
				useAnimation = 26;
				scale = 1.15f;
				damage = 6;
				value = 4000;
				netID = -10;
				break;
			case "Silver Hammer":
				SetDefaults(7);
				color = new Color(180, 180, 180, 100);
				useAnimation = 29;
				useTime = 19;
				scale = 1.25f;
				damage = 9;
				hammer = 45;
				value = 4000;
				netID = -11;
				break;
			case "Silver Bow":
				SetDefaults(99);
				useAnimation = 27;
				useTime = 27;
				color = new Color(180, 180, 180, 100);
				damage = 9;
				value = 3500;
				netID = -12;
				break;
			case "Copper Pickaxe":
				SetDefaults(1);
				color = new Color(180, 100, 45, 80);
				useTime = 15;
				pick = 35;
				useAnimation = 23;
				damage = 4;
				scale = 0.9f;
				tileBoost = -1;
				value = 500;
				netID = -13;
				break;
			case "Copper Broadsword":
				SetDefaults(4);
				color = new Color(180, 100, 45, 80);
				useAnimation = 23;
				damage = 8;
				value = 450;
				netID = -14;
				break;
			case "Copper Shortsword":
				SetDefaults(6);
				color = new Color(180, 100, 45, 80);
				damage = 5;
				useAnimation = 13;
				scale = 0.8f;
				value = 350;
				netID = -15;
				break;
			case "Copper Axe":
				SetDefaults(10);
				color = new Color(180, 100, 45, 80);
				useTime = 21;
				axe = 7;
				useAnimation = 30;
				scale = 1f;
				damage = 3;
				tileBoost = -1;
				value = 400;
				netID = -16;
				break;
			case "Copper Hammer":
				SetDefaults(7);
				color = new Color(180, 100, 45, 80);
				useAnimation = 33;
				useTime = 23;
				scale = 1.1f;
				damage = 4;
				hammer = 35;
				tileBoost = -1;
				value = 400;
				netID = -17;
				break;
			case "Copper Bow":
				SetDefaults(99);
				useAnimation = 29;
				useTime = 29;
				color = new Color(180, 100, 45, 80);
				damage = 6;
				value = 350;
				netID = -18;
				break;
			case "Blue Phasesaber":
				SetDefaults(198);
				damage = 41;
				scale = 1.15f;
				flag = true;
				autoReuse = true;
				useTurn = true;
				rare = 4;
				netID = -19;
				break;
			case "Red Phasesaber":
				SetDefaults(199);
				damage = 41;
				scale = 1.15f;
				flag = true;
				autoReuse = true;
				useTurn = true;
				rare = 4;
				netID = -20;
				break;
			case "Green Phasesaber":
				SetDefaults(200);
				damage = 41;
				scale = 1.15f;
				flag = true;
				autoReuse = true;
				useTurn = true;
				rare = 4;
				netID = -21;
				break;
			case "Purple Phasesaber":
				SetDefaults(201);
				damage = 41;
				scale = 1.15f;
				flag = true;
				autoReuse = true;
				useTurn = true;
				rare = 4;
				netID = -22;
				break;
			case "White Phasesaber":
				SetDefaults(202);
				damage = 41;
				scale = 1.15f;
				flag = true;
				autoReuse = true;
				useTurn = true;
				rare = 4;
				netID = -23;
				break;
			case "Yellow Phasesaber":
				SetDefaults(203);
				damage = 41;
				scale = 1.15f;
				flag = true;
				autoReuse = true;
				useTurn = true;
				rare = 4;
				netID = -24;
				break;
			case "Tin Pickaxe":
				SetDefaults(1);
				color = new Color(170, 150, 80, 110);
				useTime = 14;
				pick = 35;
				useAnimation = 21;
				damage = 5;
				scale = 0.95f;
				value = 750;
				netID = -25;
				break;
			case "Tin Broadsword":
				SetDefaults(4);
				color = new Color(170, 150, 80, 110);
				useAnimation = 22;
				damage = 9;
				value = 675;
				netID = -26;
				break;
			case "Tin Shortsword":
				SetDefaults(6);
				color = new Color(170, 150, 80, 110);
				damage = 7;
				useAnimation = 12;
				scale = 0.85f;
				value = 525;
				netID = -27;
				break;
			case "Tin Axe":
				SetDefaults(10);
				color = new Color(170, 150, 80, 110);
				useTime = 20;
				axe = 8;
				useAnimation = 28;
				scale = 1.05f;
				damage = 4;
				value = 600;
				netID = -28;
				break;
			case "Tin Hammer":
				SetDefaults(7);
				color = new Color(170, 150, 80, 110);
				useAnimation = 31;
				useTime = 21;
				scale = 1.15f;
				damage = 6;
				hammer = 38;
				value = 600;
				netID = -29;
				break;
			case "Tin Bow":
				SetDefaults(99);
				useAnimation = 28;
				useTime = 28;
				color = new Color(170, 150, 80, 110);
				damage = 7;
				value = 525;
				netID = -30;
				break;
			case "Lead Pickaxe":
				SetDefaults(1);
				color = new Color(90, 100, 110, 170);
				useTime = 12;
				pick = 43;
				useAnimation = 19;
				damage = 6;
				scale = 1.025f;
				value = 3000;
				netID = -31;
				break;
			case "Lead Broadsword":
				SetDefaults(4);
				color = new Color(80, 90, 170, 160);
				useAnimation = 21;
				damage = 11;
				value = 2700;
				netID = -32;
				break;
			case "Lead Shortsword":
				SetDefaults(6);
				color = new Color(90, 100, 110, 170);
				damage = 9;
				useAnimation = 12;
				scale = 0.925f;
				value = 2100;
				netID = -33;
				break;
			case "Lead Axe":
				SetDefaults(10);
				color = new Color(90, 100, 110, 170);
				useTime = 19;
				axe = 10;
				useAnimation = 28;
				scale = 1.125f;
				damage = 6;
				value = 2400;
				netID = -34;
				break;
			case "Lead Hammer":
				SetDefaults(7);
				color = new Color(90, 100, 110, 170);
				useAnimation = 29;
				useTime = 19;
				scale = 1.225f;
				damage = 8;
				hammer = 43;
				value = 2400;
				netID = -35;
				break;
			case "Lead Bow":
				SetDefaults(99);
				useAnimation = 27;
				useTime = 27;
				color = new Color(90, 100, 110, 170);
				damage = 9;
				value = 2100;
				netID = -36;
				break;
			case "Tungsten Pickaxe":
				SetDefaults(1);
				color = new Color(130, 180, 130, 100);
				useTime = 19;
				pick = 50;
				useAnimation = 21;
				scale = 1.05f;
				damage = 6;
				value = 7500;
				netID = -37;
				toolTip = "Can mine Meteorite";
				break;
			case "Tungsten Broadsword":
				SetDefaults(4);
				color = new Color(130, 180, 130, 100);
				useAnimation = 20;
				damage = 12;
				scale *= 1.025f;
				value = 6750;
				netID = -38;
				break;
			case "Tungsten Shortsword":
				SetDefaults(6);
				color = new Color(130, 180, 130, 100);
				damage = 10;
				useAnimation = 11;
				scale = 0.95f;
				value = 5250;
				netID = -39;
				break;
			case "Tungsten Axe":
				SetDefaults(10);
				color = new Color(130, 180, 130, 100);
				useTime = 18;
				axe = 11;
				useAnimation = 26;
				scale = 1.15f;
				damage = 7;
				value = 4000;
				netID = -40;
				break;
			case "Tungsten Hammer":
				SetDefaults(7);
				color = new Color(130, 180, 130, 100);
				useAnimation = 28;
				useTime = 25;
				scale = 1.25f;
				damage = 9;
				hammer = 50;
				value = 6000;
				netID = -41;
				break;
			case "Tungsten Bow":
				SetDefaults(99);
				useAnimation = 26;
				useTime = 26;
				color = new Color(130, 180, 130, 100);
				damage = 10;
				value = 5250;
				netID = -42;
				break;
			case "Platinum Pickaxe":
				SetDefaults(1);
				color = new Color(110, 140, 200, 80);
				useTime = 15;
				pick = 59;
				useAnimation = 19;
				scale = 1.05f;
				damage = 7;
				value = 15000;
				toolTip = "Can mine Meteorite";
				netID = -43;
				break;
			case "Platinum Broadsword":
				SetDefaults(4);
				color = new Color(110, 140, 200, 80);
				useAnimation = 19;
				damage = 15;
				scale = 1.075f;
				value = 13500;
				netID = -44;
				break;
			case "Platinum Shortsword":
				SetDefaults(6);
				color = new Color(110, 140, 200, 80);
				damage = 13;
				useAnimation = 10;
				scale = 0.975f;
				value = 10500;
				netID = -45;
				break;
			case "Platinum Axe":
				SetDefaults(10);
				color = new Color(110, 140, 200, 80);
				useTime = 17;
				axe = 12;
				useAnimation = 25;
				scale = 1.175f;
				damage = 8;
				value = 12000;
				netID = -46;
				break;
			case "Platinum Hammer":
				SetDefaults(7);
				color = new Color(110, 140, 200, 80);
				useAnimation = 27;
				useTime = 21;
				scale = 1.275f;
				damage = 10;
				hammer = 59;
				value = 12000;
				netID = -47;
				break;
			case "Platinum Bow":
				SetDefaults(99);
				useAnimation = 25;
				useTime = 25;
				color = new Color(110, 140, 200, 80);
				damage = 13;
				value = 10500;
				netID = -48;
				break;
			default:
			{
				if (!(ItemName != ""))
				{
					break;
				}
				for (int i = 0; i < 2749; i++)
				{
					if (Main.itemName[i] == ItemName)
					{
						SetDefaults(i);
						checkMat();
						return;
					}
				}
				name = "";
				stack = 0;
				type = 0;
				break;
			}
			}
			if (type != 0)
			{
				if (flag)
				{
					material = false;
				}
				else
				{
					checkMat();
				}
				name = ItemName;
				name = Lang.itemName(netID);
				CheckTip();
			}
		}

		public Rectangle getRect()
		{
			return new Rectangle((int)position.X, (int)position.Y, width, height);
		}

		public bool checkMat()
		{
			if (type >= 71 && type <= 74)
			{
				material = false;
				return false;
			}
			for (int i = 0; i < Recipe.numRecipes; i++)
			{
				for (int j = 0; Main.recipe[i].requiredItem[j].type > 0; j++)
				{
					if (netID == Main.recipe[i].requiredItem[j].netID)
					{
						material = true;
						return true;
					}
				}
			}
			switch (type)
			{
			case 529:
			case 541:
			case 542:
			case 543:
			case 852:
			case 853:
			case 1151:
				material = true;
				return true;
			default:
				material = false;
				return false;
			}
		}

		public void netDefaults(int type)
		{
			if (type < 0)
			{
				switch (type)
				{
				case -1:
					SetDefaults("Gold Pickaxe");
					break;
				case -2:
					SetDefaults("Gold Broadsword");
					break;
				case -3:
					SetDefaults("Gold Shortsword");
					break;
				case -4:
					SetDefaults("Gold Axe");
					break;
				case -5:
					SetDefaults("Gold Hammer");
					break;
				case -6:
					SetDefaults("Gold Bow");
					break;
				case -7:
					SetDefaults("Silver Pickaxe");
					break;
				case -8:
					SetDefaults("Silver Broadsword");
					break;
				case -9:
					SetDefaults("Silver Shortsword");
					break;
				case -10:
					SetDefaults("Silver Axe");
					break;
				case -11:
					SetDefaults("Silver Hammer");
					break;
				case -12:
					SetDefaults("Silver Bow");
					break;
				case -13:
					SetDefaults("Copper Pickaxe");
					break;
				case -14:
					SetDefaults("Copper Broadsword");
					break;
				case -15:
					SetDefaults("Copper Shortsword");
					break;
				case -16:
					SetDefaults("Copper Axe");
					break;
				case -17:
					SetDefaults("Copper Hammer");
					break;
				case -18:
					SetDefaults("Copper Bow");
					break;
				case -19:
					SetDefaults("Blue Phasesaber");
					break;
				case -20:
					SetDefaults("Red Phasesaber");
					break;
				case -21:
					SetDefaults("Green Phasesaber");
					break;
				case -22:
					SetDefaults("Purple Phasesaber");
					break;
				case -23:
					SetDefaults("White Phasesaber");
					break;
				case -24:
					SetDefaults("Yellow Phasesaber");
					break;
				case -25:
					SetDefaults("Tin Pickaxe");
					break;
				case -26:
					SetDefaults("Tin Broadsword");
					break;
				case -27:
					SetDefaults("Tin Shortsword");
					break;
				case -28:
					SetDefaults("Tin Axe");
					break;
				case -29:
					SetDefaults("Tin Hammer");
					break;
				case -30:
					SetDefaults("Tin Bow");
					break;
				case -31:
					SetDefaults("Lead Pickaxe");
					break;
				case -32:
					SetDefaults("Lead Broadsword");
					break;
				case -33:
					SetDefaults("Lead Shortsword");
					break;
				case -34:
					SetDefaults("Lead Axe");
					break;
				case -35:
					SetDefaults("Lead Hammer");
					break;
				case -36:
					SetDefaults("Lead Bow");
					break;
				case -37:
					SetDefaults("Tungsten Pickaxe");
					break;
				case -38:
					SetDefaults("Tungsten Broadsword");
					break;
				case -39:
					SetDefaults("Tungsten Shortsword");
					break;
				case -40:
					SetDefaults("Tungsten Axe");
					break;
				case -41:
					SetDefaults("Tungsten Hammer");
					break;
				case -42:
					SetDefaults("Tungsten Bow");
					break;
				case -43:
					SetDefaults("Platinum Pickaxe");
					break;
				case -44:
					SetDefaults("Platinum Broadsword");
					break;
				case -45:
					SetDefaults("Platinum Shortsword");
					break;
				case -46:
					SetDefaults("Platinum Axe");
					break;
				case -47:
					SetDefaults("Platinum Hammer");
					break;
				case -48:
					SetDefaults("Platinum Bow");
					break;
				}
			}
			else
			{
				SetDefaults(type);
			}
		}

		public static int NPCtoBanner(int i)
		{
			switch (i)
			{
			case 102:
				return 1;
			case 250:
				return 2;
			case 257:
				return 3;
			case 69:
				return 4;
			case 157:
				return 5;
			case 77:
				return 6;
			case 49:
			case 93:
				return 7;
			case 74:
				return 8;
			case 163:
			case 238:
				return 9;
			case 241:
				return 10;
			case 242:
				return 11;
			case 239:
				return 12;
			case 39:
			case 40:
			case 41:
				return 13;
			case 46:
				return 14;
			case 120:
				return 15;
			case 85:
				return 16;
			case 109:
				return 17;
			case 47:
				return 18;
			case 57:
				return 19;
			case 67:
				return 20;
			case 173:
				return 21;
			case 179:
				return 22;
			case 83:
				return 23;
			case 62:
			case 66:
			case 156:
				return 24;
			case 2:
			case 133:
			case 190:
			case 191:
			case 192:
			case 193:
			case 194:
				return 25;
			case 177:
				return 26;
			case 6:
				return 27;
			case 84:
				return 28;
			case 161:
				return 29;
			case 181:
				return 30;
			case 182:
				return 31;
			case 224:
				return 32;
			case 226:
				return 33;
			case 162:
				return 34;
			case 259:
			case 260:
				return 35;
			case 256:
				return 36;
			case 122:
				return 37;
			case 111:
				return 38;
			case 29:
				return 39;
			case 73:
				return 40;
			case 27:
				return 41;
			case 28:
				return 42;
			case 55:
			case 230:
				return 43;
			case 48:
				return 44;
			case 60:
			case 151:
				return 45;
			case 174:
				return 46;
			case 42:
			case 176:
			case 231:
			case 232:
			case 233:
			case 234:
			case 235:
				return 47;
			case 169:
				return 48;
			case 206:
				return 49;
			case 24:
				return 50;
			case 63:
			case 64:
			case 103:
				return 51;
			case 236:
			case 237:
				return 52;
			case 198:
			case 199:
				return 53;
			case 43:
				return 54;
			case 23:
				return 55;
			case 205:
				return 56;
			case 78:
			case 79:
			case 80:
				return 57;
			case 258:
				return 58;
			case 252:
				return 59;
			case 170:
			case 171:
			case 180:
				return 60;
			case 58:
				return 61;
			case 212:
			case 213:
			case 214:
			case 215:
			case 216:
				return 62;
			case 75:
				return 63;
			case 223:
				return 64;
			case 253:
				return 65;
			case 65:
				return 66;
			case 21:
			case 201:
			case 202:
			case 203:
				return 67;
			case 32:
				return 68;
			case 1:
			case 147:
			case 184:
				return 69;
			case 185:
				return 70;
			case 164:
			case 165:
				return 71;
			case 254:
			case 255:
				return 72;
			case 166:
				return 73;
			case 153:
			case 154:
				return 74;
			case 141:
				return 75;
			case 225:
				return 76;
			case 86:
				return 77;
			case 158:
			case 159:
				return 78;
			case 61:
				return 79;
			case 195:
			case 196:
				return 80;
			case 104:
				return 81;
			case 155:
				return 82;
			case 98:
			case 99:
			case 100:
				return 83;
			case 10:
			case 11:
			case 12:
			case 95:
			case 96:
			case 97:
				return 84;
			case 82:
				return 85;
			case 87:
			case 88:
			case 89:
			case 90:
			case 91:
			case 92:
				return 86;
			case 3:
			case 132:
			case 186:
			case 187:
			case 188:
			case 189:
			case 200:
				return 87;
			default:
				return -1;
			}
		}

		public static int BannerToNPC(int i)
		{
			switch (i)
			{
			case 1:
				return 102;
			case 2:
				return 250;
			case 3:
				return 257;
			case 4:
				return 69;
			case 5:
				return 157;
			case 6:
				return 77;
			case 7:
				return 49;
			case 8:
				return 74;
			case 9:
				return 163;
			case 10:
				return 241;
			case 11:
				return 242;
			case 12:
				return 239;
			case 13:
				return 39;
			case 14:
				return 46;
			case 15:
				return 120;
			case 16:
				return 85;
			case 17:
				return 109;
			case 18:
				return 47;
			case 19:
				return 57;
			case 20:
				return 67;
			case 21:
				return 173;
			case 22:
				return 179;
			case 23:
				return 83;
			case 24:
				return 62;
			case 25:
				return 2;
			case 26:
				return 177;
			case 27:
				return 6;
			case 28:
				return 84;
			case 29:
				return 161;
			case 30:
				return 181;
			case 31:
				return 182;
			case 32:
				return 224;
			case 33:
				return 226;
			case 34:
				return 162;
			case 35:
				return 259;
			case 36:
				return 256;
			case 37:
				return 122;
			case 38:
				return 111;
			case 39:
				return 29;
			case 40:
				return 73;
			case 41:
				return 27;
			case 42:
				return 28;
			case 43:
				return 55;
			case 44:
				return 48;
			case 45:
				return 60;
			case 46:
				return 174;
			case 47:
				return 42;
			case 48:
				return 169;
			case 49:
				return 206;
			case 50:
				return 24;
			case 51:
				return 63;
			case 52:
				return 236;
			case 53:
				return 199;
			case 54:
				return 43;
			case 55:
				return 23;
			case 56:
				return 205;
			case 57:
				return 78;
			case 58:
				return 258;
			case 59:
				return 252;
			case 60:
				return 170;
			case 61:
				return 58;
			case 62:
				return 212;
			case 63:
				return 75;
			case 64:
				return 223;
			case 65:
				return 253;
			case 66:
				return 65;
			case 67:
				return 21;
			case 68:
				return 32;
			case 69:
				return 1;
			case 70:
				return 185;
			case 71:
				return 164;
			case 72:
				return 254;
			case 73:
				return 166;
			case 74:
				return 153;
			case 75:
				return 141;
			case 76:
				return 225;
			case 77:
				return 86;
			case 78:
				return 158;
			case 79:
				return 61;
			case 80:
				return 196;
			case 81:
				return 104;
			case 82:
				return 155;
			case 83:
				return 98;
			case 84:
				return 10;
			case 85:
				return 82;
			case 86:
				return 87;
			case 87:
				return 3;
			default:
				return -1;
			}
		}

		public void SetDefaults1(int type)
		{
			switch (type)
			{
			case 1:
				name = "Iron Pickaxe";
				color = new Color(160, 145, 130, 110);
				useStyle = 1;
				useTurn = true;
				useAnimation = 20;
				useTime = 13;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 5;
				pick = 40;
				useSound = 1;
				knockBack = 2f;
				value = 2000;
				melee = true;
				break;
			case 2:
				name = "Dirt Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 0;
				width = 12;
				height = 12;
				break;
			case 3:
				name = "Stone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 1;
				width = 12;
				height = 12;
				break;
			case 4:
				name = "Iron Broadsword";
				color = new Color(160, 145, 130, 110);
				useStyle = 1;
				useTurn = false;
				useAnimation = 21;
				useTime = 21;
				width = 24;
				height = 28;
				damage = 10;
				knockBack = 5f;
				useSound = 1;
				scale = 1f;
				value = 1800;
				melee = true;
				break;
			case 5:
				name = "Mushroom";
				useStyle = 2;
				useSound = 2;
				useTurn = false;
				useAnimation = 17;
				useTime = 17;
				width = 16;
				height = 18;
				healLife = 15;
				maxStack = 99;
				consumable = true;
				potion = true;
				value = 25;
				break;
			case 6:
				name = "Iron Shortsword";
				color = new Color(160, 145, 130, 110);
				useStyle = 3;
				useTurn = false;
				useAnimation = 12;
				useTime = 12;
				width = 24;
				height = 28;
				damage = 8;
				knockBack = 4f;
				scale = 0.9f;
				useSound = 1;
				useTurn = true;
				value = 1400;
				melee = true;
				break;
			case 7:
				name = "Iron Hammer";
				color = new Color(160, 145, 130, 110);
				autoReuse = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 30;
				useTime = 20;
				hammer = 40;
				width = 24;
				height = 28;
				damage = 7;
				knockBack = 5.5f;
				scale = 1.2f;
				useSound = 1;
				value = 1600;
				melee = true;
				break;
			case 8:
				flame = true;
				noWet = true;
				name = "Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				width = 10;
				height = 12;
				toolTip = "Provides light";
				value = 50;
				break;
			case 9:
				name = "Wood";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 30;
				width = 8;
				height = 10;
				break;
			case 10:
				name = "Iron Axe";
				color = new Color(160, 145, 130, 110);
				useStyle = 1;
				useTurn = true;
				useAnimation = 27;
				knockBack = 4.5f;
				useTime = 19;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 5;
				axe = 9;
				scale = 1.1f;
				useSound = 1;
				value = 1600;
				melee = true;
				break;
			case 11:
				name = "Iron Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 6;
				width = 12;
				height = 12;
				value = 500;
				break;
			case 12:
				name = "Copper Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 7;
				width = 12;
				height = 12;
				value = 250;
				break;
			case 13:
				name = "Gold Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 8;
				width = 12;
				height = 12;
				value = 2000;
				break;
			case 14:
				name = "Silver Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 9;
				width = 12;
				height = 12;
				value = 1000;
				break;
			case 15:
				name = "Copper Watch";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Tells the time";
				value = 1000;
				waistSlot = 2;
				break;
			case 16:
				name = "Silver Watch";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Tells the time";
				value = 5000;
				waistSlot = 7;
				break;
			case 17:
				name = "Gold Watch";
				width = 24;
				height = 28;
				accessory = true;
				rare = 1;
				toolTip = "Tells the time";
				value = 10000;
				waistSlot = 3;
				break;
			case 18:
				name = "Depth Meter";
				width = 24;
				height = 18;
				accessory = true;
				rare = 1;
				toolTip = "Shows depth";
				value = 10000;
				break;
			case 19:
				name = "Gold Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 6000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 6;
				break;
			case 20:
				name = "Copper Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 750;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 0;
				break;
			case 21:
				name = "Silver Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 3000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 4;
				break;
			case 22:
				name = "Iron Bar";
				color = new Color(160, 145, 130, 110);
				width = 20;
				height = 20;
				maxStack = 99;
				value = 1500;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 2;
				break;
			case 23:
				name = "Gel";
				width = 10;
				height = 12;
				maxStack = 999;
				alpha = 175;
				ammo = 23;
				color = new Color(0, 80, 255, 100);
				toolTip = "'Both tasty and flammable'";
				value = 5;
				break;
			case 24:
				name = "Wooden Sword";
				useStyle = 1;
				useTurn = false;
				useAnimation = 25;
				width = 24;
				height = 28;
				damage = 7;
				knockBack = 4f;
				scale = 0.95f;
				useSound = 1;
				value = 100;
				melee = true;
				break;
			case 25:
				name = "Wooden Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				width = 14;
				height = 28;
				value = 200;
				break;
			case 26:
				name = "Stone Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 1;
				width = 12;
				height = 12;
				break;
			case 27:
				name = "Acorn";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 20;
				width = 18;
				height = 18;
				value = 10;
				break;
			case 28:
				name = "Lesser Healing Potion";
				useSound = 3;
				healLife = 50;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				potion = true;
				value = 300;
				break;
			case 29:
				name = "Life Crystal";
				maxStack = 99;
				consumable = true;
				width = 18;
				height = 18;
				useStyle = 4;
				useTime = 30;
				useSound = 4;
				useAnimation = 30;
				toolTip = "Permanently increases maximum life by 20";
				rare = 2;
				value = 75000;
				break;
			case 30:
				name = "Dirt Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 16;
				width = 12;
				height = 12;
				break;
			case 31:
				name = "Bottle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 13;
				width = 16;
				height = 24;
				value = 20;
				break;
			case 32:
				name = "Wooden Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				width = 26;
				height = 20;
				value = 300;
				break;
			case 33:
				name = "Furnace";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 17;
				width = 26;
				height = 24;
				value = 300;
				toolTip = "Used for smelting ore";
				break;
			case 34:
				name = "Wooden Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				width = 12;
				height = 30;
				value = 150;
				break;
			case 35:
				name = "Iron Anvil";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 16;
				width = 28;
				height = 14;
				value = 5000;
				toolTip = "Used to craft items from metal bars";
				break;
			case 36:
				name = "Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				break;
			case 37:
				name = "Goggles";
				width = 28;
				height = 12;
				defense = 1;
				headSlot = 10;
				rare = 1;
				value = 1000;
				break;
			case 38:
				name = "Lens";
				width = 12;
				height = 20;
				maxStack = 99;
				value = 500;
				break;
			case 39:
				useStyle = 5;
				useAnimation = 30;
				useTime = 30;
				name = "Wooden Bow";
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 4;
				shootSpeed = 6.1f;
				noMelee = true;
				value = 100;
				ranged = true;
				break;
			case 40:
				name = "Wooden Arrow";
				shootSpeed = 3f;
				shoot = 1;
				damage = 4;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = 1;
				knockBack = 2f;
				value = 10;
				ranged = true;
				break;
			case 41:
				name = "Flaming Arrow";
				shootSpeed = 3.5f;
				shoot = 2;
				damage = 6;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = 1;
				knockBack = 2f;
				value = 15;
				ranged = true;
				break;
			case 42:
				useStyle = 1;
				name = "Shuriken";
				shootSpeed = 9f;
				shoot = 3;
				damage = 10;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 20;
				ranged = true;
				break;
			case 43:
				useStyle = 4;
				name = "Suspicious Looking Eye";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons the Eye of Cthulhu";
				break;
			case 44:
				useStyle = 5;
				useAnimation = 25;
				useTime = 25;
				name = "Demon Bow";
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 14;
				shootSpeed = 6.7f;
				knockBack = 1f;
				alpha = 30;
				rare = 1;
				noMelee = true;
				value = 18000;
				ranged = true;
				break;
			case 45:
				name = "War Axe of the Night";
				autoReuse = true;
				useStyle = 1;
				useAnimation = 30;
				knockBack = 6f;
				useTime = 15;
				width = 24;
				height = 28;
				damage = 20;
				axe = 15;
				scale = 1.2f;
				useSound = 1;
				rare = 1;
				value = 13500;
				melee = true;
				break;
			case 46:
				name = "Light's Bane";
				useStyle = 1;
				useAnimation = 20;
				knockBack = 5f;
				width = 24;
				height = 28;
				damage = 17;
				scale = 1.1f;
				useSound = 1;
				rare = 1;
				value = 13500;
				melee = true;
				break;
			case 47:
				name = "Unholy Arrow";
				shootSpeed = 3.4f;
				shoot = 4;
				damage = 8;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = 1;
				knockBack = 3f;
				alpha = 30;
				rare = 1;
				value = 40;
				ranged = true;
				break;
			case 48:
				name = "Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				width = 26;
				height = 22;
				value = 500;
				break;
			case 49:
				name = "Band of Regeneration";
				width = 22;
				height = 22;
				accessory = true;
				lifeRegen = 1;
				rare = 1;
				toolTip = "Slowly regenerates life";
				value = 50000;
				handOnSlot = 2;
				break;
			case 50:
				name = "Magic Mirror";
				useTurn = true;
				width = 20;
				height = 20;
				useStyle = 4;
				useTime = 90;
				useSound = 6;
				useAnimation = 90;
				toolTip = "Gaze in the mirror to return home";
				rare = 1;
				value = 50000;
				break;
			case 51:
				name = "Jester's Arrow";
				shootSpeed = 0.5f;
				shoot = 5;
				damage = 9;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = 1;
				knockBack = 4f;
				rare = 1;
				value = 100;
				ranged = true;
				break;
			case 52:
				type = 52;
				name = "Angel Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 1;
				break;
			case 53:
				name = "Cloud in a Bottle";
				width = 16;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "Allows the holder to double jump";
				value = 50000;
				waistSlot = 1;
				break;
			case 54:
				name = "Hermes Boots";
				width = 28;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "The wearer can run super fast";
				value = 50000;
				shoeSlot = 6;
				break;
			case 55:
				noMelee = true;
				useStyle = 1;
				name = "Enchanted Boomerang";
				shootSpeed = 10f;
				shoot = 6;
				damage = 13;
				knockBack = 8f;
				width = 14;
				height = 28;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 1;
				value = 50000;
				melee = true;
				break;
			case 56:
				name = "Demonite Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 22;
				width = 12;
				height = 12;
				rare = 1;
				toolTip = "'Pulsing with dark energy'";
				value = 4000;
				break;
			case 57:
				name = "Demonite Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				rare = 1;
				toolTip = "'Pulsing with dark energy'";
				value = 16000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 8;
				break;
			case 58:
				name = "Heart";
				width = 12;
				height = 12;
				break;
			case 59:
				name = "Corrupt Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 23;
				width = 14;
				height = 14;
				value = 500;
				break;
			case 60:
				name = "Vile Mushroom";
				width = 16;
				height = 18;
				maxStack = 99;
				value = 50;
				break;
			case 61:
				name = "Ebonstone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 25;
				width = 12;
				height = 12;
				break;
			case 62:
				name = "Grass Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 2;
				width = 14;
				height = 14;
				value = 20;
				break;
			case 63:
				name = "Sunflower";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 27;
				width = 26;
				height = 26;
				value = 200;
				break;
			case 64:
				mana = 10;
				damage = 10;
				useStyle = 1;
				name = "Vilethorn";
				shootSpeed = 32f;
				shoot = 7;
				width = 26;
				height = 28;
				useSound = 8;
				useAnimation = 28;
				useTime = 28;
				rare = 1;
				noMelee = true;
				knockBack = 1f;
				toolTip = "Summons a vile thorn";
				value = 10000;
				magic = true;
				break;
			case 65:
				knockBack = 5f;
				alpha = 100;
				color = new Color(150, 150, 150, 0);
				damage = 22;
				useStyle = 1;
				scale = 1.25f;
				name = "Starfury";
				shootSpeed = 20f;
				shoot = 9;
				width = 14;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 40;
				rare = 2;
				toolTip = "Causes stars to rain from the sky";
				toolTip2 = "'Forged with the fury of heaven'";
				value = 50000;
				melee = true;
				break;
			case 66:
				useStyle = 1;
				name = "Purification Powder";
				shootSpeed = 4f;
				shoot = 10;
				width = 16;
				height = 24;
				maxStack = 99;
				consumable = true;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noMelee = true;
				toolTip = "Cleanses the corruption";
				value = 75;
				break;
			case 67:
				damage = 0;
				useStyle = 1;
				name = "Vile Powder";
				shootSpeed = 4f;
				shoot = 11;
				width = 16;
				height = 24;
				maxStack = 99;
				consumable = true;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noMelee = true;
				value = 100;
				toolTip = "Removes the Hallow";
				break;
			case 68:
				name = "Rotten Chunk";
				width = 18;
				height = 20;
				maxStack = 99;
				toolTip = "'Looks tasty!'";
				value = 10;
				break;
			case 69:
				name = "Worm Tooth";
				width = 8;
				height = 20;
				maxStack = 99;
				value = 100;
				break;
			case 70:
				useStyle = 4;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				name = "Worm Food";
				width = 28;
				height = 28;
				maxStack = 20;
				toolTip = "Summons the Eater of Worlds";
				break;
			case 71:
				name = "Copper Coin";
				width = 10;
				height = 12;
				maxStack = 100;
				value = 5;
				ammo = 71;
				shoot = 158;
				notAmmo = true;
				damage = 25;
				shootSpeed = 1f;
				ranged = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 330;
				noMelee = true;
				break;
			case 72:
				name = "Silver Coin";
				width = 10;
				height = 12;
				maxStack = 100;
				value = 500;
				ammo = 71;
				notAmmo = true;
				damage = 50;
				shoot = 159;
				shootSpeed = 2f;
				ranged = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 331;
				noMelee = true;
				break;
			case 73:
				name = "Gold Coin";
				width = 10;
				height = 12;
				maxStack = 100;
				value = 50000;
				ammo = 71;
				notAmmo = true;
				damage = 100;
				shoot = 160;
				shootSpeed = 3f;
				ranged = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 332;
				noMelee = true;
				break;
			case 74:
				name = "Platinum Coin";
				width = 10;
				height = 12;
				maxStack = 999;
				value = 5000000;
				ammo = 71;
				notAmmo = true;
				damage = 200;
				shoot = 161;
				shootSpeed = 4f;
				ranged = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 333;
				noMelee = true;
				break;
			case 75:
				name = "Fallen Star";
				width = 18;
				height = 20;
				maxStack = 100;
				alpha = 75;
				ammo = 15;
				toolTip = "Disappears after the sunrise";
				value = 500;
				useStyle = 4;
				useSound = 4;
				useTurn = false;
				useAnimation = 17;
				useTime = 17;
				consumable = true;
				rare = 1;
				break;
			case 76:
				name = "Copper Greaves";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 1;
				value = 750;
				break;
			case 77:
				name = "Iron Greaves";
				width = 18;
				height = 18;
				defense = 2;
				legSlot = 2;
				value = 3000;
				break;
			case 78:
				name = "Silver Greaves";
				width = 18;
				height = 18;
				defense = 3;
				legSlot = 3;
				value = 7500;
				break;
			case 79:
				name = "Gold Greaves";
				width = 18;
				height = 18;
				defense = 4;
				legSlot = 4;
				value = 15000;
				break;
			case 80:
				name = "Copper Chainmail";
				width = 18;
				height = 18;
				defense = 2;
				bodySlot = 1;
				value = 1000;
				break;
			case 81:
				name = "Iron Chainmail";
				width = 18;
				height = 18;
				defense = 3;
				bodySlot = 2;
				value = 4000;
				break;
			case 82:
				name = "Silver Chainmail";
				width = 18;
				height = 18;
				defense = 4;
				bodySlot = 3;
				value = 10000;
				break;
			case 83:
				name = "Gold Chainmail";
				width = 18;
				height = 18;
				defense = 5;
				bodySlot = 4;
				value = 20000;
				break;
			case 84:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Grappling Hook";
				shootSpeed = 11.5f;
				shoot = 13;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				toolTip = "'Get over here!'";
				break;
			case 85:
				name = "Chain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 8;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 214;
				width = 12;
				height = 12;
				value = 1000;
				tileBoost += 2;
				toolTip = "Can be climbed on";
				break;
			case 86:
				name = "Shadow Scale";
				width = 14;
				height = 18;
				maxStack = 99;
				rare = 1;
				value = 500;
				break;
			case 87:
				name = "Piggy Bank";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 29;
				width = 20;
				height = 12;
				value = 10000;
				break;
			case 88:
				name = "Mining Helmet";
				width = 22;
				height = 16;
				defense = 1;
				headSlot = 11;
				rare = 1;
				value = 80000;
				toolTip = "Provides light when worn";
				break;
			case 89:
				name = "Copper Helmet";
				width = 18;
				height = 18;
				defense = 1;
				headSlot = 1;
				value = 1250;
				break;
			case 90:
				name = "Iron Helmet";
				width = 18;
				height = 18;
				defense = 2;
				headSlot = 2;
				value = 5000;
				break;
			case 91:
				name = "Silver Helmet";
				width = 18;
				height = 18;
				defense = 3;
				headSlot = 3;
				value = 12500;
				break;
			case 92:
				name = "Gold Helmet";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 4;
				value = 25000;
				break;
			case 93:
				name = "Wood Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 4;
				width = 12;
				height = 12;
				break;
			case 94:
				name = "Wood Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				width = 8;
				height = 10;
				break;
			case 95:
				useStyle = 5;
				useAnimation = 16;
				useTime = 16;
				name = "Flintlock Pistol";
				width = 24;
				height = 28;
				shoot = 14;
				useAmmo = 14;
				useSound = 11;
				damage = 10;
				shootSpeed = 5f;
				noMelee = true;
				value = 50000;
				scale = 0.9f;
				rare = 1;
				ranged = true;
				break;
			case 96:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 41;
				useTime = 41;
				name = "Musket";
				width = 44;
				height = 14;
				shoot = 10;
				useAmmo = 14;
				useSound = 11;
				damage = 25;
				shootSpeed = 8.5f;
				noMelee = true;
				value = 100000;
				knockBack = 4.5f;
				rare = 1;
				ranged = true;
				break;
			case 97:
				name = "Musket Ball";
				shootSpeed = 4f;
				shoot = 14;
				damage = 7;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 14;
				knockBack = 2f;
				value = 7;
				ranged = true;
				break;
			case 98:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 8;
				useTime = 8;
				name = "Minishark";
				width = 50;
				height = 18;
				shoot = 10;
				useAmmo = 14;
				useSound = 11;
				damage = 6;
				shootSpeed = 7f;
				noMelee = true;
				value = 350000;
				rare = 2;
				toolTip = "33% chance to not consume ammo";
				toolTip2 = "'Half shark, half gun, completely awesome.'";
				ranged = true;
				break;
			case 99:
				useStyle = 5;
				useAnimation = 28;
				useTime = 28;
				name = "Iron Bow";
				color = new Color(160, 145, 130, 110);
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 8;
				shootSpeed = 6.6f;
				noMelee = true;
				value = 1400;
				ranged = true;
				break;
			case 100:
				name = "Shadow Greaves";
				width = 18;
				height = 18;
				defense = 6;
				legSlot = 5;
				rare = 1;
				value = 22500;
				toolTip = "7% increased melee speed";
				break;
			case 101:
				name = "Shadow Scalemail";
				width = 18;
				height = 18;
				defense = 7;
				bodySlot = 5;
				rare = 1;
				value = 30000;
				toolTip = "7% increased melee speed";
				break;
			case 102:
				name = "Shadow Helmet";
				width = 18;
				height = 18;
				defense = 6;
				headSlot = 5;
				rare = 1;
				value = 37500;
				toolTip = "7% increased melee speed";
				break;
			case 103:
				name = "Nightmare Pickaxe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 20;
				useTime = 15;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 9;
				pick = 65;
				useSound = 1;
				knockBack = 3f;
				rare = 1;
				value = 18000;
				scale = 1.15f;
				toolTip = "Able to mine Hellstone";
				melee = true;
				break;
			case 104:
				name = "The Breaker";
				autoReuse = true;
				useStyle = 1;
				useAnimation = 45;
				useTime = 19;
				hammer = 55;
				width = 24;
				height = 28;
				damage = 24;
				knockBack = 6f;
				scale = 1.3f;
				useSound = 1;
				rare = 1;
				value = 15000;
				melee = true;
				break;
			case 105:
				flame = true;
				noWet = true;
				name = "Candle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 33;
				width = 8;
				height = 18;
				holdStyle = 1;
				break;
			case 106:
				name = "Copper Chandelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				width = 26;
				height = 26;
				value = 3000;
				break;
			case 107:
				name = "Silver Chandelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 1;
				width = 26;
				height = 26;
				value = 12000;
				break;
			case 108:
				name = "Gold Chandelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 2;
				width = 26;
				height = 26;
				value = 24000;
				break;
			case 109:
				name = "Mana Crystal";
				maxStack = 99;
				consumable = true;
				width = 18;
				height = 18;
				useStyle = 4;
				useTime = 30;
				useSound = 29;
				useAnimation = 30;
				toolTip = "Permanently increases maximum mana by 20";
				rare = 2;
				break;
			case 110:
				name = "Lesser Mana Potion";
				useSound = 3;
				healMana = 50;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 25;
				consumable = true;
				width = 14;
				height = 24;
				value = 200;
				break;
			case 111:
				name = "Band of Starpower";
				width = 22;
				height = 22;
				accessory = true;
				rare = 1;
				toolTip = "Increases maximum mana by 20";
				value = 50000;
				handOnSlot = 3;
				break;
			case 112:
				mana = 17;
				damage = 44;
				useStyle = 1;
				name = "Flower of Fire";
				shootSpeed = 6f;
				shoot = 15;
				width = 26;
				height = 28;
				useSound = 20;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				knockBack = 5.5f;
				toolTip = "Throws balls of fire";
				value = 10000;
				magic = true;
				break;
			case 113:
				mana = 10;
				channel = true;
				damage = 23;
				useStyle = 1;
				name = "Magic Missile";
				shootSpeed = 6f;
				shoot = 16;
				width = 26;
				height = 28;
				useSound = 9;
				useAnimation = 17;
				useTime = 17;
				rare = 2;
				noMelee = true;
				knockBack = 5.5f;
				toolTip = "Casts a controllable missile";
				value = 10000;
				magic = true;
				break;
			case 114:
				channel = true;
				damage = 0;
				useStyle = 1;
				name = "Dirt Rod";
				shoot = 17;
				width = 26;
				height = 28;
				useSound = 8;
				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				knockBack = 5f;
				toolTip = "Magically moves dirt";
				value = 200000;
				break;
			case 115:
				channel = true;
				damage = 0;
				useStyle = 4;
				name = "Shadow Orb";
				shoot = 18;
				width = 24;
				height = 24;
				useSound = 8;
				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				toolTip = "Creates a magical shadow orb";
				value = 10000;
				buffType = 19;
				break;
			case 116:
				name = "Meteorite";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 37;
				width = 12;
				height = 12;
				value = 1000;
				break;
			case 117:
				name = "Meteorite Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				rare = 1;
				toolTip = "'Warm to the touch'";
				value = 7000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 9;
				break;
			case 118:
				name = "Hook";
				maxStack = 99;
				width = 18;
				height = 18;
				value = 1000;
				toolTip = "Sometimes dropped by Skeletons and Piranha";
				break;
			case 119:
				noMelee = true;
				useStyle = 1;
				name = "Flamarang";
				shootSpeed = 11f;
				shoot = 19;
				damage = 32;
				knockBack = 8f;
				width = 14;
				height = 28;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 3;
				value = 100000;
				melee = true;
				break;
			case 120:
				useStyle = 5;
				useAnimation = 25;
				useTime = 25;
				name = "Molten Fury";
				width = 14;
				height = 32;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 29;
				shootSpeed = 8f;
				knockBack = 2f;
				alpha = 30;
				rare = 3;
				noMelee = true;
				scale = 1.1f;
				value = 27000;
				toolTip = "Lights wooden arrows ablaze";
				ranged = true;
				break;
			case 121:
				name = "Fiery Greatsword";
				useStyle = 1;
				useAnimation = 34;
				knockBack = 6.5f;
				width = 24;
				height = 28;
				damage = 36;
				scale = 1.3f;
				useSound = 1;
				rare = 3;
				value = 27000;
				toolTip = "'It's made out of fire!'";
				melee = true;
				break;
			}
			switch (type)
			{
			case 122:
				name = "Molten Pickaxe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 25;
				useTime = 25;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 12;
				pick = 100;
				scale = 1.15f;
				useSound = 1;
				knockBack = 2f;
				rare = 3;
				value = 27000;
				melee = true;
				break;
			case 123:
				name = "Meteor Helmet";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 6;
				rare = 1;
				value = 45000;
				toolTip = "7% increased magic damage";
				break;
			case 124:
				name = "Meteor Suit";
				width = 18;
				height = 18;
				defense = 6;
				bodySlot = 6;
				rare = 1;
				value = 30000;
				toolTip = "7% increased magic damage";
				break;
			case 125:
				name = "Meteor Leggings";
				width = 18;
				height = 18;
				defense = 5;
				legSlot = 6;
				rare = 1;
				value = 30000;
				toolTip = "7% increased magic damage";
				break;
			case 126:
				name = "Bottled Water";
				useSound = 3;
				healLife = 20;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				potion = true;
				value = 20;
				break;
			case 127:
				autoReuse = true;
				useStyle = 5;
				useAnimation = 17;
				useTime = 17;
				name = "Space Gun";
				width = 24;
				height = 28;
				shoot = 20;
				mana = 7;
				useSound = 12;
				knockBack = 0.75f;
				damage = 19;
				shootSpeed = 10f;
				noMelee = true;
				scale = 0.8f;
				rare = 1;
				magic = true;
				value = 20000;
				break;
			case 128:
				name = "Rocket Boots";
				width = 28;
				height = 24;
				accessory = true;
				rare = 3;
				toolTip = "Allows flight";
				value = 50000;
				shoeSlot = 12;
				break;
			case 129:
				name = "Gray Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 38;
				width = 12;
				height = 12;
				break;
			case 130:
				name = "Gray Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 5;
				width = 12;
				height = 12;
				break;
			case 131:
				name = "Red Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 39;
				width = 12;
				height = 12;
				break;
			case 132:
				name = "Red Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 6;
				width = 12;
				height = 12;
				break;
			case 133:
				name = "Clay Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 40;
				width = 12;
				height = 12;
				break;
			case 134:
				name = "Blue Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 41;
				width = 12;
				height = 12;
				break;
			case 135:
				name = "Blue Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 17;
				width = 12;
				height = 12;
				break;
			case 136:
				name = "Chain Lantern";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				break;
			case 137:
				name = "Green Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 43;
				width = 12;
				height = 12;
				break;
			case 138:
				name = "Green Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 18;
				width = 12;
				height = 12;
				break;
			case 139:
				name = "Pink Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 44;
				width = 12;
				height = 12;
				break;
			case 140:
				name = "Pink Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 19;
				width = 12;
				height = 12;
				break;
			case 141:
				name = "Gold Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 45;
				width = 12;
				height = 12;
				break;
			case 142:
				name = "Gold Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 10;
				width = 12;
				height = 12;
				break;
			case 143:
				name = "Silver Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 46;
				width = 12;
				height = 12;
				break;
			case 144:
				name = "Silver Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 11;
				width = 12;
				height = 12;
				break;
			case 145:
				name = "Copper Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 47;
				width = 12;
				height = 12;
				break;
			case 146:
				name = "Copper Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 12;
				width = 12;
				height = 12;
				break;
			case 147:
				name = "Spike";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 48;
				width = 12;
				height = 12;
				break;
			case 148:
				flame = true;
				noWet = true;
				name = "Water Candle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 49;
				width = 8;
				height = 18;
				holdStyle = 1;
				toolTip = "Holding this may attract unwanted attention";
				break;
			case 149:
				name = "Book";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 50;
				width = 24;
				height = 28;
				toolTip = "'It contains strange symbols'";
				break;
			case 150:
				name = "Cobweb";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 51;
				width = 20;
				height = 24;
				alpha = 100;
				break;
			case 151:
				name = "Necro Helmet";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 7;
				rare = 2;
				value = 45000;
				toolTip = "4% increased ranged damage.";
				break;
			case 152:
				name = "Necro Breastplate";
				width = 18;
				height = 18;
				defense = 6;
				bodySlot = 7;
				rare = 2;
				value = 30000;
				toolTip = "4% increased ranged damage.";
				break;
			case 153:
				name = "Necro Greaves";
				width = 18;
				height = 18;
				defense = 5;
				legSlot = 7;
				rare = 2;
				value = 30000;
				toolTip = "4% increased ranged damage.";
				break;
			case 154:
				name = "Bone";
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 14;
				value = 50;
				useAnimation = 12;
				useTime = 12;
				useStyle = 1;
				useSound = 1;
				shootSpeed = 8f;
				noUseGraphic = true;
				damage = 22;
				knockBack = 4f;
				shoot = 21;
				ranged = true;
				break;
			case 155:
				autoReuse = true;
				useTurn = true;
				name = "Muramasa";
				useStyle = 1;
				useAnimation = 20;
				width = 40;
				height = 40;
				damage = 18;
				scale = 1.1f;
				useSound = 1;
				rare = 2;
				value = 27000;
				knockBack = 1f;
				melee = true;
				break;
			case 156:
				name = "Cobalt Shield";
				width = 24;
				height = 28;
				rare = 2;
				value = 27000;
				accessory = true;
				defense = 1;
				toolTip = "Grants immunity to knockback";
				shieldSlot = 1;
				break;
			case 157:
				mana = 6;
				autoReuse = true;
				name = "Aqua Scepter";
				useStyle = 5;
				useAnimation = 16;
				useTime = 8;
				knockBack = 5f;
				width = 38;
				height = 10;
				damage = 15;
				scale = 1f;
				shoot = 22;
				shootSpeed = 11f;
				useSound = 13;
				rare = 2;
				value = 27000;
				toolTip = "Sprays out a shower of water";
				magic = true;
				break;
			case 158:
				name = "Lucky Horseshoe";
				width = 20;
				height = 22;
				rare = 1;
				value = 27000;
				accessory = true;
				toolTip = "Negates fall damage";
				break;
			case 159:
				name = "Shiny Red Balloon";
				width = 14;
				height = 28;
				rare = 1;
				value = 27000;
				accessory = true;
				toolTip = "Increases jump height";
				balloonSlot = 8;
				break;
			case 160:
				autoReuse = true;
				noMelee = true;
				name = "Harpoon";
				useStyle = 5;
				useAnimation = 30;
				useTime = 30;
				knockBack = 6f;
				width = 30;
				height = 10;
				damage = 25;
				scale = 1.1f;
				shoot = 23;
				shootSpeed = 11f;
				useSound = 10;
				rare = 2;
				value = 27000;
				ranged = true;
				break;
			case 161:
				useStyle = 1;
				name = "Spiky Ball";
				shootSpeed = 5f;
				shoot = 24;
				knockBack = 1f;
				damage = 15;
				width = 10;
				height = 10;
				maxStack = 999;
				consumable = true;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 80;
				ranged = true;
				break;
			case 162:
				name = "Ball O' Hurt";
				useStyle = 5;
				useAnimation = 45;
				useTime = 45;
				knockBack = 6.5f;
				width = 30;
				height = 10;
				damage = 15;
				scale = 1.1f;
				noUseGraphic = true;
				shoot = 25;
				shootSpeed = 12f;
				useSound = 1;
				rare = 1;
				value = 27000;
				melee = true;
				channel = true;
				noMelee = true;
				break;
			case 163:
				name = "Blue Moon";
				noMelee = true;
				useStyle = 5;
				useAnimation = 45;
				useTime = 45;
				knockBack = 7f;
				width = 30;
				height = 10;
				damage = 23;
				scale = 1.1f;
				noUseGraphic = true;
				shoot = 26;
				shootSpeed = 12f;
				useSound = 1;
				rare = 2;
				value = 27000;
				melee = true;
				channel = true;
				break;
			case 164:
				autoReuse = false;
				useStyle = 5;
				useAnimation = 12;
				useTime = 12;
				name = "Handgun";
				width = 24;
				height = 24;
				shoot = 14;
				knockBack = 3f;
				useAmmo = 14;
				useSound = 41;
				damage = 15;
				shootSpeed = 10f;
				noMelee = true;
				value = 50000;
				scale = 0.85f;
				rare = 2;
				ranged = true;
				break;
			case 165:
				autoReuse = true;
				rare = 2;
				mana = 10;
				useSound = 21;
				name = "Water Bolt";
				useStyle = 5;
				damage = 17;
				useAnimation = 17;
				useTime = 17;
				width = 24;
				height = 28;
				shoot = 27;
				scale = 0.9f;
				shootSpeed = 4.5f;
				knockBack = 5f;
				toolTip = "Casts a slow moving bolt of water";
				magic = true;
				value = 50000;
				break;
			case 166:
				useStyle = 1;
				name = "Bomb";
				shootSpeed = 5f;
				shoot = 28;
				width = 20;
				height = 20;
				maxStack = 100;
				consumable = true;
				useSound = 1;
				useAnimation = 25;
				useTime = 25;
				noUseGraphic = true;
				noMelee = true;
				value = buyPrice(0, 0, 3);
				damage = 0;
				toolTip = "A small explosion that will destroy some tiles";
				break;
			case 167:
				useStyle = 1;
				name = "Dynamite";
				shootSpeed = 4f;
				shoot = 29;
				width = 8;
				height = 28;
				maxStack = 30;
				consumable = true;
				useSound = 1;
				useAnimation = 40;
				useTime = 40;
				noUseGraphic = true;
				noMelee = true;
				value = sellPrice(0, 0, 30);
				rare = 1;
				toolTip = "A large explosion that will destroy most tiles";
				break;
			case 168:
				useStyle = 5;
				name = "Grenade";
				shootSpeed = 5.5f;
				shoot = 30;
				width = 20;
				height = 20;
				maxStack = 99;
				consumable = true;
				useSound = 1;
				useAnimation = 45;
				useTime = 45;
				noUseGraphic = true;
				noMelee = true;
				value = 75;
				damage = 60;
				knockBack = 8f;
				toolTip = "A small explosion that will not destroy tiles";
				ranged = true;
				break;
			case 169:
				name = "Sand Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 53;
				width = 12;
				height = 12;
				ammo = 42;
				break;
			case 170:
				name = "Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 54;
				width = 12;
				height = 12;
				break;
			case 171:
				name = "Sign";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 55;
				width = 28;
				height = 28;
				break;
			case 172:
				name = "Ash Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 57;
				width = 12;
				height = 12;
				break;
			case 173:
				name = "Obsidian";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 56;
				width = 12;
				height = 12;
				break;
			case 174:
				name = "Hellstone";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 58;
				width = 12;
				height = 12;
				rare = 2;
				break;
			case 175:
				name = "Hellstone Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				rare = 2;
				toolTip = "'Hot to the touch'";
				value = 20000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 10;
				break;
			case 176:
				name = "Mud Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 59;
				width = 12;
				height = 12;
				break;
			case 181:
				name = "Amethyst";
				createTile = 178;
				placeStyle = 0;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 1875;
				break;
			case 180:
				name = "Topaz";
				createTile = 178;
				placeStyle = 1;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 3750;
				break;
			case 177:
				name = "Sapphire";
				createTile = 178;
				placeStyle = 2;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 5625;
				break;
			case 179:
				name = "Emerald";
				createTile = 178;
				placeStyle = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 7500;
				break;
			case 178:
				name = "Ruby";
				createTile = 178;
				placeStyle = 4;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 11250;
				break;
			case 182:
				name = "Diamond";
				createTile = 178;
				placeStyle = 5;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 15000;
				break;
			case 183:
				name = "Glowing Mushroom";
				width = 16;
				height = 18;
				value = 50;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 190;
				break;
			case 184:
				name = "Star";
				width = 12;
				height = 12;
				break;
			case 185:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Ivy Whip";
				shootSpeed = 13f;
				shoot = 32;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				value = 20000;
				break;
			case 186:
				name = "Breathing Reed";
				width = 44;
				height = 44;
				rare = 1;
				value = 10000;
				holdStyle = 2;
				toolTip = "'Because not drowning is kinda nice'";
				break;
			case 187:
				name = "Flipper";
				width = 28;
				height = 28;
				rare = 1;
				value = 10000;
				accessory = true;
				toolTip = "Grants the ability to swim";
				shoeSlot = 1;
				break;
			case 188:
				name = "Healing Potion";
				useSound = 3;
				healLife = 100;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				rare = 1;
				potion = true;
				value = 1000;
				break;
			case 189:
				name = "Mana Potion";
				useSound = 3;
				healMana = 100;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 50;
				consumable = true;
				width = 14;
				height = 24;
				rare = 1;
				value = 500;
				break;
			case 190:
				name = "Blade of Grass";
				useStyle = 1;
				useAnimation = 30;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 28;
				scale = 1.4f;
				useSound = 1;
				rare = 3;
				value = 27000;
				melee = true;
				break;
			case 191:
				noMelee = true;
				useStyle = 1;
				name = "Thorn Chakram";
				shootSpeed = 11f;
				shoot = 33;
				damage = 25;
				knockBack = 8f;
				width = 14;
				height = 28;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 3;
				value = 50000;
				melee = true;
				break;
			case 192:
				name = "Obsidian Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 75;
				width = 12;
				height = 12;
				break;
			case 193:
				name = "Obsidian Skull";
				width = 20;
				height = 22;
				rare = 2;
				value = 27000;
				accessory = true;
				defense = 1;
				toolTip = "Grants immunity to fire blocks";
				break;
			case 194:
				name = "Mushroom Grass Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 70;
				width = 14;
				height = 14;
				value = 150;
				break;
			case 195:
				name = "Jungle Grass Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 60;
				width = 14;
				height = 14;
				value = 150;
				break;
			case 196:
				name = "Wooden Hammer";
				autoReuse = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 37;
				useTime = 25;
				hammer = 25;
				width = 24;
				height = 28;
				damage = 2;
				knockBack = 5.5f;
				scale = 1.2f;
				useSound = 1;
				tileBoost = -1;
				value = 50;
				melee = true;
				break;
			case 197:
				autoReuse = true;
				useStyle = 5;
				useAnimation = 12;
				useTime = 12;
				name = "Star Cannon";
				width = 50;
				height = 18;
				shoot = 12;
				useAmmo = 15;
				useSound = 9;
				damage = 55;
				shootSpeed = 14f;
				noMelee = true;
				value = 500000;
				rare = 2;
				toolTip = "Shoots fallen stars";
				ranged = true;
				break;
			case 198:
				name = "Blue Phaseblade";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 21;
				scale = 1f;
				useSound = 15;
				rare = 1;
				value = 27000;
				melee = true;
				break;
			case 199:
				name = "Red Phaseblade";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 21;
				scale = 1f;
				useSound = 15;
				rare = 1;
				value = 27000;
				melee = true;
				break;
			case 200:
				name = "Green Phaseblade";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 21;
				scale = 1f;
				useSound = 15;
				rare = 1;
				value = 27000;
				melee = true;
				break;
			case 201:
				name = "Purple Phaseblade";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 21;
				scale = 1f;
				useSound = 15;
				rare = 1;
				value = 27000;
				melee = true;
				break;
			case 202:
				name = "White Phaseblade";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 21;
				scale = 1f;
				useSound = 15;
				rare = 1;
				value = 27000;
				melee = true;
				break;
			case 203:
				name = "Yellow Phaseblade";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 3f;
				width = 40;
				height = 40;
				damage = 21;
				scale = 1f;
				useSound = 15;
				rare = 1;
				value = 27000;
				melee = true;
				break;
			case 204:
				name = "Meteor Hamaxe";
				useTurn = true;
				autoReuse = true;
				useStyle = 1;
				useAnimation = 30;
				useTime = 16;
				hammer = 60;
				axe = 20;
				width = 24;
				height = 28;
				damage = 20;
				knockBack = 7f;
				scale = 1.2f;
				useSound = 1;
				rare = 1;
				value = 15000;
				melee = true;
				break;
			case 205:
				name = "Empty Bucket";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				width = 20;
				height = 20;
				headSlot = 13;
				defense = 1;
				maxStack = 99;
				autoReuse = true;
				break;
			case 206:
				name = "Water Bucket";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				width = 20;
				height = 20;
				maxStack = 99;
				autoReuse = true;
				break;
			case 207:
				name = "Lava Bucket";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				width = 20;
				height = 20;
				maxStack = 99;
				autoReuse = true;
				break;
			case 208:
				name = "Jungle Rose";
				width = 20;
				height = 20;
				value = 100;
				headSlot = 23;
				toolTip = "'It's pretty, oh so pretty'";
				vanity = true;
				break;
			case 209:
				name = "Stinger";
				width = 16;
				height = 18;
				maxStack = 99;
				value = 200;
				break;
			case 210:
				name = "Vine";
				width = 14;
				height = 20;
				maxStack = 99;
				value = 1000;
				break;
			case 211:
				name = "Feral Claws";
				width = 20;
				height = 20;
				accessory = true;
				rare = 3;
				toolTip = "12% increased melee speed";
				value = 50000;
				handOnSlot = 5;
				handOffSlot = 9;
				break;
			case 212:
				name = "Anklet of the Wind";
				width = 20;
				height = 20;
				accessory = true;
				rare = 3;
				toolTip = "10% increased movement speed";
				value = 50000;
				break;
			case 213:
				name = "Staff of Regrowth";
				useStyle = 1;
				useTurn = true;
				useAnimation = 25;
				useTime = 13;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 7;
				createTile = 2;
				scale = 1.2f;
				useSound = 1;
				knockBack = 3f;
				rare = 3;
				value = 2000;
				toolTip = "Creates grass on dirt";
				melee = true;
				break;
			case 214:
				name = "Hellstone Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 76;
				width = 12;
				height = 12;
				break;
			case 215:
				name = "Whoopie Cushion";
				width = 18;
				height = 18;
				useTurn = true;
				useTime = 30;
				useAnimation = 30;
				noUseGraphic = true;
				useStyle = 10;
				useSound = 16;
				rare = 2;
				toolTip = "'May annoy others'";
				value = 100;
				break;
			case 216:
				name = "Shackle";
				width = 20;
				height = 20;
				rare = 1;
				value = 1500;
				accessory = true;
				defense = 1;
				handOffSlot = 7;
				handOnSlot = 12;
				break;
			case 217:
				name = "Molten Hamaxe";
				useTurn = true;
				autoReuse = true;
				useStyle = 1;
				useAnimation = 27;
				useTime = 14;
				hammer = 70;
				axe = 30;
				width = 24;
				height = 28;
				damage = 20;
				knockBack = 7f;
				scale = 1.4f;
				useSound = 1;
				rare = 3;
				value = 15000;
				melee = true;
				break;
			case 218:
				mana = 16;
				channel = true;
				damage = 34;
				useStyle = 1;
				name = "Flamelash";
				shootSpeed = 6f;
				shoot = 34;
				width = 26;
				height = 28;
				useSound = 20;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				knockBack = 6.5f;
				toolTip = "Summons a controllable ball of fire";
				value = 10000;
				magic = true;
				break;
			case 219:
				autoReuse = false;
				useStyle = 5;
				useAnimation = 11;
				useTime = 11;
				name = "Phoenix Blaster";
				width = 24;
				height = 22;
				shoot = 14;
				knockBack = 2f;
				useAmmo = 14;
				useSound = 41;
				damage = 23;
				shootSpeed = 13f;
				noMelee = true;
				value = 50000;
				scale = 0.85f;
				rare = 3;
				ranged = true;
				break;
			case 220:
				name = "Sunfury";
				noMelee = true;
				useStyle = 5;
				useAnimation = 45;
				useTime = 45;
				knockBack = 7f;
				width = 30;
				height = 10;
				damage = 33;
				scale = 1.1f;
				noUseGraphic = true;
				shoot = 35;
				shootSpeed = 12f;
				useSound = 1;
				rare = 3;
				value = 27000;
				melee = true;
				channel = true;
				break;
			case 221:
				name = "Hellforge";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 77;
				width = 26;
				height = 24;
				value = 3000;
				break;
			case 222:
				name = "Clay Pot";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 78;
				width = 14;
				height = 14;
				value = 100;
				toolTip = "Grows plants";
				break;
			case 223:
				name = "Nature's Gift";
				width = 20;
				height = 22;
				rare = 3;
				value = 27000;
				accessory = true;
				toolTip = "6% reduced mana usage";
				faceSlot = 1;
				break;
			case 224:
				name = "Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				width = 28;
				height = 20;
				value = 2000;
				break;
			case 225:
				name = "Silk";
				maxStack = 999;
				width = 22;
				height = 22;
				value = 1000;
				break;
			case 226:
				name = "Lesser Restoration Potion";
				useSound = 3;
				healMana = 50;
				healLife = 50;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 20;
				consumable = true;
				width = 14;
				height = 24;
				potion = true;
				value = 2000;
				break;
			case 227:
				name = "Restoration Potion";
				useSound = 3;
				healMana = 100;
				healLife = 100;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 20;
				consumable = true;
				width = 14;
				height = 24;
				potion = true;
				value = 4000;
				rare = 1;
				break;
			case 228:
				name = "Jungle Hat";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 8;
				rare = 3;
				value = 45000;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "3% increased magic critical strike chance";
				break;
			case 229:
				name = "Jungle Shirt";
				width = 18;
				height = 18;
				defense = 5;
				bodySlot = 8;
				rare = 3;
				value = 30000;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "3% increased magic critical strike chance";
				break;
			case 230:
				name = "Jungle Pants";
				width = 18;
				height = 18;
				defense = 5;
				legSlot = 8;
				rare = 3;
				value = 30000;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "3% increased magic critical strike chance";
				break;
			case 231:
				name = "Molten Helmet";
				width = 18;
				height = 18;
				defense = 8;
				headSlot = 9;
				rare = 3;
				value = 45000;
				break;
			case 232:
				name = "Molten Breastplate";
				width = 18;
				height = 18;
				defense = 9;
				bodySlot = 9;
				rare = 3;
				value = 30000;
				break;
			case 233:
				name = "Molten Greaves";
				width = 18;
				height = 18;
				defense = 8;
				legSlot = 9;
				rare = 3;
				value = 30000;
				break;
			case 234:
				name = "Meteor Shot";
				shootSpeed = 3f;
				shoot = 36;
				damage = 9;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 14;
				knockBack = 1f;
				value = 8;
				rare = 1;
				ranged = true;
				break;
			case 235:
				useStyle = 1;
				name = "Sticky Bomb";
				shootSpeed = 5f;
				shoot = 37;
				width = 20;
				height = 20;
				maxStack = 50;
				consumable = true;
				useSound = 1;
				useAnimation = 25;
				useTime = 25;
				noUseGraphic = true;
				noMelee = true;
				value = 500;
				damage = 0;
				toolTip = "'Tossing may be difficult.'";
				break;
			case 236:
				name = "Black Lens";
				width = 12;
				height = 20;
				maxStack = 99;
				value = 5000;
				break;
			case 237:
				name = "Sunglasses";
				width = 28;
				height = 12;
				headSlot = 12;
				rare = 2;
				value = 10000;
				toolTip = "'Makes you look cool!'";
				vanity = true;
				break;
			case 238:
				name = "Wizard Hat";
				width = 28;
				height = 20;
				headSlot = 14;
				rare = 2;
				value = 10000;
				defense = 2;
				toolTip = "15% increased magic damage";
				break;
			case 239:
				name = "Top Hat";
				width = 18;
				height = 18;
				headSlot = 15;
				value = 10000;
				vanity = true;
				break;
			case 240:
				name = "Tuxedo Shirt";
				width = 18;
				height = 18;
				bodySlot = 10;
				value = 5000;
				vanity = true;
				break;
			case 241:
				name = "Tuxedo Pants";
				width = 18;
				height = 18;
				legSlot = 10;
				value = 5000;
				vanity = true;
				break;
			case 242:
				name = "Summer Hat";
				width = 18;
				height = 18;
				headSlot = 16;
				value = 10000;
				vanity = true;
				break;
			case 243:
				name = "Bunny Hood";
				width = 18;
				height = 18;
				headSlot = 17;
				value = 20000;
				vanity = true;
				break;
			case 244:
				name = "Plumber's Hat";
				width = 18;
				height = 12;
				headSlot = 18;
				value = 10000;
				vanity = true;
				break;
			case 245:
				name = "Plumber's Shirt";
				width = 18;
				height = 18;
				bodySlot = 11;
				value = 250000;
				vanity = true;
				break;
			case 246:
				name = "Plumber's Pants";
				width = 18;
				height = 18;
				legSlot = 11;
				value = 250000;
				vanity = true;
				break;
			case 247:
				name = "Hero's Hat";
				width = 18;
				height = 12;
				headSlot = 19;
				value = 10000;
				vanity = true;
				break;
			case 248:
				name = "Hero's Shirt";
				width = 18;
				height = 18;
				bodySlot = 12;
				value = 5000;
				vanity = true;
				break;
			case 249:
				name = "Hero's Pants";
				width = 18;
				height = 18;
				legSlot = 12;
				value = 5000;
				vanity = true;
				break;
			case 250:
				name = "Fish Bowl";
				width = 18;
				height = 18;
				headSlot = 20;
				value = 10000;
				vanity = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 282;
				width = 12;
				height = 12;
				break;
			case 251:
				name = "Archaeologist's Hat";
				width = 18;
				height = 12;
				headSlot = 21;
				value = 10000;
				vanity = true;
				break;
			case 252:
				name = "Archaeologist's Jacket";
				width = 18;
				height = 18;
				bodySlot = 13;
				value = 5000;
				vanity = true;
				break;
			case 253:
				name = "Archaeologist's Pants";
				width = 18;
				height = 18;
				legSlot = 13;
				value = 5000;
				vanity = true;
				break;
			case 254:
				name = "Black Thread";
				maxStack = 99;
				width = 12;
				height = 20;
				value = 10000;
				break;
			case 255:
				name = "Green Thread";
				maxStack = 99;
				width = 12;
				height = 20;
				value = 2000;
				break;
			case 256:
				name = "Ninja Hood";
				width = 18;
				height = 12;
				headSlot = 22;
				value = 10000;
				vanity = true;
				break;
			case 257:
				name = "Ninja Shirt";
				width = 18;
				height = 18;
				bodySlot = 14;
				value = 5000;
				vanity = true;
				break;
			case 258:
				name = "Ninja Pants";
				width = 18;
				height = 18;
				legSlot = 14;
				value = 5000;
				vanity = true;
				break;
			case 259:
				name = "Leather";
				width = 18;
				height = 20;
				maxStack = 99;
				value = 50;
				break;
			case 260:
				name = "Red Hat";
				width = 18;
				height = 14;
				headSlot = 24;
				value = 1000;
				vanity = true;
				break;
			case 261:
				name = "Goldfish";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				noUseGraphic = true;
				makeNPC = 55;
				break;
			case 262:
				name = "Robe";
				width = 18;
				height = 14;
				bodySlot = 15;
				value = 2000;
				vanity = true;
				break;
			case 263:
				name = "Robot Hat";
				width = 18;
				height = 18;
				headSlot = 25;
				value = 10000;
				vanity = true;
				break;
			case 264:
				name = "Gold Crown";
				width = 18;
				height = 18;
				headSlot = 26;
				value = 10000;
				vanity = true;
				break;
			case 265:
				name = "Hellfire Arrow";
				shootSpeed = 6.5f;
				shoot = 41;
				damage = 10;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = 1;
				knockBack = 8f;
				value = 100;
				rare = 2;
				ranged = true;
				break;
			case 266:
				useStyle = 5;
				useAnimation = 16;
				useTime = 16;
				autoReuse = true;
				name = "Sandgun";
				width = 40;
				height = 20;
				shoot = 42;
				useAmmo = 42;
				useSound = 11;
				damage = 30;
				shootSpeed = 12f;
				noMelee = true;
				knockBack = 5f;
				value = 10000;
				rare = 2;
				toolTip = "'This is a good idea!'";
				ranged = true;
				break;
			case 267:
				accessory = true;
				name = "Guide Voodoo Doll";
				width = 14;
				height = 26;
				value = 1000;
				toolTip = "'You are a terrible person.'";
				break;
			case 268:
				headSlot = 27;
				defense = 2;
				name = "Diving Helmet";
				width = 20;
				height = 20;
				value = 1000;
				rare = 2;
				toolTip = "Greatly extends underwater breathing";
				break;
			case 269:
				name = "Familiar Shirt";
				bodySlot = 0;
				width = 20;
				height = 20;
				value = 10000;
				color = Main.player[Main.myPlayer].shirtColor;
				break;
			case 270:
				name = "Familiar Pants";
				legSlot = 0;
				width = 20;
				height = 20;
				value = 10000;
				color = Main.player[Main.myPlayer].pantsColor;
				break;
			case 271:
				name = "Familiar Wig";
				headSlot = 0;
				width = 20;
				height = 20;
				value = 10000;
				color = Main.player[Main.myPlayer].hairColor;
				break;
			case 272:
				mana = 14;
				damage = 35;
				useStyle = 5;
				name = "Demon Scythe";
				shootSpeed = 0.2f;
				shoot = 45;
				width = 26;
				height = 28;
				useSound = 8;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				knockBack = 5f;
				scale = 0.9f;
				toolTip = "Casts a demon scythe";
				value = 10000;
				magic = true;
				break;
			case 273:
				name = "Night's Edge";
				useStyle = 1;
				useAnimation = 27;
				useTime = 27;
				knockBack = 4.5f;
				width = 40;
				height = 40;
				damage = 42;
				scale = 1.15f;
				useSound = 1;
				rare = 3;
				value = 54000;
				melee = true;
				break;
			case 274:
				name = "Dark Lance";
				useStyle = 5;
				useAnimation = 25;
				useTime = 25;
				shootSpeed = 5f;
				knockBack = 4f;
				width = 40;
				height = 40;
				damage = 27;
				scale = 1.1f;
				useSound = 1;
				shoot = 46;
				rare = 3;
				value = 27000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				break;
			case 275:
				name = "Coral";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 81;
				width = 20;
				height = 22;
				value = 400;
				break;
			case 276:
				name = "Cactus";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 188;
				width = 12;
				height = 12;
				value = 10;
				break;
			case 277:
				name = "Trident";
				useStyle = 5;
				useAnimation = 31;
				useTime = 31;
				shootSpeed = 4f;
				knockBack = 5f;
				width = 40;
				height = 40;
				damage = 10;
				scale = 1.1f;
				useSound = 1;
				shoot = 47;
				rare = 1;
				value = 10000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				break;
			case 278:
				name = "Silver Bullet";
				shootSpeed = 4.5f;
				shoot = 14;
				damage = 9;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 14;
				knockBack = 3f;
				value = 15;
				ranged = true;
				break;
			case 279:
				useStyle = 1;
				name = "Throwing Knife";
				shootSpeed = 10f;
				shoot = 48;
				damage = 12;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 50;
				knockBack = 2f;
				ranged = true;
				break;
			case 280:
				name = "Spear";
				useStyle = 5;
				useAnimation = 31;
				useTime = 31;
				shootSpeed = 3.7f;
				knockBack = 6.5f;
				width = 32;
				height = 32;
				damage = 8;
				scale = 1f;
				useSound = 1;
				shoot = 49;
				value = 1000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				break;
			case 281:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 45;
				useTime = 45;
				name = "Blowpipe";
				width = 38;
				height = 6;
				shoot = 10;
				useAmmo = 51;
				useSound = 5;
				damage = 9;
				shootSpeed = 11f;
				noMelee = true;
				value = 10000;
				knockBack = 3.5f;
				useAmmo = 51;
				toolTip = "Allows the collection of seeds for ammo";
				ranged = true;
				break;
			case 282:
				useStyle = 1;
				name = "Glowstick";
				shootSpeed = 6f;
				shoot = 50;
				width = 12;
				height = 12;
				maxStack = 99;
				consumable = true;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noMelee = true;
				value = 10;
				holdStyle = 1;
				toolTip = "Works when wet";
				break;
			case 283:
				name = "Seed";
				shoot = 51;
				width = 8;
				height = 8;
				maxStack = 999;
				ammo = 51;
				toolTip = "For use with Blowpipe";
				damage = 1;
				ranged = true;
				break;
			case 284:
				noMelee = true;
				useStyle = 1;
				name = "Wooden Boomerang";
				shootSpeed = 6.5f;
				shoot = 52;
				damage = 7;
				knockBack = 5f;
				width = 14;
				height = 28;
				useSound = 1;
				useAnimation = 16;
				useTime = 16;
				noUseGraphic = true;
				value = 5000;
				melee = true;
				break;
			case 285:
				name = "Aglet";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "5% increased movement speed";
				value = 5000;
				break;
			case 286:
				useStyle = 1;
				name = "Sticky Glowstick";
				shootSpeed = 6f;
				shoot = 53;
				width = 12;
				height = 12;
				maxStack = 99;
				consumable = true;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noMelee = true;
				value = 20;
				holdStyle = 1;
				break;
			case 287:
				useStyle = 1;
				name = "Poisoned Knife";
				shootSpeed = 11f;
				shoot = 54;
				damage = 13;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 60;
				knockBack = 2f;
				ranged = true;
				break;
			case 288:
				name = "Obsidian Skin Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 1;
				buffTime = 14400;
				toolTip = "Provides immunity to lava";
				value = 1000;
				rare = 1;
				break;
			case 289:
				name = "Regeneration Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 2;
				buffTime = 18000;
				toolTip = "Provides life regeneration";
				value = 1000;
				rare = 1;
				break;
			case 290:
				name = "Swiftness Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 3;
				buffTime = 14400;
				toolTip = "25% increased movement speed";
				value = 1000;
				rare = 1;
				break;
			case 291:
				name = "Gills Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 4;
				buffTime = 7200;
				toolTip = "Breathe water instead of air";
				value = 1000;
				rare = 1;
				break;
			case 292:
				name = "Ironskin Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 5;
				buffTime = 18000;
				toolTip = "Increase defense by 8";
				value = 1000;
				rare = 1;
				break;
			case 293:
				name = "Mana Regeneration Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 6;
				buffTime = 7200;
				toolTip = "Increased mana regeneration";
				value = 1000;
				rare = 1;
				break;
			case 294:
				name = "Magic Power Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 7;
				buffTime = 7200;
				toolTip = "20% increased magic damage";
				value = 1000;
				rare = 1;
				break;
			case 295:
				name = "Featherfall Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 8;
				buffTime = 18000;
				toolTip = "Slows falling speed";
				value = 1000;
				rare = 1;
				break;
			case 296:
				name = "Spelunker Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 9;
				buffTime = 18000;
				toolTip = "Shows the location of treasure and ore";
				value = 1000;
				rare = 1;
				break;
			case 297:
				name = "Invisibility Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 10;
				buffTime = 7200;
				toolTip = "Grants invisibility";
				value = 1000;
				rare = 1;
				break;
			case 298:
				name = "Shine Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 11;
				buffTime = 18000;
				toolTip = "Emits an aura of light";
				value = 1000;
				rare = 1;
				break;
			case 299:
				name = "Night Owl Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 12;
				buffTime = 14400;
				toolTip = "Increases night vision";
				value = 1000;
				rare = 1;
				break;
			case 300:
				name = "Battle Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 13;
				buffTime = 25200;
				toolTip = "Increases enemy spawn rate";
				value = 1000;
				rare = 1;
				break;
			case 301:
				name = "Thorns Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 14;
				buffTime = 7200;
				toolTip = "Attackers also take damage";
				value = 1000;
				rare = 1;
				break;
			case 302:
				name = "Water Walking Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 15;
				buffTime = 18000;
				toolTip = "Allows the ability to walk on water";
				value = 1000;
				rare = 1;
				break;
			case 303:
				name = "Archery Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 16;
				buffTime = 14400;
				toolTip = "20% increased arrow speed and damage";
				value = 1000;
				rare = 1;
				break;
			case 304:
				name = "Hunter Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 17;
				buffTime = 18000;
				toolTip = "Shows the location of enemies";
				value = 1000;
				rare = 1;
				break;
			case 305:
				name = "Gravitation Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 18;
				buffTime = 10800;
				toolTip = "Allows the control of gravity";
				value = 1000;
				rare = 1;
				break;
			case 306:
				name = "Gold Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 1;
				width = 26;
				height = 22;
				value = 5000;
				break;
			case 307:
				name = "Daybloom Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 82;
				placeStyle = 0;
				width = 12;
				height = 14;
				value = 80;
				break;
			case 308:
				name = "Moonglow Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 82;
				placeStyle = 1;
				width = 12;
				height = 14;
				value = 80;
				break;
			case 309:
				name = "Blinkroot Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 82;
				placeStyle = 2;
				width = 12;
				height = 14;
				value = 80;
				break;
			case 310:
				name = "Deathweed Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 82;
				placeStyle = 3;
				width = 12;
				height = 14;
				value = 80;
				break;
			case 311:
				name = "Waterleaf Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 82;
				placeStyle = 4;
				width = 12;
				height = 14;
				value = 80;
				break;
			case 312:
				name = "Fireblossom Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 82;
				placeStyle = 5;
				width = 12;
				height = 14;
				value = 80;
				break;
			case 313:
				name = "Daybloom";
				maxStack = 99;
				width = 12;
				height = 14;
				value = 100;
				break;
			case 314:
				name = "Moonglow";
				maxStack = 99;
				width = 12;
				height = 14;
				value = 100;
				break;
			case 315:
				name = "Blinkroot";
				maxStack = 99;
				width = 12;
				height = 14;
				value = 100;
				break;
			case 316:
				name = "Deathweed";
				maxStack = 99;
				width = 12;
				height = 14;
				value = 100;
				break;
			case 317:
				name = "Waterleaf";
				maxStack = 99;
				width = 12;
				height = 14;
				value = 100;
				break;
			case 318:
				name = "Fireblossom";
				maxStack = 99;
				width = 12;
				height = 14;
				value = 100;
				break;
			case 319:
				name = "Shark Fin";
				maxStack = 99;
				width = 16;
				height = 14;
				value = 200;
				break;
			case 320:
				name = "Feather";
				maxStack = 99;
				width = 16;
				height = 14;
				value = 50;
				break;
			case 321:
				name = "Tombstone";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 85;
				width = 20;
				height = 20;
				break;
			case 322:
				name = "Mime Mask";
				headSlot = 28;
				width = 20;
				height = 20;
				value = 20000;
				break;
			case 323:
				name = "Antlion Mandible";
				width = 10;
				height = 20;
				maxStack = 99;
				value = 50;
				break;
			case 324:
				name = "Illegal Gun Parts";
				width = 10;
				height = 20;
				maxStack = 99;
				value = 250000;
				toolTip = "'Banned in most places'";
				break;
			case 325:
				name = "The Doctor's Shirt";
				width = 18;
				height = 18;
				bodySlot = 16;
				value = 200000;
				vanity = true;
				break;
			case 326:
				name = "The Doctor's Pants";
				width = 18;
				height = 18;
				legSlot = 15;
				value = 200000;
				vanity = true;
				break;
			case 327:
				name = "Golden Key";
				width = 14;
				height = 20;
				maxStack = 99;
				toolTip = "Opens one Gold Chest";
				break;
			case 328:
				name = "Shadow Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 3;
				width = 26;
				height = 22;
				value = 5000;
				break;
			case 329:
				name = "Shadow Key";
				width = 14;
				height = 20;
				maxStack = 1;
				toolTip = "Opens all Shadow Chests";
				value = 75000;
				break;
			case 330:
				name = "Obsidian Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 20;
				width = 12;
				height = 12;
				break;
			case 331:
				name = "Jungle Spores";
				width = 18;
				height = 16;
				maxStack = 99;
				value = 100;
				break;
			case 332:
				name = "Loom";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 86;
				width = 20;
				height = 20;
				value = 300;
				toolTip = "Used for crafting cloth";
				break;
			case 333:
				name = "Piano";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 87;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 334:
				name = "Dresser";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 88;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 335:
				name = "Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 89;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 336:
				name = "Bathtub";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 90;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 337:
				name = "Red Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 0;
				width = 10;
				height = 24;
				value = 500;
				break;
			case 338:
				name = "Green Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 1;
				width = 10;
				height = 24;
				value = 500;
				break;
			case 339:
				name = "Blue Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 2;
				width = 10;
				height = 24;
				value = 500;
				break;
			case 340:
				name = "Yellow Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 3;
				width = 10;
				height = 24;
				value = 500;
				break;
			case 341:
				name = "Lamp Post";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 92;
				width = 10;
				height = 24;
				value = 500;
				break;
			case 342:
				name = "Tiki Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 93;
				width = 10;
				height = 24;
				value = 500;
				break;
			case 343:
				name = "Barrel";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 5;
				width = 20;
				height = 20;
				value = 500;
				break;
			case 344:
				name = "Chinese Lantern";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 95;
				width = 20;
				height = 20;
				value = 500;
				break;
			case 345:
				name = "Cooking Pot";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 96;
				width = 20;
				height = 20;
				value = 500;
				break;
			case 346:
				name = "Safe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 97;
				width = 20;
				height = 20;
				value = 200000;
				break;
			case 347:
				name = "Skull Lantern";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 98;
				width = 20;
				height = 20;
				value = 500;
				break;
			case 348:
				name = "Trash Can";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 6;
				width = 20;
				height = 20;
				value = 1000;
				break;
			case 349:
				name = "Candelabra";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 100;
				width = 20;
				height = 20;
				value = 1500;
				break;
			case 350:
				name = "Pink Vase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 13;
				placeStyle = 3;
				width = 16;
				height = 24;
				value = 70;
				break;
			case 351:
				name = "Mug";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 13;
				placeStyle = 4;
				width = 16;
				height = 24;
				value = 20;
				break;
			case 352:
				name = "Keg";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 94;
				width = 24;
				height = 24;
				value = 600;
				toolTip = "Used for brewing ale";
				break;
			case 353:
				name = "Ale";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 10;
				height = 10;
				buffType = 25;
				buffTime = 7200;
				value = 100;
				break;
			case 354:
				name = "Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 355:
				name = "Throne";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 102;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 356:
				name = "Bowl";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 103;
				width = 16;
				height = 24;
				value = 20;
				break;
			case 357:
				name = "Bowl of Soup";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 10;
				height = 10;
				buffType = 26;
				buffTime = 36000;
				rare = 1;
				toolTip = "Minor improvements to all stats";
				value = 1000;
				break;
			case 358:
				name = "Toilet";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 1;
				width = 12;
				height = 30;
				value = 150;
				break;
			case 359:
				name = "Grandfather Clock";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 104;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 360:
				name = "Armor Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 361:
				useStyle = 4;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				name = "Goblin Battle Standard";
				width = 28;
				height = 28;
				toolTip = "Summons a Goblin Army";
				break;
			case 362:
				name = "Tattered Cloth";
				maxStack = 99;
				width = 24;
				height = 24;
				value = 30;
				break;
			case 363:
				name = "Sawmill";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 106;
				width = 20;
				height = 20;
				value = 300;
				toolTip = "Used for advanced wood crafting";
				break;
			case 364:
				name = "Cobalt Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 107;
				width = 12;
				height = 12;
				value = 3500;
				rare = 3;
				break;
			case 365:
				name = "Mythril Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 108;
				width = 12;
				height = 12;
				value = 5500;
				rare = 3;
				break;
			case 366:
				name = "Adamantite Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 111;
				width = 12;
				height = 12;
				value = 7500;
				rare = 3;
				break;
			case 367:
				name = "Pwnhammer";
				useTurn = true;
				autoReuse = true;
				useStyle = 1;
				useAnimation = 27;
				useTime = 14;
				hammer = 80;
				width = 24;
				height = 28;
				damage = 26;
				knockBack = 7.5f;
				scale = 1.2f;
				useSound = 1;
				rare = 4;
				value = 39000;
				melee = true;
				toolTip = "Strong enough to destroy Demon Altars";
				break;
			case 368:
				autoReuse = true;
				name = "Excalibur";
				useStyle = 1;
				useAnimation = 25;
				useTime = 25;
				knockBack = 4.5f;
				width = 40;
				height = 40;
				damage = 47;
				scale = 1.15f;
				useSound = 1;
				rare = 5;
				value = 230000;
				melee = true;
				break;
			case 369:
				name = "Hallowed Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 109;
				width = 14;
				height = 14;
				value = 2000;
				rare = 3;
				break;
			case 370:
				name = "Ebonsand Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 112;
				width = 12;
				height = 12;
				ammo = 42;
				break;
			case 371:
				name = "Cobalt Hat";
				width = 18;
				height = 18;
				defense = 2;
				headSlot = 29;
				rare = 4;
				value = 75000;
				toolTip = "Increases maximum mana by 40";
				toolTip2 = "9% increased magic critical strike chance";
				break;
			case 372:
				name = "Cobalt Helmet";
				width = 18;
				height = 18;
				defense = 11;
				headSlot = 30;
				rare = 4;
				value = 75000;
				toolTip = "7% increased movement speed";
				toolTip2 = "12% increased melee speed";
				break;
			case 373:
				name = "Cobalt Mask";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 31;
				rare = 4;
				value = 75000;
				toolTip = "10% increased ranged damage";
				toolTip2 = "6% increased ranged critical strike chance";
				break;
			case 374:
				name = "Cobalt Breastplate";
				width = 18;
				height = 18;
				defense = 8;
				bodySlot = 17;
				rare = 4;
				value = 60000;
				toolTip2 = "3% increased critical strike chance";
				break;
			case 375:
				name = "Cobalt Leggings";
				width = 18;
				height = 18;
				defense = 7;
				legSlot = 16;
				rare = 4;
				value = 45000;
				toolTip2 = "10% increased movement speed";
				break;
			case 376:
				name = "Mythril Hood";
				width = 18;
				height = 18;
				defense = 3;
				headSlot = 32;
				rare = 4;
				value = 112500;
				toolTip = "Increases maximum mana by 60";
				toolTip2 = "15% increased magic damage";
				break;
			case 377:
				name = "Mythril Helmet";
				width = 18;
				height = 18;
				defense = 16;
				headSlot = 33;
				rare = 4;
				value = 112500;
				toolTip = "5% increased melee critical strike chance";
				toolTip2 = "10% increased melee damage";
				break;
			case 378:
				name = "Mythril Hat";
				width = 18;
				height = 18;
				defense = 6;
				headSlot = 34;
				rare = 4;
				value = 112500;
				toolTip = "12% increased ranged damage";
				toolTip2 = "7% increased ranged critical strike chance";
				break;
			case 379:
				name = "Mythril Chainmail";
				width = 18;
				height = 18;
				defense = 12;
				bodySlot = 18;
				rare = 4;
				value = 90000;
				toolTip2 = "5% increased damage";
				break;
			case 380:
				name = "Mythril Greaves";
				width = 18;
				height = 18;
				defense = 9;
				legSlot = 17;
				rare = 4;
				value = 67500;
				toolTip2 = "3% increased critical strike chance";
				break;
			case 381:
				name = "Cobalt Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10500;
				rare = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 11;
				break;
			case 382:
				name = "Mythril Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 22000;
				rare = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 13;
				break;
			case 383:
				name = "Cobalt Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 8;
				shootSpeed = 40f;
				knockBack = 2.75f;
				width = 20;
				height = 12;
				damage = 23;
				axe = 14;
				useSound = 23;
				shoot = 57;
				rare = 4;
				value = 54000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				break;
			case 384:
				name = "Mythril Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 8;
				shootSpeed = 40f;
				knockBack = 3f;
				width = 20;
				height = 12;
				damage = 29;
				axe = 17;
				useSound = 23;
				shoot = 58;
				rare = 4;
				value = 81000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				break;
			case 385:
				name = "Cobalt Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 13;
				shootSpeed = 32f;
				knockBack = 0f;
				width = 20;
				height = 12;
				damage = 10;
				pick = 110;
				useSound = 23;
				shoot = 59;
				rare = 4;
				value = 54000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				toolTip = "Can mine Mythril and Orichalcum";
				break;
			case 386:
				name = "Mythril Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 10;
				shootSpeed = 32f;
				knockBack = 0f;
				width = 20;
				height = 12;
				damage = 15;
				pick = 150;
				useSound = 23;
				shoot = 60;
				rare = 4;
				value = 81000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				toolTip = "Can mine Adamantite and Titanium";
				break;
			case 387:
				name = "Adamantite Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 6;
				shootSpeed = 40f;
				knockBack = 4.5f;
				width = 20;
				height = 12;
				damage = 33;
				axe = 20;
				useSound = 23;
				shoot = 61;
				rare = 4;
				value = 108000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				break;
			case 388:
				name = "Adamantite Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 32f;
				knockBack = 0f;
				width = 20;
				height = 12;
				damage = 20;
				pick = 180;
				useSound = 23;
				shoot = 62;
				rare = 4;
				value = 108000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				break;
			case 389:
				name = "Dao of Pow";
				noMelee = true;
				useStyle = 5;
				useAnimation = 45;
				useTime = 45;
				knockBack = 7f;
				width = 30;
				height = 10;
				damage = 49;
				scale = 1.1f;
				noUseGraphic = true;
				shoot = 63;
				shootSpeed = 15f;
				useSound = 1;
				rare = 5;
				value = 144000;
				melee = true;
				channel = true;
				toolTip = "Has a chance to confuse";
				toolTip2 = "'Find your inner pieces'";
				break;
			case 390:
				name = "Mythril Halberd";
				useStyle = 5;
				useAnimation = 26;
				useTime = 26;
				shootSpeed = 4.5f;
				knockBack = 5f;
				width = 40;
				height = 40;
				damage = 35;
				scale = 1.1f;
				useSound = 1;
				shoot = 64;
				rare = 4;
				value = 67500;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				break;
			case 391:
				name = "Adamantite Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 37500;
				rare = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 15;
				break;
			case 392:
				name = "Glass Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 21;
				width = 12;
				height = 12;
				break;
			case 393:
				name = "Compass";
				width = 24;
				height = 28;
				rare = 3;
				value = 100000;
				accessory = true;
				toolTip = "Shows horizontal position";
				break;
			case 394:
				name = "Diving Gear";
				width = 24;
				height = 28;
				rare = 4;
				value = 100000;
				accessory = true;
				toolTip = "Grants the ability to swim";
				toolTip2 = "Greatly extends underwater breathing";
				faceSlot = 4;
				break;
			case 395:
				name = "GPS";
				width = 24;
				height = 28;
				rare = 4;
				value = 150000;
				accessory = true;
				toolTip = "Shows position";
				toolTip2 = "Tells the time";
				break;
			case 396:
				name = "Obsidian Horseshoe";
				width = 24;
				height = 28;
				rare = 4;
				value = 100000;
				accessory = true;
				toolTip = "Negates fall damage";
				toolTip2 = "Grants immunity to fire blocks";
				break;
			case 397:
				name = "Obsidian Shield";
				width = 24;
				height = 28;
				rare = 4;
				value = 100000;
				accessory = true;
				defense = 2;
				toolTip = "Grants immunity to knockback";
				toolTip2 = "Grants immunity to fire blocks";
				shieldSlot = 3;
				break;
			case 398:
				name = "Tinkerer's Workshop";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 114;
				width = 26;
				height = 20;
				value = 100000;
				toolTip = "Allows the combining of some accessories";
				break;
			case 399:
				name = "Cloud in a Balloon";
				width = 14;
				height = 28;
				rare = 4;
				value = 150000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip2 = "Increases jump height";
				balloonSlot = 4;
				break;
			case 400:
				name = "Adamantite Headgear";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 35;
				rare = 4;
				value = 150000;
				toolTip = "Increases maximum mana by 80";
				toolTip2 = "11% increased magic damage and critical strike chance";
				break;
			case 401:
				name = "Adamantite Helmet";
				width = 18;
				height = 18;
				defense = 22;
				headSlot = 36;
				rare = 4;
				value = 150000;
				toolTip = "7% increased melee critical strike chance";
				toolTip2 = "14% increased melee damage";
				break;
			case 402:
				name = "Adamantite Mask";
				width = 18;
				height = 18;
				defense = 8;
				headSlot = 37;
				rare = 4;
				value = 150000;
				toolTip = "14% increased ranged damage";
				toolTip2 = "8% increased ranged critical strike chance";
				break;
			case 403:
				name = "Adamantite Breastplate";
				width = 18;
				height = 18;
				defense = 14;
				bodySlot = 19;
				rare = 4;
				value = 120000;
				toolTip = "6% increased damage";
				break;
			case 404:
				name = "Adamantite Leggings";
				width = 18;
				height = 18;
				defense = 10;
				legSlot = 18;
				rare = 4;
				value = 90000;
				toolTip = "4% increased critical strike chance";
				toolTip2 = "5% increased movement speed";
				break;
			case 405:
				name = "Spectre Boots";
				width = 28;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Allows flight";
				toolTip2 = "The wearer can run super fast";
				value = 100000;
				shoeSlot = 13;
				break;
			case 406:
				name = "Adamantite Glaive";
				useStyle = 5;
				useAnimation = 25;
				useTime = 25;
				shootSpeed = 5f;
				knockBack = 6f;
				width = 40;
				height = 40;
				damage = 38;
				scale = 1.1f;
				useSound = 1;
				shoot = 66;
				rare = 4;
				value = 90000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				break;
			case 407:
				name = "Toolbelt";
				width = 28;
				height = 24;
				accessory = true;
				rare = 3;
				toolTip = "Increases block placement range";
				value = 100000;
				waistSlot = 5;
				break;
			case 408:
				name = "Pearlsand Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 116;
				width = 12;
				height = 12;
				ammo = 42;
				break;
			case 409:
				name = "Pearlstone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 117;
				width = 12;
				height = 12;
				break;
			case 410:
				name = "Mining Shirt";
				width = 18;
				height = 18;
				defense = 1;
				bodySlot = 20;
				value = 5000;
				rare = 1;
				break;
			case 411:
				name = "Mining Pants";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 19;
				value = 5000;
				rare = 1;
				break;
			case 412:
				name = "Pearlstone Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 118;
				width = 12;
				height = 12;
				break;
			case 413:
				name = "Iridescent Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 119;
				width = 12;
				height = 12;
				break;
			case 414:
				name = "Mudstone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 120;
				width = 12;
				height = 12;
				break;
			case 415:
				name = "Cobalt Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 121;
				width = 12;
				height = 12;
				break;
			case 416:
				name = "Mythril Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 122;
				width = 12;
				height = 12;
				break;
			case 417:
				name = "Pearlstone Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 22;
				width = 12;
				height = 12;
				break;
			case 418:
				name = "Iridescent Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 23;
				width = 12;
				height = 12;
				break;
			case 419:
				name = "Mudstone Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 24;
				width = 12;
				height = 12;
				break;
			case 420:
				name = "Cobalt Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 25;
				width = 12;
				height = 12;
				break;
			case 421:
				name = "Mythril Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 26;
				width = 12;
				height = 12;
				break;
			case 422:
				useStyle = 1;
				name = "Holy Water";
				shootSpeed = 9f;
				rare = 3;
				damage = 20;
				shoot = 69;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				knockBack = 3f;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 200;
				toolTip = "Spreads the Hallow to some blocks";
				break;
			case 423:
				useStyle = 1;
				name = "Unholy Water";
				shootSpeed = 9f;
				rare = 3;
				damage = 20;
				shoot = 70;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				knockBack = 3f;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 200;
				toolTip = "Spreads the corruption to some blocks";
				break;
			case 424:
				name = "Silt Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 123;
				width = 12;
				height = 12;
				break;
			case 425:
				channel = true;
				damage = 0;
				useStyle = 1;
				name = "Fairy Bell";
				width = 24;
				height = 24;
				useSound = 25;
				useAnimation = 20;
				useTime = 20;
				rare = 5;
				noMelee = true;
				toolTip = "Summons a magical fairy";
				value = (value = 250000);
				break;
			case 426:
				name = "Breaker Blade";
				useStyle = 1;
				useAnimation = 30;
				knockBack = 8f;
				width = 60;
				height = 70;
				damage = 39;
				scale = 1.05f;
				useSound = 1;
				rare = 4;
				value = 150000;
				melee = true;
				break;
			case 427:
				flame = true;
				noWet = true;
				name = "Blue Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 1;
				width = 10;
				height = 12;
				value = 200;
				break;
			case 428:
				flame = true;
				noWet = true;
				name = "Red Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 2;
				width = 10;
				height = 12;
				value = 200;
				break;
			case 429:
				flame = true;
				noWet = true;
				name = "Green Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 3;
				width = 10;
				height = 12;
				value = 200;
				break;
			case 430:
				flame = true;
				noWet = true;
				name = "Purple Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 4;
				width = 10;
				height = 12;
				value = 200;
				break;
			case 431:
				flame = true;
				noWet = true;
				name = "White Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 5;
				width = 10;
				height = 12;
				value = 500;
				break;
			case 432:
				flame = true;
				noWet = true;
				name = "Yellow Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 6;
				width = 10;
				height = 12;
				value = 200;
				break;
			case 433:
				flame = true;
				noWet = true;
				name = "Demon Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 7;
				width = 10;
				height = 12;
				value = 300;
				break;
			case 434:
				autoReuse = true;
				useStyle = 5;
				useAnimation = 12;
				useTime = 4;
				reuseDelay = 14;
				name = "Clockwork Assault Rifle";
				width = 50;
				height = 18;
				shoot = 10;
				useAmmo = 14;
				useSound = 31;
				damage = 19;
				shootSpeed = 7.75f;
				noMelee = true;
				value = 150000;
				rare = 4;
				ranged = true;
				toolTip = "Three round burst";
				toolTip2 = "Only the first shot consumes ammo";
				break;
			case 435:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 25;
				useTime = 25;
				name = "Cobalt Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 32;
				shootSpeed = 9f;
				noMelee = true;
				value = 60000;
				ranged = true;
				rare = 4;
				knockBack = 1.5f;
				break;
			case 436:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 23;
				useTime = 23;
				name = "Mythril Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 36;
				shootSpeed = 9.5f;
				noMelee = true;
				value = 90000;
				ranged = true;
				rare = 4;
				knockBack = 2f;
				break;
			case 437:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Dual Hook";
				shootSpeed = 14f;
				shoot = 73;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 4;
				noMelee = true;
				value = 200000;
				break;
			case 438:
				name = "Star Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 2;
				break;
			case 439:
				name = "Sword Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 3;
				break;
			case 440:
				name = "Slime Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 4;
				break;
			case 441:
				name = "Goblin Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 5;
				break;
			case 442:
				name = "Shield Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 6;
				break;
			case 443:
				name = "Bat Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 7;
				break;
			case 444:
				name = "Fish Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 8;
				break;
			case 445:
				name = "Bunny Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 9;
				break;
			case 446:
				name = "Skeleton Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 10;
				break;
			case 447:
				name = "Reaper Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 11;
				break;
			case 448:
				name = "Woman Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 12;
				break;
			case 449:
				name = "Imp Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 13;
				break;
			case 450:
				name = "Gargoyle Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 14;
				break;
			case 451:
				name = "Gloom Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 15;
				break;
			case 452:
				name = "Hornet Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 16;
				break;
			case 453:
				name = "Bomb Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 17;
				break;
			case 454:
				name = "Crab Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 18;
				break;
			case 455:
				name = "Hammer Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 19;
				break;
			case 456:
				name = "Potion Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 20;
				break;
			case 457:
				name = "Spear Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 21;
				break;
			case 458:
				name = "Cross Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 22;
				break;
			case 459:
				name = "Jellyfish Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 23;
				break;
			case 460:
				name = "Bow Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 24;
				break;
			case 461:
				name = "Boomerang Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 25;
				break;
			case 462:
				name = "Boot Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 26;
				break;
			case 463:
				name = "Chest Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 27;
				break;
			case 464:
				name = "Bird Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 28;
				break;
			case 465:
				name = "Axe Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 29;
				break;
			case 466:
				name = "Corrupt Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 30;
				break;
			case 467:
				name = "Tree Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 31;
				break;
			case 468:
				name = "Anvil Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 32;
				break;
			case 469:
				name = "Pickaxe Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 33;
				break;
			case 470:
				name = "Mushroom Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 34;
				break;
			case 471:
				name = "Eyeball Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 35;
				break;
			case 472:
				name = "Pillar Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 36;
				break;
			case 473:
				name = "Heart Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 37;
				break;
			case 474:
				name = "Pot Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 38;
				break;
			case 475:
				name = "Sunflower Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 39;
				break;
			case 476:
				name = "King Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 40;
				break;
			case 477:
				name = "Queen Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 41;
				break;
			case 478:
				name = "Pirahna Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 42;
				break;
			case 479:
				name = "Planked Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 27;
				width = 12;
				height = 12;
				break;
			case 480:
				name = "Wooden Beam";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 124;
				width = 12;
				height = 12;
				break;
			case 481:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 20;
				useTime = 20;
				name = "Adamantite Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 40;
				shootSpeed = 10f;
				noMelee = true;
				value = 120000;
				ranged = true;
				rare = 4;
				knockBack = 2.5f;
				break;
			case 482:
				name = "Adamantite Sword";
				useStyle = 1;
				useAnimation = 27;
				useTime = 27;
				knockBack = 6f;
				width = 40;
				height = 40;
				damage = 44;
				scale = 1.2f;
				useSound = 1;
				rare = 4;
				value = 138000;
				melee = true;
				break;
			case 483:
				useTurn = true;
				autoReuse = true;
				name = "Cobalt Sword";
				useStyle = 1;
				useAnimation = 23;
				useTime = 23;
				knockBack = 3.85f;
				width = 40;
				height = 40;
				damage = 34;
				scale = 1.1f;
				useSound = 1;
				rare = 4;
				value = 69000;
				melee = true;
				break;
			case 484:
				name = "Mythril Sword";
				useStyle = 1;
				useAnimation = 26;
				useTime = 26;
				knockBack = 6f;
				width = 40;
				height = 40;
				damage = 39;
				scale = 1.15f;
				useSound = 1;
				rare = 4;
				value = 103500;
				melee = true;
				break;
			case 485:
				rare = 4;
				name = "Moon Charm";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Turns the holder into a werewolf on full moons";
				value = 150000;
				break;
			case 486:
				name = "Ruler";
				width = 10;
				height = 26;
				accessory = true;
				toolTip = "Creates a grid on screen for block placement";
				value = 10000;
				rare = 1;
				break;
			case 487:
				name = "Crystal Ball";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 125;
				width = 22;
				height = 22;
				value = 100000;
				rare = 3;
				break;
			case 488:
				name = "Disco Ball";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 126;
				width = 22;
				height = 26;
				value = 10000;
				break;
			case 489:
				name = "Sorcerer Emblem";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "15% increased magic damage";
				value = 100000;
				rare = 4;
				break;
			case 491:
				name = "Ranger Emblem";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "15% increased ranged damage";
				value = 100000;
				rare = 4;
				break;
			case 490:
				name = "Warrior Emblem";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "15% increased melee damage";
				value = 100000;
				rare = 4;
				break;
			case 492:
				name = "Demon Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 1;
				break;
			case 493:
				name = "Angel Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 2;
				break;
			case 494:
				rare = 5;
				useStyle = 5;
				useAnimation = 12;
				useTime = 12;
				name = "Magical Harp";
				width = 12;
				height = 28;
				shoot = 76;
				holdStyle = 3;
				autoReuse = true;
				damage = 32;
				shootSpeed = 4.5f;
				noMelee = true;
				value = 200000;
				mana = 4;
				magic = true;
				break;
			case 495:
				rare = 5;
				mana = 18;
				channel = true;
				damage = 72;
				useStyle = 1;
				name = "Rainbow Rod";
				shootSpeed = 6f;
				shoot = 79;
				width = 26;
				height = 28;
				useSound = 28;
				useAnimation = 19;
				useTime = 18;
				noMelee = true;
				knockBack = 6f;
				toolTip = "Casts a controllable rainbow";
				value = 200000;
				magic = true;
				break;
			case 496:
				rare = 4;
				mana = 7;
				damage = 26;
				useStyle = 1;
				name = "Ice Rod";
				shootSpeed = 12f;
				shoot = 80;
				width = 26;
				height = 28;
				useSound = 28;
				useAnimation = 17;
				useTime = 17;
				rare = 4;
				autoReuse = true;
				noMelee = true;
				knockBack = 0f;
				toolTip = "Summons a block of ice";
				value = 1000000;
				magic = true;
				knockBack = 2f;
				break;
			case 497:
				name = "Neptune's Shell";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Transforms the holder into merfolk when entering water";
				value = 150000;
				rare = 5;
				break;
			case 498:
				name = "Mannequin";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 128;
				width = 12;
				height = 12;
				break;
			case 499:
				name = "Greater Healing Potion";
				useSound = 3;
				healLife = 150;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				rare = 3;
				potion = true;
				value = 5000;
				break;
			case 500:
				name = "Greater Mana Potion";
				useSound = 3;
				healMana = 200;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 75;
				consumable = true;
				width = 14;
				height = 24;
				rare = 3;
				value = 1000;
				break;
			case 501:
				name = "Pixie Dust";
				width = 16;
				height = 14;
				maxStack = 99;
				value = 500;
				rare = 1;
				break;
			case 502:
				name = "Crystal Shard";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 129;
				width = 24;
				height = 24;
				value = 8000;
				rare = 1;
				break;
			case 503:
				name = "Clown Hat";
				width = 18;
				height = 18;
				headSlot = 40;
				value = 20000;
				vanity = true;
				rare = 2;
				break;
			case 504:
				name = "Clown Shirt";
				width = 18;
				height = 18;
				bodySlot = 23;
				value = 10000;
				vanity = true;
				rare = 2;
				break;
			case 505:
				name = "Clown Pants";
				width = 18;
				height = 18;
				legSlot = 22;
				value = 10000;
				vanity = true;
				rare = 2;
				break;
			case 506:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 30;
				useTime = 6;
				name = "Flamethrower";
				width = 50;
				height = 18;
				shoot = 85;
				useAmmo = 23;
				useSound = 34;
				damage = 27;
				knockBack = 0.3f;
				shootSpeed = 7f;
				noMelee = true;
				value = 500000;
				rare = 5;
				ranged = true;
				toolTip = "Uses gel for ammo";
				break;
			case 507:
				rare = 3;
				useStyle = 1;
				useAnimation = 12;
				useTime = 12;
				name = "Bell";
				width = 12;
				height = 28;
				autoReuse = true;
				noMelee = true;
				value = 10000;
				break;
			case 508:
				rare = 3;
				useStyle = 5;
				useAnimation = 12;
				useTime = 12;
				name = "Harp";
				width = 12;
				height = 28;
				autoReuse = true;
				noMelee = true;
				value = 10000;
				break;
			case 509:
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				name = "Wrench";
				width = 24;
				height = 28;
				rare = 1;
				toolTip = "Places red wire";
				value = 20000;
				mech = true;
				tileBoost = 3;
				break;
			case 510:
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				name = "Wire Cutter";
				width = 24;
				height = 28;
				rare = 1;
				toolTip = "Removes wire";
				value = 20000;
				mech = true;
				tileBoost = 3;
				break;
			case 511:
				name = "Active Stone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 130;
				width = 12;
				height = 12;
				value = 1000;
				mech = true;
				break;
			case 512:
				name = "Inactive Stone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 131;
				width = 12;
				height = 12;
				value = 1000;
				mech = true;
				break;
			case 513:
				name = "Lever";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 132;
				width = 24;
				height = 24;
				value = 3000;
				mech = true;
				break;
			case 514:
				autoReuse = true;
				useStyle = 5;
				useAnimation = 12;
				useTime = 12;
				name = "Laser Rifle";
				width = 36;
				height = 22;
				shoot = 88;
				mana = 8;
				useSound = 12;
				knockBack = 2.5f;
				damage = 29;
				shootSpeed = 17f;
				noMelee = true;
				rare = 4;
				magic = true;
				value = 150000;
				break;
			case 515:
				name = "Crystal Bullet";
				shootSpeed = 5f;
				shoot = 89;
				damage = 8;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 14;
				knockBack = 1f;
				value = 30;
				ranged = true;
				rare = 3;
				toolTip = "Creates several crystal shards on impact";
				break;
			case 516:
				name = "Holy Arrow";
				shootSpeed = 3.5f;
				shoot = 91;
				damage = 6;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = 1;
				knockBack = 2f;
				value = 80;
				ranged = true;
				rare = 3;
				toolTip = "Summons falling stars on impact";
				break;
			case 517:
				useStyle = 1;
				name = "Magic Dagger";
				shootSpeed = 12f;
				shoot = 93;
				damage = 40;
				width = 18;
				height = 20;
				mana = 6;
				useSound = 1;
				useAnimation = 8;
				useTime = 8;
				noUseGraphic = true;
				noMelee = true;
				value = sellPrice(0, 5);
				knockBack = 3.75f;
				magic = true;
				rare = 4;
				toolTip = "A magical returning dagger";
				break;
			case 518:
				autoReuse = true;
				rare = 4;
				mana = 4;
				useSound = 9;
				name = "Crystal Storm";
				useStyle = 5;
				damage = 25;
				useAnimation = 7;
				useTime = 7;
				width = 24;
				height = 28;
				shoot = 94;
				scale = 0.9f;
				shootSpeed = 16f;
				knockBack = 5f;
				toolTip = "Summons rapid fire crystal shards";
				magic = true;
				value = 500000;
				break;
			case 519:
				autoReuse = true;
				rare = 4;
				mana = 12;
				useSound = 20;
				name = "Cursed Flames";
				useStyle = 5;
				damage = 35;
				useAnimation = 20;
				useTime = 20;
				width = 24;
				height = 28;
				shoot = 95;
				scale = 0.9f;
				shootSpeed = 10f;
				knockBack = 6.5f;
				toolTip = "Summons unholy fire balls";
				magic = true;
				value = 500000;
				break;
			case 520:
				name = "Soul of Light";
				width = 18;
				height = 18;
				maxStack = 999;
				value = 1000;
				rare = 3;
				toolTip = "'The essence of light creatures'";
				break;
			case 521:
				name = "Soul of Night";
				width = 18;
				height = 18;
				maxStack = 999;
				value = 1000;
				rare = 3;
				toolTip = "'The essence of dark creatures'";
				break;
			case 522:
				name = "Cursed Flame";
				width = 12;
				height = 14;
				maxStack = 99;
				value = 4000;
				rare = 3;
				toolTip = "'Not even water can put the flame out'";
				break;
			case 523:
				flame = true;
				name = "Cursed Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 8;
				width = 10;
				height = 12;
				value = 300;
				rare = 1;
				toolTip = "Can be placed in water";
				break;
			case 524:
				name = "Adamantite Forge";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 133;
				width = 44;
				height = 30;
				value = 50000;
				toolTip = "Used to smelt adamantite ore";
				rare = 3;
				break;
			case 525:
				name = "Mythril Anvil";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 134;
				width = 28;
				height = 14;
				value = 25000;
				toolTip = "Used to craft items from mythril and adamantite bars";
				rare = 3;
				break;
			case 526:
				name = "Unicorn Horn";
				width = 14;
				height = 14;
				maxStack = 99;
				value = 15000;
				rare = 1;
				toolTip = "'Sharp and magical!'";
				break;
			case 527:
				name = "Dark Shard";
				width = 14;
				height = 14;
				maxStack = 99;
				value = 4500;
				rare = 2;
				toolTip = "'Sometimes carried by creatures in corrupt deserts'";
				break;
			case 528:
				name = "Light Shard";
				width = 14;
				height = 14;
				maxStack = 99;
				value = 4500;
				rare = 2;
				toolTip = "'Sometimes carried by creatures in light deserts'";
				break;
			case 529:
				name = "Red Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 0;
				mech = true;
				value = 5000;
				mech = true;
				toolTip = "Activates when stepped on";
				break;
			case 530:
				name = "Wire";
				width = 12;
				height = 18;
				maxStack = 999;
				value = 500;
				mech = true;
				break;
			case 531:
				name = "Spell Tome";
				width = 12;
				height = 18;
				maxStack = 99;
				value = 50000;
				rare = 1;
				toolTip = "Can be enchanted";
				break;
			case 532:
				name = "Star Cloak";
				width = 20;
				height = 24;
				value = 100000;
				toolTip = "Causes stars to fall when injured";
				accessory = true;
				rare = 4;
				backSlot = 2;
				break;
			case 533:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 7;
				useTime = 7;
				name = "Megashark";
				width = 50;
				height = 18;
				shoot = 10;
				useAmmo = 14;
				useSound = 11;
				damage = 23;
				shootSpeed = 10f;
				noMelee = true;
				value = 300000;
				rare = 5;
				toolTip = "50% chance to not consume ammo";
				toolTip2 = "'Minishark's older brother'";
				knockBack = 1f;
				ranged = true;
				break;
			case 534:
				knockBack = 6.5f;
				useStyle = 5;
				useAnimation = 45;
				useTime = 45;
				name = "Shotgun";
				width = 50;
				height = 14;
				shoot = 10;
				useAmmo = 14;
				useSound = 36;
				damage = 23;
				shootSpeed = 6f;
				noMelee = true;
				value = 250000;
				rare = 4;
				ranged = true;
				toolTip = "Fires a spread of bullets";
				break;
			case 535:
				name = "Philosopher's Stone";
				width = 12;
				height = 18;
				value = 100000;
				toolTip = "Reduces the cooldown of healing potions";
				accessory = true;
				rare = 4;
				break;
			case 536:
				name = "Titan Glove";
				width = 12;
				height = 18;
				value = 100000;
				toolTip = "Increases melee knockback";
				rare = 4;
				accessory = true;
				handOnSlot = 15;
				handOffSlot = 8;
				break;
			case 537:
				name = "Cobalt Naginata";
				useStyle = 5;
				useAnimation = 28;
				useTime = 28;
				shootSpeed = 4.3f;
				knockBack = 4f;
				width = 40;
				height = 40;
				damage = 29;
				scale = 1.1f;
				useSound = 1;
				shoot = 97;
				rare = 4;
				value = 45000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				break;
			case 538:
				name = "Switch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 136;
				width = 12;
				height = 12;
				value = 2000;
				mech = true;
				break;
			case 539:
				name = "Dart Trap";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 137;
				width = 12;
				height = 12;
				value = 10000;
				mech = true;
				break;
			case 540:
				name = "Boulder";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 138;
				width = 12;
				height = 12;
				mech = true;
				break;
			case 541:
				name = "Green Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 1;
				mech = true;
				value = 5000;
				toolTip = "Activates when stepped on";
				break;
			case 542:
				name = "Gray Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 2;
				mech = true;
				value = 5000;
				toolTip = "Activates when a player steps on it on";
				break;
			case 543:
				name = "Brown Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 3;
				mech = true;
				value = 5000;
				toolTip = "Activates when a player steps on it on";
				break;
			case 544:
				useStyle = 4;
				name = "Mechanical Eye";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons The Twins";
				rare = 3;
				break;
			case 545:
				name = "Cursed Arrow";
				shootSpeed = 4f;
				shoot = 103;
				damage = 14;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = 1;
				knockBack = 3f;
				value = 80;
				ranged = true;
				rare = 3;
				break;
			case 546:
				name = "Cursed Bullet";
				shootSpeed = 5f;
				shoot = 104;
				damage = 12;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 14;
				knockBack = 4f;
				value = 30;
				rare = 1;
				ranged = true;
				rare = 3;
				break;
			case 547:
				name = "Soul of Fright";
				width = 18;
				height = 18;
				maxStack = 999;
				value = 40000;
				rare = 5;
				toolTip = "'The essence of pure terror'";
				break;
			case 548:
				name = "Soul of Might";
				width = 18;
				height = 18;
				maxStack = 999;
				value = 40000;
				rare = 5;
				toolTip = "'The essence of the destroyer'";
				break;
			case 549:
				name = "Soul of Sight";
				width = 18;
				height = 18;
				maxStack = 999;
				value = 40000;
				rare = 5;
				toolTip = "'The essence of omniscient watchers'";
				break;
			case 550:
				name = "Gungnir";
				useStyle = 5;
				useAnimation = 22;
				useTime = 22;
				shootSpeed = 5.6f;
				knockBack = 6.4f;
				width = 40;
				height = 40;
				damage = 42;
				scale = 1.1f;
				useSound = 1;
				shoot = 105;
				rare = 5;
				value = 230000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				break;
			case 551:
				name = "Hallowed Plate Mail";
				width = 18;
				height = 18;
				defense = 15;
				bodySlot = 24;
				rare = 5;
				value = 200000;
				toolTip = "7% increased critical strike chance";
				break;
			case 552:
				name = "Hallowed Greaves";
				width = 18;
				height = 18;
				defense = 11;
				legSlot = 23;
				rare = 5;
				value = 150000;
				toolTip = "7% increased damage";
				toolTip2 = "8% increased movement speed";
				break;
			case 553:
				name = "Hallowed Helmet";
				width = 18;
				height = 18;
				defense = 9;
				headSlot = 41;
				rare = 5;
				value = 250000;
				toolTip = "15% increased ranged damage";
				toolTip2 = "8% increased ranged critical strike chance";
				break;
			case 558:
				name = "Hallowed Headgear";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 42;
				rare = 5;
				value = 250000;
				toolTip = "Increases maximum mana by 100";
				toolTip2 = "12% increased magic damage and critical strike chance";
				break;
			case 559:
				name = "Hallowed Mask";
				width = 18;
				height = 18;
				defense = 24;
				headSlot = 43;
				rare = 5;
				value = 250000;
				toolTip = "10% increased melee damage and critical strike chance";
				toolTip2 = "10% increased melee haste";
				break;
			case 554:
				name = "Cross Necklace";
				width = 20;
				height = 24;
				value = 1500;
				toolTip = "Increases length of invincibility after taking damage";
				accessory = true;
				rare = 4;
				neckSlot = 2;
				break;
			case 555:
				name = "Mana Flower";
				width = 20;
				height = 24;
				value = 50000;
				toolTip = "8% reduced mana usage";
				toolTip2 = "Automatically use mana potions when needed";
				accessory = true;
				rare = 4;
				waistSlot = 6;
				break;
			case 556:
				useStyle = 4;
				name = "Mechanical Worm";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons Destroyer";
				rare = 3;
				break;
			case 557:
				useStyle = 4;
				name = "Mechanical Skull";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons Skeletron Prime";
				rare = 3;
				break;
			case 560:
				useStyle = 4;
				name = "Slime Crown";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons King Slime";
				rare = 1;
				break;
			case 561:
				melee = true;
				autoReuse = true;
				noMelee = true;
				useStyle = 1;
				name = "Light Disc";
				shootSpeed = 13f;
				shoot = 106;
				damage = 35;
				knockBack = 8f;
				width = 24;
				height = 24;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 5;
				maxStack = 5;
				value = 500000;
				toolTip = "Stacks up to 5";
				break;
			case 562:
				name = "Music Box (Overworld Day)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 0;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				break;
			case 563:
				name = "Music Box (Eerie)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 1;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				break;
			case 564:
				name = "Music Box (Night)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 2;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				break;
			case 565:
				name = "Music Box (Title)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 3;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				break;
			case 566:
				name = "Music Box (Underground)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 4;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				break;
			case 567:
				name = "Music Box (Boss 1)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 5;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				break;
			case 568:
				name = "Music Box (Jungle)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 6;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				break;
			case 569:
				name = "Music Box (Corruption)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 7;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				break;
			case 570:
				name = "Music Box (Underground Corruption)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 8;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				break;
			case 571:
				name = "Music Box (The Hallow)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 9;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				break;
			case 572:
				name = "Music Box (Boss 2)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 10;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				break;
			case 573:
				name = "Music Box (Underground Hallow)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 11;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				break;
			case 574:
				name = "Music Box (Boss 3)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 12;
				width = 24;
				height = 24;
				rare = 3;
				value = 100000;
				accessory = true;
				break;
			case 575:
				name = "Soul of Flight";
				width = 18;
				height = 18;
				maxStack = 999;
				value = 1000;
				rare = 3;
				toolTip = "'The essence of powerful flying creatures'";
				break;
			case 576:
				name = "Music Box";
				width = 24;
				height = 24;
				rare = 3;
				toolTip = "Has a chance to record songs";
				value = 100000;
				accessory = true;
				break;
			case 577:
				name = "Demonite Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 140;
				width = 12;
				height = 12;
				break;
			case 578:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 19;
				useTime = 19;
				name = "Hallowed Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 43;
				shootSpeed = 11f;
				noMelee = true;
				value = 200000;
				ranged = true;
				rare = 4;
				knockBack = 2.5f;
				break;
			case 579:
				name = "Drax";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 36f;
				knockBack = 4.75f;
				width = 20;
				height = 12;
				damage = 35;
				pick = 200;
				axe = 22;
				useSound = 23;
				shoot = 107;
				rare = 4;
				value = 220000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				toolTip = "'Not to be confused with a picksaw'";
				break;
			case 580:
				mech = true;
				name = "Explosives";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 141;
				width = 12;
				height = 12;
				toolTip = "Explodes when activated";
				break;
			case 581:
				mech = true;
				name = "Inlet Pump";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 142;
				width = 12;
				height = 12;
				toolTip = "Sends water to outlet pumps";
				break;
			case 582:
				mech = true;
				name = "Outlet Pump";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 143;
				width = 12;
				height = 12;
				toolTip = "Receives water from inlet pumps";
				break;
			case 583:
				mech = true;
				noWet = true;
				name = "1 Second Timer";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 144;
				placeStyle = 0;
				width = 10;
				height = 12;
				value = 50;
				toolTip = "Activates every second";
				break;
			case 584:
				mech = true;
				noWet = true;
				name = "3 Second Timer";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 144;
				placeStyle = 1;
				width = 10;
				height = 12;
				value = 50;
				toolTip = "Activates every 3 seconds";
				break;
			case 585:
				mech = true;
				noWet = true;
				name = "5 Second Timer";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 144;
				placeStyle = 2;
				width = 10;
				height = 12;
				value = 50;
				toolTip = "Activates every 5 seconds";
				break;
			case 586:
				name = "Candy Cane Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 145;
				width = 12;
				height = 12;
				break;
			case 587:
				name = "Candy Cane Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 29;
				width = 12;
				height = 12;
				break;
			case 588:
				name = "Santa Hat";
				width = 18;
				height = 12;
				headSlot = 44;
				value = 150000;
				vanity = true;
				break;
			case 589:
				name = "Santa Shirt";
				width = 18;
				height = 18;
				bodySlot = 25;
				value = 150000;
				vanity = true;
				break;
			case 590:
				name = "Santa Pants";
				width = 18;
				height = 18;
				legSlot = 24;
				value = 150000;
				vanity = true;
				break;
			case 591:
				name = "Green Candy Cane Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 146;
				width = 12;
				height = 12;
				break;
			case 592:
				name = "Green Candy Cane Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 30;
				width = 12;
				height = 12;
				break;
			case 593:
				name = "Snow Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 147;
				width = 12;
				height = 12;
				break;
			case 594:
				name = "Snow Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 148;
				width = 12;
				height = 12;
				break;
			case 595:
				name = "Snow Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 31;
				width = 12;
				height = 12;
				break;
			case 596:
				name = "Blue Light";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 149;
				placeStyle = 0;
				width = 12;
				height = 12;
				value = 500;
				break;
			case 597:
				name = "Red Light";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 149;
				placeStyle = 1;
				width = 12;
				height = 12;
				value = 500;
				break;
			case 598:
				name = "Green Light";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 149;
				placeStyle = 2;
				width = 12;
				height = 12;
				value = 500;
				break;
			case 599:
				name = "Blue Present";
				width = 12;
				height = 12;
				rare = 1;
				toolTip = "Right click to open";
				break;
			case 600:
				name = "Green Present";
				width = 12;
				height = 12;
				rare = 1;
				toolTip = "Right click to open";
				break;
			case 601:
				name = "Yellow Present";
				width = 12;
				height = 12;
				rare = 1;
				toolTip = "Right click to open";
				break;
			case 602:
				name = "Snow Globe";
				useStyle = 4;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				width = 28;
				height = 28;
				toolTip = "Summons the Frost Legion";
				rare = 2;
				break;
			case 603:
				damage = 0;
				useStyle = 1;
				name = "Carrot";
				shoot = 111;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a pet bunny";
				value = 0;
				buffType = 40;
				break;
			case 604:
				name = "Adamantite Beam";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 150;
				width = 12;
				height = 12;
				break;
			case 605:
				name = "Adamantite Beam Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 32;
				width = 12;
				height = 12;
				break;
			case 606:
				name = "Demonite Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 33;
				width = 12;
				height = 12;
				break;
			case 607:
				name = "Sandstone Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 151;
				width = 12;
				height = 12;
				break;
			case 608:
				name = "Sandstone Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 34;
				width = 12;
				height = 12;
				break;
			case 609:
				name = "Ebonstone Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 152;
				width = 12;
				height = 12;
				break;
			case 610:
				name = "Ebonstone Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 35;
				width = 12;
				height = 12;
				break;
			case 611:
				name = "Red Stucco";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 153;
				width = 12;
				height = 12;
				break;
			case 612:
				name = "Yellow Stucco";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 154;
				width = 12;
				height = 12;
				break;
			case 613:
				name = "Green Stucco";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 155;
				width = 12;
				height = 12;
				break;
			case 614:
				name = "Gray Stucco";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 156;
				width = 12;
				height = 12;
				break;
			case 615:
				name = "Red Stucco Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 36;
				width = 12;
				height = 12;
				break;
			case 616:
				name = "Yellow Stucco Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 37;
				width = 12;
				height = 12;
				break;
			case 617:
				name = "Green Stucco Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 38;
				width = 12;
				height = 12;
				break;
			case 618:
				name = "Gray Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 39;
				width = 12;
				height = 12;
				break;
			case 619:
				name = "Ebonwood";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 157;
				width = 8;
				height = 10;
				break;
			case 620:
				name = "Rich Mahogany";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 158;
				width = 8;
				height = 10;
				break;
			case 621:
				name = "Pearlwood";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 159;
				width = 8;
				height = 10;
				break;
			case 622:
				name = "Ebonwood Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 41;
				width = 12;
				height = 12;
				break;
			case 623:
				name = "Rich Mahogany Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 42;
				width = 12;
				height = 12;
				break;
			case 624:
				name = "Pearlwood Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 43;
				width = 12;
				height = 12;
				break;
			case 625:
				name = "Ebonwood Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 7;
				width = 26;
				height = 22;
				value = 500;
				break;
			case 626:
				name = "Rich Mahogany Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 8;
				width = 26;
				height = 22;
				value = 500;
				break;
			case 627:
				name = "Pearlwood Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 9;
				width = 26;
				height = 22;
				value = 500;
				break;
			case 628:
				name = "Ebonwood Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 2;
				width = 12;
				height = 30;
				break;
			case 629:
				name = "Rich Mahogany Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 3;
				width = 12;
				height = 30;
				break;
			case 630:
				name = "Pearlwood Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 4;
				width = 12;
				height = 30;
				break;
			case 631:
				name = "Ebonwood Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 1;
				width = 8;
				height = 10;
				break;
			case 632:
				name = "Rich Mahogany Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 2;
				width = 8;
				height = 10;
				break;
			case 633:
				name = "Pearlwood Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 3;
				width = 8;
				height = 10;
				break;
			case 634:
				name = "Bone Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 4;
				width = 8;
				height = 10;
				break;
			case 635:
				name = "Ebonwood Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 1;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				break;
			case 636:
				name = "Rich Mahogany Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 2;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				break;
			case 637:
				name = "Pearlwood Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 3;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				break;
			case 638:
				name = "Ebonwood Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 1;
				width = 26;
				height = 20;
				value = 300;
				break;
			case 639:
				name = "Rich Mahogany Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 2;
				width = 26;
				height = 20;
				value = 300;
				break;
			case 640:
				name = "Pearlwood Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 3;
				width = 26;
				height = 20;
				value = 300;
				break;
			case 641:
				name = "Ebonwood Piano";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 87;
				placeStyle = 1;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 642:
				name = "Rich Mahogany Piano";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 87;
				placeStyle = 2;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 643:
				name = "Pearlwood Piano";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 87;
				placeStyle = 3;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 644:
				name = "Ebonwood Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 1;
				width = 28;
				height = 20;
				value = 2000;
				break;
			case 645:
				name = "Rich Mahogany Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 2;
				width = 28;
				height = 20;
				value = 2000;
				break;
			case 646:
				name = "Pearlwood Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 3;
				width = 28;
				height = 20;
				value = 2000;
				break;
			case 647:
				name = "Ebonwood Dresser";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 88;
				placeStyle = 1;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 648:
				name = "Rich Mahogany Dresser";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 88;
				placeStyle = 2;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 649:
				name = "Pearlwood Dresser";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 88;
				placeStyle = 3;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 650:
				name = "Ebonwood Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 1;
				width = 14;
				height = 28;
				value = 200;
				break;
			case 651:
				name = "Rich Mahogany Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 2;
				width = 14;
				height = 28;
				value = 200;
				break;
			case 652:
				name = "Pearlwood Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 3;
				width = 14;
				height = 28;
				value = 200;
				break;
			case 653:
				name = "Ebonwood Sword";
				useStyle = 1;
				useTurn = false;
				useAnimation = 21;
				useTime = 21;
				width = 24;
				height = 28;
				damage = 10;
				knockBack = 5f;
				useSound = 1;
				scale = 1f;
				value = 100;
				melee = true;
				break;
			case 654:
				name = "Ebonwood Hammer";
				autoReuse = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 30;
				useTime = 20;
				hammer = 40;
				width = 24;
				height = 28;
				damage = 7;
				knockBack = 5.5f;
				scale = 1.2f;
				useSound = 1;
				value = 50;
				melee = true;
				break;
			case 655:
				name = "Ebonwood Bow";
				useStyle = 5;
				useAnimation = 28;
				useTime = 28;
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 8;
				shootSpeed = 6.6f;
				noMelee = true;
				value = 100;
				ranged = true;
				break;
			case 656:
				name = "Rich Mahogany Sword";
				useStyle = 1;
				useTurn = false;
				useAnimation = 23;
				useTime = 23;
				width = 24;
				height = 28;
				damage = 8;
				knockBack = 5f;
				useSound = 1;
				scale = 1f;
				value = 100;
				melee = true;
				break;
			case 657:
				name = "Rich Mahogany Hammer";
				autoReuse = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 33;
				useTime = 23;
				hammer = 35;
				width = 24;
				height = 28;
				damage = 4;
				knockBack = 5.5f;
				scale = 1.1f;
				useSound = 1;
				value = 50;
				melee = true;
				break;
			case 658:
				name = "Rich Mahogany Bow";
				useStyle = 5;
				useAnimation = 29;
				useTime = 29;
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 6;
				shootSpeed = 6.6f;
				noMelee = true;
				value = 100;
				ranged = true;
				break;
			case 659:
				name = "Pearlwood Sword";
				useStyle = 1;
				useTurn = false;
				useAnimation = 21;
				useTime = 21;
				width = 24;
				height = 28;
				damage = 11;
				knockBack = 5f;
				useSound = 1;
				scale = 1f;
				value = 100;
				melee = true;
				break;
			case 660:
				name = "Pearlwood Hammer";
				autoReuse = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 29;
				useTime = 19;
				hammer = 45;
				width = 24;
				height = 28;
				damage = 9;
				knockBack = 5.5f;
				scale = 1.25f;
				useSound = 1;
				value = 50;
				melee = true;
				break;
			case 661:
				name = "Pearlwood Bow";
				useStyle = 5;
				useAnimation = 27;
				useTime = 27;
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 9;
				shootSpeed = 6.6f;
				noMelee = true;
				value = 100;
				ranged = true;
				break;
			case 662:
				name = "Rainbow Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 160;
				width = 12;
				height = 12;
				break;
			case 663:
				name = "Rainbow Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 44;
				width = 12;
				height = 12;
				break;
			case 664:
				name = "Ice Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 161;
				width = 12;
				height = 12;
				break;
			case 665:
				name = "Red's Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "You shouldn't have this";
				rare = 9;
				wingSlot = 3;
				break;
			case 666:
				name = "Red's Helmet";
				width = 18;
				height = 18;
				headSlot = 45;
				rare = 9;
				toolTip = "You shouldn't have this";
				vanity = true;
				break;
			case 667:
				name = "Red's Breastplate";
				width = 18;
				height = 18;
				bodySlot = 26;
				rare = 9;
				toolTip = "You shouldn't have this";
				vanity = true;
				break;
			case 668:
				name = "Red's Leggings";
				width = 18;
				height = 18;
				legSlot = 25;
				rare = 9;
				toolTip = "You shouldn't have this";
				vanity = true;
				break;
			case 669:
				damage = 0;
				useStyle = 1;
				name = "Fish";
				shoot = 112;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a baby penguin";
				buffType = 41;
				value = sellPrice(0, 2);
				break;
			case 670:
				noMelee = true;
				useStyle = 1;
				name = "Ice Boomerang";
				shootSpeed = 11.5f;
				shoot = 113;
				damage = 14;
				knockBack = 8.5f;
				width = 14;
				height = 28;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 1;
				value = 50000;
				melee = true;
				break;
			case 671:
				name = "Lockblade";
				useStyle = 1;
				useAnimation = 22;
				useTime = 22;
				knockBack = 6f;
				width = 40;
				height = 40;
				damage = 55;
				scale = 1.2f;
				useSound = 1;
				rare = 8;
				value = 138000;
				melee = true;
				break;
			case 672:
				name = "Cutlass";
				useStyle = 1;
				useAnimation = 17;
				knockBack = 4f;
				width = 24;
				height = 28;
				damage = 51;
				scale = 1.1f;
				useSound = 1;
				rare = 4;
				value = 180000;
				melee = true;
				autoReuse = true;
				useTurn = true;
				break;
			case 673:
				name = "Boreal Wood Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 23;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				break;
			case 674:
				name = "True Excalibur";
				useStyle = 1;
				useAnimation = 16;
				useTime = 16;
				shoot = 156;
				shootSpeed = 11f;
				knockBack = 4.5f;
				width = 40;
				height = 40;
				damage = 60;
				scale = 1.05f;
				useSound = 1;
				rare = 8;
				value = sellPrice(0, 10);
				melee = true;
				break;
			case 675:
				name = "True Night's Edge";
				useStyle = 1;
				useAnimation = 24;
				useTime = 24;
				shoot = 157;
				shootSpeed = 10f;
				knockBack = 4.75f;
				width = 40;
				height = 40;
				damage = 78;
				scale = 1.15f;
				useSound = 1;
				rare = 8;
				value = sellPrice(0, 10);
				melee = true;
				break;
			case 676:
				name = "Frostbrand";
				useStyle = 1;
				useAnimation = 23;
				useTime = 59;
				knockBack = 4.5f;
				width = 24;
				height = 28;
				damage = 49;
				scale = 1.15f;
				useSound = 1;
				rare = 5;
				shoot = 119;
				shootSpeed = 12f;
				value = 250000;
				toolTip = "Shoots an icy bolt";
				melee = true;
				break;
			case 677:
				name = "Boreal Wood Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 28;
				width = 26;
				height = 20;
				value = 300;
				break;
			case 678:
				name = "Red Potion";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				rare = 9;
				break;
			case 679:
				autoReuse = true;
				knockBack = 7f;
				useStyle = 5;
				useAnimation = 34;
				useTime = 34;
				name = "Tactical Shotgun";
				width = 50;
				height = 14;
				shoot = 10;
				useAmmo = 14;
				useSound = 38;
				damage = 29;
				shootSpeed = 6f;
				noMelee = true;
				value = 700000;
				rare = 8;
				ranged = true;
				toolTip = "Fires a spread of bullets";
				break;
			case 680:
				name = "Bamboo Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 10;
				width = 26;
				height = 22;
				value = 5000;
				break;
			case 681:
				name = "Ice Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 11;
				width = 26;
				height = 22;
				value = 5000;
				break;
			case 682:
				useStyle = 5;
				useAnimation = 19;
				useTime = 19;
				name = "Marrow";
				width = 14;
				height = 32;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 40;
				shootSpeed = 11f;
				knockBack = 4.7f;
				rare = 5;
				crit = 5;
				noMelee = true;
				scale = 1.1f;
				value = 27000;
				ranged = true;
				break;
			case 683:
				rare = 7;
				mana = 14;
				useSound = 20;
				name = "Unholy Trident";
				useStyle = 5;
				damage = 67;
				useAnimation = 30;
				useTime = 30;
				width = 30;
				height = 30;
				shoot = 114;
				shootSpeed = 13f;
				knockBack = 6.5f;
				toolTip = "Summons the Devil's trident";
				magic = true;
				value = 500000;
				break;
			case 684:
				name = "Frost Helmet";
				width = 18;
				height = 18;
				defense = 10;
				headSlot = 46;
				rare = 5;
				value = 250000;
				toolTip = "16% increased melee and ranged damage";
				break;
			case 685:
				name = "Frost Breastplate";
				width = 18;
				height = 18;
				defense = 20;
				bodySlot = 27;
				rare = 5;
				value = 200000;
				toolTip = "11% increased melee and ranged critical strike chance";
				break;
			case 686:
				name = "Frost Leggings";
				width = 18;
				height = 18;
				defense = 13;
				legSlot = 26;
				rare = 5;
				value = 150000;
				toolTip = "8% increased movement speed";
				toolTip = "7% increased melee attack speed";
				break;
			case 687:
				name = "Tin Helmet";
				width = 18;
				height = 18;
				defense = 2;
				headSlot = 47;
				value = 1875;
				break;
			case 688:
				name = "Tin Chainmail";
				width = 18;
				height = 18;
				defense = 2;
				bodySlot = 28;
				value = sellPrice(0, 0, 0, 50);
				break;
			case 689:
				name = "Tin Greaves";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 27;
				value = 1125;
				break;
			case 690:
				name = "Lead Helmet";
				width = 18;
				height = 18;
				defense = 3;
				headSlot = 48;
				value = 7500;
				break;
			case 691:
				name = "Lead Chainmail";
				width = 18;
				height = 18;
				defense = 3;
				bodySlot = 29;
				value = 6000;
				break;
			case 692:
				name = "Lead Greaves";
				width = 18;
				height = 18;
				defense = 2;
				legSlot = 28;
				value = 4500;
				break;
			case 693:
				name = "Tungsten Helmet";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 49;
				value = 7500;
				break;
			case 694:
				name = "Tungsten Chainmail";
				width = 18;
				height = 18;
				defense = 5;
				bodySlot = 30;
				value = 6000;
				break;
			case 695:
				name = "Tungsten Greaves";
				width = 18;
				height = 18;
				defense = 3;
				legSlot = 29;
				value = 4500;
				break;
			case 696:
				name = "Platinum Helmet";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 50;
				value = 7500;
				break;
			case 697:
				name = "Platinum Chainmail";
				width = 18;
				height = 18;
				defense = 6;
				bodySlot = 31;
				value = 6000;
				break;
			case 698:
				name = "Platinum Greaves";
				width = 18;
				height = 18;
				defense = 5;
				legSlot = 30;
				value = 4500;
				break;
			case 699:
				name = "Tin Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 166;
				width = 12;
				height = 12;
				value = 375;
				break;
			case 700:
				name = "Lead Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 167;
				width = 12;
				height = 12;
				value = 750;
				break;
			case 701:
				name = "Tungsten Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 168;
				width = 12;
				height = 12;
				value = 1500;
				break;
			case 702:
				name = "Platinum Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 169;
				width = 12;
				height = 12;
				value = 3000;
				break;
			case 703:
				name = "Tin Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 1125;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 1;
				break;
			case 704:
				name = "Lead Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 2250;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 3;
				break;
			case 705:
				name = "Tungsten Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 4500;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 5;
				break;
			case 706:
				name = "Platinum Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 9000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 7;
				break;
			case 707:
				name = "Tin Watch";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Tells the time";
				value = 1500;
				waistSlot = 8;
				break;
			case 708:
				name = "Tungsten Watch";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Tells the time";
				value = 7500;
				waistSlot = 9;
				break;
			case 709:
				name = "Platinum Watch";
				width = 24;
				height = 28;
				accessory = true;
				rare = 1;
				toolTip = "Tells the time";
				value = 15000;
				waistSlot = 4;
				break;
			case 710:
				name = "Tin Chandelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 3;
				width = 26;
				height = 26;
				value = 4500;
				break;
			case 711:
				name = "Tungsten Chandelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 4;
				width = 26;
				height = 26;
				value = 18000;
				break;
			case 712:
				name = "Platinum Chandelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 5;
				width = 26;
				height = 26;
				value = 36000;
				break;
			case 713:
				flame = true;
				name = "Platinum Candle";
				noWet = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 174;
				width = 8;
				height = 18;
				holdStyle = 1;
				break;
			case 714:
				name = "Platinum Candelabra";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 173;
				width = 20;
				height = 20;
				break;
			case 715:
				name = "Platinum Crown";
				width = 18;
				height = 18;
				headSlot = 51;
				value = 15000;
				vanity = true;
				break;
			case 716:
				name = "Lead Anvil";
				placeStyle = 1;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 16;
				width = 28;
				height = 14;
				value = 7500;
				toolTip = "Used to craft items from metal bars";
				break;
			case 717:
				name = "Tin Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 175;
				width = 12;
				height = 12;
				break;
			case 718:
				name = "Tungsten Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 176;
				width = 12;
				height = 12;
				break;
			case 719:
				name = "Platinum Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 177;
				width = 12;
				height = 12;
				break;
			case 720:
				name = "Tin Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 45;
				width = 12;
				height = 12;
				break;
			case 721:
				name = "Tungsten Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 46;
				width = 12;
				height = 12;
				break;
			case 722:
				name = "Platinum Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 47;
				width = 12;
				height = 12;
				break;
			case 723:
				rare = 4;
				useSound = 1;
				name = "Beam Sword";
				useStyle = 1;
				damage = 52;
				useAnimation = 15;
				useTime = 60;
				width = 30;
				height = 30;
				shoot = 116;
				shootSpeed = 11f;
				knockBack = 6.5f;
				toolTip = "Shoots a beam of light";
				melee = true;
				value = 500000;
				break;
			case 724:
				rare = 1;
				useSound = 1;
				name = "Ice Blade";
				useStyle = 1;
				damage = 13;
				useAnimation = 20;
				useTime = 70;
				width = 30;
				height = 30;
				shoot = 118;
				shootSpeed = 8f;
				knockBack = 4.75f;
				toolTip = "Shoots an icy bolt";
				melee = true;
				value = 20000;
				break;
			case 725:
				useStyle = 5;
				useAnimation = 21;
				useTime = 21;
				name = "Ice Bow";
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 46;
				shootSpeed = 10f;
				knockBack = 4.5f;
				alpha = 30;
				rare = 5;
				noMelee = true;
				value = sellPrice(0, 3, 50);
				toolTip = "Shoots frost arrows";
				ranged = true;
				break;
			case 726:
				autoReuse = true;
				rare = 5;
				mana = 14;
				useSound = 20;
				name = "Frost Staff";
				useStyle = 5;
				damage = 43;
				useAnimation = 20;
				useTime = 20;
				width = 30;
				height = 30;
				shoot = 359;
				shootSpeed = 16f;
				knockBack = 5f;
				toolTip = "Shoots a stream of frost";
				magic = true;
				value = 500000;
				noMelee = true;
				break;
			case 727:
				name = "Wood Helmet";
				width = 18;
				height = 18;
				defense = 1;
				headSlot = 52;
				break;
			case 728:
				name = "Wood Breastplate";
				width = 18;
				height = 18;
				defense = 1;
				bodySlot = 32;
				break;
			case 729:
				name = "Wood Greaves";
				width = 18;
				height = 18;
				defense = 0;
				legSlot = 31;
				break;
			case 730:
				name = "Ebonwood Helmet";
				width = 18;
				height = 18;
				defense = 1;
				headSlot = 53;
				break;
			case 731:
				name = "Ebonwood Breastplate";
				width = 18;
				height = 18;
				defense = 2;
				bodySlot = 33;
				break;
			case 732:
				name = "Ebonwood Greaves";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 32;
				break;
			case 733:
				name = "Rich Mahogany Helmet";
				width = 18;
				height = 18;
				defense = 1;
				headSlot = 54;
				break;
			case 734:
				name = "Rich Mahogany Breastplate";
				width = 18;
				height = 18;
				defense = 1;
				bodySlot = 34;
				break;
			case 735:
				name = "Rich Mahogany Greaves";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 33;
				break;
			case 736:
				name = "Pearlwood Helmet";
				width = 18;
				height = 18;
				defense = 2;
				headSlot = 55;
				break;
			case 737:
				name = "Pearlwood Breastplate";
				width = 18;
				height = 18;
				defense = 3;
				bodySlot = 35;
				break;
			case 738:
				name = "Pearlwood Greaves";
				width = 18;
				height = 18;
				defense = 2;
				legSlot = 34;
				break;
			case 739:
				name = "Amethyst Staff";
				mana = 3;
				useSound = 43;
				useStyle = 5;
				damage = 14;
				useAnimation = 40;
				useTime = 40;
				width = 40;
				height = 40;
				shoot = 121;
				shootSpeed = 6f;
				knockBack = 3.25f;
				value = 2000;
				magic = true;
				noMelee = true;
				break;
			case 740:
				name = "Topaz Staff";
				mana = 4;
				useSound = 43;
				useStyle = 5;
				damage = 15;
				useAnimation = 38;
				useTime = 38;
				width = 40;
				height = 40;
				shoot = 122;
				shootSpeed = 6.5f;
				knockBack = 3.5f;
				value = 3000;
				magic = true;
				noMelee = true;
				break;
			case 741:
				name = "Sapphire Staff";
				mana = 5;
				useSound = 43;
				useStyle = 5;
				damage = 17;
				useAnimation = 34;
				useTime = 34;
				width = 40;
				height = 40;
				shoot = 123;
				shootSpeed = 7.5f;
				knockBack = 4f;
				value = 10000;
				magic = true;
				rare = 1;
				noMelee = true;
				break;
			case 742:
				name = "Emerald Staff";
				mana = 6;
				useSound = 43;
				useStyle = 5;
				damage = 19;
				useAnimation = 32;
				useTime = 32;
				width = 40;
				height = 40;
				shoot = 124;
				shootSpeed = 8f;
				knockBack = 4.25f;
				magic = true;
				autoReuse = true;
				value = 15000;
				rare = 1;
				noMelee = true;
				break;
			case 743:
				name = "Ruby Staff";
				mana = 7;
				useSound = 43;
				useStyle = 5;
				damage = 21;
				useAnimation = 28;
				useTime = 28;
				width = 40;
				height = 40;
				shoot = 125;
				shootSpeed = 9f;
				knockBack = 4.75f;
				magic = true;
				autoReuse = true;
				value = 20000;
				rare = 1;
				noMelee = true;
				break;
			case 744:
				name = "Diamond Staff";
				mana = 8;
				useSound = 43;
				useStyle = 5;
				damage = 23;
				useAnimation = 26;
				useTime = 26;
				width = 40;
				height = 40;
				shoot = 126;
				shootSpeed = 9.5f;
				knockBack = 5.5f;
				magic = true;
				autoReuse = true;
				value = 30000;
				rare = 2;
				noMelee = true;
				break;
			case 745:
				name = "Grass Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 66;
				width = 12;
				height = 12;
				value = 10;
				break;
			case 746:
				name = "Jungle Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 67;
				width = 12;
				height = 12;
				value = 10;
				break;
			case 747:
				name = "Flower Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 68;
				width = 12;
				height = 12;
				value = 10;
				break;
			case 748:
				name = "Jetpack";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				toolTip2 = "Hold up to rocket faster";
				value = 400000;
				rare = 5;
				wingSlot = 4;
				break;
			case 749:
				name = "Butterfly Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 5;
				break;
			case 750:
				name = "Cactus Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 72;
				width = 12;
				height = 12;
				break;
			case 751:
				name = "Cloud";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 189;
				width = 12;
				height = 12;
				break;
			case 752:
				name = "Cloud Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 73;
				width = 12;
				height = 12;
				break;
			case 753:
				damage = 0;
				useStyle = 1;
				name = "Seaweed";
				shoot = 127;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a turtle";
				value = sellPrice(0, 2);
				buffType = 42;
				break;
			case 754:
				name = "Rune Hat";
				width = 28;
				height = 20;
				headSlot = 56;
				rare = 5;
				value = 50000;
				vanity = true;
				break;
			case 755:
				name = "Rune Robe";
				width = 18;
				height = 14;
				bodySlot = 36;
				value = 50000;
				vanity = true;
				rare = 5;
				break;
			case 756:
				rare = 7;
				name = "Mushroom Spear";
				useStyle = 5;
				useAnimation = 40;
				useTime = 40;
				shootSpeed = 5.5f;
				knockBack = 6.2f;
				width = 32;
				height = 32;
				damage = 60;
				scale = 1f;
				useSound = 1;
				shoot = 130;
				value = buyPrice(0, 70);
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				break;
			case 757:
				rare = 8;
				useSound = 1;
				name = "Terra Blade";
				useStyle = 1;
				damage = 88;
				useAnimation = 16;
				useTime = 16;
				width = 30;
				height = 30;
				shoot = 132;
				scale = 1.1f;
				shootSpeed = 12f;
				knockBack = 6.5f;
				melee = true;
				value = sellPrice(0, 20);
				autoReuse = true;
				break;
			case 758:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 30;
				useTime = 30;
				name = "Grenade Launcher";
				useAmmo = 771;
				width = 50;
				height = 20;
				shoot = 133;
				useSound = 11;
				damage = 55;
				shootSpeed = 10f;
				noMelee = true;
				value = 100000;
				knockBack = 4f;
				rare = 8;
				ranged = true;
				break;
			case 759:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 30;
				useTime = 30;
				name = "Rocket Launcher";
				useAmmo = 771;
				width = 50;
				height = 20;
				shoot = 134;
				useSound = 11;
				damage = 50;
				shootSpeed = 5f;
				noMelee = true;
				value = 100000;
				knockBack = 4f;
				rare = 8;
				ranged = true;
				break;
			case 760:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 30;
				useTime = 30;
				name = "Proximity Mine Launcher";
				useAmmo = 771;
				width = 50;
				height = 20;
				shoot = 135;
				useSound = 11;
				damage = 45;
				shootSpeed = 11f;
				noMelee = true;
				value = buyPrice(0, 35);
				knockBack = 4f;
				rare = 8;
				ranged = true;
				break;
			case 761:
				name = "Fairy Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 6;
				break;
			case 762:
				name = "Slime Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 193;
				width = 12;
				height = 12;
				break;
			case 763:
				name = "Flesh Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 195;
				width = 12;
				height = 12;
				break;
			case 764:
				name = "Mushroom Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 74;
				width = 12;
				height = 12;
				break;
			case 765:
				name = "Rain Cloud";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 196;
				width = 12;
				height = 12;
				break;
			case 766:
				name = "Bone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 194;
				width = 12;
				height = 12;
				break;
			case 767:
				name = "Frozen Slime Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 197;
				width = 12;
				height = 12;
				break;
			case 768:
				name = "Bone Block Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 75;
				width = 12;
				height = 12;
				break;
			case 769:
				name = "Slime Block Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 76;
				width = 12;
				height = 12;
				break;
			case 770:
				name = "Flesh Block Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 77;
				width = 12;
				height = 12;
				break;
			case 771:
				name = "Rocket I";
				shoot = 0;
				damage = 35;
				width = 20;
				height = 14;
				maxStack = 999;
				consumable = true;
				ammo = 771;
				knockBack = 4f;
				value = buyPrice(0, 0, 0, 50);
				ranged = true;
				toolTip = "Small blast radius. Will not destroy tiles";
				break;
			case 772:
				name = "Rocket II";
				shoot = 3;
				damage = 40;
				width = 20;
				height = 14;
				maxStack = 999;
				consumable = true;
				ammo = 771;
				knockBack = 4f;
				value = buyPrice(0, 0, 2, 50);
				ranged = true;
				toolTip = "Small blast radius. Will destroy tiles";
				rare = 1;
				break;
			case 773:
				name = "Rocket III";
				shoot = 6;
				damage = 55;
				width = 20;
				height = 14;
				maxStack = 999;
				consumable = true;
				ammo = 771;
				knockBack = 6f;
				value = buyPrice(0, 0, 1);
				ranged = true;
				toolTip = "Large blast radius. Will not destroy tiles";
				rare = 1;
				break;
			case 774:
				name = "Rocket IV";
				shoot = 9;
				damage = 60;
				width = 20;
				height = 14;
				maxStack = 999;
				consumable = true;
				ammo = 771;
				knockBack = 6f;
				value = (value = buyPrice(0, 0, 5));
				ranged = true;
				toolTip = "Large blast radius. Will destroy tiles";
				rare = 2;
				break;
			case 775:
				name = "Asphalt Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 198;
				width = 12;
				height = 12;
				toolTip = "Increases running speed";
				break;
			case 776:
				name = "Cobalt Pickaxe";
				useStyle = 1;
				useTurn = true;
				autoReuse = true;
				useAnimation = 25;
				useTime = 13;
				knockBack = 5f;
				width = 20;
				height = 12;
				damage = 10;
				pick = 110;
				useSound = 1;
				rare = 4;
				value = 54000;
				melee = true;
				toolTip = "Can mine Mythril and Orichalcum";
				scale = 1.15f;
				break;
			case 777:
				name = "Mythril Pickaxe";
				useStyle = 1;
				useAnimation = 25;
				useTime = 10;
				knockBack = 5f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 15;
				pick = 150;
				useSound = 1;
				rare = 4;
				value = 81000;
				melee = true;
				toolTip = "Can mine Adamantite and Titanium";
				scale = 1.15f;
				break;
			case 778:
				name = "Adamantite Pickaxe";
				useStyle = 1;
				useAnimation = 25;
				useTime = 7;
				knockBack = 5f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 20;
				pick = 180;
				useSound = 1;
				rare = 4;
				value = 108000;
				melee = true;
				scale = 1.15f;
				break;
			case 779:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 30;
				useTime = 5;
				name = "Clentaminator";
				width = 50;
				height = 18;
				shoot = 145;
				useAmmo = 780;
				useSound = 34;
				knockBack = 0.3f;
				shootSpeed = 7f;
				noMelee = true;
				value = buyPrice(2);
				rare = 5;
				toolTip = "Creates and destroys biomes when sprayed";
				toolTip2 = "Uses colored solution";
				break;
			case 780:
				name = "Green Solutiuon";
				shoot = 0;
				ammo = 780;
				width = 10;
				height = 12;
				value = buyPrice(0, 0, 25);
				rare = 3;
				maxStack = 999;
				toolTip = "Used by the Clentaminator";
				toolTip2 = "Spreads the purity";
				break;
			case 781:
				name = "Blue Solutiuon";
				shoot = 1;
				ammo = 780;
				width = 10;
				height = 12;
				value = buyPrice(0, 0, 25);
				rare = 3;
				maxStack = 999;
				toolTip = "Used by the Clentaminator";
				toolTip2 = "Spreads the hallow";
				break;
			case 782:
				name = "Purple Solutiuon";
				shoot = 2;
				ammo = 780;
				width = 10;
				height = 12;
				value = buyPrice(0, 0, 25);
				rare = 3;
				maxStack = 999;
				toolTip = "Used by the Clentaminator";
				toolTip2 = "Spreads the corruption";
				break;
			case 783:
				name = "Dark Blue Solution";
				shoot = 3;
				ammo = 780;
				width = 10;
				height = 12;
				value = buyPrice(0, 0, 25);
				rare = 3;
				maxStack = 999;
				toolTip = "Used by the Clentaminator";
				toolTip2 = "Spreads glowing mushrooms";
				break;
			case 784:
				name = "Red Solution";
				shoot = 4;
				ammo = 780;
				width = 10;
				height = 12;
				value = buyPrice(0, 0, 25);
				rare = 3;
				maxStack = 999;
				toolTip = "Used by the Clentaminator";
				toolTip2 = "Spreads the crimson";
				break;
			case 785:
				name = "Harpy Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 7;
				break;
			case 786:
				name = "Bone Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 8;
				break;
			case 787:
				name = "Hammush";
				useTurn = true;
				autoReuse = true;
				useStyle = 1;
				useAnimation = 27;
				useTime = 14;
				hammer = 85;
				width = 24;
				height = 28;
				damage = 26;
				knockBack = 7.5f;
				scale = 1.1f;
				useSound = 1;
				rare = 7;
				value = buyPrice(0, 40);
				melee = true;
				toolTip = "Strong enough to destroy Demon Altars";
				break;
			case 788:
				mana = 10;
				damage = 25;
				useStyle = 5;
				name = "Nettle Burst";
				shootSpeed = 32f;
				shoot = 150;
				width = 26;
				height = 28;
				useSound = 8;
				useAnimation = 25;
				useTime = 25;
				autoReuse = true;
				rare = 7;
				noMelee = true;
				knockBack = 1f;
				toolTip = "Summons a thorn spear";
				value = 200000;
				magic = true;
				break;
			case 789:
				name = "Ankh Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 4;
				width = 10;
				height = 24;
				value = 5000;
				break;
			case 790:
				name = "Snake Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 5;
				width = 10;
				height = 24;
				value = 5000;
				break;
			case 791:
				name = "Omega Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 6;
				width = 10;
				height = 24;
				value = 5000;
				break;
			case 792:
				name = "Crimson Helmet";
				width = 18;
				height = 18;
				defense = 6;
				headSlot = 57;
				value = 50000;
				toolTip = "2% increased damage";
				rare = 1;
				break;
			case 793:
				name = "Crimson Scalemail";
				width = 18;
				height = 18;
				defense = 7;
				bodySlot = 37;
				value = 40000;
				toolTip = "2% increased damage";
				rare = 1;
				break;
			case 794:
				name = "Crimson Greaves";
				width = 18;
				height = 18;
				defense = 6;
				legSlot = 35;
				value = 30000;
				toolTip = "2% increased damage";
				rare = 1;
				break;
			case 795:
				name = "Blood Butcherer";
				useStyle = 1;
				useAnimation = 25;
				knockBack = 5f;
				width = 24;
				height = 28;
				damage = 22;
				scale = 1.1f;
				useSound = 1;
				rare = 1;
				value = 13500;
				melee = true;
				break;
			case 796:
				useStyle = 5;
				useAnimation = 30;
				useTime = 30;
				name = "Tendon Bow";
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 19;
				shootSpeed = 6.7f;
				knockBack = 1f;
				alpha = 30;
				rare = 1;
				noMelee = true;
				value = 18000;
				ranged = true;
				break;
			case 797:
				name = "Flesh Grinder";
				autoReuse = true;
				useStyle = 1;
				useAnimation = 40;
				useTime = 19;
				hammer = 55;
				width = 24;
				height = 28;
				damage = 23;
				knockBack = 6f;
				scale = 1.2f;
				useSound = 1;
				rare = 1;
				value = 15000;
				melee = true;
				break;
			case 798:
				name = "Deathbringer Pickaxe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 22;
				useTime = 14;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 12;
				pick = 70;
				useSound = 1;
				knockBack = 3.5f;
				rare = 1;
				value = 18000;
				scale = 1.15f;
				toolTip = "Able to mine Hellstone";
				melee = true;
				break;
			case 799:
				name = "Blood Lust Cluster";
				autoReuse = true;
				useStyle = 1;
				useAnimation = 32;
				knockBack = 6f;
				useTime = 15;
				width = 24;
				height = 28;
				damage = 22;
				axe = 15;
				scale = 1.2f;
				useSound = 1;
				rare = 1;
				value = 13500;
				melee = true;
				break;
			case 800:
				useStyle = 5;
				useAnimation = 24;
				useTime = 24;
				name = "The Undertaker";
				width = 24;
				height = 28;
				shoot = 14;
				useAmmo = 14;
				useSound = 11;
				damage = 15;
				shootSpeed = 5f;
				noMelee = true;
				value = 50000;
				scale = 0.9f;
				rare = 1;
				ranged = true;
				break;
			case 801:
				name = "The Meatball";
				useStyle = 5;
				useAnimation = 45;
				useTime = 45;
				knockBack = 6.5f;
				width = 30;
				height = 10;
				damage = 16;
				scale = 1.1f;
				noUseGraphic = true;
				shoot = 154;
				shootSpeed = 12f;
				useSound = 1;
				rare = 1;
				value = 27000;
				melee = true;
				channel = true;
				noMelee = true;
				break;
			case 802:
				name = "The Rotted Fork";
				useStyle = 5;
				useAnimation = 31;
				useTime = 31;
				shootSpeed = 4f;
				knockBack = 5f;
				width = 40;
				height = 40;
				damage = 14;
				scale = 1.1f;
				useSound = 1;
				shoot = 153;
				rare = 1;
				value = 10000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				break;
			case 803:
				name = "Eskimo Hood";
				width = 18;
				height = 18;
				headSlot = 58;
				value = 50000;
				defense = 1;
				break;
			case 804:
				name = "Eskimo Coat";
				width = 18;
				height = 18;
				bodySlot = 38;
				value = 40000;
				defense = 2;
				break;
			case 805:
				name = "Eskimo Pants";
				width = 18;
				height = 18;
				legSlot = 36;
				value = 30000;
				defense = 1;
				break;
			case 806:
				name = "Living Wood Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 5;
				width = 12;
				height = 30;
				break;
			case 807:
				name = "Cactus Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 6;
				width = 12;
				height = 30;
				break;
			case 808:
				name = "Bone Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 7;
				width = 12;
				height = 30;
				break;
			case 809:
				name = "Flesh Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 8;
				width = 12;
				height = 30;
				break;
			case 810:
				name = "Mushroom Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 9;
				width = 12;
				height = 30;
				break;
			case 811:
				name = "Bone Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 4;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				break;
			case 812:
				name = "Cactus Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 5;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				break;
			case 813:
				name = "Flesh Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 6;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				break;
			case 814:
				name = "Mushroom Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 7;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				break;
			case 815:
				name = "Slime Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 8;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				break;
			case 816:
				name = "Cactus Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 4;
				width = 14;
				height = 28;
				value = 200;
				break;
			case 817:
				name = "Flesh Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 5;
				width = 14;
				height = 28;
				value = 200;
				break;
			case 818:
				name = "Mushroom Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 6;
				width = 14;
				height = 28;
				value = 200;
				break;
			case 819:
				name = "Living Wood Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 7;
				width = 14;
				height = 28;
				value = 200;
				break;
			case 820:
				name = "Bone Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 8;
				width = 14;
				height = 28;
				value = 200;
				break;
			case 821:
				name = "Flame Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 9;
				break;
			case 822:
				name = "Frozen Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 10;
				break;
			case 823:
				name = "Ghost Wings";
				color = new Color(255, 255, 255, 0);
				alpha = 255;
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 7;
				wingSlot = 11;
				break;
			case 824:
				name = "Sunplate Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 202;
				width = 12;
				height = 12;
				break;
			case 825:
				name = "Disc Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 82;
				width = 12;
				height = 12;
				break;
			case 826:
				name = "Skyware Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 10;
				width = 12;
				height = 30;
				break;
			case 827:
				name = "Bone Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 4;
				width = 26;
				height = 20;
				value = 300;
				break;
			case 828:
				name = "Flesh Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 5;
				width = 26;
				height = 20;
				value = 300;
				break;
			case 829:
				name = "Living Wood Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 6;
				width = 26;
				height = 20;
				value = 300;
				break;
			case 830:
				name = "Skyware Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 7;
				width = 26;
				height = 20;
				value = 300;
				break;
			case 831:
				name = "Living Wood Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 12;
				width = 26;
				height = 22;
				value = 5000;
				break;
			case 832:
				name = "Living Wood Wand";
				tileWand = 9;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				createTile = 191;
				width = 8;
				height = 10;
				rare = 1;
				toolTip = "Places living wood";
				break;
			case 833:
				name = "Purple Ice Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 163;
				width = 12;
				height = 12;
				break;
			case 834:
				name = "Pink Ice Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 164;
				width = 12;
				height = 12;
				break;
			case 835:
				name = "Red Ice Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 200;
				width = 12;
				height = 12;
				break;
			case 836:
				name = "Crimstone";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 203;
				width = 12;
				height = 12;
				break;
			case 837:
				name = "Skyware Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 9;
				width = 14;
				height = 28;
				value = 200;
				break;
			case 838:
				name = "Skyware Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 13;
				width = 26;
				height = 22;
				value = 5000;
				break;
			case 839:
				name = "Steampunk Hat";
				width = 28;
				height = 20;
				headSlot = 59;
				rare = 2;
				vanity = true;
				value = buyPrice(0, 1, 50);
				break;
			case 840:
				name = "Steampunk Shirt";
				width = 18;
				height = 14;
				bodySlot = 39;
				rare = 2;
				vanity = true;
				value = buyPrice(0, 1, 50);
				break;
			case 841:
				name = "Steampunk Pants";
				width = 18;
				height = 14;
				legSlot = 37;
				rare = 2;
				vanity = true;
				value = buyPrice(0, 1, 50);
				break;
			case 842:
				name = "Bee Hat";
				width = 28;
				height = 20;
				headSlot = 60;
				rare = 1;
				vanity = true;
				break;
			case 843:
				name = "Bee Shirt";
				width = 18;
				height = 14;
				bodySlot = 40;
				rare = 1;
				vanity = true;
				break;
			case 844:
				name = "Bee Pants";
				width = 18;
				height = 14;
				legSlot = 38;
				rare = 1;
				vanity = true;
				break;
			case 845:
				name = "World Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 7;
				width = 10;
				height = 24;
				value = 5000;
				break;
			case 846:
				name = "Sun Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 8;
				width = 10;
				height = 24;
				value = 5000;
				break;
			case 847:
				name = "Gravity Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 9;
				width = 10;
				height = 24;
				value = 5000;
				break;
			case 848:
				name = "Pharaoh's Mask";
				width = 28;
				height = 20;
				headSlot = 61;
				rare = 1;
				vanity = true;
				break;
			case 849:
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				name = "Actuator";
				width = 24;
				height = 28;
				toolTip = "Enables solid blocks to be toggled on and off";
				maxStack = 999;
				mech = true;
				value = buyPrice(0, 0, 10);
				break;
			case 850:
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				name = "Blue Wrench";
				width = 24;
				height = 28;
				rare = 1;
				toolTip = "Places blue wire";
				value = 20000;
				mech = true;
				tileBoost = 3;
				break;
			case 851:
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				name = "Green Wrench";
				width = 24;
				height = 28;
				rare = 1;
				toolTip = "Places green wire";
				value = 20000;
				mech = true;
				tileBoost = 3;
				break;
			case 852:
				name = "Blue Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 4;
				mech = true;
				value = 5000;
				toolTip = "Activates when a player steps on it on";
				break;
			case 853:
				name = "Yellow Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 5;
				mech = true;
				value = 5000;
				toolTip = "Activates when anything but a player steps on it on";
				break;
			case 854:
				name = "Discount Card";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Shops have lower prices";
				value = 50000;
				break;
			case 855:
				name = "Lucky Coin";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Hitting enemies will sometimes drop extra coins";
				value = 50000;
				break;
			case 856:
				noWet = true;
				name = "Stick Unicorn";
				holdStyle = 1;
				width = 30;
				height = 30;
				toolTip = "'Having a wonderful time!'";
				value = 500;
				rare = 2;
				break;
			case 857:
				name = "Sandstorm in a Bottle";
				width = 16;
				height = 24;
				accessory = true;
				rare = 2;
				toolTip = "Allows the holder to double jump";
				value = 50000;
				break;
			case 858:
				name = "Boreal Wood Sofa";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 89;
				placeStyle = 24;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 859:
				useStyle = 1;
				name = "Beach Ball";
				shootSpeed = 6f;
				shoot = 155;
				width = 44;
				height = 44;
				consumable = true;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				noUseGraphic = true;
				noMelee = true;
				value = 20;
				break;
			case 860:
				name = "Charm of Myths";
				width = 16;
				height = 24;
				accessory = true;
				rare = 6;
				lifeRegen = 1;
				toolTip = "Provides life regeneration and reduces the cooldown of healing potions";
				value = 500000;
				handOnSlot = 4;
				break;
			case 861:
				name = "Moon Shell";
				width = 16;
				height = 24;
				accessory = true;
				rare = 6;
				toolTip = "Turns the holder into a werewolf on full moons and a merfolk when entering water";
				value = 500000;
				break;
			case 862:
				name = "Star Veil";
				width = 16;
				height = 24;
				accessory = true;
				rare = 6;
				toolTip = "Causes stars to fall and increases length of invincibility after taking damage";
				value = 500000;
				neckSlot = 5;
				break;
			case 863:
				name = "Water Walking Boots";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Provides the ability to walk on water";
				value = 200000;
				shoeSlot = 2;
				break;
			case 864:
				name = "Tiara";
				width = 28;
				height = 20;
				headSlot = 62;
				rare = 1;
				vanity = true;
				value = buyPrice(0, 25);
				break;
			case 865:
				name = "Princess Dress";
				width = 18;
				height = 14;
				bodySlot = 41;
				rare = 1;
				vanity = true;
				value = buyPrice(0, 10);
				break;
			case 866:
				name = "Pharaoh's Robe";
				width = 18;
				height = 14;
				bodySlot = 42;
				rare = 1;
				vanity = true;
				break;
			case 867:
				name = "Green Cap";
				width = 28;
				height = 20;
				headSlot = 63;
				rare = 1;
				vanity = true;
				break;
			case 868:
				name = "Mushroom Cap";
				width = 28;
				height = 20;
				headSlot = 64;
				rare = 1;
				vanity = true;
				value = buyPrice(0, 2);
				break;
			case 869:
				name = "Tam O' Shanter";
				width = 28;
				height = 20;
				headSlot = 65;
				rare = 1;
				vanity = true;
				value = buyPrice(0, 2, 50);
				break;
			case 870:
				name = "Mummy Mask";
				width = 28;
				height = 20;
				headSlot = 66;
				rare = 1;
				vanity = true;
				break;
			case 871:
				name = "Mummy Shirt";
				width = 28;
				height = 20;
				bodySlot = 43;
				rare = 1;
				vanity = true;
				break;
			case 872:
				name = "Mummy Pants";
				width = 28;
				height = 20;
				legSlot = 39;
				rare = 1;
				vanity = true;
				break;
			case 873:
				name = "Cowboy Hat";
				width = 28;
				height = 20;
				headSlot = 67;
				rare = 1;
				vanity = true;
				value = buyPrice(0, 5);
				break;
			case 874:
				name = "Cowboy Jacket";
				width = 28;
				height = 20;
				bodySlot = 44;
				rare = 1;
				vanity = true;
				value = buyPrice(0, 5);
				break;
			case 875:
				name = "Cowboy Pants";
				width = 28;
				height = 20;
				legSlot = 40;
				rare = 1;
				vanity = true;
				value = buyPrice(0, 5);
				break;
			case 876:
				name = "Pirate Hat";
				width = 28;
				height = 20;
				headSlot = 68;
				rare = 1;
				vanity = true;
				value = buyPrice(0, 5);
				break;
			case 877:
				name = "Pirate Shirt";
				width = 28;
				height = 20;
				bodySlot = 45;
				rare = 1;
				vanity = true;
				value = buyPrice(0, 5);
				break;
			case 878:
				name = "Pirate Pants";
				width = 28;
				height = 20;
				legSlot = 41;
				rare = 1;
				vanity = true;
				value = buyPrice(0, 5);
				break;
			case 879:
				name = "Viking Helmet";
				width = 28;
				height = 20;
				headSlot = 69;
				rare = 1;
				defense = 4;
				value = sellPrice(0, 0, 50);
				break;
			case 880:
				name = "Crimtane";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 204;
				width = 12;
				height = 12;
				rare = 1;
				value = 4500;
				break;
			case 881:
				name = "Cactus Sword";
				useStyle = 1;
				useTurn = false;
				useAnimation = 25;
				useTime = 25;
				width = 24;
				height = 28;
				damage = 9;
				knockBack = 5f;
				useSound = 1;
				scale = 1f;
				value = 1800;
				melee = true;
				break;
			case 882:
				name = "Cactus Pickaxe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 23;
				useTime = 15;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 5;
				pick = 35;
				useSound = 1;
				knockBack = 2f;
				value = 2000;
				melee = true;
				break;
			case 883:
				name = "Ice Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 206;
				width = 12;
				height = 12;
				break;
			case 884:
				name = "Ice Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 84;
				width = 12;
				height = 12;
				break;
			case 885:
				name = "Adhesive Bandage";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Bleeding";
				value = 100000;
				break;
			case 886:
				name = "Armor Polish";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Broken Armor";
				value = 100000;
				break;
			case 887:
				name = "Bezoar";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Poison";
				value = 100000;
				break;
			case 888:
				name = "Blindfold";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Darkness";
				value = 100000;
				faceSlot = 5;
				break;
			case 889:
				name = "Fast Clock";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Slow";
				value = 100000;
				break;
			case 890:
				name = "Megaphone";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Silence";
				value = 100000;
				break;
			case 891:
				name = "Nazar";
				width = 16;
				height = 24;
				accessory = true;
				rare = 2;
				toolTip = "Immunity to Curse";
				value = 100000;
				break;
			case 892:
				name = "Vitamins";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Weakness";
				value = 100000;
				break;
			case 893:
				name = "Trifold Map";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Immunity to Confusion";
				value = 100000;
				break;
			case 894:
				name = "Cactus Helmet";
				width = 18;
				height = 18;
				defense = 1;
				headSlot = 70;
				break;
			case 895:
				name = "Cactus Breastplate";
				width = 18;
				height = 18;
				defense = 2;
				bodySlot = 46;
				break;
			case 896:
				name = "Cactus Leggings";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 42;
				break;
			case 897:
				name = "Power Glove";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Increases melee knockback";
				toolTip = "12% increased melee speed";
				value = 300000;
				handOffSlot = 5;
				handOnSlot = 10;
				break;
			case 898:
				name = "Lightning Boots";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Allows flight and super fast running";
				toolTip = "7% increased movement speed";
				value = 300000;
				shoeSlot = 10;
				break;
			case 899:
				name = "Sun Stone";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Increases all stats if worn during the day";
				value = 300000;
				handOnSlot = 13;
				break;
			case 900:
				name = "Moon Stone";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Increases all stats if worn during the night";
				value = 300000;
				handOnSlot = 14;
				break;
			case 901:
				name = "Armor Bracing";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Immunity to Weakness and Broken Armor";
				value = 100000;
				break;
			case 902:
				name = "Medicated Bandage";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Immunity to Poison and Bleeding";
				value = 100000;
				break;
			case 903:
				name = "The Plan";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Immunity to Slow and Confusion";
				value = 100000;
				break;
			case 904:
				name = "Countercurse Mantra";
				width = 16;
				height = 24;
				accessory = true;
				rare = 5;
				toolTip = "Immunity to Silence and Curse";
				value = 100000;
				break;
			case 905:
				name = "Coin Gun";
				useStyle = 5;
				autoReuse = true;
				useAnimation = 8;
				useTime = 8;
				width = 50;
				height = 18;
				shoot = 158;
				useAmmo = 71;
				useSound = 11;
				damage = 0;
				shootSpeed = 10f;
				noMelee = true;
				value = 300000;
				rare = 6;
				toolTip = "Uses coins for ammo";
				toolTip2 = "Higher valued coins do more damage";
				knockBack = 2f;
				ranged = true;
				break;
			case 906:
				name = "Lava Charm";
				width = 16;
				height = 24;
				accessory = true;
				rare = 3;
				toolTip = "Provides 7 seconds of immunity to lava";
				value = 300000;
				break;
			case 907:
				name = "Obsidian Water Walking Boots";
				width = 16;
				height = 24;
				accessory = true;
				rare = 4;
				toolTip = "Provides the ability to walk on water";
				toolTip = "Grants immunity to fire blocks";
				value = 500000;
				shoeSlot = 11;
				break;
			case 908:
				name = "Lava Waders";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Provides the ability to walk on water and lava";
				toolTip = "Grants immunity to fire blocks and 7 seconds of immunity to lava";
				value = 500000;
				shoeSlot = 8;
				break;
			case 909:
				name = "Pure Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 0;
				width = 26;
				height = 36;
				break;
			case 910:
				name = "Desert Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 1;
				width = 26;
				height = 36;
				break;
			case 911:
				name = "Shadewood";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 208;
				width = 8;
				height = 10;
				break;
			case 912:
				name = "Shadewood Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 10;
				width = 14;
				height = 28;
				value = 200;
				break;
			case 913:
				name = "Shadewood Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 5;
				width = 8;
				height = 10;
				break;
			case 914:
				name = "Shadewood Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 14;
				width = 26;
				height = 22;
				value = 500;
				break;
			case 915:
				name = "Shadewood Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 11;
				width = 12;
				height = 30;
				break;
			case 916:
				name = "Shadewood Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 9;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				break;
			case 917:
				name = "Shadewood Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 8;
				width = 26;
				height = 20;
				value = 300;
				break;
			case 918:
				name = "Shadewood Dresser";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 88;
				placeStyle = 4;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 919:
				name = "Shadewood Piano";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 87;
				placeStyle = 4;
				width = 20;
				height = 20;
				value = 300;
				break;
			case 920:
				name = "Shadewood Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 4;
				width = 28;
				height = 20;
				value = 2000;
				break;
			case 921:
				name = "Shadewood Sword";
				useStyle = 1;
				useTurn = false;
				useAnimation = 21;
				useTime = 21;
				width = 24;
				height = 28;
				damage = 10;
				knockBack = 5f;
				useSound = 1;
				scale = 1f;
				value = 100;
				melee = true;
				break;
			case 922:
				name = "Shadewood Hammer";
				autoReuse = true;
				useStyle = 1;
				useTurn = true;
				useAnimation = 30;
				useTime = 20;
				hammer = 40;
				width = 24;
				height = 28;
				damage = 7;
				knockBack = 5.5f;
				scale = 1.2f;
				useSound = 1;
				value = 50;
				melee = true;
				break;
			case 923:
				name = "Shadewood Bow";
				useStyle = 5;
				useAnimation = 28;
				useTime = 28;
				width = 12;
				height = 28;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 8;
				shootSpeed = 6.6f;
				noMelee = true;
				value = 100;
				ranged = true;
				break;
			case 924:
				name = "Shadewood Helmet";
				width = 18;
				height = 18;
				defense = 1;
				headSlot = 71;
				break;
			case 925:
				name = "Shadewood Breastplate";
				width = 18;
				height = 18;
				defense = 2;
				bodySlot = 47;
				break;
			case 926:
				name = "Shadewood Greaves";
				width = 18;
				height = 18;
				defense = 1;
				legSlot = 43;
				break;
			case 927:
				name = "Shadewood Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 85;
				width = 12;
				height = 12;
				break;
			case 928:
				name = "Cannon";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 209;
				width = 12;
				height = 12;
				rare = 3;
				value = buyPrice(0, 25);
				break;
			case 929:
				name = "Cannonball";
				useStyle = 1;
				useTurn = true;
				useAnimation = 20;
				useTime = 20;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				damage = 300;
				noMelee = true;
				value = buyPrice(0, 0, 15);
				break;
			case 930:
				useStyle = 5;
				useAnimation = 18;
				useTime = 18;
				name = "Flare Gun";
				width = 24;
				height = 28;
				shoot = 163;
				useAmmo = 931;
				useSound = 11;
				damage = 2;
				shootSpeed = 6f;
				noMelee = true;
				value = 50000;
				scale = 0.9f;
				rare = 1;
				holdStyle = 1;
				break;
			case 931:
				name = "Flare";
				shootSpeed = 6f;
				shoot = 163;
				damage = 1;
				width = 12;
				height = 12;
				maxStack = 999;
				consumable = true;
				ammo = 931;
				knockBack = 1.5f;
				value = 7;
				ranged = true;
				break;
			case 932:
				name = "Bone Wand";
				tileWand = 154;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				createTile = 194;
				width = 8;
				height = 10;
				rare = 1;
				toolTip = "Places bone";
				break;
			case 933:
				name = "Leaf Wand";
				tileWand = 9;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				createTile = 192;
				width = 8;
				height = 10;
				rare = 1;
				toolTip = "Places leaves";
				break;
			case 934:
				name = "Flying Carpet";
				width = 34;
				height = 12;
				accessory = true;
				rare = 2;
				toolTip = "Allows the owner to float for a few seconds";
				value = 50000;
				break;
			case 935:
				name = "Avenger Emblem";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "12% increased damage";
				value = 300000;
				rare = 5;
				break;
			case 936:
				name = "Mechanical Glove";
				width = 24;
				height = 24;
				accessory = true;
				rare = 6;
				toolTip = "Increases melee knockback";
				toolTip = "12% increased melee damage and melee speed";
				value = 300000;
				handOffSlot = 4;
				handOnSlot = 9;
				break;
			case 937:
				name = "Land Mine";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 210;
				width = 12;
				height = 12;
				placeStyle = 0;
				mech = true;
				value = 50000;
				mech = true;
				toolTip = "Explodes when stepped on";
				break;
			case 938:
				name = "Paladin's Shield";
				width = 24;
				height = 24;
				accessory = true;
				rare = 8;
				defense = 6;
				toolTip = "Absorbs 25% of damage done to players on your team when above 25% life";
				toolTip = "Grants immunity to knockback";
				value = 300000;
				shieldSlot = 2;
				break;
			case 939:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Web Slinger";
				shootSpeed = 10f;
				shoot = 165;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 2;
				noMelee = true;
				value = 20000;
				break;
			case 940:
				name = "Jungle Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 2;
				width = 26;
				height = 36;
				break;
			case 941:
				name = "Icy Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 3;
				width = 26;
				height = 36;
				break;
			case 942:
				name = "Corrupt Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 4;
				width = 26;
				height = 36;
				break;
			case 943:
				name = "Crimson Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 5;
				width = 26;
				height = 36;
				break;
			case 944:
				name = "Hallowed Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 6;
				width = 26;
				height = 36;
				break;
			case 945:
				name = "Blood Water Fountain";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 207;
				placeStyle = 7;
				width = 26;
				height = 36;
				break;
			case 946:
				name = "Umbrella";
				width = 44;
				height = 44;
				rare = 1;
				value = 10000;
				holdStyle = 2;
				toolTip = "You will fall slower while holding this";
				break;
			case 947:
				name = "Chlorophyte Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 211;
				width = 12;
				height = 12;
				rare = 7;
				value = 250;
				toolTip = "Reacts to the light";
				break;
			case 948:
				name = "Steampunk Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 8;
				wingSlot = 12;
				break;
			case 949:
				useStyle = 1;
				name = "Snowball";
				shootSpeed = 7f;
				shoot = 166;
				ammo = 949;
				damage = 4;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				useSound = 1;
				useAnimation = 19;
				useTime = 19;
				noUseGraphic = true;
				noMelee = true;
				ranged = true;
				knockBack = 4.5f;
				break;
			case 950:
				name = "Ice Skates";
				width = 16;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "Provides extra mobility on ice";
				value = 50000;
				shoeSlot = 7;
				break;
			case 951:
				name = "Snowball Launcher";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 212;
				width = 20;
				height = 20;
				value = 50000;
				rare = 2;
				toolTip = "Rapidly launches snowballs";
				break;
			case 952:
				name = "Web Covered Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 15;
				width = 26;
				height = 22;
				value = 500;
				break;
			case 953:
				name = "Climbing Claws";
				width = 16;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "Allows the ability to slide down walls";
				toolTip = "Improved ability if combined with Shoe Spikes";
				value = 50000;
				handOnSlot = 11;
				handOffSlot = 6;
				break;
			case 954:
				name = "Ancient Iron Helmet";
				width = 18;
				height = 18;
				defense = 2;
				headSlot = 72;
				value = 5000;
				break;
			case 955:
				name = "Ancient Gold Helmet";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 73;
				value = 25000;
				break;
			case 956:
				name = "Ancient Shadow Helmet";
				width = 18;
				height = 18;
				defense = 6;
				headSlot = 74;
				rare = 1;
				value = 37500;
				toolTip = "7% increased melee speed";
				break;
			case 957:
				name = "Ancient Shadow Scalemail";
				width = 18;
				height = 18;
				defense = 7;
				bodySlot = 48;
				rare = 1;
				value = 30000;
				toolTip = "7% increased melee speed";
				break;
			case 958:
				name = "Ancient Shadow Greaves";
				width = 18;
				height = 18;
				defense = 6;
				legSlot = 44;
				rare = 1;
				value = 22500;
				toolTip = "7% increased melee speed";
				break;
			case 959:
				name = "Ancient Necro Helmet";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 75;
				rare = 2;
				value = 45000;
				toolTip = "4% increased ranged damage.";
				break;
			case 960:
				name = "Ancient Cobalt Helmet";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 76;
				rare = 3;
				value = 45000;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "3% increased magic critical strike chance";
				break;
			case 961:
				name = "Ancient Cobalt Breastplate";
				width = 18;
				height = 18;
				defense = 5;
				bodySlot = 49;
				rare = 3;
				value = 30000;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "3% increased magic critical strike chance";
				break;
			case 962:
				name = "Ancient Cobalt Leggings";
				width = 18;
				height = 18;
				defense = 5;
				legSlot = 45;
				rare = 3;
				value = 30000;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "3% increased magic critical strike chance";
				break;
			case 963:
				name = "Black Belt";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Gives a chance to dodge attacks";
				value = 50000;
				waistSlot = 10;
				break;
			case 964:
				knockBack = 5.5f;
				useStyle = 5;
				useAnimation = 42;
				useTime = 42;
				name = "Boomstick";
				width = 50;
				height = 14;
				shoot = 10;
				useAmmo = 14;
				useSound = 36;
				damage = 12;
				shootSpeed = 5.25f;
				noMelee = true;
				value = sellPrice(0, 2);
				rare = 2;
				ranged = true;
				toolTip = "Fires a spread of bullets";
				break;
			case 965:
				name = "Rope";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 8;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 213;
				width = 12;
				height = 12;
				value = 10;
				tileBoost += 2;
				toolTip = "Can be climbed on";
				break;
			case 966:
				name = "Campfire";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 215;
				width = 12;
				height = 12;
				toolTip = "Life regen is increased when near a campfire";
				break;
			case 967:
				name = "Marshmellow";
				width = 12;
				height = 12;
				maxStack = 99;
				value = 100;
				break;
			case 968:
				name = "Marshmellow on a Stick";
				holdStyle = 1;
				width = 12;
				height = 12;
				value = 200;
				break;
			case 969:
				name = "Cooked Marshmellow";
				useSound = 2;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 12;
				height = 12;
				buffType = 26;
				buffTime = 36000;
				rare = 1;
				toolTip = "Minor improvements to all stats";
				value = 1000;
				value = 1000;
				break;
			case 970:
				name = "Red Rocket";
				createTile = 216;
				placeStyle = 0;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				width = 12;
				height = 30;
				value = 1500;
				mech = true;
				break;
			case 971:
				name = "Green Rocket";
				createTile = 216;
				placeStyle = 1;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				width = 12;
				height = 30;
				value = 1500;
				mech = true;
				break;
			case 972:
				name = "Blue Rocket";
				createTile = 216;
				placeStyle = 2;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				width = 12;
				height = 30;
				value = 1500;
				mech = true;
				break;
			case 973:
				name = "Yellow Rocket";
				createTile = 216;
				placeStyle = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				width = 12;
				height = 30;
				value = 1500;
				mech = true;
				break;
			case 974:
				flame = true;
				name = "Ice Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 9;
				width = 10;
				height = 12;
				value = 60;
				noWet = true;
				break;
			case 975:
				name = "Shoe Spikes";
				width = 16;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "Allows the ability to slide down walls";
				toolTip = "Improved ability if combined with Climbing Claws";
				value = 50000;
				shoeSlot = 4;
				break;
			case 976:
				name = "Tiger Climbing Gear";
				width = 16;
				height = 24;
				accessory = true;
				rare = 2;
				toolTip = "Allows the ability to climb walls";
				value = 50000;
				shoeSlot = 4;
				handOnSlot = 11;
				handOffSlot = 6;
				break;
			case 977:
				name = "Tabi";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Allows the ability to dash";
				toolTip = "Double tap a direction";
				value = 50000;
				shoeSlot = 3;
				break;
			case 978:
				name = "Pink Eskimo Hood";
				width = 18;
				height = 18;
				headSlot = 77;
				value = 50000;
				defense = 1;
				break;
			case 979:
				name = "Pink Eskimo Coat";
				width = 18;
				height = 18;
				bodySlot = 50;
				value = 40000;
				defense = 2;
				break;
			case 980:
				name = "Pink Eskimo Pants";
				width = 18;
				height = 18;
				legSlot = 46;
				value = 30000;
				defense = 1;
				break;
			case 981:
				name = "Pink Thread";
				maxStack = 99;
				width = 12;
				height = 20;
				value = 10000;
				break;
			case 982:
				name = "Mana Regeneration Band";
				width = 22;
				height = 22;
				accessory = true;
				rare = 1;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "Increases mana regeneration rate";
				value = 50000;
				handOnSlot = 1;
				break;
			case 983:
				name = "Sandstorm in a Balloon";
				width = 14;
				height = 28;
				rare = 4;
				value = 150000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip2 = "Increases jump height";
				balloonSlot = 6;
				break;
			case 984:
				name = "Master Ninja Gear";
				width = 16;
				height = 24;
				accessory = true;
				rare = 8;
				toolTip = "Allows the ability to climb walls and dash";
				toolTip2 = "Gives a chance to dodge attacks";
				value = 500000;
				handOnSlot = 11;
				handOffSlot = 6;
				shoeSlot = 14;
				waistSlot = 10;
				break;
			case 985:
				useStyle = 1;
				name = "Rope Coil";
				shootSpeed = 10f;
				shoot = 171;
				damage = 0;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				noUseGraphic = true;
				noMelee = true;
				value = 100;
				toolTip = "Throw to create a climbable line of rope";
				break;
			case 986:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 35;
				useTime = 35;
				name = "Blowgun";
				width = 38;
				height = 6;
				shoot = 10;
				useAmmo = 51;
				useSound = 5;
				damage = 25;
				shootSpeed = 13f;
				noMelee = true;
				value = buyPrice(0, 5);
				knockBack = 4f;
				useAmmo = 51;
				toolTip = "Allows the collection of seeds for ammo";
				ranged = true;
				rare = 3;
				break;
			case 987:
				name = "Blizzard in a Bottle";
				width = 16;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "Allows the holder to double jump";
				value = 50000;
				break;
			case 988:
				name = "Frostburn Arrow";
				shootSpeed = 3.75f;
				shoot = 172;
				damage = 7;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = 1;
				knockBack = 2.2f;
				value = 15;
				ranged = true;
				break;
			case 989:
				rare = 2;
				useSound = 1;
				name = "Enchanted Sword";
				useStyle = 1;
				damage = 18;
				useAnimation = 19;
				useTime = 60;
				scale = 1.1f;
				width = 30;
				height = 30;
				shoot = 173;
				shootSpeed = 9f;
				knockBack = 5f;
				toolTip = "Shoots an echanted beam";
				melee = true;
				value = 20000;
				break;
			case 990:
				useTurn = true;
				autoReuse = true;
				name = "Pickaxe Axe";
				useStyle = 1;
				useAnimation = 25;
				useTime = 7;
				knockBack = 4.75f;
				width = 20;
				height = 12;
				damage = 35;
				pick = 200;
				axe = 22;
				useSound = 1;
				rare = 4;
				value = 220000;
				melee = true;
				scale = 1.1f;
				toolTip = "'Not to be confused with a hamdrill'";
				break;
			case 991:
				useTurn = true;
				autoReuse = true;
				name = "Cobalt Waraxe";
				useStyle = 1;
				useAnimation = 35;
				useTime = 8;
				knockBack = 5f;
				width = 20;
				height = 12;
				damage = 33;
				axe = 14;
				useSound = 1;
				rare = 4;
				value = 54000;
				melee = true;
				scale = 1.1f;
				break;
			case 992:
				useTurn = true;
				autoReuse = true;
				name = "Mythril Waraxe";
				useStyle = 1;
				useAnimation = 35;
				useTime = 8;
				knockBack = 6f;
				width = 20;
				height = 12;
				damage = 39;
				axe = 17;
				useSound = 1;
				rare = 4;
				value = 81000;
				melee = true;
				scale = 1.1f;
				break;
			case 993:
				useTurn = true;
				autoReuse = true;
				name = "Adamantite Waraxe";
				useStyle = 1;
				useAnimation = 35;
				useTime = 6;
				knockBack = 7f;
				width = 20;
				height = 12;
				damage = 43;
				axe = 20;
				useSound = 1;
				rare = 4;
				value = 108000;
				melee = true;
				scale = 1.1f;
				break;
			case 994:
				damage = 0;
				useStyle = 1;
				name = "Eater's Bone";
				shoot = 175;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Baby Eater of Souls";
				value = 0;
				buffType = 45;
				break;
			case 995:
				name = "Blend-O-Matic";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 217;
				width = 26;
				height = 20;
				value = 100000;
				toolTip = "Used to craft objects";
				break;
			case 996:
				name = "Meat Grinder";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 218;
				width = 26;
				height = 20;
				value = 100000;
				toolTip = "Used to craft objects";
				break;
			case 997:
				name = "Silt Extractinator";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 219;
				width = 26;
				height = 20;
				value = 100000;
				toolTip = "Turns silt into something more useful";
				toolTip2 = "'To use: Place silt in the extractinator'";
				break;
			case 998:
				name = "Solidifier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 220;
				width = 26;
				height = 20;
				value = 100000;
				toolTip = "Used to craft objects";
				break;
			case 999:
				name = "Amber";
				createTile = 178;
				placeStyle = 6;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				alpha = 50;
				width = 10;
				height = 14;
				value = 15000;
				break;
			case 1000:
				useStyle = 5;
				name = "Confetti Gun";
				shootSpeed = 10f;
				shoot = 178;
				damage = 0;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				useSound = 11;
				useAnimation = 15;
				useTime = 15;
				noMelee = true;
				value = 100;
				ranged = true;
				break;
			}
		}

		public void SetDefaults2(int type)
		{
			switch (type)
			{
			case 1001:
				name = "Chlorophyte Mask";
				width = 18;
				height = 18;
				defense = 25;
				headSlot = 78;
				rare = 7;
				value = 300000;
				toolTip = "16% increased melee damage";
				toolTip2 = "6% increased melee critical strike chance";
				return;
			case 1002:
				name = "Chlorophyte Helmet";
				width = 18;
				height = 18;
				defense = 13;
				headSlot = 79;
				rare = 7;
				value = 300000;
				toolTip = "16% increased ranged damage";
				toolTip2 = "20% chance to not consume ammo";
				return;
			case 1003:
				name = "Chlorophyte Headgear";
				width = 18;
				height = 18;
				defense = 7;
				headSlot = 80;
				rare = 7;
				value = 300000;
				toolTip = "Increases maximum mana by 80 and reduces mana usage by 17%";
				toolTip2 = "16% increased magic damage";
				return;
			case 1004:
				name = "Chlorophyte Plate Mail";
				width = 18;
				height = 18;
				defense = 18;
				bodySlot = 51;
				rare = 7;
				value = 240000;
				toolTip = "5% increased damage";
				toolTip = "7% increased critical strike chance";
				return;
			case 1005:
				name = "Chlorophyte Greaves";
				width = 18;
				height = 18;
				defense = 13;
				legSlot = 47;
				rare = 7;
				value = 180000;
				toolTip = "8% increased critical strike chance";
				toolTip = "5% increased movement speed";
				return;
			case 1006:
				name = "Chlorophyte Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = sellPrice(0, 0, 90);
				rare = 7;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 17;
				return;
			case 1007:
				name = "Red Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 1;
				return;
			case 1008:
				name = "Orange Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 2;
				return;
			case 1009:
				name = "Yellow Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 3;
				return;
			case 1010:
				name = "Lime Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 4;
				return;
			case 1011:
				name = "Green Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 5;
				return;
			case 1012:
				name = "Teal Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 6;
				return;
			case 1013:
				name = "Cyan Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 7;
				return;
			case 1014:
				name = "Sky Blue Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 8;
				return;
			case 1015:
				name = "Blue Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 9;
				return;
			case 1016:
				name = "Purple Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 10;
				return;
			case 1017:
				name = "Violet Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 11;
				return;
			case 1018:
				name = "Pink Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 12;
				return;
			case 1019:
				name = "Red and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 13;
				return;
			case 1020:
				name = "Orange and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 14;
				return;
			case 1021:
				name = "Yellow and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 15;
				return;
			case 1022:
				name = "Lime and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 16;
				return;
			case 1023:
				name = "Green and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 17;
				return;
			case 1024:
				name = "Teal and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 18;
				return;
			case 1025:
				name = "Cyan and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 19;
				return;
			case 1026:
				name = "Sky Blue and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 20;
				return;
			case 1027:
				name = "Blue and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 21;
				return;
			case 1028:
				name = "Purple and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 22;
				return;
			case 1029:
				name = "Violet and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 23;
				return;
			case 1030:
				name = "Pink and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 24;
				return;
			case 1031:
				name = "Flame Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 25;
				return;
			case 1032:
				name = "Flame and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 26;
				return;
			case 1033:
				name = "Green Flame Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 27;
				return;
			case 1034:
				name = "Green Flame and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 28;
				return;
			case 1035:
				name = "Blue Flame Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 29;
				return;
			case 1036:
				name = "Blue Flame and Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 30;
				return;
			case 1037:
				name = "Silver Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 31;
				return;
			case 1038:
				name = "Bright Red Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 32;
				return;
			case 1039:
				name = "Bright Orange Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 33;
				return;
			case 1040:
				name = "Bright Yellow Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 34;
				return;
			case 1041:
				name = "Bright Lime Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 35;
				return;
			case 1042:
				name = "Bright Green Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 36;
				return;
			case 1043:
				name = "Bright Teal Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 37;
				return;
			case 1044:
				name = "Bright Cyan Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 38;
				return;
			case 1045:
				name = "Bright Sky Blue Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 39;
				return;
			case 1046:
				name = "Bright Blue Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 40;
				return;
			case 1047:
				name = "Bright Purple Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 41;
				return;
			case 1048:
				name = "Bright Violet Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 42;
				return;
			case 1049:
				name = "Bright Pink Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 43;
				return;
			case 1050:
				name = "Black Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 44;
				return;
			case 1051:
				name = "Red and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 45;
				return;
			case 1052:
				name = "Orange and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 46;
				return;
			case 1053:
				name = "Yellow and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 47;
				return;
			case 1054:
				name = "Lime and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 48;
				return;
			case 1055:
				name = "Green and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 49;
				return;
			case 1056:
				name = "Teal and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 50;
				return;
			case 1057:
				name = "Cyan and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 51;
				return;
			case 1058:
				name = "Sky Blue and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 52;
				return;
			case 1059:
				name = "Blue and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 53;
				return;
			case 1060:
				name = "Purple and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 54;
				return;
			case 1061:
				name = "Violet and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 55;
				return;
			case 1062:
				name = "Pink and Silver Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 56;
				return;
			case 1063:
				name = "Intense Flame Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 57;
				return;
			case 1064:
				name = "Intense Green Flame Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 58;
				return;
			case 1065:
				name = "Intense Blue Flame Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 59;
				return;
			case 1066:
				name = "Rainbow Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 60;
				return;
			case 1067:
				name = "Intense Rainbow Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 61;
				return;
			case 1068:
				name = "Yellow Gradient Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 62;
				return;
			case 1069:
				name = "Cyan Gradient Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 63;
				return;
			case 1070:
				name = "Violet Gradient Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 64;
				return;
			case 1071:
				name = "Paintbrush";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				width = 24;
				height = 24;
				toolTip = "Used with paint to color blocks";
				value = 10000;
				return;
			case 1072:
				name = "Paint Roller";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				width = 24;
				height = 24;
				toolTip = "Used with paint to color walls";
				value = 10000;
				return;
			case 1073:
				name = "Red Paint";
				paint = 1;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1074:
				name = "Orange Paint";
				paint = 2;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1075:
				name = "Yellow Paint";
				paint = 3;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1076:
				name = "Lime Paint";
				paint = 4;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1077:
				name = "Green Paint";
				paint = 5;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1078:
				name = "Teal Paint";
				paint = 6;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1079:
				name = "Cyan Paint";
				paint = 7;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1080:
				name = "Sky Blue Paint";
				paint = 8;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1081:
				name = "Blue Paint";
				paint = 9;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1082:
				name = "Purple Paint";
				paint = 10;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1083:
				name = "Violet Paint";
				paint = 11;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1084:
				name = "Pink Paint";
				paint = 12;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1085:
				name = "Deep Red Paint";
				paint = 13;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1086:
				name = "Deep Orange Paint";
				paint = 14;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1087:
				name = "Deep Yellow Paint";
				paint = 15;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1088:
				name = "Deep Lime Paint";
				paint = 16;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1089:
				name = "Deep Green Paint";
				paint = 17;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1090:
				name = "Deep Teal Paint";
				paint = 18;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1091:
				name = "Deep Cyan Paint";
				paint = 19;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1092:
				name = "Deep Sky Blue Paint";
				paint = 20;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1093:
				name = "Deep Blue Paint";
				paint = 21;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1094:
				name = "Deep Purple Paint";
				paint = 22;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1095:
				name = "Deep Violet Paint";
				paint = 23;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1096:
				name = "Deep Pink Paint";
				paint = 24;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1097:
				name = "Black Paint";
				paint = 25;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1098:
				name = "White Paint";
				paint = 26;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1099:
				name = "Grey Paint";
				paint = 27;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1100:
				name = "Paint Scraper";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				width = 24;
				height = 24;
				toolTip = "Used to remove paint";
				value = 10000;
				return;
			case 1101:
				name = "Lihzahrd Brick";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 226;
				width = 12;
				height = 12;
				return;
			case 1102:
				name = "Lihzahrd Brick Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 112;
				width = 12;
				height = 12;
				return;
			case 1103:
				name = "Slush Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 224;
				width = 12;
				height = 12;
				return;
			case 1104:
				name = "Palladium Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 221;
				width = 12;
				height = 12;
				value = 4500;
				rare = 3;
				return;
			case 1105:
				name = "Orichalcum Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 222;
				width = 12;
				height = 12;
				value = 6500;
				rare = 3;
				return;
			case 1106:
				name = "Titanium Ore";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 223;
				width = 12;
				height = 12;
				value = 8500;
				rare = 3;
				return;
			case 1107:
				name = "Teal Mushroom";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Teal Dye";
				placeStyle = 0;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			case 1108:
				name = "Green Mushroom";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Green Dye";
				placeStyle = 1;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			case 1109:
				name = "Sky Blue Flower";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Sky Blue Dye";
				placeStyle = 2;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			case 1110:
				name = "Yellow Marigold";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Yellow Dye";
				placeStyle = 3;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			case 1111:
				name = "Blue Berries";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Blue Dye";
				placeStyle = 4;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			case 1112:
				name = "Lime Kelp";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Lime Dye";
				placeStyle = 5;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			case 1113:
				name = "Pink Prickly Pear";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Pink Dye";
				placeStyle = 6;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			case 1114:
				name = "Orange Bloodroot";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Orange Dye";
				placeStyle = 7;
				createTile = 227;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				return;
			case 1115:
				name = "Red Husk";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Red Dye";
				return;
			case 1116:
				name = "Cyan Husk";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Cyan Dye";
				return;
			case 1117:
				name = "Violet Husk";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Violet Dye";
				return;
			case 1118:
				name = "Purple Mucus";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Purple Dye";
				return;
			case 1119:
				name = "Black Ink";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 10000;
				rare = 1;
				toolTip = "Used to make Black Dye";
				return;
			case 1120:
				name = "Dye Vat";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 228;
				width = 26;
				height = 20;
				value = buyPrice(0, 5);
				toolTip = "Used to craft dyes";
				return;
			case 1121:
				name = "Beegun";
				useStyle = 5;
				autoReuse = true;
				useAnimation = 12;
				useTime = 12;
				mana = 5;
				width = 50;
				height = 18;
				shoot = 181;
				useSound = 11;
				damage = 9;
				shootSpeed = 8f;
				noMelee = true;
				value = sellPrice(0, 3);
				rare = 2;
				magic = true;
				scale = 0.8f;
				return;
			case 1122:
				useStyle = 1;
				name = "Possessed Hatchet";
				shootSpeed = 12f;
				shoot = 182;
				damage = 90;
				width = 18;
				height = 20;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 500000;
				knockBack = 5f;
				melee = true;
				rare = 7;
				toolTip = "A magical returning hatchet";
				return;
			case 1123:
				name = "Bee Keeper";
				useStyle = 1;
				useAnimation = 22;
				knockBack = 5.2f;
				width = 40;
				height = 40;
				damage = 22;
				scale = 1.1f;
				useSound = 1;
				rare = 3;
				value = 27000;
				melee = true;
				toolTip = "Summons killer bees after striking your foe";
				toolTip2 = "Small chance to cause confusion";
				return;
			case 1124:
				name = "Hive";
				width = 12;
				height = 12;
				maxStack = 999;
				return;
			case 1125:
				name = "Honey Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 229;
				width = 12;
				height = 12;
				return;
			case 1126:
				name = "Hive Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 108;
				width = 12;
				height = 12;
				return;
			case 1127:
				name = "Crispy Honey Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 230;
				width = 12;
				height = 12;
				return;
			case 1128:
				name = "Honey Bucket";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				width = 20;
				height = 20;
				maxStack = 99;
				autoReuse = true;
				return;
			case 1129:
				name = "Hive Wand";
				tileWand = 1124;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				createTile = 225;
				width = 8;
				height = 10;
				rare = 1;
				toolTip = "Places hives";
				return;
			case 1130:
				useStyle = 1;
				name = "Beenade";
				shootSpeed = 6f;
				shoot = 183;
				knockBack = 1f;
				damage = 14;
				width = 10;
				height = 10;
				maxStack = 999;
				consumable = true;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 200;
				ranged = true;
				return;
			case 1131:
				name = "Gravity Globe";
				width = 22;
				height = 22;
				accessory = true;
				rare = 8;
				toolTip = "Allows the holder to reverse gravity";
				toolTip2 = "Press UP to change gravity";
				value = 50000;
				return;
			case 1132:
				name = "Honey Comb";
				width = 22;
				height = 22;
				accessory = true;
				rare = 2;
				toolTip = "Releases bees when damaged";
				value = 100000;
				return;
			case 1133:
				useStyle = 4;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				name = "Abeemination";
				width = 28;
				height = 28;
				maxStack = 20;
				toolTip = "Summons the Queen Bee";
				return;
			case 1134:
				name = "Bottled Honey";
				useSound = 3;
				healLife = 80;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				potion = true;
				value = 40;
				return;
			case 1135:
				name = "Rain Hat";
				width = 18;
				height = 18;
				headSlot = 81;
				value = 1000;
				vanity = true;
				rare = 1;
				return;
			case 1136:
				name = "Rain Coat";
				width = 18;
				height = 18;
				bodySlot = 52;
				value = 1000;
				vanity = true;
				rare = 1;
				return;
			case 1137:
				name = "Lihzahrd Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 12;
				width = 14;
				height = 28;
				value = 200;
				return;
			case 1138:
				name = "Dungeon Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 13;
				width = 14;
				height = 28;
				value = 200;
				return;
			case 1139:
				name = "Lead Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 14;
				width = 14;
				height = 28;
				value = 200;
				return;
			case 1140:
				name = "Iron Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 15;
				width = 14;
				height = 28;
				value = 200;
				return;
			case 1141:
				name = "Temple Key";
				width = 14;
				height = 20;
				maxStack = 99;
				toolTip = "Opens the jungle temple door";
				rare = 7;
				return;
			case 1142:
				name = "Lihzahrd Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 16;
				width = 26;
				height = 22;
				value = 500;
				return;
			case 1143:
				name = "Lihzahrd Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 12;
				width = 12;
				height = 30;
				return;
			case 1144:
				name = "Lihzahrd Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 9;
				width = 26;
				height = 20;
				value = 300;
				return;
			case 1145:
				name = "Lihzahrd Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 10;
				width = 28;
				height = 14;
				value = 150;
				toolTip = "Used for basic crafting";
				return;
			case 1146:
				name = "Super Dart Trap";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 137;
				placeStyle = 1;
				width = 12;
				height = 12;
				value = 10000;
				mech = true;
				return;
			case 1147:
				name = "Flame Trap";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 137;
				placeStyle = 2;
				width = 12;
				height = 12;
				value = 10000;
				mech = true;
				return;
			case 1148:
				name = "Spiky Ball Trap";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 137;
				placeStyle = 3;
				width = 12;
				height = 12;
				value = 10000;
				mech = true;
				return;
			case 1149:
				name = "Spear Trap";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 137;
				placeStyle = 4;
				width = 12;
				height = 12;
				value = 10000;
				mech = true;
				return;
			case 1150:
				name = "Wooden Spike";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 232;
				width = 12;
				height = 12;
				return;
			case 1151:
				name = "Lihzahrd Pressure Plate";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 135;
				width = 12;
				height = 12;
				placeStyle = 6;
				mech = true;
				value = 5000;
				toolTip = "Activates when a player steps on it on";
				return;
			case 1152:
				name = "Lihzahrd Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 43;
				return;
			case 1153:
				name = "Lihzahrd Watcher Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 44;
				return;
			case 1154:
				name = "Lihzahrd Guardian Statue";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 45;
				return;
			case 1155:
				name = "Wasp Gun";
				useStyle = 5;
				autoReuse = true;
				useAnimation = 11;
				useTime = 11;
				mana = 6;
				width = 50;
				height = 18;
				shoot = 189;
				useSound = 11;
				damage = 19;
				shootSpeed = 9f;
				noMelee = true;
				value = 500000;
				rare = 8;
				magic = true;
				return;
			case 1156:
				channel = true;
				name = "Piranha Gun";
				useStyle = 5;
				useAnimation = 30;
				useTime = 30;
				knockBack = 1f;
				width = 30;
				height = 10;
				damage = 33;
				scale = 1.1f;
				shoot = 190;
				shootSpeed = 14f;
				useSound = 10;
				rare = 8;
				value = sellPrice(0, 5, 50);
				ranged = true;
				noMelee = true;
				return;
			case 1157:
				mana = 10;
				damage = 34;
				useStyle = 1;
				name = "Pygmy Staff";
				shootSpeed = 10f;
				shoot = 191;
				width = 26;
				height = 28;
				useSound = 44;
				useAnimation = 28;
				useTime = 28;
				rare = 7;
				noMelee = true;
				knockBack = 3f;
				toolTip = "Summons a pygmy to fight for you";
				buffType = 49;
				value = 100000;
				summon = true;
				return;
			case 1158:
				name = "Pygmy Necklace";
				rare = 7;
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Increases your max number of minions";
				value = buyPrice(0, 40);
				neckSlot = 4;
				return;
			case 1159:
				name = "Tiki Mask";
				width = 18;
				height = 18;
				defense = 6;
				headSlot = 82;
				rare = 7;
				value = buyPrice(0, 50);
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 10%";
				return;
			case 1160:
				name = "Tiki Shirt";
				width = 18;
				height = 18;
				defense = 17;
				bodySlot = 53;
				rare = 7;
				value = buyPrice(0, 50);
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 10%";
				return;
			case 1161:
				name = "Tiki Pants";
				width = 18;
				height = 18;
				defense = 12;
				legSlot = 48;
				rare = 7;
				value = buyPrice(0, 50);
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 10%";
				return;
			case 1162:
				name = "Leaf Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = buyPrice(1);
				wingSlot = 13;
				rare = 5;
				return;
			case 1163:
				name = "Blizzard in a Balloon";
				width = 14;
				height = 28;
				rare = 4;
				value = 150000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip2 = "Increases jump height";
				balloonSlot = 1;
				return;
			case 1164:
				name = "Bundle of Balloons";
				width = 14;
				height = 28;
				rare = 8;
				value = 150000;
				accessory = true;
				toolTip = "Allows the holder to quadruple jump";
				toolTip2 = "Increases jump height";
				balloonSlot = 3;
				return;
			case 1165:
				name = "Bat Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 14;
				return;
			case 1166:
				name = "Bone Sword";
				useStyle = 1;
				useAnimation = 22;
				knockBack = 4.5f;
				width = 24;
				height = 28;
				damage = 16;
				scale = 1.05f;
				useSound = 1;
				rare = 3;
				value = 9000;
				melee = true;
				return;
			case 1167:
				name = "Hercules Beetle";
				rare = 7;
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Increases the damage and knockback of your minions";
				value = buyPrice(0, 40);
				return;
			case 1168:
				useStyle = 1;
				name = "Smoke Bomb";
				shootSpeed = 6f;
				shoot = 196;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 20;
				return;
			case 1169:
				damage = 0;
				useStyle = 1;
				name = "Bone Key";
				shoot = 197;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Baby Skeletron Head";
				value = sellPrice(0, 5);
				buffType = 50;
				return;
			case 1170:
				damage = 0;
				useStyle = 1;
				name = "Nectar";
				shoot = 198;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Baby Hornet";
				value = sellPrice(0, 3);
				buffType = 51;
				return;
			case 1171:
				damage = 0;
				useStyle = 1;
				name = "Tiki Totem";
				shoot = 199;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Tiki Spirit";
				buffType = 52;
				value = buyPrice(2);
				return;
			case 1172:
				damage = 0;
				useStyle = 1;
				name = "Lizard Egg";
				shoot = 200;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Pet Lizard";
				value = sellPrice(0, 2);
				buffType = 53;
				return;
			case 1173:
				name = "Grave Marker";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 85;
				placeStyle = 1;
				width = 20;
				height = 20;
				return;
			case 1174:
				name = "Cross Grave Marker";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 85;
				placeStyle = 2;
				width = 20;
				height = 20;
				return;
			case 1175:
				name = "Headstone";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 85;
				placeStyle = 3;
				width = 20;
				height = 20;
				return;
			case 1176:
				name = "Gravestone";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 85;
				placeStyle = 4;
				width = 20;
				height = 20;
				return;
			case 1177:
				name = "Obelisk";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 85;
				placeStyle = 5;
				width = 20;
				height = 20;
				return;
			case 1178:
				useStyle = 5;
				mana = 4;
				autoReuse = true;
				useAnimation = 8;
				useTime = 8;
				name = "Leaf Blower";
				width = 24;
				height = 18;
				shoot = 206;
				useSound = 7;
				damage = 42;
				shootSpeed = 11f;
				noMelee = true;
				value = 350000;
				knockBack = 3f;
				rare = 7;
				toolTip = "Rapidly shoots razor sharp leaves";
				magic = true;
				return;
			case 1179:
				name = "Chlorophyte Bullet";
				shootSpeed = 5f;
				shoot = 207;
				damage = 10;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 14;
				knockBack = 4.5f;
				value = 50;
				ranged = true;
				rare = 7;
				return;
			case 1180:
				damage = 0;
				useStyle = 1;
				name = "Parrot Cracker";
				shoot = 208;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Pet Parrot";
				buffType = 54;
				value = sellPrice(0, 75);
				return;
			case 1181:
				damage = 0;
				useStyle = 1;
				name = "Strange Glowing Mushroom";
				shoot = 209;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Baby Truffle";
				value = buyPrice(0, 45);
				buffType = 55;
				return;
			case 1182:
				damage = 0;
				useStyle = 1;
				name = "Seedling";
				shoot = 210;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Pet Sapling";
				value = sellPrice(0, 2);
				buffType = 56;
				return;
			case 1183:
				damage = 0;
				useStyle = 1;
				name = "Wisp in a Bottle";
				shoot = 211;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 8;
				noMelee = true;
				toolTip = "Summons a Wisp to provide light";
				value = sellPrice(0, 5, 50);
				buffType = 57;
				return;
			case 1184:
				name = "Palladium Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 13500;
				rare = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 12;
				return;
			case 1185:
				useTurn = true;
				autoReuse = true;
				name = "Palladium Sword";
				useStyle = 1;
				useAnimation = 25;
				useTime = 25;
				knockBack = 4.75f;
				width = 40;
				height = 40;
				damage = 36;
				scale = 1.125f;
				useSound = 1;
				rare = 4;
				value = 92000;
				melee = true;
				return;
			case 1186:
				name = "Palladium Pike";
				useStyle = 5;
				useAnimation = 27;
				useTime = 27;
				shootSpeed = 4.4f;
				knockBack = 4.5f;
				width = 40;
				height = 40;
				damage = 32;
				scale = 1.1f;
				useSound = 1;
				shoot = 212;
				rare = 4;
				value = 60000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			case 1187:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 24;
				useTime = 24;
				name = "Palladium Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 34;
				shootSpeed = 9.25f;
				noMelee = true;
				value = 80000;
				ranged = true;
				rare = 4;
				knockBack = 1.75f;
				return;
			case 1188:
				name = "Palladium Pickaxe";
				useStyle = 1;
				useTurn = true;
				autoReuse = true;
				useAnimation = 25;
				useTime = 11;
				knockBack = 5f;
				width = 20;
				height = 12;
				damage = 12;
				pick = 130;
				useSound = 1;
				rare = 4;
				value = 72000;
				melee = true;
				toolTip = "Can mine Mythril and Orichalcum";
				scale = 1.15f;
				return;
			case 1189:
				name = "Palladium Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 11;
				shootSpeed = 32f;
				knockBack = 0f;
				width = 20;
				height = 12;
				damage = 12;
				pick = 130;
				useSound = 23;
				shoot = 213;
				rare = 4;
				value = 72000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				toolTip = "Can mine Mythril and Orichalcum";
				return;
			case 1190:
				name = "Palladium Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 8;
				shootSpeed = 40f;
				knockBack = 2.9f;
				width = 20;
				height = 12;
				damage = 26;
				axe = 15;
				useSound = 23;
				shoot = 214;
				rare = 4;
				value = 72000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				return;
			case 1191:
				name = "Orichalcum Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 22000;
				rare = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 14;
				return;
			case 1192:
				name = "Orichalcum Sword";
				useStyle = 1;
				useAnimation = 26;
				useTime = 26;
				knockBack = 6f;
				width = 40;
				height = 40;
				damage = 41;
				scale = 1.17f;
				useSound = 1;
				rare = 4;
				value = 126500;
				melee = true;
				return;
			case 1193:
				name = "Orichalcum Halberd";
				useStyle = 5;
				useAnimation = 25;
				useTime = 25;
				shootSpeed = 4.5f;
				knockBack = 5.5f;
				width = 40;
				height = 40;
				damage = 36;
				scale = 1.1f;
				useSound = 1;
				shoot = 215;
				rare = 4;
				value = 82500;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			case 1194:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 22;
				useTime = 22;
				name = "Orichalcum Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 38;
				shootSpeed = 9.75f;
				noMelee = true;
				value = 110000;
				ranged = true;
				rare = 4;
				knockBack = 2f;
				return;
			case 1195:
				name = "Orichalcum Pickaxe";
				useStyle = 1;
				useAnimation = 25;
				useTime = 8;
				knockBack = 5f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 17;
				pick = 165;
				useSound = 1;
				rare = 4;
				value = 99000;
				melee = true;
				toolTip = "Can mine Adamantite and Titanium";
				scale = 1.15f;
				return;
			case 1196:
				name = "Orichalcum Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 10;
				shootSpeed = 32f;
				knockBack = 0f;
				width = 20;
				height = 12;
				damage = 17;
				pick = 165;
				useSound = 23;
				shoot = 216;
				rare = 4;
				value = 99000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				toolTip = "Can mine Adamantite and Titanium";
				return;
			case 1197:
				name = "Orichalcum Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 40f;
				knockBack = 3.75f;
				width = 20;
				height = 12;
				damage = 31;
				axe = 18;
				useSound = 23;
				shoot = 217;
				rare = 4;
				value = 99000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				return;
			case 1198:
				name = "Titanium Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = 37500;
				rare = 3;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 16;
				return;
			case 1199:
				name = "Titanium Sword";
				useStyle = 1;
				useAnimation = 26;
				useTime = 26;
				knockBack = 6f;
				width = 40;
				height = 40;
				damage = 46;
				scale = 1.2f;
				useSound = 1;
				rare = 4;
				value = 161000;
				melee = true;
				return;
			case 1200:
				name = "Titanium Trident";
				useStyle = 5;
				useAnimation = 23;
				useTime = 23;
				shootSpeed = 5f;
				knockBack = 6.2f;
				width = 40;
				height = 40;
				damage = 40;
				scale = 1.1f;
				useSound = 1;
				shoot = 218;
				rare = 4;
				value = 105000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			case 1201:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 19;
				useTime = 19;
				name = "Titanium Repeater";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 41;
				shootSpeed = 10.5f;
				noMelee = true;
				value = 140000;
				ranged = true;
				rare = 4;
				knockBack = 2.5f;
				return;
			case 1202:
				name = "Titanium Pickaxe";
				useStyle = 1;
				useAnimation = 25;
				useTime = 7;
				knockBack = 5f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 27;
				pick = 190;
				useSound = 1;
				rare = 4;
				value = 126000;
				melee = true;
				scale = 1.15f;
				return;
			case 1203:
				name = "Titanium Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 32f;
				knockBack = 0f;
				width = 20;
				height = 12;
				damage = 27;
				pick = 190;
				useSound = 23;
				shoot = 219;
				rare = 4;
				value = 126000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				return;
			case 1204:
				name = "Titanium Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 6;
				shootSpeed = 40f;
				knockBack = 4.6f;
				width = 20;
				height = 12;
				damage = 34;
				axe = 21;
				useSound = 23;
				shoot = 220;
				rare = 4;
				value = 126000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				return;
			case 1205:
				name = "Palladium Mask";
				width = 18;
				height = 18;
				defense = 14;
				headSlot = 83;
				rare = 4;
				value = 75000;
				toolTip = "7% increased movement speed";
				toolTip2 = "12% increased melee speed";
				return;
			case 1206:
				name = "Palladium Helmet";
				width = 18;
				height = 18;
				defense = 5;
				headSlot = 84;
				rare = 4;
				value = 75000;
				toolTip = "10% increased ranged damage";
				toolTip2 = "6% increased ranged critical strike chance";
				return;
			case 1207:
				name = "Palladium Headgear";
				width = 18;
				height = 18;
				defense = 3;
				headSlot = 85;
				rare = 4;
				value = 75000;
				toolTip = "Increases maximum mana by 40";
				toolTip2 = "9% increased magic critical strike chance";
				return;
			case 1208:
				name = "Palladium Breastplate";
				width = 18;
				height = 18;
				defense = 10;
				bodySlot = 54;
				rare = 4;
				value = 60000;
				toolTip2 = "3% increased critical strike chance";
				return;
			case 1209:
				name = "Palladium Leggings";
				width = 18;
				height = 18;
				defense = 8;
				legSlot = 49;
				rare = 4;
				value = 45000;
				toolTip2 = "10% increased movement speed";
				return;
			case 1210:
				name = "Orichalcum Mask";
				width = 18;
				height = 18;
				defense = 19;
				headSlot = 86;
				rare = 4;
				value = 112500;
				toolTip = "5% increased melee critical strike chance";
				toolTip2 = "10% increased melee damage";
				return;
			case 1211:
				name = "Orichalcum Helmet";
				width = 18;
				height = 18;
				defense = 7;
				headSlot = 87;
				rare = 4;
				value = 112500;
				toolTip = "12% increased ranged damage";
				toolTip2 = "7% increased ranged critical strike chance";
				return;
			case 1212:
				name = "Orichalcum Headgear";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 88;
				rare = 4;
				value = 112500;
				toolTip = "Increases maximum mana by 60";
				toolTip2 = "15% increased magic damage";
				return;
			case 1213:
				name = "Orichalcum Breastplate";
				width = 18;
				height = 18;
				defense = 13;
				bodySlot = 55;
				rare = 4;
				value = 90000;
				toolTip2 = "5% increased damage";
				return;
			case 1214:
				name = "Orichalcum Leggings";
				width = 18;
				height = 18;
				defense = 10;
				legSlot = 50;
				rare = 4;
				value = 67500;
				toolTip2 = "3% increased critical strike chance";
				return;
			case 1215:
				name = "Titanium Mask";
				width = 18;
				height = 18;
				defense = 23;
				headSlot = 89;
				rare = 4;
				value = 150000;
				toolTip = "7% increased melee critical strike chance";
				toolTip2 = "14% increased melee damage";
				return;
			case 1216:
				name = "Titanium Helmet";
				width = 18;
				height = 18;
				defense = 8;
				headSlot = 90;
				rare = 4;
				value = 150000;
				toolTip = "14% increased ranged damage";
				toolTip2 = "8% increased ranged critical strike chance";
				return;
			case 1217:
				name = "Titanium Headgear";
				width = 18;
				height = 18;
				defense = 4;
				headSlot = 91;
				rare = 4;
				value = 150000;
				toolTip = "Increases maximum mana by 80";
				toolTip2 = "11% increased magic damage and critical strike chance";
				return;
			case 1218:
				name = "Titanium Breastplate";
				width = 18;
				height = 18;
				defense = 15;
				bodySlot = 56;
				rare = 4;
				value = 120000;
				toolTip = "6% increased damage";
				return;
			case 1219:
				name = "Titanium Leggings";
				width = 18;
				height = 18;
				defense = 11;
				legSlot = 51;
				rare = 4;
				value = 90000;
				toolTip = "4% increased critical strike chance";
				toolTip2 = "5% increased movement speed";
				return;
			case 1220:
				name = "Mythril Anvil";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 134;
				placeStyle = 1;
				width = 28;
				height = 14;
				value = 25000;
				toolTip = "Used to craft items from mythril, orichalcum, adamantite, and titanium bars";
				rare = 3;
				return;
			case 1221:
				name = "Orichalcum Forge";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 133;
				placeStyle = 1;
				width = 44;
				height = 30;
				value = 50000;
				toolTip = "Used to smelt adamantite and titanium ore";
				rare = 3;
				return;
			case 1222:
				useTurn = true;
				autoReuse = true;
				name = "Palladium Waraxe";
				useStyle = 1;
				useAnimation = 35;
				useTime = 8;
				knockBack = 5.5f;
				width = 20;
				height = 12;
				damage = 36;
				axe = 15;
				useSound = 1;
				rare = 4;
				value = 72000;
				melee = true;
				scale = 1.1f;
				return;
			case 1223:
				useTurn = true;
				autoReuse = true;
				name = "Orichalcum Waraxe";
				useStyle = 1;
				useAnimation = 35;
				useTime = 7;
				knockBack = 6.5f;
				width = 20;
				height = 12;
				damage = 41;
				axe = 18;
				useSound = 1;
				rare = 4;
				value = 99000;
				melee = true;
				scale = 1.1f;
				return;
			case 1224:
				useTurn = true;
				autoReuse = true;
				name = "Titanium Waraxe";
				useStyle = 1;
				useAnimation = 35;
				useTime = 6;
				knockBack = 7.5f;
				width = 20;
				height = 12;
				damage = 44;
				axe = 21;
				useSound = 1;
				rare = 4;
				value = 108000;
				melee = true;
				scale = 1.1f;
				return;
			case 1225:
				name = "Hallowed Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				value = sellPrice(0, 0, 40);
				rare = 4;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 18;
				return;
			case 1226:
				name = "Chlorophyte Claymore";
				useStyle = 1;
				useAnimation = 28;
				useTime = 60;
				shoot = 229;
				shootSpeed = 8f;
				knockBack = 6f;
				width = 40;
				height = 40;
				damage = 65;
				useSound = 1;
				rare = 7;
				value = 276000;
				scale = 1.25f;
				melee = true;
				return;
			case 1227:
				name = "Chlorophyte Saber";
				autoReuse = true;
				useTurn = true;
				useStyle = 1;
				useAnimation = 17;
				useTime = 42;
				shoot = 228;
				shootSpeed = 8f;
				knockBack = 4f;
				width = 40;
				height = 40;
				damage = 43;
				useSound = 1;
				rare = 7;
				value = 276000;
				melee = true;
				return;
			case 1228:
				name = "Chlorophyte Partisan";
				useStyle = 5;
				useAnimation = 23;
				useTime = 23;
				shootSpeed = 5f;
				knockBack = 6.2f;
				width = 40;
				height = 40;
				damage = 49;
				scale = 1.1f;
				useSound = 1;
				shoot = 222;
				rare = 7;
				value = 180000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			case 1229:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 19;
				useTime = 19;
				name = "Chlorophyte Shotbow";
				width = 50;
				height = 18;
				shoot = 1;
				useAmmo = 1;
				useSound = 5;
				damage = 34;
				shootSpeed = 11.5f;
				noMelee = true;
				value = 240000;
				ranged = true;
				rare = 7;
				knockBack = 2.75f;
				return;
			case 1230:
				name = "Chlorophyte Pickaxe";
				useStyle = 1;
				useAnimation = 25;
				useTime = 7;
				knockBack = 5f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 40;
				pick = 200;
				useSound = 1;
				rare = 7;
				value = 216000;
				melee = true;
				scale = 1.15f;
				tileBoost++;
				return;
			case 1231:
				name = "Chlorophyte Drill";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 40f;
				knockBack = 1f;
				width = 20;
				height = 12;
				damage = 35;
				pick = 200;
				useSound = 23;
				shoot = 223;
				rare = 7;
				value = 216000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				tileBoost++;
				return;
			case 1232:
				name = "Chlorophyte Chainsaw";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 46f;
				knockBack = 4.6f;
				width = 20;
				height = 12;
				damage = 50;
				axe = 23;
				useSound = 23;
				shoot = 224;
				rare = 7;
				value = 216000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				tileBoost++;
				return;
			case 1233:
				useTurn = true;
				autoReuse = true;
				name = "Chlorophyte Greataxe";
				useStyle = 1;
				useAnimation = 30;
				useTime = 6;
				knockBack = 7f;
				width = 20;
				height = 12;
				damage = 70;
				axe = 23;
				useSound = 1;
				rare = 7;
				value = 216000;
				melee = true;
				scale = 1.15f;
				tileBoost++;
				return;
			case 1234:
				name = "Chlorophyte Warhammer";
				useTurn = true;
				autoReuse = true;
				useStyle = 1;
				useAnimation = 35;
				useTime = 14;
				hammer = 90;
				width = 24;
				height = 28;
				damage = 80;
				knockBack = 8f;
				scale = 1.25f;
				useSound = 1;
				rare = 7;
				value = 216000;
				melee = true;
				tileBoost++;
				return;
			case 1235:
				name = "Chlorophyte Arrow";
				shootSpeed = 4.5f;
				shoot = 225;
				damage = 16;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = 1;
				knockBack = 3.5f;
				value = 100;
				ranged = true;
				rare = 7;
				return;
			case 1236:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Amethyst Hook";
				shootSpeed = 10f;
				shoot = 230;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				return;
			case 1237:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Topaz Hook";
				shootSpeed = 10.5f;
				shoot = 231;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				return;
			case 1238:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Sapphire Hook";
				shootSpeed = 11f;
				shoot = 232;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				return;
			case 1239:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Emerald Hook";
				shootSpeed = 11.5f;
				shoot = 233;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				return;
			case 1240:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Ruby Hook";
				shootSpeed = 12f;
				shoot = 234;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				return;
			case 1241:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Diamond Hook";
				shootSpeed = 12.5f;
				shoot = 235;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 1;
				noMelee = true;
				value = 20000;
				return;
			case 1242:
				damage = 0;
				useStyle = 1;
				name = "Amber Mosquito";
				shoot = 236;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Baby Dinosaur";
				value = sellPrice(0, 7, 50);
				buffType = 61;
				return;
			case 1243:
				name = "Umbrella Hat";
				width = 28;
				height = 20;
				headSlot = 92;
				rare = 1;
				vanity = true;
				return;
			case 1244:
				mana = 10;
				damage = 36;
				useStyle = 1;
				name = "Nimbus Rod";
				shootSpeed = 16f;
				shoot = 237;
				width = 26;
				height = 28;
				useSound = 8;
				useAnimation = 22;
				useTime = 22;
				rare = 6;
				noMelee = true;
				knockBack = 0f;
				toolTip = "Summons a cloud to rain down on your foes";
				value = sellPrice(0, 3, 50);
				magic = true;
				return;
			case 1245:
				name = "Orange Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 10;
				width = 10;
				height = 12;
				value = 60;
				noWet = true;
				return;
			case 1246:
				name = "Crimsand Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 234;
				width = 12;
				height = 12;
				ammo = 42;
				return;
			case 1247:
				name = "Bee Cloak";
				width = 20;
				height = 24;
				value = 150000;
				toolTip = "Causes stars to fall and releases bees when injured";
				accessory = true;
				rare = 4;
				backSlot = 1;
				return;
			case 1248:
				name = "Eye of the Golem";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "10% increased critical strike chance";
				value = 100000;
				rare = 7;
				return;
			case 1249:
				name = "Honey Balloon";
				width = 14;
				height = 28;
				rare = 2;
				value = 54000;
				accessory = true;
				toolTip = "Increases jump height";
				toolTip2 = "Releases bees when damaged";
				balloonSlot = 7;
				return;
			case 1250:
				name = "Blue Horseshoe Balloon";
				width = 20;
				height = 22;
				rare = 4;
				value = 45000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip = "Increases jump height and negates fall damage";
				balloonSlot = 2;
				return;
			case 1251:
				name = "White Horseshoe Balloon";
				width = 20;
				height = 22;
				rare = 4;
				value = 45000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip = "Increases jump height and negates fall damage";
				balloonSlot = 9;
				return;
			case 1252:
				name = "Yellow Horseshoe Balloon";
				width = 20;
				height = 22;
				rare = 4;
				value = 45000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip = "Increases jump height and negates fall damage";
				balloonSlot = 10;
				return;
			case 1253:
				name = "Frozen Turtle Scale";
				width = 20;
				height = 24;
				value = 225000;
				toolTip = "Puts a shell around the owner when below 20% life";
				accessory = true;
				rare = 5;
				return;
			case 1254:
				useStyle = 5;
				useAnimation = 50;
				useTime = 50;
				name = "Sniper Rifle";
				crit += 15;
				width = 44;
				height = 14;
				shoot = 10;
				useAmmo = 14;
				useSound = 40;
				damage = 125;
				shootSpeed = 16f;
				noMelee = true;
				value = 100000;
				knockBack = 8f;
				rare = 8;
				ranged = true;
				return;
			case 1255:
				autoReuse = false;
				useStyle = 5;
				useAnimation = 9;
				useTime = 9;
				name = "Venus Magnum";
				width = 24;
				height = 22;
				shoot = 14;
				knockBack = 5.5f;
				useAmmo = 14;
				useSound = 41;
				damage = 36;
				shootSpeed = 13.5f;
				noMelee = true;
				value = sellPrice(0, 5);
				scale = 0.85f;
				rare = 7;
				ranged = true;
				return;
			case 1256:
				mana = 10;
				damage = 12;
				useStyle = 1;
				name = "Crimson Rod";
				shootSpeed = 12f;
				shoot = 243;
				width = 26;
				height = 28;
				useSound = 8;
				useAnimation = 24;
				useTime = 24;
				rare = 1;
				noMelee = true;
				knockBack = 0f;
				toolTip = "Summons a cloud to rain blood on your foes";
				value = 10000;
				magic = true;
				return;
			case 1257:
				name = "Crimtane Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				rare = 1;
				value = 20000;
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 19;
				return;
			case 1258:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 22;
				useTime = 22;
				name = "Stynger";
				width = 50;
				height = 18;
				shoot = 246;
				useAmmo = 246;
				useSound = 11;
				damage = 43;
				knockBack = 5f;
				shootSpeed = 9f;
				noMelee = true;
				value = 350000;
				rare = 7;
				ranged = true;
				toolTip = "Shoots a bolt that explodes into deadly shrapnel";
				return;
			case 1259:
				name = "Flower Pow";
				noMelee = true;
				useStyle = 5;
				useAnimation = 40;
				useTime = 40;
				knockBack = 7.5f;
				width = 30;
				height = 10;
				damage = 52;
				scale = 1.1f;
				noUseGraphic = true;
				shoot = 247;
				shootSpeed = 15.9f;
				useSound = 1;
				rare = 7;
				value = sellPrice(0, 6);
				melee = true;
				channel = true;
				return;
			case 1260:
				useStyle = 5;
				useAnimation = 40;
				useTime = 40;
				name = "Rainbow Gun";
				width = 50;
				height = 18;
				shoot = 250;
				useSound = 9;
				damage = 45;
				knockBack = 2f;
				shootSpeed = 16f;
				noMelee = true;
				value = 350000;
				rare = 8;
				magic = true;
				mana = 20;
				return;
			case 1261:
				name = "Stynger Bolt";
				shootSpeed = 2f;
				shoot = 246;
				damage = 15;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = 246;
				knockBack = 1f;
				value = 75;
				rare = 5;
				ranged = true;
				return;
			case 1262:
				name = "Chlorophyte Jackhammer";
				useStyle = 5;
				useAnimation = 25;
				useTime = 7;
				shootSpeed = 46f;
				knockBack = 5.2f;
				width = 20;
				height = 12;
				damage = 45;
				hammer = 90;
				useSound = 23;
				shoot = 252;
				rare = 7;
				value = 216000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				channel = true;
				tileBoost++;
				return;
			case 1263:
				name = "Teleporter";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 235;
				width = 12;
				height = 12;
				value = buyPrice(0, 2, 50);
				mech = true;
				return;
			case 1264:
				mana = 17;
				damage = 50;
				useStyle = 1;
				name = "Flower of Frost";
				shootSpeed = 7f;
				shoot = 253;
				width = 26;
				height = 28;
				useSound = 20;
				useAnimation = 20;
				useTime = 20;
				rare = 6;
				noMelee = true;
				knockBack = 6.5f;
				toolTip = "Throws balls of frost";
				value = 10000;
				magic = true;
				return;
			case 1265:
				autoReuse = true;
				useStyle = 5;
				useAnimation = 9;
				useTime = 9;
				name = "Uzi";
				width = 24;
				height = 22;
				shoot = 14;
				knockBack = 3.5f;
				useAmmo = 14;
				useSound = 11;
				damage = 30;
				shootSpeed = 13f;
				noMelee = true;
				value = 50000;
				scale = 0.75f;
				rare = 7;
				ranged = true;
				return;
			case 1266:
				rare = 8;
				mana = 14;
				useSound = 20;
				name = "Magnet Sphere";
				useStyle = 5;
				damage = 48;
				knockBack = 6f;
				useAnimation = 20;
				useTime = 20;
				width = 24;
				height = 28;
				shoot = 254;
				shootSpeed = 2f;
				toolTip = "Summons something to do stuff and things";
				magic = true;
				value = 500000;
				return;
			case 1267:
				name = "Purple Stained Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 88;
				width = 12;
				height = 12;
				value = sellPrice(0, 0, 5);
				return;
			case 1268:
				name = "Yellow Stained Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 89;
				width = 12;
				height = 12;
				value = sellPrice(0, 0, 5);
				return;
			case 1269:
				name = "Blue Stained Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 90;
				width = 12;
				height = 12;
				value = sellPrice(0, 0, 5);
				return;
			case 1270:
				name = "Green Stained Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 91;
				width = 12;
				height = 12;
				value = sellPrice(0, 0, 5);
				return;
			case 1271:
				name = "Red Stained Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 92;
				width = 12;
				height = 12;
				value = sellPrice(0, 0, 5);
				return;
			case 1272:
				name = "Multicolored Stained Glass";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 93;
				width = 12;
				height = 12;
				value = sellPrice(0, 0, 5);
				return;
			case 1273:
				name = "Skeletron Hand";
				useStyle = 5;
				useAnimation = 25;
				useTime = 25;
				width = 30;
				height = 10;
				noUseGraphic = true;
				shoot = 256;
				shootSpeed = 15f;
				useSound = 1;
				rare = 2;
				value = 45000;
				return;
			case 1274:
				name = "Skull";
				width = 28;
				height = 20;
				headSlot = 93;
				rare = 1;
				vanity = true;
				return;
			case 1275:
				name = "Balla Hat";
				width = 28;
				height = 20;
				headSlot = 94;
				rare = 1;
				vanity = true;
				return;
			case 1276:
				name = "Gangsta Hat";
				width = 28;
				height = 20;
				headSlot = 95;
				rare = 1;
				vanity = true;
				return;
			case 1277:
				name = "Sailor Hat";
				width = 28;
				height = 20;
				headSlot = 96;
				rare = 1;
				vanity = true;
				return;
			case 1278:
				name = "Eye Patch";
				width = 28;
				height = 20;
				headSlot = 97;
				rare = 1;
				vanity = true;
				return;
			case 1279:
				name = "Sailor Shirt";
				width = 28;
				height = 20;
				bodySlot = 57;
				rare = 1;
				vanity = true;
				return;
			case 1280:
				name = "Sailor Pants";
				width = 28;
				height = 20;
				legSlot = 52;
				rare = 1;
				vanity = true;
				return;
			case 1281:
				name = "Skeletron Mask";
				width = 28;
				height = 20;
				headSlot = 98;
				rare = 1;
				vanity = true;
				return;
			case 1282:
				name = "Amethyst Robe";
				width = 18;
				height = 14;
				bodySlot = 58;
				value = sellPrice(0, 0, 50);
				toolTip = "Increases maximum mana by 20";
				toolTip = "Reduces mana usage by 5%";
				return;
			case 1283:
				name = "Topaz Robe";
				width = 18;
				height = 14;
				bodySlot = 59;
				defense = 1;
				value = sellPrice(0, 0, 50) * 2;
				toolTip = "Increases maximum mana by 40";
				toolTip2 = "Reduces mana usage by 7%";
				return;
			case 1284:
				name = "Sapphire Robe";
				width = 18;
				height = 14;
				bodySlot = 60;
				defense = 1;
				value = sellPrice(0, 0, 50) * 3;
				toolTip = "Increases maximum mana by 40";
				toolTip2 = "Reduces mana usage by 9%";
				rare = 1;
				return;
			case 1285:
				name = "Emerald Robe";
				width = 18;
				height = 14;
				bodySlot = 61;
				defense = 2;
				value = sellPrice(0, 0, 50) * 4;
				toolTip = "Increases maximum mana by 60";
				toolTip2 = "Reduces mana usage by 11%";
				rare = 1;
				return;
			case 1286:
				name = "Ruby Robe";
				width = 18;
				height = 14;
				bodySlot = 62;
				defense = 2;
				value = sellPrice(0, 0, 50) * 5;
				toolTip = "Increases maximum mana by 60";
				toolTip2 = "Reduces mana usage by 13%";
				rare = 1;
				return;
			case 1287:
				name = "Diamond Robe";
				defense = 3;
				width = 18;
				height = 14;
				bodySlot = 63;
				value = sellPrice(0, 0, 50) * 6;
				toolTip = "Increases maximum mana by 80";
				toolTip2 = "Reduces mana usage by 15%";
				rare = 2;
				return;
			case 1288:
				name = "White Tuxedo Shirt";
				width = 28;
				height = 20;
				bodySlot = 64;
				rare = 1;
				vanity = true;
				return;
			case 1289:
				name = "White Tuxedo Pants";
				width = 28;
				height = 20;
				legSlot = 53;
				rare = 1;
				vanity = true;
				return;
			case 1290:
				name = "Panic Necklace";
				width = 22;
				height = 22;
				accessory = true;
				rare = 1;
				toolTip = "Increases movement speed after being struck";
				value = 50000;
				neckSlot = 3;
				return;
			case 1291:
				name = "Heart Fruit";
				maxStack = 99;
				consumable = true;
				width = 18;
				height = 18;
				useStyle = 4;
				useTime = 30;
				useSound = 4;
				useAnimation = 30;
				toolTip = "Permanently increases maximum life by 5";
				rare = 7;
				value = sellPrice(0, 2);
				return;
			case 1292:
				name = "Lihzahrd Altar";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 237;
				width = 26;
				height = 20;
				value = 300;
				return;
			case 1293:
				name = "Lihzahrd Power Cell";
				maxStack = 99;
				consumable = true;
				width = 22;
				height = 10;
				value = sellPrice(0, 1);
				return;
			case 1294:
				name = "Picksaw";
				useStyle = 1;
				useAnimation = 16;
				useTime = 6;
				knockBack = 5.5f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 34;
				pick = 210;
				axe = 25;
				useSound = 1;
				rare = 7;
				value = 216000;
				melee = true;
				scale = 1.15f;
				tileBoost++;
				toolTip = "Capable of mining Lihzahrd Bricks";
				return;
			case 1295:
				mana = 8;
				useStyle = 5;
				autoReuse = true;
				useAnimation = 16;
				useTime = 16;
				name = "Heat Ray";
				width = 24;
				height = 18;
				shoot = 260;
				useSound = 12;
				damage = 55;
				shootSpeed = 15f;
				noMelee = true;
				value = 350000;
				knockBack = 3f;
				rare = 7;
				magic = true;
				toolTip = "Shoots a piercing beam of heat";
				return;
			case 1296:
				mana = 17;
				damage = 45;
				useStyle = 1;
				name = "Staff of Earth";
				shootSpeed = 11f;
				shoot = 261;
				width = 26;
				height = 28;
				useSound = 20;
				useAnimation = 40;
				useTime = 40;
				rare = 7;
				noMelee = true;
				knockBack = 7.5f;
				value = sellPrice(0, 10);
				magic = true;
				toolTip = "Summons a powerful boulder";
				return;
			case 1297:
				autoReuse = true;
				name = "Golem Fist";
				useStyle = 5;
				useAnimation = 30;
				useTime = 30;
				knockBack = 9f;
				width = 30;
				height = 10;
				damage = 60;
				scale = 0.9f;
				shoot = 262;
				shootSpeed = 14f;
				useSound = 10;
				rare = 7;
				value = sellPrice(0, 5);
				melee = true;
				noMelee = true;
				toolTip = "Punches with the force of a golem";
				return;
			case 1298:
				name = "Water Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 17;
				width = 26;
				height = 22;
				value = 500;
				return;
			case 1299:
				name = "Binoculars";
				width = 14;
				height = 28;
				rare = 4;
				value = 150000;
				toolTip = "Increases view range when held";
				return;
			case 1300:
				name = "Rifle Scope";
				width = 14;
				height = 28;
				rare = 4;
				value = 150000;
				accessory = true;
				toolTip = "Increases view range for guns";
				toolTip2 = "Right click to zoom out";
				return;
			case 1301:
				name = "Destroyer Emblem";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "10% increased damage";
				toolTip2 = "8% increased critical strike chance";
				value = 300000;
				rare = 7;
				return;
			case 1302:
				name = "High Velocity Bullet";
				shootSpeed = 4f;
				shoot = 242;
				damage = 10;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 14;
				knockBack = 4f;
				value = 40;
				ranged = true;
				rare = 3;
				return;
			case 1303:
				name = "Jellyfish Necklace";
				width = 24;
				height = 24;
				accessory = true;
				toolTip = "Provides light under water";
				value = sellPrice(0, 1);
				rare = 2;
				neckSlot = 1;
				return;
			case 1304:
				name = "Zombie Arm";
				useStyle = 1;
				useTurn = false;
				useAnimation = 20;
				useTime = 20;
				width = 24;
				height = 28;
				damage = 12;
				knockBack = 4.5f;
				useSound = 1;
				scale = 1f;
				value = 2000;
				melee = true;
				return;
			case 1305:
				name = "The Axe";
				autoReuse = true;
				useStyle = 1;
				useAnimation = 23;
				knockBack = 7.25f;
				useTime = 7;
				width = 24;
				height = 28;
				damage = 72;
				axe = 35;
				hammer = 100;
				tileBoost = 1;
				scale = 1.15f;
				useSound = 47;
				rare = 8;
				value = sellPrice(0, 10);
				melee = true;
				return;
			case 1306:
				name = "Ice Sickle";
				useStyle = 1;
				useAnimation = 25;
				useTime = 25;
				knockBack = 5.5f;
				width = 24;
				height = 28;
				damage = 40;
				scale = 1.15f;
				useSound = 1;
				rare = 5;
				shoot = 263;
				shootSpeed = 8f;
				value = 250000;
				toolTip = "Shoots an icy sickle";
				melee = true;
				return;
			case 1307:
				accessory = true;
				name = "Clothier Voodoo Doll";
				width = 14;
				height = 26;
				value = 1000;
				toolTip = "'You are a terrible person.'";
				rare = 1;
				return;
			case 1308:
				name = "Poison Staff";
				mana = 22;
				useSound = 43;
				useStyle = 5;
				damage = 48;
				useAnimation = 36;
				useTime = 36;
				width = 40;
				height = 40;
				shoot = 265;
				shootSpeed = 13.5f;
				knockBack = 5.6f;
				magic = true;
				autoReuse = true;
				rare = 6;
				noMelee = true;
				value = sellPrice(0, 4);
				return;
			case 1309:
				mana = 10;
				damage = 8;
				useStyle = 1;
				name = "Slime Staff";
				shootSpeed = 10f;
				shoot = 266;
				width = 26;
				height = 28;
				useSound = 44;
				useAnimation = 28;
				useTime = 28;
				rare = 4;
				noMelee = true;
				knockBack = 2f;
				toolTip = "Summons a baby slime to fight for you";
				buffType = 64;
				value = 100000;
				summon = true;
				return;
			case 1310:
				name = "Poison Dart";
				shoot = 267;
				width = 8;
				height = 8;
				maxStack = 999;
				ammo = 51;
				toolTip = "Inflicts poison on enemies";
				toolTip2 = "For use with Blowpipe and Blowgun";
				damage = 8;
				knockBack = 2f;
				shootSpeed = 2f;
				ranged = true;
				rare = 2;
				return;
			case 1311:
				damage = 0;
				useStyle = 1;
				name = "Eyespring";
				shoot = 268;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 6;
				noMelee = true;
				toolTip = "Summons an eye spring";
				value = sellPrice(0, 3);
				buffType = 65;
				return;
			case 1312:
				damage = 0;
				useStyle = 1;
				name = "Toy Sled";
				shoot = 269;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 6;
				noMelee = true;
				toolTip = "Summons a baby snowman";
				value = sellPrice(0, 2, 50);
				buffType = 66;
				return;
			case 1313:
				autoReuse = true;
				rare = 2;
				mana = 22;
				useSound = 8;
				name = "Book of Skulls";
				useStyle = 5;
				damage = 28;
				useAnimation = 26;
				useTime = 26;
				width = 24;
				height = 28;
				shoot = 270;
				scale = 0.9f;
				shootSpeed = 4f;
				knockBack = 3.5f;
				toolTip = "Shoots a skull";
				magic = true;
				value = 50000;
				return;
			case 1314:
				autoReuse = true;
				name = "KO Cannon";
				useStyle = 5;
				useAnimation = 28;
				useTime = 28;
				knockBack = 6.5f;
				width = 30;
				height = 10;
				damage = 35;
				scale = 0.9f;
				shoot = 271;
				shootSpeed = 15f;
				useSound = 10;
				rare = 4;
				value = 27000;
				melee = true;
				noMelee = true;
				toolTip = "Shoots a boxing glove";
				return;
			case 1315:
				useStyle = 4;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				name = "Pirate Map";
				width = 28;
				height = 28;
				toolTip = "Summons a Pirate Invasion";
				return;
			case 1316:
				name = "Turtle Helmet";
				width = 18;
				height = 18;
				defense = 21;
				headSlot = 99;
				rare = 8;
				value = 300000;
				toolTip = "5% increased melee damage";
				toolTip2 = "Enemies are more likely to target you";
				return;
			case 1317:
				name = "Turtle Scale Mail";
				width = 18;
				height = 18;
				defense = 27;
				bodySlot = 65;
				rare = 8;
				value = 240000;
				toolTip = "7% increased melee damage and critical strike chance";
				toolTip2 = "Enemies are more likely to target you";
				return;
			case 1318:
				name = "Turtle Leggings";
				width = 18;
				height = 18;
				defense = 17;
				legSlot = 54;
				rare = 8;
				value = 180000;
				toolTip = "3% increased melee critical strike chance";
				toolTip2 = "Enemies are more likely to target you";
				return;
			case 1319:
				name = "Snowball Cannon";
				autoReuse = true;
				useStyle = 5;
				useAnimation = 18;
				useTime = 18;
				width = 44;
				height = 14;
				shoot = 166;
				useAmmo = 14;
				useSound = 11;
				damage = 4;
				shootSpeed = 11f;
				noMelee = true;
				value = 100000;
				knockBack = 4.5f;
				rare = 1;
				ranged = true;
				useAmmo = 949;
				shoot = 166;
				return;
			case 1320:
				name = "Bone Pickaxe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 19;
				useTime = 11;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 8;
				pick = 50;
				useSound = 1;
				knockBack = 3f;
				rare = 1;
				value = 18000;
				scale = 1.15f;
				melee = true;
				return;
			case 1321:
				name = "Magic Quiver";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Increase arrow speed and damage by 10%";
				toolTip2 = "20% chance to not consume arrow";
				value = sellPrice(0, 5);
				rare = 4;
				backSlot = 7;
				return;
			case 1322:
				name = "Magma Stone";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Chance to inflict fire damage on attack";
				value = sellPrice(0, 2);
				rare = 3;
				return;
			case 1323:
				name = "Lava Rose";
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Reduced damage from touching lava";
				value = sellPrice(0, 2);
				rare = 3;
				faceSlot = 6;
				return;
			case 1324:
				noMelee = true;
				useStyle = 1;
				name = "Bananarang";
				shootSpeed = 14f;
				shoot = 272;
				damage = 40;
				knockBack = 8.5f;
				width = 14;
				height = 28;
				useSound = 1;
				useAnimation = 8;
				useTime = 8;
				noUseGraphic = true;
				rare = 5;
				value = 75000;
				melee = true;
				maxStack = 10;
				return;
			case 1325:
				autoReuse = false;
				name = "Chain Knife";
				useStyle = 5;
				useAnimation = 20;
				useTime = 20;
				knockBack = 3.5f;
				width = 30;
				height = 10;
				damage = 11;
				shoot = 273;
				shootSpeed = 12f;
				useSound = 1;
				rare = 2;
				value = 1000;
				melee = true;
				noUseGraphic = true;
				return;
			case 1326:
				autoReuse = false;
				name = "Rod of Discord";
				useStyle = 1;
				useAnimation = 20;
				useTime = 20;
				width = 20;
				height = 20;
				useSound = 8;
				rare = 7;
				value = sellPrice(0, 10);
				toolTip = "Teleports to a new location";
				return;
			case 1327:
				autoReuse = true;
				name = "Death Sickle";
				useStyle = 1;
				useAnimation = 25;
				useTime = 25;
				knockBack = 7f;
				width = 24;
				height = 28;
				damage = 57;
				scale = 1.15f;
				useSound = 1;
				rare = 6;
				shoot = 274;
				shootSpeed = 9f;
				value = 250000;
				toolTip = "Shoots a deathly sickle";
				melee = true;
				return;
			case 1328:
				name = "Turtle Scale";
				width = 14;
				height = 18;
				maxStack = 99;
				rare = 7;
				value = 5000;
				return;
			case 1329:
				name = "Tissue Sample";
				width = 14;
				height = 18;
				maxStack = 99;
				rare = 1;
				value = 750;
				return;
			case 1330:
				name = "Vertebrae";
				width = 18;
				height = 20;
				maxStack = 99;
				value = 12;
				return;
			case 1331:
				useStyle = 4;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				name = "Bloody Spine";
				width = 28;
				height = 28;
				maxStack = 20;
				toolTip = "Summons the Brain of Cthulhu";
				return;
			case 1332:
				name = "Ichor";
				width = 12;
				height = 14;
				maxStack = 99;
				value = 4500;
				rare = 3;
				toolTip = "'The blood of gods'";
				return;
			case 1333:
				flame = true;
				name = "Ichor Torch";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				holdStyle = 1;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 4;
				placeStyle = 11;
				width = 10;
				height = 12;
				value = 330;
				rare = 1;
				toolTip = "Can be placed in water";
				return;
			case 1334:
				name = "Ichor Arrow";
				shootSpeed = 4.25f;
				shoot = 278;
				damage = 15;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = 1;
				knockBack = 3f;
				value = 80;
				ranged = true;
				rare = 3;
				toolTip = "Decreases target's defense";
				return;
			case 1335:
				name = "Ichor Bullet";
				shootSpeed = 5.25f;
				shoot = 279;
				damage = 13;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 14;
				knockBack = 4f;
				value = 30;
				ranged = true;
				rare = 3;
				toolTip = "Decreases target's defense";
				return;
			case 1336:
				mana = 7;
				autoReuse = true;
				name = "Golden Shower";
				useStyle = 5;
				useAnimation = 18;
				useTime = 6;
				knockBack = 4f;
				width = 38;
				height = 10;
				damage = 22;
				shoot = 280;
				shootSpeed = 10f;
				useSound = 13;
				rare = 4;
				value = 500000;
				toolTip = "Sprays out a shower of ichor";
				magic = true;
				noMelee = true;
				return;
			case 1337:
				name = "Bunny Cannon";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 209;
				placeStyle = 1;
				width = 12;
				height = 12;
				value = buyPrice(0, 50);
				return;
			case 1338:
				name = "Explosive Bunny";
				useStyle = 1;
				useTurn = true;
				useAnimation = 20;
				useTime = 20;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				damage = 350;
				noMelee = true;
				value = buyPrice(0, 0, 35);
				return;
			case 1339:
				name = "Vial of Venom";
				width = 12;
				height = 20;
				maxStack = 99;
				value = buyPrice(0, 0, 10);
				return;
			case 1340:
				name = "Flask of Venom";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 71;
				buffTime = 54000;
				toolTip = "Melee attacks inflict venom on enemies";
				value = sellPrice(0, 0, 5);
				rare = 4;
				return;
			case 1341:
				name = "Venom Arrow";
				shootSpeed = 4.3f;
				shoot = 282;
				damage = 17;
				width = 10;
				height = 28;
				maxStack = 999;
				consumable = true;
				ammo = 1;
				knockBack = 4.2f;
				value = 90;
				ranged = true;
				rare = 3;
				toolTip = "Inflicts target with venom";
				return;
			case 1342:
				name = "Venom Bullet";
				shootSpeed = 5.3f;
				shoot = 283;
				damage = 14;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 14;
				knockBack = 4.1f;
				value = 40;
				ranged = true;
				rare = 3;
				toolTip = "Inflicts target with venom";
				return;
			case 1343:
				name = "Fire Gauntlet";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Increases melee knockback and inflicts fire damage on attack";
				toolTip = "9% increased melee damage and speed";
				value = 300000;
				handOffSlot = 1;
				handOnSlot = 6;
				return;
			case 1344:
				name = "Cog";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 272;
				width = 12;
				height = 12;
				value = buyPrice(0, 0, 7);
				return;
			case 1345:
				name = "Confetti";
				width = 12;
				height = 20;
				maxStack = 99;
				value = buyPrice(0, 0, 1);
				return;
			case 1346:
				name = "Nanites";
				width = 12;
				height = 20;
				maxStack = 99;
				value = buyPrice(0, 0, 10);
				return;
			case 1347:
				name = "Explosive Powder";
				width = 12;
				height = 20;
				maxStack = 99;
				value = buyPrice(0, 0, 12);
				return;
			case 1348:
				name = "Gold Dust";
				width = 12;
				height = 20;
				maxStack = 99;
				value = buyPrice(0, 0, 17);
				return;
			case 1349:
				name = "Party Bullet";
				shootSpeed = 5.1f;
				shoot = 284;
				damage = 10;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 14;
				knockBack = 5f;
				value = 40;
				ranged = true;
				rare = 3;
				toolTip = "Explodes into confetti on impact";
				return;
			case 1350:
				name = "Nano Bullet";
				shootSpeed = 4.6f;
				shoot = 285;
				damage = 10;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 14;
				knockBack = 3.6f;
				value = 40;
				ranged = true;
				rare = 3;
				toolTip = "Causes confusion";
				return;
			case 1351:
				name = "Exploding Bullet";
				shootSpeed = 4.7f;
				shoot = 286;
				damage = 10;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 14;
				knockBack = 6.6f;
				value = 40;
				ranged = true;
				rare = 3;
				toolTip = "Explodes on impact";
				return;
			case 1352:
				name = "Golden Bullet";
				shootSpeed = 4.6f;
				shoot = 287;
				damage = 10;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 14;
				knockBack = 3.6f;
				value = 40;
				ranged = true;
				rare = 3;
				toolTip = "Enemies killed will drop more money";
				return;
			case 1353:
				name = "Flask of Cursed Flames";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 73;
				buffTime = 54000;
				value = sellPrice(0, 0, 5);
				rare = 4;
				return;
			case 1354:
				name = "Flask of Fire";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 74;
				buffTime = 54000;
				value = sellPrice(0, 0, 5);
				rare = 4;
				return;
			case 1355:
				name = "Flask of Gold";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 75;
				buffTime = 54000;
				value = sellPrice(0, 0, 5);
				rare = 4;
				return;
			case 1356:
				name = "Flask of Ichor";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 76;
				buffTime = 54000;
				value = sellPrice(0, 0, 5);
				rare = 4;
				return;
			case 1357:
				name = "Flask of Nanites";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 77;
				buffTime = 54000;
				value = sellPrice(0, 0, 5);
				rare = 4;
				return;
			case 1358:
				name = "Flask of Party";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 78;
				buffTime = 54000;
				value = sellPrice(0, 0, 5);
				rare = 4;
				return;
			case 1359:
				name = "Flask of Poison";
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				buffType = 79;
				buffTime = 54000;
				value = sellPrice(0, 0, 5);
				rare = 4;
				return;
			case 1360:
				name = "Eye of Cthulhu Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				placeStyle = 0;
				rare = 1;
				return;
			case 1361:
				name = "Eater of Worlds Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				placeStyle = 1;
				rare = 1;
				return;
			case 1362:
				name = "Brain of Cthulhu Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				placeStyle = 2;
				rare = 1;
				return;
			case 1363:
				name = "Skeletron Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				placeStyle = 3;
				rare = 1;
				return;
			case 1364:
				name = "Queen Bee Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				placeStyle = 4;
				rare = 1;
				return;
			case 1365:
				name = "Wall of Flesh Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				placeStyle = 5;
				rare = 1;
				return;
			case 1366:
				name = "Destroyer Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				placeStyle = 6;
				rare = 1;
				return;
			case 1367:
				name = "Skeletron Prime Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				placeStyle = 7;
				rare = 1;
				return;
			case 1368:
				name = "Retinazer Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				placeStyle = 8;
				rare = 1;
				return;
			case 1369:
				name = "Spazmatism Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				placeStyle = 9;
				rare = 1;
				return;
			case 1370:
				name = "Plantera Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				placeStyle = 10;
				rare = 1;
				return;
			case 1371:
				name = "Golem Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				placeStyle = 11;
				rare = 1;
				return;
			case 1372:
				name = "Blood Moon Rising";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 12;
				return;
			case 1373:
				name = "The Hanged Man";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 13;
				return;
			case 1374:
				name = "Glory of the Fire";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 14;
				return;
			case 1375:
				name = "Bone Warp";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 15;
				return;
			case 1376:
				name = "Wall Skeleton";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				placeStyle = 16;
				return;
			case 1377:
				name = "Hanging Skeleton";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				placeStyle = 17;
				return;
			case 1378:
				name = "Blue Slab Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 100;
				width = 12;
				height = 12;
				return;
			case 1379:
				name = "Blue Tiled Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 101;
				width = 12;
				height = 12;
				return;
			case 1380:
				name = "Pink Slab Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 102;
				width = 12;
				height = 12;
				return;
			case 1381:
				name = "Pink Tiled Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 103;
				width = 12;
				height = 12;
				return;
			case 1382:
				name = "Green Slab Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 104;
				width = 12;
				height = 12;
				return;
			case 1383:
				name = "Green Tiled Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 105;
				width = 12;
				height = 12;
				return;
			case 1384:
				name = "Blue Brick Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 6;
				width = 8;
				height = 10;
				return;
			case 1385:
				name = "Pink Brick Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 7;
				width = 8;
				height = 10;
				return;
			case 1386:
				name = "Green Brick Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 8;
				width = 8;
				height = 10;
				return;
			case 1387:
				name = "Dungeon Shelf 1";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 9;
				width = 8;
				height = 10;
				return;
			case 1388:
				name = "Dungeon Shelf 2";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 10;
				width = 8;
				height = 10;
				return;
			case 1389:
				name = "Dungeon Shelf 3";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 11;
				width = 8;
				height = 10;
				return;
			case 1390:
				name = "Lantern 1";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 1;
				return;
			case 1391:
				name = "Lantern 2";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 2;
				return;
			case 1392:
				name = "Lantern 3";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 3;
				return;
			case 1393:
				name = "Lantern 4";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 4;
				return;
			case 1394:
				name = "Lantern 5";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 5;
				return;
			case 1395:
				name = "Lantern 6";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 6;
				return;
			case 1396:
				name = "Blue Dungeon Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 13;
				width = 12;
				height = 30;
				return;
			case 1397:
				name = "Blue Dungeon Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 10;
				width = 26;
				height = 20;
				value = 300;
				return;
			case 1398:
				name = "Blue Dungeon Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 11;
				width = 28;
				height = 14;
				value = 150;
				return;
			case 1399:
				name = "Green Dungeon Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 14;
				width = 12;
				height = 30;
				return;
			case 1400:
				name = "Green Dungeon Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 11;
				width = 26;
				height = 20;
				value = 300;
				return;
			case 1401:
				name = "Green Dungeon Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 12;
				width = 28;
				height = 14;
				value = 150;
				return;
			case 1402:
				name = "Pink Dungeon Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 15;
				width = 12;
				height = 30;
				return;
			case 1403:
				name = "Pink Dungeon Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 12;
				width = 26;
				height = 20;
				value = 300;
				return;
			case 1404:
				name = "Pink Dungeon Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 13;
				width = 28;
				height = 14;
				value = 150;
				return;
			case 1405:
				noWet = true;
				name = "Blue Dungeon Candle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 33;
				width = 8;
				height = 18;
				placeStyle = 1;
				return;
			case 1406:
				noWet = true;
				name = "Green Dungeon Candle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 33;
				width = 8;
				height = 18;
				placeStyle = 2;
				return;
			case 1407:
				noWet = true;
				name = "Pink Dungeon Candle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 33;
				width = 8;
				height = 18;
				placeStyle = 3;
				return;
			case 1408:
				name = "Blue Dungeon Vase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 46;
				return;
			case 1409:
				name = "Green Dungeon Vase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 47;
				return;
			case 1410:
				name = "Pink Dungeon Vase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 48;
				return;
			case 1411:
				name = "Blue Dungeon Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 16;
				width = 14;
				height = 28;
				value = 200;
				return;
			case 1412:
				name = "Green Dungeon Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 17;
				width = 14;
				height = 28;
				value = 200;
				return;
			case 1413:
				name = "Pink Dungeon Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 18;
				width = 14;
				height = 28;
				value = 200;
				return;
			case 1414:
				name = "Blue Dungeon Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 1;
				return;
			case 1415:
				name = "Green Dungeon Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 2;
				return;
			case 1416:
				name = "Pink Dungeon Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 3;
				return;
			case 1417:
				name = "Catacomb";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 241;
				placeStyle = 0;
				width = 30;
				height = 30;
				return;
			case 1418:
				name = "Dungeon Shelf 4";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 12;
				width = 8;
				height = 10;
				return;
			case 1419:
				name = "Skellington J Skellingsworth";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 18;
				return;
			case 1420:
				name = "The Cursed Man";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 19;
				return;
			case 1421:
				name = "The Eye Sees the End";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 0;
				return;
			case 1422:
				name = "Something Evil is Watching You";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 1;
				return;
			case 1423:
				name = "The Twins Have Awoken";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 2;
				return;
			case 1424:
				name = "The Screamer";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 3;
				return;
			case 1425:
				name = "Goblins Playing Poker";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 4;
				return;
			case 1426:
				name = "Dryadisque";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 5;
				return;
			case 1427:
				name = "Sunflowers";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 20;
				return;
			case 1428:
				name = "Terrarian Gothic";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 21;
				return;
			case 1429:
				name = "Beanie";
				width = 18;
				height = 18;
				headSlot = 100;
				vanity = true;
				value = buyPrice(0, 1);
				return;
			case 1430:
				name = "Imbuing Station";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 243;
				width = 26;
				height = 20;
				value = buyPrice(0, 7);
				rare = 2;
				return;
			case 1431:
				name = "Star in a Bottle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 7;
				return;
			case 1432:
				name = "Empty Bullet";
				width = 12;
				height = 20;
				maxStack = 999;
				value = buyPrice(0, 0, 0, 3);
				return;
			case 1433:
				name = "Impact";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 6;
				return;
			case 1434:
				name = "Powered by Birds";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 7;
				return;
			case 1435:
				name = "The Destroyer";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 8;
				return;
			case 1436:
				name = "The Persistency of Eyes";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 9;
				return;
			case 1437:
				name = "Unicorn Crossing the Hallows";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 10;
				return;
			case 1438:
				name = "Great Wave";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 11;
				return;
			case 1439:
				name = "Starry Night";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 12;
				return;
			case 1440:
				name = "Guide Picasso";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 22;
				return;
			case 1441:
				name = "The Guardian's Gaze";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 23;
				return;
			case 1442:
				name = "Father of Someone";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 24;
				return;
			case 1443:
				name = "Nurse Lisa";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 25;
				return;
			case 1444:
				name = "Shadowbeam Staff";
				mana = 7;
				useSound = 8;
				useStyle = 5;
				damage = 53;
				useAnimation = 16;
				useTime = 16;
				autoReuse = true;
				width = 40;
				height = 40;
				shoot = 294;
				shootSpeed = 6f;
				knockBack = 3.25f;
				value = sellPrice(0, 6);
				magic = true;
				rare = 8;
				noMelee = true;
				return;
			case 1445:
				name = "Inferno Fork";
				mana = 18;
				useSound = 45;
				useStyle = 5;
				damage = 65;
				useAnimation = 30;
				useTime = 30;
				width = 40;
				height = 40;
				shoot = 295;
				shootSpeed = 8f;
				knockBack = 8f;
				value = sellPrice(0, 6);
				magic = true;
				noMelee = true;
				rare = 8;
				return;
			case 1446:
				name = "Spectre Staff";
				mana = 11;
				useSound = 43;
				useStyle = 5;
				damage = 68;
				autoReuse = true;
				useAnimation = 24;
				useTime = 24;
				width = 40;
				height = 40;
				shoot = 297;
				shootSpeed = 6f;
				knockBack = 6f;
				value = sellPrice(0, 6);
				magic = true;
				noMelee = true;
				rare = 8;
				return;
			case 1447:
				name = "Wooden Fence";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 106;
				width = 12;
				height = 12;
				return;
			case 1448:
				name = "Lead Fence";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 107;
				width = 12;
				height = 12;
				return;
			case 1449:
				name = "Bubble Machine";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 244;
				width = 26;
				height = 20;
				value = buyPrice(0, 4);
				rare = 1;
				return;
			case 1450:
				name = "Bubble Wand";
				useStyle = 1;
				autoReuse = true;
				useTurn = false;
				useAnimation = 25;
				useTime = 25;
				width = 24;
				height = 28;
				scale = 1f;
				value = buyPrice(0, 5);
				noMelee = true;
				rare = 1;
				return;
			case 1451:
				name = "Marching Bones Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 10;
				width = 10;
				height = 24;
				value = 1000;
				return;
			case 1452:
				name = "Necromantic Sign";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 11;
				width = 10;
				height = 24;
				value = 1000;
				return;
			case 1453:
				name = "Rusted Company Standard";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 12;
				width = 10;
				height = 24;
				value = 1000;
				return;
			case 1454:
				name = "Ragged Brotherhood Sigil";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 13;
				width = 10;
				height = 24;
				value = 1000;
				return;
			case 1455:
				name = "Molten Legion Flag";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 14;
				width = 10;
				height = 24;
				value = 1000;
				return;
			case 1456:
				name = "Diabolic Sigil";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 15;
				width = 10;
				height = 24;
				value = 1000;
				return;
			case 1457:
				name = "Obsidian Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 13;
				width = 8;
				height = 10;
				return;
			case 1458:
				name = "Obsidian Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 19;
				width = 14;
				height = 28;
				value = 200;
				return;
			case 1459:
				name = "Obsidian Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 16;
				width = 12;
				height = 30;
				return;
			case 1460:
				name = "Obsidian Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 13;
				width = 26;
				height = 20;
				value = 300;
				return;
			case 1461:
				name = "Obsidian Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 14;
				width = 28;
				height = 14;
				value = 150;
				return;
			case 1462:
				name = "Obsidian Vase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 105;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 49;
				return;
			case 1463:
				name = "Obsidian Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 4;
				return;
			case 1464:
				name = "Hellbound Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 16;
				width = 10;
				height = 24;
				value = 1000;
				return;
			case 1465:
				name = "Hell Hammer Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 17;
				width = 10;
				height = 24;
				value = 1000;
				return;
			case 1466:
				name = "Helltower Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 18;
				width = 10;
				height = 24;
				value = 1000;
				return;
			case 1467:
				name = "Lost Hopes of Man Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 19;
				width = 10;
				height = 24;
				value = 1000;
				return;
			case 1468:
				name = "Obsidian Watcher Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 20;
				width = 10;
				height = 24;
				value = 1000;
				return;
			case 1469:
				name = "Lava Erupts Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 21;
				width = 10;
				height = 24;
				value = 1000;
				return;
			case 1470:
				name = "Blue Dungeon Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 5;
				width = 28;
				height = 20;
				value = 2000;
				return;
			case 1471:
				name = "Green Dungeon Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 6;
				width = 28;
				height = 20;
				value = 2000;
				return;
			case 1472:
				name = "Red Dungeon Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 7;
				width = 28;
				height = 20;
				value = 2000;
				return;
			case 1473:
				name = "Obsidian Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 8;
				width = 28;
				height = 20;
				value = 2000;
				return;
			case 1474:
			case 1475:
			case 1476:
			case 1477:
			case 1478:
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 245;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = type - 1474;
				return;
			}
			if (type >= 1479 && type <= 1494)
			{
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 246;
				width = 30;
				height = 30;
				if (type >= 1481 && type <= 1494)
				{
					value = buyPrice(0, 1);
				}
				else
				{
					value = sellPrice(0, 0, 10);
				}
				placeStyle = type - 1479;
				return;
			}
			switch (type)
			{
			case 1495:
				name = "American Explosive";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 245;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 5;
				return;
			case 1496:
			case 1497:
			case 1498:
			case 1499:
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 26 + type - 1496;
				return;
			}
			if (type >= 1500 && type <= 1502)
			{
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 13 + type - 1500;
				return;
			}
			switch (type)
			{
			case 1503:
				name = "Spectre Hood";
				width = 18;
				height = 18;
				defense = 6;
				headSlot = 101;
				rare = 8;
				value = 375000;
				toolTip = "40% decreased magic damage";
				return;
			case 1504:
				name = "Spectre Robe";
				width = 18;
				height = 18;
				defense = 14;
				bodySlot = 66;
				rare = 8;
				value = 300000;
				toolTip = "7% increased magic damage and critical strike chance";
				return;
			case 1505:
				name = "Spectre Pants";
				width = 18;
				height = 18;
				defense = 10;
				legSlot = 55;
				rare = 8;
				value = 225000;
				toolTip = "8% increased magic damage";
				toolTip2 = "8% increased movement speed";
				return;
			case 1506:
				name = "Spirit Pickaxe";
				useStyle = 1;
				useAnimation = 24;
				useTime = 10;
				knockBack = 5.25f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 32;
				pick = 200;
				useSound = 1;
				rare = 8;
				value = 216000;
				melee = true;
				scale = 1.15f;
				tileBoost += 3;
				return;
			case 1507:
				name = "Spirit Hamaxe";
				useTurn = true;
				autoReuse = true;
				useStyle = 1;
				useAnimation = 28;
				useTime = 8;
				knockBack = 7f;
				width = 20;
				height = 12;
				damage = 60;
				axe = 23;
				hammer = 90;
				useSound = 1;
				rare = 8;
				value = 216000;
				melee = true;
				scale = 1.05f;
				tileBoost += 3;
				return;
			case 1508:
				name = "Ectoplasm";
				maxStack = 99;
				width = 16;
				height = 14;
				value = sellPrice(0, 0, 50);
				rare = 8;
				return;
			case 1509:
				name = "Gothic Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 17;
				width = 12;
				height = 30;
				return;
			case 1510:
				name = "Gothic Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 14;
				width = 26;
				height = 20;
				value = 300;
				return;
			case 1511:
				name = "Gothic Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 15;
				width = 28;
				height = 14;
				value = 150;
				return;
			case 1512:
				name = "Gothic Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 5;
				return;
			case 1513:
				noMelee = true;
				useStyle = 1;
				name = "Paladin's Hammer";
				shootSpeed = 14f;
				shoot = 301;
				damage = 90;
				knockBack = 9f;
				width = 14;
				height = 28;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 8;
				value = sellPrice(0, 10);
				melee = true;
				return;
			case 1514:
				name = "SWAT Helmet";
				width = 18;
				height = 18;
				headSlot = 102;
				rare = 1;
				value = sellPrice(0, 1);
				vanity = true;
				return;
			case 1515:
				name = "Bee Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 15;
				return;
			case 1516:
			case 1517:
			case 1518:
			case 1519:
			case 1520:
			case 1521:
				name = "Feather";
				maxStack = 99;
				width = 16;
				height = 14;
				value = sellPrice(0, 2, 50);
				rare = 5;
				return;
			}
			if (type >= 1522 && type <= 1527)
			{
				name = "Large Gem";
				width = 20;
				height = 20;
				rare = 1;
				return;
			}
			if (type >= 1528 && type <= 1532)
			{
				name = "Dungeon Chest";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 21;
				placeStyle = 18 + type - 1528;
				width = 26;
				height = 22;
				value = 2500;
				return;
			}
			if (type >= 1533 && type <= 1537)
			{
				name = "Dungeon Key";
				width = 14;
				height = 20;
				maxStack = 99;
				rare = 8;
				return;
			}
			if (type >= 1538 && type <= 1540)
			{
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 30 + type - 1538;
				return;
			}
			if (type >= 1541 && type <= 1542)
			{
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 246;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 16 + type - 1541;
				return;
			}
			if (type >= 1543 && type <= 1545)
			{
				name = "Spectre Paintbrush";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				width = 24;
				height = 24;
				value = 10000;
				tileBoost += 3;
				return;
			}
			switch (type)
			{
			case 1546:
				name = "Shroomite Headgear";
				width = 18;
				height = 18;
				defense = 11;
				headSlot = 103;
				rare = 8;
				value = 375000;
				toolTip = "15% increased arrow damage";
				toolTip2 = "5% ranged critical strike chance";
				return;
			case 1547:
				name = "Shroomite Mask";
				width = 18;
				height = 18;
				defense = 11;
				headSlot = 104;
				rare = 8;
				value = 375000;
				toolTip = "15% increased bullet damage";
				toolTip2 = "5% ranged critical strike chance";
				return;
			case 1548:
				name = "Shroomite Helmet";
				width = 18;
				height = 18;
				defense = 11;
				headSlot = 105;
				rare = 8;
				value = 375000;
				toolTip = "15% increased rocket damage";
				toolTip2 = "5% ranged critical strike chance";
				return;
			case 1549:
				name = "Shroomite Breastplate";
				width = 18;
				height = 18;
				defense = 24;
				bodySlot = 67;
				rare = 8;
				value = 300000;
				toolTip = "13% increased ranged critical strike chance";
				toolTip2 = "20% chance to not consume ammo";
				return;
			case 1550:
				name = "Shroomite Leggings";
				width = 18;
				height = 18;
				defense = 16;
				legSlot = 56;
				rare = 8;
				value = 225000;
				toolTip = "7% increased ranged critical strike chance";
				toolTip2 = "12% increased movement speed";
				return;
			case 1551:
				name = "Autohammer";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 247;
				width = 26;
				height = 24;
				value = buyPrice(1);
				toolTip = "Converts Chlorophyte Bars into Shroomite Bars";
				return;
			case 1552:
				name = "Shroomite Bar";
				width = 20;
				height = 20;
				maxStack = 99;
				rare = 7;
				value = sellPrice(0, 1);
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 239;
				placeStyle = 20;
				return;
			case 1553:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 6;
				useTime = 6;
				name = "S.D.M.G.";
				crit += 5;
				width = 60;
				height = 26;
				shoot = 10;
				useAmmo = 14;
				useSound = 11;
				damage = 35;
				shootSpeed = 12f;
				noMelee = true;
				value = 750000;
				rare = 8;
				toolTip = "50% chance to not consume ammo";
				toolTip2 = "'Space Dolphin Machine Gun'";
				knockBack = 2.5f;
				ranged = true;
				return;
			case 1554:
				name = "Cenx's Tiara";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				headSlot = 106;
				return;
			case 1555:
				name = "Cenx's Breastplate";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 68;
				return;
			case 1556:
				name = "Cenx's Leggings";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 57;
				return;
			case 1557:
				name = "Crowno's Mask";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				headSlot = 107;
				return;
			case 1558:
				name = "Crowno's Breastplate";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 69;
				return;
			case 1559:
				name = "Crowno's Leggings";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 58;
				return;
			case 1560:
				name = "Will's Helmet";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				headSlot = 108;
				return;
			case 1561:
				name = "Will's Breastplate";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 70;
				return;
			case 1562:
				name = "Will's Leggings";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 59;
				return;
			case 1563:
				name = "Jim's Helmet";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				headSlot = 109;
				return;
			case 1564:
				name = "Jim's Breastplate";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 71;
				return;
			case 1565:
				name = "Jim's Leggings";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 60;
				return;
			case 1566:
				name = "Aaron's Helmet";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				headSlot = 110;
				return;
			case 1567:
				name = "Aaron's Breastplate";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 72;
				return;
			case 1568:
				name = "Aaron's Leggings";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 61;
				return;
			case 1569:
				autoReuse = true;
				useStyle = 1;
				name = "Vampire Knives";
				shootSpeed = 15f;
				shoot = 304;
				damage = 29;
				width = 18;
				height = 20;
				useSound = 39;
				useAnimation = 16;
				useTime = 16;
				noUseGraphic = true;
				noMelee = true;
				value = sellPrice(0, 20);
				knockBack = 2.75f;
				melee = true;
				rare = 8;
				toolTip = "Rapidly shoot life stealing daggers";
				return;
			case 1570:
				name = "Broken Hero Sword";
				width = 14;
				height = 18;
				maxStack = 99;
				rare = 8;
				value = sellPrice(0, 2);
				return;
			case 1571:
				autoReuse = true;
				useStyle = 5;
				name = "Eater's Bite";
				shootSpeed = 14f;
				shoot = 306;
				damage = 64;
				width = 18;
				height = 20;
				useSound = 39;
				useAnimation = 20;
				useTime = 20;
				noUseGraphic = true;
				noMelee = true;
				value = sellPrice(0, 20);
				knockBack = 5f;
				melee = true;
				rare = 8;
				return;
			case 1572:
				name = "Hydra Staff";
				useStyle = 1;
				shootSpeed = 14f;
				shoot = 308;
				damage = 100;
				width = 18;
				height = 20;
				useSound = 1;
				useAnimation = 30;
				useTime = 30;
				noMelee = true;
				value = sellPrice(0, 20);
				knockBack = 7.5f;
				rare = 8;
				summon = true;
				mana = 20;
				return;
			case 1573:
				name = "The Creation of the Guide";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 16;
				return;
			case 1574:
			case 1575:
			case 1576:
				name = "Picture";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 33 + type - 1574;
				return;
			}
			switch (type)
			{
			case 1577:
				name = "Glorious Night";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 245;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 6;
				return;
			case 1578:
				name = "Sweetheart Necklace";
				width = 22;
				height = 22;
				accessory = true;
				rare = 3;
				toolTip = "Releases bees and increases movement speed when damaged";
				value = 200000;
				neckSlot = 6;
				return;
			case 1579:
				name = "Flurry Boots";
				width = 28;
				height = 24;
				accessory = true;
				rare = 1;
				toolTip = "The wearer can run super fast";
				value = 50000;
				shoeSlot = 5;
				return;
			case 1580:
				name = "D-Town's Helmet";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				headSlot = 111;
				return;
			case 1581:
				name = "D-Town's Breastplate";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 73;
				return;
			case 1582:
				name = "D-Town's Leggings";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 62;
				return;
			case 1583:
				name = "D-Town's Wings";
				width = 24;
				height = 8;
				accessory = true;
				rare = 9;
				wingSlot = 16;
				return;
			case 1584:
				name = "Will's Wings";
				width = 24;
				height = 8;
				accessory = true;
				rare = 9;
				wingSlot = 17;
				return;
			case 1585:
				name = "Crowno's Wings";
				width = 24;
				height = 8;
				accessory = true;
				rare = 9;
				wingSlot = 18;
				return;
			case 1586:
				name = "Cenx's Wings";
				width = 24;
				height = 8;
				accessory = true;
				rare = 9;
				wingSlot = 19;
				return;
			case 1587:
				name = "Cenx's Dress";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				bodySlot = 74;
				return;
			case 1588:
				name = "Cenx's Dress Pants";
				width = 18;
				height = 18;
				rare = 9;
				vanity = true;
				legSlot = 63;
				return;
			case 1589:
				name = "Palladium Column";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 248;
				width = 12;
				height = 12;
				return;
			case 1590:
				name = "Palladium Column Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 109;
				width = 12;
				height = 12;
				return;
			case 1591:
				name = "Bubblegum Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 249;
				width = 12;
				height = 12;
				return;
			case 1592:
				name = "Bubblegum Block Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 110;
				width = 12;
				height = 12;
				return;
			case 1593:
				name = "Titanstone Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 250;
				width = 12;
				height = 12;
				return;
			case 1594:
				name = "Titanstone Block Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 111;
				width = 12;
				height = 12;
				return;
			case 1595:
				name = "Magic Cuffs";
				width = 22;
				height = 22;
				accessory = true;
				rare = 2;
				toolTip = "Increases maximum mana by 20";
				toolTip2 = "Restores mana when damaged";
				value = 100000;
				handOffSlot = 3;
				handOnSlot = 8;
				return;
			case 1596:
			case 1597:
			case 1598:
			case 1599:
			case 1600:
			case 1601:
			case 1602:
			case 1603:
			case 1604:
			case 1605:
			case 1606:
			case 1607:
			case 1608:
			case 1609:
			case 1610:
				name = "Music Box";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = type - 1596 + 13;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			}
			switch (type)
			{
			case 1611:
				name = "Butterfly Dust";
				maxStack = 99;
				width = 16;
				height = 14;
				value = sellPrice(0, 2, 50);
				rare = 5;
				return;
			case 1612:
				name = "Ankh Charm";
				width = 16;
				height = 24;
				accessory = true;
				rare = 6;
				toolTip = "Grants immunity to most debuffs";
				value = sellPrice(0, 3);
				return;
			case 1613:
				name = "Ankh Shield";
				width = 24;
				height = 28;
				rare = 7;
				value = sellPrice(0, 5);
				accessory = true;
				defense = 4;
				toolTip = "Grants immunity to knockback and fire blocks";
				toolTip2 = "Grants immunity to most debuffs";
				shieldSlot = 4;
				return;
			case 1614:
				name = "Blue Flare";
				shootSpeed = 6f;
				shoot = 310;
				damage = 1;
				width = 12;
				height = 12;
				maxStack = 999;
				consumable = true;
				ammo = 931;
				knockBack = 1.5f;
				value = 7;
				ranged = true;
				return;
			case 1615:
			case 1616:
			case 1617:
			case 1618:
			case 1619:
			case 1620:
			case 1621:
			case 1622:
			case 1623:
			case 1624:
			case 1625:
			case 1626:
			case 1627:
			case 1628:
			case 1629:
			case 1630:
			case 1631:
			case 1632:
			case 1633:
			case 1634:
			case 1635:
			case 1636:
			case 1637:
			case 1638:
			case 1639:
			case 1640:
			case 1641:
			case 1642:
			case 1643:
			case 1644:
			case 1645:
			case 1646:
			case 1647:
			case 1648:
			case 1649:
			case 1650:
			case 1651:
			case 1652:
			case 1653:
			case 1654:
			case 1655:
			case 1656:
			case 1657:
			case 1658:
			case 1659:
			case 1660:
			case 1661:
			case 1662:
			case 1663:
			case 1664:
			case 1665:
			case 1666:
			case 1667:
			case 1668:
			case 1669:
			case 1670:
			case 1671:
			case 1672:
			case 1673:
			case 1674:
			case 1675:
			case 1676:
			case 1677:
			case 1678:
			case 1679:
			case 1680:
			case 1681:
			case 1682:
			case 1683:
			case 1684:
			case 1685:
			case 1686:
			case 1687:
			case 1688:
			case 1689:
			case 1690:
			case 1691:
			case 1692:
			case 1693:
			case 1694:
			case 1695:
			case 1696:
			case 1697:
			case 1698:
			case 1699:
			case 1700:
			case 1701:
				name = "Monster Banner";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 91;
				placeStyle = 22 + type - 1615;
				width = 10;
				height = 24;
				value = 1000;
				rare = 1;
				return;
			}
			switch (type)
			{
			case 1702:
				name = "Glass Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 14;
				width = 8;
				height = 10;
				return;
			case 1703:
			case 1704:
			case 1705:
			case 1706:
			case 1707:
			case 1708:
				name = "Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 18 + type - 1703;
				width = 12;
				height = 30;
				return;
			}
			if (type >= 1709 && type <= 1712)
			{
				name = "Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 20 + type - 1709;
				width = 14;
				height = 28;
				value = 200;
				return;
			}
			if (type >= 1713 && type <= 1718)
			{
				name = "Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 15 + type - 1713;
				width = 26;
				height = 20;
				value = 300;
				return;
			}
			if (type >= 1719 && type <= 1722)
			{
				name = "Bed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 79;
				placeStyle = 9 + type - 1719;
				width = 28;
				height = 20;
				value = 2000;
				return;
			}
			switch (type)
			{
			case 1723:
				name = "Living Wood Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 78;
				width = 12;
				height = 12;
				return;
			case 1724:
				name = "Fart in a Jar";
				width = 16;
				height = 24;
				accessory = true;
				rare = 2;
				toolTip = "Allows the holder to double jump";
				value = 75000;
				return;
			case 1725:
				name = "Pumpkin";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 251;
				width = 8;
				height = 10;
				return;
			case 1726:
				name = "Pumpkin Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 113;
				width = 12;
				height = 12;
				return;
			case 1727:
				name = "Hay";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 252;
				width = 8;
				height = 10;
				return;
			case 1728:
				name = "Hay Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 114;
				width = 12;
				height = 12;
				return;
			case 1729:
				name = "Spooky Wood";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 253;
				width = 8;
				height = 10;
				return;
			case 1730:
				name = "Spooky Wood Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 115;
				width = 12;
				height = 12;
				return;
			case 1731:
				name = "Pumpkin Helmet";
				width = 18;
				height = 18;
				defense = 2;
				headSlot = 112;
				return;
			case 1732:
				name = "Pumpkin Breastplate";
				width = 18;
				height = 18;
				defense = 3;
				bodySlot = 75;
				return;
			case 1733:
				name = "Pumpkin Leggings";
				width = 18;
				height = 18;
				defense = 2;
				legSlot = 64;
				return;
			case 1734:
				name = "Candy Apple";
				width = 12;
				height = 12;
				return;
			case 1735:
				name = "Soul Cake";
				width = 12;
				height = 12;
				return;
			case 1736:
				name = "Nurse Hat";
				width = 18;
				height = 18;
				headSlot = 113;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1737:
				name = "Nurse Shirt";
				width = 18;
				height = 18;
				bodySlot = 76;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1738:
				name = "Nurse Pants";
				width = 18;
				height = 18;
				legSlot = 65;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1739:
				name = "Wizard's Hat";
				width = 18;
				height = 18;
				headSlot = 114;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1740:
				name = "Guy Fawkes Mask";
				width = 18;
				height = 18;
				headSlot = 115;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1741:
				name = "Dye Trader Robe";
				width = 18;
				height = 18;
				bodySlot = 77;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1742:
				name = "Steampunk Goggles";
				width = 18;
				height = 18;
				headSlot = 116;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1743:
				name = "Cyborg Helmet";
				width = 18;
				height = 18;
				headSlot = 117;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1744:
				name = "Cyborg Shirt";
				width = 18;
				height = 18;
				bodySlot = 78;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1745:
				name = "Cyborg Pants";
				width = 18;
				height = 18;
				legSlot = 66;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1746:
				name = "Creeper Mask";
				width = 18;
				height = 18;
				headSlot = 118;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1747:
				name = "Creeper Shirt";
				width = 18;
				height = 18;
				bodySlot = 79;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1748:
				name = "Creeper Pants";
				width = 18;
				height = 18;
				legSlot = 67;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1749:
				name = "Cat Mask";
				width = 18;
				height = 18;
				headSlot = 119;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1750:
				name = "Cat Shirt";
				width = 18;
				height = 18;
				bodySlot = 80;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1751:
				name = "Cat Pants";
				width = 18;
				height = 18;
				legSlot = 68;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1752:
				name = "Ghost Mask";
				width = 18;
				height = 18;
				headSlot = 120;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1753:
				name = "Ghost Shirt";
				width = 18;
				height = 18;
				bodySlot = 81;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1754:
				name = "Pumpkin Mask";
				width = 18;
				height = 18;
				headSlot = 121;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1755:
				name = "Pumpkin Shirt";
				width = 18;
				height = 18;
				bodySlot = 82;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1756:
				name = "Pumpkin Pants";
				width = 18;
				height = 18;
				legSlot = 69;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1757:
				name = "Robot Mask";
				width = 18;
				height = 18;
				headSlot = 122;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1758:
				name = "Robot Shirt";
				width = 18;
				height = 18;
				bodySlot = 83;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1759:
				name = "Robot Pants";
				width = 18;
				height = 18;
				legSlot = 70;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1760:
				name = "Unicorn Mask";
				width = 18;
				height = 18;
				headSlot = 123;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1761:
				name = "Unicorn Shirt";
				width = 18;
				height = 18;
				bodySlot = 84;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1762:
				name = "Unicorn Pants";
				width = 18;
				height = 18;
				legSlot = 71;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1763:
				name = "Vampire Mask";
				width = 18;
				height = 18;
				headSlot = 124;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1764:
				name = "Vampire Shirt";
				width = 18;
				height = 18;
				bodySlot = 85;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1765:
				name = "Vampire Pants";
				width = 18;
				height = 18;
				legSlot = 72;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1766:
				name = "Witch Hat";
				width = 18;
				height = 18;
				headSlot = 125;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1767:
				name = "Leprechaun Hat";
				width = 18;
				height = 18;
				headSlot = 126;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1768:
				name = "Leprechaun Shirt";
				width = 18;
				height = 18;
				bodySlot = 86;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1769:
				name = "Leprechaun Pants";
				width = 18;
				height = 18;
				legSlot = 73;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1770:
				name = "Pixie Shirt";
				width = 18;
				height = 18;
				bodySlot = 87;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1771:
				name = "Pixie Pants";
				width = 18;
				height = 18;
				legSlot = 74;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1772:
				name = "Princess Hat";
				width = 18;
				height = 18;
				headSlot = 127;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1773:
				name = "Princess Dress";
				width = 18;
				height = 18;
				bodySlot = 88;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1774:
				name = "Goodie Bag";
				width = 12;
				height = 12;
				rare = 3;
				toolTip = "Right click to open";
				maxStack = 99;
				value = sellPrice(0, 1);
				return;
			case 1775:
				name = "Witch Dress";
				width = 18;
				height = 18;
				bodySlot = 89;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1776:
				name = "Witch Boots";
				width = 18;
				height = 18;
				legSlot = 75;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1777:
				name = "Bride of Frankenstein Mask";
				width = 18;
				height = 18;
				headSlot = 128;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1778:
				name = "Bride of Frankenstein Dress";
				width = 18;
				height = 18;
				bodySlot = 90;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1779:
				name = "Karate Tortoise Mask";
				width = 18;
				height = 18;
				headSlot = 129;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1780:
				name = "Karate Tortoise Shirt";
				width = 18;
				height = 18;
				bodySlot = 91;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1781:
				name = "Karate Tortoise Pants";
				width = 18;
				height = 18;
				legSlot = 76;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1782:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 9;
				useTime = 9;
				name = "Candy Corn Rifle";
				crit += 6;
				width = 60;
				height = 26;
				shoot = 311;
				useAmmo = 311;
				useSound = 11;
				damage = 44;
				shootSpeed = 10f;
				noMelee = true;
				value = 750000;
				rare = 8;
				knockBack = 2f;
				ranged = true;
				return;
			case 1783:
				name = "Candy Corn";
				shootSpeed = 4f;
				shoot = 311;
				damage = 9;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 311;
				knockBack = 1.5f;
				value = 5;
				ranged = true;
				return;
			case 1784:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 30;
				useTime = 30;
				name = "Jack 'O Lantern Launcher";
				crit += 6;
				width = 60;
				height = 26;
				shoot = 312;
				useAmmo = 312;
				useSound = 11;
				damage = 60;
				shootSpeed = 7f;
				noMelee = true;
				value = 750000;
				rare = 8;
				knockBack = 5f;
				ranged = true;
				return;
			case 1785:
				name = "Explosive Jack 'O Lanter";
				shootSpeed = 4f;
				shoot = 312;
				damage = 25;
				width = 8;
				height = 8;
				maxStack = 999;
				consumable = true;
				ammo = 312;
				knockBack = 3f;
				value = 15;
				ranged = true;
				return;
			case 1786:
				name = "Sickle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 23;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 7;
				useSound = 1;
				knockBack = 2.5f;
				value = buyPrice(0, 1);
				melee = true;
				return;
			case 1787:
				name = "Pumpkin Pie";
				useSound = 2;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 10;
				height = 10;
				buffType = 26;
				buffTime = 54000;
				rare = 1;
				toolTip = "Minor improvements to all stats";
				value = 1000;
				return;
			case 1788:
				name = "Scarecrow Hat";
				width = 18;
				height = 18;
				headSlot = 130;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1789:
				name = "Scarecrow Shirt";
				width = 18;
				height = 18;
				bodySlot = 92;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1790:
				name = "Scarecrow Pants";
				width = 18;
				height = 18;
				legSlot = 77;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1791:
				name = "Cauldron";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 96;
				placeStyle = 1;
				width = 20;
				height = 20;
				value = buyPrice(0, 1, 50);
				return;
			case 1792:
				name = "Pumpkin Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 24;
				width = 12;
				height = 30;
				return;
			case 1793:
				name = "Pumpkin Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 24;
				width = 14;
				height = 28;
				value = 200;
				return;
			case 1794:
				name = "Pumpkin Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 21;
				width = 26;
				height = 20;
				value = 300;
				return;
			case 1795:
				name = "Pumpkin Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 16;
				width = 28;
				height = 14;
				value = 150;
				return;
			case 1796:
				name = "Pumpkin Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 15;
				width = 8;
				height = 10;
				return;
			case 1797:
				name = "Tattered Fairy Wings";
				width = 24;
				height = 8;
				accessory = true;
				rare = 7;
				value = 400000;
				wingSlot = 20;
				return;
			case 1798:
				damage = 0;
				useStyle = 1;
				name = "Spider Egg";
				shoot = 313;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a pet spider";
				buffType = 81;
				value = sellPrice(0, 2);
				return;
			case 1799:
				damage = 0;
				useStyle = 1;
				name = "Magical Pumpkin Seed";
				shoot = 314;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a squashling";
				buffType = 82;
				value = sellPrice(0, 2);
				return;
			case 1800:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Bat Hook";
				shootSpeed = 15.5f;
				shoot = 315;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				value = sellPrice(0, 2);
				return;
			case 1801:
				name = "Bat Scepter";
				useStyle = 5;
				autoReuse = true;
				useAnimation = 12;
				useTime = 12;
				mana = 3;
				width = 50;
				height = 18;
				shoot = 316;
				useSound = 32;
				damage = 45;
				shootSpeed = 10f;
				noMelee = true;
				value = 500000;
				rare = 8;
				magic = true;
				knockBack = 3f;
				return;
			case 1802:
				mana = 10;
				damage = 37;
				useStyle = 1;
				name = "Raven Staff";
				shootSpeed = 10f;
				shoot = 317;
				width = 26;
				height = 28;
				useSound = 44;
				useAnimation = 28;
				useTime = 28;
				rare = 8;
				noMelee = true;
				knockBack = 3f;
				toolTip = "Summons a raven to fight for you";
				buffType = 83;
				value = 100000;
				summon = true;
				return;
			case 1803:
			case 1804:
			case 1805:
			case 1806:
			case 1807:
				name = "Dungeon Key Mold";
				width = 14;
				height = 20;
				maxStack = 99;
				rare = 8;
				return;
			}
			switch (type)
			{
			case 1808:
				name = "Hanging Jack 'O Lantern";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 8;
				return;
			case 1809:
				useStyle = 1;
				name = "Rotten Egg";
				shootSpeed = 9f;
				shoot = 318;
				damage = 10;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				useSound = 1;
				useAnimation = 19;
				useTime = 19;
				noUseGraphic = true;
				noMelee = true;
				ranged = true;
				knockBack = 6.5f;
				return;
			case 1810:
				damage = 0;
				useStyle = 1;
				name = "Unlucky Yarn";
				shoot = 319;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				buffType = 84;
				value = sellPrice(0, 2);
				return;
			case 1811:
				name = "Black Fairy Dust";
				maxStack = 99;
				width = 16;
				height = 14;
				value = sellPrice(0, 2, 50);
				rare = 5;
				return;
			case 1812:
				name = "Jackelier";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 6;
				width = 26;
				height = 26;
				return;
			case 1813:
				name = "Jack 'O Lantern";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 35;
				width = 26;
				height = 26;
				return;
			case 1814:
				name = "Spooky Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 25;
				width = 12;
				height = 30;
				return;
			case 1815:
				name = "Spooky Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 25;
				width = 14;
				height = 28;
				value = 200;
				return;
			case 1816:
				name = "Spooky Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 22;
				width = 26;
				height = 20;
				value = 300;
				return;
			case 1817:
				name = "Spooky Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 18;
				placeStyle = 17;
				width = 28;
				height = 14;
				value = 150;
				return;
			case 1818:
				name = "Spooky Platform";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 19;
				placeStyle = 16;
				width = 8;
				height = 10;
				return;
			case 1819:
				name = "Reaper Mask";
				width = 18;
				height = 18;
				headSlot = 131;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1820:
				name = "Reaper Robe";
				width = 18;
				height = 18;
				bodySlot = 93;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1821:
				name = "Fox Mask";
				width = 18;
				height = 18;
				headSlot = 132;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1822:
				name = "Fox Shirt";
				width = 18;
				height = 18;
				bodySlot = 94;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1823:
				name = "Fox Pants";
				width = 18;
				height = 18;
				legSlot = 78;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1824:
				name = "Cat Ears";
				width = 18;
				height = 18;
				headSlot = 133;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1825:
				noMelee = true;
				useStyle = 1;
				name = "Bloody Machete";
				shootSpeed = 15f;
				shoot = 320;
				damage = 15;
				knockBack = 5f;
				width = 34;
				height = 34;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 2;
				value = 50000;
				melee = true;
				return;
			case 1826:
				autoReuse = true;
				name = "Horseman's Blade";
				useStyle = 1;
				useAnimation = 26;
				knockBack = 7.5f;
				width = 40;
				height = 40;
				damage = 75;
				scale = 1.15f;
				useSound = 1;
				rare = 8;
				value = sellPrice(0, 10);
				melee = true;
				return;
			case 1827:
				name = "Bladed Glove";
				useStyle = 1;
				useTurn = true;
				autoReuse = true;
				useAnimation = 8;
				useTime = 8;
				width = 24;
				height = 28;
				damage = 12;
				knockBack = 4f;
				useSound = 1;
				scale = 1.35f;
				melee = true;
				rare = 2;
				value = 50000;
				melee = true;
				return;
			case 1828:
				name = "Pumpkin Seed";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 254;
				width = 8;
				height = 10;
				value = buyPrice(0, 0, 2, 50);
				return;
			case 1829:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Spooky Hook";
				shootSpeed = 15.5f;
				shoot = 322;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 7;
				noMelee = true;
				value = sellPrice(0, 4);
				return;
			case 1830:
				name = "Spooky Wings";
				width = 24;
				height = 8;
				accessory = true;
				rare = 7;
				value = 400000;
				wingSlot = 21;
				return;
			case 1831:
				name = "Spooky Twig";
				maxStack = 99;
				width = 16;
				height = 14;
				value = sellPrice(0, 2, 50);
				rare = 5;
				return;
			case 1832:
				name = "Spooky Helmet";
				width = 18;
				height = 18;
				headSlot = 134;
				value = sellPrice(0, 1);
				defense = 8;
				rare = 8;
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 11%";
				return;
			case 1833:
				name = "Spooky Breastplate";
				width = 18;
				height = 18;
				bodySlot = 95;
				value = sellPrice(0, 1);
				defense = 10;
				rare = 8;
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 11%";
				return;
			case 1834:
				name = "Spooky Leggings";
				width = 18;
				height = 18;
				legSlot = 79;
				value = sellPrice(0, 1);
				defense = 9;
				rare = 8;
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 11%";
				return;
			case 1835:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 26;
				useTime = 26;
				name = "Stake Launcher";
				crit += 10;
				width = 40;
				height = 26;
				shoot = 323;
				useAmmo = 323;
				useSound = 5;
				damage = 75;
				shootSpeed = 9f;
				noMelee = true;
				value = 750000;
				rare = 8;
				knockBack = 6.5f;
				ranged = true;
				return;
			case 1836:
				name = "Stake";
				shootSpeed = 3f;
				shoot = 323;
				damage = 25;
				width = 20;
				height = 14;
				maxStack = 999;
				consumable = true;
				ammo = 323;
				knockBack = 4.5f;
				value = 15;
				ranged = true;
				return;
			case 1837:
				useStyle = 1;
				name = "Cursed Sapling";
				shoot = 324;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				buffType = 85;
				value = sellPrice(0, 2);
				return;
			case 1838:
				name = "Space Creature Mask";
				width = 18;
				height = 18;
				headSlot = 135;
				value = buyPrice(0, 3);
				vanity = true;
				return;
			case 1839:
				name = "Space Creature Shirt";
				width = 18;
				height = 18;
				bodySlot = 96;
				value = buyPrice(0, 3);
				vanity = true;
				return;
			case 1840:
				name = "Space Creature Pants";
				width = 18;
				height = 18;
				legSlot = 80;
				value = buyPrice(0, 3);
				vanity = true;
				return;
			case 1841:
				name = "Wolf Mask";
				width = 18;
				height = 18;
				headSlot = 136;
				value = buyPrice(0, 3);
				vanity = true;
				return;
			case 1842:
				name = "Wolf Shirt";
				width = 18;
				height = 18;
				bodySlot = 97;
				value = buyPrice(0, 3);
				vanity = true;
				return;
			case 1843:
				name = "Wolf Pants";
				width = 18;
				height = 18;
				legSlot = 81;
				value = buyPrice(0, 3);
				vanity = true;
				return;
			case 1844:
				useStyle = 4;
				name = "Pumpkin Moon Medallion";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons the Pumpkin Moon";
				rare = 8;
				return;
			case 1845:
				name = "Necromantic Scroll";
				rare = 8;
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases minion damage by 10%";
				value = buyPrice(0, 20);
				return;
			case 1846:
			case 1847:
			case 1848:
			case 1849:
			case 1850:
				name = "Large Painting";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 242;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 17 + type - 1846;
				return;
			}
			switch (type)
			{
			case 1851:
				name = "Treasure Hunter Shirt";
				width = 18;
				height = 18;
				bodySlot = 98;
				value = buyPrice(0, 3);
				vanity = true;
				return;
			case 1852:
				name = "Treasure Hunter Pants";
				width = 18;
				height = 18;
				legSlot = 82;
				value = buyPrice(0, 3);
				vanity = true;
				return;
			case 1853:
				name = "Dryad Coverings";
				width = 18;
				height = 18;
				bodySlot = 99;
				value = buyPrice(0, 3);
				vanity = true;
				return;
			case 1854:
				name = "Dryad Loincloth";
				width = 18;
				height = 18;
				legSlot = 83;
				value = buyPrice(0, 3);
				vanity = true;
				return;
			case 1855:
			case 1856:
				name = "Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				rare = 1;
				placeStyle = 36 + type - 1855;
				return;
			case 1857:
				name = "Jack 'O Lantern Mask";
				width = 18;
				height = 18;
				headSlot = 137;
				value = sellPrice(0, 5);
				vanity = true;
				rare = 3;
				return;
			case 1858:
				name = "Sniper Scope";
				width = 14;
				height = 28;
				rare = 7;
				value = 300000;
				accessory = true;
				toolTip = "Increases view range for guns (Right click to zoom out)";
				toolTip2 = "10% increased ranged damage and critical strike chance";
				return;
			case 1859:
				name = "Heart Lantern";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 9;
				return;
			case 1860:
				name = "Jellyfish Diving Gear";
				width = 24;
				height = 28;
				rare = 5;
				value = 150000;
				accessory = true;
				toolTip = "Grants the ability to swim and greatly extends underwater breathing";
				toolTip2 = "Provides light under water";
				faceSlot = 3;
				return;
			case 1861:
				name = "Arctic Diving Gear";
				width = 24;
				height = 28;
				rare = 6;
				value = 250000;
				accessory = true;
				toolTip = "Grants the ability to swim and greatly extends underwater breathing";
				toolTip2 = "Provides light under water and extra mobility on ice";
				faceSlot = 2;
				return;
			case 1862:
				name = "Sparkfrost Boots";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Allows flight, super fast running, and extra mobility on ice";
				toolTip = "7% increased movement speed";
				value = 350000;
				shoeSlot = 9;
				return;
			case 1863:
				name = "Fart in a Balloon";
				width = 14;
				height = 28;
				rare = 4;
				value = 150000;
				accessory = true;
				toolTip = "Allows the holder to double jump";
				toolTip2 = "Increases jump height";
				balloonSlot = 5;
				return;
			case 1864:
				name = "Papyrus Scarab";
				rare = 8;
				width = 24;
				height = 28;
				accessory = true;
				toolTip = "Increases your max number of minions";
				toolTip2 = "Increases the damage and knockback of your minions";
				value = buyPrice(0, 25);
				return;
			case 1865:
				name = "Celestial Stone";
				width = 16;
				height = 24;
				accessory = true;
				rare = 7;
				toolTip = "Minor increase to damage, attack speed, critical strike chance,";
				toolTip2 = "life regeneration, defense, pick speed, and minion knockback";
				value = 400000;
				return;
			case 1866:
				name = "Hoverboard";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 22;
				return;
			case 1867:
				name = "Candy Cane";
				width = 12;
				height = 12;
				return;
			case 1868:
				name = "Sugar Plum";
				width = 12;
				height = 12;
				return;
			case 1869:
				name = "Present";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 36;
				width = 12;
				height = 28;
				rare = 1;
				toolTip = "Right click to open";
				return;
			case 1870:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 38;
				useTime = 38;
				name = "Red Ryder";
				width = 44;
				height = 14;
				shoot = 10;
				useAmmo = 14;
				useSound = 11;
				damage = 20;
				shootSpeed = 8f;
				noMelee = true;
				value = 100000;
				knockBack = 3.75f;
				rare = 1;
				ranged = true;
				return;
			case 1871:
				name = "Festive Wings";
				width = 24;
				height = 8;
				accessory = true;
				toolTip = "Allows flight and slow fall";
				value = 400000;
				rare = 5;
				wingSlot = 23;
				return;
			case 1872:
				name = "Tree Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 170;
				width = 12;
				height = 12;
				return;
			case 1873:
				name = "Christmas Tree";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 171;
				width = 12;
				height = 12;
				value = buyPrice(0, 0, 25);
				return;
			case 1874:
			case 1875:
			case 1876:
			case 1877:
			case 1878:
			case 1879:
			case 1880:
			case 1881:
			case 1882:
			case 1883:
			case 1884:
			case 1885:
			case 1886:
			case 1887:
			case 1888:
			case 1889:
			case 1890:
			case 1891:
			case 1892:
			case 1893:
			case 1894:
			case 1895:
			case 1896:
			case 1897:
			case 1898:
			case 1899:
			case 1900:
			case 1901:
			case 1902:
			case 1903:
			case 1904:
			case 1905:
				name = "Xmas decorations";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				noMelee = true;
				value = buyPrice(0, 0, 5);
				return;
			}
			switch (type)
			{
			case 1906:
				name = "Giant Bow";
				width = 18;
				height = 18;
				headSlot = 138;
				vanity = true;
				value = buyPrice(0, 1);
				return;
			case 1907:
				name = "Reindeer Antlers";
				width = 18;
				height = 18;
				headSlot = 139;
				vanity = true;
				value = buyPrice(0, 1);
				return;
			case 1908:
				name = "Holly";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 246;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 10);
				placeStyle = 18;
				return;
			case 1909:
				name = "Candy Cane Sword";
				useStyle = 1;
				useAnimation = 27;
				knockBack = 5.3f;
				width = 24;
				height = 28;
				damage = 16;
				scale = 1.1f;
				useSound = 1;
				rare = 1;
				value = 13500;
				melee = true;
				return;
			case 1910:
				name = "Elf Melter";
				useStyle = 5;
				autoReuse = true;
				useAnimation = 30;
				useTime = 5;
				width = 50;
				height = 18;
				shoot = 85;
				useAmmo = 23;
				useSound = 34;
				damage = 40;
				knockBack = 0.425f;
				shootSpeed = 8.5f;
				noMelee = true;
				value = 500000;
				rare = 8;
				ranged = true;
				toolTip = "Uses gel for ammo";
				return;
			case 1911:
				name = "Christmas Pudding";
				useSound = 2;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 10;
				height = 10;
				buffType = 26;
				buffTime = 54000;
				rare = 1;
				toolTip = "Minor improvements to all stats";
				value = 1000;
				return;
			case 1912:
				name = "Eggnog";
				useSound = 3;
				healLife = 80;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 14;
				height = 24;
				potion = true;
				value = 40;
				rare = 1;
				return;
			case 1913:
				useStyle = 1;
				name = "Star Anise";
				shootSpeed = 12f;
				shoot = 330;
				damage = 14;
				width = 18;
				height = 20;
				maxStack = 999;
				consumable = true;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				noMelee = true;
				value = 25;
				ranged = true;
				return;
			case 1914:
				useStyle = 1;
				name = "Reindeer Bells";
				width = 16;
				height = 30;
				useSound = 25;
				useAnimation = 20;
				useTime = 20;
				rare = 8;
				noMelee = true;
				mountType = 0;
				value = sellPrice(0, 5);
				return;
			case 1915:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Candy Cane Hook";
				shootSpeed = 11.5f;
				shoot = 331;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 7;
				noMelee = true;
				value = sellPrice(0, 4);
				return;
			case 1916:
				noUseGraphic = true;
				damage = 0;
				knockBack = 7f;
				useStyle = 5;
				name = "Christmas Hook";
				shootSpeed = 15.5f;
				shoot = 332;
				width = 18;
				height = 28;
				useSound = 1;
				useAnimation = 20;
				useTime = 20;
				rare = 7;
				noMelee = true;
				value = sellPrice(0, 4);
				return;
			case 1917:
				name = "Candy Cane Pickaxe";
				useStyle = 1;
				useTurn = true;
				useAnimation = 20;
				useTime = 16;
				autoReuse = true;
				width = 24;
				height = 28;
				damage = 7;
				pick = 55;
				useSound = 1;
				knockBack = 2.5f;
				value = 10000;
				melee = true;
				toolTip = "Can mine Meteorite";
				return;
			case 1918:
				noMelee = true;
				useStyle = 1;
				name = "Fruitcake Chakrum";
				shootSpeed = 11f;
				shoot = 333;
				damage = 14;
				knockBack = 8f;
				width = 14;
				height = 28;
				useSound = 1;
				useAnimation = 15;
				useTime = 15;
				noUseGraphic = true;
				rare = 1;
				value = 50000;
				melee = true;
				return;
			case 1919:
				name = "Sugar Cookie";
				useSound = 2;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 10;
				height = 10;
				buffType = 26;
				buffTime = 54000;
				rare = 1;
				toolTip = "Minor improvements to all stats";
				value = 1000;
				return;
			case 1920:
				name = "Gingerbread Man";
				useSound = 2;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				maxStack = 30;
				consumable = true;
				width = 10;
				height = 10;
				buffType = 26;
				buffTime = 54000;
				rare = 1;
				toolTip = "Minor improvements to all stats";
				value = 1000;
				return;
			case 1921:
				name = "Hand Warmer";
				width = 16;
				height = 24;
				accessory = true;
				rare = 2;
				value = 50000;
				handOffSlot = 2;
				handOnSlot = 7;
				return;
			case 1922:
				name = "Coal";
				width = 16;
				height = 24;
				return;
			case 1923:
				name = "Toolbox";
				width = 16;
				height = 24;
				accessory = true;
				rare = 2;
				value = 50000;
				return;
			case 1924:
				name = "Pine Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 26;
				width = 14;
				height = 28;
				value = 200;
				return;
			case 1925:
				name = "Pine Chair";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 15;
				placeStyle = 26;
				width = 12;
				height = 30;
				return;
			case 1926:
				name = "Pine Table";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 14;
				placeStyle = 23;
				width = 26;
				height = 20;
				value = 300;
				return;
			case 1927:
				useStyle = 1;
				name = "Dog Whistle";
				shoot = 334;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Puppy";
				value = 0;
				buffType = 91;
				return;
			case 1928:
				name = "Christmas Sword";
				useStyle = 1;
				useAnimation = 26;
				useTime = 26;
				knockBack = 7f;
				width = 40;
				height = 40;
				damage = 73;
				scale = 1.1f;
				shoot = 335;
				shootSpeed = 14f;
				useSound = 1;
				rare = 8;
				value = sellPrice(0, 10);
				melee = true;
				return;
			case 1929:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 4;
				useTime = 4;
				name = "Chaingun";
				width = 50;
				height = 18;
				shoot = 10;
				useAmmo = 14;
				useSound = 41;
				damage = 31;
				shootSpeed = 14f;
				noMelee = true;
				value = sellPrice(0, 5);
				rare = 8;
				toolTip = "50% chance to not consume ammo";
				knockBack = 1.75f;
				ranged = true;
				return;
			case 1930:
				autoReuse = true;
				name = "Razorpine";
				mana = 5;
				useSound = 39;
				useStyle = 5;
				damage = 48;
				useAnimation = 8;
				useTime = 8;
				width = 40;
				height = 40;
				shoot = 336;
				shootSpeed = 12f;
				knockBack = 3.25f;
				value = sellPrice(0, 5);
				toolTip = "Shoots razor sharp pine needles";
				magic = true;
				rare = 8;
				noMelee = true;
				return;
			case 1931:
				autoReuse = true;
				name = "Blizzard Staff";
				mana = 9;
				useStyle = 5;
				damage = 58;
				useAnimation = 10;
				useTime = 5;
				width = 40;
				height = 40;
				shoot = 337;
				shootSpeed = 10f;
				knockBack = 4.5f;
				value = sellPrice(0, 5);
				magic = true;
				rare = 8;
				noMelee = true;
				return;
			case 1932:
				name = "Mrs. Clause Hat";
				width = 18;
				height = 18;
				headSlot = 140;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1933:
				name = "Mrs. Clause Shirt";
				width = 18;
				height = 18;
				bodySlot = 100;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1934:
				name = "Mrs. Clause Heals";
				width = 18;
				height = 18;
				legSlot = 84;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1935:
				name = "Parka Hood";
				width = 18;
				height = 18;
				headSlot = 142;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1936:
				name = "Parka Coat";
				width = 18;
				height = 18;
				bodySlot = 102;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1937:
				name = "Parka Pants";
				width = 18;
				height = 18;
				legSlot = 86;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1940:
				name = "Tree Mask";
				width = 18;
				height = 18;
				headSlot = 141;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1941:
				name = "Tree Shirt";
				width = 18;
				height = 18;
				bodySlot = 101;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1942:
				name = "Tree Trunks";
				width = 18;
				height = 18;
				legSlot = 85;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1938:
				name = "Snow Hat";
				width = 18;
				height = 18;
				headSlot = 143;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1939:
				name = "Christmas Sweater";
				width = 18;
				height = 18;
				bodySlot = 103;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1943:
				name = "Elf Mask";
				width = 18;
				height = 18;
				headSlot = 144;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1944:
				name = "Elf Shirt";
				width = 18;
				height = 18;
				bodySlot = 104;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1945:
				name = "Elf Pants";
				width = 18;
				height = 18;
				legSlot = 87;
				vanity = true;
				value = buyPrice(0, 3);
				return;
			case 1946:
				useStyle = 5;
				autoReuse = true;
				useAnimation = 15;
				useTime = 15;
				name = "Snowman Cannon";
				useAmmo = 771;
				width = 50;
				height = 20;
				shoot = 338;
				useSound = 11;
				damage = 67;
				shootSpeed = 15f;
				noMelee = true;
				value = sellPrice(0, 20);
				knockBack = 4f;
				rare = 8;
				ranged = true;
				return;
			case 1947:
				name = "North Pole";
				useStyle = 5;
				useAnimation = 25;
				useTime = 25;
				shootSpeed = 4.75f;
				knockBack = 6.7f;
				width = 40;
				height = 40;
				damage = 73;
				scale = 1.1f;
				useSound = 1;
				shoot = 342;
				rare = 7;
				value = 180000;
				noMelee = true;
				noUseGraphic = true;
				melee = true;
				return;
			case 1948:
			case 1949:
			case 1950:
			case 1951:
			case 1952:
			case 1953:
			case 1954:
			case 1955:
			case 1956:
			case 1957:
				name = "Christmas Wallpaper";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 116 + type - 1948;
				width = 12;
				height = 12;
				value = buyPrice(0, 0, 1);
				return;
			}
			switch (type)
			{
			case 1958:
				useStyle = 4;
				name = "Naughty Present";
				width = 22;
				height = 14;
				consumable = true;
				useAnimation = 45;
				useTime = 45;
				maxStack = 20;
				toolTip = "Summons the Frost Moon";
				rare = 8;
				return;
			case 1959:
				useStyle = 1;
				name = "Baby Grinch Mischief's Whistle";
				shoot = 353;
				width = 16;
				height = 30;
				useSound = 2;
				useAnimation = 20;
				useTime = 20;
				rare = 3;
				noMelee = true;
				toolTip = "Summons a Baby Grinch";
				value = 0;
				buffType = 92;
				return;
			case 1960:
			case 1961:
			case 1962:
				name = "Trophy";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 1);
				rare = 1;
				placeStyle = 38 + type - 1960;
				return;
			case 1963:
				name = "Music Box (Pumpkin Moon)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 28;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			case 1964:
				name = "Music Box (Alt Underground)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 29;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			case 1965:
				name = "Music Box (Frost Moon)";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				consumable = true;
				createTile = 139;
				placeStyle = 30;
				width = 24;
				height = 24;
				rare = 4;
				value = 100000;
				accessory = true;
				return;
			case 1966:
				name = "Brown Paint";
				paint = 28;
				width = 24;
				height = 24;
				value = 25;
				maxStack = 999;
				return;
			case 1967:
				name = "Shadow Paint";
				paint = 29;
				width = 24;
				height = 24;
				value = 50;
				maxStack = 999;
				return;
			case 1968:
				name = "Negative Paint";
				paint = 30;
				width = 24;
				height = 24;
				value = 75;
				maxStack = 999;
				return;
			case 1969:
				name = "Team Dye";
				width = 20;
				height = 20;
				maxStack = 1;
				value = 10000;
				rare = 1;
				dye = 65;
				return;
			case 1970:
			case 1971:
			case 1972:
			case 1973:
			case 1974:
			case 1975:
			case 1976:
				name = "Gemspark Block";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 262 + type - 1970;
				width = 12;
				height = 12;
				return;
			}
			if (type >= 1977 && type <= 1986)
			{
				name = "Hair Dye";
				width = 20;
				height = 26;
				maxStack = 99;
				value = buyPrice(0, 5);
				rare = 2;
				hairDye = (short)(1 + type - 1977);
				if (type == 1980)
				{
					value = buyPrice(0, 10);
				}
				if (type == 1984)
				{
					value = buyPrice(0, 7, 50);
				}
				if (type == 1985)
				{
					value = buyPrice(0, 15);
				}
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				consumable = true;
				return;
			}
			switch (type)
			{
			case 1987:
				name = "Angel Halo";
				width = 18;
				height = 12;
				maxStack = 1;
				value = buyPrice(0, 40);
				rare = 5;
				accessory = true;
				faceSlot = 7;
				vanity = true;
				break;
			case 1988:
				name = "Fez";
				width = 20;
				height = 14;
				maxStack = 1;
				value = buyPrice(0, 3, 50);
				vanity = true;
				headSlot = 145;
				break;
			case 1989:
				name = "Womannequin";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 269;
				width = 22;
				height = 32;
				break;
			case 1990:
				name = "Hair Dye Remover";
				width = 20;
				height = 26;
				maxStack = 99;
				value = buyPrice(0, 2);
				rare = 2;
				hairDye = 0;
				useSound = 3;
				useStyle = 2;
				useTurn = true;
				useAnimation = 17;
				useTime = 17;
				consumable = true;
				break;
			case 1991:
				name = "Bug Net";
				useTurn = true;
				useStyle = 1;
				useAnimation = 25;
				width = 24;
				height = 28;
				useSound = 1;
				value = buyPrice(0, 1);
				autoReuse = true;
				break;
			case 1992:
				name = "Firefly";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 355;
				noUseGraphic = true;
				bait = 20;
				break;
			case 1993:
				name = "Firefly in a Bottle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 270;
				width = 12;
				height = 28;
				break;
			case 1994:
			case 1995:
			case 1996:
			case 1997:
			case 1998:
			case 1999:
			case 2000:
			case 2001:
			{
				name = "Butterfly";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 356;
				placeStyle = 1 + type - 1994;
				noUseGraphic = true;
				int num = type - 1994;
				if (num == 0)
				{
					bait = 5;
				}
				if (num == 4)
				{
					bait = 10;
				}
				if (num == 6)
				{
					bait = 15;
				}
				if (num == 3)
				{
					bait = 20;
				}
				if (num == 7)
				{
					bait = 25;
				}
				if (num == 2)
				{
					bait = 30;
				}
				if (num == 1)
				{
					bait = 35;
				}
				if (num == 5)
				{
					bait = 50;
				}
				break;
			}
			}
		}

		public void SetDefaults3(int type)
		{
			switch (type)
			{
			case 2002:
				name = "Worm";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 357;
				noUseGraphic = true;
				bait = 25;
				return;
			case 2003:
				name = "Mouse";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 300;
				noUseGraphic = true;
				return;
			case 2004:
				name = "Lightning Bug";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 358;
				noUseGraphic = true;
				bait = 35;
				return;
			case 2005:
				name = "Lightning Bug in a Bottle";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 271;
				width = 12;
				height = 28;
				return;
			case 2006:
				name = "Snail";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 359;
				noUseGraphic = true;
				bait = 10;
				return;
			case 2007:
				name = "Glowing Snail";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 360;
				noUseGraphic = true;
				bait = 15;
				return;
			case 2008:
			case 2009:
			case 2010:
			case 2011:
			case 2012:
			case 2013:
			case 2014:
				name = "Wallpaper";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 126 + type - 2008;
				width = 12;
				height = 12;
				value = buyPrice(0, 0, 1);
				return;
			}
			if (type >= 2015 && type <= 2019)
			{
				name = "Glowing Snail";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				noUseGraphic = true;
				if (type == 2015)
				{
					makeNPC = 74;
				}
				if (type == 2016)
				{
					makeNPC = 297;
				}
				if (type == 2017)
				{
					makeNPC = 298;
				}
				if (type == 2018)
				{
					makeNPC = 299;
				}
				if (type == 2019)
				{
					makeNPC = 46;
				}
				return;
			}
			switch (type)
			{
			case 2020:
				name = "Cactus Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 6;
				return;
			case 2021:
				name = "Ebonwood Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 7;
				return;
			case 2022:
				name = "Flesh Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 8;
				return;
			case 2023:
				name = "Hive Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 9;
				return;
			case 2024:
				name = "Steampunk Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 10;
				return;
			case 2025:
				name = "Glass Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 11;
				return;
			case 2026:
				name = "Rich Mahogany Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 12;
				return;
			case 2027:
				name = "Pearlwood Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 13;
				return;
			case 2028:
				name = "Spooky Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 14;
				return;
			case 2029:
				name = "Sunplate Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 15;
				return;
			case 2030:
				name = "Temple Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 16;
				return;
			case 2031:
				name = "Frozen Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 17;
				return;
			case 2032:
				name = "Lantern 10";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 10;
				return;
			case 2033:
				name = "Lantern 11";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 11;
				return;
			case 2034:
				name = "Lantern 12";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 12;
				return;
			case 2035:
				name = "Lantern 13";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 13;
				return;
			case 2036:
				name = "Lantern 14";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 14;
				return;
			case 2037:
				name = "Lantern 15";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 15;
				return;
			case 2038:
				name = "Lantern 16";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 16;
				return;
			case 2039:
				name = "Lantern 17";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 17;
				return;
			case 2040:
				name = "Lantern 18";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 18;
				return;
			case 2041:
				name = "Lantern 19";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 19;
				return;
			case 2042:
				name = "Lantern 20";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 20;
				return;
			case 2043:
				name = "Lantern 21";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 21;
				return;
			case 2044:
				name = "Frozen Door";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 10;
				placeStyle = 27;
				width = 14;
				height = 28;
				value = 200;
				return;
			case 2045:
			case 2046:
			case 2047:
			case 2048:
			case 2049:
			case 2050:
			case 2051:
			case 2052:
			case 2053:
			case 2054:
				noWet = true;
				name = "more candles";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 33;
				width = 8;
				height = 18;
				placeStyle = 4 + type - 2045;
				return;
			}
			if (type >= 2055 && type <= 2065)
			{
				name = "more chandeliers";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 7 + type - 2055;
				width = 26;
				height = 26;
				value = 3000;
				return;
			}
			if (type >= 2066 && type <= 2071)
			{
				name = "more beds";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				autoReuse = true;
				createTile = 79;
				placeStyle = 13 + type - 2066;
				width = 28;
				height = 20;
				value = 2000;
				return;
			}
			if (type >= 2072 && type <= 2081)
			{
				name = "more bathtubs";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 90;
				placeStyle = type + 1 - 2072;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type >= 2082 && type <= 2091)
			{
				name = "Lamps";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 93;
				placeStyle = type + 1 - 2082;
				width = 10;
				height = 24;
				value = 500;
				return;
			}
			if (type >= 2092 && type <= 2103)
			{
				name = "more candelabras";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 100;
				placeStyle = type + 1 - 2092;
				width = 20;
				height = 20;
				value = 1500;
				return;
			}
			if (type >= 2104 && type <= 2113)
			{
				name = "Skeletron Mask";
				width = 28;
				height = 20;
				headSlot = type + 146 - 2104;
				rare = 1;
				vanity = true;
				return;
			}
			if (type >= 2114 && type <= 2118)
			{
				name = "Rack";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 240;
				width = 30;
				height = 30;
				value = sellPrice(0, 0, 5);
				placeStyle = 41 + type - 2114;
				maxStack = 99;
				return;
			}
			switch (type)
			{
			case 2119:
				name = "Stone Slab";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 273;
				width = 12;
				height = 12;
				return;
			case 2120:
				name = "Sandstone Slab";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 274;
				width = 12;
				height = 12;
				return;
			case 2121:
				name = "Frog";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 361;
				noUseGraphic = true;
				return;
			case 2122:
				name = "Duck";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 362;
				noUseGraphic = true;
				return;
			case 2123:
				name = "Duck";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 364;
				noUseGraphic = true;
				return;
			case 2124:
			case 2125:
			case 2126:
			case 2127:
			case 2128:
				name = "more bathtubs";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 90;
				placeStyle = type + 11 - 2124;
				width = 20;
				height = 20;
				value = 300;
				return;
			}
			if (type >= 2129 && type <= 2134)
			{
				name = "Lamps";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 93;
				placeStyle = type + 11 - 2129;
				width = 10;
				height = 24;
				value = 500;
				return;
			}
			if (type >= 2135 && type <= 2138)
			{
				name = "Bookcase";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 101;
				width = 20;
				height = 20;
				value = 300;
				placeStyle = 18 + type - 2135;
				return;
			}
			switch (type)
			{
			case 2139:
				name = "more beds";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				autoReuse = true;
				createTile = 79;
				placeStyle = 19;
				width = 28;
				height = 20;
				value = 2000;
				return;
			case 2140:
				name = "more beds";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				autoReuse = true;
				createTile = 79;
				placeStyle = 20;
				width = 28;
				height = 20;
				value = 2000;
				return;
			case 2141:
			case 2142:
			case 2143:
			case 2144:
				name = "more chandeliers";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 34;
				placeStyle = 18 + type - 2141;
				width = 26;
				height = 26;
				value = 3000;
				return;
			}
			if (type >= 2145 && type <= 2148)
			{
				name = "Lantern 22";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 42;
				width = 12;
				height = 28;
				placeStyle = 22 + type - 2145;
				return;
			}
			if (type >= 2149 && type <= 2152)
			{
				name = "more candelabras";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 100;
				placeStyle = type + 13 - 2149;
				width = 20;
				height = 20;
				value = 1500;
				return;
			}
			if (type >= 2153 && type <= 2155)
			{
				noWet = true;
				name = "more candles";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 33;
				width = 8;
				height = 18;
				placeStyle = 14 + type - 2153;
				return;
			}
			switch (type)
			{
			case 2156:
				name = "Black Scorpion";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 366;
				noUseGraphic = true;
				bait = 15;
				return;
			case 2157:
				name = "Scorpion";
				useStyle = 1;
				autoReuse = true;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				maxStack = 999;
				consumable = true;
				width = 12;
				height = 12;
				makeNPC = 367;
				noUseGraphic = true;
				bait = 10;
				return;
			case 2158:
			case 2159:
			case 2160:
				name = "Wallpaper";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 133 + type - 2158;
				width = 12;
				height = 12;
				value = buyPrice(0, 0, 1);
				return;
			}
			switch (type)
			{
			case 2161:
				name = "Frost Core";
				width = 18;
				height = 18;
				maxStack = 999;
				value = 50000;
				rare = 5;
				return;
			case 2162:
			case 2163:
			case 2164:
			case 2165:
			case 2166:
			case 2167:
			case 2168:
				name = "Critter Cage";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 275 + type - 2162;
				width = 12;
				height = 12;
				return;
			}
			switch (type)
			{
			case 2169:
				name = "Waterfall Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 136;
				width = 12;
				height = 12;
				return;
			case 2170:
				name = "Lavafall Wall";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 7;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createWall = 137;
				width = 12;
				height = 12;
				return;
			case 2171:
				name = "Crimson Seeds";
				useTurn = true;
				useStyle = 1;
				useAnimation = 15;
				useTime = 10;
				maxStack = 99;
				consumable = true;
				createTile = 199;
				width = 14;
				height = 14;
				value = 500;
				return;
			case 2172:
				name = "Heavy Work Bench";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 283;
				width = 28;
				height = 14;
				value = 500;
				toolTip = "Used for advanced crafting";
				return;
			case 2173:
				name = "Copper Plating";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 284;
				width = 12;
				height = 12;
				return;
			case 2174:
			case 2175:
				name = "Critter Cage";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 285 + type - 2174;
				width = 12;
				height = 12;
				return;
			}
			switch (type)
			{
			case 2176:
				name = "Shroomite Digging Claw";
				useStyle = 1;
				useAnimation = 12;
				useTime = 4;
				knockBack = 6f;
				useTurn = true;
				autoReuse = true;
				width = 20;
				height = 12;
				damage = 45;
				pick = 200;
				axe = 25;
				useSound = 1;
				rare = 8;
				value = sellPrice(0, 1);
				melee = true;
				tileBoost--;
				return;
			case 2177:
				name = "Ammo Box";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 999;
				consumable = true;
				createTile = 287;
				width = 22;
				height = 22;
				value = buyPrice(0, 15);
				rare = 6;
				return;
			case 2178:
			case 2179:
			case 2180:
			case 2181:
			case 2182:
			case 2183:
			case 2184:
			case 2185:
			case 2186:
			case 2187:
				name = "Butterfly Jar";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 288 + type - 2178;
				width = 12;
				height = 12;
				return;
			}
			switch (type)
			{
			case 2189:
				name = "Spectre Mask";
				width = 18;
				height = 18;
				defense = 18;
				headSlot = 156;
				rare = 8;
				value = 375000;
				toolTip = "Increases maximum mana by 60 and reduces mana usage by 13%";
				toolTip2 = "5% increased magic damage and critical strike chance";
				return;
			case 2188:
				name = "Venom Staff";
				mana = 25;
				useSound = 43;
				useStyle = 5;
				damage = 63;
				useAnimation = 30;
				useTime = 30;
				width = 40;
				height = 40;
				shoot = 355;
				shootSpeed = 14f;
				knockBack = 7f;
				magic = true;
				autoReuse = true;
				rare = 7;
				noMelee = true;
				value = sellPrice(0, 7);
				return;
			case 2190:
			case 2191:
				name = "Critter Cage";
				useStyle = 1;
				useTurn = true;
				useAnimation = 15;
				useTime = 10;
				autoReuse = true;
				maxStack = 99;
				consumable = true;
				createTile = 298 + type - 2190;
				width = 12;
				height = 12;
				return;
			}
			if (type < 2192 || type > 2198)
			{
				switch (type)
				{
				case 2203:
				case 2204:
					break;
				case 2199:
					name = "Beetle Helmet";
					width = 18;
					height = 18;
					defense = 23;
					headSlot = 157;
					rare = 8;
					value = 300000;
					toolTip = "6% increased melee damage";
					toolTip2 = "Enemies are more likely to target you";
					return;
				case 2200:
					name = "Beetle Scale Mail";
					width = 18;
					height = 18;
					defense = 20;
					bodySlot = 105;
					rare = 8;
					value = 240000;
					toolTip = "8% increased melee damage and critical strike chance";
					toolTip = "6% increased movement and melee speed";
					return;
				case 2201:
					name = "Beetle Shell";
					width = 18;
					height = 18;
					defense = 32;
					bodySlot = 106;
					rare = 8;
					value = 240000;
					toolTip = "5% increased melee damage and critical strike chance";
					toolTip2 = "Enemies are more likely to target you";
					return;
				case 2202:
					name = "Beetle Leggings";
					width = 18;
					height = 18;
					defense = 18;
					legSlot = 98;
					rare = 8;
					value = 180000;
					toolTip = "6% increased movement and melee speed";
					toolTip2 = "Enemies are more likely to target you";
					return;
				case 2205:
					name = "Penguin";
					useStyle = 1;
					autoReuse = true;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					maxStack = 999;
					consumable = true;
					width = 12;
					height = 12;
					makeNPC = 148;
					noUseGraphic = true;
					return;
				case 2206:
				case 2207:
					name = "Critter Cage";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 10;
					autoReuse = true;
					maxStack = 99;
					consumable = true;
					createTile = 309 + type - 2206;
					width = 12;
					height = 12;
					return;
				case 2208:
					name = "Terrarium";
					width = 18;
					height = 20;
					maxStack = 99;
					return;
				case 2209:
					name = "Super Mana Potion";
					useSound = 3;
					healMana = 300;
					useStyle = 2;
					useTurn = true;
					useAnimation = 17;
					useTime = 17;
					maxStack = 99;
					consumable = true;
					width = 14;
					height = 24;
					rare = 4;
					value = 1500;
					return;
				case 2210:
				case 2211:
				case 2212:
				case 2213:
					name = "Wooden Fences";
					useStyle = 1;
					useTurn = true;
					useAnimation = 15;
					useTime = 7;
					autoReuse = true;
					maxStack = 999;
					consumable = true;
					createWall = 138 + type - 2210;
					width = 12;
					height = 12;
					return;
				default:
					if (type >= 2214 && type <= 2217)
					{
						name = "Builder's Accessories";
						width = 30;
						height = 30;
						accessory = true;
						rare = 3;
						value = buyPrice(0, 10);
						return;
					}
					switch (type)
					{
					case 2218:
						name = "Beetle Husk";
						width = 14;
						height = 18;
						maxStack = 99;
						rare = 8;
						value = sellPrice(0, 0, 50);
						return;
					case 2219:
						name = "Celestial Magnet";
						width = 24;
						height = 24;
						accessory = true;
						toolTip = "Increases pickup range for stars";
						value = buyPrice(0, 15);
						rare = 4;
						return;
					case 2220:
						name = "Celestial Emblem";
						width = 24;
						height = 24;
						accessory = true;
						toolTip = "15% increased magic damage";
						toolTip2 = "Increases pickup range for stars";
						value = buyPrice(0, 16);
						rare = 5;
						return;
					case 2221:
						name = "Celestial Cuffs";
						width = 24;
						height = 24;
						accessory = true;
						rare = 5;
						toolTip = "Restores mana when damaged";
						toolTip2 = "Increases pickup range for stars";
						value = buyPrice(0, 16);
						handOffSlot = 10;
						handOnSlot = 17;
						return;
					case 2222:
						name = "Peddler's Hat";
						width = 18;
						height = 18;
						headSlot = 158;
						vanity = true;
						value = sellPrice(0, 0, 25);
						return;
					case 2223:
						autoReuse = true;
						useStyle = 5;
						useAnimation = 22;
						useTime = 22;
						name = "Pulse Bow";
						width = 50;
						height = 18;
						shoot = 10;
						useAmmo = 1;
						useSound = 5;
						crit = 7;
						damage = 65;
						knockBack = 3f;
						shootSpeed = 7.75f;
						noMelee = true;
						value = buyPrice(0, 45);
						rare = 8;
						ranged = true;
						toolTip = "Shoots a charged arrow";
						return;
					case 2224:
						name = "more chandeliers";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 34;
						placeStyle = 22;
						width = 26;
						height = 26;
						value = 3000;
						return;
					case 2225:
						name = "Lamps";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 93;
						placeStyle = 17;
						width = 10;
						height = 24;
						value = 500;
						return;
					case 2226:
						name = "Lantern";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 42;
						width = 12;
						height = 28;
						placeStyle = 26;
						return;
					case 2227:
						name = "more candelabras";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 100;
						placeStyle = 17;
						width = 20;
						height = 20;
						value = 1500;
						return;
					case 2228:
						name = "Dynasty Chair";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 15;
						placeStyle = 27;
						width = 12;
						height = 30;
						return;
					case 2229:
						name = "Dynasty Work Bench";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 18;
						placeStyle = 18;
						width = 28;
						height = 14;
						value = 150;
						return;
					case 2230:
						name = "Dynasty Chest";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 21;
						placeStyle = 28;
						width = 26;
						height = 22;
						value = 2500;
						return;
					case 2231:
						name = "Dynasty Bed";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 99;
						consumable = true;
						autoReuse = true;
						createTile = 79;
						placeStyle = 21;
						width = 28;
						height = 20;
						value = 2000;
						return;
					case 2232:
						name = "more bathtubs";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 90;
						placeStyle = 16;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2233:
						name = "Bookcase";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 101;
						width = 20;
						height = 20;
						value = 300;
						placeStyle = 22;
						return;
					case 2234:
						name = "Dynasty Cup";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 13;
						placeStyle = 5;
						width = 16;
						height = 24;
						value = 20;
						return;
					case 2235:
						name = "Bowl";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 103;
						placeStyle = 1;
						width = 16;
						height = 24;
						value = 20;
						return;
					case 2236:
						noWet = true;
						name = "more candles";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 33;
						width = 8;
						height = 18;
						placeStyle = 17;
						return;
					case 2237:
					case 2238:
					case 2239:
					case 2240:
					case 2241:
						name = "Grandfather Clock";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 104;
						placeStyle = 1 + type - 2237;
						width = 20;
						height = 20;
						value = 300;
						return;
					}
					switch (type)
					{
					case 2242:
					case 2243:
						name = "Bowl";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 103;
						placeStyle = 2 + type - 2242;
						width = 16;
						height = 24;
						value = 20;
						if (type == 2242)
						{
							value = buyPrice(0, 0, 20);
						}
						return;
					case 2244:
						name = "Wine Glass";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 13;
						placeStyle = 6;
						width = 16;
						height = 24;
						value = 20;
						return;
					case 2245:
					case 2246:
					case 2247:
						name = "Piano";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 87;
						placeStyle = 5 + type - 2245;
						width = 20;
						height = 20;
						value = 300;
						return;
					}
					switch (type)
					{
					case 2248:
						name = "Frozen Table";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 14;
						placeStyle = 24;
						width = 26;
						height = 20;
						value = 300;
						return;
					case 2249:
					case 2250:
						name = "Dynasty Chest";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 21;
						placeStyle = 29 + type - 2249;
						width = 26;
						height = 22;
						value = 2500;
						return;
					case 2251:
					case 2252:
					case 2253:
						name = "Honey Work Bench";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 18;
						placeStyle = 19 + type - 2251;
						width = 28;
						height = 14;
						value = 150;
						return;
					}
					if (type >= 2254 && type <= 2256)
					{
						name = "Piano";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 87;
						placeStyle = 8 + type - 2254;
						width = 20;
						height = 20;
						value = 300;
						return;
					}
					switch (type)
					{
					case 2257:
					case 2258:
						name = "more cups";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 13;
						placeStyle = 7 + type - 2257;
						width = 16;
						height = 24;
						value = 20;
						if (type == 2258)
						{
							value = buyPrice(0, 0, 50);
						}
						return;
					case 2259:
						name = "Dynasty Table";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 14;
						placeStyle = 25;
						width = 26;
						height = 20;
						value = 300;
						return;
					case 2260:
					case 2261:
					case 2262:
						name = "Dynasty Blocks";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 311 + type - 2260;
						width = 12;
						height = 12;
						value = buyPrice(0, 0, 0, 50);
						return;
					}
					if (type >= 2263 && type <= 2264)
					{
						name = "Dynasty Walls";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createWall = 142 + type - 2263;
						width = 12;
						height = 12;
						return;
					}
					switch (type)
					{
					case 2265:
						name = "Dynasty Door";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 99;
						consumable = true;
						createTile = 10;
						placeStyle = 28;
						width = 14;
						height = 28;
						value = 200;
						return;
					case 2266:
						name = "Sake";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 10;
						height = 10;
						buffType = 25;
						buffTime = 14400;
						rare = 1;
						value = buyPrice(0, 0, 5);
						return;
					case 2267:
						name = "Pad Thai";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 10;
						height = 10;
						buffType = 26;
						buffTime = 14400;
						rare = 1;
						toolTip = "Minor improvements to all stats";
						value = buyPrice(0, 0, 20);
						return;
					case 2268:
						name = "Pho";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 10;
						height = 10;
						buffType = 26;
						buffTime = 25200;
						rare = 1;
						toolTip = "Minor improvements to all stats";
						value = buyPrice(0, 0, 30);
						return;
					case 2269:
						name = "Revolver";
						autoReuse = false;
						useStyle = 5;
						useAnimation = 22;
						useTime = 22;
						width = 24;
						height = 24;
						shoot = 14;
						knockBack = 4f;
						useAmmo = 14;
						useSound = 41;
						damage = 20;
						shootSpeed = 16f;
						noMelee = true;
						value = buyPrice(0, 10);
						scale = 0.85f;
						rare = 2;
						ranged = true;
						crit = 5;
						return;
					case 2270:
						useStyle = 5;
						autoReuse = true;
						useAnimation = 7;
						useTime = 7;
						name = "Gatligator";
						width = 50;
						height = 18;
						shoot = 10;
						useAmmo = 14;
						useSound = 41;
						damage = 21;
						shootSpeed = 8f;
						noMelee = true;
						value = buyPrice(0, 35);
						knockBack = 1.5f;
						rare = 4;
						toolTip = "33% chance to not consume ammo";
						ranged = true;
						return;
					case 2271:
						name = "Arcane Runes";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createWall = 144;
						width = 12;
						height = 12;
						value = buyPrice(0, 0, 2, 50);
						return;
					case 2272:
						name = "Water Gun";
						useStyle = 5;
						useAnimation = 20;
						useTime = 20;
						width = 38;
						height = 10;
						damage = 0;
						scale = 0.9f;
						shoot = 358;
						shootSpeed = 11f;
						value = buyPrice(0, 1, 50);
						return;
					case 2273:
						autoReuse = true;
						useTurn = true;
						name = "Katana";
						useStyle = 1;
						useAnimation = 22;
						knockBack = 3.5f;
						width = 34;
						height = 34;
						damage = 16;
						crit = 15;
						scale = 1f;
						useSound = 1;
						rare = 1;
						value = buyPrice(0, 2, 50);
						melee = true;
						return;
					case 2274:
						flame = true;
						noWet = true;
						name = "Ultrabright Torch";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						holdStyle = 1;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 4;
						placeStyle = 12;
						width = 10;
						height = 12;
						value = buyPrice(0, 0, 3);
						return;
					case 2275:
						name = "Magic Hat";
						width = 18;
						height = 18;
						headSlot = 159;
						value = buyPrice(0, 3);
						toolTip = "7% increased magic damage and critical strike chance";
						defense = 2;
						rare = 2;
						return;
					case 2276:
						name = "Diamond Ring";
						width = 24;
						height = 24;
						accessory = true;
						vanity = true;
						rare = 8;
						value = buyPrice(2);
						handOnSlot = 16;
						return;
					case 2277:
						name = "Gi";
						width = 18;
						height = 14;
						bodySlot = 165;
						value = buyPrice(0, 2);
						defense = 4;
						toolTip = "5% increased damage and critical strike chance";
						toolTip = "10% increased melee and movement speed";
						rare = 1;
						return;
					case 2278:
						name = "Kimono";
						width = 18;
						height = 14;
						bodySlot = 166;
						vanity = true;
						value = buyPrice(0, 1);
						return;
					case 2279:
						name = "Gypsy Robe";
						width = 18;
						height = 14;
						bodySlot = 167;
						value = buyPrice(0, 2);
						defense = 2;
						toolTip = "6% increased magic damage and critical strike chance";
						toolTip2 = "Reduces mana usage by 10%";
						rare = 1;
						return;
					case 2280:
						name = "Beetle Wings";
						width = 22;
						height = 20;
						accessory = true;
						toolTip = "Allows flight and slow fall";
						value = 400000;
						rare = 7;
						wingSlot = 24;
						return;
					case 2281:
					case 2282:
					case 2283:
						name = "Animal Skins";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 242;
						width = 30;
						height = 30;
						value = buyPrice(0, 1);
						placeStyle = 22 + type - 2281;
						return;
					}
					if (type >= 2284 && type <= 2287)
					{
						name = "Capes";
						width = 26;
						height = 30;
						maxStack = 1;
						value = buyPrice(0, 5);
						rare = 5;
						accessory = true;
						backSlot = (sbyte)(3 + type - 2284);
						frontSlot = (sbyte)(1 + type - 2284);
						vanity = true;
						return;
					}
					switch (type)
					{
					case 2288:
						name = "Frozen Chair";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 15;
						placeStyle = 28;
						width = 12;
						height = 30;
						return;
					case 2289:
					case 2291:
					case 2292:
					case 2293:
					case 2294:
					case 2295:
					case 2296:
						name = "Fishing Poles";
						useStyle = 1;
						useAnimation = 8;
						useTime = 8;
						width = 24;
						height = 28;
						useSound = 1;
						shoot = 361 + type - 2291;
						switch (type)
						{
						case 2289:
							fishingPole = 5;
							shootSpeed = 9f;
							shoot = 360;
							break;
						case 2291:
							fishingPole = 15;
							shootSpeed = 11f;
							break;
						case 2293:
							fishingPole = 20;
							shootSpeed = 13f;
							rare = 1;
							break;
						case 2292:
							fishingPole = 25;
							shootSpeed = 14f;
							rare = 2;
							value = sellPrice(0, 1);
							break;
						case 2295:
							fishingPole = 30;
							shootSpeed = 15f;
							rare = 2;
							value = buyPrice(0, 20);
							break;
						case 2296:
							fishingPole = 40;
							shootSpeed = 16f;
							rare = 2;
							value = buyPrice(0, 35);
							break;
						case 2294:
							fishingPole = 50;
							shootSpeed = 17f;
							rare = 3;
							value = sellPrice(0, 20);
							break;
						}
						return;
					}
					if (type >= 2421 && type <= 2422)
					{
						name = "Fishing Poles";
						useStyle = 1;
						useAnimation = 8;
						useTime = 8;
						width = 24;
						height = 28;
						useSound = 1;
						shoot = 381 + type - 2421;
						if (type == 2421)
						{
							fishingPole = 22;
							shootSpeed = 13.5f;
							rare = 1;
						}
						else
						{
							fishingPole = 45;
							shootSpeed = 16.5f;
							rare = 3;
							value = sellPrice(0, 10);
						}
						return;
					}
					if (type == 2320)
					{
						name = "Rockfish";
						autoReuse = true;
						width = 26;
						height = 26;
						value = sellPrice(0, 1, 50);
						useStyle = 1;
						useAnimation = 24;
						useTime = 14;
						hammer = 70;
						knockBack = 6f;
						damage = 24;
						scale = 1.05f;
						useSound = 1;
						rare = 3;
						melee = true;
						return;
					}
					switch (type)
					{
					case 2314:
						name = "Honeyfin";
						maxStack = 30;
						width = 26;
						height = 26;
						value = sellPrice(0, 0, 15);
						rare = 1;
						useSound = 3;
						healLife = 120;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						consumable = true;
						potion = true;
						return;
					case 2290:
					case 2291:
					case 2292:
					case 2293:
					case 2294:
					case 2295:
					case 2296:
					case 2297:
					case 2298:
					case 2299:
					case 2300:
					case 2301:
					case 2302:
					case 2303:
					case 2304:
					case 2305:
					case 2306:
					case 2307:
					case 2308:
					case 2309:
					case 2310:
					case 2311:
					case 2312:
					case 2313:
					case 2315:
					case 2316:
					case 2317:
					case 2318:
					case 2319:
					case 2320:
					case 2321:
						name = "Fish";
						maxStack = 999;
						width = 26;
						height = 26;
						value = sellPrice(0, 0, 5);
						if (type == 2308)
						{
							value = sellPrice(0, 10);
							rare = 4;
						}
						if (type == 2312)
						{
							value = sellPrice(0, 0, 50);
							rare = 2;
						}
						if (type == 2317)
						{
							value = sellPrice(0, 3);
							rare = 4;
						}
						if (type == 2310)
						{
							value = sellPrice(0, 1);
							rare = 3;
						}
						if (type == 2321)
						{
							value = sellPrice(0, 0, 25);
							rare = 1;
						}
						if (type == 2315)
						{
							value = sellPrice(0, 0, 15);
							rare = 2;
						}
						if (type == 2303)
						{
							value = sellPrice(0, 0, 15);
							rare = 1;
						}
						if (type == 2304)
						{
							value = sellPrice(0, 0, 30);
							rare = 1;
						}
						if (type == 2316)
						{
							value = sellPrice(0, 0, 15);
						}
						if (type == 2311)
						{
							value = sellPrice(0, 0, 15);
							rare = 1;
						}
						if (type == 2313)
						{
							value = sellPrice(0, 0, 15);
							rare = 1;
						}
						if (type == 2306)
						{
							value = sellPrice(0, 0, 15);
							rare = 1;
						}
						if (type == 2307)
						{
							value = sellPrice(0, 0, 25);
							rare = 2;
						}
						if (type == 2319)
						{
							value = sellPrice(0, 0, 15);
							rare = 1;
						}
						if (type == 2318)
						{
							value = sellPrice(0, 0, 15);
							rare = 1;
						}
						if (type == 2298)
						{
							value = sellPrice(0, 0, 7, 50);
						}
						if (type == 2309)
						{
							value = sellPrice(0, 0, 7, 50);
							rare = 1;
						}
						if (type == 2300)
						{
							value = sellPrice(0, 0, 7, 50);
						}
						if (type == 2301)
						{
							value = sellPrice(0, 0, 7, 50);
						}
						if (type == 2302)
						{
							value = sellPrice(0, 0, 15);
						}
						if (type == 2299)
						{
							value = sellPrice(0, 0, 7, 50);
						}
						if (type == 2305)
						{
							value = sellPrice(0, 0, 7, 50);
							rare = 1;
						}
						return;
					}
					switch (type)
					{
					case 2322:
						name = "Mining Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 104;
						buffTime = 18000;
						toolTip = "Increases mining speed";
						value = 1000;
						rare = 1;
						return;
					case 2323:
						name = "Heartreach Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 105;
						buffTime = 28800;
						toolTip = "Increases pickup range for life hearts";
						value = 1000;
						rare = 1;
						return;
					case 2324:
						name = "Calming Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 106;
						buffTime = 18000;
						toolTip = "Reduces enemy aggression and spawn rate";
						value = 1000;
						rare = 1;
						return;
					case 2325:
						name = "Builder Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 107;
						buffTime = 54000;
						toolTip = "Increases placement speed and range";
						value = 1000;
						rare = 1;
						return;
					case 2326:
						name = "Titan Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 108;
						buffTime = 14400;
						toolTip = "Increases knockback";
						value = 1000;
						rare = 1;
						return;
					case 2327:
						name = "Flipper Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 109;
						buffTime = 28800;
						toolTip = "Lets you to move swiftly in liquids";
						value = 1000;
						rare = 1;
						return;
					case 2328:
						name = "Summoning Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 110;
						buffTime = 21600;
						toolTip = "Increases your max number of minions";
						value = 1000;
						rare = 1;
						return;
					case 2329:
						name = "Trapsight Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 111;
						buffTime = 36000;
						toolTip = "Allows you to see nearby traps";
						value = 1000;
						rare = 1;
						return;
					case 2330:
						name = "Purple Clubberfish";
						autoReuse = true;
						useStyle = 1;
						useAnimation = 35;
						width = 24;
						height = 28;
						damage = 24;
						knockBack = 7f;
						scale = 1.15f;
						useSound = 1;
						rare = 1;
						value = sellPrice(0, 1);
						melee = true;
						return;
					case 2331:
						name = "Obsidian Swordfish";
						useStyle = 5;
						useAnimation = 20;
						useTime = 20;
						shootSpeed = 4f;
						knockBack = 6.5f;
						width = 40;
						height = 40;
						damage = 70;
						crit = 20;
						useSound = 1;
						shoot = 367;
						rare = 7;
						value = sellPrice(0, 1);
						noMelee = true;
						noUseGraphic = true;
						melee = true;
						return;
					case 2332:
						name = "Swordfish";
						useStyle = 5;
						useAnimation = 20;
						useTime = 20;
						shootSpeed = 4f;
						knockBack = 5f;
						width = 40;
						height = 40;
						damage = 16;
						useSound = 1;
						shoot = 368;
						rare = 2;
						value = sellPrice(0, 0, 50);
						noMelee = true;
						noUseGraphic = true;
						melee = true;
						return;
					case 2333:
						name = "Iron Fence";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 7;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createWall = 145;
						width = 12;
						height = 12;
						return;
					case 2334:
						name = "Wooden Crate";
						width = 12;
						height = 12;
						rare = 1;
						toolTip = "Right click to open";
						maxStack = 99;
						value = sellPrice(0, 0, 10);
						return;
					case 2335:
						name = "Iron Crate";
						width = 12;
						height = 12;
						rare = 2;
						toolTip = "Right click to open";
						maxStack = 99;
						value = sellPrice(0, 0, 50);
						return;
					case 2336:
						name = "Golden Crate";
						width = 12;
						height = 12;
						rare = 3;
						toolTip = "Right click to open";
						maxStack = 99;
						value = sellPrice(0, 2);
						return;
					case 2337:
					case 2338:
					case 2339:
						name = "Junk";
						width = 12;
						height = 12;
						rare = -1;
						maxStack = 99;
						return;
					}
					switch (type)
					{
					case 2340:
						name = "Tracks";
						useStyle = 1;
						useAnimation = 15;
						useTime = 7;
						useTurn = true;
						autoReuse = true;
						width = 16;
						height = 16;
						maxStack = 999;
						createTile = 314;
						placeStyle = 0;
						consumable = true;
						cartTrack = true;
						tileBoost = 1;
						return;
					case 2341:
						name = "Reaver Shark";
						useStyle = 1;
						useTurn = true;
						useAnimation = 22;
						useTime = 18;
						autoReuse = true;
						width = 24;
						height = 28;
						damage = 16;
						pick = 100;
						scale = 1.15f;
						useSound = 1;
						knockBack = 3f;
						rare = 3;
						value = sellPrice(0, 1, 50);
						melee = true;
						return;
					case 2342:
						name = "Sawtooth Shark";
						useStyle = 5;
						useAnimation = 25;
						useTime = 8;
						shootSpeed = 48f;
						knockBack = 2.25f;
						width = 20;
						height = 12;
						damage = 13;
						axe = 14;
						useSound = 23;
						shoot = 369;
						rare = 3;
						value = sellPrice(0, 1, 50);
						noMelee = true;
						noUseGraphic = true;
						melee = true;
						channel = true;
						return;
					case 2343:
						name = "Minecart";
						width = 48;
						height = 28;
						return;
					case 2344:
						name = "Ammo Reservation Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 112;
						buffTime = 25200;
						toolTip = "Gives 15% chance to not consume ammo";
						value = 1000;
						rare = 1;
						return;
					case 2345:
						name = "Lifeforce Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 113;
						buffTime = 18000;
						toolTip = "Increases max life by 20%";
						value = 1000;
						rare = 1;
						return;
					case 2346:
						name = "Endurance Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 114;
						buffTime = 14400;
						toolTip = "Reduces damage taken by 10%";
						value = 1000;
						rare = 1;
						return;
					case 2347:
						name = "Rage Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 115;
						buffTime = 14400;
						toolTip = "Increases critical strike chance by 10%";
						value = 1000;
						rare = 1;
						return;
					case 2348:
						name = "Inferno Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 116;
						buffTime = 14400;
						toolTip = "Ignites nearby enemies";
						value = 1000;
						rare = 1;
						return;
					case 2349:
						name = "Wrath Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 117;
						buffTime = 14400;
						toolTip = "Increases damage by 10%";
						value = 1000;
						rare = 1;
						return;
					case 2350:
						name = "Recall Potion";
						useSound = 6;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						toolTip = "Teleports you home";
						value = 1000;
						rare = 1;
						return;
					case 2351:
						name = "Teleportation Potion";
						useSound = 6;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						toolTip = "Teleports you to a random location";
						value = 1000;
						rare = 1;
						return;
					case 2352:
						useStyle = 1;
						name = "Love Potion";
						shootSpeed = 9f;
						shoot = 370;
						width = 18;
						height = 20;
						maxStack = 99;
						consumable = true;
						useSound = 1;
						useAnimation = 15;
						useTime = 15;
						noUseGraphic = true;
						noMelee = true;
						value = 200;
						toolTip = "Throw at someone to make them fall in love";
						return;
					case 2353:
						useStyle = 1;
						name = "Stink Potion";
						shootSpeed = 9f;
						shoot = 371;
						width = 18;
						height = 20;
						maxStack = 99;
						consumable = true;
						useSound = 1;
						useAnimation = 15;
						useTime = 15;
						noUseGraphic = true;
						noMelee = true;
						value = 200;
						toolTip = "Throw at someone to make them smell terrible";
						return;
					case 2354:
						name = "Fishing Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 121;
						buffTime = 28800;
						toolTip = "Increases fishing skill";
						rare = 1;
						return;
					case 2355:
						name = "Sonar Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 122;
						buffTime = 14400;
						value = 1000;
						rare = 1;
						return;
					case 2356:
						name = "Crate Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 123;
						buffTime = 10800;
						value = 1000;
						rare = 1;
						return;
					case 2357:
						name = "Shiverthorn Seeds";
						useTurn = true;
						useStyle = 1;
						useAnimation = 15;
						useTime = 10;
						maxStack = 99;
						consumable = true;
						createTile = 82;
						placeStyle = 6;
						width = 12;
						height = 14;
						value = 80;
						return;
					case 2358:
						name = "Shiverthorn";
						maxStack = 99;
						width = 12;
						height = 14;
						value = 100;
						return;
					case 2359:
						name = "Warmth Potion";
						useSound = 3;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 14;
						height = 24;
						buffType = 124;
						buffTime = 54000;
						toolTip = "Reduces damage from cold sources";
						value = 1000;
						rare = 1;
						return;
					case 2360:
						noUseGraphic = true;
						damage = 0;
						useStyle = 5;
						name = "Fish Hook";
						shootSpeed = 13f;
						shoot = 372;
						width = 18;
						height = 28;
						useSound = 1;
						useAnimation = 20;
						useTime = 20;
						rare = 3;
						noMelee = true;
						value = 20000;
						return;
					case 2361:
						name = "Bee Headgear";
						width = 18;
						height = 18;
						defense = 4;
						headSlot = 160;
						rare = 3;
						value = 45000;
						toolTip = "Increases minion damage by 4%";
						return;
					case 2362:
						name = "Bee Breastplate";
						width = 18;
						height = 18;
						defense = 5;
						bodySlot = 168;
						rare = 3;
						value = 30000;
						toolTip = "Increases minion damage by 6%";
						return;
					case 2363:
						name = "Bee Greaves";
						width = 18;
						height = 18;
						defense = 4;
						legSlot = 103;
						rare = 3;
						value = 30000;
						toolTip = "Increases minion damage by 5%";
						return;
					case 2364:
						mana = 10;
						damage = 9;
						useStyle = 1;
						name = "Hornet Staff";
						shootSpeed = 10f;
						shoot = 373;
						width = 26;
						height = 28;
						useSound = 44;
						useAnimation = 22;
						useTime = 22;
						rare = 3;
						noMelee = true;
						knockBack = 2f;
						toolTip = "Summons a hornet to fight for you";
						buffType = 125;
						value = 10000;
						summon = true;
						return;
					case 2365:
						mana = 10;
						damage = 21;
						useStyle = 1;
						name = "Imp Staff";
						shootSpeed = 10f;
						shoot = 375;
						width = 26;
						height = 28;
						useSound = 44;
						useAnimation = 36;
						useTime = 36;
						rare = 3;
						noMelee = true;
						knockBack = 2f;
						toolTip = "Summons an imp to fight for you";
						buffType = 126;
						value = 10000;
						summon = true;
						return;
					case 2366:
						mana = 10;
						damage = 19;
						name = "Spider Queen Staff";
						useStyle = 1;
						shootSpeed = 14f;
						shoot = 377;
						width = 18;
						height = 20;
						useSound = 1;
						useAnimation = 30;
						useTime = 30;
						noMelee = true;
						value = sellPrice(0, 5);
						knockBack = 7.5f;
						rare = 4;
						summon = true;
						return;
					case 2367:
						name = "Angler Hat";
						width = 18;
						height = 18;
						defense = 1;
						headSlot = 161;
						rare = 1;
						value = sellPrice(0, 1);
						return;
					case 2368:
						name = "Angler Vest";
						width = 18;
						height = 18;
						bodySlot = 169;
						defense = 2;
						rare = 1;
						value = sellPrice(0, 1);
						return;
					case 2369:
						name = "Angler Pants";
						width = 18;
						height = 18;
						legSlot = 104;
						defense = 1;
						rare = 1;
						value = sellPrice(0, 1);
						return;
					case 2370:
						name = "Spider Mask";
						width = 18;
						height = 18;
						headSlot = 162;
						rare = 4;
						value = sellPrice(0, 0, 75);
						toolTip = "Increases your max number of minions";
						toolTip2 = "Increases minion damage by 5%";
						defense = 5;
						return;
					case 2371:
						name = "Spider Breastplate";
						width = 18;
						height = 18;
						bodySlot = 170;
						rare = 4;
						value = sellPrice(0, 0, 75);
						toolTip = "Increases your max number of minions";
						toolTip2 = "Increases minion damage by 6%";
						defense = 8;
						return;
					case 2372:
						name = "Spider Greaves";
						width = 18;
						height = 18;
						legSlot = 105;
						rare = 4;
						value = sellPrice(0, 0, 75);
						toolTip = "Increases your max number of minions";
						toolTip2 = "Increases minion damage by 6%";
						defense = 7;
						return;
					case 2373:
					case 2374:
					case 2375:
						name = "Fishing Accessories";
						width = 26;
						height = 30;
						maxStack = 1;
						value = sellPrice(0, 1);
						rare = 1;
						accessory = true;
						return;
					}
					if (type >= 2376 && type <= 2385)
					{
						name = "More Pianos";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 87;
						placeStyle = 11 + type - 2376;
						width = 20;
						height = 20;
						value = 300;
						return;
					}
					if (type >= 2386 && type <= 2396)
					{
						name = "More Dressers";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 88;
						placeStyle = 5 + type - 2386;
						width = 20;
						height = 20;
						value = 300;
						return;
					}
					if (type >= 2397 && type <= 2416)
					{
						name = "Sofas";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 89;
						placeStyle = 1 + type - 2397;
						width = 20;
						height = 20;
						value = 300;
						return;
					}
					switch (type)
					{
					case 2417:
						name = "Seashell Hairpin";
						width = 18;
						height = 18;
						headSlot = 163;
						vanity = true;
						value = sellPrice(0, 1);
						return;
					case 2418:
						name = "Mermaid Adornment";
						width = 18;
						height = 18;
						bodySlot = 171;
						vanity = true;
						value = sellPrice(0, 1);
						return;
					case 2419:
						name = "Mermaid Tail";
						width = 18;
						height = 18;
						legSlot = 106;
						vanity = true;
						value = sellPrice(0, 1);
						return;
					case 2420:
						damage = 0;
						useStyle = 1;
						name = "Zephyr Fish";
						shoot = 380;
						width = 16;
						height = 30;
						useSound = 2;
						useAnimation = 20;
						useTime = 20;
						rare = 3;
						noMelee = true;
						toolTip = "Summons a Zephyr Fish";
						value = sellPrice(0, 3);
						buffType = 127;
						return;
					case 2423:
						name = "Frog Leg";
						width = 16;
						height = 24;
						accessory = true;
						rare = 1;
						toolTip = "Increases Jump Speed";
						toolTip2 = "Allows constant jumping";
						value = 50000;
						shoeSlot = 15;
						return;
					case 2424:
						noMelee = true;
						useStyle = 1;
						name = "Anchor";
						shootSpeed = 20f;
						shoot = 383;
						damage = 30;
						knockBack = 5f;
						width = 34;
						height = 34;
						useSound = 1;
						useAnimation = 30;
						useTime = 30;
						noUseGraphic = true;
						rare = 3;
						value = 50000;
						melee = true;
						return;
					case 2425:
					case 2426:
					case 2427:
						name = "Fishing Food";
						useSound = 2;
						useStyle = 2;
						useTurn = true;
						useAnimation = 17;
						useTime = 17;
						maxStack = 30;
						consumable = true;
						width = 10;
						height = 10;
						buffType = 26;
						buffTime = 10800;
						rare = 1;
						toolTip = "Minor improvements to all stats";
						value = sellPrice(0, 0, 5);
						return;
					}
					switch (type)
					{
					case 2428:
						useStyle = 1;
						name = "Fuzzy Carrot";
						width = 16;
						height = 30;
						useSound = 25;
						useAnimation = 20;
						useTime = 20;
						rare = 8;
						noMelee = true;
						mountType = 1;
						value = sellPrice(0, 5);
						return;
					case 2429:
						useStyle = 1;
						name = "Scaly Truffle";
						width = 16;
						height = 30;
						useSound = 25;
						useAnimation = 20;
						useTime = 20;
						rare = 8;
						noMelee = true;
						mountType = 2;
						value = sellPrice(0, 5);
						return;
					case 2430:
						useStyle = 1;
						name = "Slimy Saddle";
						width = 16;
						height = 30;
						useSound = 25;
						useAnimation = 20;
						useTime = 20;
						rare = 8;
						noMelee = true;
						mountType = 3;
						value = sellPrice(0, 5);
						return;
					case 2431:
						name = "Bee Wax";
						width = 18;
						height = 16;
						maxStack = 99;
						value = 100;
						return;
					case 2432:
					case 2433:
					case 2434:
						name = "Some walls";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 7;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createWall = 146 + type - 2432;
						width = 12;
						height = 12;
						if (type == 2434)
						{
							value = buyPrice(0, 0, 0, 50);
						}
						return;
					}
					switch (type)
					{
					case 2435:
						name = "Coralstone Block";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 315;
						width = 12;
						height = 12;
						value = buyPrice(0, 0, 0, 50);
						return;
					case 2436:
					case 2437:
					case 2438:
						name = "Jellyfish(es)";
						useStyle = 1;
						autoReuse = true;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 999;
						consumable = true;
						width = 12;
						height = 12;
						noUseGraphic = true;
						bait = 20;
						return;
					}
					if (type >= 2439 && type <= 2441)
					{
						name = "Jellyfish Jar";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 316 + type - 2439;
						width = 12;
						height = 12;
						return;
					}
					if (type >= 2442 && type <= 2449)
					{
						name = "Fishing Wall Hangings";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 240;
						width = 30;
						height = 30;
						value = sellPrice(0, 0, 10);
						placeStyle = 46 + type - 2442;
						return;
					}
					if (type >= 2450 && type <= 2488)
					{
						name = "Quest Fish";
						questItem = true;
						maxStack = 1;
						width = 26;
						height = 26;
						uniqueStack = true;
						rare = -11;
						return;
					}
					switch (type)
					{
					case 2489:
						name = "King Slime Trophy";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 240;
						width = 30;
						height = 30;
						value = sellPrice(0, 1);
						placeStyle = 54;
						rare = 1;
						return;
					case 2490:
						name = "Ship in a Bottle";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 319;
						width = 12;
						height = 12;
						value = buyPrice(0, 10);
						return;
					case 2491:
						useStyle = 1;
						name = "Hardy Saddle";
						width = 16;
						height = 30;
						useSound = 25;
						useAnimation = 20;
						useTime = 20;
						rare = 8;
						noMelee = true;
						mountType = 4;
						value = sellPrice(0, 5);
						return;
					case 2492:
						name = "Pressure Track";
						useStyle = 1;
						useAnimation = 15;
						useTime = 7;
						useTurn = true;
						autoReuse = true;
						width = 16;
						height = 16;
						maxStack = 99;
						createTile = 314;
						placeStyle = 1;
						consumable = true;
						cartTrack = true;
						mech = true;
						tileBoost = 1;
						value = sellPrice(0, 0, 10);
						return;
					case 2493:
						name = "King Slime Mask";
						width = 28;
						height = 20;
						headSlot = 164;
						rare = 1;
						vanity = true;
						return;
					case 2494:
						name = "Fin Wings";
						width = 22;
						height = 20;
						accessory = true;
						toolTip = "Allows flight and slow fall";
						value = buyPrice(0, 1);
						rare = 4;
						wingSlot = 25;
						return;
					case 2495:
						name = "Treasure Map";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 242;
						width = 30;
						height = 30;
						value = buyPrice(0, 1);
						placeStyle = 25;
						return;
					case 2496:
						name = "Seaweed Planter";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 320;
						placeStyle = 0;
						width = 22;
						height = 30;
						value = buyPrice(0, 0, 1);
						return;
					case 2497:
						name = "Pillagin Me Pixels";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 242;
						width = 30;
						height = 30;
						value = buyPrice(0, 1);
						placeStyle = 26;
						return;
					case 2498:
						name = "Fish Costume Mask";
						width = 18;
						height = 18;
						headSlot = 165;
						vanity = true;
						value = sellPrice(0, 1);
						return;
					case 2499:
						name = "Fish Costume Shirt";
						width = 18;
						height = 18;
						bodySlot = 172;
						vanity = true;
						value = sellPrice(0, 1);
						return;
					case 2500:
						name = "Fish Costume Finskirt";
						width = 18;
						height = 18;
						legSlot = 107;
						vanity = true;
						value = sellPrice(0, 1);
						return;
					case 2501:
						name = "Ginger Beard";
						width = 18;
						height = 12;
						maxStack = 1;
						value = buyPrice(0, 40);
						rare = 5;
						accessory = true;
						faceSlot = 8;
						vanity = true;
						return;
					case 2502:
						useStyle = 1;
						name = "Honeyed Goggles";
						width = 16;
						height = 30;
						useSound = 25;
						useAnimation = 20;
						useTime = 20;
						rare = 8;
						noMelee = true;
						mountType = 5;
						value = sellPrice(0, 5);
						return;
					case 2503:
						name = "Boreal Wood";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 321;
						width = 8;
						height = 10;
						return;
					case 2504:
						name = "Palm Wood";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 322;
						width = 8;
						height = 10;
						return;
					case 2505:
						name = "Boreal Wood Wall";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 7;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createWall = 149;
						width = 12;
						height = 12;
						return;
					case 2506:
						name = "Palm Wood Wall";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 7;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createWall = 151;
						width = 12;
						height = 12;
						return;
					case 2507:
						name = "Boreal Wood Fence";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 7;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createWall = 150;
						width = 12;
						height = 12;
						return;
					case 2508:
						name = "Palm Wood Fence";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 7;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createWall = 152;
						width = 12;
						height = 12;
						return;
					case 2509:
						name = "Boreal Wood Helmet";
						width = 18;
						height = 18;
						defense = 1;
						headSlot = 166;
						return;
					case 2510:
						name = "Boreal Wood Breastplate";
						width = 18;
						height = 18;
						defense = 1;
						bodySlot = 173;
						return;
					case 2511:
						name = "Boreal Wood Greaves";
						width = 18;
						height = 18;
						defense = 1;
						legSlot = 108;
						return;
					case 2512:
						name = "Palm Wood Helmet";
						width = 18;
						height = 18;
						defense = 1;
						headSlot = 167;
						return;
					case 2513:
						name = "Palm Wood Breastplate";
						width = 18;
						height = 18;
						defense = 1;
						bodySlot = 174;
						return;
					case 2514:
						name = "Palm Wood Greaves";
						width = 18;
						height = 18;
						defense = 1;
						legSlot = 109;
						return;
					case 2517:
						name = "Palm Wood Sword";
						useStyle = 1;
						useTurn = false;
						useAnimation = 23;
						useTime = 23;
						width = 24;
						height = 28;
						damage = 8;
						knockBack = 5f;
						useSound = 1;
						scale = 1f;
						value = 100;
						melee = true;
						return;
					case 2516:
						name = "Palm Wood Hammer";
						autoReuse = true;
						useStyle = 1;
						useTurn = true;
						useAnimation = 33;
						useTime = 23;
						hammer = 35;
						width = 24;
						height = 28;
						damage = 4;
						knockBack = 5.5f;
						scale = 1.1f;
						useSound = 1;
						value = 50;
						melee = true;
						return;
					case 2515:
						name = "Palm Wood Bow";
						useStyle = 5;
						useAnimation = 29;
						useTime = 29;
						width = 12;
						height = 28;
						shoot = 1;
						useAmmo = 1;
						useSound = 5;
						damage = 6;
						shootSpeed = 6.6f;
						noMelee = true;
						value = 100;
						ranged = true;
						return;
					case 2518:
						name = "Palm Wood Platform";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 19;
						placeStyle = 17;
						width = 8;
						height = 10;
						return;
					case 2519:
						name = "Palm Wood Bathtub";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 90;
						placeStyle = 17;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2520:
						name = "Palm Wood Bed";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 99;
						consumable = true;
						autoReuse = true;
						createTile = 79;
						placeStyle = 22;
						width = 28;
						height = 20;
						value = 2000;
						return;
					case 2521:
						name = "Palm Wood Bench";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 89;
						placeStyle = 21;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2527:
						name = "Palm Wood Sofa";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 89;
						placeStyle = 22;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2522:
						name = "Palm Wood Candelabra";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 100;
						placeStyle = 18;
						width = 20;
						height = 20;
						value = 1500;
						return;
					case 2523:
						noWet = true;
						name = "Palm Wood Candle";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 33;
						placeStyle = 18;
						width = 8;
						height = 18;
						return;
					case 2524:
						name = "Palm Wood Chair";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 15;
						placeStyle = 29;
						width = 12;
						height = 30;
						return;
					case 2525:
						name = "Palm Wood Chandelier";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 34;
						placeStyle = 23;
						width = 26;
						height = 26;
						value = 3000;
						return;
					case 2526:
						name = "Palm Wood Chest";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 21;
						placeStyle = 31;
						width = 26;
						height = 22;
						value = 500;
						return;
					case 2528:
						name = "Palm Wood Door";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 99;
						consumable = true;
						createTile = 10;
						placeStyle = 29;
						width = 14;
						height = 28;
						value = 200;
						return;
					case 2529:
						name = "Palm Wood Dresser";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 88;
						placeStyle = 16;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2530:
						name = "Palm Wood Lantern";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 42;
						width = 12;
						height = 28;
						placeStyle = 27;
						return;
					case 2531:
						name = "Palm Wood Piano";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 87;
						placeStyle = 21;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2535:
						mana = 10;
						damage = 30;
						useStyle = 1;
						name = "Optic Staff";
						shootSpeed = 10f;
						shoot = 387;
						width = 26;
						height = 28;
						useSound = 44;
						useAnimation = 36;
						useTime = 36;
						rare = 5;
						noMelee = true;
						knockBack = 2f;
						toolTip = "Summons twins to fight for you";
						buffType = 134;
						value = buyPrice(0, 10);
						summon = true;
						return;
					case 2532:
						name = "Palm Wood Table";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 14;
						placeStyle = 26;
						width = 26;
						height = 20;
						value = 300;
						return;
					case 2533:
						name = "Palm Wood Lamp";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 93;
						placeStyle = 18;
						width = 10;
						height = 24;
						value = 500;
						return;
					case 2534:
						name = "Palm Wood Work Bench";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 18;
						placeStyle = 22;
						width = 28;
						height = 14;
						value = 150;
						toolTip = "Used for basic crafting";
						return;
					case 2536:
						name = "Palm Wood Bookcase";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 101;
						width = 20;
						height = 20;
						value = 300;
						placeStyle = 23;
						return;
					case 2549:
						name = "Mushroom Platform";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 19;
						placeStyle = 18;
						width = 8;
						height = 10;
						return;
					case 2537:
						name = "Mushroom Bathtub";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 90;
						placeStyle = 18;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2538:
						name = "Mushroom Bed";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 99;
						consumable = true;
						autoReuse = true;
						createTile = 79;
						placeStyle = 23;
						width = 28;
						height = 20;
						value = 2000;
						return;
					case 2539:
						name = "Mushroom Bench";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 89;
						placeStyle = 23;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2540:
						name = "Mushroom Bookcase";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 101;
						width = 20;
						height = 20;
						value = 300;
						placeStyle = 24;
						return;
					case 2541:
						name = "Mushroom Candelabra";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 100;
						placeStyle = 19;
						width = 20;
						height = 20;
						value = 1500;
						return;
					case 2542:
						noWet = true;
						name = "Mushroom Candle";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 33;
						placeStyle = 19;
						width = 8;
						height = 18;
						return;
					case 2543:
						name = "Mushroom Chandelier";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 34;
						placeStyle = 24;
						width = 26;
						height = 26;
						value = 3000;
						return;
					case 2544:
						name = "Mushroom Chest";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 21;
						placeStyle = 32;
						width = 26;
						height = 22;
						value = 500;
						return;
					case 2545:
						name = "Mushroom Dresser";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 88;
						placeStyle = 17;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2547:
						name = "Mushroom Lamp";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 93;
						placeStyle = 19;
						width = 10;
						height = 24;
						value = 500;
						return;
					case 2546:
						name = "Mushroom Lantern";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 42;
						width = 12;
						height = 28;
						placeStyle = 28;
						return;
					case 2548:
						name = "Mushroom Piano";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 87;
						placeStyle = 22;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2413:
						name = "Mushroom Sofa";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 89;
						placeStyle = 23;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2550:
						name = "Mushroom Table";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 14;
						placeStyle = 27;
						width = 26;
						height = 20;
						value = 300;
						return;
					case 2551:
						mana = 10;
						damage = 25;
						useStyle = 1;
						name = "Spider Staff";
						shootSpeed = 10f;
						shoot = 390;
						width = 26;
						height = 28;
						useSound = 44;
						useAnimation = 36;
						useTime = 36;
						rare = 4;
						noMelee = true;
						knockBack = 2f;
						toolTip = "Summons spiders to fight for you";
						buffType = 133;
						value = buyPrice(0, 5);
						summon = true;
						return;
					case 2552:
						name = "Boreal Wood Bathtub";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 90;
						placeStyle = 19;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2553:
						name = "Boreal Wood Bed";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 99;
						consumable = true;
						autoReuse = true;
						createTile = 79;
						placeStyle = 24;
						width = 28;
						height = 20;
						value = 2000;
						return;
					case 2554:
						name = "Boreal Wood Bookcase";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 101;
						width = 20;
						height = 20;
						value = 300;
						placeStyle = 25;
						return;
					case 2555:
						name = "Boreal Wood Candelabra";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 100;
						placeStyle = 20;
						width = 20;
						height = 20;
						value = 1500;
						return;
					case 2556:
						noWet = true;
						name = "Boreal Wood Candle";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 33;
						placeStyle = 20;
						width = 8;
						height = 18;
						return;
					case 2557:
						name = "Boreal Wood Chair";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 15;
						placeStyle = 30;
						width = 12;
						height = 30;
						return;
					case 2558:
						name = "Boreal Wood Chandelier";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 34;
						placeStyle = 25;
						width = 26;
						height = 26;
						value = 3000;
						return;
					case 2559:
						name = "Boreal Wood Chest";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 21;
						placeStyle = 33;
						width = 26;
						height = 22;
						value = 500;
						return;
					case 2560:
						name = "Boreal Wood Clock";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 104;
						placeStyle = 6;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2561:
						name = "Boreal Wood Door";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 99;
						consumable = true;
						createTile = 10;
						placeStyle = 30;
						width = 14;
						height = 28;
						value = 200;
						return;
					case 2562:
						name = "Boreal Wood Dresser";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 88;
						placeStyle = 18;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2563:
						name = "Boreal Wood Lamp";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 93;
						placeStyle = 20;
						width = 10;
						height = 24;
						value = 500;
						return;
					case 2564:
						name = "Boreal Wood Lantern";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 42;
						placeStyle = 29;
						width = 12;
						height = 28;
						return;
					case 2565:
						name = "Boreal Wood Piano";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 87;
						placeStyle = 23;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2566:
						name = "Boreal Wood Platform";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 19;
						placeStyle = 19;
						width = 8;
						height = 10;
						return;
					case 2567:
						name = "Slime Bathtub";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 90;
						placeStyle = 20;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2568:
						name = "Slime Bed";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 99;
						consumable = true;
						autoReuse = true;
						createTile = 79;
						placeStyle = 25;
						width = 28;
						height = 20;
						value = 2000;
						return;
					case 2569:
						name = "Slime Bookcase";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 101;
						placeStyle = 26;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2570:
						name = "Slime Candelabra";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 100;
						placeStyle = 21;
						width = 20;
						height = 20;
						value = 1500;
						return;
					case 2571:
						noWet = true;
						name = "Slime Candle";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 33;
						placeStyle = 21;
						width = 8;
						height = 18;
						return;
					case 2572:
						name = "Slime Chair";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 15;
						placeStyle = 31;
						width = 12;
						height = 30;
						return;
					case 2573:
						name = "Slime Chandelier";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 34;
						placeStyle = 26;
						width = 26;
						height = 26;
						value = 3000;
						return;
					case 2574:
						name = "Slime Chest";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 21;
						placeStyle = 34;
						width = 26;
						height = 22;
						value = 500;
						return;
					case 2575:
						name = "Slime Clock";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 104;
						placeStyle = 7;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2576:
						name = "Slime Door";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 99;
						consumable = true;
						createTile = 10;
						placeStyle = 31;
						width = 14;
						height = 28;
						value = 200;
						return;
					case 2577:
						name = "Slime Dresser";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 88;
						placeStyle = 19;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2578:
						name = "Slime Lamp";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 93;
						placeStyle = 21;
						width = 10;
						height = 24;
						value = 500;
						return;
					case 2579:
						name = "Slime Lantern";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 42;
						placeStyle = 30;
						width = 12;
						height = 28;
						return;
					case 2580:
						name = "Slime Piano";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 87;
						placeStyle = 24;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2581:
						name = "Slime Platform";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 19;
						placeStyle = 20;
						width = 8;
						height = 10;
						return;
					case 2582:
						name = "Slime Sofa";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 89;
						placeStyle = 25;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2583:
						name = "Slime Table";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 14;
						placeStyle = 29;
						width = 26;
						height = 20;
						value = 300;
						return;
					case 2584:
						mana = 10;
						damage = 32;
						useStyle = 1;
						name = "Pirate Staff";
						shootSpeed = 10f;
						shoot = 393;
						width = 26;
						height = 28;
						useSound = 44;
						useAnimation = 36;
						useTime = 36;
						rare = 5;
						noMelee = true;
						knockBack = 2f;
						toolTip = "Summons pirates to fight for you";
						buffType = 135;
						value = buyPrice(0, 5);
						summon = true;
						return;
					case 2585:
						noUseGraphic = true;
						damage = 0;
						useStyle = 5;
						name = "Slime Hook";
						shootSpeed = 13f;
						shoot = 396;
						width = 18;
						height = 28;
						useSound = 1;
						useAnimation = 20;
						useTime = 20;
						rare = 3;
						noMelee = true;
						value = 20000;
						return;
					case 2586:
						useStyle = 5;
						name = "Sticky Grenade";
						shootSpeed = 5.5f;
						shoot = 397;
						width = 20;
						height = 20;
						maxStack = 99;
						consumable = true;
						useSound = 1;
						useAnimation = 45;
						useTime = 45;
						noUseGraphic = true;
						noMelee = true;
						value = 75;
						damage = 60;
						knockBack = 8f;
						toolTip = "A small explosion that will not destroy tiles";
						toolTip2 = "Tossing may be difficult";
						ranged = true;
						return;
					case 2587:
						damage = 0;
						useStyle = 1;
						name = "Tartar Sauce";
						shoot = 398;
						width = 16;
						height = 30;
						useSound = 2;
						useAnimation = 20;
						useTime = 20;
						rare = 3;
						noMelee = true;
						toolTip = "Summons a mini minotaur";
						buffType = 136;
						value = sellPrice(0, 2);
						return;
					case 2588:
						name = "Duke Fishron Mask";
						width = 28;
						height = 20;
						headSlot = 168;
						rare = 1;
						vanity = true;
						return;
					case 2589:
						name = "Duke Fishron Trophy";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 240;
						width = 30;
						height = 30;
						value = sellPrice(0, 1);
						placeStyle = 55;
						rare = 1;
						return;
					case 2590:
						useStyle = 5;
						name = "Molotov Cocktail";
						shootSpeed = 6.5f;
						shoot = 399;
						width = 20;
						height = 20;
						maxStack = 99;
						consumable = true;
						useSound = 1;
						useAnimation = 30;
						useTime = 30;
						noUseGraphic = true;
						noMelee = true;
						value = 75;
						damage = 40;
						knockBack = 8f;
						toolTip = "A small explosion that puts enemies on fire";
						toolTip2 = "Lights nearby area on fire for a while";
						ranged = true;
						return;
					case 2591:
					case 2592:
					case 2593:
					case 2594:
					case 2595:
					case 2596:
					case 2597:
					case 2598:
					case 2599:
					case 2600:
					case 2601:
					case 2602:
					case 2603:
					case 2604:
					case 2605:
					case 2606:
						name = "Grandfather Clock";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 104;
						placeStyle = 8 + type - 2591;
						width = 20;
						height = 20;
						value = 300;
						return;
					}
					switch (type)
					{
					case 2607:
						name = "Spider Fang";
						maxStack = 99;
						width = 12;
						height = 12;
						rare = 4;
						value = sellPrice(0, 0, 5);
						return;
					case 2608:
						name = "Falcon Blade";
						useStyle = 1;
						useAnimation = 15;
						knockBack = 6f;
						width = 24;
						height = 28;
						damage = 25;
						scale = 1.05f;
						useSound = 1;
						rare = 4;
						value = 10000;
						melee = true;
						return;
					case 2609:
						name = "Fishron Wings";
						width = 22;
						height = 20;
						accessory = true;
						toolTip = "Allows flight and slow fall";
						value = buyPrice(0, 10);
						rare = 8;
						wingSlot = 26;
						return;
					case 2610:
						name = "Slime Gun";
						useStyle = 5;
						useAnimation = 12;
						useTime = 12;
						width = 38;
						height = 10;
						damage = 0;
						scale = 0.9f;
						shoot = 406;
						shootSpeed = 8f;
						autoReuse = true;
						value = buyPrice(0, 1, 50);
						return;
					case 2611:
						autoReuse = false;
						name = "Flairon";
						useStyle = 5;
						useAnimation = 20;
						useTime = 20;
						autoReuse = true;
						knockBack = 4.5f;
						width = 30;
						height = 10;
						damage = 66;
						shoot = 404;
						shootSpeed = 14f;
						useSound = 1;
						rare = 8;
						value = sellPrice(0, 5);
						melee = true;
						noUseGraphic = true;
						return;
					case 2612:
					case 2613:
					case 2614:
					case 2615:
					case 2616:
					case 2617:
					case 2618:
					case 2619:
					case 2620:
						name = "Many Chests";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 21;
						if (type <= 2614)
						{
							placeStyle = 35 + (type - 2612) * 2;
						}
						else
						{
							placeStyle = 41 + type - 2615;
						}
						width = 26;
						height = 22;
						value = 500;
						return;
					}
					switch (type)
					{
					case 2621:
						mana = 10;
						damage = 50;
						useStyle = 1;
						name = "Tempest Staff";
						shootSpeed = 10f;
						shoot = 407;
						width = 26;
						height = 28;
						useSound = 44;
						useAnimation = 36;
						useTime = 36;
						rare = 8;
						noMelee = true;
						knockBack = 2f;
						toolTip = "Summons sharknados to fight for you";
						buffType = 139;
						value = sellPrice(0, 5);
						summon = true;
						return;
					case 2624:
						useStyle = 5;
						useAnimation = 24;
						useTime = 24;
						name = "Tsunami";
						width = 50;
						height = 18;
						shoot = 1;
						useAmmo = 1;
						useSound = 5;
						damage = 60;
						shootSpeed = 10f;
						noMelee = true;
						value = sellPrice(0, 5);
						ranged = true;
						rare = 8;
						knockBack = 2f;
						return;
					case 2622:
						mana = 18;
						damage = 60;
						useStyle = 5;
						name = "Razorblade Typhoon";
						shootSpeed = 6f;
						shoot = 409;
						width = 26;
						height = 28;
						useSound = 8;
						useAnimation = 20;
						useTime = 20;
						autoReuse = true;
						rare = 8;
						noMelee = true;
						knockBack = 5f;
						scale = 0.9f;
						toolTip = "Casts a typhoon";
						value = sellPrice(0, 5);
						magic = true;
						return;
					case 2625:
					case 2626:
						name = "Beach Stuff";
						useStyle = 1;
						autoReuse = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 99;
						consumable = true;
						createTile = 324;
						if (type == 2626)
						{
							placeStyle = 1;
							width = 26;
							height = 24;
						}
						else
						{
							width = 22;
							height = 22;
						}
						return;
					case 2627:
					case 2628:
					case 2629:
					case 2630:
						name = "More Platforms";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 19;
						placeStyle = 21 + type - 2627;
						width = 8;
						height = 10;
						return;
					}
					if (type >= 2631 && type <= 2633)
					{
						name = "More Work Benches";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 18;
						placeStyle = 24 + type - 2631;
						width = 28;
						height = 14;
						value = 150;
						toolTip = "Used for basic crafting";
						return;
					}
					if (type >= 2634 && type <= 2636)
					{
						name = "Sofas";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 89;
						placeStyle = 26 + type - 2634;
						width = 20;
						height = 20;
						value = 300;
						return;
					}
					switch (type)
					{
					case 2623:
						autoReuse = true;
						name = "Bubble Gun";
						mana = 4;
						useSound = 39;
						useStyle = 5;
						damage = 70;
						useAnimation = 9;
						useTime = 9;
						width = 40;
						height = 40;
						shoot = 410;
						shootSpeed = 11f;
						knockBack = 3f;
						value = sellPrice(0, 5);
						magic = true;
						rare = 8;
						noMelee = true;
						return;
					case 2637:
					case 2638:
					case 2639:
					case 2640:
						name = "Dressers";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 88;
						placeStyle = 20 + type - 2637;
						width = 20;
						height = 20;
						value = 300;
						return;
					}
					switch (type)
					{
					case 2641:
					case 2642:
						name = "Lantern 1";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 42;
						if (type == 2641)
						{
							placeStyle = 31;
						}
						else
						{
							placeStyle = 32;
						}
						width = 12;
						height = 28;
						return;
					case 2643:
					case 2644:
					case 2645:
					case 2646:
					case 2647:
						name = "More Lamps";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 93;
						placeStyle = 22 + type - 2643;
						width = 10;
						height = 24;
						value = 500;
						return;
					}
					if (type >= 2648 && type <= 2651)
					{
						noWet = true;
						name = "even more candles";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 33;
						width = 8;
						height = 18;
						placeStyle = 22 + type - 2648;
						return;
					}
					if (type >= 2652 && type <= 2657)
					{
						name = "More Chandeliers";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 34;
						placeStyle = 27 + type - 2652;
						width = 26;
						height = 26;
						value = 3000;
						return;
					}
					if (type >= 2658 && type <= 2663)
					{
						name = "more bathtubs";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 90;
						placeStyle = 21 + type - 2658;
						width = 20;
						height = 20;
						value = 300;
						return;
					}
					if (type >= 2664 && type <= 2668)
					{
						name = "even more candelabras";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 100;
						placeStyle = 22 + type - 2664;
						width = 20;
						height = 20;
						value = 1500;
						return;
					}
					switch (type)
					{
					case 2669:
						name = "Pumpkin Bed";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 99;
						consumable = true;
						autoReuse = true;
						createTile = 79;
						placeStyle = 26;
						width = 28;
						height = 20;
						value = 2000;
						return;
					case 2670:
						name = "Pumpkin Bookcase";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 101;
						width = 20;
						height = 20;
						value = 300;
						placeStyle = 27;
						return;
					case 2671:
						name = "Pumpkin Piano";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 87;
						placeStyle = 25;
						width = 20;
						height = 20;
						value = 300;
						return;
					case 2672:
						name = "Shark Statue";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 105;
						width = 20;
						height = 20;
						value = 300;
						placeStyle = 50;
						return;
					case 2673:
						name = "Truffle Worm";
						useStyle = 1;
						autoReuse = true;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 999;
						consumable = true;
						width = 12;
						height = 12;
						makeNPC = 374;
						noUseGraphic = true;
						bait = 666;
						return;
					case 2674:
					case 2675:
					case 2676:
						name = "baits";
						maxStack = 999;
						consumable = true;
						width = 12;
						height = 12;
						bait = 15;
						if (type == 2675)
						{
							bait = 30;
						}
						if (type == 2676)
						{
							bait = 50;
						}
						return;
					}
					if (type >= 2677 && type <= 2690)
					{
						name = "gemspark walls";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						switch (type)
						{
						case 2677:
							createWall = 153;
							break;
						case 2678:
							createWall = 157;
							break;
						case 2679:
							createWall = 154;
							break;
						case 2680:
							createWall = 158;
							break;
						case 2681:
							createWall = 155;
							break;
						case 2682:
							createWall = 159;
							break;
						case 2683:
							createWall = 156;
							break;
						case 2684:
							createWall = 160;
							break;
						case 2685:
							createWall = 164;
							break;
						case 2686:
							createWall = 161;
							break;
						case 2687:
							createWall = 165;
							break;
						case 2688:
							createWall = 162;
							break;
						case 2689:
							createWall = 166;
							break;
						case 2690:
							createWall = 163;
							break;
						}
						width = 12;
						height = 12;
						return;
					}
					switch (type)
					{
					case 2691:
						name = "Tin Plating Wall";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 7;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createWall = 167;
						width = 12;
						height = 12;
						return;
					case 2692:
						name = "Tin Plating";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 325;
						width = 12;
						height = 12;
						return;
					case 2693:
						name = "Waterfall Block";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 326;
						width = 12;
						height = 12;
						return;
					case 2694:
						name = "Lavafall Block";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 327;
						width = 12;
						height = 12;
						return;
					case 2695:
						name = "Confetti Block";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 328;
						width = 12;
						height = 12;
						return;
					case 2696:
						name = "Confetti Wall";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 7;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createWall = 168;
						width = 12;
						height = 12;
						return;
					case 2697:
						name = "Confetti Block";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 329;
						width = 12;
						height = 12;
						return;
					case 2698:
						name = "Confetti Wall";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 7;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createWall = 169;
						width = 12;
						height = 12;
						return;
					case 2699:
						name = "Weapon Rack";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 334;
						width = 30;
						height = 30;
						value = sellPrice(0, 0, 10);
						return;
					case 2700:
						name = "Fireworks Box";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 335;
						width = 26;
						height = 22;
						value = buyPrice(0, 5);
						mech = true;
						return;
					case 2701:
						name = "Living Fire Block";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 999;
						consumable = true;
						createTile = 336;
						width = 12;
						height = 12;
						return;
					case 2702:
					case 2703:
					case 2704:
					case 2705:
					case 2706:
					case 2707:
					case 2708:
					case 2709:
					case 2710:
					case 2711:
					case 2712:
					case 2713:
					case 2714:
					case 2715:
					case 2716:
					case 2717:
					case 2718:
					case 2719:
					case 2720:
					case 2721:
					case 2722:
					case 2723:
					case 2724:
					case 2725:
					case 2726:
					case 2727:
					case 2728:
					case 2729:
					case 2730:
					case 2731:
					case 2732:
					case 2733:
					case 2734:
					case 2735:
					case 2736:
					case 2737:
						name = "statues";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 337;
						width = 20;
						height = 20;
						value = 300;
						placeStyle = type - 2702;
						return;
					}
					switch (type)
					{
					case 2738:
						name = "Firework Fountain";
						createTile = 338;
						placeStyle = 0;
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						width = 12;
						height = 30;
						value = buyPrice(0, 3);
						mech = true;
						break;
					case 2739:
						name = "Booster Track";
						useStyle = 1;
						useAnimation = 15;
						useTime = 7;
						useTurn = true;
						autoReuse = true;
						width = 16;
						height = 16;
						maxStack = 99;
						createTile = 314;
						placeStyle = 2;
						consumable = true;
						cartTrack = true;
						mech = true;
						tileBoost = 1;
						value = buyPrice(0, 0, 50);
						break;
					case 2740:
						name = "Grasshopper";
						useStyle = 1;
						autoReuse = true;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						maxStack = 999;
						consumable = true;
						width = 12;
						height = 12;
						makeNPC = 377;
						noUseGraphic = true;
						bait = 10;
						break;
					case 2741:
						name = "Critter Cage";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 339;
						width = 12;
						height = 12;
						break;
					case 2742:
						name = "Music Box (Underground Crimson)";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						consumable = true;
						createTile = 139;
						placeStyle = 31;
						width = 24;
						height = 24;
						rare = 4;
						value = 100000;
						accessory = true;
						break;
					case 2743:
						name = "Cactus Table";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 14;
						placeStyle = 30;
						width = 26;
						height = 20;
						value = 300;
						break;
					case 2744:
						name = "Cactus Platform";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 19;
						placeStyle = 25;
						width = 8;
						height = 10;
						break;
					case 2745:
						name = "Boreal Wood Sword";
						useStyle = 1;
						useTurn = false;
						useAnimation = 23;
						useTime = 23;
						width = 24;
						height = 28;
						damage = 8;
						knockBack = 5f;
						useSound = 1;
						scale = 1f;
						value = 100;
						melee = true;
						break;
					case 2746:
						name = "Boreal Wood Hammer";
						autoReuse = true;
						useStyle = 1;
						useTurn = true;
						useAnimation = 33;
						useTime = 23;
						hammer = 35;
						width = 24;
						height = 28;
						damage = 4;
						knockBack = 5.5f;
						scale = 1.1f;
						useSound = 1;
						value = 50;
						melee = true;
						break;
					case 2747:
						name = "Boreal Wood Bow";
						useStyle = 5;
						useAnimation = 29;
						useTime = 29;
						width = 12;
						height = 28;
						shoot = 1;
						useAmmo = 1;
						useSound = 5;
						damage = 6;
						shootSpeed = 6.6f;
						noMelee = true;
						value = 100;
						ranged = true;
						break;
					case 2748:
						name = "Glass Chest";
						useStyle = 1;
						useTurn = true;
						useAnimation = 15;
						useTime = 10;
						autoReuse = true;
						maxStack = 99;
						consumable = true;
						createTile = 21;
						placeStyle = 47;
						width = 26;
						height = 22;
						value = 500;
						break;
					}
					return;
				}
			}
			name = "Crafting Tables";
			useStyle = 1;
			useTurn = true;
			useAnimation = 15;
			useTime = 10;
			autoReuse = true;
			maxStack = 99;
			consumable = true;
			switch (type)
			{
			case 2203:
				createTile = 307;
				break;
			case 2204:
				createTile = 308;
				break;
			default:
				createTile = 300 + type - 2192;
				break;
			}
			width = 12;
			height = 12;
			value = buyPrice(0, 10);
		}

		public void SetDefaults(int Type, bool noMatCheck = false)
		{
			if (Main.netMode == 1 || Main.netMode == 2)
			{
				owner = 255;
			}
			else
			{
				owner = Main.myPlayer;
			}
			questItem = false;
			fishingPole = 0;
			bait = 0;
			hairDye = -1;
			makeNPC = 0;
			dye = 0;
			paint = 0;
			tileWand = -1;
			notAmmo = false;
			netID = 0;
			prefix = 0;
			crit = 0;
			mech = false;
			flame = false;
			reuseDelay = 0;
			melee = false;
			magic = false;
			ranged = false;
			summon = false;
			placeStyle = 0;
			buffTime = 0;
			buffType = 0;
			mountType = -1;
			cartTrack = false;
			material = false;
			noWet = false;
			vanity = false;
			mana = 0;
			wet = false;
			wetCount = 0;
			lavaWet = false;
			channel = false;
			manaIncrease = 0;
			release = 0;
			noMelee = false;
			noUseGraphic = false;
			lifeRegen = 0;
			shootSpeed = 0f;
			active = true;
			alpha = 0;
			ammo = 0;
			useAmmo = 0;
			autoReuse = false;
			accessory = false;
			axe = 0;
			healMana = 0;
			bodySlot = -1;
			legSlot = -1;
			headSlot = -1;
			potion = false;
			color = default(Color);
			consumable = false;
			createTile = -1;
			createWall = -1;
			damage = -1;
			defense = 0;
			hammer = 0;
			healLife = 0;
			holdStyle = 0;
			knockBack = 0f;
			maxStack = 1;
			pick = 0;
			rare = 0;
			scale = 1f;
			shoot = 0;
			stack = 1;
			toolTip = null;
			toolTip2 = null;
			tileBoost = 0;
			type = Type;
			useStyle = 0;
			useSound = 0;
			useTime = 100;
			useAnimation = 100;
			value = 0;
			useTurn = false;
			buy = false;
			handOnSlot = -1;
			handOffSlot = -1;
			backSlot = -1;
			frontSlot = -1;
			shoeSlot = -1;
			waistSlot = -1;
			wingSlot = -1;
			shieldSlot = -1;
			neckSlot = -1;
			faceSlot = -1;
			balloonSlot = -1;
			uniqueStack = false;
			if (type >= 2749)
			{
				type = 0;
			}
			if (type == 0)
			{
				netID = 0;
				name = "";
				stack = 0;
			}
			else if (type <= 1000)
			{
				SetDefaults1(type);
			}
			else if (type <= 2001)
			{
				SetDefaults2(type);
			}
			else
			{
				SetDefaults3(type);
			}
			if (dye > 0)
			{
				maxStack = 99;
			}
			netID = type;
			if (!noMatCheck)
			{
				checkMat();
			}
			name = Lang.itemName(netID);
			CheckTip();
		}

		public static string VersionName(string oldName, int release)
		{
			string result = oldName;
			if (release <= 4)
			{
				switch (oldName)
				{
				case "Cobalt Helmet":
					result = "Jungle Hat";
					break;
				case "Cobalt Breastplate":
					result = "Jungle Shirt";
					break;
				case "Cobalt Greaves":
					result = "Jungle Pants";
					break;
				}
			}
			if (release <= 13 && oldName == "Jungle Rose")
			{
				result = "Jungle Spores";
			}
			if (release <= 20)
			{
				switch (oldName)
				{
				case "Gills potion":
					result = "Gills Potion";
					break;
				case "Thorn Chakrum":
					result = "Thorn Chakram";
					break;
				case "Ball 'O Hurt":
					result = "Ball O' Hurt";
					break;
				}
			}
			if (release <= 41 && oldName == "Iron Chain")
			{
				result = "Chain";
			}
			if (release <= 44 && oldName == "Orb of Light")
			{
				result = "Shadow Orb";
			}
			if (release <= 46)
			{
				if (oldName == "Black Dye")
				{
					result = "Black Thread";
				}
				if (oldName == "Green Dye")
				{
					result = "Green Thread";
				}
			}
			return result;
		}

		public Color GetAlpha(Color newColor)
		{
			if (type == 75)
			{
				return new Color(255, 255, 255, newColor.A - alpha);
			}
			if (type == 121 || type == 122 || type == 217 || type == 218 || type == 219 || type == 220 || type == 120 || type == 119)
			{
				return new Color(255, 255, 255, 255);
			}
			if (type == 501)
			{
				return new Color(200, 200, 200, 50);
			}
			if (type == 757)
			{
				return new Color(255, 255, 255, 200);
			}
			if (type == 1306)
			{
				return new Color(255, 255, 255, 200);
			}
			if (type == 520 || type == 521 || type == 522 || type == 547 || type == 548 || type == 549 || type == 575 || type == 1332)
			{
				return new Color(255, 255, 255, 50);
			}
			if (type == 58 || type == 184 || type == 1734 || type == 1735 || type == 1867 || type == 1868)
			{
				return new Color(200, 200, 200, 200);
			}
			if (type == 1572)
			{
				return new Color(200, 200, 255, 125);
			}
			if (type == 787)
			{
				return new Color(255, 255, 255, 175);
			}
			if (type == 1826)
			{
				return new Color(255, 255, 255, 200);
			}
			if (type == 1508)
			{
				return new Color(200, 200, 200, 0);
			}
			if (type == 502)
			{
				return new Color(255, 255, 255, 150);
			}
			if (type == 51)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 1260)
			{
				return new Color(255, 255, 255, 175);
			}
			if (type == 1508)
			{
				return new Color(newColor.R, newColor.G, newColor.B, Main.gFade);
			}
			if (type == 1506 || type == 1507)
			{
				return new Color(newColor.R, newColor.G, newColor.B, Main.gFade);
			}
			if (type == 1446 || (type >= 1543 && type <= 1545))
			{
				return new Color(newColor.R, newColor.G, newColor.B, Main.gFade);
			}
			float num = (float)(255 - alpha) / 255f;
			int r = (int)((float)(int)newColor.R * num);
			int g = (int)((float)(int)newColor.G * num);
			int b = (int)((float)(int)newColor.B * num);
			int num2 = newColor.A - alpha;
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (type >= 198 && type <= 203)
			{
				return Color.White;
			}
			return new Color(r, g, b, num2);
		}

		public Color GetColor(Color newColor)
		{
			int num = color.R - (255 - newColor.R);
			int num2 = color.G - (255 - newColor.G);
			int num3 = color.B - (255 - newColor.B);
			int num4 = color.A - (255 - newColor.A);
			if (num < 0)
			{
				num = 0;
			}
			if (num > 255)
			{
				num = 255;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			return new Color(num, num2, num3, num4);
		}

		public static bool MechSpawn(float x, float y, int type)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.item[i].active && Main.item[i].type == type)
				{
					num++;
					Vector2 vector = new Vector2(x, y);
					float num4 = Main.item[i].position.X - vector.X;
					float num5 = Main.item[i].position.Y - vector.Y;
					float num6 = (float)Math.Sqrt(num4 * num4 + num5 * num5);
					if (num6 < 300f)
					{
						num2++;
					}
					if (num6 < 800f)
					{
						num3++;
					}
				}
			}
			if (num2 >= 3 || num3 >= 6 || num >= 10)
			{
				return false;
			}
			return true;
		}

		public static int buyPrice(int platinum = 0, int gold = 0, int silver = 0, int copper = 0)
		{
			int num = copper;
			num += silver * 100;
			num += gold * 100 * 100;
			return num + platinum * 100 * 100 * 100;
		}

		public static int sellPrice(int platinum = 0, int gold = 0, int silver = 0, int copper = 0)
		{
			int num = copper;
			num += silver * 100;
			num += gold * 100 * 100;
			num += platinum * 100 * 100 * 100;
			return num * 5;
		}

		public void UpdateItem(int i)
		{
			if (!active)
			{
				return;
			}
			if (Main.netMode == 0)
			{
				owner = Main.myPlayer;
			}
			float num = 0.1f;
			float num2 = 7f;
			if (Main.netMode == 1)
			{
				int num3 = (int)(position.X + (float)(width / 2)) / 16;
				int num4 = (int)(position.Y + (float)(height / 2)) / 16;
				if (num3 >= 0 && num4 >= 0 && num3 < Main.maxTilesX && num4 < Main.maxTilesY && Main.tile[num3, num4] == null)
				{
					num = 0f;
					velocity.X = 0f;
					velocity.Y = 0f;
				}
			}
			if (honeyWet)
			{
				num = 0.05f;
				num2 = 3f;
			}
			else if (wet)
			{
				num2 = 5f;
				num = 0.08f;
			}
			Vector2 vector = velocity * 0.5f;
			if (ownTime > 0)
			{
				ownTime--;
			}
			else
			{
				ownIgnore = -1;
			}
			if (keepTime > 0)
			{
				keepTime--;
			}
			if (!beingGrabbed)
			{
				if (owner == Main.myPlayer && (createTile >= 0 || createWall > 0 || (ammo > 0 && !notAmmo) || consumable || (type >= 71 && type <= 74) || (type >= 205 && type <= 207) || type == 1128 || type == 530) && stack < maxStack)
				{
					for (int j = i + 1; j < 400; j++)
					{
						if (!Main.item[j].active || Main.item[j].type != type || Main.item[j].stack <= 0 || Main.item[j].owner != owner)
						{
							continue;
						}
						float num5 = Math.Abs(position.X + (float)(width / 2) - (Main.item[j].position.X + (float)(Main.item[j].width / 2))) + Math.Abs(position.Y + (float)(height / 2) - (Main.item[j].position.Y + (float)(Main.item[j].height / 2)));
						if (num5 < 30f)
						{
							position = (position + Main.item[j].position) / 2f;
							velocity = (velocity + Main.item[j].velocity) / 2f;
							int num6 = Main.item[j].stack;
							if (num6 > maxStack - stack)
							{
								num6 = maxStack - stack;
							}
							Main.item[j].stack -= num6;
							stack += num6;
							if (Main.item[j].stack <= 0)
							{
								Main.item[j].SetDefaults(0);
								Main.item[j].active = false;
							}
							if (Main.netMode != 0)
							{
								NetMessage.SendData(21, -1, -1, "", i);
								NetMessage.SendData(21, -1, -1, "", j);
							}
						}
					}
				}
				if (type == 520 || type == 521 || type == 547 || type == 548 || type == 549 || type == 575)
				{
					velocity.X *= 0.95f;
					if ((double)velocity.X < 0.1 && (double)velocity.X > -0.1)
					{
						velocity.X = 0f;
					}
					velocity.Y *= 0.95f;
					if ((double)velocity.Y < 0.1 && (double)velocity.Y > -0.1)
					{
						velocity.Y = 0f;
					}
				}
				else
				{
					velocity.Y += num;
					if (velocity.Y > num2)
					{
						velocity.Y = num2;
					}
					velocity.X *= 0.95f;
					if ((double)velocity.X < 0.1 && (double)velocity.X > -0.1)
					{
						velocity.X = 0f;
					}
				}
				bool flag = Collision.LavaCollision(position, width, height);
				if (flag)
				{
					lavaWet = true;
				}
				bool flag2 = Collision.WetCollision(position, width, height);
				if (Collision.honey)
				{
					honeyWet = true;
				}
				if (flag2)
				{
					if (!wet)
					{
						if (wetCount == 0)
						{
							wetCount = 20;
							if (!flag)
							{
								if (honeyWet)
								{
									for (int k = 0; k < 5; k++)
									{
										int num7 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2) - 8f), width + 12, 24, 152);
										Main.dust[num7].velocity.Y -= 1f;
										Main.dust[num7].velocity.X *= 2.5f;
										Main.dust[num7].scale = 1.3f;
										Main.dust[num7].alpha = 100;
										Main.dust[num7].noGravity = true;
									}
									Main.PlaySound(19, (int)position.X, (int)position.Y);
								}
								else
								{
									for (int l = 0; l < 10; l++)
									{
										int num8 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2) - 8f), width + 12, 24, Dust.dustWater());
										Main.dust[num8].velocity.Y -= 4f;
										Main.dust[num8].velocity.X *= 2.5f;
										Main.dust[num8].scale *= 0.8f;
										Main.dust[num8].alpha = 100;
										Main.dust[num8].noGravity = true;
									}
									Main.PlaySound(19, (int)position.X, (int)position.Y);
								}
							}
							else
							{
								for (int m = 0; m < 5; m++)
								{
									int num9 = Dust.NewDust(new Vector2(position.X - 6f, position.Y + (float)(height / 2) - 8f), width + 12, 24, 35);
									Main.dust[num9].velocity.Y -= 1.5f;
									Main.dust[num9].velocity.X *= 2.5f;
									Main.dust[num9].scale = 1.3f;
									Main.dust[num9].alpha = 100;
									Main.dust[num9].noGravity = true;
								}
								Main.PlaySound(19, (int)position.X, (int)position.Y);
							}
						}
						wet = true;
					}
				}
				else if (wet)
				{
					wet = false;
				}
				if (!wet)
				{
					lavaWet = false;
					honeyWet = false;
				}
				if (wetCount > 0)
				{
					wetCount--;
				}
				if (wet)
				{
					if (wet)
					{
						Vector2 vector2 = velocity;
						velocity = Collision.TileCollision(position, velocity, width, height);
						if (velocity.X != vector2.X)
						{
							vector.X = velocity.X;
						}
						if (velocity.Y != vector2.Y)
						{
							vector.Y = velocity.Y;
						}
					}
				}
				else
				{
					velocity = Collision.TileCollision(position, velocity, width, height);
				}
				Vector4 vector3 = Collision.SlopeCollision(position, velocity, width, height, num);
				position.X = vector3.X;
				position.Y = vector3.Y;
				velocity.X = vector3.Z;
				velocity.Y = vector3.W;
				if (lavaWet)
				{
					if (type == 267)
					{
						if (Main.netMode != 1)
						{
							active = false;
							type = 0;
							name = "";
							stack = 0;
							for (int n = 0; n < 200; n++)
							{
								if (Main.npc[n].active && Main.npc[n].type == 22)
								{
									if (Main.netMode == 2)
									{
										NetMessage.SendData(28, -1, -1, "", n, 9999f, 10f, -Main.npc[n].direction);
									}
									Main.npc[n].StrikeNPC(9999, 10f, -Main.npc[n].direction);
									NPC.SpawnWOF(position);
								}
							}
							NetMessage.SendData(21, -1, -1, "", i);
						}
					}
					else if (owner == Main.myPlayer && type != 312 && type != 318 && type != 173 && type != 174 && type != 175 && type != 2701 && rare == 0)
					{
						active = false;
						type = 0;
						name = "";
						stack = 0;
						if (Main.netMode != 0)
						{
							NetMessage.SendData(21, -1, -1, "", i);
						}
					}
				}
				if (type == 520)
				{
					float num10 = (float)Main.rand.Next(90, 111) * 0.01f;
					num10 *= Main.essScale;
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.5f * num10, 0.1f * num10, 0.25f * num10);
				}
				else if (type == 521)
				{
					float num11 = (float)Main.rand.Next(90, 111) * 0.01f;
					num11 *= Main.essScale;
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.25f * num11, 0.1f * num11, 0.5f * num11);
				}
				else if (type == 547)
				{
					float num12 = (float)Main.rand.Next(90, 111) * 0.01f;
					num12 *= Main.essScale;
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.5f * num12, 0.3f * num12, 0.05f * num12);
				}
				else if (type == 548)
				{
					float num13 = (float)Main.rand.Next(90, 111) * 0.01f;
					num13 *= Main.essScale;
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.1f * num13, 0.1f * num13, 0.6f * num13);
				}
				else if (type == 575)
				{
					float num14 = (float)Main.rand.Next(90, 111) * 0.01f;
					num14 *= Main.essScale;
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.1f * num14, 0.3f * num14, 0.5f * num14);
				}
				else if (type == 549)
				{
					float num15 = (float)Main.rand.Next(90, 111) * 0.01f;
					num15 *= Main.essScale;
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.1f * num15, 0.5f * num15, 0.2f * num15);
				}
				else if (type == 58 || type == 1734 || type == 1867)
				{
					float num16 = (float)Main.rand.Next(90, 111) * 0.01f;
					num16 *= Main.essScale * 0.5f;
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.5f * num16, 0.1f * num16, 0.1f * num16);
				}
				else if (type == 184 || type == 1735 || type == 1868)
				{
					float num17 = (float)Main.rand.Next(90, 111) * 0.01f;
					num17 *= Main.essScale * 0.5f;
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.1f * num17, 0.1f * num17, 0.5f * num17);
				}
				else if (type == 522)
				{
					float num18 = (float)Main.rand.Next(90, 111) * 0.01f;
					num18 *= Main.essScale * 0.2f;
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.5f * num18, 1f * num18, 0.1f * num18);
				}
				else if (type == 1332)
				{
					float num19 = (float)Main.rand.Next(90, 111) * 0.01f;
					num19 *= Main.essScale * 0.2f;
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 1f * num19, 1f * num19, 0.1f * num19);
				}
				if (type == 75 && Main.dayTime)
				{
					for (int num20 = 0; num20 < 10; num20++)
					{
						Dust.NewDust(position, width, height, 15, velocity.X, velocity.Y, 150, default(Color), 1.2f);
					}
					for (int num21 = 0; num21 < 3; num21++)
					{
						Gore.NewGore(position, new Vector2(velocity.X, velocity.Y), Main.rand.Next(16, 18));
					}
					active = false;
					type = 0;
					stack = 0;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(21, -1, -1, "", i);
					}
				}
			}
			else
			{
				beingGrabbed = false;
			}
			if (type == 501)
			{
				if (Main.rand.Next(6) == 0)
				{
					int num22 = Dust.NewDust(position, width, height, 55, 0f, 0f, 200, color);
					Main.dust[num22].velocity *= 0.3f;
					Main.dust[num22].scale *= 0.5f;
				}
			}
			else if (type == 1970)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.75f, 0f, 0.75f);
			}
			else if (type == 1972)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0f, 0f, 0.75f);
			}
			else if (type == 1971)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.75f, 0.75f, 0f);
			}
			else if (type == 1973)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0f, 0.75f, 0f);
			}
			else if (type == 1974)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.75f, 0f, 0f);
			}
			else if (type == 1975)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.75f, 0.75f, 0.75f);
			}
			else if (type == 1976)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.75f, 0.375f, 0f);
			}
			else if (type == 2679)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.6f, 0f, 0.6f);
			}
			else if (type == 2687)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0f, 0f, 0.6f);
			}
			else if (type == 2689)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.6f, 0.6f, 0f);
			}
			else if (type == 2683)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0f, 0.6f, 0f);
			}
			else if (type == 2685)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.6f, 0f, 0f);
			}
			else if (type == 2681)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.6f, 0.6f, 0.6f);
			}
			else if (type == 2677)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.6f, 0.375f, 0f);
			}
			else if (type == 8 || type == 105)
			{
				if (!wet)
				{
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 1f, 0.95f, 0.8f);
				}
			}
			else if (type == 2701)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.7f, 0.65f, 0.55f);
			}
			else if (type == 523)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.85f, 1f, 0.7f);
			}
			else if (type == 974)
			{
				if (!wet)
				{
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.7f, 0.85f, 1f);
				}
			}
			else if (type == 1333)
			{
				Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 1.25f, 1.25f, 0.8f);
			}
			else if (type == 2274)
			{
				float r = 0.75f;
				float g = 1.3499999f;
				float b = 1.5f;
				if (!wet)
				{
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), r, g, b);
				}
			}
			else if (type >= 427 && type <= 432)
			{
				if (!wet)
				{
					float r2 = 0f;
					float g2 = 0f;
					float b2 = 0f;
					int num23 = type - 426;
					if (num23 == 1)
					{
						r2 = 0.1f;
						g2 = 0.2f;
						b2 = 1.1f;
					}
					if (num23 == 2)
					{
						r2 = 1f;
						g2 = 0.1f;
						b2 = 0.1f;
					}
					if (num23 == 3)
					{
						r2 = 0f;
						g2 = 1f;
						b2 = 0.1f;
					}
					if (num23 == 4)
					{
						r2 = 0.9f;
						g2 = 0f;
						b2 = 0.9f;
					}
					if (num23 == 5)
					{
						r2 = 1.3f;
						g2 = 1.3f;
						b2 = 1.3f;
					}
					if (num23 == 6)
					{
						r2 = 0.9f;
						g2 = 0.9f;
						b2 = 0f;
					}
					Lighting.addLight((int)((position.X + (float)(width / 2)) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), r2, g2, b2);
				}
			}
			else if (type == 41)
			{
				if (!wet)
				{
					Lighting.addLight((int)((position.X + (float)width) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 1f, 0.75f, 0.55f);
				}
			}
			else if (type == 988)
			{
				if (!wet)
				{
					Lighting.addLight((int)((position.X + (float)width) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.35f, 0.65f, 1f);
				}
			}
			else if (type == 282)
			{
				Lighting.addLight((int)((position.X + (float)width) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.7f, 1f, 0.8f);
			}
			else if (type == 286)
			{
				Lighting.addLight((int)((position.X + (float)width) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.7f, 0.8f, 1f);
			}
			else if (type == 331)
			{
				Lighting.addLight((int)((position.X + (float)width) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.55f, 0.75f, 0.6f);
			}
			else if (type == 183)
			{
				Lighting.addLight((int)((position.X + (float)width) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.15f, 0.45f, 0.9f);
			}
			else if (type == 75)
			{
				Lighting.addLight((int)((position.X + (float)width) / 16f), (int)((position.Y + (float)(height / 2)) / 16f), 0.8f, 0.7f, 0.1f);
			}
			if (type == 75)
			{
				if (Main.rand.Next(25) == 0)
				{
					Dust.NewDust(position, width, height, 58, velocity.X * 0.5f, velocity.Y * 0.5f, 150, default(Color), 1.2f);
				}
				if (Main.rand.Next(50) == 0)
				{
					Gore.NewGore(position, new Vector2(velocity.X * 0.2f, velocity.Y * 0.2f), Main.rand.Next(16, 18));
				}
			}
			if (spawnTime < 2147483646)
			{
				if (type == 58 || type == 184 || type == 1867 || type == 1868 || type == 1734 || type == 1735)
				{
					spawnTime += 4;
				}
				spawnTime++;
			}
			if (Main.netMode == 2 && owner != Main.myPlayer)
			{
				release++;
				if (release >= 300)
				{
					release = 0;
					NetMessage.SendData(39, owner, -1, "", i);
				}
			}
			if (wet)
			{
				position += vector;
			}
			else
			{
				position += velocity;
			}
			if (noGrabDelay > 0)
			{
				noGrabDelay--;
			}
		}

		public static int NewItem(int X, int Y, int Width, int Height, int Type, int Stack = 1, bool noBroadcast = false, int pfix = 0, bool noGrabDelay = false)
		{
			if (Main.rand == null)
			{
				Main.rand = new Random();
			}
			if (WorldGen.gen)
			{
				return 0;
			}
			int num = 400;
			Main.item[400] = new Item();
			if (Main.halloween)
			{
				if (Type == 58)
				{
					Type = 1734;
				}
				if (Type == 184)
				{
					Type = 1735;
				}
			}
			if (Main.xMas)
			{
				if (Type == 58)
				{
					Type = 1867;
				}
				if (Type == 184)
				{
					Type = 1868;
				}
			}
			if (Main.netMode != 1)
			{
				for (int i = 0; i < 400; i++)
				{
					if (!Main.item[i].active)
					{
						num = i;
						break;
					}
				}
			}
			if (num == 400 && Main.netMode != 1)
			{
				int num2 = 0;
				for (int j = 0; j < 400; j++)
				{
					if (Main.item[j].spawnTime > num2)
					{
						num2 = Main.item[j].spawnTime;
						num = j;
					}
				}
			}
			Main.item[num] = new Item();
			Main.item[num].SetDefaults(Type);
			Main.item[num].Prefix(pfix);
			Main.item[num].position.X = X + Width / 2 - Main.item[num].width / 2;
			Main.item[num].position.Y = Y + Height / 2 - Main.item[num].height / 2;
			Main.item[num].wet = Collision.WetCollision(Main.item[num].position, Main.item[num].width, Main.item[num].height);
			Main.item[num].velocity.X = (float)Main.rand.Next(-30, 31) * 0.1f;
			Main.item[num].velocity.Y = (float)Main.rand.Next(-40, -15) * 0.1f;
			if (Type == 859)
			{
				Main.item[num].velocity *= 0f;
			}
			if (Type == 520 || Type == 521)
			{
				Main.item[num].velocity.X = (float)Main.rand.Next(-30, 31) * 0.1f;
				Main.item[num].velocity.Y = (float)Main.rand.Next(-30, 31) * 0.1f;
			}
			Main.item[num].active = true;
			Main.item[num].spawnTime = 0;
			Main.item[num].stack = Stack;
			if (Main.netMode == 2 && !noBroadcast)
			{
				int num3 = 0;
				if (noGrabDelay)
				{
					num3 = 1;
				}
				NetMessage.SendData(21, -1, -1, "", num, num3);
				Main.item[num].FindOwner(num);
			}
			else if (Main.netMode == 0)
			{
				Main.item[num].owner = Main.myPlayer;
			}
			return num;
		}

		public void FindOwner(int whoAmI)
		{
			if (keepTime > 0)
			{
				return;
			}
			int num = owner;
			owner = 255;
			float num2 = 999999f;
			for (int i = 0; i < 255; i++)
			{
				if (ownIgnore != i && Main.player[i].active && Main.player[i].ItemSpace(Main.item[whoAmI]))
				{
					float num3 = Math.Abs(Main.player[i].position.X + (float)(Main.player[i].width / 2) - position.X - (float)(width / 2)) + Math.Abs(Main.player[i].position.Y + (float)(Main.player[i].height / 2) - position.Y - (float)height);
					if (Main.player[i].manaMagnet && (type == 184 || type == 1735 || type == 1868))
					{
						num3 -= (float)manaGrabRange;
					}
					if (Main.player[i].lifeMagnet && (type == 58 || type == 1734 || type == 1867))
					{
						num3 -= (float)lifeGrabRange;
					}
					if (num3 < (float)NPC.sWidth && num3 < num2)
					{
						num2 = num3;
						owner = i;
					}
				}
			}
			if (owner != num && ((num == Main.myPlayer && Main.netMode == 1) || (num == 255 && Main.netMode == 2) || !Main.player[num].active))
			{
				NetMessage.SendData(21, -1, -1, "", whoAmI);
				if (active)
				{
					NetMessage.SendData(22, -1, -1, "", whoAmI);
				}
			}
		}

		public Item Clone()
		{
			return (Item)MemberwiseClone();
		}

		public bool IsTheSameAs(Item compareItem)
		{
			if (netID == compareItem.netID)
			{
				return type == compareItem.type;
			}
			return false;
		}

		public bool IsNotTheSameAs(Item compareItem)
		{
			if (netID == compareItem.netID && stack == compareItem.stack)
			{
				return prefix != compareItem.prefix;
			}
			return true;
		}
	}
}
