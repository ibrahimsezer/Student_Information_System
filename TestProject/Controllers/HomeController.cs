﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestProject.DataDB;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            StudentModel employeeModel = new StudentModel();
            employeeModel.EmplDetailList = new List<EmplDetail>();

            TestDBContext testDBContext = new TestDBContext();
            var data = testDBContext.Employees.ToList();
            foreach (var item in data)
            {
                employeeModel.EmplDetailList.Add(NewMethod(item));
            }
            return View(employeeModel);
        }

        //SAYFA EKLEYİNCE HER SAYFA İÇİN BUNU ÜRET
        public IActionResult Students()
        {
            StudentModel employeeModel = new StudentModel();
            employeeModel.EmplDetailList = new List<EmplDetail>();

            TestDBContext testDBContext = new TestDBContext();
            var data = testDBContext.Employees.ToList();
            foreach (var item in data)
            {
                employeeModel.EmplDetailList.Add(NewMethod(item));
            }
            return View(employeeModel);
        }

        //SAYFA EKLEYİNCE HER SAYFA İÇİN BUNU ÜRET
        public IActionResult Create()
        {
            StudentModel employeeModel = new StudentModel();
            employeeModel.EmplDetailList = new List<EmplDetail>();

            TestDBContext testDBContext = new TestDBContext();
            var data = testDBContext.Employees.ToList();
            foreach (var item in data)
            {
                employeeModel.EmplDetailList.Add(NewMethod(item));
            }
            return View(employeeModel);

            //using (var context = new TestDBContext())
            //{
            //    context.Employees.Add(student);
            //    context.SaveChanges();
            //}
            //return RedirectToAction("Index");
        }

        private static EmplDetail NewMethod(Student item)
        {
            return new EmplDetail
            {
                Id = item.Id,
                StudentNo = item.StudentNo,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Gender = item.Gender,
                Department = item.Department,
                Email = item.Email,
                Adress = item.Adress,
                PhoneNumber = item.PhoneNumber,
                BirthDate = item.BirthDate,
                RegistrationDate = item.RegistrationDate,
                IdentificationNumber = item.IdentificationNumber,
                //GPA = item.GPA,
                //Graduated = item.Graduated
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}