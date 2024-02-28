#include <fstream>
#include <string>
#include <iostream>

using namespace std;
int main()
{
    int A[5][5], B[5][5], C[5][5];
    int n = 3;
    ifstream fin("A.txt");
    if (!fin.is_open())
    {
        cout << "Файл не может быть открыт!\n";
    }
    else
    {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {

                fin >> A[i][j];

            }
        }

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {

                cout << A[i][j] << " ";

            }
            cout << endl;
        }

        cout << endl;
    }
    fin.close();

    ifstream out;
    string gg = "B.txt";

    out.open(gg);
    if (!out.is_open())
    {
        cout <<"Файл не может быть открыт!\n";
    }
    else
    {
        

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {

                out >> B[i][j];

            }
        }




        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {

                cout << B[i][j] << " ";

            }
            cout << endl;
        }
        cout << endl;

    }
    out.close();
    for (int i = 0; i < n; i++) {            
        for (int j = 0; j < n; j++) {
            C[i][j] = 0;
            for (int t = 0; t < n; t++) {
                C[i][j] += A[i][t] * B[t][j];
            }
        }
    }
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {

            cout << C[i][j] << " ";

        }
        cout << endl;
    }

    ofstream fout("C.txt");
    
    if (!fout.is_open())
    {
        cout << "Файл не может быть открыт!\n";
    }
    else
    {


        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {

                fout << C[i][j] << " ";

            }
            fout<< endl;
        }





    }
    fout.close();

}

