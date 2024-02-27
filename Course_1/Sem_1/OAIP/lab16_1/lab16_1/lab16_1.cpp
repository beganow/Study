#include <iostream>
using namespace std;

void mass() {
    
    int a[100][100];
    int n, min;
    cin >> n;
    min = 100000;
    for (int i = 1; i <= n; i++)
        for (int j = 1; j <= n; j++)
        {
            cin >> a[i][j];
            if (*(*(a+i)+j) < min)
                min = (*(*(a + i) + j));
        }
    for (int i = 1; i <= n; i++)
        (*(*(a + i) + i)) = min;
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
            cout << a[i][j] << " ";
        cout << endl;
    }
}
void kod() {
    const int N = 4;
    int  A[N][N];
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < N; j++)
        {
            cin >> A[i][j];
        }
    }
    for (int i = 0; i < N; i++)
    {
        bool found = true;
        for (int j = 0; j < N; j++) 
            if (A[i][j] != A[j][i])
            {
                found = false;
                break;
            }
            if (found==true)             
       cout << "k = " << i << endl;
    }
    system("pause");
}

int main()
{   setlocale(LC_ALL, "ru");
    int choice;
    do
    {
        cout << "Выберите номер пункта из 4 задания" << endl;
        cout << "1 : Первое задание " << endl;
        cout << "2 : Второе задание " << endl;
        cout << "3 : Выход" << endl;
        cin >> choice;
        switch (choice)
        {
        case 1: mass();
            break;

        case 2: kod();
            break;

        case 3:
            break;
        default:
            cout << "Введенно некоректное значение" << endl;
            break;

        }
    } while (choice != 3);
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
