using Microsoft.Xna.Framework;

namespace Terraria.UI
{
	public class SnapPoint
	{
		private Vector2 _anchor;

		private Vector2 _offset;

		private Vector2 _calculatedPosition;

		private string _name;

		private int _id;

		public UIElement BoundElement;

		public string Name => _name;

		public int ID => _id;

		public Vector2 Position => _calculatedPosition;

		public SnapPoint(string name, int id, Vector2 anchor, Vector2 offset)
		{
			_name = name;
			_id = id;
			_anchor = anchor;
			_offset = offset;
		}

		public void Calculate(UIElement element)
		{
			BoundElement = element;
			CalculatedStyle dimensions = element.GetDimensions();
			_calculatedPosition = dimensions.Position() + _offset + _anchor * new Vector2(dimensions.Width, dimensions.Height);
		}

		public override string ToString()
		{
			return "Snap Point - " + Name + " " + ID;
		}
	}
}
