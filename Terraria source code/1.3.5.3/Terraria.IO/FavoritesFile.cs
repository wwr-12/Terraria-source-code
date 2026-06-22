using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Terraria.Utilities;

namespace Terraria.IO
{
	public class FavoritesFile
	{
		public readonly string Path;

		public readonly bool IsCloudSave;

		private Dictionary<string, Dictionary<string, bool>> _data = new Dictionary<string, Dictionary<string, bool>>();

		public FavoritesFile(string path, bool isCloud)
		{
			Path = path;
			IsCloudSave = isCloud;
		}

		public void SaveFavorite(FileData fileData)
		{
			if (!_data.ContainsKey(fileData.Type))
			{
				_data.Add(fileData.Type, new Dictionary<string, bool>());
			}
			_data[fileData.Type][fileData.GetFileName()] = fileData.IsFavorite;
			Save();
		}

		public void ClearEntry(FileData fileData)
		{
			if (_data.ContainsKey(fileData.Type))
			{
				_data[fileData.Type].Remove(fileData.GetFileName());
				Save();
			}
		}

		public bool IsFavorite(FileData fileData)
		{
			if (!_data.ContainsKey(fileData.Type))
			{
				return false;
			}
			string fileName = fileData.GetFileName();
			if (_data[fileData.Type].TryGetValue(fileName, out var value))
			{
				return value;
			}
			return false;
		}

		public void Save()
		{
			string s = JsonConvert.SerializeObject((object)_data, (Formatting)1);
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			FileUtilities.WriteAllBytes(Path, bytes, IsCloudSave);
		}

		public void Load()
		{
			if (!FileUtilities.Exists(Path, IsCloudSave))
			{
				_data.Clear();
				return;
			}
			byte[] bytes = FileUtilities.ReadAllBytes(Path, IsCloudSave);
			string text = Encoding.ASCII.GetString(bytes);
			_data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, bool>>>(text);
			if (_data == null)
			{
				_data = new Dictionary<string, Dictionary<string, bool>>();
			}
		}
	}
}
