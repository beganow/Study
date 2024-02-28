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
        Node* NewNode = new Node; // указатель на новый узел
        NewNode->FIO = FIO;
        NewNode->Position = Position;
        NewNode->salary = salary;
        NewNode->date->days = days;
        NewNode->date->months = months;
        NewNode->date->years = years;
        NewNode->next = NULL; // следующего узла нет
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
        { // если список пуст,
            AddFirst(Head, NewNode); // вставляем первый элемент
            return;
        }
        while (q->next) q = q->next; // ищем последний элемент
        AddAfter(q, NewNode);
    }
    void findList(pNode& Head)
    {
        Node* current = Head;

        while (current != NULL)
        {
            if (current->date->years < 1988)
            {
                cout << "Имя: ";
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
        cout << "Средний возраст:\n";
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
        cout << "Суммарная зп:\n";
        cout << sum << "\n";
    }
    void printList()
    {
        setlocale(LC_CTYPE, "rus");
        Node* current = head;
        int count = 1;
        while (current != NULL)
        {
            cout << count << " узел списка:\n";
            cout << "Фамилия:\n";
            cout << current->FIO << endl;
            cout << "Профессия:\n";
            cout << current->Position<< endl;
            cout << "Зарплата:\n";
            cout << current->salary << endl;
            cout << "День Рождения:\n";
            cout << current->date->days << endl;
            cout << "Месяц:\n";
            cout << current->date->months << endl;
            cout << "Год:\n";
            cout << current->date->years << endl;
            current = current->next;
            count++;
        }
    }
};

int choice;

void Menu()
{
    cout << "Выберети действие:" << endl
        << "(1) Добавить элемент в начало" << endl
        << "(2) Добавить элемент в конец" << endl
        << "(3) Найти людей старше 40 лет" << endl
        << "(4) Найти средний возраст" << endl
        << "(5) Найти суммарную зарплату" << endl

        << "Ваш выбор: ";
    cin >> choice;
}

void main()
{
    setlocale(LC_CTYPE, "ru");

    List mytask;

    string FIO;
    cout << "Введите Фамилию" << endl;
    cin >> FIO;
    string Position;
    cout << "Введите должность" << endl;
    cin >> Position;
    int salary, days, months, years;
    cout << "Введите зарплату" << endl;
    cin >> salary;
    cout << "Введите день рождения" << endl;
    cin >> days;
    cout << "Введите месяц рождения" << endl;
    cin >> months;
    cout << "Введите год рождения" << endl;
    cin >> years;
    mytask.AddFirst(mytask.head, mytask.CreateNode(FIO, Position, salary, days, months, years));
    cout << endl;
    mytask.printList();

    cout << "Хотите ли вы внести данные в начало списка ?(0 - нет, 1 - да) \n ";
    int choose1;
    cin >> choose1;

    while (choose1 == 1) {
        string FIO;
        cout << "Введите Фамилию" << endl;
        cin >> FIO;
        string Position;
        cout << "Введите должность" << endl;
        cin >> Position;
        int salary, days, months, years;
        cout << "Введите зарплату" << endl;
        cin >> salary;
        cout << "Введите день рождения" << endl;
        cin >> days;
        cout << "Введите месяц рождения" << endl;
        cin >> months;
        cout << "Введите год рождения" << endl;
        cin >> years;
        mytask.AddFirst(mytask.head, mytask.CreateNode(FIO, Position, salary, days, months, years));
        cout << endl;
        cout << "Хотите продолжить ?(0 - нет, 1 - да)\n ";
        cin >> choose1;
    }

    cout << "Ваш список:\n";
    mytask.printList();

    cout << "Хотите ли вы внести данные в конец списка ?(0 - нет, 1 - да) \n ";
    int choose2;
    cin >> choose2;

    while (choose2 == 1) {
        string FIO;
        cout << "Введите Фамилию" << endl;
        cin >> FIO;
        string Position;
        cout << "Введите должность" << endl;
        cin >> Position;
        int salary, days, months, years;
        cout << "Введите зарплату" << endl;
        cin >> salary;
        cout << "Введите день рождения" << endl;
        cin >> days;
        cout << "Введите месяц рождения" << endl;
        cin >> months;
        cout << "Введите год рождения" << endl;
        cin >> years;
        mytask.AddLast(mytask.head, mytask.CreateNode(FIO, Position, salary, days, months, years));
        cout << endl;
        mytask.printList();

        cout << "Хотите продолжить ?(0 - нет, 1 - да)\n ";
        cin >> choose2;
    }

    cout << "Ваш список:\n";
    mytask.printList();

    cout << "Хотите ли вы найти людей старше 40 лет ?(1 - да, 0 - нет)\n";
    int n;
    cin >> n;
    if (n == 1) {
        mytask.findList(mytask.head);
    }

    cout << "Хотите ли вы найти средний возраст(1 - да, 0 - нет)\n";
    int e;
    cin >> e;
    if (e == 1) {
        mytask.AverAge(mytask.head);
    }

    cout << "Хотите ли вы найти суммарную зарплату(1 - да, 0 - нет)\n";
    int j;
    cin >> j;
    if (j == 1) {
        mytask.SumofList(mytask.head);
    }
}
