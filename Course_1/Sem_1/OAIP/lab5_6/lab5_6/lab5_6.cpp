﻿// lab5_6.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <iomanip>

int main()
{
    setlocale(LC_CTYPE, "russian");
    using namespace std;
    int k;
    puts("Здравствуйте, как у вас дела?(1-хорошо, 2-плохо)");
    std::cin >> k;
    switch (k)
    {
    case 1:puts("Какие выберете секции?(1-футбол,2-баскетбол, 3 -волейбол)"); break;
        std::cin >> k;
        switch (k)
        {
        case 1:puts("Вы уверены в своём выборе ?"); break;
        case 2:puts("Как хорошо вы владеете навыками спорта ?"); break;
        case 3:puts("Хороший выбор"); break;
        }
        break;
    case 2:puts("Полезно заниматься спортом"); break;
    default:puts("Некорректный вариант"); break;

}
        return 0;
}
// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
