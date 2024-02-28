#include <conio.h>
#include <stdio.h>

union Register32 {
	struct {			//занимает 4 байта
		unsigned char byte1; //занимает 1 байт
		unsigned char byte2; //занимает 1 байт
		unsigned char byte3; //занимает 1 байт
		unsigned char byte4; //занимает 1 байт
	} bytes;
	struct {				//занимает 4 байта
		unsigned short low; 	//занимает 2 байта
		unsigned short high; 	//занимает 2 байта
	} words;
	unsigned dword;      	//без знаковое int  от 0 до 4 294 967 295
};

typedef union Register32 EAX; //синоним

void main() {
	EAX reg;
	reg.dword = 0x0000C0FF;
	printf("    dword \t%08x\n", reg.dword);
	printf("    low word \t%04x\n", reg.words.low);
	printf("    high word \t%04x\n", reg.words.high);
	printf("    byte1 \t%02x\n", reg.bytes.byte1);
	printf("    byte2 \t%02x\n", reg.bytes.byte2);
	printf("    byte3 \t%02x\n", reg.bytes.byte3);
	printf("    byte4 \t%02x\n", reg.bytes.byte4);
}
