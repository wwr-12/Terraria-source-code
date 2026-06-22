using System.Collections.Generic;
using System.Diagnostics;
using Terraria.GameContent.UI.States;
using Terraria.Utilities;

namespace Terraria.World.Generation
{
	public class WorldGenerator
	{
		private List<GenPass> _passes = new List<GenPass>();

		private float _totalLoadWeight;

		private int _seed;

		public WorldGenerator(int seed)
		{
			_seed = seed;
		}

		public void Append(GenPass pass)
		{
			_passes.Add(pass);
			_totalLoadWeight += pass.Weight;
		}

		public void GenerateWorld(GenerationProgress progress = null)
		{
			Stopwatch stopwatch = new Stopwatch();
			float num = 0f;
			foreach (GenPass pass in _passes)
			{
				num += pass.Weight;
			}
			if (progress == null)
			{
				progress = new GenerationProgress();
			}
			progress.TotalWeight = num;
			Main.menuMode = 888;
			Main.MenuUI.SetState(new UIWorldLoad(progress));
			foreach (GenPass pass2 in _passes)
			{
				WorldGen._genRand = new UnifiedRandom(_seed);
				Main.rand = new UnifiedRandom(_seed);
				stopwatch.Start();
				progress.Start(pass2.Weight);
				pass2.Apply(progress);
				progress.End();
				stopwatch.Reset();
			}
		}
	}
}
