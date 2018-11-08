namespace Shop.Models
{
    public abstract class Discount
    {
        public abstract decimal Apply(decimal price);
    }
}