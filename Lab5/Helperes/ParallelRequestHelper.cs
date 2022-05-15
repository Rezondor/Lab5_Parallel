using Lab5.Interfaces;
using Lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab5.Helperes.RequestHelper;

namespace Lab5.Helperes
{
    public class ParallelRequestHelper: IRequests
    {
        public int NumberThreads { get; set; }
        public ParallelRequestHelper(int numberThreads)=>NumberThreads = numberThreads;
        public List<Order> GetOrdersWhereFullNameStartsWith(List<Worker> workers, char mark)
        {
            var orders = workers.AsParallel()
                .WithDegreeOfParallelism(NumberThreads)
                .SelectMany(u => u.Orders, (u, l) => new { Worker = u, Orders = l })
                .Where(u => u.Worker.LastName.ToLower().Contains(mark) ||
                u.Worker.FirstName.ToLower().Contains(mark) ||
                u.Worker.Patronymic.ToLower().Contains(mark))
                .Select(u => u.Orders).OrderBy(u => u.DateTime).ToList();
            return orders;

        }
        public List<Order> GetOrdersBeforeOrAfterDate(List<Worker> workers, BeforeOrAfter beforeOrAfter, DateTime dt)
        {
            List<Order> orders = new List<Order>();
            switch (beforeOrAfter)
            {
                case BeforeOrAfter.Before:
                    return orders = workers.AsParallel()
                                    .WithDegreeOfParallelism(NumberThreads)
                                    .SelectMany(u => u.Orders, (u, l) => new { Orders = l })
                                    .Where(u => u.Orders.DateTime < dt)
                                    .Select(u => u.Orders).OrderBy(u => u.DateTime).ToList();
                   
                case BeforeOrAfter.After:
                    return orders = workers.AsParallel()
                                    .WithDegreeOfParallelism(NumberThreads)
                                    .SelectMany(u => u.Orders, (u, l) => new { Orders = l })
                                    .Where(u => u.Orders.DateTime > dt)
                                    .Select(u => u.Orders).OrderBy(u => u.DateTime).ToList();
            }
            return orders;
            
        }

        public List<VR> GetWorkersSortedByAVGOrderPrice(List<Worker> workers)
        {
            var vr = workers.AsParallel()
                    .WithDegreeOfParallelism(NumberThreads)
                    .Select(u => new { Worker = u, AVG = u.Orders.Average(p => p.Price)})
                    .OrderByDescending(u => u.AVG).ToList();
            List<VR> vr1 = new();
            foreach (var item in vr)
            {
                vr1.Add(new VR(item.Worker, item.AVG));
            }
            return vr1;
        }
    }
}
