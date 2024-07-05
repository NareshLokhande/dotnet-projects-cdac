using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { EmpNo = 1, Name = "Naresh", Basic = 12154, DeptNo = 10 });
            employees.Add(new Employee { EmpNo = 2, Name = "Paras", Basic = 12154, DeptNo = 10 });
            employees.Add(new Employee { EmpNo = 3, Name = "Pradeep", Basic = 12154, DeptNo = 10 });
            
            //List<Employee> list = Employee.GetAllEmployees():
            return View(employees);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id=1)
        {
            Employee obj = new Employee();
            obj.EmpNo = id;
            obj.Name = "Naresh";
            obj.Basic = 12454;
            obj.DeptNo = 10;

            //Employee employee = Employee.GetSingleEmployee();
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
        //public ActionResult Create(IFormCollection collection)
        //public ActionResult Create(IFormCollection collection,int EmpNo, string Name, decimal Basic,int DeptNo) //Binding
        //public ActionResult Create(Employee obj,IFormCollection collection,int EmpNo, string Name, decimal Basic,int DeptNo) //Combination 
        public ActionResult Create(Employee obj) //Model Binding
        {
            try
            {
                //Employee.Insert(obj);
                
                //string name = collection["Name"];
                //string empno = collection["EmpNo"];
                //string basic = collection["Basic"];
                //string deptNo = collection["DeptNo"];
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee obj = new Employee();
            obj.EmpNo = id;
            obj.Name = "Naresh";
            obj.Basic = 12454;
            obj.DeptNo = 10;
            return View(obj);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            //Employee.Delete(Employee);
            Employee obj = new Employee();
            obj.EmpNo = id;
            obj.Name = "Naresh";
            obj.Basic = 12454;
            obj.DeptNo = 10;
            return View(obj);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
