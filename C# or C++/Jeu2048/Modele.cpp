#include "Modele.h"

Modele::Modele()
{
}
bool Modele::connection(){
	_conn = mysql_init(NULL);
	if (mysql_real_connect(_conn, "localhost", "root", "password", "jeu2048", 3307, NULL, 0) == NULL)
	{
		printf("erreur de connection");
		return false;
	}
	printf("connection ok");
	return true;
}
void Modele::selectTout(){
	sprintf_s(this->_requete, "SELECT nom, prenom, score, gagnant from joueurs order by nom desc");
	mysql_query(this->_conn, this->_requete);
	res_set = mysql_store_result(this->_conn);
}
void Modele::insertJoueur(std::string nom, std::string prenom, int score, bool gagne){
	sprintf_s(_requete, "INSERT INTO joueurs (nom,prenom,score,gagnant) VALUES('%s','%s','%d','%d')", nom.c_str(), prenom.c_str(), score, gagne);
	mysql_query(this->_conn, this->_requete);
}
int Modele::getLastId(){
	sprintf_s(_requete, "Select MAX(idjoueurs) from joueurs");
	mysql_query(this->_conn, _requete);
	res_set = mysql_store_result(this->_conn);
	return (int)mysql_fetch_row(res_set)[0];
}
void Modele::envoyerRequete(std::string requete){
	sprintf_s(this->_requete, (char*)(requete.c_str()));
	mysql_query(this->_conn, this->_requete);
	res_set = mysql_store_result(this->_conn);
}


Modele::~Modele()
{
}