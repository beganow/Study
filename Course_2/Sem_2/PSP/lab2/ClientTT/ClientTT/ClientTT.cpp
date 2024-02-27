#include <string>
#include <iostream>
#pragma comment(lib, "WS2_32.lib")
#include "Winsock2.h"
#pragma warning(disable:4996)
using namespace std;
string GetErrorMsgText(int code);
string SetErrorMsgText(string msgText, int code);

void main() {

	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);

	SOCKET sS;
	WSADATA wsaData;
	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw SetErrorMsgText("Startup:", WSAGetLastError());
		//............................................................



		if ((sS = socket(AF_INET, SOCK_STREAM, NULL)) == INVALID_SOCKET)
			throw SetErrorMsgText("socket:", WSAGetLastError());
		//.............................................................	

		SOCKADDR_IN serv; // ��������� ������ �������
		serv.sin_family = AF_INET; // ������������ IP-���������
		serv.sin_port = htons(2000); // TCP-���� 2000
		serv.sin_addr.s_addr = inet_addr("127.0.0.1"); // ����� �������
		if ((connect(sS, (sockaddr*)&serv, sizeof(serv))) == SOCKET_ERROR)
			throw SetErrorMsgText("connect:", WSAGetLastError());
		//..............................................................
		int n = 1000;
		string msg;
		int lb;
		char ibuf[50];
		int lc = sizeof(serv);
		int lobuf = 0; //���������� ������������ ����

		for (int i = 0; i < n; i++)
		{
			msg = "Hello from Client " + to_string(i);

			if ((lobuf = sendto(sS, msg.c_str(), strlen(msg.c_str()) + 1, NULL, (sockaddr*)&serv, sizeof(serv))) == SOCKET_ERROR)
				throw  SetErrorMsgText("sendto:", WSAGetLastError());

			if ((lb = recvfrom(sS, ibuf, sizeof(ibuf), NULL, (sockaddr*)&serv, &lc)) == SOCKET_ERROR)
				throw SetErrorMsgText("recv:", WSAGetLastError());
			cout << ibuf << endl;

		}




		if (closesocket(sS) == SOCKET_ERROR)
			throw SetErrorMsgText("closesocket:", WSAGetLastError());

		if (WSACleanup() == SOCKET_ERROR)
			throw SetErrorMsgText("Cleanup:", WSAGetLastError());
	}
	catch (string errorMsgText)
	{
		cout << endl << "WSAGetLastError: " << errorMsgText;
	}

}

string GetErrorMsgText(int code) // c����������� ����� ������
{
	string msgText;
	switch (code) // �������� ���� ��������
	{
	case WSAEINTR:      msgText = "WSAEINTR";  return "������ ������� �������� "; break;
	case WSAEBADF:        msgText = "WSAEBADF";  return "File handle is not valid"; break;
	case WSAEACCES:      msgText = "WSAEACCES";   return "���������� ����������"; break;
	case WSAEFAULT:     msgText = "WSAEFAULT";    return "��������� �����"; break;
	case WSAEINVAL:     msgText = "WSAEINVAL";    return "������ � ��������� "; break;
	case WSAEMFILE:      msgText = "WSAEMFILE";   return "������� ����� ������ �������"; break;
	case WSAEWOULDBLOCK:  msgText = "WSAEWOULDBLOCK";  return "������ �������� ����������"; break;
	case WSAEINPROGRESS:   msgText = "WSAEINPROGRESS"; return "�������� � �������� ��������"; break;
	case WSAEALREADY:      msgText = "WSAEALREADY"; return "�������� ��� ����������� "; break;
	case WSAENOTSOCK:      msgText = "WSAENOTSOCK"; return "����� ����� �����������   "; break;
	case WSAEDESTADDRREQ:  msgText = "WSAEDESTADDRREQ"; return "��������� ����� ������������ "; break;
	case WSAEMSGSIZE:     msgText = "WSAEMSGSIZE";  return "��������� ������� ������� "; break;
	case WSAEPROTOTYPE:    msgText = "WSAEPROTOTYPE"; return "������������ ��� ��������� ��� ������ "; break;
	case WSAENOPROTOOPT:   msgText = "WSAENOPROTOOPT"; return "������ � ����� ���������"; break;
	case WSAEPROTONOSUPPORT: msgText = "WSAEPROTONOSUPPORT"; return "�������� �� ��������������"; break;
	case WSAESOCKTNOSUPPORT: msgText = "WSAESOCKTNOSUPPORT"; return "��� ������ �� �������������� "; break;
	case WSAEOPNOTSUPP:     msgText = "WSAEOPNOTSUPP"; return "�������� �� �������������� "; break;
	case WSAEPFNOSUPPORT: msgText = "WSAEPFNOSUPPORT";  return "��� ���������� �� �������������� "; break;
	case WSAEAFNOSUPPORT:  msgText = "WSAEAFNOSUPPORT"; return "��� ������� �� �������������� ����������"; break;
	case WSAEADDRINUSE:    msgText = "WSAEADDRINUSE"; return "����� ��� ������������ "; break;
	case WSAEADDRNOTAVAIL: msgText = "WSAEADDRNOTAVAIL"; return "����������� ����� �� ����� ���� �����������"; break;
	case WSAENETDOWN:      msgText = "WSAENETDOWN"; return "���� ��������� "; break;
	case WSAENETUNREACH:   msgText = "WSAENETUNREACH"; return "���� �� ���������"; break;
	case WSAENETRESET:     msgText = "WSAENETRESET"; return "���� ��������� ����������"; break;
	case WSAECONNABORTED: msgText = "WSAECONNABORTED";  return "����������� ����� ����� "; break;
	case WSAECONNRESET:   msgText = "WSAECONNRESET";  return "����� ������������� "; break;
	case WSAENOBUFS:      msgText = "WSAENOBUFS";  return "�� ������� ������ ��� �������"; break;
	case WSAEISCONN:      msgText = "WSAEISCONN";  return "����� ��� ���������"; break;
	case WSAENOTCONN:     msgText = "WSAENOTCONN";  return "����� �� ���������"; break;
	case WSAESHUTDOWN:    msgText = "WSAESHUTDOWN";  return "������ ��������� send: ����� �������� ������"; break;
	case WSAETIMEDOUT:    msgText = "WSAETIMEDOUT";  return "���������� ���������� ��������  �������"; break;
	case WSAECONNREFUSED:  msgText = "WSAECONNREFUSED"; return "���������� ���������  "; break;
	case WSAEHOSTDOWN:    msgText = "WSAEHOSTDOWN";   return "���� � ����������������� ���������"; break;
	case WSAEHOSTUNREACH:  msgText = "WSAEHOSTUNREACH"; return "��� �������� ��� ����� ��� �������� ��� ����� "; break;
	case WSAEPROCLIM:    msgText = "WSAEPROCLIM";  return "������� ����� ��������� "; break;
	case WSASYSNOTREADY:    msgText = "WSASYSNOTREADY";  return "���� �� ��������  "; break;
	case WSAVERNOTSUPPORTED:  msgText = "WSAVERNOTSUPPORTED";    return "������ ������ ���������� "; break;
	case WSANOTINITIALISED:   msgText = "WSANOTINITIALISED";   return "�� ��������� ������������� WS2_32.DLL"; break;
	case WSAEDISCON:    msgText = "WSAEDISCON";  return "����������� ����������"; break;
	case WSATYPE_NOT_FOUND:    msgText = "WSATYPE_NOT_FOUND";  return "����� �� ������ "; break;
	case WSAHOST_NOT_FOUND:   msgText = "WSAHOST_NOT_FOUND";   return "���� �� ������"; break;
	case WSATRY_AGAIN:    msgText = "WSATRY_AGAIN";  return "������� ����� ��������� "; break;
	case WSANO_RECOVERY:    msgText = "WSANO_RECOVERY";  return "������� ����� ��������� "; break;
	case WSANO_DATA:    msgText = "WSANO_DATA";  return "��� ������ ������������ ���� "; break;
	case WSA_INVALID_HANDLE:    msgText = "WSA_INVALID_HANDLE";  return "��������� ���������� �������  � �������   "; break;
	case WSA_INVALID_PARAMETER:   msgText = "WSA_INVALID_PARAMETER";   return "���� ��� ����� ���������� � �������   "; break;
	case WSA_IO_INCOMPLETE:    msgText = "WSA_IO_INCOMPLETE";  return "������ �����-������ �� � ���������� ���������"; break;
	case WSA_IO_PENDING:    msgText = "WSA_IO_PENDING";  return "�������� ���������� �����  "; break;
	case WSA_NOT_ENOUGH_MEMORY:    msgText = "WSA_NOT_ENOUGH_MEMORY";  return "�� ���������� ������ "; break;
	case WSA_OPERATION_ABORTED:   msgText = "WSA_OPERATION_ABORTED";   return "�������� ���������� "; break;
	case WSASYSCALLFAILURE:  msgText = "WSASYSCALLFAILURE";    return "��������� ���������� ���������� ������ "; break;
	default: msgText = "***ERROR***"; break;
	};
	return msgText;
};
string SetErrorMsgText(string msgText, int code)
{
	return msgText + GetErrorMsgText(code);
};
