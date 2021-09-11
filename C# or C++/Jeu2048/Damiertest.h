#pragma once
#include <time.h>
#include "fenetre.h"
#include "Jeton.h"
#include "Constantes.h"
#include "Damiertest.h"

class Damiertest :
	public fenetre
{
    public:
	Damiertest();
	Damiertest(std::string, int, int, int, int);
	void init();
	void genererJeton();
	void afficher();
	void afficherContenu();
	int compterBlanc();
	void deplacer(std::string);
	int getScore();
	int setScore();
	int getnbCoupGauche();
	int getnbCoupDroite();
	int getnbCoupBas();
	int getnbCoupHaut();
	int getSommeJeton();
	int setNbCoupHaut(int);
	int setNbCoupBas(int);
	int setNbCoupGauche(int);
	int setNbCoupDroite(int);
	void stat();
	bool start=false;
	~Damiertest();

private:
	Jeton *leJeton;
	Jeton *_lesJetons[taille_jeux][taille_jeux];
	int _nbBlanc;
	int _score;
	int _gagne;
	int _perdu;
	int _sommeJeton;
	int _nbCoupHaut;
	int _nbCoupBas;
	int _nbCoupDroite;
	int _nbCoupGauche;
};

