using Lab5.Models;
using Lab5.Helperes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Helperes
{
    internal class WorkerHelper
    {
        public static List<Worker> GenerateWorkersList(int count)
        {
            Random random = new Random();
            List<Worker> workers = new List<Worker>();

            for (int i = 0; i < count; i += 2)
            {
                int countOrdersFirsrt = random.Next(1, 181);
                workers.Add(GenerateWorker(i, countOrdersFirsrt, random));
                workers.Add(GenerateWorker(i + 1, 200 - countOrdersFirsrt, random));
            }
            return workers;
        }
        public static Worker GenerateWorker(int id, int countOrders, Random random)
        {
            return new Worker
            {
                Id = id,
                FirastName = NameHelper.GenerateName(random.Next(3, 10)),
                LastName = NameHelper.GenerateName(random.Next(3, 10)),
                Patronymic = NameHelper.GenerateName(random.Next(3, 10)),
                Orders = OrderHelper.GenerateOrdersList(countOrders)
            };
        }
    }
}
