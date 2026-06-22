using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
	public static class Utils
	{
		public static Dictionary<SpriteFont, float[]> charLengths = new Dictionary<SpriteFont, float[]>();

		public static bool FloatIntersect(float r1StartX, float r1StartY, float r1Width, float r1Height, float r2StartX, float r2StartY, float r2Width, float r2Height)
		{
			if (r1StartX > r2StartX + r2Width || r1StartY > r2StartY + r2Height || r1StartX + r1Width < r2StartX || r1StartY + r1Height < r2StartY)
			{
				return false;
			}
			return true;
		}

		public static string[] WordwrapString(string text, SpriteFont font, int maxWidth, int maxLines, out int lineAmount)
		{
			string[] array = new string[maxLines];
			int num = 0;
			List<string> list = new List<string>(text.Split('\n'));
			List<string> list2 = new List<string>(list[0].Split(' '));
			for (int i = 1; i < list.Count; i++)
			{
				list2.Add("\n");
				list2.AddRange(list[i].Split(' '));
			}
			bool flag = true;
			while (list2.Count > 0)
			{
				string text2 = list2[0];
				string text3 = " ";
				if (list2.Count == 1)
				{
					text3 = "";
				}
				if (text2 == "\n")
				{
					string[] array3;
					string[] array2 = (array3 = array);
					int num2 = num++;
					IntPtr intPtr = (IntPtr)num2;
					array2[num2] = array3[(long)intPtr] + text2;
					if (num >= maxLines)
					{
						break;
					}
					list2.RemoveAt(0);
				}
				else if (flag)
				{
					if (font.MeasureString(text2).X > (float)maxWidth)
					{
						string text4 = string.Concat(text2[0]);
						int num3 = 1;
						while (font.MeasureString(text4 + text2[num3] + '-').X <= (float)maxWidth)
						{
							text4 += text2[num3++];
						}
						text4 += '-';
						array[num++] = text4 + " ";
						if (num >= maxLines)
						{
							break;
						}
						list2.RemoveAt(0);
						list2.Insert(0, text2.Substring(num3));
					}
					else
					{
						string[] array5;
						string[] array4 = (array5 = array);
						int num4 = num;
						IntPtr intPtr2 = (IntPtr)num4;
						array4[num4] = array5[(long)intPtr2] + text2 + text3;
						flag = false;
						list2.RemoveAt(0);
					}
				}
				else if (font.MeasureString(array[num] + text2).X > (float)maxWidth)
				{
					num++;
					if (num >= maxLines)
					{
						break;
					}
					flag = true;
				}
				else
				{
					string[] array7;
					string[] array6 = (array7 = array);
					int num5 = num;
					IntPtr intPtr3 = (IntPtr)num5;
					array6[num5] = array7[(long)intPtr3] + text2 + text3;
					flag = false;
					list2.RemoveAt(0);
				}
			}
			lineAmount = num;
			if (lineAmount == maxLines)
			{
				lineAmount--;
			}
			return array;
		}

		public static void DrawBorderStringFourWay(SpriteBatch sb, SpriteFont font, string text, float x, float y, Color textColor, Color borderColor, Vector2 origin, float scale = 1f)
		{
			Color color = borderColor;
			Vector2 zero = Vector2.Zero;
			for (int i = 0; i < 5; i++)
			{
				switch (i)
				{
				case 0:
					zero.X = x - 2f;
					zero.Y = y;
					break;
				case 1:
					zero.X = x + 2f;
					zero.Y = y;
					break;
				case 2:
					zero.X = x;
					zero.Y = y - 2f;
					break;
				case 3:
					zero.X = x;
					zero.Y = y + 2f;
					break;
				default:
					zero.X = x;
					zero.Y = y;
					color = textColor;
					break;
				}
				sb.DrawString(font, text, zero, color, 0f, origin, scale, SpriteEffects.None, 0f);
			}
		}

		public static Vector2 DrawBorderString(SpriteBatch sb, string text, Vector2 pos, Color color, float scale = 1f, float anchorx = 0f, float anchory = 0f, int stringLimit = -1)
		{
			if (stringLimit != -1 && text.Length > stringLimit)
			{
				text.Substring(0, stringLimit);
			}
			SpriteFont fontMouseText = Main.fontMouseText;
			for (int i = -1; i < 2; i++)
			{
				for (int j = -1; j < 2; j++)
				{
					sb.DrawString(fontMouseText, text, pos + new Vector2(i, j) * 1f, Color.Black, 0f, new Vector2(anchorx, anchory) * fontMouseText.MeasureString(text), scale, SpriteEffects.None, 0f);
				}
			}
			sb.DrawString(fontMouseText, text, pos, color, 0f, new Vector2(anchorx, anchory) * fontMouseText.MeasureString(text), scale, SpriteEffects.None, 0f);
			return fontMouseText.MeasureString(text) * scale;
		}

		public static Vector2 DrawBorderStringBig(SpriteBatch sb, string text, Vector2 pos, Color color, float scale = 1f, float anchorx = 0f, float anchory = 0f, int stringLimit = -1)
		{
			if (stringLimit != -1 && text.Length > stringLimit)
			{
				text.Substring(0, stringLimit);
			}
			SpriteFont fontDeathText = Main.fontDeathText;
			for (int i = -1; i < 2; i++)
			{
				for (int j = -1; j < 2; j++)
				{
					sb.DrawString(fontDeathText, text, pos + new Vector2(i, j) * 1f, Color.Black, 0f, new Vector2(anchorx, anchory) * fontDeathText.MeasureString(text), scale, SpriteEffects.None, 0f);
				}
			}
			sb.DrawString(fontDeathText, text, pos, color, 0f, new Vector2(anchorx, anchory) * fontDeathText.MeasureString(text), scale, SpriteEffects.None, 0f);
			return fontDeathText.MeasureString(text) * scale;
		}

		public static void DrawInvBG(SpriteBatch sb, Rectangle R, Color c = default(Color))
		{
			DrawInvBG(sb, R.X, R.Y, R.Width, R.Height, c);
		}

		public static void DrawInvBG(SpriteBatch sb, float x, float y, float w, float h, Color c = default(Color))
		{
			DrawInvBG(sb, (int)x, (int)y, (int)w, (int)h, c);
		}

		public static void DrawInvBG(SpriteBatch sb, int x, int y, int w, int h, Color c = default(Color))
		{
			if (c == default(Color))
			{
				c = new Color(63, 65, 151, 255) * 0.785f;
			}
			Texture2D inventoryBack13Texture = Main.inventoryBack13Texture;
			if (w < 20)
			{
				w = 20;
			}
			if (h < 20)
			{
				h = 20;
			}
			sb.Draw(inventoryBack13Texture, new Rectangle(x, y, 10, 10), new Rectangle(0, 0, 10, 10), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x + 10, y, w - 20, 10), new Rectangle(10, 0, 10, 10), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x + w - 10, y, 10, 10), new Rectangle(inventoryBack13Texture.Width - 10, 0, 10, 10), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x, y + 10, 10, h - 20), new Rectangle(0, 10, 10, 10), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x + 10, y + 10, w - 20, h - 20), new Rectangle(10, 10, 10, 10), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x + w - 10, y + 10, 10, h - 20), new Rectangle(inventoryBack13Texture.Width - 10, 10, 10, 10), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x, y + h - 10, 10, 10), new Rectangle(0, inventoryBack13Texture.Height - 10, 10, 10), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x + 10, y + h - 10, w - 20, 10), new Rectangle(10, inventoryBack13Texture.Height - 10, 10, 10), c);
			sb.Draw(inventoryBack13Texture, new Rectangle(x + w - 10, y + h - 10, 10, 10), new Rectangle(inventoryBack13Texture.Width - 10, inventoryBack13Texture.Height - 10, 10, 10), c);
		}

		public static void WriteRGB(this BinaryWriter bb, Color c)
		{
			bb.Write(c.R);
			bb.Write(c.G);
			bb.Write(c.B);
		}

		public static void WriteVector2(this BinaryWriter bb, Vector2 v)
		{
			bb.Write(v.X);
			bb.Write(v.Y);
		}

		public static Color ReadRGB(this BinaryReader bb)
		{
			return new Color(bb.ReadByte(), bb.ReadByte(), bb.ReadByte());
		}

		public static Vector2 ReadVector2(this BinaryReader bb)
		{
			return new Vector2(bb.ReadSingle(), bb.ReadSingle());
		}

		public static float ToRotation(this Vector2 v)
		{
			return (float)Math.Atan2(v.Y, v.X);
		}

		public static Vector2 ToRotationVector2(this float f)
		{
			return new Vector2((float)Math.Cos(f), (float)Math.Sin(f));
		}

		public static Vector2 Rotate(this Vector2 spinningpoint, double radians, Vector2 center = default(Vector2))
		{
			float num = (float)Math.Cos(radians);
			float num2 = (float)Math.Sin(radians);
			Vector2 vector = spinningpoint - center;
			Vector2 result = center;
			result.X += vector.X * num - vector.Y * num2;
			result.Y += vector.X * num2 + vector.Y * num;
			return result;
		}

		public static Color Multiply(this Color firstColor, Color secondColor)
		{
			return new Color((byte)((float)(firstColor.R * secondColor.R) / 255f), (byte)((float)(firstColor.G * secondColor.G) / 255f), (byte)((float)(firstColor.B * secondColor.B) / 255f));
		}
	}
}
