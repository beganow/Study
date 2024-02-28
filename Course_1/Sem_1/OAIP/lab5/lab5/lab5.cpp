#include <iostream>
    int main(){
       
            setlocale(LC_CTYPE, "Russian" );
            using namespace std;
           int a, b, c;
            cout << "введите число=";
            cin >> a;
            b = a / 10;
            c = a % 10;
            if ((b == 1) || (b == 9)|| (a == 1) || (a == 9))
                cout << "Имеется";
            else
                cout << "не имеется";
        
}


