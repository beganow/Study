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
    HANDLE heap = GetProcessHeap();

    std::cout << "Before Allocation:\n";
    sh(heap);

    // Выделение памяти под массив
    int* myArray = new int[300000];

    std::cout << "\nAfter Allocation:\n";
    sh(heap);

    // Освобождение памяти массива
    delete[] myArray;

    return 0;
}