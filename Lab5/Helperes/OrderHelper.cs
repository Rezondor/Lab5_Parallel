using Lab5.Models;
using Lab5.Helperes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Helperes
{
    public class OrderHelper
    {
        public static List<Order> GenerateOrdersList(int count)
        {
            Random random = new Random();
            List<Order> orders = new List<Order>();
            for (int i = 0; i < count; i++)
            {
                orders.Add(GenerateOrder(random));
            }

            return orders;
        }
        public static Order GenerateOrder(Random random)
        {
            return new Order
            {
                Title = NameHelper.GenerateName(random.Next(3, 10)) + " - Order",
                DateTime = new DateTime(random.Next(1990, 2023), random.Next(1, 13), random.Next(1, 29)),
                Price = random.Next(10, 101) * 1000 / 23 * 77
            };
        }
    }
}