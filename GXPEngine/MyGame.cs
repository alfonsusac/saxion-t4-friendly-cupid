using System;									
using System.Drawing;
using System.Collections.Generic;
using GXPEngine;

using static GXPEngine.SceneManager;

public class MyGame : Game
{
    public Level currentLevel;

    EasyDraw box;
    EasyDraw screeninfo;
    SceneManager sm;


    public MyGame() : base(540, 1080, false)     // Create a window that's 800x700 and NOT fullscreen
    {
        sm = new SceneManager();
        AddChild(sm);
        sm.LoadMainMenu();

        //box = new EasyDraw(1000, 1000);
        //box.Fill(100);

        //AddChild(box);

        //screeninfo = new EasyDraw(1000, 1000);
        //screeninfo.Fill(200);
        //screeninfo.TextAlign(CenterMode.Min, CenterMode.Min);
        //AddChild(screeninfo);

        //targetFps = 60; 

        //AddChild(new Sprite("Heaven1.jpg"));
        //level = new Level(); 
        //AddChild(level);

        pointer = new EasyDraw(new Bitmap(width, height));
        pointer.Fill(Color.White, 40);
        pointer.Stroke(Color.White, 0);
        AddChild(pointer);

        ShowMouse(false);
    }

    EasyDraw pointer;

    void HandleMouse()
    {
        pointer.Clear(Color.Transparent);
        pointer.Ellipse(Input.mouseX, Input.mouseY, 60, 60);

        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            pointer.Fill(Color.White, 20);
        }
        else
        {
            pointer.Fill(Color.White, 40);
        }
    }


    void Update()
    {
        HandleMouse();
        //box.Clear(Color.Transparent);
        //screeninfo.Clear(Color.Transparent);
        
        
        //box.Rect(0, 0, 100, 250);
        //screeninfo.Text("Window Size: " + width + " x " + height, 100, 100);
        //if(Input.GetKey(Key.R) || Ball.position.y > 720) 
        //{
        //    level.Remove();
        //    level = new Level();
        //    AddChild(level);   
        //}


        //level.MovingLine(); //wkładamy do Update, ponieważ chcemy żeby to na bieżąco się odświeżało
    }

    static void Main()                          
    {
        new MyGame().Start();
        //new MyGame().Start();
    }


}