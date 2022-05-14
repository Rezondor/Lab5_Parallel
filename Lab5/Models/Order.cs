using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string WorkerFullName { get; set; } = "";
        public DateTime DateTime { get; set; }
        public int Price { get; set; }
        public override string ToString() => $"{Id,-5} | {Title,-25}| {WorkerFullName,-40} | {Price,-7} | {DateTime.ToShortDateString(),-1}";
    }
}
