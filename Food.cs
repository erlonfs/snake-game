using System;

namespace Snake
{
	public class Food : IElement
	{
		public ConsoleColor Cor { get; set; }
		public Type Type { get { return Type.Food; } }

		public int DX { get; set; }
		public int DY { get; set; }

		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		public bool IsEated { get; private set; }

		public void Update(IElement colision)
		{
			if (colision != null && colision.Type == Type.Snake)
			{
				IsEated = true;

				var rand = new Random();
				X = rand.Next(0, Console.WindowWidth);
				Y = rand.Next(0, Console.WindowHeight);

			}

		}

		public void Draw()
		{
			Console.SetCursorPosition(X, Y);
			Console.ForegroundColor = Cor;
			Console.Write("0");
		}

		public Food()
		{
			DX = 1;
			DY = 1;
			Cor = ConsoleColor.White;
		}
	}
}
