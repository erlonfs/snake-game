﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
	public class Program
	{
		private static ICollection<IElement> _elements = new List<IElement>();

		private static double _frames { get { return 1000D / (_msNextFrame + _msMainLoop); } }
		private static double _msNextFrame;
		private static double _msBase { get { return 16.6; } }
		private static double _msGameVelocity { get { return 30; } }
		private static double _msMainLoop = 0;

		private static int _mod = 0;

		private static TimeSpan _timeGameUpdate { get; set; }
		private static TimeSpan _timeMainLoop { get; set; }
		private static TimeSpan _timeFrameRate { get; set; } = DateTime.Now.TimeOfDay;

		//milisegundos => 16.6; frames => 60fps
		//milisegundos => 33.2; frames => 30fps
		//milisegundos => 66.4; frames => 15fps
		//milisegundos => 125; frames => 8fps

		static void Main(string[] args)
		{

			Initialize();

			var _stWatch = new Stopwatch();

			var _countFrames = 0;
			var _timesOfMainLoop = new List<double>();

			while (true)
			{
				if (_timeMainLoop <= DateTime.Now.TimeOfDay)
				{
					_stWatch.Reset();
					_stWatch.Start();

					Run();

					_stWatch.Stop();
					_msMainLoop = _stWatch.ElapsedMilliseconds;

					_msNextFrame = (_msMainLoop - _msBase) * -1;
					_timeMainLoop = DateTime.Now.AddMilliseconds(_msNextFrame).TimeOfDay;

					_timesOfMainLoop.Add(_msMainLoop);
					_countFrames++;

				}

				if (_timeFrameRate <= DateTime.Now.TimeOfDay)
				{

					ShowFrameRate(_countFrames, _timesOfMainLoop.Average());

					_timeFrameRate = DateTime.Now.AddSeconds(1).TimeOfDay;

					_countFrames = 0;
					_timesOfMainLoop.Clear();
				}

				

			}
		}

		static void ShowFrameRate(int frames, double msMainLoop)
		{
			Console.Title = $@".:: snake game ::.   {frames.ToString("N0")} fps | 
							elapsed main loop {msMainLoop.ToString("N0")} milliseconds";
		}

		static bool Colision(IElement elem1, IElement elem2)
		{
			int left1 = elem1.X;
			int left2 = elem2.X;
			int right1 = elem1.X + elem1.Width;
			int right2 = elem2.X + elem2.Width;
			int top1 = elem1.Y;
			int top2 = elem2.Y;
			int bottom1 = elem1.Y + elem1.Height;
			int bottom2 = elem2.Y + elem2.Height;

			if (bottom1 < top2) return false;
			if (top1 > bottom2) return false;

			if (right1 < left2) return false;
			if (left1 > right2) return false;

			return true;

		}

		static void Run()
		{
			if (_timeGameUpdate < DateTime.Now.TimeOfDay)
			{
				Console.Clear();

				_elements.ForEach(q1 =>
				{
					bool colision = false;
					_elements.ForEach(q2 => { if (q2.X != q1.X && q2.Y != q1.Y) { colision = colision || Colision((Snake)q1, (Snake)q2); } });
					q1.Update(colision);
					q1.Draw();
				});

				_timeGameUpdate = DateTime.Now.AddMilliseconds(_msGameVelocity).TimeOfDay;

			}
		}

		static void Initialize()
		{
			Console.CursorVisible = false;

			_timeMainLoop = DateTime.Now.TimeOfDay;
			_msNextFrame = _msBase;

			var snake = new Snake();
			snake.X = 1;
			snake.Y = 10;
			snake.Width = 2;
			snake.Height = 1;
			snake.Cor = ConsoleColor.DarkGreen;

			_elements.Add(snake);

		}

	}

	public static class System
	{
		public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			foreach (var item in enumerable)
			{
				action(item);
			}
		}
	}
}