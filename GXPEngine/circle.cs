using System;
namespace GXPEngine
{
	public class Circle: EasyDraw
	{

		public int radius;
		public float points;
		public Vec2 position;

		public Circle(Vec2 pPosition, int pRadius, float pPoints) : base (pRadius*2+1, pRadius*2+1)
		{
			points = pPoints;
			radius = pRadius;
			position = pPosition;
			SetOrigin(radius, radius); //punkt startowy
			Draw(255, 255, 255); //kolor z palety RGB
		}

		void Draw (byte r, byte g, byte b) //funkcja do kolorowania naszego kółka
        {
			StrokeWeight(1);
			Stroke(r, g, b);
			Fill(r, g, b);
			Ellipse(radius, radius, 2 * radius, 2 * radius);
        }

		void Update()
        {
			UpdatePosition();
        }

		void UpdatePosition()
        {
			x = position.x;
			y = position.y;
        }
	}
}

