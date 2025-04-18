#include "KirillsClicker.h"

int kirillPower = 0;
int powerPerSec = 0;
bool inGame = true;
bool canClick = true;

void pr(std::string text) {
    std::cout << text << std::endl;
}
void pr(std::string text, bool flag) {
    if (flag)
        std::cout << text << std::endl;
    else
        std::cout << text;
}
void nl() {
    std::cout << std::endl;
}

Concurrency::task<void> getMoneyPerSecond() {
    int i = 0;
    return Concurrency::create_task([i] {
        while (inGame) {
            if (canClick) {
                pr("\rВаша мощь: " + std::to_string(kirillPower) + " >>> ", false);
            }
            kirillPower += powerPerSec;
            std::this_thread::sleep_for(std::chrono::seconds(1));
        }
        });
}

int main()
{
    std::setlocale(LC_ALL, "Russian");
    HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
    pr("Добро пожаловать в КЛИКЕР СИЛЫ КИРИЛЛА");
    pr("Нажимайте на пробел, чтобы усилить КИРИЛЛОВУ МОЩЬ");
    pr("Для вывода всех команд нажмите h, для выхода из игры - e");
    char command = 0;
    int swordCost = 50;
    int powerPerClick = 1;
    int powerPerSecCost = 50;
    int shopUpgradeCost = 10000;

    std::async(std::launch::async, getMoneyPerSecond);
    while (inGame) {
        pr("\rВаша мощь: " + std::to_string(kirillPower) + " >>> ", false);
        command = _getch();
        switch (command) {
        case ' ':
            kirillPower += powerPerClick;
            break;
        case 'h':
            nl();
            SetConsoleTextAttribute(hStdOut, FOREGROUND_INTENSITY);
            pr("Пробел - увеличить Кириллову мощь.");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
            pr("h - открыть помощь (ты и так уже тут).");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_INTENSITY);
            pr("e - выйти из игры:(");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
            pr("u - открыть магазин улучшений Вячеслава.");
            break;
        case 'u':
            canClick = false;
            nl();
            SetConsoleTextAttribute(hStdOut, FOREGROUND_INTENSITY);
            pr("Вячеслав: добро пожаловать в мой магазин, добрый Кирилл!");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
            pr("Что ты хочешь купить?");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_INTENSITY);
            pr("1: мечъ дабы со злого люда больше мощи получать : " + std::to_string(swordCost) + " мощи надобно.");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
            pr("2: часики волшебные, дабы мощъ пассивно получать. Но знай, не ленись добрый молодецъ! : " + std::to_string(powerPerSecCost) + " мощи надобно.");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_INTENSITY);
            pr("3: в магазинчик-то у меня никто не ходит. Пожертвуй добрый молодецъ на развитие моего магазина, а я тебе отплачу. Заплати-ка мне " + std::to_string(shopUpgradeCost) + " мощи.");
            command = _getch();
            switch (command)
            {
            case '1':
                if (kirillPower >= swordCost) {
                    kirillPower -= swordCost;
                    powerPerClick++;
                    swordCost *= 2.71828;
                    pr("Спасибо за покупку, добрый молодецъ! Приходи в мой магазин ещё!");
                    SetConsoleTextAttribute(hStdOut, FOREGROUND_GREEN);
                    pr("Теперь вы получаете " + std::to_string(powerPerClick) + " мощи за один клик. Так держать!");
                }
                else {
                    SetConsoleTextAttribute(hStdOut, FOREGROUND_RED);
                    pr("Не хватает у тебя денюжек... Приходи когда накопишь.");
                }
                break;
            case '2':
                if (kirillPower >= powerPerSecCost) {
                    kirillPower -= powerPerSecCost;
                    powerPerSec++;
                    powerPerSecCost *= 2.71828;
                    pr("Спасибо за покупку, добрый молодецъ! Приходи в мой магазин ещё!");
                    SetConsoleTextAttribute(hStdOut, FOREGROUND_GREEN);
                    pr("Теперь вы получаете " + std::to_string(powerPerSec) + " мощи за одну секунду. Так держать!");
                }
                else {
                    SetConsoleTextAttribute(hStdOut, FOREGROUND_RED);
                    pr("Не хватает у тебя денюжек... Приходи когда накопишь.");
                }
                break;
            case '3':
                if (kirillPower >= shopUpgradeCost) {
                    kirillPower -= shopUpgradeCost;
                    shopUpgradeCost = 2147000000;
                    SetConsoleTextAttribute(hStdOut, FOREGROUND_GREEN | FOREGROUND_BLUE);
                    pr("Ох выручил ты дедушку Вячеслава, спасибо тебе огромное! Теперь, ты очень крутой Кирилл");
                }
                else {
                    SetConsoleTextAttribute(hStdOut, FOREGROUND_RED);
                    pr("Не хватает у тебя денюжек... Приходи когда накопишь.");
                }
                break;
            default:
                pr("Не понимаю я таких слов заморских... Ну ничего, приходи ещё!");
                break;
            }
            canClick = true;
            break;
        case 'e':
            inGame = false;
            break;
        }
    }
}