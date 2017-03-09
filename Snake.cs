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

		public OnDead Dead { get; set; }
		public delegate void OnDead();

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

				Dead();
				return;

			}

			if (X >= Console.WindowWidth || X <= 0 || Y <= 0 || Y >= Console.WindowHeight)
			{
				Dead();
				return;
			}

			if (Direction == Direction.Down)
			{
				Y += DY;
			}

			if (Direction == Direction.Up)
			{
				Y -= DY;
			}

			if (Direction == Direction.Left)
			{
				X -= DX;
			}

			if (Direction == Direction.Right)
			{
				X += DX;
			}

		}

		public void Draw()
		{
			Console.ForegroundColor = Cor;

			var texture = string.Empty;

			if (Direction == Direction.Down)
			{
				texture = "W";
			}

			if (Direction == Direction.Up)
			{
				texture = "M";
			}

			if (Direction == Direction.Left)
			{
				texture = "<<";
			}

			if (Direction == Direction.Right)
			{
				texture = ">>";
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
