using System;

namespace FindingAlgorithmWithHeap
{
    public class AlgorithmRealisation
    {
        static void Main(string[] args)
        {
            int[] healthArray = new int[10000];
            int[] topValues = new int[10];
            var heap = new MinHeap(10);

            AlgorithmRealisation p = new AlgorithmRealisation();
            MinHeap minHeap = new MinHeap(10);
            p.FillArrayRandomly(healthArray);
            p.InitialHeapFill(minHeap, healthArray);
            p.IterateThrowRemains(minHeap, healthArray);
            p.WriteTopValues(minHeap, topValues);

            Console.Read();
        }

        public void DisplayArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public void FillArrayRandomly(int[] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1, int.MaxValue);
            }
        }

        public void InitialHeapFill(MinHeap heap, int[] arr)
        {
            for (int i = 0; i < 10; i++)
            {
                heap.Add(arr[i]);
            }
        }

        public void IterateThrowRemains(MinHeap heap, int[] arr)
        {
            for (int i = 10; i < arr.Length; i++)
            {
                int currentHealth = arr[i];

                if (currentHealth > heap.GetMin())
                {
                    heap.ReplaceMin(currentHealth);
                }
            }
        }

        public void WriteTopValues(MinHeap heap, int[] topValues)
        {
            for (int i = 0; i < 10; i++)
            {
                topValues[i] = heap.GetMin(); // Тут записываются итоговые значения
                heap.ReplaceMin(int.MaxValue);
            }
        }
    }
}
