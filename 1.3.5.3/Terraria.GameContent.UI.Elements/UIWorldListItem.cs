using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.OS;
using Terraria.Graphics;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Social;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	public class UIWorldListItem : UIPanel
	{
		private WorldFileData _data;

		private Texture2D _dividerTexture;

		private Texture2D _innerPanelTexture;

		private UIImage _worldIcon;

		private UIText _buttonLabel;

		private UIText _deleteButtonLabel;

		private Texture2D _buttonCloudActiveTexture;

		private Texture2D _buttonCloudInactiveTexture;

		private Texture2D _buttonFavoriteActiveTexture;

		private Texture2D _buttonFavoriteInactiveTexture;

		private Texture2D _buttonPlayTexture;

		private Texture2D _buttonSeedTexture;

		private Texture2D _buttonDeleteTexture;

		private UIImageButton _deleteButton;

		public bool IsFavorite => _data.IsFavorite;

		public UIWorldListItem(WorldFileData data, int snapPointIndex)
		{
			_data = data;
			LoadTextures();
			InitializeAppearance();
			_worldIcon = new UIImage(GetIcon());
			_worldIcon.Left.Set(4f, 0f);
			_worldIcon.OnDoubleClick += PlayGame;
			Append(_worldIcon);
			float num = 4f;
			UIImageButton uIImageButton = new UIImageButton(_buttonPlayTexture);
			uIImageButton.VAlign = 1f;
			uIImageButton.Left.Set(num, 0f);
			uIImageButton.OnClick += PlayGame;
			base.OnDoubleClick += PlayGame;
			uIImageButton.OnMouseOver += PlayMouseOver;
			uIImageButton.OnMouseOut += ButtonMouseOut;
			Append(uIImageButton);
			num += 24f;
			UIImageButton uIImageButton2 = new UIImageButton(_data.IsFavorite ? _buttonFavoriteActiveTexture : _buttonFavoriteInactiveTexture);
			uIImageButton2.VAlign = 1f;
			uIImageButton2.Left.Set(num, 0f);
			uIImageButton2.OnClick += FavoriteButtonClick;
			uIImageButton2.OnMouseOver += FavoriteMouseOver;
			uIImageButton2.OnMouseOut += ButtonMouseOut;
			uIImageButton2.SetVisibility(1f, _data.IsFavorite ? 0.8f : 0.4f);
			Append(uIImageButton2);
			num += 24f;
			if (SocialAPI.Cloud != null)
			{
				UIImageButton uIImageButton3 = new UIImageButton(_data.IsCloudSave ? _buttonCloudActiveTexture : _buttonCloudInactiveTexture);
				uIImageButton3.VAlign = 1f;
				uIImageButton3.Left.Set(num, 0f);
				uIImageButton3.OnClick += CloudButtonClick;
				uIImageButton3.OnMouseOver += CloudMouseOver;
				uIImageButton3.OnMouseOut += ButtonMouseOut;
				uIImageButton3.SetSnapPoint("Cloud", snapPointIndex);
				Append(uIImageButton3);
				num += 24f;
			}
			if (Main.UseSeedUI && _data.WorldGeneratorVersion != 0L)
			{
				UIImageButton uIImageButton4 = new UIImageButton(_buttonSeedTexture);
				uIImageButton4.VAlign = 1f;
				uIImageButton4.Left.Set(num, 0f);
				uIImageButton4.OnClick += SeedButtonClick;
				uIImageButton4.OnMouseOver += SeedMouseOver;
				uIImageButton4.OnMouseOut += ButtonMouseOut;
				uIImageButton4.SetSnapPoint("Seed", snapPointIndex);
				Append(uIImageButton4);
				num += 24f;
			}
			UIImageButton uIImageButton5 = new UIImageButton(_buttonDeleteTexture);
			uIImageButton5.VAlign = 1f;
			uIImageButton5.HAlign = 1f;
			uIImageButton5.OnClick += DeleteButtonClick;
			uIImageButton5.OnMouseOver += DeleteMouseOver;
			uIImageButton5.OnMouseOut += DeleteMouseOut;
			_deleteButton = uIImageButton5;
			if (!_data.IsFavorite)
			{
				Append(uIImageButton5);
			}
			num += 4f;
			_buttonLabel = new UIText("");
			_buttonLabel.VAlign = 1f;
			_buttonLabel.Left.Set(num, 0f);
			_buttonLabel.Top.Set(-3f, 0f);
			Append(_buttonLabel);
			_deleteButtonLabel = new UIText("");
			_deleteButtonLabel.VAlign = 1f;
			_deleteButtonLabel.HAlign = 1f;
			_deleteButtonLabel.Left.Set(-30f, 0f);
			_deleteButtonLabel.Top.Set(-3f, 0f);
			Append(_deleteButtonLabel);
			uIImageButton.SetSnapPoint("Play", snapPointIndex);
			uIImageButton2.SetSnapPoint("Favorite", snapPointIndex);
			uIImageButton5.SetSnapPoint("Delete", snapPointIndex);
		}

		private void LoadTextures()
		{
			_dividerTexture = TextureManager.Load("Images/UI/Divider");
			_innerPanelTexture = TextureManager.Load("Images/UI/InnerPanelBackground");
			_buttonCloudActiveTexture = TextureManager.Load("Images/UI/ButtonCloudActive");
			_buttonCloudInactiveTexture = TextureManager.Load("Images/UI/ButtonCloudInactive");
			_buttonFavoriteActiveTexture = TextureManager.Load("Images/UI/ButtonFavoriteActive");
			_buttonFavoriteInactiveTexture = TextureManager.Load("Images/UI/ButtonFavoriteInactive");
			_buttonPlayTexture = TextureManager.Load("Images/UI/ButtonPlay");
			_buttonSeedTexture = TextureManager.Load("Images/UI/ButtonSeed");
			_buttonDeleteTexture = TextureManager.Load("Images/UI/ButtonDelete");
		}

		private void InitializeAppearance()
		{
			Height.Set(96f, 0f);
			Width.Set(0f, 1f);
			SetPadding(6f);
			BorderColor = new Color(89, 116, 213) * 0.7f;
		}

		private Texture2D GetIcon()
		{
			return TextureManager.Load("Images/UI/Icon" + (_data.IsHardMode ? "Hallow" : "") + (_data.HasCorruption ? "Corruption" : "Crimson"));
		}

		private void FavoriteMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			if (_data.IsFavorite)
			{
				_buttonLabel.SetText(Language.GetTextValue("UI.Unfavorite"));
			}
			else
			{
				_buttonLabel.SetText(Language.GetTextValue("UI.Favorite"));
			}
		}

		private void CloudMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			if (_data.IsCloudSave)
			{
				_buttonLabel.SetText(Language.GetTextValue("UI.MoveOffCloud"));
			}
			else
			{
				_buttonLabel.SetText(Language.GetTextValue("UI.MoveToCloud"));
			}
		}

		private void PlayMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			_buttonLabel.SetText(Language.GetTextValue("UI.Play"));
		}

		private void SeedMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			_buttonLabel.SetText(Language.GetTextValue("UI.CopySeed", _data.SeedText));
		}

		private void DeleteMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			_deleteButtonLabel.SetText(Language.GetTextValue("UI.Delete"));
		}

		private void DeleteMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			_deleteButtonLabel.SetText("");
		}

		private void ButtonMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			_buttonLabel.SetText("");
		}

		private void CloudButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			if (_data.IsCloudSave)
			{
				_data.MoveToLocal();
			}
			else
			{
				_data.MoveToCloud();
			}
			((UIImageButton)evt.Target).SetImage(_data.IsCloudSave ? _buttonCloudActiveTexture : _buttonCloudInactiveTexture);
			if (_data.IsCloudSave)
			{
				_buttonLabel.SetText(Language.GetTextValue("UI.MoveOffCloud"));
			}
			else
			{
				_buttonLabel.SetText(Language.GetTextValue("UI.MoveToCloud"));
			}
		}

		private void DeleteButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			for (int i = 0; i < Main.WorldList.Count; i++)
			{
				if (Main.WorldList[i] == _data)
				{
					Main.PlaySound(10);
					Main.selectedWorld = i;
					Main.menuMode = 9;
					break;
				}
			}
		}

		private void PlayGame(UIMouseEvent evt, UIElement listeningElement)
		{
			if (listeningElement == evt.Target)
			{
				_data.SetAsActive();
				Main.PlaySound(10);
				Main.GetInputText("");
				if (Main.menuMultiplayer && SocialAPI.Network != null)
				{
					Main.menuMode = 889;
				}
				else if (Main.menuMultiplayer)
				{
					Main.menuMode = 30;
				}
				else
				{
					Main.menuMode = 10;
				}
				if (!Main.menuMultiplayer)
				{
					WorldGen.playWorld();
				}
			}
		}

		private void FavoriteButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			_data.ToggleFavorite();
			((UIImageButton)evt.Target).SetImage(_data.IsFavorite ? _buttonFavoriteActiveTexture : _buttonFavoriteInactiveTexture);
			((UIImageButton)evt.Target).SetVisibility(1f, _data.IsFavorite ? 0.8f : 0.4f);
			if (_data.IsFavorite)
			{
				_buttonLabel.SetText(Language.GetTextValue("UI.Unfavorite"));
				RemoveChild(_deleteButton);
			}
			else
			{
				_buttonLabel.SetText(Language.GetTextValue("UI.Favorite"));
				Append(_deleteButton);
			}
			if (Parent.Parent is UIList uIList)
			{
				uIList.UpdateOrder();
			}
		}

		private void SeedButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			Platform.Current.Clipboard = _data.SeedText;
			_buttonLabel.SetText(Language.GetTextValue("UI.SeedCopied"));
		}

		public override int CompareTo(object obj)
		{
			if (obj is UIWorldListItem uIWorldListItem)
			{
				if (IsFavorite && !uIWorldListItem.IsFavorite)
				{
					return -1;
				}
				if (!IsFavorite && uIWorldListItem.IsFavorite)
				{
					return 1;
				}
				if (_data.Name.CompareTo(uIWorldListItem._data.Name) != 0)
				{
					return _data.Name.CompareTo(uIWorldListItem._data.Name);
				}
				return _data.GetFileName().CompareTo(uIWorldListItem._data.GetFileName());
			}
			return base.CompareTo(obj);
		}

		public override void MouseOver(UIMouseEvent evt)
		{
			base.MouseOver(evt);
			BackgroundColor = new Color(73, 94, 171);
			BorderColor = new Color(89, 116, 213);
		}

		public override void MouseOut(UIMouseEvent evt)
		{
			base.MouseOut(evt);
			BackgroundColor = new Color(63, 82, 151) * 0.7f;
			BorderColor = new Color(89, 116, 213) * 0.7f;
		}

		private void DrawPanel(SpriteBatch spriteBatch, Vector2 position, float width)
		{
			spriteBatch.Draw(_innerPanelTexture, position, new Rectangle(0, 0, 8, _innerPanelTexture.Height), Color.White);
			spriteBatch.Draw(_innerPanelTexture, new Vector2(position.X + 8f, position.Y), new Rectangle(8, 0, 8, _innerPanelTexture.Height), Color.White, 0f, Vector2.Zero, new Vector2((width - 16f) / 8f, 1f), SpriteEffects.None, 0f);
			spriteBatch.Draw(_innerPanelTexture, new Vector2(position.X + width - 8f, position.Y), new Rectangle(16, 0, 8, _innerPanelTexture.Height), Color.White);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);
			CalculatedStyle innerDimensions = GetInnerDimensions();
			CalculatedStyle dimensions = _worldIcon.GetDimensions();
			float num = dimensions.X + dimensions.Width;
			Color color = (_data.IsValid ? Color.White : Color.Red);
			Utils.DrawBorderString(spriteBatch, _data.Name, new Vector2(num + 6f, dimensions.Y - 2f), color);
			spriteBatch.Draw(_dividerTexture, new Vector2(num, innerDimensions.Y + 21f), null, Color.White, 0f, Vector2.Zero, new Vector2((GetDimensions().X + GetDimensions().Width - num) / 8f, 1f), SpriteEffects.None, 0f);
			Vector2 vector = new Vector2(num + 6f, innerDimensions.Y + 29f);
			float num2 = 100f;
			DrawPanel(spriteBatch, vector, num2);
			string text = (_data.IsExpertMode ? Language.GetTextValue("UI.Expert") : Language.GetTextValue("UI.Normal"));
			float x = Main.fontMouseText.MeasureString(text).X;
			float x2 = num2 * 0.5f - x * 0.5f;
			Utils.DrawBorderString(spriteBatch, text, vector + new Vector2(x2, 3f), _data.IsExpertMode ? new Color(217, 143, 244) : Color.White);
			vector.X += num2 + 5f;
			float num3 = 150f;
			if (!GameCulture.English.IsActive)
			{
				num3 += 40f;
			}
			DrawPanel(spriteBatch, vector, num3);
			string textValue = Language.GetTextValue("UI.WorldSizeFormat", _data.WorldSizeName);
			float x3 = Main.fontMouseText.MeasureString(textValue).X;
			float x4 = num3 * 0.5f - x3 * 0.5f;
			Utils.DrawBorderString(spriteBatch, textValue, vector + new Vector2(x4, 3f), Color.White);
			vector.X += num3 + 5f;
			float num4 = innerDimensions.X + innerDimensions.Width - vector.X;
			DrawPanel(spriteBatch, vector, num4);
			string arg = ((!GameCulture.English.IsActive) ? _data.CreationTime.ToShortDateString() : _data.CreationTime.ToString("d MMMM yyyy"));
			string textValue2 = Language.GetTextValue("UI.WorldCreatedFormat", arg);
			float x5 = Main.fontMouseText.MeasureString(textValue2).X;
			float x6 = num4 * 0.5f - x5 * 0.5f;
			Utils.DrawBorderString(spriteBatch, textValue2, vector + new Vector2(x6, 3f), Color.White);
			vector.X += num4 + 5f;
		}
	}
}
