using System;

namespace FindingAlgorithmWithHeap
{
    public class MinHeap
    {
        private int[] heap;
        private int size;

        public MinHeap(int capacity)
        {
            heap = new int[capacity];
            size = 0;
        }

        public void Add(int value)
        {
            if (size == heap.Length)
            {
                throw new InvalidOperationException("Heap is full");
            }

            heap[size] = value;
            size++;

            int index = size - 1;
            while (index > 0 && heap[index] < heap[(index - 1) / 2])
            {
                Swap(index, (index - 1) / 2);
                index = (index - 1) / 2;
            }
        }

        public int GetMin()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            return heap[0];
        }

        public void ReplaceMin(int value)
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            heap[0] = value;

            int index = 0;
            while (true)
            {
                int leftChildIndex = index * 2 + 1;
                int rightChildIndex = index * 2 + 2;

                if (leftChildIndex >= size)
                {
                    break;
                }

                int minChildIndex = leftChildIndex;
                if (rightChildIndex < size && heap[rightChildIndex] < heap[leftChildIndex])
                {
                    minChildIndex = rightChildIndex;
                }

                if (heap[index] <= heap[minChildIndex])
                {
                    break;
                }

                Swap(index, minChildIndex);
                index = minChildIndex;
            }
        }

        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
