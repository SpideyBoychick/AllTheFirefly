using System.Runtime.InteropServices;
using AllTheFirefly.Main;

namespace AllTheFirefly.Programs
{
    enum GameState
    {
        Click,
        Help,
        Upgrade,
        Cases,
        Stat,
        LamaDance
    }

    class KirillClicker : IProgram
    {
        private int kirillPower = 0;
        private GameState currentState = GameState.Click;
        bool canExitMenu = false;

        private Purchase swordPurchase = new Purchase(50, 2.71828, 1, 1, "Спасибо за покупку, добрый молодецъ! Приходи в мой магазин ещё!");
        private Purchase secPurchase = new Purchase(50, 2.71828, 0, 5, "Спасибо за покупку, добрый молодецъ! Приходи в мой магазин ещё!");
        int secIterator = 0;
        private Purchase shopPurchase = new Purchase(10000, 1000, 0, 1, "Ох выручил ты дедушку Вячеслава, спасибо тебе огромное! Теперь, ты очень крутой Кирилл");

        private Case PythonCase = new Case(1, 500, 100);
        private Case CppCase = new Case(5, 2000, 500);
        private Case RustCase = new Case(15, 10000, 2000);
        private Case JavaCase = new Case(30, 20000, 5000);
        private Case CsCase = new Case(50, 100000, 10000);
        private int currentLoozeCashback = 0;
        private int lamaIteration = 0;
        private int colorIndex = 0;

        private ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.DarkRed, ConsoleColor.Green, ConsoleColor.DarkGreen, ConsoleColor.Blue, ConsoleColor.DarkBlue, ConsoleColor.White, ConsoleColor.Black, ConsoleColor.Gray, ConsoleColor.DarkGray, ConsoleColor.Cyan, ConsoleColor.DarkCyan, ConsoleColor.Magenta, ConsoleColor.DarkMagenta, ConsoleColor.Yellow, ConsoleColor.DarkYellow };

        private char command = '0';

        public async Task Draw()
        {
            Console.SetCursorPosition(0, 1);
            Oh.prc("#################################", ConsoleColor.Green);
            Oh.prc("#Kirill clicker THE CASES UPDATE#", ConsoleColor.Green);
            Oh.prc("#################################", ConsoleColor.Green);
            Oh.pr("Добро пожаловать в КЛИКЕР СИЛЫ КИРИЛЛА");
            Oh.pr("Нажимайте на пробел, чтобы усилить КИРИЛЛОВУ МОЩЬ");
            Oh.pr("Для вывода всех команд нажмите h, для выхода из игры - e");
            Console.SetCursorPosition(0, 7);
            Oh.prc("\rВаша мощь: " + kirillPower + " >>> ", ConsoleColor.Yellow, false);

            getMoneyPerSecond();

            switch (currentState)
            {
                case GameState.Click:
                    if (Console.KeyAvailable)
                    {
                        command = Console.ReadKey().KeyChar;
                    }
                    else
                    {
                        command = '0';
                    }
                    switch (command)
                    {
                        case ' ':
                            kirillPower += swordPurchase.Purch;
                            break;
                        case 'h':
                            Console.Clear();
                            currentState = GameState.Help;
                            break;
                        case 'u':
                            Console.Clear();
                            currentState = GameState.Upgrade;
                            break;
                        case 'c':
                            Console.Clear();
                            currentState = GameState.Cases;
                            break;
                        case 's':
                            Console.Clear();
                            currentState = GameState.Stat;
                            break;
                        case 'e':
                            FMain.inMenu = true;
                            Console.Clear();
                            break;
                    }
                    break;
                case GameState.Help:
                    printHelp();
                    break;
                case GameState.Upgrade:
                    printUpgrades();
                    break;
                case GameState.Cases:
                    printCases();
                    break;
                case GameState.Stat:
                    printStat();
                    break;
                case GameState.LamaDance:
                    printLamaDance();
                    break;
            }
        }
        private void printLamaDance()
        {
            Console.SetCursorPosition(0, 22);
            Oh.prc("Вы проиграли. Ну не расстраивайтесь, повезёт в следующий раз.", ConsoleColor.Red);
            Oh.pr("Посмотри пока что, как танцует лама!");
            if (!canExitMenu)
            {
                lamaIteration++;
                if (lamaIteration >= 0.75 * FMain.FPS)
                {
                    lamaIteration = 0;
                    colorIndex++;
                    if(colorIndex > colors.Length - 1)
                    {
                        colorIndex = colors.Length - 1;
                        canExitMenu = true;
                    }
                }
                Oh.prc("Лама", colors[colorIndex]);
            }
            else
            {
                Oh.nl();
                Oh.prc("Ну как тебе? Ладно, верну тебе некоторую часть от суммы.", ConsoleColor.DarkGray);
                Oh.prc("Вам вернули " + currentLoozeCashback, ConsoleColor.Green);

                if (Console.KeyAvailable)
                {
                    colorIndex = 0;
                    currentState = GameState.Click;
                    canExitMenu = false;
                }
            }
        }

        private void getMoneyPerSecond()
        {
            secIterator++;
            if (secIterator >= FMain.FPS)
            {
                secIterator = 0;
                kirillPower += secPurchase.Purch;
            }
        }

        private void printHelp()
        {
            Console.SetCursorPosition(0, 12);
            Oh.prc("Пробел - увеличить Кириллову мощь.", ConsoleColor.Gray);
            Oh.prc("h - открыть помощь (ты и так уже тут).", ConsoleColor.DarkGray);
            Oh.prc("u - открыть магазин улучшений Вячеслава.", ConsoleColor.Gray);
            Oh.prc("c - крутить кейсы в казино Артёма.", ConsoleColor.DarkGray);
            Oh.prc("s - открыть статистику.", ConsoleColor.Gray);
            Oh.prc("e - выйти из игры:(", ConsoleColor.DarkGray);

            if (Console.KeyAvailable)
            {
                currentState = GameState.Click;
            }
        }

        private void printUpgrades()
        {
            Console.SetCursorPosition(0, 12);
            Oh.prc("Вячеслав: добро пожаловать в мой магазин, добрый Кирилл!", ConsoleColor.Gray);
            Oh.prc("Что ты хочешь купить?", ConsoleColor.DarkGray);
            Oh.prc("1: мечъ дабы со злого люда больше мощи получать : " + swordPurchase.Cost + " мощи надобно.", ConsoleColor.Gray);
            Oh.prc("2: часики волшебные, дабы мощъ пассивно получать. Но знай, не ленись добрый молодецъ! : " + secPurchase.Cost + " мощи надобно.", ConsoleColor.DarkGray);
            Oh.prc("3: в магазинчик-то у меня никто не ходит. Пожертвуй добрый молодецъ на развитие моего магазина, а я тебе отплачу. Заплати-ка мне " + shopPurchase.Cost + " мощи.", ConsoleColor.Gray);
            if (Console.KeyAvailable)
            {
                command = Console.ReadKey().KeyChar;
            }
            else
            {
                command = '=';
            }
            Oh.nl();
            if (!canExitMenu)
            {
                switch (command)
                {
                    case '1':
                        swordPurchase.Buy(ref kirillPower);
                        canExitMenu = true;
                        break;
                    case '2':
                        secPurchase.Buy(ref kirillPower); 
                        canExitMenu = true;
                        break;
                    case '3':
                        shopPurchase.Buy(ref kirillPower);
                        canExitMenu = true;
                        break;
                    case '=':
                        break;
                    default:
                        Oh.pr("Не понимаю я таких слов заморских... Ну ничего, приходи ещё!");
                        canExitMenu = true;
                        break;
                }
            }
            else
            {
                currentState = GameState.Click;
                canExitMenu = false;
            }

        }

        private void printCases()
        {
            Console.SetCursorPosition(0, 12);
            Oh.prc("Добро пожаловать в магазин кейсов!", ConsoleColor.Magenta);
            Oh.prc("Какой кейс хотите открыть?", ConsoleColor.Magenta);
            Oh.prc("1: Python кейс - 500 мощи. 1% шанс пройти игру.", ConsoleColor.Gray);
            Oh.prc("2: C++ кейс - 2000 мощи. 5% шанс пройти игру.", ConsoleColor.DarkGray);
            Oh.prc("3: Rust кейс - 10000 мощи. 15% шанс пройти игру.", ConsoleColor.Gray);
            Oh.prc("4: Java кейс - 20000 мощи. 30% шанс пройти игру.", ConsoleColor.DarkGray);
            Oh.prc("5: C# кейс - 100000 мощи. 50% шанс пройти игру.", ConsoleColor.Gray);

            if (Console.KeyAvailable)
            {
                command = Console.ReadKey().KeyChar;
            }
            else
            {
                command = '=';
            }
            Oh.nl();
            if (!canExitMenu)
            {
                switch (command)
                {
                    case '1':
                        canExitMenu = true;
                        PythonCase.Open(ref kirillPower, ref currentState, ref currentLoozeCashback, ref canExitMenu);
                        break;
                    case '2':
                        canExitMenu = true;
                        CppCase.Open(ref kirillPower, ref currentState, ref currentLoozeCashback, ref canExitMenu);
                        break;
                    case '3':
                        canExitMenu = true;
                        RustCase.Open(ref kirillPower, ref currentState, ref currentLoozeCashback, ref canExitMenu);
                        break;
                    case '4':
                        canExitMenu = true;
                        JavaCase.Open(ref kirillPower, ref currentState, ref currentLoozeCashback, ref canExitMenu);
                        break;
                    case '5':
                        canExitMenu = true;
                        CsCase.Open(ref kirillPower, ref currentState, ref currentLoozeCashback, ref canExitMenu);
                        break;
                    case '=':
                        break;
                    default:
                        Oh.pr("Я не понял что ты сказал");
                        canExitMenu = true;
                        break;
                }
            }
            else
            {
                currentState = GameState.Click;
                canExitMenu = false;
            }
        }

        private void printStat()
        {
            Console.SetCursorPosition(0, 12);
            Oh.prc("СТАТИСТИКА", ConsoleColor.Green);
            Oh.prc(">Мощи за клик: " + swordPurchase.Purch, ConsoleColor.Gray);
            Oh.prc(">Мощи в секунду: " + secPurchase.Purch, ConsoleColor.DarkGray);
            Oh.prc(">Уровень магазина Вячеслава: " + shopPurchase.Purch, ConsoleColor.Gray);

            if (Console.KeyAvailable)
            {
                currentState = GameState.Click;
            }
        }
    }

    class Case
    {
        public int Chance;
        public int Cost;
        public int LoozeCashback;
        private static Random r = new Random();

        public Case(int chance, int cost, int loozeCashbach)
        {
            Chance = chance;
            Cost = cost;
            LoozeCashback = loozeCashbach;
        }

        public void Open(ref int kirillPower, ref GameState currentState, ref int loozeCashback, ref bool canExitMenu)
        {
            if (kirillPower >= Cost)
            {
                kirillPower -= Cost;
                loozeCashback = LoozeCashback;
                bool isWin = r.Next(0, 101) <= Chance;
                if (isWin)
                {
                    Oh.prc("Ох, вот это везение!!! Вы выйграли, и прошли игру!", ConsoleColor.Green);
                    kirillPower = 2_000_000_000;
                }
                else
                {
                    currentState = GameState.LamaDance;
                    canExitMenu = false;
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
                Cost = (int)(Cost * CostMult);
                Oh.pr(Text);
            }
            else
            {
                Oh.prc("Не хватает у тебя денюжек... Приходи когда накопишь.", ConsoleColor.Red);
            }
        }
    }
}