#include <fstream>
#include <iostream>
#include <string>
using namespace std;
void main()
{
    setlocale(LC_ALL, "rus");
    char buff[50],str[50];
    int n,ans=0;
    cout << "Введите кол-во строк: ";
    cin >> n;
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
            int r=-1;
            while (!fin.eof())
            {
                r++;
                fin.getline(str,50);
                if (r > 2)
                {
                    cout << str << endl;
                    
                }
                if (r==n-1)
                    ans=strlen(str);
            }
            cout << ans;
        }
    fin.close();
 

 }
