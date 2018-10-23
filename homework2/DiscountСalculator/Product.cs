using System;

namespace DiscountСalculator
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int DiscountValue { get; set; }
        public DateTime? StartSellDate { get; set; }
        public DateTime? EndSellDate { get; set; }
        public int x { get; set; }

        public int CalculateDiscountPrice()
        {
            return x == 2 ? DiscountValue != 0 &&
                    StartSellDate.HasValue &&
                    EndSellDate.HasValue &&
                    StartSellDate <= DateTime.UtcNow &&
                    EndSellDate >= DateTime.UtcNow
                ? Price - (Price * DiscountValue / 100)
                : Price : x == 1 ? DiscountValue != 0 &&
                       StartSellDate.HasValue &&
                       EndSellDate.HasValue &&
                       StartSellDate <= DateTime.UtcNow &&
                       EndSellDate >= DateTime.UtcNow
                   ? Price > DiscountValue ? Price - DiscountValue : 0
                   : Price : DiscountValue != 0
                 ? Price > DiscountValue ? Price - DiscountValue : 0
                 : Price;

        }

        public string GetSellInformation()
        {
            return DiscountValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue && x == 2
                ? $"На данный товар действует скидка {DiscountValue}% в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                    $"Сумма с учётом скидки - {CalculateDiscountPrice()}р."
                : x == 1 && DiscountValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue ?  $"Используя бонусную карту на сумму {DiscountValue} р." +
                $"активной с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()} сумма будет составлять: {CalculateDiscountPrice()} р." : x ==3 && DiscountValue != 0 ? $"При использовании скидки в размере {DiscountValue} р. товар будет стоить: {CalculateDiscountPrice()} р." : "В настоящий момент на данный товар нет скидок.";
        }   
    }


}
            
