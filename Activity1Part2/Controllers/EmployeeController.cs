using Activity1Part2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part2.Controllers
{
    public class EmployeeController : Controller
    {
        /* GET: Employee
        public ActionResult Search(string name = "No name Entered")
        {
            var input = Server.HtmlEncode(name);
            return Content(input);
        }
        
        public ActionResult Search(string name)
        {
            var input = Server.HtmlEncode(name);
            return Content(input);
        }

        [HttpGet]
        public ActionResult Search()
        {
            var input = "Another Search action";
            return Content(input);
        }
        */

        public ActionResult Index()
        {
            var employees = from e in empList
                            orderby e.ID
                            select e;
            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        /* POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Employee emp = new Employee();
                emp.Name = collection["Name"];
                DateTime jDate;
                DateTime.TryParse(collection["DOB"], out jDate);
                emp.JoiningDate = jDate;
                string age = collection["Age"];
                emp.Age = Int32.Parse(age);
                empList.Add(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                empList.Add(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = empList.Single(m => m.ID == id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var employee = empList.Single(m => m.ID == id);
                if (TryUpdateModel(employee))
                {
                    //To Do:- database code
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public static List<Employee> empList = new List<Employee>
        {
            new Employee{
                ID = 1,
                Name = "Allan",
                JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                Age = 23
            },

            new Employee{
                ID = 2,
                Name = "Carson",
                JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                Age = 45
            },

            new Employee{
                ID = 3,
                Name = "Carson",
                JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                Age = 37
            },

            new Employee{
                ID = 4,
                Name = "Laura",
                JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
                Age = 26
            },

};
    }
}