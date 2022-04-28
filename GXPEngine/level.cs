using System;
using System.Collections.Generic;
namespace GXPEngine
{


	public class Level : GameObject
	{

		private Vec2 startH; //musimy mieć to cały czas a nie tylko w jednej klatce
		private Vec2 endH;
		private LineSegment Hover;
		

		List<LineSegment> _lineslist = new List<LineSegment>(); //tworzymy listę z naszymi liniami

		List<Circle> _circleslist = new List<Circle>();

		Ball _ball;

		public Level()
		{
			//AddCircle(new Vec2(100, 500), 20, 10);
			//AddCircle(new Vec2(200, 300), 20, 10);
			//AddCircle(new Vec2(300, 500), 20, 10);
			//AddCircle(new Vec2(400, 300), 20, 10);
			//AddCircle(new Vec2(500, 500), 20, 10);
			//AddCircle(new Vec2(600, 300), 20, 10);



			//AddLine(new Vec2(600, 21), new Vec2(780, 155), 0); //linia prawy róg
			AddLine(new Vec2(20, 20), new Vec2(300, 20), 0); //linia góra
			//AddLine(new Vec2(680, 200), new Vec2(680, 650), 0); //linia prawy bok 1
			//AddLine(new Vec2(780, 20), new Vec2(780, 700), 0); //linia prawy bok 2
			//AddLine(new Vec2(20, 155), new Vec2(200, 21), 0); //linia lewy róg
			AddLine(new Vec2(20, 20), new Vec2(20, 200), 0); //linia lewa bok
			//AddLine(new Vec2(20, 700), new Vec2(780, 700), 0);
			AddLine(new Vec2(20, 200), new Vec2(200, 200), 0);
			AddLine(new Vec2(200, 200), new Vec2(250, 150), 0);
			AddLine(new Vec2(300, 400), new Vec2(500, 200), 0);

			AddLine(new Vec2(20, 300), new Vec2(20, 600), 0); //linia lewa bok
			AddLine(new Vec2(350, 20), new Vec2(500, 170), 0); //linia lewa bok



			_ball = new Ball(740, 680, 12); // tworzenie piłki
			AddChild(_ball); 



			//tworzenie Hovera od początku
			startH = new Vec2(500, 680);
			endH = new Vec2(300, 680);

			Hover = new LineSegment(startH, endH, 0);
			_lineslist.Add(Hover);
			AddChild(Hover);
		}



		public int GetLinesCount()
		{
			return _lineslist.Count; //zwraca ilość linii
		}

		public LineSegment GetLine(int i)
		{
			if (i >= 0 && i < _lineslist.Count)
			{
				return _lineslist[i];
			}
			return null; //nic nie zwróci

		}


		public int CountCircles()
		{
			return _circleslist.Count; //zwraca ilość kółek
		}

		public Circle GetCircle(int i)
		{
			if (i >= 0 && i < _circleslist.Count)
			{
				return _circleslist[i];
			}
			return null; //nic nie zwróci
		}



		public void AddCircle(Vec2 position, int radius, float points)
		{
			Circle circle = new Circle(position, radius, points);
			AddChild(circle); //dodaje kółko do gry
			_circleslist.Add(circle); //dodaje kółko do listy kółek
		}

		public void AddLine(Vec2 start, Vec2 end, float points)
		{
			LineSegment lineup = new LineSegment(start, end, points);
			LineSegment linedown = new LineSegment(end, start, points);

			Circle linestart = new Circle(start, 0, points);
			Circle lineend = new Circle(end, 0, points);

			AddChild(lineup);
			AddChild(linedown);
			_lineslist.Add(lineup);
			_lineslist.Add(linedown);

			AddChild(linestart);
			AddChild(lineend);
			_circleslist.Add(linestart);
			_circleslist.Add(lineend);
		}

        public void MovingLine()
        {
            RemoveChild(Hover);
			_lineslist.Remove(Hover);

            if (Input.GetKey(Key.RIGHT) && startH.x<=770)
            {
                startH.x += 10;
                endH.x += 10;
            }
            else if (Input.GetKey(Key.LEFT) && endH.x>=21)
            {
                startH.x -= 10;
                endH.x -= 10;
            }

            Hover = new LineSegment(startH, endH, 0);
            AddChild(Hover);
			_lineslist.Add(Hover);
        }

	}

}


