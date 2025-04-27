using AllTheFirefly.Programs;

namespace AllTheFirefly.Main
{
    static class Menu
    {
        private static Dictionary<string, Ceil> ceils = new Dictionary<string, Ceil>()
            {
                {"0_0", new Ceil(0, 0, "Кликер мощи КИРИЛЛА", ConsoleColor.Gray, new KirillClicker())},
                {"1_0", new Ceil(1, 0, "Симулятор Вячеслава", ConsoleColor.DarkGray, new KirillClicker())},
                {"0_1", new Ceil(0, 1, "mp3/wav плеер", ConsoleColor.DarkGray, new MP3player())},
                {"1_1", new Ceil(1, 1, "Артём ди пидиди", ConsoleColor.Gray, new KirillClicker())}
            };

        private static char command = '0';
        private static int currentX = 0;
        private static int currentY = 0;
        private static int maxX = 1;
        private static int maxY = 1;
        private static string currentCeilKey = "0_0";

        public static void Draw()
        {
            Console.SetCursorPosition(0, 1);
            Oh.prc("wasd для перемещения между программами, пробел чтобы открыть, kl для изменения скорости новостей", ConsoleColor.Green, false);

            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    if (y == currentY && x == currentX)
                    {
                        currentCeilKey = x + "_" + y;
                        ceils[currentCeilKey].isCurrent = true;
                        FMain.currentProgram = ceils[currentCeilKey].program;
                    }
                    ceils[x + "_" + y].Draw();
                }
            }

            if (Console.KeyAvailable)
            {
                command = Console.ReadKey().KeyChar;
            }
            else
            {
                command = '0';
            }

            int dx = 0;
            int dy = 0;
            switch (command)
            {
                case ' ':
                    Console.Clear();
                    FMain.inMenu = false;
                    break;
                case 'w':
                    dy = -1;
                    break;
                case 's':
                    dy = 1;
                    break;
                case 'a':
                    dx = -1;
                    break;
                case 'd':
                    dx = 1;
                    break;
                case 'k':
                    if (New.Speed - 0.1 >= 0)
                    {
                        New.Speed -= 0.1;
                    }
                    else
                    {
                        New.Speed = 0;
                    }
                    break;
                case 'l':
                    New.Speed += 0.1;
                    break;
            }

            if ("wsad".Contains(command))
            {
                ceils[currentCeilKey].isCurrent = false;
                currentX += dx;
                currentY += dy;
                if (currentX < 0)
                    currentX = maxX;
                if (currentX > maxX)
                    currentX = 0;
                if (currentY < 0)
                    currentY = maxY;
                if (currentY > maxY)
                    currentY = 0;
            }
        }
    }
}
