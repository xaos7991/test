using System;

namespace Shop.Models
{
    public class GiftCardExpirationException : Exception
    {
        public GiftCardExpirationException(DateTime startDate, DateTime endDate) : base($"Срок действия карты прошел, карта была действительна с {startDate} по {endDate}")
        {
        }
    }
}