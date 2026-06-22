using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Net;
using Terraria.UI;

namespace Terraria
{
	public class MessageBuffer
	{
		public const int readBufferMax = 131070;

		public const int writeBufferMax = 131070;

		public bool broadcast;

		public byte[] readBuffer = new byte[131070];

		public byte[] writeBuffer = new byte[131070];

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

		public static event TileChangeReceivedEvent OnTileChangeReceived;

		public void Reset()
		{
			Array.Clear(readBuffer, 0, readBuffer.Length);
			Array.Clear(writeBuffer, 0, writeBuffer.Length);
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

		public void GetData(int start, int length, out int messageType)
		{
			if (whoAmI < 256)
			{
				Netplay.Clients[whoAmI].TimeOutTimer = 0;
			}
			else
			{
				Netplay.Connection.TimeOutTimer = 0;
			}
			byte b = 0;
			int num = 0;
			num = start + 1;
			b = (byte)(messageType = readBuffer[start]);
			if (b >= 120)
			{
				return;
			}
			Main.rxMsg++;
			Main.rxData += length;
			Main.rxMsgType[b]++;
			Main.rxDataType[b] += length;
			if (Main.netMode == 1 && Netplay.Connection.StatusMax > 0)
			{
				Netplay.Connection.StatusCount++;
			}
			if (Main.verboseNetplay)
			{
				for (int i = start; i < start + length; i++)
				{
				}
				for (int j = start; j < start + length; j++)
				{
					_ = readBuffer[j];
				}
			}
			if (Main.netMode == 2 && b != 38 && Netplay.Clients[whoAmI].State == -1)
			{
				NetMessage.SendData(2, whoAmI, -1, Lang.mp[1].ToNetworkText());
				return;
			}
			if (Main.netMode == 2 && Netplay.Clients[whoAmI].State < 10 && b > 12 && b != 93 && b != 16 && b != 42 && b != 50 && b != 38 && b != 68)
			{
				NetMessage.BootPlayer(whoAmI, Lang.mp[2].ToNetworkText());
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
				if (Main.dedServ && Netplay.IsBanned(Netplay.Clients[whoAmI].Socket.GetRemoteAddress()))
				{
					NetMessage.SendData(2, whoAmI, -1, Lang.mp[3].ToNetworkText());
				}
				else
				{
					if (Netplay.Clients[whoAmI].State != 0)
					{
						break;
					}
					if (reader.ReadString() == "Terraria" + 194)
					{
						if (string.IsNullOrEmpty(Netplay.ServerPassword))
						{
							Netplay.Clients[whoAmI].State = 1;
							NetMessage.SendData(3, whoAmI);
						}
						else
						{
							Netplay.Clients[whoAmI].State = -1;
							NetMessage.SendData(37, whoAmI);
						}
					}
					else
					{
						NetMessage.SendData(2, whoAmI, -1, Lang.mp[4].ToNetworkText());
					}
				}
				break;
			case 2:
				if (Main.netMode == 1)
				{
					Netplay.disconnect = true;
					Main.statusText = NetworkText.Deserialize(reader).ToString();
				}
				break;
			case 3:
				if (Main.netMode == 1)
				{
					if (Netplay.Connection.State == 1)
					{
						Netplay.Connection.State = 2;
					}
					int num112 = reader.ReadByte();
					if (num112 != Main.myPlayer)
					{
						Main.player[num112] = Main.ActivePlayerFileData.Player;
						Main.player[Main.myPlayer] = new Player();
					}
					Main.player[num112].whoAmI = num112;
					Main.myPlayer = num112;
					Player player10 = Main.player[num112];
					NetMessage.SendData(4, -1, -1, null, num112);
					NetMessage.SendData(68, -1, -1, null, num112);
					NetMessage.SendData(16, -1, -1, null, num112);
					NetMessage.SendData(42, -1, -1, null, num112);
					NetMessage.SendData(50, -1, -1, null, num112);
					for (int num113 = 0; num113 < 59; num113++)
					{
						NetMessage.SendData(5, -1, -1, null, num112, num113, (int)player10.inventory[num113].prefix);
					}
					for (int num114 = 0; num114 < player10.armor.Length; num114++)
					{
						NetMessage.SendData(5, -1, -1, null, num112, 59 + num114, (int)player10.armor[num114].prefix);
					}
					for (int num115 = 0; num115 < player10.dye.Length; num115++)
					{
						NetMessage.SendData(5, -1, -1, null, num112, 58 + player10.armor.Length + 1 + num115, (int)player10.dye[num115].prefix);
					}
					for (int num116 = 0; num116 < player10.miscEquips.Length; num116++)
					{
						NetMessage.SendData(5, -1, -1, null, num112, 58 + player10.armor.Length + player10.dye.Length + 1 + num116, (int)player10.miscEquips[num116].prefix);
					}
					for (int num117 = 0; num117 < player10.miscDyes.Length; num117++)
					{
						NetMessage.SendData(5, -1, -1, null, num112, 58 + player10.armor.Length + player10.dye.Length + player10.miscEquips.Length + 1 + num117, (int)player10.miscDyes[num117].prefix);
					}
					for (int num118 = 0; num118 < player10.bank.item.Length; num118++)
					{
						NetMessage.SendData(5, -1, -1, null, num112, 58 + player10.armor.Length + player10.dye.Length + player10.miscEquips.Length + player10.miscDyes.Length + 1 + num118, (int)player10.bank.item[num118].prefix);
					}
					for (int num119 = 0; num119 < player10.bank2.item.Length; num119++)
					{
						NetMessage.SendData(5, -1, -1, null, num112, 58 + player10.armor.Length + player10.dye.Length + player10.miscEquips.Length + player10.miscDyes.Length + player10.bank.item.Length + 1 + num119, (int)player10.bank2.item[num119].prefix);
					}
					NetMessage.SendData(5, -1, -1, null, num112, 58 + player10.armor.Length + player10.dye.Length + player10.miscEquips.Length + player10.miscDyes.Length + player10.bank.item.Length + player10.bank2.item.Length + 1, (int)player10.trashItem.prefix);
					for (int num120 = 0; num120 < player10.bank3.item.Length; num120++)
					{
						NetMessage.SendData(5, -1, -1, null, num112, 58 + player10.armor.Length + player10.dye.Length + player10.miscEquips.Length + player10.miscDyes.Length + player10.bank.item.Length + player10.bank2.item.Length + 2 + num120, (int)player10.bank3.item[num120].prefix);
					}
					NetMessage.SendData(6);
					if (Netplay.Connection.State == 2)
					{
						Netplay.Connection.State = 3;
					}
				}
				break;
			case 4:
			{
				int num87 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num87 = whoAmI;
				}
				if (num87 == Main.myPlayer && !Main.ServerSideCharacter)
				{
					break;
				}
				Player player7 = Main.player[num87];
				player7.whoAmI = num87;
				player7.skinVariant = reader.ReadByte();
				player7.skinVariant = (int)MathHelper.Clamp(player7.skinVariant, 0f, 9f);
				player7.hair = reader.ReadByte();
				if (player7.hair >= 134)
				{
					player7.hair = 0;
				}
				player7.name = reader.ReadString().Trim().Trim();
				player7.hairDye = reader.ReadByte();
				BitsByte bitsByte12 = reader.ReadByte();
				for (int num88 = 0; num88 < 8; num88++)
				{
					player7.hideVisual[num88] = bitsByte12[num88];
				}
				bitsByte12 = reader.ReadByte();
				for (int num89 = 0; num89 < 2; num89++)
				{
					player7.hideVisual[num89 + 8] = bitsByte12[num89];
				}
				player7.hideMisc = reader.ReadByte();
				player7.hairColor = reader.ReadRGB();
				player7.skinColor = reader.ReadRGB();
				player7.eyeColor = reader.ReadRGB();
				player7.shirtColor = reader.ReadRGB();
				player7.underShirtColor = reader.ReadRGB();
				player7.pantsColor = reader.ReadRGB();
				player7.shoeColor = reader.ReadRGB();
				BitsByte bitsByte13 = reader.ReadByte();
				player7.difficulty = 0;
				if (bitsByte13[0])
				{
					player7.difficulty++;
				}
				if (bitsByte13[1])
				{
					player7.difficulty += 2;
				}
				if (player7.difficulty > 2)
				{
					player7.difficulty = 2;
				}
				player7.extraAccessory = bitsByte13[2];
				if (Main.netMode != 2)
				{
					break;
				}
				bool flag7 = false;
				if (Netplay.Clients[whoAmI].State < 10)
				{
					for (int num90 = 0; num90 < 255; num90++)
					{
						if (num90 != num87 && player7.name == Main.player[num90].name && Netplay.Clients[num90].IsActive)
						{
							flag7 = true;
						}
					}
				}
				if (flag7)
				{
					NetMessage.SendData(2, whoAmI, -1, NetworkText.FromFormattable("{0} {1}", player7.name, Lang.mp[5].ToNetworkText()));
				}
				else if (player7.name.Length > Player.nameLen)
				{
					NetMessage.SendData(2, whoAmI, -1, NetworkText.FromKey("Net.NameTooLong"));
				}
				else if (player7.name == "")
				{
					NetMessage.SendData(2, whoAmI, -1, NetworkText.FromKey("Net.EmptyName"));
				}
				else
				{
					Netplay.Clients[whoAmI].Name = player7.name;
					Netplay.Clients[whoAmI].Name = player7.name;
					NetMessage.SendData(4, -1, whoAmI, null, num87);
				}
				break;
			}
			case 5:
			{
				int num213 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num213 = whoAmI;
				}
				if (num213 == Main.myPlayer && !Main.ServerSideCharacter && !Main.player[num213].IsStackingItems())
				{
					break;
				}
				Player player14 = Main.player[num213];
				lock (player14)
				{
					int num214 = reader.ReadByte();
					int stack4 = reader.ReadInt16();
					int num215 = reader.ReadByte();
					int type13 = reader.ReadInt16();
					Item[] array3 = null;
					int num216 = 0;
					bool flag10 = false;
					if (num214 > 58 + player14.armor.Length + player14.dye.Length + player14.miscEquips.Length + player14.miscDyes.Length + player14.bank.item.Length + player14.bank2.item.Length + 1)
					{
						num216 = num214 - 58 - (player14.armor.Length + player14.dye.Length + player14.miscEquips.Length + player14.miscDyes.Length + player14.bank.item.Length + player14.bank2.item.Length + 1) - 1;
						array3 = player14.bank3.item;
					}
					else if (num214 > 58 + player14.armor.Length + player14.dye.Length + player14.miscEquips.Length + player14.miscDyes.Length + player14.bank.item.Length + player14.bank2.item.Length)
					{
						flag10 = true;
					}
					else if (num214 > 58 + player14.armor.Length + player14.dye.Length + player14.miscEquips.Length + player14.miscDyes.Length + player14.bank.item.Length)
					{
						num216 = num214 - 58 - (player14.armor.Length + player14.dye.Length + player14.miscEquips.Length + player14.miscDyes.Length + player14.bank.item.Length) - 1;
						array3 = player14.bank2.item;
					}
					else if (num214 > 58 + player14.armor.Length + player14.dye.Length + player14.miscEquips.Length + player14.miscDyes.Length)
					{
						num216 = num214 - 58 - (player14.armor.Length + player14.dye.Length + player14.miscEquips.Length + player14.miscDyes.Length) - 1;
						array3 = player14.bank.item;
					}
					else if (num214 > 58 + player14.armor.Length + player14.dye.Length + player14.miscEquips.Length)
					{
						num216 = num214 - 58 - (player14.armor.Length + player14.dye.Length + player14.miscEquips.Length) - 1;
						array3 = player14.miscDyes;
					}
					else if (num214 > 58 + player14.armor.Length + player14.dye.Length)
					{
						num216 = num214 - 58 - (player14.armor.Length + player14.dye.Length) - 1;
						array3 = player14.miscEquips;
					}
					else if (num214 > 58 + player14.armor.Length)
					{
						num216 = num214 - 58 - player14.armor.Length - 1;
						array3 = player14.dye;
					}
					else if (num214 > 58)
					{
						num216 = num214 - 58 - 1;
						array3 = player14.armor;
					}
					else
					{
						num216 = num214;
						array3 = player14.inventory;
					}
					if (flag10)
					{
						player14.trashItem = new Item();
						player14.trashItem.netDefaults(type13);
						player14.trashItem.stack = stack4;
						player14.trashItem.Prefix(num215);
					}
					else if (num214 <= 58)
					{
						int type14 = array3[num216].type;
						int stack5 = array3[num216].stack;
						array3[num216] = new Item();
						array3[num216].netDefaults(type13);
						array3[num216].stack = stack4;
						array3[num216].Prefix(num215);
						if (num213 == Main.myPlayer && num216 == 58)
						{
							Main.mouseItem = array3[num216].Clone();
						}
						if (num213 == Main.myPlayer && Main.netMode == 1)
						{
							Main.player[num213].inventoryChestStack[num214] = false;
							if (array3[num216].stack != stack5 || array3[num216].type != type14)
							{
								Recipe.FindRecipes();
								Main.PlaySound(7);
							}
						}
					}
					else
					{
						array3[num216] = new Item();
						array3[num216].netDefaults(type13);
						array3[num216].stack = stack4;
						array3[num216].Prefix(num215);
					}
					if (Main.netMode == 2 && num213 == whoAmI && num214 <= 58 + player14.armor.Length + player14.dye.Length + player14.miscEquips.Length + player14.miscDyes.Length)
					{
						NetMessage.SendData(5, -1, whoAmI, null, num213, num214, num215);
					}
					break;
				}
			}
			case 6:
				if (Main.netMode == 2)
				{
					if (Netplay.Clients[whoAmI].State == 1)
					{
						Netplay.Clients[whoAmI].State = 2;
					}
					NetMessage.SendData(7, whoAmI);
					Main.SyncAnInvasion(whoAmI);
				}
				break;
			case 7:
				if (Main.netMode == 1)
				{
					Main.time = reader.ReadInt32();
					BitsByte bitsByte = reader.ReadByte();
					Main.dayTime = bitsByte[0];
					Main.bloodMoon = bitsByte[1];
					Main.eclipse = bitsByte[2];
					Main.moonPhase = reader.ReadByte();
					Main.maxTilesX = reader.ReadInt16();
					Main.maxTilesY = reader.ReadInt16();
					Main.spawnTileX = reader.ReadInt16();
					Main.spawnTileY = reader.ReadInt16();
					Main.worldSurface = reader.ReadInt16();
					Main.rockLayer = reader.ReadInt16();
					Main.worldID = reader.ReadInt32();
					Main.worldName = reader.ReadString();
					Main.ActiveWorldFileData.UniqueId = new Guid(reader.ReadBytes(16));
					Main.ActiveWorldFileData.WorldGeneratorVersion = reader.ReadUInt64();
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
					for (int l = 0; l < 3; l++)
					{
						Main.treeX[l] = reader.ReadInt32();
					}
					for (int m = 0; m < 4; m++)
					{
						Main.treeStyle[m] = reader.ReadByte();
					}
					for (int n = 0; n < 3; n++)
					{
						Main.caveBackX[n] = reader.ReadInt32();
					}
					for (int num5 = 0; num5 < 4; num5++)
					{
						Main.caveBackStyle[num5] = reader.ReadByte();
					}
					Main.maxRaining = reader.ReadSingle();
					Main.raining = Main.maxRaining > 0f;
					BitsByte bitsByte2 = reader.ReadByte();
					WorldGen.shadowOrbSmashed = bitsByte2[0];
					NPC.downedBoss1 = bitsByte2[1];
					NPC.downedBoss2 = bitsByte2[2];
					NPC.downedBoss3 = bitsByte2[3];
					Main.hardMode = bitsByte2[4];
					NPC.downedClown = bitsByte2[5];
					Main.ServerSideCharacter = bitsByte2[6];
					NPC.downedPlantBoss = bitsByte2[7];
					BitsByte bitsByte3 = reader.ReadByte();
					NPC.downedMechBoss1 = bitsByte3[0];
					NPC.downedMechBoss2 = bitsByte3[1];
					NPC.downedMechBoss3 = bitsByte3[2];
					NPC.downedMechBossAny = bitsByte3[3];
					Main.cloudBGActive = (bitsByte3[4] ? 1 : 0);
					WorldGen.crimson = bitsByte3[5];
					Main.pumpkinMoon = bitsByte3[6];
					Main.snowMoon = bitsByte3[7];
					BitsByte bitsByte4 = reader.ReadByte();
					Main.expertMode = bitsByte4[0];
					Main.fastForwardTime = bitsByte4[1];
					Main.UpdateSundial();
					bool num6 = bitsByte4[2];
					NPC.downedSlimeKing = bitsByte4[3];
					NPC.downedQueenBee = bitsByte4[4];
					NPC.downedFishron = bitsByte4[5];
					NPC.downedMartians = bitsByte4[6];
					NPC.downedAncientCultist = bitsByte4[7];
					BitsByte bitsByte5 = reader.ReadByte();
					NPC.downedMoonlord = bitsByte5[0];
					NPC.downedHalloweenKing = bitsByte5[1];
					NPC.downedHalloweenTree = bitsByte5[2];
					NPC.downedChristmasIceQueen = bitsByte5[3];
					NPC.downedChristmasSantank = bitsByte5[4];
					NPC.downedChristmasTree = bitsByte5[5];
					NPC.downedGolemBoss = bitsByte5[6];
					BirthdayParty.ManualParty = bitsByte5[7];
					BitsByte bitsByte6 = reader.ReadByte();
					NPC.downedPirates = bitsByte6[0];
					NPC.downedFrost = bitsByte6[1];
					NPC.downedGoblins = bitsByte6[2];
					Sandstorm.Happening = bitsByte6[3];
					DD2Event.Ongoing = bitsByte6[4];
					DD2Event.DownedInvasionT1 = bitsByte6[5];
					DD2Event.DownedInvasionT2 = bitsByte6[6];
					DD2Event.DownedInvasionT3 = bitsByte6[7];
					if (num6)
					{
						Main.StartSlimeRain();
					}
					else
					{
						Main.StopSlimeRain();
					}
					Main.invasionType = reader.ReadSByte();
					Main.LobbyId = reader.ReadUInt64();
					Sandstorm.IntendedSeverity = reader.ReadSingle();
					if (Netplay.Connection.State == 3)
					{
						Netplay.Connection.State = 4;
					}
				}
				break;
			case 8:
			{
				if (Main.netMode != 2)
				{
					break;
				}
				int num153 = reader.ReadInt32();
				int num154 = reader.ReadInt32();
				bool flag8 = true;
				if (num153 == -1 || num154 == -1)
				{
					flag8 = false;
				}
				else if (num153 < 10 || num153 > Main.maxTilesX - 10)
				{
					flag8 = false;
				}
				else if (num154 < 10 || num154 > Main.maxTilesY - 10)
				{
					flag8 = false;
				}
				int num155 = Netplay.GetSectionX(Main.spawnTileX) - 2;
				int num156 = Netplay.GetSectionY(Main.spawnTileY) - 1;
				int num157 = num155 + 5;
				int num158 = num156 + 3;
				if (num155 < 0)
				{
					num155 = 0;
				}
				if (num157 >= Main.maxSectionsX)
				{
					num157 = Main.maxSectionsX - 1;
				}
				if (num156 < 0)
				{
					num156 = 0;
				}
				if (num158 >= Main.maxSectionsY)
				{
					num158 = Main.maxSectionsY - 1;
				}
				int num159 = (num157 - num155) * (num158 - num156);
				List<Point> list = new List<Point>();
				for (int num160 = num155; num160 < num157; num160++)
				{
					for (int num161 = num156; num161 < num158; num161++)
					{
						list.Add(new Point(num160, num161));
					}
				}
				int num162 = -1;
				int num163 = -1;
				if (flag8)
				{
					num153 = Netplay.GetSectionX(num153) - 2;
					num154 = Netplay.GetSectionY(num154) - 1;
					num162 = num153 + 5;
					num163 = num154 + 3;
					if (num153 < 0)
					{
						num153 = 0;
					}
					if (num162 >= Main.maxSectionsX)
					{
						num162 = Main.maxSectionsX - 1;
					}
					if (num154 < 0)
					{
						num154 = 0;
					}
					if (num163 >= Main.maxSectionsY)
					{
						num163 = Main.maxSectionsY - 1;
					}
					for (int num164 = num153; num164 < num162; num164++)
					{
						for (int num165 = num154; num165 < num163; num165++)
						{
							if (num164 < num155 || num164 >= num157 || num165 < num156 || num165 >= num158)
							{
								list.Add(new Point(num164, num165));
								num159++;
							}
						}
					}
				}
				int num166 = 1;
				PortalHelper.SyncPortalsOnPlayerJoin(whoAmI, 1, list, out var portals, out var portalCenters);
				num159 += portals.Count;
				if (Netplay.Clients[whoAmI].State == 2)
				{
					Netplay.Clients[whoAmI].State = 3;
				}
				NetMessage.SendData(9, whoAmI, -1, Lang.inter[44].ToNetworkText(), num159);
				Netplay.Clients[whoAmI].StatusText2 = Language.GetTextValue("Net.IsReceivingTileData");
				Netplay.Clients[whoAmI].StatusMax += num159;
				for (int num167 = num155; num167 < num157; num167++)
				{
					for (int num168 = num156; num168 < num158; num168++)
					{
						NetMessage.SendSection(whoAmI, num167, num168);
					}
				}
				NetMessage.SendData(11, whoAmI, -1, null, num155, num156, num157 - 1, num158 - 1);
				if (flag8)
				{
					for (int num169 = num153; num169 < num162; num169++)
					{
						for (int num170 = num154; num170 < num163; num170++)
						{
							NetMessage.SendSection(whoAmI, num169, num170, skipSent: true);
						}
					}
					NetMessage.SendData(11, whoAmI, -1, null, num153, num154, num162 - 1, num163 - 1);
				}
				for (int num171 = 0; num171 < portals.Count; num171++)
				{
					NetMessage.SendSection(whoAmI, portals[num171].X, portals[num171].Y, skipSent: true);
				}
				for (int num172 = 0; num172 < portalCenters.Count; num172++)
				{
					NetMessage.SendData(11, whoAmI, -1, null, portalCenters[num172].X - num166, portalCenters[num172].Y - num166, portalCenters[num172].X + num166 + 1, portalCenters[num172].Y + num166 + 1);
				}
				for (int num173 = 0; num173 < 400; num173++)
				{
					if (Main.item[num173].active)
					{
						NetMessage.SendData(21, whoAmI, -1, null, num173);
						NetMessage.SendData(22, whoAmI, -1, null, num173);
					}
				}
				for (int num174 = 0; num174 < 200; num174++)
				{
					if (Main.npc[num174].active)
					{
						NetMessage.SendData(23, whoAmI, -1, null, num174);
					}
				}
				for (int num175 = 0; num175 < 1000; num175++)
				{
					if (Main.projectile[num175].active && (Main.projPet[Main.projectile[num175].type] || Main.projectile[num175].netImportant))
					{
						NetMessage.SendData(27, whoAmI, -1, null, num175);
					}
				}
				for (int num176 = 0; num176 < 267; num176++)
				{
					NetMessage.SendData(83, whoAmI, -1, null, num176);
				}
				NetMessage.SendData(49, whoAmI);
				NetMessage.SendData(57, whoAmI);
				NetMessage.SendData(7, whoAmI);
				NetMessage.SendData(103, -1, -1, null, NPC.MoonLordCountdown);
				NetMessage.SendData(101, whoAmI);
				break;
			}
			case 9:
				if (Main.netMode == 1)
				{
					Netplay.Connection.StatusMax += reader.ReadInt32();
					Netplay.Connection.StatusText = NetworkText.Deserialize(reader).ToString();
				}
				break;
			case 10:
				if (Main.netMode == 1)
				{
					NetMessage.DecompressTileBlock(readBuffer, num, length);
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
				int num183 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num183 = whoAmI;
				}
				Player obj3 = Main.player[num183];
				obj3.SpawnX = reader.ReadInt16();
				obj3.SpawnY = reader.ReadInt16();
				obj3.Spawn();
				if (num183 == Main.myPlayer && Main.netMode != 2)
				{
					Main.ActivePlayerFileData.StartPlayTimer();
					Player.Hooks.EnterWorld(Main.myPlayer);
				}
				if (Main.netMode == 2 && Netplay.Clients[whoAmI].State >= 3)
				{
					if (Netplay.Clients[whoAmI].State == 3)
					{
						Netplay.Clients[whoAmI].State = 10;
						NetMessage.greetPlayer(whoAmI);
						NetMessage.buffer[whoAmI].broadcast = true;
						NetMessage.SyncConnectedPlayer(whoAmI);
						NetMessage.SendData(12, -1, whoAmI, null, whoAmI);
						NetMessage.SendData(74, whoAmI, -1, NetworkText.FromLiteral(Main.player[whoAmI].name), Main.anglerQuest);
					}
					else
					{
						NetMessage.SendData(12, -1, whoAmI, null, whoAmI);
					}
				}
				break;
			}
			case 13:
			{
				int num184 = reader.ReadByte();
				if (num184 != Main.myPlayer || Main.ServerSideCharacter)
				{
					if (Main.netMode == 2)
					{
						num184 = whoAmI;
					}
					Player player12 = Main.player[num184];
					BitsByte bitsByte16 = reader.ReadByte();
					player12.controlUp = bitsByte16[0];
					player12.controlDown = bitsByte16[1];
					player12.controlLeft = bitsByte16[2];
					player12.controlRight = bitsByte16[3];
					player12.controlJump = bitsByte16[4];
					player12.controlUseItem = bitsByte16[5];
					player12.direction = (bitsByte16[6] ? 1 : (-1));
					BitsByte bitsByte17 = reader.ReadByte();
					if (bitsByte17[0])
					{
						player12.pulley = true;
						player12.pulleyDir = (byte)((!bitsByte17[1]) ? 1u : 2u);
					}
					else
					{
						player12.pulley = false;
					}
					player12.selectedItem = reader.ReadByte();
					player12.position = reader.ReadVector2();
					if (bitsByte17[2])
					{
						player12.velocity = reader.ReadVector2();
					}
					else
					{
						player12.velocity = Vector2.Zero;
					}
					player12.vortexStealthActive = bitsByte17[3];
					player12.gravDir = (bitsByte17[4] ? 1 : (-1));
					if (Main.netMode == 2 && Netplay.Clients[whoAmI].State == 10)
					{
						NetMessage.SendData(13, -1, whoAmI, null, num184);
					}
				}
				break;
			}
			case 14:
			{
				int num53 = reader.ReadByte();
				int num54 = reader.ReadByte();
				if (Main.netMode != 1)
				{
					break;
				}
				bool active = Main.player[num53].active;
				if (num54 == 1)
				{
					if (!Main.player[num53].active)
					{
						Main.player[num53] = new Player();
					}
					Main.player[num53].active = true;
				}
				else
				{
					Main.player[num53].active = false;
				}
				if (active != Main.player[num53].active)
				{
					if (Main.player[num53].active)
					{
						Player.Hooks.PlayerConnect(num53);
					}
					else
					{
						Player.Hooks.PlayerDisconnect(num53);
					}
				}
				break;
			}
			case 16:
			{
				int num30 = reader.ReadByte();
				if (num30 != Main.myPlayer || Main.ServerSideCharacter)
				{
					if (Main.netMode == 2)
					{
						num30 = whoAmI;
					}
					Player player = Main.player[num30];
					player.statLife = reader.ReadInt16();
					player.statLifeMax = reader.ReadInt16();
					if (player.statLifeMax < 100)
					{
						player.statLifeMax = 100;
					}
					player.dead = player.statLife <= 0;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(16, -1, whoAmI, null, num30);
					}
				}
				break;
			}
			case 17:
			{
				byte b3 = reader.ReadByte();
				int num26 = reader.ReadInt16();
				int num27 = reader.ReadInt16();
				short num28 = reader.ReadInt16();
				int num29 = reader.ReadByte();
				bool flag2 = num28 == 1;
				if (!WorldGen.InWorld(num26, num27, 3))
				{
					break;
				}
				if (Main.tile[num26, num27] == null)
				{
					Main.tile[num26, num27] = new Tile();
				}
				if (Main.netMode == 2)
				{
					if (!flag2)
					{
						if (b3 == 0 || b3 == 2 || b3 == 4)
						{
							Netplay.Clients[whoAmI].SpamDeleteBlock += 1f;
						}
						if (b3 == 1 || b3 == 3)
						{
							Netplay.Clients[whoAmI].SpamAddBlock += 1f;
						}
					}
					if (!Netplay.Clients[whoAmI].TileSections[Netplay.GetSectionX(num26), Netplay.GetSectionY(num27)])
					{
						flag2 = true;
					}
				}
				if (b3 == 0)
				{
					WorldGen.KillTile(num26, num27, flag2);
				}
				if (b3 == 1)
				{
					WorldGen.PlaceTile(num26, num27, num28, mute: false, forced: true, -1, num29);
				}
				if (b3 == 2)
				{
					WorldGen.KillWall(num26, num27, flag2);
				}
				if (b3 == 3)
				{
					WorldGen.PlaceWall(num26, num27, num28);
				}
				if (b3 == 4)
				{
					WorldGen.KillTile(num26, num27, flag2, effectOnly: false, noItem: true);
				}
				if (b3 == 5)
				{
					WorldGen.PlaceWire(num26, num27);
				}
				if (b3 == 6)
				{
					WorldGen.KillWire(num26, num27);
				}
				if (b3 == 7)
				{
					WorldGen.PoundTile(num26, num27);
				}
				if (b3 == 8)
				{
					WorldGen.PlaceActuator(num26, num27);
				}
				if (b3 == 9)
				{
					WorldGen.KillActuator(num26, num27);
				}
				if (b3 == 10)
				{
					WorldGen.PlaceWire2(num26, num27);
				}
				if (b3 == 11)
				{
					WorldGen.KillWire2(num26, num27);
				}
				if (b3 == 12)
				{
					WorldGen.PlaceWire3(num26, num27);
				}
				if (b3 == 13)
				{
					WorldGen.KillWire3(num26, num27);
				}
				if (b3 == 14)
				{
					WorldGen.SlopeTile(num26, num27, num28);
				}
				if (b3 == 15)
				{
					Minecart.FrameTrack(num26, num27, pound: true);
				}
				if (b3 == 16)
				{
					WorldGen.PlaceWire4(num26, num27);
				}
				if (b3 == 17)
				{
					WorldGen.KillWire4(num26, num27);
				}
				switch (b3)
				{
				case 18:
					Wiring.SetCurrentUser(whoAmI);
					Wiring.PokeLogicGate(num26, num27);
					Wiring.SetCurrentUser();
					break;
				case 19:
					Wiring.SetCurrentUser(whoAmI);
					Wiring.Actuate(num26, num27);
					Wiring.SetCurrentUser();
					break;
				default:
					if (Main.netMode == 2)
					{
						NetMessage.SendData(17, -1, whoAmI, null, b3, num26, num27, num28, num29);
						if (b3 == 1 && num28 == 53)
						{
							NetMessage.SendTileSquare(-1, num26, num27, 1);
						}
					}
					break;
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
				byte b6 = reader.ReadByte();
				int num45 = reader.ReadInt16();
				int num46 = reader.ReadInt16();
				if (WorldGen.InWorld(num45, num46, 3))
				{
					int num47 = ((reader.ReadByte() != 0) ? 1 : (-1));
					switch (b6)
					{
					case 0:
						WorldGen.OpenDoor(num45, num46, num47);
						break;
					case 1:
						WorldGen.CloseDoor(num45, num46, forced: true);
						break;
					case 2:
						WorldGen.ShiftTrapdoor(num45, num46, num47 == 1, 1);
						break;
					case 3:
						WorldGen.ShiftTrapdoor(num45, num46, num47 == 1, 0);
						break;
					case 4:
						WorldGen.ShiftTallGate(num45, num46, closing: false);
						break;
					case 5:
						WorldGen.ShiftTallGate(num45, num46, closing: true);
						break;
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData(19, -1, whoAmI, null, b6, num45, num46, (num47 == 1) ? 1 : 0);
					}
				}
				break;
			}
			case 20:
			{
				ushort num56 = reader.ReadUInt16();
				short num57 = (short)(num56 & 0x7FFF);
				bool num58 = (num56 & 0x8000) != 0;
				byte b7 = 0;
				if (num58)
				{
					b7 = reader.ReadByte();
				}
				int num59 = reader.ReadInt16();
				int num60 = reader.ReadInt16();
				if (!WorldGen.InWorld(num59, num60, 3))
				{
					break;
				}
				TileChangeType type4 = TileChangeType.None;
				if (Enum.IsDefined(typeof(TileChangeType), b7))
				{
					type4 = (TileChangeType)b7;
				}
				if (MessageBuffer.OnTileChangeReceived != null)
				{
					MessageBuffer.OnTileChangeReceived(num59, num60, num57, type4);
				}
				BitsByte bitsByte8 = (byte)0;
				BitsByte bitsByte9 = (byte)0;
				Tile tile4 = null;
				for (int num61 = num59; num61 < num59 + num57; num61++)
				{
					for (int num62 = num60; num62 < num60 + num57; num62++)
					{
						if (Main.tile[num61, num62] == null)
						{
							Main.tile[num61, num62] = new Tile();
						}
						tile4 = Main.tile[num61, num62];
						bool flag4 = tile4.active();
						bitsByte8 = reader.ReadByte();
						bitsByte9 = reader.ReadByte();
						tile4.active(bitsByte8[0]);
						tile4.wall = (byte)(bitsByte8[2] ? 1u : 0u);
						bool flag5 = bitsByte8[3];
						if (Main.netMode != 2)
						{
							tile4.liquid = (byte)(flag5 ? 1u : 0u);
						}
						tile4.wire(bitsByte8[4]);
						tile4.halfBrick(bitsByte8[5]);
						tile4.actuator(bitsByte8[6]);
						tile4.inActive(bitsByte8[7]);
						tile4.wire2(bitsByte9[0]);
						tile4.wire3(bitsByte9[1]);
						if (bitsByte9[2])
						{
							tile4.color(reader.ReadByte());
						}
						if (bitsByte9[3])
						{
							tile4.wallColor(reader.ReadByte());
						}
						if (tile4.active())
						{
							int type5 = tile4.type;
							tile4.type = reader.ReadUInt16();
							if (Main.tileFrameImportant[tile4.type])
							{
								tile4.frameX = reader.ReadInt16();
								tile4.frameY = reader.ReadInt16();
							}
							else if (!flag4 || tile4.type != type5)
							{
								tile4.frameX = -1;
								tile4.frameY = -1;
							}
							byte b8 = 0;
							if (bitsByte9[4])
							{
								b8++;
							}
							if (bitsByte9[5])
							{
								b8 += 2;
							}
							if (bitsByte9[6])
							{
								b8 += 4;
							}
							tile4.slope(b8);
						}
						tile4.wire4(bitsByte9[7]);
						if (tile4.wall > 0)
						{
							tile4.wall = reader.ReadByte();
						}
						if (flag5)
						{
							tile4.liquid = reader.ReadByte();
							tile4.liquidType(reader.ReadByte());
						}
					}
				}
				WorldGen.RangeFrame(num59, num60, num59 + num57, num60 + num57);
				if (Main.netMode == 2)
				{
					NetMessage.SendData(b, -1, whoAmI, null, num57, num59, num60);
				}
				break;
			}
			case 21:
			case 90:
			{
				int num193 = reader.ReadInt16();
				Vector2 position3 = reader.ReadVector2();
				Vector2 velocity5 = reader.ReadVector2();
				int stack2 = reader.ReadInt16();
				int pre2 = reader.ReadByte();
				int num194 = reader.ReadByte();
				int num195 = reader.ReadInt16();
				if (Main.netMode == 1)
				{
					if (num195 == 0)
					{
						Main.item[num193].active = false;
						break;
					}
					int num196 = num193;
					Item item2 = Main.item[num196];
					bool newAndShiny = (item2.newAndShiny || item2.netID != num195) && ItemSlot.Options.HighlightNewItems && (num195 < 0 || num195 >= 3930 || !ItemID.Sets.NeverShiny[num195]);
					item2.netDefaults(num195);
					item2.newAndShiny = newAndShiny;
					item2.Prefix(pre2);
					item2.stack = stack2;
					item2.position = position3;
					item2.velocity = velocity5;
					item2.active = true;
					if (b == 90)
					{
						item2.instanced = true;
						item2.owner = Main.myPlayer;
						item2.keepTime = 600;
					}
					item2.wet = Collision.WetCollision(item2.position, item2.width, item2.height);
				}
				else
				{
					if (Main.itemLockoutTime[num193] > 0)
					{
						break;
					}
					if (num195 == 0)
					{
						if (num193 < 400)
						{
							Main.item[num193].active = false;
							NetMessage.SendData(21, -1, -1, null, num193);
						}
						break;
					}
					bool flag9 = false;
					if (num193 == 400)
					{
						flag9 = true;
					}
					if (flag9)
					{
						Item item3 = new Item();
						item3.netDefaults(num195);
						num193 = Item.NewItem((int)position3.X, (int)position3.Y, item3.width, item3.height, item3.type, stack2, noBroadcast: true);
					}
					Item obj6 = Main.item[num193];
					obj6.netDefaults(num195);
					obj6.Prefix(pre2);
					obj6.stack = stack2;
					obj6.position = position3;
					obj6.velocity = velocity5;
					obj6.active = true;
					obj6.owner = Main.myPlayer;
					if (flag9)
					{
						NetMessage.SendData(21, -1, -1, null, num193);
						if (num194 == 0)
						{
							Main.item[num193].ownIgnore = whoAmI;
							Main.item[num193].ownTime = 100;
						}
						Main.item[num193].FindOwner(num193);
					}
					else
					{
						NetMessage.SendData(21, -1, whoAmI, null, num193);
					}
				}
				break;
			}
			case 22:
			{
				int num110 = reader.ReadInt16();
				int num111 = reader.ReadByte();
				if (Main.netMode != 2 || Main.item[num110].owner == whoAmI)
				{
					Main.item[num110].owner = num111;
					if (num111 == Main.myPlayer)
					{
						Main.item[num110].keepTime = 15;
					}
					else
					{
						Main.item[num110].keepTime = 0;
					}
					if (Main.netMode == 2)
					{
						Main.item[num110].owner = 255;
						Main.item[num110].keepTime = 15;
						NetMessage.SendData(22, -1, -1, null, num110);
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
				int num103 = reader.ReadInt16();
				Vector2 vector3 = reader.ReadVector2();
				Vector2 velocity2 = reader.ReadVector2();
				int num104 = reader.ReadUInt16();
				if (num104 == 65535)
				{
					num104 = 0;
				}
				BitsByte bitsByte14 = reader.ReadByte();
				float[] array2 = new float[NPC.maxAI];
				for (int num105 = 0; num105 < NPC.maxAI; num105++)
				{
					if (bitsByte14[num105 + 2])
					{
						array2[num105] = reader.ReadSingle();
					}
					else
					{
						array2[num105] = 0f;
					}
				}
				int num106 = reader.ReadInt16();
				int num107 = 0;
				if (!bitsByte14[7])
				{
					switch (reader.ReadByte())
					{
					case 2:
						num107 = reader.ReadInt16();
						break;
					case 4:
						num107 = reader.ReadInt32();
						break;
					default:
						num107 = reader.ReadSByte();
						break;
					}
				}
				int num108 = -1;
				NPC nPC = Main.npc[num103];
				if (!nPC.active || nPC.netID != num106)
				{
					if (nPC.active)
					{
						num108 = nPC.type;
					}
					nPC.active = true;
					nPC.SetDefaults(num106);
				}
				if (Vector2.DistanceSquared(nPC.position, vector3) < 6400f)
				{
					nPC.visualOffset = nPC.position - vector3;
				}
				nPC.position = vector3;
				nPC.velocity = velocity2;
				nPC.target = num104;
				nPC.direction = (bitsByte14[0] ? 1 : (-1));
				nPC.directionY = (bitsByte14[1] ? 1 : (-1));
				nPC.spriteDirection = (bitsByte14[6] ? 1 : (-1));
				if (bitsByte14[7])
				{
					num107 = (nPC.life = nPC.lifeMax);
				}
				else
				{
					nPC.life = num107;
				}
				if (num107 <= 0)
				{
					nPC.active = false;
				}
				for (int num109 = 0; num109 < NPC.maxAI; num109++)
				{
					nPC.ai[num109] = array2[num109];
				}
				if (num108 > -1 && num108 != nPC.type)
				{
					nPC.TransformVisuals(num108, nPC.type);
				}
				if (num106 == 262)
				{
					NPC.plantBoss = num103;
				}
				if (num106 == 245)
				{
					NPC.golemBoss = num103;
				}
				if (nPC.type >= 0 && nPC.type < 580 && Main.npcCatchable[nPC.type])
				{
					nPC.releaseOwner = reader.ReadByte();
				}
				break;
			}
			case 24:
			{
				int num188 = reader.ReadInt16();
				int num189 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num189 = whoAmI;
				}
				Player player13 = Main.player[num189];
				Main.npc[num188].StrikeNPC(player13.inventory[player13.selectedItem].damage, player13.inventory[player13.selectedItem].knockBack, player13.direction);
				if (Main.netMode == 2)
				{
					NetMessage.SendData(24, -1, whoAmI, null, num188, num189);
					NetMessage.SendData(23, -1, -1, null, num188);
				}
				break;
			}
			case 27:
			{
				int num75 = reader.ReadInt16();
				Vector2 position = reader.ReadVector2();
				Vector2 velocity = reader.ReadVector2();
				float knockBack2 = reader.ReadSingle();
				int damage3 = reader.ReadInt16();
				int num76 = reader.ReadByte();
				int num77 = reader.ReadInt16();
				BitsByte bitsByte10 = reader.ReadByte();
				float[] array = new float[Projectile.maxAI];
				for (int num78 = 0; num78 < Projectile.maxAI; num78++)
				{
					if (bitsByte10[num78])
					{
						array[num78] = reader.ReadSingle();
					}
					else
					{
						array[num78] = 0f;
					}
				}
				int num79 = (bitsByte10[Projectile.maxAI] ? reader.ReadInt16() : (-1));
				if (num79 >= 1000)
				{
					num79 = -1;
				}
				if (Main.netMode == 2)
				{
					num76 = whoAmI;
					if (Main.projHostile[num77])
					{
						break;
					}
				}
				int num80 = 1000;
				for (int num81 = 0; num81 < 1000; num81++)
				{
					if (Main.projectile[num81].owner == num76 && Main.projectile[num81].identity == num75 && Main.projectile[num81].active)
					{
						num80 = num81;
						break;
					}
				}
				if (num80 == 1000)
				{
					for (int num82 = 0; num82 < 1000; num82++)
					{
						if (!Main.projectile[num82].active)
						{
							num80 = num82;
							break;
						}
					}
				}
				Projectile projectile = Main.projectile[num80];
				if (!projectile.active || projectile.type != num77)
				{
					projectile.SetDefaults(num77);
					if (Main.netMode == 2)
					{
						Netplay.Clients[whoAmI].SpamProjectile += 1f;
					}
				}
				projectile.identity = num75;
				projectile.position = position;
				projectile.velocity = velocity;
				projectile.type = num77;
				projectile.damage = damage3;
				projectile.knockBack = knockBack2;
				projectile.owner = num76;
				for (int num83 = 0; num83 < Projectile.maxAI; num83++)
				{
					projectile.ai[num83] = array[num83];
				}
				if (num79 >= 0)
				{
					projectile.projUUID = num79;
					Main.projectileIdentity[num76, num79] = num80;
				}
				projectile.ProjectileFixDesperation();
				if (Main.netMode == 2)
				{
					NetMessage.SendData(27, -1, whoAmI, null, num80);
				}
				break;
			}
			case 28:
			{
				int num142 = reader.ReadInt16();
				int num143 = reader.ReadInt16();
				float num144 = reader.ReadSingle();
				int num145 = reader.ReadByte() - 1;
				byte b12 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					if (num143 < 0)
					{
						num143 = 0;
					}
					Main.npc[num142].PlayerInteraction(whoAmI);
				}
				if (num143 >= 0)
				{
					Main.npc[num142].StrikeNPC(num143, num144, num145, b12 == 1, noEffect: false, fromNet: true);
				}
				else
				{
					Main.npc[num142].life = 0;
					Main.npc[num142].HitEffect();
					Main.npc[num142].active = false;
				}
				if (Main.netMode != 2)
				{
					break;
				}
				NetMessage.SendData(28, -1, whoAmI, null, num142, num143, num144, num145, b12);
				if (Main.npc[num142].life <= 0)
				{
					NetMessage.SendData(23, -1, -1, null, num142);
				}
				else
				{
					Main.npc[num142].netUpdate = true;
				}
				if (Main.npc[num142].realLife >= 0)
				{
					if (Main.npc[Main.npc[num142].realLife].life <= 0)
					{
						NetMessage.SendData(23, -1, -1, null, Main.npc[num142].realLife);
					}
					else
					{
						Main.npc[Main.npc[num142].realLife].netUpdate = true;
					}
				}
				break;
			}
			case 29:
			{
				int num134 = reader.ReadInt16();
				int num135 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num135 = whoAmI;
				}
				for (int num136 = 0; num136 < 1000; num136++)
				{
					if (Main.projectile[num136].owner == num135 && Main.projectile[num136].identity == num134 && Main.projectile[num136].active)
					{
						Main.projectile[num136].Kill();
						break;
					}
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(29, -1, whoAmI, null, num134, num135);
				}
				break;
			}
			case 30:
			{
				int num40 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num40 = whoAmI;
				}
				bool flag3 = reader.ReadBoolean();
				Main.player[num40].hostile = flag3;
				if (Main.netMode == 2)
				{
					NetMessage.SendData(30, -1, whoAmI, null, num40);
					LocalizedText obj = (flag3 ? Lang.mp[11] : Lang.mp[12]);
					NetMessage.BroadcastChatMessage(color: Main.teamColor[Main.player[num40].team], text: NetworkText.FromKey(obj.Key, Main.player[num40].name));
				}
				break;
			}
			case 31:
			{
				if (Main.netMode != 2)
				{
					break;
				}
				short x2 = reader.ReadInt16();
				int y2 = reader.ReadInt16();
				int num12 = Chest.FindChest(x2, y2);
				if (num12 > -1 && Chest.UsingChest(num12) == -1)
				{
					for (int num13 = 0; num13 < 40; num13++)
					{
						NetMessage.SendData(32, whoAmI, -1, null, num12, num13);
					}
					NetMessage.SendData(33, whoAmI, -1, null, num12);
					Main.player[whoAmI].chest = num12;
					if (Main.myPlayer == whoAmI)
					{
						Main.recBigList = false;
					}
					NetMessage.SendData(80, -1, whoAmI, null, whoAmI, num12);
				}
				break;
			}
			case 32:
			{
				int num204 = reader.ReadInt16();
				int num205 = reader.ReadByte();
				int stack3 = reader.ReadInt16();
				int pre3 = reader.ReadByte();
				int type12 = reader.ReadInt16();
				if (Main.chest[num204] == null)
				{
					Main.chest[num204] = new Chest();
				}
				if (Main.chest[num204].item[num205] == null)
				{
					Main.chest[num204].item[num205] = new Item();
				}
				Main.chest[num204].item[num205].netDefaults(type12);
				Main.chest[num204].item[num205].Prefix(pre3);
				Main.chest[num204].item[num205].stack = stack3;
				Recipe.FindRecipes();
				break;
			}
			case 33:
			{
				int num41 = reader.ReadInt16();
				int num42 = reader.ReadInt16();
				int num43 = reader.ReadInt16();
				int num44 = reader.ReadByte();
				string name = string.Empty;
				if (num44 != 0)
				{
					if (num44 <= 20)
					{
						name = reader.ReadString();
					}
					else if (num44 != 255)
					{
						num44 = 0;
					}
				}
				if (Main.netMode == 1)
				{
					Player player2 = Main.player[Main.myPlayer];
					if (player2.chest == -1)
					{
						Main.playerInventory = true;
						Main.PlaySound(10);
					}
					else if (player2.chest != num41 && num41 != -1)
					{
						Main.playerInventory = true;
						Main.PlaySound(12);
						Main.recBigList = false;
					}
					else if (player2.chest != -1 && num41 == -1)
					{
						Main.PlaySound(11);
						Main.recBigList = false;
					}
					player2.chest = num41;
					player2.chestX = num42;
					player2.chestY = num43;
					Recipe.FindRecipes();
					if (Main.tile[num42, num43].frameX >= 36 && Main.tile[num42, num43].frameX < 72)
					{
						AchievementsHelper.HandleSpecialEvent(Main.player[Main.myPlayer], 16);
					}
				}
				else
				{
					if (num44 != 0)
					{
						int chest3 = Main.player[whoAmI].chest;
						Chest chest4 = Main.chest[chest3];
						chest4.name = name;
						NetMessage.SendData(69, -1, whoAmI, null, chest3, chest4.x, chest4.y);
					}
					Main.player[whoAmI].chest = num41;
					Recipe.FindRecipes();
					NetMessage.SendData(80, -1, whoAmI, null, whoAmI, num41);
				}
				break;
			}
			case 34:
			{
				byte b2 = reader.ReadByte();
				int num19 = reader.ReadInt16();
				int num20 = reader.ReadInt16();
				int num21 = reader.ReadInt16();
				int num22 = reader.ReadInt16();
				if (Main.netMode == 2)
				{
					num22 = 0;
				}
				if (Main.netMode == 2)
				{
					switch (b2)
					{
					case 0:
					{
						int num25 = WorldGen.PlaceChest(num19, num20, 21, notNearOtherChests: false, num21);
						if (num25 == -1)
						{
							NetMessage.SendData(34, whoAmI, -1, null, b2, num19, num20, num21, num25);
							Item.NewItem(num19 * 16, num20 * 16, 32, 32, Chest.chestItemSpawn[num21], 1, noBroadcast: true);
						}
						else
						{
							NetMessage.SendData(34, -1, -1, null, b2, num19, num20, num21, num25);
						}
						break;
					}
					case 1:
						if (Main.tile[num19, num20].type == 21)
						{
							Tile tile = Main.tile[num19, num20];
							if (tile.frameX % 36 != 0)
							{
								num19--;
							}
							if (tile.frameY % 36 != 0)
							{
								num20--;
							}
							int number = Chest.FindChest(num19, num20);
							WorldGen.KillTile(num19, num20);
							if (!tile.active())
							{
								NetMessage.SendData(34, -1, -1, null, b2, num19, num20, 0f, number);
							}
							break;
						}
						goto default;
					default:
						switch (b2)
						{
						case 2:
						{
							int num23 = WorldGen.PlaceChest(num19, num20, 88, notNearOtherChests: false, num21);
							if (num23 == -1)
							{
								NetMessage.SendData(34, whoAmI, -1, null, b2, num19, num20, num21, num23);
								Item.NewItem(num19 * 16, num20 * 16, 32, 32, Chest.dresserItemSpawn[num21], 1, noBroadcast: true);
							}
							else
							{
								NetMessage.SendData(34, -1, -1, null, b2, num19, num20, num21, num23);
							}
							break;
						}
						case 3:
							if (Main.tile[num19, num20].type == 88)
							{
								Tile tile2 = Main.tile[num19, num20];
								num19 -= tile2.frameX % 54 / 18;
								if (tile2.frameY % 36 != 0)
								{
									num20--;
								}
								int number2 = Chest.FindChest(num19, num20);
								WorldGen.KillTile(num19, num20);
								if (!tile2.active())
								{
									NetMessage.SendData(34, -1, -1, null, b2, num19, num20, 0f, number2);
								}
								break;
							}
							goto default;
						default:
							switch (b2)
							{
							case 4:
							{
								int num24 = WorldGen.PlaceChest(num19, num20, 467, notNearOtherChests: false, num21);
								if (num24 == -1)
								{
									NetMessage.SendData(34, whoAmI, -1, null, b2, num19, num20, num21, num24);
									Item.NewItem(num19 * 16, num20 * 16, 32, 32, Chest.chestItemSpawn2[num21], 1, noBroadcast: true);
								}
								else
								{
									NetMessage.SendData(34, -1, -1, null, b2, num19, num20, num21, num24);
								}
								break;
							}
							case 5:
								if (Main.tile[num19, num20].type == 467)
								{
									Tile tile3 = Main.tile[num19, num20];
									if (tile3.frameX % 36 != 0)
									{
										num19--;
									}
									if (tile3.frameY % 36 != 0)
									{
										num20--;
									}
									int number3 = Chest.FindChest(num19, num20);
									WorldGen.KillTile(num19, num20);
									if (!tile3.active())
									{
										NetMessage.SendData(34, -1, -1, null, b2, num19, num20, 0f, number3);
									}
								}
								break;
							}
							break;
						}
						break;
					}
					break;
				}
				switch (b2)
				{
				case 0:
					if (num22 == -1)
					{
						WorldGen.KillTile(num19, num20);
					}
					else
					{
						WorldGen.PlaceChestDirect(num19, num20, 21, num21, num22);
					}
					break;
				case 2:
					if (num22 == -1)
					{
						WorldGen.KillTile(num19, num20);
					}
					else
					{
						WorldGen.PlaceDresserDirect(num19, num20, 88, num21, num22);
					}
					break;
				case 4:
					if (num22 == -1)
					{
						WorldGen.KillTile(num19, num20);
					}
					else
					{
						WorldGen.PlaceChestDirect(num19, num20, 467, num21, num22);
					}
					break;
				default:
					Chest.DestroyChestDirect(num19, num20, num22);
					WorldGen.KillTile(num19, num20);
					break;
				}
				break;
			}
			case 35:
			{
				int num217 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num217 = whoAmI;
				}
				int num218 = reader.ReadInt16();
				if (num217 != Main.myPlayer || Main.ServerSideCharacter)
				{
					Main.player[num217].HealEffect(num218);
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(35, -1, whoAmI, null, num217, num218);
				}
				break;
			}
			case 36:
			{
				int num192 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num192 = whoAmI;
				}
				Player obj5 = Main.player[num192];
				obj5.zone1 = reader.ReadByte();
				obj5.zone2 = reader.ReadByte();
				obj5.zone3 = reader.ReadByte();
				obj5.zone4 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					NetMessage.SendData(36, -1, whoAmI, null, num192);
				}
				break;
			}
			case 37:
				if (Main.netMode == 1)
				{
					if (Main.autoPass)
					{
						NetMessage.SendData(38);
						Main.autoPass = false;
					}
					else
					{
						Netplay.ServerPassword = "";
						Main.menuMode = 31;
					}
				}
				break;
			case 38:
				if (Main.netMode == 2)
				{
					if (reader.ReadString() == Netplay.ServerPassword)
					{
						Netplay.Clients[whoAmI].State = 1;
						NetMessage.SendData(3, whoAmI);
					}
					else
					{
						NetMessage.SendData(2, whoAmI, -1, Lang.mp[1].ToNetworkText());
					}
				}
				break;
			case 39:
				if (Main.netMode == 1)
				{
					int num127 = reader.ReadInt16();
					Main.item[num127].owner = 255;
					NetMessage.SendData(22, -1, -1, null, num127);
				}
				break;
			case 40:
			{
				int num133 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num133 = whoAmI;
				}
				int talkNPC = reader.ReadInt16();
				Main.player[num133].talkNPC = talkNPC;
				if (Main.netMode == 2)
				{
					NetMessage.SendData(40, -1, whoAmI, null, num133);
				}
				break;
			}
			case 41:
			{
				int num55 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num55 = whoAmI;
				}
				Player player5 = Main.player[num55];
				float itemRotation = reader.ReadSingle();
				int itemAnimation = reader.ReadInt16();
				player5.itemRotation = itemRotation;
				player5.itemAnimation = itemAnimation;
				player5.channel = player5.inventory[player5.selectedItem].channel;
				if (Main.netMode == 2)
				{
					NetMessage.SendData(41, -1, whoAmI, null, num55);
				}
				break;
			}
			case 42:
			{
				int num39 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num39 = whoAmI;
				}
				else if (Main.myPlayer == num39 && !Main.ServerSideCharacter)
				{
					break;
				}
				int statMana = reader.ReadInt16();
				int statManaMax = reader.ReadInt16();
				Main.player[num39].statMana = statMana;
				Main.player[num39].statManaMax = statManaMax;
				break;
			}
			case 43:
			{
				int num10 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num10 = whoAmI;
				}
				int num11 = reader.ReadInt16();
				if (num10 != Main.myPlayer)
				{
					Main.player[num10].ManaEffect(num11);
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(43, -1, whoAmI, null, num10, num11);
				}
				break;
			}
			case 45:
			{
				int num219 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num219 = whoAmI;
				}
				int num220 = reader.ReadByte();
				Player player15 = Main.player[num219];
				int team = player15.team;
				player15.team = num220;
				Color color = Main.teamColor[num220];
				if (Main.netMode != 2)
				{
					break;
				}
				NetMessage.SendData(45, -1, whoAmI, null, num219);
				LocalizedText localizedText = Lang.mp[13 + num220];
				if (num220 == 5)
				{
					localizedText = Lang.mp[22];
				}
				for (int num221 = 0; num221 < 255; num221++)
				{
					if (num221 == whoAmI || (team > 0 && Main.player[num221].team == team) || (num220 > 0 && Main.player[num221].team == num220))
					{
						NetMessage.SendChatMessageToClient(NetworkText.FromKey(localizedText.Key, player15.name), color, num221);
					}
				}
				break;
			}
			case 46:
				if (Main.netMode == 2)
				{
					short i3 = reader.ReadInt16();
					int j3 = reader.ReadInt16();
					int num187 = Sign.ReadSign(i3, j3);
					if (num187 >= 0)
					{
						NetMessage.SendData(47, whoAmI, -1, null, num187, whoAmI);
					}
				}
				break;
			case 47:
			{
				int num138 = reader.ReadInt16();
				int x8 = reader.ReadInt16();
				int y8 = reader.ReadInt16();
				string text2 = reader.ReadString();
				string text3 = null;
				if (Main.sign[num138] != null)
				{
					text3 = Main.sign[num138].text;
				}
				Main.sign[num138] = new Sign();
				Main.sign[num138].x = x8;
				Main.sign[num138].y = y8;
				Sign.TextSign(num138, text2);
				int num139 = reader.ReadByte();
				if (Main.netMode == 2 && text3 != text2)
				{
					num139 = whoAmI;
					NetMessage.SendData(47, -1, whoAmI, null, num138, num139);
				}
				if (Main.netMode == 1 && num139 == Main.myPlayer && Main.sign[num138] != null)
				{
					Main.playerInventory = false;
					Main.player[Main.myPlayer].talkNPC = -1;
					Main.npcChatCornerItem = 0;
					Main.editSign = false;
					Main.PlaySound(10);
					Main.player[Main.myPlayer].sign = num138;
					Main.npcChatText = Main.sign[num138].text;
				}
				break;
			}
			case 48:
			{
				int num65 = reader.ReadInt16();
				int num66 = reader.ReadInt16();
				byte liquid = reader.ReadByte();
				byte liquidType = reader.ReadByte();
				if (Main.netMode == 2 && Netplay.spamCheck)
				{
					int num67 = whoAmI;
					int num68 = (int)(Main.player[num67].position.X + (float)(Main.player[num67].width / 2));
					int num69 = (int)(Main.player[num67].position.Y + (float)(Main.player[num67].height / 2));
					int num70 = 10;
					int num71 = num68 - num70;
					int num72 = num68 + num70;
					int num73 = num69 - num70;
					int num74 = num69 + num70;
					if (num65 < num71 || num65 > num72 || num66 < num73 || num66 > num74)
					{
						NetMessage.BootPlayer(whoAmI, NetworkText.FromKey("Net.CheatingLiquidSpam"));
						break;
					}
				}
				if (Main.tile[num65, num66] == null)
				{
					Main.tile[num65, num66] = new Tile();
				}
				lock (Main.tile[num65, num66])
				{
					Main.tile[num65, num66].liquid = liquid;
					Main.tile[num65, num66].liquidType(liquidType);
					if (Main.netMode == 2)
					{
						WorldGen.SquareTileFrame(num65, num66);
					}
					break;
				}
			}
			case 49:
				if (Netplay.Connection.State == 6)
				{
					Netplay.Connection.State = 10;
					Main.ActivePlayerFileData.StartPlayTimer();
					Player.Hooks.EnterWorld(Main.myPlayer);
					Main.player[Main.myPlayer].Spawn();
				}
				break;
			case 50:
			{
				int num51 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num51 = whoAmI;
				}
				else if (num51 == Main.myPlayer && !Main.ServerSideCharacter)
				{
					break;
				}
				Player player4 = Main.player[num51];
				for (int num52 = 0; num52 < 22; num52++)
				{
					player4.buffType[num52] = reader.ReadByte();
					if (player4.buffType[num52] > 0)
					{
						player4.buffTime[num52] = 60;
					}
					else
					{
						player4.buffTime[num52] = 0;
					}
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(50, -1, whoAmI, null, num51);
				}
				break;
			}
			case 51:
			{
				byte b4 = reader.ReadByte();
				byte b5 = reader.ReadByte();
				switch (b5)
				{
				case 1:
					NPC.SpawnSkeletron();
					break;
				case 2:
					if (Main.netMode == 2)
					{
						NetMessage.SendData(51, -1, whoAmI, null, b4, (int)b5);
					}
					else
					{
						Main.PlaySound(SoundID.Item1, (int)Main.player[b4].position.X, (int)Main.player[b4].position.Y);
					}
					break;
				case 3:
					if (Main.netMode == 2)
					{
						Main.Sundialing();
					}
					break;
				case 4:
					Main.npc[b4].BigMimicSpawnSmoke();
					break;
				}
				break;
			}
			case 52:
			{
				int num15 = reader.ReadByte();
				int num16 = reader.ReadInt16();
				int num17 = reader.ReadInt16();
				if (num15 == 1)
				{
					Chest.Unlock(num16, num17);
					if (Main.netMode == 2)
					{
						NetMessage.SendData(52, -1, whoAmI, null, 0, num15, num16, num17);
						NetMessage.SendTileSquare(-1, num16, num17, 2);
					}
				}
				if (num15 == 2)
				{
					WorldGen.UnlockDoor(num16, num17);
					if (Main.netMode == 2)
					{
						NetMessage.SendData(52, -1, whoAmI, null, 0, num15, num16, num17);
						NetMessage.SendTileSquare(-1, num16, num17, 2);
					}
				}
				break;
			}
			case 53:
			{
				int num18 = reader.ReadInt16();
				int type2 = reader.ReadByte();
				int time = reader.ReadInt16();
				Main.npc[num18].AddBuff(type2, time, quiet: true);
				if (Main.netMode == 2)
				{
					NetMessage.SendData(54, -1, -1, null, num18);
				}
				break;
			}
			case 54:
				if (Main.netMode == 1)
				{
					int num223 = reader.ReadInt16();
					NPC nPC2 = Main.npc[num223];
					for (int num224 = 0; num224 < 5; num224++)
					{
						nPC2.buffType[num224] = reader.ReadByte();
						nPC2.buffTime[num224] = reader.ReadInt16();
					}
				}
				break;
			case 55:
			{
				int num206 = reader.ReadByte();
				int num207 = reader.ReadByte();
				int num208 = reader.ReadInt32();
				if (Main.netMode != 2 || num206 == whoAmI || Main.pvpBuff[num207])
				{
					if (Main.netMode == 1 && num206 == Main.myPlayer)
					{
						Main.player[num206].AddBuff(num207, num208);
					}
					else if (Main.netMode == 2)
					{
						NetMessage.SendData(55, num206, -1, null, num206, num207, num208);
					}
				}
				break;
			}
			case 56:
			{
				int num190 = reader.ReadInt16();
				if (num190 >= 0 && num190 < 200)
				{
					if (Main.netMode == 1)
					{
						string givenName = reader.ReadString();
						Main.npc[num190].GivenName = givenName;
					}
					else if (Main.netMode == 2)
					{
						NetMessage.SendData(56, whoAmI, -1, null, num190);
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
				int num131 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num131 = whoAmI;
				}
				float num132 = reader.ReadSingle();
				if (Main.netMode == 2)
				{
					NetMessage.SendData(58, -1, whoAmI, null, whoAmI, num132);
					break;
				}
				Player player11 = Main.player[num131];
				Main.harpNote = num132;
				LegacySoundStyle type9 = SoundID.Item26;
				if (player11.inventory[player11.selectedItem].type == 507)
				{
					type9 = SoundID.Item35;
				}
				Main.PlaySound(type9, player11.position);
				break;
			}
			case 59:
			{
				int num128 = reader.ReadInt16();
				int num129 = reader.ReadInt16();
				Wiring.SetCurrentUser(whoAmI);
				Wiring.HitSwitch(num128, num129);
				Wiring.SetCurrentUser();
				if (Main.netMode == 2)
				{
					NetMessage.SendData(59, -1, whoAmI, null, num128, num129);
				}
				break;
			}
			case 60:
			{
				int num91 = reader.ReadInt16();
				int num92 = reader.ReadInt16();
				int num93 = reader.ReadInt16();
				byte b9 = reader.ReadByte();
				if (num91 >= 200)
				{
					NetMessage.BootPlayer(whoAmI, NetworkText.FromKey("Net.CheatingInvalid"));
				}
				else if (Main.netMode == 1)
				{
					Main.npc[num91].homeless = b9 == 1;
					Main.npc[num91].homeTileX = num92;
					Main.npc[num91].homeTileY = num93;
					switch (b9)
					{
					case 1:
						WorldGen.TownManager.KickOut(Main.npc[num91].type);
						break;
					case 2:
						WorldGen.TownManager.SetRoom(Main.npc[num91].type, num92, num93);
						break;
					}
				}
				else if (b9 == 1)
				{
					WorldGen.kickOut(num91);
				}
				else
				{
					WorldGen.moveRoom(num92, num93, num91);
				}
				break;
			}
			case 61:
			{
				int plr = reader.ReadInt16();
				int num197 = reader.ReadInt16();
				if (Main.netMode != 2)
				{
					break;
				}
				if (num197 >= 0 && num197 < 580 && NPCID.Sets.MPAllowedEnemies[num197])
				{
					if (!NPC.AnyNPCs(num197))
					{
						NPC.SpawnOnPlayer(plr, num197);
					}
				}
				else if (num197 == -4)
				{
					if (!Main.dayTime && !DD2Event.Ongoing)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.misc[31].Key), new Color(50, 255, 130));
						Main.startPumpkinMoon();
						NetMessage.SendData(7);
						NetMessage.SendData(78, -1, -1, null, 0, 1f, 2f, 1f);
					}
				}
				else if (num197 == -5)
				{
					if (!Main.dayTime && !DD2Event.Ongoing)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.misc[34].Key), new Color(50, 255, 130));
						Main.startSnowMoon();
						NetMessage.SendData(7);
						NetMessage.SendData(78, -1, -1, null, 0, 1f, 1f, 1f);
					}
				}
				else if (num197 == -6)
				{
					if (Main.dayTime && !Main.eclipse)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.misc[20].Key), new Color(50, 255, 130));
						Main.eclipse = true;
						NetMessage.SendData(7);
					}
				}
				else if (num197 == -7)
				{
					Main.invasionDelay = 0;
					Main.StartInvasion(4);
					NetMessage.SendData(7);
					NetMessage.SendData(78, -1, -1, null, 0, 1f, Main.invasionType + 3);
				}
				else if (num197 == -8)
				{
					if (NPC.downedGolemBoss && Main.hardMode && !NPC.AnyDanger() && !NPC.AnyoneNearCultists())
					{
						WorldGen.StartImpendingDoom();
						NetMessage.SendData(7);
					}
				}
				else if (num197 < 0)
				{
					int num198 = 1;
					if (num197 > -5)
					{
						num198 = -num197;
					}
					if (num198 > 0 && Main.invasionType == 0)
					{
						Main.invasionDelay = 0;
						Main.StartInvasion(num198);
					}
					NetMessage.SendData(78, -1, -1, null, 0, 1f, Main.invasionType + 3);
				}
				break;
			}
			case 62:
			{
				int num180 = reader.ReadByte();
				int num181 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num180 = whoAmI;
				}
				if (num181 == 1)
				{
					Main.player[num180].NinjaDodge();
				}
				if (num181 == 2)
				{
					Main.player[num180].ShadowDodge();
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(62, -1, whoAmI, null, num180, num181);
				}
				break;
			}
			case 63:
			{
				int num177 = reader.ReadInt16();
				int num178 = reader.ReadInt16();
				byte b14 = reader.ReadByte();
				WorldGen.paintTile(num177, num178, b14);
				if (Main.netMode == 2)
				{
					NetMessage.SendData(63, -1, whoAmI, null, num177, num178, (int)b14);
				}
				break;
			}
			case 64:
			{
				int num148 = reader.ReadInt16();
				int num149 = reader.ReadInt16();
				byte b13 = reader.ReadByte();
				WorldGen.paintWall(num148, num149, b13);
				if (Main.netMode == 2)
				{
					NetMessage.SendData(64, -1, whoAmI, null, num148, num149, (int)b13);
				}
				break;
			}
			case 65:
			{
				BitsByte bitsByte15 = reader.ReadByte();
				int num121 = reader.ReadInt16();
				if (Main.netMode == 2)
				{
					num121 = whoAmI;
				}
				Vector2 vector4 = reader.ReadVector2();
				int num122 = 0;
				int num123 = 0;
				if (bitsByte15[0])
				{
					num122++;
				}
				if (bitsByte15[1])
				{
					num122 += 2;
				}
				if (bitsByte15[2])
				{
					num123++;
				}
				if (bitsByte15[3])
				{
					num123 += 2;
				}
				switch (num122)
				{
				case 0:
					Main.player[num121].Teleport(vector4, num123);
					break;
				case 1:
					Main.npc[num121].Teleport(vector4, num123);
					break;
				case 2:
				{
					Main.player[num121].Teleport(vector4, num123);
					if (Main.netMode != 2)
					{
						break;
					}
					RemoteClient.CheckSection(whoAmI, vector4);
					NetMessage.SendData(65, -1, -1, null, 0, num121, vector4.X, vector4.Y, num123);
					int num124 = -1;
					float num125 = 9999f;
					for (int num126 = 0; num126 < 255; num126++)
					{
						if (Main.player[num126].active && num126 != whoAmI)
						{
							Vector2 vector5 = Main.player[num126].position - Main.player[whoAmI].position;
							if (vector5.Length() < num125)
							{
								num125 = vector5.Length();
								num124 = num126;
							}
						}
					}
					if (num124 >= 0)
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey("Game.HasTeleportedTo", Main.player[whoAmI].name, Main.player[num124].name), new Color(250, 250, 0));
					}
					break;
				}
				}
				if (Main.netMode == 2 && num122 == 0)
				{
					NetMessage.SendData(65, -1, whoAmI, null, 0, num121, vector4.X, vector4.Y, num123);
				}
				break;
			}
			case 66:
			{
				int num84 = reader.ReadByte();
				int num85 = reader.ReadInt16();
				if (num85 > 0)
				{
					Player player6 = Main.player[num84];
					player6.statLife += num85;
					if (player6.statLife > player6.statLifeMax2)
					{
						player6.statLife = player6.statLifeMax2;
					}
					player6.HealEffect(num85, broadcast: false);
					if (Main.netMode == 2)
					{
						NetMessage.SendData(66, -1, whoAmI, null, num84, num85);
					}
				}
				break;
			}
			case 68:
				reader.ReadString();
				break;
			case 69:
			{
				int num31 = reader.ReadInt16();
				int num32 = reader.ReadInt16();
				int num33 = reader.ReadInt16();
				if (Main.netMode == 1)
				{
					if (num31 >= 0 && num31 < 1000)
					{
						Chest chest = Main.chest[num31];
						if (chest == null)
						{
							chest = new Chest();
							chest.x = num32;
							chest.y = num33;
							Main.chest[num31] = chest;
						}
						else if (chest.x != num32 || chest.y != num33)
						{
							break;
						}
						chest.name = reader.ReadString();
					}
				}
				else
				{
					if (num31 < -1 || num31 >= 1000)
					{
						break;
					}
					if (num31 == -1)
					{
						num31 = Chest.FindChest(num32, num33);
						if (num31 == -1)
						{
							break;
						}
					}
					Chest chest2 = Main.chest[num31];
					if (chest2.x == num32 && chest2.y == num33)
					{
						NetMessage.SendData(69, whoAmI, -1, null, num31, num32, num33);
					}
				}
				break;
			}
			case 70:
				if (Main.netMode == 2)
				{
					int num14 = reader.ReadInt16();
					int who = reader.ReadByte();
					if (Main.netMode == 2)
					{
						who = whoAmI;
					}
					if (num14 < 200 && num14 >= 0)
					{
						NPC.CatchNPC(num14, who);
					}
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
					for (int k = 0; k < 40; k++)
					{
						Main.travelShop[k] = reader.ReadInt16();
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
					string name2 = Main.player[whoAmI].name;
					if (!Main.anglerWhoFinishedToday.Contains(name2))
					{
						Main.anglerWhoFinishedToday.Add(name2);
					}
				}
				break;
			case 76:
			{
				int num203 = reader.ReadByte();
				if (num203 != Main.myPlayer || Main.ServerSideCharacter)
				{
					if (Main.netMode == 2)
					{
						num203 = whoAmI;
					}
					Main.player[num203].anglerQuestsFinished = reader.ReadInt32();
					if (Main.netMode == 2)
					{
						NetMessage.SendData(76, -1, whoAmI, null, num203);
					}
				}
				break;
			}
			case 77:
			{
				short type11 = reader.ReadInt16();
				ushort tileType = reader.ReadUInt16();
				short x12 = reader.ReadInt16();
				short y12 = reader.ReadInt16();
				Animation.NewTemporaryAnimation(type11, tileType, x12, y12);
				break;
			}
			case 78:
				if (Main.netMode == 1)
				{
					Main.ReportInvasionProgress(reader.ReadInt32(), reader.ReadInt32(), reader.ReadSByte(), reader.ReadSByte());
				}
				break;
			case 79:
			{
				int x11 = reader.ReadInt16();
				int y11 = reader.ReadInt16();
				short type10 = reader.ReadInt16();
				int style2 = reader.ReadInt16();
				int num182 = reader.ReadByte();
				int random = reader.ReadSByte();
				int direction = (reader.ReadBoolean() ? 1 : (-1));
				if (Main.netMode == 2)
				{
					Netplay.Clients[whoAmI].SpamAddBlock += 1f;
					if (!WorldGen.InWorld(x11, y11, 10) || !Netplay.Clients[whoAmI].TileSections[Netplay.GetSectionX(x11), Netplay.GetSectionY(y11)])
					{
						break;
					}
				}
				WorldGen.PlaceObject(x11, y11, type10, mute: false, style2, num182, random, direction);
				if (Main.netMode == 2)
				{
					NetMessage.SendObjectPlacment(whoAmI, x11, y11, type10, style2, num182, random, direction);
				}
				break;
			}
			case 80:
				if (Main.netMode == 1)
				{
					int num151 = reader.ReadByte();
					int num152 = reader.ReadInt16();
					if (num152 >= -3 && num152 < 1000)
					{
						Main.player[num151].chest = num152;
						Recipe.FindRecipes();
					}
				}
				break;
			case 81:
				if (Main.netMode == 1)
				{
					int x9 = (int)reader.ReadSingle();
					int y9 = (int)reader.ReadSingle();
					CombatText.NewText(color: reader.ReadRGB(), amount: reader.ReadInt32(), location: new Rectangle(x9, y9, 0, 0));
				}
				break;
			case 119:
				if (Main.netMode == 1)
				{
					int x10 = (int)reader.ReadSingle();
					int y10 = (int)reader.ReadSingle();
					CombatText.NewText(color: reader.ReadRGB(), text: NetworkText.Deserialize(reader).ToString(), location: new Rectangle(x10, y10, 0, 0));
				}
				break;
			case 82:
				NetManager.Instance.Read(reader, whoAmI);
				break;
			case 83:
				if (Main.netMode == 1)
				{
					int num140 = reader.ReadInt16();
					int num141 = reader.ReadInt32();
					if (num140 >= 0 && num140 < 267)
					{
						NPC.killCount[num140] = num141;
					}
				}
				break;
			case 84:
			{
				int num137 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num137 = whoAmI;
				}
				float stealth = reader.ReadSingle();
				Main.player[num137].stealth = stealth;
				if (Main.netMode == 2)
				{
					NetMessage.SendData(84, -1, whoAmI, null, num137);
				}
				break;
			}
			case 85:
			{
				int num130 = whoAmI;
				byte b11 = reader.ReadByte();
				if (Main.netMode == 2 && num130 < 255 && b11 < 58)
				{
					Chest.ServerPlaceItem(whoAmI, b11);
				}
				break;
			}
			case 86:
			{
				if (Main.netMode != 1)
				{
					break;
				}
				int num94 = reader.ReadInt32();
				if (!reader.ReadBoolean())
				{
					if (TileEntity.ByID.TryGetValue(num94, out var value2) && (value2 is TETrainingDummy || value2 is TEItemFrame || value2 is TELogicSensor))
					{
						TileEntity.ByID.Remove(num94);
						TileEntity.ByPosition.Remove(value2.Position);
					}
				}
				else
				{
					TileEntity tileEntity = TileEntity.Read(reader, networkSend: true);
					tileEntity.ID = num94;
					TileEntity.ByID[tileEntity.ID] = tileEntity;
					TileEntity.ByPosition[tileEntity.Position] = tileEntity;
				}
				break;
			}
			case 87:
				if (Main.netMode == 2)
				{
					int x7 = reader.ReadInt16();
					int y7 = reader.ReadInt16();
					int type6 = reader.ReadByte();
					if (WorldGen.InWorld(x7, y7) && !TileEntity.ByPosition.ContainsKey(new Point16(x7, y7)))
					{
						TileEntity.PlaceEntityNet(x7, y7, type6);
					}
				}
				break;
			case 88:
			{
				if (Main.netMode != 1)
				{
					break;
				}
				int num222 = reader.ReadInt16();
				if (num222 < 0 || num222 > 400)
				{
					break;
				}
				Item item4 = Main.item[num222];
				BitsByte bitsByte18 = reader.ReadByte();
				if (bitsByte18[0])
				{
					item4.color.PackedValue = reader.ReadUInt32();
				}
				if (bitsByte18[1])
				{
					item4.damage = reader.ReadUInt16();
				}
				if (bitsByte18[2])
				{
					item4.knockBack = reader.ReadSingle();
				}
				if (bitsByte18[3])
				{
					item4.useAnimation = reader.ReadUInt16();
				}
				if (bitsByte18[4])
				{
					item4.useTime = reader.ReadUInt16();
				}
				if (bitsByte18[5])
				{
					item4.shoot = reader.ReadInt16();
				}
				if (bitsByte18[6])
				{
					item4.shootSpeed = reader.ReadSingle();
				}
				if (bitsByte18[7])
				{
					bitsByte18 = reader.ReadByte();
					if (bitsByte18[0])
					{
						item4.width = reader.ReadInt16();
					}
					if (bitsByte18[1])
					{
						item4.height = reader.ReadInt16();
					}
					if (bitsByte18[2])
					{
						item4.scale = reader.ReadSingle();
					}
					if (bitsByte18[3])
					{
						item4.ammo = reader.ReadInt16();
					}
					if (bitsByte18[4])
					{
						item4.useAmmo = reader.ReadInt16();
					}
					if (bitsByte18[5])
					{
						item4.notAmmo = reader.ReadBoolean();
					}
				}
				break;
			}
			case 89:
				if (Main.netMode == 2)
				{
					short x13 = reader.ReadInt16();
					int y13 = reader.ReadInt16();
					int netid = reader.ReadInt16();
					int prefix = reader.ReadByte();
					int stack6 = reader.ReadInt16();
					TEItemFrame.TryPlacing(x13, y13, netid, prefix, stack6);
				}
				break;
			case 91:
			{
				if (Main.netMode != 1)
				{
					break;
				}
				int num209 = reader.ReadInt32();
				int num210 = reader.ReadByte();
				if (num210 == 255)
				{
					if (EmoteBubble.byID.ContainsKey(num209))
					{
						EmoteBubble.byID.Remove(num209);
					}
					break;
				}
				int meta = reader.ReadUInt16();
				int num211 = reader.ReadByte();
				int num212 = reader.ReadByte();
				int metadata = 0;
				if (num212 < 0)
				{
					metadata = reader.ReadInt16();
				}
				WorldUIAnchor worldUIAnchor = EmoteBubble.DeserializeNetAnchor(num210, meta);
				lock (EmoteBubble.byID)
				{
					if (!EmoteBubble.byID.ContainsKey(num209))
					{
						EmoteBubble.byID[num209] = new EmoteBubble(num212, worldUIAnchor, num211);
					}
					else
					{
						EmoteBubble.byID[num209].lifeTime = num211;
						EmoteBubble.byID[num209].lifeTimeStart = num211;
						EmoteBubble.byID[num209].emote = num212;
						EmoteBubble.byID[num209].anchor = worldUIAnchor;
					}
					EmoteBubble.byID[num209].ID = num209;
					EmoteBubble.byID[num209].metadata = metadata;
					break;
				}
			}
			case 92:
			{
				int num199 = reader.ReadInt16();
				float num200 = reader.ReadSingle();
				float num201 = reader.ReadSingle();
				float num202 = reader.ReadSingle();
				if (num199 >= 0 && num199 <= 200)
				{
					if (Main.netMode == 1)
					{
						Main.npc[num199].moneyPing(new Vector2(num201, num202));
						Main.npc[num199].extraValue = num200;
					}
					else
					{
						Main.npc[num199].extraValue += num200;
						NetMessage.SendData(92, -1, -1, null, num199, Main.npc[num199].extraValue, num201, num202);
					}
				}
				break;
			}
			case 95:
			{
				ushort num191 = reader.ReadUInt16();
				if (Main.netMode == 2 && num191 >= 0 && num191 < 1000)
				{
					Projectile projectile2 = Main.projectile[num191];
					if (projectile2.type == 602)
					{
						projectile2.Kill();
						NetMessage.SendData(29, -1, -1, null, projectile2.whoAmI, projectile2.owner);
					}
				}
				break;
			}
			case 96:
			{
				int num185 = reader.ReadByte();
				Player obj4 = Main.player[num185];
				int num186 = reader.ReadInt16();
				Vector2 newPos2 = reader.ReadVector2();
				Vector2 velocity4 = reader.ReadVector2();
				int lastPortalColorIndex2 = num186 + ((num186 % 2 == 0) ? 1 : (-1));
				obj4.lastPortalColorIndex = lastPortalColorIndex2;
				obj4.Teleport(newPos2, 4, num186);
				obj4.velocity = velocity4;
				break;
			}
			case 97:
				if (Main.netMode == 1)
				{
					AchievementsHelper.NotifyNPCKilledDirect(Main.player[Main.myPlayer], reader.ReadInt16());
				}
				break;
			case 98:
				if (Main.netMode == 1)
				{
					AchievementsHelper.NotifyProgressionEvent(reader.ReadInt16());
				}
				break;
			case 99:
			{
				int num179 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num179 = whoAmI;
				}
				Main.player[num179].MinionRestTargetPoint = reader.ReadVector2();
				if (Main.netMode == 2)
				{
					NetMessage.SendData(99, -1, whoAmI, null, num179);
				}
				break;
			}
			case 115:
			{
				int num150 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num150 = whoAmI;
				}
				Main.player[num150].MinionAttackTargetNPC = reader.ReadInt16();
				if (Main.netMode == 2)
				{
					NetMessage.SendData(115, -1, whoAmI, null, num150);
				}
				break;
			}
			case 100:
			{
				int num146 = reader.ReadUInt16();
				NPC obj2 = Main.npc[num146];
				int num147 = reader.ReadInt16();
				Vector2 newPos = reader.ReadVector2();
				Vector2 velocity3 = reader.ReadVector2();
				int lastPortalColorIndex = num147 + ((num147 % 2 == 0) ? 1 : (-1));
				obj2.lastPortalColorIndex = lastPortalColorIndex;
				obj2.Teleport(newPos, 4, num147);
				obj2.velocity = velocity3;
				break;
			}
			case 101:
				if (Main.netMode != 2)
				{
					NPC.ShieldStrengthTowerSolar = reader.ReadUInt16();
					NPC.ShieldStrengthTowerVortex = reader.ReadUInt16();
					NPC.ShieldStrengthTowerNebula = reader.ReadUInt16();
					NPC.ShieldStrengthTowerStardust = reader.ReadUInt16();
					if (NPC.ShieldStrengthTowerSolar < 0)
					{
						NPC.ShieldStrengthTowerSolar = 0;
					}
					if (NPC.ShieldStrengthTowerVortex < 0)
					{
						NPC.ShieldStrengthTowerVortex = 0;
					}
					if (NPC.ShieldStrengthTowerNebula < 0)
					{
						NPC.ShieldStrengthTowerNebula = 0;
					}
					if (NPC.ShieldStrengthTowerStardust < 0)
					{
						NPC.ShieldStrengthTowerStardust = 0;
					}
					if (NPC.ShieldStrengthTowerSolar > NPC.LunarShieldPowerExpert)
					{
						NPC.ShieldStrengthTowerSolar = NPC.LunarShieldPowerExpert;
					}
					if (NPC.ShieldStrengthTowerVortex > NPC.LunarShieldPowerExpert)
					{
						NPC.ShieldStrengthTowerVortex = NPC.LunarShieldPowerExpert;
					}
					if (NPC.ShieldStrengthTowerNebula > NPC.LunarShieldPowerExpert)
					{
						NPC.ShieldStrengthTowerNebula = NPC.LunarShieldPowerExpert;
					}
					if (NPC.ShieldStrengthTowerStardust > NPC.LunarShieldPowerExpert)
					{
						NPC.ShieldStrengthTowerStardust = NPC.LunarShieldPowerExpert;
					}
				}
				break;
			case 102:
			{
				int num95 = reader.ReadByte();
				byte b10 = reader.ReadByte();
				Vector2 other = reader.ReadVector2();
				if (Main.netMode == 2)
				{
					num95 = whoAmI;
					NetMessage.SendData(102, -1, -1, null, num95, (int)b10, other.X, other.Y);
					break;
				}
				Player player8 = Main.player[num95];
				for (int num96 = 0; num96 < 255; num96++)
				{
					Player player9 = Main.player[num96];
					if (!player9.active || player9.dead || (player8.team != 0 && player8.team != player9.team) || !(player9.Distance(other) < 700f))
					{
						continue;
					}
					Vector2 value3 = player8.Center - player9.Center;
					Vector2 vector = Vector2.Normalize(value3);
					if (!vector.HasNaNs())
					{
						int type8 = 90;
						float num97 = 0f;
						float num98 = (float)Math.PI / 15f;
						Vector2 spinningpoint = new Vector2(0f, -8f);
						Vector2 vector2 = new Vector2(-3f);
						float num99 = 0f;
						float num100 = 0.005f;
						switch (b10)
						{
						case 179:
							type8 = 86;
							break;
						case 173:
							type8 = 90;
							break;
						case 176:
							type8 = 88;
							break;
						}
						for (int num101 = 0; (float)num101 < value3.Length() / 6f; num101++)
						{
							Vector2 position2 = player9.Center + 6f * (float)num101 * vector + spinningpoint.RotatedBy(num97) + vector2;
							num97 += num98;
							int num102 = Dust.NewDust(position2, 6, 6, type8, 0f, 0f, 100, default(Color), 1.5f);
							Main.dust[num102].noGravity = true;
							Main.dust[num102].velocity = Vector2.Zero;
							num99 = (Main.dust[num102].fadeIn = num99 + num100);
							Main.dust[num102].velocity += vector * 1.5f;
						}
					}
					player9.NebulaLevelup(b10);
				}
				break;
			}
			case 103:
				if (Main.netMode == 1)
				{
					NPC.MoonLordCountdown = reader.ReadInt32();
				}
				break;
			case 104:
				if (Main.netMode == 1 && Main.npcShop > 0)
				{
					Item[] item = Main.instance.shop[Main.npcShop].item;
					int num86 = reader.ReadByte();
					int type7 = reader.ReadInt16();
					int stack = reader.ReadInt16();
					int pre = reader.ReadByte();
					int value = reader.ReadInt32();
					BitsByte bitsByte11 = reader.ReadByte();
					if (num86 < item.Length)
					{
						item[num86] = new Item();
						item[num86].netDefaults(type7);
						item[num86].stack = stack;
						item[num86].Prefix(pre);
						item[num86].value = value;
						item[num86].buyOnce = bitsByte11[0];
					}
				}
				break;
			case 105:
				if (Main.netMode != 1)
				{
					short i2 = reader.ReadInt16();
					int j2 = reader.ReadInt16();
					bool flag6 = reader.ReadBoolean();
					WorldGen.ToggleGemLock(i2, j2, flag6);
				}
				break;
			case 106:
				if (Main.netMode == 1)
				{
					HalfVector2 halfVector = new HalfVector2
					{
						PackedValue = reader.ReadUInt32()
					};
					Utils.PoofOfSmoke(halfVector.ToVector2());
				}
				break;
			case 107:
				if (Main.netMode == 1)
				{
					Color c = reader.ReadRGB();
					string text = NetworkText.Deserialize(reader).ToString();
					int widthLimit = reader.ReadInt16();
					Main.NewTextMultiline(text, force: false, c, widthLimit);
				}
				break;
			case 108:
				if (Main.netMode == 1)
				{
					int damage2 = reader.ReadInt16();
					float knockBack = reader.ReadSingle();
					int x6 = reader.ReadInt16();
					int y6 = reader.ReadInt16();
					int angle = reader.ReadInt16();
					int ammo = reader.ReadInt16();
					int num64 = reader.ReadByte();
					if (num64 == Main.myPlayer)
					{
						WorldGen.ShootFromCannon(x6, y6, angle, ammo, damage2, knockBack, num64);
					}
				}
				break;
			case 109:
				if (Main.netMode == 2)
				{
					short x4 = reader.ReadInt16();
					int y4 = reader.ReadInt16();
					int x5 = reader.ReadInt16();
					int y5 = reader.ReadInt16();
					byte toolMode = reader.ReadByte();
					int num63 = whoAmI;
					WiresUI.Settings.MultiToolMode toolMode2 = WiresUI.Settings.ToolMode;
					WiresUI.Settings.ToolMode = (WiresUI.Settings.MultiToolMode)toolMode;
					Wiring.MassWireOperation(new Point(x4, y4), new Point(x5, y5), Main.player[num63]);
					WiresUI.Settings.ToolMode = toolMode2;
				}
				break;
			case 110:
			{
				if (Main.netMode != 1)
				{
					break;
				}
				int type3 = reader.ReadInt16();
				int num48 = reader.ReadInt16();
				int num49 = reader.ReadByte();
				if (num49 == Main.myPlayer)
				{
					Player player3 = Main.player[num49];
					for (int num50 = 0; num50 < num48; num50++)
					{
						player3.ConsumeItem(type3);
					}
					player3.wireOperationsCooldown = 0;
				}
				break;
			}
			case 111:
				if (Main.netMode == 2)
				{
					BirthdayParty.ToggleManualParty();
				}
				break;
			case 112:
			{
				int num34 = reader.ReadByte();
				int num35 = reader.ReadInt16();
				int num36 = reader.ReadInt16();
				int num37 = reader.ReadByte();
				int num38 = reader.ReadInt16();
				if (num34 == 1)
				{
					if (Main.netMode == 1)
					{
						WorldGen.TreeGrowFX(num35, num36, num37, num38);
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData(b, -1, -1, null, num34, num35, num36, num37, num38);
					}
				}
				break;
			}
			case 113:
			{
				int x3 = reader.ReadInt16();
				int y3 = reader.ReadInt16();
				if (Main.netMode == 2 && !Main.snowMoon && !Main.pumpkinMoon)
				{
					if (DD2Event.WouldFailSpawningHere(x3, y3))
					{
						DD2Event.FailureMessage(whoAmI);
					}
					DD2Event.SummonCrystal(x3, y3);
				}
				break;
			}
			case 114:
				if (Main.netMode == 1)
				{
					DD2Event.WipeEntities();
				}
				break;
			case 116:
				if (Main.netMode == 1)
				{
					DD2Event.TimeLeftBetweenWaves = reader.ReadInt32();
				}
				break;
			case 117:
			{
				int num7 = reader.ReadByte();
				if (Main.netMode != 2 || whoAmI == num7 || (Main.player[num7].hostile && Main.player[whoAmI].hostile))
				{
					PlayerDeathReason playerDeathReason2 = PlayerDeathReason.FromReader(reader);
					int damage = reader.ReadInt16();
					int num8 = reader.ReadByte() - 1;
					BitsByte bitsByte7 = reader.ReadByte();
					bool flag = bitsByte7[0];
					bool pvp2 = bitsByte7[1];
					int num9 = reader.ReadSByte();
					Main.player[num7].Hurt(playerDeathReason2, damage, num8, pvp2, quiet: true, flag, num9);
					if (Main.netMode == 2)
					{
						NetMessage.SendPlayerHurt(num7, playerDeathReason2, damage, num8, flag, pvp2, num9, -1, whoAmI);
					}
				}
				break;
			}
			case 118:
			{
				int num2 = reader.ReadByte();
				if (Main.netMode == 2)
				{
					num2 = whoAmI;
				}
				PlayerDeathReason playerDeathReason = PlayerDeathReason.FromReader(reader);
				int num3 = reader.ReadInt16();
				int num4 = reader.ReadByte() - 1;
				bool pvp = ((BitsByte)reader.ReadByte())[0];
				Main.player[num2].KillMe(playerDeathReason, num3, num4, pvp);
				if (Main.netMode == 2)
				{
					NetMessage.SendPlayerDeath(num2, playerDeathReason, num3, num4, pvp, -1, whoAmI);
				}
				break;
			}
			case 15:
			case 25:
			case 26:
			case 44:
			case 67:
			case 93:
			case 94:
				break;
			}
		}
	}
}
