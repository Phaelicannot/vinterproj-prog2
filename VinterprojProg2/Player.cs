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
    private int birdRot = 0;

    public Texture2D birdTex = Raylib.LoadTexture("bee.png");
    
    public Vector2 birdVec()
    {
        return new Vector2(0, 0);
    }
    public Rectangle getRectSrc()
    {
        return new Rectangle(0, 0, 16, 16);
    }
    public Rectangle getRectDest()
    {
        return new Rectangle(100, charPosY, 64, 64);
    }

    public void DrawCharacter()
    {
        Raylib.DrawTexturePro(birdTex, getRectSrc(), getRectDest(), birdVec(), birdRot, Color.WHITE);
    }
    public void Flap()
    {
        if(dead == false)
        {
            if(Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                speed = 30;
                birdRot = -20;
            }
        }
        if(charPosY < Raylib.GetScreenHeight() - 64)
        {
            if(speed >= -25)
            {
                speed = speed - gravity;
                charPosY = charPosY - speed;
                birdRot = birdRot + gravity/2;
            }
            else if(speed <= -25)
            {
                charPosY = charPosY - speed;
                birdRot = birdRot + gravity;
            }
        }
        
    }
    public void IsDead()
    {
        if(dead == true)
        { 
            Raylib.DrawText("You died", 200, v.windowHeight/2, 30, Color.BLACK);
            Raylib.DrawText("Press enter to retry", 200, v.windowHeight/2 + 50, 30, Color.BLACK);
        }
    }

    
    
}
