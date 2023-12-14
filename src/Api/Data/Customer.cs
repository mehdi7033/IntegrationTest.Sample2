using System.Data;

namespace Api.Data
{
    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
