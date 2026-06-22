using System;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.States;
using Terraria.GameInput;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.Initializers
{
	public class UILinksInitializer
	{
		public class SomeVarsForUILinkers
		{
			public static Recipe SequencedCraftingCurrent;

			public static int HairMoveCD;
		}

		public static bool NothingMoreImportantThanNPCChat()
		{
			if (!Main.hairWindow && Main.npcShop == 0)
			{
				return Main.player[Main.myPlayer].chest == -1;
			}
			return false;
		}

		public static float HandleSlider(float currentValue, float min, float max, float deadZone = 0.2f, float sensitivity = 0.5f)
		{
			float x = PlayerInput.GamepadThumbstickLeft.X;
			x = ((!(x < 0f - deadZone) && !(x > deadZone)) ? 0f : (MathHelper.Lerp(0f, sensitivity / 60f, (Math.Abs(x) - deadZone) / (1f - deadZone)) * (float)Math.Sign(x)));
			return MathHelper.Clamp((currentValue - min) / (max - min) + x, 0f, 1f) * (max - min) + min;
		}

		public static void Load()
		{
			Func<string> value = () => PlayerInput.BuildCommand(Lang.misc[53].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
			UILinkPage uILinkPage = new UILinkPage();
			uILinkPage.UpdateEvent += delegate
			{
				PlayerInput.GamepadAllowScrolling = true;
			};
			for (int num = 0; num < 20; num++)
			{
				uILinkPage.LinkMap.Add(2000 + num, new UILinkPoint(2000 + num, enabled: true, -3, -4, -1, -2));
			}
			uILinkPage.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[53].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]) + PlayerInput.BuildCommand(Lang.misc[82].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]);
			uILinkPage.UpdateEvent += delegate
			{
				if (PlayerInput.Triggers.JustPressed.Inventory)
				{
					FancyExit();
				}
				UILinkPointNavigator.Shortcuts.BackButtonInUse = PlayerInput.Triggers.JustPressed.Inventory;
				HandleOptionsSpecials();
			};
			uILinkPage.IsValidEvent += () => Main.gameMenu && !Main.MenuUI.IsVisible;
			uILinkPage.CanEnterEvent += () => Main.gameMenu && !Main.MenuUI.IsVisible;
			UILinkPointNavigator.RegisterPage(uILinkPage, 1000);
			UILinkPage cp = new UILinkPage();
			cp.LinkMap.Add(2500, new UILinkPoint(2500, enabled: true, -3, 2501, -1, -2));
			cp.LinkMap.Add(2501, new UILinkPoint(2501, enabled: true, 2500, 2502, -1, -2));
			cp.LinkMap.Add(2502, new UILinkPoint(2502, enabled: true, 2501, -4, -1, -2));
			cp.UpdateEvent += delegate
			{
				cp.LinkMap[2501].Right = (UILinkPointNavigator.Shortcuts.NPCCHAT_ButtonsRight ? 2502 : (-4));
			};
			cp.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[53].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]) + PlayerInput.BuildCommand(Lang.misc[56].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]);
			cp.IsValidEvent += () => (Main.player[Main.myPlayer].talkNPC != -1 || Main.player[Main.myPlayer].sign != -1) && NothingMoreImportantThanNPCChat();
			cp.CanEnterEvent += () => (Main.player[Main.myPlayer].talkNPC != -1 || Main.player[Main.myPlayer].sign != -1) && NothingMoreImportantThanNPCChat();
			cp.EnterEvent += delegate
			{
				Main.player[Main.myPlayer].releaseInventory = false;
			};
			cp.LeaveEvent += delegate
			{
				Main.npcChatRelease = false;
				Main.player[Main.myPlayer].releaseUseTile = false;
			};
			UILinkPointNavigator.RegisterPage(cp, 1003);
			UILinkPage cp2 = new UILinkPage();
			cp2.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			Func<string> value2 = delegate
			{
				int currentPoint = UILinkPointNavigator.CurrentPoint;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].inventory, 0, currentPoint);
			};
			Func<string> value3 = () => ItemSlot.GetGamepadInstructions(ref Main.player[Main.myPlayer].trashItem, 6);
			for (int num2 = 0; num2 <= 49; num2++)
			{
				UILinkPoint uILinkPoint = new UILinkPoint(num2, enabled: true, num2 - 1, num2 + 1, num2 - 10, num2 + 10);
				uILinkPoint.OnSpecialInteracts += value2;
				int num3 = num2;
				if (num3 < 10)
				{
					uILinkPoint.Up = -1;
				}
				if (num3 >= 40)
				{
					uILinkPoint.Down = -2;
				}
				if (num3 % 10 == 9)
				{
					uILinkPoint.Right = -4;
				}
				if (num3 % 10 == 0)
				{
					uILinkPoint.Left = -3;
				}
				cp2.LinkMap.Add(num2, uILinkPoint);
			}
			cp2.LinkMap[9].Right = 0;
			cp2.LinkMap[19].Right = 50;
			cp2.LinkMap[29].Right = 51;
			cp2.LinkMap[39].Right = 52;
			cp2.LinkMap[49].Right = 53;
			cp2.LinkMap[0].Left = 9;
			cp2.LinkMap[10].Left = 54;
			cp2.LinkMap[20].Left = 55;
			cp2.LinkMap[30].Left = 56;
			cp2.LinkMap[40].Left = 57;
			cp2.LinkMap.Add(300, new UILinkPoint(300, enabled: true, 302, 301, 49, -2));
			cp2.LinkMap.Add(301, new UILinkPoint(301, enabled: true, 300, 302, 53, 50));
			cp2.LinkMap.Add(302, new UILinkPoint(302, enabled: true, 301, 300, 57, 54));
			cp2.LinkMap[301].OnSpecialInteracts += value;
			cp2.LinkMap[302].OnSpecialInteracts += value;
			cp2.LinkMap[300].OnSpecialInteracts += value3;
			cp2.UpdateEvent += delegate
			{
				bool inReforgeMenu = Main.InReforgeMenu;
				bool flag = Main.player[Main.myPlayer].chest != -1;
				bool flag2 = Main.npcShop != 0;
				for (int i = 40; i <= 49; i++)
				{
					if (inReforgeMenu)
					{
						cp2.LinkMap[i].Down = ((i < 45) ? 303 : 304);
					}
					else if (flag)
					{
						cp2.LinkMap[i].Down = 400 + i - 40;
					}
					else if (flag2)
					{
						cp2.LinkMap[i].Down = 2700 + i - 40;
					}
					else
					{
						cp2.LinkMap[i].Down = -2;
					}
				}
				if (flag)
				{
					cp2.LinkMap[300].Up = 439;
					cp2.LinkMap[300].Right = -4;
					cp2.LinkMap[300].Left = -3;
				}
				else if (flag2)
				{
					cp2.LinkMap[300].Up = 2739;
					cp2.LinkMap[300].Right = -4;
					cp2.LinkMap[300].Left = -3;
				}
				else
				{
					cp2.LinkMap[300].Up = 49;
					cp2.LinkMap[300].Right = 301;
					cp2.LinkMap[300].Left = 302;
					cp2.LinkMap[49].Down = 300;
				}
				cp2.LinkMap[10].Left = 54;
				cp2.LinkMap[20].Left = 55;
				cp2.LinkMap[30].Left = 56;
				cp2.LinkMap[40].Left = 57;
				if (UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT > 8)
				{
					cp2.LinkMap[0].Left = 4000;
					cp2.LinkMap[10].Left = 4002;
					cp2.LinkMap[20].Left = 4004;
					cp2.LinkMap[30].Left = 4006;
					cp2.LinkMap[40].Left = 4008;
				}
				else
				{
					cp2.LinkMap[0].Left = 9;
					if (UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT > 0)
					{
						cp2.LinkMap[10].Left = 4000;
					}
					if (UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT > 2)
					{
						cp2.LinkMap[20].Left = 4002;
					}
					if (UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT > 4)
					{
						cp2.LinkMap[30].Left = 4004;
					}
					if (UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT > 6)
					{
						cp2.LinkMap[40].Left = 4006;
					}
				}
				cp2.PageOnLeft = (Main.InReforgeMenu ? 5 : 9);
			};
			cp2.IsValidEvent += () => Main.playerInventory;
			cp2.PageOnLeft = 9;
			cp2.PageOnRight = 2;
			UILinkPointNavigator.RegisterPage(cp2, 0);
			UILinkPage cp3 = new UILinkPage();
			cp3.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			Func<string> value4 = delegate
			{
				int currentPoint = UILinkPointNavigator.CurrentPoint;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].inventory, 1, currentPoint);
			};
			for (int num4 = 50; num4 <= 53; num4++)
			{
				UILinkPoint uILinkPoint2 = new UILinkPoint(num4, enabled: true, -3, -4, num4 - 1, num4 + 1);
				uILinkPoint2.OnSpecialInteracts += value4;
				cp3.LinkMap.Add(num4, uILinkPoint2);
			}
			cp3.LinkMap[50].Left = 19;
			cp3.LinkMap[51].Left = 29;
			cp3.LinkMap[52].Left = 39;
			cp3.LinkMap[53].Left = 49;
			cp3.LinkMap[50].Right = 54;
			cp3.LinkMap[51].Right = 55;
			cp3.LinkMap[52].Right = 56;
			cp3.LinkMap[53].Right = 57;
			cp3.LinkMap[50].Up = -1;
			cp3.LinkMap[53].Down = -2;
			cp3.UpdateEvent += delegate
			{
				if (Main.player[Main.myPlayer].chest == -1 && Main.npcShop == 0)
				{
					cp3.LinkMap[50].Up = 301;
					cp3.LinkMap[53].Down = 301;
				}
				else
				{
					cp3.LinkMap[50].Up = 504;
					cp3.LinkMap[53].Down = 500;
				}
			};
			cp3.IsValidEvent += () => Main.playerInventory;
			cp3.PageOnLeft = 0;
			cp3.PageOnRight = 2;
			UILinkPointNavigator.RegisterPage(cp3, 1);
			UILinkPage cp4 = new UILinkPage();
			cp4.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			Func<string> value5 = delegate
			{
				int currentPoint = UILinkPointNavigator.CurrentPoint;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].inventory, 2, currentPoint);
			};
			for (int num5 = 54; num5 <= 57; num5++)
			{
				UILinkPoint uILinkPoint3 = new UILinkPoint(num5, enabled: true, -3, -4, num5 - 1, num5 + 1);
				uILinkPoint3.OnSpecialInteracts += value5;
				cp4.LinkMap.Add(num5, uILinkPoint3);
			}
			cp4.LinkMap[54].Left = 50;
			cp4.LinkMap[55].Left = 51;
			cp4.LinkMap[56].Left = 52;
			cp4.LinkMap[57].Left = 53;
			cp4.LinkMap[54].Right = 10;
			cp4.LinkMap[55].Right = 20;
			cp4.LinkMap[56].Right = 30;
			cp4.LinkMap[57].Right = 40;
			cp4.LinkMap[54].Up = -1;
			cp4.LinkMap[57].Down = -2;
			cp4.UpdateEvent += delegate
			{
				if (Main.player[Main.myPlayer].chest == -1 && Main.npcShop == 0)
				{
					cp4.LinkMap[54].Up = 302;
					cp4.LinkMap[57].Down = 302;
				}
				else
				{
					cp4.LinkMap[54].Up = 504;
					cp4.LinkMap[57].Down = 500;
				}
			};
			cp4.PageOnLeft = 0;
			cp4.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp4, 2);
			UILinkPage cp5 = new UILinkPage();
			cp5.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			Func<string> value6 = delegate
			{
				int num30 = UILinkPointNavigator.CurrentPoint - 100;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].armor, (num30 < 10) ? 8 : 9, num30);
			};
			Func<string> value7 = delegate
			{
				int slot = UILinkPointNavigator.CurrentPoint - 120;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].dye, 12, slot);
			};
			for (int num6 = 100; num6 <= 119; num6++)
			{
				UILinkPoint uILinkPoint4 = new UILinkPoint(num6, enabled: true, num6 + 10, num6 - 10, num6 - 1, num6 + 1);
				uILinkPoint4.OnSpecialInteracts += value6;
				int num7 = num6 - 100;
				if (num7 == 0)
				{
					uILinkPoint4.Up = 305;
				}
				if (num7 == 10)
				{
					uILinkPoint4.Up = 306;
				}
				if (num7 == 9 || num7 == 19)
				{
					uILinkPoint4.Down = -2;
				}
				if (num7 >= 10)
				{
					uILinkPoint4.Left = 120 + num7 % 10;
				}
				else
				{
					uILinkPoint4.Right = -4;
				}
				cp5.LinkMap.Add(num6, uILinkPoint4);
			}
			for (int num8 = 120; num8 <= 129; num8++)
			{
				UILinkPoint uILinkPoint4 = new UILinkPoint(num8, enabled: true, -3, -10 + num8, num8 - 1, num8 + 1);
				uILinkPoint4.OnSpecialInteracts += value7;
				int num9 = num8 - 120;
				if (num9 == 0)
				{
					uILinkPoint4.Up = 307;
				}
				if (num9 == 9)
				{
					uILinkPoint4.Down = 308;
					uILinkPoint4.Left = 1557;
				}
				cp5.LinkMap.Add(num8, uILinkPoint4);
			}
			cp5.IsValidEvent += () => Main.playerInventory && Main.EquipPage == 0;
			cp5.UpdateEvent += delegate
			{
				int num30 = 107;
				int extraAccessorySlots = Main.player[Main.myPlayer].extraAccessorySlots;
				for (int i = 0; i < extraAccessorySlots; i++)
				{
					cp5.LinkMap[num30 + i].Down = num30 + i + 1;
					cp5.LinkMap[num30 - 100 + 120 + i].Down = num30 - 100 + 120 + i + 1;
					cp5.LinkMap[num30 + 10 + i].Down = num30 + 10 + i + 1;
				}
				cp5.LinkMap[num30 + extraAccessorySlots].Down = 308;
				cp5.LinkMap[num30 - 100 + 120 + extraAccessorySlots].Down = 308;
				cp5.LinkMap[num30 + 10 + extraAccessorySlots].Down = 308;
				bool shouldPVPDraw = Main.ShouldPVPDraw;
				for (int j = 120; j <= 129; j++)
				{
					UILinkPoint uILinkPoint15 = cp5.LinkMap[j];
					int num31 = j - 120;
					if (num31 == 0)
					{
						uILinkPoint15.Left = (shouldPVPDraw ? 1550 : (-3));
					}
					if (num31 == 1)
					{
						uILinkPoint15.Left = (shouldPVPDraw ? 1552 : (-3));
					}
					if (num31 == 2)
					{
						uILinkPoint15.Left = (shouldPVPDraw ? 1556 : (-3));
					}
					if (num31 == 3)
					{
						uILinkPoint15.Left = ((UILinkPointNavigator.Shortcuts.INFOACCCOUNT >= 1) ? 1558 : (-3));
					}
					if (num31 == 4)
					{
						uILinkPoint15.Left = ((UILinkPointNavigator.Shortcuts.INFOACCCOUNT >= 5) ? 1562 : (-3));
					}
					if (num31 == 5)
					{
						uILinkPoint15.Left = ((UILinkPointNavigator.Shortcuts.INFOACCCOUNT >= 9) ? 1566 : (-3));
					}
					if (num31 == 7)
					{
						uILinkPoint15.Left = (shouldPVPDraw ? 1557 : (-3));
					}
				}
			};
			cp5.PageOnLeft = 8;
			cp5.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp5, 3);
			UILinkPage uILinkPage2 = new UILinkPage();
			uILinkPage2.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			Func<string> value8 = delegate
			{
				int slot = UILinkPointNavigator.CurrentPoint - 400;
				int context = 4;
				Item[] item = Main.player[Main.myPlayer].bank.item;
				switch (Main.player[Main.myPlayer].chest)
				{
				case -1:
					return "";
				case -3:
					item = Main.player[Main.myPlayer].bank2.item;
					break;
				case -4:
					item = Main.player[Main.myPlayer].bank3.item;
					break;
				default:
					item = Main.chest[Main.player[Main.myPlayer].chest].item;
					context = 3;
					break;
				case -2:
					break;
				}
				return ItemSlot.GetGamepadInstructions(item, context, slot);
			};
			for (int num10 = 400; num10 <= 439; num10++)
			{
				UILinkPoint uILinkPoint5 = new UILinkPoint(num10, enabled: true, num10 - 1, num10 + 1, num10 - 10, num10 + 10);
				uILinkPoint5.OnSpecialInteracts += value8;
				int num11 = num10 - 400;
				if (num11 < 10)
				{
					uILinkPoint5.Up = 40 + num11;
				}
				if (num11 >= 30)
				{
					uILinkPoint5.Down = -2;
				}
				if (num11 % 10 == 9)
				{
					uILinkPoint5.Right = -4;
				}
				if (num11 % 10 == 0)
				{
					uILinkPoint5.Left = -3;
				}
				uILinkPage2.LinkMap.Add(num10, uILinkPoint5);
			}
			uILinkPage2.LinkMap.Add(500, new UILinkPoint(500, enabled: true, 409, -4, 53, 501));
			uILinkPage2.LinkMap.Add(501, new UILinkPoint(501, enabled: true, 419, -4, 500, 502));
			uILinkPage2.LinkMap.Add(502, new UILinkPoint(502, enabled: true, 429, -4, 501, 503));
			uILinkPage2.LinkMap.Add(503, new UILinkPoint(503, enabled: true, 439, -4, 502, 505));
			uILinkPage2.LinkMap.Add(505, new UILinkPoint(505, enabled: true, 439, -4, 503, 504));
			uILinkPage2.LinkMap.Add(504, new UILinkPoint(504, enabled: true, 439, -4, 505, 50));
			uILinkPage2.LinkMap[500].OnSpecialInteracts += value;
			uILinkPage2.LinkMap[501].OnSpecialInteracts += value;
			uILinkPage2.LinkMap[502].OnSpecialInteracts += value;
			uILinkPage2.LinkMap[503].OnSpecialInteracts += value;
			uILinkPage2.LinkMap[504].OnSpecialInteracts += value;
			uILinkPage2.LinkMap[505].OnSpecialInteracts += value;
			uILinkPage2.LinkMap[409].Right = 500;
			uILinkPage2.LinkMap[419].Right = 501;
			uILinkPage2.LinkMap[429].Right = 502;
			uILinkPage2.LinkMap[439].Right = 503;
			uILinkPage2.LinkMap[439].Down = 300;
			uILinkPage2.PageOnLeft = 0;
			uILinkPage2.PageOnRight = 0;
			uILinkPage2.DefaultPoint = 500;
			UILinkPointNavigator.RegisterPage(uILinkPage2, 4, automatedDefault: false);
			uILinkPage2.IsValidEvent += () => Main.playerInventory && Main.player[Main.myPlayer].chest != -1;
			UILinkPage uILinkPage3 = new UILinkPage();
			uILinkPage3.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			Func<string> value9 = delegate
			{
				int slot = UILinkPointNavigator.CurrentPoint - 2700;
				return ItemSlot.GetGamepadInstructions(Main.instance.shop[Main.npcShop].item, 15, slot);
			};
			for (int num12 = 2700; num12 <= 2739; num12++)
			{
				UILinkPoint uILinkPoint6 = new UILinkPoint(num12, enabled: true, num12 - 1, num12 + 1, num12 - 10, num12 + 10);
				uILinkPoint6.OnSpecialInteracts += value9;
				int num13 = num12 - 2700;
				if (num13 < 10)
				{
					uILinkPoint6.Up = 40 + num13;
				}
				if (num13 >= 30)
				{
					uILinkPoint6.Down = -2;
				}
				if (num13 % 10 == 9)
				{
					uILinkPoint6.Right = -4;
				}
				if (num13 % 10 == 0)
				{
					uILinkPoint6.Left = -3;
				}
				uILinkPage3.LinkMap.Add(num12, uILinkPoint6);
			}
			uILinkPage3.LinkMap[2739].Down = 300;
			uILinkPage3.PageOnLeft = 0;
			uILinkPage3.PageOnRight = 0;
			UILinkPointNavigator.RegisterPage(uILinkPage3, 13);
			uILinkPage3.IsValidEvent += () => Main.playerInventory && Main.npcShop != 0;
			UILinkPage cp6 = new UILinkPage();
			cp6.LinkMap.Add(303, new UILinkPoint(303, enabled: true, 304, 304, 40, -2));
			cp6.LinkMap.Add(304, new UILinkPoint(304, enabled: true, 303, 303, 40, -2));
			cp6.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			Func<string> value10 = () => ItemSlot.GetGamepadInstructions(ref Main.reforgeItem, 5);
			cp6.LinkMap[303].OnSpecialInteracts += value10;
			cp6.LinkMap[304].OnSpecialInteracts += () => Lang.misc[53].Value;
			cp6.UpdateEvent += delegate
			{
				if (Main.reforgeItem.type > 0)
				{
					cp6.LinkMap[303].Left = (cp6.LinkMap[303].Right = 304);
				}
				else
				{
					if (UILinkPointNavigator.OverridePoint == -1 && cp6.CurrentPoint == 304)
					{
						UILinkPointNavigator.ChangePoint(303);
					}
					cp6.LinkMap[303].Left = -3;
					cp6.LinkMap[303].Right = -4;
				}
			};
			cp6.IsValidEvent += () => Main.playerInventory && Main.InReforgeMenu;
			cp6.PageOnLeft = 0;
			cp6.PageOnRight = 0;
			UILinkPointNavigator.RegisterPage(cp6, 5);
			UILinkPage cp7 = new UILinkPage();
			cp7.OnSpecialInteracts += delegate
			{
				if (PlayerInput.Triggers.JustPressed.Grapple)
				{
					Point point = Main.player[Main.myPlayer].Center.ToTileCoordinates();
					if (UILinkPointNavigator.CurrentPoint == 600)
					{
						if (WorldGen.MoveTownNPC(point.X, point.Y, -1))
						{
							Main.NewText(Lang.inter[39].Value, byte.MaxValue, 240, 20);
						}
						Main.PlaySound(12);
					}
					else if (WorldGen.MoveTownNPC(point.X, point.Y, UILinkPointNavigator.Shortcuts.NPCS_LastHovered))
					{
						WorldGen.moveRoom(point.X, point.Y, UILinkPointNavigator.Shortcuts.NPCS_LastHovered);
						Main.PlaySound(12);
					}
				}
				if (PlayerInput.Triggers.JustPressed.SmartSelect)
				{
					UILinkPointNavigator.Shortcuts.NPCS_IconsDisplay = !UILinkPointNavigator.Shortcuts.NPCS_IconsDisplay;
				}
				return PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]) + PlayerInput.BuildCommand(Lang.misc[70].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]) + PlayerInput.BuildCommand(Lang.misc[69].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["SmartSelect"]);
			};
			for (int num14 = 600; num14 <= 650; num14++)
			{
				UILinkPoint value11 = new UILinkPoint(num14, enabled: true, num14 + 10, num14 - 10, num14 - 1, num14 + 1);
				cp7.LinkMap.Add(num14, value11);
			}
			cp7.UpdateEvent += delegate
			{
				int num30 = UILinkPointNavigator.Shortcuts.NPCS_IconsPerColumn;
				if (num30 == 0)
				{
					num30 = 100;
				}
				for (int i = 0; i < 50; i++)
				{
					cp7.LinkMap[600 + i].Up = ((i % num30 == 0) ? (-1) : (600 + i - 1));
					if (cp7.LinkMap[600 + i].Up == -1)
					{
						if (i >= num30 * 2)
						{
							cp7.LinkMap[600 + i].Up = 307;
						}
						else if (i >= num30)
						{
							cp7.LinkMap[600 + i].Up = 306;
						}
						else
						{
							cp7.LinkMap[600 + i].Up = 305;
						}
					}
					cp7.LinkMap[600 + i].Down = (((i + 1) % num30 == 0 || i == UILinkPointNavigator.Shortcuts.NPCS_IconsTotal - 1) ? 308 : (600 + i + 1));
					cp7.LinkMap[600 + i].Left = ((i < UILinkPointNavigator.Shortcuts.NPCS_IconsTotal - num30) ? (600 + i + num30) : (-3));
					cp7.LinkMap[600 + i].Right = ((i < num30) ? (-4) : (600 + i - num30));
				}
			};
			cp7.IsValidEvent += () => Main.playerInventory && Main.EquipPage == 1;
			cp7.PageOnLeft = 8;
			cp7.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp7, 6);
			UILinkPage cp8 = new UILinkPage();
			cp8.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			Func<string> value12 = delegate
			{
				int slot = UILinkPointNavigator.CurrentPoint - 180;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].miscEquips, 20, slot);
			};
			Func<string> value13 = delegate
			{
				int slot = UILinkPointNavigator.CurrentPoint - 180;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].miscEquips, 19, slot);
			};
			Func<string> value14 = delegate
			{
				int slot = UILinkPointNavigator.CurrentPoint - 180;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].miscEquips, 18, slot);
			};
			Func<string> value15 = delegate
			{
				int slot = UILinkPointNavigator.CurrentPoint - 180;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].miscEquips, 17, slot);
			};
			Func<string> value16 = delegate
			{
				int slot = UILinkPointNavigator.CurrentPoint - 180;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].miscEquips, 16, slot);
			};
			Func<string> value17 = delegate
			{
				int slot = UILinkPointNavigator.CurrentPoint - 185;
				return ItemSlot.GetGamepadInstructions(Main.player[Main.myPlayer].miscDyes, 12, slot);
			};
			for (int num15 = 180; num15 <= 184; num15++)
			{
				UILinkPoint uILinkPoint7 = new UILinkPoint(num15, enabled: true, 185 + num15 - 180, -4, num15 - 1, num15 + 1);
				int num16 = num15 - 180;
				if (num16 == 0)
				{
					uILinkPoint7.Up = 305;
				}
				if (num16 == 4)
				{
					uILinkPoint7.Down = 308;
				}
				cp8.LinkMap.Add(num15, uILinkPoint7);
				switch (num15)
				{
				case 180:
					uILinkPoint7.OnSpecialInteracts += value13;
					break;
				case 181:
					uILinkPoint7.OnSpecialInteracts += value12;
					break;
				case 182:
					uILinkPoint7.OnSpecialInteracts += value14;
					break;
				case 183:
					uILinkPoint7.OnSpecialInteracts += value15;
					break;
				case 184:
					uILinkPoint7.OnSpecialInteracts += value16;
					break;
				}
			}
			for (int num17 = 185; num17 <= 189; num17++)
			{
				UILinkPoint uILinkPoint7 = new UILinkPoint(num17, enabled: true, -3, -5 + num17, num17 - 1, num17 + 1);
				uILinkPoint7.OnSpecialInteracts += value17;
				int num18 = num17 - 185;
				if (num18 == 0)
				{
					uILinkPoint7.Up = 306;
				}
				if (num18 == 4)
				{
					uILinkPoint7.Down = 308;
				}
				cp8.LinkMap.Add(num17, uILinkPoint7);
			}
			cp8.UpdateEvent += delegate
			{
				cp8.LinkMap[184].Down = ((UILinkPointNavigator.Shortcuts.BUFFS_DRAWN > 0) ? 9000 : 308);
				cp8.LinkMap[189].Down = ((UILinkPointNavigator.Shortcuts.BUFFS_DRAWN > 0) ? 9000 : 308);
			};
			cp8.IsValidEvent += () => Main.playerInventory && Main.EquipPage == 2;
			cp8.PageOnLeft = 8;
			cp8.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp8, 7);
			UILinkPage cp9 = new UILinkPage();
			cp9.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			cp9.LinkMap.Add(305, new UILinkPoint(305, enabled: true, 306, -4, 308, -2));
			cp9.LinkMap.Add(306, new UILinkPoint(306, enabled: true, 307, 305, 308, -2));
			cp9.LinkMap.Add(307, new UILinkPoint(307, enabled: true, -3, 306, 308, -2));
			cp9.LinkMap.Add(308, new UILinkPoint(308, enabled: true, -3, -4, -1, 305));
			cp9.LinkMap[305].OnSpecialInteracts += value;
			cp9.LinkMap[306].OnSpecialInteracts += value;
			cp9.LinkMap[307].OnSpecialInteracts += value;
			cp9.LinkMap[308].OnSpecialInteracts += value;
			cp9.UpdateEvent += delegate
			{
				switch (Main.EquipPage)
				{
				case 0:
					cp9.LinkMap[305].Down = 100;
					cp9.LinkMap[306].Down = 110;
					cp9.LinkMap[307].Down = 120;
					cp9.LinkMap[308].Up = 108 + Main.player[Main.myPlayer].extraAccessorySlots - 1;
					break;
				case 1:
				{
					cp9.LinkMap[305].Down = 600;
					cp9.LinkMap[306].Down = ((UILinkPointNavigator.Shortcuts.NPCS_IconsTotal / UILinkPointNavigator.Shortcuts.NPCS_IconsPerColumn > 0) ? (600 + UILinkPointNavigator.Shortcuts.NPCS_IconsPerColumn) : (-2));
					cp9.LinkMap[307].Down = ((UILinkPointNavigator.Shortcuts.NPCS_IconsTotal / UILinkPointNavigator.Shortcuts.NPCS_IconsPerColumn > 1) ? (600 + UILinkPointNavigator.Shortcuts.NPCS_IconsPerColumn * 2) : (-2));
					int num30 = UILinkPointNavigator.Shortcuts.NPCS_IconsPerColumn;
					if (num30 == 0)
					{
						num30 = 100;
					}
					if (num30 == 100)
					{
						num30 = UILinkPointNavigator.Shortcuts.NPCS_IconsTotal;
					}
					cp9.LinkMap[308].Up = 600 + num30 - 1;
					break;
				}
				case 2:
					cp9.LinkMap[305].Down = 180;
					cp9.LinkMap[306].Down = 185;
					cp9.LinkMap[307].Down = -2;
					cp9.LinkMap[308].Up = ((UILinkPointNavigator.Shortcuts.BUFFS_DRAWN > 0) ? 9000 : 184);
					break;
				case 3:
					break;
				}
			};
			cp9.IsValidEvent += () => Main.playerInventory;
			cp9.PageOnLeft = 0;
			cp9.PageOnRight = 0;
			UILinkPointNavigator.RegisterPage(cp9, 8);
			UILinkPage cp10 = new UILinkPage();
			cp10.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			Func<string> value18 = () => ItemSlot.GetGamepadInstructions(ref Main.guideItem, 7);
			Func<string> HandleItem2 = () => (Main.mouseItem.type < 1) ? "" : ItemSlot.GetGamepadInstructions(ref Main.mouseItem, 22);
			for (int num19 = 1500; num19 < 1550; num19++)
			{
				UILinkPoint uILinkPoint8 = new UILinkPoint(num19, enabled: true, num19, num19, -1, -2);
				if (num19 != 1500)
				{
					uILinkPoint8.OnSpecialInteracts += HandleItem2;
				}
				cp10.LinkMap.Add(num19, uILinkPoint8);
			}
			cp10.LinkMap[1500].OnSpecialInteracts += value18;
			cp10.UpdateEvent += delegate
			{
				int num30 = UILinkPointNavigator.Shortcuts.CRAFT_CurrentIngridientsCount;
				int num31 = num30;
				if (Main.numAvailableRecipes > 0)
				{
					num31 += 2;
				}
				if (num30 < num31)
				{
					num30 = num31;
				}
				if (UILinkPointNavigator.OverridePoint == -1 && cp10.CurrentPoint > 1500 + num30)
				{
					UILinkPointNavigator.ChangePoint(1500);
				}
				if (UILinkPointNavigator.OverridePoint == -1 && cp10.CurrentPoint == 1500 && !Main.InGuideCraftMenu)
				{
					UILinkPointNavigator.ChangePoint(1501);
				}
				for (int i = 1; i < num30; i++)
				{
					cp10.LinkMap[1500 + i].Left = 1500 + i - 1;
					cp10.LinkMap[1500 + i].Right = ((i == num30 - 2) ? (-4) : (1500 + i + 1));
				}
				cp10.LinkMap[1501].Left = -3;
				cp10.LinkMap[1500 + num30 - 1].Right = -4;
				cp10.LinkMap[1500].Down = ((num30 >= 2) ? 1502 : (-2));
				cp10.LinkMap[1500].Left = ((num30 >= 1) ? 1501 : (-3));
				cp10.LinkMap[1502].Up = (Main.InGuideCraftMenu ? 1500 : (-1));
			};
			cp10.LinkMap[1501].OnSpecialInteracts += delegate
			{
				if (Main.InGuideCraftMenu)
				{
					return "";
				}
				string text = "";
				Player player = Main.player[Main.myPlayer];
				bool flag = false;
				if (Main.mouseItem.type == 0 && player.ItemSpace(Main.recipe[Main.availableRecipe[Main.focusRecipe]].createItem) && !player.IsStackingItems())
				{
					flag = true;
					if (PlayerInput.Triggers.Current.Grapple && Main.stackSplit <= 1)
					{
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							SomeVarsForUILinkers.SequencedCraftingCurrent = Main.recipe[Main.availableRecipe[Main.focusRecipe]];
						}
						if (Main.stackSplit == 0)
						{
							Main.stackSplit = 15;
						}
						else
						{
							Main.stackSplit = Main.stackDelay;
						}
						if (SomeVarsForUILinkers.SequencedCraftingCurrent == Main.recipe[Main.availableRecipe[Main.focusRecipe]])
						{
							Main.CraftItem(Main.recipe[Main.availableRecipe[Main.focusRecipe]]);
							Main.mouseItem = player.GetItem(player.whoAmI, Main.mouseItem);
						}
					}
				}
				else if (Main.mouseItem.type > 0 && Main.mouseItem.maxStack == 1 && ItemSlot.Equippable(ref Main.mouseItem))
				{
					text += PlayerInput.BuildCommand(Lang.misc[67].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
					if (PlayerInput.Triggers.JustPressed.Grapple)
					{
						ItemSlot.SwapEquip(ref Main.mouseItem);
						if (Main.player[Main.myPlayer].ItemSpace(Main.mouseItem))
						{
							Main.mouseItem = player.GetItem(player.whoAmI, Main.mouseItem);
						}
					}
				}
				bool flag2 = Main.mouseItem.stack <= 0;
				if (flag2 || (Main.mouseItem.type == Main.recipe[Main.availableRecipe[Main.focusRecipe]].createItem.type && Main.mouseItem.stack < Main.mouseItem.maxStack))
				{
					text = ((!flag2) ? (text + PlayerInput.BuildCommand(Lang.misc[72].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"])) : (text + PlayerInput.BuildCommand(Lang.misc[72].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"], PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"])));
				}
				if (!flag2 && Main.mouseItem.type == Main.recipe[Main.availableRecipe[Main.focusRecipe]].createItem.type && Main.mouseItem.stack < Main.mouseItem.maxStack)
				{
					text += PlayerInput.BuildCommand(Lang.misc[93].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
				}
				if (flag)
				{
					text += PlayerInput.BuildCommand(Lang.misc[71].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
				}
				return text + HandleItem2();
			};
			cp10.ReachEndEvent += delegate(int current, int next)
			{
				switch (current)
				{
				case 1501:
					switch (next)
					{
					case -1:
						if (Main.focusRecipe > 0)
						{
							Main.focusRecipe--;
						}
						break;
					case -2:
						if (Main.focusRecipe < Main.numAvailableRecipes - 1)
						{
							Main.focusRecipe++;
						}
						break;
					}
					break;
				default:
					switch (next)
					{
					case -1:
						if (Main.focusRecipe > 0)
						{
							UILinkPointNavigator.ChangePoint(1501);
							Main.focusRecipe--;
						}
						break;
					case -2:
						if (Main.focusRecipe < Main.numAvailableRecipes - 1)
						{
							UILinkPointNavigator.ChangePoint(1501);
							Main.focusRecipe++;
						}
						break;
					}
					break;
				case 1500:
					break;
				}
			};
			cp10.EnterEvent += delegate
			{
				Main.recBigList = false;
			};
			cp10.CanEnterEvent += () => Main.playerInventory && (Main.numAvailableRecipes > 0 || Main.InGuideCraftMenu);
			cp10.IsValidEvent += () => Main.playerInventory && (Main.numAvailableRecipes > 0 || Main.InGuideCraftMenu);
			cp10.PageOnLeft = 10;
			cp10.PageOnRight = 0;
			UILinkPointNavigator.RegisterPage(cp10, 9);
			UILinkPage cp11 = new UILinkPage();
			cp11.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			for (int num20 = 700; num20 < 1500; num20++)
			{
				UILinkPoint uILinkPoint9 = new UILinkPoint(num20, enabled: true, num20, num20, num20, num20);
				int IHateLambda = num20;
				uILinkPoint9.OnSpecialInteracts += delegate
				{
					string text = "";
					bool flag = false;
					Player player = Main.player[Main.myPlayer];
					if (IHateLambda + Main.recStart < Main.numAvailableRecipes)
					{
						int num30 = Main.recStart + IHateLambda - 700;
						if (Main.mouseItem.type == 0 && player.ItemSpace(Main.recipe[Main.availableRecipe[num30]].createItem) && !player.IsStackingItems())
						{
							flag = true;
							if (PlayerInput.Triggers.JustPressed.Grapple)
							{
								SomeVarsForUILinkers.SequencedCraftingCurrent = Main.recipe[Main.availableRecipe[num30]];
							}
							if (PlayerInput.Triggers.Current.Grapple && Main.stackSplit <= 1)
							{
								if (Main.stackSplit == 0)
								{
									Main.stackSplit = 15;
								}
								else
								{
									Main.stackSplit = Main.stackDelay;
								}
								if (SomeVarsForUILinkers.SequencedCraftingCurrent == Main.recipe[Main.availableRecipe[num30]])
								{
									Main.CraftItem(Main.recipe[Main.availableRecipe[num30]]);
									Main.mouseItem = player.GetItem(player.whoAmI, Main.mouseItem);
								}
							}
						}
					}
					text += PlayerInput.BuildCommand(Lang.misc[73].Value, !flag, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
					if (flag)
					{
						text += PlayerInput.BuildCommand(Lang.misc[71].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
					}
					return text;
				};
				cp11.LinkMap.Add(num20, uILinkPoint9);
			}
			cp11.UpdateEvent += delegate
			{
				int num30 = UILinkPointNavigator.Shortcuts.CRAFT_IconsPerRow;
				int cRAFT_IconsPerColumn = UILinkPointNavigator.Shortcuts.CRAFT_IconsPerColumn;
				if (num30 == 0)
				{
					num30 = 100;
				}
				int num31 = num30 * cRAFT_IconsPerColumn;
				if (num31 > 800)
				{
					num31 = 800;
				}
				if (num31 > Main.numAvailableRecipes)
				{
					num31 = Main.numAvailableRecipes;
				}
				for (int i = 0; i < num31; i++)
				{
					cp11.LinkMap[700 + i].Left = ((i % num30 == 0) ? (-3) : (700 + i - 1));
					cp11.LinkMap[700 + i].Right = (((i + 1) % num30 == 0 || i == Main.numAvailableRecipes - 1) ? (-4) : (700 + i + 1));
					cp11.LinkMap[700 + i].Down = ((i < num31 - num30) ? (700 + i + num30) : (-2));
					cp11.LinkMap[700 + i].Up = ((i < num30) ? (-1) : (700 + i - num30));
				}
			};
			cp11.ReachEndEvent += delegate(int current, int next)
			{
				int cRAFT_IconsPerRow = UILinkPointNavigator.Shortcuts.CRAFT_IconsPerRow;
				switch (next)
				{
				case -1:
					Main.recStart -= cRAFT_IconsPerRow;
					if (Main.recStart < 0)
					{
						Main.recStart = 0;
					}
					break;
				case -2:
					Main.recStart += cRAFT_IconsPerRow;
					Main.PlaySound(12);
					if (Main.recStart > Main.numAvailableRecipes - cRAFT_IconsPerRow)
					{
						Main.recStart = Main.numAvailableRecipes - cRAFT_IconsPerRow;
					}
					break;
				}
			};
			cp11.EnterEvent += delegate
			{
				Main.recBigList = true;
			};
			cp11.LeaveEvent += delegate
			{
				Main.recBigList = false;
			};
			cp11.CanEnterEvent += () => Main.playerInventory && Main.numAvailableRecipes > 0;
			cp11.IsValidEvent += () => Main.playerInventory && Main.recBigList && Main.numAvailableRecipes > 0;
			cp11.PageOnLeft = 0;
			cp11.PageOnRight = 9;
			UILinkPointNavigator.RegisterPage(cp11, 10);
			UILinkPage cp12 = new UILinkPage();
			cp12.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			for (int num21 = 2605; num21 < 2620; num21++)
			{
				UILinkPoint uILinkPoint10 = new UILinkPoint(num21, enabled: true, num21, num21, num21, num21);
				uILinkPoint10.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[73].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
				cp12.LinkMap.Add(num21, uILinkPoint10);
			}
			cp12.UpdateEvent += delegate
			{
				int num30 = 5;
				int num31 = 3;
				int num32 = num30 * num31;
				int num33 = Main.UnlockedMaxHair();
				for (int i = 0; i < num32; i++)
				{
					cp12.LinkMap[2605 + i].Left = ((i % num30 == 0) ? (-3) : (2605 + i - 1));
					cp12.LinkMap[2605 + i].Right = (((i + 1) % num30 == 0 || i == num33 - 1) ? (-4) : (2605 + i + 1));
					cp12.LinkMap[2605 + i].Down = ((i < num32 - num30) ? (2605 + i + num30) : (-2));
					cp12.LinkMap[2605 + i].Up = ((i < num30) ? (-1) : (2605 + i - num30));
				}
			};
			cp12.ReachEndEvent += delegate(int current, int next)
			{
				int num30 = 5;
				switch (next)
				{
				case -1:
					Main.hairStart -= num30;
					Main.PlaySound(12);
					break;
				case -2:
					Main.hairStart += num30;
					Main.PlaySound(12);
					break;
				}
			};
			cp12.CanEnterEvent += () => Main.hairWindow;
			cp12.IsValidEvent += () => Main.hairWindow;
			cp12.PageOnLeft = 12;
			cp12.PageOnRight = 12;
			UILinkPointNavigator.RegisterPage(cp12, 11);
			UILinkPage uILinkPage4 = new UILinkPage();
			uILinkPage4.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			uILinkPage4.LinkMap.Add(2600, new UILinkPoint(2600, enabled: true, -3, -4, -1, 2601));
			uILinkPage4.LinkMap.Add(2601, new UILinkPoint(2601, enabled: true, -3, -4, 2600, 2602));
			uILinkPage4.LinkMap.Add(2602, new UILinkPoint(2602, enabled: true, -3, -4, 2601, 2603));
			uILinkPage4.LinkMap.Add(2603, new UILinkPoint(2603, enabled: true, -3, 2604, 2602, -2));
			uILinkPage4.LinkMap.Add(2604, new UILinkPoint(2604, enabled: true, 2603, -4, 2602, -2));
			uILinkPage4.UpdateEvent += delegate
			{
				Vector3 value20 = Main.rgbToHsl(Main.selColor);
				float interfaceDeadzoneX = PlayerInput.CurrentProfile.InterfaceDeadzoneX;
				float x = PlayerInput.GamepadThumbstickLeft.X;
				x = ((!(x < 0f - interfaceDeadzoneX) && !(x > interfaceDeadzoneX)) ? 0f : (MathHelper.Lerp(0f, 1f / 120f, (Math.Abs(x) - interfaceDeadzoneX) / (1f - interfaceDeadzoneX)) * (float)Math.Sign(x)));
				int currentPoint = UILinkPointNavigator.CurrentPoint;
				if (currentPoint == 2600)
				{
					Main.hBar = MathHelper.Clamp(Main.hBar + x, 0f, 1f);
				}
				if (currentPoint == 2601)
				{
					Main.sBar = MathHelper.Clamp(Main.sBar + x, 0f, 1f);
				}
				if (currentPoint == 2602)
				{
					Main.lBar = MathHelper.Clamp(Main.lBar + x, 0.15f, 1f);
				}
				Vector3.Clamp(value20, Vector3.Zero, Vector3.One);
				if (x != 0f)
				{
					if (Main.hairWindow)
					{
						Main.player[Main.myPlayer].hairColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
					}
					Main.PlaySound(12);
				}
			};
			uILinkPage4.CanEnterEvent += () => Main.hairWindow;
			uILinkPage4.IsValidEvent += () => Main.hairWindow;
			uILinkPage4.PageOnLeft = 11;
			uILinkPage4.PageOnRight = 11;
			UILinkPointNavigator.RegisterPage(uILinkPage4, 12);
			UILinkPage cp13 = new UILinkPage();
			for (int num22 = 0; num22 < 30; num22++)
			{
				cp13.LinkMap.Add(2900 + num22, new UILinkPoint(2900 + num22, enabled: true, -3, -4, -1, -2));
				cp13.LinkMap[2900 + num22].OnSpecialInteracts += value;
			}
			cp13.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			cp13.TravelEvent += delegate
			{
				if (UILinkPointNavigator.CurrentPage == cp13.ID)
				{
					int num30 = cp13.CurrentPoint - 2900;
					if (num30 < 4)
					{
						IngameOptions.category = num30;
					}
				}
			};
			cp13.UpdateEvent += delegate
			{
				int num30 = UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_LEFT;
				if (num30 == 0)
				{
					num30 = 5;
				}
				if (UILinkPointNavigator.OverridePoint == -1 && cp13.CurrentPoint < 2930 && cp13.CurrentPoint > 2900 + num30 - 1)
				{
					UILinkPointNavigator.ChangePoint(2900);
				}
				for (int i = 2900; i < 2900 + num30; i++)
				{
					cp13.LinkMap[i].Up = i - 1;
					cp13.LinkMap[i].Down = i + 1;
				}
				cp13.LinkMap[2900].Up = 2900 + num30 - 1;
				cp13.LinkMap[2900 + num30 - 1].Down = 2900;
				int num31 = cp13.CurrentPoint - 2900;
				if (num31 < 4 && PlayerInput.Triggers.JustPressed.MouseLeft)
				{
					IngameOptions.category = num31;
					UILinkPointNavigator.ChangePage(1002);
				}
			};
			cp13.EnterEvent += delegate
			{
				cp13.CurrentPoint = 2900 + IngameOptions.category;
			};
			cp13.PageOnLeft = (cp13.PageOnRight = 1002);
			cp13.IsValidEvent += () => Main.ingameOptionsWindow && !Main.InGameUI.IsVisible;
			cp13.CanEnterEvent += () => Main.ingameOptionsWindow && !Main.InGameUI.IsVisible;
			UILinkPointNavigator.RegisterPage(cp13, 1001);
			UILinkPage cp14 = new UILinkPage();
			for (int num23 = 0; num23 < 30; num23++)
			{
				cp14.LinkMap.Add(2930 + num23, new UILinkPoint(2930 + num23, enabled: true, -3, -4, -1, -2));
				cp14.LinkMap[2930 + num23].OnSpecialInteracts += value;
			}
			cp14.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			cp14.UpdateEvent += delegate
			{
				int num30 = UILinkPointNavigator.Shortcuts.INGAMEOPTIONS_BUTTONS_RIGHT;
				if (num30 == 0)
				{
					num30 = 5;
				}
				if (UILinkPointNavigator.OverridePoint == -1 && cp14.CurrentPoint >= 2930 && cp14.CurrentPoint > 2930 + num30 - 1)
				{
					UILinkPointNavigator.ChangePoint(2930);
				}
				for (int i = 2930; i < 2930 + num30; i++)
				{
					cp14.LinkMap[i].Up = i - 1;
					cp14.LinkMap[i].Down = i + 1;
				}
				cp14.LinkMap[2930].Up = -1;
				cp14.LinkMap[2930 + num30 - 1].Down = -2;
				_ = PlayerInput.Triggers.JustPressed.Inventory;
				HandleOptionsSpecials();
			};
			cp14.PageOnLeft = (cp14.PageOnRight = 1001);
			cp14.IsValidEvent += () => Main.ingameOptionsWindow;
			cp14.CanEnterEvent += () => Main.ingameOptionsWindow;
			UILinkPointNavigator.RegisterPage(cp14, 1002);
			UILinkPage cp15 = new UILinkPage();
			cp15.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			for (int num24 = 1550; num24 < 1558; num24++)
			{
				UILinkPoint uILinkPoint11 = new UILinkPoint(num24, enabled: true, -3, -4, -1, -2);
				switch (num24)
				{
				case 1551:
				case 1553:
				case 1555:
					uILinkPoint11.Up = uILinkPoint11.ID - 2;
					uILinkPoint11.Down = uILinkPoint11.ID + 2;
					uILinkPoint11.Right = uILinkPoint11.ID + 1;
					break;
				case 1552:
				case 1554:
				case 1556:
					uILinkPoint11.Up = uILinkPoint11.ID - 2;
					uILinkPoint11.Down = uILinkPoint11.ID + 2;
					uILinkPoint11.Left = uILinkPoint11.ID - 1;
					break;
				}
				cp15.LinkMap.Add(num24, uILinkPoint11);
			}
			cp15.LinkMap[1550].Down = 1551;
			cp15.LinkMap[1550].Right = 120;
			cp15.LinkMap[1550].Up = 307;
			cp15.LinkMap[1551].Up = 1550;
			cp15.LinkMap[1552].Up = 1550;
			cp15.LinkMap[1552].Right = 121;
			cp15.LinkMap[1554].Right = 121;
			cp15.LinkMap[1555].Down = 1557;
			cp15.LinkMap[1556].Down = 1557;
			cp15.LinkMap[1556].Right = 122;
			cp15.LinkMap[1557].Up = 1555;
			cp15.LinkMap[1557].Down = 308;
			cp15.LinkMap[1557].Right = 127;
			for (int num25 = 0; num25 < 7; num25++)
			{
				cp15.LinkMap[1550 + num25].OnSpecialInteracts += value;
			}
			cp15.UpdateEvent += delegate
			{
				if (!Main.ShouldPVPDraw)
				{
					if (UILinkPointNavigator.OverridePoint == -1 && cp15.CurrentPoint != 1557)
					{
						UILinkPointNavigator.ChangePoint(1557);
					}
					cp15.LinkMap[1557].Up = -1;
					cp15.LinkMap[1557].Down = 308;
					cp15.LinkMap[1557].Right = 127;
				}
				else
				{
					cp15.LinkMap[1557].Up = 1555;
					cp15.LinkMap[1557].Down = 308;
					cp15.LinkMap[1557].Right = 127;
				}
				int iNFOACCCOUNT = UILinkPointNavigator.Shortcuts.INFOACCCOUNT;
				if (iNFOACCCOUNT > 0)
				{
					cp15.LinkMap[1557].Up = 1558 + (iNFOACCCOUNT - 1) / 2 * 2;
				}
				if (Main.ShouldPVPDraw)
				{
					if (iNFOACCCOUNT >= 1)
					{
						cp15.LinkMap[1555].Down = 1558;
						cp15.LinkMap[1556].Down = 1558;
					}
					else
					{
						cp15.LinkMap[1555].Down = 1557;
						cp15.LinkMap[1556].Down = 1557;
					}
					if (iNFOACCCOUNT >= 2)
					{
						cp15.LinkMap[1556].Down = 1559;
					}
					else
					{
						cp15.LinkMap[1556].Down = 1557;
					}
				}
			};
			cp15.IsValidEvent += () => Main.playerInventory;
			cp15.PageOnLeft = 8;
			cp15.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp15, 16);
			UILinkPage cp16 = new UILinkPage();
			cp16.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			for (int num26 = 1558; num26 < 1570; num26++)
			{
				UILinkPoint uILinkPoint12 = new UILinkPoint(num26, enabled: true, -3, -4, -1, -2);
				uILinkPoint12.OnSpecialInteracts += value;
				switch (num26)
				{
				case 1559:
				case 1561:
				case 1563:
					uILinkPoint12.Up = uILinkPoint12.ID - 2;
					uILinkPoint12.Down = uILinkPoint12.ID + 2;
					uILinkPoint12.Right = uILinkPoint12.ID + 1;
					break;
				case 1560:
				case 1562:
				case 1564:
					uILinkPoint12.Up = uILinkPoint12.ID - 2;
					uILinkPoint12.Down = uILinkPoint12.ID + 2;
					uILinkPoint12.Left = uILinkPoint12.ID - 1;
					break;
				}
				cp16.LinkMap.Add(num26, uILinkPoint12);
			}
			cp16.UpdateEvent += delegate
			{
				int iNFOACCCOUNT = UILinkPointNavigator.Shortcuts.INFOACCCOUNT;
				if (UILinkPointNavigator.OverridePoint == -1 && cp16.CurrentPoint - 1558 >= iNFOACCCOUNT)
				{
					UILinkPointNavigator.ChangePoint(1558 + iNFOACCCOUNT - 1);
				}
				for (int i = 0; i < iNFOACCCOUNT; i++)
				{
					bool flag = i % 2 == 0;
					int num30 = i + 1558;
					cp16.LinkMap[num30].Down = ((i < iNFOACCCOUNT - 2) ? (num30 + 2) : 1557);
					cp16.LinkMap[num30].Up = ((i > 1) ? (num30 - 2) : (Main.ShouldPVPDraw ? (flag ? 1555 : 1556) : (-1)));
					cp16.LinkMap[num30].Right = ((flag && i + 1 < iNFOACCCOUNT) ? (num30 + 1) : (123 + i / 4));
					cp16.LinkMap[num30].Left = (flag ? (-3) : (num30 - 1));
				}
			};
			cp16.IsValidEvent += () => Main.playerInventory && UILinkPointNavigator.Shortcuts.INFOACCCOUNT > 0;
			cp16.PageOnLeft = 8;
			cp16.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp16, 17);
			UILinkPage cp17 = new UILinkPage();
			cp17.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			for (int num27 = 4000; num27 < 4010; num27++)
			{
				UILinkPoint uILinkPoint13 = new UILinkPoint(num27, enabled: true, -3, -4, -1, -2);
				switch (num27)
				{
				case 4000:
				case 4001:
					uILinkPoint13.Right = 0;
					break;
				case 4002:
				case 4003:
					uILinkPoint13.Right = 10;
					break;
				case 4004:
				case 4005:
					uILinkPoint13.Right = 20;
					break;
				case 4006:
				case 4007:
					uILinkPoint13.Right = 30;
					break;
				case 4008:
				case 4009:
					uILinkPoint13.Right = 40;
					break;
				}
				cp17.LinkMap.Add(num27, uILinkPoint13);
			}
			cp17.UpdateEvent += delegate
			{
				int bUILDERACCCOUNT = UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT;
				if (UILinkPointNavigator.OverridePoint == -1 && cp17.CurrentPoint - 4000 >= bUILDERACCCOUNT)
				{
					UILinkPointNavigator.ChangePoint(4000 + bUILDERACCCOUNT - 1);
				}
				for (int i = 0; i < bUILDERACCCOUNT; i++)
				{
					_ = i % 2;
					int num30 = i + 4000;
					cp17.LinkMap[num30].Down = ((i < bUILDERACCCOUNT - 1) ? (num30 + 1) : (-2));
					cp17.LinkMap[num30].Up = ((i > 0) ? (num30 - 1) : (-1));
				}
			};
			cp17.IsValidEvent += () => Main.playerInventory && UILinkPointNavigator.Shortcuts.BUILDERACCCOUNT > 0;
			cp17.PageOnLeft = 8;
			cp17.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp17, 18);
			UILinkPage uILinkPage5 = new UILinkPage();
			uILinkPage5.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			uILinkPage5.LinkMap.Add(2806, new UILinkPoint(2806, enabled: true, 2805, 2807, -1, 2808));
			uILinkPage5.LinkMap.Add(2807, new UILinkPoint(2807, enabled: true, 2806, -4, -1, 2809));
			uILinkPage5.LinkMap.Add(2808, new UILinkPoint(2808, enabled: true, 2805, 2809, 2806, -2));
			uILinkPage5.LinkMap.Add(2809, new UILinkPoint(2809, enabled: true, 2808, -4, 2807, -2));
			uILinkPage5.LinkMap.Add(2805, new UILinkPoint(2805, enabled: true, -3, 2806, -1, -2));
			uILinkPage5.LinkMap[2806].OnSpecialInteracts += value;
			uILinkPage5.LinkMap[2807].OnSpecialInteracts += value;
			uILinkPage5.LinkMap[2808].OnSpecialInteracts += value;
			uILinkPage5.LinkMap[2809].OnSpecialInteracts += value;
			uILinkPage5.LinkMap[2805].OnSpecialInteracts += value;
			uILinkPage5.CanEnterEvent += () => Main.clothesWindow;
			uILinkPage5.IsValidEvent += () => Main.clothesWindow;
			uILinkPage5.EnterEvent += delegate
			{
				Main.player[Main.myPlayer].releaseInventory = false;
			};
			uILinkPage5.LeaveEvent += delegate
			{
				Main.player[Main.myPlayer].releaseUseTile = false;
			};
			uILinkPage5.PageOnLeft = 15;
			uILinkPage5.PageOnRight = 15;
			UILinkPointNavigator.RegisterPage(uILinkPage5, 14);
			UILinkPage uILinkPage6 = new UILinkPage();
			uILinkPage6.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, true, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			uILinkPage6.LinkMap.Add(2800, new UILinkPoint(2800, enabled: true, -3, -4, -1, 2801));
			uILinkPage6.LinkMap.Add(2801, new UILinkPoint(2801, enabled: true, -3, -4, 2800, 2802));
			uILinkPage6.LinkMap.Add(2802, new UILinkPoint(2802, enabled: true, -3, -4, 2801, 2803));
			uILinkPage6.LinkMap.Add(2803, new UILinkPoint(2803, enabled: true, -3, 2804, 2802, -2));
			uILinkPage6.LinkMap.Add(2804, new UILinkPoint(2804, enabled: true, 2803, -4, 2802, -2));
			uILinkPage6.LinkMap[2800].OnSpecialInteracts += value;
			uILinkPage6.LinkMap[2801].OnSpecialInteracts += value;
			uILinkPage6.LinkMap[2802].OnSpecialInteracts += value;
			uILinkPage6.LinkMap[2803].OnSpecialInteracts += value;
			uILinkPage6.LinkMap[2804].OnSpecialInteracts += value;
			uILinkPage6.UpdateEvent += delegate
			{
				Vector3 value20 = Main.rgbToHsl(Main.selColor);
				float interfaceDeadzoneX = PlayerInput.CurrentProfile.InterfaceDeadzoneX;
				float x = PlayerInput.GamepadThumbstickLeft.X;
				x = ((!(x < 0f - interfaceDeadzoneX) && !(x > interfaceDeadzoneX)) ? 0f : (MathHelper.Lerp(0f, 1f / 120f, (Math.Abs(x) - interfaceDeadzoneX) / (1f - interfaceDeadzoneX)) * (float)Math.Sign(x)));
				int currentPoint = UILinkPointNavigator.CurrentPoint;
				if (currentPoint == 2800)
				{
					Main.hBar = MathHelper.Clamp(Main.hBar + x, 0f, 1f);
				}
				if (currentPoint == 2801)
				{
					Main.sBar = MathHelper.Clamp(Main.sBar + x, 0f, 1f);
				}
				if (currentPoint == 2802)
				{
					Main.lBar = MathHelper.Clamp(Main.lBar + x, 0.15f, 1f);
				}
				Vector3.Clamp(value20, Vector3.Zero, Vector3.One);
				if (x != 0f)
				{
					if (Main.clothesWindow)
					{
						Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
						switch (Main.selClothes)
						{
						case 0:
							Main.player[Main.myPlayer].shirtColor = Main.selColor;
							break;
						case 1:
							Main.player[Main.myPlayer].underShirtColor = Main.selColor;
							break;
						case 2:
							Main.player[Main.myPlayer].pantsColor = Main.selColor;
							break;
						case 3:
							Main.player[Main.myPlayer].shoeColor = Main.selColor;
							break;
						}
					}
					Main.PlaySound(12);
				}
			};
			uILinkPage6.CanEnterEvent += () => Main.clothesWindow;
			uILinkPage6.IsValidEvent += () => Main.clothesWindow;
			uILinkPage6.EnterEvent += delegate
			{
				Main.player[Main.myPlayer].releaseInventory = false;
			};
			uILinkPage6.LeaveEvent += delegate
			{
				Main.player[Main.myPlayer].releaseUseTile = false;
			};
			uILinkPage6.PageOnLeft = 14;
			uILinkPage6.PageOnRight = 14;
			UILinkPointNavigator.RegisterPage(uILinkPage6, 15);
			UILinkPage cp18 = new UILinkPage();
			cp18.UpdateEvent += delegate
			{
				PlayerInput.GamepadAllowScrolling = true;
			};
			for (int num28 = 0; num28 < 200; num28++)
			{
				cp18.LinkMap.Add(3000 + num28, new UILinkPoint(3000 + num28, enabled: true, -3, -4, -1, -2));
			}
			cp18.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[53].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]) + PlayerInput.BuildCommand(Lang.misc[82].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + FancyUISpecialInstructions();
			cp18.UpdateEvent += delegate
			{
				if (PlayerInput.Triggers.JustPressed.Inventory)
				{
					FancyExit();
				}
				UILinkPointNavigator.Shortcuts.BackButtonInUse = false;
			};
			cp18.EnterEvent += delegate
			{
				cp18.CurrentPoint = 3002;
			};
			cp18.CanEnterEvent += () => Main.MenuUI.IsVisible || Main.InGameUI.IsVisible;
			cp18.IsValidEvent += () => Main.MenuUI.IsVisible || Main.InGameUI.IsVisible;
			UILinkPointNavigator.RegisterPage(cp18, 1004);
			UILinkPage cp19 = new UILinkPage();
			cp19.OnSpecialInteracts += () => PlayerInput.BuildCommand(Lang.misc[56].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Inventory"]) + PlayerInput.BuildCommand(Lang.misc[64].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"], PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
			Func<string> value19 = () => PlayerInput.BuildCommand(Lang.misc[94].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
			for (int num29 = 9000; num29 <= 9050; num29++)
			{
				UILinkPoint uILinkPoint14 = new UILinkPoint(num29, enabled: true, num29 + 10, num29 - 10, num29 - 1, num29 + 1);
				cp19.LinkMap.Add(num29, uILinkPoint14);
				uILinkPoint14.OnSpecialInteracts += value19;
			}
			cp19.UpdateEvent += delegate
			{
				int num30 = UILinkPointNavigator.Shortcuts.BUFFS_PER_COLUMN;
				if (num30 == 0)
				{
					num30 = 100;
				}
				for (int i = 0; i < 50; i++)
				{
					cp19.LinkMap[9000 + i].Up = ((i % num30 == 0) ? (-1) : (9000 + i - 1));
					if (cp19.LinkMap[9000 + i].Up == -1)
					{
						if (i >= num30)
						{
							cp19.LinkMap[9000 + i].Up = 184;
						}
						else
						{
							cp19.LinkMap[9000 + i].Up = 189;
						}
					}
					cp19.LinkMap[9000 + i].Down = (((i + 1) % num30 == 0 || i == UILinkPointNavigator.Shortcuts.BUFFS_DRAWN - 1) ? 308 : (9000 + i + 1));
					cp19.LinkMap[9000 + i].Left = ((i < UILinkPointNavigator.Shortcuts.BUFFS_DRAWN - num30) ? (9000 + i + num30) : (-3));
					cp19.LinkMap[9000 + i].Right = ((i < num30) ? (-4) : (9000 + i - num30));
				}
			};
			cp19.IsValidEvent += () => Main.playerInventory && Main.EquipPage == 2 && UILinkPointNavigator.Shortcuts.BUFFS_DRAWN > 0;
			cp19.PageOnLeft = 8;
			cp19.PageOnRight = 8;
			UILinkPointNavigator.RegisterPage(cp19, 19);
			UILinkPage uILinkPage7 = UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage];
			uILinkPage7.CurrentPoint = uILinkPage7.DefaultPoint;
			uILinkPage7.Enter();
		}

		public static void FancyExit()
		{
			switch (UILinkPointNavigator.Shortcuts.BackButtonCommand)
			{
			case 1:
				Main.PlaySound(11);
				Main.menuMode = 0;
				break;
			case 2:
				Main.PlaySound(11);
				Main.menuMode = ((!Main.menuMultiplayer) ? 1 : 12);
				break;
			case 3:
				Main.menuMode = 0;
				IngameFancyUI.Close();
				break;
			case 4:
				Main.PlaySound(11);
				Main.menuMode = 11;
				break;
			case 5:
				Main.PlaySound(11);
				Main.menuMode = 11;
				break;
			case 6:
				UIVirtualKeyboard.Cancel();
				break;
			}
		}

		public static string FancyUISpecialInstructions()
		{
			string text = "";
			int fANCYUI_SPECIAL_INSTRUCTIONS = UILinkPointNavigator.Shortcuts.FANCYUI_SPECIAL_INSTRUCTIONS;
			if (fANCYUI_SPECIAL_INSTRUCTIONS == 1)
			{
				if (PlayerInput.Triggers.JustPressed.HotbarMinus)
				{
					UIVirtualKeyboard.CycleSymbols();
				}
				text += PlayerInput.BuildCommand(Lang.menu[235].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"]);
				if (PlayerInput.Triggers.JustPressed.MouseRight)
				{
					UIVirtualKeyboard.BackSpace();
				}
				text += PlayerInput.BuildCommand(Lang.menu[236].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
				if (PlayerInput.Triggers.JustPressed.SmartCursor)
				{
					UIVirtualKeyboard.Write(" ");
				}
				text += PlayerInput.BuildCommand(Lang.menu[238].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["SmartCursor"]);
				if (UIVirtualKeyboard.CanSubmit)
				{
					if (PlayerInput.Triggers.JustPressed.HotbarPlus)
					{
						UIVirtualKeyboard.Submit();
					}
					text += PlayerInput.BuildCommand(Lang.menu[237].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
				}
			}
			return text;
		}

		public static void HandleOptionsSpecials()
		{
			switch (UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE)
			{
			case 1:
				Main.bgScroll = (int)HandleSlider(Main.bgScroll, 0f, 100f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 1f);
				Main.caveParallax = 1f - (float)Main.bgScroll / 500f;
				break;
			case 2:
				Main.musicVolume = HandleSlider(Main.musicVolume, 0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
				break;
			case 3:
				Main.soundVolume = HandleSlider(Main.soundVolume, 0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
				break;
			case 4:
				Main.ambientVolume = HandleSlider(Main.ambientVolume, 0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
				break;
			case 5:
			{
				float hBar = Main.hBar;
				float num3 = (Main.hBar = HandleSlider(hBar, 0f, 1f));
				if (hBar != num3)
				{
					switch (Main.menuMode)
					{
					case 17:
						Main.player[Main.myPlayer].hairColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 18:
						Main.player[Main.myPlayer].eyeColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 19:
						Main.player[Main.myPlayer].skinColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 21:
						Main.player[Main.myPlayer].shirtColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 22:
						Main.player[Main.myPlayer].underShirtColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 23:
						Main.player[Main.myPlayer].pantsColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 24:
						Main.player[Main.myPlayer].shoeColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 25:
						Main.mouseColorSlider.Hue = num3;
						break;
					case 252:
						Main.mouseBorderColorSlider.Hue = num3;
						break;
					}
					Main.PlaySound(12);
				}
				break;
			}
			case 6:
			{
				float sBar = Main.sBar;
				float num2 = (Main.sBar = HandleSlider(sBar, 0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX));
				if (sBar != num2)
				{
					switch (Main.menuMode)
					{
					case 17:
						Main.player[Main.myPlayer].hairColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 18:
						Main.player[Main.myPlayer].eyeColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 19:
						Main.player[Main.myPlayer].skinColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 21:
						Main.player[Main.myPlayer].shirtColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 22:
						Main.player[Main.myPlayer].underShirtColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 23:
						Main.player[Main.myPlayer].pantsColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 24:
						Main.player[Main.myPlayer].shoeColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 25:
						Main.mouseColorSlider.Saturation = num2;
						break;
					case 252:
						Main.mouseBorderColorSlider.Saturation = num2;
						break;
					}
					Main.PlaySound(12);
				}
				break;
			}
			case 7:
			{
				float lBar = Main.lBar;
				float min = 0.15f;
				if (Main.menuMode == 252)
				{
					min = 0f;
				}
				float num4 = (Main.lBar = HandleSlider(lBar, min, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX));
				if (lBar != num4)
				{
					switch (Main.menuMode)
					{
					case 17:
						Main.player[Main.myPlayer].hairColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 18:
						Main.player[Main.myPlayer].eyeColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 19:
						Main.player[Main.myPlayer].skinColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 21:
						Main.player[Main.myPlayer].shirtColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 22:
						Main.player[Main.myPlayer].underShirtColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 23:
						Main.player[Main.myPlayer].pantsColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 24:
						Main.player[Main.myPlayer].shoeColor = (Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar));
						break;
					case 25:
						Main.mouseColorSlider.Luminance = num4;
						break;
					case 252:
						Main.mouseBorderColorSlider.Luminance = num4;
						break;
					}
					Main.PlaySound(12);
				}
				break;
			}
			case 8:
			{
				float aBar = Main.aBar;
				float num5 = (Main.aBar = HandleSlider(aBar, 0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX));
				if (aBar != num5)
				{
					int menuMode = Main.menuMode;
					if (menuMode == 252)
					{
						Main.mouseBorderColorSlider.Alpha = num5;
					}
					Main.PlaySound(12);
				}
				break;
			}
			case 9:
			{
				bool left = PlayerInput.Triggers.Current.Left;
				bool right = PlayerInput.Triggers.Current.Right;
				if (PlayerInput.Triggers.JustPressed.Left || PlayerInput.Triggers.JustPressed.Right)
				{
					SomeVarsForUILinkers.HairMoveCD = 0;
				}
				else if (SomeVarsForUILinkers.HairMoveCD > 0)
				{
					SomeVarsForUILinkers.HairMoveCD--;
				}
				if (SomeVarsForUILinkers.HairMoveCD == 0 && (left || right))
				{
					if (left)
					{
						Main.PendingPlayer.hair--;
					}
					if (right)
					{
						Main.PendingPlayer.hair++;
					}
					SomeVarsForUILinkers.HairMoveCD = 12;
				}
				int num = 51;
				if (Main.PendingPlayer.hair >= num)
				{
					Main.PendingPlayer.hair = 0;
				}
				if (Main.PendingPlayer.hair < 0)
				{
					Main.PendingPlayer.hair = num - 1;
				}
				break;
			}
			case 10:
				Main.GameZoomTarget = HandleSlider(Main.GameZoomTarget, 1f, 2f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
				break;
			case 11:
				Main.UIScale = HandleSlider(Main.UIScaleWanted, 1f, 2f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
				Main.temporaryGUIScaleSlider = Main.UIScaleWanted;
				break;
			}
		}
	}
}
