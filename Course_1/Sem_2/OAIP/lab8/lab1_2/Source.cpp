#include <iostream>
using namespace std;

int main()
{
    int m[5];
    for (int i = 0; i < 5; ++i)
    {
        cin >> m[i];
    }
        for (int i = 0; i < 5; ++i)
        {
            if (m[i] < 0)
            {
                m[i] *= 0;
            }
        }
    cout << endl;
    for (int i = 0; i < 5; ++i)
    {
        cout << m[i] << ' ' ;
    }
    return 0;
}