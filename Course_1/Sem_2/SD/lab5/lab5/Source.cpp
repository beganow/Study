#include <iostream>
#include <fstream>
#include <windows.h>
#include <typeinfo>
#include <algorithm>
#include <string>
using namespace std;
void enter_client();
void search_client_index();
void input();
void menu();
void menu1();
void menu2();
void write_file();
void read_file();
void del();
void change();
void sort(int l,int r);
void Sortу(int n);
void find_surname();
void b_search();
void i_search();


struct person
{
	string name;
	string surname;
	string profession;
	int age;
}client[101];
int current_client = 0;

int main()
{
	setlocale(LC_ALL, "rus");
	int choise = 0;
	input();
	while (choise != 12)
	{
		menu();
		cin >> choise;
		switch (choise)
		{
		case 1:
		{
			system("cls");
			enter_client();
			system("pause");
			system("cls");
			break;
		}
		case 2:
		{
			system("cls");
			search_client_index();
			system("pause");
			system("cls");
			break;
		}
		case 3:
		{
			system("cls");
			read_file();
			system("pause");
			system("cls");
			break;
		}
		case 4:
		{
			system("cls");
			del();
			system("pause");
			system("cls");
			break;
		}
		case 5:
		{
			system("cls");
			change();
			system("pause");
			system("cls");
			break;
		}
		case 6:
		{
			system("cls");
			write_file();
			system("pause");
			system("cls");
			break;
		}
		case 7:
		{
			sort(0, current_client - 1);
			system("cls");
			break;
		}
		case 8:
		{
			Sortу(current_client);
			system("cls");
			break;
		}
		case 9:
		{
			system("cls");
			find_surname();
			system("pause");
			system("cls");
			break;
		}
		case 10:
		{
			system("cls");
			b_search();
			system("pause");
			system("cls");
			break;
		}
		case 11:
		{
			system("cls");
			i_search();
			system("pause");
			system("cls");
			break;
		}
		}
	}
	cout << "Конец" << endl;
}
void enter_client() {
	int n;
	int i = 0;
	cout << "Введите количество клиентов" << endl;
	cin >> n;
	while (i != n) {
		string str;
		int p;
		cout << "Введите имя:" << endl;
		cin >> str;
		client[current_client].name = str;
		cout << "Введите фамилию:" << endl;
		cin >> str;
		client[current_client].surname = str;
		cout << "Введите возраст: " << endl;
		cin >> p;
		client[current_client].age = p;
		cout << "Введите профессию:" << endl;
		cin >> str;
		client[current_client].profession = str;
		current_client++;
		i++;
	}
	write_file();
}
void search_client_index()
{
	int index;
	cout << "Введите нoмер клиента :" << endl;
	cin >> index;
	index--;
	if (index <= current_client)
	{
		cout << "Имя: " << client[index].name << endl;
		cout << "Фамилия: " << client[index].surname << endl;
		cout << "Возраст: " << client[index].age << endl;
		cout << "Профессия: " << client[index].profession << endl;
	}
	else {
		cout << "Клиента под таким номером пока не существует!";
	}
}


void write_file() {
	menu1();
	int choose;
	string str;
	cin >> choose;
	if (choose == 1) { str = "t.txt"; }
	else {
		system("cls");
		cout << "Введите имя файла" << endl;
		cin >> str;
	}
	fstream clear_file(str, ios::out);
	clear_file.close();
	ofstream fout(str, ofstream::app);

	for (int i = 0; i < current_client; i++)
	{
		fout << client[i].name << endl;
		fout << client[i].surname << endl;
		fout << client[i].age << endl;
		fout << client[i].profession << endl;


	}
	fout.close();
}
void read_file() {
	menu1();
	int k = 0;
	string str;
	int n;
	int choose;
	cin >> choose;
	if (choose == 1) { str = "t.txt"; }
	else {
		system("cls");
		cout << "Введите имя файла" << endl;
		cin >> str;
	}
	system("cls");
	ifstream fin(str);
	if (!fin.is_open())
		cout << "Файл не может быть открыт!\n";
	else
	{
		while (k != current_client)
		{
			fin >> str;
			cout << "Имя:\t" << str << endl;

			fin >> str;
			cout << "Фамилия:\t" << str << endl;

			fin >> n;
			cout << "Возраст:\t" << n << endl;

			fin >> str;
			cout << "Профессия:\t" << str << endl;

			k++;
		}
	}
	fin.close();
}
void del() {
	menu2();
	int choose, index;
	cin >> choose;
	if (choose == 1) { current_client = 0; write_file();}
	else {
		system("cls");
		cout << "Введите номер работодателя, которого хотите удалиить: " << endl;
		cin >> index;
		for (int i = index - 1; i < current_client; i++)
			client[i] = client[i + 1];
		current_client--;
		write_file();
	}
}
void change() {
	int index, p;
	cout << "Введите номер клиента, которого хотите изменить: " << endl;
	cin >> index;
	index--;
	string str;
	cout << "Введите имя:" << endl;
	cin >> str;
	client[index].name = str;
	cout << "Введите фамилию:" << endl;
	cin >> str;
	client[index].surname = str;
	cout << "Введите возраст:" << endl;
	cin >> p;
	client[index].age = p;
	cout << "Введите вид дейтельности:" << endl;
	cin >> str;
	client[index].profession = str;
	write_file();
}


void input() {
	string str;
	int p;
	int k = 0;
	ifstream fin("t.txt");
	while (!fin.eof())
	{
		k++;
		if (k % 4 == 1) {
			fin >> str;
			client[current_client].name = str;
		}
		else if (k % 4 == 2) {
			fin >> str;
			client[current_client].surname = str;
		}
		else if (k % 4 == 3) {
			fin >> p;
			client[current_client].age = p;
		}
		else if (k % 4 == 0) {
			fin >> str;
			client[current_client].profession = str;
			current_client++;
		}
	}
	fin.close();

}
void Sortу(int n)
{
	for (int i = 0; i < n; i++) {
		for (int j = i + 1; j < n; j++) {
			if (client[i].age < client[j].age) {
				swap(client[i], client[j]);
			}
		}
	}

}
void sort(int l, int r)
{
	int i, j;
	string x;
	{
		i = l;
		j = r;
		x = client[(l + r) / 2].profession;
		do {

			while (client[i].profession < x) i++;
			while (client[j].profession > x) j--;
			if (i <= j)
			{
				client[100] = client[i];
				client[i] = client [j] ;
				client[j] = client[100];
				i++; j--;
			}
		} while (i < j);

		if (i < r) sort(i, r);
		if (l < j) sort(l, j);
	}
}
void find_surname() {
	string str, s;
	bool retro;
	int pos;
	cout << "Введите искомую строку или подстроку:" << endl;
	cin >> str;
	system("cls");
	for (int k = 0; k < current_client; k++) {
		pos = 0;
		retro = false;
		s = client[k].surname;
		for (int i = 0; i < s.length(); i++)
			if (s[i] == str[pos]) {
				pos++;
				if (pos == (str.length()))
				{
					retro = true;
					break;
				}


			}
			else {
				pos = 0;
			}
		if (retro == true)
		{
			cout << "Название:\t" << client[k].name << endl;
			cout << "Вид деятельности:\t" << client[k].surname << endl;
			cout << "Адрес:\t" << client[k].profession << endl;
			cout << "Лет:\t" << client[k].age << endl << endl;
		}
	}
}
void b_search() {//бинарный поиск
	string key;
	cout << "Введите название, которое хотите найти:" << endl;
	cin >> key;
	system("cls");
	bool retro = false;
	int l = 0;
	int r = current_client - 1;
	int mid;

	while ((l <= r) && (retro != true)) {
		mid = (l + r) / 2;

		if (client[mid].profession == key) retro = true;
		if (client[mid].profession > key) r = mid - 1;
		else l = mid + 1;
	}
	if (retro) {
		cout << "Индекс элемента " << key << " в массиве равен: " << mid << endl;
		cout << "Название:\t" << client[mid].name << endl;
		cout << "Вид деятельности:\t" << client[mid].surname << endl;
		cout << "Адрес:\t" << client[mid].profession << endl;
		cout << "Лет:\t" << client[mid].age << endl;


	}
	else cout << "Извините, но такого элемента в нашей базе данных нет";
}
void i_search() {//интерполирующиий поиск
	int key;
	cout << "Введите число, которое хотите найти:" << endl;
	cin >> key;
	int l = 0;
	int r = current_client - 1;
	int x;
	while (client[l].age > key && client[r].age <= key) {
		x = l + ((key - client[l].age) * (r - l)) / (client[r].age - client[l].age);
		if (l > r){
			break;
	}
		else if (client[x].age > key) {
			l = x + 1;
		}
		else if (client[x].age < key) {
			r = x - 1;
		}
		else if (client[l].age == key) { break; }
		else if (client[r].age == key) { break; }

	}

	if (client[l].age == key)

	{
		cout << "Индекс элемента " << key << " в массиве равен: " << l << endl;
		cout << "Название:\t" << client[l].name << endl;
		cout << "Вид деятельности:\t" << client[l].surname << endl;
		cout << "Адрес:\t" << client[l].profession << endl;
		cout << "Лет:\t" << client[l].age << endl;

	}
	else if (client[r].age == key) {
		cout << "Индекс элемента " << key << " в массиве равен: " << r << endl;
		cout << "Название:\t" << client[r].name << endl;
		cout << "Вид деятельности:\t" << client[r].surname << endl;
		cout << "Адрес:\t" << client[r].profession<< endl;
		cout << "Лет:\t" << client[r].age << endl;

	}
	else cout << "Извините, но такого элемента в нашей базе данных нет" << endl;
}


		void menu()
		{
			cout << "Выберите один из пунктов:" << endl;
			cout << " 1 - Ввести данные клиента" << endl;
			cout << " 2 - Найти клиента по его номеру" << endl;
			cout << " 3 - Вывод данных клиента из файла" << endl;
			cout << " 4 - Удаление данных клиента" << endl;
			cout << " 5 - Изменение данных клиента" << endl;
			cout << " 6 - Добавить данные клиента в файл" << endl;
			cout << " 7 - Сортировать клиентов по професии по возврастанию" << endl;
			cout << " 8 - Сортировать возраст по убыванию" << endl;
			cout << " 9 - Поиск строки по подстроке" << endl;
			cout << " 10 - Бинарный поиск" << endl;
			cout << " 11 - Интернальный поиск" << endl;
			cout << " 12 - Выйти из программы" << endl;
		}
		void menu1()
		{
			cout << "Выберите один из пунктов:" << endl;
			cout << " 1 - Готовый файл" << endl;
			cout << " 2 - Новый файл" << endl;

		}
		void menu2()
		{
			cout << "Выберите один из пунктов:" << endl;
			cout << " 1 - Удалить все" << endl;
			cout << " 2 - Удалить выбранный элемент " << endl;
		}