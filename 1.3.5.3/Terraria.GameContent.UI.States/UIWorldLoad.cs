using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.UI;
using Terraria.UI.Gamepad;
using Terraria.World.Generation;

namespace Terraria.GameContent.UI.States
{
	public class UIWorldLoad : UIState
	{
		private UIGenProgressBar _progressBar = new UIGenProgressBar();

		private UIHeader _progressMessage = new UIHeader();

		private GenerationProgress _progress;

		public UIWorldLoad(GenerationProgress progress)
		{
			_progressBar.Top.Pixels = 370f;
			_progressBar.HAlign = 0.5f;
			_progressBar.VAlign = 0f;
			_progressBar.Recalculate();
			_progressMessage.CopyStyle(_progressBar);
			_progressMessage.Top.Pixels -= 70f;
			_progressMessage.Recalculate();
			_progress = progress;
			Append(_progressBar);
			Append(_progressMessage);
		}

		public override void OnActivate()
		{
			if (PlayerInput.UsingGamepadUI)
			{
				UILinkPointNavigator.Points[3000].Unlink();
				UILinkPointNavigator.ChangePoint(3000);
			}
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			_progressBar.SetProgress(_progress.TotalProgress, _progress.Value);
			_progressMessage.Text = _progress.Message;
			UpdateGamepadSquiggle();
		}

		private void UpdateGamepadSquiggle()
		{
			Vector2 vector = new Vector2((float)Math.Cos(Main.GlobalTime * ((float)Math.PI * 2f)), (float)Math.Sin(Main.GlobalTime * ((float)Math.PI * 2f) * 2f)) * new Vector2(30f, 15f) + Vector2.UnitY * 20f;
			UILinkPointNavigator.Points[3000].Unlink();
			UILinkPointNavigator.SetPosition(3000, new Vector2(Main.screenWidth, Main.screenHeight) / 2f + vector);
		}

		public string GetStatusText()
		{
			return string.Format("{0:0.0%} - " + _progress.Message + " - {1:0.0%}", _progress.TotalProgress, _progress.Value);
		}
	}
}
