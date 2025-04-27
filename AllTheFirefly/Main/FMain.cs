using System;
using System.Diagnostics;
using AllTheFirefly.Programs;

namespace AllTheFirefly.Main
{
    static class FMain
    {
        public static bool inMenu = true;
        public static IProgram currentProgram;
        public static int FPS = 60;

        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            double drawInterval = 1_000_000_000 / FPS;
            double delta = 0;
            long lastTime = nanoTime();
            long currentTime = 0;
            
            while (true)
            {
                currentTime = nanoTime();
                delta += (currentTime - lastTime) / drawInterval;
                lastTime = currentTime;
            
                if (delta >= 1)
                {
                    delta--;
                    NewsHandler.Draw();
            
                    if (inMenu)
                    {
                        Menu.Draw();
                    }
                    else
                    {
                        currentProgram.Draw();
                    }
                }
            }
        }

        private static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
    }
}