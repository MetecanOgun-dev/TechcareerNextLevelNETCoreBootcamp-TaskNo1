using Microsoft.AspNetCore.Mvc;
using Task_DataAccessLayer.Context;
using Task_EntityLayer.Entities;
using Task_Main.Models;

namespace Task_Main.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _appContext;
        public EmployeeController(AppDbContext appContext)
        {
            _appContext = appContext;

        }
        public IActionResult Index()
        {
            var employees = _appContext.Employees.
                Select(e1 => new Employee
                {
                    EmployeeId = e1.EmployeeId,
                    FirstName = e1.FirstName,
                    LastName = e1.LastName,
                    Title = e1.Title,
                })
                .ToList();
            ViewData["Title"] = "Employees";
            return View(employees);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Title = model.Title
                };

                _appContext.Employees.Add(employee);
                var result = _appContext.SaveChanges();

                ViewData["Title"] = "Add Employee";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
