using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    internal class Worker: Object
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public List<Order> Orders { get; set; }
        public string FullName => $"{LastName} {FirstName} {Patronymic}";
        public override string ToString() => $"{Id,-6} | {FullName,-45} | {Orders.Count,3}";

    }
}
