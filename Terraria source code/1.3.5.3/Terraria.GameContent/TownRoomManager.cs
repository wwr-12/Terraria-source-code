using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;

namespace Terraria.GameContent
{
	public class TownRoomManager
	{
		private List<Tuple<int, Point>> _roomLocationPairs = new List<Tuple<int, Point>>();

		private bool[] _hasRoom = new bool[580];

		public int FindOccupation(int x, int y)
		{
			return FindOccupation(new Point(x, y));
		}

		public int FindOccupation(Point tilePosition)
		{
			foreach (Tuple<int, Point> roomLocationPair in _roomLocationPairs)
			{
				if (roomLocationPair.Item2 == tilePosition)
				{
					return roomLocationPair.Item1;
				}
			}
			return -1;
		}

		public bool HasRoomQuick(int npcID)
		{
			return _hasRoom[npcID];
		}

		public bool HasRoom(int npcID, out Point roomPosition)
		{
			if (!_hasRoom[npcID])
			{
				roomPosition = new Point(0, 0);
				return false;
			}
			foreach (Tuple<int, Point> roomLocationPair in _roomLocationPairs)
			{
				if (roomLocationPair.Item1 == npcID)
				{
					roomPosition = roomLocationPair.Item2;
					return true;
				}
			}
			roomPosition = new Point(0, 0);
			return false;
		}

		public void SetRoom(int npcID, int x, int y)
		{
			_hasRoom[npcID] = true;
			SetRoom(npcID, new Point(x, y));
		}

		public void SetRoom(int npcID, Point pt)
		{
			_roomLocationPairs.RemoveAll((Tuple<int, Point> x) => x.Item1 == npcID);
			_roomLocationPairs.Add(Tuple.Create(npcID, pt));
		}

		public void KickOut(NPC n)
		{
			KickOut(n.type);
			_hasRoom[n.type] = false;
		}

		public void KickOut(int npcType)
		{
			_roomLocationPairs.RemoveAll((Tuple<int, Point> x) => x.Item1 == npcType);
		}

		public void DisplayRooms()
		{
			foreach (Tuple<int, Point> roomLocationPair in _roomLocationPairs)
			{
				Dust.QuickDust(roomLocationPair.Item2, Main.hslToRgb((float)roomLocationPair.Item1 * 0.05f % 1f, 1f, 0.5f));
			}
		}

		public void Save(BinaryWriter writer)
		{
			writer.Write(_roomLocationPairs.Count);
			foreach (Tuple<int, Point> roomLocationPair in _roomLocationPairs)
			{
				writer.Write(roomLocationPair.Item1);
				writer.Write(roomLocationPair.Item2.X);
				writer.Write(roomLocationPair.Item2.Y);
			}
		}

		public void Load(BinaryReader reader)
		{
			Clear();
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				int num2 = reader.ReadInt32();
				Point item = new Point(reader.ReadInt32(), reader.ReadInt32());
				_roomLocationPairs.Add(Tuple.Create(num2, item));
				_hasRoom[num2] = true;
			}
		}

		public void Clear()
		{
			_roomLocationPairs.Clear();
			for (int i = 0; i < _hasRoom.Length; i++)
			{
				_hasRoom[i] = false;
			}
		}

		public byte GetHouseholdStatus(NPC n)
		{
			byte result = 0;
			if (n.homeless)
			{
				result = 1;
			}
			else if (HasRoomQuick(n.type))
			{
				result = 2;
			}
			return result;
		}
	}
}
