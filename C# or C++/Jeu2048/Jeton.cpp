#include "Jeton.h"


Jeton::Jeton(void)
{
	this->_posX = 0;
	this->_posY = 0;
}

std::string Jeton::init(int x, int y, int taille){
	this->_posX = x * taille + 3;;
	this->_posY = y * taille + 3;;
	sprintf_s(path, "../jetons/%d.bmp", this->getValeur());
	return path;
}

Jeton::~Jeton(void)
{
}

int Jeton::getValeur() {
	return this->_valeur;
}

void Jeton::setValeur(int val){
	this->_valeur = val;
}

std::string Jeton::getPath() {
	return this->path;
}

int Jeton::getPosX() {
	return this->_posX;
}

int Jeton::getPosY() {
	return this->_posY;
}