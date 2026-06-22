using System;
using Microsoft.Xna.Framework;

namespace Terraria
{
	public class Gore
	{
		public static int goreTime = 600;

		public Vector2 position;

		public Vector2 velocity;

		public float rotation;

		public float scale;

		public int alpha;

		public int type;

		public float light;

		public bool active;

		public bool sticky = true;

		public int timeLeft = goreTime;

		public void Update()
		{
			if (Main.netMode == 2 || !active)
			{
				return;
			}
			if (type >= 276 && type <= 282)
			{
				velocity.X *= 0.98f;
				velocity.Y *= 0.98f;
				if (velocity.Y < scale)
				{
					velocity.Y += 0.05f;
				}
				if ((double)velocity.Y > 0.1)
				{
					if (velocity.X > 0f)
					{
						rotation += 0.01f;
					}
					else
					{
						rotation -= 0.01f;
					}
				}
			}
			if (type >= 570 && type <= 572)
			{
				scale -= 0.001f;
				if ((double)scale <= 0.01)
				{
					scale = 0.01f;
					goreTime = 0;
				}
				sticky = false;
				rotation = velocity.X * 0.1f;
			}
			else if (type == 11 || type == 12 || type == 13 || type == 61 || type == 62 || type == 63 || type == 99 || type == 220 || type == 221 || type == 222 || (type >= 375 && type <= 377) || (type >= 435 && type <= 437))
			{
				velocity.Y *= 0.98f;
				velocity.X *= 0.98f;
				scale -= 0.007f;
				if ((double)scale < 0.1)
				{
					scale = 0.1f;
					alpha = 255;
				}
			}
			else if (type == 16 || type == 17)
			{
				velocity.Y *= 0.98f;
				velocity.X *= 0.98f;
				scale -= 0.01f;
				if ((double)scale < 0.1)
				{
					scale = 0.1f;
					alpha = 255;
				}
			}
			else if (type == 331)
			{
				alpha += 5;
				velocity.Y *= 0.95f;
				velocity.X *= 0.95f;
				rotation = velocity.X * 0.1f;
			}
			else if (type < 411 || type > 430)
			{
				velocity.Y += 0.2f;
			}
			rotation += velocity.X * 0.1f;
			if (type >= 580 && type <= 582)
			{
				rotation = 0f;
				velocity.X *= 0.95f;
			}
			if (type >= 411 && type <= 430)
			{
				alpha = 50;
				velocity.X = (velocity.X * 50f + Main.windSpeed * 2f + (float)Main.rand.Next(-10, 11) * 0.1f) / 51f;
				velocity.Y = (velocity.Y * 50f + -0.25f + (float)Main.rand.Next(-10, 11) * 0.2f) / 51f;
				rotation = velocity.X * 0.3f;
				if (Main.goreLoaded[type])
				{
					Rectangle rectangle = new Rectangle((int)position.X, (int)position.Y, (int)((float)Main.goreTexture[type].Width * scale), (int)((float)Main.goreTexture[type].Height * scale));
					for (int i = 0; i < 255; i++)
					{
						if (Main.player[i].active && !Main.player[i].dead)
						{
							Rectangle value = new Rectangle((int)Main.player[i].position.X, (int)Main.player[i].position.Y, Main.player[i].width, Main.player[i].height);
							if (rectangle.Intersects(value))
							{
								timeLeft = 0;
							}
						}
					}
					if (Collision.SolidCollision(position, (int)((float)Main.goreTexture[type].Width * scale), (int)((float)Main.goreTexture[type].Height * scale)))
					{
						timeLeft = 0;
					}
				}
				if (timeLeft > 0)
				{
					if (Main.rand.Next(2) == 0)
					{
						timeLeft--;
					}
					if (Main.rand.Next(50) == 0)
					{
						timeLeft -= 5;
					}
					if (Main.rand.Next(100) == 0)
					{
						timeLeft -= 10;
					}
				}
				else
				{
					alpha = 255;
					if (Main.goreLoaded[type])
					{
						float num = (float)Main.goreTexture[type].Width * scale * 0.8f;
						float x = position.X;
						float y = position.Y;
						float num2 = (float)Main.goreTexture[type].Width * scale;
						float num3 = (float)Main.goreTexture[type].Height * scale;
						int num4 = 176;
						if (type >= 416 && type <= 420)
						{
							num4 = 177;
						}
						if (type >= 421 && type <= 425)
						{
							num4 = 178;
						}
						if (type >= 426 && type <= 430)
						{
							num4 = 179;
						}
						for (int j = 0; (float)j < num; j++)
						{
							int num5 = Dust.NewDust(new Vector2(x, y), (int)num2, (int)num3, num4);
							Main.dust[num5].noGravity = true;
							Main.dust[num5].alpha = 100;
							Main.dust[num5].scale = scale;
						}
					}
				}
			}
			else if (sticky)
			{
				int num6 = 32;
				if (Main.goreLoaded[type])
				{
					num6 = Main.goreTexture[type].Width;
					if (Main.goreTexture[type].Height < num6)
					{
						num6 = Main.goreTexture[type].Height;
					}
				}
				num6 = (int)((float)num6 * 0.9f);
				velocity = Collision.TileCollision(position, velocity, (int)((float)num6 * scale), (int)((float)num6 * scale));
				if (velocity.Y == 0f)
				{
					velocity.X *= 0.97f;
					if ((double)velocity.X > -0.01 && (double)velocity.X < 0.01)
					{
						velocity.X = 0f;
					}
				}
				if (timeLeft > 0)
				{
					timeLeft--;
				}
				else
				{
					alpha++;
				}
			}
			else
			{
				alpha += 2;
			}
			position += velocity;
			if (alpha >= 255)
			{
				active = false;
			}
			if (light > 0f)
			{
				float num7 = light * scale;
				float num8 = light * scale;
				float num9 = light * scale;
				if (type == 16)
				{
					num9 *= 0.3f;
					num8 *= 0.8f;
				}
				else if (type == 17)
				{
					num8 *= 0.6f;
					num7 *= 0.3f;
				}
				if (Main.goreLoaded[type])
				{
					Lighting.addLight((int)((position.X + (float)Main.goreTexture[type].Width * scale / 2f) / 16f), (int)((position.Y + (float)Main.goreTexture[type].Height * scale / 2f) / 16f), num7, num8, num9);
				}
				else
				{
					Lighting.addLight((int)((position.X + 32f * scale / 2f) / 16f), (int)((position.Y + 32f * scale / 2f) / 16f), num7, num8, num9);
				}
			}
		}

		public static int NewGore(Vector2 Position, Vector2 Velocity, int Type, float Scale = 1f)
		{
			if (Main.netMode == 2)
			{
				return 500;
			}
			if (Main.gamePaused)
			{
				return 500;
			}
			if (Main.rand == null)
			{
				Main.rand = new Random();
			}
			int num = 500;
			for (int i = 0; i < 500; i++)
			{
				if (!Main.gore[i].active)
				{
					num = i;
					break;
				}
			}
			if (num == 500)
			{
				return num;
			}
			Main.gore[num].light = 0f;
			Main.gore[num].position = Position;
			Main.gore[num].velocity = Velocity;
			Main.gore[num].velocity.Y -= (float)Main.rand.Next(10, 31) * 0.1f;
			Main.gore[num].velocity.X += (float)Main.rand.Next(-20, 21) * 0.1f;
			Main.gore[num].type = Type;
			Main.gore[num].active = true;
			Main.gore[num].alpha = 0;
			Main.gore[num].rotation = 0f;
			Main.gore[num].scale = Scale;
			if (goreTime == 0 || Type == 11 || Type == 12 || Type == 13 || Type == 16 || Type == 17 || Type == 61 || Type == 62 || Type == 63 || Type == 99 || Type == 220 || Type == 221 || Type == 222 || Type == 435 || Type == 436 || Type == 437)
			{
				Main.gore[num].sticky = false;
			}
			else if (Type >= 375 && Type <= 377)
			{
				Main.gore[num].sticky = false;
				Main.gore[num].alpha = 100;
			}
			else
			{
				Main.gore[num].sticky = true;
				Main.gore[num].timeLeft = goreTime;
			}
			if (Type == 16 || Type == 17)
			{
				Main.gore[num].alpha = 100;
				Main.gore[num].scale = 0.7f;
				Main.gore[num].light = 1f;
			}
			if (Type >= 570 && Type <= 572)
			{
				Main.gore[num].velocity = Velocity;
			}
			if (Type >= 411 && Type <= 430 && Main.goreLoaded[Type])
			{
				Main.gore[num].position.X = Position.X - (float)(Main.goreTexture[Type].Width / 2) * Scale;
				Main.gore[num].position.Y = Position.Y - (float)Main.goreTexture[Type].Height * Scale;
				Main.gore[num].velocity.Y *= (float)Main.rand.Next(90, 150) * 0.01f;
				Main.gore[num].velocity.X *= (float)Main.rand.Next(40, 90) * 0.01f;
				int num2 = Main.rand.Next(4) * 5;
				Main.gore[num].type += num2;
				Main.gore[num].timeLeft = Main.rand.Next(goreTime / 2, goreTime * 2);
			}
			return num;
		}

		public Color GetAlpha(Color newColor)
		{
			float num = (float)(255 - alpha) / 255f;
			int r;
			int g;
			int b;
			if (type == 16 || type == 17)
			{
				r = newColor.R;
				g = newColor.G;
				b = newColor.B;
			}
			else
			{
				if (type >= 570 && type <= 572)
				{
					byte b2 = (byte)(255 - alpha);
					return new Color(b2, b2, b2, b2 / 2);
				}
				if (type == 331)
				{
					return new Color(255, 255, 255, 50);
				}
				r = (int)((float)(int)newColor.R * num);
				g = (int)((float)(int)newColor.G * num);
				b = (int)((float)(int)newColor.B * num);
			}
			int num2 = newColor.A - alpha;
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			return new Color(r, g, b, num2);
		}
	}
}
