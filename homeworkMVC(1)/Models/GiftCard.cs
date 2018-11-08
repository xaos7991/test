using System;

namespace Shop.Models
{
    public class GiftCard : Discount
    {
        public int Id { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public decimal Balance { get; private set; }
        public string Number { get; private set; }

        private GiftCard() { }

        public GiftCard(string number, decimal balance, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Подарочная карта не может быть без номера");

            if (balance <= 0)
                throw new ArgumentException("Подарочная карта не может быть с нулевым или отрицательным балансом");

            if (endDate <= startDate.AddDays(1))
                throw new ArgumentException("Действие подарочной карты должно быть больше 1 дня");

            Number = number;
            Balance = balance;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override decimal Apply(decimal price)
        {
            if (IsExpiration())
                throw new GiftCardExpirationException(StartDate, EndDate);

            if (price <= Balance)
            {
                Balance -= price;
                return 0;
            }

            return price - Balance;
        }

        private bool IsExpiration()
        {
            return !(StartDate <= DateTime.Now && EndDate >= DateTime.Now);
        }

        public override string ToString()
        {
            return $"Подарочная карта номиналом в {Balance} рублей";
        }
    }
}