#pragma once
#include "Windows.h"

class Config {
public:
	static void init();

	static int getKirillPower();
	static void setkirillPower(int val);
	static void addKirillPower(int inc);

	static HANDLE getHStdOut();
};