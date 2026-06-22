using System;
using System.Collections.Concurrent;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics
{
	public static class TextureManager
	{
		private struct LoadPair
		{
			public string Path;

			public Ref<Texture2D> TextureRef;

			public LoadPair(string path, Ref<Texture2D> textureRef)
			{
				Path = path;
				TextureRef = textureRef;
			}
		}

		private static ConcurrentDictionary<string, Texture2D> _textures = new ConcurrentDictionary<string, Texture2D>();

		private static ConcurrentQueue<LoadPair> _loadQueue = new ConcurrentQueue<LoadPair>();

		private static Thread _loadThread;

		private static readonly object _loadThreadLock = new object();

		public static Texture2D BlankTexture;

		public static void Initialize()
		{
			BlankTexture = new Texture2D(Main.graphics.GraphicsDevice, 4, 4);
		}

		public static Texture2D Load(string name)
		{
			if (!_textures.ContainsKey(name))
			{
				Texture2D texture2D = BlankTexture;
				if (name != "" && name != null)
				{
					try
					{
						texture2D = Main.instance.OurLoad<Texture2D>(name);
					}
					catch (Exception)
					{
						texture2D = BlankTexture;
					}
				}
				_textures[name] = texture2D;
				return texture2D;
			}
			return _textures[name];
		}

		public static Ref<Texture2D> AsyncLoad(string name)
		{
			return new Ref<Texture2D>(Load(name));
		}

		private static void Run(object context)
		{
			bool looping = true;
			Main.instance.Exiting += delegate
			{
				looping = false;
				if (Monitor.TryEnter(_loadThreadLock))
				{
					Monitor.Pulse(_loadThreadLock);
					Monitor.Exit(_loadThreadLock);
				}
			};
			Monitor.Enter(_loadThreadLock);
			while (looping)
			{
				if (_loadQueue.Count != 0)
				{
					if (_loadQueue.TryDequeue(out var result))
					{
						result.TextureRef.Value = Load(result.Path);
					}
				}
				else
				{
					Monitor.Wait(_loadThreadLock);
				}
			}
			Monitor.Exit(_loadThreadLock);
		}
	}
}
