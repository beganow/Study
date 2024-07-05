#include <iostream>
#include <fstream>
#include <vector>
#include <Windows.h>
#include <string>

BOOL delRowFileTxt(LPWSTR FileName, DWORD row)
{
    std::wifstream inputFile(FileName);
    if (!inputFile)
    {
        std::wcout << L"Ошибка при открытии файла: " << FileName << std::endl;
        return FALSE;
    }

    std::vector<std::wstring> lines;
    std::wstring line;
    DWORD currentRow = 1;

    // Читаем строки из файла и сохраняем их в векторе
    while (std::getline(inputFile, line))
    {
        if (currentRow != row)
        {
            lines.push_back(line);
        }
        currentRow++;
    }

    inputFile.close();

    std::wofstream outputFile(FileName, std::ios::trunc);
    if (!outputFile)
    {
        std::wcout << L"Ошибка при открытии файла для записи: " << FileName << std::endl;
        return FALSE;
    }

    // Записываем строки обратно в файл
    for (const auto& line : lines)
    {
        outputFile << line << std::endl;
    }

    outputFile.close();

    return TRUE;
}

int main()
{
    LPWSTR fileName = const_cast<LPWSTR>(L"D:\\OS\\Лаб9\\OS09_01.txt");

    // Удаляем строки 1, 3, 8, 10 из файла
    std::vector<DWORD> rowsToDelete = { 1, 3, 8, 10 };
    for (const auto& row : rowsToDelete)
    {
        if (!delRowFileTxt(fileName, row))
        {
            return 1;
        }
    }
    return 0;
}