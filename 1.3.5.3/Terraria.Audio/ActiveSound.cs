using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Terraria.Audio
{
	public class ActiveSound
	{
		private SoundEffectInstance _sound;

		public readonly bool IsGlobal;

		public Vector2 Position;

		public float Volume;

		private SoundStyle _style;

		public SoundEffectInstance Sound => _sound;

		public SoundStyle Style => _style;

		public bool IsPlaying => Sound.State == SoundState.Playing;

		public ActiveSound(SoundStyle style, Vector2 position)
		{
			Position = position;
			Volume = 1f;
			IsGlobal = false;
			_style = style;
			Play();
		}

		public ActiveSound(SoundStyle style)
		{
			Position = Vector2.Zero;
			Volume = 1f;
			IsGlobal = true;
			_style = style;
			Play();
		}

		private void Play()
		{
			SoundEffectInstance soundEffectInstance = _style.GetRandomSound().CreateInstance();
			soundEffectInstance.Pitch += _style.GetRandomPitch();
			Main.PlaySoundInstance(soundEffectInstance);
			_sound = soundEffectInstance;
			Update();
		}

		public void Stop()
		{
			if (_sound != null)
			{
				_sound.Stop();
			}
		}

		public void Pause()
		{
			if (_sound != null && _sound.State == SoundState.Playing)
			{
				_sound.Pause();
			}
		}

		public void Resume()
		{
			if (_sound != null && _sound.State == SoundState.Paused)
			{
				_sound.Resume();
			}
		}

		public void Update()
		{
			if (_sound != null)
			{
				Vector2 value = Main.screenPosition + new Vector2(Main.screenWidth / 2, Main.screenHeight / 2);
				float num = 1f;
				if (!IsGlobal)
				{
					float value2 = (Position.X - value.X) / ((float)Main.screenWidth * 0.5f);
					value2 = MathHelper.Clamp(value2, -1f, 1f);
					Sound.Pan = value2;
					float num2 = Vector2.Distance(Position, value);
					num = 1f - num2 / ((float)Main.screenWidth * 1.5f);
				}
				num *= _style.Volume * Volume;
				switch (_style.Type)
				{
				case SoundType.Sound:
					num *= Main.soundVolume;
					break;
				case SoundType.Ambient:
					num *= Main.ambientVolume;
					break;
				case SoundType.Music:
					num *= Main.musicVolume;
					break;
				}
				num = MathHelper.Clamp(num, 0f, 1f);
				Sound.Volume = num;
			}
		}
	}
}
