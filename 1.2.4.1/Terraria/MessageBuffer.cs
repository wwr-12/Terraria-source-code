using System;
using System.IO;
using Microsoft.Xna.Framework;

namespace Terraria
{
	public class MessageBuffer
	{
		public const int readBufferMax = 65535;

		public const int writeBufferMax = 65535;

		public bool broadcast;

		public byte[] readBuffer = new byte[65535];

		public byte[] writeBuffer = new byte[65535];

		public bool writeLocked;

		public int messageLength;

		public int totalData;

		public int whoAmI;

		public int spamCount;

		public int maxSpam;

		public bool checkBytes;

		public MemoryStream readerStream;

		public MemoryStream writerStream;

		public BinaryReader reader;

		public BinaryWriter writer;

		public void Reset()
		{
			readBuffer = new byte[65535];
			writeBuffer = new byte[65535];
			writeLocked = false;
			messageLength = 0;
			totalData = 0;
			spamCount = 0;
			broadcast = false;
			checkBytes = false;
			ResetReader();
			ResetWriter();
		}

		public void ResetReader()
		{
			if (readerStream != null)
			{
				readerStream.Close();
			}
			readerStream = new MemoryStream(readBuffer);
			reader = new BinaryReader(readerStream);
		}

		public void ResetWriter()
		{
			if (writerStream != null)
			{
				writerStream.Close();
			}
			writerStream = new MemoryStream(writeBuffer);
			writer = new BinaryWriter(writerStream);
		}

		public void GetData(int start, int length)
		{
			if (whoAmI < 256)
			{
				Netplay.serverSock[whoAmI].timeOut = 0;
			}
			else
			{
				Netplay.clientSock.timeOut = 0;
			}
			byte b = 0;
			int num = 0;
			num = start + 1;
			b = readBuffer[start];
			Main.rxMsg++;
			Main.rxData += length;
			Main.rxMsgType[b]++;
			Main.rxDataType[b] += length;
			if (Main.netMode == 1 && Netplay.clientSock.statusMax > 0)
			{
				Netplay.clientSock.statusCount++;
			}
			if (Main.verboseNetplay)
			{
				for (int i = start; i < start + length; i++)
				{
				}
				for (int j = start; j < start + length; j++)
				{
					byte b13 = readBuffer[j];
				}
			}
			if (Main.netMode == 2 && b != 38 && Netplay.serverSock[whoAmI].state == -1)
			{
				NetMessage.SendData(2, whoAmI, -1, Lang.mp[1]);
				return;
			}
			if (Main.netMode == 2 && Netplay.serverSock[whoAmI].state < 10 && b > 12 && b != 16 && b != 42 && b != 50 && b != 38 && b != 68)
			{
				NetMessage.BootPlayer(whoAmI, Lang.mp[2]);
			}
			if (reader == null)
			{
				ResetReader();
			}
			reader.BaseStream.Position = num;
			switch (b)
			{
			case 1:
				if (Main.netMode != 2)
				{
					break;
				}
				if (Main.dedServ && Netplay.CheckBan(Netplay.serverSock[whoAmI].tcpClient.Client.RemoteEndPoint.ToString()))
				{
					NetMessage.SendData(2, whoAmI, -1, Lang.mp[3]);
				}
				else
				{
					if (Netplay.serverSock[whoAmI].state != 0)
					{
						break;
					}
					string text7 = reader.ReadString();
					if (text7 == "Terraria" + Main.curRelease)
					{
						if (string.IsNullOrEmpty(Netplay.password))
						{
							Netplay.serverSock[whoAmI].state = 1;
							NetMessage.SendData(3, whoAmI);
						}
						else
						{
							Netplay.serverSock[whoAmI].state = -1;
							NetMessage.SendData(37, whoAmI);
						}
					}
					else
					{
						NetMessage.SendData(2, whoAmI, -1, Lang.mp[4]);
					}
				}
				break;
			case 2:
				if (Main.netMode == 1)
				{
					Netplay.disconnect = true;
					Main.statusText = reader.ReadString();
				}
				break;
			case 3:
				if (Main.netMode == 1)
				{
					if (Netplay.clientSock.state == 1)
					{
						Netplay.clientSock.state = 2;
					}
					int num21 = reader.ReadByte();
					if (num21 != Main.myPlayer)
					{
						Main.player[num21] = (Player)Main.player[Main.myPlayer].Clone();
						Main.player[Main.myPlayer] = new Player();
						Main.player[num21].whoAmi = num21;
						Main.myPlayer = num21;
					}
					Player player5 = Main.player[num21];
					NetMessage.SendData(4, -1, -1, player5.name, num21);
					NetMessage.SendData(68, -1, -1, "", num21);
					NetMessage.SendData(16, -1, -1, "", num21);
					NetMessage.SendData(42, -1, -1, "", num21);
					NetMessage.SendData(50, -1, -1, "", num21);
					for (int num22 = 0; num22 < 59; num22++)
					{
						NetMessage.SendData(5, -1, -1, player5.inventory[num22].name, num21, num22, (int)player5.inventory[num22].prefix);
					}
					for (int num23 = 0; num23 < 16; num23++)
					{
						NetMessage.SendData(5, -1, -1, player5.armor[num23].name, num21, 59 + num23, (int)player5.armor[num23].prefix);
					}
					for (int num24 = 0; num24 < 8; num24++)
					{
						NetMessage.SendData(5, -1, -1, player5.dye[num24].name, num21, 75 + num24, (int)player5.dye[num24].prefix);
					}
					NetMessage.SendData(6);
					if (Netplay.clientSock.state == 2)
					{
						Netplay.clientSock.state = 3;
					}
				}
				break;
			case 4:
			{
				int num151 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num151 = whoAmI;
				}
				if (num151 == Main.myPlayer && !Main.ServerSideCharacter)
				{
					break;
				}
				Player player15 = Main.player[num151];
				player15.whoAmi = num151;
				if (reader.ReadByte() == 0)
				{
					player15.male = true;
				}
				else
				{
					player15.male = false;
				}
				player15.hair = reader.ReadByte();
				if (player15.hair >= 123)
				{
					player15.hair = 0;
				}
				player15.name = reader.ReadString().Trim().Trim();
				player15.hairDye = reader.ReadByte();
				player15.hideVisual = reader.ReadByte();
				player15.hairColor = reader.ReadRGB();
				player15.skinColor = reader.ReadRGB();
				player15.eyeColor = reader.ReadRGB();
				player15.shirtColor = reader.ReadRGB();
				player15.underShirtColor = reader.ReadRGB();
				player15.pantsColor = reader.ReadRGB();
				player15.shoeColor = reader.ReadRGB();
				player15.difficulty = reader.ReadByte();
				if (Main.netMode != 2)
				{
					break;
				}
				bool flag9 = false;
				if (Netplay.serverSock[whoAmI].state < 10)
				{
					for (int num152 = 0; num152 < 255; num152++)
					{
						if (num152 != num151 && player15.name == Main.player[num152].name && Netplay.serverSock[num152].active)
						{
							flag9 = true;
						}
					}
				}
				if (flag9)
				{
					NetMessage.SendData(2, whoAmI, -1, player15.name + " " + Lang.mp[5]);
					break;
				}
				if (player15.name.Length > Player.nameLen)
				{
					NetMessage.SendData(2, whoAmI, -1, "Name is too long.");
					break;
				}
				if (player15.name == "")
				{
					NetMessage.SendData(2, whoAmI, -1, "Empty name.");
					break;
				}
				Netplay.serverSock[whoAmI].oldName = player15.name;
				Netplay.serverSock[whoAmI].name = player15.name;
				NetMessage.SendData(4, -1, whoAmI, player15.name, num151);
				break;
			}
			case 5:
			{
				int num127 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num127 = whoAmI;
				}
				if (num127 == Main.myPlayer && !Main.ServerSideCharacter)
				{
					break;
				}
				Player player14 = Main.player[num127];
				lock (player14)
				{
					int num128 = reader.ReadByte();
					int stack2 = reader.ReadInt16();
					int num129 = reader.ReadByte();
					int type3 = reader.ReadInt16();
					if (num128 < 59)
					{
						player14.inventory[num128] = new Item();
						player14.inventory[num128].netDefaults(type3);
						player14.inventory[num128].stack = stack2;
						player14.inventory[num128].Prefix(num129);
						if (num127 == Main.myPlayer && num128 == 58)
						{
							Main.mouseItem = player14.inventory[num128].Clone();
						}
					}
					else if (num128 >= 75 && num128 <= 82)
					{
						int num130 = num128 - 58 - 17;
						player14.dye[num130] = new Item();
						player14.dye[num130].netDefaults(type3);
						player14.dye[num130].stack = stack2;
						player14.dye[num130].Prefix(num129);
					}
					else
					{
						int num131 = num128 - 58 - 1;
						player14.armor[num131] = new Item();
						player14.armor[num131].netDefaults(type3);
						player14.armor[num131].stack = stack2;
						player14.armor[num131].Prefix(num129);
					}
					if (Main.netMode == 2 && num127 == whoAmI)
					{
						NetMessage.SendData(5, -1, whoAmI, "", num127, num128, num129);
					}
					break;
				}
			}
			case 6:
				if (Main.netMode == 2)
				{
					if (Netplay.serverSock[whoAmI].state == 1)
					{
						Netplay.serverSock[whoAmI].state = 2;
					}
					NetMessage.SendData(7, whoAmI);
				}
				break;
			case 7:
				if (Main.netMode == 1)
				{
					Main.time = reader.ReadInt32();
					BitsByte bitsByte2 = reader.ReadByte();
					Main.dayTime = bitsByte2[0];
					Main.bloodMoon = bitsByte2[1];
					Main.eclipse = bitsByte2[2];
					Main.moonPhase = reader.ReadByte();
					Main.maxTilesX = reader.ReadInt16();
					Main.maxTilesY = reader.ReadInt16();
					Main.spawnTileX = reader.ReadInt16();
					Main.spawnTileY = reader.ReadInt16();
					Main.worldSurface = reader.ReadInt16();
					Main.rockLayer = reader.ReadInt16();
					Main.worldID = reader.ReadInt32();
					Main.worldName = reader.ReadString();
					Main.moonType = reader.ReadByte();
					WorldGen.setBG(0, reader.ReadByte());
					WorldGen.setBG(1, reader.ReadByte());
					WorldGen.setBG(2, reader.ReadByte());
					WorldGen.setBG(3, reader.ReadByte());
					WorldGen.setBG(4, reader.ReadByte());
					WorldGen.setBG(5, reader.ReadByte());
					WorldGen.setBG(6, reader.ReadByte());
					WorldGen.setBG(7, reader.ReadByte());
					Main.iceBackStyle = reader.ReadByte();
					Main.jungleBackStyle = reader.ReadByte();
					Main.hellBackStyle = reader.ReadByte();
					Main.windSpeedSet = reader.ReadSingle();
					Main.numClouds = reader.ReadByte();
					for (int m = 0; m < 3; m++)
					{
						Main.treeX[m] = reader.ReadInt32();
					}
					for (int n = 0; n < 4; n++)
					{
						Main.treeStyle[n] = reader.ReadByte();
					}
					for (int num8 = 0; num8 < 3; num8++)
					{
						Main.caveBackX[num8] = reader.ReadInt32();
					}
					for (int num9 = 0; num9 < 4; num9++)
					{
						Main.caveBackStyle[num9] = reader.ReadByte();
					}
					Main.maxRaining = reader.ReadSingle();
					Main.raining = Main.maxRaining > 0f;
					BitsByte bitsByte3 = reader.ReadByte();
					WorldGen.shadowOrbSmashed = bitsByte3[0];
					NPC.downedBoss1 = bitsByte3[1];
					NPC.downedBoss2 = bitsByte3[2];
					NPC.downedBoss3 = bitsByte3[3];
					Main.hardMode = bitsByte3[4];
					NPC.downedClown = bitsByte3[5];
					Main.ServerSideCharacter = bitsByte3[6];
					NPC.downedPlantBoss = bitsByte3[7];
					BitsByte bitsByte4 = reader.ReadByte();
					NPC.downedMechBoss1 = bitsByte4[0];
					NPC.downedMechBoss2 = bitsByte4[1];
					NPC.downedMechBoss3 = bitsByte4[2];
					NPC.downedMechBossAny = bitsByte4[3];
					Main.cloudBGActive = (bitsByte4[4] ? 1 : 0);
					WorldGen.crimson = bitsByte4[5];
					Main.pumpkinMoon = bitsByte4[6];
					Main.snowMoon = bitsByte4[7];
					if (Netplay.clientSock.state == 3)
					{
						Netplay.clientSock.state = 4;
					}
				}
				break;
			case 8:
			{
				if (Main.netMode != 2)
				{
					break;
				}
				int num89 = reader.ReadInt32();
				int num90 = reader.ReadInt32();
				bool flag8 = true;
				if (num89 == -1 || num90 == -1)
				{
					flag8 = false;
				}
				else if (num89 < 10 || num89 > Main.maxTilesX - 10)
				{
					flag8 = false;
				}
				else if (num90 < 10 || num90 > Main.maxTilesY - 10)
				{
					flag8 = false;
				}
				int num91 = Netplay.GetSectionX(Main.spawnTileX) - 2;
				int num92 = Netplay.GetSectionY(Main.spawnTileY) - 1;
				int num93 = num91 + 5;
				int num94 = num92 + 3;
				if (num91 < 0)
				{
					num91 = 0;
				}
				if (num93 >= Main.maxSectionsX)
				{
					num93 = Main.maxSectionsX - 1;
				}
				if (num92 < 0)
				{
					num92 = 0;
				}
				if (num94 >= Main.maxSectionsY)
				{
					num94 = Main.maxSectionsY - 1;
				}
				int num95 = (num93 - num91) * (num94 - num92);
				int num96 = -1;
				int num97 = -1;
				if (flag8)
				{
					num89 = Netplay.GetSectionX(num89) - 2;
					num90 = Netplay.GetSectionY(num90) - 1;
					num96 = num89 + 5;
					num97 = num90 + 3;
					if (num89 < 0)
					{
						num89 = 0;
					}
					if (num96 >= Main.maxSectionsX)
					{
						num96 = Main.maxSectionsX - 1;
					}
					if (num90 < 0)
					{
						num90 = 0;
					}
					if (num97 >= Main.maxSectionsY)
					{
						num97 = Main.maxSectionsY - 1;
					}
					for (int num98 = num89; num98 < num96; num98++)
					{
						for (int num99 = num90; num99 < num97; num99++)
						{
							if (num98 < num91 || num98 >= num93 || num99 < num92 || num99 >= num94)
							{
								num95++;
							}
						}
					}
				}
				if (Netplay.serverSock[whoAmI].state == 2)
				{
					Netplay.serverSock[whoAmI].state = 3;
				}
				NetMessage.SendData(9, whoAmI, -1, Lang.inter[44], num95);
				Netplay.serverSock[whoAmI].statusText2 = "is receiving tile data";
				Netplay.serverSock[whoAmI].statusMax += num95;
				for (int num100 = num91; num100 < num93; num100++)
				{
					for (int num101 = num92; num101 < num94; num101++)
					{
						NetMessage.SendSection(whoAmI, num100, num101);
					}
				}
				if (flag8)
				{
					for (int num102 = num89; num102 < num96; num102++)
					{
						for (int num103 = num90; num103 < num97; num103++)
						{
							NetMessage.SendSection(whoAmI, num102, num103, true);
						}
					}
					NetMessage.SendData(11, whoAmI, -1, "", num89, num90, num96 - 1, num97 - 1);
				}
				NetMessage.SendData(11, whoAmI, -1, "", num91, num92, num93 - 1, num94 - 1);
				for (int num104 = 0; num104 < 400; num104++)
				{
					if (Main.item[num104].active)
					{
						NetMessage.SendData(21, whoAmI, -1, "", num104);
						NetMessage.SendData(22, whoAmI, -1, "", num104);
					}
				}
				for (int num105 = 0; num105 < 200; num105++)
				{
					if (Main.npc[num105].active)
					{
						NetMessage.SendData(23, whoAmI, -1, "", num105);
					}
				}
				for (int num106 = 0; num106 < 1000; num106++)
				{
					if (Main.projectile[num106].active && (Main.projPet[Main.projectile[num106].type] || Main.projectile[num106].netImportant))
					{
						NetMessage.SendData(27, whoAmI, -1, "", num106);
					}
				}
				NetMessage.SendData(49, whoAmI);
				NetMessage.SendData(57, whoAmI);
				NetMessage.SendData(7, whoAmI);
				break;
			}
			case 9:
				if (Main.netMode == 1)
				{
					Netplay.clientSock.statusMax += reader.ReadInt32();
					Netplay.clientSock.statusText = reader.ReadString();
				}
				break;
			case 10:
				if (Main.netMode == 1)
				{
					NetMessage.DecompressTileBlock(readBuffer, num, length, true);
				}
				break;
			case 11:
				if (Main.netMode == 1)
				{
					WorldGen.SectionTileFrame(reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16(), reader.ReadInt16());
				}
				break;
			case 12:
			{
				int num59 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num59 = whoAmI;
				}
				Player player7 = Main.player[num59];
				player7.SpawnX = reader.ReadInt16();
				player7.SpawnY = reader.ReadInt16();
				player7.Spawn();
				if (Main.netMode == 2 && Netplay.serverSock[whoAmI].state >= 3)
				{
					if (Netplay.serverSock[whoAmI].state == 3)
					{
						Netplay.serverSock[whoAmI].state = 10;
						NetMessage.greetPlayer(whoAmI);
						NetMessage.buffer[whoAmI].broadcast = true;
						NetMessage.syncPlayers();
						NetMessage.SendData(12, -1, whoAmI, "", whoAmI);
						NetMessage.SendData(74, whoAmI, -1, Main.player[whoAmI].name, Main.anglerQuest);
					}
					else
					{
						NetMessage.SendData(12, -1, whoAmI, "", whoAmI);
					}
				}
				break;
			}
			case 13:
			{
				int num60 = reader.ReadByte();
				if (num60 != Main.myPlayer || Main.ServerSideCharacter)
				{
					if (Main.netMode == 2)
					{
						num60 = whoAmI;
					}
					Player player8 = Main.player[num60];
					BitsByte bitsByte7 = reader.ReadByte();
					player8.controlUp = bitsByte7[0];
					player8.controlDown = bitsByte7[1];
					player8.controlLeft = bitsByte7[2];
					player8.controlRight = bitsByte7[3];
					player8.controlJump = bitsByte7[4];
					player8.controlUseItem = bitsByte7[5];
					player8.direction = (bitsByte7[6] ? 1 : (-1));
					BitsByte bitsByte8 = reader.ReadByte();
					if (bitsByte8[0])
					{
						player8.pulley = true;
						player8.pulleyDir = (byte)((!bitsByte8[1]) ? 1u : 2u);
					}
					else
					{
						player8.pulley = false;
					}
					player8.selectedItem = reader.ReadByte();
					player8.position = reader.ReadVector2();
					if (bitsByte8[2])
					{
						player8.velocity = reader.ReadVector2();
					}
					if (Main.netMode == 2 && Netplay.serverSock[whoAmI].state == 10)
					{
						NetMessage.SendData(13, -1, whoAmI, "", num60);
					}
				}
				break;
			}
			case 14:
			{
				if (Main.netMode != 1)
				{
					break;
				}
				int num156 = reader.ReadByte();
				int num157 = reader.ReadByte();
				if (num157 == 1)
				{
					if (!Main.player[num156].active)
					{
						Main.player[num156] = new Player();
					}
					Main.player[num156].active = true;
				}
				else
				{
					Main.player[num156].active = false;
				}
				break;
			}
			case 16:
			{
				int num115 = reader.ReadByte();
				if (num115 != Main.myPlayer || Main.ServerSideCharacter)
				{
					if (Main.netMode == 2)
					{
						num115 = whoAmI;
					}
					Player player13 = Main.player[num115];
					player13.statLife = reader.ReadInt16();
					player13.statLifeMax = reader.ReadInt16();
					if (player13.statLifeMax < 100)
					{
						player13.statLifeMax = 100;
					}
					player13.dead = player13.statLife <= 0;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(16, -1, whoAmI, "", num115);
					}
				}
				break;
			}
			case 17:
			{
				byte b4 = reader.ReadByte();
				int num13 = reader.ReadInt16();
				int num14 = reader.ReadInt16();
				short num15 = reader.ReadInt16();
				int num16 = reader.ReadByte();
				bool flag = num15 == 1;
				if (Main.tile[num13, num14] == null)
				{
					Main.tile[num13, num14] = new Tile();
				}
				if (Main.netMode == 2)
				{
					if (!flag)
					{
						if (b4 == 0 || b4 == 2 || b4 == 4)
						{
							Netplay.serverSock[whoAmI].spamDelBlock += 1f;
						}
						if (b4 == 1 || b4 == 3)
						{
							Netplay.serverSock[whoAmI].spamAddBlock += 1f;
						}
					}
					if (!Netplay.serverSock[whoAmI].tileSection[Netplay.GetSectionX(num13), Netplay.GetSectionY(num14)])
					{
						flag = true;
					}
				}
				if (b4 == 0)
				{
					WorldGen.KillTile(num13, num14, flag);
				}
				if (b4 == 1)
				{
					WorldGen.PlaceTile(num13, num14, num15, false, true, -1, num16);
				}
				if (b4 == 2)
				{
					WorldGen.KillWall(num13, num14, flag);
				}
				if (b4 == 3)
				{
					WorldGen.PlaceWall(num13, num14, num15);
				}
				if (b4 == 4)
				{
					WorldGen.KillTile(num13, num14, flag, false, true);
				}
				if (b4 == 5)
				{
					WorldGen.PlaceWire(num13, num14);
				}
				if (b4 == 6)
				{
					WorldGen.KillWire(num13, num14);
				}
				if (b4 == 7)
				{
					WorldGen.PoundTile(num13, num14);
				}
				if (b4 == 8)
				{
					WorldGen.PlaceActuator(num13, num14);
				}
				if (b4 == 9)
				{
					WorldGen.KillActuator(num13, num14);
				}
				if (b4 == 10)
				{
					WorldGen.PlaceWire2(num13, num14);
				}
				if (b4 == 11)
				{
					WorldGen.KillWire2(num13, num14);
				}
				if (b4 == 12)
				{
					WorldGen.PlaceWire3(num13, num14);
				}
				if (b4 == 13)
				{
					WorldGen.KillWire3(num13, num14);
				}
				if (b4 == 14)
				{
					WorldGen.SlopeTile(num13, num14, num15);
				}
				if (b4 == 15)
				{
					Minecart.FrameTrack(num13, num14, true);
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(17, -1, whoAmI, "", b4, num13, num14, num15, num16);
					if (b4 == 1 && num15 == 53)
					{
						NetMessage.SendTileSquare(-1, num13, num14, 1);
					}
				}
				break;
			}
			case 18:
				if (Main.netMode == 1)
				{
					Main.dayTime = reader.ReadByte() == 1;
					Main.time = reader.ReadInt32();
					Main.sunModY = reader.ReadInt16();
					Main.moonModY = reader.ReadInt16();
				}
				break;
			case 19:
			{
				byte b8 = reader.ReadByte();
				int num86 = reader.ReadInt16();
				int num87 = reader.ReadInt16();
				int num88 = ((reader.ReadByte() != 0) ? 1 : (-1));
				switch (b8)
				{
				case 0:
					WorldGen.OpenDoor(num86, num87, num88);
					break;
				case 1:
					WorldGen.CloseDoor(num86, num87, true);
					break;
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(19, -1, whoAmI, "", b8, num86, num87, (num88 == 1) ? 1 : 0);
				}
				break;
			}
			case 20:
			{
				short num51 = reader.ReadInt16();
				int num52 = reader.ReadInt16();
				int num53 = reader.ReadInt16();
				BitsByte bitsByte5 = (byte)0;
				BitsByte bitsByte6 = (byte)0;
				Tile tile = null;
				for (int num54 = num52; num54 < num52 + num51; num54++)
				{
					for (int num55 = num53; num55 < num53 + num51; num55++)
					{
						if (Main.tile[num54, num55] == null)
						{
							Main.tile[num54, num55] = new Tile();
						}
						tile = Main.tile[num54, num55];
						bool flag3 = tile.active();
						bitsByte5 = reader.ReadByte();
						bitsByte6 = reader.ReadByte();
						tile.active(bitsByte5[0]);
						tile.wall = (byte)(bitsByte5[2] ? 1u : 0u);
						bool flag4 = bitsByte5[3];
						if (Main.netMode != 2)
						{
							tile.liquid = (byte)(flag4 ? 1u : 0u);
						}
						tile.wire(bitsByte5[4]);
						tile.halfBrick(bitsByte5[5]);
						tile.actuator(bitsByte5[6]);
						tile.inActive(bitsByte5[7]);
						tile.wire2(bitsByte6[0]);
						tile.wire3(bitsByte6[1]);
						if (bitsByte6[2])
						{
							tile.color(reader.ReadByte());
						}
						if (bitsByte6[3])
						{
							tile.wallColor(reader.ReadByte());
						}
						if (tile.active())
						{
							int type2 = tile.type;
							tile.type = reader.ReadUInt16();
							if (Main.tileFrameImportant[tile.type])
							{
								tile.frameX = reader.ReadInt16();
								tile.frameY = reader.ReadInt16();
							}
							else if (!flag3 || tile.type != type2)
							{
								tile.frameX = -1;
								tile.frameY = -1;
							}
							byte b6 = 0;
							if (bitsByte6[4])
							{
								b6++;
							}
							if (bitsByte6[5])
							{
								b6 += 2;
							}
							if (bitsByte6[6])
							{
								b6 += 4;
							}
							tile.slope(b6);
						}
						if (tile.wall > 0)
						{
							tile.wall = reader.ReadByte();
						}
						if (flag4)
						{
							tile.liquid = reader.ReadByte();
							tile.liquidType(reader.ReadByte());
						}
					}
				}
				WorldGen.RangeFrame(num52, num53, num52 + num51, num53 + num51);
				if (Main.netMode == 2)
				{
					NetMessage.SendData(b, -1, whoAmI, "", num51, num52, num53);
				}
				break;
			}
			case 21:
			{
				int num56 = reader.ReadInt16();
				Vector2 position2 = reader.ReadVector2();
				Vector2 velocity2 = reader.ReadVector2();
				int stack = reader.ReadInt16();
				int pre = reader.ReadByte();
				int num57 = reader.ReadByte();
				int num58 = reader.ReadInt16();
				if (Main.netMode == 1)
				{
					if (num58 == 0)
					{
						Main.item[num56].active = false;
						break;
					}
					Item item = Main.item[num56];
					item.netDefaults(num58);
					item.Prefix(pre);
					item.stack = stack;
					item.position = position2;
					item.velocity = velocity2;
					item.active = true;
					item.wet = Collision.WetCollision(item.position, item.width, item.height);
					break;
				}
				if (num58 == 0)
				{
					if (num56 < 400)
					{
						Main.item[num56].active = false;
						NetMessage.SendData(21, -1, -1, "", num56);
					}
					break;
				}
				bool flag5 = false;
				if (num56 == 400)
				{
					flag5 = true;
				}
				if (flag5)
				{
					Item item2 = new Item();
					item2.netDefaults(num58);
					num56 = Item.NewItem((int)position2.X, (int)position2.Y, item2.width, item2.height, item2.type, stack, true);
				}
				Item item3 = Main.item[num56];
				item3.netDefaults(num58);
				item3.Prefix(pre);
				item3.stack = stack;
				item3.position = position2;
				item3.velocity = velocity2;
				item3.active = true;
				item3.owner = Main.myPlayer;
				if (flag5)
				{
					NetMessage.SendData(21, -1, -1, "", num56);
					if (num57 == 0)
					{
						Main.item[num56].ownIgnore = whoAmI;
						Main.item[num56].ownTime = 100;
					}
					Main.item[num56].FindOwner(num56);
				}
				else
				{
					NetMessage.SendData(21, -1, whoAmI, "", num56);
				}
				break;
			}
			case 22:
			{
				int num43 = reader.ReadInt16();
				int num44 = reader.ReadByte();
				if (Main.netMode != 2 || Main.item[num43].owner == whoAmI)
				{
					Main.item[num43].owner = num44;
					if (num44 == Main.myPlayer)
					{
						Main.item[num43].keepTime = 15;
					}
					else
					{
						Main.item[num43].keepTime = 0;
					}
					if (Main.netMode == 2)
					{
						Main.item[num43].owner = 255;
						Main.item[num43].keepTime = 15;
						NetMessage.SendData(22, -1, -1, "", num43);
					}
				}
				break;
			}
			case 23:
			{
				if (Main.netMode != 1)
				{
					break;
				}
				int num4 = reader.ReadInt16();
				Vector2 position = reader.ReadVector2();
				Vector2 velocity = reader.ReadVector2();
				int target = reader.ReadByte();
				BitsByte bitsByte = reader.ReadByte();
				float[] array = new float[NPC.maxAI];
				for (int k = 0; k < NPC.maxAI; k++)
				{
					if (bitsByte[k + 2])
					{
						array[k] = reader.ReadSingle();
					}
					else
					{
						array[k] = 0f;
					}
				}
				int num5 = reader.ReadInt16();
				int num6 = 0;
				if (!bitsByte[7])
				{
					num6 = ((Main.npcLifeBytes[num5] == 2) ? reader.ReadInt16() : ((Main.npcLifeBytes[num5] != 4) ? reader.ReadSByte() : reader.ReadInt32()));
				}
				int num7 = -1;
				NPC nPC = Main.npc[num4];
				if (!nPC.active || nPC.netID != num5)
				{
					if (nPC.active)
					{
						num7 = nPC.type;
					}
					nPC.active = true;
					nPC.netDefaults(num5);
				}
				nPC.position = position;
				nPC.velocity = velocity;
				nPC.target = target;
				nPC.direction = (bitsByte[0] ? 1 : (-1));
				nPC.directionY = (bitsByte[1] ? 1 : (-1));
				nPC.spriteDirection = (bitsByte[6] ? 1 : (-1));
				if (bitsByte[7])
				{
					num6 = (nPC.life = nPC.lifeMax);
				}
				else
				{
					nPC.life = num6;
				}
				if (num6 <= 0)
				{
					nPC.active = false;
				}
				for (int l = 0; l < NPC.maxAI; l++)
				{
					nPC.ai[l] = array[l];
				}
				if (num7 > -1 && num7 != nPC.type)
				{
					nPC.xForm(num7, nPC.type);
				}
				if (num5 == 262)
				{
					NPC.plantBoss = num4;
				}
				if (num5 == 245)
				{
					NPC.golemBoss = num4;
				}
				if (Main.npcCatchable[nPC.type])
				{
					nPC.releaseOwner = reader.ReadByte();
				}
				break;
			}
			case 24:
			{
				int num18 = reader.ReadInt16();
				int num19 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num19 = whoAmI;
				}
				Player player4 = Main.player[num19];
				Main.npc[num18].StrikeNPC(player4.inventory[player4.selectedItem].damage, player4.inventory[player4.selectedItem].knockBack, player4.direction);
				if (Main.netMode == 2)
				{
					NetMessage.SendData(24, -1, whoAmI, "", num18, num19);
					NetMessage.SendData(23, -1, -1, "", num18);
				}
				break;
			}
			case 25:
			{
				int num140 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num140 = whoAmI;
				}
				Color color3 = reader.ReadRGB();
				if (Main.netMode == 2)
				{
					color3 = new Color(255, 255, 255);
				}
				string text9 = reader.ReadString();
				if (Main.netMode == 1)
				{
					string newText = text9;
					if (num140 < 255)
					{
						newText = "<" + Main.player[num140].name + "> " + text9;
						Main.player[num140].chatText = text9;
						Main.player[num140].chatShowTime = Main.chatLength / 2;
					}
					Main.NewText(newText, color3.R, color3.G, color3.B);
				}
				else
				{
					if (Main.netMode != 2)
					{
						break;
					}
					string text10 = text9.ToLower();
					if (text10 == Lang.mp[6] || text10 == Lang.mp[21])
					{
						string text11 = "";
						for (int num141 = 0; num141 < 255; num141++)
						{
							if (Main.player[num141].active)
							{
								text11 = ((!(text11 == "")) ? (text11 + ", " + Main.player[num141].name) : Main.player[num141].name);
							}
						}
						NetMessage.SendData(25, whoAmI, -1, Lang.mp[7] + " " + text11 + ".", 255, 255f, 240f, 20f);
					}
					else if (text10.StartsWith("/me "))
					{
						NetMessage.SendData(25, -1, -1, "*" + Main.player[whoAmI].name + " " + text9.Substring(4), 255, 200f, 100f);
					}
					else if (text10 == Lang.mp[8])
					{
						NetMessage.SendData(25, -1, -1, "*" + Main.player[whoAmI].name + " " + Lang.mp[9] + " " + Main.rand.Next(1, 101), 255, 255f, 240f, 20f);
					}
					else if (text10.StartsWith("/p "))
					{
						int team2 = Main.player[whoAmI].team;
						color3 = Main.teamColor[team2];
						if (team2 != 0)
						{
							for (int num142 = 0; num142 < 255; num142++)
							{
								if (Main.player[num142].team == team2)
								{
									NetMessage.SendData(25, num142, -1, text9.Substring(3), num140, (int)color3.R, (int)color3.G, (int)color3.B);
								}
							}
						}
						else
						{
							NetMessage.SendData(25, whoAmI, -1, Lang.mp[10], 255, 255f, 240f, 20f);
						}
					}
					else
					{
						if (Main.player[whoAmI].difficulty == 2)
						{
							color3 = Main.hcColor;
						}
						else if (Main.player[whoAmI].difficulty == 1)
						{
							color3 = Main.mcColor;
						}
						NetMessage.SendData(25, -1, -1, text9, num140, (int)color3.R, (int)color3.G, (int)color3.B);
						if (Main.dedServ)
						{
							Console.WriteLine("<" + Main.player[whoAmI].name + "> " + text9);
						}
					}
				}
				break;
			}
			case 26:
			{
				int num75 = reader.ReadByte();
				if (Main.netMode != 2 || whoAmI == num75 || (Main.player[num75].hostile && Main.player[whoAmI].hostile))
				{
					int num76 = reader.ReadByte() - 1;
					int num77 = reader.ReadInt16();
					string text5 = reader.ReadString();
					BitsByte bitsByte11 = reader.ReadByte();
					bool flag6 = bitsByte11[0];
					bool flag7 = bitsByte11[1];
					Main.player[num75].Hurt(num77, num76, flag6, true, text5, flag7);
					if (Main.netMode == 2)
					{
						NetMessage.SendData(26, -1, whoAmI, text5, num75, num76, num77, flag6 ? 1 : 0, flag7 ? 1 : 0);
					}
				}
				break;
			}
			case 27:
			{
				int num132 = reader.ReadInt16();
				Vector2 position3 = reader.ReadVector2();
				Vector2 velocity3 = reader.ReadVector2();
				float knockBack = reader.ReadSingle();
				int damage = reader.ReadInt16();
				int num133 = reader.ReadByte();
				int num134 = reader.ReadInt16();
				BitsByte bitsByte12 = reader.ReadByte();
				float[] array2 = new float[Projectile.maxAI];
				for (int num135 = 0; num135 < Projectile.maxAI; num135++)
				{
					if (bitsByte12[num135])
					{
						array2[num135] = reader.ReadSingle();
					}
					else
					{
						array2[num135] = 0f;
					}
				}
				if (Main.netMode == 2)
				{
					num133 = whoAmI;
					if (Main.projHostile[num134])
					{
						break;
					}
				}
				int num136 = 1000;
				for (int num137 = 0; num137 < 1000; num137++)
				{
					if (Main.projectile[num137].owner == num133 && Main.projectile[num137].identity == num132 && Main.projectile[num137].active)
					{
						num136 = num137;
						break;
					}
				}
				if (num136 == 1000)
				{
					for (int num138 = 0; num138 < 1000; num138++)
					{
						if (!Main.projectile[num138].active)
						{
							num136 = num138;
							break;
						}
					}
				}
				Projectile projectile = Main.projectile[num136];
				if (!projectile.active || projectile.type != num134)
				{
					projectile.SetDefaults(num134);
					if (Main.netMode == 2)
					{
						Netplay.serverSock[whoAmI].spamProjectile += 1f;
					}
				}
				projectile.identity = num132;
				projectile.position = position3;
				projectile.velocity = velocity3;
				projectile.type = num134;
				projectile.damage = damage;
				projectile.knockBack = knockBack;
				projectile.owner = num133;
				for (int num139 = 0; num139 < Projectile.maxAI; num139++)
				{
					projectile.ai[num139] = array2[num139];
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(27, -1, whoAmI, "", num136);
				}
				break;
			}
			case 28:
			{
				int num78 = reader.ReadInt16();
				int num79 = reader.ReadInt16();
				float num80 = reader.ReadSingle();
				int num81 = reader.ReadByte() - 1;
				byte b7 = reader.ReadByte();
				if (num79 >= 0)
				{
					Main.npc[num78].StrikeNPC(num79, num80, num81, b7 == 1);
				}
				else
				{
					Main.npc[num78].life = 0;
					Main.npc[num78].HitEffect();
					Main.npc[num78].active = false;
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(28, -1, whoAmI, "", num78, num79, num80, num81, b7);
					if (Main.npc[num78].life <= 0)
					{
						NetMessage.SendData(23, -1, -1, "", num78);
					}
					else
					{
						Main.npc[num78].netUpdate = true;
					}
				}
				break;
			}
			case 29:
			{
				int num48 = reader.ReadInt16();
				int num49 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num49 = whoAmI;
				}
				for (int num50 = 0; num50 < 1000; num50++)
				{
					if (Main.projectile[num50].owner == num49 && Main.projectile[num50].identity == num48 && Main.projectile[num50].active)
					{
						Main.projectile[num50].Kill();
						break;
					}
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(29, -1, whoAmI, "", num48, num49);
				}
				break;
			}
			case 30:
			{
				int num20 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num20 = whoAmI;
				}
				bool flag2 = reader.ReadBoolean();
				Main.player[num20].hostile = flag2;
				if (Main.netMode == 2)
				{
					NetMessage.SendData(30, -1, whoAmI, "", num20);
					string text = " " + Lang.mp[flag2 ? 11 : 12];
					Color color = Main.teamColor[Main.player[num20].team];
					NetMessage.SendData(25, -1, -1, Main.player[num20].name + text, 255, (int)color.R, (int)color.G, (int)color.B);
				}
				break;
			}
			case 31:
			{
				if (Main.netMode != 2)
				{
					break;
				}
				int x2 = reader.ReadInt16();
				int y2 = reader.ReadInt16();
				int num41 = Chest.FindChest(x2, y2);
				if (num41 > -1 && Chest.UsingChest(num41) == -1)
				{
					for (int num42 = 0; num42 < Chest.maxItems; num42++)
					{
						NetMessage.SendData(32, whoAmI, -1, "", num41, num42);
					}
					NetMessage.SendData(33, whoAmI, -1, "", num41);
					Main.player[whoAmI].chest = num41;
				}
				break;
			}
			case 32:
			{
				int num143 = reader.ReadInt16();
				int num144 = reader.ReadByte();
				int stack3 = reader.ReadInt16();
				int pre2 = reader.ReadByte();
				int type4 = reader.ReadInt16();
				if (Main.chest[num143] == null)
				{
					Main.chest[num143] = new Chest();
				}
				if (Main.chest[num143].item[num144] == null)
				{
					Main.chest[num143].item[num144] = new Item();
				}
				Main.chest[num143].item[num144].netDefaults(type4);
				Main.chest[num143].item[num144].Prefix(pre2);
				Main.chest[num143].item[num144].stack = stack3;
				break;
			}
			case 33:
			{
				int num26 = reader.ReadInt16();
				int chestX = reader.ReadInt16();
				int chestY = reader.ReadInt16();
				int num27 = reader.ReadByte();
				string text2 = string.Empty;
				if (num27 != 0)
				{
					if (num27 <= 20)
					{
						text2 = reader.ReadString();
					}
					else if (num27 != 255)
					{
						num27 = 0;
					}
				}
				if (Main.netMode == 1)
				{
					Player player6 = Main.player[Main.myPlayer];
					if (player6.chest == -1)
					{
						Main.playerInventory = true;
						Main.PlaySound(10);
					}
					else if (player6.chest != num26 && num26 != -1)
					{
						Main.playerInventory = true;
						Main.PlaySound(12);
					}
					else if (player6.chest != -1 && num26 == -1)
					{
						Main.PlaySound(11);
					}
					player6.chest = num26;
					player6.chestX = chestX;
					player6.chestY = chestY;
				}
				else
				{
					if (num27 != 0)
					{
						int chest = Main.player[whoAmI].chest;
						Chest chest2 = Main.chest[chest];
						chest2.name = text2;
						NetMessage.SendData(69, -1, whoAmI, text2, chest, chest2.x, chest2.y);
					}
					Main.player[whoAmI].chest = num26;
				}
				break;
			}
			case 34:
			{
				byte b10 = reader.ReadByte();
				int num110 = reader.ReadInt16();
				int num111 = reader.ReadInt16();
				int num112 = reader.ReadInt16();
				if (Main.netMode == 2)
				{
					if (b10 == 0)
					{
						int num113 = WorldGen.PlaceChest(num110, num111, 21, false, num112);
						if (num113 == -1)
						{
							NetMessage.SendData(34, whoAmI, -1, "", b10, num110, num111, num112, num113);
							Item.NewItem(num110 * 16, num111 * 16, 32, 32, Chest.itemSpawn[num112], 1, true);
						}
						else
						{
							NetMessage.SendData(34, -1, -1, "", b10, num110, num111, num112, num113);
						}
						break;
					}
					Tile tile2 = Main.tile[num110, num111];
					if (tile2.type == 21)
					{
						if (tile2.frameX % 36 != 0)
						{
							num110--;
						}
						if (tile2.frameY % 36 != 0)
						{
							num111--;
						}
						int number = Chest.FindChest(num110, num111);
						WorldGen.KillTile(num110, num111);
						if (!tile2.active())
						{
							NetMessage.SendData(34, -1, -1, "", b10, num110, num111, 0f, number);
						}
					}
					break;
				}
				int num114 = reader.ReadInt16();
				if (b10 == 0)
				{
					if (num114 == -1)
					{
						WorldGen.KillTile(num110, num111);
					}
					else
					{
						WorldGen.PlaceChestDirect(num110, num111, 21, num112, num114);
					}
				}
				else
				{
					Chest.DestroyChestDirect(num110, num111, num114);
					WorldGen.KillTile(num110, num111);
				}
				break;
			}
			case 35:
			{
				int num73 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num73 = whoAmI;
				}
				int num74 = reader.ReadInt16();
				if (num73 != Main.myPlayer || Main.ServerSideCharacter)
				{
					Main.player[num73].HealEffect(num74);
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(35, -1, whoAmI, "", num73, num74);
				}
				break;
			}
			case 36:
			{
				int num61 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num61 = whoAmI;
				}
				Player player9 = Main.player[num61];
				BitsByte bitsByte9 = reader.ReadByte();
				player9.zoneEvil = bitsByte9[0];
				player9.zoneMeteor = bitsByte9[1];
				player9.zoneDungeon = bitsByte9[2];
				player9.zoneJungle = bitsByte9[3];
				player9.zoneHoly = bitsByte9[4];
				player9.zoneSnow = bitsByte9[5];
				player9.zoneBlood = bitsByte9[6];
				player9.zoneCandle = bitsByte9[7];
				if (Main.netMode == 2)
				{
					NetMessage.SendData(36, -1, whoAmI, "", num61);
				}
				break;
			}
			case 37:
				if (Main.netMode == 1)
				{
					if (Main.autoPass)
					{
						NetMessage.SendData(38, -1, -1, Netplay.password);
						Main.autoPass = false;
					}
					else
					{
						Netplay.password = "";
						Main.menuMode = 31;
					}
				}
				break;
			case 38:
				if (Main.netMode == 2)
				{
					string text3 = reader.ReadString();
					if (text3 == Netplay.password)
					{
						Netplay.serverSock[whoAmI].state = 1;
						NetMessage.SendData(3, whoAmI);
					}
					else
					{
						NetMessage.SendData(2, whoAmI, -1, Lang.mp[1]);
					}
				}
				break;
			case 39:
				if (Main.netMode == 1)
				{
					int num25 = reader.ReadInt16();
					Main.item[num25].owner = 255;
					NetMessage.SendData(22, -1, -1, "", num25);
				}
				break;
			case 40:
			{
				int num12 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num12 = whoAmI;
				}
				int talkNPC = reader.ReadInt16();
				Main.player[num12].talkNPC = talkNPC;
				if (Main.netMode == 2)
				{
					NetMessage.SendData(40, -1, whoAmI, "", num12);
				}
				break;
			}
			case 41:
			{
				int num3 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num3 = whoAmI;
				}
				Player player2 = Main.player[num3];
				float itemRotation = reader.ReadSingle();
				int itemAnimation = reader.ReadInt16();
				player2.itemRotation = itemRotation;
				player2.itemAnimation = itemAnimation;
				player2.channel = player2.inventory[player2.selectedItem].channel;
				if (Main.netMode == 2)
				{
					NetMessage.SendData(41, -1, whoAmI, "", num3);
				}
				break;
			}
			case 42:
			{
				int num149 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num149 = whoAmI;
				}
				else if (Main.myPlayer == num149 && !Main.ServerSideCharacter)
				{
					break;
				}
				int statMana = reader.ReadInt16();
				int statManaMax = reader.ReadInt16();
				Main.player[num149].statMana = statMana;
				Main.player[num149].statManaMax = statManaMax;
				break;
			}
			case 43:
			{
				int num123 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num123 = whoAmI;
				}
				int num124 = reader.ReadInt16();
				if (num123 != Main.myPlayer)
				{
					Main.player[num123].ManaEffect(num124);
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(43, -1, whoAmI, "", num123, num124);
				}
				break;
			}
			case 44:
			{
				int num107 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num107 = whoAmI;
				}
				int num108 = reader.ReadByte() - 1;
				int num109 = reader.ReadInt16();
				byte b9 = reader.ReadByte();
				string text8 = reader.ReadString();
				Main.player[num107].KillMe(num109, num108, b9 == 1, text8);
				if (Main.netMode == 2)
				{
					NetMessage.SendData(44, -1, whoAmI, text8, num107, num108, num109, (int)b9);
				}
				break;
			}
			case 45:
			{
				int num82 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num82 = whoAmI;
				}
				int num83 = reader.ReadByte();
				Player player12 = Main.player[num82];
				int team = player12.team;
				player12.team = num83;
				Color color2 = Main.teamColor[num83];
				if (Main.netMode != 2)
				{
					break;
				}
				NetMessage.SendData(45, -1, whoAmI, "", num82);
				string text6 = " " + Lang.mp[13 + num83];
				for (int num84 = 0; num84 < 255; num84++)
				{
					if (num84 == whoAmI || (team > 0 && Main.player[num84].team == team) || (num83 > 0 && Main.player[num84].team == num83))
					{
						NetMessage.SendData(25, num84, -1, player12.name + text6, 255, (int)color2.R, (int)color2.G, (int)color2.B);
					}
				}
				break;
			}
			case 46:
				if (Main.netMode == 2)
				{
					int i3 = reader.ReadInt16();
					int j2 = reader.ReadInt16();
					int num69 = Sign.ReadSign(i3, j2);
					if (num69 >= 0)
					{
						NetMessage.SendData(47, whoAmI, -1, "", num69);
					}
				}
				break;
			case 47:
			{
				int num62 = reader.ReadInt16();
				int x3 = reader.ReadInt16();
				int y3 = reader.ReadInt16();
				string text4 = reader.ReadString();
				Main.sign[num62] = new Sign();
				Main.sign[num62].x = x3;
				Main.sign[num62].y = y3;
				Sign.TextSign(num62, text4);
				if (Main.netMode == 1 && Main.sign[num62] != null)
				{
					Main.playerInventory = false;
					Main.player[Main.myPlayer].talkNPC = -1;
					Main.npcChatCornerItem = 0;
					Main.editSign = false;
					Main.PlaySound(10);
					Main.player[Main.myPlayer].sign = num62;
					Main.npcChatText = Main.sign[num62].text;
				}
				break;
			}
			case 48:
			{
				int num31 = reader.ReadInt16();
				int num32 = reader.ReadInt16();
				byte liquid = reader.ReadByte();
				byte liquidType = reader.ReadByte();
				if (Main.netMode == 2 && Netplay.spamCheck)
				{
					int num33 = whoAmI;
					int num34 = (int)(Main.player[num33].position.X + (float)(Main.player[num33].width / 2));
					int num35 = (int)(Main.player[num33].position.Y + (float)(Main.player[num33].height / 2));
					int num36 = 10;
					int num37 = num34 - num36;
					int num38 = num34 + num36;
					int num39 = num35 - num36;
					int num40 = num35 + num36;
					if (num31 < num37 || num31 > num38 || num32 < num39 || num32 > num40)
					{
						NetMessage.BootPlayer(whoAmI, "Cheating attempt detected: Liquid spam");
						break;
					}
				}
				if (Main.tile[num31, num32] == null)
				{
					Main.tile[num31, num32] = new Tile();
				}
				lock (Main.tile[num31, num32])
				{
					Main.tile[num31, num32].liquid = liquid;
					Main.tile[num31, num32].liquidType(liquidType);
					if (Main.netMode == 2)
					{
						WorldGen.SquareTileFrame(num31, num32);
					}
					break;
				}
			}
			case 49:
				if (Netplay.clientSock.state == 6)
				{
					Netplay.clientSock.state = 10;
					Main.player[Main.myPlayer].Spawn();
				}
				break;
			case 50:
			{
				int num10 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num10 = whoAmI;
				}
				else if (num10 == Main.myPlayer && !Main.ServerSideCharacter)
				{
					break;
				}
				Player player3 = Main.player[num10];
				for (int num11 = 0; num11 < 22; num11++)
				{
					player3.buffType[num11] = reader.ReadByte();
					if (player3.buffType[num11] > 0)
					{
						player3.buffTime[num11] = 60;
					}
					else
					{
						player3.buffTime[num11] = 0;
					}
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(50, -1, whoAmI, "", num10);
				}
				break;
			}
			case 51:
			{
				byte b2 = reader.ReadByte();
				byte b3 = reader.ReadByte();
				switch (b3)
				{
				case 1:
					NPC.SpawnSkeletron();
					break;
				case 2:
					if (Main.netMode == 2)
					{
						NetMessage.SendData(51, -1, whoAmI, "", b2, (int)b3);
					}
					else
					{
						Main.PlaySound(2, (int)Main.player[b2].position.X, (int)Main.player[b2].position.Y);
					}
					break;
				}
				break;
			}
			case 52:
			{
				int number2 = reader.ReadByte();
				int num153 = reader.ReadByte();
				int num154 = reader.ReadInt16();
				int num155 = reader.ReadInt16();
				if (num153 == 1)
				{
					Chest.Unlock(num154, num155);
					if (Main.netMode == 2)
					{
						NetMessage.SendData(52, -1, whoAmI, "", number2, num153, num154, num155);
						NetMessage.SendTileSquare(-1, num154, num155, 2);
					}
				}
				if (num153 == 2)
				{
					WorldGen.UnlockDoor(num154, num155);
					if (Main.netMode == 2)
					{
						NetMessage.SendData(52, -1, whoAmI, "", number2, num153, num154, num155);
						NetMessage.SendTileSquare(-1, num154, num155, 2);
					}
				}
				break;
			}
			case 53:
			{
				int num150 = reader.ReadInt16();
				int type5 = reader.ReadByte();
				int time = reader.ReadInt16();
				Main.npc[num150].AddBuff(type5, time, true);
				if (Main.netMode == 2)
				{
					NetMessage.SendData(54, -1, -1, "", num150);
				}
				break;
			}
			case 54:
				if (Main.netMode == 1)
				{
					int num145 = reader.ReadInt16();
					NPC nPC2 = Main.npc[num145];
					for (int num146 = 0; num146 < 5; num146++)
					{
						nPC2.buffType[num146] = reader.ReadByte();
						nPC2.buffTime[num146] = reader.ReadInt16();
					}
				}
				break;
			case 55:
			{
				int num118 = reader.ReadByte();
				int num119 = reader.ReadByte();
				int num120 = reader.ReadInt16();
				if (Main.netMode != 2 || num118 == whoAmI || Main.pvpBuff[num119])
				{
					if (Main.netMode == 1 && num118 == Main.myPlayer)
					{
						Main.player[num118].AddBuff(num119, num120);
					}
					else if (Main.netMode == 2)
					{
						NetMessage.SendData(55, num118, -1, "", num118, num119, num120);
					}
				}
				break;
			}
			case 56:
			{
				int num85 = reader.ReadInt16();
				if (num85 >= 0 && num85 < 200)
				{
					if (Main.netMode == 1)
					{
						Main.npc[num85].displayName = reader.ReadString();
					}
					else if (Main.netMode == 2)
					{
						NetMessage.SendData(56, whoAmI, -1, Main.npc[num85].displayName, num85);
					}
				}
				break;
			}
			case 57:
				if (Main.netMode == 1)
				{
					WorldGen.tGood = reader.ReadByte();
					WorldGen.tEvil = reader.ReadByte();
					WorldGen.tBlood = reader.ReadByte();
				}
				break;
			case 58:
			{
				int num67 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num67 = whoAmI;
				}
				float num68 = reader.ReadSingle();
				if (Main.netMode == 2)
				{
					NetMessage.SendData(58, -1, whoAmI, "", whoAmI, num68);
					break;
				}
				Player player11 = Main.player[num67];
				Main.harpNote = num68;
				int style2 = 26;
				if (player11.inventory[player11.selectedItem].type == 507)
				{
					style2 = 35;
				}
				Main.PlaySound(2, (int)player11.position.X, (int)player11.position.Y, style2);
				break;
			}
			case 59:
			{
				int num65 = reader.ReadInt16();
				int num66 = reader.ReadInt16();
				Wiring.hitSwitch(num65, num66);
				if (Main.netMode == 2)
				{
					NetMessage.SendData(59, -1, whoAmI, "", num65, num66);
				}
				break;
			}
			case 60:
			{
				int num45 = reader.ReadInt16();
				int num46 = reader.ReadInt16();
				int num47 = reader.ReadInt16();
				byte b5 = reader.ReadByte();
				if (num45 >= 200)
				{
					NetMessage.BootPlayer(whoAmI, "cheating attempt detected: Invalid kick-out");
				}
				else if (Main.netMode == 1)
				{
					Main.npc[num45].homeless = b5 == 1;
					Main.npc[num45].homeTileX = num46;
					Main.npc[num45].homeTileY = num47;
				}
				else if (b5 == 0)
				{
					WorldGen.kickOut(num45);
				}
				else
				{
					WorldGen.moveRoom(num46, num47, num45);
				}
				break;
			}
			case 61:
			{
				int plr = reader.ReadInt32();
				int num147 = reader.ReadInt32();
				if (Main.netMode != 2)
				{
					break;
				}
				if (num147 == 4 || num147 == 13 || num147 == 50 || num147 == 125 || num147 == 126 || num147 == 134 || num147 == 127 || num147 == 128 || num147 == 222 || num147 == 245 || num147 == 266 || num147 == 370)
				{
					if (!NPC.AnyNPCs(num147))
					{
						NPC.SpawnOnPlayer(plr, num147);
					}
				}
				else if (num147 == -4)
				{
					if (!Main.dayTime)
					{
						NetMessage.SendData(25, -1, -1, Lang.misc[31], 255, 50f, 255f, 130f);
						Main.startPumpkinMoon();
						NetMessage.SendData(7);
					}
				}
				else if (num147 == -5)
				{
					if (!Main.dayTime)
					{
						NetMessage.SendData(25, -1, -1, Lang.misc[34], 255, 50f, 255f, 130f);
						Main.startSnowMoon();
						NetMessage.SendData(7);
					}
				}
				else if (num147 < 0)
				{
					int num148 = 1;
					if (num147 > -4)
					{
						num148 = -num147;
					}
					if (num148 > 0 && Main.invasionType == 0)
					{
						Main.invasionDelay = 0;
						Main.StartInvasion(num148);
					}
				}
				break;
			}
			case 62:
			{
				int num125 = reader.ReadByte();
				int num126 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num125 = whoAmI;
				}
				if (num126 == 1)
				{
					Main.player[num125].NinjaDodge();
				}
				if (num126 == 2)
				{
					Main.player[num125].ShadowDodge();
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(62, -1, whoAmI, "", num125, num126);
				}
				break;
			}
			case 63:
			{
				int num121 = reader.ReadInt16();
				int num122 = reader.ReadInt16();
				byte b12 = reader.ReadByte();
				WorldGen.paintTile(num121, num122, b12);
				if (Main.netMode == 2)
				{
					NetMessage.SendData(63, -1, whoAmI, "", num121, num122, (int)b12);
				}
				break;
			}
			case 64:
			{
				int num116 = reader.ReadInt16();
				int num117 = reader.ReadInt16();
				byte b11 = reader.ReadByte();
				WorldGen.paintWall(num116, num117, b11);
				if (Main.netMode == 2)
				{
					NetMessage.SendData(64, -1, whoAmI, "", num116, num117, (int)b11);
				}
				break;
			}
			case 65:
			{
				BitsByte bitsByte10 = reader.ReadByte();
				int num70 = reader.ReadInt16();
				if (Main.netMode == 2)
				{
					num70 = whoAmI;
				}
				Vector2 newPos = reader.ReadVector2();
				int num71 = 0;
				int num72 = 0;
				if (bitsByte10[0])
				{
					num71++;
				}
				if (bitsByte10[1])
				{
					num71 += 2;
				}
				if (bitsByte10[2])
				{
					num72++;
				}
				if (bitsByte10[3])
				{
					num72++;
				}
				switch (num71)
				{
				case 0:
					Main.player[num70].Teleport(newPos, num72);
					break;
				case 1:
					Main.npc[num70].Teleport(newPos, num72);
					break;
				}
				if (Main.netMode == 2 && num71 == 0)
				{
					NetMessage.SendData(65, -1, whoAmI, "", 0, num70, newPos.X, newPos.Y, num72);
				}
				break;
			}
			case 66:
			{
				int num63 = reader.ReadByte();
				int num64 = reader.ReadInt16();
				if (num64 > 0)
				{
					Player player10 = Main.player[num63];
					player10.statLife += num64;
					if (player10.statLife > player10.statLifeMax2)
					{
						player10.statLife = player10.statLifeMax2;
					}
					player10.HealEffect(num64, false);
					if (Main.netMode == 2)
					{
						NetMessage.SendData(66, -1, whoAmI, "", num63, num64);
					}
				}
				break;
			}
			case 68:
				reader.ReadString();
				break;
			case 69:
			{
				int num28 = reader.ReadInt16();
				int num29 = reader.ReadInt16();
				int num30 = reader.ReadInt16();
				if (Main.netMode == 1)
				{
					if (num28 >= 0 && num28 < 1000)
					{
						Chest chest3 = Main.chest[num28];
						if (chest3 == null)
						{
							chest3 = new Chest();
							chest3.x = num29;
							chest3.y = num30;
							Main.chest[num28] = chest3;
						}
						else if (chest3.x != num29 || chest3.y != num30)
						{
							break;
						}
						chest3.name = reader.ReadString();
					}
				}
				else
				{
					if (num28 < -1 || num28 >= 1000)
					{
						break;
					}
					if (num28 == -1)
					{
						num28 = Chest.FindChest(num29, num30);
						if (num28 == -1)
						{
							break;
						}
					}
					Chest chest4 = Main.chest[num28];
					if (chest4.x == num29 && chest4.y == num30)
					{
						NetMessage.SendData(69, whoAmI, -1, chest4.name, num28, num29, num30);
					}
				}
				break;
			}
			case 70:
				if (Main.netMode == 2)
				{
					int i2 = reader.ReadInt16();
					int who = reader.ReadByte();
					if (Main.netMode == 2)
					{
						who = whoAmI;
					}
					NPC.CatchNPC(i2, who);
				}
				break;
			case 71:
				if (Main.netMode == 2)
				{
					int x = reader.ReadInt32();
					int y = reader.ReadInt32();
					int type = reader.ReadInt16();
					byte style = reader.ReadByte();
					NPC.ReleaseNPC(x, y, type, style, whoAmI);
				}
				break;
			case 72:
				if (Main.netMode == 1)
				{
					for (int num17 = 0; num17 < Chest.maxItems; num17++)
					{
						Main.travelShop[num17] = reader.ReadInt16();
					}
				}
				break;
			case 73:
				Main.player[whoAmI].TeleportationPotion();
				break;
			case 74:
				if (Main.netMode == 1)
				{
					Main.anglerQuest = reader.ReadByte();
					Main.anglerQuestFinished = reader.ReadBoolean();
				}
				break;
			case 75:
				if (Main.netMode == 2)
				{
					string name = Main.player[whoAmI].name;
					if (!Main.anglerWhoFinishedToday.Contains(name))
					{
						Main.anglerWhoFinishedToday.Add(name);
					}
				}
				break;
			case 76:
			{
				int num2 = reader.ReadByte();
				if (num2 != Main.myPlayer || Main.ServerSideCharacter)
				{
					if (Main.netMode == 2)
					{
						num2 = whoAmI;
					}
					Player player = Main.player[num2];
					player.anglerQuestsFinished = reader.ReadInt32();
					if (Main.netMode == 2)
					{
						NetMessage.SendData(76, -1, whoAmI, "", num2);
					}
				}
				break;
			}
			case 15:
			case 67:
				break;
			}
		}
	}
}
