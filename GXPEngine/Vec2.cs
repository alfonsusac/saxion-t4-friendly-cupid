using System;
using GXPEngine; // Allows using Mathf functions

public struct Vec2
{
	public float x;
	public float y;


	public Vec2(float pX = 0, float pY = 0)
	{
		x = pX;
		y = pY;
	}


	public float Length()
	{
		return Mathf.Sqrt(x * x + y * y);
	}

	public void Normalize()
	{
		float lenght = Length();
		if (lenght != 0.0f)
		{
			x = x / lenght;
			y = y / lenght;
		}
	}

	public void SetXY(float a, float b)
	{
		x = a;
		y = b;
	}

	public Vec2 Normalized()
	{
		float length = Length();
		return new Vec2(x / length, y / length);
	}

	public static float Deg2Rad(float degrees)
	{
		float radians = (Mathf.PI / 180) * degrees;
		return radians;
	}

	public static float Rad2Deg(float radians)
	{
		float degrees = (180 / Mathf.PI) * radians;
		return degrees;
	}

	public static Vec2 GetUnitVectorRad(float radians)
	{
		float x = Mathf.Cos(radians);
		float y = Mathf.Sin(radians);
		Vec2 u = new Vec2(x, y);
		return u;
	}

	public static Vec2 GetUnitVectorDeg(float degrees)
	{
		float radians = Deg2Rad(degrees);
		return GetUnitVectorRad(radians);
	}

	public static Vec2 RandomUnitVector()
	{
		Random radians = new Random();
		return GetUnitVectorRad(radians.Next(0, 1000));
	}


	public void SetAngleRadians(float radians)
	{
		float r = Length(); // Mathf.Sqrt(x * x + y * y);
		x = r * Mathf.Cos(radians);
		y = r * Mathf.Sin(radians);
	}


	public void SetAngleDegrees(float degrees)
	{
		float radians = Deg2Rad(degrees);
		SetAngleRadians(radians);
	}


	public float GetAngleDegrees()
	{
		float angle = Mathf.Atan2(y, x);
		float degrees = Rad2Deg(angle);
		return degrees;
	}

	public float GetAngleRadians()
	{
		float angle = Mathf.Atan2(y, x);
		return angle;
	}


	public void RotateRadians(float radians)
	{
		float cos = Mathf.Cos(radians);
		float sin = Mathf.Sin(radians);
		if (Mathf.Abs(sin) < 0.0001f) sin = 0; //fixes inaccuracies
		if (Mathf.Abs(cos) < 0.0001f) cos = 0; // same^
		Vec2 v = new Vec2(x, y);
		Vec2 z = new Vec2(cos * v.x - sin * v.y, sin * v.x + cos * v.y);
		SetXY(z.x, z.y);
	}

	public void RotateDegrees(float degrees)
	{
		float radians = Deg2Rad(degrees);
		RotateRadians(radians);
	}

	public void RotateAroundRadians(Vec2 Point, float radians)
	{
		float cos = Mathf.Cos(radians);
		float sin = Mathf.Sin(radians);
		Vec2 v = new Vec2(x - Point.x, y - Point.y);
		Vec2 z = new Vec2(cos * v.x - sin * v.y, sin * v.x + cos * v.y);
		SetXY(z.x + Point.x, z.y + Point.y);
	}

	public void RotateAroundDegrees(Vec2 Point, float degrees)
	{
		float radians = Deg2Rad(degrees);
		float cos = Mathf.Cos(radians);
		float sin = Mathf.Sin(radians);
		Vec2 v = new Vec2(x - Point.x, y - Point.y);
		Vec2 z = new Vec2(cos * v.x - sin * v.y, sin * v.x + cos * v.y);
		SetXY(z.x + Point.x, z.y + Point.y);
	}

	public float Dot(Vec2 other)
	{
		return (x * other.x) + (y * other.y);
	}

	public Vec2 Normal()
	{
		return new Vec2(-y, x).Normalized();
	}

	public void Reflect(Vec2 normal, float bounciness )
	{
		float C = bounciness;
		Vec2 IN = new Vec2(x, y);
		Vec2 OUT = IN - (1 + C) * IN.Dot(normal) * normal;
		x = OUT.x;
		y = OUT.y;
	}

	public static Vec2 operator +(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x + right.x, left.y + right.y);
	}

	public static Vec2 operator -(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x - right.x, left.y - right.y);
	}

	public static Vec2 operator *(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x * right.x, left.y * right.y);
	}

	public static Vec2 operator /(Vec2 left, Vec2 right)
	{
		return new Vec2(left.x / right.x, left.y / right.y);
	}


	public static Vec2 operator +(Vec2 A, float B)
	{
		return new Vec2(A.x + B, A.y + B);
	}

	public static Vec2 operator -(Vec2 A, float B)
	{
		return new Vec2(A.x - B, A.y - B);
	}

	public static Vec2 operator *(Vec2 A, float B)
	{
		return new Vec2(A.x * B, A.y * B);
	}

	public static Vec2 operator /(Vec2 A, float B)
	{
		return new Vec2(A.x / B, A.y / B);
	}


	public static Vec2 operator +(float B, Vec2 A)
	{
		return new Vec2(B + A.x, B + A.y);
	}

	public static Vec2 operator -(float B, Vec2 A)
	{
		return new Vec2(B - A.x, B - A.y);
	}

	public static Vec2 operator *(float B, Vec2 A)
	{
		return new Vec2(B * A.x, B * A.y);
	}

	public static Vec2 operator /(float B, Vec2 A)
	{
		return new Vec2(B / A.x, B / A.y);
	}


	public override string ToString()
	{
		return String.Format("({0},{1})", x, y);
	}

}
