#pragma once

#include <iostream>
#include <Windows.h>
#include "Config.h"

//oh - output handler
class oh
{
public:

    static const WORD darkRed = FOREGROUND_RED;
    static const WORD lightRed = FOREGROUND_RED | FOREGROUND_INTENSITY;
    static const WORD darkGreen = FOREGROUND_GREEN;
    static const WORD lightGreen = FOREGROUND_GREEN | FOREGROUND_INTENSITY;
    static const WORD darkBlue = FOREGROUND_BLUE;
    static const WORD lightBlue = FOREGROUND_BLUE | FOREGROUND_INTENSITY;
    static const WORD darkGray = FOREGROUND_INTENSITY;
    static const WORD lightGray = FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE;
    static const WORD white = FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_INTENSITY;
    static const WORD black = 0;
    static const WORD darkYellow = FOREGROUND_RED | FOREGROUND_GREEN;
    static const WORD lightYellow = FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_INTENSITY;
    static const WORD darkPurple = FOREGROUND_RED | FOREGROUND_BLUE;
    static const WORD lightPurple = FOREGROUND_RED | FOREGROUND_BLUE | FOREGROUND_INTENSITY;
    static const WORD darkCyan = FOREGROUND_GREEN | FOREGROUND_BLUE;
    static const WORD lightCyan = FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_INTENSITY;

	static void pr(std::string text);
	static void pr(std::string text, bool flag);
	static void prc(std::string text, int color);
    static void prc(std::string text, int color, bool flag);
	static void nl();
};