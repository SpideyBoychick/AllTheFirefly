using Xamarin.Essentials;

namespace AllTheFirefly.Main
{
    static class IH
    {
        public static ConsoleKeyInfo cki;
        public static string inputStr = "";
        
        public static void Update()
        {
            if (Console.KeyAvailable)
            {
                cki = Console.ReadKey(true);
                if (Match(ConsoleKey.Enter))
                {
                    return;
                }
                else if (Match(ConsoleKey.Backspace))
                {
                    if (inputStr.Length > 0)
                    {
                        inputStr = inputStr.Substring(0, inputStr.Length - 1);
                    }
                }
                else
                {
                    inputStr += cki.KeyChar;
                }
            }
            else
            {
                cki = new ConsoleKeyInfo('\0', ConsoleKey.Delete, false, false, false);
            }
        }

        public static bool Match(ConsoleKey ck)
        {
            return cki.Key.Equals(ck);
        }
    }
}
