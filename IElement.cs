using System;

namespace Snake
{
	public interface IElement
	{
		Type Type { get; }

		int X { get; set; }
		int Y { get; set; }

		int Width { get; set; }
		int Height { get; set; }

		void Update(IElement colision);
		void Draw();
	}
}
