﻿// lab14_1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//
#include <iostream>
#include <stdio.h>
#include <conio.h>
#include <locale.h>
#include <math.h>
using namespace std;

int main()
{
    setlocale(LC_ALL, "Russian");
    const int ai = 10;
    const int aj = 10;
    int S = 0, P = 1;
    int a[ai][aj];
    for (int i = 0; i < ai; i++) {
        for (int j = 0; j < aj; j++) {
            a[i][j] = rand() % 21-10;
        }
    }
    for (int i = 0; i < ai; i++) {
        for (int j = 0; j < aj; j++) {
            cout << a[i][j] << "\t";
        }
        cout << endl;
    }
    
    for (int i = 0; i < ai; i++) {
        for (int j = 0; j < aj; j++) {
            if (((abs(a[i][j]) % 2 == 1)) && ((abs(a[i][j]) < i)) && (a[i][j] < 0)) {
                S += a[i][j];
                P = P * a[i][j];
            } 
        }
    }
    cout << "Сумма:" << S << endl;
    cout << "Произведение:" << P << endl;
   
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
