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

		SOCKADDR_IN serv;
		serv.sin_family = AF_INET;
		serv.sin_port = htons(2000);
		serv.sin_addr.s_addr = inet_addr("127.0.0.1");

		if (bind(sS, (LPSOCKADDR)&serv, sizeof(serv)) == SOCKET_ERROR)
			throw SetErrorMsgText("bind:", WSAGetLastError());

		if (listen(sS, SOMAXCONN) == SOCKET_ERROR)
			throw SetErrorMsgText("listen:", WSAGetLastError());

		SOCKET cS;
		SOCKADDR_IN clnt;

		int lclnt = sizeof(clnt);
		while (true) {
			if ((cS = accept(sS, (sockaddr*)&clnt, &lclnt)) == INVALID_SOCKET)
				throw SetErrorMsgText("accept:", WSAGetLastError());


			cout << "Подключился клиент " << inet_ntoa(clnt.sin_addr) << ":" << ntohs(clnt.sin_port) << endl;

			int lobuf;
			int lc = sizeof(clnt);
			char ibuf[50];
			int lb = 0;
			for (int i = 0; i < 1000; i++)
			{

				if ((lb = recvfrom(cS, ibuf, sizeof(ibuf), NULL, (sockaddr*)&clnt, &lc)) == SOCKET_ERROR)
					throw SetErrorMsgText("recv:", WSAGetLastError());
				//................................................................
				cout << ibuf << endl;

				if ((lobuf = sendto(cS, ibuf, strlen(ibuf) + 1, NULL, (sockaddr*)&clnt, sizeof(clnt))) == SOCKET_ERROR)
					throw  SetErrorMsgText("recv:", WSAGetLastError());
	
			}
			closesocket(cS);
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

string GetErrorMsgText(int code) // cформировать текст ошибки
{
	string msgText;
	switch (code) // проверка кода возврата
	{
	case WSAEINTR:      msgText = "WSAEINTR";  return "Работа функции прервана "; break;
	case WSAEBADF:        msgText = "WSAEBADF";  return "File handle is not valid"; break;
	case WSAEACCES:      msgText = "WSAEACCES";   return "Разрешение отвергнуто"; break;
	case WSAEFAULT:     msgText = "WSAEFAULT";    return "Ошибочный адрес"; break;
	case WSAEINVAL:     msgText = "WSAEINVAL";    return "Ошибка в аргументе "; break;
	case WSAEMFILE:      msgText = "WSAEMFILE";   return "Слишком много файлов открыто"; break;
	case WSAEWOULDBLOCK:  msgText = "WSAEWOULDBLOCK";  return "Ресурс временно недоступен"; break;
	case WSAEINPROGRESS:   msgText = "WSAEINPROGRESS"; return "Операция в процессе развития"; break;
	case WSAEALREADY:      msgText = "WSAEALREADY"; return "Операция уже выполняется "; break;
	case WSAENOTSOCK:      msgText = "WSAENOTSOCK"; return "Сокет задан неправильно   "; break;
	case WSAEDESTADDRREQ:  msgText = "WSAEDESTADDRREQ"; return "Требуется адрес расположения "; break;
	case WSAEMSGSIZE:     msgText = "WSAEMSGSIZE";  return "Сообщение слишком длинное "; break;
	case WSAEPROTOTYPE:    msgText = "WSAEPROTOTYPE"; return "Неправильный тип протокола для сокета "; break;
	case WSAENOPROTOOPT:   msgText = "WSAENOPROTOOPT"; return "Ошибка в опции протокола"; break;
	case WSAEPROTONOSUPPORT: msgText = "WSAEPROTONOSUPPORT"; return "Протокол не поддерживается"; break;
	case WSAESOCKTNOSUPPORT: msgText = "WSAESOCKTNOSUPPORT"; return "Тип сокета не поддерживается "; break;
	case WSAEOPNOTSUPP:     msgText = "WSAEOPNOTSUPP"; return "Операция не поддерживается "; break;
	case WSAEPFNOSUPPORT: msgText = "WSAEPFNOSUPPORT";  return "Тип протоколов не поддерживается "; break;
	case WSAEAFNOSUPPORT:  msgText = "WSAEAFNOSUPPORT"; return "Тип адресов не поддерживается протоколом"; break;
	case WSAEADDRINUSE:    msgText = "WSAEADDRINUSE"; return "Адрес уже используется "; break;
	case WSAEADDRNOTAVAIL: msgText = "WSAEADDRNOTAVAIL"; return "Запрошенный адрес не может быть использован"; break;
	case WSAENETDOWN:      msgText = "WSAENETDOWN"; return "Сеть отключена "; break;
	case WSAENETUNREACH:   msgText = "WSAENETUNREACH"; return "Сеть не достижима"; break;
	case WSAENETRESET:     msgText = "WSAENETRESET"; return "Сеть разорвала соединение"; break;
	case WSAECONNABORTED: msgText = "WSAECONNABORTED";  return "Программный отказ связи "; break;
	case WSAECONNRESET:   msgText = "WSAECONNRESET";  return "Связь восстановлена "; break;
	case WSAENOBUFS:      msgText = "WSAENOBUFS";  return "Не хватает памяти для буферов"; break;
	case WSAEISCONN:      msgText = "WSAEISCONN";  return "Сокет уже подключен"; break;
	case WSAENOTCONN:     msgText = "WSAENOTCONN";  return "Сокет не подключен"; break;
	case WSAESHUTDOWN:    msgText = "WSAESHUTDOWN";  return "Нельзя выполнить send: сокет завершил работу"; break;
	case WSAETIMEDOUT:    msgText = "WSAETIMEDOUT";  return "Закончился отведенный интервал  времени"; break;
	case WSAECONNREFUSED:  msgText = "WSAECONNREFUSED"; return "Соединение отклонено  "; break;
	case WSAEHOSTDOWN:    msgText = "WSAEHOSTDOWN";   return "Хост в неработоспособном состоянии"; break;
	case WSAEHOSTUNREACH:  msgText = "WSAEHOSTUNREACH"; return "Нет маршрута для хоста Нет маршрута для хоста "; break;
	case WSAEPROCLIM:    msgText = "WSAEPROCLIM";  return "Слишком много процессов "; break;
	case WSASYSNOTREADY:    msgText = "WSASYSNOTREADY";  return "Сеть не доступна  "; break;
	case WSAVERNOTSUPPORTED:  msgText = "WSAVERNOTSUPPORTED";    return "Данная версия недоступна "; break;
	case WSANOTINITIALISED:   msgText = "WSANOTINITIALISED";   return "Не выполнена инициализация WS2_32.DLL"; break;
	case WSAEDISCON:    msgText = "WSAEDISCON";  return "Выполняется отключение"; break;
	case WSATYPE_NOT_FOUND:    msgText = "WSATYPE_NOT_FOUND";  return "Класс не найден "; break;
	case WSAHOST_NOT_FOUND:   msgText = "WSAHOST_NOT_FOUND";   return "Хост не найден"; break;
	case WSATRY_AGAIN:    msgText = "WSATRY_AGAIN";  return "Слишком много процессов "; break;
	case WSANO_RECOVERY:    msgText = "WSANO_RECOVERY";  return "Слишком много процессов "; break;
	case WSANO_DATA:    msgText = "WSANO_DATA";  return "Нет записи запрошенного типа "; break;
	case WSA_INVALID_HANDLE:    msgText = "WSA_INVALID_HANDLE";  return "Указанный дескриптор события  с ошибкой   "; break;
	case WSA_INVALID_PARAMETER:   msgText = "WSA_INVALID_PARAMETER";   return "Один или более параметров с ошибкой   "; break;
	case WSA_IO_INCOMPLETE:    msgText = "WSA_IO_INCOMPLETE";  return "Объект ввода-вывода не в сигнальном состоянии"; break;
	case WSA_IO_PENDING:    msgText = "WSA_IO_PENDING";  return "Операция завершится позже  "; break;
	case WSA_NOT_ENOUGH_MEMORY:    msgText = "WSA_NOT_ENOUGH_MEMORY";  return "Не достаточно памяти "; break;
	case WSA_OPERATION_ABORTED:   msgText = "WSA_OPERATION_ABORTED";   return "Операция отвергнута "; break;
	case WSASYSCALLFAILURE:  msgText = "WSASYSCALLFAILURE";    return "Аварийное завершение системного вызова "; break;
	default: msgText = "***ERROR***"; break;
	};
	return msgText;
};
string SetErrorMsgText(string msgText, int code)
{
	return msgText + GetErrorMsgText(code);
};
