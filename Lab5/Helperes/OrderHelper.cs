using Lab5.Models;
using Lab5.Helperes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Helperes
{
    internal class OrderHelper
    {
        public static List<Order> GenerateOrdersList(int count,string WorkerFullName)
        {
            Random random = new Random();
            List<Order> orders = new List<Order>();
            for (int i = 0; i < count; i++)
            {
                orders.Add(GenerateOrder(i, WorkerFullName, random));
            }

            return orders;
        }
        public static Order GenerateOrder(int id, string WorkerFullName, Random random)
        {
            return new Order
            {
                Id = id,
                Title = NameHelper.GenerateName(random.Next(3, 10)) + " - Order",
                DateTime = new DateTime(random.Next(1990, 2023), random.Next(1, 13), random.Next(1, 29)),
                Price = random.Next(10, 101) * 1000 / 23 * 77,
                WorkerFullName = WorkerFullName

            };
        }
    }
}