using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria
{
	public static class IngameOptions
	{
		public const int width = 670;

		public const int height = 480;

		public static float[] leftScale = new float[9] { 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f };

		public static float[] rightScale = new float[15]
		{
			0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f,
			0.7f, 0.7f, 0.7f, 0.7f, 0.7f
		};

		public static bool[] skipRightSlot = new bool[20];

		public static int leftHover = -1;

		public static int rightHover = -1;

		public static int oldLeftHover = -1;

		public static int oldRightHover = -1;

		public static int rightLock = -1;

		public static bool inBar = false;

		public static bool notBar = false;

		public static bool noSound = false;

		private static Rectangle _GUIHover = default(Rectangle);

		public static int category = 0;

		public static Vector2 valuePosition = Vector2.Zero;

		private static string _mouseOverText;

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
			for (int j = 0; j < rightScale.Length; j++)
			{
				rightScale[j] = 0f;
			}
			leftHover = -1;
			rightHover = -1;
			oldLeftHover = -1;
			oldRightHover = -1;
			rightLock = -1;
			inBar = false;
			notBar = false;
			noSound = false;
		}

		public static void Close()
		{
			if (Main.setKey == -1)
			{
				Main.ingameOptionsWindow = false;
				Main.PlaySound(11);
				Recipe.FindRecipes();
				Main.playerInventory = true;
				Main.SaveSettings();
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
			for (int i = 0; i < skipRightSlot.Length; i++)
			{
				skipRightSlot[i] = false;
			}
			bool flag = GameCulture.Russian.IsActive || GameCulture.Portuguese.IsActive || GameCulture.Polish.IsActive || GameCulture.French.IsActive;
			bool isActive = GameCulture.Polish.IsActive;
			bool isActive2 = GameCulture.German.IsActive;
			bool flag2 = GameCulture.Italian.IsActive || GameCulture.Spanish.IsActive;
			bool flag3 = false;
			int num = 70;
			float scale = 0.75f;
			float num2 = 60f;
			float num3 = 300f;
			if (flag)
			{
				flag3 = true;
			}
			if (isActive)
			{
				num3 = 200f;
			}
			new Vector2(Main.mouseX, Main.mouseY);
			bool flag4 = Main.mouseLeft && Main.mouseLeftRelease;
			Vector2 vector = new Vector2(Main.screenWidth, Main.screenHeight);
			Vector2 vector2 = new Vector2(670f, 480f);
			Vector2 vector3 = vector / 2f - vector2 / 2f;
			int num4 = 20;
			_GUIHover = new Rectangle((int)(vector3.X - (float)num4), (int)(vector3.Y - (float)num4), (int)(vector2.X + (float)(num4 * 2)), (int)(vector2.Y + (float)(num4 * 2)));
			Utils.DrawInvBG(sb, vector3.X - (float)num4, vector3.Y - (float)num4, vector2.X + (float)(num4 * 2), vector2.Y + (float)(num4 * 2), new Color(33, 15, 91, 255) * 0.685f);
			if (new Rectangle((int)vector3.X - num4, (int)vector3.Y - num4, (int)vector2.X + num4 * 2, (int)vector2.Y + num4 * 2).Contains(new Point(Main.mouseX, Main.mouseY)))
			{
				Main.player[Main.myPlayer].mouseInterface = true;
			}
			Utils.DrawBorderString(sb, Language.GetTextValue("GameUI.SettingsMenu"), vector3 + vector2 * new Vector2(0.5f, 0f), Color.White, 1f, 0.5f);
			if (flag)
			{
				Utils.DrawInvBG(sb, vector3.X + (float)(num4 / 2), vector3.Y + (float)(num4 * 5 / 2), vector2.X / 3f - (float)num4, vector2.Y - (float)(num4 * 3));
				Utils.DrawInvBG(sb, vector3.X + vector2.X / 3f + (float)num4, vector3.Y + (float)(num4 * 5 / 2), vector2.X * 2f / 3f - (float)(num4 * 3 / 2), vector2.Y - (float)(num4 * 3));
			}
			else
			{
				Utils.DrawInvBG(sb, vector3.X + (float)(num4 / 2), vector3.Y + (float)(num4 * 5 / 2), vector2.X / 2f - (float)num4, vector2.Y - (float)(num4 * 3));
				Utils.DrawInvBG(sb, vector3.X + vector2.X / 2f + (float)num4, vector3.Y + (float)(num4 * 5 / 2), vector2.X / 2f - (float)(num4 * 3 / 2), vector2.Y - (float)(num4 * 3));
			}
			float num5 = 0.7f;
			float num6 = 0.8f;
			float num7 = 0.01f;
			if (flag)
			{
				num5 = 0.4f;
				num6 = 0.44f;
			}
			if (isActive2)
			{
				num5 = 0.55f;
				num6 = 0.6f;
			}
			if (oldLeftHover != leftHover && leftHover != -1)
			{
				Main.PlaySound(12);
			}
			if (oldRightHover != rightHover && rightHover != -1)
			{
				Main.PlaySound(12);
			}
			if (flag4 && rightHover != -1 && !noSound)
			{
				Main.PlaySound(12);
			}
			oldLeftHover = leftHover;
			oldRightHover = rightHover;
			noSound = false;
			bool flag5 = SocialAPI.Network != null && SocialAPI.Network.CanInvite();
			int num8 = (flag5 ? 1 : 0);
			int num9 = 5 + num8 + 2;
			Vector2 vector4 = new Vector2(vector3.X + vector2.X / 4f, vector3.Y + (float)(num4 * 5 / 2));
			Vector2 vector5 = new Vector2(0f, vector2.Y - (float)(num4 * 5)) / (num9 + 1);
			if (flag)
			{
				vector4.X -= 55f;
			}
			UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_LEFT = num9 + 1;
			for (int j = 0; j <= num9; j++)
			{
				if (leftHover == j || j == category)
				{
					leftScale[j] += num7;
				}
				else
				{
					leftScale[j] -= num7;
				}
				if (leftScale[j] < num5)
				{
					leftScale[j] = num5;
				}
				if (leftScale[j] > num6)
				{
					leftScale[j] = num6;
				}
			}
			leftHover = -1;
			int num10 = category;
			int num11 = 0;
			if (DrawLeftSide(sb, Lang.menu[114].Value, num11, vector4, vector5, leftScale))
			{
				leftHover = num11;
				if (flag4)
				{
					category = 0;
					Main.PlaySound(10);
				}
			}
			num11++;
			if (DrawLeftSide(sb, Lang.menu[210].Value, num11, vector4, vector5, leftScale))
			{
				leftHover = num11;
				if (flag4)
				{
					category = 1;
					Main.PlaySound(10);
				}
			}
			num11++;
			if (DrawLeftSide(sb, Lang.menu[63].Value, num11, vector4, vector5, leftScale))
			{
				leftHover = num11;
				if (flag4)
				{
					category = 2;
					Main.PlaySound(10);
				}
			}
			num11++;
			if (DrawLeftSide(sb, Lang.menu[218].Value, num11, vector4, vector5, leftScale))
			{
				leftHover = num11;
				if (flag4)
				{
					category = 3;
					Main.PlaySound(10);
				}
			}
			num11++;
			if (DrawLeftSide(sb, Lang.menu[66].Value, num11, vector4, vector5, leftScale))
			{
				leftHover = num11;
				if (flag4)
				{
					Close();
					IngameFancyUI.OpenKeybinds();
				}
			}
			num11++;
			if (flag5 && DrawLeftSide(sb, Lang.menu[147].Value, num11, vector4, vector5, leftScale))
			{
				leftHover = num11;
				if (flag4)
				{
					Close();
					SocialAPI.Network.OpenInviteInterface();
				}
			}
			if (flag5)
			{
				num11++;
			}
			if (DrawLeftSide(sb, Lang.menu[131].Value, num11, vector4, vector5, leftScale))
			{
				leftHover = num11;
				if (flag4)
				{
					Close();
					IngameFancyUI.OpenAchievements();
				}
			}
			num11++;
			if (DrawLeftSide(sb, Lang.menu[118].Value, num11, vector4, vector5, leftScale))
			{
				leftHover = num11;
				if (flag4)
				{
					Close();
				}
			}
			num11++;
			if (DrawLeftSide(sb, Lang.inter[35].Value, num11, vector4, vector5, leftScale))
			{
				leftHover = num11;
				if (flag4)
				{
					Close();
					Main.menuMode = 10;
					WorldGen.SaveAndQuit();
				}
			}
			num11++;
			if (num10 != category)
			{
				for (int k = 0; k < rightScale.Length; k++)
				{
					rightScale[k] = 0f;
				}
			}
			int num12 = 0;
			switch (category)
			{
			case 0:
				num12 = 15;
				num5 = 1f;
				num6 = 1.001f;
				num7 = 0.001f;
				break;
			case 1:
				num12 = 6;
				num5 = 1f;
				num6 = 1.001f;
				num7 = 0.001f;
				break;
			case 2:
				num12 = 12;
				num5 = 1f;
				num6 = 1.001f;
				num7 = 0.001f;
				break;
			case 3:
				num12 = 15;
				num5 = 1f;
				num6 = 1.001f;
				num7 = 0.001f;
				break;
			}
			if (flag)
			{
				num5 -= 0.1f;
				num6 -= 0.1f;
			}
			if (isActive2 && category == 3)
			{
				num5 -= 0.15f;
				num6 -= 0.15f;
			}
			if (flag2 && (category == 0 || category == 3))
			{
				num5 -= 0.2f;
				num6 -= 0.2f;
			}
			UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_RIGHT = num12;
			Vector2 vector6 = new Vector2(vector3.X + vector2.X * 3f / 4f, vector3.Y + (float)(num4 * 5 / 2));
			if (flag)
			{
				vector6.X = vector3.X + vector2.X * 2f / 3f;
			}
			Vector2 vector7 = new Vector2(0f, vector2.Y - (float)(num4 * 3)) / (num12 + 1);
			if (category == 2)
			{
				vector7.Y -= 2f;
			}
			for (int l = 0; l < 15; l++)
			{
				if (rightLock == l || (rightHover == l && rightLock == -1))
				{
					rightScale[l] += num7;
				}
				else
				{
					rightScale[l] -= num7;
				}
				if (rightScale[l] < num5)
				{
					rightScale[l] = num5;
				}
				if (rightScale[l] > num6)
				{
					rightScale[l] = num6;
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
				int num13 = 0;
				DrawRightSide(sb, Lang.menu[65].Value, num13, vector6, vector7, rightScale[num13], 1f);
				skipRightSlot[num13] = true;
				num13++;
				vector6.X -= num;
				if (DrawRightSide(sb, Lang.menu[99].Value + " " + Math.Round(Main.musicVolume * 100f) + "%", num13, vector6, vector7, rightScale[num13], (rightScale[num13] - num5) / (num6 - num5)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					noSound = true;
					rightHover = num13;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num4 / 2) - 20f;
				valuePosition.Y -= 3f;
				float musicVolume = DrawValueBar(sb, scale, Main.musicVolume);
				if ((inBar || rightLock == num13) && !notBar)
				{
					rightHover = num13;
					if (Main.mouseLeft && rightLock == num13)
					{
						Main.musicVolume = musicVolume;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num4 && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num13;
				}
				if (rightHover == num13)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 2;
				}
				num13++;
				if (DrawRightSide(sb, Lang.menu[98].Value + " " + Math.Round(Main.soundVolume * 100f) + "%", num13, vector6, vector7, rightScale[num13], (rightScale[num13] - num5) / (num6 - num5)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num13;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num4 / 2) - 20f;
				valuePosition.Y -= 3f;
				float soundVolume = DrawValueBar(sb, scale, Main.soundVolume);
				if ((inBar || rightLock == num13) && !notBar)
				{
					rightHover = num13;
					if (Main.mouseLeft && rightLock == num13)
					{
						Main.soundVolume = soundVolume;
						noSound = true;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num4 && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num13;
				}
				if (rightHover == num13)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 3;
				}
				num13++;
				if (DrawRightSide(sb, Lang.menu[119].Value + " " + Math.Round(Main.ambientVolume * 100f) + "%", num13, vector6, vector7, rightScale[num13], (rightScale[num13] - num5) / (num6 - num5)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num13;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num4 / 2) - 20f;
				valuePosition.Y -= 3f;
				float ambientVolume = DrawValueBar(sb, scale, Main.ambientVolume);
				if ((inBar || rightLock == num13) && !notBar)
				{
					rightHover = num13;
					if (Main.mouseLeft && rightLock == num13)
					{
						Main.ambientVolume = ambientVolume;
						noSound = true;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num4 && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num13;
				}
				if (rightHover == num13)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 4;
				}
				num13++;
				vector6.X += num;
				DrawRightSide(sb, "", num13, vector6, vector7, rightScale[num13], 1f);
				skipRightSlot[num13] = true;
				num13++;
				DrawRightSide(sb, Language.GetTextValue("GameUI.ZoomCategory"), num13, vector6, vector7, rightScale[num13], 1f);
				skipRightSlot[num13] = true;
				num13++;
				vector6.X -= num;
				string text = Language.GetTextValue("GameUI.GameZoom", Math.Round(Main.GameZoomTarget * 100f), Math.Round(Main.GameViewMatrix.Zoom.X * 100f));
				if (flag3)
				{
					text = Main.fontItemStack.CreateWrappedText(text, num3, Language.ActiveCulture.CultureInfo);
				}
				if (DrawRightSide(sb, text, num13, vector6, vector7, rightScale[num13] * 0.85f, (rightScale[num13] - num5) / (num6 - num5)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num13;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num4 / 2) - 20f;
				valuePosition.Y -= 3f;
				float num14 = DrawValueBar(sb, scale, Main.GameZoomTarget - 1f);
				if ((inBar || rightLock == num13) && !notBar)
				{
					rightHover = num13;
					if (Main.mouseLeft && rightLock == num13)
					{
						Main.GameZoomTarget = num14 + 1f;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num4 && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num13;
				}
				if (rightHover == num13)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 10;
				}
				num13++;
				bool flag6 = false;
				if (Main.temporaryGUIScaleSlider == -1f)
				{
					Main.temporaryGUIScaleSlider = Main.UIScaleWanted;
				}
				string text2 = Language.GetTextValue("GameUI.UIScale", Math.Round(Main.temporaryGUIScaleSlider * 100f), Math.Round(Main.UIScale * 100f));
				if (flag3)
				{
					text2 = Main.fontItemStack.CreateWrappedText(text2, num3, Language.ActiveCulture.CultureInfo);
				}
				if (DrawRightSide(sb, text2, num13, vector6, vector7, rightScale[num13] * 0.75f, (rightScale[num13] - num5) / (num6 - num5)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num13;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num4 / 2) - 20f;
				valuePosition.Y -= 3f;
				float num15 = DrawValueBar(sb, scale, Main.temporaryGUIScaleSlider - 1f);
				if ((inBar || rightLock == num13) && !notBar)
				{
					rightHover = num13;
					if (Main.mouseLeft && rightLock == num13)
					{
						Main.temporaryGUIScaleSlider = num15 + 1f;
						Main.temporaryGUIScaleSliderUpdate = true;
						flag6 = true;
					}
				}
				if (!flag6 && Main.temporaryGUIScaleSliderUpdate && Main.temporaryGUIScaleSlider != -1f)
				{
					Main.UIScale = Main.temporaryGUIScaleSlider;
					Main.temporaryGUIScaleSliderUpdate = false;
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num4 && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num13;
				}
				if (rightHover == num13)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 11;
				}
				num13++;
				vector6.X += num;
				DrawRightSide(sb, "", num13, vector6, vector7, rightScale[num13], 1f);
				skipRightSlot[num13] = true;
				num13++;
				DrawRightSide(sb, Language.GetTextValue("GameUI.Gameplay"), num13, vector6, vector7, rightScale[num13], 1f);
				skipRightSlot[num13] = true;
				num13++;
				if (DrawRightSide(sb, Main.autoSave ? Lang.menu[67].Value : Lang.menu[68].Value, num13, vector6, vector7, rightScale[num13], (rightScale[num13] - num5) / (num6 - num5)))
				{
					rightHover = num13;
					if (flag4)
					{
						Main.autoSave = !Main.autoSave;
					}
				}
				num13++;
				if (DrawRightSide(sb, Main.autoPause ? Lang.menu[69].Value : Lang.menu[70].Value, num13, vector6, vector7, rightScale[num13], (rightScale[num13] - num5) / (num6 - num5)))
				{
					rightHover = num13;
					if (flag4)
					{
						Main.autoPause = !Main.autoPause;
					}
				}
				num13++;
				if (DrawRightSide(sb, Player.SmartCursorSettings.SmartWallReplacement ? Lang.menu[226].Value : Lang.menu[225].Value, num13, vector6, vector7, rightScale[num13], (rightScale[num13] - num5) / (num6 - num5)))
				{
					rightHover = num13;
					if (flag4)
					{
						Player.SmartCursorSettings.SmartWallReplacement = !Player.SmartCursorSettings.SmartWallReplacement;
					}
				}
				num13++;
				if (DrawRightSide(sb, Main.ReversedUpDownArmorSetBonuses ? Lang.menu[220].Value : Lang.menu[221].Value, num13, vector6, vector7, rightScale[num13], (rightScale[num13] - num5) / (num6 - num5)))
				{
					rightHover = num13;
					if (flag4)
					{
						Main.ReversedUpDownArmorSetBonuses = !Main.ReversedUpDownArmorSetBonuses;
					}
				}
				num13++;
				DrawRightSide(sb, "", num13, vector6, vector7, rightScale[num13], 1f);
				skipRightSlot[num13] = true;
				num13++;
			}
			if (category == 1)
			{
				int num16 = 0;
				if (DrawRightSide(sb, Main.showItemText ? Lang.menu[71].Value : Lang.menu[72].Value, num16, vector6, vector7, rightScale[num16], (rightScale[num16] - num5) / (num6 - num5)))
				{
					rightHover = num16;
					if (flag4)
					{
						Main.showItemText = !Main.showItemText;
					}
				}
				num16++;
				if (DrawRightSide(sb, Lang.menu[123].Value + " " + Lang.menu[124 + Main.invasionProgressMode], num16, vector6, vector7, rightScale[num16], (rightScale[num16] - num5) / (num6 - num5)))
				{
					rightHover = num16;
					if (flag4)
					{
						Main.invasionProgressMode++;
						if (Main.invasionProgressMode >= 3)
						{
							Main.invasionProgressMode = 0;
						}
					}
				}
				num16++;
				if (DrawRightSide(sb, Main.placementPreview ? Lang.menu[128].Value : Lang.menu[129].Value, num16, vector6, vector7, rightScale[num16], (rightScale[num16] - num5) / (num6 - num5)))
				{
					rightHover = num16;
					if (flag4)
					{
						Main.placementPreview = !Main.placementPreview;
					}
				}
				num16++;
				if (DrawRightSide(sb, ItemSlot.Options.HighlightNewItems ? Lang.inter[117].Value : Lang.inter[116].Value, num16, vector6, vector7, rightScale[num16], (rightScale[num16] - num5) / (num6 - num5)))
				{
					rightHover = num16;
					if (flag4)
					{
						ItemSlot.Options.HighlightNewItems = !ItemSlot.Options.HighlightNewItems;
					}
				}
				num16++;
				if (DrawRightSide(sb, Main.MouseShowBuildingGrid ? Lang.menu[229].Value : Lang.menu[230].Value, num16, vector6, vector7, rightScale[num16], (rightScale[num16] - num5) / (num6 - num5)))
				{
					rightHover = num16;
					if (flag4)
					{
						Main.MouseShowBuildingGrid = !Main.MouseShowBuildingGrid;
					}
				}
				num16++;
				if (DrawRightSide(sb, Main.GamepadDisableInstructionsDisplay ? Lang.menu[241].Value : Lang.menu[242].Value, num16, vector6, vector7, rightScale[num16], (rightScale[num16] - num5) / (num6 - num5)))
				{
					rightHover = num16;
					if (flag4)
					{
						Main.GamepadDisableInstructionsDisplay = !Main.GamepadDisableInstructionsDisplay;
					}
				}
				num16++;
			}
			if (category == 2)
			{
				int num17 = 0;
				if (DrawRightSide(sb, Main.graphics.IsFullScreen ? Lang.menu[49].Value : Lang.menu[50].Value, num17, vector6, vector7, rightScale[num17], (rightScale[num17] - num5) / (num6 - num5)))
				{
					rightHover = num17;
					if (flag4)
					{
						Main.ToggleFullScreen();
					}
				}
				num17++;
				if (DrawRightSide(sb, Lang.menu[51].Value + ": " + Main.PendingResolutionWidth + "x" + Main.PendingResolutionHeight, num17, vector6, vector7, rightScale[num17], (rightScale[num17] - num5) / (num6 - num5)))
				{
					rightHover = num17;
					if (flag4)
					{
						int num18 = 0;
						for (int m = 0; m < Main.numDisplayModes; m++)
						{
							if (Main.displayWidth[m] == Main.PendingResolutionWidth && Main.displayHeight[m] == Main.PendingResolutionHeight)
							{
								num18 = m;
								break;
							}
						}
						num18++;
						if (num18 >= Main.numDisplayModes)
						{
							num18 = 0;
						}
						Main.PendingResolutionWidth = Main.displayWidth[num18];
						Main.PendingResolutionHeight = Main.displayHeight[num18];
					}
				}
				num17++;
				vector6.X -= num;
				if (DrawRightSide(sb, Lang.menu[52].Value + ": " + Main.bgScroll + "%", num17, vector6, vector7, rightScale[num17], (rightScale[num17] - num5) / (num6 - num5)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					noSound = true;
					rightHover = num17;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num4 / 2) - 20f;
				valuePosition.Y -= 3f;
				float num19 = DrawValueBar(sb, scale, (float)Main.bgScroll / 100f);
				if ((inBar || rightLock == num17) && !notBar)
				{
					rightHover = num17;
					if (Main.mouseLeft && rightLock == num17)
					{
						Main.bgScroll = (int)(num19 * 100f);
						Main.caveParallax = 1f - (float)Main.bgScroll / 500f;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num4 && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num17;
				}
				if (rightHover == num17)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 1;
				}
				num17++;
				vector6.X += num;
				if (DrawRightSide(sb, Lang.menu[247 + Main.FrameSkipMode].Value, num17, vector6, vector7, rightScale[num17], (rightScale[num17] - num5) / (num6 - num5)))
				{
					rightHover = num17;
					if (flag4)
					{
						Main.FrameSkipMode++;
						if (Main.FrameSkipMode < 0 || Main.FrameSkipMode > 2)
						{
							Main.FrameSkipMode = 0;
						}
					}
				}
				num17++;
				if (DrawRightSide(sb, Lang.menu[55 + Lighting.lightMode].Value, num17, vector6, vector7, rightScale[num17], (rightScale[num17] - num5) / (num6 - num5)))
				{
					rightHover = num17;
					if (flag4)
					{
						Lighting.NextLightMode();
					}
				}
				num17++;
				if (DrawRightSide(sb, Lang.menu[116].Value + " " + ((Lighting.LightingThreads > 0) ? string.Concat(Lighting.LightingThreads + 1) : Lang.menu[117].Value), num17, vector6, vector7, rightScale[num17], (rightScale[num17] - num5) / (num6 - num5)))
				{
					rightHover = num17;
					if (flag4)
					{
						Lighting.LightingThreads++;
						if (Lighting.LightingThreads > Environment.ProcessorCount - 1)
						{
							Lighting.LightingThreads = 0;
						}
					}
				}
				num17++;
				if (DrawRightSide(sb, Lang.menu[59 + Main.qaStyle].Value, num17, vector6, vector7, rightScale[num17], (rightScale[num17] - num5) / (num6 - num5)))
				{
					rightHover = num17;
					if (flag4)
					{
						Main.qaStyle++;
						if (Main.qaStyle > 3)
						{
							Main.qaStyle = 0;
						}
					}
				}
				num17++;
				if (DrawRightSide(sb, Main.BackgroundEnabled ? Lang.menu[100].Value : Lang.menu[101].Value, num17, vector6, vector7, rightScale[num17], (rightScale[num17] - num5) / (num6 - num5)))
				{
					rightHover = num17;
					if (flag4)
					{
						Main.BackgroundEnabled = !Main.BackgroundEnabled;
					}
				}
				num17++;
				if (DrawRightSide(sb, ChildSafety.Disabled ? Lang.menu[132].Value : Lang.menu[133].Value, num17, vector6, vector7, rightScale[num17], (rightScale[num17] - num5) / (num6 - num5)))
				{
					rightHover = num17;
					if (flag4)
					{
						ChildSafety.Disabled = !ChildSafety.Disabled;
					}
				}
				num17++;
				if (DrawRightSide(sb, Language.GetTextValue("GameUI.HeatDistortion", Main.UseHeatDistortion ? Language.GetTextValue("GameUI.Enabled") : Language.GetTextValue("GameUI.Disabled")), num17, vector6, vector7, rightScale[num17], (rightScale[num17] - num5) / (num6 - num5)))
				{
					rightHover = num17;
					if (flag4)
					{
						Main.UseHeatDistortion = !Main.UseHeatDistortion;
					}
				}
				num17++;
				if (DrawRightSide(sb, Language.GetTextValue("GameUI.StormEffects", Main.UseStormEffects ? Language.GetTextValue("GameUI.Enabled") : Language.GetTextValue("GameUI.Disabled")), num17, vector6, vector7, rightScale[num17], (rightScale[num17] - num5) / (num6 - num5)))
				{
					rightHover = num17;
					if (flag4)
					{
						Main.UseStormEffects = !Main.UseStormEffects;
					}
				}
				num17++;
				string textValue;
				switch (Main.WaveQuality)
				{
				case 1:
					textValue = Language.GetTextValue("GameUI.QualityLow");
					break;
				case 2:
					textValue = Language.GetTextValue("GameUI.QualityMedium");
					break;
				case 3:
					textValue = Language.GetTextValue("GameUI.QualityHigh");
					break;
				default:
					textValue = Language.GetTextValue("GameUI.QualityOff");
					break;
				}
				if (DrawRightSide(sb, Language.GetTextValue("GameUI.WaveQuality", textValue), num17, vector6, vector7, rightScale[num17], (rightScale[num17] - num5) / (num6 - num5)))
				{
					rightHover = num17;
					if (flag4)
					{
						Main.WaveQuality = (Main.WaveQuality + 1) % 4;
					}
				}
				num17++;
			}
			if (category == 3)
			{
				int num20 = 0;
				float num21 = num;
				if (flag)
				{
					num2 = 126f;
				}
				Vector3 hSLVector = Main.mouseColorSlider.GetHSLVector();
				Main.mouseColorSlider.ApplyToMainLegacyBars();
				DrawRightSide(sb, Lang.menu[64].Value, num20, vector6, vector7, rightScale[num20], 1f);
				skipRightSlot[num20] = true;
				num20++;
				vector6.X -= num21;
				if (DrawRightSide(sb, "", num20, vector6, vector7, rightScale[num20], (rightScale[num20] - num5) / (num6 - num5)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num4 / 2) - 20f;
				valuePosition.Y -= 3f;
				valuePosition.X -= num2;
				DelegateMethods.v3_1 = hSLVector;
				float x = DrawValueBar(sb, scale, hSLVector.X, 0, DelegateMethods.ColorLerp_HSL_H);
				if ((inBar || rightLock == num20) && !notBar)
				{
					rightHover = num20;
					if (Main.mouseLeft && rightLock == num20)
					{
						hSLVector.X = x;
						noSound = true;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num4 && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				if (rightHover == num20)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 5;
					Main.menuMode = 25;
				}
				num20++;
				if (DrawRightSide(sb, "", num20, vector6, vector7, rightScale[num20], (rightScale[num20] - num5) / (num6 - num5)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num4 / 2) - 20f;
				valuePosition.Y -= 3f;
				valuePosition.X -= num2;
				DelegateMethods.v3_1 = hSLVector;
				x = DrawValueBar(sb, scale, hSLVector.Y, 0, DelegateMethods.ColorLerp_HSL_S);
				if ((inBar || rightLock == num20) && !notBar)
				{
					rightHover = num20;
					if (Main.mouseLeft && rightLock == num20)
					{
						hSLVector.Y = x;
						noSound = true;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num4 && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				if (rightHover == num20)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 6;
					Main.menuMode = 25;
				}
				num20++;
				if (DrawRightSide(sb, "", num20, vector6, vector7, rightScale[num20], (rightScale[num20] - num5) / (num6 - num5)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num4 / 2) - 20f;
				valuePosition.Y -= 3f;
				valuePosition.X -= num2;
				DelegateMethods.v3_1 = hSLVector;
				DelegateMethods.v3_1.Z = Utils.InverseLerp(0.15f, 1f, DelegateMethods.v3_1.Z, clamped: true);
				x = DrawValueBar(sb, scale, DelegateMethods.v3_1.Z, 0, DelegateMethods.ColorLerp_HSL_L);
				if ((inBar || rightLock == num20) && !notBar)
				{
					rightHover = num20;
					if (Main.mouseLeft && rightLock == num20)
					{
						hSLVector.Z = x * 0.85f + 0.15f;
						noSound = true;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num4 && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				if (rightHover == num20)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 7;
					Main.menuMode = 25;
				}
				num20++;
				if (hSLVector.Z < 0.15f)
				{
					hSLVector.Z = 0.15f;
				}
				Main.mouseColorSlider.SetHSL(hSLVector);
				Main.mouseColor = Main.mouseColorSlider.GetColor();
				vector6.X += num21;
				DrawRightSide(sb, "", num20, vector6, vector7, rightScale[num20], 1f);
				skipRightSlot[num20] = true;
				num20++;
				hSLVector = Main.mouseBorderColorSlider.GetHSLVector();
				if (PlayerInput.UsingGamepad && rightHover == -1)
				{
					Main.mouseBorderColorSlider.ApplyToMainLegacyBars();
				}
				DrawRightSide(sb, Lang.menu[217].Value, num20, vector6, vector7, rightScale[num20], 1f);
				skipRightSlot[num20] = true;
				num20++;
				vector6.X -= num21;
				if (DrawRightSide(sb, "", num20, vector6, vector7, rightScale[num20], (rightScale[num20] - num5) / (num6 - num5)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num4 / 2) - 20f;
				valuePosition.Y -= 3f;
				valuePosition.X -= num2;
				DelegateMethods.v3_1 = hSLVector;
				x = DrawValueBar(sb, scale, hSLVector.X, 0, DelegateMethods.ColorLerp_HSL_H);
				if ((inBar || rightLock == num20) && !notBar)
				{
					rightHover = num20;
					if (Main.mouseLeft && rightLock == num20)
					{
						hSLVector.X = x;
						noSound = true;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num4 && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				if (rightHover == num20)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 5;
					Main.menuMode = 252;
				}
				num20++;
				if (DrawRightSide(sb, "", num20, vector6, vector7, rightScale[num20], (rightScale[num20] - num5) / (num6 - num5)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num4 / 2) - 20f;
				valuePosition.Y -= 3f;
				valuePosition.X -= num2;
				DelegateMethods.v3_1 = hSLVector;
				x = DrawValueBar(sb, scale, hSLVector.Y, 0, DelegateMethods.ColorLerp_HSL_S);
				if ((inBar || rightLock == num20) && !notBar)
				{
					rightHover = num20;
					if (Main.mouseLeft && rightLock == num20)
					{
						hSLVector.Y = x;
						noSound = true;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num4 && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				if (rightHover == num20)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 6;
					Main.menuMode = 252;
				}
				num20++;
				if (DrawRightSide(sb, "", num20, vector6, vector7, rightScale[num20], (rightScale[num20] - num5) / (num6 - num5)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num4 / 2) - 20f;
				valuePosition.Y -= 3f;
				valuePosition.X -= num2;
				DelegateMethods.v3_1 = hSLVector;
				x = DrawValueBar(sb, scale, hSLVector.Z, 0, DelegateMethods.ColorLerp_HSL_L);
				if ((inBar || rightLock == num20) && !notBar)
				{
					rightHover = num20;
					if (Main.mouseLeft && rightLock == num20)
					{
						hSLVector.Z = x;
						noSound = true;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num4 && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				if (rightHover == num20)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 7;
					Main.menuMode = 252;
				}
				num20++;
				if (DrawRightSide(sb, "", num20, vector6, vector7, rightScale[num20], (rightScale[num20] - num5) / (num6 - num5)))
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				valuePosition.X = vector3.X + vector2.X - (float)(num4 / 2) - 20f;
				valuePosition.Y -= 3f;
				valuePosition.X -= num2;
				DelegateMethods.v3_1 = hSLVector;
				float num22 = Main.mouseBorderColorSlider.Alpha;
				x = DrawValueBar(sb, scale, num22, 0, DelegateMethods.ColorLerp_HSL_O);
				if ((inBar || rightLock == num20) && !notBar)
				{
					rightHover = num20;
					if (Main.mouseLeft && rightLock == num20)
					{
						num22 = x;
						noSound = true;
					}
				}
				if ((float)Main.mouseX > vector3.X + vector2.X * 2f / 3f + (float)num4 && (float)Main.mouseX < valuePosition.X + 3.75f && (float)Main.mouseY > valuePosition.Y - 10f && (float)Main.mouseY <= valuePosition.Y + 10f)
				{
					if (rightLock == -1)
					{
						notBar = true;
					}
					rightHover = num20;
				}
				if (rightHover == num20)
				{
					UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE = 8;
					Main.menuMode = 252;
				}
				num20++;
				Main.mouseBorderColorSlider.SetHSL(hSLVector);
				Main.mouseBorderColorSlider.Alpha = num22;
				Main.MouseBorderColor = Main.mouseBorderColorSlider.GetColor();
				vector6.X += num21;
				DrawRightSide(sb, "", num20, vector6, vector7, rightScale[num20], 1f);
				skipRightSlot[num20] = true;
				num20++;
				string txt = "";
				switch (LockOnHelper.UseMode)
				{
				case LockOnHelper.LockOnMode.FocusTarget:
					txt = Lang.menu[232].Value;
					break;
				case LockOnHelper.LockOnMode.TargetClosest:
					txt = Lang.menu[233].Value;
					break;
				case LockOnHelper.LockOnMode.ThreeDS:
					txt = Lang.menu[234].Value;
					break;
				}
				if (DrawRightSide(sb, txt, num20, vector6, vector7, rightScale[num20] * 0.9f, (rightScale[num20] - num5) / (num6 - num5)))
				{
					rightHover = num20;
					if (flag4)
					{
						LockOnHelper.CycleUseModes();
					}
				}
				num20++;
				if (DrawRightSide(sb, Player.SmartCursorSettings.SmartBlocksEnabled ? Lang.menu[215].Value : Lang.menu[216].Value, num20, vector6, vector7, rightScale[num20] * 0.9f, (rightScale[num20] - num5) / (num6 - num5)))
				{
					rightHover = num20;
					if (flag4)
					{
						Player.SmartCursorSettings.SmartBlocksEnabled = !Player.SmartCursorSettings.SmartBlocksEnabled;
					}
				}
				num20++;
				if (DrawRightSide(sb, Main.cSmartCursorToggle ? Lang.menu[121].Value : Lang.menu[122].Value, num20, vector6, vector7, rightScale[num20], (rightScale[num20] - num5) / (num6 - num5)))
				{
					rightHover = num20;
					if (flag4)
					{
						Main.cSmartCursorToggle = !Main.cSmartCursorToggle;
					}
				}
				num20++;
				if (DrawRightSide(sb, Player.SmartCursorSettings.SmartAxeAfterPickaxe ? Lang.menu[214].Value : Lang.menu[213].Value, num20, vector6, vector7, rightScale[num20] * 0.9f, (rightScale[num20] - num5) / (num6 - num5)))
				{
					rightHover = num20;
					if (flag4)
					{
						Player.SmartCursorSettings.SmartAxeAfterPickaxe = !Player.SmartCursorSettings.SmartAxeAfterPickaxe;
					}
				}
				num20++;
			}
			if (rightHover != -1 && rightLock == -1)
			{
				rightLock = rightHover;
			}
			for (int n = 0; n < num9 + 1; n++)
			{
				UILinkPointNavigator.SetPosition(2900 + n, vector4 + vector5 * (n + 1));
			}
			int num23 = 0;
			Vector2 zero = Vector2.Zero;
			if (flag)
			{
				zero.X = -40f;
			}
			for (int num24 = 0; num24 < num12; num24++)
			{
				if (!skipRightSlot[num24])
				{
					UILinkPointNavigator.SetPosition(2930 + num23, vector6 + zero + vector7 * (num24 + 1));
					num23++;
				}
			}
			UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_RIGHT = num23;
			Main.DrawGamepadInstructions();
			Main.mouseText = false;
			Main.instance.GUIBarsDraw();
			Main.instance.DrawMouseOver();
			Main.DrawCursor(Main.DrawThickCursor());
		}

		public static void MouseOver()
		{
			if (Main.ingameOptionsWindow)
			{
				if (_GUIHover.Contains(Main.MouseScreen.ToPoint()))
				{
					Main.mouseText = true;
				}
				if (_mouseOverText != null)
				{
					Main.instance.MouseText(_mouseOverText, 0, 0);
				}
				_mouseOverText = null;
			}
		}

		public static bool DrawLeftSide(SpriteBatch sb, string txt, int i, Vector2 anchor, Vector2 offset, float[] scales, float minscale = 0.7f, float maxscale = 0.8f, float scalespeed = 0.01f)
		{
			bool num = i == category;
			Color color = Color.Lerp(Color.Gray, Color.White, (scales[i] - minscale) / (maxscale - minscale));
			if (num)
			{
				color = Color.Gold;
			}
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
			bool num = new Rectangle((int)valuePosition.X, (int)valuePosition.Y - (int)vector.Y / 2, (int)vector.X, (int)vector.Y).Contains(new Point(Main.mouseX, Main.mouseY));
			if (num)
			{
				color = Color.White;
			}
			if (over != default(Color))
			{
				color = over;
			}
			Utils.DrawBorderString(sb, txt, valuePosition, color, scale, 0f, 0.5f);
			valuePosition.X += vector.X;
			if (num)
			{
				return true;
			}
			return false;
		}

		public static float DrawValueBar(SpriteBatch sb, float scale, float perc, int lockState = 0, Utils.ColorLerpMethod colorMethod = null)
		{
			if (colorMethod == null)
			{
				colorMethod = Utils.ColorLerp_BlackToWhite;
			}
			Texture2D colorBarTexture = Main.colorBarTexture;
			Vector2 vector = new Vector2(colorBarTexture.Width, colorBarTexture.Height) * scale;
			valuePosition.X -= (int)vector.X;
			Rectangle rectangle = new Rectangle((int)valuePosition.X, (int)valuePosition.Y - (int)vector.Y / 2, (int)vector.X, (int)vector.Y);
			Rectangle destinationRectangle = rectangle;
			sb.Draw(colorBarTexture, rectangle, Color.White);
			int num = 167;
			float num2 = (float)rectangle.X + 5f * scale;
			float num3 = (float)rectangle.Y + 4f * scale;
			for (float num4 = 0f; num4 < (float)num; num4 += 1f)
			{
				float percent = num4 / (float)num;
				sb.Draw(Main.colorBlipTexture, new Vector2(num2 + num4 * scale, num3), null, colorMethod(percent), 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
			}
			rectangle.X = (int)num2;
			rectangle.Y = (int)num3;
			bool flag = rectangle.Contains(new Point(Main.mouseX, Main.mouseY));
			if (lockState == 2)
			{
				flag = false;
			}
			if (flag || lockState == 1)
			{
				sb.Draw(Main.colorHighlightTexture, destinationRectangle, Main.OurFavoriteColor);
			}
			sb.Draw(Main.colorSliderTexture, new Vector2(num2 + 167f * scale * perc, num3 + 4f * scale), null, Color.White, 0f, new Vector2(0.5f * (float)Main.colorSliderTexture.Width, 0.5f * (float)Main.colorSliderTexture.Height), scale, SpriteEffects.None, 0f);
			if (Main.mouseX >= rectangle.X && Main.mouseX <= rectangle.X + rectangle.Width)
			{
				inBar = flag;
				return (float)(Main.mouseX - rectangle.X) / (float)rectangle.Width;
			}
			inBar = false;
			if (rectangle.X >= Main.mouseX)
			{
				return 0f;
			}
			return 1f;
		}
	}
}
