#include <iostream>
#include <string>

using namespace std;

struct Date
{
    int days;
    int months;
    int years;
};
struct Node
{
    string FIO;
    string Position;
    int salary;
    Date* date = new Date;
    Node* next;
};


typedef Node* pNode;


struct List
{
    Node* head;
    List()
    {
        head = NULL;
    }
    Node* CreateNode(string FIO, string Position, int salary, int days, int months, int years)
    {
        Node* NewNode = new Node; // ��������� �� ����� ����
        NewNode->FIO = FIO;
        NewNode->Position = Position;
        NewNode->salary = salary;
        NewNode->date->days = days;
        NewNode->date->months = months;
        NewNode->date->years = years;
        NewNode->next = NULL; // ���������� ���� ���
        return NewNode;
    }
    void AddFirst(pNode& Head, pNode NewNode)
    {
        NewNode->next = Head;
        Head = NewNode;
    }
    void AddAfter(pNode p, pNode NewNode)
    {
        NewNode->next = p->next;
        p->next = NewNode;
    }
    void AddLast(pNode& Head, pNode NewNode)
    {
        pNode q = Head;
        if (Head == NULL)
        { // ���� ������ ����,
            AddFirst(Head, NewNode); // ��������� ������ �������
            return;
        }
        while (q->next) q = q->next; // ���� ��������� �������
        AddAfter(q, NewNode);
    }
    void findList(pNode& Head)
    {
        Node* current = Head;

        while (current != NULL)
        {
            if (current->date->years < 1988)
            {
                cout << "���: ";
                cout << current->FIO << endl;
            }
            current = current->next;
        }
    }
    void AverAge(pNode& Head)
    {
        Node* current = Head;
        int sum = 0;
        int count = 0;

        while (current != NULL)
        {
            count++;
            sum += abs(current->date->years - 2022);
            current = current->next;
        }
        cout << "������� �������:\n";
        cout << (sum / count) << "\n";
    }
    void SumofList(pNode& Head)
    {
        Node* current = Head;
        int sum = 0;
        while (current != NULL)
        {
            sum += current->salary;
            current = current->next;
        }
        cout << "��������� ��:\n";
        cout << sum << "\n";
    }
    void printList()
    {
        setlocale(LC_CTYPE, "rus");
        Node* current = head;
        int count = 1;
        while (current != NULL)
        {
            cout << count << " ���� ������:\n";
            cout << "�������:\n";
            cout << current->FIO << endl;
            cout << "���������:\n";
            cout << current->Position<< endl;
            cout << "��������:\n";
            cout << current->salary << endl;
            cout << "���� ��������:\n";
            cout << current->date->days << endl;
            cout << "�����:\n";
            cout << current->date->months << endl;
            cout << "���:\n";
            cout << current->date->years << endl;
            current = current->next;
            count++;
        }
    }
};

int choice;

void Menu()
{
    cout << "�������� ��������:" << endl
        << "(1) �������� ������� � ������" << endl
        << "(2) �������� ������� � �����" << endl
        << "(3) ����� ����� ������ 40 ���" << endl
        << "(4) ����� ������� �������" << endl
        << "(5) ����� ��������� ��������" << endl

        << "��� �����: ";
    cin >> choice;
}

void main()
{
    setlocale(LC_CTYPE, "ru");

    List mytask;

    string FIO;
    cout << "������� �������" << endl;
    cin >> FIO;
    string Position;
    cout << "������� ���������" << endl;
    cin >> Position;
    int salary, days, months, years;
    cout << "������� ��������" << endl;
    cin >> salary;
    cout << "������� ���� ��������" << endl;
    cin >> days;
    cout << "������� ����� ��������" << endl;
    cin >> months;
    cout << "������� ��� ��������" << endl;
    cin >> years;
    mytask.AddFirst(mytask.head, mytask.CreateNode(FIO, Position, salary, days, months, years));
    cout << endl;
    mytask.printList();

    cout << "������ �� �� ������ ������ � ������ ������ ?(0 - ���, 1 - ��) \n ";
    int choose1;
    cin >> choose1;

    while (choose1 == 1) {
        string FIO;
        cout << "������� �������" << endl;
        cin >> FIO;
        string Position;
        cout << "������� ���������" << endl;
        cin >> Position;
        int salary, days, months, years;
        cout << "������� ��������" << endl;
        cin >> salary;
        cout << "������� ���� ��������" << endl;
        cin >> days;
        cout << "������� ����� ��������" << endl;
        cin >> months;
        cout << "������� ��� ��������" << endl;
        cin >> years;
        mytask.AddFirst(mytask.head, mytask.CreateNode(FIO, Position, salary, days, months, years));
        cout << endl;
        cout << "������ ���������� ?(0 - ���, 1 - ��)\n ";
        cin >> choose1;
    }

    cout << "��� ������:\n";
    mytask.printList();

    cout << "������ �� �� ������ ������ � ����� ������ ?(0 - ���, 1 - ��) \n ";
    int choose2;
    cin >> choose2;

    while (choose2 == 1) {
        string FIO;
        cout << "������� �������" << endl;
        cin >> FIO;
        string Position;
        cout << "������� ���������" << endl;
        cin >> Position;
        int salary, days, months, years;
        cout << "������� ��������" << endl;
        cin >> salary;
        cout << "������� ���� ��������" << endl;
        cin >> days;
        cout << "������� ����� ��������" << endl;
        cin >> months;
        cout << "������� ��� ��������" << endl;
        cin >> years;
        mytask.AddLast(mytask.head, mytask.CreateNode(FIO, Position, salary, days, months, years));
        cout << endl;
        mytask.printList();

        cout << "������ ���������� ?(0 - ���, 1 - ��)\n ";
        cin >> choose2;
    }

    cout << "��� ������:\n";
    mytask.printList();

    cout << "������ �� �� ����� ����� ������ 40 ��� ?(1 - ��, 0 - ���)\n";
    int n;
    cin >> n;
    if (n == 1) {
        mytask.findList(mytask.head);
    }

    cout << "������ �� �� ����� ������� �������(1 - ��, 0 - ���)\n";
    int e;
    cin >> e;
    if (e == 1) {
        mytask.AverAge(mytask.head);
    }

    cout << "������ �� �� ����� ��������� ��������(1 - ��, 0 - ���)\n";
    int j;
    cin >> j;
    if (j == 1) {
        mytask.SumofList(mytask.head);
    }
}
