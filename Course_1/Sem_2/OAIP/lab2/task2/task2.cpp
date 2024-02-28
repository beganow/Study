#include <fstream>
#include <iostream>
#include <string>
using namespace std;
void main()
{
    setlocale(LC_ALL, "rus");
    char buff[50], str[50];
    int n=6, ans = 0;
    cout << "Введите 6 строк: " << endl;
   
    ofstream fout("t.txt");
    for (int i = 0;i < n; i++)
    {
        cout << "Введите строку под №" << i + 1 << ": " << endl;
        cin >> str;

        fout << str;
        fout << "\n";
    }
    fout.close();
    ifstream fin("t.txt");
    if (!fin.is_open())
        cout << "Файл не может быть открыт!\n";
    else
    {
        while (!fin.eof())
        {
           
            fin.getline(str, 50);
            if (str[0] == 'A') cout << str << endl;
        }
    }
    fin.close();


}
