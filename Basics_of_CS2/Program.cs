using System.Diagnostics.Metrics;

namespace Basics_of_CS2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool equals = false;
            const int size = 15;
            float sum = 0;
            int min = int.MaxValue, 
                max = int.MinValue,
                count = 0,
                tmp = 11,
                ind = 0;
            Random rnd = new Random();

            int[] arr = new int[size];
            int[] arr2 = new int[arr.Length];

            Console.Write(" Array : ");
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(-10, 11);

                // Task 1
                if (min > arr[i]) min = arr[i];
                if (max < arr[i]) max = arr[i];

                // Task 3
                if (arr[i] % 2 == 0 && i % 2 != 0)
                {
                    sum += arr[i];
                    ++count;
                }

                // Task 4
                if (arr[i] % 2 != 0 && arr[i] < 0)
                {
                    arr2[ind] = arr[i];
                    ++ind;
                }

                Console.Write(arr[i] + (i != size-1 ? " , " : ""));  
            }

            // Task 2
            Array.Sort(arr);
            foreach (var val in arr)
            {
                if (tmp == val)
                {
                    equals = true;
                    break;
                }
                tmp = val;
            }

            Array.Resize(ref arr2, ind);
            Console.WriteLine($"\n\n Max element in Array  = {max}");
            Console.WriteLine($"\n Min element in Array  = {min}");
            Console.WriteLine($"\n Identical elements {(equals ? "are" :"not")} present");
            Console.WriteLine($"\n Arithmetic mean of all even elements of the Array = {sum/count}");
            Console.Write($"\n Сopied even elements less than zero : ");
            for (int i = 0; i < arr2.Length; i++)
                Console.Write(arr2[i] + (i != arr2.Length - 1 ? " , " : ""));
            Console.WriteLine("\n\n");

            // Task 5
            Array.Resize(ref arr2, size);
            int[] arr3 = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(10, 31);
                arr2[i] = rnd.Next(10, 31);
                arr3[i] = arr[i] + arr2[i];
            }

            Console.Write(" Array1 : ");
            for (int i = 0; i < size; i++)
                Console.Write(arr[i] + (i != size - 1 ? " , " : ""));
            Console.WriteLine("\n");

            Console.Write(" Array2 : ");
            for (int i = 0; i < size; i++)
                Console.Write(arr2[i] + (i != size - 1 ? " , " : ""));
            Console.WriteLine("\n");
            //Array.Sort(arr3);
            //Array.Reverse(arr3);
            Console.Write(" Array3 : ");
            for (int i = 0; i < size; i++)
                Console.Write(arr3[i] + (i != size - 1 ? " , " : ""));
            Console.WriteLine("\n");
           
            // Task 6
            count = 0;
            max = 0;
            tmp = 1;
            int[,] matrix = new int[size ,2];
            for (int i = 0; i < size - 1; i++)
            {
                if (arr3[i] >= arr3[i + 1]) 
                {
                    matrix[count++,1] = i;
                    matrix[count,0] = i + 1;
                }
            }
            matrix[count, 1] = size - 1;
            for (int i = 0; i < size; i++)
            {
                if (matrix[i, 1] == 0 && i != 0) break;
                if (max < matrix[i, 1] - matrix[i, 0]) max = matrix[i, 1] - matrix[i, 0];
            }
            if (max != 0)
            {
                Console.WriteLine(" The largest sequences by growth in Array3 :\n");
                for (int i = 0; i < size; i++)
                {
                    if (matrix[i, 1] == 0 && i != 0) break;
                    if (max == matrix[i, 1] - matrix[i, 0])
                    {
                        Console.Write($" {tmp++}) ");
                        for (int y = matrix[i, 0]; y <= matrix[i, 1]; y++)
                            Console.Write(arr3[y] + (y != matrix[i, 1] ? " , " : ""));
                        Console.WriteLine("\n");
                    }
                }
            }
            else Console.WriteLine(" The Array3 does not have ascending sequence.\n");
            Console.ReadKey();
        }
    }
}