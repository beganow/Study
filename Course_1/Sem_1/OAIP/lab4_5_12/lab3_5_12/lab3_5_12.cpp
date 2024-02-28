#include <iomanip> 
#include <iostream>
int main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	char c, probel; probel = ' ';
	cout << "Введите символ "; cin >> c;
	cout << setw(35) << setfill(probel) << probel;
	cout << setw(1) << setfill(c) << c << endl;
	cout << setw(35) << setfill(probel) << probel;
	cout << setw(1) << setfill(c) << c << endl;
	cout << setw(35) << setfill(probel) << probel;
	cout << setw(1) << setfill(c) << c << endl;
	cout << setw(35) << setfill(probel) << probel;
	cout << setw(1) << setfill(c) << c << endl;
	cout << setw(31) << setfill(probel) << probel;
	cout << setw(9) << setfill(c) << c << endl;
	cout << setw(35) << setfill(probel) << probel;
	cout << setw(1) << setfill(c) << c << endl; 
	cout << setw(35) << setfill(probel) << probel;
	cout << setw(1) << setfill(c) << c << endl;
	cout << setw(35) << setfill(probel) << probel;
	cout << setw(1) << setfill(c) << c << endl;
	cout << setw(35) << setfill(probel) << probel;
	cout << setw(1) << setfill(c) << c << endl;
}
