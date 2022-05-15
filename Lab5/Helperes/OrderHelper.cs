using Lab5.Models;

namespace Lab5.Helperes
{
    public class OrderHelper
    {
        public static List<Order> GenerateOrdersList(int count)
        {

            List<Order> orders = new List<Order>(count);
            /*for(int i = 0; i < count; i++)
            {
                orders.Add(GenerateOrder());
            }*/
            Parallel.For(0, count, i => orders.Add(GenerateOrder()));

            return orders;
        }
        public static Order GenerateOrder()
        {
            Random random = new Random();
            return new Order
            {
                Title = NameHelper.GenerateName(random.Next(3, 10)) + " - Order",
                DateTime = new DateTime(random.Next(1990, 2023), random.Next(1, 13), random.Next(1, 29)),
                Price = random.Next(10, 101) * 1000 / 23 * 77
            };
        }
    }
}