using System;

namespace Snake
{
	public class Snake : IElement
	{
		public ConsoleColor Cor { get; set; }

		public int DX { get; set; }
		public int DY { get; set; }

		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		public void Update(bool colision)
		{
			if (colision)
			{
				DX *= -1;
				DY *= -1;
			}
			else
			{
				if (X + Width >= Console.WindowWidth)
				{
					DX = -1;
				}

				if (X - Width <= 0)
				{
					DX = 1;
				}

				if (Y - Height <= 0)
				{
					DY = 1;
				}

				if (Y + Height >= Console.WindowHeight)
				{
					DY = -1;
				}
			}

			X += DX;
			Y += DY;

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
							Console.Write("0");
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
