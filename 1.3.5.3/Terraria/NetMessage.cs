using System;
using System.IO;
using Ionic.Zlib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.GameContent.NetModules;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Net;
using Terraria.Social;

namespace Terraria
{
	public class NetMessage
	{
		public static MessageBuffer[] buffer = new MessageBuffer[257];

		private static PlayerDeathReason _currentPlayerDeathReason;

		public static void SendChatMessageToClient(NetworkText text, Color color, int playerId)
		{
			NetPacket packet = NetTextModule.SerializeServerMessage(text, color, byte.MaxValue);
			NetManager.Instance.SendToClient(packet, playerId);
		}

		public static void BroadcastChatMessage(NetworkText text, Color color, int excludedPlayer = -1)
		{
			NetPacket packet = NetTextModule.SerializeServerMessage(text, color, byte.MaxValue);
			NetManager.Instance.Broadcast(packet, excludedPlayer);
		}

		public static void SendChatMessageFromClient(ChatMessage text)
		{
			NetPacket packet = NetTextModule.SerializeClientMessage(text);
			NetManager.Instance.SendToServer(packet);
		}

		public static void SendData(int msgType, int remoteClient = -1, int ignoreClient = -1, NetworkText text = null, int number = 0, float number2 = 0f, float number3 = 0f, float number4 = 0f, int number5 = 0, int number6 = 0, int number7 = 0)
		{
			if (Main.netMode == 0)
			{
				return;
			}
			int num = 256;
			if (text == null)
			{
				text = NetworkText.Empty;
			}
			if (Main.netMode == 2 && remoteClient >= 0)
			{
				num = remoteClient;
			}
			lock (buffer[num])
			{
				BinaryWriter writer = buffer[num].writer;
				if (writer == null)
				{
					buffer[num].ResetWriter();
					writer = buffer[num].writer;
				}
				writer.BaseStream.Position = 0L;
				long position = writer.BaseStream.Position;
				writer.BaseStream.Position += 2L;
				writer.Write((byte)msgType);
				switch (msgType)
				{
				case 1:
					writer.Write("Terraria" + 194);
					break;
				case 2:
					text.Serialize(writer);
					if (Main.dedServ)
					{
						Console.WriteLine(Language.GetTextValue("CLI.ClientWasBooted", Netplay.Clients[num].Socket.GetRemoteAddress().ToString(), text));
					}
					break;
				case 3:
					writer.Write((byte)remoteClient);
					break;
				case 4:
				{
					Player player3 = Main.player[number];
					writer.Write((byte)number);
					writer.Write((byte)player3.skinVariant);
					writer.Write((byte)player3.hair);
					writer.Write(player3.name);
					writer.Write(player3.hairDye);
					BitsByte bitsByte10 = (byte)0;
					for (int n = 0; n < 8; n++)
					{
						bitsByte10[n] = player3.hideVisual[n];
					}
					writer.Write(bitsByte10);
					bitsByte10 = (byte)0;
					for (int num6 = 0; num6 < 2; num6++)
					{
						bitsByte10[num6] = player3.hideVisual[num6 + 8];
					}
					writer.Write(bitsByte10);
					writer.Write(player3.hideMisc);
					writer.WriteRGB(player3.hairColor);
					writer.WriteRGB(player3.skinColor);
					writer.WriteRGB(player3.eyeColor);
					writer.WriteRGB(player3.shirtColor);
					writer.WriteRGB(player3.underShirtColor);
					writer.WriteRGB(player3.pantsColor);
					writer.WriteRGB(player3.shoeColor);
					BitsByte bitsByte11 = (byte)0;
					if (player3.difficulty == 1)
					{
						bitsByte11[0] = true;
					}
					else if (player3.difficulty == 2)
					{
						bitsByte11[1] = true;
					}
					bitsByte11[2] = player3.extraAccessory;
					writer.Write(bitsByte11);
					break;
				}
				case 5:
				{
					writer.Write((byte)number);
					writer.Write((byte)number2);
					Player player5 = Main.player[number];
					Item item4 = null;
					int num7 = 0;
					int num8 = 0;
					item4 = ((number2 > (float)(58 + player5.armor.Length + player5.dye.Length + player5.miscEquips.Length + player5.miscDyes.Length + player5.bank.item.Length + player5.bank2.item.Length + 1)) ? player5.bank3.item[(int)number2 - 58 - (player5.armor.Length + player5.dye.Length + player5.miscEquips.Length + player5.miscDyes.Length + player5.bank.item.Length + player5.bank2.item.Length + 1) - 1] : ((number2 > (float)(58 + player5.armor.Length + player5.dye.Length + player5.miscEquips.Length + player5.miscDyes.Length + player5.bank.item.Length + player5.bank2.item.Length)) ? player5.trashItem : ((number2 > (float)(58 + player5.armor.Length + player5.dye.Length + player5.miscEquips.Length + player5.miscDyes.Length + player5.bank.item.Length)) ? player5.bank2.item[(int)number2 - 58 - (player5.armor.Length + player5.dye.Length + player5.miscEquips.Length + player5.miscDyes.Length + player5.bank.item.Length) - 1] : ((number2 > (float)(58 + player5.armor.Length + player5.dye.Length + player5.miscEquips.Length + player5.miscDyes.Length)) ? player5.bank.item[(int)number2 - 58 - (player5.armor.Length + player5.dye.Length + player5.miscEquips.Length + player5.miscDyes.Length) - 1] : ((number2 > (float)(58 + player5.armor.Length + player5.dye.Length + player5.miscEquips.Length)) ? player5.miscDyes[(int)number2 - 58 - (player5.armor.Length + player5.dye.Length + player5.miscEquips.Length) - 1] : ((number2 > (float)(58 + player5.armor.Length + player5.dye.Length)) ? player5.miscEquips[(int)number2 - 58 - (player5.armor.Length + player5.dye.Length) - 1] : ((number2 > (float)(58 + player5.armor.Length)) ? player5.dye[(int)number2 - 58 - player5.armor.Length - 1] : ((!(number2 > 58f)) ? player5.inventory[(int)number2] : player5.armor[(int)number2 - 58 - 1]))))))));
					if (item4.Name == "" || item4.stack == 0 || item4.type == 0)
					{
						item4.SetDefaults();
					}
					num7 = item4.stack;
					num8 = item4.netID;
					if (num7 < 0)
					{
						num7 = 0;
					}
					writer.Write((short)num7);
					writer.Write((byte)number3);
					writer.Write((short)num8);
					break;
				}
				case 7:
				{
					writer.Write((int)Main.time);
					BitsByte bitsByte4 = (byte)0;
					bitsByte4[0] = Main.dayTime;
					bitsByte4[1] = Main.bloodMoon;
					bitsByte4[2] = Main.eclipse;
					writer.Write(bitsByte4);
					writer.Write((byte)Main.moonPhase);
					writer.Write((short)Main.maxTilesX);
					writer.Write((short)Main.maxTilesY);
					writer.Write((short)Main.spawnTileX);
					writer.Write((short)Main.spawnTileY);
					writer.Write((short)Main.worldSurface);
					writer.Write((short)Main.rockLayer);
					writer.Write(Main.worldID);
					writer.Write(Main.worldName);
					writer.Write(Main.ActiveWorldFileData.UniqueId.ToByteArray());
					writer.Write(Main.ActiveWorldFileData.WorldGeneratorVersion);
					writer.Write((byte)Main.moonType);
					writer.Write((byte)WorldGen.treeBG);
					writer.Write((byte)WorldGen.corruptBG);
					writer.Write((byte)WorldGen.jungleBG);
					writer.Write((byte)WorldGen.snowBG);
					writer.Write((byte)WorldGen.hallowBG);
					writer.Write((byte)WorldGen.crimsonBG);
					writer.Write((byte)WorldGen.desertBG);
					writer.Write((byte)WorldGen.oceanBG);
					writer.Write((byte)Main.iceBackStyle);
					writer.Write((byte)Main.jungleBackStyle);
					writer.Write((byte)Main.hellBackStyle);
					writer.Write(Main.windSpeedSet);
					writer.Write((byte)Main.numClouds);
					for (int j = 0; j < 3; j++)
					{
						writer.Write(Main.treeX[j]);
					}
					for (int k = 0; k < 4; k++)
					{
						writer.Write((byte)Main.treeStyle[k]);
					}
					for (int l = 0; l < 3; l++)
					{
						writer.Write(Main.caveBackX[l]);
					}
					for (int m = 0; m < 4; m++)
					{
						writer.Write((byte)Main.caveBackStyle[m]);
					}
					if (!Main.raining)
					{
						Main.maxRaining = 0f;
					}
					writer.Write(Main.maxRaining);
					BitsByte bitsByte5 = (byte)0;
					bitsByte5[0] = WorldGen.shadowOrbSmashed;
					bitsByte5[1] = NPC.downedBoss1;
					bitsByte5[2] = NPC.downedBoss2;
					bitsByte5[3] = NPC.downedBoss3;
					bitsByte5[4] = Main.hardMode;
					bitsByte5[5] = NPC.downedClown;
					bitsByte5[7] = NPC.downedPlantBoss;
					writer.Write(bitsByte5);
					BitsByte bitsByte6 = (byte)0;
					bitsByte6[0] = NPC.downedMechBoss1;
					bitsByte6[1] = NPC.downedMechBoss2;
					bitsByte6[2] = NPC.downedMechBoss3;
					bitsByte6[3] = NPC.downedMechBossAny;
					bitsByte6[4] = Main.cloudBGActive >= 1f;
					bitsByte6[5] = WorldGen.crimson;
					bitsByte6[6] = Main.pumpkinMoon;
					bitsByte6[7] = Main.snowMoon;
					writer.Write(bitsByte6);
					BitsByte bitsByte7 = (byte)0;
					bitsByte7[0] = Main.expertMode;
					bitsByte7[1] = Main.fastForwardTime;
					bitsByte7[2] = Main.slimeRain;
					bitsByte7[3] = NPC.downedSlimeKing;
					bitsByte7[4] = NPC.downedQueenBee;
					bitsByte7[5] = NPC.downedFishron;
					bitsByte7[6] = NPC.downedMartians;
					bitsByte7[7] = NPC.downedAncientCultist;
					writer.Write(bitsByte7);
					BitsByte bitsByte8 = (byte)0;
					bitsByte8[0] = NPC.downedMoonlord;
					bitsByte8[1] = NPC.downedHalloweenKing;
					bitsByte8[2] = NPC.downedHalloweenTree;
					bitsByte8[3] = NPC.downedChristmasIceQueen;
					bitsByte8[4] = NPC.downedChristmasSantank;
					bitsByte8[5] = NPC.downedChristmasTree;
					bitsByte8[6] = NPC.downedGolemBoss;
					bitsByte8[7] = BirthdayParty.PartyIsUp;
					writer.Write(bitsByte8);
					BitsByte bitsByte9 = (byte)0;
					bitsByte9[0] = NPC.downedPirates;
					bitsByte9[1] = NPC.downedFrost;
					bitsByte9[2] = NPC.downedGoblins;
					bitsByte9[3] = Sandstorm.Happening;
					bitsByte9[4] = DD2Event.Ongoing;
					bitsByte9[5] = DD2Event.DownedInvasionT1;
					bitsByte9[6] = DD2Event.DownedInvasionT2;
					bitsByte9[7] = DD2Event.DownedInvasionT3;
					writer.Write(bitsByte9);
					writer.Write((sbyte)Main.invasionType);
					if (SocialAPI.Network != null)
					{
						writer.Write(SocialAPI.Network.GetLobbyId());
					}
					else
					{
						writer.Write(0uL);
					}
					writer.Write(Sandstorm.IntendedSeverity);
					break;
				}
				case 8:
					writer.Write(number);
					writer.Write((int)number2);
					break;
				case 9:
					writer.Write(number);
					text.Serialize(writer);
					break;
				case 10:
				{
					int num11 = CompressTileBlock(number, (int)number2, (short)number3, (short)number4, buffer[num].writeBuffer, (int)writer.BaseStream.Position);
					writer.BaseStream.Position += num11;
					break;
				}
				case 11:
					writer.Write((short)number);
					writer.Write((short)number2);
					writer.Write((short)number3);
					writer.Write((short)number4);
					break;
				case 12:
					writer.Write((byte)number);
					writer.Write((short)Main.player[number].SpawnX);
					writer.Write((short)Main.player[number].SpawnY);
					break;
				case 13:
				{
					Player player4 = Main.player[number];
					writer.Write((byte)number);
					BitsByte bitsByte12 = (byte)0;
					bitsByte12[0] = player4.controlUp;
					bitsByte12[1] = player4.controlDown;
					bitsByte12[2] = player4.controlLeft;
					bitsByte12[3] = player4.controlRight;
					bitsByte12[4] = player4.controlJump;
					bitsByte12[5] = player4.controlUseItem;
					bitsByte12[6] = player4.direction == 1;
					writer.Write(bitsByte12);
					BitsByte bitsByte13 = (byte)0;
					bitsByte13[0] = player4.pulley;
					bitsByte13[1] = player4.pulley && player4.pulleyDir == 2;
					bitsByte13[2] = player4.velocity != Vector2.Zero;
					bitsByte13[3] = player4.vortexStealthActive;
					bitsByte13[4] = player4.gravDir == 1f;
					bitsByte13[5] = player4.shieldRaised;
					writer.Write(bitsByte13);
					writer.Write((byte)player4.selectedItem);
					writer.WriteVector2(player4.position);
					if (bitsByte13[2])
					{
						writer.WriteVector2(player4.velocity);
					}
					break;
				}
				case 14:
					writer.Write((byte)number);
					writer.Write((byte)number2);
					break;
				case 16:
					writer.Write((byte)number);
					writer.Write((short)Main.player[number].statLife);
					writer.Write((short)Main.player[number].statLifeMax);
					break;
				case 17:
					writer.Write((byte)number);
					writer.Write((short)number2);
					writer.Write((short)number3);
					writer.Write((short)number4);
					writer.Write((byte)number5);
					break;
				case 18:
					writer.Write((byte)(Main.dayTime ? 1u : 0u));
					writer.Write((int)Main.time);
					writer.Write(Main.sunModY);
					writer.Write(Main.moonModY);
					break;
				case 19:
					writer.Write((byte)number);
					writer.Write((short)number2);
					writer.Write((short)number3);
					writer.Write((number4 == 1f) ? ((byte)1) : ((byte)0));
					break;
				case 20:
				{
					int num13 = number;
					int num14 = (int)number2;
					int num15 = (int)number3;
					if (num13 < 0)
					{
						num13 = 0;
					}
					if (num14 < num13)
					{
						num14 = num13;
					}
					if (num14 >= Main.maxTilesX + num13)
					{
						num14 = Main.maxTilesX - num13 - 1;
					}
					if (num15 < num13)
					{
						num15 = num13;
					}
					if (num15 >= Main.maxTilesY + num13)
					{
						num15 = Main.maxTilesY - num13 - 1;
					}
					if (number5 == 0)
					{
						writer.Write((ushort)(num13 & 0x7FFF));
					}
					else
					{
						writer.Write((ushort)((num13 & 0x7FFF) | 0x8000));
						writer.Write((byte)number5);
					}
					writer.Write((short)num14);
					writer.Write((short)num15);
					for (int num16 = num14; num16 < num14 + num13; num16++)
					{
						for (int num17 = num15; num17 < num15 + num13; num17++)
						{
							BitsByte bitsByte15 = (byte)0;
							BitsByte bitsByte16 = (byte)0;
							byte b3 = 0;
							byte b4 = 0;
							Tile tile = Main.tile[num16, num17];
							bitsByte15[0] = tile.active();
							bitsByte15[2] = tile.wall > 0;
							bitsByte15[3] = tile.liquid > 0 && Main.netMode == 2;
							bitsByte15[4] = tile.wire();
							bitsByte15[5] = tile.halfBrick();
							bitsByte15[6] = tile.actuator();
							bitsByte15[7] = tile.inActive();
							bitsByte16[0] = tile.wire2();
							bitsByte16[1] = tile.wire3();
							if (tile.active() && tile.color() > 0)
							{
								bitsByte16[2] = true;
								b3 = tile.color();
							}
							if (tile.wall > 0 && tile.wallColor() > 0)
							{
								bitsByte16[3] = true;
								b4 = tile.wallColor();
							}
							bitsByte16 = (byte)((byte)bitsByte16 + (byte)(tile.slope() << 4));
							bitsByte16[7] = tile.wire4();
							writer.Write(bitsByte15);
							writer.Write(bitsByte16);
							if (b3 > 0)
							{
								writer.Write(b3);
							}
							if (b4 > 0)
							{
								writer.Write(b4);
							}
							if (tile.active())
							{
								writer.Write(tile.type);
								if (Main.tileFrameImportant[tile.type])
								{
									writer.Write(tile.frameX);
									writer.Write(tile.frameY);
								}
							}
							if (tile.wall > 0)
							{
								writer.Write(tile.wall);
							}
							if (tile.liquid > 0 && Main.netMode == 2)
							{
								writer.Write(tile.liquid);
								writer.Write(tile.liquidType());
							}
						}
					}
					break;
				}
				case 21:
				case 90:
				{
					Item item5 = Main.item[number];
					writer.Write((short)number);
					writer.WriteVector2(item5.position);
					writer.WriteVector2(item5.velocity);
					writer.Write((short)item5.stack);
					writer.Write(item5.prefix);
					writer.Write((byte)number2);
					short value5 = 0;
					if (item5.active && item5.stack > 0)
					{
						value5 = (short)item5.netID;
					}
					writer.Write(value5);
					break;
				}
				case 22:
					writer.Write((short)number);
					writer.Write((byte)Main.item[number].owner);
					break;
				case 23:
				{
					NPC nPC2 = Main.npc[number];
					writer.Write((short)number);
					writer.WriteVector2(nPC2.position);
					writer.WriteVector2(nPC2.velocity);
					writer.Write((ushort)nPC2.target);
					int num2 = nPC2.life;
					if (!nPC2.active)
					{
						num2 = 0;
					}
					if (!nPC2.active || nPC2.life <= 0)
					{
						nPC2.netSkip = 0;
					}
					short value = (short)nPC2.netID;
					bool[] array = new bool[4];
					BitsByte bitsByte3 = (byte)0;
					bitsByte3[0] = nPC2.direction > 0;
					bitsByte3[1] = nPC2.directionY > 0;
					bitsByte3[2] = (array[0] = nPC2.ai[0] != 0f);
					bitsByte3[3] = (array[1] = nPC2.ai[1] != 0f);
					bitsByte3[4] = (array[2] = nPC2.ai[2] != 0f);
					bitsByte3[5] = (array[3] = nPC2.ai[3] != 0f);
					bitsByte3[6] = nPC2.spriteDirection > 0;
					bitsByte3[7] = num2 == nPC2.lifeMax;
					writer.Write(bitsByte3);
					for (int i = 0; i < NPC.maxAI; i++)
					{
						if (array[i])
						{
							writer.Write(nPC2.ai[i]);
						}
					}
					writer.Write(value);
					if (!bitsByte3[7])
					{
						byte b = Main.npcLifeBytes[nPC2.netID];
						writer.Write(b);
						switch (b)
						{
						case 2:
							writer.Write((short)num2);
							break;
						case 4:
							writer.Write(num2);
							break;
						default:
							writer.Write((sbyte)num2);
							break;
						}
					}
					if (nPC2.type >= 0 && nPC2.type < 580 && Main.npcCatchable[nPC2.type])
					{
						writer.Write((byte)nPC2.releaseOwner);
					}
					break;
				}
				case 24:
					writer.Write((short)number);
					writer.Write((byte)number2);
					break;
				case 107:
					writer.Write((byte)number2);
					writer.Write((byte)number3);
					writer.Write((byte)number4);
					text.Serialize(writer);
					writer.Write((short)number5);
					break;
				case 27:
				{
					Projectile projectile = Main.projectile[number];
					writer.Write((short)projectile.identity);
					writer.WriteVector2(projectile.position);
					writer.WriteVector2(projectile.velocity);
					writer.Write(projectile.knockBack);
					writer.Write((short)projectile.damage);
					writer.Write((byte)projectile.owner);
					writer.Write((short)projectile.type);
					BitsByte bitsByte14 = (byte)0;
					for (int num9 = 0; num9 < Projectile.maxAI; num9++)
					{
						if (projectile.ai[num9] != 0f)
						{
							bitsByte14[num9] = true;
						}
					}
					if (projectile.type > 0 && projectile.type < 714 && ProjectileID.Sets.NeedsUUID[projectile.type])
					{
						bitsByte14[Projectile.maxAI] = true;
					}
					writer.Write(bitsByte14);
					for (int num10 = 0; num10 < Projectile.maxAI; num10++)
					{
						if (bitsByte14[num10])
						{
							writer.Write(projectile.ai[num10]);
						}
					}
					if (bitsByte14[Projectile.maxAI])
					{
						writer.Write((short)projectile.projUUID);
					}
					break;
				}
				case 28:
					writer.Write((short)number);
					writer.Write((short)number2);
					writer.Write(number3);
					writer.Write((byte)(number4 + 1f));
					writer.Write((byte)number5);
					break;
				case 29:
					writer.Write((short)number);
					writer.Write((byte)number2);
					break;
				case 30:
					writer.Write((byte)number);
					writer.Write(Main.player[number].hostile);
					break;
				case 31:
					writer.Write((short)number);
					writer.Write((short)number2);
					break;
				case 32:
				{
					Item item3 = Main.chest[number].item[(byte)number2];
					writer.Write((short)number);
					writer.Write((byte)number2);
					short value2 = (short)item3.netID;
					if (item3.Name == null)
					{
						value2 = 0;
					}
					writer.Write((short)item3.stack);
					writer.Write(item3.prefix);
					writer.Write(value2);
					break;
				}
				case 33:
				{
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					string text2 = null;
					if (number > -1)
					{
						num3 = Main.chest[number].x;
						num4 = Main.chest[number].y;
					}
					if (number2 == 1f)
					{
						string text3 = text.ToString();
						num5 = (byte)text3.Length;
						if (num5 == 0 || num5 > 20)
						{
							num5 = 255;
						}
						else
						{
							text2 = text3;
						}
					}
					writer.Write((short)number);
					writer.Write((short)num3);
					writer.Write((short)num4);
					writer.Write((byte)num5);
					if (text2 != null)
					{
						writer.Write(text2);
					}
					break;
				}
				case 34:
					writer.Write((byte)number);
					writer.Write((short)number2);
					writer.Write((short)number3);
					writer.Write((short)number4);
					if (Main.netMode == 2)
					{
						Netplay.GetSectionX((int)number2);
						Netplay.GetSectionY((int)number3);
						writer.Write((short)number5);
					}
					else
					{
						writer.Write((short)0);
					}
					break;
				case 35:
				case 66:
					writer.Write((byte)number);
					writer.Write((short)number2);
					break;
				case 36:
				{
					Player player2 = Main.player[number];
					writer.Write((byte)number);
					writer.Write(player2.zone1);
					writer.Write(player2.zone2);
					writer.Write(player2.zone3);
					writer.Write(player2.zone4);
					break;
				}
				case 38:
					writer.Write(Netplay.ServerPassword);
					break;
				case 39:
					writer.Write((short)number);
					break;
				case 40:
					writer.Write((byte)number);
					writer.Write((short)Main.player[number].talkNPC);
					break;
				case 41:
					writer.Write((byte)number);
					writer.Write(Main.player[number].itemRotation);
					writer.Write((short)Main.player[number].itemAnimation);
					break;
				case 42:
					writer.Write((byte)number);
					writer.Write((short)Main.player[number].statMana);
					writer.Write((short)Main.player[number].statManaMax);
					break;
				case 43:
					writer.Write((byte)number);
					writer.Write((short)number2);
					break;
				case 45:
					writer.Write((byte)number);
					writer.Write((byte)Main.player[number].team);
					break;
				case 46:
					writer.Write((short)number);
					writer.Write((short)number2);
					break;
				case 47:
					writer.Write((short)number);
					writer.Write((short)Main.sign[number].x);
					writer.Write((short)Main.sign[number].y);
					writer.Write(Main.sign[number].text);
					writer.Write((byte)number2);
					break;
				case 48:
				{
					Tile tile2 = Main.tile[number, (int)number2];
					writer.Write((short)number);
					writer.Write((short)number2);
					writer.Write(tile2.liquid);
					writer.Write(tile2.liquidType());
					break;
				}
				case 50:
				{
					writer.Write((byte)number);
					for (int num20 = 0; num20 < 22; num20++)
					{
						writer.Write((byte)Main.player[number].buffType[num20]);
					}
					break;
				}
				case 51:
					writer.Write((byte)number);
					writer.Write((byte)number2);
					break;
				case 52:
					writer.Write((byte)number2);
					writer.Write((short)number3);
					writer.Write((short)number4);
					break;
				case 53:
					writer.Write((short)number);
					writer.Write((byte)number2);
					writer.Write((short)number3);
					break;
				case 54:
				{
					writer.Write((short)number);
					for (int num19 = 0; num19 < 5; num19++)
					{
						writer.Write((byte)Main.npc[number].buffType[num19]);
						writer.Write((short)Main.npc[number].buffTime[num19]);
					}
					break;
				}
				case 55:
					writer.Write((byte)number);
					writer.Write((byte)number2);
					writer.Write((int)number3);
					break;
				case 56:
					writer.Write((short)number);
					if (Main.netMode == 2)
					{
						string givenName = Main.npc[number].GivenName;
						writer.Write(givenName);
					}
					break;
				case 57:
					writer.Write(WorldGen.tGood);
					writer.Write(WorldGen.tEvil);
					writer.Write(WorldGen.tBlood);
					break;
				case 58:
					writer.Write((byte)number);
					writer.Write(number2);
					break;
				case 59:
					writer.Write((short)number);
					writer.Write((short)number2);
					break;
				case 60:
					writer.Write((short)number);
					writer.Write((short)number2);
					writer.Write((short)number3);
					writer.Write((byte)number4);
					break;
				case 61:
					writer.Write((short)number);
					writer.Write((short)number2);
					break;
				case 62:
					writer.Write((byte)number);
					writer.Write((byte)number2);
					break;
				case 63:
				case 64:
					writer.Write((short)number);
					writer.Write((short)number2);
					writer.Write((byte)number3);
					break;
				case 65:
				{
					BitsByte bitsByte17 = (byte)0;
					bitsByte17[0] = (number & 1) == 1;
					bitsByte17[1] = (number & 2) == 2;
					bitsByte17[2] = (number5 & 1) == 1;
					bitsByte17[3] = (number5 & 2) == 2;
					writer.Write(bitsByte17);
					writer.Write((short)number2);
					writer.Write(number3);
					writer.Write(number4);
					break;
				}
				case 68:
					writer.Write(Main.clientUUID);
					break;
				case 69:
					Netplay.GetSectionX((int)number2);
					Netplay.GetSectionY((int)number3);
					writer.Write((short)number);
					writer.Write((short)number2);
					writer.Write((short)number3);
					writer.Write(Main.chest[(short)number].name);
					break;
				case 70:
					writer.Write((short)number);
					writer.Write((byte)number2);
					break;
				case 71:
					writer.Write(number);
					writer.Write((int)number2);
					writer.Write((short)number3);
					writer.Write((byte)number4);
					break;
				case 72:
				{
					for (int num18 = 0; num18 < 40; num18++)
					{
						writer.Write((short)Main.travelShop[num18]);
					}
					break;
				}
				case 74:
				{
					writer.Write((byte)Main.anglerQuest);
					bool value6 = Main.anglerWhoFinishedToday.Contains(text.ToString());
					writer.Write(value6);
					break;
				}
				case 76:
					writer.Write((byte)number);
					writer.Write(Main.player[number].anglerQuestsFinished);
					break;
				case 77:
					if (Main.netMode != 2)
					{
						return;
					}
					writer.Write((short)number);
					writer.Write((ushort)number2);
					writer.Write((short)number3);
					writer.Write((short)number4);
					break;
				case 78:
					writer.Write(number);
					writer.Write((int)number2);
					writer.Write((sbyte)number3);
					writer.Write((sbyte)number4);
					break;
				case 79:
					writer.Write((short)number);
					writer.Write((short)number2);
					writer.Write((short)number3);
					writer.Write((short)number4);
					writer.Write((byte)number5);
					writer.Write((sbyte)number6);
					writer.Write(number7 == 1);
					break;
				case 80:
					writer.Write((byte)number);
					writer.Write((short)number2);
					break;
				case 81:
					writer.Write(number2);
					writer.Write(number3);
					writer.WriteRGB(new Color
					{
						PackedValue = (uint)number
					});
					writer.Write((int)number4);
					break;
				case 119:
					writer.Write(number2);
					writer.Write(number3);
					writer.WriteRGB(new Color
					{
						PackedValue = (uint)number
					});
					text.Serialize(writer);
					break;
				case 83:
				{
					int num12 = number;
					if (num12 < 0 && num12 >= 267)
					{
						num12 = 1;
					}
					int value4 = NPC.killCount[num12];
					writer.Write((short)num12);
					writer.Write(value4);
					break;
				}
				case 84:
				{
					byte b2 = (byte)number;
					float stealth = Main.player[b2].stealth;
					writer.Write(b2);
					writer.Write(stealth);
					break;
				}
				case 85:
				{
					byte value3 = (byte)number;
					writer.Write(value3);
					break;
				}
				case 86:
				{
					writer.Write(number);
					bool flag = TileEntity.ByID.ContainsKey(number);
					writer.Write(flag);
					if (flag)
					{
						TileEntity.Write(writer, TileEntity.ByID[number], networkSend: true);
					}
					break;
				}
				case 87:
					writer.Write((short)number);
					writer.Write((short)number2);
					writer.Write((byte)number3);
					break;
				case 88:
				{
					BitsByte bitsByte = (byte)number2;
					BitsByte bitsByte2 = (byte)number3;
					writer.Write((short)number);
					writer.Write(bitsByte);
					Item item2 = Main.item[number];
					if (bitsByte[0])
					{
						writer.Write(item2.color.PackedValue);
					}
					if (bitsByte[1])
					{
						writer.Write((ushort)item2.damage);
					}
					if (bitsByte[2])
					{
						writer.Write(item2.knockBack);
					}
					if (bitsByte[3])
					{
						writer.Write((ushort)item2.useAnimation);
					}
					if (bitsByte[4])
					{
						writer.Write((ushort)item2.useTime);
					}
					if (bitsByte[5])
					{
						writer.Write((short)item2.shoot);
					}
					if (bitsByte[6])
					{
						writer.Write(item2.shootSpeed);
					}
					if (bitsByte[7])
					{
						writer.Write(bitsByte2);
						if (bitsByte2[0])
						{
							writer.Write((ushort)item2.width);
						}
						if (bitsByte2[1])
						{
							writer.Write((ushort)item2.height);
						}
						if (bitsByte2[2])
						{
							writer.Write(item2.scale);
						}
						if (bitsByte2[3])
						{
							writer.Write((short)item2.ammo);
						}
						if (bitsByte2[4])
						{
							writer.Write((short)item2.useAmmo);
						}
						if (bitsByte2[5])
						{
							writer.Write(item2.notAmmo);
						}
					}
					break;
				}
				case 89:
				{
					writer.Write((short)number);
					writer.Write((short)number2);
					Item item = Main.player[(int)number4].inventory[(int)number3];
					writer.Write((short)item.netID);
					writer.Write(item.prefix);
					writer.Write((short)item.stack);
					break;
				}
				case 91:
					writer.Write(number);
					writer.Write((byte)number2);
					if (number2 != 255f)
					{
						writer.Write((ushort)number3);
						writer.Write((byte)number4);
						writer.Write((byte)number5);
						if (number5 < 0)
						{
							writer.Write((short)number6);
						}
					}
					break;
				case 92:
					writer.Write((short)number);
					writer.Write(number2);
					writer.Write(number3);
					writer.Write(number4);
					break;
				case 95:
					writer.Write((ushort)number);
					break;
				case 96:
				{
					writer.Write((byte)number);
					Player player = Main.player[number];
					writer.Write((short)number4);
					writer.Write(number2);
					writer.Write(number3);
					writer.WriteVector2(player.velocity);
					break;
				}
				case 97:
					writer.Write((short)number);
					break;
				case 98:
					writer.Write((short)number);
					break;
				case 99:
					writer.Write((byte)number);
					writer.WriteVector2(Main.player[number].MinionRestTargetPoint);
					break;
				case 115:
					writer.Write((byte)number);
					writer.Write((short)Main.player[number].MinionAttackTargetNPC);
					break;
				case 100:
				{
					writer.Write((ushort)number);
					NPC nPC = Main.npc[number];
					writer.Write((short)number4);
					writer.Write(number2);
					writer.Write(number3);
					writer.WriteVector2(nPC.velocity);
					break;
				}
				case 101:
					writer.Write((ushort)NPC.ShieldStrengthTowerSolar);
					writer.Write((ushort)NPC.ShieldStrengthTowerVortex);
					writer.Write((ushort)NPC.ShieldStrengthTowerNebula);
					writer.Write((ushort)NPC.ShieldStrengthTowerStardust);
					break;
				case 102:
					writer.Write((byte)number);
					writer.Write((byte)number2);
					writer.Write(number3);
					writer.Write(number4);
					break;
				case 103:
					writer.Write(NPC.MoonLordCountdown);
					break;
				case 104:
					writer.Write((byte)number);
					writer.Write((short)number2);
					writer.Write(((short)number3 < 0) ? 0f : number3);
					writer.Write((byte)number4);
					writer.Write(number5);
					writer.Write((byte)number6);
					break;
				case 105:
					writer.Write((short)number);
					writer.Write((short)number2);
					writer.Write(number3 == 1f);
					break;
				case 106:
					writer.Write(new HalfVector2(number, number2).PackedValue);
					break;
				case 108:
					writer.Write((short)number);
					writer.Write(number2);
					writer.Write((short)number3);
					writer.Write((short)number4);
					writer.Write((short)number5);
					writer.Write((short)number6);
					writer.Write((byte)number7);
					break;
				case 109:
					writer.Write((short)number);
					writer.Write((short)number2);
					writer.Write((short)number3);
					writer.Write((short)number4);
					writer.Write((byte)number5);
					break;
				case 110:
					writer.Write((short)number);
					writer.Write((short)number2);
					writer.Write((byte)number3);
					break;
				case 112:
					writer.Write((byte)number);
					writer.Write((short)number2);
					writer.Write((short)number3);
					writer.Write((byte)number4);
					writer.Write((short)number5);
					break;
				case 113:
					writer.Write((short)number);
					writer.Write((short)number2);
					break;
				case 116:
					writer.Write(number);
					break;
				case 117:
					writer.Write((byte)number);
					_currentPlayerDeathReason.WriteSelfTo(writer);
					writer.Write((short)number2);
					writer.Write((byte)(number3 + 1f));
					writer.Write((byte)number4);
					writer.Write((sbyte)number5);
					break;
				case 118:
					writer.Write((byte)number);
					_currentPlayerDeathReason.WriteSelfTo(writer);
					writer.Write((short)number2);
					writer.Write((byte)(number3 + 1f));
					writer.Write((byte)number4);
					break;
				}
				int num21 = (int)writer.BaseStream.Position;
				writer.BaseStream.Position = position;
				writer.Write((short)num21);
				writer.BaseStream.Position = num21;
				if (Main.netMode == 1)
				{
					if (Netplay.Connection.Socket.IsConnected())
					{
						try
						{
							buffer[num].spamCount++;
							Main.txMsg++;
							Main.txData += num21;
							Main.txMsgType[msgType]++;
							Main.txDataType[msgType] += num21;
							Netplay.Connection.Socket.AsyncSend(buffer[num].writeBuffer, 0, num21, Netplay.Connection.ClientWriteCallBack);
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
						for (int num23 = 0; num23 < 256; num23++)
						{
							if (num23 != ignoreClient && buffer[num23].broadcast && Netplay.Clients[num23].IsConnected())
							{
								try
								{
									buffer[num23].spamCount++;
									Main.txMsg++;
									Main.txData += num21;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num21;
									Netplay.Clients[num23].Socket.AsyncSend(buffer[num].writeBuffer, 0, num21, Netplay.Clients[num23].ServerWriteCallBack);
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
						for (int num27 = 0; num27 < 256; num27++)
						{
							if (num27 != ignoreClient && buffer[num27].broadcast && Netplay.Clients[num27].IsConnected() && Netplay.Clients[num27].SectionRange(number, (int)number2, (int)number3))
							{
								try
								{
									buffer[num27].spamCount++;
									Main.txMsg++;
									Main.txData += num21;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num21;
									Netplay.Clients[num27].Socket.AsyncSend(buffer[num].writeBuffer, 0, num21, Netplay.Clients[num27].ServerWriteCallBack);
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
						NPC nPC4 = Main.npc[number];
						for (int num28 = 0; num28 < 256; num28++)
						{
							if (num28 == ignoreClient || !buffer[num28].broadcast || !Netplay.Clients[num28].IsConnected())
							{
								continue;
							}
							bool flag4 = false;
							if (nPC4.boss || nPC4.netAlways || nPC4.townNPC || !nPC4.active)
							{
								flag4 = true;
							}
							else if (nPC4.netSkip <= 0)
							{
								Rectangle rect5 = Main.player[num28].getRect();
								Rectangle rect6 = nPC4.getRect();
								rect6.X -= 2500;
								rect6.Y -= 2500;
								rect6.Width += 5000;
								rect6.Height += 5000;
								if (rect5.Intersects(rect6))
								{
									flag4 = true;
								}
							}
							else
							{
								flag4 = true;
							}
							if (flag4)
							{
								try
								{
									buffer[num28].spamCount++;
									Main.txMsg++;
									Main.txData += num21;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num21;
									Netplay.Clients[num28].Socket.AsyncSend(buffer[num].writeBuffer, 0, num21, Netplay.Clients[num28].ServerWriteCallBack);
								}
								catch
								{
								}
							}
						}
						nPC4.netSkip++;
						if (nPC4.netSkip > 4)
						{
							nPC4.netSkip = 0;
						}
						break;
					}
					case 28:
					{
						NPC nPC3 = Main.npc[number];
						for (int num25 = 0; num25 < 256; num25++)
						{
							if (num25 == ignoreClient || !buffer[num25].broadcast || !Netplay.Clients[num25].IsConnected())
							{
								continue;
							}
							bool flag3 = false;
							if (nPC3.life <= 0)
							{
								flag3 = true;
							}
							else
							{
								Rectangle rect3 = Main.player[num25].getRect();
								Rectangle rect4 = nPC3.getRect();
								rect4.X -= 3000;
								rect4.Y -= 3000;
								rect4.Width += 6000;
								rect4.Height += 6000;
								if (rect3.Intersects(rect4))
								{
									flag3 = true;
								}
							}
							if (flag3)
							{
								try
								{
									buffer[num25].spamCount++;
									Main.txMsg++;
									Main.txData += num21;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num21;
									Netplay.Clients[num25].Socket.AsyncSend(buffer[num].writeBuffer, 0, num21, Netplay.Clients[num25].ServerWriteCallBack);
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
						for (int num26 = 0; num26 < 256; num26++)
						{
							if (num26 != ignoreClient && buffer[num26].broadcast && Netplay.Clients[num26].IsConnected())
							{
								try
								{
									buffer[num26].spamCount++;
									Main.txMsg++;
									Main.txData += num21;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num21;
									Netplay.Clients[num26].Socket.AsyncSend(buffer[num].writeBuffer, 0, num21, Netplay.Clients[num26].ServerWriteCallBack);
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
						for (int num24 = 0; num24 < 256; num24++)
						{
							if (num24 == ignoreClient || !buffer[num24].broadcast || !Netplay.Clients[num24].IsConnected())
							{
								continue;
							}
							bool flag2 = false;
							if (projectile2.type == 12 || Main.projPet[projectile2.type] || projectile2.aiStyle == 11 || projectile2.netImportant)
							{
								flag2 = true;
							}
							else
							{
								Rectangle rect = Main.player[num24].getRect();
								Rectangle rect2 = projectile2.getRect();
								rect2.X -= 5000;
								rect2.Y -= 5000;
								rect2.Width += 10000;
								rect2.Height += 10000;
								if (rect.Intersects(rect2))
								{
									flag2 = true;
								}
							}
							if (flag2)
							{
								try
								{
									buffer[num24].spamCount++;
									Main.txMsg++;
									Main.txData += num21;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num21;
									Netplay.Clients[num24].Socket.AsyncSend(buffer[num].writeBuffer, 0, num21, Netplay.Clients[num24].ServerWriteCallBack);
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
						for (int num22 = 0; num22 < 256; num22++)
						{
							if (num22 != ignoreClient && (buffer[num22].broadcast || (Netplay.Clients[num22].State >= 3 && msgType == 10)) && Netplay.Clients[num22].IsConnected())
							{
								try
								{
									buffer[num22].spamCount++;
									Main.txMsg++;
									Main.txData += num21;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num21;
									Netplay.Clients[num22].Socket.AsyncSend(buffer[num].writeBuffer, 0, num21, Netplay.Clients[num22].ServerWriteCallBack);
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
				else if (Netplay.Clients[remoteClient].IsConnected())
				{
					try
					{
						buffer[remoteClient].spamCount++;
						Main.txMsg++;
						Main.txData += num21;
						Main.txMsgType[msgType]++;
						Main.txDataType[msgType] += num21;
						Netplay.Clients[remoteClient].Socket.AsyncSend(buffer[num].writeBuffer, 0, num21, Netplay.Clients[remoteClient].ServerWriteCallBack);
					}
					catch
					{
					}
				}
				if (Main.verboseNetplay)
				{
					for (int num29 = 0; num29 < num21; num29++)
					{
					}
					for (int num30 = 0; num30 < num21; num30++)
					{
						_ = buffer[num].writeBuffer[num30];
					}
				}
				buffer[num].writeLocked = false;
				if (msgType == 19 && Main.netMode == 1)
				{
					SendTileSquare(num, (int)number2, (int)number3, 5);
				}
				if (msgType == 2 && Main.netMode == 2)
				{
					Netplay.Clients[num].PendingTermination = true;
				}
			}
		}

		public static int CompressTileBlock(int xStart, int yStart, short width, short height, byte[] buffer, int bufferStart)
		{
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(xStart);
					binaryWriter.Write(yStart);
					binaryWriter.Write(width);
					binaryWriter.Write(height);
					CompressTileBlock_Inner(binaryWriter, xStart, yStart, width, height);
					int num = buffer.Length;
					if (bufferStart + memoryStream.Length > num)
					{
						return (int)(num - bufferStart + memoryStream.Length);
					}
					memoryStream.Position = 0L;
					MemoryStream memoryStream2 = new MemoryStream();
					DeflateStream val = new DeflateStream((Stream)memoryStream2, (CompressionMode)0, true);
					try
					{
						memoryStream.CopyTo((Stream)(object)val);
						((Stream)(object)val).Flush();
						((Stream)(object)val).Close();
						((Stream)(object)val).Dispose();
					}
					finally
					{
						((IDisposable)val)?.Dispose();
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

		public static void CompressTileBlock_Inner(BinaryWriter writer, int xStart, int yStart, int width, int height)
		{
			short[] array = new short[1000];
			short[] array2 = new short[1000];
			short[] array3 = new short[1000];
			short num = 0;
			short num2 = 0;
			short num3 = 0;
			short num4 = 0;
			int num5 = 0;
			int num6 = 0;
			byte b = 0;
			byte[] array4 = new byte[13];
			Tile tile = null;
			for (int i = yStart; i < yStart + height; i++)
			{
				for (int j = xStart; j < xStart + width; j++)
				{
					Tile tile2 = Main.tile[j, i];
					if (tile2.isTheSameAs(tile))
					{
						num4++;
						continue;
					}
					if (tile != null)
					{
						if (num4 > 0)
						{
							array4[num5] = (byte)(num4 & 0xFF);
							num5++;
							if (num4 > 255)
							{
								b |= 0x80;
								array4[num5] = (byte)((num4 & 0xFF00) >> 8);
								num5++;
							}
							else
							{
								b |= 0x40;
							}
						}
						array4[num6] = b;
						writer.Write(array4, num6, num5 - num6);
						num4 = 0;
					}
					num5 = 3;
					byte b3;
					byte b2;
					b = (b2 = (b3 = 0));
					if (tile2.active())
					{
						b |= 2;
						array4[num5] = (byte)tile2.type;
						num5++;
						if (tile2.type > 255)
						{
							array4[num5] = (byte)(tile2.type >> 8);
							num5++;
							b |= 0x20;
						}
						if (TileID.Sets.BasicChest[tile2.type] && tile2.frameX % 36 == 0 && tile2.frameY % 36 == 0)
						{
							short num7 = (short)Chest.FindChest(j, i);
							if (num7 != -1)
							{
								array[num] = num7;
								num++;
							}
						}
						if (tile2.type == 88 && tile2.frameX % 54 == 0 && tile2.frameY % 36 == 0)
						{
							short num8 = (short)Chest.FindChest(j, i);
							if (num8 != -1)
							{
								array[num] = num8;
								num++;
							}
						}
						if (tile2.type == 85 && tile2.frameX % 36 == 0 && tile2.frameY % 36 == 0)
						{
							short num9 = (short)Sign.ReadSign(j, i);
							if (num9 != -1)
							{
								array2[num2++] = num9;
							}
						}
						if (tile2.type == 55 && tile2.frameX % 36 == 0 && tile2.frameY % 36 == 0)
						{
							short num10 = (short)Sign.ReadSign(j, i);
							if (num10 != -1)
							{
								array2[num2++] = num10;
							}
						}
						if (tile2.type == 425 && tile2.frameX % 36 == 0 && tile2.frameY % 36 == 0)
						{
							short num11 = (short)Sign.ReadSign(j, i);
							if (num11 != -1)
							{
								array2[num2++] = num11;
							}
						}
						if (tile2.type == 378 && tile2.frameX % 36 == 0 && tile2.frameY == 0)
						{
							int num12 = TETrainingDummy.Find(j, i);
							if (num12 != -1)
							{
								array3[num3++] = (short)num12;
							}
						}
						if (tile2.type == 395 && tile2.frameX % 36 == 0 && tile2.frameY == 0)
						{
							int num13 = TEItemFrame.Find(j, i);
							if (num13 != -1)
							{
								array3[num3++] = (short)num13;
							}
						}
						if (Main.tileFrameImportant[tile2.type])
						{
							array4[num5] = (byte)(tile2.frameX & 0xFF);
							num5++;
							array4[num5] = (byte)((tile2.frameX & 0xFF00) >> 8);
							num5++;
							array4[num5] = (byte)(tile2.frameY & 0xFF);
							num5++;
							array4[num5] = (byte)((tile2.frameY & 0xFF00) >> 8);
							num5++;
						}
						if (tile2.color() != 0)
						{
							b3 |= 8;
							array4[num5] = tile2.color();
							num5++;
						}
					}
					if (tile2.wall != 0)
					{
						b |= 4;
						array4[num5] = tile2.wall;
						num5++;
						if (tile2.wallColor() != 0)
						{
							b3 |= 0x10;
							array4[num5] = tile2.wallColor();
							num5++;
						}
					}
					if (tile2.liquid != 0)
					{
						b = (tile2.lava() ? ((byte)(b | 0x10)) : ((!tile2.honey()) ? ((byte)(b | 8)) : ((byte)(b | 0x18))));
						array4[num5] = tile2.liquid;
						num5++;
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
					int num14 = (tile2.halfBrick() ? 16 : ((tile2.slope() != 0) ? (tile2.slope() + 1 << 4) : 0));
					b2 |= (byte)num14;
					if (tile2.actuator())
					{
						b3 |= 2;
					}
					if (tile2.inActive())
					{
						b3 |= 4;
					}
					if (tile2.wire4())
					{
						b3 |= 0x20;
					}
					num6 = 2;
					if (b3 != 0)
					{
						b2 |= 1;
						array4[num6] = b3;
						num6--;
					}
					if (b2 != 0)
					{
						b |= 1;
						array4[num6] = b2;
						num6--;
					}
					tile = tile2;
				}
			}
			if (num4 > 0)
			{
				array4[num5] = (byte)(num4 & 0xFF);
				num5++;
				if (num4 > 255)
				{
					b |= 0x80;
					array4[num5] = (byte)((num4 & 0xFF00) >> 8);
					num5++;
				}
				else
				{
					b |= 0x40;
				}
			}
			array4[num6] = b;
			writer.Write(array4, num6, num5 - num6);
			writer.Write(num);
			for (int k = 0; k < num; k++)
			{
				Chest chest = Main.chest[array[k]];
				writer.Write(array[k]);
				writer.Write((short)chest.x);
				writer.Write((short)chest.y);
				writer.Write(chest.name);
			}
			writer.Write(num2);
			for (int l = 0; l < num2; l++)
			{
				Sign sign = Main.sign[array2[l]];
				writer.Write(array2[l]);
				writer.Write((short)sign.x);
				writer.Write((short)sign.y);
				writer.Write(sign.text);
			}
			writer.Write(num3);
			for (int m = 0; m < num3; m++)
			{
				TileEntity.Write(writer, TileEntity.ByID[array3[m]]);
			}
		}

		public static void DecompressTileBlock(byte[] buffer, int bufferStart, int bufferLength)
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(buffer, bufferStart, bufferLength);
				memoryStream.Position = 0L;
				MemoryStream memoryStream3;
				if (memoryStream.ReadByte() != 0)
				{
					MemoryStream memoryStream2 = new MemoryStream();
					DeflateStream val = new DeflateStream((Stream)memoryStream, (CompressionMode)1, true);
					try
					{
						((Stream)(object)val).CopyTo((Stream)memoryStream2);
						((Stream)(object)val).Close();
					}
					finally
					{
						((IDisposable)val)?.Dispose();
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
					DecompressTileBlock_Inner(binaryReader, xStart, yStart, width, height);
				}
			}
		}

		public static void DecompressTileBlock_Inner(BinaryReader reader, int xStart, int yStart, int width, int height)
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
						tile.ClearEverything();
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
						tile.active(active: true);
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
								tile.lava(lava: true);
							}
							else
							{
								tile.honey(honey: true);
							}
						}
					}
					if (b > 1)
					{
						if ((b & 2) == 2)
						{
							tile.wire(wire: true);
						}
						if ((b & 4) == 4)
						{
							tile.wire2(wire2: true);
						}
						if ((b & 8) == 8)
						{
							tile.wire3(wire3: true);
						}
						b4 = (byte)((b & 0x70) >> 4);
						if (b4 != 0 && Main.tileSolid[tile.type])
						{
							if (b4 == 1)
							{
								tile.halfBrick(halfBrick: true);
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
							tile.actuator(actuator: true);
						}
						if ((b2 & 4) == 4)
						{
							tile.inActive(inActive: true);
						}
						if ((b2 & 0x20) == 32)
						{
							tile.wire4(wire4: true);
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
			num3 = reader.ReadInt16();
			for (int l = 0; l < num3; l++)
			{
				short num5 = reader.ReadInt16();
				short x2 = reader.ReadInt16();
				short y2 = reader.ReadInt16();
				string text = reader.ReadString();
				if (num5 >= 0 && num5 < 1000)
				{
					if (Main.sign[num5] == null)
					{
						Main.sign[num5] = new Sign();
					}
					Main.sign[num5].text = text;
					Main.sign[num5].x = x2;
					Main.sign[num5].y = y2;
				}
			}
			num3 = reader.ReadInt16();
			for (int m = 0; m < num3; m++)
			{
				TileEntity tileEntity = TileEntity.Read(reader);
				TileEntity.ByID[tileEntity.ID] = tileEntity;
				TileEntity.ByPosition[tileEntity.Position] = tileEntity;
			}
		}

		public static void ReceiveBytes(byte[] bytes, int streamLength, int i = 256)
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
						Main.statusText = Language.GetTextValue("Error.BadHeaderBufferOverflow");
						Netplay.disconnect = true;
					}
					else
					{
						Netplay.Clients[i].PendingTermination = true;
					}
				}
			}
		}

		public static void CheckBytes(int bufferIndex = 256)
		{
			lock (buffer[bufferIndex])
			{
				int num = 0;
				int num2 = buffer[bufferIndex].totalData;
				try
				{
					while (num2 >= 2)
					{
						int num3 = BitConverter.ToUInt16(buffer[bufferIndex].readBuffer, num);
						if (num2 >= num3)
						{
							long position = buffer[bufferIndex].reader.BaseStream.Position;
							buffer[bufferIndex].GetData(num + 2, num3 - 2, out var _);
							buffer[bufferIndex].reader.BaseStream.Position = position + num3;
							num2 -= num3;
							num += num3;
							continue;
						}
						break;
					}
				}
				catch
				{
					num2 = 0;
					num = 0;
				}
				if (num2 != buffer[bufferIndex].totalData)
				{
					for (int i = 0; i < num2; i++)
					{
						buffer[bufferIndex].readBuffer[i] = buffer[bufferIndex].readBuffer[i + num];
					}
					buffer[bufferIndex].totalData = num2;
				}
				buffer[bufferIndex].checkBytes = false;
			}
		}

		public static void BootPlayer(int plr, NetworkText msg)
		{
			SendData(2, plr, -1, msg);
		}

		public static void SendObjectPlacment(int whoAmi, int x, int y, int type, int style, int alternative, int random, int direction)
		{
			int remoteClient;
			int ignoreClient;
			if (Main.netMode == 2)
			{
				remoteClient = -1;
				ignoreClient = whoAmi;
			}
			else
			{
				remoteClient = whoAmi;
				ignoreClient = -1;
			}
			SendData(79, remoteClient, ignoreClient, null, x, y, type, style, alternative, random, direction);
		}

		public static void SendTemporaryAnimation(int whoAmi, int animationType, int tileType, int xCoord, int yCoord)
		{
			SendData(77, whoAmi, -1, null, animationType, tileType, xCoord, yCoord);
		}

		public static void SendPlayerHurt(int playerTargetIndex, PlayerDeathReason reason, int damage, int direction, bool critical, bool pvp, int hitContext, int remoteClient = -1, int ignoreClient = -1)
		{
			_currentPlayerDeathReason = reason;
			BitsByte bitsByte = (byte)0;
			bitsByte[0] = critical;
			bitsByte[1] = pvp;
			SendData(117, remoteClient, ignoreClient, null, playerTargetIndex, damage, direction, (int)(byte)bitsByte, hitContext);
		}

		public static void SendPlayerDeath(int playerTargetIndex, PlayerDeathReason reason, int damage, int direction, bool pvp, int remoteClient = -1, int ignoreClient = -1)
		{
			_currentPlayerDeathReason = reason;
			BitsByte bitsByte = (byte)0;
			bitsByte[0] = pvp;
			SendData(118, remoteClient, ignoreClient, null, playerTargetIndex, damage, direction, (int)(byte)bitsByte);
		}

		public static void SendTileRange(int whoAmi, int tileX, int tileY, int xSize, int ySize, TileChangeType changeType = TileChangeType.None)
		{
			int number = ((xSize >= ySize) ? xSize : ySize);
			SendData(20, whoAmi, -1, null, number, tileX, tileY, 0f, (int)changeType);
		}

		public static void SendTileSquare(int whoAmi, int tileX, int tileY, int size, TileChangeType changeType = TileChangeType.None)
		{
			int num = (size - 1) / 2;
			SendData(20, whoAmi, -1, null, size, tileX - num, tileY - num, 0f, (int)changeType);
		}

		public static void SendTravelShop(int remoteClient)
		{
			if (Main.netMode == 2)
			{
				SendData(72, remoteClient);
			}
		}

		public static void SendAnglerQuest(int remoteClient)
		{
			if (Main.netMode != 2)
			{
				return;
			}
			if (remoteClient == -1)
			{
				for (int i = 0; i < 255; i++)
				{
					if (Netplay.Clients[i].State == 10)
					{
						SendData(74, i, -1, NetworkText.FromLiteral(Main.player[i].name), Main.anglerQuest);
					}
				}
			}
			else if (Netplay.Clients[remoteClient].State == 10)
			{
				SendData(74, remoteClient, -1, NetworkText.FromLiteral(Main.player[remoteClient].name), Main.anglerQuest);
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
				if (sectionX < 0 || sectionY < 0 || sectionX >= Main.maxSectionsX || sectionY >= Main.maxSectionsY || (skipSent && Netplay.Clients[whoAmi].TileSections[sectionX, sectionY]))
				{
					return;
				}
				Netplay.Clients[whoAmi].TileSections[sectionX, sectionY] = true;
				int number = sectionX * 200;
				int num = sectionY * 150;
				int num2 = 150;
				for (int i = num; i < num + 150; i += num2)
				{
					SendData(10, whoAmi, -1, null, number, i, 200f, num2);
				}
				for (int j = 0; j < 200; j++)
				{
					if (Main.npc[j].active && Main.npc[j].townNPC)
					{
						int sectionX2 = Netplay.GetSectionX((int)(Main.npc[j].position.X / 16f));
						int sectionY2 = Netplay.GetSectionY((int)(Main.npc[j].position.Y / 16f));
						if (sectionX2 == sectionX && sectionY2 == sectionY)
						{
							SendData(23, whoAmi, -1, null, j);
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
				SendChatMessageToClient(NetworkText.FromFormattable("{0} {1}!", Lang.mp[18].ToNetworkText(), Main.worldName), new Color(255, 240, 20), plr);
			}
			else
			{
				SendChatMessageToClient(NetworkText.FromLiteral(Main.motd), new Color(255, 240, 20), plr);
			}
			string text = "";
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					text = ((!(text == "")) ? (text + ", " + Main.player[i].name) : (text + Main.player[i].name));
				}
			}
			SendChatMessageToClient(NetworkText.FromKey("Game.JoinGreeting", text), new Color(255, 240, 20), plr);
		}

		public static void sendWater(int x, int y)
		{
			if (Main.netMode == 1)
			{
				SendData(48, -1, -1, null, x, y);
				return;
			}
			for (int i = 0; i < 256; i++)
			{
				if ((buffer[i].broadcast || Netplay.Clients[i].State >= 3) && Netplay.Clients[i].IsConnected())
				{
					int num = x / 200;
					int num2 = y / 150;
					if (Netplay.Clients[i].TileSections[num, num2])
					{
						SendData(48, i, -1, null, x, y);
					}
				}
			}
		}

		public static void SyncDisconnectedPlayer(int plr)
		{
			SyncOnePlayer(plr, -1, plr);
			EnsureLocalPlayerIsPresent();
		}

		public static void SyncConnectedPlayer(int plr)
		{
			SyncOnePlayer(plr, -1, plr);
			for (int i = 0; i < 255; i++)
			{
				if (plr != i && Main.player[i].active)
				{
					SyncOnePlayer(i, plr, -1);
				}
			}
			SendNPCHousesAndTravelShop(plr);
			SendAnglerQuest(plr);
			EnsureLocalPlayerIsPresent();
		}

		private static void SendNPCHousesAndTravelShop(int plr)
		{
			bool flag = false;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].townNPC && NPC.TypeToHeadIndex(Main.npc[i].type) != -1)
				{
					if (!flag && Main.npc[i].type == 368)
					{
						flag = true;
					}
					byte householdStatus = WorldGen.TownManager.GetHouseholdStatus(Main.npc[i]);
					SendData(60, plr, -1, null, i, Main.npc[i].homeTileX, Main.npc[i].homeTileY, (int)householdStatus);
				}
			}
			if (flag)
			{
				SendTravelShop(plr);
			}
		}

		private static void EnsureLocalPlayerIsPresent()
		{
			if (!Main.autoShutdown)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < 255; i++)
			{
				if (Netplay.Clients[i].State == 10 && Netplay.Clients[i].Socket.GetRemoteAddress().IsLocalHost())
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Console.WriteLine(Language.GetTextValue("Net.ServerAutoShutdown"));
				WorldFile.saveWorld();
				Netplay.disconnect = true;
			}
		}

		private static void SyncOnePlayer(int plr, int toWho, int fromWho)
		{
			int num = 0;
			if (Main.player[plr].active)
			{
				num = 1;
			}
			if (Netplay.Clients[plr].State == 10)
			{
				SendData(14, toWho, fromWho, null, plr, num);
				SendData(4, toWho, fromWho, null, plr);
				SendData(13, toWho, fromWho, null, plr);
				SendData(16, toWho, fromWho, null, plr);
				SendData(30, toWho, fromWho, null, plr);
				SendData(45, toWho, fromWho, null, plr);
				SendData(42, toWho, fromWho, null, plr);
				SendData(50, toWho, fromWho, null, plr);
				for (int i = 0; i < 59; i++)
				{
					SendData(5, toWho, fromWho, null, plr, i, (int)Main.player[plr].inventory[i].prefix);
				}
				for (int j = 0; j < Main.player[plr].armor.Length; j++)
				{
					SendData(5, toWho, fromWho, null, plr, 59 + j, (int)Main.player[plr].armor[j].prefix);
				}
				for (int k = 0; k < Main.player[plr].dye.Length; k++)
				{
					SendData(5, toWho, fromWho, null, plr, 58 + Main.player[plr].armor.Length + 1 + k, (int)Main.player[plr].dye[k].prefix);
				}
				for (int l = 0; l < Main.player[plr].miscEquips.Length; l++)
				{
					SendData(5, toWho, fromWho, null, plr, 58 + Main.player[plr].armor.Length + Main.player[plr].dye.Length + 1 + l, (int)Main.player[plr].miscEquips[l].prefix);
				}
				for (int m = 0; m < Main.player[plr].miscDyes.Length; m++)
				{
					SendData(5, toWho, fromWho, null, plr, 58 + Main.player[plr].armor.Length + Main.player[plr].dye.Length + Main.player[plr].miscEquips.Length + 1 + m, (int)Main.player[plr].miscDyes[m].prefix);
				}
				if (!Netplay.Clients[plr].IsAnnouncementCompleted)
				{
					Netplay.Clients[plr].IsAnnouncementCompleted = true;
					BroadcastChatMessage(NetworkText.FromKey(Lang.mp[19].Key, Main.player[plr].name), new Color(255, 240, 20), plr);
					if (Main.dedServ)
					{
						Console.WriteLine(Lang.mp[19].Format(Main.player[plr].name));
					}
				}
				return;
			}
			num = 0;
			SendData(14, -1, plr, null, plr, num);
			if (Netplay.Clients[plr].IsAnnouncementCompleted)
			{
				Netplay.Clients[plr].IsAnnouncementCompleted = false;
				BroadcastChatMessage(NetworkText.FromKey(Lang.mp[20].Key, Netplay.Clients[plr].Name), new Color(255, 240, 20), plr);
				if (Main.dedServ)
				{
					Console.WriteLine(Lang.mp[20].Format(Netplay.Clients[plr].Name));
				}
				Netplay.Clients[plr].Name = "Anonymous";
			}
		}
	}
}
