using System;

namespace Shop.Models
{
    public class ProcentSale : Discount
    {
        public byte Procent { get; private set; }

        public ProcentSale(byte procent)
        {
            if (Procent >= 100)
                throw new ArgumentException("Процентная скидка не может быть больше или равна 100%");

            Procent = procent;
        }

        public override decimal Apply(decimal price)
        {
            return price - price * Procent / 100;
        }

        public override string ToString()
        {
            return $"{Procent}% от стоимости";
        }
    }
}