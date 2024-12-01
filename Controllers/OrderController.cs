using Microsoft.AspNetCore.Mvc;
using SPO.Models;
using SPO.Services;

namespace SPO.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var orders = context.orders.OrderByDescending(p=>p.id).ToList();
            return View(orders);
        }


        public IActionResult Create() { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderDto orderDto)
        {

            if (!ModelState.IsValid)
            {
                return View(orderDto);
            }

            Order iteam = new Order();
            iteam.orderId= orderDto.orderId;
            iteam.customerName= orderDto.customerName;
            iteam.sweaterType = orderDto.sweaterType;
            iteam.quantity = orderDto.quantity;
            iteam.orderDate= ""+DateTime.Now;
            iteam.status= orderDto.status;

            context.orders.Add(iteam);
            context.SaveChanges();

            return RedirectToAction("Index","Order");
        }



        public IActionResult Edit( int id)
        {
            var order= context.orders.Find(id);

            if (order==null)
            {
                return RedirectToAction("Index", "Order");
            }


            var orderDto = new OrderDto()
            {
                orderId = order.orderId,
                customerName = order.customerName,
                sweaterType = order.sweaterType,
                quantity = order.quantity,
                status = order.status
            };
            return View(orderDto);
        }



        [HttpPost]
        public IActionResult Edit(int id,OrderDto orderDto)
        {
            var order = context.orders.Find(id);

            if (order == null)
            {
                return RedirectToAction("Index", "Order");
            }

            if (!ModelState.IsValid)
            {
                return View(orderDto);
            }

            order.orderId = orderDto.orderId;
            order.customerName = orderDto.customerName;
            order.sweaterType = orderDto.sweaterType;
            order.quantity = orderDto.quantity;
            order.status = orderDto.status;

            context.SaveChanges();
            return RedirectToAction("Index", "Order");
        }


        public IActionResult Delete(int id) {

            var order = context.orders.Find(id);

            if (order == null)
            {
                return RedirectToAction("Index", "Order");
            }

            context.orders.Remove(order);
            context.SaveChanges();
            return RedirectToAction("Index", "Order");
        }

    }
}
