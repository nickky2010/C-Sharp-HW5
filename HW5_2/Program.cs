﻿//                                                          Задание 2 (было в EPAM).
//  Разработать базовый класс, определяющий покупку товара:
//  Поля:
//      ●	название товара;
//      ●	цена в рублях;
//      ●	кол-во единиц товара.
//  Конструкторы:
//      ●	по умолчанию;
//      ●	с параметрами.
//  Методы:
//      ●	установки/считывания полей;
//      ●	GetCost() – вычисляет стоимость покупки;
//      ●	ToString() – переводит объект в строку с разделителями «;»;
//      ●	Equals() – сравнивает две продажи(считаются равными, если совпадают название и цена).
//  Разработать первый производный класс, для покупки товара с фиксированной скидкой от цены и переопределить нужные методы(GetCost( ) и ToString( )).
//  Разработать второй производный класс (от базового) со скидкой к цене, если количество единиц товара не меньше некоторой константы подкласса.Переопределить нужные методы.
//  Разработать консольное приложение, выполняющее следующее:
//      1 Создать массив из шести объектов (2 – базового класса, по 2 – каждого производного класса).
//      2 Вывести массив на консоль.
//      3 Вывести покупку с максимальной стоимостью.
//      4 Определить, являются ли все покупки равными.
//  Задачи 2–4 реализовать в одном общем цикле.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //  1 Создать массив из шести объектов (2 – базового класса, по 2 – каждого производного класса).
            Purchase[] purchases = {
                new Purchase("Кофе", 8.56m, 9),
                new Purchase("Чай", 3.3m, 32),
                new FixedDiscount ("Молоко", 1.11m, 44, 9d),
                new FixedDiscount ("Масло сливочное", 2.77m, 13, 11d),
                new PriceDiscount("Хлеб", 0.99m, 23),
                new PriceDiscount("Батон", 1.32m, 9),
            };
            decimal maxPurchase = 0;    // максимальная стоимость из всех покупок
            int indexMaxPurchase = 0;   // индекс покупки с максимальной стоимостью
            bool equal = true;          // являются ли все покупки равными
            //  Задачи 2–4 реализовать в одном общем цикле.
            for (int i = 0; i < purchases.Length; i++)
            {
                //  2 Вывести массив на консоль.
                if(i==0)
                    Console.WriteLine("Выводим массив покупок на консоль");
                Console.WriteLine(purchases[i]);
                if(maxPurchase < purchases[i].GetCost())
                {
                    maxPurchase = purchases[i].GetCost();
                    indexMaxPurchase = i;
                }
                if(i>0&&equal)
                {
                    equal = purchases[i - 1].Equals(purchases[i]);
                }
                if (i == purchases.Length-1)
                {
                    //  3 Вывести покупку с максимальной стоимостью.
                    Console.WriteLine("\nПокупка с максимальной стоимостью");
                    Console.WriteLine(purchases[indexMaxPurchase]);
                    Console.WriteLine("Стоимость покупки = "+ maxPurchase);
                    //  4 Определить, являются ли все покупки равными.
                    if (equal)
                        Console.WriteLine("\nВсе покупки являются равными");
                    else
                        Console.WriteLine("\nВсе покупки не являются равными");
                }
            }
            Console.ReadKey();
        }
    }
}
