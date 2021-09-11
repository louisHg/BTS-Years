#undef UNICODE
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <WinSock2.h>
#include <ws2tcpip.h>
#include <stdlib.h>
#include <stdio.h>
#include <thread>    //std::thread
#include "Score.h"
// Need to link with Ws2_32.lib
#pragma comment (lib, "Ws2_32.lib")
// #pragma comment (lib, "Mswsock.lib")
#define DEFAULT_BUFLEN 512
#define DEFAULT_PORT "27015"

class Serveur
{
	struct thread_param{
		Serveur* ser;
		SOCKET soc;
	};
public:
	Serveur(void);
	int start();
	int pause();
	~Serveur(void);
	WSADATA        WSAData;
	SOCKET        sock;
	SOCKET        csock;
	SOCKADDR_IN    sin;
	SOCKADDR_IN    csin;
};