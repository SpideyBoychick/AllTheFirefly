#pragma once

#include <iostream>
#include "Config.h"
#include "oh.h"

class purchase
{
public:
	int Cost;
	double CostMult;
	int Purch;
	int PurchIncrement;
	std::string Text1;

	purchase(int cost, double costMult, int purch, int purchIncrement, std::string text1);
	void buy();
};

