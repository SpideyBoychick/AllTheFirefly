using System.Runtime.InteropServices;

namespace AllTheFirefly
{
    static class KirillClicker
    {
        private static bool inGame = true;
        private static bool canClick = true;
        private static int kirillPower = 0;

        private static Purchase swordPurchase = new Purchase(50, 2.71828, 1, 1, "Спасибо за покупку, добрый молодецъ! Приходи в мой магазин ещё!");
        private static Purchase secPurchase = new Purchase(50, 2.71828, 0, 1, "Спасибо за покупку, добрый молодецъ! Приходи в мой магазин ещё!");
        private static Purchase shopPurchase = new Purchase(10000, 1000, 0, 1, "Ох выручил ты дедушку Вячеслава, спасибо тебе огромное! Теперь, ты очень крутой Кирилл");

        private static Case PythonCase = new Case(1, 500, 100);
        private static Case CppCase = new Case(5, 2000, 500);
        private static Case RustCase = new Case(15, 10000, 2000);
        private static Case JavaCase = new Case(30, 20000, 5000);
        private static Case CsCase = new Case(50, 100000, 10000);

        public static void Start()
        {
            inGame = true;
            Oh.nl();
            Oh.prc("#################################", ConsoleColor.Green);
            Oh.prc("#Kirill clicker THE CASES UPDATE#", ConsoleColor.Green);
            Oh.prc("#################################", ConsoleColor.Green);
            Oh.pr("Добро пожаловать в КЛИКЕР СИЛЫ КИРИЛЛА");
            Oh.pr("Нажимайте на пробел, чтобы усилить КИРИЛЛОВУ МОЩЬ");
            Oh.pr("Для вывода всех команд нажмите h, для выхода из игры - e");
            char command = ' ';
            getMoneyPerSecond();
            while (inGame)
            {
                Oh.prc("\rВаша мощь: " + kirillPower + " >>> ", ConsoleColor.Yellow, false);
                command = Console.ReadKey().KeyChar;
                switch (command)
                {
                    case ' ':
                        kirillPower += swordPurchase.Purch;
                        break;
                    case 'h':
                        printHelp();
                        break;
                    case 'u':
                        canClick = false;
                        printUpgrades();
                        canClick = true;
                        break;
                    case 'c':
                        canClick = false;
                        printCases();
                        canClick = true;
                        break;
                    case 's':
                        printStat();
                        break;
                    case 'e':
                        inGame = false;
                        break;
                }
            }
        }

        private static async Task getMoneyPerSecond()
        {
            while (inGame)
            {
                if (canClick)
                {
                    Oh.prc("\rВаша мощь: " + kirillPower + " >>> ", ConsoleColor.Yellow, false);
                }
                kirillPower += secPurchase.Purch;
                await Task.Delay(1000);
            }
        }

        private static void printHelp()
        {
            Oh.nl();
            Oh.prc("Пробел - увеличить Кириллову мощь.", ConsoleColor.Gray);
            Oh.prc("h - открыть помощь (ты и так уже тут).", ConsoleColor.DarkGray);
            Oh.prc("u - открыть магазин улучшений Вячеслава.", ConsoleColor.Gray);
            Oh.prc("c - крутить кейсы в казино Артёма.", ConsoleColor.DarkGray);
            Oh.prc("s - открыть статистику.", ConsoleColor.Gray);
            Oh.prc("e - выйти из игры:(", ConsoleColor.DarkGray);
        }

        private static void printUpgrades()
        {
            Oh.nl();
            Oh.prc("Вячеслав: добро пожаловать в мой магазин, добрый Кирилл!", ConsoleColor.Gray);
            Oh.prc("Что ты хочешь купить?", ConsoleColor.DarkGray);
            Oh.prc("1: мечъ дабы со злого люда больше мощи получать : " + swordPurchase.Cost + " мощи надобно.", ConsoleColor.Gray);
            Oh.prc("2: часики волшебные, дабы мощъ пассивно получать. Но знай, не ленись добрый молодецъ! : " + secPurchase.Cost + " мощи надобно.", ConsoleColor.DarkGray);
            Oh.prc("3: в магазинчик-то у меня никто не ходит. Пожертвуй добрый молодецъ на развитие моего магазина, а я тебе отплачу. Заплати-ка мне " + shopPurchase.Cost + " мощи.", ConsoleColor.Gray);
            char command = Console.ReadKey().KeyChar;
            Oh.nl();
            switch (command)
            {
                case '1':
                    swordPurchase.Buy(ref kirillPower);
                    break;
                case '2':
                    secPurchase.Buy(ref kirillPower);
                    break;
                case '3':
                    shopPurchase.Buy(ref kirillPower);
                    break;
                default:
                    Oh.pr("Не понимаю я таких слов заморских... Ну ничего, приходи ещё!");
                    break;
            }
        }

        private static void printCases()
        {
            Oh.nl();
            Oh.prc("Добро пожаловать в магазин кейсов!", ConsoleColor.Magenta);
            Oh.prc("Какой кейс хотите открыть?", ConsoleColor.Magenta);
            Oh.prc("1: Python кейс - 500 мощи. 1% шанс пройти игру.", ConsoleColor.Gray);
            Oh.prc("2: C++ кейс - 2000 мощи. 5% шанс пройти игру.", ConsoleColor.DarkGray);
            Oh.prc("3: Rust кейс - 10000 мощи. 15% шанс пройти игру.", ConsoleColor.Gray);
            Oh.prc("4: Java кейс - 20000 мощи. 30% шанс пройти игру.", ConsoleColor.DarkGray);
            Oh.prc("5: C# кейс - 100000 мощи. 50% шанс пройти игру.", ConsoleColor.Gray);

            char command = Console.ReadKey().KeyChar;
            Oh.nl();
            switch (command)
            {
                case '1':
                    PythonCase.Open(ref kirillPower);
                    break;
                case '2':
                    CppCase.Open(ref kirillPower);
                    break;
                case '3':
                    RustCase.Open(ref kirillPower);
                    break;
                case '4':
                    JavaCase.Open(ref kirillPower);
                    break;
                case '5':
                    CsCase.Open(ref kirillPower);
                    break;
                default:
                    Oh.pr("Я не понял что ты сказал");
                    break;
            }
        }

        private static void printStat()
        {
            Oh.nl();
            Oh.prc("Мощи за клик: " + swordPurchase.Purch, ConsoleColor.Gray);
            Oh.prc("Мощи в секунду: " + secPurchase.Purch, ConsoleColor.DarkGray);
            Oh.prc("Уровень магазина Вячеслава: " + shopPurchase.Purch, ConsoleColor.Gray);
        }
    }

    class Case
    {
        public int Chance;
        public int Cost;
        public int LoozeCashback;
        private Random r = new Random();
        private ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.DarkRed, ConsoleColor.Green, ConsoleColor.DarkGreen, ConsoleColor.Blue, ConsoleColor.DarkBlue, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Gray, ConsoleColor.DarkGray, ConsoleColor.Cyan, ConsoleColor.DarkCyan, ConsoleColor.Magenta, ConsoleColor.DarkMagenta, ConsoleColor.Yellow, ConsoleColor.DarkYellow};

        public Case(int chance, int cost, int loozeCashbach)
        {
            Chance = chance;
            Cost = cost;
            LoozeCashback = loozeCashbach;
        }

        public void Open(ref int kirillPower)
        {
            if (kirillPower >= Cost)
            {
                kirillPower -= Cost;
                bool isWin = r.Next(0, 101) <= Chance;
                if (isWin)
                {
                    Oh.prc("Ох, вот это везение!!! Вы выйграли, и прошли игру!", ConsoleColor.Green);
                    kirillPower = 2_000_000_000;
                }
                else
                {
                    Oh.prc("Вы проиграли. Ну не расстраивайтесь, повезёт в следующий раз.", ConsoleColor.Red);
                    Oh.pr("Посмотри пока что, как танцует лама!");
                    for(int i = 0; i < colors.Length; i++)
                    {
                        Oh.prc("\rЛама", colors[i], false);
                        Thread.Sleep(750);
                    }
                    Oh.nl();
                    Oh.prc("Ну как тебе? Ладно, верну тебе некоторую часть от суммы.", ConsoleColor.DarkGray);
                    Oh.prc("Вам вернули " + LoozeCashback, ConsoleColor.Green);
                    kirillPower += LoozeCashback;
                }

            }
            else
            {
                Oh.prc("Не хватает у тебя денюжек... Приходи когда накопишь.", ConsoleColor.Red);
            }
        }
    }

    class Purchase
    {
        public int Cost;
        public double CostMult;
        public int Purch;
        public int PurchIncrement;
        public string Text;

        public Purchase(int cost, double costMult, int purch, int purchIncrement, string text1)
        {
            Cost = cost;
            CostMult = costMult;
            Purch = purch;
            PurchIncrement = purchIncrement;
            Text = text1;
        }

        public void Buy(ref int kirillPower)
        {
            if (kirillPower >= Cost)
            {
                kirillPower -= Cost;
                Purch += PurchIncrement;
                Cost = (int)((double)Cost * CostMult);
                Oh.pr(Text);
            }
            else
            {
                Oh.prc("Не хватает у тебя денюжек... Приходи когда накопишь.", ConsoleColor.Red);
            }
        }
    }
}