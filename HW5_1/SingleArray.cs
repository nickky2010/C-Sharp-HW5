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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_1
{
    class SingleArray
    {
        //  •	закрытое поле – массив целых чисел
        private int[] array;
        //  •	свойство для определения длины массива
        public int GetLength()
        {
            int n = 0;
            foreach (int item in array)
            {
                n++;
            }
            return (n);
        }
        //  •	индексатор для доступа к элементам поля-массива
        public int this[int i] { get => array[i]; set => array[i] = value; }
        //  •	конструктор с параметрами
        public SingleArray(int size)
        {
            if (size > 0)
                array = new int[size];
            else 
                throw new Exception("Размер массива должен быть больше 0!");
        }
        public SingleArray(int[] array)
        {
            this.array = array;
        }

        //  •	метод ToString()
        public override string ToString()
        {
            string str="";
            for (int i = 0; i < array.Length; i++)
            {
                if (i != array.Length - 1)
                    str += array[i] + " ";
                else
                    str += array[i];
            }
            return (str);
        }
        //  •	статический метод с переменным числом параметров для вычисления общей суммы отрицательных элементов в нескольких массивах
        public static int TotalSumNegativeElem(params SingleArray [] arrays)
        {
            int sumNegative = 0;
            foreach (SingleArray arr in arrays)
            {
                for (int i = 0; i < arr.GetLength(); i++)
                {
                    if (arr.array[i] < 0)
                        sumNegative += arr.array[i];
                }
            }
            return (sumNegative);
        }
        //  •	операции умножения массива на целое число и числа на массив
        public static SingleArray operator *(SingleArray array, int x)
        {
            SingleArray singleArray = new SingleArray(array.array);
            for (int i = 0; i < singleArray.GetLength(); i++)
            {
                singleArray[i] *= x; 
            }
            return (singleArray);
        }
        public static SingleArray operator *(int x, SingleArray array)
        {
            SingleArray singleArray = new SingleArray(array.array);
            for (int i = 0; i < singleArray.GetLength(); i++)
            {
                singleArray[i] *= x;
            }
            return (singleArray);
        }
        //  •	унарная операция - (знаки элементов меняются на противоположные)
        public static SingleArray operator -(SingleArray array)
        {
            SingleArray singleArray = new SingleArray(array.array);
            for (int i = 0; i < singleArray.GetLength(); i++)
            {
                singleArray[i] = -singleArray[i];
            }
            return (singleArray);
        }
        //  •	операция неявного преобразования строки в объект этого класса (Например, строка вида «1 2 -4 3 -2» 
        //  преобразуется в объект класса Одномерный массив с полем-массивом (1 2 -4 3 -2) ).  
        //  При попытке неявного преобразования строки неправильного формата должно генерироваться исключение.
        public static implicit operator SingleArray(string str)
        {
            string tmp = "";
            int countElem = 0;
            int[] arr = null;
            int[] t;
            int x;
            for (int i = 0; i < str.Length; i++)
            {
                if((str[i] <'0' && str[i] > '9')&&str[i]!=' '&&str[i]!='-')
                    throw new Exception("Ошибка! Введен неправильный формат строки для инициализации массива");
                if (str[i] == '-' || (str[i] >= '0' && str[i] <= '9'))
                {
                    tmp += str[i];
                    if(i!=str.Length-1)
                        continue;
                }
                x = Convert.ToInt32(tmp);
                t = arr;
                arr = new int[++countElem];
                for (int j = 0; j < countElem-1; j++)
                {
                    arr[j] = t[j];
                }
                arr[countElem - 1] = x;
                tmp = "";
            }
            SingleArray singleArray = new SingleArray(arr);
            return (singleArray);
        }
    }
}
