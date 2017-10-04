namespace TriangleProblem.Models
{
	public class Coordinate
	{
		public Coordinate(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; }

		public int Y { get; }

		public override bool Equals(object obj)
		{
			var coord = obj as Coordinate;
			if (coord == null)
			{
				return false;
			}

			return Equals(coord);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X*397) ^ Y;
			}
		}


		protected bool Equals(Coordinate other)
		{
			return X == other.X && Y == other.Y;
		}
	}
}
