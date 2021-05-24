using ASPMVCCoreDay01Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPMVCCoreDay01Lab.Controllers
{
    public class HomeController : Controller
    {

        private CompanyContext _db;
        public HomeController(CompanyContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var emps = _db.Employees.Include(ww => ww.Department).ToList();
            return View(emps);
        }

      
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["depts"] = new SelectList(_db.Departments.ToList(),"DeptId", "DeptName", 1);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _db.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var emp = _db.Employees.Include(ww => ww.Department).FirstOrDefault(ee => ee.Id == Id);
            return View(emp);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _db.Remove(_db.Employees.Find(id));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var emp = _db.Employees.Include(ww => ww.Department).FirstOrDefault(ee => ee.Id == Id);
            ViewData["depts"] = new SelectList(_db.Departments.ToList(), "DeptId", "DeptName", 1);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _db.Update(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
