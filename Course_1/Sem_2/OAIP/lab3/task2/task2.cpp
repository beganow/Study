#include <fstream>
#include <iostream>
#include <string>
using namespace std;
void main()
{
    setlocale(LC_ALL, "rus");
    char buff[50], str[50];
    int n, ans = 0;
    ofstream fout("t.txt");
  
        cin >> str;

        fout << str;
        fout << "\n";
    
    fout.close();
    ifstream fin("t.txt");
    if (!fin.is_open())
        cout << "Файл не может быть открыт!\n";
    else
    {
        fin.getline(str, 50);
        for (int i = 0;i < strlen(str);i++)
        {
            if ((int)str[i] > 47 && (int)str[i] < 58) cout << str[i];
            if ((int)str[i] > 47 && (int)str[i] < 58 && (int)str[i + 1]>57) cout << endl;
            if ((int)str[i] > 47 && (int)str[i] < 58 && (int)str[i + 1]<48) cout << endl;
        }

    }
    fin.close();

}
