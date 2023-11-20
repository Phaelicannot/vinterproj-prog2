using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Numerics;
using Raylib_cs;
using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;

namespace VinterprojProg2;


public class Player
{
    Variables v = new Variables();
    Obstacle pipes = new Obstacle();
    public int charPosY;
    public bool dead = false;
    static public int gravity = 2;
    static public int speed = 10;
    
    public Rectangle getRect()
    {
        return new Rectangle(100, charPosY, 64, 64);
    }

    public void DrawCharacter()
    {
        Raylib.DrawRectangleRec(getRect(), Color.BROWN);
    }
    public void Flap()
    {
        if(dead == false)
        {
            if(Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                speed = 30;
            }
        }
        if(charPosY < Raylib.GetScreenHeight() - 64)
        {
            if(speed >= -25)
            {
                speed = speed - gravity;
                charPosY = charPosY - speed;
            }
            else if(speed <= -25)
            {
                charPosY = charPosY - speed;
            }
        }
        
    }
    public void IsDead()
    {
        if(dead == true)
        { 
            Raylib.DrawText("Damn L", v.windowWidth/2, v.windowHeight/2, 30, Color.BLACK);
        }
    }

    
    
}
