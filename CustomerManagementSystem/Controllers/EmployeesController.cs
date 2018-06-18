using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem;

namespace CustomerManagementSystem.Controllers
{
    /// <summary>
    /// Controller class for Employees (Create, Read, Update, Delete)
    /// which also inherits MVC Controller class
    /// </summary>
    public class EmployeesController : Controller
    {
        // AppDbContext variable is set to private
        // and readonly which makes it to be assigned once
        // and to avoid reading from the public scope
        private readonly AppDbContext _context;

        
        // message which can be displayed according to user actions
        //public string Message { get; set; }

        /// <summary>
        /// Instantiation of Employees Controller while
        /// initializing AppDbContext variable
        /// </summary>
        /// <param name="context"></param>
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Employees
        /// The Employees will be added to a list
        /// Asynchronously. Finally, the view will display all
        /// the available employees
        /// </summary>
        /// <returns>View with Employees List</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        /// <summary>
        /// GET: Employees/Details/:id
        /// Diplays an Employee according to
        /// the user specified Employee ID else display error
        /// if not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View with an Employee</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        /// <summary>
        /// GET: Employees/Create
        /// Display Create View Page
        /// </summary>
        /// <returns>Create View Page</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Employees/Create
        /// Binds an Employee with the user
        /// specified details and adds to db.
        /// Then the user is redirect to the Employees Index Page
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Create View Page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Role,Gender,Address")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(employee);
                await _context.SaveChangesAsync();
                //Message = "";
                //ViewBag.Message = "Employee {employee.Name} added!";
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        /// <summary>
        ///  GET: Employees/Edit/:id
        ///  Display updated Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        /// <summary>
        /// POST: Employees/Edit/:id
        /// Updates an Employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Role,Gender,Address")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        /// <summary>
        /// GET: Employees/Delete/:id
        /// Gets Deleted User specified Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        /// <summary>
        /// POST: Employees/Delete/:id
        /// Deletes an User specified Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks if the Employee exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
