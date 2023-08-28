namespace RoverIntersection
{
    class Rover {
        private Platau _platau;
		private int _moveCount;
		private char _prevMove;
		internal Point Position { set; get; }
        internal string Moves { set; get; }

        internal Rover(Point position, Platau platau, string moves){
            Position = position;
            _platau = platau;
            Moves = moves;
			_moveCount = 0;
			_prevMove = 'X';
			_platau.VisualRepresantation[Position.X][Position.Y] = 'X';
		}

        internal void Up(){
			_moveCount++;
			if (_platau.TopRight?.Y == Position.Y)
                return;

			Position.Y = Position.Y + 1;
			FootPrint('|', "up");
		} 

        internal void Down(){
			_moveCount++;
            if (Position.Y == 0)
                return;

			Position.Y = Position.Y - 1;
			FootPrint('|', "down");
		}

        internal void Right(){
			_moveCount++;
			if (_platau.TopRight?.X == Position.X)
                return;

			Position.X = Position.X + 1;
			FootPrint('-', "right");
		}

        internal void Left(){
			_moveCount++;
			if (Position.X == 0)
                return;

			Position.X = Position.X - 1;
			FootPrint('-', "left");
		}

		private void FootPrint(char print, string direction)
		{
			if (_platau.VisualRepresantation[Position.X][Position.Y] != '.')
			{
				_platau.VisualRepresantation[Position.X][Position.Y] = '*';
			}
			else
			{
				switch (print)
				{
					case '|':
						_platau.VisualRepresantation[Position.X][Position.Y] = print;
						break;
					case '-':
						_platau.VisualRepresantation[Position.X][Position.Y] = print;
						break;
				}
			}

			Turn(direction);

			if (_moveCount == Moves.Length)
				_platau.VisualRepresantation[Position.X][Position.Y] = '0';

			_prevMove = print;
		}

		private void Turn(string direction){
			if (_prevMove == '-'){
				if (direction == "up" && _platau.VisualRepresantation[Position.X][Position.Y - 1] != '*')
					_platau.VisualRepresantation[Position.X][Position.Y - 1] = '+';
				else if (direction == "down" && _platau.VisualRepresantation[Position.X][Position.Y + 1] != '*')
					_platau.VisualRepresantation[Position.X][Position.Y + 1] = '+';
			}else if (_prevMove == '|')
				if (direction == "right" && _platau.VisualRepresantation[Position.X - 1][Position.Y] != '*')
					_platau.VisualRepresantation[Position.X - 1][Position.Y] = '+';
				else if (direction == "left" && _platau.VisualRepresantation[Position.X + 1][Position.Y] != '*')
					_platau.VisualRepresantation[Position.X + 1][Position.Y] = '+';
		}
    }
}