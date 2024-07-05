#include <iostream>
#include <Windows.h>
#include <ctime>
#include <atomic>
#include <thread>

std::atomic<bool> flag(false);

bool isPrime(int n)
{

    if (n == 1 || n == 0) return false;

   
    for (int i = 2; i < n; i++)
    {
      
        if (n % i == 0) return false;
    }
  
    return true;
}

int freeCycle() {

    for (int i = 1; !flag.load(); i++)
    {
    
        if (isPrime(i))
        {
            std::cout << "Простое число: " << i << "\n";
        }
    }
    return 0;
}

int main()
{

    setlocale(LC_CTYPE, "rus");

    std::thread Fthread(freeCycle);

    HANDLE htimer = OpenWaitableTimer(TIMER_ALL_ACCESS, FALSE, L"smwTimer");
    WaitForSingleObject(htimer, INFINITE);

    flag.store(true);

    CloseHandle(htimer);
    Fthread.join();

    system("pause");

    return 0;
}
