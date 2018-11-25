//  Разработать второй производный класс (от базового) со скидкой к цене, если количество единиц товара 
//  не меньше некоторой константы подкласса. Переопределить нужные методы.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_2
{
    class PriceDiscount:Purchase
    {
        const int countPurchase = 10;
        double discount;
        public PriceDiscount(string name, decimal price, int count): base(name, price, count)
        {
            if (count >= countPurchase)
                discount = 10d;
            else
                discount = 0d;
        }
        public override string ToString()
        {
            return (base.ToString() + ";" + discount);
        }
        public decimal GetCost()
        {
            return (base.GetCost() - base.GetCost() * ((decimal)discount / 100));
        }

    }
}
