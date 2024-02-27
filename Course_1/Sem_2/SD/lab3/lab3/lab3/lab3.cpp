#include <iostream>
#include <string>
#include <clocale>
#include <cstdlib>
#include <conio.h>
#include <stdio.h>
#include <string>
#include <fstream>


using namespace std;

struct Data
{
	int number;
	int month;
	int year;
};
struct Node
{
	string first_name;
	string last_name;
	string work;
	int data;
	Data birth;//вложенная структура
	Node* next; //указатель на следующий узел
};

typedef Node* PNode; //тип данных : указатель на узел
Node* head = NULL; 

struct Nnode
{
	string data;
	Nnode* next;
};

typedef Nnode* CNode;
Nnode* hhead = NULL;

CNode  CreateNodeHistory(string e)
{
	CNode NewNode = new Nnode; // указатель на новый узел
	NewNode->data = e;
	NewNode->next = NULL;

	return NewNode;
}
void AddFirstHistory(CNode& Head, CNode NewNode)
{
	if (Head == NULL)
	{
		Head = NewNode;
	}
	else
	{
		NewNode->next = Head;//установить ссылку узла NewNode на голову существующего списка
		Head = NewNode; //установить голову списка на новый узел.
	}
}
void printListHistory()
{
	Nnode* current = hhead; //текущий узел голова

	while (current != NULL)
	{
		cout << "-->" << current->data;
		current = current->next;//текущий следующий узел
	}
	cout << "-->NULL" << endl;
}
void deletelistHistory(Nnode*& head)
{
	Nnode* current = head;
	Nnode* delete_nd;
	while (current != NULL) {
		delete_nd = current;
		current = current->next;
		delete delete_nd;

	}
	head = NULL;
}

PNode CreateNode(int d, string str11, string str22, string str33, int num1, int num2, int num3)
{
	PNode NewNode = new Node;
	NewNode->data = d;
	NewNode->first_name = str11;
	NewNode->last_name = str22;
	NewNode->work = str33;
	NewNode->birth.number = num1;
	NewNode->birth.month = num2;
	NewNode->birth.year = num3;
	NewNode->next = NULL;

	return NewNode;
}
void AddFirst(PNode& Head, PNode NewNode)
{
	if (head == NULL)
	{
		head = NewNode;
	}
	else
	{
		NewNode->next = Head;
		Head = NewNode;
	}
}
void printList()
{
	Node* current = head;

	while (current != NULL)
	{
		cout << "Имя: " << current->first_name << endl;
		cout << "Фамилия: " << current->last_name << endl;
		cout << "Работа:" << current->work << endl;
		cout << "Зарплата: " << current->data << endl;
		cout << "Дата рождения " << current->birth.number << "." << current->birth.month << "." << current->birth.year << endl;
		current = current->next;
	}
}
void deletelist(Node*& head)
{
	Node* current = head;
	Node* delete_nd;
	while (current != NULL) {
		delete_nd = current;
		current = current->next;
		delete delete_nd;

	}
	head = NULL;
}
void AddFile(Node*& head)
{
	Node* current = head;
	fstream clear_file("t.txt", ios::out);//чистка файла
	clear_file.close();
	ofstream fout("t.txt", ofstream::app);//заполнение файла
	while (current != NULL)
	{

		fout << current->first_name << endl;
		fout << current->last_name << endl;
		fout << current->work << endl;
		fout << current->data << endl;
		fout << current->birth.number << "." << current->birth.month << "." << current->birth.year << endl;

		current = current->next;
	}
	fout.close();

}
void outputFile()
{
	string str;
	ifstream fin("t.txt");//чтение файла
	while (!fin.eof()) //пока файл не пуст
	{
		getline(fin, str);
		cout << str << endl;
	}
	fin.close();
}

void findName(Node*& Head, string e)
{
	Node* current = Head;
	while (current != NULL) {
		if (current->first_name == e) {
			cout << "Имя: " << current->first_name << endl;
			cout << "Фамилия: " << current->last_name << endl;
			cout << "Работа:" << current->work << endl;
			cout << "Зарплата: " << current->data << endl;
			cout << "Дата рождения " << current->birth.number << "." << current->birth.month << "." << current->birth.year << endl;
			return;
		}
		current = current->next;
	}
	cout << "Элемент не найден \n";
}
void findSName(Node*& Head, string e)
{
	Node* current = Head;
	while (current != NULL) {
		if (current->last_name == e) {
			cout << "Имя: " << current->first_name << endl;
			cout << "Фамилия: " << current->last_name << endl;
			cout << "Работа:" << current->work << endl;
			cout << "Зарплата: " << current->data << endl;
			cout << "Дата рождения " << current->birth.number << "." << current->birth.month << "." << current->birth.year << endl;
			return;
		}
		current = current->next;
	}
	cout << "Элемент не найден \n";
}
void findWork(Node*& Head, string e)
{
	Node* current = Head;
	while (current != NULL) {
		if (current->work == e) {
			cout << "Имя: " << current->first_name << endl;
			cout << "Фамилия: " << current->last_name << endl;
			cout << "Работа:" << current->work << endl;
			cout << "Зарплата: " << current->data << endl;
			cout << "Дата рождения " << current->birth.number << "." << current->birth.month << "." << current->birth.year << endl;
			return;
		}
		current = current->next;
	}
	cout << "Элемент не найден \n";
}
void findData(Node*& Head, int e)
{
	Node* current = Head;
	while (current != NULL) {
		if (current->data == e) {
			cout << "Имя: " << current->first_name << endl;
			cout << "Фамилия: " << current->last_name << endl;
			cout << "Работа:" << current->work << endl;
			cout << "Зарплата: " << current->data << endl;
			cout << "Дата рождения " << current->birth.number << "." << current->birth.month << "." << current->birth.year << endl;
			return;
		}
		current = current->next;
	}
	cout << "Элемент не найден \n";
}
void findBirth(Node*& Head, int a, int b, int c)
{
	Node* current = Head;
	while (current != NULL) {
		if (current->birth.number == a && current->birth.month == b && current->birth.year == c) {
			cout << "Имя: " << current->first_name << endl;
			cout << "Фамилия: " << current->last_name << endl;
			cout << "Работа:" << current->work << endl;
			cout << "Зарплата: " << current->data << endl;
			cout << "Дата рождения " << current->birth.number << "." << current->birth.month << "." << current->birth.year << endl;
			return;
		}
		current = current->next;
	}
	cout << "Элемент не найден \n";
}
void input() {
	string str1, str2, str3, str, s1, s2, s3;
	int n, ch1, ch2, ch3;
	int k = 0;
	ifstream fin("t.txt");
	if (!fin.is_open())
		cout << "Файл не может быть открыт!\n";
	else {
		while (!fin.eof())//пока есть что читать из файла 
		{
			k++;
			if (k % 5 == 1) {
				fin >> str1;
			}
			else if (k % 5 == 2) {
				fin >> str2;
			}
			else if (k % 5 == 3) {
				fin >> str3;
			}
			else if (k % 5 == 4) {
				fin >> n;

			}
			else if (k % 5 == 0) {
				fin >> str;
				int i = 0;
				s1 = "";
				s2 = "";
				s3 = "";
				ch1 = 0;
				ch2 = 0;
				ch3 = 0;
				while (str[i] != '.') {
					s1 += str[i];
					i++;

				}
				ch1 = stoi(s1);//переводит строки в числа
				i++;
				while (str[i] != '.') {
					s2 += str[i];
					i++;

				}
				ch2 = stoi(s2);
				i++;
				for (int j = i; j < str.length(); j++)
					s3 += str[j];

				ch3 = stoi(s3);

				AddFirst(head, CreateNode(n, str1, str2, str3, ch1, ch2, ch3));

			}



		}
	}
	fin.close();

}



void menu();
void menu1();


int main()
{
	setlocale(LC_CTYPE, "rus");
	int  choice = 1;
	string yn;


	int n, ch1, ch2, ch3, kol = 0;
	input();
	string str1, str2, str3;

	while (choice != 6)
	{
		menu();
		cin >> choice;

		switch (choice)
		{
		case 1:
		{


			cout << "Введите имя: ";
			cin >> str1;
			cout << "Введите фамилию: ";
			cin >> str2;
			cout << "Введите работу: ";
			cin >> str3;
			cout << "Введите зарплату: ";
			cin >> n;
			cout << "Введите день рождения: ";
			cin >> ch1;
			cout << "Введите месяц рождения: ";
			cin >> ch2;
			cout << "Введите год рождения: ";
			cin >> ch3;
			AddFirst(head, CreateNode(n, str1, str2, str3, ch1, ch2, ch3));
			cout << "Добавить список в файл?Y/N" << endl;
			cin >> yn;
			if (yn == "Yes" || yn == "Y") { AddFile(head); }

			break;

		}
		case 2:
		{
			printList();
			break;
		}
		case 3:
		{
			int choose, numb1, numb2, numb3, numb;
			string str, s;
			menu1();
			cin >> choose;
			switch (choose)
			{
			case 1:
			{
				cout << "Введите искомое имя: " << endl;
				cin >> str;
				AddFirstHistory(hhead, CreateNodeHistory(str));

				findName(head, str);
				break;
			}
			case 2:
			{

				cout << "Введите искомую фамилию: " << endl;
				cin >> str;

				AddFirstHistory(hhead, CreateNodeHistory(str));
				findSName(head, str);
				break;
			}
			case 3:
			{

				cout << "Введите искомую работу: " << endl;
				cin >> str;

				AddFirstHistory(hhead, CreateNodeHistory(str));
				findWork(head, str);
				break;
			}
			case 4:
			{

				cout << "Введите искомую зарпклату: " << endl;
				cin >> numb;

				str = to_string(numb);
				AddFirstHistory(hhead, CreateNodeHistory(str));
				findData(head, numb);
				break;
			}
			case 5:
			{

				cout << "Введите искомое число: " << endl;
				cin >> numb1;
				cout << "Введите искомый месяц: " << endl;
				cin >> numb2;
				cout << "Введите искомый год: " << endl;
				cin >> numb3;
				if (numb1 < 10) str = '0';
				str += to_string(numb1) + '.';
				if (numb2 < 10) str += '0';
				str += to_string(numb2) + '.';
				str += to_string(numb3);

				AddFirstHistory(hhead, CreateNodeHistory(str));
				findBirth(head, numb1, numb2, numb3);
				break;
			}
			}
			cout << "Добавить список в файл?Y/N" << endl;
			cin >> yn;
			if (yn == "Yes" || yn == "Y") { AddFile(head); }
			break;
		}
		case 4:
		{

			cout << "Ваша история запросов:" << endl;
			printListHistory();
			break;
		}
		case 5:
		{
			outputFile();
			break;
		}
		case 6:
		{
			deletelist(head);
			deletelistHistory(hhead);
			cout << "Конец" << endl;
			break;
		}
		default:
		{
			cout << "Неправильный выбор" << endl;
			break;
		}
		}

	}
}

void menu()
{
	cout << "Сделайте выбор:" << endl;
	cout << " 1 - Ввод данных" << endl;
	cout << " 2 - Вывод данных" << endl;
	cout << " 3 - Поиск по параметру " << endl;
	cout << " 4 - Вывести историю запросов по поиску " << endl;
	cout << " 5 - Чтение из файла " << endl;
	cout << " 6 - Выход, очистить список" << endl;

}
void menu1()
{
	cout << "Сделайте выбор:" << endl;
	cout << " 1 - Поиск по имени " << endl;
	cout << " 2 - Поиск по фимилии " << endl;
	cout << " 3 - Поиск по работе " << endl;
	cout << " 4 - Поиск по зарплате " << endl;
	cout << " 5 - Поиск по дате рождения " << endl;
	cout << " 6 - Поиск по индексу" << endl;

}


