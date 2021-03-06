﻿using System;

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

		public OnEat Eated { get; set; }
		public delegate void OnEat();

		public void Update(IElement colision)
		{
			if (colision != null && colision.Type == Type.Snake)
			{
				Eated();

				var rand = new Random();
				X = rand.Next(0, Console.WindowWidth - 2);
				Y = rand.Next(0, Console.WindowHeight - 2);
			}

		}

		public void Draw()
		{
			Console.SetCursorPosition(X, Y);
			Console.ForegroundColor = Cor;
			Console.Write("■");
		}

		public Food()
		{
			DX = 1;
			DY = 1;
			Cor = ConsoleColor.White;
		}
	}
}
