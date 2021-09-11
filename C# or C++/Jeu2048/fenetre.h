#pragma once
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <SDL.h>
#include <SDL_ttf.h>
#include "fenetre.h"
#include <string>


class fenetre
{
public:
	fenetre();
	fenetre(std::string, int x, int y, int tailleH, int tailleV);
	virtual void afficherContenu();
	void poserTexte(char[20], int, int);
	void poserImage(char[20], int, int);
	void poserTexte(char[20], int, int, SDL_Color);
	void couleur(int, int, int, int);
	void fondColorier(int, int, int);
	SDL_Event evenements;
	~fenetre(void);

protected:
	SDL_Window *_gwindow;
	SDL_Surface *_gScreenSurface;
	TTF_Font *_font;
	SDL_Rect _pos;
	SDL_Color _color;
	int tailleV;
	int tailleH;
};

