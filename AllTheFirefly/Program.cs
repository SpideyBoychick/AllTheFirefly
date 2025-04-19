namespace AllTheFirefly
{
    class Program
    {
        public static void Main(string[] args)
        {

            Dictionary<string, Ceil> ceils = new Dictionary<string, Ceil>()
            {
                {"0_0", new Ceil(0, 0, "Кликер мощи КИРИЛЛА", ConsoleColor.Gray, KirillClicker.Start)},
                {"1_0", new Ceil(1, 0, "Симулятор Вячеслава", ConsoleColor.DarkGray, VSimulator.Start)},
                {"0_1", new Ceil(0, 1, "123", ConsoleColor.DarkGray, () => Oh.pr("Заходим в 123"))},
                {"1_1", new Ceil(1, 1, "Артём ди пидиди", ConsoleColor.Gray, () => Oh.pr("Заходим в Артём ди пидиди"))}
            };

            Console.CursorVisible = false;
            char command;

            int currentX = 0;
            int currentY = 0;
            int maxX = 1;
            int maxY = 1;
            string currentCeilKey = "0_0";

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Oh.prc("wasd для перемещения между программами, пробел чтобы открыть", ConsoleColor.Green, false);

                for (int y = 0; y <= maxY; y++)
                {
                    for (int x = 0; x <= maxX; x++)
                    {
                        if (y == currentY && x == currentX)
                        {
                            currentCeilKey = x + "_" + y;
                            ceils[currentCeilKey].isCurrent = true;
                        }
                        ceils[x + "_" + y].Draw();
                    }
                }

                command = Console.ReadKey().KeyChar;


                int dx = 0;
                int dy = 0;
                switch (command)
                {
                    case ' ':
                        Console.Clear();
                        ceils[currentCeilKey].OnClick();
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
                }

                if("wsad".Contains(command))
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
}