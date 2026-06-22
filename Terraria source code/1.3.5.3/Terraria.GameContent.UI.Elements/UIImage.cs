using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	public class UIImage : UIElement
	{
		private Texture2D _texture;

		public float ImageScale = 1f;

		public UIImage(Texture2D texture)
		{
			_texture = texture;
			Width.Set(_texture.Width, 0f);
			Height.Set(_texture.Height, 0f);
		}

		public void SetImage(Texture2D texture)
		{
			_texture = texture;
			Width.Set(_texture.Width, 0f);
			Height.Set(_texture.Height, 0f);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			CalculatedStyle dimensions = GetDimensions();
			spriteBatch.Draw(_texture, dimensions.Position() + _texture.Size() * (1f - ImageScale) / 2f, null, Color.White, 0f, Vector2.Zero, ImageScale, SpriteEffects.None, 0f);
		}
	}
}
