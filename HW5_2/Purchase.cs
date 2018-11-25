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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_2
{
    class Purchase
    {
        //  Поля и Методы установки/считывания полей;
        //      ●	название товара;
        public string Name { get; set; }
        //      ●	цена в рублях;
        public decimal Price { get; set; }
        //      ●	кол-во единиц товара.
        public int Count { get; set; }
        //  Конструкторы:
        //      ●	по умолчанию;
        public Purchase()
        {
                
        }
        //      ●	с параметрами.
        public Purchase(string name, decimal price, int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }
        //  Методы:
        //      ●	GetCost() – вычисляет стоимость покупки;
        public decimal GetCost()
        {
            return (Price*Count);
        }
        //      ●	ToString() – переводит объект в строку с разделителями «;»;
        public override string ToString()
        {
            string str = Name + ";" + Price + ";" + Count;
            return (str);
        }
        //      ●	Equals() – сравнивает две продажи(считаются равными, если совпадают название и цена).
        public override bool Equals(object obj)
        {
            Purchase p = obj as Purchase;  // не приводит к исключению
            if (p != null)
                return (this.Name == p.Name && this.Price == p.Price);
            return false;
        }
    }
}
