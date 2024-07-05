#include <iostream>
#include <windows.h>
#include <process.h>

// Функция для процесса OS03_02_1
PROCESS_INFORMATION Process1Function(TCHAR* pro) {
    // Создаем первый дочерний процесс (OS03_02_1)
    STARTUPINFO si1 = {};
    PROCESS_INFORMATION pi1 = {};
    TCHAR* text = pro;
    if (CreateProcess(NULL, text, NULL, NULL, FALSE, 0, NULL, NULL, &si1, &pi1)) {
        // Создание прошло успешно
        CloseHandle(pi1.hProcess);
        CloseHandle(pi1.hThread);
    }
    else {
        std::cerr << "Ошибка создания процесса OS03_02_1." << std::endl;
        throw "error in procces";
    }
    return pi1;
}


int main() {
    try {
        TCHAR exe1com[] = L"OS03_02_1";
        TCHAR exe2com[] = L"OS03_02_2";
        PROCESS_INFORMATION pi1 = Process1Function(exe1com);
        PROCESS_INFORMATION pi2 = Process1Function(exe2com);
       // PROCESS_INFORMATION pi2 = Process1Function(L"OS03_02_2");
        for (int i = 0; i < 100; i++)
        {
            std::cout << "OS03_02: Iteration " << i << ", Process ID: " << _getpid() << std::endl;
            Sleep(1000); // Подождать 1 секунду
        }
        // Ожидание завершения обоих дочерних процессов
        WaitForSingleObject(pi1.hProcess, INFINITE);
        WaitForSingleObject(pi2.hProcess, INFINITE);
    }
    catch (EXCEPINFO e)
    {
        std::cout << e.dwHelpContext << std::endl;
    }

  

    return 0;
}
