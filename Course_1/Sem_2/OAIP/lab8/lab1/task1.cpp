#include <iostream>
#include <cmath>
using namespace std;
float f1(float t)
{
	return exp(t) - 3 - 1 / t;
}
float f2(float t)
{
	return 0.2 - pow(t, 2);
}
float resh(float a,float b, float x,float (*f)(float ))
{
	float  e = 1e-3;
	while (b-a >  e)
	{
		x = (a + b) / 2;
		if (f(x) * f(b) < 0) { a = x; }
		else { b = x; }
	}
	return  (a+b)/2;
}
int main()
{
	setlocale(LC_ALL, "RUS");
	float a = 8, b = 12, x = 0;
	cout << "Первый пример "<<resh(a,b,x,f1)<<endl;
	cout << "Второй пример "<<resh(a,b,x,f2);
}