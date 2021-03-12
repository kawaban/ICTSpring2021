using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Example1
{
    class Game
    {

        Timer wormTimer = new Timer(100);
        Timer gameTimer = new Timer(1000);

        public static int Width { get { return 40; } }
        public static int Height { get { return 40; } }

        Worm w = new Worm('@', ConsoleColor.DarkGreen);
        Food f = new Food('%', ConsoleColor.Red);
        Wall wall = new Wall('#', ConsoleColor.DarkGray, @"Levels/Level3.txt");

        public bool IsRunning { get; set; }

        bool pause = false;
        public Game()
        {
            gameTimer.Elapsed += GameTimer_Elapsed;
            gameTimer.Start();
            wormTimer.Elapsed += Move2;
            wormTimer.Start();

            pause = false;
            IsRunning = true;
            Console.CursorVisible = false;
            Console.SetWindowSize(Width, Width);
            Console.SetBufferSize(Width, Width);
        }

        private void GameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.Title = DateTime.Now.ToLongTimeString();
        }
        bool CheckCollisionFoodWithWorm()

        {
            w.GetPointsForFood();
            return w.body[0].X == f.body[0].X && w.body[0].Y == f.body[0].Y;
        }

        bool CheckCollisionWormWithWalls()
        {
            return w.body[0].X == wall.body[0].X && w.body[0].Y == wall.body[0].Y;
        }
            

        void Move2(object sender, ElapsedEventArgs e)
        {
            w.Move();
            if (CheckCollisionFoodWithWorm())
            {
                w.Increase(w.body[0]);
                f.Generate();
            }
        }

        void PointsForFood()
        {
            if (CheckCollisionFoodWithWorm())
            {
                w.GetPointsForFood();
            }
        }
        public void KeyPressed(ConsoleKeyInfo pressedKey)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    w.ChangeDirection(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    w.ChangeDirection(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    w.ChangeDirection(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    w.ChangeDirection(1, 0);
                    break;
                case ConsoleKey.Escape:
                    IsRunning = false;
                    break;
                case ConsoleKey.Spacebar:
                    if (!pause)
                    {
                        gameTimer.Stop();
                        wormTimer.Stop();
                        pause = true;
                    }
                    else
                    {
                        gameTimer.Start();
                        wormTimer.Start();
                        pause = false;
                    }
                    break;
            
          
            }
        }

    }
}
