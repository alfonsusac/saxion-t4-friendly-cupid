using System;
using GXPEngine;    // For Mathf

public struct Vec2
{
	public float x;
	public float y;

	public Vec2(float pX = 0, float pY = 0)
	{
		x = pX;
		y = pY;
	}

	public override string ToString() => $"({x} .{y} )";
	public float Length() => Mathf.Sqrt(x * x + y * y);
	public void Normalize()
	{
		float tempL = Length();
		if (tempL != 0.0f)
		{
			x /= tempL;
			y /= tempL;
		}
	}
	public void SetXY(float a, float b)
	{
		x = a;
		y = b;
	}
	public Vec2 Normalized()
	{
		Vec2 temp = this;
		temp.Normalize();
		return temp;
	}
	public static Vec2 operator +(Vec2 left, Vec2 right) => new Vec2(left.x + right.x, left.y + right.y);
	public static Vec2 operator -(Vec2 left, Vec2 right) => new Vec2(left.x - right.x, left.y - right.y);
	public static Vec2 operator *(float left, Vec2 right) => new Vec2(left * right.x, left * right.y);
	public static Vec2 operator *(Vec2 left, float right) => new Vec2(left.x * right, left.y * right);
	public static Vec2 operator /(float left, Vec2 right) => new Vec2(left / right.x, left / right.y);
	public static Vec2 operator /(Vec2 left, float right) => new Vec2(left.x / right, left.y / right);
	public static bool operator ==(Vec2 left, Vec2 right) => left.x == right.x && left.y == right.y;
	public static bool operator !=(Vec2 left, Vec2 right) => left.x != right.x && left.y != right.y;
	public static bool operator >(Vec2 left, Vec2 right) => left.x > right.x && left.y > right.y;
	public static bool operator <(Vec2 left, Vec2 right) => left.x < right.x && left.y < right.y;
	public static Vec2 operator +(Vec2 left) => left;
	public static Vec2 operator -(Vec2 left) => -1 * left;
	public static bool operator !(Vec2 left) => left != zero;

	public static void UnitTest1()
	{
		Console.WriteLine("\nWeek 1 Unit Tests\n------");

		Vec2 v = new Vec2(3, 4);
		Console.WriteLine("Length ok?\n {0} ({1})\n", v.Length() == 5, v.Length());
		Console.WriteLine("Coordinates ok?\n {0} ({1}, {2})\n",
			(v.x == 3 && v.y == 4), v.x, v.y);

		Vec2 w = new Vec2(6, 8);
		Vec2 z = v + w;
		Console.WriteLine("Addition ok?\n {0} ({1} {2})\n",
			(z.x == 9 && z.y == 12), z.x, z.y);

		Vec2 x = v - w;
		Console.WriteLine("Substraction ok?\n {0} ({1}, {2})\n",
			(x.x == -3 && x.y == -4), x.x, x.y);

		Vec2 y = v * 10;
		Console.WriteLine("Scalar Multiplication Left ok?\n {0} ({1}, {2})\n",
			(y.x == 30 && y.y == 40), y.x, y.y);

		Vec2 u = 5 * v;
		Console.WriteLine("Scalar Multiplication Right ok?\n {0} ({1}, {2})\n",
			(u.x == 15 && u.y == 20), u.x, u.y);

		Vec2 t = v.Normalized();
		Console.WriteLine("Normalized() ok?\n {0} ({1}) ({2}, {3})\n",
			(t.x == 0.6f && t.y == 0.8f), t.Length(), t.x, t.y);

		w.Normalize();
		Console.WriteLine("Normalize() ok?\n {0} ({1}) ({2}, {3})\n",
			(w.x == 0.6f && w.y == 0.8f), w.Length(), w.x, w.y);

		w.SetXY(12, 16);
		Console.WriteLine("SetXY ok?\n {0} ({1}, {2})\n",
			(w.x == 12 && w.y == 16), w.x, w.y);
	}

	// --------------------------
	// FROM ASSIGNMENT 2
	// --------------------------
	public static float Deg2Rad(float Degrees) => (Degrees * Mathf.PI) / 180f;
	public static float Rad2Deg(float Radians) => (Radians * 180f) / Mathf.PI;
	public static Vec2 GetUnitVectorRad(float Rad) => new Vec2(Mathf.Cos(Rad), Mathf.Sin(Rad));
	public static Vec2 GetUnitVectorDeg(float Degrees) => GetUnitVectorRad(Deg2Rad(Degrees));
	public static Vec2 RandomUnitVector()
	{
		Random s = new Random();
		float rad = (float)(s.NextDouble() * Math.PI * 2);
		Vec2 u = new Vec2(Mathf.Cos(rad), Mathf.Sin(rad));
		return u;
	}
	public void SetAngleRadians(float Radian)
	{
		float r = Length();
		SetXY(
			r * Mathf.Cos(Radian),
			r * Mathf.Sin(Radian)
		);
	}
	public void SetAngleDegrees(float Degrees) => SetAngleRadians(Deg2Rad(Degrees));
	public float GetAngleRadians() => Mathf.Atan2(y, x);
	public float GetAngleDegrees() => Rad2Deg(GetAngleRadians());
	public void RotateRadians(float Radians)
	{
		float newx = x * Mathf.Cos(Radians) - y * Mathf.Sin(Radians);
		float newy = x * Mathf.Sin(Radians) + y * Mathf.Cos(Radians);
		SetXY(newx, newy);
	}
	public void RotateDegrees(float Degrees) => RotateRadians(Deg2Rad(Degrees));
	public void RotateAroundRadians(float Radians, Vec2 center)
	{
		Vec2 tmp = this - center;
		tmp.RotateRadians(Radians);
		tmp += center;
		SetXY(tmp.x, tmp.y);
	}
	public void RotateAroundDegrees(float Degrees, Vec2 center) => RotateAroundRadians(Deg2Rad(Degrees), center);
	public static float getDistanceBetweenVec(Vec2 a, Vec2 b) => (b - a).Length();
	public static float getAngleBetweenVec(Vec2 a, Vec2 b) => Mathf.Atan2(b.y - a.y, b.x - a.x);
	public static void UnitTest2()
	{
		Console.WriteLine("\nWeek 2 Unit Tests\n------");

		float rad = Deg2Rad(45f);
		Console.WriteLine("Deg2Rad ok?\n" + "{0} ({1})\n",
			Approximate(rad, 0.785f), rad);

		float deg = Rad2Deg(Mathf.PI);
		Console.WriteLine("Rad2Deg ok?\n" + "{0} ({1})\n",
			Approximate(deg, 180f), deg);

		Vec2 u = GetUnitVectorRad(0.25f * Mathf.PI);
		Vec2 v = new Vec2(1.00f / Mathf.Sqrt(2), 1.00f / Mathf.Sqrt(2));
		Console.WriteLine("GetUnitVectorRad ok?\n" + "{0} ({1}, {2})\n",
			Approximate(v, u), u.x, u.y);

		Vec2 w = GetUnitVectorDeg(45f);
		Console.WriteLine("GetUnitVectorRad ok?\n" + "{0} ({1}, {2})\n",
			Approximate(w, u), w.x, w.y);

		Vec2 x = new Vec2(100, 0);
		x.SetAngleDegrees(45);
		Vec2 y = new Vec2(50 * Mathf.Sqrt(2), 50 * Mathf.Sqrt(2));
		Console.WriteLine("SetAngleDegrees ok?\n" + "{0} ({1}, {2})\n",
			Approximate(y, x), x.x, x.y);

		Vec2 x2 = new Vec2(50, 0);
		x2.SetAngleRadians(0.25f * Mathf.PI);
		Vec2 y2 = new Vec2(25 * Mathf.Sqrt(2), 25 * Mathf.Sqrt(2));
		Console.WriteLine("SetAngleRadians ok?\n" + "{0} ({1}, {2})\n",
			Approximate(y2, x2), x2.x, x2.y);

		float u1 = y2.GetAngleDegrees();
		Console.WriteLine("GetAngleDegrees ok?\n" + "{0} ({1})\n",
			u1 == 45f, u1);

		float u2 = y.GetAngleRadians();
		Console.WriteLine("GetAngleRadians ok?\n" + "{0} ({1})\n",
			u2 == (Mathf.PI * 0.25f), u2);

		y2.RotateDegrees(90f);
		Vec2 z1 = new Vec2(-25 * Mathf.Sqrt(2), 25 * Mathf.Sqrt(2));
		Console.WriteLine("RotateDegrees ok?\n" + "{0} ({1}, {2})\n",
			Approximate(z1, y2), y2.x, y2.y);

		y2.RotateRadians(Mathf.PI);
		Vec2 z2 = new Vec2(25 * Mathf.Sqrt(2), -25 * Mathf.Sqrt(2));
		Console.WriteLine("RotateRadians ok?\n" + "{0} ({1}, {2})\n",
			Approximate(z2, y2), y2.x, y2.y);

		Vec2 u3 = new Vec2(5, 3);
		u3.RotateAroundDegrees(90, new Vec2(2, 3));
		Console.WriteLine("RotateAroundDegrees ok?\n" + "{0} ({1}, {2})\n",
			Approximate(u3, new Vec2(2, 6)), u3.x, u3.y);

		Vec2 u4 = new Vec2(5, 3);
		u4.RotateAroundRadians(Mathf.PI * 0.5f, new Vec2(2, 3));
		Console.WriteLine("RotateAroundRadians ok?\n" + "{0} ({1}, {2})\n",
			Approximate(u4, new Vec2(2, 6)), u4.x, u4.y);


	}

	// For Box Collision

	public static readonly int top = 0;
	public static readonly int bottom = 1;
	public static readonly int left = 2;
	public static readonly int right = 3;
	public static bool IsYAxis(int direction) => direction == top || direction == bottom ? true : false;
	public static bool IsXAxis(int direction) => direction == left || direction == right ? true : false;
	public float Axis(int direction) => IsYAxis(direction) ? y : IsXAxis(direction) ? x : 0f;
	public void setXYonAxis(int direction, float Value)
	{
		if (IsYAxis(direction)) y = Value;
		else if (IsXAxis(direction)) x = Value;
	}
	public static Vec2 zero = new Vec2(0, 0);
	public static void UnitTest3()
	{
		Console.WriteLine("\nWeek 3 Unit Tests\n------");

		Console.WriteLine("IsYAxis ok?\n" + "{0} ({1})\n",
			IsYAxis(left) == false, "Left");

		Console.WriteLine("IsXAxis ok?\n" + "{0} ({1})\n",
			IsXAxis(left) == true, "Left");

		Vec2 v = new Vec2(3, 4);
		Console.WriteLine("IsXAxis ok?\n" + "{0} ({1})\n",
			v.Axis(left) == 3, "Left, 3");

		Console.WriteLine("IsXAxis ok?\n" + "{0} ({1})\n",
			v.Axis(top) == 4, "Top, 4");

		v.setXYonAxis(right, 10);
		Console.WriteLine("setXYonAxis ok?\n" + "{0} ({1})\n",
			v.Axis(right) == 10, "right, 10");
	}
	// For Circle/Line Collision
	public float Dot(Vec2 other) => x * other.x + y * other.y;
	public static float operator *(Vec2 left, Vec2 right) => left.x * right.x + left.y * right.y;
	public Vec2 Normal() => new Vec2(-y, x).Normalized();
	public float scalarProj(Vec2 b) => Dot(b.Normalized());
	public Vec2 vectorProj(Vec2 b) => scalarProj(b) * b.Normalized();
	public Vec2 Reflect(Vec2 normal, float bounciness = 1)
	{
		float C = bounciness;
		Vec2 n = normal;
		Vec2 newV = this - (1 + C) * vectorProj(n);
		SetXY(newV.x, newV.y);
		return this;
	}
	public static void UnitTest4()
	{
		Console.WriteLine("\nWeek 4 Unit Tests\n------");

		Vec2 v = new Vec2(3, 4);
		Vec2 w = new Vec2(5, 6);
		Console.WriteLine("Is Dot ok?\n {0} ({1})\n",
			v.Dot(w) == 39, v.Dot(w));

		Console.WriteLine("Is Normal ok?\n {0} ({1})\n",
			v.Normal() == new Vec2(-0.8f, 0.6f), v.Normal());

		Console.WriteLine("Is Scalar Projection ok?\n {0} ({1})\n",
			w.scalarProj(v) == 7.8f, w.scalarProj(v));

		Console.WriteLine("Is Vector Projection ok?\n {0} ({1})\n",
			Approximate(w.vectorProj(v), new Vec2(4.68f, 6.24f)), w.vectorProj(v));

		Vec2 x = new Vec2(4, 6);
		x.Reflect(new Vec2(2, 1), 1);
		Console.WriteLine("Is Reflect ok?\n {0} ({1})\n",
			Approximate(x, new Vec2(-7.2f, 0.4f)), x);

	}
	// Unit Testing


	public static void unitTest()
	{
		UnitTest1();
		UnitTest2();
		UnitTest3();
		UnitTest4();
	}
	public static bool Eq(float a, float b, float errorMargin = 0.01f) => Approximate(a, b, errorMargin);
	public static bool Approximate(float a, float b, float errorMargin = 0.01f) => Mathf.Abs(a - b) < errorMargin;
	public static bool Approximate(Vec2 a, Vec2 b, float errorMargin = 0.01f) => Approximate(a.x, b.x, errorMargin) && Approximate(a.y, b.y, errorMargin);
}

