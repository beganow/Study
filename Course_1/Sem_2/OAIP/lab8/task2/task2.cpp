#include <iostream>
int kvadr(int n, ...);
using namespace std;

void main()
{
	setlocale(LC_ALL, "RUS");
	int a, b, c, d, e, f;
	cout << "Введите 6 любых чисел: ";
	cin >> a>>b>>c>>d>>e>>f;

	kvadr(6, a, b, c, d, e, f);
}

int kvadr(int n, ...)
{
	bool t;
	int * p = &n;
	for (int i = 1;i <= n;i++)
	{
		t = false;
		int a = *(++p);
		for (int j = 1;j <= a;j++)
			if (j * j == a) 
			{
				t = true;
				break;
			}
		if (t==true) cout << a << " ";
	}

	return 0;
}
