using System.Text;
using AllTheFirefly.Programs;

namespace AllTheFirefly.Main
{
    class Ceil
    {
        private int x;
        private int y;
        private const int width = 30;
        private string text;
        private ConsoleColor color;
        public bool isCurrent;
        public IProgram program;

        public Ceil(int x, int y, string text, ConsoleColor color, IProgram program)
        {
            this.x = x;
            this.y = y;
            this.text = text;
            this.color = color;
            isCurrent = false;
            this.program = program;
        }

        public void Draw()
        {

            ConsoleColor c = color;
            if (isCurrent)
            {
                c = ConsoleColor.DarkYellow;
            }

            StringBuilder line = new StringBuilder();
            StringBuilder line2 = new StringBuilder();
            for (int i = 0; i < width; i++)
            {
                line.Append("#");
            }
            for (int i = 0; i < (width - 2 - text.Length) / 2; i++)
            {
                line2.Append(" ");
            }
            Console.SetCursorPosition(x * width, y * 3 + 2);
            Oh.prc(line.ToString(), c);
            Console.SetCursorPosition(x * width, y * 3 + 3);
            if (2 * line2.Length + 2 != width)
            {
                Oh.prc("#" + line2 + text + line2 + " #", c);
            }
            else
            {
                Oh.prc("#" + line2 + text + line2 + "#", c);
            }

            Console.SetCursorPosition(x * width, y * 3 + 4);
            Oh.prc(line.ToString(), c);
        }
    }
}
