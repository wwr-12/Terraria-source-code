namespace Terraria.DataStructures
{
	public struct Point16
	{
		public short x;

		public short y;

		public Point16(int x, int y)
		{
			this.x = (short)x;
			this.y = (short)y;
		}

		public Point16(short x, short y)
		{
			this.x = x;
			this.y = y;
		}

		public override bool Equals(object obj)
		{
			Point16 point = (Point16)obj;
			if (x != point.x || y != point.y)
			{
				return false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return (x << 16) + y;
		}

		public override string ToString()
		{
			return $"{{{x}, {y}}}";
		}
	}
}
