namespace Terraria.Modules
{
	public class TileObjectStyleModule
	{
		public int style;

		public bool horizontal;

		public int styleWrapLimit;

		public int styleMultiplier;

		public int styleLineSkip;

		public TileObjectStyleModule(TileObjectStyleModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				style = 0;
				horizontal = false;
				styleWrapLimit = 0;
				styleMultiplier = 1;
				styleLineSkip = 1;
			}
			else
			{
				style = copyFrom.style;
				horizontal = copyFrom.horizontal;
				styleWrapLimit = copyFrom.styleWrapLimit;
				styleMultiplier = copyFrom.styleMultiplier;
				styleLineSkip = copyFrom.styleLineSkip;
			}
		}
	}
}
