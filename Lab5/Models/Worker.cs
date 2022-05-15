namespace Lab5.Models
{
    public class Worker : Object
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public List<Order> Orders { get; set; }
        public string FullName => $"{LastName} {FirstName} {Patronymic}";
        public override string ToString() => $"{FullName,-45} | {Orders.Count,3}";

    }
}
