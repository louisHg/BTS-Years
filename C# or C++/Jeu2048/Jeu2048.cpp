#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <SDL.h>
#include <SDL_ttf.h>
#include "score.h"
#include "Joueurs.h"
#include "Damier.h"
#include "fenetre.h"
#include "Damiertest.h"
#include "Statistique.h"

int main(int argc, char *argv[])
{
	SetConsoleCP(CP_UTF8);
	SetConsoleOutputCP(CP_UTF8);
	int size = 400;
	bool saisiePrenom = false;
	int tailleNom = 0;
   // fenetre *lafenetre = new fenetre("Jeu2048", SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, size, size);
	score *leScore = new score("Score", 100, 100 + size / 2, size / 2, size / 2);
	Joueurs *lesJoueurs = new Joueurs("Joueurs", 120 + size + size / 2, SDL_WINDOWPOS_CENTERED, size * 2, size);
	Damiertest *damiertest = new Damiertest("Damiertest", 110 + size / 2, SDL_WINDOWPOS_CENTERED, size, size);
	Statistique *statistique = new Statistique("Statistique", 100, 100 + size / 2, size / 2, size / 2);

	SDL_StartTextInput();
	while (1){
		SDL_WaitEvent(&damiertest->evenements);
		if (damiertest->start){
			switch (damiertest->evenements.type)
			{
			case SDL_KEYDOWN:
				switch (damiertest->evenements.key.keysym.sym)
				{
				case SDLK_UP:
					damiertest->deplacer("haut");
					break;
				case SDLK_DOWN:
					damiertest->deplacer("bas");
					break;
				case SDLK_LEFT:
					damiertest->deplacer("gauche");
					break;
				case SDLK_RIGHT:
					damiertest->deplacer("droite");
					break;
				}
				break;
			}
			leScore->setScore(damiertest->getScore());
			leScore->afficherContenu();
			leScore->setSommeJeton(damiertest->getSommeJeton());
			leScore->poserImage("../jetons/jeuOK.bmp", 130, 4);
			statistique->setNbCoupHaut(damiertest->getnbCoupHaut());
			statistique->setNbCoupBas(damiertest->getnbCoupBas());
			statistique->setNbCoupGauche(damiertest->getnbCoupGauche());
			statistique->setNbCoupDroit(damiertest->getnbCoupDroite());
			statistique->afficherContenu();
		}
		else {
			if (damiertest->evenements.key.keysym.sym == SDLK_RETURN){
				saisiePrenom = true;
				tailleNom = lesJoueurs->getNom().size();
			}
			if (!saisiePrenom){
				if (damiertest->evenements.type == SDL_TEXTINPUT){
					lesJoueurs->setNom(lesJoueurs->getNom() + damiertest->evenements.text.text);
					std::cout << lesJoueurs->getNom() << std::endl;
					lesJoueurs->poserTexte((char*)lesJoueurs->getNom().c_str(), 100, 0);
				}
			}
			else {
				if (damiertest->evenements.type == SDL_TEXTINPUT){
					lesJoueurs->setPrenom(lesJoueurs->getPrenom() + damiertest->evenements.text.text);
					std::cout << lesJoueurs->getPrenom() << std::endl;
					lesJoueurs->poserTexte((char*)lesJoueurs->getPrenom().c_str(), 200 + tailleNom * 10, 0);
				}
			}
			if (damiertest->evenements.type == SDL_MOUSEBUTTONDOWN){
				printf("click gauche");
				printf("position X %d\n", damiertest->evenements.motion.x);
				if (damiertest->evenements.motion.x > 130 && damiertest->evenements.motion.x < 130 + taille_jeton && damiertest->evenements.motion.y < 30){
					damiertest->start = true;
					SDL_StopTextInput();
					lesJoueurs->bdd->insertJoueur(lesJoueurs->getNom(), "", 123, false);
					lesJoueurs->bdd->insertJoueur(lesJoueurs->getPrenom(),"" , 123, false);
				}
			}
	    }
	}
		SDL_Delay(5000);
		SDL_Quit();
		return EXIT_SUCCESS;
}
