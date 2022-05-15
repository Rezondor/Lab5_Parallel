using Lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab5.Helperes.RequestHelper;

namespace Lab5.Interfaces
{
    internal interface IRequests
    {
        public List<Order> GetOrdersWhereFullNameStartsWith(List<Worker> workers, char mark);
        public List<Order> GetOrdersBeforeOrAfterDate(List<Worker> workers, BeforeOrAfter beforeOrAfter, DateTime dt);
        public List<VR> GetWorkersSortedByAVGOrderPrice(List<Worker> workers);
    }
}
