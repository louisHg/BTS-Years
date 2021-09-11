#include "Damier.h"
#include "jeton.h"

Damier::Damier()
{
}

Damier::Damier(std::string texte, int x, int y, int tailleH, int tailleV) :fenetre(texte, x, y, tailleH, tailleV)
{
	this->afficherContenu();
	this->init();
}



void Damier::afficherContenu(){
	std::string texte = "Damier";
	this->poserTexte((char*)texte.c_str(), 10, 100);

	std::string image = "../jetons/1.bmp";
	this->poserImage((char*)image.c_str(), 10, 10);
}

void Damier::init(){
}