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
                pr("\r���� ����: " + std::to_string(kirillPower) + " >>> ", false);
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
    pr("����� ���������� � ������ ���� �������");
    pr("��������� �� ������, ����� ������� ��������� ����");
    pr("��� ������ ���� ������ ������� h, ��� ������ �� ���� - e");
    char command = 0;
    int swordCost = 50;
    int powerPerClick = 1;
    int powerPerSecCost = 50;
    int shopUpgradeCost = 10000;

    std::async(std::launch::async, getMoneyPerSecond);
    while (inGame) {
        pr("\r���� ����: " + std::to_string(kirillPower) + " >>> ", false);
        command = _getch();
        switch (command) {
        case ' ':
            kirillPower += powerPerClick;
            break;
        case 'h':
            nl();
            SetConsoleTextAttribute(hStdOut, FOREGROUND_INTENSITY);
            pr("������ - ��������� ��������� ����.");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
            pr("h - ������� ������ (�� � ��� ��� ���).");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_INTENSITY);
            pr("e - ����� �� ����:(");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
            pr("u - ������� ������� ��������� ���������.");
            break;
        case 'u':
            canClick = false;
            nl();
            SetConsoleTextAttribute(hStdOut, FOREGROUND_INTENSITY);
            pr("��������: ����� ���������� � ��� �������, ������ ������!");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
            pr("��� �� ������ ������?");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_INTENSITY);
            pr("1: ���� ���� �� ����� ���� ������ ���� �������� : " + std::to_string(swordCost) + " ���� �������.");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
            pr("2: ������ ���������, ���� ���� �������� ��������. �� ����, �� ������ ������ ��������! : " + std::to_string(powerPerSecCost) + " ���� �������.");
            SetConsoleTextAttribute(hStdOut, FOREGROUND_INTENSITY);
            pr("3: � ����������-�� � ���� ����� �� �����. ��������� ������ �������� �� �������� ����� ��������, � � ���� �������. �������-�� ��� " + std::to_string(shopUpgradeCost) + " ����.");
            command = _getch();
            switch (command)
            {
            case '1':
                if (kirillPower >= swordCost) {
                    kirillPower -= swordCost;
                    powerPerClick++;
                    swordCost *= 2.71828;
                    pr("������� �� �������, ������ ��������! ������� � ��� ������� ���!");
                    SetConsoleTextAttribute(hStdOut, FOREGROUND_GREEN);
                    pr("������ �� ��������� " + std::to_string(powerPerClick) + " ���� �� ���� ����. ��� �������!");
                }
                else {
                    SetConsoleTextAttribute(hStdOut, FOREGROUND_RED);
                    pr("�� ������� � ���� �������... ������� ����� ��������.");
                }
                break;
            case '2':
                if (kirillPower >= powerPerSecCost) {
                    kirillPower -= powerPerSecCost;
                    powerPerSec++;
                    powerPerSecCost *= 2.71828;
                    pr("������� �� �������, ������ ��������! ������� � ��� ������� ���!");
                    SetConsoleTextAttribute(hStdOut, FOREGROUND_GREEN);
                    pr("������ �� ��������� " + std::to_string(powerPerSec) + " ���� �� ���� �������. ��� �������!");
                }
                else {
                    SetConsoleTextAttribute(hStdOut, FOREGROUND_RED);
                    pr("�� ������� � ���� �������... ������� ����� ��������.");
                }
                break;
            case '3':
                if (kirillPower >= shopUpgradeCost) {
                    kirillPower -= shopUpgradeCost;
                    shopUpgradeCost = 2147000000;
                    SetConsoleTextAttribute(hStdOut, FOREGROUND_GREEN | FOREGROUND_BLUE);
                    pr("�� ������� �� ������� ���������, ������� ���� ��������! ������, �� ����� ������ ������");
                }
                else {
                    SetConsoleTextAttribute(hStdOut, FOREGROUND_RED);
                    pr("�� ������� � ���� �������... ������� ����� ��������.");
                }
                break;
            default:
                pr("�� ������� � ����� ���� ���������... �� ������, ������� ���!");
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