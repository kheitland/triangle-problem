using System;
using TriangleProblem.Models;

namespace TriangleProblem
{
	class Program
	{
		static void Main(string[] args)
		{
			var triangleGridGenerator = new TriangleGridGenerator();
			var triangleGridResult = triangleGridGenerator.Generate();

			Console.WriteLine("Triangle Coordinate Generator");

			while (true)
			{
				Console.WriteLine(String.Empty);
				Console.WriteLine("To find the coordinates of a triangle, enter the triangle row and column in the format: {row},{col} IE: A,4");
				Console.WriteLine("To find the triangle row and col, enter the coordinates in the format: {v1x},{v1y},{v2x},{v2y},{v3x},{v3y} IE: 20,20,20,10,30,20");
				Console.WriteLine("To exit type: exit");
				Console.WriteLine(String.Empty);

				try
				{
					var line = Console.ReadLine();
					if (!String.IsNullOrWhiteSpace(line))
					{
						if (line.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
						{
							return;
						}

						var inputs = line.Trim().Split(',');

						if (inputs.Length == 2) //Find Coords
						{
							string row = inputs[0].ToUpper();
							int column = ParseToInt(inputs[1]);

							var gridPosition = new GridPosition(row, column);

							var triangle = triangleGridResult.GetTriangleByRowColumn(gridPosition);
							if (triangle != null)
							{
								Console.WriteLine("=== Result: {0} ===", triangle.PrintCoordinates());
							}
							else
							{
								Console.WriteLine("Triangle coordinates could not be found for row: {0} and col: {1}", row, column);
							}
						}
						else if (inputs.Length == 6) //Find row/col
						{
							var v1Coord = new Coordinate(ParseToInt(inputs[0]), ParseToInt(inputs[1]));
							var v2Coord = new Coordinate(ParseToInt(inputs[2]), ParseToInt(inputs[3]));
							var v3Coord = new Coordinate(ParseToInt(inputs[4]), ParseToInt(inputs[5]));
							Triangle triangle = new Triangle(v1Coord, v2Coord, v3Coord);

							var gridPosition = triangleGridResult.GetRowColumnByTriangle(triangle);
							if (gridPosition != null)
							{
								Console.WriteLine("=== Row: {0}, Col: {1} ===", gridPosition.Row, gridPosition.Column);
							}
							else
							{
								Console.WriteLine("Coordinates do not match a triangle");
							}
						}
						else
						{
							Console.WriteLine("Invalid format entered");
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}

		private static int ParseToInt(string value)
		{
			int result;

			if (!int.TryParse(value, out result))
			{
				throw new InvalidOperationException($"{value} is not a number");
			}

			return result;
		}
	}
}
