using System;
using Microsoft.Xna.Framework;

namespace Terraria
{
	public class Dust
	{
		public static float dCount;

		public static int lavaBubbles;

		public Vector2 position;

		public Vector2 velocity;

		public float fadeIn;

		public bool noGravity;

		public float scale;

		public float rotation;

		public bool noLight;

		public bool active;

		public int type;

		public Color color;

		public int alpha;

		public Rectangle frame;

		public static int NewDust(Vector2 Position, int Width, int Height, int Type, float SpeedX = 0f, float SpeedY = 0f, int Alpha = 0, Color newColor = default(Color), float Scale = 1f)
		{
			if (Main.gameMenu)
			{
				return 6000;
			}
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			if (Main.gamePaused)
			{
				return 6000;
			}
			if (WorldGen.gen)
			{
				return 6000;
			}
			if (Main.netMode == 2)
			{
				return 6000;
			}
			int num = (int)(400f * (1f - dCount));
			Rectangle rectangle = new Rectangle((int)(Main.screenPosition.X - (float)num), (int)(Main.screenPosition.Y - (float)num), Main.screenWidth + num * 2, Main.screenHeight + num * 2);
			Rectangle value = new Rectangle((int)Position.X, (int)Position.Y, 10, 10);
			if (!rectangle.Intersects(value))
			{
				return 6000;
			}
			int result = 6000;
			for (int i = 0; i < 6000; i++)
			{
				Dust dust = Main.dust[i];
				if (dust.active)
				{
					continue;
				}
				if ((double)i > (double)Main.numDust * 0.9)
				{
					if (Main.rand.Next(4) != 0)
					{
						return 5999;
					}
				}
				else if ((double)i > (double)Main.numDust * 0.8)
				{
					if (Main.rand.Next(3) != 0)
					{
						return 5999;
					}
				}
				else if ((double)i > (double)Main.numDust * 0.7)
				{
					if (Main.rand.Next(2) == 0)
					{
						return 5999;
					}
				}
				else if ((double)i > (double)Main.numDust * 0.6)
				{
					if (Main.rand.Next(4) == 0)
					{
						return 5999;
					}
				}
				else if ((double)i > (double)Main.numDust * 0.5)
				{
					if (Main.rand.Next(5) == 0)
					{
						return 5999;
					}
				}
				else
				{
					dCount = 0f;
				}
				int num2 = Width;
				int num3 = Height;
				if (num2 < 5)
				{
					num2 = 5;
				}
				if (num3 < 5)
				{
					num3 = 5;
				}
				result = i;
				dust.fadeIn = 0f;
				dust.active = true;
				dust.type = Type;
				dust.noGravity = false;
				dust.color = newColor;
				dust.alpha = Alpha;
				dust.position.X = Position.X + (float)Main.rand.Next(num2 - 4) + 4f;
				dust.position.Y = Position.Y + (float)Main.rand.Next(num3 - 4) + 4f;
				dust.velocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + SpeedX;
				dust.velocity.Y = (float)Main.rand.Next(-20, 21) * 0.1f + SpeedY;
				dust.frame.X = 10 * Type;
				dust.frame.Y = 10 * Main.rand.Next(3);
				int num4 = Type;
				while (num4 >= 100)
				{
					num4 -= 100;
					dust.frame.X -= 1000;
					dust.frame.Y += 30;
				}
				dust.frame.Width = 8;
				dust.frame.Height = 8;
				dust.rotation = 0f;
				dust.scale = 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
				dust.scale *= Scale;
				dust.noLight = false;
				if (dust.type == 135 || dust.type == 6 || dust.type == 75 || dust.type == 169 || dust.type == 29 || (dust.type >= 59 && dust.type <= 65) || dust.type == 158)
				{
					dust.velocity.Y = (float)Main.rand.Next(-10, 6) * 0.1f;
					dust.velocity.X *= 0.3f;
					dust.scale *= 0.7f;
				}
				if (dust.type == 127 || dust.type == 187)
				{
					dust.velocity *= 0.3f;
					dust.scale *= 0.7f;
				}
				if (dust.type == 33 || dust.type == 52 || dust.type == 98 || dust.type == 99 || dust.type == 100 || dust.type == 101 || dust.type == 102 || dust.type == 103 || dust.type == 104 || dust.type == 105)
				{
					dust.alpha = 170;
					dust.velocity *= 0.5f;
					dust.velocity.Y += 1f;
				}
				if (dust.type == 41)
				{
					dust.velocity *= 0f;
				}
				if (dust.type == 80)
				{
					dust.alpha = 50;
				}
				if (dust.type == 34 || dust.type == 35 || dust.type == 152)
				{
					dust.velocity *= 0.1f;
					dust.velocity.Y = -0.5f;
					if (dust.type == 34 && !Collision.WetCollision(new Vector2(dust.position.X, dust.position.Y - 8f), 4, 4))
					{
						dust.active = false;
					}
				}
				break;
			}
			return result;
		}

		public static int dustWater()
		{
			switch (Main.waterStyle)
			{
			case 2:
				return 98;
			case 3:
				return 99;
			case 4:
				return 100;
			case 5:
				return 101;
			case 6:
				return 102;
			case 7:
				return 103;
			case 8:
				return 104;
			case 9:
				return 105;
			case 10:
				return 123;
			default:
				return 33;
			}
		}

		public static void UpdateDust()
		{
			int num = 0;
			lavaBubbles = 0;
			Main.snowDust = 0;
			for (int i = 0; i < 6000; i++)
			{
				Dust dust = Main.dust[i];
				if (i < Main.numDust)
				{
					if (!dust.active)
					{
						continue;
					}
					dCount += 1f;
					if (dust.scale > 10f)
					{
						dust.active = false;
					}
					if (dust.type == 35)
					{
						lavaBubbles++;
					}
					dust.position += dust.velocity;
					if (dust.type >= 86 && dust.type <= 92 && !dust.noLight)
					{
						float num2 = dust.scale * 0.6f;
						int num3 = dust.type - 85;
						float num4 = num2;
						float num5 = num2;
						float num6 = num2;
						switch (num3)
						{
						case 3:
							num4 *= 0f;
							num5 *= 0.1f;
							num6 *= 1.3f;
							break;
						case 5:
							num4 *= 1f;
							num5 *= 0.1f;
							num6 *= 0.1f;
							break;
						case 4:
							num4 *= 0f;
							num5 *= 1f;
							num6 *= 0.1f;
							break;
						case 1:
							num4 *= 0.9f;
							num5 *= 0f;
							num6 *= 0.9f;
							break;
						case 6:
							num4 *= 1.3f;
							num5 *= 1.3f;
							num6 *= 1.3f;
							break;
						case 2:
							num4 *= 0.9f;
							num5 *= 0.9f;
							num6 *= 0f;
							break;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num2 * num4, num2 * num5, num2 * num6);
					}
					if (dust.type == 154 || dust.type == 218)
					{
						dust.rotation += dust.velocity.X * 0.3f;
						dust.scale -= 0.03f;
					}
					if (dust.type == 172)
					{
						float num7 = dust.scale * 0.5f;
						if (num7 > 1f)
						{
							num7 = 1f;
						}
						float num8 = num7;
						float num9 = num7;
						float num10 = num7;
						num8 *= 0f;
						num9 *= 0.25f;
						num10 *= 1f;
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num7 * num8, num7 * num9, num7 * num10);
					}
					if (dust.type == 182)
					{
						dust.rotation += 1f;
						float num11 = dust.scale * 0.25f;
						if (num11 > 1f)
						{
							num11 = 1f;
						}
						float num12 = num11;
						float num13 = num11;
						float num14 = num11;
						num12 *= 1f;
						num13 *= 0.2f;
						num14 *= 0.1f;
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num11 * num12, num11 * num13, num11 * num14);
					}
					if (dust.type == 211 && dust.noLight && Collision.SolidCollision(dust.position, 4, 4))
					{
						dust.active = false;
					}
					if (dust.type == 213)
					{
						dust.rotation = 0f;
						float num15 = dust.scale / 2.5f * 0.2f;
						if (num15 > 1f)
						{
							num15 = 1f;
						}
						float r = 1f * num15;
						float g = 0.8509804f * num15;
						float b = 16f / 85f * num15;
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), r, g, b);
					}
					if (dust.type == 157)
					{
						float num16 = dust.scale * 0.2f;
						float num17 = num16;
						float num18 = num16;
						float num19 = num16;
						num17 *= 0.25f;
						num18 *= 1f;
						num19 *= 0.5f;
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num16 * num17, num16 * num18, num16 * num19);
					}
					if (dust.type == 206)
					{
						dust.scale -= 0.1f;
						float num20 = dust.scale * 0.4f;
						float num21 = num20;
						float num22 = num20;
						float num23 = num20;
						num21 *= 0.1f;
						num22 *= 0.6f;
						num23 *= 1f;
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num20 * num21, num20 * num22, num20 * num23);
					}
					if (dust.type == 163)
					{
						float num24 = dust.scale * 0.25f;
						float num25 = num24;
						float num26 = num24;
						float num27 = num24;
						num25 *= 0.25f;
						num26 *= 1f;
						num27 *= 0.05f;
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num24 * num25, num24 * num26, num24 * num27);
					}
					if (dust.type == 205)
					{
						float num28 = dust.scale * 0.25f;
						float num29 = num28;
						float num30 = num28;
						float num31 = num28;
						num29 *= 1f;
						num30 *= 0.05f;
						num31 *= 1f;
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num28 * num29, num28 * num30, num28 * num31);
					}
					if (dust.type == 170)
					{
						float num32 = dust.scale * 0.5f;
						float num33 = num32;
						float num34 = num32;
						float num35 = num32;
						num33 *= 1f;
						num34 *= 1f;
						num35 *= 0.05f;
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num32 * num33, num32 * num34, num32 * num35);
					}
					if (dust.type == 156)
					{
						float num36 = dust.scale * 0.6f;
						int type2 = dust.type;
						float num37 = num36;
						float num38 = num36;
						float num39 = num36;
						num37 *= 0.5f;
						num38 *= 0.9f;
						num39 *= 1f;
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num36 * num37, num36 * num38, num36 * num39);
					}
					if (dust.type == 175)
					{
						dust.scale -= 0.05f;
					}
					if (dust.type == 174)
					{
						dust.scale -= 0.01f;
						float num40 = dust.scale * 1f;
						if (num40 > 0.6f)
						{
							num40 = 0.6f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num40, num40 * 0.4f, 0f);
					}
					if (dust.type == 6 || dust.type == 135 || dust.type == 127 || dust.type == 187 || dust.type == 75 || dust.type == 169 || dust.type == 29 || (dust.type >= 59 && dust.type <= 65) || dust.type == 158)
					{
						if (!dust.noGravity)
						{
							dust.velocity.Y += 0.05f;
						}
						if (!dust.noLight)
						{
							float num41 = dust.scale * 1.4f;
							if (dust.type == 29)
							{
								if (num41 > 1f)
								{
									num41 = 1f;
								}
								Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num41 * 0.1f, num41 * 0.4f, num41);
							}
							if (dust.type == 75)
							{
								if (num41 > 1f)
								{
									num41 = 1f;
								}
								Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num41 * 0.7f, num41, num41 * 0.2f);
							}
							if (dust.type == 169)
							{
								if (num41 > 1f)
								{
									num41 = 1f;
								}
								Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num41 * 1.1f, num41 * 1.1f, num41 * 0.2f);
							}
							else if (dust.type == 135)
							{
								if (num41 > 1f)
								{
									num41 = 1f;
								}
								Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num41 * 0.2f, num41 * 0.7f, num41);
							}
							else if (dust.type == 158)
							{
								if (num41 > 1f)
								{
									num41 = 1f;
								}
								Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num41 * 1f, num41 * 0.5f, 0f);
							}
							else if (dust.type >= 59 && dust.type <= 65)
							{
								if (num41 > 0.8f)
								{
									num41 = 0.8f;
								}
								int num42 = dust.type - 58;
								float num43 = 1f;
								float num44 = 1f;
								float num45 = 1f;
								switch (num42)
								{
								case 1:
									num43 = 0f;
									num44 = 0.1f;
									num45 = 1.3f;
									break;
								case 2:
									num43 = 1f;
									num44 = 0.1f;
									num45 = 0.1f;
									break;
								case 3:
									num43 = 0f;
									num44 = 1f;
									num45 = 0.1f;
									break;
								case 4:
									num43 = 0.9f;
									num44 = 0f;
									num45 = 0.9f;
									break;
								case 5:
									num43 = 1.3f;
									num44 = 1.3f;
									num45 = 1.3f;
									break;
								case 6:
									num43 = 0.9f;
									num44 = 0.9f;
									num45 = 0f;
									break;
								case 7:
									num43 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
									num44 = 0.3f;
									num45 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
									break;
								}
								Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num41 * num43, num41 * num44, num41 * num45);
							}
							else if (dust.type == 127)
							{
								num41 *= 1.3f;
								if (num41 > 1f)
								{
									num41 = 1f;
								}
								Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num41, num41 * 0.45f, num41 * 0.2f);
							}
							else if (dust.type == 187)
							{
								num41 *= 1.3f;
								if (num41 > 1f)
								{
									num41 = 1f;
								}
								Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num41 * 0.2f, num41 * 0.45f, num41);
							}
							else
							{
								if (num41 > 0.6f)
								{
									num41 = 0.6f;
								}
								Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num41, num41 * 0.65f, num41 * 0.4f);
							}
						}
					}
					else if (dust.type == 159)
					{
						float num46 = dust.scale * 1.3f;
						if (num46 > 1f)
						{
							num46 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num46, num46, num46 * 0.1f);
						if (dust.noGravity)
						{
							if (dust.scale < 0.7f)
							{
								dust.velocity *= 1.075f;
							}
							else if (Main.rand.Next(2) == 0)
							{
								dust.velocity *= -0.95f;
							}
							else
							{
								dust.velocity *= 1.05f;
							}
							dust.scale -= 0.03f;
						}
						else
						{
							dust.scale += 0.005f;
							dust.velocity *= 0.9f;
							dust.velocity.X += (float)Main.rand.Next(-10, 11) * 0.02f;
							dust.velocity.Y += (float)Main.rand.Next(-10, 11) * 0.02f;
							if (Main.rand.Next(5) == 0)
							{
								int num47 = NewDust(dust.position, 4, 4, dust.type);
								Main.dust[num47].noGravity = true;
								Main.dust[num47].scale = dust.scale * 2.5f;
							}
						}
					}
					else if (dust.type == 164)
					{
						float num48 = dust.scale;
						if (num48 > 1f)
						{
							num48 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num48, num48 * 0.1f, num48 * 0.8f);
						if (dust.noGravity)
						{
							if (dust.scale < 0.7f)
							{
								dust.velocity *= 1.075f;
							}
							else if (Main.rand.Next(2) == 0)
							{
								dust.velocity *= -0.95f;
							}
							else
							{
								dust.velocity *= 1.05f;
							}
							dust.scale -= 0.03f;
						}
						else
						{
							dust.scale -= 0.005f;
							dust.velocity *= 0.9f;
							dust.velocity.X += (float)Main.rand.Next(-10, 11) * 0.02f;
							dust.velocity.Y += (float)Main.rand.Next(-10, 11) * 0.02f;
							if (Main.rand.Next(5) == 0)
							{
								int num49 = NewDust(dust.position, 4, 4, dust.type);
								Main.dust[num49].noGravity = true;
								Main.dust[num49].scale = dust.scale * 2.5f;
							}
						}
					}
					else if (dust.type == 173)
					{
						float num50 = dust.scale;
						if (num50 > 1f)
						{
							num50 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num50 * 0.4f, num50 * 0.1f, num50);
						if (dust.noGravity)
						{
							dust.velocity *= 0.8f;
							dust.velocity.X += (float)Main.rand.Next(-20, 21) * 0.01f;
							dust.velocity.Y += (float)Main.rand.Next(-20, 21) * 0.01f;
							dust.scale -= 0.01f;
						}
						else
						{
							dust.scale -= 0.015f;
							dust.velocity *= 0.8f;
							dust.velocity.X += (float)Main.rand.Next(-10, 11) * 0.005f;
							dust.velocity.Y += (float)Main.rand.Next(-10, 11) * 0.005f;
							if (Main.rand.Next(10) == 10)
							{
								int num51 = NewDust(dust.position, 4, 4, dust.type);
								Main.dust[num51].noGravity = true;
								Main.dust[num51].scale = dust.scale;
							}
						}
					}
					else if (dust.type == 184)
					{
						if (!dust.noGravity)
						{
							dust.velocity *= 0f;
							dust.scale -= 0.01f;
						}
					}
					else if (dust.type == 160 || dust.type == 162)
					{
						float num52 = dust.scale * 1.3f;
						if (num52 > 1f)
						{
							num52 = 1f;
						}
						if (dust.type == 162)
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num52, num52 * 0.7f, num52 * 0.1f);
						}
						else
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num52 * 0.1f, num52, num52);
						}
						if (dust.noGravity)
						{
							dust.velocity *= 0.8f;
							dust.velocity.X += (float)Main.rand.Next(-20, 21) * 0.04f;
							dust.velocity.Y += (float)Main.rand.Next(-20, 21) * 0.04f;
							dust.scale -= 0.1f;
						}
						else
						{
							dust.scale -= 0.1f;
							dust.velocity.X += (float)Main.rand.Next(-10, 11) * 0.02f;
							dust.velocity.Y += (float)Main.rand.Next(-10, 11) * 0.02f;
							if ((double)dust.scale > 0.3 && Main.rand.Next(50) == 0)
							{
								int num53 = NewDust(new Vector2(dust.position.X - 4f, dust.position.Y - 4f), 1, 1, dust.type);
								Main.dust[num53].noGravity = true;
								Main.dust[num53].scale = dust.scale * 1.5f;
							}
						}
					}
					else if (dust.type == 168)
					{
						float num54 = dust.scale * 0.8f;
						if ((double)num54 > 0.55)
						{
							num54 = 0.55f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num54, 0f, num54 * 0.8f);
						dust.scale += 0.03f;
						dust.velocity.X += (float)Main.rand.Next(-10, 11) * 0.02f;
						dust.velocity.Y += (float)Main.rand.Next(-10, 11) * 0.02f;
						dust.velocity *= 0.99f;
					}
					else if (dust.type >= 139 && dust.type < 143)
					{
						dust.velocity.X *= 0.98f;
						dust.velocity.Y *= 0.98f;
						if (dust.velocity.Y < 1f)
						{
							dust.velocity.Y += 0.05f;
						}
						dust.scale += 0.009f;
						dust.rotation -= dust.velocity.X * 0.4f;
						if (dust.velocity.X > 0f)
						{
							dust.rotation += 0.005f;
						}
						else
						{
							dust.rotation -= 0.005f;
						}
					}
					else if (dust.type == 14 || dust.type == 16 || dust.type == 31 || dust.type == 46 || dust.type == 124 || dust.type == 186 || dust.type == 188)
					{
						dust.velocity.Y *= 0.98f;
						dust.velocity.X *= 0.98f;
						if (dust.type == 31 && dust.noGravity)
						{
							dust.velocity *= 1.02f;
							dust.scale += 0.02f;
							dust.alpha += 4;
							if (dust.alpha > 255)
							{
								dust.scale = 0.0001f;
								dust.alpha = 255;
							}
						}
					}
					else if (dust.type == 32)
					{
						dust.scale -= 0.01f;
						dust.velocity.X *= 0.96f;
						if (!dust.noGravity)
						{
							dust.velocity.Y += 0.1f;
						}
					}
					else if (dust.type == 43)
					{
						dust.rotation += 0.1f * dust.scale;
						Color color = Lighting.GetColor((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f));
						float num55 = (float)(int)color.R / 270f;
						float num56 = (float)(int)color.G / 270f;
						float num57 = (float)(int)color.B / 270f;
						float num58 = dust.color.R / 255;
						float num59 = dust.color.G / 255;
						float num60 = dust.color.B / 255;
						num55 *= dust.scale * 1.07f * num58;
						num56 *= dust.scale * 1.07f * num59;
						num57 *= dust.scale * 1.07f * num60;
						if (dust.alpha < 255)
						{
							dust.scale += 0.09f;
							if (dust.scale >= 1f)
							{
								dust.scale = 1f;
								dust.alpha = 255;
							}
						}
						else
						{
							if ((double)dust.scale < 0.8)
							{
								dust.scale -= 0.01f;
							}
							if ((double)dust.scale < 0.5)
							{
								dust.scale -= 0.01f;
							}
						}
						if ((double)num55 < 0.05 && (double)num56 < 0.05 && (double)num57 < 0.05)
						{
							dust.active = false;
						}
						else
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num55, num56, num57);
						}
					}
					else if (dust.type == 15 || dust.type == 57 || dust.type == 58)
					{
						dust.velocity.Y *= 0.98f;
						dust.velocity.X *= 0.98f;
						float num61 = dust.scale;
						if (dust.type != 15)
						{
							num61 = dust.scale * 0.8f;
						}
						if (dust.noLight)
						{
							dust.velocity *= 0.95f;
						}
						if (num61 > 1f)
						{
							num61 = 1f;
						}
						if (dust.type == 15)
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num61 * 0.45f, num61 * 0.55f, num61);
						}
						else if (dust.type == 57)
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num61 * 0.95f, num61 * 0.95f, num61 * 0.45f);
						}
						else if (dust.type == 58)
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num61, num61 * 0.55f, num61 * 0.75f);
						}
					}
					else if (dust.type == 204)
					{
						if (dust.fadeIn > dust.scale)
						{
							dust.scale += 0.02f;
						}
						else
						{
							dust.scale -= 0.02f;
						}
						dust.velocity *= 0.95f;
					}
					else if (dust.type == 110)
					{
						float num62 = dust.scale * 0.1f;
						if (num62 > 1f)
						{
							num62 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num62 * 0.2f, num62, num62 * 0.5f);
					}
					else if (dust.type == 111)
					{
						float num63 = dust.scale * 0.125f;
						if (num63 > 1f)
						{
							num63 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num63 * 0.2f, num63 * 0.7f, num63);
					}
					else if (dust.type == 112)
					{
						float num64 = dust.scale * 0.1f;
						if (num64 > 1f)
						{
							num64 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num64 * 0.8f, num64 * 0.2f, num64 * 0.8f);
					}
					else if (dust.type == 113)
					{
						float num65 = dust.scale * 0.1f;
						if (num65 > 1f)
						{
							num65 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num65 * 0.2f, num65 * 0.3f, num65 * 1.3f);
					}
					else if (dust.type == 114)
					{
						float num66 = dust.scale * 0.1f;
						if (num66 > 1f)
						{
							num66 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num66 * 1.2f, num66 * 0.5f, num66 * 0.4f);
					}
					else if (dust.type == 66)
					{
						if (dust.velocity.X < 0f)
						{
							dust.rotation -= 1f;
						}
						else
						{
							dust.rotation += 1f;
						}
						dust.velocity.Y *= 0.98f;
						dust.velocity.X *= 0.98f;
						dust.scale += 0.02f;
						float num67 = dust.scale;
						if (dust.type != 15)
						{
							num67 = dust.scale * 0.8f;
						}
						if (num67 > 1f)
						{
							num67 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num67 * ((float)(int)dust.color.R / 255f), num67 * ((float)(int)dust.color.G / 255f), num67 * ((float)(int)dust.color.B / 255f));
					}
					else if (dust.type == 20 || dust.type == 21)
					{
						dust.scale += 0.005f;
						dust.velocity.Y *= 0.94f;
						dust.velocity.X *= 0.94f;
						float num68 = dust.scale * 0.8f;
						if (num68 > 1f)
						{
							num68 = 1f;
						}
						if (dust.type == 21)
						{
							num68 = dust.scale * 0.4f;
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num68 * 0.8f, num68 * 0.3f, num68);
						}
						else
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num68 * 0.3f, num68 * 0.6f, num68);
						}
					}
					else if (dust.type == 27 || dust.type == 45)
					{
						dust.velocity *= 0.94f;
						dust.scale += 0.002f;
						float num69 = dust.scale;
						if (dust.noLight)
						{
							num69 *= 0.1f;
							dust.scale -= 0.06f;
							if (dust.scale < 1f)
							{
								dust.scale -= 0.06f;
							}
							if (Main.player[Main.myPlayer].wet)
							{
								dust.position += Main.player[Main.myPlayer].velocity * 0.5f;
							}
							else
							{
								dust.position += Main.player[Main.myPlayer].velocity;
							}
						}
						if (num69 > 1f)
						{
							num69 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num69 * 0.6f, num69 * 0.2f, num69);
					}
					else if (dust.type == 55 || dust.type == 56 || dust.type == 73 || dust.type == 74)
					{
						dust.velocity *= 0.98f;
						float num70 = dust.scale * 0.8f;
						if (dust.type == 55)
						{
							if (num70 > 1f)
							{
								num70 = 1f;
							}
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num70, num70, num70 * 0.6f);
						}
						else if (dust.type == 73)
						{
							if (num70 > 1f)
							{
								num70 = 1f;
							}
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num70, num70 * 0.35f, num70 * 0.5f);
						}
						else if (dust.type == 74)
						{
							if (num70 > 1f)
							{
								num70 = 1f;
							}
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num70 * 0.35f, num70, num70 * 0.5f);
						}
						else
						{
							num70 = dust.scale * 1.2f;
							if (num70 > 1f)
							{
								num70 = 1f;
							}
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num70 * 0.35f, num70 * 0.5f, num70);
						}
					}
					else if (dust.type == 71 || dust.type == 72)
					{
						dust.velocity *= 0.98f;
						float num71 = dust.scale;
						if (num71 > 1f)
						{
							num71 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num71 * 0.2f, 0f, num71 * 0.1f);
					}
					else if (dust.type == 76)
					{
						int num85 = (int)dust.position.X / 16;
						int num86 = (int)dust.position.Y / 16;
						Main.snowDust++;
						dust.scale += 0.009f;
						if (!dust.noLight)
						{
							dust.position += Main.player[Main.myPlayer].velocity * 0.2f;
						}
					}
					else if (!dust.noGravity && dust.type != 41 && dust.type != 44)
					{
						if (dust.type == 107)
						{
							dust.velocity *= 0.9f;
						}
						else
						{
							dust.velocity.Y += 0.1f;
						}
					}
					if (dust.type == 5 && dust.noGravity)
					{
						dust.scale -= 0.04f;
					}
					if (dust.type == 33 || dust.type == 52 || dust.type == 98 || dust.type == 99 || dust.type == 100 || dust.type == 101 || dust.type == 102 || dust.type == 103 || dust.type == 104 || dust.type == 105 || dust.type == 123)
					{
						if (dust.velocity.X == 0f)
						{
							if (Collision.SolidCollision(dust.position, 2, 2))
							{
								dust.scale = 0f;
							}
							dust.rotation += 0.5f;
							dust.scale -= 0.01f;
						}
						if (Collision.WetCollision(new Vector2(dust.position.X, dust.position.Y), 4, 4))
						{
							dust.alpha += 20;
							dust.scale -= 0.1f;
						}
						dust.alpha += 2;
						dust.scale -= 0.005f;
						if (dust.alpha > 255)
						{
							dust.scale = 0f;
						}
						if (dust.velocity.Y > 4f)
						{
							dust.velocity.Y = 4f;
						}
						if (dust.noGravity)
						{
							if (dust.velocity.X < 0f)
							{
								dust.rotation -= 0.2f;
							}
							else
							{
								dust.rotation += 0.2f;
							}
							dust.scale += 0.03f;
							dust.velocity.X *= 1.05f;
							dust.velocity.Y += 0.15f;
						}
					}
					if (dust.type == 35 && dust.noGravity)
					{
						dust.scale += 0.03f;
						if (dust.scale < 1f)
						{
							dust.velocity.Y += 0.075f;
						}
						dust.velocity.X *= 1.08f;
						if (dust.velocity.X > 0f)
						{
							dust.rotation += 0.01f;
						}
						else
						{
							dust.rotation -= 0.01f;
						}
						float num72 = dust.scale * 0.6f;
						if (num72 > 1f)
						{
							num72 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f + 1f), num72, num72 * 0.3f, num72 * 0.1f);
					}
					else if (dust.type == 152 && dust.noGravity)
					{
						dust.scale += 0.03f;
						if (dust.scale < 1f)
						{
							dust.velocity.Y += 0.075f;
						}
						dust.velocity.X *= 1.08f;
						if (dust.velocity.X > 0f)
						{
							dust.rotation += 0.01f;
						}
						else
						{
							dust.rotation -= 0.01f;
						}
					}
					else if (dust.type == 67 || dust.type == 92)
					{
						float num73 = dust.scale;
						if (num73 > 1f)
						{
							num73 = 1f;
						}
						if (dust.noLight)
						{
							num73 *= 0.1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0f, num73 * 0.8f, num73);
					}
					else if (dust.type == 185)
					{
						float num74 = dust.scale;
						if (num74 > 1f)
						{
							num74 = 1f;
						}
						if (dust.noLight)
						{
							num74 *= 0.1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num74 * 0.1f, num74 * 0.7f, num74);
					}
					else if (dust.type == 107)
					{
						float num75 = dust.scale * 0.5f;
						if (num75 > 1f)
						{
							num75 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num75 * 0.1f, num75, num75 * 0.4f);
					}
					else if (dust.type == 34 || dust.type == 35 || dust.type == 152)
					{
						if (!Collision.WetCollision(new Vector2(dust.position.X, dust.position.Y - 8f), 4, 4))
						{
							dust.scale = 0f;
						}
						else
						{
							dust.alpha += Main.rand.Next(2);
							if (dust.alpha > 255)
							{
								dust.scale = 0f;
							}
							dust.velocity.Y = -0.5f;
							if (dust.type == 34)
							{
								dust.scale += 0.005f;
							}
							else
							{
								dust.alpha++;
								dust.scale -= 0.01f;
								dust.velocity.Y = -0.2f;
							}
							dust.velocity.X += (float)Main.rand.Next(-10, 10) * 0.002f;
							if ((double)dust.velocity.X < -0.25)
							{
								dust.velocity.X = -0.25f;
							}
							if ((double)dust.velocity.X > 0.25)
							{
								dust.velocity.X = 0.25f;
							}
						}
						if (dust.type == 35)
						{
							float num76 = dust.scale * 0.3f + 0.4f;
							if (num76 > 1f)
							{
								num76 = 1f;
							}
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num76, num76 * 0.5f, num76 * 0.3f);
						}
					}
					if (dust.type == 68)
					{
						float num77 = dust.scale * 0.3f;
						if (num77 > 1f)
						{
							num77 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num77 * 0.1f, num77 * 0.2f, num77);
					}
					if (dust.type == 70)
					{
						float num78 = dust.scale * 0.3f;
						if (num78 > 1f)
						{
							num78 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num78 * 0.5f, 0f, num78);
					}
					if (dust.type == 41)
					{
						dust.velocity.X += (float)Main.rand.Next(-10, 11) * 0.01f;
						dust.velocity.Y += (float)Main.rand.Next(-10, 11) * 0.01f;
						if ((double)dust.velocity.X > 0.75)
						{
							dust.velocity.X = 0.75f;
						}
						if ((double)dust.velocity.X < -0.75)
						{
							dust.velocity.X = -0.75f;
						}
						if ((double)dust.velocity.Y > 0.75)
						{
							dust.velocity.Y = 0.75f;
						}
						if ((double)dust.velocity.Y < -0.75)
						{
							dust.velocity.Y = -0.75f;
						}
						dust.scale += 0.007f;
						float num79 = dust.scale * 0.7f;
						if (num79 > 1f)
						{
							num79 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num79 * 0.4f, num79 * 0.9f, num79);
					}
					else if (dust.type == 44)
					{
						dust.velocity.X += (float)Main.rand.Next(-10, 11) * 0.003f;
						dust.velocity.Y += (float)Main.rand.Next(-10, 11) * 0.003f;
						if ((double)dust.velocity.X > 0.35)
						{
							dust.velocity.X = 0.35f;
						}
						if ((double)dust.velocity.X < -0.35)
						{
							dust.velocity.X = -0.35f;
						}
						if ((double)dust.velocity.Y > 0.35)
						{
							dust.velocity.Y = 0.35f;
						}
						if ((double)dust.velocity.Y < -0.35)
						{
							dust.velocity.Y = -0.35f;
						}
						dust.scale += 0.0085f;
						float num80 = dust.scale * 0.7f;
						if (num80 > 1f)
						{
							num80 = 1f;
						}
						Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num80 * 0.7f, num80, num80 * 0.8f);
					}
					else
					{
						dust.velocity.X *= 0.99f;
					}
					if (dust.type != 79)
					{
						dust.rotation += dust.velocity.X * 0.5f;
					}
					if (dust.fadeIn > 0f)
					{
						if (dust.type == 46)
						{
							dust.scale += 0.1f;
						}
						else if (dust.type == 213)
						{
							dust.scale += 0.1f;
						}
						else
						{
							dust.scale += 0.03f;
						}
						if (dust.scale > dust.fadeIn)
						{
							dust.fadeIn = 0f;
						}
					}
					else if (dust.type == 213)
					{
						dust.scale -= 0.2f;
					}
					else
					{
						dust.scale -= 0.01f;
					}
					if (dust.type >= 130 && dust.type <= 134)
					{
						float num81 = dust.scale;
						if (num81 > 1f)
						{
							num81 = 1f;
						}
						if (dust.type == 130)
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num81 * 1f, num81 * 0.5f, num81 * 0.4f);
						}
						if (dust.type == 131)
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num81 * 0.4f, num81 * 1f, num81 * 0.6f);
						}
						if (dust.type == 132)
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num81 * 0.3f, num81 * 0.5f, num81 * 1f);
						}
						if (dust.type == 133)
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num81 * 0.9f, num81 * 0.9f, num81 * 0.3f);
						}
						if (dust.noGravity)
						{
							dust.velocity *= 0.93f;
							if (dust.fadeIn == 0f)
							{
								dust.scale += 0.0025f;
							}
						}
						else if (dust.type == 131)
						{
							dust.velocity *= 0.98f;
							dust.velocity.Y -= 0.1f;
							dust.scale += 0.0025f;
						}
						else
						{
							dust.velocity *= 0.95f;
							dust.scale -= 0.0025f;
						}
					}
					else if (dust.type >= 219 && dust.type <= 223)
					{
						float num82 = dust.scale;
						if (num82 > 1f)
						{
							num82 = 1f;
						}
						if (dust.type == 219)
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num82 * 1f, num82 * 0.5f, num82 * 0.4f);
						}
						if (dust.type == 220)
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num82 * 0.4f, num82 * 1f, num82 * 0.6f);
						}
						if (dust.type == 221)
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num82 * 0.3f, num82 * 0.5f, num82 * 1f);
						}
						if (dust.type == 222)
						{
							Lighting.addLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num82 * 0.9f, num82 * 0.9f, num82 * 0.3f);
						}
						if (dust.noGravity)
						{
							dust.velocity *= 0.93f;
							if (dust.fadeIn == 0f)
							{
								dust.scale += 0.0025f;
							}
						}
						dust.velocity *= new Vector2(0.97f, 0.99f);
						dust.scale -= 0.0025f;
					}
					else if (dust.noGravity)
					{
						dust.velocity *= 0.92f;
						if (dust.fadeIn == 0f)
						{
							dust.scale -= 0.04f;
						}
					}
					if (dust.position.Y > Main.screenPosition.Y + (float)Main.screenHeight)
					{
						dust.active = false;
					}
					float num83 = 0.1f;
					if ((double)dCount == 0.5)
					{
						dust.scale -= 0.001f;
					}
					if ((double)dCount == 0.6)
					{
						dust.scale -= 0.0025f;
					}
					if ((double)dCount == 0.7)
					{
						dust.scale -= 0.005f;
					}
					if ((double)dCount == 0.8)
					{
						dust.scale -= 0.01f;
					}
					if ((double)dCount == 0.9)
					{
						dust.scale -= 0.02f;
					}
					if ((double)dCount == 0.5)
					{
						num83 = 0.11f;
					}
					if ((double)dCount == 0.6)
					{
						num83 = 0.13f;
					}
					if ((double)dCount == 0.7)
					{
						num83 = 0.16f;
					}
					if ((double)dCount == 0.8)
					{
						num83 = 0.22f;
					}
					if ((double)dCount == 0.9)
					{
						num83 = 0.25f;
					}
					if (dust.scale < num83)
					{
						dust.active = false;
					}
				}
				else
				{
					dust.active = false;
				}
			}
			int num84 = num;
			if ((double)num84 > (double)Main.numDust * 0.9)
			{
				dCount = 0.9f;
			}
			else if ((double)num84 > (double)Main.numDust * 0.8)
			{
				dCount = 0.8f;
			}
			else if ((double)num84 > (double)Main.numDust * 0.7)
			{
				dCount = 0.7f;
			}
			else if ((double)num84 > (double)Main.numDust * 0.6)
			{
				dCount = 0.6f;
			}
			else if ((double)num84 > (double)Main.numDust * 0.5)
			{
				dCount = 0.5f;
			}
			else
			{
				dCount = 0f;
			}
		}

		public Color GetAlpha(Color newColor)
		{
			float num = (float)(255 - alpha) / 255f;
			if (type >= 86 && type <= 91 && !noLight)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 213)
			{
				int num2 = (int)(scale / 2.5f * 255f);
				return new Color(num2, num2, num2, num2);
			}
			if (type == 64 && alpha == 255 && noLight)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 197)
			{
				return new Color(250, 250, 250, 150);
			}
			if (type >= 110 && type <= 114)
			{
				return new Color(200, 200, 200, 0);
			}
			if (type == 204)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 181)
			{
				return new Color(200, 200, 200, 0);
			}
			if (type == 182 || type == 206)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 159)
			{
				return new Color(250, 250, 250, 50);
			}
			if (type == 163 || type == 205)
			{
				return new Color(250, 250, 250, 0);
			}
			if (type == 170)
			{
				return new Color(200, 200, 200, 100);
			}
			if (type == 180)
			{
				return new Color(200, 200, 200, 0);
			}
			if (type == 175)
			{
				return new Color(200, 200, 200, 0);
			}
			if (type == 183)
			{
				return new Color(50, 0, 0, 0);
			}
			if (type == 172)
			{
				return new Color(250, 250, 250, 150);
			}
			if (type == 160 || type == 162 || type == 164 || type == 173)
			{
				int num3 = (int)(250f * scale);
				return new Color(num3, num3, num3, 0);
			}
			if (type == 92 || type == 106 || type == 107)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 185)
			{
				return new Color(200, 200, 255, 125);
			}
			if (type == 127 || type == 187)
			{
				return new Color(newColor.R, newColor.G, newColor.B, 25);
			}
			if (type == 156)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 6 || type == 174 || type == 135 || type == 75 || type == 20 || type == 21 || type == 169 || (type >= 130 && type <= 134) || type == 158)
			{
				return new Color(newColor.R, newColor.G, newColor.B, 25);
			}
			if (type >= 219 && type <= 223)
			{
				newColor = Color.Lerp(newColor, Color.White, 0.5f);
				return new Color(newColor.R, newColor.G, newColor.B, 25);
			}
			if ((type == 68 || type == 70) && noGravity)
			{
				return new Color(255, 255, 255, 0);
			}
			int num4;
			int num5;
			int num6;
			if (type == 157)
			{
				num4 = (num5 = (num6 = 255));
				float num7 = (float)(int)Main.mouseTextColor / 100f - 1.6f;
				num4 = (int)((float)num4 * num7);
				num5 = (int)((float)num5 * num7);
				num6 = (int)((float)num6 * num7);
				int a = (int)(100f * num7);
				num4 += 50;
				if (num4 > 255)
				{
					num4 = 255;
				}
				num5 += 50;
				if (num5 > 255)
				{
					num5 = 255;
				}
				num6 += 50;
				if (num6 > 255)
				{
					num6 = 255;
				}
				return new Color(num4, num5, num6, a);
			}
			if (type == 15 || type == 20 || type == 21 || type == 29 || type == 35 || type == 41 || type == 44 || type == 27 || type == 45 || type == 55 || type == 56 || type == 57 || type == 58 || type == 73 || type == 74)
			{
				num = (num + 3f) / 4f;
			}
			else if (type == 43)
			{
				num = (num + 9f) / 10f;
			}
			else
			{
				if (type == 66)
				{
					return new Color(newColor.R, newColor.G, newColor.B, 0);
				}
				if (type == 71)
				{
					return new Color(200, 200, 200, 0);
				}
				if (type == 72)
				{
					return new Color(200, 200, 200, 200);
				}
			}
			num4 = (int)((float)(int)newColor.R * num);
			num5 = (int)((float)(int)newColor.G * num);
			num6 = (int)((float)(int)newColor.B * num);
			int num8 = newColor.A - alpha;
			if (num8 < 0)
			{
				num8 = 0;
			}
			if (num8 > 255)
			{
				num8 = 255;
			}
			return new Color(num4, num5, num6, num8);
		}

		public Color GetColor(Color newColor)
		{
			int num = color.R - (255 - newColor.R);
			int num2 = color.G - (255 - newColor.G);
			int num3 = color.B - (255 - newColor.B);
			int num4 = color.A - (255 - newColor.A);
			if (num < 0)
			{
				num = 0;
			}
			if (num > 255)
			{
				num = 255;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (num4 > 255)
			{
				num4 = 255;
			}
			return new Color(num, num2, num3, num4);
		}
	}
}
