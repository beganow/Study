#include <iostream>
#include <windows.h>
#include <io.h>
#include <fcntl.h>

int main() {
    // Устанавливаем кодировку консоли на UTF-8
    _setmode(_fileno(stdout), _O_U16TEXT);

    while (true) {
        DWORD processId = GetCurrentProcessId();
        std::wcout << L"Идентификатор процесса: " << processId << std::endl;

        Sleep(1000);
    }

    return 0;
}