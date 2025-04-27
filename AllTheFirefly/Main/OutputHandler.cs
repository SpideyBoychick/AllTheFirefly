namespace AllTheFirefly.Main
{
    //output handler
    static class Oh
    {
        public static void pr(string text)
        {
            Console.WriteLine(text);
        }

        public static void pr(string text, bool flag)
        {
            if (flag)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }
        }

        public static void prc(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void prc(string text, ConsoleColor color, bool flag)
        {
            Console.ForegroundColor = color;
            pr(text, flag);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void nl()
        {
            Console.WriteLine();
        }
    }
}
