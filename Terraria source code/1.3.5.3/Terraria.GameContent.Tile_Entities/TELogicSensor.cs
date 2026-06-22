using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Terraria.GameContent.Tile_Entities
{
	public class TELogicSensor : TileEntity
	{
		public enum LogicCheckType
		{
			None,
			Day,
			Night,
			PlayerAbove,
			Water,
			Lava,
			Honey,
			Liquid
		}

		private static Dictionary<int, Rectangle> playerBox = new Dictionary<int, Rectangle>();

		private static List<Tuple<Point16, bool>> tripPoints = new List<Tuple<Point16, bool>>();

		private static List<int> markedIDsForRemoval = new List<int>();

		private static bool inUpdateLoop = false;

		private static bool playerBoxFilled = false;

		public LogicCheckType logicCheck;

		public bool On;

		public int CountedData;

		public static void Initialize()
		{
			TileEntity._UpdateStart += UpdateStartInternal;
			TileEntity._UpdateEnd += UpdateEndInternal;
			TileEntity._NetPlaceEntity += NetPlaceEntity;
		}

		public static void NetPlaceEntity(int x, int y, int type)
		{
			if (type == 2 && ValidTile(x, y))
			{
				int num = Place(x, y);
				((TELogicSensor)TileEntity.ByID[num]).FigureCheckState();
				NetMessage.SendData(86, -1, -1, null, num, x, y);
			}
		}

		private static void UpdateStartInternal()
		{
			inUpdateLoop = true;
			markedIDsForRemoval.Clear();
			playerBox.Clear();
			playerBoxFilled = false;
			FillPlayerHitboxes();
		}

		private static void FillPlayerHitboxes()
		{
			if (playerBoxFilled)
			{
				return;
			}
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					playerBox[i] = Main.player[i].getRect();
				}
			}
			playerBoxFilled = true;
		}

		private static void UpdateEndInternal()
		{
			inUpdateLoop = false;
			foreach (Tuple<Point16, bool> tripPoint in tripPoints)
			{
				Wiring.blockPlayerTeleportationForOneIteration = tripPoint.Item2;
				Wiring.HitSwitch(tripPoint.Item1.X, tripPoint.Item1.Y);
			}
			Wiring.blockPlayerTeleportationForOneIteration = false;
			tripPoints.Clear();
			foreach (int item in markedIDsForRemoval)
			{
				if (TileEntity.ByID.TryGetValue(item, out var value) && value.type == 2)
				{
					TileEntity.ByID.Remove(item);
				}
				TileEntity.ByPosition.Remove(value.Position);
			}
			markedIDsForRemoval.Clear();
		}

		public override void Update()
		{
			bool state = GetState(Position.X, Position.Y, logicCheck, this);
			switch (logicCheck)
			{
			case LogicCheckType.Day:
			case LogicCheckType.Night:
				if (!On && state)
				{
					ChangeState(onState: true, TripWire: true);
				}
				if (On && !state)
				{
					ChangeState(onState: false, TripWire: false);
				}
				break;
			case LogicCheckType.PlayerAbove:
			case LogicCheckType.Water:
			case LogicCheckType.Lava:
			case LogicCheckType.Honey:
			case LogicCheckType.Liquid:
				if (On != state)
				{
					ChangeState(state, TripWire: true);
				}
				break;
			}
		}

		public void ChangeState(bool onState, bool TripWire)
		{
			if (onState == On || SanityCheck(Position.X, Position.Y))
			{
				Main.tile[Position.X, Position.Y].frameX = (short)(onState ? 18 : 0);
				On = onState;
				if (Main.netMode == 2)
				{
					NetMessage.SendTileSquare(-1, Position.X, Position.Y, 1);
				}
				if (TripWire && Main.netMode != 1)
				{
					tripPoints.Add(Tuple.Create(Position, logicCheck == LogicCheckType.PlayerAbove));
				}
			}
		}

		public static bool ValidTile(int x, int y)
		{
			if (!Main.tile[x, y].active() || Main.tile[x, y].type != 423 || Main.tile[x, y].frameY % 18 != 0 || Main.tile[x, y].frameX % 18 != 0)
			{
				return false;
			}
			return true;
		}

		public TELogicSensor()
		{
			logicCheck = LogicCheckType.None;
			On = false;
		}

		public static LogicCheckType FigureCheckType(int x, int y, out bool on)
		{
			on = false;
			if (!WorldGen.InWorld(x, y))
			{
				return LogicCheckType.None;
			}
			Tile tile = Main.tile[x, y];
			if (tile == null)
			{
				return LogicCheckType.None;
			}
			LogicCheckType result = LogicCheckType.None;
			switch (tile.frameY / 18)
			{
			case 0:
				result = LogicCheckType.Day;
				break;
			case 1:
				result = LogicCheckType.Night;
				break;
			case 2:
				result = LogicCheckType.PlayerAbove;
				break;
			case 3:
				result = LogicCheckType.Water;
				break;
			case 4:
				result = LogicCheckType.Lava;
				break;
			case 5:
				result = LogicCheckType.Honey;
				break;
			case 6:
				result = LogicCheckType.Liquid;
				break;
			}
			on = GetState(x, y, result);
			return result;
		}

		public static bool GetState(int x, int y, LogicCheckType type, TELogicSensor instance = null)
		{
			switch (type)
			{
			case LogicCheckType.Day:
				return Main.dayTime;
			case LogicCheckType.Night:
				return !Main.dayTime;
			case LogicCheckType.PlayerAbove:
			{
				bool result = false;
				Rectangle value = new Rectangle(x * 16 - 32 - 1, y * 16 - 160 - 1, 82, 162);
				foreach (KeyValuePair<int, Rectangle> item in playerBox)
				{
					if (item.Value.Intersects(value))
					{
						result = true;
						break;
					}
				}
				return result;
			}
			case LogicCheckType.Water:
			case LogicCheckType.Lava:
			case LogicCheckType.Honey:
			case LogicCheckType.Liquid:
			{
				if (instance == null)
				{
					return false;
				}
				Tile tile = Main.tile[x, y];
				bool flag = true;
				if (tile == null || tile.liquid == 0)
				{
					flag = false;
				}
				if (!tile.lava() && type == LogicCheckType.Lava)
				{
					flag = false;
				}
				if (!tile.honey() && type == LogicCheckType.Honey)
				{
					flag = false;
				}
				if ((tile.honey() || tile.lava()) && type == LogicCheckType.Water)
				{
					flag = false;
				}
				if (!flag && instance.On)
				{
					if (instance.CountedData == 0)
					{
						instance.CountedData = 15;
					}
					else if (instance.CountedData > 0)
					{
						instance.CountedData--;
					}
					flag = instance.CountedData > 0;
				}
				return flag;
			}
			default:
				return false;
			}
		}

		public void FigureCheckState()
		{
			logicCheck = FigureCheckType(Position.X, Position.Y, out On);
			GetFrame(Position.X, Position.Y, logicCheck, On);
		}

		public static void GetFrame(int x, int y, LogicCheckType type, bool on)
		{
			Main.tile[x, y].frameX = (short)(on ? 18 : 0);
			switch (type)
			{
			case LogicCheckType.Day:
				Main.tile[x, y].frameY = 0;
				break;
			case LogicCheckType.Night:
				Main.tile[x, y].frameY = 18;
				break;
			case LogicCheckType.PlayerAbove:
				Main.tile[x, y].frameY = 36;
				break;
			case LogicCheckType.Water:
				Main.tile[x, y].frameY = 54;
				break;
			case LogicCheckType.Lava:
				Main.tile[x, y].frameY = 72;
				break;
			case LogicCheckType.Honey:
				Main.tile[x, y].frameY = 90;
				break;
			case LogicCheckType.Liquid:
				Main.tile[x, y].frameY = 108;
				break;
			default:
				Main.tile[x, y].frameY = 0;
				break;
			}
		}

		public static bool SanityCheck(int x, int y)
		{
			if (!Main.tile[x, y].active() || Main.tile[x, y].type != 423)
			{
				Kill(x, y);
				return false;
			}
			return true;
		}

		public static int Place(int x, int y)
		{
			TELogicSensor tELogicSensor = new TELogicSensor();
			tELogicSensor.Position = new Point16(x, y);
			tELogicSensor.ID = TileEntity.AssignNewID();
			tELogicSensor.type = 2;
			TileEntity.ByID[tELogicSensor.ID] = tELogicSensor;
			TileEntity.ByPosition[tELogicSensor.Position] = tELogicSensor;
			return tELogicSensor.ID;
		}

		public static int Hook_AfterPlacement(int x, int y, int type = 423, int style = 0, int direction = 1)
		{
			bool on;
			LogicCheckType logicCheckType = FigureCheckType(x, y, out on);
			GetFrame(x, y, logicCheckType, on);
			if (Main.netMode == 1)
			{
				NetMessage.SendTileSquare(Main.myPlayer, x, y, 1);
				NetMessage.SendData(87, -1, -1, null, x, y, 2f);
				return -1;
			}
			int num = Place(x, y);
			((TELogicSensor)TileEntity.ByID[num]).FigureCheckState();
			return num;
		}

		public static void Kill(int x, int y)
		{
			if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out var value) && value.type == 2)
			{
				Wiring.blockPlayerTeleportationForOneIteration = ((TELogicSensor)value).logicCheck == LogicCheckType.PlayerAbove;
				if (((TELogicSensor)value).logicCheck == LogicCheckType.PlayerAbove && ((TELogicSensor)value).On)
				{
					Wiring.HitSwitch(value.Position.X, value.Position.Y);
				}
				if (((TELogicSensor)value).logicCheck == LogicCheckType.Water && ((TELogicSensor)value).On)
				{
					Wiring.HitSwitch(value.Position.X, value.Position.Y);
				}
				if (((TELogicSensor)value).logicCheck == LogicCheckType.Lava && ((TELogicSensor)value).On)
				{
					Wiring.HitSwitch(value.Position.X, value.Position.Y);
				}
				if (((TELogicSensor)value).logicCheck == LogicCheckType.Honey && ((TELogicSensor)value).On)
				{
					Wiring.HitSwitch(value.Position.X, value.Position.Y);
				}
				if (((TELogicSensor)value).logicCheck == LogicCheckType.Liquid && ((TELogicSensor)value).On)
				{
					Wiring.HitSwitch(value.Position.X, value.Position.Y);
				}
				Wiring.blockPlayerTeleportationForOneIteration = false;
				if (inUpdateLoop)
				{
					markedIDsForRemoval.Add(value.ID);
					return;
				}
				TileEntity.ByPosition.Remove(new Point16(x, y));
				TileEntity.ByID.Remove(value.ID);
			}
		}

		public static int Find(int x, int y)
		{
			if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out var value) && value.type == 2)
			{
				return value.ID;
			}
			return -1;
		}

		public override void WriteExtraData(BinaryWriter writer, bool networkSend)
		{
			if (!networkSend)
			{
				writer.Write((byte)logicCheck);
				writer.Write(On);
			}
		}

		public override void ReadExtraData(BinaryReader reader, bool networkSend)
		{
			if (!networkSend)
			{
				logicCheck = (LogicCheckType)reader.ReadByte();
				On = reader.ReadBoolean();
			}
		}

		public override string ToString()
		{
			return Position.X + "x  " + Position.Y + "y " + logicCheck;
		}
	}
}
