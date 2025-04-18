#include "purchase.h"

purchase::purchase(int cost, double costMult, int purch, int purchIncrement, std::string text1)
: Cost(cost), CostMult(costMult), Purch(purch), PurchIncrement(purchIncrement), Text1(text1)
{

}

void purchase::buy() {
    if (Config::getKirillPower() >= Cost) {
        Config::addKirillPower(-Cost);
        Purch += PurchIncrement;
        Cost *= CostMult;
        oh::pr(Text1);
    }
    else {
        oh::prc("Не хватает у тебя денюжек... Приходи когда накопишь.", oh::darkRed);
    }
}