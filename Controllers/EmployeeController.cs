using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ostim.Models;
using System;

namespace Ostim.Controllers
{
    public class EmployeeController : Controller
    {
        private List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 0, Name = "Martin", Surname = "Simpson",
                BirthDate = new DateTime(1992, 12, 3),
                Position = "Marketing Expert", Image="/images/Martin.jpg"
            },
            new Employee
            {
                Id = 1, Name = "Jacob", Surname = "Hawk",
                BirthDate = new DateTime(1995, 10, 2), Position = "Manager", Image="/images/Jacob.jpg"
            },
            new Employee
            {
                Id = 2, Name = "Elizabeth", Surname = "Geil",
                BirthDate = new DateTime(2000, 1, 7),
                Position = "Software Engineer", Image="/images/Elizabeth.jpg"
            },
            new Employee
            {
                Id = 3, Name = "Kate", Surname =  "Metain",
                BirthDate = new DateTime(1997, 2, 13),
                Position = "Admin", Image="/images/Kate.jpg"
            },
            new Employee
            {
                Id = 4, Name = "Michael", Surname = "Cook",
                BirthDate = new DateTime(1990, 12, 25),
                Position = "Marketing expert", Image="/images/Michael.jpg"
            },
            new Employee
            {
                Id = 5, Name = "John", Surname = "Snow",
                BirthDate = new DateTime(2001, 7, 15),
                Position = "Software Engineer", Image="/images/John.jpg"
            },
            new Employee
            {
                Id = 6, Name = "Nina", Surname = "Soprano",
                BirthDate = new DateTime(1999, 9, 30),
                Position = "Software Engineer", Image="/images/Nina.jpg"
            },
            new Employee
            {
                Id = 7, Name = "Tina", Surname = "Fins",
                BirthDate = new DateTime(2000, 5, 14),
                Position = "Team Leader", Image="/images/Tina.jpg"
            }
        };
        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(_employees);
        }

        public ActionResult Details(int id)
        {
            Employee employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            Employee employee = _employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            
            if (ModelState.IsValid)
            {
                return RedirectToAction("Update");
            }
            return View(employee);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee empolyee)
        {
            if (ModelState.IsValid)
            {
                using var context = new EmployeeDbContext();
                context.Employee.Add(empolyee);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Something went wrong");
            return View(empolyee);
        }


        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        public IActionResult SalaryDetails()
        {
            using var context = new EmployeeDbContext();
            var employeeSalaryDetails = context.Employee
                .Select(e => new EmployeeSalaryDto
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    CompanyName = e.Company.Name,
                    NetSalary = e.SalaryInfo.Net,
                    GrossSalary = e.SalaryInfo.Gross
                })
                .ToList();
            return View(employeeSalaryDetails);
        }
    }
}
