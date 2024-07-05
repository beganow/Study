#include <iostream>
#include <windows.h>

void sh(HANDLE heap) {
    PROCESS_HEAP_ENTRY entry;
    SIZE_T totalSize = 0, allocatedSize = 0, freeSize = 0;

    entry.lpData = NULL;
    while (HeapWalk(heap, &entry)) {
        totalSize += entry.cbData;
        if (entry.wFlags & PROCESS_HEAP_ENTRY_BUSY) {
            allocatedSize += entry.cbData;
        }
        else {
            freeSize += entry.cbData;
        }
    }

    std::cout << "Total Heap Size: " << totalSize << " bytes\n";
    std::cout << "Allocated Size: " << allocatedSize << " bytes\n";
    std::cout << "Free Size: " << freeSize << " bytes\n";
}

int main() {
    // Создание пользовательской кучи с начальным размером 4MB
    HANDLE customHeap = HeapCreate(0, 4 * 1024 * 1024, 0);

    std::cout << "Before Allocation:\n";
    sh(customHeap);

    // Выделение памяти под массив
    int* myArray = (int*)HeapAlloc(customHeap, 0, 300000 * sizeof(int));

    std::cout << "\nAfter Allocation:\n";
    sh(customHeap);

    // Освобождение памяти массива
    HeapFree(customHeap, 0, myArray);

    // Уничтожение пользовательской кучи
    HeapDestroy(customHeap);

    return 0;
}