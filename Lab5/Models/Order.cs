namespace Lab5.Models
{
    public class Order
    {
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public int Price { get; set; }
        public override string ToString() => $"{Title,-25} | {Price,-7} | {DateTime.ToShortDateString(),-1}";
    }
}
