namespace RoverIntersection
{
    class RoversMover {
        private IEnumerable<Rover> _rovers;

        internal RoversMover(IEnumerable<Rover> rovers){
            _rovers = rovers;
        }

        internal void MoveRorovers(){
             foreach(var rover in _rovers)
             {
                 foreach(var move in rover.Moves)
                 {
                    switch (move.ToString().ToLower())
                    {
                        case "n":
                            rover.Up();
                            break;

						case "s":
							rover.Down();
							break;

						case "e":
							rover.Right();
							break;

						case "w":
							rover.Left();
							break;

                        default: break;
					}
                 }
             }
        }
    }
}