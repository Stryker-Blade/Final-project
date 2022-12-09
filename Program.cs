using Raylib_cs;
using System.Numerics;

namespace Helloworld{
static class Program{
        public static void Main()
        {

            var ScreenHeight = 480;
            var ScreenWidth = 800;
            var Objects = new List<FallingObject>();
            var projectilelist = new List<Projectile>();
            var Random = new Random();
            var player = new Player();
            var score = new Score();
            int lives = 15;
            var playerPosition = player.PlayerPosition;
            var projectilecollision = new Projectile(2);

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Greed");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                // Add a new random object to the screen every iteration of our game loop
                var whichType = Random.Next(100);

                // Generate a random velocity for this object
                var randomY = Random.Next(1, 4);
                var Rocketspeed = Random.Next(6, 9);
                var randomX = Random.Next(1, 4);
                
                //Generating a random x coordinate for each object
                var xposition = Random.Next(20,780);
                
                // I am generating the positions of the falling objects here
                var position = new Vector2(xposition, 0);
                var position2 = new Vector2(xposition,480);
            
                switch (whichType) {
                            case 0:
                            //Tempararoly using squares for gem, need to switch to actual drawing
                                var gem = new Gem(20);
                                gem.Position = position2;
                                gem.Velocity = new Vector2(0, -Rocketspeed);
                                Objects.Add(gem);
                                break;
                        case 1:
                        //Tempararoly using circles for rock, need to switch to actual drawing
                            var rock = new Rock(15);
                            rock.Position = position;
                            rock.Velocity = new Vector2(0, randomY);
                            Objects.Add(rock);
                            break;
                        case 2:
                            rock = new Rock(15);
                            rock.Position = position;
                            rock.Velocity = new Vector2(0, randomY);
                            Objects.Add(rock);
                            break;
                        case 3:
                            rock = new Rock(15);
                            rock.Position = position;
                            rock.Velocity = new Vector2(0, randomY);
                            Objects.Add(rock);
                            break;
                        case 4:
                            rock = new Rock(15);
                            rock.Position = position;
                            rock.Velocity = new Vector2(0, randomY);
                            Objects.Add(rock);
                            break;
                        case 5:
                            rock = new Rock(15);
                            rock.Position = position;
                            rock.Velocity = new Vector2(0, randomY);
                            Objects.Add(rock);
                            break;
                        default:
                            break;
                        
                        }
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.BLACK);
                    // This draws all of the objects in their current location, updating every single runthrough of the program
                   
                   if(Raylib.IsKeyDown(KeyboardKey.KEY_UP)){
                        var projectile = new Projectile(5);
                        projectile.Position = new Vector2(player.PlayerPosition.x+10, player.PlayerPosition.y-30);
                        projectile.Velocity = new Vector2(0,-15);
                        projectilelist.Add(projectile);
                        
                   }



                    foreach (var obj in Objects) {
                        obj.Draw();
                    }
                    foreach (var projectile in projectilelist) {
                        projectile.Draw();
                        projectile.Move();
                    }

                    player.movement();
                
                    // place to add in the projectile loop
                    score.scorekeeping();
                    // Move all of the objects to their next location
                    Raylib.DrawText($"You have {lives} lives left remaining", 430,20,20,Color.WHITE);
                    foreach (var obj in Objects.ToList()) {
                        obj.Move();
                        foreach(var projectile in projectilelist.ToList()){
                            if(obj.CheckCollision(projectile.CollisonProjectile())){
                            var newscore = score.pointtotal +  obj.pointvalue;
                            score.pointtotal = newscore;
                            Objects.Remove(obj);
                            projectilelist.Remove(projectile);
                            }
                        }
                        if (obj.Position.Y > 490){
                            Objects.Remove(obj);
                            lives = lives - 1;
                            if (lives.Equals(0)){  
                                Raylib.CloseWindow();
                            }
                        if(obj.Position.Y < 0){
                            Objects.Remove(obj);
                        }
                        
                        
                        }
                    }
                Raylib.EndDrawing();
            }
        
            


        }
        
}
            
}


