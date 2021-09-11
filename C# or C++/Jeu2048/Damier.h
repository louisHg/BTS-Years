#include "fenetre.h"

class Damier :
	public fenetre
{
public:
	Damier();
	Damier(std::string, int, int, int, int);
	void afficherContenu();
	void init();
	
};

