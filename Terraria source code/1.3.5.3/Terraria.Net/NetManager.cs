using System;
using System.Collections.Generic;
using System.IO;
using Terraria.Localization;
using Terraria.Net.Sockets;

namespace Terraria.Net
{
	public class NetManager
	{
		private class PacketTypeStorage<T> where T : NetModule
		{
			public static ushort Id;

			public static T Module;
		}

		public static readonly NetManager Instance = new NetManager();

		private Dictionary<ushort, NetModule> _modules = new Dictionary<ushort, NetModule>();

		private ushort _moduleCount;

		private NetManager()
		{
		}

		public void Register<T>() where T : NetModule, new()
		{
			T val = new T();
			PacketTypeStorage<T>.Id = _moduleCount;
			PacketTypeStorage<T>.Module = val;
			_modules[_moduleCount] = val;
			_moduleCount++;
		}

		public NetModule GetModule<T>() where T : NetModule
		{
			return PacketTypeStorage<T>.Module;
		}

		public ushort GetId<T>() where T : NetModule
		{
			return PacketTypeStorage<T>.Id;
		}

		public void Read(BinaryReader reader, int userId)
		{
			ushort key = reader.ReadUInt16();
			if (_modules.ContainsKey(key))
			{
				_modules[key].Deserialize(reader, userId);
			}
		}

		public void Broadcast(NetPacket packet, int ignoreClient = -1)
		{
			for (int i = 0; i < 256; i++)
			{
				if (i != ignoreClient && Netplay.Clients[i].IsConnected())
				{
					SendData(Netplay.Clients[i].Socket, packet);
				}
			}
		}

		public void SendToServer(NetPacket packet)
		{
			SendData(Netplay.Connection.Socket, packet);
		}

		public void SendToClient(NetPacket packet, int playerId)
		{
			SendData(Netplay.Clients[playerId].Socket, packet);
		}

		private void SendData(ISocket socket, NetPacket packet)
		{
			if (Main.netMode == 0)
			{
				return;
			}
			packet.ShrinkToFit();
			try
			{
				socket.AsyncSend(packet.Buffer.Data, 0, packet.Length, SendCallback, packet);
			}
			catch
			{
				Console.WriteLine(Language.GetTextValue("Error.ExceptionNormal", Language.GetTextValue("Error.DataSentAfterConnectionLost")));
			}
		}

		public static void SendCallback(object state)
		{
			((NetPacket)state).Recycle();
		}
	}
}
