using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;

namespace Terraria.GameContent.UI
{
	public class CustomCurrencyManager
	{
		private static int _nextCurrencyIndex = 0;

		private static Dictionary<int, CustomCurrencySystem> _currencies = new Dictionary<int, CustomCurrencySystem>();

		public static void Initialize()
		{
			_nextCurrencyIndex = 0;
			CustomCurrencyID.DefenderMedals = RegisterCurrency(new CustomCurrencySingleCoin(3817, 999L));
		}

		public static int RegisterCurrency(CustomCurrencySystem collection)
		{
			int nextCurrencyIndex = _nextCurrencyIndex;
			_nextCurrencyIndex++;
			_currencies[nextCurrencyIndex] = collection;
			return nextCurrencyIndex;
		}

		public static void DrawSavings(SpriteBatch sb, int currencyIndex, float shopx, float shopy, bool horizontal = false)
		{
			CustomCurrencySystem customCurrencySystem = _currencies[currencyIndex];
			Player player = Main.player[Main.myPlayer];
			bool overFlowing;
			long num = customCurrencySystem.CountCurrency(out overFlowing, player.bank.item);
			long num2 = customCurrencySystem.CountCurrency(out overFlowing, player.bank2.item);
			long num3 = customCurrencySystem.CountCurrency(out overFlowing, player.bank3.item);
			long num4 = customCurrencySystem.CombineStacks(out overFlowing, num, num2, num3);
			if (num4 > 0)
			{
				if (num3 > 0)
				{
					sb.Draw(Main.itemTexture[3813], Utils.CenteredRectangle(new Vector2(shopx + 80f, shopy + 50f), Main.itemTexture[3813].Size() * 0.65f), null, Color.White);
				}
				if (num2 > 0)
				{
					sb.Draw(Main.itemTexture[346], Utils.CenteredRectangle(new Vector2(shopx + 80f, shopy + 50f), Main.itemTexture[346].Size() * 0.65f), null, Color.White);
				}
				if (num > 0)
				{
					sb.Draw(Main.itemTexture[87], Utils.CenteredRectangle(new Vector2(shopx + 70f, shopy + 60f), Main.itemTexture[87].Size() * 0.65f), null, Color.White);
				}
				Utils.DrawBorderStringFourWay(sb, Main.fontMouseText, Lang.inter[66].Value, shopx, shopy + 40f, Color.White * ((float)(int)Main.mouseTextColor / 255f), Color.Black, Vector2.Zero);
				customCurrencySystem.DrawSavingsMoney(sb, Lang.inter[66].Value, shopx, shopy, num4, horizontal);
			}
		}

		public static void GetPriceText(int currencyIndex, string[] lines, ref int currentLine, int price)
		{
			_currencies[currencyIndex].GetPriceText(lines, ref currentLine, price);
		}

		public static bool BuyItem(Player player, int price, int currencyIndex)
		{
			CustomCurrencySystem customCurrencySystem = _currencies[currencyIndex];
			bool overFlowing;
			long num = customCurrencySystem.CountCurrency(out overFlowing, player.inventory, 58, 57, 56, 55, 54);
			long num2 = customCurrencySystem.CountCurrency(out overFlowing, player.bank.item);
			long num3 = customCurrencySystem.CountCurrency(out overFlowing, player.bank2.item);
			long num4 = customCurrencySystem.CountCurrency(out overFlowing, player.bank3.item);
			if (customCurrencySystem.CombineStacks(out overFlowing, num, num2, num3, num4) < price)
			{
				return false;
			}
			List<Item[]> list = new List<Item[]>();
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			List<Point> list2 = new List<Point>();
			List<Point> list3 = new List<Point>();
			List<Point> list4 = new List<Point>();
			List<Point> list5 = new List<Point>();
			List<Point> list6 = new List<Point>();
			list.Add(player.inventory);
			list.Add(player.bank.item);
			list.Add(player.bank2.item);
			list.Add(player.bank3.item);
			for (int i = 0; i < list.Count; i++)
			{
				dictionary[i] = new List<int>();
			}
			dictionary[0] = new List<int> { 58, 57, 56, 55, 54 };
			for (int j = 0; j < list.Count; j++)
			{
				for (int k = 0; k < list[j].Length; k++)
				{
					if (!dictionary[j].Contains(k) && customCurrencySystem.Accepts(list[j][k]))
					{
						list3.Add(new Point(j, k));
					}
				}
			}
			FindEmptySlots(list, dictionary, list2, 0);
			FindEmptySlots(list, dictionary, list4, 1);
			FindEmptySlots(list, dictionary, list5, 2);
			FindEmptySlots(list, dictionary, list6, 3);
			if (!customCurrencySystem.TryPurchasing(price, list, list3, list2, list4, list5, list6))
			{
				return false;
			}
			return true;
		}

		private static void FindEmptySlots(List<Item[]> inventories, Dictionary<int, List<int>> slotsToIgnore, List<Point> emptySlots, int currentInventoryIndex)
		{
			for (int num = inventories[currentInventoryIndex].Length - 1; num >= 0; num--)
			{
				if (!slotsToIgnore[currentInventoryIndex].Contains(num) && (inventories[currentInventoryIndex][num].type == 0 || inventories[currentInventoryIndex][num].stack == 0))
				{
					emptySlots.Add(new Point(currentInventoryIndex, num));
				}
			}
		}
	}
}
