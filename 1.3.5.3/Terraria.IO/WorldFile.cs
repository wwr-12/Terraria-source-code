using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria.IO
{
	public class WorldFile
	{
		private static object padlock = new object();

		public static double tempTime = Main.time;

		public static bool tempRaining = false;

		public static float tempMaxRain = 0f;

		public static int tempRainTime = 0;

		public static bool tempDayTime = Main.dayTime;

		public static bool tempBloodMoon = Main.bloodMoon;

		public static bool tempEclipse = Main.eclipse;

		public static int tempMoonPhase = Main.moonPhase;

		public static int tempCultistDelay = CultistRitual.delay;

		public static int versionNumber;

		public static bool IsWorldOnCloud = false;

		public static bool tempPartyGenuine = false;

		public static bool tempPartyManual = false;

		public static int tempPartyCooldown = 0;

		public static List<int> tempPartyCelebratingNPCs = new List<int>();

		private static bool HasCache = false;

		private static bool? CachedDayTime = null;

		private static double? CachedTime = null;

		private static int? CachedMoonPhase = null;

		private static bool? CachedBloodMoon = null;

		private static bool? CachedEclipse = null;

		private static int? CachedCultistDelay = null;

		private static bool? CachedPartyGenuine = null;

		private static bool? CachedPartyManual = null;

		private static int? CachedPartyDaysOnCooldown = null;

		private static List<int> CachedCelebratingNPCs = new List<int>();

		private static bool? Cached_Sandstorm_Happening = null;

		private static bool Temp_Sandstorm_Happening = false;

		private static int? Cached_Sandstorm_TimeLeft = null;

		private static int Temp_Sandstorm_TimeLeft = 0;

		private static float? Cached_Sandstorm_Severity = null;

		private static float Temp_Sandstorm_Severity = 0f;

		private static float? Cached_Sandstorm_IntendedSeverity = null;

		private static float Temp_Sandstorm_IntendedSeverity = 0f;

		public static event Action OnWorldLoad;

		public static void CacheSaveTime()
		{
			HasCache = true;
			CachedDayTime = Main.dayTime;
			CachedTime = Main.time;
			CachedMoonPhase = Main.moonPhase;
			CachedBloodMoon = Main.bloodMoon;
			CachedEclipse = Main.eclipse;
			CachedCultistDelay = CultistRitual.delay;
			CachedPartyGenuine = BirthdayParty.GenuineParty;
			CachedPartyManual = BirthdayParty.ManualParty;
			CachedPartyDaysOnCooldown = BirthdayParty.PartyDaysOnCooldown;
			CachedCelebratingNPCs.Clear();
			CachedCelebratingNPCs.AddRange(BirthdayParty.CelebratingNPCs);
			Cached_Sandstorm_Happening = Sandstorm.Happening;
			Cached_Sandstorm_TimeLeft = Sandstorm.TimeLeft;
			Cached_Sandstorm_Severity = Sandstorm.Severity;
			Cached_Sandstorm_IntendedSeverity = Sandstorm.IntendedSeverity;
		}

		private static void ResetTempsToDayTime()
		{
			tempDayTime = true;
			tempTime = 13500.0;
			tempMoonPhase = 0;
			tempBloodMoon = false;
			tempEclipse = false;
			tempCultistDelay = 86400;
			tempPartyManual = false;
			tempPartyGenuine = false;
			tempPartyCooldown = 0;
			tempPartyCelebratingNPCs.Clear();
			Temp_Sandstorm_Happening = false;
			Temp_Sandstorm_TimeLeft = 0;
			Temp_Sandstorm_Severity = 0f;
			Temp_Sandstorm_IntendedSeverity = 0f;
		}

		private static void SetTempToOngoing()
		{
			tempDayTime = Main.dayTime;
			tempTime = Main.time;
			tempMoonPhase = Main.moonPhase;
			tempBloodMoon = Main.bloodMoon;
			tempEclipse = Main.eclipse;
			tempCultistDelay = CultistRitual.delay;
			tempPartyManual = BirthdayParty.ManualParty;
			tempPartyGenuine = BirthdayParty.GenuineParty;
			tempPartyCooldown = BirthdayParty.PartyDaysOnCooldown;
			tempPartyCelebratingNPCs.Clear();
			tempPartyCelebratingNPCs.AddRange(BirthdayParty.CelebratingNPCs);
			Temp_Sandstorm_Happening = Sandstorm.Happening;
			Temp_Sandstorm_TimeLeft = Sandstorm.TimeLeft;
			Temp_Sandstorm_Severity = Sandstorm.Severity;
			Temp_Sandstorm_IntendedSeverity = Sandstorm.IntendedSeverity;
		}

		private static void SetTempToCache()
		{
			HasCache = false;
			tempDayTime = CachedDayTime.Value;
			tempTime = CachedTime.Value;
			tempMoonPhase = CachedMoonPhase.Value;
			tempBloodMoon = CachedBloodMoon.Value;
			tempEclipse = CachedEclipse.Value;
			tempCultistDelay = CachedCultistDelay.Value;
			tempPartyManual = CachedPartyManual.Value;
			tempPartyGenuine = CachedPartyGenuine.Value;
			tempPartyCooldown = CachedPartyDaysOnCooldown.Value;
			tempPartyCelebratingNPCs.Clear();
			tempPartyCelebratingNPCs.AddRange(CachedCelebratingNPCs);
			Temp_Sandstorm_Happening = Cached_Sandstorm_Happening.Value;
			Temp_Sandstorm_TimeLeft = Cached_Sandstorm_TimeLeft.Value;
			Temp_Sandstorm_Severity = Cached_Sandstorm_Severity.Value;
			Temp_Sandstorm_IntendedSeverity = Cached_Sandstorm_IntendedSeverity.Value;
		}

		public static void SetOngoingToTemps()
		{
			Main.dayTime = tempDayTime;
			Main.time = tempTime;
			Main.moonPhase = tempMoonPhase;
			Main.bloodMoon = tempBloodMoon;
			Main.eclipse = tempEclipse;
			Main.raining = tempRaining;
			Main.rainTime = tempRainTime;
			Main.maxRaining = tempMaxRain;
			Main.cloudAlpha = tempMaxRain;
			CultistRitual.delay = tempCultistDelay;
			BirthdayParty.ManualParty = tempPartyManual;
			BirthdayParty.GenuineParty = tempPartyGenuine;
			BirthdayParty.PartyDaysOnCooldown = tempPartyCooldown;
			BirthdayParty.CelebratingNPCs.Clear();
			BirthdayParty.CelebratingNPCs.AddRange(tempPartyCelebratingNPCs);
			Sandstorm.Happening = Temp_Sandstorm_Happening;
			Sandstorm.TimeLeft = Temp_Sandstorm_TimeLeft;
			Sandstorm.Severity = Temp_Sandstorm_Severity;
			Sandstorm.IntendedSeverity = Temp_Sandstorm_IntendedSeverity;
		}

		public static void loadWorld(bool loadFromCloud)
		{
			IsWorldOnCloud = loadFromCloud;
			Main.checkXMas();
			Main.checkHalloween();
			bool flag = loadFromCloud && SocialAPI.Cloud != null;
			if (!FileUtilities.Exists(Main.worldPathName, flag) && Main.autoGen)
			{
				if (!flag)
				{
					for (int num = Main.worldPathName.Length - 1; num >= 0; num--)
					{
						if (Main.worldPathName.Substring(num, 1) == (Path.DirectorySeparatorChar.ToString() ?? ""))
						{
							Directory.CreateDirectory(Main.worldPathName.Substring(0, num));
							break;
						}
					}
				}
				WorldGen.clearWorld();
				Main.ActiveWorldFileData = CreateMetadata((Main.worldName == "") ? "World" : Main.worldName, flag, Main.expertMode);
				string text = (Main.AutogenSeedName ?? "").Trim();
				if (text.Length == 0)
				{
					Main.ActiveWorldFileData.SetSeedToRandom();
				}
				else
				{
					Main.ActiveWorldFileData.SetSeed(text);
				}
				WorldGen.generateWorld(Main.ActiveWorldFileData.Seed, Main.AutogenProgress);
				saveWorld();
			}
			using (MemoryStream memoryStream = new MemoryStream(FileUtilities.ReadAllBytes(Main.worldPathName, flag)))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					try
					{
						WorldGen.loadFailed = false;
						WorldGen.loadSuccess = false;
						int num2 = (versionNumber = binaryReader.ReadInt32());
						int num3 = ((num2 > 87) ? LoadWorld_Version2(binaryReader) : LoadWorld_Version1(binaryReader));
						if (num2 < 141)
						{
							if (!loadFromCloud)
							{
								Main.ActiveWorldFileData.CreationTime = File.GetCreationTime(Main.worldPathName);
							}
							else
							{
								Main.ActiveWorldFileData.CreationTime = DateTime.Now;
							}
						}
						binaryReader.Close();
						memoryStream.Close();
						if (num3 != 0)
						{
							WorldGen.loadFailed = true;
						}
						else
						{
							WorldGen.loadSuccess = true;
						}
						if (WorldGen.loadFailed || !WorldGen.loadSuccess)
						{
							return;
						}
						WorldGen.gen = true;
						WorldGen.waterLine = Main.maxTilesY;
						Liquid.QuickWater(2);
						WorldGen.WaterCheck();
						int num4 = 0;
						Liquid.quickSettle = true;
						int num5 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
						float num6 = 0f;
						while (Liquid.numLiquid > 0 && num4 < 100000)
						{
							num4++;
							float num7 = (float)(num5 - (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer)) / (float)num5;
							if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > num5)
							{
								num5 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
							}
							if (num7 > num6)
							{
								num6 = num7;
							}
							else
							{
								num7 = num6;
							}
							Main.statusText = Lang.gen[27].Value + " " + (int)(num7 * 100f / 2f + 50f) + "%";
							Liquid.UpdateLiquid();
						}
						Liquid.quickSettle = false;
						Main.weatherCounter = WorldGen.genRand.Next(3600, 18000);
						Cloud.resetClouds();
						WorldGen.WaterCheck();
						WorldGen.gen = false;
						NPC.setFireFlyChance();
						Main.InitLifeBytes();
						if (Main.slimeRainTime > 0.0)
						{
							Main.StartSlimeRain(announce: false);
						}
						NPC.setWorldMonsters();
					}
					catch
					{
						WorldGen.loadFailed = true;
						WorldGen.loadSuccess = false;
						try
						{
							binaryReader.Close();
							memoryStream.Close();
							return;
						}
						catch
						{
							return;
						}
					}
				}
			}
			if (WorldFile.OnWorldLoad != null)
			{
				WorldFile.OnWorldLoad();
			}
		}

		public static void saveWorld()
		{
			saveWorld(IsWorldOnCloud);
		}

		public static void saveWorld(bool useCloudSaving, bool resetTime = false)
		{
			if (useCloudSaving && SocialAPI.Cloud == null)
			{
				return;
			}
			if (Main.worldName == "")
			{
				Main.worldName = "World";
			}
			if (WorldGen.saveLock)
			{
				return;
			}
			WorldGen.saveLock = true;
			while (WorldGen.IsGeneratingHardMode)
			{
				Main.statusText = Lang.gen[48].Value;
			}
			lock (padlock)
			{
				try
				{
					Directory.CreateDirectory(Main.WorldPath);
				}
				catch
				{
				}
				if (Main.skipMenu)
				{
					return;
				}
				if (HasCache)
				{
					SetTempToCache();
				}
				else
				{
					SetTempToOngoing();
				}
				if (resetTime)
				{
					ResetTempsToDayTime();
				}
				if (Main.worldPathName == null)
				{
					return;
				}
				new Stopwatch().Start();
				byte[] array = null;
				int num = 0;
				using (MemoryStream memoryStream = new MemoryStream(7000000))
				{
					using (BinaryWriter writer = new BinaryWriter(memoryStream))
					{
						SaveWorld_Version2(writer);
					}
					array = memoryStream.ToArray();
					num = array.Length;
				}
				if (array == null)
				{
					return;
				}
				byte[] array2 = null;
				if (FileUtilities.Exists(Main.worldPathName, useCloudSaving))
				{
					array2 = FileUtilities.ReadAllBytes(Main.worldPathName, useCloudSaving);
				}
				FileUtilities.Write(Main.worldPathName, array, num, useCloudSaving);
				array = FileUtilities.ReadAllBytes(Main.worldPathName, useCloudSaving);
				string text = null;
				using (MemoryStream input = new MemoryStream(array, 0, num, writable: false))
				{
					using (BinaryReader fileIO = new BinaryReader(input))
					{
						if (!Main.validateSaves || validateWorld(fileIO))
						{
							if (array2 != null)
							{
								text = Main.worldPathName + ".bak";
								Main.statusText = Lang.gen[50].Value;
							}
						}
						else
						{
							text = Main.worldPathName;
						}
					}
				}
				if (text != null && array2 != null)
				{
					FileUtilities.WriteAllBytes(text, array2, useCloudSaving);
				}
				WorldGen.saveLock = false;
			}
			Main.serverGenLock = false;
		}

		public static int LoadWorld_Version1(BinaryReader fileIO)
		{
			Main.WorldFileMetadata = FileMetadata.FromCurrentSettings(FileType.World);
			int num = versionNumber;
			if (num > 194)
			{
				return 1;
			}
			Main.worldName = fileIO.ReadString();
			Main.worldID = fileIO.ReadInt32();
			Main.leftWorld = fileIO.ReadInt32();
			Main.rightWorld = fileIO.ReadInt32();
			Main.topWorld = fileIO.ReadInt32();
			Main.bottomWorld = fileIO.ReadInt32();
			Main.maxTilesY = fileIO.ReadInt32();
			Main.maxTilesX = fileIO.ReadInt32();
			if (num >= 112)
			{
				Main.expertMode = fileIO.ReadBoolean();
			}
			else
			{
				Main.expertMode = false;
			}
			if (num >= 63)
			{
				Main.moonType = fileIO.ReadByte();
			}
			else
			{
				WorldGen.RandomizeMoonState();
			}
			WorldGen.clearWorld();
			if (num >= 44)
			{
				Main.treeX[0] = fileIO.ReadInt32();
				Main.treeX[1] = fileIO.ReadInt32();
				Main.treeX[2] = fileIO.ReadInt32();
				Main.treeStyle[0] = fileIO.ReadInt32();
				Main.treeStyle[1] = fileIO.ReadInt32();
				Main.treeStyle[2] = fileIO.ReadInt32();
				Main.treeStyle[3] = fileIO.ReadInt32();
			}
			if (num >= 60)
			{
				Main.caveBackX[0] = fileIO.ReadInt32();
				Main.caveBackX[1] = fileIO.ReadInt32();
				Main.caveBackX[2] = fileIO.ReadInt32();
				Main.caveBackStyle[0] = fileIO.ReadInt32();
				Main.caveBackStyle[1] = fileIO.ReadInt32();
				Main.caveBackStyle[2] = fileIO.ReadInt32();
				Main.caveBackStyle[3] = fileIO.ReadInt32();
				Main.iceBackStyle = fileIO.ReadInt32();
				if (num >= 61)
				{
					Main.jungleBackStyle = fileIO.ReadInt32();
					Main.hellBackStyle = fileIO.ReadInt32();
				}
			}
			else
			{
				WorldGen.RandomizeCaveBackgrounds();
			}
			Main.spawnTileX = fileIO.ReadInt32();
			Main.spawnTileY = fileIO.ReadInt32();
			Main.worldSurface = fileIO.ReadDouble();
			Main.rockLayer = fileIO.ReadDouble();
			tempTime = fileIO.ReadDouble();
			tempDayTime = fileIO.ReadBoolean();
			tempMoonPhase = fileIO.ReadInt32();
			tempBloodMoon = fileIO.ReadBoolean();
			if (num >= 70)
			{
				tempEclipse = fileIO.ReadBoolean();
				Main.eclipse = tempEclipse;
			}
			Main.dungeonX = fileIO.ReadInt32();
			Main.dungeonY = fileIO.ReadInt32();
			if (num >= 56)
			{
				WorldGen.crimson = fileIO.ReadBoolean();
			}
			else
			{
				WorldGen.crimson = false;
			}
			NPC.downedBoss1 = fileIO.ReadBoolean();
			NPC.downedBoss2 = fileIO.ReadBoolean();
			NPC.downedBoss3 = fileIO.ReadBoolean();
			if (num >= 66)
			{
				NPC.downedQueenBee = fileIO.ReadBoolean();
			}
			if (num >= 44)
			{
				NPC.downedMechBoss1 = fileIO.ReadBoolean();
				NPC.downedMechBoss2 = fileIO.ReadBoolean();
				NPC.downedMechBoss3 = fileIO.ReadBoolean();
				NPC.downedMechBossAny = fileIO.ReadBoolean();
			}
			if (num >= 64)
			{
				NPC.downedPlantBoss = fileIO.ReadBoolean();
				NPC.downedGolemBoss = fileIO.ReadBoolean();
			}
			if (num >= 29)
			{
				NPC.savedGoblin = fileIO.ReadBoolean();
				NPC.savedWizard = fileIO.ReadBoolean();
				if (num >= 34)
				{
					NPC.savedMech = fileIO.ReadBoolean();
					if (num >= 80)
					{
						NPC.savedStylist = fileIO.ReadBoolean();
					}
				}
				if (num >= 129)
				{
					NPC.savedTaxCollector = fileIO.ReadBoolean();
				}
				NPC.downedGoblins = fileIO.ReadBoolean();
			}
			if (num >= 32)
			{
				NPC.downedClown = fileIO.ReadBoolean();
			}
			if (num >= 37)
			{
				NPC.downedFrost = fileIO.ReadBoolean();
			}
			if (num >= 56)
			{
				NPC.downedPirates = fileIO.ReadBoolean();
			}
			WorldGen.shadowOrbSmashed = fileIO.ReadBoolean();
			WorldGen.spawnMeteor = fileIO.ReadBoolean();
			WorldGen.shadowOrbCount = fileIO.ReadByte();
			if (num >= 23)
			{
				WorldGen.altarCount = fileIO.ReadInt32();
				Main.hardMode = fileIO.ReadBoolean();
			}
			Main.invasionDelay = fileIO.ReadInt32();
			Main.invasionSize = fileIO.ReadInt32();
			Main.invasionType = fileIO.ReadInt32();
			Main.invasionX = fileIO.ReadDouble();
			if (num >= 113)
			{
				Main.sundialCooldown = fileIO.ReadByte();
			}
			if (num >= 53)
			{
				tempRaining = fileIO.ReadBoolean();
				tempRainTime = fileIO.ReadInt32();
				tempMaxRain = fileIO.ReadSingle();
			}
			if (num >= 54)
			{
				WorldGen.oreTier1 = fileIO.ReadInt32();
				WorldGen.oreTier2 = fileIO.ReadInt32();
				WorldGen.oreTier3 = fileIO.ReadInt32();
			}
			else if (num >= 23 && WorldGen.altarCount == 0)
			{
				WorldGen.oreTier1 = -1;
				WorldGen.oreTier2 = -1;
				WorldGen.oreTier3 = -1;
			}
			else
			{
				WorldGen.oreTier1 = 107;
				WorldGen.oreTier2 = 108;
				WorldGen.oreTier3 = 111;
			}
			int style = 0;
			int style2 = 0;
			int style3 = 0;
			int style4 = 0;
			int style5 = 0;
			int style6 = 0;
			int style7 = 0;
			int style8 = 0;
			if (num >= 55)
			{
				style = fileIO.ReadByte();
				style2 = fileIO.ReadByte();
				style3 = fileIO.ReadByte();
			}
			if (num >= 60)
			{
				style4 = fileIO.ReadByte();
				style5 = fileIO.ReadByte();
				style6 = fileIO.ReadByte();
				style7 = fileIO.ReadByte();
				style8 = fileIO.ReadByte();
			}
			WorldGen.setBG(0, style);
			WorldGen.setBG(1, style2);
			WorldGen.setBG(2, style3);
			WorldGen.setBG(3, style4);
			WorldGen.setBG(4, style5);
			WorldGen.setBG(5, style6);
			WorldGen.setBG(6, style7);
			WorldGen.setBG(7, style8);
			if (num >= 60)
			{
				Main.cloudBGActive = fileIO.ReadInt32();
				if (Main.cloudBGActive >= 1f)
				{
					Main.cloudBGAlpha = 1f;
				}
				else
				{
					Main.cloudBGAlpha = 0f;
				}
			}
			else
			{
				Main.cloudBGActive = -WorldGen.genRand.Next(8640, 86400);
			}
			if (num >= 62)
			{
				Main.numClouds = fileIO.ReadInt16();
				Main.windSpeedSet = fileIO.ReadSingle();
				Main.windSpeed = Main.windSpeedSet;
			}
			else
			{
				WorldGen.RandomizeWeather();
			}
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				float num2 = (float)i / (float)Main.maxTilesX;
				Main.statusText = Lang.gen[51].Value + " " + (int)(num2 * 100f + 1f) + "%";
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					Tile tile = Main.tile[i, j];
					int num3 = -1;
					tile.active(fileIO.ReadBoolean());
					if (tile.active())
					{
						num3 = ((num <= 77) ? fileIO.ReadByte() : fileIO.ReadUInt16());
						tile.type = (ushort)num3;
						if (tile.type == 127)
						{
							tile.active(active: false);
						}
						if (num < 72 && (tile.type == 35 || tile.type == 36 || tile.type == 170 || tile.type == 171 || tile.type == 172))
						{
							tile.frameX = fileIO.ReadInt16();
							tile.frameY = fileIO.ReadInt16();
						}
						else if (Main.tileFrameImportant[num3])
						{
							if (num < 28 && num3 == 4)
							{
								tile.frameX = 0;
								tile.frameY = 0;
							}
							else if (num < 40 && tile.type == 19)
							{
								tile.frameX = 0;
								tile.frameY = 0;
							}
							else
							{
								tile.frameX = fileIO.ReadInt16();
								tile.frameY = fileIO.ReadInt16();
								if (tile.type == 144)
								{
									tile.frameY = 0;
								}
							}
						}
						else
						{
							tile.frameX = -1;
							tile.frameY = -1;
						}
						if (num >= 48 && fileIO.ReadBoolean())
						{
							tile.color(fileIO.ReadByte());
						}
					}
					if (num <= 25)
					{
						fileIO.ReadBoolean();
					}
					if (fileIO.ReadBoolean())
					{
						tile.wall = fileIO.ReadByte();
						if (num >= 48 && fileIO.ReadBoolean())
						{
							tile.wallColor(fileIO.ReadByte());
						}
					}
					if (fileIO.ReadBoolean())
					{
						tile.liquid = fileIO.ReadByte();
						tile.lava(fileIO.ReadBoolean());
						if (num >= 51)
						{
							tile.honey(fileIO.ReadBoolean());
						}
					}
					if (num >= 33)
					{
						tile.wire(fileIO.ReadBoolean());
					}
					if (num >= 43)
					{
						tile.wire2(fileIO.ReadBoolean());
						tile.wire3(fileIO.ReadBoolean());
					}
					if (num >= 41)
					{
						tile.halfBrick(fileIO.ReadBoolean());
						if (!Main.tileSolid[tile.type])
						{
							tile.halfBrick(halfBrick: false);
						}
						if (num >= 49)
						{
							tile.slope(fileIO.ReadByte());
							if (!Main.tileSolid[tile.type])
							{
								tile.slope(0);
							}
						}
					}
					if (num >= 42)
					{
						tile.actuator(fileIO.ReadBoolean());
						tile.inActive(fileIO.ReadBoolean());
					}
					int num4 = 0;
					if (num >= 25)
					{
						num4 = fileIO.ReadInt16();
					}
					if (num3 != -1)
					{
						if ((double)j <= Main.worldSurface)
						{
							if ((double)(j + num4) <= Main.worldSurface)
							{
								WorldGen.tileCounts[num3] += (num4 + 1) * 5;
							}
							else
							{
								int num5 = (int)(Main.worldSurface - (double)j + 1.0);
								int num6 = num4 + 1 - num5;
								WorldGen.tileCounts[num3] += num5 * 5 + num6;
							}
						}
						else
						{
							WorldGen.tileCounts[num3] += num4 + 1;
						}
					}
					if (num4 > 0)
					{
						for (int k = j + 1; k < j + num4 + 1; k++)
						{
							Main.tile[i, k].CopyFrom(Main.tile[i, j]);
						}
						j += num4;
					}
				}
			}
			WorldGen.AddUpAlignmentCounts(clearCounts: true);
			if (num < 67)
			{
				WorldGen.FixSunflowers();
			}
			if (num < 72)
			{
				WorldGen.FixChands();
			}
			int num7 = 40;
			if (num < 58)
			{
				num7 = 20;
			}
			for (int l = 0; l < 1000; l++)
			{
				if (!fileIO.ReadBoolean())
				{
					continue;
				}
				Main.chest[l] = new Chest();
				Main.chest[l].x = fileIO.ReadInt32();
				Main.chest[l].y = fileIO.ReadInt32();
				if (num >= 85)
				{
					string text = fileIO.ReadString();
					if (text.Length > 20)
					{
						text = text.Substring(0, 20);
					}
					Main.chest[l].name = text;
				}
				for (int m = 0; m < 40; m++)
				{
					Main.chest[l].item[m] = new Item();
					if (m >= num7)
					{
						continue;
					}
					int num8 = 0;
					num8 = ((num < 59) ? fileIO.ReadByte() : fileIO.ReadInt16());
					if (num8 > 0)
					{
						if (num >= 38)
						{
							Main.chest[l].item[m].netDefaults(fileIO.ReadInt32());
						}
						else
						{
							short type = ItemID.FromLegacyName(fileIO.ReadString(), num);
							Main.chest[l].item[m].SetDefaults(type);
						}
						Main.chest[l].item[m].stack = num8;
						if (num >= 36)
						{
							Main.chest[l].item[m].Prefix(fileIO.ReadByte());
						}
					}
				}
			}
			for (int n = 0; n < 1000; n++)
			{
				if (fileIO.ReadBoolean())
				{
					string text2 = fileIO.ReadString();
					int num9 = fileIO.ReadInt32();
					int num10 = fileIO.ReadInt32();
					if (Main.tile[num9, num10].active() && (Main.tile[num9, num10].type == 55 || Main.tile[num9, num10].type == 85))
					{
						Main.sign[n] = new Sign();
						Main.sign[n].x = num9;
						Main.sign[n].y = num10;
						Main.sign[n].text = text2;
					}
				}
			}
			bool flag = fileIO.ReadBoolean();
			int num11 = 0;
			while (flag)
			{
				if (num >= 190)
				{
					Main.npc[num11].SetDefaults(fileIO.ReadInt32());
				}
				else
				{
					Main.npc[num11].SetDefaults(NPCID.FromLegacyName(fileIO.ReadString()));
				}
				if (num >= 83)
				{
					Main.npc[num11].GivenName = fileIO.ReadString();
				}
				Main.npc[num11].position.X = fileIO.ReadSingle();
				Main.npc[num11].position.Y = fileIO.ReadSingle();
				Main.npc[num11].homeless = fileIO.ReadBoolean();
				Main.npc[num11].homeTileX = fileIO.ReadInt32();
				Main.npc[num11].homeTileY = fileIO.ReadInt32();
				flag = fileIO.ReadBoolean();
				num11++;
			}
			if (num >= 31 && num <= 83)
			{
				NPC.setNPCName(fileIO.ReadString(), 17, resetExtras: true);
				NPC.setNPCName(fileIO.ReadString(), 18, resetExtras: true);
				NPC.setNPCName(fileIO.ReadString(), 19, resetExtras: true);
				NPC.setNPCName(fileIO.ReadString(), 20, resetExtras: true);
				NPC.setNPCName(fileIO.ReadString(), 22, resetExtras: true);
				NPC.setNPCName(fileIO.ReadString(), 54, resetExtras: true);
				NPC.setNPCName(fileIO.ReadString(), 38, resetExtras: true);
				NPC.setNPCName(fileIO.ReadString(), 107, resetExtras: true);
				NPC.setNPCName(fileIO.ReadString(), 108, resetExtras: true);
				if (num >= 35)
				{
					NPC.setNPCName(fileIO.ReadString(), 124, resetExtras: true);
					if (num >= 65)
					{
						NPC.setNPCName(fileIO.ReadString(), 160, resetExtras: true);
						NPC.setNPCName(fileIO.ReadString(), 178, resetExtras: true);
						NPC.setNPCName(fileIO.ReadString(), 207, resetExtras: true);
						NPC.setNPCName(fileIO.ReadString(), 208, resetExtras: true);
						NPC.setNPCName(fileIO.ReadString(), 209, resetExtras: true);
						NPC.setNPCName(fileIO.ReadString(), 227, resetExtras: true);
						NPC.setNPCName(fileIO.ReadString(), 228, resetExtras: true);
						NPC.setNPCName(fileIO.ReadString(), 229, resetExtras: true);
						if (num >= 79)
						{
							NPC.setNPCName(fileIO.ReadString(), 353, resetExtras: true);
						}
					}
				}
			}
			if (Main.invasionType > 0 && Main.invasionSize > 0)
			{
				Main.FakeLoadInvasionStart();
			}
			if (num >= 7)
			{
				bool num12 = fileIO.ReadBoolean();
				string text3 = fileIO.ReadString();
				int num13 = fileIO.ReadInt32();
				if (num12 && (text3 == Main.worldName || num13 == Main.worldID))
				{
					return 0;
				}
				return 2;
			}
			return 0;
		}

		public static void SaveWorld_Version2(BinaryWriter writer)
		{
			int[] pointers = new int[10]
			{
				SaveFileFormatHeader(writer),
				SaveWorldHeader(writer),
				SaveWorldTiles(writer),
				SaveChests(writer),
				SaveSigns(writer),
				SaveNPCs(writer),
				SaveTileEntities(writer),
				SaveWeightedPressurePlates(writer),
				SaveTownManager(writer),
				0
			};
			SaveFooter(writer);
			SaveHeaderPointers(writer, pointers);
		}

		private static int SaveFileFormatHeader(BinaryWriter writer)
		{
			short num = 470;
			short num2 = 10;
			writer.Write(194);
			Main.WorldFileMetadata.IncrementAndWrite(writer);
			writer.Write(num2);
			for (int i = 0; i < num2; i++)
			{
				writer.Write(0);
			}
			writer.Write(num);
			byte b = 0;
			byte b2 = 1;
			for (int i = 0; i < num; i++)
			{
				if (Main.tileFrameImportant[i])
				{
					b |= b2;
				}
				if (b2 == 128)
				{
					writer.Write(b);
					b = 0;
					b2 = 1;
				}
				else
				{
					b2 <<= 1;
				}
			}
			if (b2 != 1)
			{
				writer.Write(b);
			}
			return (int)writer.BaseStream.Position;
		}

		private static int SaveHeaderPointers(BinaryWriter writer, int[] pointers)
		{
			writer.BaseStream.Position = 0L;
			writer.Write(194);
			writer.BaseStream.Position += 20L;
			writer.Write((short)pointers.Length);
			for (int i = 0; i < pointers.Length; i++)
			{
				writer.Write(pointers[i]);
			}
			return (int)writer.BaseStream.Position;
		}

		private static int SaveWorldHeader(BinaryWriter writer)
		{
			writer.Write(Main.worldName);
			writer.Write(Main.ActiveWorldFileData.SeedText);
			writer.Write(Main.ActiveWorldFileData.WorldGeneratorVersion);
			writer.Write(Main.ActiveWorldFileData.UniqueId.ToByteArray());
			writer.Write(Main.worldID);
			writer.Write((int)Main.leftWorld);
			writer.Write((int)Main.rightWorld);
			writer.Write((int)Main.topWorld);
			writer.Write((int)Main.bottomWorld);
			writer.Write(Main.maxTilesY);
			writer.Write(Main.maxTilesX);
			writer.Write(Main.expertMode);
			writer.Write(Main.ActiveWorldFileData.CreationTime.ToBinary());
			writer.Write((byte)Main.moonType);
			writer.Write(Main.treeX[0]);
			writer.Write(Main.treeX[1]);
			writer.Write(Main.treeX[2]);
			writer.Write(Main.treeStyle[0]);
			writer.Write(Main.treeStyle[1]);
			writer.Write(Main.treeStyle[2]);
			writer.Write(Main.treeStyle[3]);
			writer.Write(Main.caveBackX[0]);
			writer.Write(Main.caveBackX[1]);
			writer.Write(Main.caveBackX[2]);
			writer.Write(Main.caveBackStyle[0]);
			writer.Write(Main.caveBackStyle[1]);
			writer.Write(Main.caveBackStyle[2]);
			writer.Write(Main.caveBackStyle[3]);
			writer.Write(Main.iceBackStyle);
			writer.Write(Main.jungleBackStyle);
			writer.Write(Main.hellBackStyle);
			writer.Write(Main.spawnTileX);
			writer.Write(Main.spawnTileY);
			writer.Write(Main.worldSurface);
			writer.Write(Main.rockLayer);
			writer.Write(tempTime);
			writer.Write(tempDayTime);
			writer.Write(tempMoonPhase);
			writer.Write(tempBloodMoon);
			writer.Write(tempEclipse);
			writer.Write(Main.dungeonX);
			writer.Write(Main.dungeonY);
			writer.Write(WorldGen.crimson);
			writer.Write(NPC.downedBoss1);
			writer.Write(NPC.downedBoss2);
			writer.Write(NPC.downedBoss3);
			writer.Write(NPC.downedQueenBee);
			writer.Write(NPC.downedMechBoss1);
			writer.Write(NPC.downedMechBoss2);
			writer.Write(NPC.downedMechBoss3);
			writer.Write(NPC.downedMechBossAny);
			writer.Write(NPC.downedPlantBoss);
			writer.Write(NPC.downedGolemBoss);
			writer.Write(NPC.downedSlimeKing);
			writer.Write(NPC.savedGoblin);
			writer.Write(NPC.savedWizard);
			writer.Write(NPC.savedMech);
			writer.Write(NPC.downedGoblins);
			writer.Write(NPC.downedClown);
			writer.Write(NPC.downedFrost);
			writer.Write(NPC.downedPirates);
			writer.Write(WorldGen.shadowOrbSmashed);
			writer.Write(WorldGen.spawnMeteor);
			writer.Write((byte)WorldGen.shadowOrbCount);
			writer.Write(WorldGen.altarCount);
			writer.Write(Main.hardMode);
			writer.Write(Main.invasionDelay);
			writer.Write(Main.invasionSize);
			writer.Write(Main.invasionType);
			writer.Write(Main.invasionX);
			writer.Write(Main.slimeRainTime);
			writer.Write((byte)Main.sundialCooldown);
			writer.Write(tempRaining);
			writer.Write(tempRainTime);
			writer.Write(tempMaxRain);
			writer.Write(WorldGen.oreTier1);
			writer.Write(WorldGen.oreTier2);
			writer.Write(WorldGen.oreTier3);
			writer.Write((byte)WorldGen.treeBG);
			writer.Write((byte)WorldGen.corruptBG);
			writer.Write((byte)WorldGen.jungleBG);
			writer.Write((byte)WorldGen.snowBG);
			writer.Write((byte)WorldGen.hallowBG);
			writer.Write((byte)WorldGen.crimsonBG);
			writer.Write((byte)WorldGen.desertBG);
			writer.Write((byte)WorldGen.oceanBG);
			writer.Write((int)Main.cloudBGActive);
			writer.Write((short)Main.numClouds);
			writer.Write(Main.windSpeedSet);
			writer.Write(Main.anglerWhoFinishedToday.Count);
			for (int i = 0; i < Main.anglerWhoFinishedToday.Count; i++)
			{
				writer.Write(Main.anglerWhoFinishedToday[i]);
			}
			writer.Write(NPC.savedAngler);
			writer.Write(Main.anglerQuest);
			writer.Write(NPC.savedStylist);
			writer.Write(NPC.savedTaxCollector);
			writer.Write(Main.invasionSizeStart);
			writer.Write(tempCultistDelay);
			writer.Write((short)580);
			for (int j = 0; j < 580; j++)
			{
				writer.Write(NPC.killCount[j]);
			}
			writer.Write(Main.fastForwardTime);
			writer.Write(NPC.downedFishron);
			writer.Write(NPC.downedMartians);
			writer.Write(NPC.downedAncientCultist);
			writer.Write(NPC.downedMoonlord);
			writer.Write(NPC.downedHalloweenKing);
			writer.Write(NPC.downedHalloweenTree);
			writer.Write(NPC.downedChristmasIceQueen);
			writer.Write(NPC.downedChristmasSantank);
			writer.Write(NPC.downedChristmasTree);
			writer.Write(NPC.downedTowerSolar);
			writer.Write(NPC.downedTowerVortex);
			writer.Write(NPC.downedTowerNebula);
			writer.Write(NPC.downedTowerStardust);
			writer.Write(NPC.TowerActiveSolar);
			writer.Write(NPC.TowerActiveVortex);
			writer.Write(NPC.TowerActiveNebula);
			writer.Write(NPC.TowerActiveStardust);
			writer.Write(NPC.LunarApocalypseIsUp);
			writer.Write(tempPartyManual);
			writer.Write(tempPartyGenuine);
			writer.Write(tempPartyCooldown);
			writer.Write(tempPartyCelebratingNPCs.Count);
			for (int k = 0; k < tempPartyCelebratingNPCs.Count; k++)
			{
				writer.Write(tempPartyCelebratingNPCs[k]);
			}
			writer.Write(Temp_Sandstorm_Happening);
			writer.Write(Temp_Sandstorm_TimeLeft);
			writer.Write(Temp_Sandstorm_Severity);
			writer.Write(Temp_Sandstorm_IntendedSeverity);
			writer.Write(NPC.savedBartender);
			DD2Event.Save(writer);
			return (int)writer.BaseStream.Position;
		}

		private static int SaveWorldTiles(BinaryWriter writer)
		{
			byte[] array = new byte[13];
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				float num = (float)i / (float)Main.maxTilesX;
				Main.statusText = Lang.gen[49].Value + " " + (int)(num * 100f + 1f) + "%";
				int num2;
				for (num2 = 0; num2 < Main.maxTilesY; num2++)
				{
					Tile tile = Main.tile[i, num2];
					int num3 = 3;
					byte b3;
					byte b2;
					byte b = (b2 = (b3 = 0));
					bool flag = false;
					if (tile.active())
					{
						flag = true;
						if (tile.type == 127)
						{
							WorldGen.KillTile(i, num2);
							if (!tile.active())
							{
								flag = false;
								if (Main.netMode != 0)
								{
									NetMessage.SendData(17, -1, -1, null, 0, i, num2);
								}
							}
						}
					}
					if (flag)
					{
						b |= 2;
						if (tile.type == 127)
						{
							WorldGen.KillTile(i, num2);
							if (!tile.active() && Main.netMode != 0)
							{
								NetMessage.SendData(17, -1, -1, null, 0, i, num2);
							}
						}
						array[num3] = (byte)tile.type;
						num3++;
						if (tile.type > 255)
						{
							array[num3] = (byte)(tile.type >> 8);
							num3++;
							b |= 0x20;
						}
						if (Main.tileFrameImportant[tile.type])
						{
							array[num3] = (byte)(tile.frameX & 0xFF);
							num3++;
							array[num3] = (byte)((tile.frameX & 0xFF00) >> 8);
							num3++;
							array[num3] = (byte)(tile.frameY & 0xFF);
							num3++;
							array[num3] = (byte)((tile.frameY & 0xFF00) >> 8);
							num3++;
						}
						if (tile.color() != 0)
						{
							b3 |= 8;
							array[num3] = tile.color();
							num3++;
						}
					}
					if (tile.wall != 0)
					{
						b |= 4;
						array[num3] = tile.wall;
						num3++;
						if (tile.wallColor() != 0)
						{
							b3 |= 0x10;
							array[num3] = tile.wallColor();
							num3++;
						}
					}
					if (tile.liquid != 0)
					{
						b = (tile.lava() ? ((byte)(b | 0x10)) : ((!tile.honey()) ? ((byte)(b | 8)) : ((byte)(b | 0x18))));
						array[num3] = tile.liquid;
						num3++;
					}
					if (tile.wire())
					{
						b2 |= 2;
					}
					if (tile.wire2())
					{
						b2 |= 4;
					}
					if (tile.wire3())
					{
						b2 |= 8;
					}
					int num4 = (tile.halfBrick() ? 16 : ((tile.slope() != 0) ? (tile.slope() + 1 << 4) : 0));
					b2 |= (byte)num4;
					if (tile.actuator())
					{
						b3 |= 2;
					}
					if (tile.inActive())
					{
						b3 |= 4;
					}
					if (tile.wire4())
					{
						b3 |= 0x20;
					}
					int num5 = 2;
					if (b3 != 0)
					{
						b2 |= 1;
						array[num5] = b3;
						num5--;
					}
					if (b2 != 0)
					{
						b |= 1;
						array[num5] = b2;
						num5--;
					}
					short num6 = 0;
					int num7 = num2 + 1;
					int num8 = Main.maxTilesY - num2 - 1;
					while (num8 > 0 && tile.isTheSameAs(Main.tile[i, num7]))
					{
						num6++;
						num8--;
						num7++;
					}
					num2 += num6;
					if (num6 > 0)
					{
						array[num3] = (byte)(num6 & 0xFF);
						num3++;
						if (num6 > 255)
						{
							b |= 0x80;
							array[num3] = (byte)((num6 & 0xFF00) >> 8);
							num3++;
						}
						else
						{
							b |= 0x40;
						}
					}
					array[num5] = b;
					writer.Write(array, num5, num3 - num5);
				}
			}
			return (int)writer.BaseStream.Position;
		}

		private static int SaveChests(BinaryWriter writer)
		{
			short num = 0;
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest == null)
				{
					continue;
				}
				bool flag = false;
				for (int j = chest.x; j <= chest.x + 1; j++)
				{
					for (int k = chest.y; k <= chest.y + 1; k++)
					{
						if (j < 0 || k < 0 || j >= Main.maxTilesX || k >= Main.maxTilesY)
						{
							flag = true;
							break;
						}
						Tile tile = Main.tile[j, k];
						if (!tile.active() || !Main.tileContainer[tile.type])
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					Main.chest[i] = null;
				}
				else
				{
					num++;
				}
			}
			writer.Write(num);
			writer.Write((short)40);
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest == null)
				{
					continue;
				}
				writer.Write(chest.x);
				writer.Write(chest.y);
				writer.Write(chest.name);
				for (int l = 0; l < 40; l++)
				{
					Item item = chest.item[l];
					if (item == null)
					{
						writer.Write((short)0);
						continue;
					}
					if (item.stack > item.maxStack)
					{
						item.stack = item.maxStack;
					}
					if (item.stack < 0)
					{
						item.stack = 1;
					}
					writer.Write((short)item.stack);
					if (item.stack > 0)
					{
						writer.Write(item.netID);
						writer.Write(item.prefix);
					}
				}
			}
			return (int)writer.BaseStream.Position;
		}

		private static int SaveSigns(BinaryWriter writer)
		{
			short num = 0;
			for (int i = 0; i < 1000; i++)
			{
				Sign sign = Main.sign[i];
				if (sign != null && sign.text != null)
				{
					num++;
				}
			}
			writer.Write(num);
			for (int j = 0; j < 1000; j++)
			{
				Sign sign = Main.sign[j];
				if (sign != null && sign.text != null)
				{
					writer.Write(sign.text);
					writer.Write(sign.x);
					writer.Write(sign.y);
				}
			}
			return (int)writer.BaseStream.Position;
		}

		private static int SaveDummies(BinaryWriter writer)
		{
			int num = 0;
			for (int i = 0; i < 1000; i++)
			{
				DeprecatedClassLeftInForLoading deprecatedClassLeftInForLoading = DeprecatedClassLeftInForLoading.dummies[i];
				if (deprecatedClassLeftInForLoading != null)
				{
					num++;
				}
			}
			writer.Write(num);
			for (int j = 0; j < 1000; j++)
			{
				DeprecatedClassLeftInForLoading deprecatedClassLeftInForLoading = DeprecatedClassLeftInForLoading.dummies[j];
				if (deprecatedClassLeftInForLoading != null)
				{
					writer.Write(deprecatedClassLeftInForLoading.x);
					writer.Write(deprecatedClassLeftInForLoading.y);
				}
			}
			return (int)writer.BaseStream.Position;
		}

		private static int SaveNPCs(BinaryWriter writer)
		{
			for (int i = 0; i < Main.npc.Length; i++)
			{
				NPC nPC = Main.npc[i];
				if (nPC.active && nPC.townNPC && nPC.type != 368)
				{
					writer.Write(nPC.active);
					writer.Write(nPC.netID);
					writer.Write(nPC.GivenName);
					writer.Write(nPC.position.X);
					writer.Write(nPC.position.Y);
					writer.Write(nPC.homeless);
					writer.Write(nPC.homeTileX);
					writer.Write(nPC.homeTileY);
				}
			}
			writer.Write(value: false);
			for (int j = 0; j < Main.npc.Length; j++)
			{
				NPC nPC2 = Main.npc[j];
				if (nPC2.active && NPCID.Sets.SavesAndLoads[nPC2.type])
				{
					writer.Write(nPC2.active);
					writer.Write(nPC2.netID);
					writer.WriteVector2(nPC2.position);
				}
			}
			writer.Write(value: false);
			return (int)writer.BaseStream.Position;
		}

		private static int SaveFooter(BinaryWriter writer)
		{
			writer.Write(value: true);
			writer.Write(Main.worldName);
			writer.Write(Main.worldID);
			return (int)writer.BaseStream.Position;
		}

		public static int LoadWorld_Version2(BinaryReader reader)
		{
			reader.BaseStream.Position = 0L;
			if (!LoadFileFormatHeader(reader, out var importance, out var positions))
			{
				return 5;
			}
			if (reader.BaseStream.Position != positions[0])
			{
				return 5;
			}
			LoadHeader(reader);
			if (reader.BaseStream.Position != positions[1])
			{
				return 5;
			}
			LoadWorldTiles(reader, importance);
			if (reader.BaseStream.Position != positions[2])
			{
				return 5;
			}
			LoadChests(reader);
			if (reader.BaseStream.Position != positions[3])
			{
				return 5;
			}
			LoadSigns(reader);
			if (reader.BaseStream.Position != positions[4])
			{
				return 5;
			}
			LoadNPCs(reader);
			if (reader.BaseStream.Position != positions[5])
			{
				return 5;
			}
			if (versionNumber >= 116)
			{
				if (versionNumber < 122)
				{
					LoadDummies(reader);
					if (reader.BaseStream.Position != positions[6])
					{
						return 5;
					}
				}
				else
				{
					LoadTileEntities(reader);
					if (reader.BaseStream.Position != positions[6])
					{
						return 5;
					}
				}
			}
			if (versionNumber >= 170)
			{
				LoadWeightedPressurePlates(reader);
				if (reader.BaseStream.Position != positions[7])
				{
					return 5;
				}
			}
			if (versionNumber >= 189)
			{
				LoadTownManager(reader);
				if (reader.BaseStream.Position != positions[8])
				{
					return 5;
				}
			}
			return LoadFooter(reader);
		}

		private static bool LoadFileFormatHeader(BinaryReader reader, out bool[] importance, out int[] positions)
		{
			importance = null;
			positions = null;
			if ((versionNumber = reader.ReadInt32()) >= 135)
			{
				try
				{
					Main.WorldFileMetadata = FileMetadata.Read(reader, FileType.World);
				}
				catch (FileFormatException value)
				{
					Console.WriteLine(Language.GetTextValue("Error.UnableToLoadWorld"));
					Console.WriteLine(value);
					return false;
				}
			}
			else
			{
				Main.WorldFileMetadata = FileMetadata.FromCurrentSettings(FileType.World);
			}
			short num = reader.ReadInt16();
			positions = new int[num];
			for (int i = 0; i < num; i++)
			{
				positions[i] = reader.ReadInt32();
			}
			short num2 = reader.ReadInt16();
			importance = new bool[num2];
			byte b = 0;
			byte b2 = 128;
			for (int i = 0; i < num2; i++)
			{
				if (b2 == 128)
				{
					b = reader.ReadByte();
					b2 = 1;
				}
				else
				{
					b2 <<= 1;
				}
				if ((b & b2) == b2)
				{
					importance[i] = true;
				}
			}
			return true;
		}

		private static void LoadHeader(BinaryReader reader)
		{
			int num = versionNumber;
			Main.worldName = reader.ReadString();
			if (num >= 179)
			{
				string seed = ((num != 179) ? reader.ReadString() : reader.ReadInt32().ToString());
				Main.ActiveWorldFileData.SetSeed(seed);
				Main.ActiveWorldFileData.WorldGeneratorVersion = reader.ReadUInt64();
			}
			if (num >= 181)
			{
				Main.ActiveWorldFileData.UniqueId = new Guid(reader.ReadBytes(16));
			}
			else
			{
				Main.ActiveWorldFileData.UniqueId = Guid.NewGuid();
			}
			Main.worldID = reader.ReadInt32();
			Main.leftWorld = reader.ReadInt32();
			Main.rightWorld = reader.ReadInt32();
			Main.topWorld = reader.ReadInt32();
			Main.bottomWorld = reader.ReadInt32();
			Main.maxTilesY = reader.ReadInt32();
			Main.maxTilesX = reader.ReadInt32();
			WorldGen.clearWorld();
			if (num >= 112)
			{
				Main.expertMode = reader.ReadBoolean();
			}
			else
			{
				Main.expertMode = false;
			}
			if (num >= 141)
			{
				Main.ActiveWorldFileData.CreationTime = DateTime.FromBinary(reader.ReadInt64());
			}
			Main.moonType = reader.ReadByte();
			Main.treeX[0] = reader.ReadInt32();
			Main.treeX[1] = reader.ReadInt32();
			Main.treeX[2] = reader.ReadInt32();
			Main.treeStyle[0] = reader.ReadInt32();
			Main.treeStyle[1] = reader.ReadInt32();
			Main.treeStyle[2] = reader.ReadInt32();
			Main.treeStyle[3] = reader.ReadInt32();
			Main.caveBackX[0] = reader.ReadInt32();
			Main.caveBackX[1] = reader.ReadInt32();
			Main.caveBackX[2] = reader.ReadInt32();
			Main.caveBackStyle[0] = reader.ReadInt32();
			Main.caveBackStyle[1] = reader.ReadInt32();
			Main.caveBackStyle[2] = reader.ReadInt32();
			Main.caveBackStyle[3] = reader.ReadInt32();
			Main.iceBackStyle = reader.ReadInt32();
			Main.jungleBackStyle = reader.ReadInt32();
			Main.hellBackStyle = reader.ReadInt32();
			Main.spawnTileX = reader.ReadInt32();
			Main.spawnTileY = reader.ReadInt32();
			Main.worldSurface = reader.ReadDouble();
			Main.rockLayer = reader.ReadDouble();
			tempTime = reader.ReadDouble();
			tempDayTime = reader.ReadBoolean();
			tempMoonPhase = reader.ReadInt32();
			tempBloodMoon = reader.ReadBoolean();
			tempEclipse = reader.ReadBoolean();
			Main.eclipse = tempEclipse;
			Main.dungeonX = reader.ReadInt32();
			Main.dungeonY = reader.ReadInt32();
			WorldGen.crimson = reader.ReadBoolean();
			NPC.downedBoss1 = reader.ReadBoolean();
			NPC.downedBoss2 = reader.ReadBoolean();
			NPC.downedBoss3 = reader.ReadBoolean();
			NPC.downedQueenBee = reader.ReadBoolean();
			NPC.downedMechBoss1 = reader.ReadBoolean();
			NPC.downedMechBoss2 = reader.ReadBoolean();
			NPC.downedMechBoss3 = reader.ReadBoolean();
			NPC.downedMechBossAny = reader.ReadBoolean();
			NPC.downedPlantBoss = reader.ReadBoolean();
			NPC.downedGolemBoss = reader.ReadBoolean();
			if (num >= 118)
			{
				NPC.downedSlimeKing = reader.ReadBoolean();
			}
			NPC.savedGoblin = reader.ReadBoolean();
			NPC.savedWizard = reader.ReadBoolean();
			NPC.savedMech = reader.ReadBoolean();
			NPC.downedGoblins = reader.ReadBoolean();
			NPC.downedClown = reader.ReadBoolean();
			NPC.downedFrost = reader.ReadBoolean();
			NPC.downedPirates = reader.ReadBoolean();
			WorldGen.shadowOrbSmashed = reader.ReadBoolean();
			WorldGen.spawnMeteor = reader.ReadBoolean();
			WorldGen.shadowOrbCount = reader.ReadByte();
			WorldGen.altarCount = reader.ReadInt32();
			Main.hardMode = reader.ReadBoolean();
			Main.invasionDelay = reader.ReadInt32();
			Main.invasionSize = reader.ReadInt32();
			Main.invasionType = reader.ReadInt32();
			Main.invasionX = reader.ReadDouble();
			if (num >= 118)
			{
				Main.slimeRainTime = reader.ReadDouble();
			}
			if (num >= 113)
			{
				Main.sundialCooldown = reader.ReadByte();
			}
			tempRaining = reader.ReadBoolean();
			tempRainTime = reader.ReadInt32();
			tempMaxRain = reader.ReadSingle();
			WorldGen.oreTier1 = reader.ReadInt32();
			WorldGen.oreTier2 = reader.ReadInt32();
			WorldGen.oreTier3 = reader.ReadInt32();
			WorldGen.setBG(0, reader.ReadByte());
			WorldGen.setBG(1, reader.ReadByte());
			WorldGen.setBG(2, reader.ReadByte());
			WorldGen.setBG(3, reader.ReadByte());
			WorldGen.setBG(4, reader.ReadByte());
			WorldGen.setBG(5, reader.ReadByte());
			WorldGen.setBG(6, reader.ReadByte());
			WorldGen.setBG(7, reader.ReadByte());
			Main.cloudBGActive = reader.ReadInt32();
			Main.cloudBGAlpha = (((double)Main.cloudBGActive < 1.0) ? 0f : 1f);
			Main.cloudBGActive = -WorldGen.genRand.Next(8640, 86400);
			Main.numClouds = reader.ReadInt16();
			Main.windSpeedSet = reader.ReadSingle();
			Main.windSpeed = Main.windSpeedSet;
			if (num < 95)
			{
				return;
			}
			Main.anglerWhoFinishedToday.Clear();
			for (int num2 = reader.ReadInt32(); num2 > 0; num2--)
			{
				Main.anglerWhoFinishedToday.Add(reader.ReadString());
			}
			if (num < 99)
			{
				return;
			}
			NPC.savedAngler = reader.ReadBoolean();
			if (num < 101)
			{
				return;
			}
			Main.anglerQuest = reader.ReadInt32();
			if (num < 104)
			{
				return;
			}
			NPC.savedStylist = reader.ReadBoolean();
			if (num >= 129)
			{
				NPC.savedTaxCollector = reader.ReadBoolean();
			}
			if (num < 107)
			{
				if (Main.invasionType > 0 && Main.invasionSize > 0)
				{
					Main.FakeLoadInvasionStart();
				}
			}
			else
			{
				Main.invasionSizeStart = reader.ReadInt32();
			}
			if (num < 108)
			{
				tempCultistDelay = 86400;
			}
			else
			{
				tempCultistDelay = reader.ReadInt32();
			}
			if (num < 109)
			{
				return;
			}
			int num3 = reader.ReadInt16();
			for (int i = 0; i < num3; i++)
			{
				if (i < 580)
				{
					NPC.killCount[i] = reader.ReadInt32();
				}
				else
				{
					reader.ReadInt32();
				}
			}
			if (num < 128)
			{
				return;
			}
			Main.fastForwardTime = reader.ReadBoolean();
			Main.UpdateSundial();
			if (num < 131)
			{
				return;
			}
			NPC.downedFishron = reader.ReadBoolean();
			NPC.downedMartians = reader.ReadBoolean();
			NPC.downedAncientCultist = reader.ReadBoolean();
			NPC.downedMoonlord = reader.ReadBoolean();
			NPC.downedHalloweenKing = reader.ReadBoolean();
			NPC.downedHalloweenTree = reader.ReadBoolean();
			NPC.downedChristmasIceQueen = reader.ReadBoolean();
			NPC.downedChristmasSantank = reader.ReadBoolean();
			NPC.downedChristmasTree = reader.ReadBoolean();
			if (num < 140)
			{
				return;
			}
			NPC.downedTowerSolar = reader.ReadBoolean();
			NPC.downedTowerVortex = reader.ReadBoolean();
			NPC.downedTowerNebula = reader.ReadBoolean();
			NPC.downedTowerStardust = reader.ReadBoolean();
			NPC.TowerActiveSolar = reader.ReadBoolean();
			NPC.TowerActiveVortex = reader.ReadBoolean();
			NPC.TowerActiveNebula = reader.ReadBoolean();
			NPC.TowerActiveStardust = reader.ReadBoolean();
			NPC.LunarApocalypseIsUp = reader.ReadBoolean();
			if (NPC.TowerActiveSolar)
			{
				NPC.ShieldStrengthTowerSolar = NPC.ShieldStrengthTowerMax;
			}
			if (NPC.TowerActiveVortex)
			{
				NPC.ShieldStrengthTowerVortex = NPC.ShieldStrengthTowerMax;
			}
			if (NPC.TowerActiveNebula)
			{
				NPC.ShieldStrengthTowerNebula = NPC.ShieldStrengthTowerMax;
			}
			if (NPC.TowerActiveStardust)
			{
				NPC.ShieldStrengthTowerStardust = NPC.ShieldStrengthTowerMax;
			}
			if (num < 170)
			{
				tempPartyManual = false;
				tempPartyGenuine = false;
				tempPartyCooldown = 0;
				tempPartyCelebratingNPCs.Clear();
			}
			else
			{
				tempPartyManual = reader.ReadBoolean();
				tempPartyGenuine = reader.ReadBoolean();
				tempPartyCooldown = reader.ReadInt32();
				int num4 = reader.ReadInt32();
				tempPartyCelebratingNPCs.Clear();
				for (int j = 0; j < num4; j++)
				{
					tempPartyCelebratingNPCs.Add(reader.ReadInt32());
				}
			}
			if (num < 174)
			{
				Temp_Sandstorm_Happening = false;
				Temp_Sandstorm_TimeLeft = 0;
				Temp_Sandstorm_Severity = 0f;
				Temp_Sandstorm_IntendedSeverity = 0f;
			}
			else
			{
				Temp_Sandstorm_Happening = reader.ReadBoolean();
				Temp_Sandstorm_TimeLeft = reader.ReadInt32();
				Temp_Sandstorm_Severity = reader.ReadSingle();
				Temp_Sandstorm_IntendedSeverity = reader.ReadSingle();
			}
			DD2Event.Load(reader, num);
		}

		private static void LoadWorldTiles(BinaryReader reader, bool[] importance)
		{
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				float num = (float)i / (float)Main.maxTilesX;
				Main.statusText = Lang.gen[51].Value + " " + (int)((double)num * 100.0 + 1.0) + "%";
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					int num2 = -1;
					byte b2;
					byte b = (b2 = 0);
					Tile tile = Main.tile[i, j];
					byte b3 = reader.ReadByte();
					if ((b3 & 1) == 1)
					{
						b = reader.ReadByte();
						if ((b & 1) == 1)
						{
							b2 = reader.ReadByte();
						}
					}
					byte b4;
					if ((b3 & 2) == 2)
					{
						tile.active(active: true);
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
						if (importance[num2])
						{
							tile.frameX = reader.ReadInt16();
							tile.frameY = reader.ReadInt16();
							if (tile.type == 144)
							{
								tile.frameY = 0;
							}
						}
						else
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
					int num3;
					switch ((byte)((b3 & 0xC0) >> 6))
					{
					case 0:
						num3 = 0;
						break;
					case 1:
						num3 = reader.ReadByte();
						break;
					default:
						num3 = reader.ReadInt16();
						break;
					}
					if (num2 != -1)
					{
						if ((double)j <= Main.worldSurface)
						{
							if ((double)(j + num3) <= Main.worldSurface)
							{
								WorldGen.tileCounts[num2] += (num3 + 1) * 5;
							}
							else
							{
								int num4 = (int)(Main.worldSurface - (double)j + 1.0);
								int num5 = num3 + 1 - num4;
								WorldGen.tileCounts[num2] += num4 * 5 + num5;
							}
						}
						else
						{
							WorldGen.tileCounts[num2] += num3 + 1;
						}
					}
					while (num3 > 0)
					{
						j++;
						Main.tile[i, j].CopyFrom(tile);
						num3--;
					}
				}
			}
			WorldGen.AddUpAlignmentCounts(clearCounts: true);
			if (versionNumber < 105)
			{
				WorldGen.FixHearts();
			}
		}

		private static void LoadChests(BinaryReader reader)
		{
			Chest chest = null;
			int num = reader.ReadInt16();
			int num2 = reader.ReadInt16();
			int num3;
			int num4;
			if (num2 < 40)
			{
				num3 = num2;
				num4 = 0;
			}
			else
			{
				num3 = 40;
				num4 = num2 - 40;
			}
			int i;
			for (i = 0; i < num; i++)
			{
				chest = new Chest();
				chest.x = reader.ReadInt32();
				chest.y = reader.ReadInt32();
				chest.name = reader.ReadString();
				for (int j = 0; j < num3; j++)
				{
					short num5 = reader.ReadInt16();
					Item item = new Item();
					if (num5 > 0)
					{
						item.netDefaults(reader.ReadInt32());
						item.stack = num5;
						item.Prefix(reader.ReadByte());
					}
					else if (num5 < 0)
					{
						item.netDefaults(reader.ReadInt32());
						item.Prefix(reader.ReadByte());
						item.stack = 1;
					}
					chest.item[j] = item;
				}
				for (int j = 0; j < num4; j++)
				{
					short num5 = reader.ReadInt16();
					if (num5 > 0)
					{
						reader.ReadInt32();
						reader.ReadByte();
					}
				}
				Main.chest[i] = chest;
			}
			List<Point16> list = new List<Point16>();
			for (int k = 0; k < i; k++)
			{
				if (Main.chest[k] != null)
				{
					Point16 item2 = new Point16(Main.chest[k].x, Main.chest[k].y);
					if (list.Contains(item2))
					{
						Main.chest[k] = null;
					}
					else
					{
						list.Add(item2);
					}
				}
			}
			for (; i < 1000; i++)
			{
				Main.chest[i] = null;
			}
			if (versionNumber < 115)
			{
				FixDresserChests();
			}
		}

		private static void LoadSigns(BinaryReader reader)
		{
			short num = reader.ReadInt16();
			int i;
			for (i = 0; i < num; i++)
			{
				string text = reader.ReadString();
				int num2 = reader.ReadInt32();
				int num3 = reader.ReadInt32();
				Tile tile = Main.tile[num2, num3];
				Sign sign;
				if (tile.active() && Main.tileSign[tile.type])
				{
					sign = new Sign();
					sign.text = text;
					sign.x = num2;
					sign.y = num3;
				}
				else
				{
					sign = null;
				}
				Main.sign[i] = sign;
			}
			List<Point16> list = new List<Point16>();
			for (int j = 0; j < 1000; j++)
			{
				if (Main.sign[j] != null)
				{
					Point16 item = new Point16(Main.sign[j].x, Main.sign[j].y);
					if (list.Contains(item))
					{
						Main.sign[j] = null;
					}
					else
					{
						list.Add(item);
					}
				}
			}
			for (; i < 1000; i++)
			{
				Main.sign[i] = null;
			}
		}

		private static void LoadDummies(BinaryReader reader)
		{
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				DeprecatedClassLeftInForLoading.dummies[i] = new DeprecatedClassLeftInForLoading(reader.ReadInt16(), reader.ReadInt16());
			}
			for (int j = num; j < 1000; j++)
			{
				DeprecatedClassLeftInForLoading.dummies[j] = null;
			}
		}

		private static void LoadNPCs(BinaryReader reader)
		{
			int num = 0;
			bool flag = reader.ReadBoolean();
			while (flag)
			{
				NPC nPC = Main.npc[num];
				if (versionNumber >= 190)
				{
					nPC.SetDefaults(reader.ReadInt32());
				}
				else
				{
					nPC.SetDefaults(NPCID.FromLegacyName(reader.ReadString()));
				}
				nPC.GivenName = reader.ReadString();
				nPC.position.X = reader.ReadSingle();
				nPC.position.Y = reader.ReadSingle();
				nPC.homeless = reader.ReadBoolean();
				nPC.homeTileX = reader.ReadInt32();
				nPC.homeTileY = reader.ReadInt32();
				num++;
				flag = reader.ReadBoolean();
			}
			if (versionNumber < 140)
			{
				return;
			}
			flag = reader.ReadBoolean();
			while (flag)
			{
				NPC nPC = Main.npc[num];
				if (versionNumber >= 190)
				{
					nPC.SetDefaults(reader.ReadInt32());
				}
				else
				{
					nPC.SetDefaults(NPCID.FromLegacyName(reader.ReadString()));
				}
				nPC.position = reader.ReadVector2();
				num++;
				flag = reader.ReadBoolean();
			}
		}

		private static int LoadFooter(BinaryReader reader)
		{
			if (!reader.ReadBoolean())
			{
				return 6;
			}
			if (reader.ReadString() != Main.worldName)
			{
				return 6;
			}
			if (reader.ReadInt32() != Main.worldID)
			{
				return 6;
			}
			return 0;
		}

		public static bool validateWorld(BinaryReader fileIO)
		{
			new Stopwatch().Start();
			try
			{
				Stream baseStream = fileIO.BaseStream;
				int num = fileIO.ReadInt32();
				if (num == 0 || num > 194)
				{
					return false;
				}
				baseStream.Position = 0L;
				if (!LoadFileFormatHeader(fileIO, out var importance, out var positions))
				{
					return false;
				}
				string text = fileIO.ReadString();
				if (num >= 179)
				{
					if (num == 179)
					{
						fileIO.ReadInt32();
					}
					else
					{
						fileIO.ReadString();
					}
					fileIO.ReadUInt64();
				}
				if (num >= 181)
				{
					fileIO.ReadBytes(16);
				}
				int num2 = fileIO.ReadInt32();
				fileIO.ReadInt32();
				fileIO.ReadInt32();
				fileIO.ReadInt32();
				fileIO.ReadInt32();
				int num3 = fileIO.ReadInt32();
				int num4 = fileIO.ReadInt32();
				baseStream.Position = positions[1];
				for (int i = 0; i < num4; i++)
				{
					float num5 = (float)i / (float)Main.maxTilesX;
					Main.statusText = Lang.gen[73].Value + " " + (int)(num5 * 100f + 1f) + "%";
					int num6;
					for (num6 = 0; num6 < num3; num6++)
					{
						byte b = 0;
						byte b2 = fileIO.ReadByte();
						if ((b2 & 1) == 1 && (fileIO.ReadByte() & 1) == 1)
						{
							b = fileIO.ReadByte();
						}
						if ((b2 & 2) == 2)
						{
							int num7;
							if ((b2 & 0x20) == 32)
							{
								byte b3 = fileIO.ReadByte();
								num7 = fileIO.ReadByte();
								num7 = (num7 << 8) | b3;
							}
							else
							{
								num7 = fileIO.ReadByte();
							}
							if (importance[num7])
							{
								fileIO.ReadInt16();
								fileIO.ReadInt16();
							}
							if ((b & 8) == 8)
							{
								fileIO.ReadByte();
							}
						}
						if ((b2 & 4) == 4)
						{
							fileIO.ReadByte();
							if ((b & 0x10) == 16)
							{
								fileIO.ReadByte();
							}
						}
						if ((b2 & 0x18) >> 3 != 0)
						{
							fileIO.ReadByte();
						}
						int num8;
						switch ((byte)((b2 & 0xC0) >> 6))
						{
						case 0:
							num8 = 0;
							break;
						case 1:
							num8 = fileIO.ReadByte();
							break;
						default:
							num8 = fileIO.ReadInt16();
							break;
						}
						num6 += num8;
					}
				}
				if (baseStream.Position != positions[2])
				{
					return false;
				}
				int num9 = fileIO.ReadInt16();
				int num10 = fileIO.ReadInt16();
				for (int j = 0; j < num9; j++)
				{
					fileIO.ReadInt32();
					fileIO.ReadInt32();
					fileIO.ReadString();
					for (int k = 0; k < num10; k++)
					{
						if (fileIO.ReadInt16() > 0)
						{
							fileIO.ReadInt32();
							fileIO.ReadByte();
						}
					}
				}
				if (baseStream.Position != positions[3])
				{
					return false;
				}
				int num11 = fileIO.ReadInt16();
				for (int l = 0; l < num11; l++)
				{
					fileIO.ReadString();
					fileIO.ReadInt32();
					fileIO.ReadInt32();
				}
				if (baseStream.Position != positions[4])
				{
					return false;
				}
				bool flag = fileIO.ReadBoolean();
				while (flag)
				{
					fileIO.ReadInt32();
					fileIO.ReadString();
					fileIO.ReadSingle();
					fileIO.ReadSingle();
					fileIO.ReadBoolean();
					fileIO.ReadInt32();
					fileIO.ReadInt32();
					flag = fileIO.ReadBoolean();
				}
				flag = fileIO.ReadBoolean();
				while (flag)
				{
					fileIO.ReadInt32();
					fileIO.ReadSingle();
					fileIO.ReadSingle();
					flag = fileIO.ReadBoolean();
				}
				if (baseStream.Position != positions[5])
				{
					return false;
				}
				if (versionNumber >= 116 && versionNumber <= 121)
				{
					int num12 = fileIO.ReadInt32();
					for (int m = 0; m < num12; m++)
					{
						fileIO.ReadInt16();
						fileIO.ReadInt16();
					}
					if (baseStream.Position != positions[6])
					{
						return false;
					}
				}
				if (versionNumber >= 122)
				{
					int num13 = fileIO.ReadInt32();
					for (int n = 0; n < num13; n++)
					{
						TileEntity.Read(fileIO);
					}
				}
				if (versionNumber >= 170)
				{
					int num14 = fileIO.ReadInt32();
					for (int num15 = 0; num15 < num14; num15++)
					{
						fileIO.ReadInt64();
					}
				}
				if (versionNumber >= 189)
				{
					int num16 = fileIO.ReadInt32();
					fileIO.ReadBytes(12 * num16);
				}
				bool num17 = fileIO.ReadBoolean();
				string text2 = fileIO.ReadString();
				int num18 = fileIO.ReadInt32();
				bool result = false;
				if (num17 && (text2 == text || num18 == num2))
				{
					result = true;
				}
				return result;
			}
			catch (Exception value)
			{
				using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", append: true))
				{
					streamWriter.WriteLine(DateTime.Now);
					streamWriter.WriteLine(value);
					streamWriter.WriteLine("");
				}
				return false;
			}
		}

		public static string GetWorldName(string WorldFileName)
		{
			if (WorldFileName == null)
			{
				return string.Empty;
			}
			try
			{
				using (FileStream fileStream = new FileStream(WorldFileName, FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(fileStream))
					{
						switch (binaryReader.ReadInt32())
						{
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
						case 9:
						case 10:
						case 11:
						case 12:
						case 13:
						case 14:
						case 15:
						case 16:
						case 17:
						case 18:
						case 19:
						case 20:
						case 21:
						case 22:
						case 23:
						case 24:
						case 25:
						case 26:
						case 27:
						case 28:
						case 29:
						case 30:
						case 31:
						case 32:
						case 33:
						case 34:
						case 35:
						case 36:
						case 37:
						case 38:
						case 39:
						case 40:
						case 41:
						case 42:
						case 43:
						case 44:
						case 45:
						case 46:
						case 47:
						case 48:
						case 49:
						case 50:
						case 51:
						case 52:
						case 53:
						case 54:
						case 55:
						case 56:
						case 57:
						case 58:
						case 59:
						case 60:
						case 61:
						case 62:
						case 63:
						case 64:
						case 65:
						case 66:
						case 67:
						case 68:
						case 69:
						case 70:
						case 71:
						case 72:
						case 73:
						case 74:
						case 75:
						case 76:
						case 77:
						case 78:
						case 79:
						case 80:
						case 81:
						case 82:
						case 83:
						case 84:
						case 85:
						case 86:
						case 87:
						{
							string result = binaryReader.ReadString();
							binaryReader.Close();
							return result;
						}
						case 135:
						case 136:
						case 137:
						case 138:
						case 139:
						case 140:
						case 141:
						case 142:
						case 143:
						case 144:
						case 145:
						case 146:
						case 147:
						case 148:
						case 149:
						case 150:
						case 151:
						case 152:
						case 153:
						case 154:
						case 155:
						case 156:
						case 157:
						case 158:
						case 159:
						case 160:
						case 161:
						case 162:
						case 163:
						case 164:
						case 165:
						case 166:
						case 167:
						case 168:
						case 169:
						case 170:
						case 171:
						case 172:
						case 173:
						case 174:
						case 175:
						case 176:
						case 177:
						case 178:
						case 179:
						case 180:
						case 181:
						case 182:
						case 183:
						case 184:
						case 185:
						case 186:
						case 187:
						case 188:
						case 189:
						case 190:
						case 191:
						case 192:
						case 193:
						case 194:
							binaryReader.BaseStream.Position += 20L;
							break;
						case 88:
						case 89:
						case 90:
						case 91:
						case 92:
						case 93:
						case 94:
						case 95:
						case 96:
						case 97:
						case 98:
						case 99:
						case 100:
						case 101:
						case 102:
						case 103:
						case 104:
						case 105:
						case 106:
						case 107:
						case 108:
						case 109:
						case 110:
						case 111:
						case 112:
						case 113:
						case 114:
						case 115:
						case 116:
						case 117:
						case 118:
						case 119:
						case 120:
						case 121:
						case 122:
						case 123:
						case 124:
						case 125:
						case 126:
						case 127:
						case 128:
						case 129:
						case 130:
						case 131:
						case 132:
						case 133:
						case 134:
							break;
						default:
							goto end_IL_0019;
						}
						binaryReader.ReadInt16();
						fileStream.Position = binaryReader.ReadInt32();
						string result2 = binaryReader.ReadString();
						binaryReader.Close();
						return result2;
						end_IL_0019:;
					}
				}
			}
			catch
			{
			}
			string[] array = WorldFileName.Split(Path.DirectorySeparatorChar);
			string text = array[array.Length - 1];
			return text.Substring(0, text.Length - 4);
		}

		public static bool GetWorldDifficulty(string WorldFileName)
		{
			if (WorldFileName == null)
			{
				return false;
			}
			try
			{
				using (FileStream fileStream = new FileStream(WorldFileName, FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(fileStream))
					{
						int num = binaryReader.ReadInt32();
						if (num >= 135)
						{
							binaryReader.BaseStream.Position += 20L;
						}
						if (num >= 112 && num <= 194)
						{
							binaryReader.ReadInt16();
							fileStream.Position = binaryReader.ReadInt32();
							binaryReader.ReadString();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							return binaryReader.ReadBoolean();
						}
					}
				}
			}
			catch
			{
			}
			return false;
		}

		public static bool IsValidWorld(string file, bool cloudSave)
		{
			return GetFileMetadata(file, cloudSave) != null;
		}

		public static WorldFileData GetAllMetadata(string file, bool cloudSave)
		{
			if (file == null || (cloudSave && SocialAPI.Cloud == null))
			{
				return null;
			}
			WorldFileData worldFileData = new WorldFileData(file, cloudSave);
			if (!FileUtilities.Exists(file, cloudSave))
			{
				worldFileData.CreationTime = DateTime.Now;
				worldFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
				return worldFileData;
			}
			try
			{
				using (Stream stream = (cloudSave ? ((Stream)new MemoryStream(SocialAPI.Cloud.Read(file))) : ((Stream)new FileStream(file, FileMode.Open))))
				{
					using (BinaryReader binaryReader = new BinaryReader(stream))
					{
						int num = binaryReader.ReadInt32();
						if (num >= 135)
						{
							worldFileData.Metadata = FileMetadata.Read(binaryReader, FileType.World);
						}
						else
						{
							worldFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
						}
						if (num <= 194)
						{
							binaryReader.ReadInt16();
							stream.Position = binaryReader.ReadInt32();
							worldFileData.Name = binaryReader.ReadString();
							if (num >= 179)
							{
								string seed = ((num != 179) ? binaryReader.ReadString() : binaryReader.ReadInt32().ToString());
								worldFileData.SetSeed(seed);
								worldFileData.WorldGeneratorVersion = binaryReader.ReadUInt64();
							}
							else
							{
								worldFileData.SetSeedToEmpty();
								worldFileData.WorldGeneratorVersion = 0uL;
							}
							if (num >= 181)
							{
								worldFileData.UniqueId = new Guid(binaryReader.ReadBytes(16));
							}
							else
							{
								worldFileData.UniqueId = Guid.Empty;
							}
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							int y = binaryReader.ReadInt32();
							int x = binaryReader.ReadInt32();
							worldFileData.SetWorldSize(x, y);
							worldFileData.IsExpertMode = num >= 112 && binaryReader.ReadBoolean();
							if (num >= 141)
							{
								worldFileData.CreationTime = DateTime.FromBinary(binaryReader.ReadInt64());
							}
							else if (!cloudSave)
							{
								worldFileData.CreationTime = File.GetCreationTime(file);
							}
							else
							{
								worldFileData.CreationTime = DateTime.Now;
							}
							binaryReader.ReadByte();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadDouble();
							binaryReader.ReadDouble();
							binaryReader.ReadDouble();
							binaryReader.ReadBoolean();
							binaryReader.ReadInt32();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							worldFileData.HasCrimson = binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							if (num >= 118)
							{
								binaryReader.ReadBoolean();
							}
							else
								_ = 0;
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadByte();
							binaryReader.ReadInt32();
							worldFileData.IsHardMode = binaryReader.ReadBoolean();
							return worldFileData;
						}
					}
				}
			}
			catch (Exception)
			{
			}
			return null;
		}

		public static WorldFileData CreateMetadata(string name, bool cloudSave, bool isExpertMode)
		{
			WorldFileData worldFileData = new WorldFileData(Main.GetWorldPathFromName(name, cloudSave), cloudSave);
			worldFileData.Name = name;
			worldFileData.IsExpertMode = isExpertMode;
			worldFileData.CreationTime = DateTime.Now;
			worldFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
			worldFileData.SetFavorite(favorite: false);
			worldFileData.WorldGeneratorVersion = 833223655425uL;
			worldFileData.UniqueId = Guid.NewGuid();
			if (Main.DefaultSeed == "")
			{
				worldFileData.SetSeedToRandom();
			}
			else
			{
				worldFileData.SetSeed(Main.DefaultSeed);
			}
			return worldFileData;
		}

		public static FileMetadata GetFileMetadata(string file, bool cloudSave)
		{
			if (file == null)
			{
				return null;
			}
			try
			{
				byte[] buffer = null;
				int num;
				if (cloudSave)
				{
					num = ((SocialAPI.Cloud != null) ? 1 : 0);
					if (num != 0)
					{
						int num2 = 24;
						buffer = new byte[num2];
						SocialAPI.Cloud.Read(file, buffer, num2);
					}
				}
				else
				{
					num = 0;
				}
				using (Stream input = ((num != 0) ? ((Stream)new MemoryStream(buffer)) : ((Stream)new FileStream(file, FileMode.Open))))
				{
					using (BinaryReader binaryReader = new BinaryReader(input))
					{
						if (binaryReader.ReadInt32() >= 135)
						{
							return FileMetadata.Read(binaryReader, FileType.World);
						}
						return FileMetadata.FromCurrentSettings(FileType.World);
					}
				}
			}
			catch
			{
			}
			return null;
		}

		public static void ResetTemps()
		{
			tempRaining = false;
			tempMaxRain = 0f;
			tempRainTime = 0;
			tempDayTime = true;
			tempBloodMoon = false;
			tempEclipse = false;
			tempMoonPhase = 0;
			Main.anglerWhoFinishedToday.Clear();
			Main.anglerQuestFinished = false;
		}

		public static void FixDresserChests()
		{
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					Tile tile = Main.tile[i, j];
					if (tile.active() && tile.type == 88 && tile.frameX % 54 == 0 && tile.frameY % 36 == 0)
					{
						Chest.CreateChest(i, j);
					}
				}
			}
		}

		private static int SaveTileEntities(BinaryWriter writer)
		{
			writer.Write(TileEntity.ByID.Count);
			foreach (KeyValuePair<int, TileEntity> item in TileEntity.ByID)
			{
				TileEntity.Write(writer, item.Value);
			}
			return (int)writer.BaseStream.Position;
		}

		private static void LoadTileEntities(BinaryReader reader)
		{
			TileEntity.ByID.Clear();
			TileEntity.ByPosition.Clear();
			int num = reader.ReadInt32();
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				TileEntity tileEntity = TileEntity.Read(reader);
				tileEntity.ID = num2++;
				TileEntity.ByID[tileEntity.ID] = tileEntity;
				if (TileEntity.ByPosition.TryGetValue(tileEntity.Position, out var value))
				{
					TileEntity.ByID.Remove(value.ID);
				}
				TileEntity.ByPosition[tileEntity.Position] = tileEntity;
			}
			TileEntity.TileEntitiesNextID = num;
			List<Point16> list = new List<Point16>();
			foreach (KeyValuePair<Point16, TileEntity> item in TileEntity.ByPosition)
			{
				if (!WorldGen.InWorld(item.Value.Position.X, item.Value.Position.Y, 1))
				{
					list.Add(item.Value.Position);
					continue;
				}
				if (item.Value.type == 0 && !TETrainingDummy.ValidTile(item.Value.Position.X, item.Value.Position.Y))
				{
					list.Add(item.Value.Position);
				}
				if (item.Value.type == 2 && !TELogicSensor.ValidTile(item.Value.Position.X, item.Value.Position.Y))
				{
					list.Add(item.Value.Position);
				}
				if (item.Value.type == 1 && !TEItemFrame.ValidTile(item.Value.Position.X, item.Value.Position.Y))
				{
					list.Add(item.Value.Position);
				}
			}
			try
			{
				foreach (Point16 item2 in list)
				{
					TileEntity tileEntity2 = TileEntity.ByPosition[item2];
					if (TileEntity.ByID.ContainsKey(tileEntity2.ID))
					{
						TileEntity.ByID.Remove(tileEntity2.ID);
					}
					if (TileEntity.ByPosition.ContainsKey(item2))
					{
						TileEntity.ByPosition.Remove(item2);
					}
				}
			}
			catch
			{
			}
		}

		private static int SaveWeightedPressurePlates(BinaryWriter writer)
		{
			writer.Write(PressurePlateHelper.PressurePlatesPressed.Count);
			foreach (KeyValuePair<Point, bool[]> item in PressurePlateHelper.PressurePlatesPressed)
			{
				writer.Write(item.Key.X);
				writer.Write(item.Key.Y);
			}
			return (int)writer.BaseStream.Position;
		}

		private static void LoadWeightedPressurePlates(BinaryReader reader)
		{
			PressurePlateHelper.Reset();
			PressurePlateHelper.NeedsFirstUpdate = true;
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				Point key = new Point(reader.ReadInt32(), reader.ReadInt32());
				PressurePlateHelper.PressurePlatesPressed.Add(key, new bool[255]);
			}
		}

		private static int SaveTownManager(BinaryWriter writer)
		{
			WorldGen.TownManager.Save(writer);
			return (int)writer.BaseStream.Position;
		}

		private static void LoadTownManager(BinaryReader reader)
		{
			WorldGen.TownManager.Load(reader);
		}
	}
}
