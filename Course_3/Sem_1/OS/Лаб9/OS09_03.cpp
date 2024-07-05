#include <iostream>
#include <fstream>
#include <vector>
#include <Windows.h>
#include <string>

BOOL insRowFileTxt(LPWSTR FileName, LPWSTR str, DWORD row)
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
        if (currentRow == row)
        {
            lines.push_back(str);  // Вставляем новую строку
        }
        lines.push_back(line);
        currentRow++;
    }

    inputFile.close();

    // Если строка вставляется в конец файла или после последней строки
    if (row == 0 || row == -1 || row > currentRow)
    {
        lines.push_back(str);
    }

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

    // Вызываем функцию insRowFileTxt четыре раза с разными значениями row
    LPWSTR str1 = const_cast<LPWSTR>(L"New line at the beginning");
    if (!insRowFileTxt(fileName, str1, 1))
    {
        std::wcout << L"Ошибка при вставке строки." << std::endl;
        return 1;
    }

    LPWSTR str2 = const_cast<LPWSTR>(L"New line at the end");
    if (!insRowFileTxt(fileName, str2, -1))
    {
        std::wcout << L"Ошибка при вставке строки." << std::endl;
        return 1;
    }

    LPWSTR str3 = const_cast<LPWSTR>(L"New line at row 5");
    if (!insRowFileTxt(fileName, str3, 5))
    {
        std::wcout << L"Ошибка при вставке строки." << std::endl;
        return 1;
    }

    LPWSTR str4 = const_cast<LPWSTR>(L"New line at row 7");
    if (!insRowFileTxt(fileName, str4, 7))
    {
        std::wcout << L"Ошибка при вставке строки." << std::endl;
        return 1;
    }

    return 0;
}