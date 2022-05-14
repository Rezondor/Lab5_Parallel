using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.Helperes;
using Lab5.Models;

namespace Lab5.Helperes
{
    internal class RequestHelper
    {
        public enum BeforeOrAfter 
        {
            Before, 
            After 
        }
        public static List<Order> GetOrdersWhereFullNameStartsWith(List<Worker> workers,char mark)
        {
            var orders = workers.SelectMany(u => u.Orders,
                                        (u, l) => new { Worker = u, Orders = l })
                                      .Where(u => u.Worker.LastName.ToLower().Contains(mark) ||
                                      u.Worker.FirstName.ToLower().Contains(mark) ||
                                      u.Worker.Patronymic.ToLower().Contains(mark))
                                      .Select(u => u.Orders).OrderBy(u => u.DateTime).ToList();
            return orders;

        }
        public static List<Order> GetOrdersBeforeOrAfterDate(List<Worker> workers,BeforeOrAfter beforeOrAfter ,DateTime dt)
        {
            List<Order> orders = new List<Order>();
            switch (beforeOrAfter)
            {
                case BeforeOrAfter.Before:
                    orders = workers.SelectMany(u => u.Orders, (u,l) => new { Orders = l })
                          .Where(u => u.Orders.DateTime < dt)
                          .Select(u => u.Orders).OrderBy(u => u.DateTime).ToList();
                    break;
                case BeforeOrAfter.After:
                    orders = workers.SelectMany(u => u.Orders, (u, l) => new { Orders = l })
                          .Where(u => u.Orders.DateTime > dt)
                          .Select(u => u.Orders).OrderBy(u => u.DateTime).ToList();
                    break;
            }
         
            
            return orders;
        }
    }
}
