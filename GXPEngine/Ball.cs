using System;
namespace GXPEngine
{
	public class Ball: EasyDraw
	{
		Vec2 _oldp;
		public static Vec2 position; //pozycja dostępna tylko tutaj ale program jak opuści to nie straci jej wartości
		Vec2 _velocity;


		float _bounciness = 0.99f;
		public float points = 0;
		int _radius;
		float _speed = 0.1f;
		bool _islaunched = false; //jeszcze nie było wystrzelone

		Aim _aiming;
		public Ball(float pPosX, float pPosY, int pRadius) : base(pRadius*2+1, pRadius*2+1)
		{
			position = new Vec2(pPosX, pPosY);
			_radius = pRadius;

			_aiming = new Aim();
			SetOrigin(_radius, _radius);
			AddChild(_aiming);
			
			Draw(255, 204, 255);
		}

		void Draw(byte r, byte g, byte b)
		{
			StrokeWeight(1);
			Stroke(r, g, b);
			Fill(r, g, b);
			Ellipse(_radius, _radius, 2 * _radius, 2 * _radius);
		}

		void Update()
        {
			MyGame myGame = (MyGame)game;
			Level level = myGame.level;
			UpdatePosition();

			if (!_islaunched)
            {
				BallLaunch();
            }

			else if(_islaunched)
			{
				_oldp = position;
				position += _velocity;
				
				_velocity = _velocity.Normalized() * _speed; // not really physics...
				_speed += 0.01f;


				FindEarliestCollisionCircle(level);
				FindEarliestCollisionLine(level);
			}
			
		}

		

		void UpdatePosition()
        {
			x = position.x;
			y = position.y;
        }

		void BallLaunch()
        {
			if(Input.GetKey(Key.SPACE))
            {
				Vec2 launchV = new Vec2(-10f, 0); //prędkośc wystrzału, musi być ujemna inaczej poleci do dołu
				launchV.RotateDegrees(_aiming.rotation - 90); //celowanie, przekęcamy o 90 stopni ze względu na to, że na nasze działko było też przekręcone;
				_velocity += launchV;
				_aiming.LateDestroy(); //usuwanie pointera po wystrzale 
				_islaunched = true; //powoduje, że kulka wystrzeliwuje

            }


        }

		void FindEarliestCollisionCircle(Level level)
		{
			//Check circle movers:			
			for (int i = 0; i < level.CountCircles(); i++)
			{
				Circle Cmover = level.GetCircle(i); //bierzemy wszystkie kółka
				Vec2 relativePosition = position - Cmover.position;
				if (relativePosition.Length() < _radius + Cmover.radius)
					{
						Vec2 normalized = relativePosition.Normalized(); //czyli musimy dostac vektor o długości 1 tzw. unit vector 
						float overlap = _radius + Cmover.radius - relativePosition.Length();
						position += normalized * overlap;
						_velocity.Reflect(normalized, _bounciness);
						points += Cmover.points;
						Console.WriteLine(points);

				}
				
			}
			
		}

		void FindEarliestCollisionLine(Level level)
		{
			// Check line movers:			
			for (int i = 0; i < level.GetLinesCount(); i++)
			{
				LineSegment Lmover = level.GetLine(i); //slajdy 76 week5
				Vec2 olddif = _oldp - Lmover.start;    //mover.end - _oldposition, musimy znależć odłegłość pomiędzy końcem linii a środkiem naszej piłki
				Vec2 linedif = Lmover.end - Lmover.start; //znajdujemy długość naszej linii
				Vec2 lineNor = linedif.Normal(); //normalizujemy naszą długość

				float a = lineNor.Dot(olddif) - _radius;
				float b = -lineNor.Dot(_velocity);
				float TOI;
				
				if (b <= 0) continue;  //if b<=0 return no collision
				if (a < 0) continue;   //if a<0 return no collision

				TOI = a / b;

				if (TOI <=1)
                {
					Vec2 POI = _oldp + TOI * _velocity;
					float d = (POI - Lmover.start).Dot(linedif.Normalized()); //sprawdzamy POI, jeśli jest na zderzeniu z linią (od startu lub końca) distance along the line
					if (d >= 0 && d <= linedif.Length())
                    { //return collision at time t
						position = POI;
						//points += Lmover.points;
						_velocity.Reflect(lineNor, _bounciness);
						//Console.WriteLine(points);
					}
				}
				
				
			}
		}
	}
}

