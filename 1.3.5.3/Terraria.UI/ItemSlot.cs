using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.UI;
using Terraria.GameContent.UI.Chat;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;

namespace Terraria.UI
{
	public class ItemSlot
	{
		public class Options
		{
			public static bool DisableLeftShiftTrashCan = false;

			public static bool HighlightNewItems = true;
		}

		public class Context
		{
			public const int InventoryItem = 0;

			public const int InventoryCoin = 1;

			public const int InventoryAmmo = 2;

			public const int ChestItem = 3;

			public const int BankItem = 4;

			public const int PrefixItem = 5;

			public const int TrashItem = 6;

			public const int GuideItem = 7;

			public const int EquipArmor = 8;

			public const int EquipArmorVanity = 9;

			public const int EquipAccessory = 10;

			public const int EquipAccessoryVanity = 11;

			public const int EquipDye = 12;

			public const int HotbarItem = 13;

			public const int ChatItem = 14;

			public const int ShopItem = 15;

			public const int EquipGrapple = 16;

			public const int EquipMount = 17;

			public const int EquipMinecart = 18;

			public const int EquipPet = 19;

			public const int EquipLight = 20;

			public const int MouseItem = 21;

			public const int CraftingMaterial = 22;

			public const int Count = 23;
		}

		public static bool ShiftForcedOn;

		private static Item[] singleSlotArray;

		private static bool[] canFavoriteAt;

		private static float[] inventoryGlowHue;

		private static int[] inventoryGlowTime;

		private static float[] inventoryGlowHueChest;

		private static int[] inventoryGlowTimeChest;

		private static int _customCurrencyForSavings;

		private static int dyeSlotCount;

		private static int accSlotCount;

		public static float CircularRadialOpacity;

		public static float QuicksRadialOpacity;

		public static bool ShiftInUse
		{
			get
			{
				if (!Main.keyState.PressingShift())
				{
					return ShiftForcedOn;
				}
				return true;
			}
		}

		static ItemSlot()
		{
			ShiftForcedOn = false;
			singleSlotArray = new Item[1];
			canFavoriteAt = new bool[23];
			inventoryGlowHue = new float[58];
			inventoryGlowTime = new int[58];
			inventoryGlowHueChest = new float[58];
			inventoryGlowTimeChest = new int[58];
			_customCurrencyForSavings = -1;
			dyeSlotCount = 0;
			accSlotCount = 0;
			CircularRadialOpacity = 0f;
			QuicksRadialOpacity = 0f;
			canFavoriteAt[0] = true;
			canFavoriteAt[1] = true;
			canFavoriteAt[2] = true;
		}

		public static void SetGlow(int index, float hue, bool chest)
		{
			if (chest)
			{
				inventoryGlowTimeChest[index] = 300;
				inventoryGlowHueChest[index] = hue;
			}
			else
			{
				inventoryGlowTime[index] = 300;
				inventoryGlowHue[index] = hue;
			}
		}

		public static void UpdateInterface()
		{
			if (!Main.playerInventory || Main.player[Main.myPlayer].talkNPC == -1)
			{
				_customCurrencyForSavings = -1;
			}
			for (int i = 0; i < inventoryGlowTime.Length; i++)
			{
				if (inventoryGlowTime[i] > 0)
				{
					inventoryGlowTime[i]--;
					if (inventoryGlowTime[i] == 0)
					{
						inventoryGlowHue[i] = 0f;
					}
				}
			}
			for (int j = 0; j < inventoryGlowTimeChest.Length; j++)
			{
				if (inventoryGlowTimeChest[j] > 0)
				{
					inventoryGlowTimeChest[j]--;
					if (inventoryGlowTimeChest[j] == 0)
					{
						inventoryGlowHueChest[j] = 0f;
					}
				}
			}
		}

		public static void Handle(ref Item inv, int context = 0)
		{
			singleSlotArray[0] = inv;
			Handle(singleSlotArray, context);
			inv = singleSlotArray[0];
			Recipe.FindRecipes();
		}

		public static void Handle(Item[] inv, int context = 0, int slot = 0)
		{
			OverrideHover(inv, context, slot);
			if (Main.mouseLeftRelease && Main.mouseLeft)
			{
				LeftClick(inv, context, slot);
				Recipe.FindRecipes();
			}
			else
			{
				RightClick(inv, context, slot);
			}
			MouseHover(inv, context, slot);
		}

		public static void OverrideHover(Item[] inv, int context = 0, int slot = 0)
		{
			Item item = inv[slot];
			if (ShiftInUse && item.type > 0 && item.stack > 0 && !inv[slot].favorited)
			{
				switch (context)
				{
				case 0:
				case 1:
				case 2:
					if (Main.npcShop > 0 && !item.favorited)
					{
						Main.cursorOverride = 10;
					}
					else if (Main.player[Main.myPlayer].chest != -1)
					{
						if (ChestUI.TryPlacingInChest(item, justCheck: true))
						{
							Main.cursorOverride = 9;
						}
					}
					else
					{
						Main.cursorOverride = 6;
					}
					break;
				case 3:
				case 4:
					if (Main.player[Main.myPlayer].ItemSpace(item))
					{
						Main.cursorOverride = 8;
					}
					break;
				case 5:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 16:
				case 17:
				case 18:
				case 19:
				case 20:
					if (Main.player[Main.myPlayer].ItemSpace(inv[slot]))
					{
						Main.cursorOverride = 7;
					}
					break;
				}
			}
			if (Main.keyState.IsKeyDown(Main.FavoriteKey) && canFavoriteAt[context])
			{
				if (item.type > 0 && item.stack > 0 && Main.drawingPlayerChat)
				{
					Main.cursorOverride = 2;
				}
				else if (item.type > 0 && item.stack > 0)
				{
					Main.cursorOverride = 3;
				}
			}
		}

		private static bool OverrideLeftClick(Item[] inv, int context = 0, int slot = 0)
		{
			Item item = inv[slot];
			if (Main.cursorOverride == 2)
			{
				if (ChatManager.AddChatText(Main.fontMouseText, ItemTagHandler.GenerateTag(item), Vector2.One))
				{
					Main.PlaySound(12);
				}
				return true;
			}
			if (Main.cursorOverride == 3)
			{
				if (!canFavoriteAt[context])
				{
					return false;
				}
				item.favorited = !item.favorited;
				Main.PlaySound(12);
				return true;
			}
			if (Main.cursorOverride == 7)
			{
				inv[slot] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, inv[slot], longText: false, noText: true);
				Main.PlaySound(12);
				return true;
			}
			if (Main.cursorOverride == 8)
			{
				inv[slot] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, inv[slot], longText: false, noText: true);
				if (Main.player[Main.myPlayer].chest > -1)
				{
					NetMessage.SendData(32, -1, -1, null, Main.player[Main.myPlayer].chest, slot);
				}
				return true;
			}
			if (Main.cursorOverride == 9)
			{
				ChestUI.TryPlacingInChest(inv[slot], justCheck: false);
				return true;
			}
			return false;
		}

		public static void LeftClick(ref Item inv, int context = 0)
		{
			singleSlotArray[0] = inv;
			LeftClick(singleSlotArray, context);
			inv = singleSlotArray[0];
		}

		public static void LeftClick(Item[] inv, int context = 0, int slot = 0)
		{
			if (OverrideLeftClick(inv, context, slot))
			{
				return;
			}
			inv[slot].newAndShiny = false;
			Player player = Main.player[Main.myPlayer];
			bool flag = false;
			if ((uint)context <= 4u)
			{
				flag = player.chest == -1;
			}
			if (ShiftInUse && flag)
			{
				SellOrTrash(inv, context, slot);
			}
			else
			{
				if (player.itemAnimation != 0 || player.itemTime != 0)
				{
					return;
				}
				switch (PickItemMovementAction(inv, context, slot, Main.mouseItem))
				{
				case 0:
					if (context == 6 && Main.mouseItem.type != 0)
					{
						inv[slot].SetDefaults();
					}
					Utils.Swap(ref inv[slot], ref Main.mouseItem);
					if (inv[slot].stack > 0)
					{
						switch (context)
						{
						case 0:
							AchievementsHelper.NotifyItemPickup(player, inv[slot]);
							break;
						case 8:
						case 9:
						case 10:
						case 11:
						case 12:
						case 16:
						case 17:
							AchievementsHelper.HandleOnEquip(player, inv[slot], context);
							break;
						}
					}
					if (inv[slot].type == 0 || inv[slot].stack < 1)
					{
						inv[slot] = new Item();
					}
					if (Main.mouseItem.IsTheSameAs(inv[slot]))
					{
						Utils.Swap(ref inv[slot].favorited, ref Main.mouseItem.favorited);
						if (inv[slot].stack != inv[slot].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
						{
							if (Main.mouseItem.stack + inv[slot].stack <= Main.mouseItem.maxStack)
							{
								inv[slot].stack += Main.mouseItem.stack;
								Main.mouseItem.stack = 0;
							}
							else
							{
								int num = Main.mouseItem.maxStack - inv[slot].stack;
								inv[slot].stack += num;
								Main.mouseItem.stack -= num;
							}
						}
					}
					if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
					{
						Main.mouseItem = new Item();
					}
					if (Main.mouseItem.type > 0 || inv[slot].type > 0)
					{
						Recipe.FindRecipes();
						Main.PlaySound(7);
					}
					if (context == 3 && Main.netMode == 1)
					{
						NetMessage.SendData(32, -1, -1, null, player.chest, slot);
					}
					break;
				case 1:
					if (Main.mouseItem.stack == 1 && Main.mouseItem.type > 0 && inv[slot].type > 0 && inv[slot].IsNotTheSameAs(Main.mouseItem))
					{
						Utils.Swap(ref inv[slot], ref Main.mouseItem);
						Main.PlaySound(7);
						if (inv[slot].stack > 0)
						{
							switch (context)
							{
							case 0:
								AchievementsHelper.NotifyItemPickup(player, inv[slot]);
								break;
							case 8:
							case 9:
							case 10:
							case 11:
							case 12:
							case 16:
							case 17:
								AchievementsHelper.HandleOnEquip(player, inv[slot], context);
								break;
							}
						}
					}
					else if (Main.mouseItem.type == 0 && inv[slot].type > 0)
					{
						Utils.Swap(ref inv[slot], ref Main.mouseItem);
						if (inv[slot].type == 0 || inv[slot].stack < 1)
						{
							inv[slot] = new Item();
						}
						if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
						{
							Main.mouseItem = new Item();
						}
						if (Main.mouseItem.type > 0 || inv[slot].type > 0)
						{
							Recipe.FindRecipes();
							Main.PlaySound(7);
						}
					}
					else
					{
						if (Main.mouseItem.type <= 0 || inv[slot].type != 0)
						{
							break;
						}
						if (Main.mouseItem.stack == 1)
						{
							Utils.Swap(ref inv[slot], ref Main.mouseItem);
							if (inv[slot].type == 0 || inv[slot].stack < 1)
							{
								inv[slot] = new Item();
							}
							if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
							{
								Main.mouseItem = new Item();
							}
							if (Main.mouseItem.type > 0 || inv[slot].type > 0)
							{
								Recipe.FindRecipes();
								Main.PlaySound(7);
							}
						}
						else
						{
							Main.mouseItem.stack--;
							inv[slot].SetDefaults(Main.mouseItem.type);
							Recipe.FindRecipes();
							Main.PlaySound(7);
						}
						if (inv[slot].stack > 0)
						{
							switch (context)
							{
							case 0:
								AchievementsHelper.NotifyItemPickup(player, inv[slot]);
								break;
							case 8:
							case 9:
							case 10:
							case 11:
							case 12:
							case 16:
							case 17:
								AchievementsHelper.HandleOnEquip(player, inv[slot], context);
								break;
							}
						}
					}
					break;
				case 2:
					if (Main.mouseItem.stack == 1 && Main.mouseItem.dye > 0 && inv[slot].type > 0 && inv[slot].type != Main.mouseItem.type)
					{
						Utils.Swap(ref inv[slot], ref Main.mouseItem);
						Main.PlaySound(7);
						if (inv[slot].stack > 0)
						{
							switch (context)
							{
							case 0:
								AchievementsHelper.NotifyItemPickup(player, inv[slot]);
								break;
							case 8:
							case 9:
							case 10:
							case 11:
							case 12:
							case 16:
							case 17:
								AchievementsHelper.HandleOnEquip(player, inv[slot], context);
								break;
							}
						}
					}
					else if (Main.mouseItem.type == 0 && inv[slot].type > 0)
					{
						Utils.Swap(ref inv[slot], ref Main.mouseItem);
						if (inv[slot].type == 0 || inv[slot].stack < 1)
						{
							inv[slot] = new Item();
						}
						if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
						{
							Main.mouseItem = new Item();
						}
						if (Main.mouseItem.type > 0 || inv[slot].type > 0)
						{
							Recipe.FindRecipes();
							Main.PlaySound(7);
						}
					}
					else
					{
						if (Main.mouseItem.dye <= 0 || inv[slot].type != 0)
						{
							break;
						}
						if (Main.mouseItem.stack == 1)
						{
							Utils.Swap(ref inv[slot], ref Main.mouseItem);
							if (inv[slot].type == 0 || inv[slot].stack < 1)
							{
								inv[slot] = new Item();
							}
							if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
							{
								Main.mouseItem = new Item();
							}
							if (Main.mouseItem.type > 0 || inv[slot].type > 0)
							{
								Recipe.FindRecipes();
								Main.PlaySound(7);
							}
						}
						else
						{
							Main.mouseItem.stack--;
							inv[slot].SetDefaults(Main.mouseItem.type);
							Recipe.FindRecipes();
							Main.PlaySound(7);
						}
						if (inv[slot].stack > 0)
						{
							switch (context)
							{
							case 0:
								AchievementsHelper.NotifyItemPickup(player, inv[slot]);
								break;
							case 8:
							case 9:
							case 10:
							case 11:
							case 12:
							case 16:
							case 17:
								AchievementsHelper.HandleOnEquip(player, inv[slot], context);
								break;
							}
						}
					}
					break;
				case 3:
					Main.mouseItem.netDefaults(inv[slot].netID);
					if (inv[slot].buyOnce)
					{
						Main.mouseItem.Prefix(inv[slot].prefix);
					}
					else
					{
						Main.mouseItem.Prefix(-1);
					}
					Main.mouseItem.position = player.Center - new Vector2(Main.mouseItem.width, Main.mouseItem.headSlot) / 2f;
					ItemText.NewText(Main.mouseItem, Main.mouseItem.stack);
					if (inv[slot].buyOnce && --inv[slot].stack <= 0)
					{
						inv[slot].SetDefaults();
					}
					if (inv[slot].value > 0)
					{
						Main.PlaySound(18);
					}
					else
					{
						Main.PlaySound(7);
					}
					break;
				case 4:
				{
					Chest chest = Main.instance.shop[Main.npcShop];
					if (player.SellItem(Main.mouseItem.value, Main.mouseItem.stack))
					{
						chest.AddShop(Main.mouseItem);
						Main.mouseItem.SetDefaults();
						Main.PlaySound(18);
					}
					else if (Main.mouseItem.value == 0)
					{
						chest.AddShop(Main.mouseItem);
						Main.mouseItem.SetDefaults();
						Main.PlaySound(7);
					}
					Recipe.FindRecipes();
					break;
				}
				}
				if ((uint)context > 2u && context != 5)
				{
					inv[slot].favorited = false;
				}
			}
		}

		private static void SellOrTrash(Item[] inv, int context, int slot)
		{
			Player player = Main.player[Main.myPlayer];
			if (inv[slot].type <= 0)
			{
				return;
			}
			if (Main.npcShop > 0 && !inv[slot].favorited)
			{
				Chest chest = Main.instance.shop[Main.npcShop];
				if (inv[slot].type < 71 || inv[slot].type > 74)
				{
					if (player.SellItem(inv[slot].value, inv[slot].stack))
					{
						chest.AddShop(inv[slot]);
						inv[slot].SetDefaults();
						Main.PlaySound(18);
						Recipe.FindRecipes();
					}
					else if (inv[slot].value == 0)
					{
						chest.AddShop(inv[slot]);
						inv[slot].SetDefaults();
						Main.PlaySound(7);
						Recipe.FindRecipes();
					}
				}
			}
			else if (!inv[slot].favorited && !Options.DisableLeftShiftTrashCan)
			{
				Main.PlaySound(7);
				player.trashItem = inv[slot].Clone();
				inv[slot].SetDefaults();
				if (context == 3 && Main.netMode == 1)
				{
					NetMessage.SendData(32, -1, -1, null, player.chest, slot);
				}
				Recipe.FindRecipes();
			}
		}

		private static string GetOverrideInstructions(Item[] inv, int context, int slot)
		{
			Player player = Main.player[Main.myPlayer];
			if (inv[slot].type > 0 && inv[slot].stack > 0)
			{
				if (!inv[slot].favorited)
				{
					switch (context)
					{
					case 0:
					case 1:
					case 2:
						if (Main.npcShop > 0 && !inv[slot].favorited)
						{
							return Lang.misc[75].Value;
						}
						if (Main.player[Main.myPlayer].chest != -1)
						{
							if (ChestUI.TryPlacingInChest(inv[slot], justCheck: true))
							{
								return Lang.misc[76].Value;
							}
							break;
						}
						return Lang.misc[74].Value;
					case 3:
					case 4:
						if (Main.player[Main.myPlayer].ItemSpace(inv[slot]))
						{
							return Lang.misc[76].Value;
						}
						break;
					case 5:
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 16:
					case 17:
					case 18:
					case 19:
					case 20:
						if (Main.player[Main.myPlayer].ItemSpace(inv[slot]))
						{
							return Lang.misc[68].Value;
						}
						break;
					}
				}
				bool flag = false;
				if ((uint)context <= 4u)
				{
					flag = player.chest == -1;
				}
				if (flag)
				{
					if (Main.npcShop > 0 && !inv[slot].favorited)
					{
						_ = Main.instance.shop[Main.npcShop];
						if (inv[slot].type >= 71 && inv[slot].type <= 74)
						{
							return "";
						}
						return Lang.misc[75].Value;
					}
					if (!inv[slot].favorited && !Options.DisableLeftShiftTrashCan)
					{
						return Lang.misc[74].Value;
					}
				}
			}
			return "";
		}

		public static int PickItemMovementAction(Item[] inv, int context, int slot, Item checkItem)
		{
			Player player = Main.player[Main.myPlayer];
			int result = -1;
			switch (context)
			{
			case 0:
				result = 0;
				break;
			case 1:
				if (checkItem.type == 0 || checkItem.type == 71 || checkItem.type == 72 || checkItem.type == 73 || checkItem.type == 74)
				{
					result = 0;
				}
				break;
			case 2:
				if (((checkItem.type == 0 || checkItem.ammo > 0 || checkItem.bait > 0) && !checkItem.notAmmo) || checkItem.type == 530)
				{
					result = 0;
				}
				break;
			case 3:
				result = 0;
				break;
			case 4:
				result = 0;
				break;
			case 5:
				if (checkItem.Prefix(-3) || checkItem.type == 0)
				{
					result = 0;
				}
				break;
			case 6:
				result = 0;
				break;
			case 7:
				if (checkItem.material || checkItem.type == 0)
				{
					result = 0;
				}
				break;
			case 8:
				if (checkItem.type == 0 || (checkItem.headSlot > -1 && slot == 0) || (checkItem.bodySlot > -1 && slot == 1) || (checkItem.legSlot > -1 && slot == 2))
				{
					result = 1;
				}
				break;
			case 9:
				if (checkItem.type == 0 || (checkItem.headSlot > -1 && slot == 10) || (checkItem.bodySlot > -1 && slot == 11) || (checkItem.legSlot > -1 && slot == 12))
				{
					result = 1;
				}
				break;
			case 10:
				if (checkItem.type == 0 || (checkItem.accessory && !AccCheck(checkItem, slot)))
				{
					result = 1;
				}
				break;
			case 11:
				if (checkItem.type == 0 || (checkItem.accessory && !AccCheck(checkItem, slot)))
				{
					result = 1;
				}
				break;
			case 12:
				result = 2;
				break;
			case 15:
				if (checkItem.type == 0 && inv[slot].type > 0)
				{
					if (player.BuyItem(inv[slot].GetStoreValue(), inv[slot].shopSpecialCurrency))
					{
						result = 3;
					}
				}
				else if (inv[slot].type == 0 && checkItem.type > 0 && (checkItem.type < 71 || checkItem.type > 74))
				{
					result = 4;
				}
				break;
			case 16:
				if (checkItem.type == 0 || Main.projHook[checkItem.shoot])
				{
					result = 1;
				}
				break;
			case 17:
				if (checkItem.type == 0 || (checkItem.mountType != -1 && !MountID.Sets.Cart[checkItem.mountType]))
				{
					result = 1;
				}
				break;
			case 19:
				if (checkItem.type == 0 || (checkItem.buffType > 0 && Main.vanityPet[checkItem.buffType] && !Main.lightPet[checkItem.buffType]))
				{
					result = 1;
				}
				break;
			case 18:
				if (checkItem.type == 0 || (checkItem.mountType != -1 && MountID.Sets.Cart[checkItem.mountType]))
				{
					result = 1;
				}
				break;
			case 20:
				if (checkItem.type == 0 || (checkItem.buffType > 0 && Main.lightPet[checkItem.buffType]))
				{
					result = 1;
				}
				break;
			}
			return result;
		}

		public static void RightClick(ref Item inv, int context = 0)
		{
			singleSlotArray[0] = inv;
			RightClick(singleSlotArray, context);
			inv = singleSlotArray[0];
		}

		public static void RightClick(Item[] inv, int context = 0, int slot = 0)
		{
			Player player = Main.player[Main.myPlayer];
			inv[slot].newAndShiny = false;
			if (player.itemAnimation > 0)
			{
				return;
			}
			bool flag = false;
			switch (context)
			{
			case 0:
				flag = true;
				if (Main.mouseRight && ((inv[slot].type >= 3318 && inv[slot].type <= 3332) || inv[slot].type == 3860 || inv[slot].type == 3862 || inv[slot].type == 3861))
				{
					if (Main.mouseRightRelease)
					{
						player.OpenBossBag(inv[slot].type);
						inv[slot].stack--;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults();
						}
						Main.PlaySound(7);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && ((inv[slot].type >= 2334 && inv[slot].type <= 2336) || (inv[slot].type >= 3203 && inv[slot].type <= 3208)))
				{
					if (Main.mouseRightRelease)
					{
						player.openCrate(inv[slot].type);
						inv[slot].stack--;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults();
						}
						Main.PlaySound(7);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && inv[slot].type == 3093)
				{
					if (Main.mouseRightRelease)
					{
						player.openHerbBag();
						inv[slot].stack--;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults();
						}
						Main.PlaySound(7);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && inv[slot].type == 1774)
				{
					if (Main.mouseRightRelease)
					{
						inv[slot].stack--;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults();
						}
						Main.PlaySound(7);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						player.openGoodieBag();
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && inv[slot].type == 3085)
				{
					if (Main.mouseRightRelease && player.ConsumeItem(327))
					{
						inv[slot].stack--;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults();
						}
						Main.PlaySound(7);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						player.openLockBox();
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && inv[slot].type == 1869)
				{
					if (Main.mouseRightRelease)
					{
						inv[slot].stack--;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults();
						}
						Main.PlaySound(7);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						player.openPresent();
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && Main.mouseRightRelease && (inv[slot].type == 599 || inv[slot].type == 600 || inv[slot].type == 601))
				{
					Main.PlaySound(7);
					Main.stackSplit = 30;
					Main.mouseRightRelease = false;
					int num2 = Main.rand.Next(14);
					if (num2 == 0 && Main.hardMode)
					{
						inv[slot].SetDefaults(602);
					}
					else if (num2 <= 7)
					{
						inv[slot].SetDefaults(586);
						inv[slot].stack = Main.rand.Next(20, 50);
					}
					else
					{
						inv[slot].SetDefaults(591);
						inv[slot].stack = Main.rand.Next(20, 50);
					}
					Recipe.FindRecipes();
				}
				else
				{
					flag = false;
				}
				break;
			case 9:
			case 11:
			{
				flag = true;
				if (!Main.mouseRight || !Main.mouseRightRelease || ((inv[slot].type <= 0 || inv[slot].stack <= 0) && (inv[slot - 10].type <= 0 || inv[slot - 10].stack <= 0)))
				{
					break;
				}
				bool flag2 = true;
				if (flag2 && context == 11 && inv[slot].wingSlot > 0)
				{
					for (int j = 3; j < 10; j++)
					{
						if (inv[j].wingSlot > 0 && j != slot - 10)
						{
							flag2 = false;
						}
					}
				}
				if (!flag2)
				{
					break;
				}
				Utils.Swap(ref inv[slot], ref inv[slot - 10]);
				Main.PlaySound(7);
				Recipe.FindRecipes();
				if (inv[slot].stack > 0)
				{
					switch (context)
					{
					case 0:
						AchievementsHelper.NotifyItemPickup(player, inv[slot]);
						break;
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 16:
					case 17:
						AchievementsHelper.HandleOnEquip(player, inv[slot], context);
						break;
					}
				}
				break;
			}
			case 12:
				flag = true;
				if (Main.mouseRight && Main.mouseRightRelease && Main.mouseItem.stack < Main.mouseItem.maxStack && Main.mouseItem.type > 0 && inv[slot].type > 0 && Main.mouseItem.type == inv[slot].type)
				{
					Main.mouseItem.stack++;
					inv[slot].SetDefaults();
					Main.PlaySound(7);
				}
				break;
			case 15:
			{
				flag = true;
				_ = Main.instance.shop[Main.npcShop];
				if (Main.stackSplit > 1 || !Main.mouseRight || inv[slot].type <= 0 || (!Main.mouseItem.IsTheSameAs(inv[slot]) && Main.mouseItem.type != 0))
				{
					break;
				}
				int num = Main.superFastStack + 1;
				for (int i = 0; i < num; i++)
				{
					if ((Main.mouseItem.stack >= Main.mouseItem.maxStack && Main.mouseItem.type != 0) || !player.BuyItem(inv[slot].GetStoreValue(), inv[slot].shopSpecialCurrency) || inv[slot].stack <= 0)
					{
						continue;
					}
					if (i == 0)
					{
						Main.PlaySound(18);
					}
					if (Main.mouseItem.type == 0)
					{
						Main.mouseItem.netDefaults(inv[slot].netID);
						if (inv[slot].prefix != 0)
						{
							Main.mouseItem.Prefix(inv[slot].prefix);
						}
						Main.mouseItem.stack = 0;
					}
					Main.mouseItem.stack++;
					if (Main.stackSplit == 0)
					{
						Main.stackSplit = 15;
					}
					else
					{
						Main.stackSplit = Main.stackDelay;
					}
					if (inv[slot].buyOnce && --inv[slot].stack <= 0)
					{
						inv[slot].SetDefaults();
					}
				}
				break;
			}
			}
			if (flag)
			{
				return;
			}
			if ((context == 0 || context == 4 || context == 3) && Main.mouseRight && Main.mouseRightRelease && inv[slot].maxStack == 1)
			{
				SwapEquip(inv, context, slot);
			}
			else
			{
				if (Main.stackSplit > 1 || !Main.mouseRight)
				{
					return;
				}
				bool flag3 = true;
				if (context == 0 && inv[slot].maxStack <= 1)
				{
					flag3 = false;
				}
				if (context == 3 && inv[slot].maxStack <= 1)
				{
					flag3 = false;
				}
				if (context == 4 && inv[slot].maxStack <= 1)
				{
					flag3 = false;
				}
				if (!flag3 || (!Main.mouseItem.IsTheSameAs(inv[slot]) && Main.mouseItem.type != 0) || (Main.mouseItem.stack >= Main.mouseItem.maxStack && Main.mouseItem.type != 0))
				{
					return;
				}
				if (Main.mouseItem.type == 0)
				{
					Main.mouseItem = inv[slot].Clone();
					Main.mouseItem.stack = 0;
					if (inv[slot].favorited && inv[slot].maxStack == 1)
					{
						Main.mouseItem.favorited = true;
					}
					else
					{
						Main.mouseItem.favorited = false;
					}
				}
				Main.mouseItem.stack++;
				inv[slot].stack--;
				if (inv[slot].stack <= 0)
				{
					inv[slot] = new Item();
				}
				Recipe.FindRecipes();
				Main.soundInstanceMenuTick.Stop();
				Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
				Main.PlaySound(12);
				if (Main.stackSplit == 0)
				{
					Main.stackSplit = 15;
				}
				else
				{
					Main.stackSplit = Main.stackDelay;
				}
				if (context == 3 && Main.netMode == 1)
				{
					NetMessage.SendData(32, -1, -1, null, player.chest, slot);
				}
			}
		}

		public static bool Equippable(ref Item inv, int context = 0)
		{
			singleSlotArray[0] = inv;
			bool result = Equippable(singleSlotArray, context, 0);
			inv = singleSlotArray[0];
			return result;
		}

		public static bool Equippable(Item[] inv, int context, int slot)
		{
			_ = Main.player[Main.myPlayer];
			if (inv[slot].dye > 0 || Main.projHook[inv[slot].shoot] || inv[slot].mountType != -1 || (inv[slot].buffType > 0 && Main.lightPet[inv[slot].buffType]) || (inv[slot].buffType > 0 && Main.vanityPet[inv[slot].buffType]) || inv[slot].headSlot >= 0 || inv[slot].bodySlot >= 0 || inv[slot].legSlot >= 0 || inv[slot].accessory)
			{
				return true;
			}
			return false;
		}

		public static void SwapEquip(ref Item inv, int context = 0)
		{
			singleSlotArray[0] = inv;
			SwapEquip(singleSlotArray, context, 0);
			inv = singleSlotArray[0];
		}

		public static void SwapEquip(Item[] inv, int context, int slot)
		{
			Player player = Main.player[Main.myPlayer];
			bool success;
			if (inv[slot].dye > 0)
			{
				inv[slot] = DyeSwap(inv[slot], out success);
				if (success)
				{
					Main.EquipPageSelected = 0;
					AchievementsHelper.HandleOnEquip(player, inv[slot], 12);
				}
			}
			else if (Main.projHook[inv[slot].shoot])
			{
				inv[slot] = EquipSwap(inv[slot], player.miscEquips, 4, out success);
				if (success)
				{
					Main.EquipPageSelected = 2;
					AchievementsHelper.HandleOnEquip(player, inv[slot], 16);
				}
			}
			else if (inv[slot].mountType != -1 && !MountID.Sets.Cart[inv[slot].mountType])
			{
				inv[slot] = EquipSwap(inv[slot], player.miscEquips, 3, out success);
				if (success)
				{
					Main.EquipPageSelected = 2;
					AchievementsHelper.HandleOnEquip(player, inv[slot], 17);
				}
			}
			else if (inv[slot].mountType != -1 && MountID.Sets.Cart[inv[slot].mountType])
			{
				inv[slot] = EquipSwap(inv[slot], player.miscEquips, 2, out success);
				if (success)
				{
					Main.EquipPageSelected = 2;
				}
			}
			else if (inv[slot].buffType > 0 && Main.lightPet[inv[slot].buffType])
			{
				inv[slot] = EquipSwap(inv[slot], player.miscEquips, 1, out success);
				if (success)
				{
					Main.EquipPageSelected = 2;
				}
			}
			else if (inv[slot].buffType > 0 && Main.vanityPet[inv[slot].buffType])
			{
				inv[slot] = EquipSwap(inv[slot], player.miscEquips, 0, out success);
				if (success)
				{
					Main.EquipPageSelected = 2;
				}
			}
			else
			{
				Item item = inv[slot];
				inv[slot] = ArmorSwap(inv[slot], out success);
				if (success)
				{
					Main.EquipPageSelected = 0;
					AchievementsHelper.HandleOnEquip(player, item, item.accessory ? 10 : 8);
				}
			}
			Recipe.FindRecipes();
			if (context == 3 && Main.netMode == 1)
			{
				NetMessage.SendData(32, -1, -1, null, player.chest, slot);
			}
		}

		public static void Draw(SpriteBatch spriteBatch, ref Item inv, int context, Vector2 position, Color lightColor = default(Color))
		{
			singleSlotArray[0] = inv;
			Draw(spriteBatch, singleSlotArray, context, 0, position, lightColor);
			inv = singleSlotArray[0];
		}

		public static void Draw(SpriteBatch spriteBatch, Item[] inv, int context, int slot, Vector2 position, Color lightColor = default(Color))
		{
			Player player = Main.player[Main.myPlayer];
			Item item = inv[slot];
			float inventoryScale = Main.inventoryScale;
			Color color = Color.White;
			if (lightColor != Color.Transparent)
			{
				color = lightColor;
			}
			int num = -1;
			bool flag = false;
			int num2 = 0;
			if (PlayerInput.UsingGamepadUI)
			{
				switch (context)
				{
				case 0:
				case 1:
				case 2:
					num = slot;
					break;
				case 8:
				case 9:
				case 10:
				case 11:
					num = 100 + slot;
					break;
				case 12:
					if (inv == player.dye)
					{
						num = 120 + slot;
					}
					if (inv == player.miscDyes)
					{
						num = 185 + slot;
					}
					break;
				case 19:
					num = 180;
					break;
				case 20:
					num = 181;
					break;
				case 18:
					num = 182;
					break;
				case 17:
					num = 183;
					break;
				case 16:
					num = 184;
					break;
				case 3:
				case 4:
					num = 400 + slot;
					break;
				case 15:
					num = 2700 + slot;
					break;
				case 6:
					num = 300;
					break;
				case 22:
					if (UILinkPointNavigator.Shortcuts.CRAFT_CurrentRecipeBig != -1)
					{
						num = 700 + UILinkPointNavigator.Shortcuts.CRAFT_CurrentRecipeBig;
					}
					if (UILinkPointNavigator.Shortcuts.CRAFT_CurrentRecipeSmall != -1)
					{
						num = 1500 + UILinkPointNavigator.Shortcuts.CRAFT_CurrentRecipeSmall + 1;
					}
					break;
				case 7:
					num = 1500;
					break;
				case 5:
					num = 303;
					break;
				}
				flag = UILinkPointNavigator.CurrentPoint == num;
				if (context == 0)
				{
					num2 = player.DpadRadial.GetDrawMode(slot);
					if (num2 > 0 && !PlayerInput.CurrentProfile.UsingDpadHotbar())
					{
						num2 = 0;
					}
				}
			}
			Texture2D texture2D = Main.inventoryBackTexture;
			Color color2 = Main.inventoryBack;
			bool flag2 = false;
			if (item.type > 0 && item.stack > 0 && item.favorited && context != 13 && context != 21 && context != 22 && context != 14)
			{
				texture2D = Main.inventoryBack10Texture;
			}
			else if (item.type > 0 && item.stack > 0 && Options.HighlightNewItems && item.newAndShiny && context != 13 && context != 21 && context != 14 && context != 22)
			{
				texture2D = Main.inventoryBack15Texture;
				float num3 = (float)(int)Main.mouseTextColor / 255f;
				num3 = num3 * 0.2f + 0.8f;
				color2 = color2.MultiplyRGBA(new Color(num3, num3, num3));
			}
			else if (PlayerInput.UsingGamepadUI && item.type > 0 && item.stack > 0 && num2 != 0 && context != 13 && context != 21 && context != 22)
			{
				texture2D = Main.inventoryBack15Texture;
				float num4 = (float)(int)Main.mouseTextColor / 255f;
				num4 = num4 * 0.2f + 0.8f;
				color2 = ((num2 != 1) ? color2.MultiplyRGBA(new Color(num4 / 2f, num4, num4 / 2f)) : color2.MultiplyRGBA(new Color(num4, num4 / 2f, num4 / 2f)));
			}
			else if (context == 0 && slot < 10)
			{
				texture2D = Main.inventoryBack9Texture;
			}
			else
			{
				switch (context)
				{
				case 8:
				case 10:
				case 16:
				case 17:
				case 18:
				case 19:
				case 20:
					texture2D = Main.inventoryBack3Texture;
					break;
				case 9:
				case 11:
					texture2D = Main.inventoryBack8Texture;
					break;
				case 12:
					texture2D = Main.inventoryBack12Texture;
					break;
				case 3:
					texture2D = Main.inventoryBack5Texture;
					break;
				case 4:
					texture2D = Main.inventoryBack2Texture;
					break;
				case 5:
				case 7:
					texture2D = Main.inventoryBack4Texture;
					break;
				case 6:
					texture2D = Main.inventoryBack7Texture;
					break;
				case 13:
				{
					byte b = 200;
					if (slot == Main.player[Main.myPlayer].selectedItem)
					{
						texture2D = Main.inventoryBack14Texture;
						b = byte.MaxValue;
					}
					color2 = new Color(b, b, b, b);
					break;
				}
				case 14:
				case 21:
					flag2 = true;
					break;
				case 15:
					texture2D = Main.inventoryBack6Texture;
					break;
				case 22:
					texture2D = Main.inventoryBack4Texture;
					break;
				}
			}
			if (context == 0 && inventoryGlowTime[slot] > 0 && !inv[slot].favorited)
			{
				float num5 = Main.invAlpha / 255f;
				Color value = new Color(63, 65, 151, 255) * num5;
				Color value2 = Main.hslToRgb(inventoryGlowHue[slot], 1f, 0.5f) * num5;
				float num6 = (float)inventoryGlowTime[slot] / 300f;
				num6 *= num6;
				color2 = Color.Lerp(value, value2, num6 / 2f);
				texture2D = Main.inventoryBack13Texture;
			}
			if ((context == 4 || context == 3) && inventoryGlowTimeChest[slot] > 0 && !inv[slot].favorited)
			{
				float num7 = Main.invAlpha / 255f;
				Color value3 = new Color(130, 62, 102, 255) * num7;
				if (context == 3)
				{
					value3 = new Color(104, 52, 52, 255) * num7;
				}
				Color value4 = Main.hslToRgb(inventoryGlowHueChest[slot], 1f, 0.5f) * num7;
				float num8 = (float)inventoryGlowTimeChest[slot] / 300f;
				num8 *= num8;
				color2 = Color.Lerp(value3, value4, num8 / 2f);
				texture2D = Main.inventoryBack13Texture;
			}
			if (flag)
			{
				texture2D = Main.inventoryBack14Texture;
				color2 = Color.White;
			}
			if (!flag2)
			{
				spriteBatch.Draw(texture2D, position, null, color2, 0f, default(Vector2), inventoryScale, SpriteEffects.None, 0f);
			}
			int num9 = -1;
			switch (context)
			{
			case 8:
				if (slot == 0)
				{
					num9 = 0;
				}
				if (slot == 1)
				{
					num9 = 6;
				}
				if (slot == 2)
				{
					num9 = 12;
				}
				break;
			case 9:
				if (slot == 10)
				{
					num9 = 3;
				}
				if (slot == 11)
				{
					num9 = 9;
				}
				if (slot == 12)
				{
					num9 = 15;
				}
				break;
			case 10:
				num9 = 11;
				break;
			case 11:
				num9 = 2;
				break;
			case 12:
				num9 = 1;
				break;
			case 16:
				num9 = 4;
				break;
			case 17:
				num9 = 13;
				break;
			case 19:
				num9 = 10;
				break;
			case 18:
				num9 = 7;
				break;
			case 20:
				num9 = 17;
				break;
			}
			if ((item.type <= 0 || item.stack <= 0) && num9 != -1)
			{
				Texture2D texture2D2 = Main.extraTexture[54];
				Rectangle rectangle = texture2D2.Frame(3, 6, num9 % 3, num9 / 3);
				rectangle.Width -= 2;
				rectangle.Height -= 2;
				spriteBatch.Draw(texture2D2, position + texture2D.Size() / 2f * inventoryScale, rectangle, Color.White * 0.35f, 0f, rectangle.Size() / 2f, inventoryScale, SpriteEffects.None, 0f);
			}
			Vector2 vector = texture2D.Size() * inventoryScale;
			if (item.type > 0 && item.stack > 0)
			{
				Texture2D texture2D3 = Main.itemTexture[item.type];
				Rectangle rectangle2 = ((Main.itemAnimations[item.type] == null) ? texture2D3.Frame() : Main.itemAnimations[item.type].GetFrame(texture2D3));
				Color currentColor = color;
				float scale = 1f;
				GetItemLight(ref currentColor, ref scale, item);
				float num10 = 1f;
				if (rectangle2.Width > 32 || rectangle2.Height > 32)
				{
					num10 = ((rectangle2.Width <= rectangle2.Height) ? (32f / (float)rectangle2.Height) : (32f / (float)rectangle2.Width));
				}
				num10 *= inventoryScale;
				Vector2 position2 = position + vector / 2f - rectangle2.Size() * num10 / 2f;
				Vector2 origin = rectangle2.Size() * (scale / 2f - 0.5f);
				spriteBatch.Draw(texture2D3, position2, rectangle2, item.GetAlpha(currentColor), 0f, origin, num10 * scale, SpriteEffects.None, 0f);
				if (item.color != Color.Transparent)
				{
					spriteBatch.Draw(texture2D3, position2, rectangle2, item.GetColor(color), 0f, origin, num10 * scale, SpriteEffects.None, 0f);
				}
				if (ItemID.Sets.TrapSigned[item.type])
				{
					spriteBatch.Draw(Main.wireTexture, position + new Vector2(40f, 40f) * inventoryScale, new Rectangle(4, 58, 8, 8), color, 0f, new Vector2(4f), 1f, SpriteEffects.None, 0f);
				}
				if (item.stack > 1)
				{
					ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, item.stack.ToString(), position + new Vector2(10f, 26f) * inventoryScale, color, 0f, Vector2.Zero, new Vector2(inventoryScale), -1f, inventoryScale);
				}
				int num11 = -1;
				if (context == 13)
				{
					if (item.DD2Summon)
					{
						for (int i = 0; i < 58; i++)
						{
							if (inv[i].type == 3822)
							{
								num11 += inv[i].stack;
							}
						}
						if (num11 >= 0)
						{
							num11++;
						}
					}
					if (item.useAmmo > 0)
					{
						int useAmmo = item.useAmmo;
						num11 = 0;
						for (int j = 0; j < 58; j++)
						{
							if (inv[j].ammo == useAmmo)
							{
								num11 += inv[j].stack;
							}
						}
					}
					if (item.fishingPole > 0)
					{
						num11 = 0;
						for (int k = 0; k < 58; k++)
						{
							if (inv[k].bait > 0)
							{
								num11 += inv[k].stack;
							}
						}
					}
					if (item.tileWand > 0)
					{
						int tileWand = item.tileWand;
						num11 = 0;
						for (int l = 0; l < 58; l++)
						{
							if (inv[l].type == tileWand)
							{
								num11 += inv[l].stack;
							}
						}
					}
					if (item.type == 509 || item.type == 851 || item.type == 850 || item.type == 3612 || item.type == 3625 || item.type == 3611)
					{
						num11 = 0;
						for (int m = 0; m < 58; m++)
						{
							if (inv[m].type == 530)
							{
								num11 += inv[m].stack;
							}
						}
					}
				}
				if (num11 != -1)
				{
					ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, num11.ToString(), position + new Vector2(8f, 30f) * inventoryScale, color, 0f, Vector2.Zero, new Vector2(inventoryScale * 0.8f), -1f, inventoryScale);
				}
				if (context == 13)
				{
					string text = string.Concat(slot + 1);
					if (text == "10")
					{
						text = "0";
					}
					ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, text, position + new Vector2(8f, 4f) * inventoryScale, color, 0f, Vector2.Zero, new Vector2(inventoryScale), -1f, inventoryScale);
				}
				if (context == 13 && item.potion)
				{
					Vector2 position3 = position + texture2D.Size() * inventoryScale / 2f - Main.cdTexture.Size() * inventoryScale / 2f;
					Color color3 = item.GetAlpha(color) * ((float)player.potionDelay / (float)player.potionDelayTime);
					spriteBatch.Draw(Main.cdTexture, position3, null, color3, 0f, default(Vector2), num10, SpriteEffects.None, 0f);
				}
				if ((context == 10 || context == 18) && item.expertOnly && !Main.expertMode)
				{
					Vector2 position4 = position + texture2D.Size() * inventoryScale / 2f - Main.cdTexture.Size() * inventoryScale / 2f;
					Color white = Color.White;
					spriteBatch.Draw(Main.cdTexture, position4, null, white, 0f, default(Vector2), num10, SpriteEffects.None, 0f);
				}
			}
			else if (context == 6)
			{
				Texture2D trashTexture = Main.trashTexture;
				Vector2 position5 = position + texture2D.Size() * inventoryScale / 2f - trashTexture.Size() * inventoryScale / 2f;
				spriteBatch.Draw(trashTexture, position5, null, new Color(100, 100, 100, 100), 0f, default(Vector2), inventoryScale, SpriteEffects.None, 0f);
			}
			if (context == 0 && slot < 10)
			{
				float num12 = inventoryScale;
				string text2 = string.Concat(slot + 1);
				if (text2 == "10")
				{
					text2 = "0";
				}
				Color inventoryBack = Main.inventoryBack;
				int num13 = 0;
				if (Main.player[Main.myPlayer].selectedItem == slot)
				{
					num13 -= 3;
					inventoryBack.R = byte.MaxValue;
					inventoryBack.B = 0;
					inventoryBack.G = 210;
					inventoryBack.A = 100;
					num12 *= 1.4f;
				}
				ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, text2, position + new Vector2(6f, 4 + num13) * inventoryScale, inventoryBack, 0f, Vector2.Zero, new Vector2(inventoryScale), -1f, inventoryScale);
			}
			if (num != -1)
			{
				UILinkPointNavigator.SetPosition(num, position + vector * 0.75f);
			}
		}

		public static void MouseHover(ref Item inv, int context = 0)
		{
			singleSlotArray[0] = inv;
			MouseHover(singleSlotArray, context);
			inv = singleSlotArray[0];
		}

		public static void MouseHover(Item[] inv, int context = 0, int slot = 0)
		{
			if (context == 6 && Main.hoverItemName == null)
			{
				Main.hoverItemName = Lang.inter[3].Value;
			}
			if (inv[slot].type > 0 && inv[slot].stack > 0)
			{
				_customCurrencyForSavings = inv[slot].shopSpecialCurrency;
				Main.hoverItemName = inv[slot].Name;
				if (inv[slot].stack > 1)
				{
					Main.hoverItemName = Main.hoverItemName + " (" + inv[slot].stack + ")";
				}
				Main.HoverItem = inv[slot].Clone();
				if (context == 8 && slot <= 2)
				{
					Main.HoverItem.wornArmor = true;
				}
				if (context == 11 || context == 9)
				{
					Main.HoverItem.social = true;
				}
				if (context == 15)
				{
					Main.HoverItem.buy = true;
				}
				return;
			}
			if (context == 10 || context == 11)
			{
				Main.hoverItemName = Lang.inter[9].Value;
			}
			if (context == 11)
			{
				Main.hoverItemName = Lang.inter[11].Value + " " + Main.hoverItemName;
			}
			if (context == 8 || context == 9)
			{
				if (slot == 0 || slot == 10)
				{
					Main.hoverItemName = Lang.inter[12].Value;
				}
				if (slot == 1 || slot == 11)
				{
					Main.hoverItemName = Lang.inter[13].Value;
				}
				if (slot == 2 || slot == 12)
				{
					Main.hoverItemName = Lang.inter[14].Value;
				}
				if (slot >= 10)
				{
					Main.hoverItemName = Lang.inter[11].Value + " " + Main.hoverItemName;
				}
			}
			if (context == 12)
			{
				Main.hoverItemName = Lang.inter[57].Value;
			}
			if (context == 16)
			{
				Main.hoverItemName = Lang.inter[90].Value;
			}
			if (context == 17)
			{
				Main.hoverItemName = Lang.inter[91].Value;
			}
			if (context == 19)
			{
				Main.hoverItemName = Lang.inter[92].Value;
			}
			if (context == 18)
			{
				Main.hoverItemName = Lang.inter[93].Value;
			}
			if (context == 20)
			{
				Main.hoverItemName = Lang.inter[94].Value;
			}
		}

		private static bool AccCheck(Item item, int slot)
		{
			Player player = Main.player[Main.myPlayer];
			if (slot != -1)
			{
				if (player.armor[slot].IsTheSameAs(item))
				{
					return false;
				}
				if (player.armor[slot].wingSlot > 0 && item.wingSlot > 0)
				{
					return false;
				}
			}
			for (int i = 0; i < player.armor.Length; i++)
			{
				if (slot < 10 && i < 10)
				{
					if (item.wingSlot > 0 && player.armor[i].wingSlot > 0)
					{
						return true;
					}
					if (slot >= 10 && i >= 10 && item.wingSlot > 0 && player.armor[i].wingSlot > 0)
					{
						return true;
					}
				}
				if (item.IsTheSameAs(player.armor[i]))
				{
					return true;
				}
			}
			return false;
		}

		private static Item DyeSwap(Item item, out bool success)
		{
			success = false;
			if (item.dye <= 0)
			{
				return item;
			}
			Player player = Main.player[Main.myPlayer];
			Item item2 = item;
			for (int i = 0; i < 10; i++)
			{
				if (player.dye[i].type == 0)
				{
					dyeSlotCount = i;
					break;
				}
			}
			if (dyeSlotCount >= 10)
			{
				dyeSlotCount = 0;
			}
			if (dyeSlotCount < 0)
			{
				dyeSlotCount = 9;
			}
			item2 = player.dye[dyeSlotCount].Clone();
			player.dye[dyeSlotCount] = item.Clone();
			dyeSlotCount++;
			if (dyeSlotCount >= 10)
			{
				accSlotCount = 0;
			}
			Main.PlaySound(7);
			Recipe.FindRecipes();
			success = true;
			return item2;
		}

		private static Item ArmorSwap(Item item, out bool success)
		{
			success = false;
			if (item.headSlot == -1 && item.bodySlot == -1 && item.legSlot == -1 && !item.accessory)
			{
				return item;
			}
			Player player = Main.player[Main.myPlayer];
			int num = ((item.vanity && !item.accessory) ? 10 : 0);
			item.favorited = false;
			Item result = item;
			if (item.headSlot != -1)
			{
				result = player.armor[num].Clone();
				player.armor[num] = item.Clone();
			}
			else if (item.bodySlot != -1)
			{
				result = player.armor[num + 1].Clone();
				player.armor[num + 1] = item.Clone();
			}
			else if (item.legSlot != -1)
			{
				result = player.armor[num + 2].Clone();
				player.armor[num + 2] = item.Clone();
			}
			else if (item.accessory)
			{
				int num2 = 5 + Main.player[Main.myPlayer].extraAccessorySlots;
				for (int i = 3; i < 3 + num2; i++)
				{
					if (player.armor[i].type == 0)
					{
						accSlotCount = i - 3;
						break;
					}
				}
				for (int j = 0; j < player.armor.Length; j++)
				{
					if (item.IsTheSameAs(player.armor[j]))
					{
						accSlotCount = j - 3;
					}
					if (j < 10 && item.wingSlot > 0 && player.armor[j].wingSlot > 0)
					{
						accSlotCount = j - 3;
					}
				}
				if (accSlotCount >= num2)
				{
					accSlotCount = 0;
				}
				if (accSlotCount < 0)
				{
					accSlotCount = num2 - 1;
				}
				int num3 = 3 + accSlotCount;
				for (int k = 0; k < player.armor.Length; k++)
				{
					if (item.IsTheSameAs(player.armor[k]))
					{
						num3 = k;
					}
				}
				result = player.armor[num3].Clone();
				player.armor[num3] = item.Clone();
				accSlotCount++;
				if (accSlotCount >= num2)
				{
					accSlotCount = 0;
				}
			}
			Main.PlaySound(7);
			Recipe.FindRecipes();
			success = true;
			return result;
		}

		private static Item EquipSwap(Item item, Item[] inv, int slot, out bool success)
		{
			success = false;
			_ = Main.player[Main.myPlayer];
			item.favorited = false;
			Item result = inv[slot].Clone();
			inv[slot] = item.Clone();
			Main.PlaySound(7);
			Recipe.FindRecipes();
			success = true;
			return result;
		}

		public static void EquipPage(Item item)
		{
			Main.EquipPage = -1;
			if (Main.projHook[item.shoot])
			{
				Main.EquipPage = 2;
			}
			else if (item.mountType != -1)
			{
				Main.EquipPage = 2;
			}
			else if (item.buffType > 0 && Main.vanityPet[item.buffType])
			{
				Main.EquipPage = 2;
			}
			else if (item.buffType > 0 && Main.lightPet[item.buffType])
			{
				Main.EquipPage = 2;
			}
			else if (item.dye > 0 && Main.EquipPageSelected == 1)
			{
				Main.EquipPage = 0;
			}
			else if (item.legSlot != -1 || item.headSlot != -1 || item.bodySlot != -1 || item.accessory)
			{
				Main.EquipPage = 0;
			}
		}

		public static void DrawMoney(SpriteBatch sb, string text, float shopx, float shopy, int[] coinsArray, bool horizontal = false)
		{
			Utils.DrawBorderStringFourWay(sb, Main.fontMouseText, text, shopx, shopy + 40f, Color.White * ((float)(int)Main.mouseTextColor / 255f), Color.Black, Vector2.Zero);
			if (horizontal)
			{
				for (int i = 0; i < 4; i++)
				{
					if (i == 0)
					{
						_ = coinsArray[3 - i];
						_ = 99;
					}
					Vector2 position = new Vector2(shopx + ChatManager.GetStringSize(Main.fontMouseText, text, Vector2.One).X + (float)(24 * i) + 45f, shopy + 50f);
					sb.Draw(Main.itemTexture[74 - i], position, null, Color.White, 0f, Main.itemTexture[74 - i].Size() / 2f, 1f, SpriteEffects.None, 0f);
					Utils.DrawBorderStringFourWay(sb, Main.fontItemStack, coinsArray[3 - i].ToString(), position.X - 11f, position.Y, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
				}
			}
			else
			{
				for (int j = 0; j < 4; j++)
				{
					int num = ((j == 0 && coinsArray[3 - j] > 99) ? (-6) : 0);
					sb.Draw(Main.itemTexture[74 - j], new Vector2(shopx + 11f + (float)(24 * j), shopy + 75f), null, Color.White, 0f, Main.itemTexture[74 - j].Size() / 2f, 1f, SpriteEffects.None, 0f);
					Utils.DrawBorderStringFourWay(sb, Main.fontItemStack, coinsArray[3 - j].ToString(), shopx + (float)(24 * j) + (float)num, shopy + 75f, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
				}
			}
		}

		public static void DrawSavings(SpriteBatch sb, float shopx, float shopy, bool horizontal = false)
		{
			Player player = Main.player[Main.myPlayer];
			if (_customCurrencyForSavings != -1)
			{
				CustomCurrencyManager.DrawSavings(sb, _customCurrencyForSavings, shopx, shopy, horizontal);
				return;
			}
			bool overFlowing;
			long num = Utils.CoinsCount(out overFlowing, player.bank.item);
			long num2 = Utils.CoinsCount(out overFlowing, player.bank2.item);
			long num3 = Utils.CoinsCount(out overFlowing, player.bank3.item);
			long num4 = Utils.CoinsCombineStacks(out overFlowing, num, num2, num3);
			if (num4 > 0)
			{
				if (num3 > 0)
				{
					sb.Draw(Main.itemTexture[3813], Utils.CenteredRectangle(new Vector2(shopx + 92f, shopy + 45f), Main.itemTexture[3813].Size() * 0.65f), null, Color.White);
				}
				if (num2 > 0)
				{
					sb.Draw(Main.itemTexture[346], Utils.CenteredRectangle(new Vector2(shopx + 80f, shopy + 50f), Main.itemTexture[346].Size() * 0.65f), null, Color.White);
				}
				if (num > 0)
				{
					sb.Draw(Main.itemTexture[87], Utils.CenteredRectangle(new Vector2(shopx + 70f, shopy + 60f), Main.itemTexture[87].Size() * 0.65f), null, Color.White);
				}
				DrawMoney(sb, Lang.inter[66].Value, shopx, shopy, Utils.CoinsSplit(num4), horizontal);
			}
		}

		public static void DrawRadialDpad(SpriteBatch sb, Vector2 position)
		{
			if (!PlayerInput.UsingGamepad || !PlayerInput.CurrentProfile.UsingDpadHotbar())
			{
				return;
			}
			Player player = Main.player[Main.myPlayer];
			if (player.chest != -1)
			{
				return;
			}
			Texture2D texture2D = Main.hotbarRadialTexture[0];
			float num = (float)(int)Main.mouseTextColor / 255f;
			float num2 = 1f - (1f - num) * (1f - num);
			num2 *= 0.785f;
			Color color = Color.White * num2;
			sb.Draw(texture2D, position, null, color, 0f, texture2D.Size() / 2f, Main.inventoryScale, SpriteEffects.None, 0f);
			for (int i = 0; i < 4; i++)
			{
				int num3 = player.DpadRadial.Bindings[i];
				if (num3 != -1)
				{
					Draw(sb, player.inventory, 14, num3, position + new Vector2(texture2D.Width / 3, 0f).RotatedBy(-(float)Math.PI / 2f + (float)Math.PI / 2f * (float)i) + new Vector2(-26f * Main.inventoryScale), Color.White);
				}
			}
		}

		public static void DrawRadialCircular(SpriteBatch sb, Vector2 position)
		{
			CircularRadialOpacity = MathHelper.Clamp(CircularRadialOpacity + ((PlayerInput.UsingGamepad && PlayerInput.Triggers.Current.RadialHotbar) ? 0.25f : (-0.15f)), 0f, 1f);
			if (CircularRadialOpacity == 0f)
			{
				return;
			}
			Player player = Main.player[Main.myPlayer];
			Texture2D texture2D = Main.hotbarRadialTexture[2];
			float num = CircularRadialOpacity * 0.9f;
			float num2 = CircularRadialOpacity * 1f;
			float num3 = (float)(int)Main.mouseTextColor / 255f;
			float num4 = 1f - (1f - num3) * (1f - num3);
			num4 *= 0.785f;
			Color color = Color.White * num4 * num;
			texture2D = Main.hotbarRadialTexture[1];
			float num5 = (float)Math.PI * 2f / (float)player.CircularRadial.RadialCount;
			float num6 = -(float)Math.PI / 2f;
			for (int i = 0; i < player.CircularRadial.RadialCount; i++)
			{
				int num7 = player.CircularRadial.Bindings[i];
				Vector2 vector = new Vector2(150f, 0f).RotatedBy(num6 + num5 * (float)i) * num2;
				float num8 = 0.85f;
				if (player.CircularRadial.SelectedBinding == i)
				{
					num8 = 1.7f;
				}
				sb.Draw(texture2D, position + vector, null, color * num8, 0f, texture2D.Size() / 2f, num2 * num8, SpriteEffects.None, 0f);
				if (num7 != -1)
				{
					float inventoryScale = Main.inventoryScale;
					Main.inventoryScale = num2 * num8;
					Draw(sb, player.inventory, 14, num7, position + vector + new Vector2(-26f * num2 * num8), Color.White);
					Main.inventoryScale = inventoryScale;
				}
			}
		}

		public static void DrawRadialQuicks(SpriteBatch sb, Vector2 position)
		{
			QuicksRadialOpacity = MathHelper.Clamp(QuicksRadialOpacity + ((PlayerInput.UsingGamepad && PlayerInput.Triggers.Current.RadialQuickbar) ? 0.25f : (-0.15f)), 0f, 1f);
			if (QuicksRadialOpacity == 0f)
			{
				return;
			}
			Player player = Main.player[Main.myPlayer];
			Texture2D texture2D = Main.hotbarRadialTexture[2];
			Texture2D quicksIconTexture = Main.quicksIconTexture;
			float num = QuicksRadialOpacity * 0.9f;
			float num2 = QuicksRadialOpacity * 1f;
			float num3 = (float)(int)Main.mouseTextColor / 255f;
			float num4 = 1f - (1f - num3) * (1f - num3);
			num4 *= 0.785f;
			Color color = Color.White * num4 * num;
			float num5 = (float)Math.PI * 2f / (float)player.QuicksRadial.RadialCount;
			float num6 = -(float)Math.PI / 2f;
			Item item = player.QuickHeal_GetItemToUse();
			Item item2 = player.QuickMana_GetItemToUse();
			Item item3 = null;
			if (item == null)
			{
				item = new Item();
				item.SetDefaults(28);
			}
			if (item2 == null)
			{
				item2 = new Item();
				item2.SetDefaults(110);
			}
			if (item3 == null)
			{
				item3 = new Item();
				item3.SetDefaults(292);
			}
			for (int i = 0; i < player.QuicksRadial.RadialCount; i++)
			{
				Item inv = item;
				if (i == 1)
				{
					inv = item3;
				}
				if (i == 2)
				{
					inv = item2;
				}
				_ = player.QuicksRadial.Bindings[i];
				Vector2 vector = new Vector2(120f, 0f).RotatedBy(num6 + num5 * (float)i) * num2;
				float num7 = 0.85f;
				if (player.QuicksRadial.SelectedBinding == i)
				{
					num7 = 1.7f;
				}
				sb.Draw(texture2D, position + vector, null, color * num7, 0f, texture2D.Size() / 2f, num2 * num7 * 1.3f, SpriteEffects.None, 0f);
				float inventoryScale = Main.inventoryScale;
				Main.inventoryScale = num2 * num7;
				Draw(sb, ref inv, 14, position + vector + new Vector2(-26f * num2 * num7), Color.White);
				Main.inventoryScale = inventoryScale;
				sb.Draw(quicksIconTexture, position + vector + new Vector2(34f, 20f) * 0.85f * num2 * num7, null, color * num7, 0f, texture2D.Size() / 2f, num2 * num7 * 1.3f, SpriteEffects.None, 0f);
			}
		}

		public static void GetItemLight(ref Color currentColor, Item item, bool outInTheWorld = false)
		{
			float scale = 1f;
			GetItemLight(ref currentColor, ref scale, item, outInTheWorld);
		}

		public static void GetItemLight(ref Color currentColor, int type, bool outInTheWorld = false)
		{
			float scale = 1f;
			GetItemLight(ref currentColor, ref scale, type, outInTheWorld);
		}

		public static void GetItemLight(ref Color currentColor, ref float scale, Item item, bool outInTheWorld = false)
		{
			GetItemLight(ref currentColor, ref scale, item.type, outInTheWorld);
		}

		public static Color GetItemLight(ref Color currentColor, ref float scale, int type, bool outInTheWorld = false)
		{
			if (type < 0 || type > 3930)
			{
				return currentColor;
			}
			if (type == 662 || type == 663)
			{
				currentColor.R = (byte)Main.DiscoR;
				currentColor.G = (byte)Main.DiscoG;
				currentColor.B = (byte)Main.DiscoB;
				currentColor.A = byte.MaxValue;
			}
			else if (ItemID.Sets.ItemIconPulse[type])
			{
				scale = Main.essScale;
				currentColor.R = (byte)((float)(int)currentColor.R * scale);
				currentColor.G = (byte)((float)(int)currentColor.G * scale);
				currentColor.B = (byte)((float)(int)currentColor.B * scale);
				currentColor.A = (byte)((float)(int)currentColor.A * scale);
			}
			else if (type == 58 || type == 184)
			{
				scale = Main.essScale * 0.25f + 0.75f;
				currentColor.R = (byte)((float)(int)currentColor.R * scale);
				currentColor.G = (byte)((float)(int)currentColor.G * scale);
				currentColor.B = (byte)((float)(int)currentColor.B * scale);
				currentColor.A = (byte)((float)(int)currentColor.A * scale);
			}
			return currentColor;
		}

		public static string GetGamepadInstructions(ref Item inv, int context = 0)
		{
			singleSlotArray[0] = inv;
			string gamepadInstructions = GetGamepadInstructions(singleSlotArray, context);
			inv = singleSlotArray[0];
			return gamepadInstructions;
		}

		public static string GetGamepadInstructions(Item[] inv, int context = 0, int slot = 0)
		{
			Player player = Main.player[Main.myPlayer];
			string text = "";
			if (inv == null || inv[slot] == null || Main.mouseItem == null)
			{
				return text;
			}
			if (context == 0 || context == 1 || context == 2)
			{
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					if (Main.mouseItem.type > 0)
					{
						text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
						if (inv[slot].type == Main.mouseItem.type && Main.mouseItem.stack < inv[slot].maxStack && inv[slot].maxStack > 1)
						{
							text += PlayerInput.BuildCommand(Lang.misc[55].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
						}
					}
					else
					{
						if (context == 0 && player.chest == -1)
						{
							player.DpadRadial.ChangeBinding(slot);
						}
						text += PlayerInput.BuildCommand(Lang.misc[54].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
						if (inv[slot].maxStack > 1)
						{
							text += PlayerInput.BuildCommand(Lang.misc[55].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
						}
					}
					if (inv[slot].maxStack == 1 && Equippable(inv, context, slot))
					{
						text += PlayerInput.BuildCommand(Lang.misc[67].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							SwapEquip(inv, context, slot);
						}
					}
					text += PlayerInput.BuildCommand(Lang.misc[83].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["SmartCursor"]);
					if (PlayerInput.Triggers.JustPressed.SmartCursor)
					{
						inv[slot].favorited = !inv[slot].favorited;
					}
				}
				else if (Main.mouseItem.type > 0)
				{
					text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
				}
			}
			if (context == 3 || context == 4)
			{
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					if (Main.mouseItem.type > 0)
					{
						text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
						if (inv[slot].type == Main.mouseItem.type && Main.mouseItem.stack < inv[slot].maxStack && inv[slot].maxStack > 1)
						{
							text += PlayerInput.BuildCommand(Lang.misc[55].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
						}
					}
					else
					{
						text += PlayerInput.BuildCommand(Lang.misc[54].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
						if (inv[slot].maxStack > 1)
						{
							text += PlayerInput.BuildCommand(Lang.misc[55].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
						}
					}
					if (inv[slot].maxStack == 1 && Equippable(inv, context, slot))
					{
						text += PlayerInput.BuildCommand(Lang.misc[67].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							SwapEquip(inv, context, slot);
						}
					}
				}
				else if (Main.mouseItem.type > 0)
				{
					text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
				}
			}
			if (context == 15)
			{
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					if (Main.mouseItem.type > 0)
					{
						if (inv[slot].type == Main.mouseItem.type && Main.mouseItem.stack < inv[slot].maxStack && inv[slot].maxStack > 1)
						{
							text += PlayerInput.BuildCommand(Lang.misc[91].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
						}
					}
					else
					{
						text += PlayerInput.BuildCommand(Lang.misc[90].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"], PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
					}
				}
				else if (Main.mouseItem.type > 0)
				{
					text += PlayerInput.BuildCommand(Lang.misc[92].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
				}
			}
			if (context == 8 || context == 9 || context == 16 || context == 17 || context == 18 || context == 19 || context == 20)
			{
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					if (Main.mouseItem.type > 0)
					{
						if (Equippable(ref Main.mouseItem, context))
						{
							text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
						}
					}
					else
					{
						text += PlayerInput.BuildCommand(Lang.misc[54].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
					}
					if (context == 8 && slot >= 3)
					{
						bool flag = player.hideVisual[slot];
						text += PlayerInput.BuildCommand(Lang.misc[flag ? 77 : 78].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							player.hideVisual[slot] = !player.hideVisual[slot];
							Main.PlaySound(12);
							if (Main.netMode == 1)
							{
								NetMessage.SendData(4, -1, -1, null, Main.myPlayer);
							}
						}
					}
					if ((context == 16 || context == 17 || context == 18 || context == 19 || context == 20) && slot < 2)
					{
						bool flag2 = player.hideMisc[slot];
						text += PlayerInput.BuildCommand(Lang.misc[flag2 ? 77 : 78].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							player.hideMisc[slot] = !player.hideMisc[slot];
							Main.PlaySound(12);
							if (Main.netMode == 1)
							{
								NetMessage.SendData(4, -1, -1, null, Main.myPlayer);
							}
						}
					}
				}
				else
				{
					if (Main.mouseItem.type > 0 && Equippable(ref Main.mouseItem, context))
					{
						text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
					}
					if (context == 8 && slot >= 3)
					{
						bool flag3 = player.hideVisual[slot];
						text += PlayerInput.BuildCommand(Lang.misc[flag3 ? 77 : 78].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							player.hideVisual[slot] = !player.hideVisual[slot];
							Main.PlaySound(12);
							if (Main.netMode == 1)
							{
								NetMessage.SendData(4, -1, -1, null, Main.myPlayer);
							}
						}
					}
					if ((context == 16 || context == 17 || context == 18 || context == 19 || context == 20) && slot < 2)
					{
						bool flag4 = player.hideMisc[slot];
						text += PlayerInput.BuildCommand(Lang.misc[flag4 ? 77 : 78].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
						if (PlayerInput.Triggers.JustPressed.Grapple)
						{
							if (slot == 0)
							{
								player.TogglePet();
							}
							if (slot == 1)
							{
								player.ToggleLight();
							}
							Main.mouseLeftRelease = false;
							Main.PlaySound(12);
							if (Main.netMode == 1)
							{
								NetMessage.SendData(4, -1, -1, null, Main.myPlayer);
							}
						}
					}
				}
			}
			switch (context)
			{
			case 12:
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					if (Main.mouseItem.type > 0)
					{
						if (Main.mouseItem.dye > 0)
						{
							text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
						}
					}
					else
					{
						text += PlayerInput.BuildCommand(Lang.misc[54].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
					}
					if (context == 12)
					{
						int num2 = -1;
						if (inv == player.dye)
						{
							num2 = slot;
						}
						if (inv == player.miscDyes)
						{
							num2 = 10 + slot;
						}
						if (num2 != -1)
						{
							if (num2 < 10)
							{
								bool flag5 = player.hideVisual[slot];
								text += PlayerInput.BuildCommand(Lang.misc[flag5 ? 77 : 78].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
								if (PlayerInput.Triggers.JustPressed.Grapple)
								{
									player.hideVisual[slot] = !player.hideVisual[slot];
									Main.PlaySound(12);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(4, -1, -1, null, Main.myPlayer);
									}
								}
							}
							else
							{
								bool flag6 = player.hideMisc[slot];
								text += PlayerInput.BuildCommand(Lang.misc[flag6 ? 77 : 78].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["Grapple"]);
								if (PlayerInput.Triggers.JustPressed.Grapple)
								{
									player.hideMisc[slot] = !player.hideMisc[slot];
									Main.PlaySound(12);
									if (Main.netMode == 1)
									{
										NetMessage.SendData(4, -1, -1, null, Main.myPlayer);
									}
								}
							}
						}
					}
				}
				else if (Main.mouseItem.type > 0 && Main.mouseItem.dye > 0)
				{
					text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
				}
				return text;
			case 6:
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					text = ((Main.mouseItem.type <= 0) ? (text + PlayerInput.BuildCommand(Lang.misc[54].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"])) : (text + PlayerInput.BuildCommand(Lang.misc[74].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"])));
				}
				else if (Main.mouseItem.type > 0)
				{
					text += PlayerInput.BuildCommand(Lang.misc[74].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
				}
				return text;
			case 5:
			case 7:
			{
				bool flag7 = false;
				if (context == 5)
				{
					flag7 = Main.mouseItem.Prefix(-3) || Main.mouseItem.type == 0;
				}
				if (context == 7)
				{
					flag7 = Main.mouseItem.material;
				}
				if (inv[slot].type > 0 && inv[slot].stack > 0)
				{
					if (Main.mouseItem.type > 0)
					{
						if (flag7)
						{
							text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
						}
					}
					else
					{
						text += PlayerInput.BuildCommand(Lang.misc[54].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
					}
				}
				else if (Main.mouseItem.type > 0 && flag7)
				{
					text += PlayerInput.BuildCommand(Lang.misc[65].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseLeft"]);
				}
				return text;
			}
			default:
			{
				string overrideInstructions = GetOverrideInstructions(inv, context, slot);
				if (Main.mouseItem.type > 0 && (context == 0 || context == 1 || context == 2 || context == 6 || context == 15 || context == 7) && string.IsNullOrEmpty(overrideInstructions))
				{
					text += PlayerInput.BuildCommand(Lang.inter[121].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["SmartSelect"]);
					if (PlayerInput.Triggers.JustPressed.SmartSelect)
					{
						player.DropSelectedItem();
					}
				}
				else if (!string.IsNullOrEmpty(overrideInstructions))
				{
					ShiftForcedOn = true;
					int cursorOverride = Main.cursorOverride;
					OverrideHover(inv, context, slot);
					if (-1 != Main.cursorOverride)
					{
						text += PlayerInput.BuildCommand(overrideInstructions, false, PlayerInput.ProfileGamepadUI.KeyStatus["SmartSelect"]);
						if (PlayerInput.Triggers.JustPressed.SmartSelect)
						{
							LeftClick(inv, context, slot);
						}
					}
					Main.cursorOverride = cursorOverride;
					ShiftForcedOn = false;
				}
				int num = 0;
				if (IsABuildingItem(Main.mouseItem))
				{
					num = 1;
				}
				if (num == 0 && Main.mouseItem.stack <= 0 && context == 0 && IsABuildingItem(inv[slot]))
				{
					num = 2;
				}
				if (Main.autoPause)
				{
					num = 0;
				}
				if (num > 0)
				{
					Item item = Main.mouseItem;
					if (num == 1)
					{
						item = Main.mouseItem;
					}
					if (num == 2)
					{
						item = inv[slot];
					}
					if (num != 1 || player.ItemSpace(item))
					{
						text = ((item.damage > 0 && item.ammo == 0) ? (text + PlayerInput.BuildCommand(Lang.misc[60].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["QuickMount"])) : ((item.createTile < 0 && item.createWall <= 0) ? (text + PlayerInput.BuildCommand(Lang.misc[63].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["QuickMount"])) : (text + PlayerInput.BuildCommand(Lang.misc[61].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["QuickMount"]))));
					}
					if (PlayerInput.Triggers.JustPressed.QuickMount)
					{
						PlayerInput.EnterBuildingMode();
					}
				}
				return text;
			}
			}
		}

		public static bool IsABuildingItem(Item item)
		{
			if (item.type > 0 && item.stack > 0 && item.useStyle > 0)
			{
				return item.useTime > 0;
			}
			return false;
		}
	}
}
