using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeEducationInfo.Model;
using EmployeeManagement.Models;
using System.Data.Entity.Validation;
using System.Data.Objects;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeManagementDB db = new EmployeeManagementDB();

        //
        // GET: /Employee/
        public ActionResult Index()
        {
            return View(db.EmployeeSet.Where(s => s.IsDel == false).ToList());
        }

        //
        // GET: /Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeSet.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //
        // GET: /Employee/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Employee employee = db.EmployeeSet.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var employee4update = db.EmployeeSet.Where(e => e.Id == employee.Id).SingleOrDefault();
                employee4update.Name = employee.Name;
                employee4update.Age = employee.Age;
                employee4update.Seniority = employee.Seniority;
                if (employee.EducationInfo.Count > 0)
                {
                    var educationInfo = employee.EducationInfo.ToList();
                    int count = educationInfo.Count;
                    for (int i = 0; i < count; i++)
                    {
                        //judge if the education info exist or not
                        int uid = educationInfo[i].Id;
                        var ret = db.EducationInfoSet.Where(e => e.Id == uid).SingleOrDefault();
                        if (ret != null)
                        {
                            //exist
                            ret.StartTime = educationInfo[i].StartTime;
                            ret.EndTime = educationInfo[i].EndTime;
                            ret.Education = educationInfo[i].Education;
                            ret.IsDel = educationInfo[i].IsDel;
                        }
                        else
                        {
                            //need to add
                            EducationInfo eduInfo = new EducationInfo();
                            eduInfo.EmployeeId = employee.Id;
                            eduInfo.IsDel = false;
                            eduInfo.StartTime = educationInfo[i].StartTime;
                            eduInfo.EndTime = educationInfo[i].EndTime;
                            eduInfo.Education = educationInfo[i].Education;
                            db.EducationInfoSet.Add(eduInfo);
                        }
                    }
                }
                //db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //
        // GET: /Employee/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Employee employee = db.EmployeeSet.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.EmployeeSet.Find(id);
            employee.IsDel = true;
            //将该employee下的education info一并删除
            foreach (var eduInfo in employee.EducationInfo)
            {
                eduInfo.IsDel = true;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddEducationInfo()
        {
            ViewBag.ClickCount = Request["index"].ToString();
            return PartialView("EducationInfoView");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}