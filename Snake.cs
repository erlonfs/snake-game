using System;

namespace Snake
{
	public class Snake : IElement
	{
		public ConsoleColor Cor { get; set; }
		public Type Type { get { return Type.Snake; } }

		public int DX { get; set; }
		public int DY { get; set; }

		public int X { get; set; }
		public int Y { get; set; }

		public int Width { get; set; }
		public int Height { get; set; }

		public bool IsDead { get; private set; } = false;
		public Direction Direction { get; set; } = Direction.Right;

		public void Update(IElement colision)
		{
			if (colision != null)
			{
				if (colision.Type == Type.Food)
				{
					Width++;
					return;
				}

				IsDead = true;
				return;

			}

			if (X + Width >= Console.WindowWidth)
			{
				IsDead = true;
			}

			if (X - Width <= 0)
			{
				IsDead = true;
			}

			if (Y - Height <= 0)
			{
				IsDead = true;
			}

			if (Y + Height >= Console.WindowHeight)
			{
				IsDead = true;
			}


			if (Direction == Direction.Down)
			{
				Y += 1;
			}

			if (Direction == Direction.Up)
			{
				Y += -1;
			}

			if (Direction == Direction.Left)
			{
				X += -1;
			}

			if (Direction == Direction.Right)
			{
				X += 1;
			}

		}

		public void Draw()
		{
			Console.ForegroundColor = Cor;

			var texture = string.Empty;

			if (Direction == Direction.Down)
			{
				texture = "--";
			}

			if (Direction == Direction.Up)
			{
				texture = "--";
			}

			if (Direction == Direction.Left)
			{
				texture = "|||";
			}

			if (Direction == Direction.Right)
			{
				texture = "|||";
			}

			Console.SetCursorPosition(X, Y);
			Console.Write(texture);


		}

		public Snake()
		{
			DX = 1;
			DY = 1;
			Cor = ConsoleColor.White;
		}
	}

	public enum Direction
	{
		None,
		Up,
		Down,
		Left,
		Right
	}

}
