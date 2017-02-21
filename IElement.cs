namespace Snake
{
	public interface IElement
	{
		int X { get; set; }
		int Y { get; set; }

		int Width { get; set; }
		int Height { get; set; }

		void Update(bool colision);
		void Draw();
	}
}
