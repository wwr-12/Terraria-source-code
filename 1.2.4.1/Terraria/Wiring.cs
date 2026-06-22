using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Terraria
{
	public static class Wiring
	{
		public static bool running = false;

		private static Dictionary<Point16, bool> wireSkip;

		private static DoubleStack<Point16> wireList;

		private static Dictionary<Point16, byte> toProcess;

		private static Vector2[] teleport = new Vector2[2];

		private static int maxPump = 20;

		private static int[] inPumpX = new int[maxPump];

		private static int[] inPumpY = new int[maxPump];

		private static int numInPump = 0;

		private static int[] outPumpX = new int[maxPump];

		private static int[] outPumpY = new int[maxPump];

		private static int numOutPump = 0;

		private static int maxMech = 1000;

		private static int[] mechX = new int[maxMech];

		private static int[] mechY = new int[maxMech];

		private static int numMechs = 0;

		private static int[] mechTime = new int[maxMech];

		public static void Initialize()
		{
			wireSkip = new Dictionary<Point16, bool>();
			wireList = new DoubleStack<Point16>();
			toProcess = new Dictionary<Point16, byte>();
		}

		public static void SkipWire(int x, int y)
		{
			wireSkip[new Point16(x, y)] = true;
		}

		public static void SkipWire(Point16 point)
		{
			wireSkip[point] = true;
		}

		public static void UpdateMech()
		{
			for (int num = numMechs - 1; num >= 0; num--)
			{
				mechTime[num]--;
				if (Main.tile[mechX[num], mechY[num]].active() && Main.tile[mechX[num], mechY[num]].type == 144)
				{
					if (Main.tile[mechX[num], mechY[num]].frameY == 0)
					{
						mechTime[num] = 0;
					}
					else
					{
						int num2 = Main.tile[mechX[num], mechY[num]].frameX / 18;
						switch (num2)
						{
						case 0:
							num2 = 60;
							break;
						case 1:
							num2 = 180;
							break;
						case 2:
							num2 = 300;
							break;
						}
						if (Math.IEEERemainder(mechTime[num], num2) == 0.0)
						{
							mechTime[num] = 18000;
							TripWire(mechX[num], mechY[num], 1, 1);
						}
					}
				}
				if (mechTime[num] <= 0)
				{
					if (Main.tile[mechX[num], mechY[num]].active() && Main.tile[mechX[num], mechY[num]].type == 144)
					{
						Main.tile[mechX[num], mechY[num]].frameY = 0;
						NetMessage.SendTileSquare(-1, mechX[num], mechY[num], 1);
					}
					for (int i = num; i < numMechs; i++)
					{
						mechX[i] = mechX[i + 1];
						mechY[i] = mechY[i + 1];
						mechTime[i] = mechTime[i + 1];
					}
					numMechs--;
				}
			}
		}

		public static void hitSwitch(int i, int j)
		{
			if (Main.tile[i, j] == null)
			{
				return;
			}
			if (Main.tile[i, j].type == 135 || Main.tile[i, j].type == 314)
			{
				Main.PlaySound(28, i * 16, j * 16, 0);
				TripWire(i, j, 1, 1);
			}
			else if (Main.tile[i, j].type == 136)
			{
				if (Main.tile[i, j].frameY == 0)
				{
					Main.tile[i, j].frameY = 18;
				}
				else
				{
					Main.tile[i, j].frameY = 0;
				}
				Main.PlaySound(28, i * 16, j * 16, 0);
				TripWire(i, j, 1, 1);
			}
			else if (Main.tile[i, j].type == 144)
			{
				if (Main.tile[i, j].frameY == 0)
				{
					Main.tile[i, j].frameY = 18;
					if (Main.netMode != 1)
					{
						checkMech(i, j, 18000);
					}
				}
				else
				{
					Main.tile[i, j].frameY = 0;
				}
				Main.PlaySound(28, i * 16, j * 16, 0);
			}
			else
			{
				if (Main.tile[i, j].type != 132)
				{
					return;
				}
				int num = i;
				int num2 = j;
				short num3 = 36;
				num = Main.tile[i, j].frameX / 18 * -1;
				num2 = Main.tile[i, j].frameY / 18 * -1;
				num %= 4;
				if (num < -1)
				{
					num += 2;
					num3 = -36;
				}
				num += i;
				num2 += j;
				for (int k = num; k < num + 2; k++)
				{
					for (int l = num2; l < num2 + 2; l++)
					{
						if (Main.tile[k, l].type == 132)
						{
							Main.tile[k, l].frameX += num3;
						}
					}
				}
				WorldGen.TileFrame(num, num2);
				Main.PlaySound(28, i * 16, j * 16, 0);
				TripWire(num, num2, 2, 2);
			}
		}

		private static bool checkMech(int i, int j, int time)
		{
			for (int k = 0; k < numMechs; k++)
			{
				if (mechX[k] == i && mechY[k] == j)
				{
					return false;
				}
			}
			if (numMechs < maxMech - 1)
			{
				mechX[numMechs] = i;
				mechY[numMechs] = j;
				mechTime[numMechs] = time;
				numMechs++;
				return true;
			}
			return false;
		}

		private static void xferWater()
		{
			for (int i = 0; i < numInPump; i++)
			{
				int num = inPumpX[i];
				int num2 = inPumpY[i];
				int liquid = Main.tile[num, num2].liquid;
				if (liquid <= 0)
				{
					continue;
				}
				bool flag = Main.tile[num, num2].lava();
				bool flag2 = Main.tile[num, num2].honey();
				for (int j = 0; j < numOutPump; j++)
				{
					int num3 = outPumpX[j];
					int num4 = outPumpY[j];
					int liquid2 = Main.tile[num3, num4].liquid;
					if (liquid2 >= 255)
					{
						continue;
					}
					bool flag3 = Main.tile[num3, num4].lava();
					bool flag4 = Main.tile[num3, num4].honey();
					if (liquid2 == 0)
					{
						flag3 = flag;
						flag4 = flag2;
					}
					if (flag == flag3 && flag2 == flag4)
					{
						int num5 = liquid;
						if (num5 + liquid2 > 255)
						{
							num5 = 255 - liquid2;
						}
						Main.tile[num3, num4].liquid += (byte)num5;
						Main.tile[num, num2].liquid -= (byte)num5;
						liquid = Main.tile[num, num2].liquid;
						Main.tile[num3, num4].lava(flag);
						Main.tile[num3, num4].honey(flag2);
						WorldGen.SquareTileFrame(num3, num4);
						if (Main.tile[num, num2].liquid == 0)
						{
							Main.tile[num, num2].lava(false);
							WorldGen.SquareTileFrame(num, num2);
							break;
						}
					}
				}
				WorldGen.SquareTileFrame(num, num2);
			}
		}

		private static void TripWire(int left, int top, int width, int height)
		{
			if (Main.netMode == 1)
			{
				return;
			}
			running = true;
			if (wireList.Count != 0)
			{
				wireList.Clear(true);
			}
			for (int i = left; i < left + width; i++)
			{
				for (int j = top; j < top + height; j++)
				{
					Point16 back = new Point16(i, j);
					Tile tile = Main.tile[i, j];
					if (tile != null && tile.wire())
					{
						wireList.PushBack(back);
					}
				}
			}
			Vector2[] array = new Vector2[6];
			teleport[0].X = -1f;
			teleport[0].Y = -1f;
			teleport[1].X = -1f;
			teleport[1].Y = -1f;
			if (wireList.Count > 0)
			{
				numInPump = 0;
				numOutPump = 0;
				hitWire(wireList, 1);
				if (numInPump > 0 && numOutPump > 0)
				{
					xferWater();
				}
			}
			for (int k = left; k < left + width; k++)
			{
				for (int l = top; l < top + height; l++)
				{
					Point16 back = new Point16(k, l);
					Tile tile2 = Main.tile[k, l];
					if (tile2 != null && tile2.wire2())
					{
						wireList.PushBack(back);
					}
				}
			}
			array[0] = teleport[0];
			array[1] = teleport[1];
			teleport[0].X = -1f;
			teleport[0].Y = -1f;
			teleport[1].X = -1f;
			teleport[1].Y = -1f;
			if (wireList.Count > 0)
			{
				numInPump = 0;
				numOutPump = 0;
				hitWire(wireList, 2);
				if (numInPump > 0 && numOutPump > 0)
				{
					xferWater();
				}
			}
			array[2] = teleport[0];
			array[3] = teleport[1];
			teleport[0].X = -1f;
			teleport[0].Y = -1f;
			teleport[1].X = -1f;
			teleport[1].Y = -1f;
			for (int m = left; m < left + width; m++)
			{
				for (int n = top; n < top + height; n++)
				{
					Point16 back = new Point16(m, n);
					Tile tile3 = Main.tile[m, n];
					if (tile3 != null && tile3.wire3())
					{
						wireList.PushBack(back);
					}
				}
			}
			if (wireList.Count > 0)
			{
				numInPump = 0;
				numOutPump = 0;
				hitWire(wireList, 3);
				if (numInPump > 0 && numOutPump > 0)
				{
					xferWater();
				}
			}
			array[4] = teleport[0];
			array[5] = teleport[1];
			for (int num = 0; num < 5; num += 2)
			{
				teleport[0] = array[num];
				teleport[1] = array[num + 1];
				if (teleport[0].X >= 0f && teleport[1].X >= 0f)
				{
					Teleport();
				}
			}
		}

		private static void hitWire(DoubleStack<Point16> next, int wireType)
		{
			for (int i = 0; i < next.Count; i++)
			{
				Point16 point = next.PopFront();
				SkipWire(point);
				toProcess.Add(point, 4);
				next.PushBack(point);
			}
			while (next.Count > 0)
			{
				Point16 key = next.PopFront();
				int x = key.x;
				int y = key.y;
				if (!wireSkip.ContainsKey(key))
				{
					hitWireSingle(x, y);
				}
				for (int j = 0; j < 4; j++)
				{
					int num;
					int num2;
					switch (j)
					{
					case 0:
						num = x;
						num2 = y + 1;
						break;
					case 1:
						num = x;
						num2 = y - 1;
						break;
					case 2:
						num = x + 1;
						num2 = y;
						break;
					case 3:
						num = x - 1;
						num2 = y;
						break;
					default:
						num = x;
						num2 = y + 1;
						break;
					}
					if (num < 2 || num >= Main.maxTilesX - 2 || num2 < 2 || num2 >= Main.maxTilesY - 2)
					{
						continue;
					}
					Tile tile = Main.tile[num, num2];
					if (tile == null)
					{
						continue;
					}
					bool flag;
					switch (wireType)
					{
					case 1:
						flag = tile.wire();
						break;
					case 2:
						flag = tile.wire2();
						break;
					case 3:
						flag = tile.wire3();
						break;
					default:
						flag = false;
						break;
					}
					if (!flag)
					{
						continue;
					}
					Point16 point2 = new Point16(num, num2);
					byte value;
					if (toProcess.TryGetValue(point2, out value))
					{
						value--;
						if (value == 0)
						{
							toProcess.Remove(point2);
						}
						else
						{
							toProcess[point2] = value;
						}
					}
					else
					{
						next.PushBack(point2);
						toProcess.Add(point2, 3);
					}
				}
			}
			wireSkip.Clear();
			toProcess.Clear();
			running = false;
		}

		private static bool hitWireSingle(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			int type = tile.type;
			if (tile.active() && type >= 255 && type <= 268)
			{
				if (type >= 262)
				{
					tile.type -= 7;
				}
				else
				{
					tile.type += 7;
				}
				NetMessage.SendTileSquare(-1, i, j, 1);
			}
			if (tile.actuator() && (type != 226 || !((double)j > Main.worldSurface) || NPC.downedPlantBoss))
			{
				if (tile.inActive())
				{
					ReActive(i, j);
				}
				else
				{
					DeActive(i, j);
				}
			}
			if (tile.active())
			{
				switch (type)
				{
				case 144:
					hitSwitch(i, j);
					WorldGen.SquareTileFrame(i, j);
					NetMessage.SendTileSquare(-1, i, j, 1);
					break;
				case 130:
					if (Main.tile[i, j - 1] == null || !Main.tile[i, j - 1].active() || Main.tile[i, j - 1].type != 21)
					{
						tile.type = 131;
						WorldGen.SquareTileFrame(i, j);
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					break;
				case 131:
					tile.type = 130;
					WorldGen.SquareTileFrame(i, j);
					NetMessage.SendTileSquare(-1, i, j, 1);
					break;
				case 11:
					if (WorldGen.CloseDoor(i, j, true))
					{
						NetMessage.SendData(19, -1, -1, "", 1, i, j);
					}
					break;
				case 10:
				{
					int num17 = 1;
					if (Main.rand.Next(2) == 0)
					{
						num17 = -1;
					}
					if (!WorldGen.OpenDoor(i, j, num17))
					{
						if (WorldGen.OpenDoor(i, j, -num17))
						{
							NetMessage.SendData(19, -1, -1, "", 0, i, j, -num17);
						}
					}
					else
					{
						NetMessage.SendData(19, -1, -1, "", 0, i, j, num17);
					}
					break;
				}
				case 216:
					WorldGen.LaunchRocket(i, j);
					SkipWire(i, j);
					break;
				case 335:
				{
					int num44 = j - tile.frameY / 18;
					int num45 = i - tile.frameX / 18;
					SkipWire(num45, num44);
					SkipWire(num45, num44 + 1);
					SkipWire(num45 + 1, num44);
					SkipWire(num45 + 1, num44 + 1);
					if (checkMech(num45, num44, 30))
					{
						WorldGen.LaunchRocketSmall(num45, num44);
					}
					break;
				}
				case 338:
				{
					int num29 = j - tile.frameY / 18;
					int num30 = i - tile.frameX / 18;
					SkipWire(num30, num29);
					SkipWire(num30, num29 + 1);
					if (!checkMech(num30, num29, 30))
					{
						break;
					}
					bool flag = false;
					for (int num31 = 0; num31 < 1000; num31++)
					{
						if (Main.projectile[num31].active && Main.projectile[num31].aiStyle == 73 && Main.projectile[num31].ai[0] == (float)num30 && Main.projectile[num31].ai[1] == (float)num29)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Projectile.NewProjectile(num30 * 16 + 8, num29 * 16 + 2, 0f, 0f, 419 + Main.rand.Next(4), 0, 0f, Main.myPlayer, num30, num29);
					}
					break;
				}
				case 235:
				{
					int num32 = i - tile.frameX / 18;
					if (tile.wall == 87 && (double)j > Main.worldSurface && !NPC.downedPlantBoss)
					{
						break;
					}
					if (teleport[0].X == -1f)
					{
						teleport[0].X = num32;
						teleport[0].Y = j;
						if (tile.halfBrick())
						{
							teleport[0].Y += 0.5f;
						}
					}
					else if (teleport[0].X != (float)num32 || teleport[0].Y != (float)j)
					{
						teleport[1].X = num32;
						teleport[1].Y = j;
						if (tile.halfBrick())
						{
							teleport[1].Y += 0.5f;
						}
					}
					break;
				}
				case 4:
					if (tile.frameX < 66)
					{
						tile.frameX += 66;
					}
					else
					{
						tile.frameX -= 66;
					}
					NetMessage.SendTileSquare(-1, i, j, 1);
					break;
				case 149:
					if (tile.frameX < 54)
					{
						tile.frameX += 54;
					}
					else
					{
						tile.frameX -= 54;
					}
					NetMessage.SendTileSquare(-1, i, j, 1);
					break;
				case 244:
				{
					int num46;
					for (num46 = tile.frameX / 18; num46 >= 3; num46 -= 3)
					{
					}
					int num47;
					for (num47 = tile.frameY / 18; num47 >= 3; num47 -= 3)
					{
					}
					int num48 = i - num46;
					int num49 = j - num47;
					int num50 = 54;
					if (Main.tile[num48, num49].frameX >= 54)
					{
						num50 = -54;
					}
					for (int num51 = num48; num51 < num48 + 3; num51++)
					{
						for (int num52 = num49; num52 < num49 + 2; num52++)
						{
							SkipWire(num51, num52);
							Main.tile[num51, num52].frameX = (short)(Main.tile[num51, num52].frameX + num50);
						}
					}
					break;
				}
				case 42:
				{
					int num26;
					for (num26 = tile.frameY / 18; num26 >= 2; num26 -= 2)
					{
					}
					int num27 = j - num26;
					short num28 = 18;
					if (tile.frameX > 0)
					{
						num28 = -18;
					}
					Main.tile[i, num27].frameX += num28;
					Main.tile[i, num27 + 1].frameX += num28;
					SkipWire(i, num27);
					SkipWire(i, num27 + 1);
					NetMessage.SendTileSquare(-1, i, j, 2);
					break;
				}
				case 93:
				{
					int num15;
					for (num15 = tile.frameY / 18; num15 >= 3; num15 -= 3)
					{
					}
					num15 = j - num15;
					short num16 = 18;
					if (tile.frameX > 0)
					{
						num16 = -18;
					}
					Main.tile[i, num15].frameX += num16;
					Main.tile[i, num15 + 1].frameX += num16;
					Main.tile[i, num15 + 2].frameX += num16;
					SkipWire(i, num15);
					SkipWire(i, num15 + 1);
					SkipWire(i, num15 + 2);
					NetMessage.SendTileSquare(-1, i, num15 + 1, 3);
					break;
				}
				case 95:
				case 100:
				case 126:
				case 173:
				{
					int num40;
					for (num40 = tile.frameY / 18; num40 >= 2; num40 -= 2)
					{
					}
					num40 = j - num40;
					int num41 = tile.frameX / 18;
					if (num41 > 1)
					{
						num41 -= 2;
					}
					num41 = i - num41;
					short num42 = 36;
					if (Main.tile[num41, num40].frameX > 0)
					{
						num42 = -36;
					}
					Main.tile[num41, num40].frameX += num42;
					Main.tile[num41, num40 + 1].frameX += num42;
					Main.tile[num41 + 1, num40].frameX += num42;
					Main.tile[num41 + 1, num40 + 1].frameX += num42;
					SkipWire(num41, num40);
					SkipWire(num41 + 1, num40);
					SkipWire(num41, num40 + 1);
					SkipWire(num41 + 1, num40 + 1);
					NetMessage.SendTileSquare(-1, num41, num40, 3);
					break;
				}
				case 34:
				{
					int num11;
					for (num11 = tile.frameY / 18; num11 >= 3; num11 -= 3)
					{
					}
					int num12 = j - num11;
					int num13 = tile.frameX / 18;
					if (num13 > 2)
					{
						num13 -= 3;
					}
					num13 = i - num13;
					short num14 = 54;
					if (Main.tile[num13, num12].frameX > 0)
					{
						num14 = -54;
					}
					for (int m = num13; m < num13 + 3; m++)
					{
						for (int n = num12; n < num12 + 3; n++)
						{
							Main.tile[m, n].frameX += num14;
							SkipWire(m, n);
						}
					}
					NetMessage.SendTileSquare(-1, num13 + 1, num12 + 1, 3);
					break;
				}
				case 314:
					if (checkMech(i, j, 5))
					{
						Minecart.FlipSwitchTrack(i, j);
					}
					break;
				case 33:
				case 174:
				{
					short num43 = 18;
					if (tile.frameX > 0)
					{
						num43 = -18;
					}
					tile.frameX += num43;
					NetMessage.SendTileSquare(-1, i, j, 3);
					break;
				}
				case 92:
				{
					int num37 = j - tile.frameY / 18;
					short num38 = 18;
					if (tile.frameX > 0)
					{
						num38 = -18;
					}
					for (int num39 = num37; num39 < num37 + 6; num39++)
					{
						Main.tile[i, num39].frameX += num38;
						SkipWire(i, num39);
					}
					NetMessage.SendTileSquare(-1, i, num37 + 3, 7);
					break;
				}
				case 137:
				{
					int num33 = tile.frameY / 18;
					if (num33 == 0 && checkMech(i, j, 180))
					{
						int num34 = -1;
						if (tile.frameX != 0)
						{
							num34 = 1;
						}
						float speedX = 12 * num34;
						int damage = 20;
						int type2 = 98;
						Vector2 vector = new Vector2(i * 16 + 8, j * 16 + 7);
						vector.X += 10 * num34;
						vector.Y += 2f;
						Projectile.NewProjectile((int)vector.X, (int)vector.Y, speedX, 0f, type2, damage, 2f, Main.myPlayer);
					}
					if (num33 == 1 && checkMech(i, j, 180))
					{
						int num35 = -1;
						if (tile.frameX != 0)
						{
							num35 = 1;
						}
						float speedX2 = 12 * num35;
						int damage2 = 40;
						int type3 = 184;
						Vector2 vector2 = new Vector2(i * 16 + 8, j * 16 + 7);
						vector2.X += 10 * num35;
						vector2.Y += 2f;
						Projectile.NewProjectile((int)vector2.X, (int)vector2.Y, speedX2, 0f, type3, damage2, 2f, Main.myPlayer);
					}
					if (num33 == 2 && checkMech(i, j, 180))
					{
						int num36 = -1;
						if (tile.frameX != 0)
						{
							num36 = 1;
						}
						float speedX3 = 5 * num36;
						int damage3 = 40;
						int type4 = 187;
						Vector2 vector3 = new Vector2(i * 16 + 8, j * 16 + 7);
						vector3.X += 10 * num36;
						vector3.Y += 2f;
						Projectile.NewProjectile((int)vector3.X, (int)vector3.Y, speedX3, 0f, type4, damage3, 2f, Main.myPlayer);
					}
					if (num33 == 3 && checkMech(i, j, 240))
					{
						float speedX4 = (float)Main.rand.Next(-20, 21) * 0.05f;
						float speedY = 4f + (float)Main.rand.Next(0, 21) * 0.05f;
						int damage4 = 40;
						int type5 = 185;
						Vector2 vector4 = new Vector2(i * 16 + 8, j * 16 + 16);
						vector4.Y += 6f;
						Projectile.NewProjectile((int)vector4.X, (int)vector4.Y, speedX4, speedY, type5, damage4, 2f, Main.myPlayer);
					}
					if (num33 == 4 && checkMech(i, j, 90))
					{
						float speedX5 = 0f;
						float speedY2 = 8f;
						int damage5 = 60;
						int type6 = 186;
						Vector2 vector5 = new Vector2(i * 16 + 8, j * 16 + 16);
						vector5.Y += 10f;
						Projectile.NewProjectile((int)vector5.X, (int)vector5.Y, speedX5, speedY2, type6, damage5, 2f, Main.myPlayer);
					}
					break;
				}
				case 35:
				case 139:
					WorldGen.SwitchMB(i, j);
					break;
				case 207:
					WorldGen.SwitchFountain(i, j);
					break;
				case 141:
					WorldGen.KillTile(i, j, false, false, true);
					NetMessage.SendTileSquare(-1, i, j, 1);
					Projectile.NewProjectile(i * 16 + 8, j * 16 + 8, 0f, 0f, 108, 250, 10f, Main.myPlayer);
					break;
				case 210:
					WorldGen.ExplodeMine(i, j);
					break;
				case 142:
				case 143:
				{
					int num18 = j - tile.frameY / 18;
					int num19 = tile.frameX / 18;
					if (num19 > 1)
					{
						num19 -= 2;
					}
					num19 = i - num19;
					SkipWire(num19, num18);
					SkipWire(num19, num18 + 1);
					SkipWire(num19 + 1, num18);
					SkipWire(num19 + 1, num18 + 1);
					if (type == 142)
					{
						int num20 = num19;
						int num21 = num18;
						for (int num22 = 0; num22 < 4; num22++)
						{
							if (numInPump >= maxPump - 1)
							{
								break;
							}
							switch (num22)
							{
							case 0:
								num20 = num19;
								num21 = num18 + 1;
								break;
							case 1:
								num20 = num19 + 1;
								num21 = num18 + 1;
								break;
							case 2:
								num20 = num19;
								num21 = num18;
								break;
							default:
								num20 = num19 + 1;
								num21 = num18;
								break;
							}
							inPumpX[numInPump] = num20;
							inPumpY[numInPump] = num21;
							numInPump++;
						}
						break;
					}
					int num23 = num19;
					int num24 = num18;
					for (int num25 = 0; num25 < 4; num25++)
					{
						if (numOutPump >= maxPump - 1)
						{
							break;
						}
						switch (num25)
						{
						case 0:
							num23 = num19;
							num24 = num18 + 1;
							break;
						case 1:
							num23 = num19 + 1;
							num24 = num18 + 1;
							break;
						case 2:
							num23 = num19;
							num24 = num18;
							break;
						default:
							num23 = num19 + 1;
							num24 = num18;
							break;
						}
						outPumpX[numOutPump] = num23;
						outPumpY[numOutPump] = num24;
						numOutPump++;
					}
					break;
				}
				case 105:
				{
					int num = j - tile.frameY / 18;
					int num2 = tile.frameX / 18;
					int num3 = 0;
					while (num2 >= 2)
					{
						num2 -= 2;
						num3++;
					}
					num2 = i - num2;
					SkipWire(num2, num);
					SkipWire(num2, num + 1);
					SkipWire(num2, num + 2);
					SkipWire(num2 + 1, num);
					SkipWire(num2 + 1, num + 1);
					SkipWire(num2 + 1, num + 2);
					int num4 = num2 * 16 + 16;
					int num5 = (num + 3) * 16;
					int num6 = -1;
					switch (num3)
					{
					case 4:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 1))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 1);
						}
						break;
					case 7:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 49))
						{
							num6 = NPC.NewNPC(num4 - 4, num5 - 6, 49);
						}
						break;
					case 8:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 55))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 55);
						}
						break;
					case 9:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 46))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 46);
						}
						break;
					case 10:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 21))
						{
							num6 = NPC.NewNPC(num4, num5, 21);
						}
						break;
					case 18:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 67))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 67);
						}
						break;
					case 23:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 63))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 63);
						}
						break;
					case 27:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 85))
						{
							num6 = NPC.NewNPC(num4 - 9, num5, 85);
						}
						break;
					case 28:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 74))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 74);
						}
						break;
					case 42:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 58))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 58);
						}
						break;
					case 37:
						if (checkMech(i, j, 600) && Item.MechSpawn(num4, num5, 58) && Item.MechSpawn(num4, num5, 1734) && Item.MechSpawn(num4, num5, 1867))
						{
							Item.NewItem(num4, num5 - 16, 0, 0, 58);
						}
						break;
					case 50:
						if (checkMech(i, j, 30) && NPC.MechSpawn(num4, num5, 65) && !Collision.SolidTiles(num2 - 2, num2 + 3, num, num + 2))
						{
							num6 = NPC.NewNPC(num4, num5 - 12, 65);
						}
						break;
					case 2:
						if (checkMech(i, j, 600) && Item.MechSpawn(num4, num5, 184) && Item.MechSpawn(num4, num5, 1735) && Item.MechSpawn(num4, num5, 1868))
						{
							Item.NewItem(num4, num5 - 16, 0, 0, 184);
						}
						break;
					case 17:
						if (checkMech(i, j, 600) && Item.MechSpawn(num4, num5, 166))
						{
							Item.NewItem(num4, num5 - 20, 0, 0, 166);
						}
						break;
					case 40:
					{
						if (!checkMech(i, j, 300))
						{
							break;
						}
						int[] array2 = new int[10];
						int num9 = 0;
						for (int l = 0; l < 200; l++)
						{
							if (Main.npc[l].active && (Main.npc[l].type == 17 || Main.npc[l].type == 19 || Main.npc[l].type == 22 || Main.npc[l].type == 38 || Main.npc[l].type == 54 || Main.npc[l].type == 107 || Main.npc[l].type == 108 || Main.npc[l].type == 142 || Main.npc[l].type == 160 || Main.npc[l].type == 207 || Main.npc[l].type == 209 || Main.npc[l].type == 227 || Main.npc[l].type == 228 || Main.npc[l].type == 229 || Main.npc[l].type == 358 || Main.npc[l].type == 369))
							{
								array2[num9] = l;
								num9++;
								if (num9 >= 9)
								{
									break;
								}
							}
						}
						if (num9 > 0)
						{
							int num10 = array2[Main.rand.Next(num9)];
							Main.npc[num10].position.X = num4 - Main.npc[num10].width / 2;
							Main.npc[num10].position.Y = num5 - Main.npc[num10].height - 1;
							NetMessage.SendData(23, -1, -1, "", num10);
						}
						break;
					}
					case 41:
					{
						if (!checkMech(i, j, 300))
						{
							break;
						}
						int[] array = new int[10];
						int num7 = 0;
						for (int k = 0; k < 200; k++)
						{
							if (Main.npc[k].active && (Main.npc[k].type == 18 || Main.npc[k].type == 20 || Main.npc[k].type == 124 || Main.npc[k].type == 178 || Main.npc[k].type == 208 || Main.npc[k].type == 353))
							{
								array[num7] = k;
								num7++;
								if (num7 >= 9)
								{
									break;
								}
							}
						}
						if (num7 > 0)
						{
							int num8 = array[Main.rand.Next(num7)];
							Main.npc[num8].position.X = num4 - Main.npc[num8].width / 2;
							Main.npc[num8].position.Y = num5 - Main.npc[num8].height - 1;
							NetMessage.SendData(23, -1, -1, "", num8);
						}
						break;
					}
					}
					if (num6 >= 0)
					{
						Main.npc[num6].value = 0f;
						Main.npc[num6].npcSlots = 0f;
					}
					break;
				}
				}
			}
			return true;
		}

		private static void Teleport()
		{
			if (teleport[0].X < teleport[1].X + 3f && teleport[0].X > teleport[1].X - 3f && teleport[0].Y > teleport[1].Y - 3f && teleport[0].Y < teleport[1].Y)
			{
				return;
			}
			Rectangle[] array = new Rectangle[2];
			array[0].X = (int)(teleport[0].X * 16f);
			array[0].Width = 48;
			array[0].Height = 48;
			array[0].Y = (int)(teleport[0].Y * 16f - (float)array[0].Height);
			array[1].X = (int)(teleport[1].X * 16f);
			array[1].Width = 48;
			array[1].Height = 48;
			array[1].Y = (int)(teleport[1].Y * 16f - (float)array[1].Height);
			for (int i = 0; i < 2; i++)
			{
				Vector2 vector = new Vector2(array[1].X - array[0].X, array[1].Y - array[0].Y);
				if (i == 1)
				{
					vector = new Vector2(array[0].X - array[1].X, array[0].Y - array[1].Y);
				}
				for (int j = 0; j < 255; j++)
				{
					if (Main.player[j].active && !Main.player[j].dead && !Main.player[j].teleporting && array[i].Intersects(Main.player[j].getRect()))
					{
						Vector2 vector2 = Main.player[j].position + vector;
						Main.player[j].teleporting = true;
						if (Main.netMode == 2)
						{
							ServerSock.CheckSection(j, vector2);
						}
						Main.player[j].Teleport(vector2);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(65, -1, -1, "", 0, j, vector2.X, vector2.Y);
						}
					}
				}
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && !Main.npc[k].teleporting && Main.npc[k].lifeMax > 5 && !Main.npc[k].boss && !Main.npc[k].noTileCollide && array[i].Intersects(Main.npc[k].getRect()))
					{
						Main.npc[k].teleporting = true;
						Main.npc[k].Teleport(Main.npc[k].position + vector);
					}
				}
			}
			for (int l = 0; l < 255; l++)
			{
				Main.player[l].teleporting = false;
			}
			for (int m = 0; m < 200; m++)
			{
				Main.npc[m].teleporting = false;
			}
		}

		private static bool DeActive(int i, int j)
		{
			if (Main.tile[i, j].active() && ((Main.tileSolid[Main.tile[i, j].type] && Main.tile[i, j].type != 10) || Main.tile[i, j].type == 314))
			{
				if (Main.tile[i, j - 1].active() && (Main.tile[i, j - 1].type == 5 || Main.tile[i, j - 1].type == 21 || Main.tile[i, j - 1].type == 26 || Main.tile[i, j - 1].type == 77 || Main.tile[i, j - 1].type == 72))
				{
					return false;
				}
				Main.tile[i, j].inActive(true);
				WorldGen.SquareTileFrame(i, j, false);
				if (Main.netMode != 1)
				{
					NetMessage.SendTileSquare(-1, i, j, 1);
				}
				return true;
			}
			return false;
		}

		private static bool ReActive(int i, int j)
		{
			Main.tile[i, j].inActive(false);
			WorldGen.SquareTileFrame(i, j, false);
			if (Main.netMode != 1)
			{
				NetMessage.SendTileSquare(-1, i, j, 1);
			}
			return true;
		}
	}
}
