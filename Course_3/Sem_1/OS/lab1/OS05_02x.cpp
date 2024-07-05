#include <iostream>
#include <Windows.h>
#include <chrono>
#include <ctime>


int main() {

    setlocale(LC_CTYPE, "rus");
    for (int i = 1; i <= 1000; ++i) {        

        // Получаем информацию о текущем процессе и потоке
        DWORD currentProcessId = GetCurrentProcessId();
        DWORD currentThreadId = GetCurrentThreadId();
        int currentProcessPriority = GetPriorityClass(GetCurrentProcess());
        int currentThreadPriority = GetThreadPriority(GetCurrentThread());
        int currentThreadProcessor = GetCurrentProcessorNumber();

        // Выводим информацию на консоль
        std::cout << "Номер итерации: " << i << std::endl;
        std::cout << "Идентификатор процесса: " << currentProcessId << std::endl;
        std::cout << "Идентификатор потока: " << currentThreadId << std::endl;
        std::cout << "Класс приоритета процесса: " << currentProcessPriority << std::endl;
        std::cout << "Приоритет потока: " << currentThreadPriority << std::endl;
        std::cout << "Номер назначенного процессора: " << currentThreadProcessor << std::endl;
        std::cout << std::endl;
        Sleep(2);
    }

    auto currentTime = std::chrono::system_clock::now();

    // Преобразуем текущее время в миллисекунды
    auto milliseconds = std::chrono::duration_cast<std::chrono::milliseconds>(currentTime.time_since_epoch()).count();

    int millisecondsPart = milliseconds % 1000;
    int seconds = (milliseconds / 1000) % 60;
    int minutes = (milliseconds / (1000 * 60)) % 60;

    // Выводим время в формате "часы:минуты:секунды:милисекунды"
    std::cout << minutes << ":" << seconds << ":" << millisecondsPart << std::endl;

    Sleep(5000);

    return 0;
}
