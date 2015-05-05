using EmployeeEducationInfo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class EmployeeManagementDB : DbContext
    {
        public DbSet<Admin> AdminSet { get; set; }
        public DbSet<Employee> EmployeeSet { get; set; }
        public DbSet<EducationInfo> EducationInfoSet { get; set; }
    }

    public class DBInit : DropCreateDatabaseIfModelChanges<EmployeeManagementDB>
    {
        protected override void Seed(EmployeeManagementDB employeeManagementDB)
        {
            //Add the default admin if model changes
            Admin admin = new Admin() { Id = 1, Name = "admin", Password = "admin", ErrorTime = 0, IsDel = false };
            employeeManagementDB.AdminSet.Add(admin);
            employeeManagementDB.SaveChanges();
        }
    }
}