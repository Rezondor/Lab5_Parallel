using Lab5.Models;

namespace Lab5.Helperes
{
    public class WorkerHelper
    {
        public static List<Worker> GenerateWorkersList(int count)
        {
            Random random = new Random();
            List<Worker> workers = new List<Worker>();

            for (int i = 0; i < count; i += 2)
            {
                int countOrdersFirsrt = random.Next(1, 181);
                workers.Add(GenerateWorker(countOrdersFirsrt, random));
                workers.Add(GenerateWorker(200 - countOrdersFirsrt, random));
            }
            return workers;
        }
        public static Worker GenerateWorker(int countOrders, Random random)
        {
            return new Worker
            {
                FirstName = NameHelper.GenerateName(random.Next(3, 10)),
                LastName = NameHelper.GenerateName(random.Next(3, 10)),
                Patronymic = NameHelper.GenerateName(random.Next(3, 10)),
                Orders = OrderHelper.GenerateOrdersList(countOrders)
            };
        }
    }
}
