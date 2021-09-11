#include "Joueurs.h"

Joueurs::Joueurs()
{
}

Joueurs::Joueurs(std::string texte, int x, int y, int tailleH, int tailleV) :fenetre(texte,x,y,tailleH,tailleV)
{
	this->afficherContenu();
	this->init();
}

void Joueurs::afficherContenu(){
	
}

void Joueurs::setNom(std::string leNom){
	this->_nom = leNom;
}

void Joueurs::setPrenom(std::string lePrenom){
	this->_prenom = lePrenom;
}

std::string Joueurs::getNom(){
	return this->_nom;
}

std::string Joueurs::getPrenom(){
	return this->_prenom;
}

void Joueurs::afficherLesJoueurs(){
	int i = 0, j = 0;
	if (this->bdd->connection()){
		this->bdd->selectTout();
		while ((this->bdd->row = mysql_fetch_row(this->bdd->res_set))!=NULL){
			for (i = 0; i < mysql_num_fields(this->bdd->res_set); i++){
				this->poserTexte(this->bdd->row[i], 100 * i, 130 + 30 * j);
			}
			j++;
		}
	}
	else {
		std::cout << "erreur de connection" << std::endl;
	}
}

void Joueurs::init(){
	this->bdd = new Modele();
	bool connectionOK = this->bdd->connection();
	std::cout << connectionOK << std::endl;
	this->fondColorier(100, 100, 200);
	this->_color.r = 255;
	this->_color.b = 255;
	this->_color.g = 255;
	this->_text = "Nom";
	this->poserTexte((char*)_text.c_str(),0,0, this->_color);
	this->_text = "Liste des joueurs";
	this->poserTexte((char*)_text.c_str(),0,100, this->_color);
	this->afficherLesJoueurs();
}

void Joueurs::afficher(){
	_bdd = new Modele();
	if (_bdd->connection()){
		_reqt = "select * from joueur order by score desc";
		_bdd->envoyerRequete(_reqt);
		unsigned int j = 0, i = 0;
		while ((_bdd->row = mysql_fetch_row(_bdd->res_set)) != NULL){
			for (i = 0; i < mysql_num_fields(_bdd->res_set); i++){
				this->poserTexte(_bdd->row[i], 50 * i, 30 + 30 * j);
			}
			j++;
		}
	}
	else {
		char error[24] = "Erreur de connexion BDD";
		this->poserTexte(error, 50, 50);
	}
}

void Joueurs::inscrireBdd(std::string nom, std::string prenom) {
	this->bdd->insertJoueur(nom, prenom,0,false);
	this->id=this->bdd->getLastId();
}
