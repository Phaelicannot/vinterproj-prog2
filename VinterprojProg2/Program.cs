// något liknande flappy bird

using Raylib_cs;
using System.IO.Pipes;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using VinterprojProg2;

Raylib.InitWindow(1920, 1080, "Flappy Bird");
Raylib.SetTargetFPS(30);

Player bird = new Player();
Variables v = new Variables();
Obstacle pipe = new Obstacle();
List<Obstacle> obstacles = new();

while(Raylib.WindowShouldClose() == false)
{

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.SKYBLUE);

    bird.Flap();
    bird.DrawCharacter();
    bird.IsDead(); 

    if(bird.dead == false)
    {
        if (obstacles.Count() <= Obstacle.maxObstacles)
        {   
            if (obstacles.Count() < 1 || obstacles[obstacles.Count()-1].Space())
            {
                obstacles.Add(new Obstacle());
                if (obstacles[obstacles.Count()-1].Space())
                {
                    pipe.obstacleSpace = 0;
                }
            }
        
        }
    }

    
    foreach(Obstacle i in obstacles)
    {
        Console.WriteLine(i.obstacleX);
        i.DrawObstacle();
        if(bird.dead == false)
        {
            i.MoveObstacle();
        }
    }


    if (obstacles.Count() > Obstacle.maxObstacles)
    {   
        obstacles.RemoveAt(0);
    }

    bool isColliding()
    {
        Raylib.CheckCollisionRecs(bird.getRectDest(), obstacles[0].getPipeH());
        Raylib.CheckCollisionRecs(bird.getRectDest(), obstacles[0].getPipeL());
        if (Raylib.CheckCollisionRecs(bird.getRectDest(), obstacles[0].getPipeH()) || Raylib.CheckCollisionRecs(bird.getRectDest(), obstacles[0].getPipeL()))
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

    bool Restart()
    {
        if(v.restartTrigger == 1)
        {
            return (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER));
        }
        if(v.restartTrigger == 2)
        {
            return true;
        }
        return false;
       
    }

    if(obstacles[0].obstacleX == 100 && !isColliding())
    {
        v.score += 1;
    }

    Raylib.DrawText(v.score.ToString(), v.windowWidth -100, 50, 30, Color.BLACK);
    if(isColliding())
    {
        bird.dead = true;
        v.restartTrigger = 1;
    }

    if(Restart())
    {
        bird.dead = false;
        bird.charPosY = v.windowHeight/2;
        obstacles.Clear();
        pipe.obstacleSpace = 0;
        v.score = 0;
        v.restartTrigger = 2;
        if(Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            v.restartTrigger = 0;
        }
    }
    
    // Raylib.DrawRectangle((int)obstacles[0].getPipeH().X, (int)obstacles[0].getPipeH().Y, (int)obstacles[0].getPipeH().Width, (int)obstacles[0].getPipeH().Height, Color.WHITE);
    // Raylib.DrawRectangle((int)obstacles[0].getPipeL().X, (int)obstacles[0].getPipeL().Y, (int)obstacles[0].getPipeL().Width, (int)obstacles[0].getPipeL().Height, Color.WHITE);
    // Console.WriteLine(pipe.getPipeH());
    // Raylib.DrawRectangle((int)bird.getRect().X, (int)bird.getRect().Y, (int)bird.getRect().Width, (int)bird.getRect().Height, Color.WHITE);
    
    Raylib.EndDrawing();
    
}


