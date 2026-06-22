using Microsoft.Xna.Framework.Audio;
using Terraria.Utilities;

namespace Terraria.Audio
{
	public class LegacySoundStyle : SoundStyle
	{
		private static UnifiedRandom _random = new UnifiedRandom();

		private int _style;

		private int _styleVariations;

		private int _soundId;

		public int Style
		{
			get
			{
				if (_styleVariations != 1)
				{
					return _random.Next(_style, _style + _styleVariations);
				}
				return _style;
			}
		}

		public int Variations => _styleVariations;

		public int SoundId => _soundId;

		public override bool IsTrackable => _soundId == 42;

		public LegacySoundStyle(int soundId, int style, SoundType type = SoundType.Sound)
			: base(type)
		{
			_style = style;
			_styleVariations = 1;
			_soundId = soundId;
		}

		public LegacySoundStyle(int soundId, int style, int variations, SoundType type = SoundType.Sound)
			: base(type)
		{
			_style = style;
			_styleVariations = variations;
			_soundId = soundId;
		}

		private LegacySoundStyle(int soundId, int style, int variations, SoundType type, float volume, float pitchVariance)
			: base(volume, pitchVariance, type)
		{
			_style = style;
			_styleVariations = variations;
			_soundId = soundId;
		}

		public LegacySoundStyle WithVolume(float volume)
		{
			return new LegacySoundStyle(_soundId, _style, _styleVariations, base.Type, volume, base.PitchVariance);
		}

		public LegacySoundStyle WithPitchVariance(float pitchVariance)
		{
			return new LegacySoundStyle(_soundId, _style, _styleVariations, base.Type, base.Volume, pitchVariance);
		}

		public LegacySoundStyle AsMusic()
		{
			return new LegacySoundStyle(_soundId, _style, _styleVariations, SoundType.Music, base.Volume, base.PitchVariance);
		}

		public LegacySoundStyle AsAmbient()
		{
			return new LegacySoundStyle(_soundId, _style, _styleVariations, SoundType.Ambient, base.Volume, base.PitchVariance);
		}

		public LegacySoundStyle AsSound()
		{
			return new LegacySoundStyle(_soundId, _style, _styleVariations, SoundType.Sound, base.Volume, base.PitchVariance);
		}

		public bool Includes(int soundId, int style)
		{
			if (_soundId == soundId && style >= _style)
			{
				return style < _style + _styleVariations;
			}
			return false;
		}

		public override SoundEffect GetRandomSound()
		{
			if (IsTrackable)
			{
				return Main.trackableSounds[Style];
			}
			return null;
		}
	}
}
