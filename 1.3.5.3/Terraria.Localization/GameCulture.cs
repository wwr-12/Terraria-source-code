using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Terraria.Localization
{
	public class GameCulture
	{
		public static readonly GameCulture English = new GameCulture("en-US", 1);

		public static readonly GameCulture German = new GameCulture("de-DE", 2);

		public static readonly GameCulture Italian = new GameCulture("it-IT", 3);

		public static readonly GameCulture French = new GameCulture("fr-FR", 4);

		public static readonly GameCulture Spanish = new GameCulture("es-ES", 5);

		public static readonly GameCulture Russian = new GameCulture("ru-RU", 6);

		public static readonly GameCulture Chinese = new GameCulture("zh-Hans", 7);

		public static readonly GameCulture Portuguese = new GameCulture("pt-BR", 8);

		public static readonly GameCulture Polish = new GameCulture("pl-PL", 9);

		private static Dictionary<int, GameCulture> _legacyCultures;

		public readonly CultureInfo CultureInfo;

		public readonly int LegacyId;

		public bool IsActive => Language.ActiveCulture == this;

		public string Name => CultureInfo.Name;

		public static GameCulture FromLegacyId(int id)
		{
			if (id < 1)
			{
				id = 1;
			}
			return _legacyCultures[id];
		}

		public static GameCulture FromName(string name)
		{
			GameCulture gameCulture = _legacyCultures.Values.SingleOrDefault((GameCulture culture) => culture.Name == name);
			if (gameCulture != null)
			{
				return gameCulture;
			}
			if (name.Length >= 2)
			{
				string prefix = name.Substring(0, 2);
				gameCulture = _legacyCultures.Values.FirstOrDefault((GameCulture culture) => culture.Name.StartsWith(prefix));
				if (gameCulture != null)
				{
					return gameCulture;
				}
			}
			return English;
		}

		public GameCulture(string name, int legacyId)
		{
			CultureInfo = new CultureInfo(name);
			LegacyId = legacyId;
			RegisterLegacyCulture(this, legacyId);
		}

		private static void RegisterLegacyCulture(GameCulture culture, int legacyId)
		{
			if (_legacyCultures == null)
			{
				_legacyCultures = new Dictionary<int, GameCulture>();
			}
			_legacyCultures.Add(legacyId, culture);
		}
	}
}
