using System.Net;
using CodedNotionTasks712025ASP.Models;
using CodedNotionTasks712025ASP.Models.SharedProp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace CodedNotionTasks712025ASP.Controllers
{
    public class CustomersController : Controller
    {
        static List<Customer> CustomersList = new List<Customer>()
         {
             new Customer
             {
                 CustomerId =1 ,
                 CustomerName = "Shahad",
                 Email= "Shahad@gmail.com",
                 City = "Assima",
                 CustomerPhone = 77077708,
                 CreationDate = DateTime.Now,
                 IsActive = true,
                 IsDeleted = true
             },
             new Customer
             {
                 CustomerId =2,
                 CustomerName = "Kai",
                 Email= "Kai@gmail.com",
                 City = "Hawalli",
                 CustomerPhone = 76650038,
                 CreationDate = DateTime.Now,
                 IsActive = false,
                 IsDeleted = true
             },
             new Customer
             {
                 CustomerId =3,
                 CustomerName = "Shay",
                 Email= "Shay@gmail.com",
                 City = "Ahmadi",
                 CustomerPhone = 76787890,
                 CreationDate = DateTime.Now,
                 IsActive = true,
                 IsDeleted = false
             }
         };
        public IActionResult GetAllCustomers(int? id)
        {
            if (id == 1)
            {
                ViewBag.Status = "Active Customer";
                return View(CustomersList.Where(x=>x.IsActive).OrderByDescending(x => x.CustomerId));
            }
            else if (id==0)
            {
                ViewBag.Status = "Non Active Customer";
                return View(CustomersList.Where(x => x.IsActive==false).OrderByDescending(x => x.CustomerId));
            }
            ViewBag.Status = "All Customers";
            return View(CustomersList.OrderByDescending(x => x.CustomerId));
        }
        // before we add active non sactive tabs:
        // public IActionResult GetAllCustomers()
        //{

        //    return View(CustomersList);
        //}
        /* to order by firsst to last
        public IActionResult GetAllCustomers()
        {
        return view(CustomersList.OrderByDescending(x=>x.CustomerId));
        */
        public IActionResult Details(int?id) 
        {
            if (id == null)
            {
                return RedirectToAction("GetAllCustomers");
            }
            var temp = (from All in CustomersList
                       where All.CustomerId == id 
                       select All).SingleOrDefault();
            if (temp == null)
            {
                return RedirectToAction("GetAllCustomers");
            }
        return View(temp);//the name id is important to be the same here and in route in the view
        }
        //perfebly we make two controllers
        List<Order> OrdersList = new List<Order>
         {
             new Order
             {
                 OrderId=1,
                 OrderDate= DateTime.Now,
                 Product = "Ipad",
                 TotalAmount=300.9,
                 CustomerId = 1,
                 CreationDate = DateTime.Now,
                 IsActive = true,
                 IsDeleted = true
             },
             new Order
             {
                 OrderId = 2,
                 OrderDate = DateTime.Now,
                 Product = "Galaxy",
                 TotalAmount=200.99,
                 CustomerId = 1,
                 CreationDate = DateTime.Now,
                 IsActive = false,
                 IsDeleted = true
             },
             new Order
             {
                 OrderId=3,
                 OrderDate = DateTime.Now,
                 CreationDate = DateTime.Now,
                 Product = "Iphone",
                 TotalAmount=500,
                 CustomerId = 2,
                 IsActive = true,
                 IsDeleted = false
             }
         };
        public IActionResult CustomersOrders(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("CustomersOrders");
            }//if we dont enter an id whats so ever like we wrote details only

            var temp2 = (from all2 in OrdersList
                         where all2.CustomerId == id
                         select all2);
            //temp2 any means if it has no data whatsoever, null isnt alway accurate cuz it ignores????? data
            if (temp2 == null || !temp2.Any())
            {
                return RedirectToAction("NoOrders");
            }//if we wrote number in id that doesnt exist whatsoever
            return View(temp2);
        }
        public IActionResult NoOrders()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer cust)
        {
            CustomersList.Add(cust);
            return RedirectToAction(nameof(GetAllCustomers)); //we can write (namrof(GetAllCustomers))
        }
        public IActionResult OrdersDetails(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("CustomersOrders");
            }
            var tempe = (from All in OrdersList
                        where All.OrderId == id
                        select All).SingleOrDefault();
            if (tempe == null)
            {
                return RedirectToAction("CustomersOrders");
            }
            return View(tempe);//the name id is important to be the same here and in route in the view
        }
    }
}