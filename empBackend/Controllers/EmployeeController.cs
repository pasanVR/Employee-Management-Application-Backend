using Microsoft.AspNetCore.Mvc;
using empBackend.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using empBackend;


namespace empBackend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            return Ok(_context.Employees.ToList());
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        [HttpGet("{id}")]
        public ActionResult GetEmployeeById(long id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(long id, Employee employeeDetails)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();

            employee.FirstName = employeeDetails.FirstName;
            employee.LastName = employeeDetails.LastName;
            employee.EmailId = employeeDetails.EmailId;

            _context.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(long id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
