using System;									
using System.Drawing;                           
using GXPEngine;								

public class MyGame : Game
{
    public Level level;

    public MyGame() : base(800, 700, false)     // Create a window that's 800x700 and NOT fullscreen
    {
        targetFps = 60; 
        //DoTests();
   
        AddChild(new Sprite("Heaven1.jpg"));
        level = new Level(); 
        AddChild(level);
     


    }

    void Update()
    {
        if(Input.GetKey(Key.R) || Ball.position.y > 720) 
        {
            level.Remove();
            level = new Level();
            AddChild(level);   
        }


        level.MovingLine(); //wkładamy do Update, ponieważ chcemy żeby to na bieżąco się odświeżało
        
    }

    static void Main()                          
    {
        new MyGame().Start();                   
    }





















    static void DoTests()
    {
        Vec2 v = new Vec2(4, 6);
        Vec2 v1 = new Vec2(4, 6);
        Vec2 v2 = new Vec2(4, 6);
        Vec2 v3 = new Vec2(4, 6);
        Vec2 v4 = new Vec2(4, 6);
        Vec2 v5 = new Vec2(4, 6);
        Vec2 v6 = new Vec2(4, 6);
        Vec2 v7 = new Vec2(4, 6);
        Vec2 v8 = new Vec2(4, 6);

        Vec2 x = new Vec2(2, 1);
        Vec2 x1 = new Vec2(2, 1);
        Vec2 x2 = new Vec2(2, 1);


        Console.WriteLine("Length={0} (should be 7.211)", v.Length());
        Console.WriteLine("Normalize={0} (should be 0.6 and 0.8", x.Normalized());
        x.Normalize();

        Console.WriteLine("Normalize={0} (should be 0.6 and 0.8)", x);
        Vec2 result = v * 3;
        Console.WriteLine("Scalar multiplication right ok ?: " +
        (result.x == -12 && result.y == 18));
        Console.ReadLine();

        Console.WriteLine("Deg2Rad ok? This should be 0.20944: {0}", Vec2.Deg2Rad(12));
        Console.WriteLine("Rad2Deg ok? This should be 687.549: {0}", Vec2.Rad2Deg(12));

        Console.WriteLine("GetUnitVecDeg ok? This should (0,1) : {0}", Vec2.GetUnitVectorDeg(90));
        Console.WriteLine("GetUnitVecRad ok? This should be (-1,0): {0}", Vec2.GetUnitVectorRad(Mathf.PI));

        Console.WriteLine("RandomUnitVector ok? This should be random: {0}", Vec2.RandomUnitVector());

        Console.WriteLine("GetAngleeDegrees ok? This should be 56.3: {0}", v.GetAngleDegrees());
        Console.WriteLine("GetAngleeRadians ok? This should be 0.9827: {0}", v.GetAngleRadians());

        v.SetAngleRadians(90);
        Console.WriteLine("SetAngleRadians ok? This should be (-3.231105,6.446702): {0}", v);

        v1.SetAngleDegrees(90);
        Console.WriteLine("SetAngleDegrees ok? This should be (-3.152073E-07,7.211102): {0}", v1);

        v2.RotateRadians(90);
        Console.WriteLine("RotateRadians ok? This should be (-7.156274,0.8875449): {0}", v2);

        v3.RotateDegrees(90);
        Console.WriteLine("RotateDegrees ok? This should be (-6,4): {0}", v3);

        v4.RotateAroundRadians(x, 90);
        Console.WriteLine("RotateAroundRadians ok? This should be (-3.36613,0.5476252): {0}", v4);

        v5.RotateAroundDegrees(x, 90);
        Console.WriteLine("RotateAroundDegrees ok? This should be (-3,3): {0}", v5);

        Console.WriteLine("Dot ok? This should be (14): {0}", v6.Dot(x1));

        Console.WriteLine("Normal ok? This should be (-0.8320503,0.5547002): {0}", v7.Normal());

        v7.Reflect(x, 1);
        Console.WriteLine("Reflect ok? This should be (-7.2,0.4000001) : {0}", v7);

        Console.ReadLine();
    }
}