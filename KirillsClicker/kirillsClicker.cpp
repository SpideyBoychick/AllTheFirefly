#include "KirillsClicker.h"

purchase swordPurchase = purchase(50, 2.71828, 1, 1, "Спасибо за покупку, добрый молодецъ! Приходи в мой магазин ещё!");
purchase secPurchase = purchase(50, 2.71828, 0, 1, "Спасибо за покупку, добрый молодецъ! Приходи в мой магазин ещё!");
purchase shopPurchase = purchase(10000, 1000, 0, 1, "Ох выручил ты дедушку Вячеслава, спасибо тебе огромное! Теперь, ты очень крутой Кирилл");

bool inGame = true;
bool canClick = true;

void printHelp();
void printUpgrades();
void printStat();

Concurrency::task<void> getMoneyPerSecond() {
    int i = 0;
    return Concurrency::create_task([i] {
        while (inGame) {
            if (canClick) {
                oh::prc("\rВаша мощь: " + std::to_string(Config::getKirillPower()) + " >>> ", oh::lightYellow, false);
            }
            Config::addKirillPower(secPurchase.Purch);
            std::this_thread::sleep_for(std::chrono::seconds(1));
        }
        });
}

int main()
{
    std::setlocale(LC_ALL, "Russian");
    Config::init();

    oh::pr("Добро пожаловать в КЛИКЕР СИЛЫ КИРИЛЛА");
    oh::pr("Нажимайте на пробел, чтобы усилить КИРИЛЛОВУ МОЩЬ");
    oh::pr("Для вывода всех команд нажмите h, для выхода из игры - e");
    char command = 0;

    std::async(std::launch::async, getMoneyPerSecond);
    while (inGame) {
        oh::prc("\rВаша мощь: " + std::to_string(Config::getKirillPower()) + " >>> ", oh::lightYellow, false);
        command = _getch();
        switch (command) {
        case ' ':
            Config::addKirillPower(swordPurchase.Purch);
            break;
        case 'h':
            printHelp();
            break;
        case 'u':
            canClick = false;
            printUpgrades();
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

void printHelp() {
    oh::nl();
    oh::prc("Пробел - увеличить Кириллову мощь.", oh::lightGray);
    oh::prc("h - открыть помощь (ты и так уже тут).", oh::darkGray);
    oh::prc("u - открыть магазин улучшений Вячеслава.", oh::darkGray);
    oh::prc("s - открыть статистику.", oh::darkGray);
    oh::prc("e - выйти из игры:(", oh::lightGray);
}
void printUpgrades() {
    oh::nl();
    oh::prc("Вячеслав: добро пожаловать в мой магазин, добрый Кирилл!", oh::lightGray);
    oh::prc("Что ты хочешь купить?", oh::darkGray);
    oh::prc("1: мечъ дабы со злого люда больше мощи получать : " + std::to_string(swordPurchase.Cost) + " мощи надобно.", oh::lightGray);
    oh::prc("2: часики волшебные, дабы мощъ пассивно получать. Но знай, не ленись добрый молодецъ! : " + std::to_string(secPurchase.Cost) + " мощи надобно.", oh::darkGray);
    oh::prc("3: в магазинчик-то у меня никто не ходит. Пожертвуй добрый молодецъ на развитие моего магазина, а я тебе отплачу. Заплати-ка мне " + std::to_string(shopPurchase.Cost) + " мощи.", oh::lightGray);
    char command = _getch();
    switch (command)
    {
    case '1':
        swordPurchase.buy();
        break;
    case '2':
        secPurchase.buy();
        break;
    case '3':
        shopPurchase.buy();
        break;
    default:
        oh::pr("Не понимаю я таких слов заморских... Ну ничего, приходи ещё!");
        break;
    }
}
void printStat() {
    oh::nl();
    oh::prc("Мощи за клик: " + std::to_string(swordPurchase.Purch), oh::lightGray);
    oh::prc("Мощи в секунду: " + std::to_string(secPurchase.Purch), oh::darkGray);
    oh::prc("Уровень магазина Вячеслава: " + std::to_string(shopPurchase.Purch), oh::lightGray);
}