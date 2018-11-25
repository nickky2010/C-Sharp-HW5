//  Разработать первый производный класс, для покупки товара с фиксированной скидкой от цены и 
//  переопределить нужные методы(GetCost( ) и ToString( )).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_2
{
    class FixedDiscount:Purchase
    {
        double discount;
        // конструктор производного класса
        public FixedDiscount(string name, decimal price, int count, double discount) :base(name,price,count)
        {
            if(discount>=0 && discount<=100)
                this.discount = discount;
        }
        public override string ToString()
        {
            return (base.ToString()+";"+discount);
        }
        public decimal GetCost()
        {
            return (base.GetCost() - base.GetCost()*((decimal)discount/100));
        }
    }
}
