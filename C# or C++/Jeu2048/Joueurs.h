#pragma once
#include "fenetre.h"
#include "Modele.h"
#include "Constantes.h"

class Joueurs :
	public fenetre
{
public:
	Joueurs();
	Joueurs(std::string, int , int, int, int);
	void afficherContenu();
	void init();
	void afficherLesJoueurs();
	void setNom(std::string);
	void setPrenom(std::string);
	void afficher();
	void inscrireBdd(std::string, std::string);
	std::string getNom();
	std::string getPrenom();

	Modele *bdd;
	~Joueurs();
private:
	char*_jetons[taille_jeux][taille_jeux];
	Modele *_bdd;
	int id;
	char*_texte;
	std::string _reqt;
	std::string _text;
	std::string _nom;
	std::string _prenom;
};