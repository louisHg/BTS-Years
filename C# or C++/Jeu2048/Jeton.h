#pragma once
#include <string>

class Jeton
{
public:
	Jeton(void);
	~Jeton(void);
	std::string init(int, int, int);
	int getValeur();
	void setValeur(int);
	std::string getPath();
	int getPosX();
	int getPosY();
private:
	int _valeur;
	int _posX;
	int _posY;
	char path[20];
};

