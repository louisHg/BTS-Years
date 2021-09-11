#include "Damiertest.h"
#include "fenetre.h"
#include "Statistique.h"
Damiertest::Damiertest()
{
}

Damiertest::Damiertest(std::string texte, int x, int y, int tailleH, int tailleV) :fenetre(texte,x,y,tailleH,tailleV)
{
	this->init();
}

void Damiertest::init()
{
	_sommeJeton = 0;
	srand(time(NULL));
	leJeton = new Jeton();
	for (int i = 0; i < 6; i++){
		for (int j = 0; j <6; j++){
		_lesJetons[i][j] = new Jeton();
		if (i == 0 || i== taille_jeux-1 || j==0 || j==taille_jeux -1){
            _lesJetons[i][j]->setValeur(12);
		}
		else {
			_lesJetons[i][j]->setValeur(0);
		}
	}
}
	genererJeton();
    afficher();
	int nbBlanc = this->compterBlanc();

}

void Damiertest::genererJeton(){
	bool placeOQP = true;
	int initX, initY;
	srand(time(NULL));
	while (placeOQP){
        initX = rand() % (taille_jeux - 2) + 1;
	    initY = rand() % (taille_jeux - 2) + 1;
	    if (_lesJetons[initX][initY]->getValeur() == 0){
		    placeOQP = false;
            _lesJetons[initX][initY]->setValeur(rand() %2 +1);
	     }
	}
}

void Damiertest::afficher(){
	std::string ligne;
	SDL_Rect pos;
	int i, j;

	for (i = 0; i < taille_jeux; i++)
	{
		ligne = "";
		pos.y = i;
		for (j = 0; j < taille_jeux; j++)
		{
			pos.x = j;
			std::string image = _lesJetons[i][j]->init(pos.x, pos.y, taille_jeton);
			this->poserImage((char*)image.c_str(), _lesJetons[i][j]->getPosX(), _lesJetons[i][j]->getPosY());
		}
	}
	if (this->_gagne) this->poserTexte("GAGNE !", 20, 20);
	this->poserTexte((char*)std::to_string(this->_score).c_str(), 300, 20);
}
void Damiertest::afficherContenu(){

}
void Damiertest::deplacer(std::string sens)
{
	this->_score++;
	int i = 0, j = 0;
	bool encore = true;
	if (sens == "gauche")
	{
        std::cout << sens << std::endl;
		_nbCoupGauche++;
	    for (int i = 1; i < taille_jeux - 1; i++){
		    for (int j = 1; j < taille_jeux - 2; j++){
			    if (_lesJetons[i][j]->getValeur() == 0){
				    _lesJetons[i][j]->setValeur(_lesJetons[i][j + 1]->getValeur());
				    _lesJetons[i][j + 1]->setValeur(0);
			     }
				else  {
					if (_lesJetons[i][j]->getValeur() == _lesJetons[i + 1][j]->getValeur())
					{
						_lesJetons[i][j]->setValeur(_lesJetons[i][j]->getValeur() + 1);
						_sommeJeton = _sommeJeton + pow(2, _lesJetons[i][j]->getValeur());
						_lesJetons[i ][j+1]->setValeur(0);
						if (_lesJetons[i][j]->getValeur() == 11) this->_gagne = true;

					}
				}
	        }
		}
	}
	if (sens == "droite")
	{
		std::cout << sens << std::endl;
		_nbCoupDroite++;
		for (int i = 1; i < taille_jeux - 1; i++){
			for (int j = taille_jeux - 2; j > 1; j--){
				if (_lesJetons[i][j]->getValeur() == 0){
					_lesJetons[i][j]->setValeur(_lesJetons[i][j - 1]->getValeur());
					_lesJetons[i][j - 1]->setValeur(0);
				}
				else  {
					if (_lesJetons[i][j]->getValeur() == _lesJetons[i][j-1]->getValeur())
					{
						_lesJetons[i][j]->setValeur(_lesJetons[i][j]->getValeur() + 1);
						_sommeJeton = _sommeJeton + pow(2, _lesJetons[i][j]->getValeur());
						_lesJetons[i][j-1]->setValeur(0);
						if (_lesJetons[i][j]->getValeur() == 11) this->_gagne = true;
					}
				}
			}
		}
	}
	if (sens == "bas")
	{
		std::cout << sens << std::endl;
		_nbCoupBas++;
		for (int i = taille_jeux - 2; i > 1; i--){
			for (int j = 1; j < taille_jeux-1; j++){
				if (_lesJetons[i][j]->getValeur() == 0){
					_lesJetons[i][j]->setValeur(_lesJetons[i-1][j]->getValeur());
					_lesJetons[i-1][j]->setValeur(0);
				}
				else  {
					if (_lesJetons[i][j]->getValeur() == _lesJetons[i - 1][j]->getValeur())
					{
						_lesJetons[i][j]->setValeur(_lesJetons[i][j]->getValeur() + 1);
						_lesJetons[i - 1][j]->setValeur(0);
						_sommeJeton = _sommeJeton + pow(2, _lesJetons[i][j]->getValeur());
						if (_lesJetons[i][j]->getValeur() == 11) this->_gagne = true;

					}
				}
			}
		}
	}
	if (sens == "haut")
	{
		std::cout << sens << std::endl;
		_nbCoupHaut++;
		for (int i = 1; i < taille_jeux - 2; i++){
			for (int j = 1; j < taille_jeux -1; j++){
				if (_lesJetons[i][j]->getValeur() == 0){
					_lesJetons[i][j]->setValeur(_lesJetons[i + 1][j]->getValeur());
					_lesJetons[i + 1][j]->setValeur(0);
				}
				else  {
					if (_lesJetons[i][j]->getValeur() ==_lesJetons [i+1][j]->getValeur()) 
					{
						_lesJetons[i][j]->setValeur(_lesJetons[i][j]->getValeur() + 1);
						_lesJetons[i+1][j]->setValeur(0);
						_sommeJeton = _sommeJeton +pow(2, _lesJetons[i][j]->getValeur());
						if (_lesJetons[i][j]->getValeur() == 11) this->_gagne = true;
					}
				}
			}
		}
	}		
	this->afficher();

	this->_nbBlanc = this->compterBlanc();
	if (this->_nbBlanc != 0){
        this->genererJeton();
	}
	
}

int Damiertest::compterBlanc(){
	_nbBlanc = 0;
	for (int i = 0; i < taille_jeux; i++){
		for (int j = 0; j < taille_jeux; j++){
			if (_lesJetons[i][j]->getValeur() == 0) _nbBlanc++;
		}
	}
	return _nbBlanc;
}

int Damiertest::getScore(){
	return _score;
}

int Damiertest::getSommeJeton()
{
	return _sommeJeton;

}
int Damiertest::getnbCoupGauche(){
	return this->_nbCoupGauche;
}

int Damiertest::getnbCoupDroite(){
	return this->_nbCoupDroite;
}
int Damiertest::getnbCoupHaut(){
	return this->_nbCoupHaut;
}
int Damiertest::getnbCoupBas(){
	return this->_nbCoupBas;
}

Damiertest::~Damiertest()
{
}

