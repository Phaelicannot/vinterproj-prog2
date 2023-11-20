// något liknande flappy bird

using Raylib_cs;
using System.IO.Pipes;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using VinterprojProg2;

Raylib.InitWindow(1920, 1080, "Flappy Bird");
Raylib.SetTargetFPS(30);

Player bird = new Player();
Variables v = new Variables();
List<Obstacle> obstacles = new();

while(Raylib.WindowShouldClose() == false)
{

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.SKYBLUE);
    Console.WriteLine(obstacles);

    bird.Flap();
    bird.DrawCharacter();
    bird.IsDead(); 

    if (obstacles.Count <= Obstacle.maxObstacles)
    {   
        if (obstacles.Count < 1 ||  > Raylib.GetScreenWidth() / Obstacle.maxObstacles)
        {
            obstacles.Add(new Obstacle());
            if ( > Raylib.GetScreenWidth() / Obstacle.maxObstacles)
            {
                pipe.obstacleSpace = 0;
            }
        }
       
    }

    foreach(Obstacle i in obstacles)
    {
        Console.WriteLine(i.obstacleX);
        i.DrawObstacle();
        i.MoveObstacle();
    }

    if (obstacles.Count > pipe.maxObstacles)
    {
        obstacles.RemoveAt(0);
    }

    bool isColliding()
    {
        foreach(Obstacle n in obstacles)
        {
            Raylib.CheckCollisionRecs(bird.getRect(), pipe.getPipeH());
            Raylib.CheckCollisionRecs(bird.getRect(), pipe.getPipeL());
            if (Raylib.CheckCollisionRecs(bird.getRect(), pipe.getPipeH()) || Raylib.CheckCollisionRecs(bird.getRect(), pipe.getPipeL()))
            {
                return true;
            }
            else if (bird.charPosY > Raylib.GetScreenHeight() - 64)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }


    if(isColliding())
    {
        bird.dead = true;
    }
    
    Raylib.DrawRectangle((int)obstacles[0].getPipeH().X, (int)obstacles[0].getPipeH().Y, (int)obstacles[0].getPipeH().Width, (int)obstacles[0].getPipeH().Height, Color.WHITE);
    Console.WriteLine(pipe.getPipeH());
    Raylib.DrawRectangle((int)bird.getRect().X, (int)bird.getRect().Y, (int)bird.getRect().Width, (int)bird.getRect().Height, Color.WHITE);
    
    Raylib.EndDrawing();
    
}


