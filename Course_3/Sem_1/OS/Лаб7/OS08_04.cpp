#include <iostream>
#include <Windows.h>
#include <ctime>
#define SECOND 10000000

int main()
{
    HANDLE htimer = CreateWaitableTimer(NULL, FALSE, L"smwTimer");
    long long it1 = -60 * SECOND;
    std::cout << "main-1 " << "\n";
    if (!SetWaitableTimer(htimer, (LARGE_INTEGER*)&it1, 10000, NULL, NULL, FALSE)) throw "Error SetWaitableTimer";

    LPCWSTR an1 = L"D:\\OS\\Лаб7\\OS08_04_X\\x64\\Debug\\OS08_04_X.exe";
    STARTUPINFO si1;
    PROCESS_INFORMATION pi1;
    ZeroMemory(&si1, sizeof(STARTUPINFO));
    si1.cb = sizeof(STARTUPINFO);

    if (CreateProcess(an1, NULL, NULL, NULL, FALSE, CREATE_NEW_CONSOLE, NULL, NULL, &si1, &pi1)) {
        std::cout << "-- Process OS07_04x-1 created \n";
    }
    else {
        std::cout << "-- Process OS07_04x-1 not created \n";
    }
    LPCWSTR an2 = L"D:\\OS\\Лаб7\\OS08_04_X\\x64\\Debug\\OS08_04_X.exe";
    STARTUPINFO si2;
    PROCESS_INFORMATION pi2;
    ZeroMemory(&si2, sizeof(STARTUPINFO));
    si2.cb = sizeof(STARTUPINFO);

    if (CreateProcess(an2, NULL, NULL, NULL, FALSE, CREATE_NEW_CONSOLE, NULL, NULL, &si2, &pi2)) {
        std::cout << "-- Process OS07_04x-2 created \n";
    }
    else {
        std::cout << "-- Process OS07_04x-2 not created \n";
    }


    std::cout << "main-2" << "\n";

    WaitForSingleObject(pi1.hProcess, INFINITE);
    WaitForSingleObject(pi2.hProcess, INFINITE);

    CloseHandle(pi1.hProcess);
    CloseHandle(pi1.hThread);
    CloseHandle(pi2.hProcess);
    CloseHandle(pi2.hThread);

    CloseHandle(htimer);

    system("pause");
    return 0;
}
