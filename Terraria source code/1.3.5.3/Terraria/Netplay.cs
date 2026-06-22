using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Net;
using Terraria.Net.Sockets;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria
{
	public class Netplay
	{
		public const int MaxConnections = 256;

		public const int NetBufferSize = 1024;

		public static string BanFilePath = "banlist.txt";

		public static string ServerPassword = "";

		public static RemoteClient[] Clients = new RemoteClient[256];

		public static RemoteServer Connection = new RemoteServer();

		public static IPAddress ServerIP;

		public static string ServerIPText = "";

		public static ISocket TcpListener;

		public static int ListenPort = 7777;

		public static bool IsServerRunning = false;

		public static bool IsListening = true;

		public static bool UseUPNP = true;

		public static bool disconnect = false;

		public static bool spamCheck = false;

		public static bool anyClients = false;

		private static Thread ServerThread;

		public static string portForwardIP;

		public static int portForwardPort;

		public static bool portForwardOpen;

		public static event Action OnDisconnect;

		private static void OpenPort()
		{
			portForwardIP = GetLocalIPAddress();
			portForwardPort = ListenPort;
		}

		public static void closePort()
		{
		}

		public static string GetLocalIPAddress()
		{
			string result = "";
			IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
			foreach (IPAddress iPAddress in addressList)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					result = iPAddress.ToString();
					break;
				}
			}
			return result;
		}

		public static void ResetNetDiag()
		{
			Main.rxMsg = 0;
			Main.rxData = 0;
			Main.txMsg = 0;
			Main.txData = 0;
			for (int i = 0; i < Main.maxMsg; i++)
			{
				Main.rxMsgType[i] = 0;
				Main.rxDataType[i] = 0;
				Main.txMsgType[i] = 0;
				Main.txDataType[i] = 0;
			}
		}

		public static void ResetSections()
		{
			for (int i = 0; i < 256; i++)
			{
				for (int j = 0; j < Main.maxSectionsX; j++)
				{
					for (int k = 0; k < Main.maxSectionsY; k++)
					{
						Clients[i].TileSections[j, k] = false;
					}
				}
			}
		}

		public static void AddBan(int plr)
		{
			RemoteAddress remoteAddress = Clients[plr].Socket.GetRemoteAddress();
			using (StreamWriter streamWriter = new StreamWriter(BanFilePath, append: true))
			{
				streamWriter.WriteLine("//" + Main.player[plr].name);
				streamWriter.WriteLine(remoteAddress.GetIdentifier());
			}
		}

		public static bool IsBanned(RemoteAddress address)
		{
			try
			{
				string identifier = address.GetIdentifier();
				if (File.Exists(BanFilePath))
				{
					using (StreamReader streamReader = new StreamReader(BanFilePath))
					{
						string text;
						while ((text = streamReader.ReadLine()) != null)
						{
							if (text == identifier)
							{
								return true;
							}
						}
					}
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		public static void newRecent()
		{
			if (Connection.Socket.GetRemoteAddress().Type != AddressType.Tcp)
			{
				return;
			}
			for (int i = 0; i < Main.maxMP; i++)
			{
				if (Main.recentIP[i].ToLower() == ServerIPText.ToLower() && Main.recentPort[i] == ListenPort)
				{
					for (int j = i; j < Main.maxMP - 1; j++)
					{
						Main.recentIP[j] = Main.recentIP[j + 1];
						Main.recentPort[j] = Main.recentPort[j + 1];
						Main.recentWorld[j] = Main.recentWorld[j + 1];
					}
				}
			}
			for (int num = Main.maxMP - 1; num > 0; num--)
			{
				Main.recentIP[num] = Main.recentIP[num - 1];
				Main.recentPort[num] = Main.recentPort[num - 1];
				Main.recentWorld[num] = Main.recentWorld[num - 1];
			}
			Main.recentIP[0] = ServerIPText;
			Main.recentPort[0] = ListenPort;
			Main.recentWorld[0] = Main.worldName;
			Main.SaveRecent();
		}

		public static void SocialClientLoop(object threadContext)
		{
			ISocket socket = (ISocket)threadContext;
			ClientLoopSetup(socket.GetRemoteAddress());
			Connection.Socket = socket;
			InnerClientLoop();
		}

		public static void TcpClientLoop(object threadContext)
		{
			ClientLoopSetup(new TcpAddress(ServerIP, ListenPort));
			Main.menuMode = 14;
			bool flag = true;
			while (flag)
			{
				flag = false;
				try
				{
					Connection.Socket.Connect(new TcpAddress(ServerIP, ListenPort));
					flag = false;
				}
				catch
				{
					if (!disconnect && Main.gameMenu)
					{
						flag = true;
					}
				}
			}
			InnerClientLoop();
		}

		private static void ClientLoopSetup(RemoteAddress address)
		{
			ResetNetDiag();
			Main.ServerSideCharacter = false;
			if (Main.rand == null)
			{
				Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
			}
			Main.player[Main.myPlayer].hostile = false;
			Main.clientPlayer = (Player)Main.player[Main.myPlayer].clientClone();
			for (int i = 0; i < 255; i++)
			{
				if (i != Main.myPlayer)
				{
					Main.player[i] = new Player();
				}
			}
			Main.netMode = 1;
			Main.menuMode = 14;
			if (!Main.autoPass)
			{
				Main.statusText = Language.GetTextValue("Net.ConnectingTo", address.GetFriendlyName());
			}
			disconnect = false;
			Connection = new RemoteServer();
			Connection.ReadBuffer = new byte[1024];
		}

		private static void InnerClientLoop()
		{
			try
			{
				NetMessage.buffer[256].Reset();
				int num = -1;
				while (!disconnect)
				{
					if (Connection.Socket.IsConnected())
					{
						if (NetMessage.buffer[256].checkBytes)
						{
							NetMessage.CheckBytes();
						}
						Connection.IsActive = true;
						if (Connection.State == 0)
						{
							Main.statusText = Language.GetTextValue("Net.FoundServer");
							Connection.State = 1;
							NetMessage.SendData(1);
						}
						if (Connection.State == 2 && num != Connection.State)
						{
							Main.statusText = Language.GetTextValue("Net.SendingPlayerData");
						}
						if (Connection.State == 3 && num != Connection.State)
						{
							Main.statusText = Language.GetTextValue("Net.RequestingWorldInformation");
						}
						if (Connection.State == 4)
						{
							WorldGen.worldCleared = false;
							Connection.State = 5;
							if (Main.cloudBGActive >= 1f)
							{
								Main.cloudBGAlpha = 1f;
							}
							else
							{
								Main.cloudBGAlpha = 0f;
							}
							Main.windSpeed = Main.windSpeedSet;
							Cloud.resetClouds();
							Main.cloudAlpha = Main.maxRaining;
							WorldGen.clearWorld();
							if (Main.mapEnabled)
							{
								Main.Map.Load();
							}
						}
						if (Connection.State == 5 && Main.loadMapLock)
						{
							float num2 = (float)Main.loadMapLastX / (float)Main.maxTilesX;
							Main.statusText = Lang.gen[68].Value + " " + (int)(num2 * 100f + 1f) + "%";
						}
						else if (Connection.State == 5 && WorldGen.worldCleared)
						{
							Connection.State = 6;
							Main.player[Main.myPlayer].FindSpawn();
							NetMessage.SendData(8, -1, -1, null, Main.player[Main.myPlayer].SpawnX, Main.player[Main.myPlayer].SpawnY);
						}
						if (Connection.State == 6 && num != Connection.State)
						{
							Main.statusText = Language.GetTextValue("Net.RequestingTileData");
						}
						if (!Connection.IsReading && !disconnect && Connection.Socket.IsDataAvailable())
						{
							Connection.IsReading = true;
							Connection.Socket.AsyncReceive(Connection.ReadBuffer, 0, Connection.ReadBuffer.Length, Connection.ClientReadCallBack);
						}
						if (Connection.StatusMax > 0 && Connection.StatusText != "")
						{
							if (Connection.StatusCount >= Connection.StatusMax)
							{
								Main.statusText = Language.GetTextValue("Net.StatusComplete", Connection.StatusText);
								Connection.StatusText = "";
								Connection.StatusMax = 0;
								Connection.StatusCount = 0;
							}
							else
							{
								Main.statusText = Connection.StatusText + ": " + (int)((float)Connection.StatusCount / (float)Connection.StatusMax * 100f) + "%";
							}
						}
						Thread.Sleep(1);
					}
					else if (Connection.IsActive)
					{
						Main.statusText = Language.GetTextValue("Net.LostConnection");
						disconnect = true;
					}
					num = Connection.State;
				}
				try
				{
					Connection.Socket.Close();
				}
				catch
				{
				}
				if (!Main.gameMenu)
				{
					Main.SwitchNetMode(0);
					Player.SavePlayer(Main.ActivePlayerFileData);
					Main.ActivePlayerFileData.StopPlayTimer();
					Main.gameMenu = true;
					Main.StopTrackedSounds();
					Main.menuMode = 14;
				}
				NetMessage.buffer[256].Reset();
				if (Main.menuMode == 15 && Main.statusText == Language.GetTextValue("Net.LostConnection"))
				{
					Main.menuMode = 14;
				}
				if (Connection.StatusText != "" && Connection.StatusText != null)
				{
					Main.statusText = Language.GetTextValue("Net.LostConnection");
				}
				Connection.StatusCount = 0;
				Connection.StatusMax = 0;
				Connection.StatusText = "";
				Main.SwitchNetMode(0);
			}
			catch (Exception value)
			{
				try
				{
					using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", append: true))
					{
						streamWriter.WriteLine(DateTime.Now);
						streamWriter.WriteLine(value);
						streamWriter.WriteLine("");
					}
				}
				catch
				{
				}
				disconnect = true;
			}
			if (Netplay.OnDisconnect != null)
			{
				Netplay.OnDisconnect();
			}
		}

		private static int FindNextOpenClientSlot()
		{
			for (int i = 0; i < Main.maxNetPlayers; i++)
			{
				if (!Clients[i].IsConnected())
				{
					return i;
				}
			}
			return -1;
		}

		private static void OnConnectionAccepted(ISocket client)
		{
			int num = FindNextOpenClientSlot();
			if (num != -1)
			{
				Clients[num].Reset();
				Clients[num].Socket = client;
				Console.WriteLine(Language.GetTextValue("Net.ClientConnecting", client.GetRemoteAddress()));
			}
			if (FindNextOpenClientSlot() == -1)
			{
				StopListening();
			}
		}

		public static void OnConnectedToSocialServer(ISocket client)
		{
			StartSocialClient(client);
		}

		private static bool StartListening()
		{
			if (SocialAPI.Network != null)
			{
				SocialAPI.Network.StartListening(OnConnectionAccepted);
			}
			return TcpListener.StartListening(OnConnectionAccepted);
		}

		private static void StopListening()
		{
			if (SocialAPI.Network != null)
			{
				SocialAPI.Network.StopListening();
			}
			TcpListener.StopListening();
		}

		public static void ServerLoop(object threadContext)
		{
			ResetNetDiag();
			if (Main.rand == null)
			{
				Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
			}
			Main.myPlayer = 255;
			ServerIP = IPAddress.Any;
			Main.menuMode = 14;
			Main.statusText = Lang.menu[8].Value;
			Main.netMode = 2;
			disconnect = false;
			for (int i = 0; i < 256; i++)
			{
				Clients[i] = new RemoteClient();
				Clients[i].Reset();
				Clients[i].Id = i;
				Clients[i].ReadBuffer = new byte[1024];
			}
			TcpListener = new TcpSocket();
			if (!disconnect)
			{
				if (!StartListening())
				{
					Main.menuMode = 15;
					Main.statusText = Language.GetTextValue("Error.TriedToRunServerTwice");
					disconnect = true;
				}
				Main.statusText = Language.GetTextValue("CLI.ServerStarted");
			}
			if (UseUPNP)
			{
				try
				{
					OpenPort();
				}
				catch
				{
				}
			}
			int num = 0;
			while (!disconnect)
			{
				if (!IsListening)
				{
					int num2 = -1;
					for (int j = 0; j < Main.maxNetPlayers; j++)
					{
						if (!Clients[j].IsConnected())
						{
							num2 = j;
							break;
						}
					}
					if (num2 >= 0)
					{
						if (Main.ignoreErrors)
						{
							try
							{
								StartListening();
								IsListening = true;
							}
							catch
							{
							}
						}
						else
						{
							StartListening();
							IsListening = true;
						}
					}
				}
				int num3 = 0;
				for (int k = 0; k < 256; k++)
				{
					if (NetMessage.buffer[k].checkBytes)
					{
						NetMessage.CheckBytes(k);
					}
					if (Clients[k].PendingTermination)
					{
						Clients[k].Reset();
						NetMessage.SyncDisconnectedPlayer(k);
						continue;
					}
					if (Clients[k].IsConnected())
					{
						if (!Clients[k].IsActive)
						{
							Clients[k].State = 0;
						}
						Clients[k].IsActive = true;
						num3++;
						if (!Clients[k].IsReading)
						{
							try
							{
								if (Clients[k].Socket.IsDataAvailable())
								{
									Clients[k].IsReading = true;
									Clients[k].Socket.AsyncReceive(Clients[k].ReadBuffer, 0, Clients[k].ReadBuffer.Length, Clients[k].ServerReadCallBack);
								}
							}
							catch
							{
								Clients[k].PendingTermination = true;
							}
						}
						if (Clients[k].StatusMax > 0 && Clients[k].StatusText2 != "")
						{
							if (Clients[k].StatusCount >= Clients[k].StatusMax)
							{
								Clients[k].StatusText = Language.GetTextValue("Net.ClientStatusComplete", Clients[k].Socket.GetRemoteAddress(), Clients[k].Name, Clients[k].StatusText2);
								Clients[k].StatusText2 = "";
								Clients[k].StatusMax = 0;
								Clients[k].StatusCount = 0;
								continue;
							}
							Clients[k].StatusText = string.Concat("(", Clients[k].Socket.GetRemoteAddress(), ") ", Clients[k].Name, " ", Clients[k].StatusText2, ": ", (int)((float)Clients[k].StatusCount / (float)Clients[k].StatusMax * 100f), "%");
						}
						else if (Clients[k].State == 0)
						{
							Clients[k].StatusText = Language.GetTextValue("Net.ClientConnecting", $"({Clients[k].Socket.GetRemoteAddress()}) {Clients[k].Name}");
						}
						else if (Clients[k].State == 1)
						{
							Clients[k].StatusText = Language.GetTextValue("Net.ClientSendingData", Clients[k].Socket.GetRemoteAddress(), Clients[k].Name);
						}
						else if (Clients[k].State == 2)
						{
							Clients[k].StatusText = Language.GetTextValue("Net.ClientRequestedWorldInfo", Clients[k].Socket.GetRemoteAddress(), Clients[k].Name);
						}
						else if (Clients[k].State != 3 && Clients[k].State == 10)
						{
							try
							{
								Clients[k].StatusText = Language.GetTextValue("Net.ClientPlaying", Clients[k].Socket.GetRemoteAddress(), Clients[k].Name);
							}
							catch (Exception)
							{
								Clients[k].PendingTermination = true;
							}
						}
						continue;
					}
					if (Clients[k].IsActive)
					{
						Clients[k].PendingTermination = true;
						continue;
					}
					Clients[k].StatusText2 = "";
					if (k < 255)
					{
						bool active = Main.player[k].active;
						Main.player[k].active = false;
						if (active)
						{
							Player.Hooks.PlayerDisconnect(k);
						}
					}
				}
				num++;
				if (num > 10)
				{
					Thread.Sleep(1);
					num = 0;
				}
				else
				{
					Thread.Sleep(0);
				}
				if (!WorldGen.saveLock && !Main.dedServ)
				{
					if (num3 == 0)
					{
						Main.statusText = Language.GetTextValue("Net.WaitingForClients");
					}
					else
					{
						Main.statusText = Language.GetTextValue("Net.ClientsConnected", num3);
					}
				}
				if (num3 == 0)
				{
					anyClients = false;
				}
				else
				{
					anyClients = true;
				}
				IsServerRunning = true;
			}
			StopListening();
			try
			{
				closePort();
			}
			catch
			{
			}
			for (int l = 0; l < 256; l++)
			{
				Clients[l].Reset();
			}
			if (Main.menuMode != 15)
			{
				Main.netMode = 0;
				Main.menuMode = 10;
				WorldFile.saveWorld();
				while (WorldGen.saveLock)
				{
				}
				Main.menuMode = 0;
			}
			else
			{
				Main.netMode = 0;
			}
			Main.myPlayer = 0;
		}

		public static void StartSocialClient(ISocket socket)
		{
			ThreadPool.QueueUserWorkItem(SocialClientLoop, socket);
		}

		public static void StartTcpClient()
		{
			ThreadPool.QueueUserWorkItem(TcpClientLoop, 1);
		}

		public static void StartServer()
		{
			ServerThread = new Thread(ServerLoop);
			ServerThread.Start();
		}

		public static bool SetRemoteIP(string remoteAddress)
		{
			try
			{
				if (IPAddress.TryParse(remoteAddress, out var address))
				{
					ServerIP = address;
					ServerIPText = address.ToString();
					return true;
				}
				IPAddress[] addressList = Dns.GetHostEntry(remoteAddress).AddressList;
				for (int i = 0; i < addressList.Length; i++)
				{
					if (addressList[i].AddressFamily == AddressFamily.InterNetwork)
					{
						ServerIP = addressList[i];
						ServerIPText = remoteAddress;
						return true;
					}
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		public static void Initialize()
		{
			NetMessage.buffer[256] = new MessageBuffer();
			NetMessage.buffer[256].whoAmI = 256;
		}

		public static int GetSectionX(int x)
		{
			return x / 200;
		}

		public static int GetSectionY(int y)
		{
			return y / 150;
		}
	}
}
