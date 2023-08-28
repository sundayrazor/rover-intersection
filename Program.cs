using System;

namespace RoverIntersection
{
    class Program {         
        static void Main(string[] args)
        {
			Console.WriteLine("-------------------------Rover Intersection Calculator-------------------------");
			string input;
			string terminater = string.Empty;

            while (terminater != "quit") 
            {
				Console.WriteLine("Press 1 to continue or Press 0 to quit");
				input = Console.ReadLine()!;
				switch (input)
				{
					case "1":
						Calculate();
						break;

					case "0":
						terminater = "quit";
						break;
				}
			}
        }

		static void Calculate()
		{
			var rovers = new List<Rover>();

			var topRightOfPlatau = GetPointFromConsole("Enter the upper-right coordinates of the plateau");
			var platau = new Platau(topRightOfPlatau.X, topRightOfPlatau.Y);

			var isAdd = true;
			while(isAdd)
			{
				Console.WriteLine("Press 2 to add a rover or Press 3 to continue to calculate intersections");
				var input = Console.ReadLine();
				switch (input)
				{
					case "2":
						var position = GetPointFromConsole("Enter the rover's initial position");
						Console.WriteLine("Enter the series of instructions telling rover how to explore the plateau");
						var moves = Console.ReadLine();
						var rover = new Rover(new Point() { X = position.X, Y = position.Y }, platau, moves!);
						rovers.Add(rover);

						break;

					case "3":
						isAdd = false;
						break;

					default:
						Console.WriteLine("Wrong input");
						break;
				}
			}

			var mover = new RoversMover(rovers);
			mover.MoveRorovers();
			var intersections = platau.GetIntersectionPoints();

			Console.WriteLine("**********************OUTPUT**********************");
			Console.WriteLine("--------------------------------------------------");
			Console.WriteLine("Intersections");
			var count = 1;
			foreach(var point in intersections)
			{
				Console.WriteLine($"Intersection point {count}: {point.X} {point.Y}");
				count++;
			}
			Console.WriteLine("--------------------------------------------------");

			Console.WriteLine("Visual representation path");
			platau.PrintVisualRepresantation();
			Console.WriteLine("--------------------------------------------------");
		}

		private static Point GetPointFromConsole(string msg)
		{
			var point = new Point();
			var pointIsValid = false;
			while (!pointIsValid)
			{
				Console.WriteLine(msg);
				var input = Console.ReadLine();
				var coordinate = input?.Split(" ");
				if (coordinate?.Length > 1 && int.TryParse(coordinate[0], out int x) && int.TryParse(coordinate[1], out int y))
				{
					point.X = x;
					point.Y = y;
					pointIsValid = true;
				}
				else
				{
					Console.WriteLine("Input invalid, insert two integers separated by space");
				}
			}

			return point;
		}
    }
}
