using System;

namespace TriangleProblem.Models
{
	public class Triangle
	{
		public Triangle(Coordinate v1, Coordinate v2, Coordinate v3)
		{
			if (v1 == null) throw new ArgumentNullException(nameof(v1));
			if (v2 == null) throw new ArgumentNullException(nameof(v2));
			if (v3 == null) throw new ArgumentNullException(nameof(v3));

			V1 = v1;
			V2 = v2;
			V3 = v3;
		}

		public Coordinate V1 { get; }

		public Coordinate V2 { get; }

		public Coordinate V3 { get; }

		public string PrintCoordinates()
		{
			return $"V1:({V1.X},{V1.Y}) V2:({V2.X},{V2.Y}) V3:({V3.X},{V3.Y})";
		}

		public override bool Equals(object obj)
		{
			var triangle = obj as Triangle;
			if (triangle == null)
			{
				return false;
			}

			return Equals(triangle);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (V1 != null ? V1.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ (V2 != null ? V2.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ (V3 != null ? V3.GetHashCode() : 0);
				return hashCode;
			}
		}

		protected bool Equals(Triangle other)
		{
			return Equals(V1, other.V1) 
				&& Equals(V2, other.V2) 
				&& Equals(V3, other.V3);
		}
	}
}
