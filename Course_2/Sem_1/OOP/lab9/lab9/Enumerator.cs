namespace lab9
{
    public interface Enumerator
    {
        bool MoveNext(); // перемещение на одну позицию вперед в контейнере элементов
        object Current { get; }  // текущий элемент в контейнере
        void Reset(); // перемещение в начало контейнера

    }
}