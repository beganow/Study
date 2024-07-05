
#include <iostream>
#include <process.h>
#include <windows.h>

int main()
{
    Sleep(10);
    for (int i = 0; i < 125; ++i) {
        std::cout << "OS03_02_2: Iteration " << i << ", Process ID: " << _getpid() << std::endl;
        Sleep(1000); // Подождать 1 секунду
    }
}

