#include "Statistique.h"


Statistique::Statistique()
{
}

Statistique::Statistique(std::string texte, int x, int y, int tailleH, int tailleV) :fenetre(texte, x, y, tailleH, tailleV)
{
	this->afficherContenu();
	this->initContenu();
}

int Statistique::getNbCoupHaut(){
	return this->_nbCoupHaut;
}

int Statistique::getNbCoupBas(){
	return this->_nbCoupBas;
}

int Statistique::getNbCoupDroit(){
	return this->_nbCoupDroite;
}

int Statistique::getNbCoupGauche(){
	return this->_nbCoupGauche;
}

void Statistique::setNbCoupHaut(int leStat){
	this->_nbCoupHaut = leStat;
}

void Statistique::setNbCoupBas(int leStat){
	this->_nbCoupBas = leStat;
}

void Statistique::setNbCoupGauche(int leStat){
	this->_nbCoupGauche = leStat;
}

void Statistique::setNbCoupDroit(int leStat){
	this->_nbCoupDroite = leStat;
}
void Statistique::initContenu(){
_unJeton = 16;
this-> _nbCoupBas = 0;
this->_nbCoupHaut = 0;
this->_nbCoupDroite = 0;
this->_nbCoupGauche = 0;
}
void Statistique::afficher(){

}
void Statistique::miseAjour(int haut, int bas, int gauche, int droite){
	this->setNbCoupBas(bas);
	this->_leStat = bas;
	this->setNbCoupHaut(haut);
	this->_leStat = haut;
	this->setNbCoupGauche(gauche);
	this->_leStat = gauche;
	this->setNbCoupDroit(droite);
	this->_leStat = droite;
	afficherContenu();
}
void Statistique::afficherContenu(){
	std::string ligne;
	SDL_Rect pos;
	int i, j;
	fondColorier(100, 100, 250);
	this->poserTexte("Haut", 10, 40);
	this->poserTexte((char*)std::to_string(this->_nbCoupHaut).c_str(), 120, 40);
	this->poserTexte("Bas", 10, 70);
	this->poserTexte((char*)std::to_string(this->_nbCoupBas).c_str(), 120, 70);
	this->poserTexte("Gauche", 10, 100);
	this->poserTexte((char*)std::to_string(this->_nbCoupGauche).c_str(), 120, 100);
	this->poserTexte("Droite", 10, 130);
	this->poserTexte((char*)std::to_string(this->_nbCoupDroite).c_str(), 120, 130);

}
Statistique::~Statistique()
{
}
