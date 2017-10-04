using System;

namespace TriangleProblem.Models
{
	public class GridPosition
	{
		public GridPosition(string row, int column)
		{
			Row = row;
			Column = column;
		}

		public string Row { get; }

		public int Column { get; }

		public override bool Equals(object obj)
		{
			var gridPosition = obj as GridPosition;
			if (gridPosition == null)
			{
				return false;
			}

			return Equals(gridPosition);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Row != null ? Row.GetHashCode() : 0) * 397) ^ Column;
			}
		}

		protected bool Equals(GridPosition other)
		{
			return String.Equals(Row, other.Row) 
				&& Column == other.Column;
		}
	}
}
