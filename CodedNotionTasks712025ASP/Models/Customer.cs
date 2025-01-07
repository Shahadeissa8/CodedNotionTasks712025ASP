using CodedNotionTasks712025ASP.Models.SharedProp;

namespace CodedNotionTasks712025ASP.Models
{
    public class Customer : BaseProp
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public int CustomerPhone { get; set; }
    }
}
