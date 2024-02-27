#include <iostream>
using namespace std;
void input(int size);
void output();
void del(int n);
void find(char lastName[]);
typedef struct Students
{
	char fio[16];
	char tovar[16];
	int stoimost;
	int zalog;
	char data[16];
	int srok;
} STUD;
int number; FILE* f; errno_t err;

int main()
{
	setlocale(LC_ALL, "Russian");
	int choice; char fio[16];
	do
	{
		cout << "\n1.Ввод данных с клавиатуры и запись в файл\n";
		cout << "2.Вывод данных из файла\n";
		cout << "3.Поиск по названию товара\n";
		cout << "4.Удаление \n";
		cout << "0.Выход из программы\n\n";
		cout << "Введите номер операции: ";
		cin >> choice;
		switch (choice)
		{
		case 1: cout << "Введите количество клиентов ламбарда: ";
			cin >> number;
			input(number);  break;
		case 2: output(); break;
		case 3: {  cout << "Введите название товара: ";
			cin >> fio;
			find(fio); break;
		}
		case 4: del(number);break;
		case 0: exit(0);  break;
		}
	} while (choice != 0);
}

void input(int size)
{
	STUD buf = { ' ', ' ', ' ', ' ', ' ', ' '};
	if (!fopen_s(&f, "base.bin", "ab"))
	{
		for (int p = 0; p < size; p++)
		{
		cout << "Фамилия " ;cin >> buf.fio;
		cout << "Наименование товара ";cin >> buf.tovar;
		cout << "Оценочная стоимость в белорусских рублях " ;cin >> buf.stoimost;
		cout << "Сумма, выданная под залог в белорусских рублях " ;cin >>buf.zalog;
		cout << "Дата сдачи(день.месяц.год)" ;cin >> buf.data;
		cout << "Срок хранения в месяцах" ;cin >> buf.srok;
			fwrite(&buf, sizeof(buf), 1, f);
		}
		fclose(f);
	}
	else {
		cout << "Ошибка открытия файла";
		return;
	}
}

void output()
{
	STUD buf;
	if (!fopen_s(&f, "base.bin", "rb"))
	{
		fread(&buf, sizeof(buf), 1, f);
		while (!feof(f))
		{
			cout << buf.fio << "\t    " << buf.tovar << "\t    " << buf.stoimost<<"\t    " << buf.zalog<<"\t    " << buf.data<<"\t    " << buf.srok<< endl;
			fread(&buf, sizeof(buf), 1, f);
		}
		cout << endl;
		fclose(f);
	}
	else
	{
		cout << "Ошибка открытия файла";
		return;
	}
}

void find(char tName[16])
{
	bool flag = false;  STUD buf;
	if (!fopen_s(&f, "base.bin", "rb"))
	{
		while (!feof(f))
		{
			fread(&buf, sizeof(buf), 1, f);
			if (strcmp(tName, buf.tovar) == 0)   //сравнение строк
			{
				cout << buf.fio << "\t    " << buf.tovar << "\t    " << buf.stoimost << "\t    " << buf.zalog << "\t    " << buf.data << "\t    " << buf.srok << endl;

				flag = true; break;
			}
		}
		fclose(f);
		if (!flag) cout << "Ничего не найдено\n";
	}
	else
	{
		cout << "Ошибка открытия файла";
		return;
	}
}

void del(int n)
{
	STUD buf;
	int d;
	cout << "\nНомер строки, которую надо удалить " << endl;  
	cin >> d;

	if (!fopen_s(&f, "base.bin", "rb"))
	{
		fread(&buf, sizeof(buf), 1, f);
		for (int de1 = (d - 1); de1 <n-1 ; de1++)
			buf[de1] = buf[de1 + 1];
	}
	else
	{
		cout << "Ошибка открытия файла";
		return;
	}
}