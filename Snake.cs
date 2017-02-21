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

		public bool IsDead { get; private set; }

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


		}

		public void Draw()
		{
			for (int x = 0; x < Console.WindowWidth; x++)
			{
				if (x >= (X - Width) && x <= (X + Width))
				{
					for (int y = 0; y < Console.WindowHeight; y++)
					{
						if (y >= (Y - Height) && y <= (Y + Height))
						{
							Console.SetCursorPosition(x, y);
							Console.ForegroundColor = Cor;
							Console.Write(".");
						}
					}
				}
			}
		}

		public Snake()
		{
			DX = 1;
			DY = 1;
			Cor = ConsoleColor.White;
		}
	}
}
