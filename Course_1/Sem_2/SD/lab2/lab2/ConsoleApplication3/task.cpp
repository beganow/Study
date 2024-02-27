#include <iostream>
#include <string>
#include <clocale>
#include <ctime>
#include <conio.h>
#include <stdio.h>


using namespace std;

struct Node
{
	int data;
	Node* next;//ссылка на следующий узел
};
typedef Node* PNode;//тип данных: указатель на узел

Node* head = NULL;//указатель головы равен 0 (или пустой)

PNode CreateNode(int d)
{
	PNode NewNode = new Node;// выделение памяти на новый узел
	NewNode->data = d;//присвоение значения к узлу
	NewNode->next = NULL;// следующего узла нет
	return NewNode; // результат функции – адрес узла
}


void AddFirst(PNode& Head, PNode NewNode)
{
	if (head == NULL) {//проверка имеет ли голова пустой адрес
		head = NewNode;
	}
	else {
		NewNode->next = Head;//переход головы на новый узел
		Head = NewNode;//присвоение головы новому узлу
	}
}

	void AddAfter(PNode head, PNode NewNode)
{
	NewNode->next = head->next;
	head->next = NewNode;
}
	void AddLast(PNode& Head, PNode NewNode)
{
	PNode q = Head;
	if (Head == NULL)
	{ // если список пуст,
		AddFirst(Head, NewNode); // вставляем первый элемент
		return;
	}
	while (q->next) q = q->next; // ищем последний элемент
	AddAfter(q, NewNode);//вставляем последний элемент
}
	void Reserchuzl(PNode& Head, int c) {
	Node* current = Head;//текущему узлу присваиваем значение головы
	int count = 0;//счётчик
	while (current != NULL) {//пока адрес карент не пустой
		count++;
		if (current->data == c) {
			cout << "Элемент найден его номер: ";
			cout << count << endl;
			return;
		}
		current = current->next;//переход к следующему узлу
	}
	cout << "Элемент не найден \n";
}

void DeleteNode(PNode& Head, int e)
{
	Node* current = Head;
	Node* deletenum; // создаем какой то адрес для итогового удаления
	if (current->data == e) {//в узле есть значение e
		deletenum = current; //присваиваем адрес текущего узла к узлу для удаления
		current = current->next;//присваиваем текущему узлу соседний элемент
		head = current;// переходим на голову
		delete deletenum; // освобождаем память
	}
	else
	{
		while (current != NULL && current->next != NULL) {
			if (current->next->data == e) {//в следующем узле значение числа
				deletenum = current->next;//делитинам присваиваиваем адрес следующего узла
				current->next = deletenum->next;//ссылка 
				delete deletenum;
			}
			current = current->next;
		}
	}

}

void deleteNodes(Node*& head, int p, int n) {
	Node* current = head;
	Node* delete_nd, * node_bd;
	int k = 0;
	while (k < p - 1) {
		k++;
		current = current->next;
	}
	node_bd = current;
	current = current->next;
	k = 0;
	while (k < n) {
		delete_nd = current;
		node_bd->next = delete_nd->next;
		current = current->next;
		delete delete_nd;
		k++;
	}
}

void printList()
{
	Node* current = head;

	while (current != NULL)
	{
		cout << "-->" << current->data;
		current = current->next;
	}
	cout << "-->NULL" << endl;
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


void menu();
void menu1();
void menu2();


void main()
{
	setlocale(LC_CTYPE, "rus");
	int n, choice = 1;



	while (choice != 4)
	{
		menu();
		cin >> choice;

		switch (choice)
		{
		case 1:
		{
			menu1();
			int choise1;
			cin >> choise1;
			switch (choise1) {
			case 1:
			{
				cout << "Введите число" << endl;
				int beforelist;
				cin >> beforelist;

				AddFirst(head, CreateNode(beforelist));

				cout << "Ваш список:" << endl;
				printList();
				break;
			}
			case 2:
			{
				cout << "Введите число которое хотите поместить в конец списка " << endl;
				int afterlist;
				cin >> afterlist;
				AddLast(head, CreateNode(afterlist));
				cout << "Ваш список:" << endl;
				printList();
				break;
			}
			}

			break;
		}
		case 2:
		{
			menu2();
			int choise2;
			cin >> choise2;
			switch (choise2)
			{
			case 1:
			{
				cout << "Введите элемент который нужно удалить " << endl;
				int deletenum;
				cin >> deletenum;
				DeleteNode(head, deletenum);

				cout << "Ваш список:" << endl;
				printList();
				break;

			}
			case 2:
			{
				cout << "Введите элемент с которого нужно удалить" << endl;
				int numstart;
				cin >> numstart;
				cout << "Введите количество элементов\n";
				int deleteofnum;
				cin >> deleteofnum;
				deleteNodes(head, numstart, deleteofnum);
				cout << "Ваш список:" << endl;
				printList();
				break;
			}
			}
			break;
		}
		case 3:
		{
			cout << "Введите элемент который нужно найти " << endl;
			int findnum;
			cin >> findnum;
			Reserchuzl(head, findnum);
			break;
		}
		case 4:
		{
			deletelist(head);
			cout << "Ваш список:" << endl;
			printList();
			break;
		}
		default:  cout << "Неправильный выбор" << endl;
			menu();
			break;
		}
	}
	cout << "Конец" << endl;

}

void menu()
{
	cout << "Сделайте выбор:" << endl;
	cout << " 1 - Ввод чиcла" << endl;
	cout << " 2 - Удаление числа" << endl;
	cout << " 3 - Найти элемент по заданному значению" << endl;
	cout << " 4 - Выход, очистить список" << endl;

}

void menu1()
{
	cout << "Сделайте выбор:" << endl;
	cout << " 1 - Ввод чиcла в начало " << endl;
	cout << " 2 - Ввод числа в конец" << endl;
}
void menu2()
{
	cout << "Сделайте выбор:" << endl;
	cout << " 1 - Удалить заданный элемент " << endl;
	cout << " 2 - Удалить n элементов" << endl;
}