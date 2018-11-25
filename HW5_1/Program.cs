//                                                  Задание 1.
//  Создать класс «Одномерный массив», в котором описать следующие элементы: 
//      •	закрытое поле – массив целых чисел, 
//      •	свойство для определения длины массива,
//      •	индексатор для доступа к элементам поля-массива,  
//      •	конструктор с параметрами,
//      •	метод ToString(), 
//      •	статический метод с переменным числом параметров для вычисления общей суммы отрицательных элементов в нескольких массивах, 
//      •	операции умножения массива на целое число и числа на массив,
//      •	унарная операция - (знаки элементов меняются на противоположные)
//      •	операция неявного преобразования строки в объект этого класса (Например, строка вида «1 2 -4 3 -2» 
//  преобразуется в объект класса Одномерный массив с полем-массивом (1 2 -4 3 -2) ).  
//  При попытке неявного преобразования строки неправильного формата должно генерироваться исключение.

//  Разработать программу, выполняющую следующие действия:
//      	Ввод и вывод трех массивов A, В и С;
//      	Вычисление общей суммы отрицательных элементов в массивах 5* A и С;
//      	Вычисление общей суммы отрицательных элементов в массивах 2* В, -А и С*4;
//      	Если сумма отрицательных элементов в массиве –А больше суммы отрицательных элементов в массиве А, 
//  заменить все отрицательные повторяющиеся элементы этого массива на значение этой суммы.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW5_1.Extend;

namespace HW5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            //	Ввод и вывод трех массивов A, В и С;
                SingleArray A = null;
                SingleArray B = null;
                SingleArray C = null;
                for (int i = 0, size = 0; i < 3; i++)
                {
                    if (!CheckAndInput.InputData(ref size, "Введите размер массива " + (char)('A' + i) + ": "))
                        throw new Exception("Ошибка! Неправильный ввод размера массива  " + (char)('A' + i) + "!");
                    if (i == 0)
                        A = new SingleArray(size);
                    else if (i == 1)
                        B = new SingleArray(size);
                    else
                        C = new SingleArray(size);
                    for (int j = 0, n = 0; j < size; j++)
                    {
                        if (!CheckAndInput.InputData(ref n, (char)('A' + i) + "[" + j + "] = "))
                            throw new Exception("Ошибка! Неправильный ввод " + j + " элемента массива " + (char)('A' + i) + "!");
                        if (i == 0)
                            A[j] = n;
                        else if (i == 1)
                            B[j] = n;
                        else
                            C[j] = n;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Массив А:\n" + A);
                Console.WriteLine("Массив B:\n" + B);
                Console.WriteLine("Массив C:\n" + C);
                //  	Вычисление общей суммы отрицательных элементов в массивах 5*A и С;
                Console.WriteLine("Общая сумма отрицательных элементов в массивах 5*A и С = " + SingleArray.TotalSumNegativeElem((5 * A), C));
                //  	Вычисление общей суммы отрицательных элементов в массивах 2*В, -А и С*4;
                Console.WriteLine("Общая сумма отрицательных элементов в массивах 2*В, -А и С*4 = " + SingleArray.TotalSumNegativeElem((2 * B), -A, C * 4));
                //  	Если сумма отрицательных элементов в массиве –А больше суммы отрицательных элементов в массиве А, 
                //  заменить все отрицательные повторяющиеся элементы этого массива на значение этой суммы.
                int sumNegA;
                int[] indexRec = null;
                int[] t;
                int countAnalog = 0;
                A = -A; //меняем знаки из-за стр 70
                Console.WriteLine("Общая сумма отрицательных элементов в массиве А = " + SingleArray.TotalSumNegativeElem(A));
                Console.WriteLine("Общая сумма отрицательных элементов в массиве -А = " + SingleArray.TotalSumNegativeElem(-A));
                A = -A; //меняем знаки из-за стр 79
                if (SingleArray.TotalSumNegativeElem(A) < SingleArray.TotalSumNegativeElem(-A))
                {
                    sumNegA = SingleArray.TotalSumNegativeElem(A);
                    A = -A; //меняем знаки из-за стр 81
                    for (int i = A.GetLength() - 1; i > 1; i--)
                    {
                        for (int j = i - 1; j > 0; j--)
                        {
                            if (A[i] < 0 && A[j] < 0 && A[i] == A[j])
                            {
                                if (countAnalog == 0)
                                {
                                    A[i] = A[j] = sumNegA;
                                    indexRec = new int[++countAnalog];
                                    indexRec[countAnalog - 1] = j;
                                }
                                else
                                {
                                    for (int n = 0; n < countAnalog; n++)
                                    {
                                        if (indexRec[n] == j)
                                            continue;
                                    }
                                    A[i] = A[j] = sumNegA;
                                    t = indexRec;
                                    indexRec = new int[++countAnalog];
                                    for (int n = 0; n < countAnalog - 1; n++)
                                    {
                                        indexRec[n] = t[n];
                                    }
                                    indexRec[countAnalog - 1] = j;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Cумма отрицательных элементов в массиве –А больше суммы отрицательных элементов в массиве А");
                    Console.WriteLine("заменяем все отрицательные повторяющиеся элементы этого массива на значение этой суммы");
                    Console.WriteLine("Массив А:\n" + A);
                }
                else
                    Console.WriteLine("Cумма отрицательных элементов в массиве –А меньше либо равно сумме отрицательных элементов в массиве А");
                //SingleArray D = "1 2 -4 3 -2";
                //Console.WriteLine("Массив D:\n" + D);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
