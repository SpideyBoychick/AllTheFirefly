namespace AllTheFirefly
{
    // V = Vyacheslav
    static class VSimulator
    {

        private static VState currentState = VState.Happy;

        private static int happy = 100;
        private static int hungry = 100;
        private static int energy = 100;

        public static void Start()
        {
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                DrawCeil(0, 0, $"Радость {happy}%", 12);
                DrawCeil(15, 0, $"Сытость {hungry}%", 12);
                DrawCeil(30, 0, $"Бодрость {energy}%", 13);
                DrawV(17, 5);

                DrawCeil(0, 11, "Что вы хотите сделать? Поиграть с вячеславом - p, Покормить его - f, Написать программу на расте - w, Выпить энергетик - g, Выйти из игры - e.", 150);
            }
        }

        private static void DrawV(int x, int y)
        {
            const string eyes1 = " / $ $ \\ ";
            const string eyes2 = " / \\ / \\ ";
            const string eyes3 = " / - - \\ ";

            const string rot1 = "|  \\-/  |";
            const string rot2 = "|  /-\\  |";

            string currentEyes = "";
            string currentRot = "";

            switch (currentState)
            {
                case VState.Happy:
                    currentEyes = eyes1;
                    currentRot = rot1;
                    break;
                case VState.Sad:
                    currentEyes = eyes1;
                    currentRot = rot2;
                    break;
                case VState.Angry:
                    currentEyes = eyes2;
                    currentRot = rot2;
                    break;
                case VState.Sleep:
                    currentEyes = eyes3;
                    currentRot = rot2;
                    break;
            }
            Console.SetCursorPosition(x, y);
            Oh.pr("  _____  ", false);
            Console.SetCursorPosition(x, y + 1);
            Oh.pr(currentEyes, false);
            Console.SetCursorPosition(x, y + 2);
            Oh.pr("|       |", false);
            Console.SetCursorPosition(x, y + 3);
            Oh.pr(currentRot, false);
            Console.SetCursorPosition(x, y + 4);
            Oh.pr("\\_______/", false);

        }

        private static void DrawCeil(int x, int y, string text, int textWidth)
        {
            string line = "";
            for(int i = 0; i < textWidth + 2; i++)
            {
                line += "#";
            }
            Console.SetCursorPosition(x, y);
            Oh.pr(line, false);

            int offset = textWidth - text.Length;
            string line2 = "#" + text;
            for (int i = 0; i < offset; i++)
            {
                line2 += " ";
            }
            line2 += "#";
            Console.SetCursorPosition(x, y + 1);
            Oh.pr(line2, false);
            
            Console.SetCursorPosition(x, y + 2);
            Oh.pr(line, false);
        }
    }

    enum VState
    {
        Happy,
        Sad,
        Angry,
        Sleep
    }
}
