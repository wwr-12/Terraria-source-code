using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace Terraria.Graphics.Effects
{
	public class SimpleOverlay : Overlay
	{
		private Ref<Texture2D> _texture;

		private ScreenShaderData _shader;

		public Vector2 TargetPosition = Vector2.Zero;

		public SimpleOverlay(string textureName, ScreenShaderData shader, EffectPriority priority = EffectPriority.VeryLow, RenderLayers layer = RenderLayers.All)
			: base(priority, layer)
		{
			_texture = TextureManager.AsyncLoad((textureName == null) ? "" : textureName);
			_shader = shader;
		}

		public SimpleOverlay(string textureName, string shaderName = "Default", EffectPriority priority = EffectPriority.VeryLow, RenderLayers layer = RenderLayers.All)
			: base(priority, layer)
		{
			_texture = TextureManager.AsyncLoad((textureName == null) ? "" : textureName);
			_shader = new ScreenShaderData(Main.ScreenShaderRef, shaderName);
		}

		public ScreenShaderData GetShader()
		{
			return _shader;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			_shader.UseGlobalOpacity(Opacity);
			_shader.UseTargetPosition(TargetPosition);
			_shader.Apply();
			spriteBatch.Draw(_texture.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Main.bgColor);
		}

		public override void Update(GameTime gameTime)
		{
			_shader.Update(gameTime);
		}

		internal override void Activate(Vector2 position, params object[] args)
		{
			TargetPosition = position;
			Mode = OverlayMode.FadeIn;
		}

		internal override void Deactivate(params object[] args)
		{
			Mode = OverlayMode.FadeOut;
		}

		public override bool IsVisible()
		{
			return _shader.CombinedOpacity > 0f;
		}
	}
}
