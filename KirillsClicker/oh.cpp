#include "oh.h"

void oh::pr(std::string text) {
    std::cout << text << std::endl;
}
void oh::pr(std::string text, bool flag) {
    if (flag)
        std::cout << text << std::endl;
    else
        std::cout << text;
}
void oh::prc(std::string text, int color) {
    SetConsoleTextAttribute(Config::getHStdOut(), color);
    pr(text);
    SetConsoleTextAttribute(Config::getHStdOut(), white);
}
void oh::prc(std::string text, int color, bool flag) {
    if (flag)
    {
        SetConsoleTextAttribute(Config::getHStdOut(), color);
        pr(text, true);
        SetConsoleTextAttribute(Config::getHStdOut(), white);
    }
    else
    {
        SetConsoleTextAttribute(Config::getHStdOut(), color);
        pr(text, false);
        SetConsoleTextAttribute(Config::getHStdOut(), white);
    }
}
void oh::nl() {
    std::cout << std::endl;
}