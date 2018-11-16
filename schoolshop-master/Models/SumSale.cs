using System;

namespace Shop.Models
{
    public class SumSale : Discount
    {
        public decimal Sum { get; private set; }

        public SumSale(decimal sum)
        {
            Sum = sum;
        }

        public override decimal Apply(decimal price)
        {
            if (price <= Sum)
                throw new ArgumentException("Итоговая сумма не может быть меньше размера скидки");

            return price - Sum;
        }

        public override string ToString()
        {
            return $"Cумма от стоимости {Sum}";
        }
    }
}