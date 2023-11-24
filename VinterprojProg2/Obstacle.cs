
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Numerics;
namespace VinterprojProg2;
using Raylib_cs;


public class Obstacle
{
    Variables v = new Variables();
    public int obstacleX = Raylib.GetScreenWidth();
    public static int maxObstacles = 4;
    public bool nextObstacle;
    public int obstacleSpace;
    public int speed = 10;
    public Random generator = new Random();
    public int heightGenHigh;
    public int heightGenLow;
    
    public Texture2D ObsTex = Raylib.LoadTexture("brick wall.png");
    
    public Rectangle getRectSrc()
    {
        return new Rectangle(0, 0, 16, 200);
    }
    public Vector2 obsVec()
    {
        return new Vector2(0, 0);
    }
    public Rectangle getPipeL()
    {
        return new Rectangle(obstacleX, heightGenLow, 64, 800);
    }
    public Rectangle getPipeH()
    {
        return new Rectangle(obstacleX, heightGenHigh, 64, 800);
    }
    public Obstacle()
    {
        heightGenHigh = generator.Next(-800, Raylib.GetScreenHeight() - 1200);
        heightGenLow = heightGenHigh + 1120;
    }
    public void DrawObstacle()
    {   
        Raylib.DrawTexturePro(ObsTex, getRectSrc(), getPipeH(), obsVec(), 0, Color.WHITE);
        Raylib.DrawTexturePro(ObsTex, getRectSrc(), getPipeL(), obsVec(), 0, Color.WHITE);
        Console.WriteLine(obstacleX);
    }
    public void MoveObstacle()
    {
        obstacleX = obstacleX - speed;
    }
    public bool Space()
    {
        return ObstacleSpace() > Raylib.GetScreenWidth() / Obstacle.maxObstacles;
    }
    
    public int ObstacleSpace()
    {
        obstacleSpace += speed;
        return obstacleSpace;
    }
}
