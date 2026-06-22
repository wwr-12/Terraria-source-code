using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Terraria
{
	public class Lighting
	{
		private class LightingSwipeData
		{
			public int outerLoopStart;

			public int outerLoopEnd;

			public int innerLoop1Start;

			public int innerLoop1End;

			public int innerLoop2Start;

			public int innerLoop2End;

			public Random rand;

			public Action<LightingSwipeData> function;

			public LightingState[][] jaggedArray;

			public LightingSwipeData()
			{
				innerLoop1Start = 0;
				outerLoopStart = 0;
				innerLoop1End = 0;
				outerLoopEnd = 0;
				innerLoop2Start = 0;
				innerLoop2End = 0;
				function = null;
				rand = new Random();
			}

			public void CopyFrom(LightingSwipeData from)
			{
				innerLoop1Start = from.innerLoop1Start;
				outerLoopStart = from.outerLoopStart;
				innerLoop1End = from.innerLoop1End;
				outerLoopEnd = from.outerLoopEnd;
				innerLoop2Start = from.innerLoop2Start;
				innerLoop2End = from.innerLoop2End;
				function = from.function;
				jaggedArray = from.jaggedArray;
			}
		}

		private class LightingState
		{
			public float r;

			public float r2;

			public float g;

			public float g2;

			public float b;

			public float b2;

			public bool stopLight;

			public bool wetLight;

			public bool honeyLight;
		}

		private struct ColorTriplet
		{
			public float r;

			public float g;

			public float b;

			public ColorTriplet(float R, float G, float B)
			{
				r = R;
				g = G;
				b = B;
			}

			public ColorTriplet(float averageColor)
			{
				r = (g = (b = averageColor));
			}
		}

		public static int maxRenderCount = 4;

		public static float brightness = 1f;

		public static float defBrightness = 1f;

		public static int lightMode = 0;

		public static bool RGB = true;

		private static float oldSkyColor = 0f;

		private static float skyColor = 0f;

		private static int lightCounter = 0;

		public static int offScreenTiles = 45;

		public static int offScreenTiles2 = 35;

		private static int firstTileX;

		private static int lastTileX;

		private static int firstTileY;

		private static int lastTileY;

		public static int LightingThreads = 0;

		private static LightingState[][] states;

		private static LightingState[][] axisFlipStates;

		private static LightingSwipeData swipe;

		private static LightingSwipeData[] threadSwipes;

		private static CountdownEvent countdown;

		public static int scrX;

		public static int scrY;

		public static int minX;

		public static int maxX;

		public static int minY;

		public static int maxY;

		private static int maxTempLights = 2000;

		private static Dictionary<Point16, ColorTriplet> tempLights;

		private static int firstToLightX;

		private static int firstToLightY;

		private static int lastToLightX;

		private static int lastToLightY;

		private static float negLight = 0.04f;

		private static float negLight2 = 0.16f;

		private static float wetLightR = 0.16f;

		private static float wetLightG = 0.16f;

		private static float wetLightB = 0.16f;

		private static float honeyLightR = 0.16f;

		private static float honeyLightG = 0.16f;

		private static float honeyLightB = 0.16f;

		private static float blueWave = 1f;

		private static int blueDir = 1;

		private static int minX7;

		private static int maxX7;

		private static int minY7;

		private static int maxY7;

		private static int firstTileX7;

		private static int lastTileX7;

		private static int lastTileY7;

		private static int firstTileY7;

		private static int firstToLightX7;

		private static int lastToLightX7;

		private static int firstToLightY7;

		private static int lastToLightY7;

		private static int firstToLightX27;

		private static int lastToLightX27;

		private static int firstToLightY27;

		private static int lastToLightY27;

		public static void Initialize(bool resize = false)
		{
			if (!resize)
			{
				tempLights = new Dictionary<Point16, ColorTriplet>();
				swipe = new LightingSwipeData();
				countdown = new CountdownEvent(0);
				threadSwipes = new LightingSwipeData[Environment.ProcessorCount];
				for (int i = 0; i < threadSwipes.Length; i++)
				{
					threadSwipes[i] = new LightingSwipeData();
				}
			}
			int num = Main.screenWidth / 16 + offScreenTiles * 2 + 10;
			int num2 = Main.screenHeight / 16 + offScreenTiles * 2 + 10;
			if (states != null && states.Length >= num && states[0].Length >= num2)
			{
				return;
			}
			states = new LightingState[num][];
			axisFlipStates = new LightingState[num2][];
			for (int j = 0; j < num2; j++)
			{
				axisFlipStates[j] = new LightingState[num];
			}
			for (int k = 0; k < num; k++)
			{
				LightingState[] array = new LightingState[num2];
				for (int l = 0; l < num2; l++)
				{
					LightingState lightingState = (array[l] = new LightingState());
					axisFlipStates[l][k] = lightingState;
				}
				states[k] = array;
			}
		}

		public static void LightTiles(int firstX, int lastX, int firstY, int lastY)
		{
			Main.render = true;
			oldSkyColor = skyColor;
			float num = (float)(int)Main.tileColor.R / 255f;
			float num2 = (float)(int)Main.tileColor.G / 255f;
			float num3 = (float)(int)Main.tileColor.B / 255f;
			skyColor = (num + num2 + num3) / 3f;
			if (lightMode < 2)
			{
				brightness = 1.2f;
				offScreenTiles2 = 34;
				offScreenTiles = 40;
			}
			else
			{
				brightness = 1f;
				offScreenTiles2 = 18;
				offScreenTiles = 23;
			}
			if (Main.player[Main.myPlayer].blind)
			{
				brightness = 1f;
			}
			defBrightness = brightness;
			firstTileX = firstX;
			lastTileX = lastX;
			firstTileY = firstY;
			lastTileY = lastY;
			firstToLightX = firstTileX - offScreenTiles;
			firstToLightY = firstTileY - offScreenTiles;
			lastToLightX = lastTileX + offScreenTiles;
			lastToLightY = lastTileY + offScreenTiles;
			if (firstToLightX < 0)
			{
				firstToLightX = 0;
			}
			if (lastToLightX >= Main.maxTilesX)
			{
				lastToLightX = Main.maxTilesX - 1;
			}
			if (firstToLightY < 0)
			{
				firstToLightY = 0;
			}
			if (lastToLightY >= Main.maxTilesY)
			{
				lastToLightY = Main.maxTilesY - 1;
			}
			lightCounter++;
			Main.renderCount++;
			int num4 = Main.screenWidth / 16 + offScreenTiles * 2;
			int num5 = Main.screenHeight / 16 + offScreenTiles * 2;
			Vector2 screenLastPosition = Main.screenLastPosition;
			if (Main.renderCount < 3)
			{
				doColors();
			}
			if (Main.renderCount == 2)
			{
				screenLastPosition = Main.screenPosition;
				int num6 = (int)(Main.screenPosition.X / 16f) - scrX;
				int num7 = (int)(Main.screenPosition.Y / 16f) - scrY;
				if (num6 > 16)
				{
					num6 = 0;
				}
				if (num7 > 16)
				{
					num7 = 0;
				}
				int num8 = 0;
				int num9 = num4;
				int num10 = 0;
				int num11 = num5;
				if (num6 < 0)
				{
					num8 -= num6;
				}
				else
				{
					num9 -= num6;
				}
				if (num7 < 0)
				{
					num10 -= num7;
				}
				else
				{
					num11 -= num7;
				}
				if (RGB)
				{
					for (int i = num8; i < num4; i++)
					{
						LightingState[] array = states[i];
						LightingState[] array2 = states[i + num6];
						for (int j = num10; j < num11; j++)
						{
							LightingState lightingState = array[j];
							LightingState lightingState2 = array2[j + num7];
							lightingState.r = lightingState2.r2;
							lightingState.g = lightingState2.g2;
							lightingState.b = lightingState2.b2;
						}
					}
				}
				else
				{
					for (int k = num8; k < num9; k++)
					{
						LightingState[] array3 = states[k];
						LightingState[] array4 = states[k + num6];
						for (int l = num10; l < num11; l++)
						{
							LightingState lightingState3 = array3[l];
							LightingState lightingState4 = array4[l + num7];
							lightingState3.r = lightingState4.r2;
							lightingState3.g = lightingState4.r2;
							lightingState3.b = lightingState4.r2;
						}
					}
				}
			}
			else if (!Main.renderNow)
			{
				int num12 = (int)(Main.screenPosition.X / 16f) - (int)(screenLastPosition.X / 16f);
				if (num12 > 5 || num12 < -5)
				{
					num12 = 0;
				}
				int num13;
				int num14;
				int num15;
				if (num12 < 0)
				{
					num13 = -1;
					num12 *= -1;
					num14 = num4;
					num15 = num12;
				}
				else
				{
					num13 = 1;
					num14 = 0;
					num15 = num4 - num12;
				}
				int num16 = (int)(Main.screenPosition.Y / 16f) - (int)(screenLastPosition.Y / 16f);
				if (num16 > 5 || num16 < -5)
				{
					num16 = 0;
				}
				int num17;
				int num18;
				int num19;
				if (num16 < 0)
				{
					num17 = -1;
					num16 *= -1;
					num18 = num5;
					num19 = num16;
				}
				else
				{
					num17 = 1;
					num18 = 0;
					num19 = num5 - num16;
				}
				if (num12 != 0 || num16 != 0)
				{
					for (int m = num14; m != num15; m += num13)
					{
						LightingState[] array5 = states[m];
						LightingState[] array6 = states[m + num12 * num13];
						for (int n = num18; n != num19; n += num17)
						{
							LightingState lightingState5 = array5[n];
							LightingState lightingState6 = array6[n + num16 * num17];
							lightingState5.r = lightingState6.r;
							lightingState5.g = lightingState6.g;
							lightingState5.b = lightingState6.b;
						}
					}
				}
				if (Netplay.clientSock.statusMax > 0)
				{
					Main.mapTime = 1;
				}
				if (Main.mapTime == 0 && Main.mapEnabled && Main.renderCount == 3)
				{
					try
					{
						Main.mapTime = Main.mapTimeMax;
						Main.updateMap = true;
						Main.mapMinX = firstToLightX + offScreenTiles;
						Main.mapMaxX = lastToLightX - offScreenTiles;
						Main.mapMinY = firstToLightY + offScreenTiles;
						Main.mapMaxY = lastToLightY - offScreenTiles;
						for (int num20 = Main.mapMinX; num20 < Main.mapMaxX; num20++)
						{
							LightingState[] array7 = states[num20 - firstTileX + offScreenTiles];
							for (int num21 = Main.mapMinY; num21 < Main.mapMaxY; num21++)
							{
								LightingState lightingState7 = array7[num21 - firstTileY + offScreenTiles];
								Tile tile = Main.tile[num20, num21];
								Map map = Main.map[num20, num21];
								if (map == null)
								{
									map = new Map();
									Main.map[num20, num21] = map;
								}
								float num22 = 0f;
								if (lightingState7.r > num22)
								{
									num22 = lightingState7.r;
								}
								if (lightingState7.g > num22)
								{
									num22 = lightingState7.g;
								}
								if (lightingState7.b > num22)
								{
									num22 = lightingState7.b;
								}
								if (lightMode < 2)
								{
									num22 *= 1.5f;
								}
								num22 *= 255f;
								if (num22 > 255f)
								{
									num22 = 255f;
								}
								if ((double)num21 < Main.worldSurface && !tile.active() && tile.wall == 0 && tile.liquid == 0)
								{
									num22 = 22f;
								}
								if (num22 > 18f || map.light > 0)
								{
									if (num22 < 22f)
									{
										num22 = 22f;
									}
									map.setTile(num20, num21, (byte)num22);
								}
							}
						}
					}
					catch
					{
					}
				}
				if (oldSkyColor != skyColor)
				{
					int num23 = firstToLightX;
					int num24 = firstToLightY;
					int num25 = lastToLightX;
					int num26 = ((!((double)lastToLightY >= Main.worldSurface)) ? lastToLightY : ((int)Main.worldSurface - 1));
					if ((double)num24 < Main.worldSurface)
					{
						for (int num27 = num23; num27 < num25; num27++)
						{
							LightingState[] array8 = states[num27 - firstToLightX];
							for (int num28 = num24; num28 < num26; num28++)
							{
								LightingState lightingState8 = array8[num28 - firstToLightY];
								Tile tile2 = Main.tile[num27, num28];
								if (tile2 == null)
								{
									tile2 = new Tile();
									Main.tile[num27, num28] = tile2;
								}
								if ((!tile2.active() || !Main.tileNoSunLight[tile2.type]) && lightingState8.r < skyColor && tile2.liquid < 200 && (Main.wallLight[tile2.wall] || tile2.wall == 73))
								{
									lightingState8.r = num;
									if (lightingState8.g < skyColor)
									{
										lightingState8.g = num2;
									}
									if (lightingState8.b < skyColor)
									{
										lightingState8.b = num3;
									}
								}
							}
						}
					}
				}
			}
			else
			{
				lightCounter = 0;
			}
			if (Main.renderCount > maxRenderCount)
			{
				PreRenderPhase();
			}
		}

		public static void PreRenderPhase()
		{
			float num = (float)(int)Main.tileColor.R / 255f;
			float num2 = (float)(int)Main.tileColor.G / 255f;
			float num3 = (float)(int)Main.tileColor.B / 255f;
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num4 = 0;
			int num5 = Main.screenWidth / 16 + offScreenTiles * 2 + 10;
			int num6 = 0;
			int num7 = Main.screenHeight / 16 + offScreenTiles * 2 + 10;
			minX = num5;
			maxX = num4;
			minY = num7;
			maxY = num6;
			if (lightMode == 0 || lightMode == 3)
			{
				RGB = true;
			}
			else
			{
				RGB = false;
			}
			for (int i = num4; i < num5; i++)
			{
				LightingState[] array = states[i];
				for (int j = num6; j < num7; j++)
				{
					LightingState lightingState = array[j];
					lightingState.r2 = 0f;
					lightingState.g2 = 0f;
					lightingState.b2 = 0f;
					lightingState.stopLight = false;
					lightingState.wetLight = false;
					lightingState.honeyLight = false;
				}
			}
			if (Main.wof >= 0 && Main.player[Main.myPlayer].gross)
			{
				try
				{
					int num8 = (int)Main.screenPosition.Y / 16 - 10;
					int num9 = (int)(Main.screenPosition.Y + (float)Main.screenHeight) / 16 + 10;
					int num10 = (int)Main.npc[Main.wof].position.X / 16;
					num10 = ((Main.npc[Main.wof].direction <= 0) ? (num10 + 2) : (num10 - 3));
					int num11 = num10 + 8;
					float num12 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
					float num13 = 0.3f;
					float num14 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
					num12 *= 0.2f;
					num13 *= 0.1f;
					num14 *= 0.3f;
					for (int k = num10; k <= num11; k++)
					{
						LightingState[] array2 = states[k - num10];
						for (int l = num8; l <= num9; l++)
						{
							LightingState lightingState2 = array2[l - firstToLightY];
							if (lightingState2.r2 < num12)
							{
								lightingState2.r2 = num12;
							}
							if (lightingState2.g2 < num13)
							{
								lightingState2.g2 = num13;
							}
							if (lightingState2.b2 < num14)
							{
								lightingState2.b2 = num14;
							}
						}
					}
				}
				catch
				{
				}
			}
			Main.sandTiles = 0;
			Main.evilTiles = 0;
			Main.bloodTiles = 0;
			Main.shroomTiles = 0;
			Main.snowTiles = 0;
			Main.holyTiles = 0;
			Main.meteorTiles = 0;
			Main.jungleTiles = 0;
			Main.dungeonTiles = 0;
			Main.campfire = false;
			Main.heartLantern = false;
			Main.musicBox = -1;
			Main.waterCandles = 0;
			int[] tileCounts = WorldGen.tileCounts;
			num4 = firstToLightX;
			num5 = lastToLightX;
			num6 = firstToLightY;
			num7 = lastToLightY;
			int num15 = (num5 - num4 - Main.zoneX) / 2;
			int num16 = (num7 - num6 - Main.zoneY) / 2;
			Main.fountainColor = -1;
			for (int m = num4; m < num5; m++)
			{
				LightingState[] array3 = states[m - firstToLightX];
				for (int n = num6; n < num7; n++)
				{
					LightingState lightingState3 = array3[n - firstToLightY];
					Tile tile = Main.tile[m, n];
					if (tile == null)
					{
						tile = new Tile();
						Main.tile[m, n] = tile;
					}
					float num17 = 0f;
					float num18 = 0f;
					float num19 = 0f;
					if ((double)n < Main.worldSurface)
					{
						if ((!tile.active() || !Main.tileNoSunLight[tile.type]) && lightingState3.r2 < skyColor && (Main.wallLight[tile.wall] || tile.wall == 73) && tile.liquid < 200 && (!tile.halfBrick() || Main.tile[m, n - 1].liquid < 200))
						{
							num17 = num;
							num18 = num2;
							num19 = num3;
						}
						if ((!tile.active() || tile.halfBrick() || !Main.tileNoSunLight[tile.type]) && tile.wall >= 88 && tile.wall <= 93 && tile.liquid < byte.MaxValue)
						{
							num17 = num;
							num18 = num2;
							num19 = num3;
							switch ((int)tile.wall)
							{
							case 88:
								num17 *= 0.9f;
								num18 *= 0.15f;
								num19 *= 0.9f;
								break;
							case 89:
								num17 *= 0.9f;
								num18 *= 0.9f;
								num19 *= 0.15f;
								break;
							case 90:
								num17 *= 0.15f;
								num18 *= 0.15f;
								num19 *= 0.9f;
								break;
							case 91:
								num17 *= 0.15f;
								num18 *= 0.9f;
								num19 *= 0.15f;
								break;
							case 92:
								num17 *= 0.9f;
								num18 *= 0.15f;
								num19 *= 0.15f;
								break;
							case 93:
							{
								float num20 = 0.2f;
								float num21 = 0.7f - num20;
								num17 *= num21 + (float)Main.DiscoR / 255f * num20;
								num18 *= num21 + (float)Main.DiscoG / 255f * num20;
								num19 *= num21 + (float)Main.DiscoB / 255f * num20;
								break;
							}
							}
						}
						if (!RGB)
						{
							float num22 = (num17 + num18 + num19) / 3f;
							num17 = (num18 = (num19 = num22));
						}
						if (lightingState3.r2 < num17)
						{
							lightingState3.r2 = num17;
						}
						if (lightingState3.g2 < num18)
						{
							lightingState3.g2 = num18;
						}
						if (lightingState3.b2 < num19)
						{
							lightingState3.b2 = num19;
						}
					}
					switch (tile.wall)
					{
					case 33:
						if (!tile.active() || !Main.tileBlockLight[tile.type])
						{
							num17 = 0.089999996f;
							num18 = 0.052500002f;
							num19 = 0.24f;
						}
						break;
					case 137:
						if (!tile.active() || !Main.tileBlockLight[tile.type])
						{
							float num23 = 0.4f;
							num23 += (float)(270 - Main.mouseTextColor) / 1500f;
							num23 += (float)Main.rand.Next(0, 50) * 0.0005f;
							num17 = 1f * num23;
							num18 = 0.5f * num23;
							num19 = 0.1f * num23;
						}
						break;
					case 44:
						if (!tile.active() || !Main.tileBlockLight[tile.type])
						{
							num17 = (float)Main.DiscoR / 255f * 0.15f;
							num18 = (float)Main.DiscoG / 255f * 0.15f;
							num19 = (float)Main.DiscoB / 255f * 0.15f;
						}
						break;
					case 154:
						num17 = 0.6f;
						num19 = 0.6f;
						break;
					case 166:
						num17 = 0.6f;
						num18 = 0.6f;
						break;
					case 165:
						num19 = 0.6f;
						break;
					case 156:
						num18 = 0.6f;
						break;
					case 164:
						num17 = 0.6f;
						break;
					case 155:
						num17 = 0.6f;
						num18 = 0.6f;
						num19 = 0.6f;
						break;
					case 153:
						num17 = 0.6f;
						num18 = 0.3f;
						break;
					}
					if (tile.active())
					{
						if (m > num4 + num15 && m < num5 - num15 && n > num6 + num16 && n < num7 - num16)
						{
							tileCounts[tile.type]++;
							if (tile.type == 42 && tile.frameY >= 324 && tile.frameY <= 358)
							{
								Main.heartLantern = true;
							}
						}
						switch (tile.type)
						{
						case 139:
							if (tile.frameX >= 36)
							{
								Main.musicBox = tile.frameY / 36;
							}
							break;
						case 207:
							if (tile.frameY >= 72)
							{
								switch (tile.frameX / 36)
								{
								case 0:
									Main.fountainColor = 0;
									break;
								case 1:
									Main.fountainColor = 6;
									break;
								case 2:
									Main.fountainColor = 3;
									break;
								case 3:
									Main.fountainColor = 5;
									break;
								case 4:
									Main.fountainColor = 2;
									break;
								case 5:
									Main.fountainColor = 10;
									break;
								case 6:
									Main.fountainColor = 4;
									break;
								case 7:
									Main.fountainColor = 9;
									break;
								default:
									Main.fountainColor = -1;
									break;
								}
							}
							break;
						}
						if (Main.tileBlockLight[tile.type] && (lightMode >= 2 || (tile.type != 131 && !tile.inActive() && tile.slope() == 0)))
						{
							lightingState3.stopLight = true;
						}
						if (Main.tileLighted[tile.type])
						{
							switch (tile.type)
							{
							case 336:
								num17 = 0.85f;
								num18 = 0.5f;
								num19 = 0.3f;
								break;
							case 327:
							{
								float num39 = 0.5f;
								num39 += (float)(270 - Main.mouseTextColor) / 1500f;
								num39 += (float)Main.rand.Next(0, 50) * 0.0005f;
								num17 = 1f * num39;
								num18 = 0.5f * num39;
								num19 = 0.1f * num39;
								break;
							}
							case 316:
							case 317:
							case 318:
							{
								int num36 = m - tile.frameX / 18;
								int num37 = n - tile.frameY / 18;
								int num38 = num36 / 2 * (num37 / 3);
								num38 %= Main.cageFrames;
								bool flag = Main.jellyfishCageMode[tile.type - 316, num38] == 2;
								if (tile.type == 316)
								{
									if (flag)
									{
										num17 = 0.2f;
										num18 = 0.3f;
										num19 = 0.8f;
									}
									else
									{
										num17 = 0.1f;
										num18 = 0.2f;
										num19 = 0.5f;
									}
								}
								if (tile.type == 317)
								{
									if (flag)
									{
										num17 = 0.2f;
										num18 = 0.7f;
										num19 = 0.3f;
									}
									else
									{
										num17 = 0.05f;
										num18 = 0.45f;
										num19 = 0.1f;
									}
								}
								if (tile.type == 318)
								{
									if (flag)
									{
										num17 = 0.7f;
										num18 = 0.2f;
										num19 = 0.5f;
									}
									else
									{
										num17 = 0.4f;
										num18 = 0.1f;
										num19 = 0.25f;
									}
								}
								break;
							}
							case 286:
								num17 = 1f;
								num18 = 0.2f;
								num19 = 0.7f;
								break;
							case 270:
								num17 = 0.73f;
								num18 = 1f;
								num19 = 0.41f;
								break;
							case 271:
								num17 = 0.45f;
								num18 = 0.95f;
								num19 = 1f;
								break;
							case 262:
								num17 = 0.75f;
								num19 = 0.75f;
								break;
							case 263:
								num17 = 0.75f;
								num18 = 0.75f;
								break;
							case 264:
								num19 = 0.75f;
								break;
							case 265:
								num18 = 0.75f;
								break;
							case 266:
								num17 = 0.75f;
								break;
							case 267:
								num17 = 0.75f;
								num18 = 0.75f;
								num19 = 0.75f;
								break;
							case 268:
								num17 = 0.75f;
								num18 = 0.375f;
								break;
							case 237:
								num17 = 0.1f;
								num18 = 0.1f;
								break;
							case 238:
								if ((double)lightingState3.r2 < 0.5)
								{
									lightingState3.r2 = 0.5f;
								}
								if ((double)lightingState3.b2 < 0.5)
								{
									lightingState3.b2 = 0.5f;
								}
								break;
							case 235:
								if ((double)lightingState3.r2 < 0.6)
								{
									lightingState3.r2 = 0.6f;
								}
								if ((double)lightingState3.g2 < 0.6)
								{
									lightingState3.g2 = 0.6f;
								}
								break;
							case 215:
							{
								float num35 = (float)Main.rand.Next(28, 42) * 0.005f;
								num35 += (float)(270 - Main.mouseTextColor) / 700f;
								num17 = 0.9f + num35;
								num18 = 0.3f + num35;
								num19 = 0.1f + num35;
								break;
							}
							case 92:
								if (tile.frameY <= 18 && tile.frameX == 0)
								{
									num17 = 1f;
									num18 = 1f;
									num19 = 1f;
								}
								break;
							case 93:
								if (tile.frameX == 0)
								{
									switch (tile.frameY / 54)
									{
									case 1:
										num17 = 0.95f;
										num18 = 0.95f;
										num19 = 0.5f;
										break;
									case 2:
										num17 = 0.85f;
										num18 = 0.6f;
										num19 = 1f;
										break;
									case 3:
										num17 = 0.75f;
										num18 = 1f;
										num19 = 0.6f;
										break;
									case 4:
									case 5:
										num17 = 0.75f;
										num18 = 0.9f;
										num19 = 1f;
										break;
									case 9:
										num17 = 1f;
										num18 = 1f;
										num19 = 0.7f;
										break;
									case 13:
										num17 = 1f;
										num18 = 1f;
										num19 = 0.6f;
										break;
									case 19:
										num17 = 0.37f;
										num18 = 0.8f;
										num19 = 1f;
										break;
									case 20:
										num17 = 0f;
										num18 = 0.9f;
										num19 = 1f;
										break;
									case 21:
										num17 = 0.25f;
										num18 = 0.7f;
										num19 = 1f;
										break;
									case 23:
										num17 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
										num18 = 0.3f;
										num19 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
										break;
									case 24:
										num17 = 0.35f;
										num18 = 0.5f;
										num19 = 0.3f;
										break;
									case 25:
										num17 = 0.34f;
										num18 = 0.4f;
										num19 = 0.31f;
										break;
									case 26:
										num17 = 0.25f;
										num18 = 0.32f;
										num19 = 0.5f;
										break;
									default:
										num17 = 1f;
										num18 = 0.97f;
										num19 = 0.85f;
										break;
									}
								}
								break;
							case 96:
								if (tile.frameX >= 36)
								{
									num17 = 0.5f;
								}
								num18 = 0.35f;
								num19 = 0.1f;
								break;
							case 98:
								if (tile.frameY == 0)
								{
									num17 = 1f;
								}
								num18 = 0.97f;
								num19 = 0.85f;
								break;
							case 4:
								if (tile.frameX < 66)
								{
									switch (tile.frameY / 22)
									{
									case 0:
										num17 = 1f;
										num18 = 0.95f;
										num19 = 0.8f;
										break;
									case 1:
										num17 = 0f;
										num18 = 0.1f;
										num19 = 1.3f;
										break;
									case 2:
										num17 = 1f;
										num18 = 0.1f;
										num19 = 0.1f;
										break;
									case 3:
										num17 = 0f;
										num18 = 1f;
										num19 = 0.1f;
										break;
									case 4:
										num17 = 0.9f;
										num18 = 0f;
										num19 = 0.9f;
										break;
									case 5:
										num17 = 1.3f;
										num18 = 1.3f;
										num19 = 1.3f;
										break;
									case 6:
										num17 = 0.9f;
										num18 = 0.9f;
										num19 = 0f;
										break;
									case 7:
										num17 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
										num18 = 0.3f;
										num19 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
										break;
									case 8:
										num17 = 0.85f;
										num18 = 1f;
										num19 = 0.7f;
										break;
									case 9:
										num17 = 0.7f;
										num18 = 0.85f;
										num19 = 1f;
										break;
									case 10:
										num17 = 1f;
										num18 = 0.5f;
										num19 = 0f;
										break;
									case 11:
										num17 = 1.25f;
										num18 = 1.25f;
										num19 = 0.8f;
										break;
									case 12:
										num17 = 0.75f;
										num18 = 1.2824999f;
										num19 = 1.2f;
										break;
									default:
										num17 = 1f;
										num18 = 0.95f;
										num19 = 0.8f;
										break;
									}
								}
								break;
							case 33:
								if (tile.frameX == 0)
								{
									switch (tile.frameY / 22)
									{
									case 0:
										num17 = 1f;
										num18 = 0.95f;
										num19 = 0.65f;
										break;
									case 1:
										num17 = 0.55f;
										num18 = 0.85f;
										num19 = 0.35f;
										break;
									case 2:
										num17 = 0.65f;
										num18 = 0.95f;
										num19 = 0.5f;
										break;
									case 3:
										num17 = 0.2f;
										num18 = 0.75f;
										num19 = 1f;
										break;
									case 14:
										num17 = 1f;
										num18 = 1f;
										num19 = 0.6f;
										break;
									case 19:
										num17 = 0.37f;
										num18 = 0.8f;
										num19 = 1f;
										break;
									case 20:
										num17 = 0f;
										num18 = 0.9f;
										num19 = 1f;
										break;
									case 21:
										num17 = 0.25f;
										num18 = 0.7f;
										num19 = 1f;
										break;
									case 25:
										num17 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
										num18 = 0.3f;
										num19 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
										break;
									default:
										num17 = 1f;
										num18 = 0.95f;
										num19 = 0.65f;
										break;
									}
								}
								break;
							case 174:
								if (tile.frameX == 0)
								{
									num17 = 1f;
									num18 = 0.95f;
									num19 = 0.65f;
								}
								break;
							case 100:
							case 173:
								if (tile.frameX < 36)
								{
									switch (tile.frameY / 36)
									{
									case 1:
										num17 = 0.95f;
										num18 = 0.95f;
										num19 = 0.5f;
										break;
									case 3:
										num17 = 1f;
										num18 = 0.6f;
										num19 = 0.6f;
										break;
									case 6:
									case 9:
										num17 = 0.75f;
										num18 = 0.9f;
										num19 = 1f;
										break;
									case 11:
										num17 = 1f;
										num18 = 1f;
										num19 = 0.7f;
										break;
									case 13:
										num17 = 1f;
										num18 = 1f;
										num19 = 0.6f;
										break;
									case 19:
										num17 = 0.37f;
										num18 = 0.8f;
										num19 = 1f;
										break;
									case 20:
										num17 = 0f;
										num18 = 0.9f;
										num19 = 1f;
										break;
									case 21:
										num17 = 0.25f;
										num18 = 0.7f;
										num19 = 1f;
										break;
									case 25:
										num17 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
										num18 = 0.3f;
										num19 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
										break;
									case 22:
										num17 = 0.35f;
										num18 = 0.5f;
										num19 = 0.3f;
										break;
									case 23:
										num17 = 0.34f;
										num18 = 0.4f;
										num19 = 0.31f;
										break;
									case 24:
										num17 = 0.25f;
										num18 = 0.32f;
										num19 = 0.5f;
										break;
									default:
										num17 = 1f;
										num18 = 0.95f;
										num19 = 0.65f;
										break;
									}
								}
								break;
							case 34:
								if (tile.frameX < 54)
								{
									switch (tile.frameY / 54)
									{
									case 7:
										num17 = 0.95f;
										num18 = 0.95f;
										num19 = 0.5f;
										break;
									case 8:
										num17 = 0.85f;
										num18 = 0.6f;
										num19 = 1f;
										break;
									case 9:
										num17 = 1f;
										num18 = 0.6f;
										num19 = 0.6f;
										break;
									case 11:
									case 17:
										num17 = 0.75f;
										num18 = 0.9f;
										num19 = 1f;
										break;
									case 15:
										num17 = 1f;
										num18 = 1f;
										num19 = 0.7f;
										break;
									case 18:
										num17 = 1f;
										num18 = 1f;
										num19 = 0.6f;
										break;
									case 24:
										num17 = 0.37f;
										num18 = 0.8f;
										num19 = 1f;
										break;
									case 25:
										num17 = 0f;
										num18 = 0.9f;
										num19 = 1f;
										break;
									case 26:
										num17 = 0.25f;
										num18 = 0.7f;
										num19 = 1f;
										break;
									case 27:
										num17 = 0.55f;
										num18 = 0.85f;
										num19 = 0.35f;
										break;
									case 28:
										num17 = 0.65f;
										num18 = 0.95f;
										num19 = 0.5f;
										break;
									case 29:
										num17 = 0.2f;
										num18 = 0.75f;
										num19 = 1f;
										break;
									case 32:
										num17 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
										num18 = 0.3f;
										num19 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
										break;
									default:
										num17 = 1f;
										num18 = 0.95f;
										num19 = 0.8f;
										break;
									}
								}
								break;
							case 35:
								if (tile.frameX < 36)
								{
									num17 = 0.75f;
									num18 = 0.6f;
									num19 = 0.3f;
								}
								break;
							case 95:
								if (tile.frameX < 36)
								{
									num17 = 1f;
									num18 = 0.95f;
									num19 = 0.8f;
								}
								break;
							case 17:
							case 133:
								num17 = 0.83f;
								num18 = 0.6f;
								num19 = 0.5f;
								break;
							case 77:
								num17 = 0.75f;
								num18 = 0.45f;
								num19 = 0.25f;
								break;
							case 37:
								num17 = 0.56f;
								num18 = 0.43f;
								num19 = 0.15f;
								break;
							case 22:
							case 140:
								num17 = 0.12f;
								num18 = 0.07f;
								num19 = 0.32f;
								break;
							case 171:
							{
								int num33 = m;
								int num34 = n;
								if (tile.frameX < 10)
								{
									num33 -= tile.frameX;
									num34 -= tile.frameY;
								}
								switch ((Main.tile[num33, num34].frameY & 0x3C00) >> 10)
								{
								case 1:
									num17 = 0.1f;
									num18 = 0.1f;
									num19 = 0.1f;
									break;
								case 2:
									num17 = 0.2f;
									break;
								case 3:
									num18 = 0.2f;
									break;
								case 4:
									num19 = 0.2f;
									break;
								case 5:
									num17 = 0.125f;
									num18 = 0.125f;
									break;
								case 6:
									num17 = 0.2f;
									num18 = 0.1f;
									break;
								case 7:
									num17 = 0.125f;
									num18 = 0.125f;
									break;
								case 8:
									num17 = 0.08f;
									num18 = 0.175f;
									break;
								case 9:
									num18 = 0.125f;
									num19 = 0.125f;
									break;
								case 10:
									num17 = 0.125f;
									num19 = 0.125f;
									break;
								case 11:
									num17 = 0.1f;
									num18 = 0.1f;
									num19 = 0.2f;
									break;
								default:
									num17 = (num18 = (num19 = 0f));
									break;
								}
								num17 *= 0.5f;
								num18 *= 0.5f;
								num19 *= 0.5f;
								break;
							}
							case 204:
								num17 = 0.35f;
								break;
							case 42:
								if (tile.frameX == 0)
								{
									switch (tile.frameY / 36)
									{
									case 0:
										num17 = 0.7f;
										num18 = 0.65f;
										num19 = 0.55f;
										break;
									case 1:
										num17 = 0.9f;
										num18 = 0.75f;
										num19 = 0.6f;
										break;
									case 2:
										num17 = 0.8f;
										num18 = 0.6f;
										num19 = 0.6f;
										break;
									case 3:
										num17 = 0.65f;
										num18 = 0.5f;
										num19 = 0.2f;
										break;
									case 4:
										num17 = 0.5f;
										num18 = 0.7f;
										num19 = 0.4f;
										break;
									case 5:
										num17 = 0.9f;
										num18 = 0.4f;
										num19 = 0.2f;
										break;
									case 6:
										num17 = 0.7f;
										num18 = 0.75f;
										num19 = 0.3f;
										break;
									case 7:
									{
										float num32 = Main.demonTorch * 0.2f;
										num17 = 0.9f - num32;
										num18 = 0.9f - num32;
										num19 = 0.7f + num32;
										break;
									}
									case 8:
										num17 = 0.75f;
										num18 = 0.6f;
										num19 = 0.3f;
										break;
									case 9:
										num17 = 1f;
										num18 = 0.3f;
										num19 = 0.5f;
										num19 += Main.demonTorch * 0.2f;
										num17 -= Main.demonTorch * 0.1f;
										num18 -= Main.demonTorch * 0.2f;
										break;
									case 28:
										num17 = 0.37f;
										num18 = 0.8f;
										num19 = 1f;
										break;
									case 29:
										num17 = 0f;
										num18 = 0.9f;
										num19 = 1f;
										break;
									case 30:
										num17 = 0.25f;
										num18 = 0.7f;
										num19 = 1f;
										break;
									case 32:
										num17 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
										num18 = 0.3f;
										num19 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
										break;
									default:
										num17 = 1f;
										num18 = 1f;
										num19 = 1f;
										break;
									}
								}
								break;
							case 49:
								num17 = 0f;
								num18 = 0.35f;
								num19 = 0.8f;
								break;
							case 70:
							case 71:
							case 72:
							case 190:
							{
								float num31 = (float)Main.rand.Next(28, 42) * 0.005f;
								num31 += (float)(270 - Main.mouseTextColor) / 1000f;
								num17 = 0.1f;
								num18 = 0.2f + num31 / 2f;
								num19 = 0.7f + num31;
								break;
							}
							case 61:
								if (tile.frameX == 144)
								{
									float num29 = 1f + (float)(270 - Main.mouseTextColor) / 400f;
									float num30 = 0.8f - (float)(270 - Main.mouseTextColor) / 400f;
									num17 = 0.42f * num30;
									num18 = 0.81f * num29;
									num19 = 0.52f * num30;
								}
								break;
							case 26:
							case 31:
								if ((tile.type == 31 && tile.frameX >= 36) || (tile.type == 26 && tile.frameX >= 54))
								{
									float num27 = (float)Main.rand.Next(-5, 6) * 0.0025f;
									num17 = 0.5f + num27 * 2f;
									num18 = 0.2f + num27;
									num19 = 0.1f;
								}
								else
								{
									float num28 = (float)Main.rand.Next(-5, 6) * 0.0025f;
									num17 = 0.31f + num28;
									num18 = 0.1f;
									num19 = 0.44f + num28 * 2f;
								}
								break;
							case 84:
							{
								int num25 = tile.frameX / 18;
								float num26 = 0f;
								switch (num25)
								{
								case 2:
									num26 = (float)(270 - Main.mouseTextColor) / 800f;
									if (num26 > 1f)
									{
										num26 = 1f;
									}
									else if (num26 < 0f)
									{
										num26 = 0f;
									}
									num17 = num26 * 0.7f;
									num18 = num26;
									num19 = num26 * 0.1f;
									break;
								case 5:
									num26 = 0.9f;
									num17 = num26;
									num18 = num26 * 0.8f;
									num19 = num26 * 0.2f;
									break;
								case 6:
									num26 = 0.08f;
									num18 = num26 * 0.8f;
									num19 = num26;
									break;
								}
								break;
							}
							case 83:
								if (tile.frameX == 18 && !Main.dayTime)
								{
									num17 = 0.1f;
									num18 = 0.4f;
									num19 = 0.6f;
								}
								break;
							case 126:
								if (tile.frameX < 36)
								{
									num17 = (float)Main.DiscoR / 255f;
									num18 = (float)Main.DiscoG / 255f;
									num19 = (float)Main.DiscoB / 255f;
								}
								break;
							case 125:
							{
								float num24 = (float)Main.rand.Next(28, 42) * 0.01f;
								num24 += (float)(270 - Main.mouseTextColor) / 800f;
								num18 = (lightingState3.g2 = 0.3f * num24);
								num19 = (lightingState3.b2 = 0.6f * num24);
								break;
							}
							case 129:
								switch (tile.frameX / 18 % 3)
								{
								case 0:
									num17 = 0f;
									num18 = 0.05f;
									num19 = 0.25f;
									break;
								case 1:
									num17 = 0.2f;
									num18 = 0f;
									num19 = 0.15f;
									break;
								case 2:
									num17 = 0.1f;
									num18 = 0f;
									num19 = 0.2f;
									break;
								}
								break;
							case 149:
								if (tile.frameX <= 36)
								{
									switch (tile.frameX / 18)
									{
									case 0:
										num17 = 0.1f;
										num18 = 0.2f;
										num19 = 0.5f;
										break;
									case 1:
										num17 = 0.5f;
										num18 = 0.1f;
										num19 = 0.1f;
										break;
									case 2:
										num17 = 0.2f;
										num18 = 0.5f;
										num19 = 0.1f;
										break;
									}
									num17 *= (float)Main.rand.Next(970, 1031) * 0.001f;
									num18 *= (float)Main.rand.Next(970, 1031) * 0.001f;
									num19 *= (float)Main.rand.Next(970, 1031) * 0.001f;
								}
								break;
							case 160:
								num17 = (float)Main.DiscoR / 255f * 0.25f;
								num18 = (float)Main.DiscoG / 255f * 0.25f;
								num19 = (float)Main.DiscoB / 255f * 0.25f;
								break;
							}
						}
					}
					if (RGB)
					{
						if (lightingState3.r2 < num17)
						{
							lightingState3.r2 = num17;
						}
						if (lightingState3.g2 < num18)
						{
							lightingState3.g2 = num18;
						}
						if (lightingState3.b2 < num19)
						{
							lightingState3.b2 = num19;
						}
					}
					else
					{
						float num40 = (num17 + num18 + num19) / 3f;
						if (lightingState3.r2 < num40)
						{
							lightingState3.r2 = num40;
						}
					}
					if (tile.lava() && tile.liquid > 0)
					{
						if (RGB)
						{
							float num41 = (float)(tile.liquid / 255) * 0.41f + 0.14f;
							num41 = 0.55f;
							num41 += (float)(270 - Main.mouseTextColor) / 900f;
							if (lightingState3.r2 < num41)
							{
								lightingState3.r2 = num41;
							}
							if (lightingState3.g2 < num41)
							{
								lightingState3.g2 = num41 * 0.6f;
							}
							if (lightingState3.b2 < num41)
							{
								lightingState3.b2 = num41 * 0.2f;
							}
						}
						else
						{
							float num42 = (float)(tile.liquid / 255) * 0.38f + 0.08f;
							num42 += (float)(270 - Main.mouseTextColor) / 2000f;
							if (lightingState3.r2 < num42)
							{
								lightingState3.r2 = num42;
							}
						}
					}
					else if (tile.liquid > 128)
					{
						lightingState3.wetLight = true;
						if (tile.honey())
						{
							lightingState3.honeyLight = true;
						}
					}
					if (lightingState3.r2 > 0f || (RGB && (lightingState3.g2 > 0f || lightingState3.b2 > 0f)))
					{
						int num43 = m - firstToLightX;
						int num44 = n - firstToLightY;
						if (minX > num43)
						{
							minX = num43;
						}
						if (maxX < num43 + 1)
						{
							maxX = num43 + 1;
						}
						if (minY > num44)
						{
							minY = num44;
						}
						if (maxY < num44 + 1)
						{
							maxY = num44 + 1;
						}
					}
				}
			}
			foreach (KeyValuePair<Point16, ColorTriplet> tempLight in tempLights)
			{
				int num45 = tempLight.Key.x - firstTileX + offScreenTiles;
				int num46 = tempLight.Key.y - firstTileY + offScreenTiles;
				if (num45 >= 0 && num45 < Main.screenWidth / 16 + offScreenTiles * 2 + 10 && num46 >= 0 && num46 < Main.screenHeight / 16 + offScreenTiles * 2 + 10)
				{
					LightingState lightingState4 = states[num45][num46];
					if (lightingState4.r2 < tempLight.Value.r)
					{
						lightingState4.r2 = tempLight.Value.r;
					}
					if (lightingState4.g2 < tempLight.Value.g)
					{
						lightingState4.g2 = tempLight.Value.g;
					}
					if (lightingState4.b2 < tempLight.Value.b)
					{
						lightingState4.b2 = tempLight.Value.b;
					}
					if (num45 < minX)
					{
						minX = num45;
					}
					if (num45 > maxX)
					{
						maxX = num45;
					}
					if (num46 < minY)
					{
						minY = num46;
					}
					if (num46 > maxY)
					{
						maxY = num46;
					}
				}
			}
			tempLights.Clear();
			if (tileCounts[215] > 0)
			{
				Main.campfire = true;
			}
			Main.holyTiles = tileCounts[109] + tileCounts[110] + tileCounts[113] + tileCounts[117] + tileCounts[116] + tileCounts[164];
			Main.evilTiles = tileCounts[23] + tileCounts[24] + tileCounts[25] + tileCounts[32] + tileCounts[112] + tileCounts[163] - 5 * tileCounts[27];
			Main.bloodTiles = tileCounts[199] + tileCounts[203] + tileCounts[200] + tileCounts[234] - 5 * tileCounts[27];
			Main.snowTiles = tileCounts[147] + tileCounts[148] + tileCounts[161] + tileCounts[162] + tileCounts[164] + tileCounts[163] + tileCounts[200];
			Main.jungleTiles = tileCounts[60] + tileCounts[61] + tileCounts[62] + tileCounts[74] + tileCounts[226];
			Main.shroomTiles = tileCounts[70] + tileCounts[71] + tileCounts[72];
			Main.meteorTiles = tileCounts[37];
			Main.dungeonTiles = tileCounts[41] + tileCounts[43] + tileCounts[44];
			Main.sandTiles = tileCounts[53] + tileCounts[112] + tileCounts[116] + tileCounts[234];
			Main.waterCandles = tileCounts[49];
			Array.Clear(tileCounts, 0, tileCounts.Length);
			if (Main.holyTiles < 0)
			{
				Main.holyTiles = 0;
			}
			if (Main.evilTiles < 0)
			{
				Main.evilTiles = 0;
			}
			if (Main.bloodTiles < 0)
			{
				Main.bloodTiles = 0;
			}
			int holyTiles = Main.holyTiles;
			Main.holyTiles -= Main.evilTiles;
			Main.holyTiles -= Main.bloodTiles;
			Main.evilTiles -= holyTiles;
			Main.bloodTiles -= holyTiles;
			if (Main.holyTiles < 0)
			{
				Main.holyTiles = 0;
			}
			if (Main.evilTiles < 0)
			{
				Main.evilTiles = 0;
			}
			if (Main.bloodTiles < 0)
			{
				Main.bloodTiles = 0;
			}
			minX += firstToLightX;
			maxX += firstToLightX;
			minY += firstToLightY;
			maxY += firstToLightY;
			minX7 = minX;
			maxX7 = maxX;
			minY7 = minY;
			maxY7 = maxY;
			firstTileX7 = firstTileX;
			lastTileX7 = lastTileX;
			lastTileY7 = lastTileY;
			firstTileY7 = firstTileY;
			firstToLightX7 = firstToLightX;
			lastToLightX7 = lastToLightX;
			firstToLightY7 = firstToLightY;
			lastToLightY7 = lastToLightY;
			firstToLightX27 = firstTileX - offScreenTiles2;
			firstToLightY27 = firstTileY - offScreenTiles2;
			lastToLightX27 = lastTileX + offScreenTiles2;
			lastToLightY27 = lastTileY + offScreenTiles2;
			if (firstToLightX27 < 0)
			{
				firstToLightX27 = 0;
			}
			if (lastToLightX27 >= Main.maxTilesX)
			{
				lastToLightX27 = Main.maxTilesX - 1;
			}
			if (firstToLightY27 < 0)
			{
				firstToLightY27 = 0;
			}
			if (lastToLightY27 >= Main.maxTilesY)
			{
				lastToLightY27 = Main.maxTilesY - 1;
			}
			scrX = (int)Main.screenPosition.X / 16;
			scrY = (int)Main.screenPosition.Y / 16;
			Main.renderCount = 0;
			TimeLogger.LightingTime(0, stopwatch.Elapsed.TotalMilliseconds);
			doColors();
		}

		public static void doColors()
		{
			if (lightMode < 2)
			{
				blueWave += (float)blueDir * 0.0001f;
				if (blueWave > 1f)
				{
					blueWave = 1f;
					blueDir = -1;
				}
				else if (blueWave < 0.97f)
				{
					blueWave = 0.97f;
					blueDir = 1;
				}
				if (RGB)
				{
					negLight = 0.91f;
					negLight2 = 0.56f;
					honeyLightG = 0.7f * negLight * blueWave;
					honeyLightR = 0.75f * negLight * blueWave;
					honeyLightB = 0.6f * negLight * blueWave;
					switch (Main.waterStyle)
					{
					case 0:
					case 1:
					case 7:
					case 8:
						wetLightG = 0.96f * negLight * blueWave;
						wetLightR = 0.88f * negLight * blueWave;
						wetLightB = 1.015f * negLight * blueWave;
						break;
					case 2:
						wetLightG = 0.85f * negLight * blueWave;
						wetLightR = 0.94f * negLight * blueWave;
						wetLightB = 1.01f * negLight * blueWave;
						break;
					case 3:
						wetLightG = 0.95f * negLight * blueWave;
						wetLightR = 0.84f * negLight * blueWave;
						wetLightB = 1.015f * negLight * blueWave;
						break;
					case 4:
						wetLightG = 0.86f * negLight * blueWave;
						wetLightR = 0.9f * negLight * blueWave;
						wetLightB = 1.01f * negLight * blueWave;
						break;
					case 5:
						wetLightG = 0.99f * negLight * blueWave;
						wetLightR = 0.84f * negLight * blueWave;
						wetLightB = 1.01f * negLight * blueWave;
						break;
					case 6:
						wetLightG = 0.98f * negLight * blueWave;
						wetLightR = 0.95f * negLight * blueWave;
						wetLightB = 0.85f * negLight * blueWave;
						break;
					case 9:
						wetLightG = 0.88f * negLight * blueWave;
						wetLightR = 1f * negLight * blueWave;
						wetLightB = 0.84f * negLight * blueWave;
						break;
					case 10:
						wetLightG = 1f * negLight * blueWave;
						wetLightR = 0.83f * negLight * blueWave;
						wetLightB = 1f * negLight * blueWave;
						break;
					default:
						wetLightG = 0f;
						wetLightR = 0f;
						wetLightB = 0f;
						break;
					}
				}
				else
				{
					negLight = 0.9f;
					negLight2 = 0.54f;
					wetLightR = 0.95f * negLight * blueWave;
				}
				if (Main.player[Main.myPlayer].nightVision)
				{
					negLight *= 1.03f;
					negLight2 *= 1.03f;
				}
				if (Main.player[Main.myPlayer].blind)
				{
					negLight *= 0.95f;
					negLight2 *= 0.95f;
				}
				if (Main.player[Main.myPlayer].blackout)
				{
					negLight *= 0.85f;
					negLight2 *= 0.85f;
				}
			}
			else
			{
				negLight = 0.04f;
				negLight2 = 0.16f;
				if (Main.player[Main.myPlayer].nightVision)
				{
					negLight -= 0.013f;
					negLight2 -= 0.04f;
				}
				if (Main.player[Main.myPlayer].blind)
				{
					negLight += 0.03f;
					negLight2 += 0.06f;
				}
				if (Main.player[Main.myPlayer].blackout)
				{
					negLight += 0.09f;
					negLight2 += 0.18f;
				}
				wetLightR = negLight * 1.2f;
				wetLightG = negLight * 1.1f;
			}
			int num;
			int num2;
			switch (Main.renderCount)
			{
			case 0:
				num = 0;
				num2 = 1;
				break;
			case 1:
				num = 1;
				num2 = 3;
				break;
			case 2:
				num = 3;
				num2 = 4;
				break;
			default:
				num = 0;
				num2 = 0;
				break;
			}
			if (LightingThreads < 0)
			{
				LightingThreads = 0;
			}
			if (LightingThreads >= Environment.ProcessorCount)
			{
				LightingThreads = Environment.ProcessorCount - 1;
			}
			int num3 = LightingThreads;
			if (num3 > 0)
			{
				num3++;
			}
			Stopwatch stopwatch = new Stopwatch();
			for (int i = num; i < num2; i++)
			{
				stopwatch.Restart();
				switch (i)
				{
				case 0:
					swipe.innerLoop1Start = minY7 - firstToLightY7;
					swipe.innerLoop1End = lastToLightY27 + maxRenderCount - firstToLightY7;
					swipe.innerLoop2Start = maxY7 - firstToLightY;
					swipe.innerLoop2End = firstTileY7 - maxRenderCount - firstToLightY7;
					swipe.outerLoopStart = minX7 - firstToLightX7;
					swipe.outerLoopEnd = maxX7 - firstToLightX7;
					swipe.jaggedArray = states;
					break;
				case 1:
					swipe.innerLoop1Start = minX7 - firstToLightX7;
					swipe.innerLoop1End = lastTileX7 + maxRenderCount - firstToLightX7;
					swipe.innerLoop2Start = maxX7 - firstToLightX7;
					swipe.innerLoop2End = firstTileX7 - maxRenderCount - firstToLightX7;
					swipe.outerLoopStart = firstToLightY7 - firstToLightY7;
					swipe.outerLoopEnd = lastToLightY7 - firstToLightY7;
					swipe.jaggedArray = axisFlipStates;
					break;
				case 2:
					swipe.innerLoop1Start = firstToLightY27 - firstToLightY7;
					swipe.innerLoop1End = lastTileY7 + maxRenderCount - firstToLightY7;
					swipe.innerLoop2Start = lastToLightY27 - firstToLightY;
					swipe.innerLoop2End = firstTileY7 - maxRenderCount - firstToLightY7;
					swipe.outerLoopStart = firstToLightX27 - firstToLightX7;
					swipe.outerLoopEnd = lastToLightX27 - firstToLightX7;
					swipe.jaggedArray = states;
					break;
				case 3:
					swipe.innerLoop1Start = firstToLightX27 - firstToLightX7;
					swipe.innerLoop1End = lastTileX7 + maxRenderCount - firstToLightX7;
					swipe.innerLoop2Start = lastToLightX27 - firstToLightX7;
					swipe.innerLoop2End = firstTileX7 - maxRenderCount - firstToLightX7;
					swipe.outerLoopStart = firstToLightY27 - firstToLightY7;
					swipe.outerLoopEnd = lastToLightY27 - firstToLightY7;
					swipe.jaggedArray = axisFlipStates;
					break;
				}
				if (swipe.innerLoop1Start > swipe.innerLoop1End)
				{
					swipe.innerLoop1Start = swipe.innerLoop1End;
				}
				if (swipe.innerLoop2Start < swipe.innerLoop2End)
				{
					swipe.innerLoop2Start = swipe.innerLoop2End;
				}
				if (swipe.outerLoopStart > swipe.outerLoopEnd)
				{
					swipe.outerLoopStart = swipe.outerLoopEnd;
				}
				switch (lightMode)
				{
				case 0:
					swipe.function = doColors_Mode0_Swipe;
					break;
				case 1:
					swipe.function = doColors_Mode1_Swipe;
					break;
				case 2:
					swipe.function = doColors_Mode2_Swipe;
					break;
				case 3:
					swipe.function = doColors_Mode3_Swipe;
					break;
				default:
					swipe.function = null;
					break;
				}
				if (num3 == 0)
				{
					swipe.function(swipe);
				}
				else
				{
					int num4 = swipe.outerLoopEnd - swipe.outerLoopStart;
					int num5 = num4 / num3;
					int num6 = num4 % num3;
					int num7 = swipe.outerLoopStart;
					countdown.Reset(num3);
					for (int j = 0; j < num3; j++)
					{
						LightingSwipeData lightingSwipeData = threadSwipes[j];
						lightingSwipeData.CopyFrom(swipe);
						lightingSwipeData.outerLoopStart = num7;
						num7 += num5;
						if (num6 > 0)
						{
							num7++;
							num6--;
						}
						lightingSwipeData.outerLoopEnd = num7;
						ThreadPool.QueueUserWorkItem(callback_LightingSwipe, lightingSwipeData);
					}
					countdown.Wait();
				}
				TimeLogger.LightingTime(i + 1, stopwatch.Elapsed.TotalMilliseconds);
			}
		}

		private static void callback_LightingSwipe(object obj)
		{
			LightingSwipeData lightingSwipeData = obj as LightingSwipeData;
			try
			{
				lightingSwipeData.function(lightingSwipeData);
			}
			catch
			{
			}
			countdown.Signal();
		}

		private static void doColors_Mode0_Swipe(LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int outerLoopStart = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = outerLoopStart; i < outerLoopEnd; i++)
					{
						LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						float num5 = 0f;
						float num6 = 0f;
						for (int j = num2; j != num3; j += num)
						{
							LightingState lightingState = array[j];
							LightingState lightingState2 = array[j + num];
							bool flag3;
							bool flag2 = (flag3 = false);
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
							}
							else if ((double)num4 <= 0.0185)
							{
								flag2 = true;
							}
							else if (lightingState.r2 < num4)
							{
								lightingState.r2 = num4;
							}
							if (!flag2 && lightingState2.r2 <= num4)
							{
								num4 = (lightingState.stopLight ? (num4 * negLight2) : ((!lightingState.wetLight) ? (num4 * negLight) : ((!lightingState.honeyLight) ? (num4 * (wetLightR * (float)swipeData.rand.Next(98, 100) * 0.01f)) : (num4 * (honeyLightR * (float)swipeData.rand.Next(98, 100) * 0.01f)))));
							}
							if (lightingState.g2 > num5)
							{
								num5 = lightingState.g2;
							}
							else if ((double)num5 <= 0.0185)
							{
								flag3 = true;
							}
							else
							{
								lightingState.g2 = num5;
							}
							if (!flag3 && lightingState2.g2 <= num5)
							{
								num5 = (lightingState.stopLight ? (num5 * negLight2) : ((!lightingState.wetLight) ? (num5 * negLight) : ((!lightingState.honeyLight) ? (num5 * (wetLightG * (float)swipeData.rand.Next(97, 100) * 0.01f)) : (num5 * (honeyLightG * (float)swipeData.rand.Next(97, 100) * 0.01f)))));
							}
							if (lightingState.b2 > num6)
							{
								num6 = lightingState.b2;
							}
							else
							{
								if ((double)num6 <= 0.0185)
								{
									continue;
								}
								lightingState.b2 = num6;
							}
							if (!(lightingState2.b2 >= num6))
							{
								num6 = ((!lightingState.stopLight) ? ((!lightingState.wetLight) ? (num6 * negLight) : ((!lightingState.honeyLight) ? (num6 * (wetLightB * (float)swipeData.rand.Next(97, 100) * 0.01f)) : (num6 * (honeyLightB * (float)swipeData.rand.Next(97, 100) * 0.01f)))) : (num6 * negLight2));
							}
						}
					}
					if (flag)
					{
						flag = false;
						continue;
					}
					break;
				}
			}
			catch
			{
			}
		}

		private static void doColors_Mode1_Swipe(LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int outerLoopStart = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = outerLoopStart; i < outerLoopEnd; i++)
					{
						LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						for (int j = num2; j != num3; j += num)
						{
							LightingState lightingState = array[j];
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
							}
							else
							{
								if ((double)num4 <= 0.0185)
								{
									continue;
								}
								if (lightingState.r2 < num4)
								{
									lightingState.r2 = num4;
								}
							}
							if (!(array[j + num].r2 > num4))
							{
								num4 = ((!lightingState.stopLight) ? ((!lightingState.wetLight) ? (num4 * negLight) : ((!lightingState.honeyLight) ? (num4 * (wetLightR * (float)swipeData.rand.Next(98, 100) * 0.01f)) : (num4 * (honeyLightR * (float)swipeData.rand.Next(98, 100) * 0.01f)))) : (num4 * negLight2));
							}
						}
					}
					if (flag)
					{
						flag = false;
						continue;
					}
					break;
				}
			}
			catch
			{
			}
		}

		private static void doColors_Mode2_Swipe(LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int outerLoopStart = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = outerLoopStart; i < outerLoopEnd; i++)
					{
						LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						for (int j = num2; j != num3; j += num)
						{
							LightingState lightingState = array[j];
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
							}
							else
							{
								if (num4 <= 0f)
								{
									continue;
								}
								lightingState.r2 = num4;
							}
							num4 = ((!lightingState.stopLight) ? ((!lightingState.wetLight) ? (num4 - negLight) : (num4 - wetLightR)) : (num4 - negLight2));
						}
					}
					if (flag)
					{
						flag = false;
						continue;
					}
					break;
				}
			}
			catch
			{
			}
		}

		private static void doColors_Mode3_Swipe(LightingSwipeData swipeData)
		{
			try
			{
				bool flag = true;
				while (true)
				{
					int num;
					int num2;
					int num3;
					if (flag)
					{
						num = 1;
						num2 = swipeData.innerLoop1Start;
						num3 = swipeData.innerLoop1End;
					}
					else
					{
						num = -1;
						num2 = swipeData.innerLoop2Start;
						num3 = swipeData.innerLoop2End;
					}
					int outerLoopStart = swipeData.outerLoopStart;
					int outerLoopEnd = swipeData.outerLoopEnd;
					for (int i = outerLoopStart; i < outerLoopEnd; i++)
					{
						LightingState[] array = swipeData.jaggedArray[i];
						float num4 = 0f;
						float num5 = 0f;
						float num6 = 0f;
						for (int j = num2; j != num3; j += num)
						{
							LightingState lightingState = array[j];
							bool flag3;
							bool flag2 = (flag3 = false);
							if (lightingState.r2 > num4)
							{
								num4 = lightingState.r2;
							}
							else if (num4 <= 0f)
							{
								flag2 = true;
							}
							else
							{
								lightingState.r2 = num4;
							}
							if (!flag2)
							{
								num4 = (lightingState.stopLight ? (num4 - negLight2) : ((!lightingState.wetLight) ? (num4 - negLight) : (num4 - wetLightR)));
							}
							if (lightingState.g2 > num5)
							{
								num5 = lightingState.g2;
							}
							else if (num5 <= 0f)
							{
								flag3 = true;
							}
							else
							{
								lightingState.g2 = num5;
							}
							if (!flag3)
							{
								num5 = (lightingState.stopLight ? (num5 - negLight2) : ((!lightingState.wetLight) ? (num5 - negLight) : (num5 - wetLightG)));
							}
							if (lightingState.b2 > num6)
							{
								num6 = lightingState.b2;
							}
							else
							{
								if (num6 <= 0f)
								{
									continue;
								}
								lightingState.b2 = num6;
							}
							num6 = ((!lightingState.stopLight) ? (num6 - negLight) : (num6 - negLight2));
						}
					}
					if (flag)
					{
						flag = false;
						continue;
					}
					break;
				}
			}
			catch
			{
			}
		}

		public static void addLight(int i, int j, float R, float G, float B)
		{
			if (Main.netMode == 2 || i - firstTileX + offScreenTiles < 0 || i - firstTileX + offScreenTiles >= Main.screenWidth / 16 + offScreenTiles * 2 + 10 || j - firstTileY + offScreenTiles < 0 || j - firstTileY + offScreenTiles >= Main.screenHeight / 16 + offScreenTiles * 2 + 10 || tempLights.Count == maxTempLights)
			{
				return;
			}
			Point16 key = new Point16(i, j);
			ColorTriplet value;
			if (tempLights.TryGetValue(key, out value))
			{
				if (RGB)
				{
					if (value.r < R)
					{
						value.r = R;
					}
					if (value.g < G)
					{
						value.g = G;
					}
					if (value.b < B)
					{
						value.b = B;
					}
					tempLights[key] = value;
				}
				else
				{
					float num = (R + G + B) / 3f;
					if (value.r < num)
					{
						tempLights[key] = new ColorTriplet(num);
					}
				}
			}
			else
			{
				value = ((!RGB) ? new ColorTriplet((R + G + B) / 3f) : new ColorTriplet(R, G, B));
				tempLights.Add(key, value);
			}
		}

		public static void NextLightMode()
		{
			lightCounter += 100;
			lightMode++;
			if (lightMode >= 4)
			{
				lightMode = 0;
			}
			if (lightMode == 2 || lightMode == 0)
			{
				Main.renderCount = 0;
				Main.renderNow = true;
				BlackOut();
			}
		}

		public static void BlackOut()
		{
			int num = Main.screenWidth / 16 + offScreenTiles * 2;
			int num2 = Main.screenHeight / 16 + offScreenTiles * 2;
			for (int i = 0; i < num; i++)
			{
				LightingState[] array = states[i];
				for (int j = 0; j < num2; j++)
				{
					LightingState lightingState = array[j];
					lightingState.r = 0f;
					lightingState.g = 0f;
					lightingState.b = 0f;
				}
			}
		}

		public static Color GetColor(int x, int y, Color oldColor)
		{
			int num = x - firstTileX + offScreenTiles;
			int num2 = y - firstTileY + offScreenTiles;
			if (Main.gameMenu)
			{
				return oldColor;
			}
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + offScreenTiles * 2 + 10)
			{
				return Color.Black;
			}
			Color white = Color.White;
			LightingState lightingState = states[num][num2];
			int num3 = (int)((float)(int)oldColor.R * lightingState.r * brightness);
			int num4 = (int)((float)(int)oldColor.G * lightingState.g * brightness);
			int num5 = (int)((float)(int)oldColor.B * lightingState.b * brightness);
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			if (num5 > 255)
			{
				num5 = 255;
			}
			white.R = (byte)num3;
			white.G = (byte)num4;
			white.B = (byte)num5;
			return white;
		}

		public static Color GetColor(int x, int y)
		{
			int num = x - firstTileX + offScreenTiles;
			int num2 = y - firstTileY + offScreenTiles;
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + offScreenTiles * 2)
			{
				return Color.Black;
			}
			LightingState lightingState = states[num][num2];
			int num3 = (int)(255f * lightingState.r * brightness);
			int num4 = (int)(255f * lightingState.g * brightness);
			int num5 = (int)(255f * lightingState.b * brightness);
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			if (num5 > 255)
			{
				num5 = 255;
			}
			return new Color((byte)num3, (byte)num4, (byte)num5, 255);
		}

		public static void GetColor9Slice(int centerX, int centerY, ref Color[] slices)
		{
			int num = centerX - firstTileX + offScreenTiles;
			int num2 = centerY - firstTileY + offScreenTiles;
			if (num <= 0 || num2 <= 0 || num >= Main.screenWidth / 16 + offScreenTiles * 2 + 10 - 1 || num2 >= Main.screenHeight / 16 + offScreenTiles * 2 - 1)
			{
				for (int i = 0; i < 9; i++)
				{
					slices[i] = Color.Black;
				}
				return;
			}
			int num3 = 0;
			for (int j = num - 1; j <= num + 1; j++)
			{
				LightingState[] array = states[j];
				for (int k = num2 - 1; k <= num2 + 1; k++)
				{
					LightingState lightingState = array[k];
					int num4 = (int)(255f * lightingState.r * brightness);
					int num5 = (int)(255f * lightingState.g * brightness);
					int num6 = (int)(255f * lightingState.b * brightness);
					if (num4 > 255)
					{
						num4 = 255;
					}
					if (num5 > 255)
					{
						num5 = 255;
					}
					if (num6 > 255)
					{
						num6 = 255;
					}
					slices[num3] = new Color((byte)num4, (byte)num5, (byte)num6, 255);
					num3 += 3;
				}
				num3 -= 8;
			}
		}

		public static void GetColor4Slice(int centerX, int centerY, ref Color[] slices)
		{
			int num = centerX - firstTileX + offScreenTiles;
			int num2 = centerY - firstTileY + offScreenTiles;
			if (num <= 0 || num2 <= 0 || num >= Main.screenWidth / 16 + offScreenTiles * 2 + 10 - 1 || num2 >= Main.screenHeight / 16 + offScreenTiles * 2 - 1)
			{
				for (num = 0; num < 4; num++)
				{
					slices[num] = Color.Black;
				}
				return;
			}
			LightingState lightingState = states[num][num2 - 1];
			LightingState lightingState2 = states[num][num2 + 1];
			LightingState lightingState3 = states[num - 1][num2];
			LightingState lightingState4 = states[num + 1][num2];
			float num3 = lightingState.r + lightingState.g + lightingState.b;
			float num4 = lightingState2.r + lightingState2.g + lightingState2.b;
			float num5 = lightingState4.r + lightingState4.g + lightingState4.b;
			float num6 = lightingState3.r + lightingState3.g + lightingState3.b;
			if (num3 >= num6)
			{
				int num7 = (int)(255f * lightingState3.r * brightness);
				int num8 = (int)(255f * lightingState3.g * brightness);
				int num9 = (int)(255f * lightingState3.b * brightness);
				if (num7 > 255)
				{
					num7 = 255;
				}
				if (num8 > 255)
				{
					num8 = 255;
				}
				if (num9 > 255)
				{
					num9 = 255;
				}
				slices[0] = new Color((byte)num7, (byte)num8, (byte)num9, 255);
			}
			else
			{
				int num10 = (int)(255f * lightingState.r * brightness);
				int num11 = (int)(255f * lightingState.g * brightness);
				int num12 = (int)(255f * lightingState.b * brightness);
				if (num10 > 255)
				{
					num10 = 255;
				}
				if (num11 > 255)
				{
					num11 = 255;
				}
				if (num12 > 255)
				{
					num12 = 255;
				}
				slices[0] = new Color((byte)num10, (byte)num11, (byte)num12, 255);
			}
			if (num3 >= num5)
			{
				int num13 = (int)(255f * lightingState4.r * brightness);
				int num14 = (int)(255f * lightingState4.g * brightness);
				int num15 = (int)(255f * lightingState4.b * brightness);
				if (num13 > 255)
				{
					num13 = 255;
				}
				if (num14 > 255)
				{
					num14 = 255;
				}
				if (num15 > 255)
				{
					num15 = 255;
				}
				slices[1] = new Color((byte)num13, (byte)num14, (byte)num15, 255);
			}
			else
			{
				int num16 = (int)(255f * lightingState.r * brightness);
				int num17 = (int)(255f * lightingState.g * brightness);
				int num18 = (int)(255f * lightingState.b * brightness);
				if (num16 > 255)
				{
					num16 = 255;
				}
				if (num17 > 255)
				{
					num17 = 255;
				}
				if (num18 > 255)
				{
					num18 = 255;
				}
				slices[1] = new Color((byte)num16, (byte)num17, (byte)num18, 255);
			}
			if (num4 >= num6)
			{
				int num19 = (int)(255f * lightingState3.r * brightness);
				int num20 = (int)(255f * lightingState3.g * brightness);
				int num21 = (int)(255f * lightingState3.b * brightness);
				if (num19 > 255)
				{
					num19 = 255;
				}
				if (num20 > 255)
				{
					num20 = 255;
				}
				if (num21 > 255)
				{
					num21 = 255;
				}
				slices[2] = new Color((byte)num19, (byte)num20, (byte)num21, 255);
			}
			else
			{
				int num22 = (int)(255f * lightingState2.r * brightness);
				int num23 = (int)(255f * lightingState2.g * brightness);
				int num24 = (int)(255f * lightingState2.b * brightness);
				if (num22 > 255)
				{
					num22 = 255;
				}
				if (num23 > 255)
				{
					num23 = 255;
				}
				if (num24 > 255)
				{
					num24 = 255;
				}
				slices[2] = new Color((byte)num22, (byte)num23, (byte)num24, 255);
			}
			if (num4 >= num5)
			{
				int num25 = (int)(255f * lightingState4.r * brightness);
				int num26 = (int)(255f * lightingState4.g * brightness);
				int num27 = (int)(255f * lightingState4.b * brightness);
				if (num25 > 255)
				{
					num25 = 255;
				}
				if (num26 > 255)
				{
					num26 = 255;
				}
				if (num27 > 255)
				{
					num27 = 255;
				}
				slices[3] = new Color((byte)num25, (byte)num26, (byte)num27, 255);
			}
			else
			{
				int num28 = (int)(255f * lightingState2.r * brightness);
				int num29 = (int)(255f * lightingState2.g * brightness);
				int num30 = (int)(255f * lightingState2.b * brightness);
				if (num28 > 255)
				{
					num28 = 255;
				}
				if (num29 > 255)
				{
					num29 = 255;
				}
				if (num30 > 255)
				{
					num30 = 255;
				}
				slices[3] = new Color((byte)num28, (byte)num29, (byte)num30, 255);
			}
		}

		public static Color GetBlackness(int x, int y)
		{
			int num = x - firstTileX + offScreenTiles;
			int num2 = y - firstTileY + offScreenTiles;
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + offScreenTiles * 2 + 10)
			{
				return Color.Black;
			}
			return new Color(0, 0, 0, (byte)(255f - 255f * states[num][num2].r));
		}

		public static float Brightness(int x, int y)
		{
			int num = x - firstTileX + offScreenTiles;
			int num2 = y - firstTileY + offScreenTiles;
			if (num < 0 || num2 < 0 || num >= Main.screenWidth / 16 + offScreenTiles * 2 + 10 || num2 >= Main.screenHeight / 16 + offScreenTiles * 2 + 10)
			{
				return 0f;
			}
			LightingState lightingState = states[num][num2];
			return (lightingState.r + lightingState.g + lightingState.b) / 3f;
		}
	}
}
