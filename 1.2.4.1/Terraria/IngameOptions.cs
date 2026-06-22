using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Terraria
{
	public static class IngameOptions
	{
		public const int width = 670;

		public const int height = 480;

		public static float[] leftScale = new float[6] { 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f };

		public static float[] rightScale = new float[14]
		{
			0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f,
			0.7f, 0.7f, 0.7f, 0.7f
		};

		public static int leftHover = -1;

		public static int rightHover = -1;

		public static int oldLeftHover = -1;

		public static int oldRightHover = -1;

		public static int rightLock = -1;

		public static bool inBar = false;

		public static bool notBar = false;

		public static bool noSound = false;

		public static int category = 0;

		public static Vector2 valuePosition = Vector2.Zero;

		public static void Open()
		{
			Main.playerInventory = false;
			Main.editChest = false;
			Main.npcChatText = "";
			Main.PlaySound(10);
			Main.ingameOptionsWindow = true;
			category = 0;
			for (int i = 0; i < leftScale.Length; i++)
			{
				leftScale[i] = 0f;
			}
		}

		public static void Close()
		{
			if (Main.setKey == -1)
			{
				Main.SaveSettings();
				Main.ingameOptionsWindow = false;
				Main.PlaySound(11);
				Recipe.FindRecipes();
				Main.playerInventory = true;
			}
		}

		public static void Draw(Main mainInstance, SpriteBatch sb)
		{
			if (Main.player[Main.myPlayer].dead && !Main.player[Main.myPlayer].ghost)
			{
				Main.setKey = -1;
				Close();
				Main.playerInventory = false;
				return;
			}
			new Vector2(Main.mouseX, Main.mouseY);
			bool flag = Main.mouseLeft && Main.mouseLeftRelease;
			Vector2 vector = new Vector2(Main.screenWidth, Main.screenHeight);
			Vector2 vector2 = new Vector2(670f, 480f);
			Vector2 vector3 = vector / 2f - vector2 / 2f;
			int num = 20;
			Utils.DrawInvBG(sb, vector3.X - (float)num, vector3.Y - (float)num, vector2.X + (float)(num * 2), vector2.Y + (float)(num * 2), new Color(33, 15, 91, 255) * 0.685f);
			if (new Rectangle((int)vector3.X - num, (int)vector3.Y - num, (int)vector2.X + num * 2, (int)vector2.Y + num * 2).Contains(new Point(Main.mouseX, Main.mouseY)))
			{
				Main.player[Main.myPlayer].mouseInterface = true;
			}
			Utils.DrawInvBG(sb, vector3.X + (float)(num / 2), vector3.Y + (float)(num * 5 / 2), vector2.X / 2f - (float)num, vector2.Y - (float)(num * 3));
			Utils.DrawInvBG(sb, vector3.X + vector2.X / 2f + (float)num, vector3.Y + (float)(num * 5 / 2), vector2.X / 2f - (float)(num * 3 / 2), vector2.Y - (float)(num * 3));
			Utils.DrawBorderString(sb, "Settings Menu", vector3 + vector2 * new Vector2(0.5f, 0f), Color.White, 1f, 0.5f);
			float num2 = 0.7f;
			float num3 = 0.8f;
			float num4 = 0.01f;
			if (oldLeftHover != leftHover && leftHover != -1)
			{
				Main.PlaySound(12);
			}
			if (oldRightHover != rightHover && rightHover != -1)
			{
				Main.PlaySound(12);
			}
			if (flag && rightHover != -1 && !noSound)
			{
				Main.PlaySound(12);
			}
			oldLeftHover = leftHover;
			oldRightHover = rightHover;
			noSound = false;
			int num5 = 5;
			Vector2 anchor = new Vector2(vector3.X + vector2.X / 4f, vector3.Y + (float)(num * 5 / 2));
			Vector2 offset = new Vector2(0f, vector2.Y - (float)(num * 3)) / (num5 + 1);
			for (int i = 0; i < 6; i++)
			{
				if (leftHover == i || i == category)
				{
					leftScale[i] += num4;
				}
				else
				{
					leftScale[i] -= num4;
				}
				if (leftScale[i] < num2)
				{
					leftScale[i] = num2;
				}
				if (leftScale[i] > num3)
				{
					leftScale[i] = num3;
				}
			}
			leftHover = -1;
			int num6 = category;
			if (DrawLeftSide(sb, Lang.menu[114], 0, anchor, offset, leftScale))
			{
				leftHover = 0;
				if (flag)
				{
					category = 0;
					Main.PlaySound(10);
				}
			}
			if (DrawLeftSide(sb, Lang.menu[63], 1, anchor, offset, leftScale))
			{
				leftHover = 1;
				if (flag)
				{
					category = 1;
					Main.PlaySound(10);
				}
			}
			if (DrawLeftSide(sb, Lang.menu[66], 2, anchor, offset, leftScale))
			{
				leftHover = 2;
				if (flag)
				{
					category = 2;
					Main.PlaySound(10);
				}
			}
			if (DrawLeftSide(sb, Lang.menu[115], 3, anchor, offset, leftScale))
			{
				leftHover = 3;
				if (flag)
				{
					category = 3;
					Main.PlaySound(10);
				}
			}
			if (DrawLeftSide(sb, Lang.menu[118], 4, anchor, offset, leftScale))
			{
				leftHover = 4;
				if (flag)
				{
					Close();
				}
			}
			if (DrawLeftSide(sb, Lang.inter[35], 5, anchor, offset, leftScale))
			{
				leftHover = 5;
				if (flag)
				{
					Close();
					Main.menuMode = 10;
					WorldGen.SaveAndQuit();
				}
			}
			if (num6 != category)
			{
				for (int j = 0; j < rightScale.Length; j++)
				{
					rightScale[j] = 0f;
				}
			}
			int num7 = 0;
			switch (category)
			{
			case 0:
				num7 = 7;
				num2 = 1f;
				num3 = 1.001f;
				num4 = 0.001f;
				break;
			case 1:
				num7 = 8;
				num2 = 1f;
				num3 = 1.001f;
				num4 = 0.001f;
				break;
			case 2:
				num7 = 14;
				num2 = 0.8f;
				num3 = 0.801f;
				num4 = 0.001f;
				break;
			case 3:
				num7 = 7;
				num2 = 0.8f;
				num3 = 0.801f;
				num4 = 0.001f;
				break;
			}
			Vector2 anchor2 = new Vector2(vector3.X + vector2.X * 3f / 4f, vector3.Y + (float)(num * 5 / 2));
			Vector2 offset2 = new Vector2(0f, vector2.Y - (float)(num * 3)) / (num7 + 1);
			for (int k = 0; k < 14; k++)
			{
				if (rightLock == k || (rightHover == k && rightLock == -1))
				{
					rightScale[k] += num4;
				}
				else
				{
					rightScale[k] -= num4;
				}
				if (rightScale[k] < num2)
				{
					rightScale[k] = num2;
				}
				if (rightScale[k] > num3)
				{
					rightScale[k] = num3;
				}
			}
			inBar = false;
			rightHover = -1;
			if (!Main.mouseLeft)
			{
				rightLock = -1;
			}
			if (rightLock == -1)
			{
				notBar = false;
			}
			if (category == 0)
			{
				int num8 = 0;
				anchor2.X -= 70f;
				if (DrawRightSide(sb, Lang.menu[99] + " " + Math.Round(Main.musicVolume * 100f) + "%", num8, anchor2, offset2, rightScale[num8], (rightScale[num8] - num2) / (num3 - num2)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					noSound = true;
					rightHover = num8;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num / 2) - 20f;
				valuePosition.Y -= 3f;
				float musicVolume = DrawValueBar(sb, 0.75f, Main.musicVolume);
				if ((inBar || rightLock == num8) && !notBar)
				{
					rightHover = num8;
					if (Main.mouseLeft && rightLock == num8)
					{
						Main.musicVolume = musicVolume;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num8;
				}
				num8++;
				if (DrawRightSide(sb, Lang.menu[98] + " " + Math.Round(Main.soundVolume * 100f) + "%", num8, anchor2, offset2, rightScale[num8], (rightScale[num8] - num2) / (num3 - num2)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num8;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num / 2) - 20f;
				valuePosition.Y -= 3f;
				float soundVolume = DrawValueBar(sb, 0.75f, Main.soundVolume);
				if ((inBar || rightLock == num8) && !notBar)
				{
					rightHover = num8;
					if (Main.mouseLeft && rightLock == num8)
					{
						Main.soundVolume = soundVolume;
						noSound = true;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num8;
				}
				num8++;
				if (DrawRightSide(sb, Lang.menu[119] + " " + Math.Round(Main.ambientVolume * 100f) + "%", num8, anchor2, offset2, rightScale[num8], (rightScale[num8] - num2) / (num3 - num2)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num8;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num / 2) - 20f;
				valuePosition.Y -= 3f;
				float ambientVolume = DrawValueBar(sb, 0.75f, Main.ambientVolume);
				if ((inBar || rightLock == num8) && !notBar)
				{
					rightHover = num8;
					if (Main.mouseLeft && rightLock == num8)
					{
						Main.ambientVolume = ambientVolume;
						noSound = true;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num8;
				}
				num8++;
				anchor2.X += 70f;
				if (DrawRightSide(sb, Main.autoSave ? Lang.menu[67] : Lang.menu[68], num8, anchor2, offset2, rightScale[num8], (rightScale[num8] - num2) / (num3 - num2)))
				{
					rightHover = num8;
					if (flag)
					{
						Main.autoSave = !Main.autoSave;
					}
				}
				num8++;
				if (DrawRightSide(sb, Main.autoPause ? Lang.menu[69] : Lang.menu[70], num8, anchor2, offset2, rightScale[num8], (rightScale[num8] - num2) / (num3 - num2)))
				{
					rightHover = num8;
					if (flag)
					{
						Main.autoPause = !Main.autoPause;
					}
				}
				num8++;
				if (DrawRightSide(sb, Main.showItemText ? Lang.menu[71] : Lang.menu[72], num8, anchor2, offset2, rightScale[num8], (rightScale[num8] - num2) / (num3 - num2)))
				{
					rightHover = num8;
					if (flag)
					{
						Main.showItemText = !Main.showItemText;
					}
				}
				num8++;
				if (DrawRightSide(sb, Main.cSmartToggle ? Lang.menu[121] : Lang.menu[122], num8, anchor2, offset2, rightScale[num8], (rightScale[num8] - num2) / (num3 - num2)))
				{
					rightHover = num8;
					if (flag)
					{
						Main.cSmartToggle = !Main.cSmartToggle;
					}
				}
				num8++;
			}
			if (category == 1)
			{
				int num9 = 0;
				if (DrawRightSide(sb, Main.graphics.IsFullScreen ? Lang.menu[49] : Lang.menu[50], num9, anchor2, offset2, rightScale[num9], (rightScale[num9] - num2) / (num3 - num2)))
				{
					rightHover = num9;
					if (flag)
					{
						Main.graphics.ToggleFullScreen();
					}
				}
				num9++;
				if (DrawRightSide(sb, Lang.menu[51] + ": " + Main.graphics.PreferredBackBufferWidth + "x" + Main.graphics.PreferredBackBufferHeight, num9, anchor2, offset2, rightScale[num9], (rightScale[num9] - num2) / (num3 - num2)))
				{
					rightHover = num9;
					if (flag)
					{
						int num10 = 0;
						for (int l = 0; l < Main.numDisplayModes; l++)
						{
							if (Main.displayWidth[l] == Main.graphics.PreferredBackBufferWidth && Main.displayHeight[l] == Main.graphics.PreferredBackBufferHeight)
							{
								num10 = l;
								break;
							}
						}
						num10++;
						if (num10 >= Main.numDisplayModes)
						{
							num10 = 0;
						}
						Main.graphics.PreferredBackBufferWidth = Main.displayWidth[num10];
						Main.graphics.PreferredBackBufferHeight = Main.displayHeight[num10];
					}
				}
				num9++;
				anchor2.X -= 70f;
				if (DrawRightSide(sb, Lang.menu[52] + ": " + Main.bgScroll + "%", num9, anchor2, offset2, rightScale[num9], (rightScale[num9] - num2) / (num3 - num2)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					noSound = true;
					rightHover = num9;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num / 2) - 20f;
				valuePosition.Y -= 3f;
				float num11 = DrawValueBar(sb, 0.75f, (float)Main.bgScroll / 100f);
				if ((inBar || rightLock == num9) && !notBar)
				{
					rightHover = num9;
					if (Main.mouseLeft && rightLock == num9)
					{
						Main.bgScroll = (int)(num11 * 100f);
						Main.caveParrallax = 1f - (float)Main.bgScroll / 500f;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num9;
				}
				num9++;
				anchor2.X += 70f;
				if (DrawRightSide(sb, Main.fixedTiming ? Lang.menu[53] : Lang.menu[54], num9, anchor2, offset2, rightScale[num9], (rightScale[num9] - num2) / (num3 - num2)))
				{
					rightHover = num9;
					if (flag)
					{
						Main.fixedTiming = !Main.fixedTiming;
					}
				}
				num9++;
				if (DrawRightSide(sb, Lang.menu[55 + Lighting.lightMode], num9, anchor2, offset2, rightScale[num9], (rightScale[num9] - num2) / (num3 - num2)))
				{
					rightHover = num9;
					if (flag)
					{
						Lighting.NextLightMode();
					}
				}
				num9++;
				if (DrawRightSide(sb, Lang.menu[116] + " " + ((Lighting.LightingThreads > 0) ? string.Concat(Lighting.LightingThreads + 1) : Lang.menu[117]), num9, anchor2, offset2, rightScale[num9], (rightScale[num9] - num2) / (num3 - num2)))
				{
					rightHover = num9;
					if (flag)
					{
						Lighting.LightingThreads++;
						if (Lighting.LightingThreads > Environment.ProcessorCount - 1)
						{
							Lighting.LightingThreads = 0;
						}
					}
				}
				num9++;
				if (DrawRightSide(sb, Lang.menu[59 + Main.qaStyle], num9, anchor2, offset2, rightScale[num9], (rightScale[num9] - num2) / (num3 - num2)))
				{
					rightHover = num9;
					if (flag)
					{
						Main.qaStyle++;
						if (Main.qaStyle > 3)
						{
							Main.qaStyle = 0;
						}
					}
				}
				num9++;
				if (DrawRightSide(sb, Main.owBack ? Lang.menu[100] : Lang.menu[101], num9, anchor2, offset2, rightScale[num9], (rightScale[num9] - num2) / (num3 - num2)))
				{
					rightHover = num9;
					if (flag)
					{
						Main.owBack = !Main.owBack;
					}
				}
				num9++;
			}
			if (category == 2)
			{
				int num12 = 0;
				int num13 = 0;
				anchor2.X -= 30f;
				num13 = 0;
				if (DrawRightSide(sb, Lang.menu[74 + num13], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2), (Main.setKey == num13) ? Color.Gold : default(Color)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num13) ? "_" : Main.cUp, num12, num3, (Main.setKey == num13) ? Color.Gold : ((rightHover == num12) ? Color.White : default(Color))))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				num12++;
				num13 = 1;
				if (DrawRightSide(sb, Lang.menu[74 + num13], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2), (Main.setKey == num13) ? Color.Gold : default(Color)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num13) ? "_" : Main.cDown, num12, num3, (Main.setKey == num13) ? Color.Gold : ((rightHover == num12) ? Color.White : default(Color))))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				num12++;
				num13 = 2;
				if (DrawRightSide(sb, Lang.menu[74 + num13], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2), (Main.setKey == num13) ? Color.Gold : default(Color)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num13) ? "_" : Main.cLeft, num12, num3, (Main.setKey == num13) ? Color.Gold : ((rightHover == num12) ? Color.White : default(Color))))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				num12++;
				num13 = 3;
				if (DrawRightSide(sb, Lang.menu[74 + num13], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2), (Main.setKey == num13) ? Color.Gold : default(Color)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num13) ? "_" : Main.cRight, num12, num3, (Main.setKey == num13) ? Color.Gold : ((rightHover == num12) ? Color.White : default(Color))))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				num12++;
				num13 = 4;
				if (DrawRightSide(sb, Lang.menu[74 + num13], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2), (Main.setKey == num13) ? Color.Gold : default(Color)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num13) ? "_" : Main.cJump, num12, num3, (Main.setKey == num13) ? Color.Gold : ((rightHover == num12) ? Color.White : default(Color))))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				num12++;
				num13 = 5;
				if (DrawRightSide(sb, Lang.menu[74 + num13], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2), (Main.setKey == num13) ? Color.Gold : default(Color)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num13) ? "_" : Main.cThrowItem, num12, num3, (Main.setKey == num13) ? Color.Gold : ((rightHover == num12) ? Color.White : default(Color))))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				num12++;
				num13 = 6;
				if (DrawRightSide(sb, Lang.menu[74 + num13], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2), (Main.setKey == num13) ? Color.Gold : default(Color)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num13) ? "_" : Main.cInv, num12, num3, (Main.setKey == num13) ? Color.Gold : ((rightHover == num12) ? Color.White : default(Color))))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				num12++;
				num13 = 7;
				if (DrawRightSide(sb, Lang.menu[74 + num13], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2), (Main.setKey == num13) ? Color.Gold : default(Color)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num13) ? "_" : Main.cHeal, num12, num3, (Main.setKey == num13) ? Color.Gold : ((rightHover == num12) ? Color.White : default(Color))))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				num12++;
				num13 = 8;
				if (DrawRightSide(sb, Lang.menu[74 + num13], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2), (Main.setKey == num13) ? Color.Gold : default(Color)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num13) ? "_" : Main.cMana, num12, num3, (Main.setKey == num13) ? Color.Gold : ((rightHover == num12) ? Color.White : default(Color))))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				num12++;
				num13 = 9;
				if (DrawRightSide(sb, Lang.menu[74 + num13], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2), (Main.setKey == num13) ? Color.Gold : default(Color)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num13) ? "_" : Main.cBuff, num12, num3, (Main.setKey == num13) ? Color.Gold : ((rightHover == num12) ? Color.White : default(Color))))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				num12++;
				num13 = 10;
				if (DrawRightSide(sb, Lang.menu[74 + num13], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2), (Main.setKey == num13) ? Color.Gold : default(Color)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num13) ? "_" : Main.cHook, num12, num3, (Main.setKey == num13) ? Color.Gold : ((rightHover == num12) ? Color.White : default(Color))))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				num12++;
				num13 = 11;
				if (DrawRightSide(sb, Lang.menu[74 + num13], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2), (Main.setKey == num13) ? Color.Gold : default(Color)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num13) ? "_" : Main.cTorch, num12, num3, (Main.setKey == num13) ? Color.Gold : ((rightHover == num12) ? Color.White : default(Color))))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				num12++;
				num13 = 12;
				if (DrawRightSide(sb, Lang.menu[120], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2), (Main.setKey == num13) ? Color.Gold : default(Color)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num13) ? "_" : Main.cSmart, num12, num3, (Main.setKey == num13) ? Color.Gold : ((rightHover == num12) ? Color.White : default(Color))))
				{
					rightHover = num12;
					if (flag)
					{
						Main.setKey = num13;
					}
				}
				num12++;
				anchor2.X += 30f;
				if (DrawRightSide(sb, Lang.menu[86], num12, anchor2, offset2, rightScale[num12], (rightScale[num12] - num2) / (num3 - num2)))
				{
					rightHover = num12;
					if (flag)
					{
						Main.cUp = "W";
						Main.cDown = "S";
						Main.cLeft = "A";
						Main.cRight = "D";
						Main.cJump = "Space";
						Main.cThrowItem = "T";
						Main.cInv = "Escape";
						Main.cHeal = "H";
						Main.cMana = "J";
						Main.cBuff = "B";
						Main.cHook = "E";
						Main.cTorch = "LeftShift";
						Main.cSmart = "LeftControl";
						Main.setKey = -1;
					}
				}
				num12++;
				if (Main.setKey >= 0)
				{
					Main.blockInput = true;
					Keys[] pressedKeys = Main.keyState.GetPressedKeys();
					if (pressedKeys.Length > 0)
					{
						string text = string.Concat(pressedKeys[0]);
						if (text != "None")
						{
							if (Main.setKey == 0)
							{
								Main.cUp = text;
							}
							if (Main.setKey == 1)
							{
								Main.cDown = text;
							}
							if (Main.setKey == 2)
							{
								Main.cLeft = text;
							}
							if (Main.setKey == 3)
							{
								Main.cRight = text;
							}
							if (Main.setKey == 4)
							{
								Main.cJump = text;
							}
							if (Main.setKey == 5)
							{
								Main.cThrowItem = text;
							}
							if (Main.setKey == 6)
							{
								Main.cInv = text;
							}
							if (Main.setKey == 7)
							{
								Main.cHeal = text;
							}
							if (Main.setKey == 8)
							{
								Main.cMana = text;
							}
							if (Main.setKey == 9)
							{
								Main.cBuff = text;
							}
							if (Main.setKey == 10)
							{
								Main.cHook = text;
							}
							if (Main.setKey == 11)
							{
								Main.cTorch = text;
							}
							if (Main.setKey == 12)
							{
								Main.cSmart = text;
							}
							Main.blockKey = pressedKeys[0];
							Main.blockInput = false;
							Main.setKey = -1;
						}
					}
				}
			}
			if (category == 3)
			{
				int num14 = 0;
				int num15 = 0;
				anchor2.X -= 30f;
				num15 = 0;
				if (DrawRightSide(sb, Lang.menu[106 + num15], num14, anchor2, offset2, rightScale[num14], (rightScale[num14] - num2) / (num3 - num2), (Main.setKey == num15) ? Color.Gold : default(Color)))
				{
					rightHover = num14;
					if (flag)
					{
						Main.setKey = num15;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num15) ? "_" : Main.cMapStyle, num14, num3, (Main.setKey == num15) ? Color.Gold : ((rightHover == num14) ? Color.White : default(Color))))
				{
					rightHover = num14;
					if (flag)
					{
						Main.setKey = num15;
					}
				}
				num14++;
				num15 = 1;
				if (DrawRightSide(sb, Lang.menu[106 + num15], num14, anchor2, offset2, rightScale[num14], (rightScale[num14] - num2) / (num3 - num2), (Main.setKey == num15) ? Color.Gold : default(Color)))
				{
					rightHover = num14;
					if (flag)
					{
						Main.setKey = num15;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num15) ? "_" : Main.cMapFull, num14, num3, (Main.setKey == num15) ? Color.Gold : ((rightHover == num14) ? Color.White : default(Color))))
				{
					rightHover = num14;
					if (flag)
					{
						Main.setKey = num15;
					}
				}
				num14++;
				num15 = 2;
				if (DrawRightSide(sb, Lang.menu[106 + num15], num14, anchor2, offset2, rightScale[num14], (rightScale[num14] - num2) / (num3 - num2), (Main.setKey == num15) ? Color.Gold : default(Color)))
				{
					rightHover = num14;
					if (flag)
					{
						Main.setKey = num15;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num15) ? "_" : Main.cMapZoomIn, num14, num3, (Main.setKey == num15) ? Color.Gold : ((rightHover == num14) ? Color.White : default(Color))))
				{
					rightHover = num14;
					if (flag)
					{
						Main.setKey = num15;
					}
				}
				num14++;
				num15 = 3;
				if (DrawRightSide(sb, Lang.menu[106 + num15], num14, anchor2, offset2, rightScale[num14], (rightScale[num14] - num2) / (num3 - num2), (Main.setKey == num15) ? Color.Gold : default(Color)))
				{
					rightHover = num14;
					if (flag)
					{
						Main.setKey = num15;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num15) ? "_" : Main.cMapZoomOut, num14, num3, (Main.setKey == num15) ? Color.Gold : ((rightHover == num14) ? Color.White : default(Color))))
				{
					rightHover = num14;
					if (flag)
					{
						Main.setKey = num15;
					}
				}
				num14++;
				num15 = 4;
				if (DrawRightSide(sb, Lang.menu[106 + num15], num14, anchor2, offset2, rightScale[num14], (rightScale[num14] - num2) / (num3 - num2), (Main.setKey == num15) ? Color.Gold : default(Color)))
				{
					rightHover = num14;
					if (flag)
					{
						Main.setKey = num15;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num15) ? "_" : Main.cMapAlphaUp, num14, num3, (Main.setKey == num15) ? Color.Gold : ((rightHover == num14) ? Color.White : default(Color))))
				{
					rightHover = num14;
					if (flag)
					{
						Main.setKey = num15;
					}
				}
				num14++;
				num15 = 5;
				if (DrawRightSide(sb, Lang.menu[106 + num15], num14, anchor2, offset2, rightScale[num14], (rightScale[num14] - num2) / (num3 - num2), (Main.setKey == num15) ? Color.Gold : default(Color)))
				{
					rightHover = num14;
					if (flag)
					{
						Main.setKey = num15;
					}
				}
				valuePosition.X += 10f;
				if (DrawValue(sb, (Main.setKey == num15) ? "_" : Main.cMapAlphaDown, num14, num3, (Main.setKey == num15) ? Color.Gold : ((rightHover == num14) ? Color.White : default(Color))))
				{
					rightHover = num14;
					if (flag)
					{
						Main.setKey = num15;
					}
				}
				num14++;
				anchor2.X += 30f;
				if (DrawRightSide(sb, Lang.menu[86], num14, anchor2, offset2, rightScale[num14], (rightScale[num14] - num2) / (num3 - num2)))
				{
					rightHover = num14;
					if (flag)
					{
						Main.cMapStyle = "Tab";
						Main.cMapFull = "M";
						Main.cMapZoomIn = "Add";
						Main.cMapZoomOut = "Subtract";
						Main.cMapAlphaUp = "PageUp";
						Main.cMapAlphaDown = "PageDown";
						Main.setKey = -1;
					}
				}
				num14++;
				if (Main.setKey >= 0)
				{
					Main.blockInput = true;
					Keys[] pressedKeys2 = Main.keyState.GetPressedKeys();
					if (pressedKeys2.Length > 0)
					{
						string text2 = string.Concat(pressedKeys2[0]);
						if (text2 != "None")
						{
							if (Main.setKey == 0)
							{
								Main.cMapStyle = text2;
							}
							if (Main.setKey == 1)
							{
								Main.cMapFull = text2;
							}
							if (Main.setKey == 2)
							{
								Main.cMapZoomIn = text2;
							}
							if (Main.setKey == 3)
							{
								Main.cMapZoomOut = text2;
							}
							if (Main.setKey == 4)
							{
								Main.cMapAlphaUp = text2;
							}
							if (Main.setKey == 5)
							{
								Main.cMapAlphaDown = text2;
							}
							Main.setKey = -1;
							Main.blockKey = pressedKeys2[0];
							Main.blockInput = false;
						}
					}
				}
			}
			if (rightHover != -1 && rightLock == -1)
			{
				rightLock = rightHover;
			}
			sb.Draw(Main.cursorTexture, new Vector2(Main.mouseX + 1, Main.mouseY + 1), null, new Color((int)((float)(int)Main.cursorColor.R * 0.2f), (int)((float)(int)Main.cursorColor.G * 0.2f), (int)((float)(int)Main.cursorColor.B * 0.2f), (int)((float)(int)Main.cursorColor.A * 0.5f)), 0f, default(Vector2), Main.cursorScale * 1.1f, SpriteEffects.None, 0f);
			sb.Draw(Main.cursorTexture, new Vector2(Main.mouseX, Main.mouseY), null, Main.cursorColor, 0f, default(Vector2), Main.cursorScale, SpriteEffects.None, 0f);
		}

		public static bool DrawLeftSide(SpriteBatch sb, string txt, int i, Vector2 anchor, Vector2 offset, float[] scales, float minscale = 0.7f, float maxscale = 0.8f, float scalespeed = 0.01f)
		{
			bool flag = i == category;
			Color color = Color.Lerp(Color.Gray, Color.White, (scales[i] - minscale) / (maxscale - minscale));
			if (flag)
			{
				color = Color.Gold;
			}
			offset.Y = 61f;
			Vector2 vector = Utils.DrawBorderStringBig(sb, txt, anchor + offset * (1 + i), color, scales[i], 0.5f, 0.5f);
			if (new Rectangle((int)anchor.X - (int)vector.X / 2, (int)anchor.Y + (int)(offset.Y * (float)(1 + i)) - (int)vector.Y / 2, (int)vector.X, (int)vector.Y).Contains(new Point(Main.mouseX, Main.mouseY)))
			{
				return true;
			}
			return false;
		}

		public static bool DrawRightSide(SpriteBatch sb, string txt, int i, Vector2 anchor, Vector2 offset, float scale, float colorScale, Color over = default(Color))
		{
			Color color = Color.Lerp(Color.Gray, Color.White, colorScale);
			if (over != default(Color))
			{
				color = over;
			}
			Vector2 vector = Utils.DrawBorderString(sb, txt, anchor + offset * (1 + i), color, scale, 0.5f, 0.5f);
			valuePosition = anchor + offset * (1 + i) + vector * new Vector2(0.5f, 0f);
			if (new Rectangle((int)anchor.X - (int)vector.X / 2, (int)anchor.Y + (int)(offset.Y * (float)(1 + i)) - (int)vector.Y / 2, (int)vector.X, (int)vector.Y).Contains(new Point(Main.mouseX, Main.mouseY)))
			{
				return true;
			}
			return false;
		}

		public static bool DrawValue(SpriteBatch sb, string txt, int i, float scale, Color over = default(Color))
		{
			Color color = Color.Gray;
			Vector2 vector = Main.fontMouseText.MeasureString(txt) * scale;
			bool flag = new Rectangle((int)valuePosition.X, (int)valuePosition.Y - (int)vector.Y / 2, (int)vector.X, (int)vector.Y).Contains(new Point(Main.mouseX, Main.mouseY));
			if (flag)
			{
				color = Color.White;
			}
			if (over != default(Color))
			{
				color = over;
			}
			Utils.DrawBorderString(sb, txt, valuePosition, color, scale, 0f, 0.5f);
			valuePosition.X += vector.X;
			if (flag)
			{
				return true;
			}
			return false;
		}

		public static float DrawValueBar(SpriteBatch sb, float scale, float perc)
		{
			Texture2D colorBarTexture = Main.colorBarTexture;
			Vector2 vector = new Vector2(colorBarTexture.Width, colorBarTexture.Height) * scale;
			valuePosition.X -= (int)vector.X;
			Rectangle destinationRectangle = new Rectangle((int)valuePosition.X, (int)valuePosition.Y - (int)vector.Y / 2, (int)vector.X, (int)vector.Y);
			sb.Draw(colorBarTexture, destinationRectangle, Color.White);
			int num = 167;
			float num2 = (float)destinationRectangle.X + 5f * scale;
			float num3 = (float)destinationRectangle.Y + 4f * scale;
			for (float num4 = 0f; num4 < (float)num; num4 += 1f)
			{
				float amount = num4 / (float)num;
				sb.Draw(Main.colorBlipTexture, new Vector2(num2 + num4 * scale, num3), null, Color.Lerp(Color.Black, Color.White, amount), 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
			}
			sb.Draw(Main.colorSliderTexture, new Vector2(num2 + 167f * scale * perc, num3 + 4f * scale), null, Color.White, 0f, new Vector2(0.5f * (float)Main.colorSliderTexture.Width, 0.5f * (float)Main.colorSliderTexture.Height), scale, SpriteEffects.None, 0f);
			destinationRectangle.X = (int)num2;
			destinationRectangle.Y = (int)num3;
			bool flag = destinationRectangle.Contains(new Point(Main.mouseX, Main.mouseY));
			if (Main.mouseX >= destinationRectangle.X && Main.mouseX <= destinationRectangle.X + destinationRectangle.Width)
			{
				inBar = flag;
				return (float)(Main.mouseX - destinationRectangle.X) / (float)destinationRectangle.Width;
			}
			inBar = false;
			if (destinationRectangle.X >= Main.mouseX)
			{
				return 0f;
			}
			return 1f;
		}
	}
}
