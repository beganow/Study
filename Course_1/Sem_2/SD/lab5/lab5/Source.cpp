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
void Sort�(int n);
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
			Sort�(current_client);
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
	cout << "�����" << endl;
}
void enter_client() {
	int n;
	int i = 0;
	cout << "������� ���������� ��������" << endl;
	cin >> n;
	while (i != n) {
		string str;
		int p;
		cout << "������� ���:" << endl;
		cin >> str;
		client[current_client].name = str;
		cout << "������� �������:" << endl;
		cin >> str;
		client[current_client].surname = str;
		cout << "������� �������: " << endl;
		cin >> p;
		client[current_client].age = p;
		cout << "������� ���������:" << endl;
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
	cout << "������� �o��� ������� :" << endl;
	cin >> index;
	index--;
	if (index <= current_client)
	{
		cout << "���: " << client[index].name << endl;
		cout << "�������: " << client[index].surname << endl;
		cout << "�������: " << client[index].age << endl;
		cout << "���������: " << client[index].profession << endl;
	}
	else {
		cout << "������� ��� ����� ������� ���� �� ����������!";
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
		cout << "������� ��� �����" << endl;
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
		cout << "������� ��� �����" << endl;
		cin >> str;
	}
	system("cls");
	ifstream fin(str);
	if (!fin.is_open())
		cout << "���� �� ����� ���� ������!\n";
	else
	{
		while (k != current_client)
		{
			fin >> str;
			cout << "���:\t" << str << endl;

			fin >> str;
			cout << "�������:\t" << str << endl;

			fin >> n;
			cout << "�������:\t" << n << endl;

			fin >> str;
			cout << "���������:\t" << str << endl;

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
		cout << "������� ����� ������������, �������� ������ ��������: " << endl;
		cin >> index;
		for (int i = index - 1; i < current_client; i++)
			client[i] = client[i + 1];
		current_client--;
		write_file();
	}
}
void change() {
	int index, p;
	cout << "������� ����� �������, �������� ������ ��������: " << endl;
	cin >> index;
	index--;
	string str;
	cout << "������� ���:" << endl;
	cin >> str;
	client[index].name = str;
	cout << "������� �������:" << endl;
	cin >> str;
	client[index].surname = str;
	cout << "������� �������:" << endl;
	cin >> p;
	client[index].age = p;
	cout << "������� ��� ������������:" << endl;
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
void Sort�(int n)
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
	cout << "������� ������� ������ ��� ���������:" << endl;
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
			cout << "��������:\t" << client[k].name << endl;
			cout << "��� ������������:\t" << client[k].surname << endl;
			cout << "�����:\t" << client[k].profession << endl;
			cout << "���:\t" << client[k].age << endl << endl;
		}
	}
}
void b_search() {//�������� �����
	string key;
	cout << "������� ��������, ������� ������ �����:" << endl;
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
		cout << "������ �������� " << key << " � ������� �����: " << mid << endl;
		cout << "��������:\t" << client[mid].name << endl;
		cout << "��� ������������:\t" << client[mid].surname << endl;
		cout << "�����:\t" << client[mid].profession << endl;
		cout << "���:\t" << client[mid].age << endl;


	}
	else cout << "��������, �� ������ �������� � ����� ���� ������ ���";
}
void i_search() {//���������������� �����
	int key;
	cout << "������� �����, ������� ������ �����:" << endl;
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
		cout << "������ �������� " << key << " � ������� �����: " << l << endl;
		cout << "��������:\t" << client[l].name << endl;
		cout << "��� ������������:\t" << client[l].surname << endl;
		cout << "�����:\t" << client[l].profession << endl;
		cout << "���:\t" << client[l].age << endl;

	}
	else if (client[r].age == key) {
		cout << "������ �������� " << key << " � ������� �����: " << r << endl;
		cout << "��������:\t" << client[r].name << endl;
		cout << "��� ������������:\t" << client[r].surname << endl;
		cout << "�����:\t" << client[r].profession<< endl;
		cout << "���:\t" << client[r].age << endl;

	}
	else cout << "��������, �� ������ �������� � ����� ���� ������ ���" << endl;
}


		void menu()
		{
			cout << "�������� ���� �� �������:" << endl;
			cout << " 1 - ������ ������ �������" << endl;
			cout << " 2 - ����� ������� �� ��� ������" << endl;
			cout << " 3 - ����� ������ ������� �� �����" << endl;
			cout << " 4 - �������� ������ �������" << endl;
			cout << " 5 - ��������� ������ �������" << endl;
			cout << " 6 - �������� ������ ������� � ����" << endl;
			cout << " 7 - ����������� �������� �� �������� �� ������������" << endl;
			cout << " 8 - ����������� ������� �� ��������" << endl;
			cout << " 9 - ����� ������ �� ���������" << endl;
			cout << " 10 - �������� �����" << endl;
			cout << " 11 - ������������ �����" << endl;
			cout << " 12 - ����� �� ���������" << endl;
		}
		void menu1()
		{
			cout << "�������� ���� �� �������:" << endl;
			cout << " 1 - ������� ����" << endl;
			cout << " 2 - ����� ����" << endl;

		}
		void menu2()
		{
			cout << "�������� ���� �� �������:" << endl;
			cout << " 1 - ������� ���" << endl;
			cout << " 2 - ������� ��������� ������� " << endl;
		}