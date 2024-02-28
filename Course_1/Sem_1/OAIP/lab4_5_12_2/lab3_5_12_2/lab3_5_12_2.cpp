#include <iostream>
#include <iomanip> 
int main()
{
	setlocale(LC_CTYPE, "Russian");
	using namespace std;
	int k, l ,b,c,n;
	cout << "введите число   "; cin >> k;
	c = k % 10;
	b = (k / 10);
	b= b % 10;
	l = k / 100;
	n = 100 * c + 10 * b + l;
	cout << n; 
}

