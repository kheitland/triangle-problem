using System.Collections.Generic;
using TriangleProblem.Models;

namespace TriangleProblem
{
	public class TriangleGridGenerator
	{
		private readonly IList<string> _rowIdentifiers;
		private readonly IList<int> _columnIdentifiers;

		private readonly int _width;
		private readonly int _height;

		public TriangleGridGenerator()
		{
			_rowIdentifiers = new List<string>() {"A", "B", "C", "D", "E", "F" };
			_columnIdentifiers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

			_width = 10;
			_height = 10;
		}

		/// <summary>
		/// Generate all the triangle coordinates in a grid of triangles
		/// </summary>
		/// <returns>Triangles in a grid result</returns>
		public TriangleGridResult Generate()
		{
			var triangles = new Dictionary<GridPosition, Triangle>();

			for (int rowIndex = 0; rowIndex < _rowIdentifiers.Count; rowIndex++)
			{
				for (int columnIndex = 0; columnIndex < _columnIdentifiers.Count; columnIndex++)
				{
					var gridPosition = new GridPosition(_rowIdentifiers[rowIndex], _columnIdentifiers[columnIndex]);
					
					var triangle = BuildTriangle(rowIndex, columnIndex);
					triangles.Add(gridPosition, triangle);
				}
			}

			return new TriangleGridResult(triangles);
		}

		/// <summary>
		/// Builds a Triangle given the row and column
		/// </summary>
		/// <param name="row">Row the triangle is in</param>
		/// <param name="column">Column the triangle is in</param>
		/// <returns>Triangle with its coordinates within the grid</returns>
		private Triangle BuildTriangle(int row, int column)
		{
			int x = (column / 2) * _width;
			int y = row * _height;

			int widthOffset = 0;
			int heightOffset = 0;

			if ((column % 2) == 0) //Even (Left bottom triangle in column)
			{
				heightOffset = _height;
			}
			else //Odd (Right top triangle in column)
			{
				widthOffset = _width;
			}

			var v1Coord = new Coordinate(x + widthOffset, y + heightOffset);
			var v2Coord = new Coordinate(x, y);
			var v3Coord = new Coordinate(x + _width, y + _height);

			var triangle = new Triangle(v1Coord, v2Coord, v3Coord);
			return triangle;
		}
	}
}
