using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArrayInputSort
{
    class Program
    {
        static String input;
        static double d;
        static int choiseSort;
        static void Main(string[] args)
        {
            int size = InputArrayStart();
            while (size <= 0)
            {
                size = InputArrayStart();
            }
            int[] array = new int[size];
            Console.WriteLine("Созданный массив");
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {                
                int number = random.Next(0, 50);
                array[i] = number;
                Console.WriteLine(array[i]);
            }
            Console.WriteLine();
            InputAction(array);
        }

        private static void InputAction(int[] arr)
        {
            Console.WriteLine("Чтобы сотсортировать массив пузырьком нажмите 1, чтобы сотсортировать массив шеллом нажмите 2");
            input = Console.ReadLine();
            int temp;
            if (double.TryParse(input, out d))
            {
                int actionNum = Convert.ToInt32(input);
                Stopwatch stopwatch = new Stopwatch();
                switch (actionNum)
                {
                    case 1:
                        choiseSort = actionNum;
                        stopwatch.Start();
                        for (int i = 0; i < arr.Length; i++)
                        {
                            for (int j = 0; j < arr.Length - 1; j++)
                            {
                                if (arr[j] > arr[j + 1])
                                {
                                    temp = arr[j];
                                    arr[j] = arr[j + 1];
                                    arr[j + 1] = temp;
                                }
                            }
                        }
                        stopwatch.Stop();
                        showArraySorted(arr, stopwatch.ElapsedMilliseconds);
                        break;

                    case 2:
                        choiseSort = actionNum;
                        int step = arr.Length / 2;
                        stopwatch.Start();
                        while (step >= 1)
                        {
                            for (int i = step; i < arr.Length; i++)
                            {
                                int j = i;
                                while ((j >= step) && (arr[j - step] > arr[j]))
                                {
                                    temp = arr[j];
                                    arr[j] = arr[j - step];
                                    arr[j - step] = temp;
                                    j = j - step;
                                }
                            }
                            step /= 2;
                        }
                        stopwatch.Stop();
                        showArraySorted(arr, stopwatch.ElapsedMilliseconds);
                        break;
                    default:
                        Console.WriteLine("Вы ошиблись с вводом, попробуйте снова");
                        InputAction(arr);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Вы ввели символ с клавиатуры, а вам нужно ввести только числа 1 или 2");
                InputAction(arr);
            }
        }

        private static int InputArrayStart()
        {
            Console.WriteLine("Введите длинну массива");
            input = Console.ReadLine();
            if (double.TryParse(input, out d))
            {
                if (d > 0)
                {
                    Console.WriteLine();
                    return Convert.ToInt32(input);
                }
                else
                {
                    Console.WriteLine("Введенный массив не должен быть меньше 0. Повторите снова");
                    Console.WriteLine();
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("Введите только целое число для корректной работы. Повторите дейсвие корректно");
                Console.WriteLine();
                return 0;
            }
        }

        private static void showArraySorted(int[] arr, long time)
        {
            Console.WriteLine("Отсортированный массив:");
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine();
            switch (choiseSort)
            {
                case 1:
                    Console.WriteLine("Время выполнения сортировки \"Пузырьком\" " + time + " сек");
                    break;
                case 2:
                    Console.WriteLine("Время выполнения сортировки \"Шелла\" " + time + " сек");
                    break;
            }
        }
    }
}
