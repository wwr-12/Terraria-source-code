using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;

namespace Terraria
{
	public static class Wiring
	{
		public static bool blockPlayerTeleportationForOneIteration;

		public static bool running;

		private static Dictionary<Point16, bool> _wireSkip;

		private static DoubleStack<Point16> _wireList;

		private static DoubleStack<byte> _wireDirectionList;

		private static Dictionary<Point16, byte> _toProcess;

		private static Queue<Point16> _GatesCurrent;

		private static Queue<Point16> _LampsToCheck;

		private static Queue<Point16> _GatesNext;

		private static Dictionary<Point16, bool> _GatesDone;

		private static Dictionary<Point16, byte> _PixelBoxTriggers;

		private static Vector2[] _teleport;

		private const int MaxPump = 20;

		private static int[] _inPumpX;

		private static int[] _inPumpY;

		private static int _numInPump;

		private static int[] _outPumpX;

		private static int[] _outPumpY;

		private static int _numOutPump;

		private const int MaxMech = 1000;

		private static int[] _mechX;

		private static int[] _mechY;

		private static int _numMechs;

		private static int[] _mechTime;

		private static int _currentWireColor;

		private static int CurrentUser = 254;

		public static void SetCurrentUser(int plr = -1)
		{
			if (plr < 0 || plr >= 255)
			{
				plr = 254;
			}
			if (Main.netMode == 0)
			{
				plr = Main.myPlayer;
			}
			CurrentUser = plr;
		}

		public static void Initialize()
		{
			_wireSkip = new Dictionary<Point16, bool>();
			_wireList = new DoubleStack<Point16>();
			_wireDirectionList = new DoubleStack<byte>();
			_toProcess = new Dictionary<Point16, byte>();
			_GatesCurrent = new Queue<Point16>();
			_GatesNext = new Queue<Point16>();
			_GatesDone = new Dictionary<Point16, bool>();
			_LampsToCheck = new Queue<Point16>();
			_PixelBoxTriggers = new Dictionary<Point16, byte>();
			_inPumpX = new int[20];
			_inPumpY = new int[20];
			_outPumpX = new int[20];
			_outPumpY = new int[20];
			_teleport = new Vector2[2];
			_mechX = new int[1000];
			_mechY = new int[1000];
			_mechTime = new int[1000];
		}

		public static void SkipWire(int x, int y)
		{
			_wireSkip[new Point16(x, y)] = true;
		}

		public static void SkipWire(Point16 point)
		{
			_wireSkip[point] = true;
		}

		public static void UpdateMech()
		{
			SetCurrentUser();
			for (int num = _numMechs - 1; num >= 0; num--)
			{
				_mechTime[num]--;
				if (Main.tile[_mechX[num], _mechY[num]].active() && Main.tile[_mechX[num], _mechY[num]].type == 144)
				{
					if (Main.tile[_mechX[num], _mechY[num]].frameY == 0)
					{
						_mechTime[num] = 0;
					}
					else
					{
						int num2 = Main.tile[_mechX[num], _mechY[num]].frameX / 18;
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
						if (Math.IEEERemainder(_mechTime[num], num2) == 0.0)
						{
							_mechTime[num] = 18000;
							TripWire(_mechX[num], _mechY[num], 1, 1);
						}
					}
				}
				if (_mechTime[num] <= 0)
				{
					if (Main.tile[_mechX[num], _mechY[num]].active() && Main.tile[_mechX[num], _mechY[num]].type == 144)
					{
						Main.tile[_mechX[num], _mechY[num]].frameY = 0;
						NetMessage.SendTileSquare(-1, _mechX[num], _mechY[num], 1);
					}
					if (Main.tile[_mechX[num], _mechY[num]].active() && Main.tile[_mechX[num], _mechY[num]].type == 411)
					{
						Tile tile = Main.tile[_mechX[num], _mechY[num]];
						int num3 = tile.frameX % 36 / 18;
						int num4 = tile.frameY % 36 / 18;
						int num5 = _mechX[num] - num3;
						int num6 = _mechY[num] - num4;
						int num7 = 36;
						if (Main.tile[num5, num6].frameX >= 36)
						{
							num7 = -36;
						}
						for (int i = num5; i < num5 + 2; i++)
						{
							for (int j = num6; j < num6 + 2; j++)
							{
								Main.tile[i, j].frameX = (short)(Main.tile[i, j].frameX + num7);
							}
						}
						NetMessage.SendTileSquare(-1, num5, num6, 2);
					}
					for (int k = num; k < _numMechs; k++)
					{
						_mechX[k] = _mechX[k + 1];
						_mechY[k] = _mechY[k + 1];
						_mechTime[k] = _mechTime[k + 1];
					}
					_numMechs--;
				}
			}
		}

		public static void HitSwitch(int i, int j)
		{
			if (!WorldGen.InWorld(i, j) || Main.tile[i, j] == null)
			{
				return;
			}
			if (Main.tile[i, j].type == 135 || Main.tile[i, j].type == 314 || Main.tile[i, j].type == 423 || Main.tile[i, j].type == 428 || Main.tile[i, j].type == 442)
			{
				Main.PlaySound(28, i * 16, j * 16, 0);
				TripWire(i, j, 1, 1);
			}
			else if (Main.tile[i, j].type == 440)
			{
				Main.PlaySound(28, i * 16 + 16, j * 16 + 16, 0);
				TripWire(i, j, 3, 3);
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
						CheckMech(i, j, 18000);
					}
				}
				else
				{
					Main.tile[i, j].frameY = 0;
				}
				Main.PlaySound(28, i * 16, j * 16, 0);
			}
			else if (Main.tile[i, j].type == 441 || Main.tile[i, j].type == 468)
			{
				int num = Main.tile[i, j].frameX / 18 * -1;
				int num2 = Main.tile[i, j].frameY / 18 * -1;
				num %= 4;
				if (num < -1)
				{
					num += 2;
				}
				num += i;
				num2 += j;
				Main.PlaySound(28, i * 16, j * 16, 0);
				TripWire(num, num2, 2, 2);
			}
			else
			{
				if (Main.tile[i, j].type != 132 && Main.tile[i, j].type != 411)
				{
					return;
				}
				short num3 = 36;
				int num4 = Main.tile[i, j].frameX / 18 * -1;
				int num5 = Main.tile[i, j].frameY / 18 * -1;
				num4 %= 4;
				if (num4 < -1)
				{
					num4 += 2;
					num3 = -36;
				}
				num4 += i;
				num5 += j;
				if (Main.netMode != 1 && Main.tile[num4, num5].type == 411)
				{
					CheckMech(num4, num5, 60);
				}
				for (int k = num4; k < num4 + 2; k++)
				{
					for (int l = num5; l < num5 + 2; l++)
					{
						if (Main.tile[k, l].type == 132 || Main.tile[k, l].type == 411)
						{
							Main.tile[k, l].frameX += num3;
						}
					}
				}
				WorldGen.TileFrame(num4, num5);
				Main.PlaySound(28, i * 16, j * 16, 0);
				TripWire(num4, num5, 2, 2);
			}
		}

		public static void PokeLogicGate(int lampX, int lampY)
		{
			if (Main.netMode != 1)
			{
				_LampsToCheck.Enqueue(new Point16(lampX, lampY));
				LogicGatePass();
			}
		}

		public static bool Actuate(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			if (!tile.actuator())
			{
				return false;
			}
			if ((tile.type != 226 || !((double)j > Main.worldSurface) || NPC.downedPlantBoss) && (!((double)j > Main.worldSurface) || NPC.downedGolemBoss || Main.tile[i, j - 1].type != 237))
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
			return true;
		}

		public static void ActuateForced(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			if (tile.type != 226 || !((double)j > Main.worldSurface) || NPC.downedPlantBoss)
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
		}

		public static void MassWireOperation(Point ps, Point pe, Player master)
		{
			int wireCount = 0;
			int actuatorCount = 0;
			for (int i = 0; i < 58; i++)
			{
				if (master.inventory[i].type == 530)
				{
					wireCount += master.inventory[i].stack;
				}
				if (master.inventory[i].type == 849)
				{
					actuatorCount += master.inventory[i].stack;
				}
			}
			int num = wireCount;
			int num2 = actuatorCount;
			MassWireOperationInner(ps, pe, master.Center, master.direction == 1, ref wireCount, ref actuatorCount);
			int num3 = num - wireCount;
			int num4 = num2 - actuatorCount;
			if (Main.netMode == 2)
			{
				NetMessage.SendData(110, master.whoAmI, -1, null, 530, num3, master.whoAmI);
				NetMessage.SendData(110, master.whoAmI, -1, null, 849, num4, master.whoAmI);
				return;
			}
			for (int j = 0; j < num3; j++)
			{
				master.ConsumeItem(530);
			}
			for (int k = 0; k < num4; k++)
			{
				master.ConsumeItem(849);
			}
		}

		private static bool CheckMech(int i, int j, int time)
		{
			for (int k = 0; k < _numMechs; k++)
			{
				if (_mechX[k] == i && _mechY[k] == j)
				{
					return false;
				}
			}
			if (_numMechs < 999)
			{
				_mechX[_numMechs] = i;
				_mechY[_numMechs] = j;
				_mechTime[_numMechs] = time;
				_numMechs++;
				return true;
			}
			return false;
		}

		private static void XferWater()
		{
			for (int i = 0; i < _numInPump; i++)
			{
				int num = _inPumpX[i];
				int num2 = _inPumpY[i];
				int liquid = Main.tile[num, num2].liquid;
				if (liquid <= 0)
				{
					continue;
				}
				bool flag = Main.tile[num, num2].lava();
				bool flag2 = Main.tile[num, num2].honey();
				for (int j = 0; j < _numOutPump; j++)
				{
					int num3 = _outPumpX[j];
					int num4 = _outPumpY[j];
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
							Main.tile[num, num2].lava(lava: false);
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
			if (_wireList.Count != 0)
			{
				_wireList.Clear(quickClear: true);
			}
			if (_wireDirectionList.Count != 0)
			{
				_wireDirectionList.Clear(quickClear: true);
			}
			Vector2[] array = new Vector2[8];
			int num = 0;
			for (int i = left; i < left + width; i++)
			{
				for (int j = top; j < top + height; j++)
				{
					Point16 back = new Point16(i, j);
					Tile tile = Main.tile[i, j];
					if (tile != null && tile.wire())
					{
						_wireList.PushBack(back);
					}
				}
			}
			_teleport[0].X = -1f;
			_teleport[0].Y = -1f;
			_teleport[1].X = -1f;
			_teleport[1].Y = -1f;
			if (_wireList.Count > 0)
			{
				_numInPump = 0;
				_numOutPump = 0;
				HitWire(_wireList, 1);
				if (_numInPump > 0 && _numOutPump > 0)
				{
					XferWater();
				}
			}
			array[num++] = _teleport[0];
			array[num++] = _teleport[1];
			for (int k = left; k < left + width; k++)
			{
				for (int l = top; l < top + height; l++)
				{
					Point16 back = new Point16(k, l);
					Tile tile2 = Main.tile[k, l];
					if (tile2 != null && tile2.wire2())
					{
						_wireList.PushBack(back);
					}
				}
			}
			_teleport[0].X = -1f;
			_teleport[0].Y = -1f;
			_teleport[1].X = -1f;
			_teleport[1].Y = -1f;
			if (_wireList.Count > 0)
			{
				_numInPump = 0;
				_numOutPump = 0;
				HitWire(_wireList, 2);
				if (_numInPump > 0 && _numOutPump > 0)
				{
					XferWater();
				}
			}
			array[num++] = _teleport[0];
			array[num++] = _teleport[1];
			_teleport[0].X = -1f;
			_teleport[0].Y = -1f;
			_teleport[1].X = -1f;
			_teleport[1].Y = -1f;
			for (int m = left; m < left + width; m++)
			{
				for (int n = top; n < top + height; n++)
				{
					Point16 back = new Point16(m, n);
					Tile tile3 = Main.tile[m, n];
					if (tile3 != null && tile3.wire3())
					{
						_wireList.PushBack(back);
					}
				}
			}
			if (_wireList.Count > 0)
			{
				_numInPump = 0;
				_numOutPump = 0;
				HitWire(_wireList, 3);
				if (_numInPump > 0 && _numOutPump > 0)
				{
					XferWater();
				}
			}
			array[num++] = _teleport[0];
			array[num++] = _teleport[1];
			_teleport[0].X = -1f;
			_teleport[0].Y = -1f;
			_teleport[1].X = -1f;
			_teleport[1].Y = -1f;
			for (int num2 = left; num2 < left + width; num2++)
			{
				for (int num3 = top; num3 < top + height; num3++)
				{
					Point16 back = new Point16(num2, num3);
					Tile tile4 = Main.tile[num2, num3];
					if (tile4 != null && tile4.wire4())
					{
						_wireList.PushBack(back);
					}
				}
			}
			if (_wireList.Count > 0)
			{
				_numInPump = 0;
				_numOutPump = 0;
				HitWire(_wireList, 4);
				if (_numInPump > 0 && _numOutPump > 0)
				{
					XferWater();
				}
			}
			array[num++] = _teleport[0];
			array[num++] = _teleport[1];
			for (int num4 = 0; num4 < 8; num4 += 2)
			{
				_teleport[0] = array[num4];
				_teleport[1] = array[num4 + 1];
				if (_teleport[0].X >= 0f && _teleport[1].X >= 0f)
				{
					Teleport();
				}
			}
			PixelBoxPass();
			LogicGatePass();
		}

		private static void PixelBoxPass()
		{
			foreach (KeyValuePair<Point16, byte> pixelBoxTrigger in _PixelBoxTriggers)
			{
				if (pixelBoxTrigger.Value == 2)
				{
					continue;
				}
				if (pixelBoxTrigger.Value == 1)
				{
					if (Main.tile[pixelBoxTrigger.Key.X, pixelBoxTrigger.Key.Y].frameX != 0)
					{
						Main.tile[pixelBoxTrigger.Key.X, pixelBoxTrigger.Key.Y].frameX = 0;
						NetMessage.SendTileSquare(-1, pixelBoxTrigger.Key.X, pixelBoxTrigger.Key.Y, 1);
					}
				}
				else if (pixelBoxTrigger.Value == 3 && Main.tile[pixelBoxTrigger.Key.X, pixelBoxTrigger.Key.Y].frameX != 18)
				{
					Main.tile[pixelBoxTrigger.Key.X, pixelBoxTrigger.Key.Y].frameX = 18;
					NetMessage.SendTileSquare(-1, pixelBoxTrigger.Key.X, pixelBoxTrigger.Key.Y, 1);
				}
			}
			_PixelBoxTriggers.Clear();
		}

		private static void LogicGatePass()
		{
			if (_GatesCurrent.Count != 0)
			{
				return;
			}
			_GatesDone.Clear();
			while (_LampsToCheck.Count > 0)
			{
				while (_LampsToCheck.Count > 0)
				{
					Point16 point = _LampsToCheck.Dequeue();
					CheckLogicGate(point.X, point.Y);
				}
				while (_GatesNext.Count > 0)
				{
					Utils.Swap(ref _GatesCurrent, ref _GatesNext);
					while (_GatesCurrent.Count > 0)
					{
						Point16 key = _GatesCurrent.Peek();
						if (_GatesDone.TryGetValue(key, out var value) && value)
						{
							_GatesCurrent.Dequeue();
							continue;
						}
						_GatesDone.Add(key, value: true);
						TripWire(key.X, key.Y, 1, 1);
						_GatesCurrent.Dequeue();
					}
				}
			}
			_GatesDone.Clear();
			if (blockPlayerTeleportationForOneIteration)
			{
				blockPlayerTeleportationForOneIteration = false;
			}
		}

		private static void CheckLogicGate(int lampX, int lampY)
		{
			if (!WorldGen.InWorld(lampX, lampY, 1))
			{
				return;
			}
			for (int i = lampY; i < Main.maxTilesY; i++)
			{
				Tile tile = Main.tile[lampX, i];
				if (!tile.active())
				{
					break;
				}
				if (tile.type == 420)
				{
					_GatesDone.TryGetValue(new Point16(lampX, i), out var value);
					int num = tile.frameY / 18;
					bool flag = tile.frameX == 18;
					bool flag2 = tile.frameX == 36;
					if (num < 0)
					{
						break;
					}
					int num2 = 0;
					int num3 = 0;
					bool flag3 = false;
					for (int num4 = i - 1; num4 > 0; num4--)
					{
						Tile tile2 = Main.tile[lampX, num4];
						if (!tile2.active() || tile2.type != 419)
						{
							break;
						}
						if (tile2.frameX == 36)
						{
							flag3 = true;
							break;
						}
						num2++;
						num3 += (tile2.frameX == 18).ToInt();
					}
					bool flag4 = false;
					switch (num)
					{
					default:
						return;
					case 0:
						flag4 = num2 == num3;
						break;
					case 2:
						flag4 = num2 != num3;
						break;
					case 1:
						flag4 = num3 > 0;
						break;
					case 3:
						flag4 = num3 == 0;
						break;
					case 4:
						flag4 = num3 == 1;
						break;
					case 5:
						flag4 = num3 != 1;
						break;
					}
					bool flag5 = !flag3 && flag2;
					bool flag6 = false;
					if (flag3 && Framing.GetTileSafely(lampX, lampY).frameX == 36)
					{
						flag6 = true;
					}
					if (!(flag4 != flag || flag5 || flag6))
					{
						break;
					}
					_ = tile.frameX % 18 / 18;
					tile.frameX = (short)(18 * flag4.ToInt());
					if (flag3)
					{
						tile.frameX = 36;
					}
					SkipWire(lampX, i);
					WorldGen.SquareTileFrame(lampX, i);
					NetMessage.SendTileSquare(-1, lampX, i, 1);
					bool flag7 = !flag3 || flag6;
					if (flag6)
					{
						if (num3 == 0 || num2 == 0)
						{
							flag7 = false;
						}
						flag7 = Main.rand.NextFloat() < (float)num3 / (float)num2;
					}
					if (flag5)
					{
						flag7 = false;
					}
					if (flag7)
					{
						if (!value)
						{
							_GatesNext.Enqueue(new Point16(lampX, i));
							break;
						}
						Vector2 position = new Vector2(lampX, i) * 16f - new Vector2(10f);
						Utils.PoofOfSmoke(position);
						NetMessage.SendData(106, -1, -1, null, (int)position.X, position.Y);
					}
					break;
				}
				if (tile.type != 419)
				{
					break;
				}
			}
		}

		private static void HitWire(DoubleStack<Point16> next, int wireType)
		{
			_wireDirectionList.Clear(quickClear: true);
			for (int i = 0; i < next.Count; i++)
			{
				Point16 point = next.PopFront();
				SkipWire(point);
				_toProcess.Add(point, 4);
				next.PushBack(point);
				_wireDirectionList.PushBack(0);
			}
			_currentWireColor = wireType;
			while (next.Count > 0)
			{
				Point16 key = next.PopFront();
				int num = _wireDirectionList.PopFront();
				int x = key.X;
				int y = key.Y;
				if (!_wireSkip.ContainsKey(key))
				{
					HitWireSingle(x, y);
				}
				for (int j = 0; j < 4; j++)
				{
					int num2;
					int num3;
					switch (j)
					{
					case 0:
						num2 = x;
						num3 = y + 1;
						break;
					case 1:
						num2 = x;
						num3 = y - 1;
						break;
					case 2:
						num2 = x + 1;
						num3 = y;
						break;
					case 3:
						num2 = x - 1;
						num3 = y;
						break;
					default:
						num2 = x;
						num3 = y + 1;
						break;
					}
					if (num2 < 2 || num2 >= Main.maxTilesX - 2 || num3 < 2 || num3 >= Main.maxTilesY - 2)
					{
						continue;
					}
					Tile tile = Main.tile[num2, num3];
					if (tile == null)
					{
						continue;
					}
					Tile tile2 = Main.tile[x, y];
					if (tile2 == null)
					{
						continue;
					}
					byte b = 3;
					if (tile.type == 424 || tile.type == 445)
					{
						b = 0;
					}
					if (tile2.type == 424)
					{
						switch (tile2.frameX / 18)
						{
						case 0:
							if (j != num)
							{
								continue;
							}
							break;
						case 1:
							if ((num != 0 || j != 3) && (num != 3 || j != 0) && (num != 1 || j != 2) && (num != 2 || j != 1))
							{
								continue;
							}
							break;
						case 2:
							if ((num != 0 || j != 2) && (num != 2 || j != 0) && (num != 1 || j != 3) && (num != 3 || j != 1))
							{
								continue;
							}
							break;
						}
					}
					if (tile2.type == 445)
					{
						if (j != num)
						{
							continue;
						}
						if (_PixelBoxTriggers.ContainsKey(key))
						{
							_PixelBoxTriggers[key] |= (byte)((!(j == 0 || j == 1)) ? 1 : 2);
						}
						else
						{
							_PixelBoxTriggers[key] = (byte)((!(j == 0 || j == 1)) ? 1u : 2u);
						}
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
					case 4:
						flag = tile.wire4();
						break;
					default:
						flag = false;
						break;
					}
					if (!flag)
					{
						continue;
					}
					Point16 point2 = new Point16(num2, num3);
					if (_toProcess.TryGetValue(point2, out var value))
					{
						value--;
						if (value == 0)
						{
							_toProcess.Remove(point2);
						}
						else
						{
							_toProcess[point2] = value;
						}
						continue;
					}
					next.PushBack(point2);
					_wireDirectionList.PushBack((byte)j);
					if (b > 0)
					{
						_toProcess.Add(point2, b);
					}
				}
			}
			_wireSkip.Clear();
			_toProcess.Clear();
			running = false;
		}

		private static void HitWireSingle(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			int type = tile.type;
			if (tile.actuator())
			{
				ActuateForced(i, j);
			}
			if (!tile.active())
			{
				return;
			}
			switch (type)
			{
			case 144:
				HitSwitch(i, j);
				WorldGen.SquareTileFrame(i, j);
				NetMessage.SendTileSquare(-1, i, j, 1);
				break;
			case 421:
				if (!tile.actuator())
				{
					tile.type = 422;
					WorldGen.SquareTileFrame(i, j);
					NetMessage.SendTileSquare(-1, i, j, 1);
				}
				break;
			case 422:
				if (!tile.actuator())
				{
					tile.type = 421;
					WorldGen.SquareTileFrame(i, j);
					NetMessage.SendTileSquare(-1, i, j, 1);
				}
				break;
			}
			if (type >= 255 && type <= 268)
			{
				if (!tile.actuator())
				{
					if (type >= 262)
					{
						tile.type -= 7;
					}
					else
					{
						tile.type += 7;
					}
					WorldGen.SquareTileFrame(i, j);
					NetMessage.SendTileSquare(-1, i, j, 1);
				}
				return;
			}
			switch (type)
			{
			case 419:
			{
				int num70 = 18;
				if (tile.frameX >= num70)
				{
					num70 = -num70;
				}
				if (tile.frameX == 36)
				{
					num70 = 0;
				}
				SkipWire(i, j);
				tile.frameX = (short)(tile.frameX + num70);
				WorldGen.SquareTileFrame(i, j);
				NetMessage.SendTileSquare(-1, i, j, 1);
				_LampsToCheck.Enqueue(new Point16(i, j));
				break;
			}
			case 406:
			{
				int num7 = tile.frameX % 54 / 18;
				int num8 = tile.frameY % 54 / 18;
				int num9 = i - num7;
				int num10 = j - num8;
				int num11 = 54;
				if (Main.tile[num9, num10].frameY >= 108)
				{
					num11 = -108;
				}
				for (int m = num9; m < num9 + 3; m++)
				{
					for (int n = num10; n < num10 + 3; n++)
					{
						SkipWire(m, n);
						Main.tile[m, n].frameY = (short)(Main.tile[m, n].frameY + num11);
					}
				}
				NetMessage.SendTileSquare(-1, num9 + 1, num10 + 1, 3);
				break;
			}
			case 452:
			{
				int num117 = tile.frameX % 54 / 18;
				int num118 = tile.frameY % 54 / 18;
				int num119 = i - num117;
				int num120 = j - num118;
				int num121 = 54;
				if (Main.tile[num119, num120].frameX >= 54)
				{
					num121 = -54;
				}
				for (int num122 = num119; num122 < num119 + 3; num122++)
				{
					for (int num123 = num120; num123 < num120 + 3; num123++)
					{
						SkipWire(num122, num123);
						Main.tile[num122, num123].frameX = (short)(Main.tile[num122, num123].frameX + num121);
					}
				}
				NetMessage.SendTileSquare(-1, num119 + 1, num120 + 1, 3);
				break;
			}
			case 411:
			{
				int num96 = tile.frameX % 36 / 18;
				int num97 = tile.frameY % 36 / 18;
				int num98 = i - num96;
				int num99 = j - num97;
				int num100 = 36;
				if (Main.tile[num98, num99].frameX >= 36)
				{
					num100 = -36;
				}
				for (int num101 = num98; num101 < num98 + 2; num101++)
				{
					for (int num102 = num99; num102 < num99 + 2; num102++)
					{
						SkipWire(num101, num102);
						Main.tile[num101, num102].frameX = (short)(Main.tile[num101, num102].frameX + num100);
					}
				}
				NetMessage.SendTileSquare(-1, num98, num99, 2);
				break;
			}
			case 425:
			{
				int num109 = tile.frameX % 36 / 18;
				int num110 = tile.frameY % 36 / 18;
				int num111 = i - num109;
				int num112 = j - num110;
				for (int num113 = num111; num113 < num111 + 2; num113++)
				{
					for (int num114 = num112; num114 < num112 + 2; num114++)
					{
						SkipWire(num113, num114);
					}
				}
				if (Main.AnnouncementBoxDisabled)
				{
					break;
				}
				Color pink = Color.Pink;
				int num115 = Sign.ReadSign(num111, num112, CreateIfMissing: false);
				if (num115 == -1 || Main.sign[num115] == null || string.IsNullOrWhiteSpace(Main.sign[num115].text))
				{
					break;
				}
				if (Main.AnnouncementBoxRange == -1)
				{
					if (Main.netMode == 0)
					{
						Main.NewTextMultiline(Main.sign[num115].text, force: false, pink, 460);
					}
					else if (Main.netMode == 2)
					{
						NetMessage.SendData(107, -1, -1, NetworkText.FromLiteral(Main.sign[num115].text), 255, (int)pink.R, (int)pink.G, (int)pink.B, 460);
					}
				}
				else if (Main.netMode == 0)
				{
					if (Main.player[Main.myPlayer].Distance(new Vector2(num111 * 16 + 16, num112 * 16 + 16)) <= (float)Main.AnnouncementBoxRange)
					{
						Main.NewTextMultiline(Main.sign[num115].text, force: false, pink, 460);
					}
				}
				else
				{
					if (Main.netMode != 2)
					{
						break;
					}
					for (int num116 = 0; num116 < 255; num116++)
					{
						if (Main.player[num116].active && Main.player[num116].Distance(new Vector2(num111 * 16 + 16, num112 * 16 + 16)) <= (float)Main.AnnouncementBoxRange)
						{
							NetMessage.SendData(107, num116, -1, NetworkText.FromLiteral(Main.sign[num115].text), 255, (int)pink.R, (int)pink.G, (int)pink.B, 460);
						}
					}
				}
				break;
			}
			case 405:
			{
				int num130 = tile.frameX % 54 / 18;
				int num131 = tile.frameY % 36 / 18;
				int num132 = i - num130;
				int num133 = j - num131;
				int num134 = 54;
				if (Main.tile[num132, num133].frameX >= 54)
				{
					num134 = -54;
				}
				for (int num135 = num132; num135 < num132 + 3; num135++)
				{
					for (int num136 = num133; num136 < num133 + 2; num136++)
					{
						SkipWire(num135, num136);
						Main.tile[num135, num136].frameX = (short)(Main.tile[num135, num136].frameX + num134);
					}
				}
				NetMessage.SendTileSquare(-1, num132 + 1, num133 + 1, 3);
				break;
			}
			case 209:
			{
				int num15 = tile.frameX % 72 / 18;
				int num16 = tile.frameY % 54 / 18;
				int num17 = i - num15;
				int num18 = j - num16;
				int num19 = tile.frameY / 54;
				int num20 = tile.frameX / 72;
				int num21 = -1;
				if (num15 == 1 || num15 == 2)
				{
					num21 = num16;
				}
				int num22 = 0;
				if (num15 == 3)
				{
					num22 = -54;
				}
				if (num15 == 0)
				{
					num22 = 54;
				}
				if (num19 >= 8 && num22 > 0)
				{
					num22 = 0;
				}
				if (num19 == 0 && num22 < 0)
				{
					num22 = 0;
				}
				bool flag6 = false;
				if (num22 != 0)
				{
					for (int num23 = num17; num23 < num17 + 4; num23++)
					{
						for (int num24 = num18; num24 < num18 + 3; num24++)
						{
							SkipWire(num23, num24);
							Main.tile[num23, num24].frameY = (short)(Main.tile[num23, num24].frameY + num22);
						}
					}
					flag6 = true;
				}
				if ((num20 == 3 || num20 == 4) && (num21 == 0 || num21 == 1))
				{
					num22 = ((num20 == 3) ? 72 : (-72));
					for (int num25 = num17; num25 < num17 + 4; num25++)
					{
						for (int num26 = num18; num26 < num18 + 3; num26++)
						{
							SkipWire(num25, num26);
							Main.tile[num25, num26].frameX = (short)(Main.tile[num25, num26].frameX + num22);
						}
					}
					flag6 = true;
				}
				if (flag6)
				{
					NetMessage.SendTileSquare(-1, num17 + 1, num18 + 1, 4);
				}
				if (num21 != -1)
				{
					bool flag7 = true;
					if ((num20 == 3 || num20 == 4) && num21 < 2)
					{
						flag7 = false;
					}
					if (CheckMech(num17, num18, 30) && flag7)
					{
						WorldGen.ShootFromCannon(num17, num18, num19, num20 + 1, 0, 0f, CurrentUser);
					}
				}
				break;
			}
			case 212:
			{
				int num81 = tile.frameX % 54 / 18;
				int num82 = tile.frameY % 54 / 18;
				int num83 = i - num81;
				int num84 = j - num82;
				int num85 = tile.frameX / 54;
				int num86 = -1;
				if (num81 == 1)
				{
					num86 = num82;
				}
				int num87 = 0;
				if (num81 == 0)
				{
					num87 = -54;
				}
				if (num81 == 2)
				{
					num87 = 54;
				}
				if (num85 >= 1 && num87 > 0)
				{
					num87 = 0;
				}
				if (num85 == 0 && num87 < 0)
				{
					num87 = 0;
				}
				bool flag10 = false;
				if (num87 != 0)
				{
					for (int num88 = num83; num88 < num83 + 3; num88++)
					{
						for (int num89 = num84; num89 < num84 + 3; num89++)
						{
							SkipWire(num88, num89);
							Main.tile[num88, num89].frameX = (short)(Main.tile[num88, num89].frameX + num87);
						}
					}
					flag10 = true;
				}
				if (flag10)
				{
					NetMessage.SendTileSquare(-1, num83 + 1, num84 + 1, 4);
				}
				if (num86 != -1 && CheckMech(num83, num84, 10))
				{
					float num90 = 12f + (float)Main.rand.Next(450) * 0.01f;
					float num91 = Main.rand.Next(85, 105);
					float num92 = Main.rand.Next(-35, 11);
					int type2 = 166;
					int damage3 = 0;
					float knockBack = 0f;
					Vector2 vector2 = new Vector2((num83 + 2) * 16 - 8, (num84 + 2) * 16 - 8);
					if (tile.frameX / 54 == 0)
					{
						num91 *= -1f;
						vector2.X -= 12f;
					}
					else
					{
						vector2.X += 12f;
					}
					float num93 = num91;
					float num94 = num92;
					float num95 = (float)Math.Sqrt(num93 * num93 + num94 * num94);
					num95 = num90 / num95;
					num93 *= num95;
					num94 *= num95;
					Projectile.NewProjectile(vector2.X, vector2.Y, num93, num94, type2, damage3, knockBack, CurrentUser);
				}
				break;
			}
			case 215:
			{
				int num137 = tile.frameX % 54 / 18;
				int num138 = tile.frameY % 36 / 18;
				int num139 = i - num137;
				int num140 = j - num138;
				int num141 = 36;
				if (Main.tile[num139, num140].frameY >= 36)
				{
					num141 = -36;
				}
				for (int num142 = num139; num142 < num139 + 3; num142++)
				{
					for (int num143 = num140; num143 < num140 + 2; num143++)
					{
						SkipWire(num142, num143);
						Main.tile[num142, num143].frameY = (short)(Main.tile[num142, num143].frameY + num141);
					}
				}
				NetMessage.SendTileSquare(-1, num139 + 1, num140 + 1, 3);
				break;
			}
			case 130:
				if (Main.tile[i, j - 1] == null || !Main.tile[i, j - 1].active() || (!TileID.Sets.BasicChest[Main.tile[i, j - 1].type] && !TileID.Sets.BasicChestFake[Main.tile[i, j - 1].type] && Main.tile[i, j - 1].type != 88))
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
			case 386:
			case 387:
			{
				bool value = type == 387;
				int num14 = WorldGen.ShiftTrapdoor(i, j, playerAbove: true).ToInt();
				if (num14 == 0)
				{
					num14 = -WorldGen.ShiftTrapdoor(i, j, playerAbove: false).ToInt();
				}
				if (num14 != 0)
				{
					NetMessage.SendData(19, -1, -1, null, 3 - value.ToInt(), i, j, num14);
				}
				break;
			}
			case 388:
			case 389:
			{
				bool flag11 = type == 389;
				WorldGen.ShiftTallGate(i, j, flag11);
				NetMessage.SendData(19, -1, -1, null, 4 + flag11.ToInt(), i, j);
				break;
			}
			case 11:
				if (WorldGen.CloseDoor(i, j, forced: true))
				{
					NetMessage.SendData(19, -1, -1, null, 1, i, j);
				}
				break;
			case 10:
			{
				int num73 = 1;
				if (Main.rand.Next(2) == 0)
				{
					num73 = -1;
				}
				if (!WorldGen.OpenDoor(i, j, num73))
				{
					if (WorldGen.OpenDoor(i, j, -num73))
					{
						NetMessage.SendData(19, -1, -1, null, 0, i, j, -num73);
					}
				}
				else
				{
					NetMessage.SendData(19, -1, -1, null, 0, i, j, num73);
				}
				break;
			}
			case 216:
				WorldGen.LaunchRocket(i, j);
				SkipWire(i, j);
				break;
			case 335:
			{
				int num50 = j - tile.frameY / 18;
				int num51 = i - tile.frameX / 18;
				SkipWire(num51, num50);
				SkipWire(num51, num50 + 1);
				SkipWire(num51 + 1, num50);
				SkipWire(num51 + 1, num50 + 1);
				if (CheckMech(num51, num50, 30))
				{
					WorldGen.LaunchRocketSmall(num51, num50);
				}
				break;
			}
			case 338:
			{
				int num147 = j - tile.frameY / 18;
				int num148 = i - tile.frameX / 18;
				SkipWire(num148, num147);
				SkipWire(num148, num147 + 1);
				if (!CheckMech(num148, num147, 30))
				{
					break;
				}
				bool flag12 = false;
				for (int num149 = 0; num149 < 1000; num149++)
				{
					if (Main.projectile[num149].active && Main.projectile[num149].aiStyle == 73 && Main.projectile[num149].ai[0] == (float)num148 && Main.projectile[num149].ai[1] == (float)num147)
					{
						flag12 = true;
						break;
					}
				}
				if (!flag12)
				{
					Projectile.NewProjectile(num148 * 16 + 8, num147 * 16 + 2, 0f, 0f, 419 + Main.rand.Next(4), 0, 0f, Main.myPlayer, num148, num147);
				}
				break;
			}
			case 235:
			{
				int num71 = i - tile.frameX / 18;
				if (tile.wall == 87 && (double)j > Main.worldSurface && !NPC.downedPlantBoss)
				{
					break;
				}
				if (_teleport[0].X == -1f)
				{
					_teleport[0].X = num71;
					_teleport[0].Y = j;
					if (tile.halfBrick())
					{
						_teleport[0].Y += 0.5f;
					}
				}
				else if (_teleport[0].X != (float)num71 || _teleport[0].Y != (float)j)
				{
					_teleport[1].X = num71;
					_teleport[1].Y = j;
					if (tile.halfBrick())
					{
						_teleport[1].Y += 0.5f;
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
			case 429:
			{
				int num12 = Main.tile[i, j].frameX / 18;
				bool flag = num12 % 2 >= 1;
				bool flag2 = num12 % 4 >= 2;
				bool flag3 = num12 % 8 >= 4;
				bool flag4 = num12 % 16 >= 8;
				bool flag5 = false;
				short num13 = 0;
				switch (_currentWireColor)
				{
				case 1:
					num13 = 18;
					flag5 = !flag;
					break;
				case 2:
					num13 = 72;
					flag5 = !flag3;
					break;
				case 3:
					num13 = 36;
					flag5 = !flag2;
					break;
				case 4:
					num13 = 144;
					flag5 = !flag4;
					break;
				}
				if (flag5)
				{
					tile.frameX += num13;
				}
				else
				{
					tile.frameX -= num13;
				}
				NetMessage.SendTileSquare(-1, i, j, 1);
				break;
			}
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
				int num74;
				for (num74 = tile.frameX / 18; num74 >= 3; num74 -= 3)
				{
				}
				int num75;
				for (num75 = tile.frameY / 18; num75 >= 3; num75 -= 3)
				{
				}
				int num76 = i - num74;
				int num77 = j - num75;
				int num78 = 54;
				if (Main.tile[num76, num77].frameX >= 54)
				{
					num78 = -54;
				}
				for (int num79 = num76; num79 < num76 + 3; num79++)
				{
					for (int num80 = num77; num80 < num77 + 2; num80++)
					{
						SkipWire(num79, num80);
						Main.tile[num79, num80].frameX = (short)(Main.tile[num79, num80].frameX + num78);
					}
				}
				NetMessage.SendTileSquare(-1, num76 + 1, num77 + 1, 3);
				break;
			}
			case 42:
			{
				int num67;
				for (num67 = tile.frameY / 18; num67 >= 2; num67 -= 2)
				{
				}
				int num68 = j - num67;
				short num69 = 18;
				if (tile.frameX > 0)
				{
					num69 = -18;
				}
				Main.tile[i, num68].frameX += num69;
				Main.tile[i, num68 + 1].frameX += num69;
				SkipWire(i, num68);
				SkipWire(i, num68 + 1);
				NetMessage.SendTileSquare(-1, i, j, 2);
				break;
			}
			case 93:
			{
				int num27;
				for (num27 = tile.frameY / 18; num27 >= 3; num27 -= 3)
				{
				}
				num27 = j - num27;
				short num28 = 18;
				if (tile.frameX > 0)
				{
					num28 = -18;
				}
				Main.tile[i, num27].frameX += num28;
				Main.tile[i, num27 + 1].frameX += num28;
				Main.tile[i, num27 + 2].frameX += num28;
				SkipWire(i, num27);
				SkipWire(i, num27 + 1);
				SkipWire(i, num27 + 2);
				NetMessage.SendTileSquare(-1, i, num27 + 1, 3);
				break;
			}
			case 95:
			case 100:
			case 126:
			case 173:
			{
				int num144;
				for (num144 = tile.frameY / 18; num144 >= 2; num144 -= 2)
				{
				}
				num144 = j - num144;
				int num145 = tile.frameX / 18;
				if (num145 > 1)
				{
					num145 -= 2;
				}
				num145 = i - num145;
				short num146 = 36;
				if (Main.tile[num145, num144].frameX > 0)
				{
					num146 = -36;
				}
				Main.tile[num145, num144].frameX += num146;
				Main.tile[num145, num144 + 1].frameX += num146;
				Main.tile[num145 + 1, num144].frameX += num146;
				Main.tile[num145 + 1, num144 + 1].frameX += num146;
				SkipWire(num145, num144);
				SkipWire(num145 + 1, num144);
				SkipWire(num145, num144 + 1);
				SkipWire(num145 + 1, num144 + 1);
				NetMessage.SendTileSquare(-1, num145, num144, 3);
				break;
			}
			case 34:
			{
				int num103;
				for (num103 = tile.frameY / 18; num103 >= 3; num103 -= 3)
				{
				}
				int num104 = j - num103;
				int num105 = tile.frameX % 108 / 18;
				if (num105 > 2)
				{
					num105 -= 3;
				}
				num105 = i - num105;
				short num106 = 54;
				if (Main.tile[num105, num104].frameX % 108 > 0)
				{
					num106 = -54;
				}
				for (int num107 = num105; num107 < num105 + 3; num107++)
				{
					for (int num108 = num104; num108 < num104 + 3; num108++)
					{
						Main.tile[num107, num108].frameX += num106;
						SkipWire(num107, num108);
					}
				}
				NetMessage.SendTileSquare(-1, num105 + 1, num104 + 1, 3);
				break;
			}
			case 314:
				if (CheckMech(i, j, 5))
				{
					Minecart.FlipSwitchTrack(i, j);
				}
				break;
			case 33:
			case 174:
			{
				short num72 = 18;
				if (tile.frameX > 0)
				{
					num72 = -18;
				}
				tile.frameX += num72;
				NetMessage.SendTileSquare(-1, i, j, 3);
				break;
			}
			case 92:
			{
				int num47 = j - tile.frameY / 18;
				short num48 = 18;
				if (tile.frameX > 0)
				{
					num48 = -18;
				}
				for (int num49 = num47; num49 < num47 + 6; num49++)
				{
					Main.tile[i, num49].frameX += num48;
					SkipWire(i, num49);
				}
				NetMessage.SendTileSquare(-1, i, num47 + 3, 7);
				break;
			}
			case 137:
			{
				int num29 = tile.frameY / 18;
				Vector2 vector = Vector2.Zero;
				float speedX = 0f;
				float speedY = 0f;
				int num30 = 0;
				int damage2 = 0;
				switch (num29)
				{
				case 0:
				case 1:
				case 2:
					if (CheckMech(i, j, 200))
					{
						int num38 = ((tile.frameX == 0) ? (-1) : ((tile.frameX == 18) ? 1 : 0));
						int num39 = ((tile.frameX >= 36) ? ((tile.frameX >= 72) ? 1 : (-1)) : 0);
						vector = new Vector2(i * 16 + 8 + 10 * num38, j * 16 + 9 + num39 * 9);
						float num40 = 3f;
						if (num29 == 0)
						{
							num30 = 98;
							damage2 = 20;
							num40 = 12f;
						}
						if (num29 == 1)
						{
							num30 = 184;
							damage2 = 40;
							num40 = 12f;
						}
						if (num29 == 2)
						{
							num30 = 187;
							damage2 = 40;
							num40 = 5f;
						}
						speedX = (float)num38 * num40;
						speedY = (float)num39 * num40;
					}
					break;
				case 3:
				{
					if (!CheckMech(i, j, 300))
					{
						break;
					}
					int num33 = 200;
					for (int num34 = 0; num34 < 1000; num34++)
					{
						if (Main.projectile[num34].active && Main.projectile[num34].type == num30)
						{
							float num35 = (new Vector2(i * 16 + 8, j * 18 + 8) - Main.projectile[num34].Center).Length();
							num33 = ((!(num35 < 50f)) ? ((!(num35 < 100f)) ? ((!(num35 < 200f)) ? ((!(num35 < 300f)) ? ((!(num35 < 400f)) ? ((!(num35 < 500f)) ? ((!(num35 < 700f)) ? ((!(num35 < 900f)) ? ((!(num35 < 1200f)) ? (num33 - 1) : (num33 - 2)) : (num33 - 3)) : (num33 - 4)) : (num33 - 5)) : (num33 - 6)) : (num33 - 8)) : (num33 - 10)) : (num33 - 15)) : (num33 - 50));
						}
					}
					if (num33 > 0)
					{
						num30 = 185;
						damage2 = 40;
						int num36 = 0;
						int num37 = 0;
						switch (tile.frameX / 18)
						{
						case 0:
						case 1:
							num36 = 0;
							num37 = 1;
							break;
						case 2:
							num36 = 0;
							num37 = -1;
							break;
						case 3:
							num36 = -1;
							num37 = 0;
							break;
						case 4:
							num36 = 1;
							num37 = 0;
							break;
						}
						speedX = (float)(4 * num36) + (float)Main.rand.Next(-20 + ((num36 == 1) ? 20 : 0), 21 - ((num36 == -1) ? 20 : 0)) * 0.05f;
						speedY = (float)(4 * num37) + (float)Main.rand.Next(-20 + ((num37 == 1) ? 20 : 0), 21 - ((num37 == -1) ? 20 : 0)) * 0.05f;
						vector = new Vector2(i * 16 + 8 + 14 * num36, j * 16 + 8 + 14 * num37);
					}
					break;
				}
				case 4:
					if (CheckMech(i, j, 90))
					{
						int num31 = 0;
						int num32 = 0;
						switch (tile.frameX / 18)
						{
						case 0:
						case 1:
							num31 = 0;
							num32 = 1;
							break;
						case 2:
							num31 = 0;
							num32 = -1;
							break;
						case 3:
							num31 = -1;
							num32 = 0;
							break;
						case 4:
							num31 = 1;
							num32 = 0;
							break;
						}
						speedX = 8 * num31;
						speedY = 8 * num32;
						damage2 = 60;
						num30 = 186;
						vector = new Vector2(i * 16 + 8 + 18 * num31, j * 16 + 8 + 18 * num32);
					}
					break;
				}
				switch (num29)
				{
				case -10:
					if (CheckMech(i, j, 200))
					{
						int num45 = -1;
						if (tile.frameX != 0)
						{
							num45 = 1;
						}
						speedX = 12 * num45;
						damage2 = 20;
						num30 = 98;
						vector = new Vector2(i * 16 + 8, j * 16 + 7);
						vector.X += 10 * num45;
						vector.Y += 2f;
					}
					break;
				case -9:
					if (CheckMech(i, j, 200))
					{
						int num41 = -1;
						if (tile.frameX != 0)
						{
							num41 = 1;
						}
						speedX = 12 * num41;
						damage2 = 40;
						num30 = 184;
						vector = new Vector2(i * 16 + 8, j * 16 + 7);
						vector.X += 10 * num41;
						vector.Y += 2f;
					}
					break;
				case -8:
					if (CheckMech(i, j, 200))
					{
						int num46 = -1;
						if (tile.frameX != 0)
						{
							num46 = 1;
						}
						speedX = 5 * num46;
						damage2 = 40;
						num30 = 187;
						vector = new Vector2(i * 16 + 8, j * 16 + 7);
						vector.X += 10 * num46;
						vector.Y += 2f;
					}
					break;
				case -7:
				{
					if (!CheckMech(i, j, 300))
					{
						break;
					}
					num30 = 185;
					int num42 = 200;
					for (int num43 = 0; num43 < 1000; num43++)
					{
						if (Main.projectile[num43].active && Main.projectile[num43].type == num30)
						{
							float num44 = (new Vector2(i * 16 + 8, j * 18 + 8) - Main.projectile[num43].Center).Length();
							num42 = ((!(num44 < 50f)) ? ((!(num44 < 100f)) ? ((!(num44 < 200f)) ? ((!(num44 < 300f)) ? ((!(num44 < 400f)) ? ((!(num44 < 500f)) ? ((!(num44 < 700f)) ? ((!(num44 < 900f)) ? ((!(num44 < 1200f)) ? (num42 - 1) : (num42 - 2)) : (num42 - 3)) : (num42 - 4)) : (num42 - 5)) : (num42 - 6)) : (num42 - 8)) : (num42 - 10)) : (num42 - 15)) : (num42 - 50));
						}
					}
					if (num42 > 0)
					{
						speedX = (float)Main.rand.Next(-20, 21) * 0.05f;
						speedY = 4f + (float)Main.rand.Next(0, 21) * 0.05f;
						damage2 = 40;
						vector = new Vector2(i * 16 + 8, j * 16 + 16);
						vector.Y += 6f;
						Projectile.NewProjectile((int)vector.X, (int)vector.Y, speedX, speedY, num30, damage2, 2f, Main.myPlayer);
					}
					break;
				}
				case -6:
					if (CheckMech(i, j, 90))
					{
						speedX = 0f;
						speedY = 8f;
						damage2 = 60;
						num30 = 186;
						vector = new Vector2(i * 16 + 8, j * 16 + 16);
						vector.Y += 10f;
					}
					break;
				}
				if (num30 != 0)
				{
					Projectile.NewProjectile((int)vector.X, (int)vector.Y, speedX, speedY, num30, damage2, 2f, Main.myPlayer);
				}
				break;
			}
			case 443:
			{
				int num4 = tile.frameX / 36;
				int num5 = i - (tile.frameX - num4 * 36) / 18;
				if (CheckMech(num5, j, 200))
				{
					Vector2 zero = Vector2.Zero;
					Vector2 zero2 = Vector2.Zero;
					int num6 = 654;
					int damage = 20;
					if (num4 < 2)
					{
						zero = new Vector2(num5 + 1, j) * 16f;
						zero2 = new Vector2(0f, -8f);
					}
					else
					{
						zero = new Vector2(num5 + 1, j + 1) * 16f;
						zero2 = new Vector2(0f, 8f);
					}
					if (num6 != 0)
					{
						Projectile.NewProjectile((int)zero.X, (int)zero.Y, zero2.X, zero2.Y, num6, damage, 2f, Main.myPlayer);
					}
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
			case 410:
				WorldGen.SwitchMonolith(i, j);
				break;
			case 455:
				BirthdayParty.ToggleManualParty();
				break;
			case 141:
				WorldGen.KillTile(i, j, fail: false, effectOnly: false, noItem: true);
				NetMessage.SendTileSquare(-1, i, j, 1);
				Projectile.NewProjectile(i * 16 + 8, j * 16 + 8, 0f, 0f, 108, 500, 10f, Main.myPlayer);
				break;
			case 210:
				WorldGen.ExplodeMine(i, j);
				break;
			case 142:
			case 143:
			{
				int num124 = j - tile.frameY / 18;
				int num125 = tile.frameX / 18;
				if (num125 > 1)
				{
					num125 -= 2;
				}
				num125 = i - num125;
				SkipWire(num125, num124);
				SkipWire(num125, num124 + 1);
				SkipWire(num125 + 1, num124);
				SkipWire(num125 + 1, num124 + 1);
				if (type == 142)
				{
					for (int num126 = 0; num126 < 4; num126++)
					{
						if (_numInPump >= 19)
						{
							break;
						}
						int num127;
						int num128;
						switch (num126)
						{
						case 0:
							num127 = num125;
							num128 = num124 + 1;
							break;
						case 1:
							num127 = num125 + 1;
							num128 = num124 + 1;
							break;
						case 2:
							num127 = num125;
							num128 = num124;
							break;
						default:
							num127 = num125 + 1;
							num128 = num124;
							break;
						}
						_inPumpX[_numInPump] = num127;
						_inPumpY[_numInPump] = num128;
						_numInPump++;
					}
					break;
				}
				for (int num129 = 0; num129 < 4; num129++)
				{
					if (_numOutPump >= 19)
					{
						break;
					}
					int num127;
					int num128;
					switch (num129)
					{
					case 0:
						num127 = num125;
						num128 = num124 + 1;
						break;
					case 1:
						num127 = num125 + 1;
						num128 = num124 + 1;
						break;
					case 2:
						num127 = num125;
						num128 = num124;
						break;
					default:
						num127 = num125 + 1;
						num128 = num124;
						break;
					}
					_outPumpX[_numOutPump] = num127;
					_outPumpY[_numOutPump] = num128;
					_numOutPump++;
				}
				break;
			}
			case 105:
			{
				int num52 = j - tile.frameY / 18;
				int num53 = tile.frameX / 18;
				int num54 = 0;
				while (num53 >= 2)
				{
					num53 -= 2;
					num54++;
				}
				num53 = i - num53;
				num53 = i - tile.frameX % 36 / 18;
				num52 = j - tile.frameY % 54 / 18;
				num54 = tile.frameX / 36 + tile.frameY / 54 * 55;
				SkipWire(num53, num52);
				SkipWire(num53, num52 + 1);
				SkipWire(num53, num52 + 2);
				SkipWire(num53 + 1, num52);
				SkipWire(num53 + 1, num52 + 1);
				SkipWire(num53 + 1, num52 + 2);
				int num55 = num53 * 16 + 16;
				int num56 = (num52 + 3) * 16;
				int num57 = -1;
				int num58 = -1;
				bool flag8 = true;
				bool flag9 = false;
				switch (num54)
				{
				case 51:
					num58 = Utils.SelectRandom(Main.rand, new short[2] { 299, 538 });
					break;
				case 52:
					num58 = 356;
					break;
				case 53:
					num58 = 357;
					break;
				case 54:
					num58 = Utils.SelectRandom(Main.rand, new short[2] { 355, 358 });
					break;
				case 55:
					num58 = Utils.SelectRandom(Main.rand, new short[2] { 367, 366 });
					break;
				case 56:
					num58 = Utils.SelectRandom(Main.rand, new short[5] { 359, 359, 359, 359, 360 });
					break;
				case 57:
					num58 = 377;
					break;
				case 58:
					num58 = 300;
					break;
				case 59:
					num58 = Utils.SelectRandom(Main.rand, new short[2] { 364, 362 });
					break;
				case 60:
					num58 = 148;
					break;
				case 61:
					num58 = 361;
					break;
				case 62:
					num58 = Utils.SelectRandom(Main.rand, new short[3] { 487, 486, 485 });
					break;
				case 63:
					num58 = 164;
					flag8 &= NPC.MechSpawn(num55, num56, 165);
					break;
				case 64:
					num58 = 86;
					flag9 = true;
					break;
				case 65:
					num58 = 490;
					break;
				case 66:
					num58 = 82;
					break;
				case 67:
					num58 = 449;
					break;
				case 68:
					num58 = 167;
					break;
				case 69:
					num58 = 480;
					break;
				case 70:
					num58 = 48;
					break;
				case 71:
					num58 = Utils.SelectRandom(Main.rand, new short[3] { 170, 180, 171 });
					flag9 = true;
					break;
				case 72:
					num58 = 481;
					break;
				case 73:
					num58 = 482;
					break;
				case 74:
					num58 = 430;
					break;
				case 75:
					num58 = 489;
					break;
				}
				if (num58 != -1 && CheckMech(num53, num52, 30) && NPC.MechSpawn(num55, num56, num58) && flag8)
				{
					if (!flag9 || !Collision.SolidTiles(num53 - 2, num53 + 3, num52, num52 + 2))
					{
						num57 = NPC.NewNPC(num55, num56 - 12, num58);
					}
					else
					{
						Vector2 position = new Vector2(num55 - 4, num56 - 22) - new Vector2(10f);
						Utils.PoofOfSmoke(position);
						NetMessage.SendData(106, -1, -1, null, (int)position.X, position.Y);
					}
				}
				if (num57 <= -1)
				{
					switch (num54)
					{
					case 4:
						if (CheckMech(num53, num52, 30) && NPC.MechSpawn(num55, num56, 1))
						{
							num57 = NPC.NewNPC(num55, num56 - 12, 1);
						}
						break;
					case 7:
						if (CheckMech(num53, num52, 30) && NPC.MechSpawn(num55, num56, 49))
						{
							num57 = NPC.NewNPC(num55 - 4, num56 - 6, 49);
						}
						break;
					case 8:
						if (CheckMech(num53, num52, 30) && NPC.MechSpawn(num55, num56, 55))
						{
							num57 = NPC.NewNPC(num55, num56 - 12, 55);
						}
						break;
					case 9:
						if (CheckMech(num53, num52, 30) && NPC.MechSpawn(num55, num56, 46))
						{
							num57 = NPC.NewNPC(num55, num56 - 12, 46);
						}
						break;
					case 10:
						if (CheckMech(num53, num52, 30) && NPC.MechSpawn(num55, num56, 21))
						{
							num57 = NPC.NewNPC(num55, num56, 21);
						}
						break;
					case 18:
						if (CheckMech(num53, num52, 30) && NPC.MechSpawn(num55, num56, 67))
						{
							num57 = NPC.NewNPC(num55, num56 - 12, 67);
						}
						break;
					case 23:
						if (CheckMech(num53, num52, 30) && NPC.MechSpawn(num55, num56, 63))
						{
							num57 = NPC.NewNPC(num55, num56 - 12, 63);
						}
						break;
					case 27:
						if (CheckMech(num53, num52, 30) && NPC.MechSpawn(num55, num56, 85))
						{
							num57 = NPC.NewNPC(num55 - 9, num56, 85);
						}
						break;
					case 28:
						if (CheckMech(num53, num52, 30) && NPC.MechSpawn(num55, num56, 74))
						{
							num57 = NPC.NewNPC(num55, num56 - 12, Utils.SelectRandom(Main.rand, new short[3] { 74, 297, 298 }));
						}
						break;
					case 34:
					{
						for (int num62 = 0; num62 < 2; num62++)
						{
							for (int num63 = 0; num63 < 3; num63++)
							{
								Tile tile2 = Main.tile[num53 + num62, num52 + num63];
								tile2.type = 349;
								tile2.frameX = (short)(num62 * 18 + 216);
								tile2.frameY = (short)(num63 * 18);
							}
						}
						Animation.NewTemporaryAnimation(0, 349, num53, num52);
						if (Main.netMode == 2)
						{
							NetMessage.SendTileRange(-1, num53, num52, 2, 3);
						}
						break;
					}
					case 42:
						if (CheckMech(num53, num52, 30) && NPC.MechSpawn(num55, num56, 58))
						{
							num57 = NPC.NewNPC(num55, num56 - 12, 58);
						}
						break;
					case 37:
						if (CheckMech(num53, num52, 600) && Item.MechSpawn(num55, num56, 58) && Item.MechSpawn(num55, num56, 1734) && Item.MechSpawn(num55, num56, 1867))
						{
							Item.NewItem(num55, num56 - 16, 0, 0, 58);
						}
						break;
					case 50:
						if (CheckMech(num53, num52, 30) && NPC.MechSpawn(num55, num56, 65))
						{
							if (!Collision.SolidTiles(num53 - 2, num53 + 3, num52, num52 + 2))
							{
								num57 = NPC.NewNPC(num55, num56 - 12, 65);
								break;
							}
							Vector2 position2 = new Vector2(num55 - 4, num56 - 22) - new Vector2(10f);
							Utils.PoofOfSmoke(position2);
							NetMessage.SendData(106, -1, -1, null, (int)position2.X, position2.Y);
						}
						break;
					case 2:
						if (CheckMech(num53, num52, 600) && Item.MechSpawn(num55, num56, 184) && Item.MechSpawn(num55, num56, 1735) && Item.MechSpawn(num55, num56, 1868))
						{
							Item.NewItem(num55, num56 - 16, 0, 0, 184);
						}
						break;
					case 17:
						if (CheckMech(num53, num52, 600) && Item.MechSpawn(num55, num56, 166))
						{
							Item.NewItem(num55, num56 - 20, 0, 0, 166);
						}
						break;
					case 40:
					{
						if (!CheckMech(num53, num52, 300))
						{
							break;
						}
						int[] array2 = new int[10];
						int num64 = 0;
						for (int num65 = 0; num65 < 200; num65++)
						{
							if (Main.npc[num65].active && (Main.npc[num65].type == 17 || Main.npc[num65].type == 19 || Main.npc[num65].type == 22 || Main.npc[num65].type == 38 || Main.npc[num65].type == 54 || Main.npc[num65].type == 107 || Main.npc[num65].type == 108 || Main.npc[num65].type == 142 || Main.npc[num65].type == 160 || Main.npc[num65].type == 207 || Main.npc[num65].type == 209 || Main.npc[num65].type == 227 || Main.npc[num65].type == 228 || Main.npc[num65].type == 229 || Main.npc[num65].type == 358 || Main.npc[num65].type == 369 || Main.npc[num65].type == 550))
							{
								array2[num64] = num65;
								num64++;
								if (num64 >= 9)
								{
									break;
								}
							}
						}
						if (num64 > 0)
						{
							int num66 = array2[Main.rand.Next(num64)];
							Main.npc[num66].position.X = num55 - Main.npc[num66].width / 2;
							Main.npc[num66].position.Y = num56 - Main.npc[num66].height - 1;
							NetMessage.SendData(23, -1, -1, null, num66);
						}
						break;
					}
					case 41:
					{
						if (!CheckMech(num53, num52, 300))
						{
							break;
						}
						int[] array = new int[10];
						int num59 = 0;
						for (int num60 = 0; num60 < 200; num60++)
						{
							if (Main.npc[num60].active && (Main.npc[num60].type == 18 || Main.npc[num60].type == 20 || Main.npc[num60].type == 124 || Main.npc[num60].type == 178 || Main.npc[num60].type == 208 || Main.npc[num60].type == 353))
							{
								array[num59] = num60;
								num59++;
								if (num59 >= 9)
								{
									break;
								}
							}
						}
						if (num59 > 0)
						{
							int num61 = array[Main.rand.Next(num59)];
							Main.npc[num61].position.X = num55 - Main.npc[num61].width / 2;
							Main.npc[num61].position.Y = num56 - Main.npc[num61].height - 1;
							NetMessage.SendData(23, -1, -1, null, num61);
						}
						break;
					}
					}
				}
				if (num57 >= 0)
				{
					Main.npc[num57].value = 0f;
					Main.npc[num57].npcSlots = 0f;
					Main.npc[num57].SpawnedFromStatue = true;
				}
				break;
			}
			case 349:
			{
				int num = j - tile.frameY / 18;
				int num2;
				for (num2 = tile.frameX / 18; num2 >= 2; num2 -= 2)
				{
				}
				num2 = i - num2;
				SkipWire(num2, num);
				SkipWire(num2, num + 1);
				SkipWire(num2, num + 2);
				SkipWire(num2 + 1, num);
				SkipWire(num2 + 1, num + 1);
				SkipWire(num2 + 1, num + 2);
				short num3 = (short)((Main.tile[num2, num].frameX != 0) ? (-216) : 216);
				for (int k = 0; k < 2; k++)
				{
					for (int l = 0; l < 3; l++)
					{
						Main.tile[num2 + k, num + l].frameX += num3;
					}
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendTileRange(-1, num2, num, 2, 3);
				}
				Animation.NewTemporaryAnimation((num3 <= 0) ? 1 : 0, 349, num2, num);
				break;
			}
			}
		}

		private static void Teleport()
		{
			if (_teleport[0].X < _teleport[1].X + 3f && _teleport[0].X > _teleport[1].X - 3f && _teleport[0].Y > _teleport[1].Y - 3f && _teleport[0].Y < _teleport[1].Y)
			{
				return;
			}
			Rectangle[] array = new Rectangle[2];
			array[0].X = (int)(_teleport[0].X * 16f);
			array[0].Width = 48;
			array[0].Height = 48;
			array[0].Y = (int)(_teleport[0].Y * 16f - (float)array[0].Height);
			array[1].X = (int)(_teleport[1].X * 16f);
			array[1].Width = 48;
			array[1].Height = 48;
			array[1].Y = (int)(_teleport[1].Y * 16f - (float)array[1].Height);
			for (int i = 0; i < 2; i++)
			{
				Vector2 vector = new Vector2(array[1].X - array[0].X, array[1].Y - array[0].Y);
				if (i == 1)
				{
					vector = new Vector2(array[0].X - array[1].X, array[0].Y - array[1].Y);
				}
				if (!blockPlayerTeleportationForOneIteration)
				{
					for (int j = 0; j < 255; j++)
					{
						if (Main.player[j].active && !Main.player[j].dead && !Main.player[j].teleporting && array[i].Intersects(Main.player[j].getRect()))
						{
							Vector2 vector2 = Main.player[j].position + vector;
							Main.player[j].teleporting = true;
							if (Main.netMode == 2)
							{
								RemoteClient.CheckSection(j, vector2);
							}
							Main.player[j].Teleport(vector2);
							if (Main.netMode == 2)
							{
								NetMessage.SendData(65, -1, -1, null, 0, j, vector2.X, vector2.Y);
							}
						}
					}
				}
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && !Main.npc[k].teleporting && Main.npc[k].lifeMax > 5 && !Main.npc[k].boss && !Main.npc[k].noTileCollide)
					{
						int type = Main.npc[k].type;
						if (!NPCID.Sets.TeleportationImmune[type] && array[i].Intersects(Main.npc[k].getRect()))
						{
							Main.npc[k].teleporting = true;
							Main.npc[k].Teleport(Main.npc[k].position + vector);
						}
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

		private static void DeActive(int i, int j)
		{
			if (!Main.tile[i, j].active())
			{
				return;
			}
			bool flag = Main.tileSolid[Main.tile[i, j].type] && !TileID.Sets.NotReallySolid[Main.tile[i, j].type];
			ushort type = Main.tile[i, j].type;
			if (type == 314 || (uint)(type - 386) <= 3u)
			{
				flag = false;
			}
			if (flag && (!Main.tile[i, j - 1].active() || (Main.tile[i, j - 1].type != 5 && !TileID.Sets.BasicChest[Main.tile[i, j - 1].type] && Main.tile[i, j - 1].type != 26 && Main.tile[i, j - 1].type != 77 && Main.tile[i, j - 1].type != 72 && Main.tile[i, j - 1].type != 88)))
			{
				Main.tile[i, j].inActive(inActive: true);
				WorldGen.SquareTileFrame(i, j, resetFrame: false);
				if (Main.netMode != 1)
				{
					NetMessage.SendTileSquare(-1, i, j, 1);
				}
			}
		}

		private static void ReActive(int i, int j)
		{
			Main.tile[i, j].inActive(inActive: false);
			WorldGen.SquareTileFrame(i, j, resetFrame: false);
			if (Main.netMode != 1)
			{
				NetMessage.SendTileSquare(-1, i, j, 1);
			}
		}

		private static void MassWireOperationInner(Point ps, Point pe, Vector2 dropPoint, bool dir, ref int wireCount, ref int actuatorCount)
		{
			Math.Abs(ps.X - pe.X);
			Math.Abs(ps.Y - pe.Y);
			int num = Math.Sign(pe.X - ps.X);
			int num2 = Math.Sign(pe.Y - ps.Y);
			WiresUI.Settings.MultiToolMode toolMode = WiresUI.Settings.ToolMode;
			Point pt = default(Point);
			bool flag = false;
			Item.StartCachingType(530);
			Item.StartCachingType(849);
			bool flag2 = dir;
			int num3;
			int num4;
			int num5;
			if (flag2)
			{
				pt.X = ps.X;
				num3 = ps.Y;
				num4 = pe.Y;
				num5 = num2;
			}
			else
			{
				pt.Y = ps.Y;
				num3 = ps.X;
				num4 = pe.X;
				num5 = num;
			}
			for (int i = num3; i != num4; i += num5)
			{
				if (flag)
				{
					break;
				}
				if (flag2)
				{
					pt.Y = i;
				}
				else
				{
					pt.X = i;
				}
				bool? flag3 = MassWireOperationStep(pt, toolMode, ref wireCount, ref actuatorCount);
				if (flag3.HasValue && !flag3.Value)
				{
					flag = true;
					break;
				}
			}
			if (flag2)
			{
				pt.Y = pe.Y;
				num3 = ps.X;
				num4 = pe.X;
				num5 = num;
			}
			else
			{
				pt.X = pe.X;
				num3 = ps.Y;
				num4 = pe.Y;
				num5 = num2;
			}
			for (int j = num3; j != num4; j += num5)
			{
				if (flag)
				{
					break;
				}
				if (!flag2)
				{
					pt.Y = j;
				}
				else
				{
					pt.X = j;
				}
				bool? flag4 = MassWireOperationStep(pt, toolMode, ref wireCount, ref actuatorCount);
				if (flag4.HasValue && !flag4.Value)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				MassWireOperationStep(pe, toolMode, ref wireCount, ref actuatorCount);
			}
			Item.DropCache(dropPoint, Vector2.Zero, 530);
			Item.DropCache(dropPoint, Vector2.Zero, 849);
		}

		private static bool? MassWireOperationStep(Point pt, WiresUI.Settings.MultiToolMode mode, ref int wiresLeftToConsume, ref int actuatorsLeftToConstume)
		{
			if (!WorldGen.InWorld(pt.X, pt.Y, 1))
			{
				return null;
			}
			Tile tile = Main.tile[pt.X, pt.Y];
			if (tile == null)
			{
				return null;
			}
			if (!mode.HasFlag(WiresUI.Settings.MultiToolMode.Cutter))
			{
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Red) && !tile.wire())
				{
					if (wiresLeftToConsume <= 0)
					{
						return false;
					}
					wiresLeftToConsume--;
					WorldGen.PlaceWire(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 5, pt.X, pt.Y);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Green) && !tile.wire3())
				{
					if (wiresLeftToConsume <= 0)
					{
						return false;
					}
					wiresLeftToConsume--;
					WorldGen.PlaceWire3(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 12, pt.X, pt.Y);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Blue) && !tile.wire2())
				{
					if (wiresLeftToConsume <= 0)
					{
						return false;
					}
					wiresLeftToConsume--;
					WorldGen.PlaceWire2(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 10, pt.X, pt.Y);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Yellow) && !tile.wire4())
				{
					if (wiresLeftToConsume <= 0)
					{
						return false;
					}
					wiresLeftToConsume--;
					WorldGen.PlaceWire4(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 16, pt.X, pt.Y);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Actuator) && !tile.actuator())
				{
					if (actuatorsLeftToConstume <= 0)
					{
						return false;
					}
					actuatorsLeftToConstume--;
					WorldGen.PlaceActuator(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 8, pt.X, pt.Y);
				}
			}
			if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Cutter))
			{
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Red) && tile.wire() && WorldGen.KillWire(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 6, pt.X, pt.Y);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Green) && tile.wire3() && WorldGen.KillWire3(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 13, pt.X, pt.Y);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Blue) && tile.wire2() && WorldGen.KillWire2(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 11, pt.X, pt.Y);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Yellow) && tile.wire4() && WorldGen.KillWire4(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 17, pt.X, pt.Y);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Actuator) && tile.actuator() && WorldGen.KillActuator(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 9, pt.X, pt.Y);
				}
			}
			return true;
		}
	}
}
