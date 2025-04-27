using MathNet.Numerics;

namespace AllTheFirefly.Main
{

    class New
    {
        string text;
        string visibleText;
        int visibleLen;
        int x;
        double X;
        int startIndex;
        double StartIndex;
        public static double Speed;
        
        public bool isFinished;

        public New(string text)
        {
            this.text = text;
            visibleText = "";
            visibleLen = 0;
            x = Console.BufferWidth + 40;
            X = x;
            startIndex = 0;
            StartIndex = startIndex;
            Speed = 0.2;

            isFinished = false;
        }

        public void Reset()
        {
            visibleText = "";
            visibleLen = 0;
            x = Console.BufferWidth + 40;
            X = x;
            startIndex = 0;
            StartIndex = startIndex;

            isFinished = false;
        }

        public void Draw()
        {
            if (startIndex < text.Length)
            {
                visibleText = "";
                Console.SetCursorPosition(0, 0);
                if (x > 0)
                {
                    X -= Speed;
                    x = (int)X;
                    int maxI;
                    if (x >= Console.BufferWidth)
                    {
                        visibleLen = 0;
                        maxI = Console.BufferWidth;
                    }
                    else
                    {
                        visibleLen = Console.BufferWidth - x;
                        maxI = x;
                    }
                    for (int i = 0; i < maxI; i++)
                    {
                        visibleText += " ";
                    }

                    if (visibleLen > text.Length)
                    {
                        visibleText += text.Substring(0, text.Length);
                    }
                    else
                    {
                        visibleText += text.Substring(0, visibleLen);
                    }

                    if (visibleText.Length < Console.BufferWidth)
                    {
                        for (int i = 0; i < Console.BufferWidth - visibleText.Length; i++)
                        {
                            visibleText += " ";
                        }
                    }
                }
                else
                {
                    StartIndex += Speed;
                    startIndex = (int)StartIndex;
                    if (text.Length - startIndex >= Console.BufferWidth)
                    {
                        visibleLen = Console.BufferWidth;
                    }
                    else
                    {
                        visibleLen = text.Length - startIndex;
                    }

                    if (startIndex <= text.Length)
                    {
                        if (visibleLen > text.Length)
                        {
                            visibleText += text.Substring(startIndex, text.Length);
                        }
                        else
                        {
                            visibleText += text.Substring(startIndex, visibleLen);
                        }

                        if (visibleLen < Console.BufferWidth)
                        {
                            for (int i = 0; i < Console.BufferWidth - visibleLen; i++)
                            {
                                visibleText += " ";
                            }
                        }
                    }
                }

                Console.WriteLine(visibleText);
            }
            else
            {
                isFinished = true;
            }
        }
    }

    static class NewsHandler
    {
        private static Random r = new Random();

        private static int tempX;
        private static int tempY;
        private static New currentNew;
        public static bool isNewsGo = true;

        private static New[] news = new New[]
        {
            new New("Артёмка-попрошайка разнылся, что его непризнанный \"кумир\" Кирилл не удостоил его высер звездой, а мрыбс тут же подхватил этот парад кумироёбства. Жалкое зрелище."),
            new New("Кирилл-плагиатор решил спиздить идею файерфлая у Пети-юриста, который сначала грозился засудить его нахуй ссаной MIT лицензией, но потом великодушно разрешил воровать. Щедрость года."),
            new New("Наш гений Кирилл-шизокодер попытался скрестить питона с плюсами в одном файле, чем вызвал праведный гнев Великого Зелебобы и дикий ржач у мрыбса со Славиком. Ебать он программист."),
            new New("Славик-джавист решил блеснуть интеллектом и загадал ебучую загадку про кэширование Integer, Зелебоба-недоучка сразу сел в лужу, а Кирилл-всезнайка попытался объяснить, но тоже жидко пёрднул. Знатоки хуевы."),
            new New("Зеро-безработный пожаловался, что Славик-архитектор отобрал у него работу, потому что лучше разбирается в скелетах, оставив беднягу бомжевать. Конкуренция, хули."),
            new New("Кирилл-говнокодер опять высрал нерабочий код менюшки на питоне, заставив бедного Зелебобу-тестировщика страдать с ошибками и правами рута, пока тот не психанул и не послал всех нахуй. Классика."),
            new New("Мрыбс-душнила доебался до Зелебобы-двоечника, нахуя тот готовится к какой-то ВПР по химии, а тот в ответ проблеял что-то невнятное про кислоты и щёлочи, чем окончательно убедил Мрыбса в своей тупости. Школьники, блядь."),
            new New("Кирилл-питонист умолял всех запустить его высер-симулятор Зеро, но Зеро-плюсовик встал в позу, обозвал питон дрисьнёй и запретил запускать, пока Зелебоба-провокатор не нажал кнопку, чем довёл Зеро до истерики и обвинений в осквернении дристо-питоном. Священная война языков."),
            new New("Влад-недоучка решил выебнуться знанием плюсов, но тут же был пойман Славиком-экзаменатором на незнании указателей и ссылок; пока Славик его учил жизни, прибежал Артём-душный-джавист и начал уже самого Славика гонять по джаве, доказывая, что тот нихуя не джун. Экзамен на выбывание."),
            new New("Мрыбс-бенчмаркер устроил гладиаторские бои между своим поделием Slinn и Фласком, заспамив чат скринами с тестами, где то один сосёт, то другой, и в итоге сам не понял, чей фреймворк говно. Научный подход, блядь."),
        };

        public static void Draw()
        {
            tempX = Console.CursorLeft;
            tempY = Console.CursorTop;
            Console.SetCursorPosition(0, 0);

            if(isNewsGo)
            {
                if (currentNew != null)
                {
                    if (currentNew.isFinished)
                    {
                        currentNew.Reset();
                        currentNew = news[r.Next(news.Length)];
                    }
                    else
                    {
                        currentNew.Draw();
                    }
                }
                else
                {
                    currentNew = news[r.Next(news.Length)];
                }
            }
            else
            {
                currentNew.Reset();
            }

            Console.SetCursorPosition(tempX, tempY);
        }
    }
}