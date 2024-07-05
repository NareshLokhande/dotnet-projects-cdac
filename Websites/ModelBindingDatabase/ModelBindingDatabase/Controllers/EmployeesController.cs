using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBindingDatabase.Models;

namespace ModelBindingDatabase.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            List<Employee> emplist = Employee.GetAllEmployees();
            return View(emplist);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
                return NotFound();  

            Employee obj = Employee.GetSingleEmployee(id.Value);
            if (obj == null)
            {
                ViewBag.message = "No record Found";
                //return NotFound();
            }
            return View(obj);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee.Insert(employee);
                    ViewBag.message = "Successfully inserted";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.message = "Validation failed";
                    return View(employee);
                }
            }
            catch(Exception ex)
            {
                ViewBag.message = "No record inserted";
                return View(employee);
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            Employee obj = Employee.GetSingleEmployee(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmpNo)
                    return NotFound();

                if (ModelState.IsValid)
                {
                    Employee.Update(employee);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(employee);
                }
            }
            catch
            {
                return View(employee);
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Employee obj = Employee.GetSingleEmployee(id.Value);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Employee.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
