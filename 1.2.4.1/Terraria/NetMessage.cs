using System;
using System.IO;
using System.IO.Compression;
using Microsoft.Xna.Framework;

namespace Terraria
{
	public class NetMessage
	{
		public static MessageBuffer[] buffer = new MessageBuffer[257];

		public static void SendData(int msgType, int remoteClient = -1, int ignoreClient = -1, string text = "", int number = 0, float number2 = 0f, float number3 = 0f, float number4 = 0f, int number5 = 0)
		{
			if (Main.netMode == 0)
			{
				return;
			}
			int num = 256;
			if (Main.netMode == 2 && remoteClient >= 0)
			{
				num = remoteClient;
			}
			lock (buffer[num])
			{
				MemoryStream output = new MemoryStream(buffer[num].writeBuffer);
				BinaryWriter binaryWriter = new BinaryWriter(output);
				long position = binaryWriter.BaseStream.Position;
				binaryWriter.BaseStream.Position += 2L;
				binaryWriter.Write((byte)msgType);
				switch (msgType)
				{
				case 1:
					binaryWriter.Write("Terraria" + Main.curRelease);
					break;
				case 2:
					binaryWriter.Write(text);
					if (Main.dedServ)
					{
						Console.WriteLine(Netplay.serverSock[num].tcpClient.Client.RemoteEndPoint.ToString() + " was booted: " + text);
					}
					break;
				case 3:
					binaryWriter.Write((byte)remoteClient);
					break;
				case 4:
				{
					Player player4 = Main.player[number];
					binaryWriter.Write((byte)number);
					binaryWriter.Write((!player4.male) ? ((byte)1) : ((byte)0));
					binaryWriter.Write((byte)player4.hair);
					binaryWriter.Write(text);
					binaryWriter.Write(player4.hairDye);
					binaryWriter.Write(player4.hideVisual);
					binaryWriter.WriteRGB(player4.hairColor);
					binaryWriter.WriteRGB(player4.skinColor);
					binaryWriter.WriteRGB(player4.eyeColor);
					binaryWriter.WriteRGB(player4.shirtColor);
					binaryWriter.WriteRGB(player4.underShirtColor);
					binaryWriter.WriteRGB(player4.pantsColor);
					binaryWriter.WriteRGB(player4.shoeColor);
					binaryWriter.Write(player4.difficulty);
					break;
				}
				case 5:
				{
					binaryWriter.Write((byte)number);
					binaryWriter.Write((byte)number2);
					Player player2 = Main.player[number];
					Item item = null;
					int num9 = 0;
					int num10 = 0;
					item = ((number2 < 59f) ? player2.inventory[(int)number2] : ((!(number2 >= 75f) || !(number2 <= 82f)) ? player2.armor[(int)number2 - 58 - 1] : player2.dye[(int)number2 - 58 - 17]));
					if (item.name == "" || item.stack == 0 || item.type == 0)
					{
						item.SetDefaults(0);
					}
					num9 = item.stack;
					num10 = item.netID;
					if (num9 < 0)
					{
						num9 = 0;
					}
					binaryWriter.Write((short)num9);
					binaryWriter.Write((byte)number3);
					binaryWriter.Write((short)num10);
					break;
				}
				case 7:
				{
					binaryWriter.Write((int)Main.time);
					BitsByte bitsByte8 = (byte)0;
					bitsByte8[0] = Main.dayTime;
					bitsByte8[1] = Main.bloodMoon;
					bitsByte8[2] = Main.eclipse;
					binaryWriter.Write(bitsByte8);
					binaryWriter.Write((byte)Main.moonPhase);
					binaryWriter.Write((short)Main.maxTilesX);
					binaryWriter.Write((short)Main.maxTilesY);
					binaryWriter.Write((short)Main.spawnTileX);
					binaryWriter.Write((short)Main.spawnTileY);
					binaryWriter.Write((short)Main.worldSurface);
					binaryWriter.Write((short)Main.rockLayer);
					binaryWriter.Write(Main.worldID);
					binaryWriter.Write(Main.worldName);
					binaryWriter.Write((byte)Main.moonType);
					binaryWriter.Write((byte)WorldGen.treeBG);
					binaryWriter.Write((byte)WorldGen.corruptBG);
					binaryWriter.Write((byte)WorldGen.jungleBG);
					binaryWriter.Write((byte)WorldGen.snowBG);
					binaryWriter.Write((byte)WorldGen.hallowBG);
					binaryWriter.Write((byte)WorldGen.crimsonBG);
					binaryWriter.Write((byte)WorldGen.desertBG);
					binaryWriter.Write((byte)WorldGen.oceanBG);
					binaryWriter.Write((byte)Main.iceBackStyle);
					binaryWriter.Write((byte)Main.jungleBackStyle);
					binaryWriter.Write((byte)Main.hellBackStyle);
					binaryWriter.Write(Main.windSpeedSet);
					binaryWriter.Write((byte)Main.numClouds);
					for (int num11 = 0; num11 < 3; num11++)
					{
						binaryWriter.Write(Main.treeX[num11]);
					}
					for (int num12 = 0; num12 < 4; num12++)
					{
						binaryWriter.Write((byte)Main.treeStyle[num12]);
					}
					for (int num13 = 0; num13 < 3; num13++)
					{
						binaryWriter.Write(Main.caveBackX[num13]);
					}
					for (int num14 = 0; num14 < 4; num14++)
					{
						binaryWriter.Write((byte)Main.caveBackStyle[num14]);
					}
					if (!Main.raining)
					{
						Main.maxRaining = 0f;
					}
					binaryWriter.Write(Main.maxRaining);
					BitsByte bitsByte9 = (byte)0;
					bitsByte9[0] = WorldGen.shadowOrbSmashed;
					bitsByte9[1] = NPC.downedBoss1;
					bitsByte9[2] = NPC.downedBoss2;
					bitsByte9[3] = NPC.downedBoss3;
					bitsByte9[4] = Main.hardMode;
					bitsByte9[5] = NPC.downedClown;
					bitsByte9[7] = NPC.downedPlantBoss;
					binaryWriter.Write(bitsByte9);
					BitsByte bitsByte10 = (byte)0;
					bitsByte10[0] = NPC.downedMechBoss1;
					bitsByte10[1] = NPC.downedMechBoss2;
					bitsByte10[2] = NPC.downedMechBoss3;
					bitsByte10[3] = NPC.downedMechBossAny;
					bitsByte10[4] = Main.cloudBGActive >= 1f;
					bitsByte10[5] = WorldGen.crimson;
					bitsByte10[6] = Main.pumpkinMoon;
					bitsByte10[7] = Main.snowMoon;
					binaryWriter.Write(bitsByte10);
					break;
				}
				case 8:
					binaryWriter.Write(number);
					binaryWriter.Write((int)number2);
					break;
				case 9:
					binaryWriter.Write(number);
					binaryWriter.Write(text);
					break;
				case 10:
				{
					int num5 = CompressTileBlock(number, (int)number2, (short)number3, (short)number4, buffer[num].writeBuffer, (int)binaryWriter.BaseStream.Position, true);
					binaryWriter.BaseStream.Position += num5;
					break;
				}
				case 11:
					binaryWriter.Write((short)number);
					binaryWriter.Write((short)number2);
					binaryWriter.Write((short)number3);
					binaryWriter.Write((short)number4);
					break;
				case 12:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((short)Main.player[number].SpawnX);
					binaryWriter.Write((short)Main.player[number].SpawnY);
					break;
				case 13:
				{
					Player player3 = Main.player[number];
					binaryWriter.Write((byte)number);
					BitsByte bitsByte6 = (byte)0;
					bitsByte6[0] = player3.controlUp;
					bitsByte6[1] = player3.controlDown;
					bitsByte6[2] = player3.controlLeft;
					bitsByte6[3] = player3.controlRight;
					bitsByte6[4] = player3.controlJump;
					bitsByte6[5] = player3.controlUseItem;
					bitsByte6[6] = player3.direction == 1;
					binaryWriter.Write(bitsByte6);
					BitsByte bitsByte7 = (byte)0;
					bitsByte7[0] = player3.pulley;
					bitsByte7[1] = player3.pulley && player3.pulleyDir == 2;
					bitsByte7[2] = player3.velocity != Vector2.Zero;
					binaryWriter.Write(bitsByte7);
					binaryWriter.Write((byte)player3.selectedItem);
					binaryWriter.WriteVector2(player3.position);
					binaryWriter.WriteVector2(player3.velocity);
					break;
				}
				case 14:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((byte)number2);
					break;
				case 16:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((short)Main.player[number].statLife);
					binaryWriter.Write((short)Main.player[number].statLifeMax);
					break;
				case 17:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((short)number2);
					binaryWriter.Write((short)number3);
					binaryWriter.Write((short)number4);
					binaryWriter.Write((byte)number5);
					break;
				case 18:
					binaryWriter.Write((byte)(Main.dayTime ? 1u : 0u));
					binaryWriter.Write((int)Main.time);
					binaryWriter.Write(Main.sunModY);
					binaryWriter.Write(Main.moonModY);
					break;
				case 19:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((short)number2);
					binaryWriter.Write((short)number3);
					binaryWriter.Write((number4 == 1f) ? ((byte)1) : ((byte)0));
					break;
				case 20:
				{
					int num3 = (int)number2;
					int num4 = (int)number3;
					binaryWriter.Write((short)number);
					binaryWriter.Write((short)num3);
					binaryWriter.Write((short)num4);
					for (int k = num3; k < num3 + number; k++)
					{
						for (int l = num4; l < num4 + number; l++)
						{
							BitsByte bitsByte3 = (byte)0;
							BitsByte bitsByte4 = (byte)0;
							byte b = 0;
							byte b2 = 0;
							Tile tile = Main.tile[k, l];
							bitsByte3[0] = tile.active();
							bitsByte3[2] = tile.wall > 0;
							bitsByte3[3] = tile.liquid > 0 && Main.netMode == 2;
							bitsByte3[4] = tile.wire();
							bitsByte3[5] = tile.halfBrick();
							bitsByte3[6] = tile.actuator();
							bitsByte3[7] = tile.inActive();
							bitsByte4[0] = tile.wire2();
							bitsByte4[1] = tile.wire3();
							if (tile.active() && tile.color() > 0)
							{
								bitsByte4[2] = true;
								b = tile.color();
							}
							if (tile.wall > 0 && tile.wallColor() > 0)
							{
								bitsByte4[3] = true;
								b2 = tile.wallColor();
							}
							bitsByte4 = (byte)((byte)bitsByte4 + (byte)(tile.slope() << 4));
							binaryWriter.Write(bitsByte3);
							binaryWriter.Write(bitsByte4);
							if (b > 0)
							{
								binaryWriter.Write(b);
							}
							if (b2 > 0)
							{
								binaryWriter.Write(b2);
							}
							if (tile.active())
							{
								binaryWriter.Write(tile.type);
								if (Main.tileFrameImportant[tile.type])
								{
									binaryWriter.Write(tile.frameX);
									binaryWriter.Write(tile.frameY);
								}
							}
							if (tile.wall > 0)
							{
								binaryWriter.Write(tile.wall);
							}
							if (tile.liquid > 0 && Main.netMode == 2)
							{
								binaryWriter.Write(tile.liquid);
								binaryWriter.Write(tile.liquidType());
							}
						}
					}
					break;
				}
				case 21:
				{
					Item item3 = Main.item[number];
					binaryWriter.Write((short)number);
					binaryWriter.WriteVector2(item3.position);
					binaryWriter.WriteVector2(item3.velocity);
					binaryWriter.Write((short)item3.stack);
					binaryWriter.Write(item3.prefix);
					binaryWriter.Write((byte)number2);
					short value5 = 0;
					if (item3.active && item3.stack > 0)
					{
						value5 = (short)item3.netID;
					}
					binaryWriter.Write(value5);
					break;
				}
				case 22:
					binaryWriter.Write((short)number);
					binaryWriter.Write((byte)Main.item[number].owner);
					break;
				case 23:
				{
					NPC nPC = Main.npc[number];
					binaryWriter.Write((short)number);
					binaryWriter.WriteVector2(nPC.position);
					binaryWriter.WriteVector2(nPC.velocity);
					binaryWriter.Write((byte)nPC.target);
					int num2 = nPC.life;
					if (!nPC.active)
					{
						num2 = 0;
					}
					if (!nPC.active || nPC.life <= 0)
					{
						nPC.netSkip = 0;
					}
					if (nPC.name == null)
					{
						nPC.name = "";
					}
					short value2 = (short)nPC.netID;
					bool[] array = new bool[4];
					BitsByte bitsByte = (byte)0;
					bitsByte[0] = nPC.direction > 0;
					bitsByte[1] = nPC.directionY > 0;
					bitsByte[2] = (array[0] = nPC.ai[0] != 0f);
					bitsByte[3] = (array[1] = nPC.ai[1] != 0f);
					bitsByte[4] = (array[2] = nPC.ai[2] != 0f);
					bitsByte[5] = (array[3] = nPC.ai[3] != 0f);
					bitsByte[6] = nPC.spriteDirection > 0;
					bitsByte[7] = num2 == nPC.lifeMax;
					binaryWriter.Write(bitsByte);
					for (int j = 0; j < NPC.maxAI; j++)
					{
						if (array[j])
						{
							binaryWriter.Write(nPC.ai[j]);
						}
					}
					binaryWriter.Write(value2);
					if (!bitsByte[7])
					{
						if (Main.npcLifeBytes[nPC.netID] == 2)
						{
							binaryWriter.Write((short)num2);
						}
						else if (Main.npcLifeBytes[nPC.netID] == 4)
						{
							binaryWriter.Write(num2);
						}
						else
						{
							binaryWriter.Write((sbyte)num2);
						}
					}
					if (Main.npcCatchable[nPC.type])
					{
						binaryWriter.Write((byte)nPC.releaseOwner);
					}
					break;
				}
				case 24:
					binaryWriter.Write((short)number);
					binaryWriter.Write((byte)number2);
					break;
				case 25:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((byte)number2);
					binaryWriter.Write((byte)number3);
					binaryWriter.Write((byte)number4);
					binaryWriter.Write(text);
					break;
				case 26:
				{
					binaryWriter.Write((byte)number);
					binaryWriter.Write((byte)(number2 + 1f));
					binaryWriter.Write((short)number3);
					binaryWriter.Write(text);
					BitsByte bitsByte12 = (byte)0;
					bitsByte12[0] = number4 == 1f;
					bitsByte12[1] = number5 == 1;
					binaryWriter.Write(bitsByte12);
					break;
				}
				case 27:
				{
					Projectile projectile = Main.projectile[number];
					binaryWriter.Write((short)projectile.identity);
					binaryWriter.WriteVector2(projectile.position);
					binaryWriter.WriteVector2(projectile.velocity);
					binaryWriter.Write(projectile.knockBack);
					binaryWriter.Write((short)projectile.damage);
					binaryWriter.Write((byte)projectile.owner);
					binaryWriter.Write((short)projectile.type);
					BitsByte bitsByte11 = (byte)0;
					for (int num15 = 0; num15 < Projectile.maxAI; num15++)
					{
						if (projectile.ai[num15] != 0f)
						{
							bitsByte11[num15] = true;
						}
					}
					binaryWriter.Write(bitsByte11);
					for (int num16 = 0; num16 < Projectile.maxAI; num16++)
					{
						if (bitsByte11[num16])
						{
							binaryWriter.Write(projectile.ai[num16]);
						}
					}
					break;
				}
				case 28:
					binaryWriter.Write((short)number);
					binaryWriter.Write((short)number2);
					binaryWriter.Write(number3);
					binaryWriter.Write((byte)(number4 + 1f));
					binaryWriter.Write((byte)number5);
					break;
				case 29:
					binaryWriter.Write((short)number);
					binaryWriter.Write((byte)number2);
					break;
				case 30:
					binaryWriter.Write((byte)number);
					binaryWriter.Write(Main.player[number].hostile);
					break;
				case 31:
					binaryWriter.Write((short)number);
					binaryWriter.Write((short)number2);
					break;
				case 32:
				{
					Item item2 = Main.chest[number].item[(byte)number2];
					binaryWriter.Write((short)number);
					binaryWriter.Write((byte)number2);
					short value4 = (short)item2.netID;
					if (item2.name == null)
					{
						value4 = 0;
					}
					binaryWriter.Write((short)item2.stack);
					binaryWriter.Write(item2.prefix);
					binaryWriter.Write(value4);
					break;
				}
				case 33:
				{
					int num6 = 0;
					int num7 = 0;
					int num8 = 0;
					string text2 = null;
					if (number > -1)
					{
						num6 = Main.chest[number].x;
						num7 = Main.chest[number].y;
					}
					if (number2 == 1f)
					{
						num8 = (byte)text.Length;
						if (num8 == 0 || num8 > 20)
						{
							num8 = 255;
						}
						else
						{
							text2 = text;
						}
					}
					binaryWriter.Write((short)number);
					binaryWriter.Write((short)num6);
					binaryWriter.Write((short)num7);
					binaryWriter.Write((byte)num8);
					if (text2 != null)
					{
						binaryWriter.Write(text2);
					}
					break;
				}
				case 34:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((short)number2);
					binaryWriter.Write((short)number3);
					binaryWriter.Write((short)number4);
					if (Main.netMode == 2)
					{
						Netplay.GetSectionX((int)number2);
						Netplay.GetSectionY((int)number3);
						binaryWriter.Write((short)number5);
					}
					break;
				case 35:
				case 66:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((short)number2);
					break;
				case 36:
				{
					Player player = Main.player[number];
					binaryWriter.Write((byte)number);
					BitsByte bitsByte5 = (byte)0;
					bitsByte5[0] = player.zoneEvil;
					bitsByte5[1] = player.zoneMeteor;
					bitsByte5[2] = player.zoneDungeon;
					bitsByte5[3] = player.zoneJungle;
					bitsByte5[4] = player.zoneHoly;
					bitsByte5[5] = player.zoneSnow;
					bitsByte5[6] = player.zoneBlood;
					bitsByte5[7] = player.zoneCandle;
					binaryWriter.Write(bitsByte5);
					break;
				}
				case 38:
					binaryWriter.Write(text);
					break;
				case 39:
					binaryWriter.Write((short)number);
					break;
				case 40:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((short)Main.player[number].talkNPC);
					break;
				case 41:
					binaryWriter.Write((byte)number);
					binaryWriter.Write(Main.player[number].itemRotation);
					binaryWriter.Write((short)Main.player[number].itemAnimation);
					break;
				case 42:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((short)Main.player[number].statMana);
					binaryWriter.Write((short)Main.player[number].statManaMax);
					break;
				case 43:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((short)number2);
					break;
				case 44:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((byte)(number2 + 1f));
					binaryWriter.Write((short)number3);
					binaryWriter.Write((byte)number4);
					binaryWriter.Write(text);
					break;
				case 45:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((byte)Main.player[number].team);
					break;
				case 46:
					binaryWriter.Write((short)number);
					binaryWriter.Write((short)number2);
					break;
				case 47:
					binaryWriter.Write((short)number);
					binaryWriter.Write((short)Main.sign[number].x);
					binaryWriter.Write((short)Main.sign[number].y);
					binaryWriter.Write(Main.sign[number].text);
					break;
				case 48:
				{
					Tile tile2 = Main.tile[number, (int)number2];
					binaryWriter.Write((short)number);
					binaryWriter.Write((short)number2);
					binaryWriter.Write(tile2.liquid);
					binaryWriter.Write(tile2.liquidType());
					break;
				}
				case 50:
				{
					binaryWriter.Write((byte)number);
					for (int n = 0; n < 22; n++)
					{
						binaryWriter.Write((byte)Main.player[number].buffType[n]);
					}
					break;
				}
				case 51:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((byte)number2);
					break;
				case 52:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((byte)number2);
					binaryWriter.Write((short)number3);
					binaryWriter.Write((short)number4);
					break;
				case 53:
					binaryWriter.Write((short)number);
					binaryWriter.Write((byte)number2);
					binaryWriter.Write((short)number3);
					break;
				case 54:
				{
					binaryWriter.Write((short)number);
					for (int m = 0; m < 5; m++)
					{
						binaryWriter.Write((byte)Main.npc[number].buffType[m]);
						binaryWriter.Write((short)Main.npc[number].buffTime[m]);
					}
					break;
				}
				case 55:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((byte)number2);
					binaryWriter.Write((short)number3);
					break;
				case 56:
				{
					string value3 = null;
					if (Main.netMode == 2)
					{
						value3 = Main.npc[number].displayName;
					}
					else if (Main.netMode == 1)
					{
						value3 = text;
					}
					binaryWriter.Write((short)number);
					binaryWriter.Write(value3);
					break;
				}
				case 57:
					binaryWriter.Write(WorldGen.tGood);
					binaryWriter.Write(WorldGen.tEvil);
					binaryWriter.Write(WorldGen.tBlood);
					break;
				case 58:
					binaryWriter.Write((byte)number);
					binaryWriter.Write(number2);
					break;
				case 59:
					binaryWriter.Write((short)number);
					binaryWriter.Write((short)number2);
					break;
				case 60:
					binaryWriter.Write((short)number);
					binaryWriter.Write((short)number2);
					binaryWriter.Write((short)number3);
					binaryWriter.Write((byte)number4);
					break;
				case 61:
					binaryWriter.Write(number);
					binaryWriter.Write((int)number2);
					break;
				case 62:
					binaryWriter.Write((byte)number);
					binaryWriter.Write((byte)number2);
					break;
				case 63:
				case 64:
					binaryWriter.Write((short)number);
					binaryWriter.Write((short)number2);
					binaryWriter.Write((byte)number3);
					break;
				case 65:
				{
					BitsByte bitsByte2 = (byte)0;
					bitsByte2[0] = (number & 1) == 1;
					bitsByte2[1] = (number & 2) == 2;
					bitsByte2[2] = (number5 & 1) == 1;
					bitsByte2[3] = (number5 & 2) == 2;
					binaryWriter.Write(bitsByte2);
					binaryWriter.Write((short)number2);
					binaryWriter.Write(number3);
					binaryWriter.Write(number4);
					break;
				}
				case 68:
					binaryWriter.Write(Main.clientUUID);
					break;
				case 69:
					Netplay.GetSectionX((int)number2);
					Netplay.GetSectionY((int)number3);
					binaryWriter.Write((short)number);
					binaryWriter.Write((short)number2);
					binaryWriter.Write((short)number3);
					binaryWriter.Write(text);
					break;
				case 70:
					binaryWriter.Write((short)number);
					binaryWriter.Write((byte)number2);
					break;
				case 71:
					binaryWriter.Write(number);
					binaryWriter.Write((int)number2);
					binaryWriter.Write((short)number3);
					binaryWriter.Write((byte)number4);
					break;
				case 72:
				{
					for (int i = 0; i < Chest.maxItems; i++)
					{
						binaryWriter.Write((short)Main.travelShop[i]);
					}
					break;
				}
				case 74:
				{
					binaryWriter.Write((byte)Main.anglerQuest);
					bool value = Main.anglerWhoFinishedToday.Contains(text);
					binaryWriter.Write(value);
					break;
				}
				case 76:
					binaryWriter.Write((byte)number);
					binaryWriter.Write(Main.player[number].anglerQuestsFinished);
					break;
				}
				int num17 = (int)binaryWriter.BaseStream.Position;
				binaryWriter.BaseStream.Position = position;
				binaryWriter.Write((short)num17);
				binaryWriter.BaseStream.Position = num17;
				if (Main.netMode == 1)
				{
					if (Netplay.clientSock.tcpClient.Connected)
					{
						try
						{
							buffer[num].spamCount++;
							Main.txMsg++;
							Main.txData += num17;
							Main.txMsgType[msgType]++;
							Main.txDataType[msgType] += num17;
							Netplay.clientSock.networkStream.BeginWrite(buffer[num].writeBuffer, 0, num17, Netplay.clientSock.ClientWriteCallBack, Netplay.clientSock.networkStream);
						}
						catch
						{
						}
					}
				}
				else if (remoteClient == -1)
				{
					switch (msgType)
					{
					case 34:
					case 69:
					{
						for (int num19 = 0; num19 < 256; num19++)
						{
							if (num19 != ignoreClient && buffer[num19].broadcast && Netplay.serverSock[num19].tcpClient.Connected)
							{
								try
								{
									buffer[num19].spamCount++;
									Main.txMsg++;
									Main.txData += num17;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num17;
									Netplay.serverSock[num19].networkStream.BeginWrite(buffer[num].writeBuffer, 0, num17, Netplay.serverSock[num19].ServerWriteCallBack, Netplay.serverSock[num19].networkStream);
								}
								catch
								{
								}
							}
						}
						break;
					}
					case 20:
					{
						for (int num23 = 0; num23 < 256; num23++)
						{
							if (num23 != ignoreClient && buffer[num23].broadcast && Netplay.serverSock[num23].tcpClient.Connected && Netplay.serverSock[num23].SectionRange(number, (int)number2, (int)number3))
							{
								try
								{
									buffer[num23].spamCount++;
									Main.txMsg++;
									Main.txData += num17;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num17;
									Netplay.serverSock[num23].networkStream.BeginWrite(buffer[num].writeBuffer, 0, num17, Netplay.serverSock[num23].ServerWriteCallBack, Netplay.serverSock[num23].networkStream);
								}
								catch
								{
								}
							}
						}
						break;
					}
					case 23:
					{
						NPC nPC3 = Main.npc[number];
						for (int num24 = 0; num24 < 256; num24++)
						{
							if (num24 == ignoreClient || !buffer[num24].broadcast || !Netplay.serverSock[num24].tcpClient.Connected)
							{
								continue;
							}
							bool flag3 = false;
							if (nPC3.boss || nPC3.netAlways || nPC3.townNPC || !nPC3.active)
							{
								flag3 = true;
							}
							else if (nPC3.netSkip <= 0)
							{
								Rectangle rect5 = Main.player[num24].getRect();
								Rectangle rect6 = nPC3.getRect();
								rect6.X -= 2500;
								rect6.Y -= 2500;
								rect6.Width += 5000;
								rect6.Height += 5000;
								if (rect5.Intersects(rect6))
								{
									flag3 = true;
								}
							}
							else
							{
								flag3 = true;
							}
							if (flag3)
							{
								try
								{
									buffer[num24].spamCount++;
									Main.txMsg++;
									Main.txData += num17;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num17;
									Netplay.serverSock[num24].networkStream.BeginWrite(buffer[num].writeBuffer, 0, num17, Netplay.serverSock[num24].ServerWriteCallBack, Netplay.serverSock[num24].networkStream);
								}
								catch
								{
								}
							}
						}
						nPC3.netSkip++;
						if (nPC3.netSkip > 4)
						{
							nPC3.netSkip = 0;
						}
						break;
					}
					case 28:
					{
						NPC nPC2 = Main.npc[number];
						for (int num21 = 0; num21 < 256; num21++)
						{
							if (num21 == ignoreClient || !buffer[num21].broadcast || !Netplay.serverSock[num21].tcpClient.Connected)
							{
								continue;
							}
							bool flag2 = false;
							if (nPC2.life <= 0)
							{
								flag2 = true;
							}
							else
							{
								Rectangle rect3 = Main.player[num21].getRect();
								Rectangle rect4 = nPC2.getRect();
								rect4.X -= 3000;
								rect4.Y -= 3000;
								rect4.Width += 6000;
								rect4.Height += 6000;
								if (rect3.Intersects(rect4))
								{
									flag2 = true;
								}
							}
							if (flag2)
							{
								try
								{
									buffer[num21].spamCount++;
									Main.txMsg++;
									Main.txData += num17;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num17;
									Netplay.serverSock[num21].networkStream.BeginWrite(buffer[num].writeBuffer, 0, num17, Netplay.serverSock[num21].ServerWriteCallBack, Netplay.serverSock[num21].networkStream);
								}
								catch
								{
								}
							}
						}
						break;
					}
					case 13:
					{
						for (int num22 = 0; num22 < 256; num22++)
						{
							if (num22 != ignoreClient && buffer[num22].broadcast && Netplay.serverSock[num22].tcpClient.Connected)
							{
								try
								{
									buffer[num22].spamCount++;
									Main.txMsg++;
									Main.txData += num17;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num17;
									Netplay.serverSock[num22].networkStream.BeginWrite(buffer[num].writeBuffer, 0, num17, Netplay.serverSock[num22].ServerWriteCallBack, Netplay.serverSock[num22].networkStream);
								}
								catch
								{
								}
							}
						}
						Main.player[number].netSkip++;
						if (Main.player[number].netSkip > 2)
						{
							Main.player[number].netSkip = 0;
						}
						break;
					}
					case 27:
					{
						Projectile projectile2 = Main.projectile[number];
						for (int num20 = 0; num20 < 256; num20++)
						{
							if (num20 == ignoreClient || !buffer[num20].broadcast || !Netplay.serverSock[num20].tcpClient.Connected)
							{
								continue;
							}
							bool flag = false;
							if (projectile2.type == 12 || Main.projPet[projectile2.type] || projectile2.aiStyle == 11 || projectile2.netImportant)
							{
								flag = true;
							}
							else
							{
								Rectangle rect = Main.player[num20].getRect();
								Rectangle rect2 = projectile2.getRect();
								rect2.X -= 5000;
								rect2.Y -= 5000;
								rect2.Width += 10000;
								rect2.Height += 10000;
								if (rect.Intersects(rect2))
								{
									flag = true;
								}
							}
							if (flag)
							{
								try
								{
									buffer[num20].spamCount++;
									Main.txMsg++;
									Main.txData += num17;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num17;
									Netplay.serverSock[num20].networkStream.BeginWrite(buffer[num].writeBuffer, 0, num17, Netplay.serverSock[num20].ServerWriteCallBack, Netplay.serverSock[num20].networkStream);
								}
								catch
								{
								}
							}
						}
						break;
					}
					default:
					{
						for (int num18 = 0; num18 < 256; num18++)
						{
							if (num18 != ignoreClient && (buffer[num18].broadcast || (Netplay.serverSock[num18].state >= 3 && msgType == 10)) && Netplay.serverSock[num18].tcpClient.Connected)
							{
								try
								{
									buffer[num18].spamCount++;
									Main.txMsg++;
									Main.txData += num17;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num17;
									Netplay.serverSock[num18].networkStream.BeginWrite(buffer[num].writeBuffer, 0, num17, Netplay.serverSock[num18].ServerWriteCallBack, Netplay.serverSock[num18].networkStream);
								}
								catch
								{
								}
							}
						}
						break;
					}
					}
				}
				else if (Netplay.serverSock[remoteClient].tcpClient.Connected)
				{
					try
					{
						buffer[remoteClient].spamCount++;
						Main.txMsg++;
						Main.txData += num17;
						Main.txMsgType[msgType]++;
						Main.txDataType[msgType] += num17;
						Netplay.serverSock[remoteClient].networkStream.BeginWrite(buffer[num].writeBuffer, 0, num17, Netplay.serverSock[remoteClient].ServerWriteCallBack, Netplay.serverSock[remoteClient].networkStream);
					}
					catch
					{
					}
				}
				if (Main.verboseNetplay)
				{
					for (int num25 = 0; num25 < num17; num25++)
					{
					}
					for (int num26 = 0; num26 < num17; num26++)
					{
						byte b3 = buffer[num].writeBuffer[num26];
					}
				}
				buffer[num].writeLocked = false;
				if (msgType == 19 && Main.netMode == 1)
				{
					SendTileSquare(num, (int)number2, (int)number3, 5);
				}
				if (msgType == 2 && Main.netMode == 2)
				{
					Netplay.serverSock[num].kill = true;
				}
			}
		}

		public static int CompressTileBlock(int xStart, int yStart, short width, short height, byte[] buffer, int bufferStart, bool packChests)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(xStart);
					binaryWriter.Write(yStart);
					binaryWriter.Write(width);
					binaryWriter.Write(height);
					CompressTileBlock_Inner(binaryWriter, xStart, yStart, width, height, packChests);
					int num = buffer.Length;
					if (bufferStart + memoryStream.Length > num)
					{
						return (int)(num - bufferStart + memoryStream.Length);
					}
					memoryStream.Position = 0L;
					MemoryStream memoryStream2 = new MemoryStream();
					using (DeflateStream deflateStream = new DeflateStream(memoryStream2, CompressionMode.Compress, true))
					{
						memoryStream.CopyTo(deflateStream);
						deflateStream.Flush();
						deflateStream.Close();
						deflateStream.Dispose();
					}
					if (memoryStream.Length <= memoryStream2.Length)
					{
						memoryStream.Position = 0L;
						buffer[bufferStart] = 0;
						bufferStart++;
						memoryStream.Read(buffer, bufferStart, (int)memoryStream.Length);
						return (int)memoryStream.Length + 1;
					}
					memoryStream2.Position = 0L;
					buffer[bufferStart] = 1;
					bufferStart++;
					memoryStream2.Read(buffer, bufferStart, (int)memoryStream2.Length);
					return (int)memoryStream2.Length + 1;
				}
			}
		}

		public static void CompressTileBlock_Inner(BinaryWriter writer, int xStart, int yStart, int width, int height, bool packChests)
		{
			short[] array = null;
			short num = 0;
			if (packChests)
			{
				array = new short[1000];
			}
			short num2 = 0;
			int num3 = 0;
			int num4 = 0;
			byte b = 0;
			byte[] array2 = new byte[13];
			Tile tile = null;
			for (int i = yStart; i < yStart + height; i++)
			{
				for (int j = xStart; j < xStart + width; j++)
				{
					Tile tile2 = Main.tile[j, i];
					if (tile2.isTheSameAs(tile))
					{
						num2++;
						continue;
					}
					if (tile != null)
					{
						if (num2 > 0)
						{
							array2[num3] = (byte)(num2 & 0xFF);
							num3++;
							if (num2 > 255)
							{
								b |= 0x80;
								array2[num3] = (byte)((num2 & 0xFF00) >> 8);
								num3++;
							}
							else
							{
								b |= 0x40;
							}
						}
						array2[num4] = b;
						writer.Write(array2, num4, num3 - num4);
						num2 = 0;
					}
					num3 = 3;
					byte b3;
					byte b2;
					b = (b2 = (b3 = 0));
					if (tile2.active())
					{
						b |= 2;
						array2[num3] = (byte)tile2.type;
						num3++;
						if (tile2.type > 255)
						{
							array2[num3] = (byte)(tile2.type >> 8);
							num3++;
							b |= 0x20;
						}
						if (tile2.type == 21 && packChests && tile2.frameX % 36 == 0 && tile2.frameY % 36 == 0)
						{
							short num5 = (short)Chest.FindChest(j, i);
							if (num5 != -1)
							{
								array[num] = num5;
								num++;
							}
						}
						if (Main.tileFrameImportant[tile2.type])
						{
							array2[num3] = (byte)(tile2.frameX & 0xFF);
							num3++;
							array2[num3] = (byte)((tile2.frameX & 0xFF00) >> 8);
							num3++;
							array2[num3] = (byte)(tile2.frameY & 0xFF);
							num3++;
							array2[num3] = (byte)((tile2.frameY & 0xFF00) >> 8);
							num3++;
						}
						if (tile2.color() != 0)
						{
							b3 |= 8;
							array2[num3] = tile2.color();
							num3++;
						}
					}
					if (tile2.wall != 0)
					{
						b |= 4;
						array2[num3] = tile2.wall;
						num3++;
						if (tile2.wallColor() != 0)
						{
							b3 |= 0x10;
							array2[num3] = tile2.wallColor();
							num3++;
						}
					}
					if (tile2.liquid != 0)
					{
						b = (tile2.lava() ? ((byte)(b | 0x10)) : ((!tile2.honey()) ? ((byte)(b | 8)) : ((byte)(b | 0x18))));
						array2[num3] = tile2.liquid;
						num3++;
					}
					if (tile2.wire())
					{
						b2 |= 2;
					}
					if (tile2.wire2())
					{
						b2 |= 4;
					}
					if (tile2.wire3())
					{
						b2 |= 8;
					}
					int num6 = (tile2.halfBrick() ? 16 : ((tile2.slope() != 0) ? (tile2.slope() + 1 << 4) : 0));
					b2 |= (byte)num6;
					if (tile2.actuator())
					{
						b3 |= 2;
					}
					if (tile2.inActive())
					{
						b3 |= 4;
					}
					num4 = 2;
					if (b3 != 0)
					{
						b2 |= 1;
						array2[num4] = b3;
						num4--;
					}
					if (b2 != 0)
					{
						b |= 1;
						array2[num4] = b2;
						num4--;
					}
					tile = tile2;
				}
			}
			if (num2 > 0)
			{
				array2[num3] = (byte)(num2 & 0xFF);
				num3++;
				if (num2 > 255)
				{
					b |= 0x80;
					array2[num3] = (byte)((num2 & 0xFF00) >> 8);
					num3++;
				}
				else
				{
					b |= 0x40;
				}
			}
			array2[num4] = b;
			writer.Write(array2, num4, num3 - num4);
			if (packChests)
			{
				writer.Write(num);
				for (int k = 0; k < num; k++)
				{
					Chest chest = Main.chest[array[k]];
					writer.Write(array[k]);
					writer.Write((short)chest.x);
					writer.Write((short)chest.y);
					writer.Write(chest.name);
				}
			}
		}

		public static void DecompressTileBlock(byte[] buffer, int bufferStart, int bufferLength, bool packedChests)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(buffer, bufferStart, bufferLength);
				memoryStream.Position = 0L;
				MemoryStream memoryStream3;
				if (memoryStream.ReadByte() != 0)
				{
					MemoryStream memoryStream2 = new MemoryStream();
					using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress, true))
					{
						deflateStream.CopyTo(memoryStream2);
						deflateStream.Close();
					}
					memoryStream3 = memoryStream2;
					memoryStream3.Position = 0L;
				}
				else
				{
					memoryStream3 = memoryStream;
					memoryStream3.Position = 1L;
				}
				using (BinaryReader binaryReader = new BinaryReader(memoryStream3))
				{
					int xStart = binaryReader.ReadInt32();
					int yStart = binaryReader.ReadInt32();
					short width = binaryReader.ReadInt16();
					short height = binaryReader.ReadInt16();
					DecompressTileBlock_Inner(binaryReader, xStart, yStart, width, height, packedChests);
				}
			}
		}

		public static void DecompressTileBlock_Inner(BinaryReader reader, int xStart, int yStart, int width, int height, bool packedChests)
		{
			Tile tile = null;
			int num = 0;
			for (int i = yStart; i < yStart + height; i++)
			{
				for (int j = xStart; j < xStart + width; j++)
				{
					if (num != 0)
					{
						num--;
						if (Main.tile[j, i] == null)
						{
							Main.tile[j, i] = new Tile(tile);
						}
						else
						{
							Main.tile[j, i].CopyFrom(tile);
						}
						continue;
					}
					byte b2;
					byte b = (b2 = 0);
					tile = Main.tile[j, i];
					if (tile == null)
					{
						tile = new Tile();
						Main.tile[j, i] = tile;
					}
					else
					{
						tile.Clear();
					}
					byte b3 = reader.ReadByte();
					if ((b3 & 1) == 1)
					{
						b = reader.ReadByte();
						if ((b & 1) == 1)
						{
							b2 = reader.ReadByte();
						}
					}
					bool flag = tile.active();
					byte b4;
					if ((b3 & 2) == 2)
					{
						tile.active(true);
						ushort type = tile.type;
						int num2;
						if ((b3 & 0x20) == 32)
						{
							b4 = reader.ReadByte();
							num2 = reader.ReadByte();
							num2 = (num2 << 8) | b4;
						}
						else
						{
							num2 = reader.ReadByte();
						}
						tile.type = (ushort)num2;
						if (Main.tileFrameImportant[num2])
						{
							tile.frameX = reader.ReadInt16();
							tile.frameY = reader.ReadInt16();
						}
						else if (!flag || tile.type != type)
						{
							tile.frameX = -1;
							tile.frameY = -1;
						}
						if ((b2 & 8) == 8)
						{
							tile.color(reader.ReadByte());
						}
					}
					if ((b3 & 4) == 4)
					{
						tile.wall = reader.ReadByte();
						if ((b2 & 0x10) == 16)
						{
							tile.wallColor(reader.ReadByte());
						}
					}
					b4 = (byte)((b3 & 0x18) >> 3);
					if (b4 != 0)
					{
						tile.liquid = reader.ReadByte();
						if (b4 > 1)
						{
							if (b4 == 2)
							{
								tile.lava(true);
							}
							else
							{
								tile.honey(true);
							}
						}
					}
					if (b > 1)
					{
						if ((b & 2) == 2)
						{
							tile.wire(true);
						}
						if ((b & 4) == 4)
						{
							tile.wire2(true);
						}
						if ((b & 8) == 8)
						{
							tile.wire3(true);
						}
						b4 = (byte)((b & 0x70) >> 4);
						if (b4 != 0 && Main.tileSolid[tile.type])
						{
							if (b4 == 1)
							{
								tile.halfBrick(true);
							}
							else
							{
								tile.slope((byte)(b4 - 1));
							}
						}
					}
					if (b2 > 0)
					{
						if ((b2 & 2) == 2)
						{
							tile.actuator(true);
						}
						if ((b2 & 4) == 4)
						{
							tile.inActive(true);
						}
					}
					switch ((byte)((b3 & 0xC0) >> 6))
					{
					case 0:
						num = 0;
						break;
					case 1:
						num = reader.ReadByte();
						break;
					default:
						num = reader.ReadInt16();
						break;
					}
				}
			}
			short num3 = reader.ReadInt16();
			for (int k = 0; k < num3; k++)
			{
				short num4 = reader.ReadInt16();
				short x = reader.ReadInt16();
				short y = reader.ReadInt16();
				string name = reader.ReadString();
				if (num4 >= 0 && num4 < 1000)
				{
					if (Main.chest[num4] == null)
					{
						Main.chest[num4] = new Chest();
					}
					Main.chest[num4].name = name;
					Main.chest[num4].x = x;
					Main.chest[num4].y = y;
				}
			}
		}

		public static void RecieveBytes(byte[] bytes, int streamLength, int i = 256)
		{
			lock (buffer[i])
			{
				try
				{
					Buffer.BlockCopy(bytes, 0, buffer[i].readBuffer, buffer[i].totalData, streamLength);
					buffer[i].totalData += streamLength;
					buffer[i].checkBytes = true;
				}
				catch
				{
					if (Main.netMode == 1)
					{
						Main.menuMode = 15;
						Main.statusText = "Bad header lead to a read buffer overflow.";
						Netplay.disconnect = true;
					}
					else
					{
						Netplay.serverSock[i].kill = true;
					}
				}
			}
		}

		public static void CheckBytes(int i = 256)
		{
			lock (buffer[i])
			{
				int num = 0;
				int num2 = 2;
				if (buffer[i].totalData < num2)
				{
					return;
				}
				if (buffer[i].messageLength == 0)
				{
					buffer[i].messageLength = BitConverter.ToUInt16(buffer[i].readBuffer, 0);
				}
				while (buffer[i].totalData >= buffer[i].messageLength + num && buffer[i].messageLength > 0)
				{
					if (!Main.ignoreErrors)
					{
						buffer[i].GetData(num + num2, buffer[i].messageLength - num2);
					}
					else
					{
						try
						{
							buffer[i].GetData(num + num2, buffer[i].messageLength - num2);
						}
						catch
						{
						}
					}
					num += buffer[i].messageLength;
					if (buffer[i].totalData - num >= num2)
					{
						buffer[i].messageLength = BitConverter.ToUInt16(buffer[i].readBuffer, num);
					}
					else
					{
						buffer[i].messageLength = 0;
					}
				}
				if (num == buffer[i].totalData)
				{
					buffer[i].totalData = 0;
				}
				else if (num > 0)
				{
					Buffer.BlockCopy(buffer[i].readBuffer, num, buffer[i].readBuffer, 0, buffer[i].totalData - num);
					buffer[i].totalData -= num;
				}
				buffer[i].checkBytes = false;
			}
		}

		public static void BootPlayer(int plr, string msg)
		{
			SendData(2, plr, -1, msg);
		}

		public static void SendTileSquare(int whoAmi, int tileX, int tileY, int size)
		{
			int num = (size - 1) / 2;
			SendData(20, whoAmi, -1, "", size, tileX - num, tileY - num);
		}

		public static void SendTravelShop()
		{
			if (Main.netMode == 2)
			{
				SendData(72);
			}
		}

		public static void SendAnglerQuest()
		{
			if (Main.netMode != 2)
			{
				return;
			}
			for (int i = 0; i < 255; i++)
			{
				if (Netplay.serverSock[i].state == 10)
				{
					SendData(74, i, -1, Main.player[i].name, Main.anglerQuest);
				}
			}
		}

		public static void SendSection(int whoAmi, int sectionX, int sectionY, bool skipSent = false)
		{
			if (Main.netMode != 2)
			{
				return;
			}
			try
			{
				if (sectionX < 0 || sectionY < 0 || sectionX >= Main.maxSectionsX || sectionY >= Main.maxSectionsY || (skipSent && Netplay.serverSock[whoAmi].tileSection[sectionX, sectionY]))
				{
					return;
				}
				Netplay.serverSock[whoAmi].tileSection[sectionX, sectionY] = true;
				int number = sectionX * 200;
				int num = sectionY * 150;
				int num2 = 150;
				for (int i = num; i < num + 150; i += num2)
				{
					SendData(10, whoAmi, -1, "", number, i, 200f, num2);
				}
				for (int j = 0; j < 200; j++)
				{
					if (Main.npc[j].active && Main.npc[j].townNPC)
					{
						int sectionX2 = Netplay.GetSectionX((int)(Main.npc[j].position.X / 16f));
						int sectionY2 = Netplay.GetSectionY((int)(Main.npc[j].position.Y / 16f));
						if (sectionX2 == sectionX && sectionY2 == sectionY)
						{
							SendData(23, whoAmi, -1, "", j);
						}
					}
				}
			}
			catch
			{
			}
		}

		public static void greetPlayer(int plr)
		{
			if (Main.motd == "")
			{
				SendData(25, plr, -1, Lang.mp[18] + " " + Main.worldName + "!", 255, 255f, 240f, 20f);
			}
			else
			{
				SendData(25, plr, -1, Main.motd, 255, 255f, 240f, 20f);
			}
			string text = "";
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					text = ((!(text == "")) ? (text + ", " + Main.player[i].name) : (text + Main.player[i].name));
				}
			}
			SendData(25, plr, -1, "Current players: " + text + ".", 255, 255f, 240f, 20f);
		}

		public static void sendWater(int x, int y)
		{
			if (Main.netMode == 1)
			{
				SendData(48, -1, -1, "", x, y);
				return;
			}
			for (int i = 0; i < 256; i++)
			{
				if ((buffer[i].broadcast || Netplay.serverSock[i].state >= 3) && Netplay.serverSock[i].tcpClient.Connected)
				{
					int num = x / 200;
					int num2 = y / 150;
					if (Netplay.serverSock[i].tileSection[num, num2])
					{
						SendData(48, i, -1, "", x, y);
					}
				}
			}
		}

		public static void syncPlayers()
		{
			bool flag = false;
			for (int i = 0; i < 255; i++)
			{
				int num = 0;
				if (Main.player[i].active)
				{
					num = 1;
				}
				if (Netplay.serverSock[i].state == 10)
				{
					if (Main.autoShutdown && !flag)
					{
						string text = Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint.ToString();
						string text2 = text;
						for (int j = 0; j < text.Length; j++)
						{
							if (text.Substring(j, 1) == ":")
							{
								text2 = text.Substring(0, j);
							}
						}
						if (text2 == "127.0.0.1")
						{
							flag = true;
						}
					}
					SendData(14, -1, i, "", i, num);
					SendData(4, -1, i, Main.player[i].name, i);
					SendData(13, -1, i, "", i);
					SendData(16, -1, i, "", i);
					SendData(30, -1, i, "", i);
					SendData(45, -1, i, "", i);
					SendData(42, -1, i, "", i);
					SendData(50, -1, i, "", i);
					for (int k = 0; k < 59; k++)
					{
						SendData(5, -1, i, Main.player[i].inventory[k].name, i, k, (int)Main.player[i].inventory[k].prefix);
					}
					SendData(5, -1, i, Main.player[i].armor[0].name, i, 59f, (int)Main.player[i].armor[0].prefix);
					SendData(5, -1, i, Main.player[i].armor[1].name, i, 60f, (int)Main.player[i].armor[1].prefix);
					SendData(5, -1, i, Main.player[i].armor[2].name, i, 61f, (int)Main.player[i].armor[2].prefix);
					SendData(5, -1, i, Main.player[i].armor[3].name, i, 62f, (int)Main.player[i].armor[3].prefix);
					SendData(5, -1, i, Main.player[i].armor[4].name, i, 63f, (int)Main.player[i].armor[4].prefix);
					SendData(5, -1, i, Main.player[i].armor[5].name, i, 64f, (int)Main.player[i].armor[5].prefix);
					SendData(5, -1, i, Main.player[i].armor[6].name, i, 65f, (int)Main.player[i].armor[6].prefix);
					SendData(5, -1, i, Main.player[i].armor[7].name, i, 66f, (int)Main.player[i].armor[7].prefix);
					SendData(5, -1, i, Main.player[i].armor[8].name, i, 67f, (int)Main.player[i].armor[8].prefix);
					SendData(5, -1, i, Main.player[i].armor[9].name, i, 68f, (int)Main.player[i].armor[9].prefix);
					SendData(5, -1, i, Main.player[i].armor[10].name, i, 69f, (int)Main.player[i].armor[10].prefix);
					SendData(5, -1, i, Main.player[i].armor[11].name, i, 70f, (int)Main.player[i].armor[11].prefix);
					SendData(5, -1, i, Main.player[i].armor[12].name, i, 71f, (int)Main.player[i].armor[12].prefix);
					SendData(5, -1, i, Main.player[i].armor[13].name, i, 72f, (int)Main.player[i].armor[13].prefix);
					SendData(5, -1, i, Main.player[i].armor[14].name, i, 73f, (int)Main.player[i].armor[14].prefix);
					SendData(5, -1, i, Main.player[i].armor[15].name, i, 74f, (int)Main.player[i].armor[15].prefix);
					SendData(5, -1, i, Main.player[i].dye[0].name, i, 75f, (int)Main.player[i].dye[0].prefix);
					SendData(5, -1, i, Main.player[i].dye[1].name, i, 76f, (int)Main.player[i].dye[1].prefix);
					SendData(5, -1, i, Main.player[i].dye[2].name, i, 77f, (int)Main.player[i].dye[2].prefix);
					SendData(5, -1, i, Main.player[i].dye[3].name, i, 78f, (int)Main.player[i].dye[3].prefix);
					SendData(5, -1, i, Main.player[i].dye[4].name, i, 79f, (int)Main.player[i].dye[4].prefix);
					SendData(5, -1, i, Main.player[i].dye[5].name, i, 80f, (int)Main.player[i].dye[5].prefix);
					SendData(5, -1, i, Main.player[i].dye[6].name, i, 81f, (int)Main.player[i].dye[6].prefix);
					SendData(5, -1, i, Main.player[i].dye[7].name, i, 82f, (int)Main.player[i].dye[7].prefix);
					if (!Netplay.serverSock[i].announced)
					{
						Netplay.serverSock[i].announced = true;
						SendData(25, -1, i, Main.player[i].name + " " + Lang.mp[19], 255, 255f, 240f, 20f);
						if (Main.dedServ)
						{
							Console.WriteLine(Main.player[i].name + " " + Lang.mp[19]);
						}
					}
					continue;
				}
				num = 0;
				SendData(14, -1, i, "", i, num);
				if (Netplay.serverSock[i].announced)
				{
					Netplay.serverSock[i].announced = false;
					SendData(25, -1, i, Netplay.serverSock[i].oldName + " " + Lang.mp[20], 255, 255f, 240f, 20f);
					if (Main.dedServ)
					{
						Console.WriteLine(Netplay.serverSock[i].oldName + " " + Lang.mp[20]);
					}
				}
			}
			bool flag2 = false;
			for (int l = 0; l < 200; l++)
			{
				if (Main.npc[l].active && Main.npc[l].townNPC && NPC.TypeToNum(Main.npc[l].type) != -1)
				{
					if (!flag2 && Main.npc[l].type == 368)
					{
						flag2 = true;
					}
					int num2 = 0;
					if (Main.npc[l].homeless)
					{
						num2 = 1;
					}
					SendData(60, -1, -1, "", l, Main.npc[l].homeTileX, Main.npc[l].homeTileY, num2);
				}
			}
			if (flag2)
			{
				SendTravelShop();
			}
			SendAnglerQuest();
			if (Main.autoShutdown && !flag)
			{
				WorldFile.saveWorld();
				Netplay.disconnect = true;
			}
		}
	}
}
