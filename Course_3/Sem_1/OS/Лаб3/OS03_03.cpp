#include <iostream>
#include <windows.h>
#include <tlhelp32.h>

int main() {
    setlocale(LC_ALL, "Russian");
    // Создаем объект снимка процессов
    HANDLE snapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
    if (snapshot == INVALID_HANDLE_VALUE) {
        std::cerr << "Ошибка при создании снимка процессов: " << GetLastError() << std::endl;
        return 1;
    }

    // Задаем размер структуры процесса
    PROCESSENTRY32 pe32;
    pe32.dwSize = sizeof(PROCESSENTRY32);

    // Получаем информацию о первом процессе в снимке
    if (!Process32First(snapshot, &pe32)) {
        std::cerr << "Ошибка при чтении информации о процессе: " << GetLastError() << std::endl;
        CloseHandle(snapshot);
        return 1;
    }

    // Выводим информацию о каждом процессе
    do {
        std::cout << "Идентификатор процесса: " << pe32.th32ProcessID << std::endl;
        std::wcout << L"Имя процесса: " << pe32.szExeFile << std::endl;
        std::cout << "------------------------------------" << std::endl;
    } while (Process32Next(snapshot, &pe32));

    // Закрываем снимок процессов
    CloseHandle(snapshot);

    return 0;
}