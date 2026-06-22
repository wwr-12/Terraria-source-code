using System;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.Graphics.Shaders;
using Terraria.Utilities;

namespace Terraria
{
	public class Dust
	{
		public static float dCount;

		public static int lavaBubbles;

		public static int SandStormCount;

		public int dustIndex;

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

		public ArmorShaderData shader;

		public object customData;

		public bool firstFrame;

		public static Dust NewDustPerfect(Vector2 Position, int Type, Vector2? Velocity = null, int Alpha = 0, Color newColor = default(Color), float Scale = 1f)
		{
			Dust dust = Main.dust[NewDust(Position, 0, 0, Type, 0f, 0f, Alpha, newColor, Scale)];
			dust.position = Position;
			if (Velocity.HasValue)
			{
				dust.velocity = Velocity.Value;
			}
			return dust;
		}

		public static Dust NewDustDirect(Vector2 Position, int Width, int Height, int Type, float SpeedX = 0f, float SpeedY = 0f, int Alpha = 0, Color newColor = default(Color), float Scale = 1f)
		{
			Dust dust = Main.dust[NewDust(Position, Width, Height, Type, SpeedX, SpeedY, Alpha, newColor, Scale)];
			if (dust.velocity.HasNaNs())
			{
				dust.velocity = Vector2.Zero;
			}
			return dust;
		}

		public static int NewDust(Vector2 Position, int Width, int Height, int Type, float SpeedX = 0f, float SpeedY = 0f, int Alpha = 0, Color newColor = default(Color), float Scale = 1f)
		{
			if (Main.gameMenu)
			{
				return 6000;
			}
			if (Main.rand == null)
			{
				Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
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
				if ((double)i > (double)Main.maxDustToDraw * 0.9)
				{
					if (Main.rand.Next(4) != 0)
					{
						return 5999;
					}
				}
				else if ((double)i > (double)Main.maxDustToDraw * 0.8)
				{
					if (Main.rand.Next(3) != 0)
					{
						return 5999;
					}
				}
				else if ((double)i > (double)Main.maxDustToDraw * 0.7)
				{
					if (Main.rand.Next(2) == 0)
					{
						return 5999;
					}
				}
				else if ((double)i > (double)Main.maxDustToDraw * 0.6)
				{
					if (Main.rand.Next(4) == 0)
					{
						return 5999;
					}
				}
				else if ((double)i > (double)Main.maxDustToDraw * 0.5)
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
				dust.shader = null;
				dust.customData = null;
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
				dust.firstFrame = true;
				if (dust.type == 228 || dust.type == 269 || dust.type == 135 || dust.type == 6 || dust.type == 242 || dust.type == 75 || dust.type == 169 || dust.type == 29 || (dust.type >= 59 && dust.type <= 65) || dust.type == 158)
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
				if (dust.type == 33 || dust.type == 52 || dust.type == 266 || dust.type == 98 || dust.type == 99 || dust.type == 100 || dust.type == 101 || dust.type == 102 || dust.type == 103 || dust.type == 104 || dust.type == 105)
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

		public static Dust CloneDust(int dustIndex)
		{
			return CloneDust(Main.dust[dustIndex]);
		}

		public static Dust CloneDust(Dust rf)
		{
			if (rf.dustIndex == Main.maxDustToDraw)
			{
				return rf;
			}
			int num = NewDust(rf.position, 0, 0, rf.type);
			Dust obj = Main.dust[num];
			obj.position = rf.position;
			obj.velocity = rf.velocity;
			obj.fadeIn = rf.fadeIn;
			obj.noGravity = rf.noGravity;
			obj.scale = rf.scale;
			obj.rotation = rf.rotation;
			obj.noLight = rf.noLight;
			obj.active = rf.active;
			obj.type = rf.type;
			obj.color = rf.color;
			obj.alpha = rf.alpha;
			obj.frame = rf.frame;
			obj.shader = rf.shader;
			obj.customData = rf.customData;
			return obj;
		}

		public static Dust QuickDust(Point tileCoords, Color color)
		{
			return QuickDust(tileCoords.ToWorldCoordinates(), color);
		}

		public static void QuickBox(Vector2 topLeft, Vector2 bottomRight, int divisions, Color color, Action<Dust> manipulator)
		{
			float num = divisions + 2;
			for (float num2 = 0f; num2 <= (float)(divisions + 2); num2 += 1f)
			{
				Dust obj = QuickDust(new Vector2(MathHelper.Lerp(topLeft.X, bottomRight.X, num2 / num), topLeft.Y), color);
				manipulator?.Invoke(obj);
				obj = QuickDust(new Vector2(MathHelper.Lerp(topLeft.X, bottomRight.X, num2 / num), bottomRight.Y), color);
				manipulator?.Invoke(obj);
				obj = QuickDust(new Vector2(topLeft.X, MathHelper.Lerp(topLeft.Y, bottomRight.Y, num2 / num)), color);
				manipulator?.Invoke(obj);
				obj = QuickDust(new Vector2(bottomRight.X, MathHelper.Lerp(topLeft.Y, bottomRight.Y, num2 / num)), color);
				manipulator?.Invoke(obj);
			}
		}

		public static Dust QuickDust(Vector2 pos, Color color)
		{
			Dust obj = Main.dust[NewDust(pos, 0, 0, 267)];
			obj.position = pos;
			obj.velocity = Vector2.Zero;
			obj.fadeIn = 1f;
			obj.noLight = true;
			obj.noGravity = true;
			obj.color = color;
			return obj;
		}

		public static void QuickDustLine(Vector2 start, Vector2 end, float splits, Color color)
		{
			QuickDust(start, color).scale = 2f;
			QuickDust(end, color).scale = 2f;
			float num = 1f / splits;
			for (float num2 = 0f; num2 < 1f; num2 += num)
			{
				QuickDust(Vector2.Lerp(start, end, num2), color).scale = 2f;
			}
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
			SandStormCount = 0;
			bool flag = Sandstorm.Happening && Main.player[Main.myPlayer].ZoneSandstorm && (Main.bgStyle == 2 || Main.bgStyle == 5) && Main.bgDelay < 50;
			for (int i = 0; i < 6000; i++)
			{
				Dust dust = Main.dust[i];
				if (i < Main.maxDustToDraw)
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
					if (dust.firstFrame && !ChildSafety.Disabled && ChildSafety.DangerousDust(dust.type))
					{
						if (Main.rand.Next(2) == 0)
						{
							dust.firstFrame = false;
							dust.type = 16;
							dust.scale = Main.rand.NextFloat() * 1.6f + 0.3f;
							dust.color = Color.Transparent;
							dust.frame.X = 10 * dust.type;
							dust.frame.Y = 10 * Main.rand.Next(3);
							dust.shader = null;
							dust.customData = null;
							int num2 = dust.type / 100;
							dust.frame.X -= 1000 * num2;
							dust.frame.Y += 30 * num2;
							dust.noGravity = true;
						}
						else
						{
							dust.active = false;
						}
					}
					if (dust.type == 35)
					{
						lavaBubbles++;
					}
					dust.position += dust.velocity;
					if (dust.type == 258)
					{
						dust.noGravity = true;
						dust.scale += 0.015f;
					}
					if (dust.type >= 86 && dust.type <= 92 && !dust.noLight)
					{
						float num3 = dust.scale * 0.6f;
						if (num3 > 1f)
						{
							num3 = 1f;
						}
						int num4 = dust.type - 85;
						float num5 = num3;
						float num6 = num3;
						float num7 = num3;
						switch (num4)
						{
						case 3:
							num5 *= 0f;
							num6 *= 0.1f;
							num7 *= 1.3f;
							break;
						case 5:
							num5 *= 1f;
							num6 *= 0.1f;
							num7 *= 0.1f;
							break;
						case 4:
							num5 *= 0f;
							num6 *= 1f;
							num7 *= 0.1f;
							break;
						case 1:
							num5 *= 0.9f;
							num6 *= 0f;
							num7 *= 0.9f;
							break;
						case 6:
							num5 *= 1.3f;
							num6 *= 1.3f;
							num7 *= 1.3f;
							break;
						case 2:
							num5 *= 0.9f;
							num6 *= 0.9f;
							num7 *= 0f;
							break;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num3 * num5, num3 * num6, num3 * num7);
					}
					if (dust.type >= 86 && dust.type <= 92)
					{
						if (dust.customData != null && dust.customData is Player)
						{
							Player player = (Player)dust.customData;
							dust.position += player.position - player.oldPosition;
						}
						else if (dust.customData != null && dust.customData is Projectile)
						{
							Projectile projectile = (Projectile)dust.customData;
							if (projectile.active)
							{
								dust.position += projectile.position - projectile.oldPosition;
							}
						}
					}
					if (dust.type == 262 && !dust.noLight)
					{
						Vector3 rgb = new Vector3(0.9f, 0.6f, 0f) * dust.scale * 0.6f;
						Lighting.AddLight(dust.position, rgb);
					}
					if (dust.type == 240 && dust.customData != null && dust.customData is Projectile)
					{
						Projectile projectile2 = (Projectile)dust.customData;
						if (projectile2.active)
						{
							dust.position += projectile2.position - projectile2.oldPosition;
						}
					}
					if ((dust.type == 259 || dust.type == 6 || dust.type == 158) && dust.customData != null && dust.customData is int)
					{
						if ((int)dust.customData == 0)
						{
							if (Collision.SolidCollision(dust.position - Vector2.One * 5f, 10, 10) && dust.fadeIn == 0f)
							{
								dust.scale *= 0.9f;
								dust.velocity *= 0.25f;
							}
						}
						else if ((int)dust.customData == 1)
						{
							dust.scale *= 0.98f;
							dust.velocity.Y *= 0.98f;
							if (Collision.SolidCollision(dust.position - Vector2.One * 5f, 10, 10) && dust.fadeIn == 0f)
							{
								dust.scale *= 0.9f;
								dust.velocity *= 0.25f;
							}
						}
					}
					if (dust.type == 263 || dust.type == 264)
					{
						if (!dust.noLight)
						{
							Vector3 rgb2 = dust.color.ToVector3() * dust.scale * 0.4f;
							Lighting.AddLight(dust.position, rgb2);
						}
						if (dust.customData != null && dust.customData is Player)
						{
							Player player2 = (Player)dust.customData;
							dust.position += player2.position - player2.oldPosition;
							dust.customData = null;
						}
						else if (dust.customData != null && dust.customData is Projectile)
						{
							Projectile projectile3 = (Projectile)dust.customData;
							dust.position += projectile3.position - projectile3.oldPosition;
						}
					}
					if (dust.type == 230)
					{
						float num8 = dust.scale * 0.6f;
						float num9 = num8;
						float num10 = num8;
						float num11 = num8;
						num9 *= 0.5f;
						num10 *= 0.9f;
						num11 *= 1f;
						dust.scale += 0.02f;
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num8 * num9, num8 * num10, num8 * num11);
						if (dust.customData != null && dust.customData is Player)
						{
							Vector2 center = ((Player)dust.customData).Center;
							Vector2 vector = dust.position - center;
							float num12 = vector.Length();
							vector /= num12;
							dust.scale = Math.Min(dust.scale, num12 / 24f - 1f);
							dust.velocity -= vector * (100f / Math.Max(50f, num12));
						}
					}
					if (dust.type == 154 || dust.type == 218)
					{
						dust.rotation += dust.velocity.X * 0.3f;
						dust.scale -= 0.03f;
					}
					if (dust.type == 172)
					{
						float num13 = dust.scale * 0.5f;
						if (num13 > 1f)
						{
							num13 = 1f;
						}
						float num14 = num13;
						float num15 = num13;
						float num16 = num13;
						num14 *= 0f;
						num15 *= 0.25f;
						num16 *= 1f;
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num13 * num14, num13 * num15, num13 * num16);
					}
					if (dust.type == 182)
					{
						dust.rotation += 1f;
						if (!dust.noLight)
						{
							float num17 = dust.scale * 0.25f;
							if (num17 > 1f)
							{
								num17 = 1f;
							}
							float num18 = num17;
							float num19 = num17;
							float num20 = num17;
							num18 *= 1f;
							num19 *= 0.2f;
							num20 *= 0.1f;
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num17 * num18, num17 * num19, num17 * num20);
						}
						if (dust.customData != null && dust.customData is Player)
						{
							Player player3 = (Player)dust.customData;
							dust.position += player3.position - player3.oldPosition;
							dust.customData = null;
						}
					}
					if (dust.type == 261)
					{
						if (!dust.noLight)
						{
							float num21 = dust.scale * 0.3f;
							if (num21 > 1f)
							{
								num21 = 1f;
							}
							Lighting.AddLight(dust.position, new Vector3(0.4f, 0.6f, 0.7f) * num21);
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
						if (dust.customData != null && dust.customData is Player)
						{
							Player player4 = (Player)dust.customData;
							dust.position += player4.position - player4.oldPosition;
						}
					}
					if (dust.type == 254)
					{
						float num22 = dust.scale * 0.35f;
						if (num22 > 1f)
						{
							num22 = 1f;
						}
						float num23 = num22;
						float num24 = num22;
						float num25 = num22;
						num23 *= 0.9f;
						num24 *= 0.1f;
						num25 *= 0.75f;
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num22 * num23, num22 * num24, num22 * num25);
					}
					if (dust.type == 255)
					{
						float num26 = dust.scale * 0.25f;
						if (num26 > 1f)
						{
							num26 = 1f;
						}
						float num27 = num26;
						float num28 = num26;
						float num29 = num26;
						num27 *= 0.9f;
						num28 *= 0.1f;
						num29 *= 0.75f;
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num26 * num27, num26 * num28, num26 * num29);
					}
					if (dust.type == 211 && dust.noLight && Collision.SolidCollision(dust.position, 4, 4))
					{
						dust.active = false;
					}
					if (dust.type == 213 || dust.type == 260)
					{
						dust.rotation = 0f;
						float num30 = dust.scale / 2.5f * 0.2f;
						Vector3 vector2 = Vector3.Zero;
						switch (dust.type)
						{
						case 213:
							vector2 = new Vector3(255f, 217f, 48f);
							break;
						case 260:
							vector2 = new Vector3(255f, 48f, 48f);
							break;
						}
						vector2 /= 255f;
						if (num30 > 1f)
						{
							num30 = 1f;
						}
						vector2 *= num30;
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), vector2.X, vector2.Y, vector2.Z);
					}
					if (dust.type == 157)
					{
						float num31 = dust.scale * 0.2f;
						float num32 = num31;
						float num33 = num31;
						float num34 = num31;
						num32 *= 0.25f;
						num33 *= 1f;
						num34 *= 0.5f;
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num31 * num32, num31 * num33, num31 * num34);
					}
					if (dust.type == 206)
					{
						dust.scale -= 0.1f;
						float num35 = dust.scale * 0.4f;
						float num36 = num35;
						float num37 = num35;
						float num38 = num35;
						num36 *= 0.1f;
						num37 *= 0.6f;
						num38 *= 1f;
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num35 * num36, num35 * num37, num35 * num38);
					}
					if (dust.type == 163)
					{
						float num39 = dust.scale * 0.25f;
						float num40 = num39;
						float num41 = num39;
						float num42 = num39;
						num40 *= 0.25f;
						num41 *= 1f;
						num42 *= 0.05f;
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num39 * num40, num39 * num41, num39 * num42);
					}
					if (dust.type == 205)
					{
						float num43 = dust.scale * 0.25f;
						float num44 = num43;
						float num45 = num43;
						float num46 = num43;
						num44 *= 1f;
						num45 *= 0.05f;
						num46 *= 1f;
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num43 * num44, num43 * num45, num43 * num46);
					}
					if (dust.type == 170)
					{
						float num47 = dust.scale * 0.5f;
						float num48 = num47;
						float num49 = num47;
						float num50 = num47;
						num48 *= 1f;
						num49 *= 1f;
						num50 *= 0.05f;
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num47 * num48, num47 * num49, num47 * num50);
					}
					if (dust.type == 156)
					{
						float num51 = dust.scale * 0.6f;
						_ = dust.type;
						float num52 = num51;
						float num53 = num51;
						float num54 = num51;
						num52 *= 0.5f;
						num53 *= 0.9f;
						num54 *= 1f;
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num51 * num52, num51 * num53, num51 * num54);
					}
					if (dust.type == 234)
					{
						float num55 = dust.scale * 0.6f;
						_ = dust.type;
						float num56 = num55;
						float num57 = num55;
						float num58 = num55;
						num56 *= 0.95f;
						num57 *= 0.65f;
						num58 *= 1.3f;
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num55 * num56, num55 * num57, num55 * num58);
					}
					if (dust.type == 175)
					{
						dust.scale -= 0.05f;
					}
					if (dust.type == 174)
					{
						dust.scale -= 0.01f;
						float num59 = dust.scale * 1f;
						if (num59 > 0.6f)
						{
							num59 = 0.6f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num59, num59 * 0.4f, 0f);
					}
					if (dust.type == 235)
					{
						Vector2 vector3 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
						vector3.Normalize();
						vector3 *= 15f;
						dust.scale -= 0.01f;
					}
					else if (dust.type == 228 || dust.type == 229 || dust.type == 6 || dust.type == 242 || dust.type == 135 || dust.type == 127 || dust.type == 187 || dust.type == 75 || dust.type == 169 || dust.type == 29 || (dust.type >= 59 && dust.type <= 65) || dust.type == 158)
					{
						if (!dust.noGravity)
						{
							dust.velocity.Y += 0.05f;
						}
						if (dust.type == 229 || dust.type == 228)
						{
							if (dust.customData != null && dust.customData is NPC)
							{
								NPC nPC = (NPC)dust.customData;
								dust.position += nPC.position - nPC.oldPos[1];
							}
							else if (dust.customData != null && dust.customData is Player)
							{
								Player player5 = (Player)dust.customData;
								dust.position += player5.position - player5.oldPosition;
							}
							else if (dust.customData != null && dust.customData is Vector2)
							{
								Vector2 vector4 = (Vector2)dust.customData - dust.position;
								if (vector4 != Vector2.Zero)
								{
									vector4.Normalize();
								}
								dust.velocity = (dust.velocity * 4f + vector4 * dust.velocity.Length()) / 5f;
							}
						}
						if (!dust.noLight)
						{
							float num60 = dust.scale * 1.4f;
							if (dust.type == 29)
							{
								if (num60 > 1f)
								{
									num60 = 1f;
								}
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num60 * 0.1f, num60 * 0.4f, num60);
							}
							else if (dust.type == 75)
							{
								if (num60 > 1f)
								{
									num60 = 1f;
								}
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num60 * 0.7f, num60, num60 * 0.2f);
							}
							else if (dust.type == 169)
							{
								if (num60 > 1f)
								{
									num60 = 1f;
								}
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num60 * 1.1f, num60 * 1.1f, num60 * 0.2f);
							}
							else if (dust.type == 135)
							{
								if (num60 > 1f)
								{
									num60 = 1f;
								}
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num60 * 0.2f, num60 * 0.7f, num60);
							}
							else if (dust.type == 158)
							{
								if (num60 > 1f)
								{
									num60 = 1f;
								}
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num60 * 1f, num60 * 0.5f, 0f);
							}
							else if (dust.type == 228)
							{
								if (num60 > 1f)
								{
									num60 = 1f;
								}
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num60 * 0.7f, num60 * 0.65f, num60 * 0.3f);
							}
							else if (dust.type == 229)
							{
								if (num60 > 1f)
								{
									num60 = 1f;
								}
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num60 * 0.3f, num60 * 0.65f, num60 * 0.7f);
							}
							else if (dust.type == 242)
							{
								if (num60 > 1f)
								{
									num60 = 1f;
								}
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num60, 0f, num60);
							}
							else if (dust.type >= 59 && dust.type <= 65)
							{
								if (num60 > 0.8f)
								{
									num60 = 0.8f;
								}
								int num61 = dust.type - 58;
								float num62 = 1f;
								float num63 = 1f;
								float num64 = 1f;
								switch (num61)
								{
								case 1:
									num62 = 0f;
									num63 = 0.1f;
									num64 = 1.3f;
									break;
								case 2:
									num62 = 1f;
									num63 = 0.1f;
									num64 = 0.1f;
									break;
								case 3:
									num62 = 0f;
									num63 = 1f;
									num64 = 0.1f;
									break;
								case 4:
									num62 = 0.9f;
									num63 = 0f;
									num64 = 0.9f;
									break;
								case 5:
									num62 = 1.3f;
									num63 = 1.3f;
									num64 = 1.3f;
									break;
								case 6:
									num62 = 0.9f;
									num63 = 0.9f;
									num64 = 0f;
									break;
								case 7:
									num62 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
									num63 = 0.3f;
									num64 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
									break;
								}
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num60 * num62, num60 * num63, num60 * num64);
							}
							else if (dust.type == 127)
							{
								num60 *= 1.3f;
								if (num60 > 1f)
								{
									num60 = 1f;
								}
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num60, num60 * 0.45f, num60 * 0.2f);
							}
							else if (dust.type == 187)
							{
								num60 *= 1.3f;
								if (num60 > 1f)
								{
									num60 = 1f;
								}
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num60 * 0.2f, num60 * 0.45f, num60);
							}
							else
							{
								if (num60 > 0.6f)
								{
									num60 = 0.6f;
								}
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num60, num60 * 0.65f, num60 * 0.4f);
							}
						}
					}
					else if (dust.type == 269)
					{
						if (!dust.noLight)
						{
							float num65 = dust.scale * 1.4f;
							if (num65 > 1f)
							{
								num65 = 1f;
							}
							Lighting.AddLight(rgb: new Vector3(0.7f, 0.65f, 0.3f) * num65, position: dust.position);
						}
						if (dust.customData != null && dust.customData is Vector2)
						{
							Vector2 vector5 = (Vector2)dust.customData - dust.position;
							dust.velocity.X += 1f * (float)Math.Sign(vector5.X) * dust.scale;
						}
					}
					else if (dust.type == 159)
					{
						float num66 = dust.scale * 1.3f;
						if (num66 > 1f)
						{
							num66 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num66, num66, num66 * 0.1f);
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
								int num67 = NewDust(dust.position, 4, 4, dust.type);
								Main.dust[num67].noGravity = true;
								Main.dust[num67].scale = dust.scale * 2.5f;
							}
						}
					}
					else if (dust.type == 164)
					{
						float num68 = dust.scale;
						if (num68 > 1f)
						{
							num68 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num68, num68 * 0.1f, num68 * 0.8f);
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
								int num69 = NewDust(dust.position, 4, 4, dust.type);
								Main.dust[num69].noGravity = true;
								Main.dust[num69].scale = dust.scale * 2.5f;
							}
						}
					}
					else if (dust.type == 173)
					{
						float num70 = dust.scale;
						if (num70 > 1f)
						{
							num70 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num70 * 0.4f, num70 * 0.1f, num70);
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
								int num71 = NewDust(dust.position, 4, 4, dust.type);
								Main.dust[num71].noGravity = true;
								Main.dust[num71].scale = dust.scale;
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
						float num72 = dust.scale * 1.3f;
						if (num72 > 1f)
						{
							num72 = 1f;
						}
						if (dust.type == 162)
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num72, num72 * 0.7f, num72 * 0.1f);
						}
						else
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num72 * 0.1f, num72, num72);
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
								int num73 = NewDust(new Vector2(dust.position.X - 4f, dust.position.Y - 4f), 1, 1, dust.type);
								Main.dust[num73].noGravity = true;
								Main.dust[num73].scale = dust.scale * 1.5f;
							}
						}
					}
					else if (dust.type == 168)
					{
						float num74 = dust.scale * 0.8f;
						if ((double)num74 > 0.55)
						{
							num74 = 0.55f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num74, 0f, num74 * 0.8f);
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
					else if (dust.type >= 244 && dust.type <= 247)
					{
						dust.rotation += 0.1f * dust.scale;
						Color color = Lighting.GetColor((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f));
						byte num75 = (byte)((color.R + color.G + color.B) / 3);
						float num76 = ((float)(int)num75 / 270f + 1f) / 2f;
						float num77 = ((float)(int)num75 / 270f + 1f) / 2f;
						float num78 = ((float)(int)num75 / 270f + 1f) / 2f;
						num76 *= dust.scale * 0.9f;
						num77 *= dust.scale * 0.9f;
						num78 *= dust.scale * 0.9f;
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
						float num79 = 1f;
						if (dust.type == 244)
						{
							num76 *= 0.8862745f;
							num77 *= 0.4627451f;
							num78 *= 0.29803923f;
							num79 = 0.9f;
						}
						else if (dust.type == 245)
						{
							num76 *= 0.5137255f;
							num77 *= 0.6745098f;
							num78 *= 0.6784314f;
							num79 = 1f;
						}
						else if (dust.type == 246)
						{
							num76 *= 0.8f;
							num77 *= 0.70980394f;
							num78 *= 24f / 85f;
							num79 = 1.1f;
						}
						else if (dust.type == 247)
						{
							num76 *= 0.6f;
							num77 *= 0.6745098f;
							num78 *= 37f / 51f;
							num79 = 1.2f;
						}
						num76 *= num79;
						num77 *= num79;
						num78 *= num79;
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num76, num77, num78);
					}
					else if (dust.type == 43)
					{
						dust.rotation += 0.1f * dust.scale;
						Color color2 = Lighting.GetColor((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f));
						float num80 = (float)(int)color2.R / 270f;
						float num81 = (float)(int)color2.G / 270f;
						float num82 = (float)(int)color2.B / 270f;
						float num83 = dust.color.R / 255;
						float num84 = dust.color.G / 255;
						float num85 = dust.color.B / 255;
						num80 *= dust.scale * 1.07f * num83;
						num81 *= dust.scale * 1.07f * num84;
						num82 *= dust.scale * 1.07f * num85;
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
						if ((double)num80 < 0.05 && (double)num81 < 0.05 && (double)num82 < 0.05)
						{
							dust.active = false;
						}
						else
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num80, num81, num82);
						}
					}
					else if (dust.type == 15 || dust.type == 57 || dust.type == 58 || dust.type == 274)
					{
						dust.velocity.Y *= 0.98f;
						dust.velocity.X *= 0.98f;
						float num86 = dust.scale;
						if (dust.type != 15)
						{
							num86 = dust.scale * 0.8f;
						}
						if (dust.noLight)
						{
							dust.velocity *= 0.95f;
						}
						if (num86 > 1f)
						{
							num86 = 1f;
						}
						if (dust.type == 15)
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num86 * 0.45f, num86 * 0.55f, num86);
						}
						else if (dust.type == 57)
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num86 * 0.95f, num86 * 0.95f, num86 * 0.45f);
						}
						else if (dust.type == 58)
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num86, num86 * 0.55f, num86 * 0.75f);
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
						float num87 = dust.scale * 0.1f;
						if (num87 > 1f)
						{
							num87 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num87 * 0.2f, num87, num87 * 0.5f);
					}
					else if (dust.type == 111)
					{
						float num88 = dust.scale * 0.125f;
						if (num88 > 1f)
						{
							num88 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num88 * 0.2f, num88 * 0.7f, num88);
					}
					else if (dust.type == 112)
					{
						float num89 = dust.scale * 0.1f;
						if (num89 > 1f)
						{
							num89 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num89 * 0.8f, num89 * 0.2f, num89 * 0.8f);
					}
					else if (dust.type == 113)
					{
						float num90 = dust.scale * 0.1f;
						if (num90 > 1f)
						{
							num90 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num90 * 0.2f, num90 * 0.3f, num90 * 1.3f);
					}
					else if (dust.type == 114)
					{
						float num91 = dust.scale * 0.1f;
						if (num91 > 1f)
						{
							num91 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num91 * 1.2f, num91 * 0.5f, num91 * 0.4f);
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
						float num92 = dust.scale;
						if (dust.type != 15)
						{
							num92 = dust.scale * 0.8f;
						}
						if (num92 > 1f)
						{
							num92 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num92 * ((float)(int)dust.color.R / 255f), num92 * ((float)(int)dust.color.G / 255f), num92 * ((float)(int)dust.color.B / 255f));
					}
					else if (dust.type == 267)
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
						float num93 = dust.scale * 0.8f;
						if (num93 > 1f)
						{
							num93 = 1f;
						}
						if (dust.noLight)
						{
							dust.noLight = false;
						}
						if (!dust.noLight)
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num93 * ((float)(int)dust.color.R / 255f), num93 * ((float)(int)dust.color.G / 255f), num93 * ((float)(int)dust.color.B / 255f));
						}
					}
					else if (dust.type == 20 || dust.type == 21 || dust.type == 231)
					{
						dust.scale += 0.005f;
						dust.velocity.Y *= 0.94f;
						dust.velocity.X *= 0.94f;
						float num94 = dust.scale * 0.8f;
						if (num94 > 1f)
						{
							num94 = 1f;
						}
						if (dust.type == 21)
						{
							num94 = dust.scale * 0.4f;
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num94 * 0.8f, num94 * 0.3f, num94);
						}
						else if (dust.type == 231)
						{
							num94 = dust.scale * 0.4f;
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num94, num94 * 0.5f, num94 * 0.3f);
						}
						else
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num94 * 0.3f, num94 * 0.6f, num94);
						}
					}
					else if (dust.type == 27 || dust.type == 45)
					{
						if (dust.type == 27 && dust.fadeIn >= 100f)
						{
							if ((double)dust.scale >= 1.5)
							{
								dust.scale -= 0.01f;
							}
							else
							{
								dust.scale -= 0.05f;
							}
							if ((double)dust.scale <= 0.5)
							{
								dust.scale -= 0.05f;
							}
							if ((double)dust.scale <= 0.25)
							{
								dust.scale -= 0.05f;
							}
						}
						dust.velocity *= 0.94f;
						dust.scale += 0.002f;
						float num95 = dust.scale;
						if (dust.noLight)
						{
							num95 *= 0.1f;
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
						if (num95 > 1f)
						{
							num95 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num95 * 0.6f, num95 * 0.2f, num95);
					}
					else if (dust.type == 55 || dust.type == 56 || dust.type == 73 || dust.type == 74)
					{
						dust.velocity *= 0.98f;
						float num96 = dust.scale * 0.8f;
						if (dust.type == 55)
						{
							if (num96 > 1f)
							{
								num96 = 1f;
							}
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num96, num96, num96 * 0.6f);
						}
						else if (dust.type == 73)
						{
							if (num96 > 1f)
							{
								num96 = 1f;
							}
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num96, num96 * 0.35f, num96 * 0.5f);
						}
						else if (dust.type == 74)
						{
							if (num96 > 1f)
							{
								num96 = 1f;
							}
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num96 * 0.35f, num96, num96 * 0.5f);
						}
						else
						{
							num96 = dust.scale * 1.2f;
							if (num96 > 1f)
							{
								num96 = 1f;
							}
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num96 * 0.35f, num96 * 0.5f, num96);
						}
					}
					else if (dust.type == 71 || dust.type == 72)
					{
						dust.velocity *= 0.98f;
						float num97 = dust.scale;
						if (num97 > 1f)
						{
							num97 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num97 * 0.2f, 0f, num97 * 0.1f);
					}
					else if (dust.type == 76)
					{
						Main.snowDust++;
						dust.scale += 0.009f;
						float y = Main.player[Main.myPlayer].velocity.Y;
						if (y > 0f && dust.fadeIn == 0f && dust.velocity.Y < y)
						{
							dust.velocity.Y = MathHelper.Lerp(dust.velocity.Y, y, 0.04f);
						}
						if (!dust.noLight && y > 0f)
						{
							dust.position.Y += Main.player[Main.myPlayer].velocity.Y * 0.2f;
						}
						if (Collision.SolidCollision(dust.position - Vector2.One * 5f, 10, 10) && dust.fadeIn == 0f)
						{
							dust.scale *= 0.9f;
							dust.velocity *= 0.25f;
						}
					}
					else if (dust.type == 270)
					{
						dust.velocity *= 1.0050251f;
						dust.scale += 0.01f;
						dust.rotation = 0f;
						if (Collision.SolidCollision(dust.position - Vector2.One * 5f, 10, 10) && dust.fadeIn == 0f)
						{
							dust.scale *= 0.95f;
							dust.velocity *= 0.25f;
						}
						else
						{
							dust.velocity.Y = (float)Math.Sin(dust.position.X * 0.0043982295f) * 2f;
							dust.velocity.Y -= 3f;
							dust.velocity.Y /= 20f;
						}
					}
					else if (dust.type == 271)
					{
						dust.velocity *= 1.0050251f;
						dust.scale += 0.003f;
						dust.rotation = 0f;
						dust.velocity.Y -= 4f;
						dust.velocity.Y /= 6f;
					}
					else if (dust.type == 268)
					{
						SandStormCount++;
						dust.velocity *= 1.0050251f;
						dust.scale += 0.01f;
						if (!flag)
						{
							dust.scale -= 0.05f;
						}
						dust.rotation = 0f;
						float y2 = Main.player[Main.myPlayer].velocity.Y;
						if (y2 > 0f && dust.fadeIn == 0f && dust.velocity.Y < y2)
						{
							dust.velocity.Y = MathHelper.Lerp(dust.velocity.Y, y2, 0.04f);
						}
						if (!dust.noLight && y2 > 0f)
						{
							dust.position.Y += y2 * 0.2f;
						}
						if (Collision.SolidCollision(dust.position - Vector2.One * 5f, 10, 10) && dust.fadeIn == 0f)
						{
							dust.scale *= 0.9f;
							dust.velocity *= 0.25f;
						}
						else
						{
							dust.velocity.Y = (float)Math.Sin(dust.position.X * 0.0043982295f) * 2f;
							dust.velocity.Y += 3f;
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
					if (dust.type == 5 || (dust.type == 273 && dust.noGravity))
					{
						dust.scale -= 0.04f;
					}
					if (dust.type == 33 || dust.type == 52 || dust.type == 266 || dust.type == 98 || dust.type == 99 || dust.type == 100 || dust.type == 101 || dust.type == 102 || dust.type == 103 || dust.type == 104 || dust.type == 105 || dust.type == 123)
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
						float num98 = dust.scale * 0.6f;
						if (num98 > 1f)
						{
							num98 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f + 1f), num98, num98 * 0.3f, num98 * 0.1f);
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
						float num99 = dust.scale;
						if (num99 > 1f)
						{
							num99 = 1f;
						}
						if (dust.noLight)
						{
							num99 *= 0.1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), 0f, num99 * 0.8f, num99);
					}
					else if (dust.type == 185)
					{
						float num100 = dust.scale;
						if (num100 > 1f)
						{
							num100 = 1f;
						}
						if (dust.noLight)
						{
							num100 *= 0.1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num100 * 0.1f, num100 * 0.7f, num100);
					}
					else if (dust.type == 107)
					{
						float num101 = dust.scale * 0.5f;
						if (num101 > 1f)
						{
							num101 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num101 * 0.1f, num101, num101 * 0.4f);
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
							float num102 = dust.scale * 0.3f + 0.4f;
							if (num102 > 1f)
							{
								num102 = 1f;
							}
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num102, num102 * 0.5f, num102 * 0.3f);
						}
					}
					if (dust.type == 68)
					{
						float num103 = dust.scale * 0.3f;
						if (num103 > 1f)
						{
							num103 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num103 * 0.1f, num103 * 0.2f, num103);
					}
					if (dust.type == 70)
					{
						float num104 = dust.scale * 0.3f;
						if (num104 > 1f)
						{
							num104 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num104 * 0.5f, 0f, num104);
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
						float num105 = dust.scale * 0.7f;
						if (num105 > 1f)
						{
							num105 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num105 * 0.4f, num105 * 0.9f, num105);
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
						float num106 = dust.scale * 0.7f;
						if (num106 > 1f)
						{
							num106 = 1f;
						}
						Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num106 * 0.7f, num106, num106 * 0.8f);
					}
					else
					{
						dust.velocity.X *= 0.99f;
					}
					if (dust.type != 79 && dust.type != 268)
					{
						dust.rotation += dust.velocity.X * 0.5f;
					}
					if (dust.fadeIn > 0f && dust.fadeIn < 100f)
					{
						if (dust.type == 235)
						{
							dust.scale += 0.007f;
							int num107 = (int)dust.fadeIn - 1;
							if (num107 >= 0 && num107 <= 255)
							{
								Vector2 vector6 = dust.position - Main.player[num107].Center;
								float num108 = vector6.Length();
								num108 = 100f - num108;
								if (num108 > 0f)
								{
									dust.scale -= num108 * 0.0015f;
								}
								vector6.Normalize();
								float num109 = (1f - dust.scale) * 20f;
								vector6 *= 0f - num109;
								dust.velocity = (dust.velocity * 4f + vector6) / 5f;
							}
						}
						else if (dust.type == 46)
						{
							dust.scale += 0.1f;
						}
						else if (dust.type == 213 || dust.type == 260)
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
					else if (dust.type == 213 || dust.type == 260)
					{
						dust.scale -= 0.2f;
					}
					else
					{
						dust.scale -= 0.01f;
					}
					if (dust.type >= 130 && dust.type <= 134)
					{
						float num110 = dust.scale;
						if (num110 > 1f)
						{
							num110 = 1f;
						}
						if (dust.type == 130)
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num110 * 1f, num110 * 0.5f, num110 * 0.4f);
						}
						if (dust.type == 131)
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num110 * 0.4f, num110 * 1f, num110 * 0.6f);
						}
						if (dust.type == 132)
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num110 * 0.3f, num110 * 0.5f, num110 * 1f);
						}
						if (dust.type == 133)
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num110 * 0.9f, num110 * 0.9f, num110 * 0.3f);
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
						float num111 = dust.scale;
						if (num111 > 1f)
						{
							num111 = 1f;
						}
						if (!dust.noLight)
						{
							if (dust.type == 219)
							{
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num111 * 1f, num111 * 0.5f, num111 * 0.4f);
							}
							if (dust.type == 220)
							{
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num111 * 0.4f, num111 * 1f, num111 * 0.6f);
							}
							if (dust.type == 221)
							{
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num111 * 0.3f, num111 * 0.5f, num111 * 1f);
							}
							if (dust.type == 222)
							{
								Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num111 * 0.9f, num111 * 0.9f, num111 * 0.3f);
							}
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
						if (dust.customData != null && dust.customData is Player)
						{
							Player player6 = (Player)dust.customData;
							dust.position += player6.position - player6.oldPosition;
						}
					}
					else if (dust.type == 226)
					{
						float num112 = dust.scale;
						if (num112 > 1f)
						{
							num112 = 1f;
						}
						if (!dust.noLight)
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num112 * 0.2f, num112 * 0.7f, num112 * 1f);
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
						if (dust.customData != null && dust.customData is Player)
						{
							Player player7 = (Player)dust.customData;
							dust.position += player7.position - player7.oldPosition;
						}
						dust.scale -= 0.01f;
					}
					else if (dust.type == 272)
					{
						float num113 = dust.scale;
						if (num113 > 1f)
						{
							num113 = 1f;
						}
						if (!dust.noLight)
						{
							Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num113 * 0.5f, num113 * 0.2f, num113 * 0.8f);
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
						if (dust.customData != null && dust.customData is Player)
						{
							Player player8 = (Player)dust.customData;
							dust.position += player8.position - player8.oldPosition;
						}
						if (dust.customData != null && dust.customData is NPC)
						{
							NPC nPC2 = (NPC)dust.customData;
							dust.position += nPC2.position - nPC2.oldPosition;
						}
						dust.scale -= 0.01f;
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
					float num114 = 0.1f;
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
						num114 = 0.11f;
					}
					if ((double)dCount == 0.6)
					{
						num114 = 0.13f;
					}
					if ((double)dCount == 0.7)
					{
						num114 = 0.16f;
					}
					if ((double)dCount == 0.8)
					{
						num114 = 0.22f;
					}
					if ((double)dCount == 0.9)
					{
						num114 = 0.25f;
					}
					if (dust.scale < num114)
					{
						dust.active = false;
					}
				}
				else
				{
					dust.active = false;
				}
			}
			int num115 = num;
			if ((double)num115 > (double)Main.maxDustToDraw * 0.9)
			{
				dCount = 0.9f;
			}
			else if ((double)num115 > (double)Main.maxDustToDraw * 0.8)
			{
				dCount = 0.8f;
			}
			else if ((double)num115 > (double)Main.maxDustToDraw * 0.7)
			{
				dCount = 0.7f;
			}
			else if ((double)num115 > (double)Main.maxDustToDraw * 0.6)
			{
				dCount = 0.6f;
			}
			else if ((double)num115 > (double)Main.maxDustToDraw * 0.5)
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
			if (type == 259)
			{
				return new Color(230, 230, 230, 230);
			}
			if (type == 261)
			{
				return new Color(230, 230, 230, 115);
			}
			if (type == 254 || type == 255)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 258)
			{
				return new Color(150, 50, 50, 0);
			}
			if (type == 263 || type == 264)
			{
				return new Color(color.R / 2 + 127, color.G + 127, color.B + 127, color.A / 8) * 0.5f;
			}
			if (type == 235)
			{
				return new Color(255, 255, 255, 0);
			}
			if (((type >= 86 && type <= 91) || type == 262) && !noLight)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 213 || type == 260)
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
			if (type == 156 || type == 230 || type == 234)
			{
				return new Color(255, 255, 255, 0);
			}
			if (type == 270)
			{
				return new Color(newColor.R / 2 + 127, newColor.G / 2 + 127, newColor.B / 2 + 127, 25);
			}
			if (type == 271)
			{
				return new Color(newColor.R / 2 + 127, newColor.G / 2 + 127, newColor.B / 2 + 127, 127);
			}
			if (type == 6 || type == 242 || type == 174 || type == 135 || type == 75 || type == 20 || type == 21 || type == 231 || type == 169 || (type >= 130 && type <= 134) || type == 158)
			{
				return new Color(newColor.R, newColor.G, newColor.B, 25);
			}
			if (type >= 219 && type <= 223)
			{
				newColor = Color.Lerp(newColor, Color.White, 0.5f);
				return new Color(newColor.R, newColor.G, newColor.B, 25);
			}
			if (type == 226 || type == 272)
			{
				newColor = Color.Lerp(newColor, Color.White, 0.8f);
				return new Color(newColor.R, newColor.G, newColor.B, 25);
			}
			if (type == 228)
			{
				newColor = Color.Lerp(newColor, Color.White, 0.8f);
				return new Color(newColor.R, newColor.G, newColor.B, 25);
			}
			if (type == 229 || type == 269)
			{
				newColor = Color.Lerp(newColor, Color.White, 0.6f);
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
			if (type == 15 || type == 274 || type == 20 || type == 21 || type == 29 || type == 35 || type == 41 || type == 44 || type == 27 || type == 45 || type == 55 || type == 56 || type == 57 || type == 58 || type == 73 || type == 74)
			{
				num = (num + 3f) / 4f;
			}
			else if (type == 43)
			{
				num = (num + 9f) / 10f;
			}
			else
			{
				if (type >= 244 && type <= 247)
				{
					return new Color(255, 255, 255, 0);
				}
				if (type == 66)
				{
					return new Color(newColor.R, newColor.G, newColor.B, 0);
				}
				if (type == 267)
				{
					return new Color(color.R, color.G, color.B, 0);
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
