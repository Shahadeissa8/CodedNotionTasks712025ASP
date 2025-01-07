using CodedNotionTasks712025ASP.Models.SharedProp;

namespace CodedNotionTasks712025ASP.Models
{
    public class Order : BaseProp2
    {
        public int OrderId{ get; set; }
        public DateTime OrderDate{ get; set; }
        public string Product{ get; set; }
        public double TotalAmount{ get; set; }
        //mapping customer + order (by customer id)
        public int CustomerId{ get; set; }
    }
}
