#include "Config.h"

static int kirillPower;
static HANDLE hStdOut;

void Config::init()
{
	kirillPower = 0;
	hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
}

int Config::getKirillPower() {
	return kirillPower;
}
void Config::setkirillPower(int val) {
	kirillPower = val;
}
void Config::addKirillPower(int inc) {
	kirillPower += inc;
}
HANDLE Config::getHStdOut() {
	return hStdOut;
}