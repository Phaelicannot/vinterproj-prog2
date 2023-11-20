
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
        heightGenLow = heightGenHigh + 1200;
    }
    public void DrawObstacle()
    {   
        Raylib.DrawRectangleRec(getPipeH(), Color.GREEN);
        Raylib.DrawRectangleRec(getPipeL(), Color.GREEN);
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
