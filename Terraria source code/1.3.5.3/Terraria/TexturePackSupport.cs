using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Ionic.Zip;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria
{
	public class TexturePackSupport
	{
		public static bool Enabled = false;

		public static int ReplacedTextures = 0;

		private static ZipFile texturePack;

		private static Dictionary<string, ZipEntry> entries = new Dictionary<string, ZipEntry>();

		private static Stopwatch test = new Stopwatch();

		public static bool FetchTexture(string path, out Texture2D tex)
		{
			if (entries.TryGetValue(path, out var value))
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					value.Extract((Stream)memoryStream);
					tex = FromStreamSlow(Main.instance.GraphicsDevice, memoryStream);
					ReplacedTextures++;
					return true;
				}
			}
			tex = null;
			return false;
		}

		public static Texture2D FromStreamSlow(GraphicsDevice graphicsDevice, Stream stream)
		{
			Texture2D texture2D = Texture2D.FromStream(graphicsDevice, stream);
			Color[] array = new Color[texture2D.Width * texture2D.Height];
			texture2D.GetData(array);
			for (int i = 0; i != array.Length; i++)
			{
				array[i] = Color.FromNonPremultiplied(array[i].ToVector4());
			}
			texture2D.SetData(array);
			return texture2D;
		}

		public static void FindTexturePack()
		{
			string path = Main.SavePath + "/Texture Pack.zip";
			if (!File.Exists(path))
			{
				return;
			}
			entries.Clear();
			texturePack = ZipFile.Read((Stream)File.OpenRead(path));
			foreach (ZipEntry entry in texturePack.Entries)
			{
				entries.Add(entry.FileName.Replace("/", "\\"), entry);
			}
		}
	}
}
