#include <iostream>
#include <Windows.h>

BOOL printFileInfo(LPCWSTR FileName)
{
    WIN32_FIND_DATA fileData;
    HANDLE hFile = FindFirstFileW(FileName, &fileData);

    if (hFile
 == INVALID_HANDLE_VALUE)
    {
        std::wcout << L"Ошибка при открытии файла: " << FileName << std::endl;
        return FALSE;
    }

    std::wcout << L"Имя файла: " << fileData.cFileName << std::endl;
    std::wcout << L"Тип файла: " << (fileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY ? L"Директория" : L"Файл") << std::endl;
    std::wcout << L"Размер файла: " << fileData.nFileSizeLow << " byte" << std::endl;

    FILETIME creationTime = fileData.ftCreationTime;
    FILETIME lastAccessTime = fileData.ftLastAccessTime;
    FILETIME lastWriteTime = fileData.ftLastWriteTime;

    SYSTEMTIME st;
    FileTimeToSystemTime(&creationTime, &st);
    std::wcout << L"Дата и время создания файла: " << st.wDay << L"." << st.wMonth << L"." << st.wYear << L" " << st.wHour << L":" << st.wMinute << std::endl;

    FileTimeToSystemTime(&lastWriteTime, &st);
    std::wcout << L"Дата и время последнего обновления: " << st.wDay << L"." << st.wMonth << L"." << st.wYear << L" " << st.wHour << L":" << st.wMinute << std::endl;

    FindClose(hFile);
    return TRUE;
}

BOOL printFileTxt(LPCWSTR FileName) {
    FILE* file;
    errno_t err = _wfopen_s(&file, FileName, L"r");

    if (err != 0 || file == nullptr) {
        std::wcout << L"Ошибка при открытии файла: " << FileName << std::endl;
        return FALSE;
    }

    wchar_t buffer[1024];
    while (fgetws(buffer, sizeof(buffer) / sizeof(wchar_t), file)) {
        std::wcout << buffer;
    }

    fclose(file);
    return TRUE;
}

int main() {
    setlocale(LC_ALL,"Russian");
    LPCWSTR fileName = L"D:\\OS\\Лаб9\\OS09_01.txt"; // Используйте двойные обратные слеши или прямые слеши
    if (!printFileInfo(fileName)) {
        return 1;
    }
    std::cout << "Содержимое файла:" << std::endl;
    if (!printFileTxt(fileName)) {
        return 1;
    }

    return 0;
}

