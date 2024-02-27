#include <iostream>
#include <fstream>
# define str_len 30                               
# define size 30  
using namespace std;
void enter_new();
void del();
void search();
void out();
struct Student
{
	char name[str_len];
	char tovar[str_len];
	int stoimost;
	int zalog;
	char data[str_len];
	int srok;

	
};
struct Student list_of_student[size];
struct Student bad;
int current_size = 0; int choice;
int main()
{
	setlocale(LC_CTYPE, "Russian");
	cout << "Введите:" << endl;
	cout << "1-для удаления записи" << endl;
	cout << "2-для ввода новой записи" << endl;
	cout << "3-для поиска товара" << endl;
	cout << "4-для вывода записией" << endl;
	cout << "для выхода введите любое число или букву" << endl;
	cin >> choice;
	do
	{
		switch (choice)
		{
		case 1:  del();	break;
		case 2:  enter_new();  break;
		case 3:  search();	break;
		case 4:  out();	break;
		}
	} while (choice == 3 || choice == 2 || choice == 1 || choice==4);
}
void enter_new()
{
	cout << "Ввод информации в файл" << endl;
	if (current_size < size)
	{

		ofstream fout("t.txt",ofstream::app);
		cout << "Строка номер ";
		cout << current_size + 1;
		cout << endl << "Фамилия " << endl;
		cin >> list_of_student[current_size].name;
		fout << list_of_student[current_size].name<<" ";
		cout << "Наименование товара " << endl;
		cin >> list_of_student[current_size].tovar;
		fout << list_of_student[current_size].tovar<<" ";
		cout << "Оценочная стоимость в белорусских рублях " << endl;
		cin >> list_of_student[current_size].stoimost;
		fout << list_of_student[current_size].stoimost<<" ";
		cout << "Сумма, выданная под залог в белорусских рублях " << endl;
		cin >> list_of_student[current_size].zalog;
		fout << list_of_student[current_size].zalog<<" ";
		cout << "Дата сдачи(день.месяц.год)" << endl;
		cin >> list_of_student[current_size].data;
		fout << list_of_student[current_size].data<<" ";
		cout << "Срок хранения в месяцах" << endl;
		cin >> list_of_student[current_size].srok;
		fout << list_of_student[current_size].srok<<"\n";
		current_size++;
		fout.close();
	}
	else
		cout << "Введено максимальное кол-во строк";
	cout << "Что дальше?" << endl;
	cin >> choice;
}
void del()
{
	fstream clear_file("t.txt", ios::out);
	clear_file.close();
	int d;
	cout << "\nНомер строки, которую надо удалить (для удаления всех строк нажать 99)" << endl;  cin >> d;
	
	for (int de1 = (d - 1); de1 < current_size; de1++)	list_of_student[de1] = list_of_student[de1 + 1];

	current_size = current_size - 1;
	ofstream fout("t.txt", ofstream::app); 
		for (int i = 0;i < current_size;i++)
		{
			fout << list_of_student[i].name << " " << list_of_student[i].tovar << " " << list_of_student[i].stoimost << " "
			<< list_of_student[i].zalog << " " << list_of_student[i].data << " " << list_of_student[i].srok << endl;
		}
	fout.close();
	cout << "Что дальше?" << endl;
	cin >> choice;

}

void search()
{
	char ch[256];
	int k=0;
	char str[256];
		cout << "Введите название товара " << endl;   cin >> ch;  
		for (int i = 0;i < current_size;i++)
		{
			int n;
			bool q = false;
			if (strlen(list_of_student[i].tovar) > strlen(ch)) 
			{
				n = strlen(list_of_student[i].tovar);
			}
			else
			{
				n = strlen(ch);
			}
			for (int j = 0;j < n;j++)
			if (ch[j] != list_of_student[i].tovar[j]) 
			{
				q = true;
				break;
			}
			if (q == false)
			{
				cout << endl << "Фамилия " ;
				cout << list_of_student[i].name<<endl;
				cout << "Наименование товара " ;
				cout << list_of_student[i].tovar<<endl;
				cout << "Оценочная стоимость в белорусских рублях " ;
				cout << list_of_student[i].stoimost<<endl;
				cout << "Сумма, выданная под залог в белорусских рублях " ;
				cout << list_of_student[i].zalog<<endl;
				cout << "Дата сдачи(день.месяц.год) " ;
				cout << list_of_student[i].data<<endl;
				cout << "Срок хранения в месяцах" ;
				cout << list_of_student[i].srok<<endl;
				k++;
			}
		}
		if (k == 0) cout << "Тавара нет" << endl;
		cout << "Что дальше?" << endl;
	cin >> choice;
}

void out()
{
	int k = 0;
	char str[256];
	ifstream fin("t.txt");
	if (!fin.is_open())
		cout << "Файл не может быть открыт!\n";
	else
	{
		while (k!= current_size)
		{
			fin.getline(str, 50);
			for (int i = 0;i < strlen(str);i++)
				cout << str[i];
			cout << endl;
			k++;
		}
	}
	fin.close();
	cout << "Что дальше?" << endl;
	cin >> choice;
}
