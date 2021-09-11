#include <stdlib.h>
#include "fenetre.h"
#include "Jeton.h"

#define taille_jeton  68
#define taille_jeux 6
#define WAV_PATH_1 "son1.wav"

class score :
	public fenetre
{
public:
	score();
	score(std::string, int , int , int , int);
	void afficherContenu();
	void init();
	void afficher();
	void setScore(int);
	int getScore();
	void setSommeJeton(int);
	void miseAjour(int score, int gagnant, int jetonBlanc);
	~score();

private:
	Jeton *_lesJetons[taille_jeux][taille_jeux];
	int _leScore;
	bool terminer;
	std::string _text1;
	std::string _text2;
	std::string _text3;
	int _jetonBlanc;
	int _gagnant;
	int _sommeJeton;
	int total;
	std::string bouton;
	std::string color;
	SDL_Color _color;
};

