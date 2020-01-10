using darkstar.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignPatternAndPrincipleDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _repo;


        public EmployeeController()
        {

        }
        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;

        }
        // GET: Employee
        public ActionResult Index()
        {
            var res = _repo.GetList(x => true).ToList();
            return View(res);
        }


        public ActionResult AddEmployee()
        {
            //var employee = new Employee();
            return View(new Employee());
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            _repo.Add(emp);
            return RedirectToAction("Index");
        }
        
    }
}