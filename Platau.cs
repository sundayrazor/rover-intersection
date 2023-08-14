using System;

namespace RoverIntersection
{
    class Platau {
        internal Point? TopRight { get; set; } = new();
        internal char[][] VisualRepresantation { get; set; }

        internal Platau(int x, int y){
            TopRight.X = x;
            TopRight.Y = y;
            VisualRepresantation = new char[x+1][];

            for(var i = 0; i <= x; i++)
            {
				VisualRepresantation[i] = new char[y+1];
                for(var j = 0; j <= y; j++)
                    VisualRepresantation[i][j] = '.';
            }
        }

		internal void PrintVisualRepresantation()
		{
			for (var y = TopRight!.Y;  y >= 0; y--)
			{
				for (var x = 0; x <= TopRight.X; x++)
                    Console.Write(VisualRepresantation[x][y]);

                Console.WriteLine();
			}
		}

		internal List<Point> GetIntersectionPoints()
		{
			var points = new List<Point>();

			for (var i = 0; i <= TopRight?.X; i++)
			{
				for (var j = 0; j <= TopRight?.Y; j++)
					if(VisualRepresantation[i][j] == '*')
						points.Add(new Point() { X = i, Y = j });
			}

			return points;
		}
	}
}