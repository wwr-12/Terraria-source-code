using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Shaders
{
	public class ShaderData
	{
		protected Ref<Effect> _shader;

		protected string _passName;

		private EffectPass _effectPass;

		private Effect _lastEffect;

		public Effect Shader
		{
			get
			{
				if (_shader != null)
				{
					return _shader.Value;
				}
				return null;
			}
		}

		public ShaderData(Ref<Effect> shader, string passName)
		{
			_passName = passName;
			_shader = shader;
		}

		public void SwapProgram(string passName)
		{
			_passName = passName;
			if (passName != null)
			{
				_effectPass = Shader.CurrentTechnique.Passes[passName];
			}
		}

		protected virtual void Apply()
		{
			if (_shader != null && _lastEffect != _shader.Value && Shader != null && _passName != null)
			{
				_effectPass = Shader.CurrentTechnique.Passes[_passName];
			}
			_effectPass.Apply();
		}
	}
}
