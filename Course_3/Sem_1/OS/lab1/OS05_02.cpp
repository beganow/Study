#include <iostream>
#include <windows.h>
#include <string>

DWORD_PTR CountMask(int affinityMask) {
    DWORD_PTR MaskBit = 0;
    for (int i = 0; i < affinityMask; i++) {
        MaskBit |= (static_cast<unsigned long long>(1) << i);
    }
    return MaskBit;
}

int SetPriority(int affinityMask, int priorityClass1, int priorityClass2) {

    std::cout << "P1 (Affinity Mask): " << affinityMask << std::endl;
    std::cout << "P2 (Priority Class for Child 1): " << priorityClass1 << std::endl;
    std::cout << "P3 (Priority Class for Child 2): " << priorityClass2 << std::endl;


    DWORD_PTR Mask = CountMask(affinityMask);
    DWORD_PTR processInfo1 = static_cast<DWORD_PTR>(priorityClass1);
    DWORD_PTR processInfo2 = static_cast<DWORD_PTR>(priorityClass2);

    STARTUPINFO si1;
    PROCESS_INFORMATION pi1;

    ZeroMemory(&si1, sizeof(si1));
    si1.cb = sizeof(si1);
    ZeroMemory(&pi1, sizeof(pi1));

    STARTUPINFO si2;
    PROCESS_INFORMATION pi2;

    ZeroMemory(&si2, sizeof(si2));
    si2.cb = sizeof(si2);
    ZeroMemory(&pi2, sizeof(pi2));

    LPCWSTR path1 = L"D:\\OS\\Lab5\\OS05_02x\\x64\\Debug\\OS05_02x.exe";
    LPCWSTR path2 = L"D:\\OS\\Lab5\\OS05_02x\\x64\\Debug\\OS05_02x.exe";

    SetProcessAffinityMask(GetCurrentProcess(), Mask);

    // Запуск первого дочернего процесса с заданными параметрами
    if (!CreateProcess(path1, const_cast<LPWSTR>(L""), NULL, NULL, FALSE, CREATE_NEW_CONSOLE | processInfo1, NULL, NULL, &si1, &pi1)) {
        std::cerr << "Error creating child process 1." << GetLastError() << std::endl;
        return 1;
    }

    // Запуск второго дочернего процесса с заданными параметрами
    if (!CreateProcess(path2, const_cast<LPWSTR>(L""), NULL, NULL, FALSE, CREATE_NEW_CONSOLE | processInfo2, NULL, NULL, &si1, &pi1)) {
        std::cerr << "Error creating child process 2." << GetLastError() << std::endl;
        return 1;
    }
    

    // Ожидание завершения обоих дочерних процессов
    WaitForSingleObject(pi1.hProcess, INFINITE);
    WaitForSingleObject(pi2.hProcess, INFINITE);

    CloseHandle(pi1.hProcess);
    CloseHandle(pi1.hThread);
    CloseHandle(pi2.hProcess);
    CloseHandle(pi2.hThread);

    return 0;
}

int main() {
    int affinityMask, priorityClass1, priorityClass2;

    std::cout << "Normal = 32 " << std::endl;
    std::cout << "Below normal = 16384 " << std::endl;
    std::cout << "High = 128 " << std::endl;

    // Ввод значений с клавиатуры
    std::cout << "Enter count processors: ";
    std::cin >> affinityMask;
    std::cout << "Enter the Priority for Child 1: ";
    std::cin >> priorityClass1;
    std::cout << "Enter the Priority for Child 2: ";
    std::cin >> priorityClass2;

    // Вызов функции SetPriority с введенными значениями
    return SetPriority(affinityMask, priorityClass1, priorityClass2);
}