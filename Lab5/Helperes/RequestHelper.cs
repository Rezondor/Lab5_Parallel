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
        public static List<Order> GetOrdersWhereFullNameStartsWith(List<Worker> workers,char mark)
        {
            //var selectedWorkers = a.Where(x => x.LastName.ToLower().StartsWith("t")&& x.FirastName.ToLower().Contains('a'));
            var selectedWorkers = workers.SelectMany(u => u.Orders,
                                        (u, l) => new { Worker = u, Orders = l })
                                      .Where(u => u.Worker.LastName.ToLower().Contains(mark) ||
                                      u.Worker.FirstName.ToLower().Contains(mark) ||
                                      u.Worker.Patronymic.ToLower().Contains(mark))
                                      .Select(u => u.Orders).OrderBy(u => u.DateTime).ToList();
            return selectedWorkers;

        }
    }
}
