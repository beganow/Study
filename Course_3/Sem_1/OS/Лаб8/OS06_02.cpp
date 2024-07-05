#include <iostream>

int main() {
    setlocale(LC_ALL, "ru");
    for (long long i = 0; i < 1e9; i++) {
       
        std::cout << "Итерация номер " << i << std::endl;
    }
    std::cout << "Завершение цикла" << std::endl;
    return 0;
}