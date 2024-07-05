#include <iostream>
#include <ctime>

int main() {
    setlocale(LC_ALL, "Russian");
    std::time_t now = std::time(nullptr);
    std::tm localTime{};
    localtime_s(&localTime, &now);

    char dateTimeString[20];
    std::strftime(dateTimeString, sizeof(dateTimeString), "%d.%m.%Y %H:%M:%S", &localTime);

    std::cout << "Текущая локальная дата и время: " << dateTimeString << std::endl;

    return 0;
}