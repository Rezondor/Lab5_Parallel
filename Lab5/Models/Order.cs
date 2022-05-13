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
        public DateTime DateTime { get; set; }

        public override string ToString() => $"{Id,-5} | {Title,-20} | {DateTime.ToShortDateString(),-1}";
    }
}
