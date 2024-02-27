#include <conio.h>
#include <stdio.h>

union floatint {
	float f;
	int i;
};

void main() {
	union floatint u = { 10.5 };
	printf(" u.f = %f\n", u.f);
	printf(" u.i = %d\n", u.i);
	u.i = 7;
	printf("\n u.f = %f\n", u.f);
	printf(" u.i = %d\n", u.i);
}

