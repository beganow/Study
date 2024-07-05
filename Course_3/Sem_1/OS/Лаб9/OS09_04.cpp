#include <windows.h>
#include <iostream>
#include <fstream>
#include <string>

BOOL printWatchRowFileTxt(LPWSTR FileName, DWORD mlsec) {
    std::wifstream file(FileName);

    if (!file.is_open()) {
        std::wcerr << L"Error opening file." << std::endl;
        return FALSE;
    }

    std::wstring line;
    DWORD initialRows = 0;

    // Подсчитать начальное количество строк
    while (std::getline(file, line)) {
        ++initialRows;
    }

    file.close();

    DWORD startTime = GetTickCount();

    do {
        Sleep(1000); // Подождать 1 секунду перед проверкой изменений

        file.open(FileName);

        if (!file.is_open()) {
            std::wcerr << L"Error opening file." << std::endl;
            return FALSE;
        }

        DWORD currentRows = 0;

        // Подсчитать текущее количество строк
        while (std::getline(file, line)) {
            ++currentRows;
        }

        file.close();

        if (currentRows != initialRows) {
            std::wcout << L"File '" << FileName << L"' has changed. New row count: " << currentRows << std::endl;
            initialRows = currentRows; // Обновить исходное количество строк
        }

    } while ((GetTickCount() - startTime) < mlsec);

    return TRUE;
}

int main() {
    setlocale(LC_ALL, "ru");
    LPWSTR FileName = const_cast <LPWSTR>(L"D:\\OS\\Лаб9\\OS09_01.txt"); // Имя файла для отслеживания изменений
    DWORD mlsec = 60000; // Время в миллисекундах (например, 60000 мс = 60 секунд)

    if (printWatchRowFileTxt(FileName, mlsec)) {
        std::wcout << L"Monitoring completed." << std::endl;
    }
    else {
        std::wcerr << L"Error during monitoring." << std::endl;
    }

    return 0;
}