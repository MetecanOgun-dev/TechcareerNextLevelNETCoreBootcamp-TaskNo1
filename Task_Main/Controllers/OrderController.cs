using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Task_DataAccessLayer.Context;
using Task_EntityLayer.Entities;

namespace Task_Main.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _appContext;
        public OrderController(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public IActionResult EmployeeOrders(int? id)
        {
            if (id.HasValue)
            {
                var orders = _appContext.Orders
                    .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Product)
                    .Where(o => o.EmployeeId == id)
                    .ToList();

                var employee = _appContext.Employees.Where(e1 => e1.EmployeeId == id).FirstOrDefault();
                if (employee != null)
                    ViewBag.EmployeeName = employee.FirstName + " " + employee.LastName;

                foreach (var order in orders)
                {
                    decimal amount = 0;
                    foreach (var item in order.OrderDetails)
                    {
                        amount += item.UnitPrice * item.Quantity;
                    }
                    order.TotalAmount = amount;
                }
                ViewData["Title"] = "EmployeeOrders";
                return View(orders);
            }
            return View();
        }
    }
}
