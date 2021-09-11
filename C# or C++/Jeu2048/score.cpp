#include "score.h"


score::score()
{
}


score::score(std::string texte, int x, int y, int tailleH, int tailleV) :fenetre(texte, x, y, tailleH, tailleV)
{
	this->afficherContenu();
	this->init();
}

void score::init()
{

}
		

void score::afficherContenu(){
	std::string ligne;
	SDL_Rect pos;
	int i, j;
	fondColorier(100, 100, 250);
	std::string texte = "score:";
	this->poserTexte((char*)texte.c_str(), 10, 10);
	this->_color.r = 255;
	this->_color.b = 0;
	this->_color.g = 255;
	this->poserTexte("score:", 10, 10, this->_color);
	this->poserTexte((char*)std::to_string(this->_leScore).c_str(), 100, 10);	
    this->poserTexte("somme:", 10, 40, this->_color);
	this->poserTexte((char*)std::to_string(this->_sommeJeton).c_str(), 120, 40);
	std::string image = "../jetons/boutonstart.bmp";
	this->poserImage((char*)image.c_str(), 130, 4);
}

void score::afficher(){

}
void score::miseAjour(int score, int gagnant, int jeton){
	this->setScore(score);
	this->_gagnant = gagnant;
	this->_jetonBlanc = jeton;
	afficher();
}

void score::setScore(int leScore)
{
	this->_leScore = leScore;
}

void score::setSommeJeton(int leScore)
{
	this->_sommeJeton = leScore;
}