using System;
using System.Collections.Generic;
using System.Linq;

namespace TriangleProblem.Models
{
	public class TriangleGridResult
	{
		/// <summary>
		/// Internal dictionary of grid locations to a triangle coordinates
		/// </summary>
		private readonly IDictionary<GridPosition, Triangle> _triangles;

		public TriangleGridResult(IDictionary<GridPosition, Triangle> triangles)
		{
			_triangles = triangles;
		}

		/// <summary>
		/// Gets a triangle by the row and column
		/// </summary>
		/// <param name="gridPosition">The grid position of the triangle</param>
		/// <returns>Triangle if exists, otherwise null</returns>
		public Triangle GetTriangleByRowColumn(GridPosition gridPosition)
		{
			if (gridPosition == null) throw new ArgumentNullException(nameof(gridPosition));

			Triangle triangle = null;

			if (_triangles.ContainsKey(gridPosition))
			{
				triangle = _triangles[gridPosition];
			}

			return triangle;
		}

		/// <summary>
		/// Gets the row and column of a triangle
		/// </summary>
		/// <param name="triangle">The triangle to lookup the row and column</param>
		/// <returns>Tuple where Item1 is row, Item2 is column, null if triangle doesn't exist</returns>
		public GridPosition GetRowColumnByTriangle(Triangle triangle)
		{
			if (triangle == null) throw new ArgumentNullException(nameof(triangle));

			GridPosition gridPosition = null;
			var triangleKeyValue = _triangles.FirstOrDefault(t => t.Value.Equals(triangle));
			if (triangleKeyValue.Key != null)
			{
				gridPosition = triangleKeyValue.Key;
			}

			return gridPosition;
		}
	}
}
