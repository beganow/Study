#include <iostream>
#include <fstream>
#include <windows.h>
#include <typeinfo>
#include <algorithm>
#include <string>
using namespace std;
void enter_client();
void search_client_index();
struct person
{
	string name;
	string surname;
	string profession;
	int age;
}client[100];
int current_client = 0;
int main()
{
	setlocale(LC_ALL, "rus");
	enter_client();
}
void enter_client() {
	int n;
	cout << "Введите количество клиентов" << endl;
	cin >> n;
	for (int i = 0; i < n; i++) {
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
	}
	search_client_index();
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
		cout << "Возраст:" << client[index].age << endl;
		cout << "Профессия: " << client[index].profession << endl;
	}
	else {
		cout << "Клиента под таким номером пока не существует!";
	}
}



