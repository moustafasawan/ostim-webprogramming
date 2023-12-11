using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Ostim.Models;

namespace Ostim.Controllers
{
    public class CompanyController : Controller
    {
        private readonly EmployeeDbContext _context;

        public CompanyController(EmployeeDbContext context)
        {
            _context = context;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var companies = _context.Companies
                .Select(c => new CompanyDetailsDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    NumberOfEmployees = c.Employees.Count()
                })
                .ToList();

            return View(companies);
        }
    }
}
