#include <iostream>
#include <vector>

const int PageSize = 4096;  // Размер страницы в байтах

int main() {
    setlocale(LC_ALL, "ru");
    const int NUM_PAGES = 256;
    const int NUM_INTS_PER_PAGE = PageSize / sizeof(int);
    int* memory = new int[NUM_PAGES * NUM_INTS_PER_PAGE];

    // Шаг 2: Заполнение массива последовательностью чисел
    for (int i = 0; i < NUM_PAGES * NUM_INTS_PER_PAGE; ++i) {
        memory[i] = i + 1;
    }

    // Запись 3 первых букв фамилии в 16-ричных числах в кодировке Windows-1251

    memory[0] = 0xCE; // О
    memory[1] = 0xC1; // Б
    memory[2] = 0xCE; // О
    // Поиск в полученной области памяти значения в байте.
    unsigned short pageNumber = static_cast<unsigned short>(memory[0]);
    unsigned short offset = (static_cast<unsigned short>(memory[1]) << 4) | static_cast<unsigned short>(memory[2] >> 4);

    int* value = memory +  pageNumber * NUM_INTS_PER_PAGE + offset;
    std::cout << "Страница: " << pageNumber << ", Смещение: " << offset << ", Значение: " << value << std::endl;
    std::cout << "Цифровое значение адреса : " << *value << std::endl;
    // Шаг 5: Освобождение выделенной памяти
    delete[] memory;

    return 0;
}

/*
    О - 206(10) - CE(16)
    Б - 193(10) - C1(16)
    О - 206(10) - CE(16)
    Страница CE = 206
    206 * 4096 = 843776(10) = 0x0843776 - добавить для перехода на страницу
    Смещение C1C = 3100(10) = 0x00000C1C
    Искомое значение: начало массива + 0x0843776 + 0x00000C1C
*/