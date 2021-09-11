#pragma once
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <WinSock2.h>
#include <mysql.h>
#include <string.h>

class Modele
{
public:
	Modele();
	~Modele();
	bool connection();
	void selectTout();
	int getLastId();
	void testRqt();
	void insertJoueur(std::string, std::string, int, bool);
	void majJoueurs(int, int, bool);
	void envoyerRequete(std::string);
	MYSQL_RES *res_set;
	MYSQL_ROW row;

private:
	char _requete[100];
	MYSQL *_conn;
	MYSQL_FIELD *_field;
};

