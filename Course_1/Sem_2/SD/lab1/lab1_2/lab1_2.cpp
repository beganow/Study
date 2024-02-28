#include <iostream>
using namespace std;

union
{
	short int name1;
	int name2;
	long int name3;
} myUnion;

int main()
{
	myUnion.name2 = 22;
	cout << myUnion.name2 << endl;
	myUnion.name3 = 222222222;
	cout << myUnion.name3 << endl;
	cout << myUnion.name2 << endl; // снова обращаемся к name1
}
