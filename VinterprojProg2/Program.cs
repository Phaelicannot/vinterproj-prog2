// något liknande flappy bird

using Raylib_cs;
using System.ComponentModel;
using System.Data;
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
List<int> scores = new();
bool playing = false;

while(Raylib.WindowShouldClose() == false)
{

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.SKYBLUE);

    scores.Add(0);
    int max = scores.Max();

    if(playing == false)
    {
        Raylib.DrawText("Press space to start", v.windowWidth/2, v.windowHeight/2, 32, Color.BLACK);
        Raylib.DrawText($"Highscore: {max.ToString()}", v.windowWidth/2, v.windowHeight/2 + 64, 32, Color.BLACK);
        bird.dead = false;
        bird.charPosY = v.windowHeight/2;
        obstacles.Clear();
        pipe.obstacleSpace = 0;
        bird.birdRot = 0;
    }

    bird.Flap();
    bird.DrawCharacter();


    if(Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
    {
        playing = true;
    }

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
        Rectangle dest = bird.getRectDest();
        dest.X -= 32;
        dest.Y -= 32;
        if (Raylib.CheckCollisionRecs(dest, obstacles[0].getPipeH()) || Raylib.CheckCollisionRecs(dest, obstacles[0].getPipeL()))
        {
            return true;
        }
        else if (bird.charPosY > Raylib.GetScreenHeight() - 64 || bird.charPosY < 0)
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

    if(obstacles[0].obstacleX == bird.charPosX && !isColliding())
    {
        v.score += 1;
    }

    Raylib.DrawText(v.score.ToString(), v.windowWidth -100, 50, 30, Color.BLACK);

    if(isColliding())
    {
        bird.dead = true;
        v.restartTrigger = 1;
        scores.Add(v.score);
    }

    if(Restart())
    {
        bird.dead = false;
        bird.charPosY = v.windowHeight/2;
        obstacles.Clear();
        pipe.obstacleSpace = 0;
        v.score = 0;
        v.restartTrigger = 2;
        playing = false;
        if(Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            v.restartTrigger = 0;
            playing = true;
        }
    }

    bird.IsDead(); 
    
    // Raylib.DrawRectangle((int)obstacles[0].getPipeH().X, (int)obstacles[0].getPipeH().Y, (int)obstacles[0].getPipeH().Width, (int)obstacles[0].getPipeH().Height, Color.WHITE);
    // Raylib.DrawRectangle((int)obstacles[0].getPipeL().X, (int)obstacles[0].getPipeL().Y, (int)obstacles[0].getPipeL().Width, (int)obstacles[0].getPipeL().Height, Color.WHITE);
    // Console.WriteLine(pipe.getPipeH());
    // Raylib.DrawRectangle((int)bird.getRect().X, (int)bird.getRect().Y, (int)bird.getRect().Width, (int)bird.getRect().Height, Color.WHITE);
    
    Raylib.EndDrawing();
    
}


