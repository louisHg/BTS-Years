#pragma once
#include <stdlib.h>
#include "fenetre.h"
#include "Jeton.h"
#include "Constantes.h"
#include "Damiertest.h"



class Statistique:
 public fenetre
{
public:
	Statistique();
	Statistique(std::string, int, int, int, int);
	void afficherContenu();
	void initContenu();
	void afficher();
	int getNbCoupHaut();
	int getNbCoupBas();
	int getNbCoupGauche();
	int getNbCoupDroit();
	void setNbCoupHaut(int);
	void setNbCoupBas(int);
	void setNbCoupGauche(int);
	void setNbCoupDroit(int);
	void miseAjour(int, int, int, int);

	~Statistique();

private:
	Jeton *_lesJetons[taille_jeux][taille_jeux];
	int _nbCoupHaut;
	int _nbCoupBas;
	int _nbCoupDroite;
	int _nbCoupGauche;
	int _unJeton;
	int _leStat;
	bool terminer;
	std::string _text1;
	std::string _text2;
	std::string _text3;
	std::string _text4;
	std::string bouton;
	
};
