using System;

namespace DiscountСalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы хотите добавить новый продукт? 1 - да, 2 - нет");

            int.TryParse(Console.ReadLine(), out var answer);

            if (answer != 1)
                return;

            CreateProduct();

            Console.ReadLine();
        }

        public static void CreateProduct()
        {   
            var product = new Product();
            int x; // целое число для выбора скидки
            int discountValue3; // целое число для присвоения суммы скидки к product.discount value 
            int discountValue1;
            Console.WriteLine("Введите название продукта");

            product.Name = Console.ReadLine();

            Console.WriteLine("Введите стоимость продукта");

            int.TryParse(Console.ReadLine(), out var price);

            while (price == 0)
            {
                Console.WriteLine("Стоимость продукта не была введена или она была введена с ошибкой. Пожалуйста, введите стоимость продукта ещё раз");

                int.TryParse(Console.ReadLine(), out price);
            }

            product.Price = price;
            
            Console.WriteLine("Укажите тип скидки: 1 - Подарочная карта; 2 - % сумма от стоимости; 3 - сумма от стоимости");
            
            while (!int.TryParse(Console.ReadLine(), out  x) || x < 0 || x > 3)
            {
                Console.WriteLine("Ошибка ввода! Повторите попытку.");
              
            }
            product.x = x;
            switch (x){
                case 1:
                    Console.WriteLine("Введите сумму подарочной карты");

                   while(!int.TryParse(Console.ReadLine(), out  discountValue1)){
                        Console.WriteLine("Ошибка! Вводите только цифры!");
                    }
                    product.DiscountValue = discountValue1;
                    Console.WriteLine("Введите дату начала действия карты");

                    DateTime.TryParse(Console.ReadLine(), out var startSellDate1);

                    if (startSellDate1 != DateTime.MinValue)
                    {
                        product.StartSellDate = startSellDate1;
                    }
                    
                    Console.WriteLine("Введите дату окончания действия карты");

                    DateTime.TryParse(Console.ReadLine(), out var endSellDate1);

                    if (endSellDate1 != DateTime.MinValue)
                    {
                        product.EndSellDate = endSellDate1;
                    }
                   
                    break;     
                case 2:
                    Console.WriteLine("Введите значение скидки на товар (в % от общей стоимости)");

                    int.TryParse(Console.ReadLine(), out var discountValue);

                    while (discountValue > 100)
                    {
                        Console.WriteLine("Значение скидки не может быть больше 100");

                        int.TryParse(Console.ReadLine(), out discountValue);
                    }

                    product.DiscountValue = discountValue;

                    Console.WriteLine("Введите дату начала действия скидки");

                    DateTime.TryParse(Console.ReadLine(), out var startSellDate);

                    if (startSellDate != DateTime.MinValue)
                    {
                        product.StartSellDate = startSellDate;
                    }

                    Console.WriteLine("Введите дату окончания действия скидки");

                    DateTime.TryParse(Console.ReadLine(), out var endSellDate);

                    if (endSellDate != DateTime.MinValue)
                    {
                        product.EndSellDate = endSellDate;
                    }

                     break;
                case 3: Console.WriteLine("Введите сумму скидки:");
                    
                   while(!int.TryParse(Console.ReadLine(), out  discountValue3)) {
                        Console.WriteLine("Ошибка! Введите только цифры!");
                     }
                    product.DiscountValue = discountValue3;
                    break;
            }
            Console.WriteLine($"Вы успешно добавили новый продукт: {product.Name}, стоимость - {product.Price}р. {product.GetSellInformation()}");
        }
    }
}
