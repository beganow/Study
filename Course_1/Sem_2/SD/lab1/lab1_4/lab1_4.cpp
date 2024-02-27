#include <iostream>
using namespace std;

enum levelsName { parking, bank, insurance, exchangee, fitnesroom, Restaurant };

int main()
{
	setlocale(LC_ALL, "rus");

	int floor = parking; // номер этажа– выбор пользователя
	int exitOrNot = 9; // выйти или нет

	while (exitOrNot == 9)
	{
		cout << "Номер этажа (0,1,2,3,4,5): ";
		cin >> floor;

		switch (floor)
		{
		case(parking):
			cout << "\a\a\aВы в паркинге!\n\n";
			break;

		case(bank):
			cout << "\a\a\aПервый этаж!";
			cout << "\n Здесь находится отделение Беларусбанк.\n\n";
			break;

		case(insurance):
			cout << "\a\a\aВторой этаж!";
			cout << "\n Страховая компания Белгосстрах.\n\n";
			break;

		case(exchangee):
			cout << "\a\a\aТретий этаж!";
			cout << "\n Белорусская валютно-фондовая биржа.\n\n";
			break;

		case(fitnesroom):
			cout << "\a\a\aЧетвёртый этаж!";
			cout << "\n Фитнес центр.\n\n";
			break;

		case(Restaurant):
			cout << "\a\a\aПятый этаж!";
			cout << "\nРесторан «7-е небо».\n\n";
			break;

		default: cout << "\a\a\aОшибка!\n\n";
		}

		cout << "Выйти из лифта - нажмите 0.\n";
		cout << "Выбрать другой этаж - нажмите 9: ";
		do
		{
			cin >> exitOrNot;
		} while (exitOrNot != 0 && exitOrNot != 9);
		cout << endl;
	}
	return 0;
}

