using System;
using System.Collections.Generic;
namespace GXPEngine
{


	public class Level : GameObject
	{
		//List<Circle> _circleslist = new List<Circle>();

		private int id;
		private Game game;

		private Vec2 startH; //musimy mieć to cały czas a nie tylko w jednej klatce
		private Vec2 endH;
		private LineSegment Hover;
		
		Ball _ball;

		//--------------------------------------------------------------
		// LEVELS
		//--------------------------------------------------------------
		private static readonly List<Level> levels = new List<Level>();

		public Level getLevel(int id)
		{
			return levels[id];
		}
		public void addLevel(Level l)
		{
			levels.Add(l);
		}

		public Level()
		{

			//AddCircle(new Vec2(100, 500), 20, 10);
			//AddCircle(new Vec2(200, 300), 20, 10);
			//AddCircle(new Vec2(300, 500), 20, 10);
			//AddCircle(new Vec2(400, 300), 20, 10);
			//AddCircle(new Vec2(500, 500), 20, 10);
			//AddCircle(new Vec2(600, 300), 20, 10);



			//AddLine(new Vec2(600, 21), new Vec2(780, 155), 0); //linia prawy róg
			//AddLine(new Vec2(680, 200), new Vec2(680, 650), 0); //linia prawy bok 1
			//AddLine(new Vec2(780, 20), new Vec2(780, 700), 0); //linia prawy bok 2
			//AddLine(new Vec2(20, 155), new Vec2(200, 21), 0); //linia lewy róg
			//AddLine(new Vec2(20, 700), new Vec2(780, 700), 0);

			//Level 1
			
			//AddLine(new Vec2(20, 20), new Vec2(300, 20), 0); //linia góra
			//AddLine(new Vec2(20, 20), new Vec2(20, 200), 0); //linia lewa bok
			//AddLine(new Vec2(20, 200), new Vec2(200, 200), 0);
			//AddLine(new Vec2(200, 200), new Vec2(250, 150), 0);
			//AddLine(new Vec2(300, 400), new Vec2(500, 200), 0);

			//AddLine(new Vec2(20, 300), new Vec2(20, 600), 0); //linia lewa bok
			//AddLine(new Vec2(350, 20), new Vec2(500, 170), 0); //linia lewa bok
			


			//Level 2
			/*
			AddLine(new Vec2(20, 20), new Vec2(300, 20), 0); //linia góra
			AddLine(new Vec2(20, 20), new Vec2(20, 200), 0); //linia lewa bok
			AddLine(new Vec2(20, 200), new Vec2(200, 200), 0);
			AddLine(new Vec2(300, 20), new Vec2(300, 300), 0);
			AddLine(new Vec2(150, 500), new Vec2(400, 500), 0);
			AddLine(new Vec2(150, 350), new Vec2(150, 500), 0);
			AddLine(new Vec2(400, 350), new Vec2(400, 500), 0);
			*/


			//_ball = new Ball(820, 660, 12); // tworzenie piłki
			//AddChild(_ball); 
		}

		//--------------------------------------------------------------
		// GAME OBJECTS
		//--------------------------------------------------------------
		private readonly List<GameObject> gameObjects = new List<GameObject>();
		public GameObject getGameObject(int i)
        {
			return gameObjects[i];
        }
		public void addGameObject(GameObject g)
        {
			gameObjects.Add(g);
        }

		//--------------------------------------------------------------
		// LINES
		//--------------------------------------------------------------
		private readonly List<LineSegment> lines = new List<LineSegment>();

		public int GetLinesCount()
		{
			return lines.Count; //zwraca ilość linii
		}

		public LineSegment GetLine(int i)
		{
			if (i >= 0 && i < lines.Count)
			{
				return lines[i];
			}
			return null; //nic nie zwróci

		}


		//public int CountCircles()
		//{
		//	return _circleslist.Count; //zwraca ilość kółek
		//}

		//public Circle GetCircle(int i)
		//{
		//	if (i >= 0 && i < _circleslist.Count)
		//	{
		//		return _circleslist[i];
		//	}
		//	return null; //nic nie zwróci
		//}



		//public void AddCircle(Vec2 position, int radius, float points)
		//{
		//	Circle circle = new Circle(position, radius, points);
		//	AddChild(circle); //dodaje kółko do gry
		//	_circleslist.Add(circle); //dodaje kółko do listy kółek
		//}

		//public void AddLine(Vec2 start, Vec2 end, float points)
		//{
		//	LineSegment lineup = new LineSegment(start, end, points);
		//	LineSegment linedown = new LineSegment(end, start, points);

		//	Circle linestart = new Circle(start, 0, points);
		//	Circle lineend = new Circle(end, 0, points);

		//	AddChild(lineup);
		//	AddChild(linedown);
		//	lines.Add(lineup);
		//	lines.Add(linedown);

		//	AddChild(linestart);
		//	AddChild(lineend);
		//	_circleslist.Add(linestart);
		//	_circleslist.Add(lineend);
		//}

   //     public void MovingLine()
   //     {
   //         RemoveChild(Hover);
			//lines.Remove(Hover);

   //         if (Input.GetKey(Key.RIGHT) && startH.x<=770)
   //         {
   //             startH.x += 10;
   //             endH.x += 10;
   //         }
   //         else if (Input.GetKey(Key.LEFT) && endH.x>=21)
   //         {
   //             startH.x -= 10;
   //             endH.x -= 10;
   //         }

   //         Hover = new LineSegment(startH, endH, 0);
   //         AddChild(Hover);
			//lines.Add(Hover);
   //     }

	}

}


