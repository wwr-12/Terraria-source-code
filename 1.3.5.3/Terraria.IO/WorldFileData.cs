using System;
using System.IO;
using Terraria.Localization;
using Terraria.Utilities;

namespace Terraria.IO
{
	public class WorldFileData : FileData
	{
		private const ulong GUID_IN_WORLD_FILE_VERSION = 777389080577uL;

		public DateTime CreationTime;

		public int WorldSizeX;

		public int WorldSizeY;

		public ulong WorldGeneratorVersion;

		private string _seedText = "";

		private int _seed;

		public bool IsValid = true;

		public Guid UniqueId;

		public LocalizedText _worldSizeName;

		public bool IsExpertMode;

		public bool HasCorruption = true;

		public bool IsHardMode;

		public string SeedText => _seedText;

		public int Seed => _seed;

		public string WorldSizeName => _worldSizeName.Value;

		public bool HasCrimson
		{
			get
			{
				return !HasCorruption;
			}
			set
			{
				HasCorruption = !value;
			}
		}

		public bool HasValidSeed => WorldGeneratorVersion != 0;

		public bool UseGuidAsMapName => WorldGeneratorVersion >= 777389080577L;

		public WorldFileData()
			: base("World")
		{
		}

		public WorldFileData(string path, bool cloudSave)
			: base("World", path, cloudSave)
		{
		}

		public override void SetAsActive()
		{
			Main.ActiveWorldFileData = this;
		}

		public void SetWorldSize(int x, int y)
		{
			WorldSizeX = x;
			WorldSizeY = y;
			switch (x)
			{
			case 4200:
				_worldSizeName = Language.GetText("UI.WorldSizeSmall");
				break;
			case 6400:
				_worldSizeName = Language.GetText("UI.WorldSizeMedium");
				break;
			case 8400:
				_worldSizeName = Language.GetText("UI.WorldSizeLarge");
				break;
			default:
				_worldSizeName = Language.GetText("UI.WorldSizeUnknown");
				break;
			}
		}

		public static WorldFileData FromInvalidWorld(string path, bool cloudSave)
		{
			WorldFileData worldFileData = new WorldFileData(path, cloudSave);
			worldFileData.IsExpertMode = false;
			worldFileData.SetSeedToEmpty();
			worldFileData.WorldGeneratorVersion = 0uL;
			worldFileData.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
			worldFileData.SetWorldSize(1, 1);
			worldFileData.HasCorruption = true;
			worldFileData.IsHardMode = false;
			worldFileData.IsValid = false;
			worldFileData.Name = FileUtilities.GetFileName(path, includeExtension: false);
			worldFileData.UniqueId = Guid.Empty;
			if (!cloudSave)
			{
				worldFileData.CreationTime = File.GetCreationTime(path);
			}
			else
			{
				worldFileData.CreationTime = DateTime.Now;
			}
			return worldFileData;
		}

		public void SetSeedToEmpty()
		{
			SetSeed("");
		}

		public void SetSeed(string seedText)
		{
			_seedText = seedText;
			if (!int.TryParse(seedText, out _seed))
			{
				_seed = seedText.GetHashCode();
			}
			_seed = Math.Abs(_seed);
		}

		public void SetSeedToRandom()
		{
			SetSeed(new UnifiedRandom().Next().ToString());
		}

		public override void MoveToCloud()
		{
			if (!base.IsCloudSave)
			{
				string worldPathFromName = Main.GetWorldPathFromName(Name, cloudSave: true);
				if (FileUtilities.MoveToCloud(base.Path, worldPathFromName))
				{
					Main.LocalFavoriteData.ClearEntry(this);
					_isCloudSave = true;
					_path = worldPathFromName;
					Main.CloudFavoritesData.SaveFavorite(this);
				}
			}
		}

		public override void MoveToLocal()
		{
			if (base.IsCloudSave)
			{
				string worldPathFromName = Main.GetWorldPathFromName(Name, cloudSave: false);
				if (FileUtilities.MoveToLocal(base.Path, worldPathFromName))
				{
					Main.CloudFavoritesData.ClearEntry(this);
					_isCloudSave = false;
					_path = worldPathFromName;
					Main.LocalFavoriteData.SaveFavorite(this);
				}
			}
		}
	}
}
