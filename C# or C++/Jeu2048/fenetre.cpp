#include "fenetre.h"
 
fenetre::fenetre(){

}

fenetre::fenetre(std::string texte, int x, int y, int tailleH, int tailleV)
{
	this->tailleH=tailleH;
	this->tailleV = tailleV;
	_gwindow = SDL_CreateWindow((char*)texte.c_str(), x, y, tailleH, tailleV, SDL_WINDOW_SHOWN);
	_gScreenSurface = SDL_GetWindowSurface(_gwindow);
}

void fenetre::poserTexte(char path[20], int x, int y)
{
	SDL_Rect pos;
	pos.x = x;
	pos.y = y;
	TTF_Init();
	TTF_Font * font = TTF_OpenFont("arial.ttf", 25);
	SDL_Color color = { 255, 0, 0 };
	SDL_Surface * surface = TTF_RenderText_Solid(font, path, color);
	SDL_BlitSurface(surface, NULL, _gScreenSurface, &pos);
	SDL_UpdateWindowSurface(_gwindow);
}

void fenetre::poserImage(char path[20], int x, int y)
{
	SDL_Rect pos;
	pos.x = x;
	pos.y = y;
	SDL_BlitSurface(SDL_LoadBMP(path), NULL, _gScreenSurface, &pos);
	SDL_UpdateWindowSurface(_gwindow);
}

void fenetre::poserTexte(char path[20], int x, int y, SDL_Color laCouleur){
	SDL_Rect pos;
	pos.x = x;
	pos.y = y;
	TTF_Init();
	TTF_Font * font = TTF_OpenFont("arial.ttf", 25);
	SDL_Color color = { 255 , 251 , 0 };
	SDL_Surface *surface = TTF_RenderText_Solid(font, path, laCouleur);
	SDL_BlitSurface(surface, NULL, _gScreenSurface, &pos);
	SDL_UpdateWindowSurface(this->_gwindow);
}

void fenetre::couleur(int r, int g, int b, int a){
}

void fenetre::fondColorier(int r, int g, int b){
	SDL_Rect pos;
	pos.x = 0;
	pos.y = 0;
	SDL_Surface * surface;
	surface = SDL_CreateRGBSurface(0, this->tailleH, this->tailleV, 32, 0, 0, 0, 0);
	SDL_FillRect(surface, NULL, SDL_MapRGB(surface->format, r, g, b));
	SDL_BlitSurface(surface, NULL, _gScreenSurface, &_pos);
	SDL_UpdateWindowSurface(this->_gwindow);
}



fenetre::~fenetre(void){
}

void fenetre::afficherContenu(){
	
}
