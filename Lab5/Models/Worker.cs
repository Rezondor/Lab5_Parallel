using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    internal class Worker
    {
        public int Id { get; set; }
        public string FirastName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public List<Order> Orders { get; set; }
        public override string ToString() => $"{Id,-6} | {FirastName, -15} | {LastName,-15} | {Patronymic,-15} | {Orders.Count,3}";

    }
}
