using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.IO;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.GameContent.UI.States
{
	public class UICharacterSelect : UIState
	{
		private static string noteToEveryone = "This code is terrible and you will risk cancer reading it --Yoraiz0r";

		private UIList _playerList;

		private UITextPanel<LocalizedText> _backPanel;

		private UITextPanel<LocalizedText> _newPanel;

		private UIPanel _containerPanel;

		private List<Tuple<string, bool>> favoritesCache = new List<Tuple<string, bool>>();

		private bool skipDraw;

		public override void OnInitialize()
		{
			UIElement uIElement = new UIElement();
			uIElement.Width.Set(0f, 0.8f);
			uIElement.MaxWidth.Set(650f, 0f);
			uIElement.Top.Set(220f, 0f);
			uIElement.Height.Set(-220f, 1f);
			uIElement.HAlign = 0.5f;
			UIPanel uIPanel = new UIPanel();
			uIPanel.Width.Set(0f, 1f);
			uIPanel.Height.Set(-110f, 1f);
			uIPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;
			_containerPanel = uIPanel;
			uIElement.Append(uIPanel);
			_playerList = new UIList();
			_playerList.Width.Set(-25f, 1f);
			_playerList.Height.Set(0f, 1f);
			_playerList.ListPadding = 5f;
			uIPanel.Append(_playerList);
			UIScrollbar uIScrollbar = new UIScrollbar();
			uIScrollbar.SetView(100f, 1000f);
			uIScrollbar.Height.Set(0f, 1f);
			uIScrollbar.HAlign = 1f;
			uIPanel.Append(uIScrollbar);
			_playerList.SetScrollbar(uIScrollbar);
			UITextPanel<LocalizedText> uITextPanel = new UITextPanel<LocalizedText>(Language.GetText("UI.SelectPlayer"), 0.8f, large: true);
			uITextPanel.HAlign = 0.5f;
			uITextPanel.Top.Set(-35f, 0f);
			uITextPanel.SetPadding(15f);
			uITextPanel.BackgroundColor = new Color(73, 94, 171);
			uIElement.Append(uITextPanel);
			UITextPanel<LocalizedText> uITextPanel2 = new UITextPanel<LocalizedText>(Language.GetText("UI.Back"), 0.7f, large: true);
			uITextPanel2.Width.Set(-10f, 0.5f);
			uITextPanel2.Height.Set(50f, 0f);
			uITextPanel2.VAlign = 1f;
			uITextPanel2.Top.Set(-45f, 0f);
			uITextPanel2.OnMouseOver += FadedMouseOver;
			uITextPanel2.OnMouseOut += FadedMouseOut;
			uITextPanel2.OnClick += GoBackClick;
			uITextPanel2.SetSnapPoint("Back", 0);
			uIElement.Append(uITextPanel2);
			_backPanel = uITextPanel2;
			UITextPanel<LocalizedText> uITextPanel3 = new UITextPanel<LocalizedText>(Language.GetText("UI.New"), 0.7f, large: true);
			uITextPanel3.CopyStyle(uITextPanel2);
			uITextPanel3.HAlign = 1f;
			uITextPanel3.OnMouseOver += FadedMouseOver;
			uITextPanel3.OnMouseOut += FadedMouseOut;
			uITextPanel3.OnClick += NewCharacterClick;
			uIElement.Append(uITextPanel3);
			uITextPanel2.SetSnapPoint("New", 0);
			_newPanel = uITextPanel3;
			Append(uIElement);
		}

		private void NewCharacterClick(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(10);
			Player player = new Player();
			player.inventory[0].SetDefaults(3507);
			player.inventory[0].Prefix(-1);
			player.inventory[1].SetDefaults(3509);
			player.inventory[1].Prefix(-1);
			player.inventory[2].SetDefaults(3506);
			player.inventory[2].Prefix(-1);
			Main.PendingPlayer = player;
			Main.menuMode = 2;
		}

		private void GoBackClick(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(11);
			Main.menuMode = 0;
		}

		private void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(12);
			((UIPanel)evt.Target).BackgroundColor = new Color(73, 94, 171);
		}

		private void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			((UIPanel)evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.7f;
		}

		public override void OnActivate()
		{
			Main.ClearPendingPlayerSelectCallbacks();
			Main.LoadPlayers();
			UpdatePlayersList();
			if (PlayerInput.UsingGamepadUI)
			{
				UILinkPointNavigator.ChangePoint(3000 + ((_playerList.Count == 0) ? 1 : 2));
			}
		}

		private void UpdatePlayersList()
		{
			_playerList.Clear();
			List<PlayerFileData> list = new List<PlayerFileData>(Main.PlayerList);
			list.Sort(delegate(PlayerFileData x, PlayerFileData y)
			{
				if (x.IsFavorite && !y.IsFavorite)
				{
					return -1;
				}
				if (!x.IsFavorite && y.IsFavorite)
				{
					return 1;
				}
				return (x.Name.CompareTo(y.Name) != 0) ? x.Name.CompareTo(y.Name) : x.GetFileName().CompareTo(y.GetFileName());
			});
			int num = 0;
			foreach (PlayerFileData item in list)
			{
				_playerList.Add(new UICharacterListItem(item, num++));
			}
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			if (skipDraw)
			{
				skipDraw = false;
				return;
			}
			if (UpdateFavoritesCache())
			{
				skipDraw = true;
				Main.MenuUI.Draw(spriteBatch, new GameTime());
			}
			base.Draw(spriteBatch);
			SetupGamepadPoints(spriteBatch);
		}

		private bool UpdateFavoritesCache()
		{
			List<PlayerFileData> list = new List<PlayerFileData>(Main.PlayerList);
			list.Sort(delegate(PlayerFileData x, PlayerFileData y)
			{
				if (x.IsFavorite && !y.IsFavorite)
				{
					return -1;
				}
				if (!x.IsFavorite && y.IsFavorite)
				{
					return 1;
				}
				return (x.Name.CompareTo(y.Name) != 0) ? x.Name.CompareTo(y.Name) : x.GetFileName().CompareTo(y.GetFileName());
			});
			bool flag = false;
			if (!flag && list.Count != favoritesCache.Count)
			{
				flag = true;
			}
			if (!flag)
			{
				for (int num = 0; num < favoritesCache.Count; num++)
				{
					Tuple<string, bool> tuple = favoritesCache[num];
					if (!(list[num].Name == tuple.Item1) || list[num].IsFavorite != tuple.Item2)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				favoritesCache.Clear();
				foreach (PlayerFileData item in list)
				{
					favoritesCache.Add(Tuple.Create(item.Name, item.IsFavorite));
				}
				UpdatePlayersList();
			}
			return flag;
		}

		private void SetupGamepadPoints(SpriteBatch spriteBatch)
		{
			UILinkPointNavigator.Shortcuts.BackButtonCommand = 1;
			int num = 3000;
			UILinkPointNavigator.SetPosition(num, _backPanel.GetInnerDimensions().ToRectangle().Center.ToVector2());
			UILinkPointNavigator.SetPosition(num + 1, _newPanel.GetInnerDimensions().ToRectangle().Center.ToVector2());
			int num2 = num;
			UILinkPoint uILinkPoint = UILinkPointNavigator.Points[num2];
			uILinkPoint.Unlink();
			uILinkPoint.Right = num2 + 1;
			num2 = num + 1;
			uILinkPoint = UILinkPointNavigator.Points[num2];
			uILinkPoint.Unlink();
			uILinkPoint.Left = num2 - 1;
			Rectangle clippingRectangle = _containerPanel.GetClippingRectangle(spriteBatch);
			Vector2 minimum = clippingRectangle.TopLeft();
			Vector2 maximum = clippingRectangle.BottomRight();
			List<SnapPoint> snapPoints = GetSnapPoints();
			for (int i = 0; i < snapPoints.Count; i++)
			{
				if (!snapPoints[i].Position.Between(minimum, maximum))
				{
					snapPoints.Remove(snapPoints[i]);
					i--;
				}
			}
			SnapPoint[,] array = new SnapPoint[_playerList.Count, 4];
			foreach (SnapPoint item in snapPoints.Where((SnapPoint a) => a.Name == "Play"))
			{
				array[item.ID, 0] = item;
			}
			foreach (SnapPoint item2 in snapPoints.Where((SnapPoint a) => a.Name == "Favorite"))
			{
				array[item2.ID, 1] = item2;
			}
			foreach (SnapPoint item3 in snapPoints.Where((SnapPoint a) => a.Name == "Cloud"))
			{
				array[item3.ID, 2] = item3;
			}
			foreach (SnapPoint item4 in snapPoints.Where((SnapPoint a) => a.Name == "Delete"))
			{
				array[item4.ID, 3] = item4;
			}
			num2 = num + 2;
			int[] array2 = new int[_playerList.Count];
			for (int num3 = 0; num3 < array2.Length; num3++)
			{
				array2[num3] = -1;
			}
			for (int num4 = 0; num4 < 4; num4++)
			{
				int num5 = -1;
				for (int num6 = 0; num6 < array.GetLength(0); num6++)
				{
					if (array[num6, num4] != null)
					{
						uILinkPoint = UILinkPointNavigator.Points[num2];
						uILinkPoint.Unlink();
						UILinkPointNavigator.SetPosition(num2, array[num6, num4].Position);
						if (num5 != -1)
						{
							uILinkPoint.Up = num5;
							UILinkPointNavigator.Points[num5].Down = num2;
						}
						if (array2[num6] != -1)
						{
							uILinkPoint.Left = array2[num6];
							UILinkPointNavigator.Points[array2[num6]].Right = num2;
						}
						uILinkPoint.Down = num;
						if (num4 == 0)
						{
							UILinkPointNavigator.Points[num].Up = (UILinkPointNavigator.Points[num + 1].Up = num2);
						}
						num5 = num2;
						array2[num6] = num2;
						UILinkPointNavigator.Shortcuts.FANCYUI_HIGHEST_INDEX = num2;
						num2++;
					}
				}
			}
			if (PlayerInput.UsingGamepadUI && _playerList.Count == 0 && UILinkPointNavigator.CurrentPoint > 3001)
			{
				UILinkPointNavigator.ChangePoint(3001);
			}
		}
	}
}
