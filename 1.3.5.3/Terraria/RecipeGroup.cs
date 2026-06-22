using System;
using System.Collections.Generic;

namespace Terraria
{
	public class RecipeGroup
	{
		public Func<string> GetText;

		public List<int> ValidItems;

		public int IconicItemIndex;

		public static Dictionary<int, RecipeGroup> recipeGroups = new Dictionary<int, RecipeGroup>();

		public static Dictionary<string, int> recipeGroupIDs = new Dictionary<string, int>();

		public static int nextRecipeGroupIndex = 0;

		public RecipeGroup(Func<string> getName, params int[] validItems)
		{
			GetText = getName;
			ValidItems = new List<int>(validItems);
		}

		public static int RegisterGroup(string name, RecipeGroup rec)
		{
			int num = nextRecipeGroupIndex++;
			recipeGroups.Add(num, rec);
			recipeGroupIDs.Add(name, num);
			return num;
		}
	}
}
