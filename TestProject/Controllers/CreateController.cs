﻿using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TestProject.DataDB;

namespace TestProject.Controllers
{

    public class CreateController : Controller
    {


        private readonly string _connectionString;

        public CreateController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            TestDBContext testDBContext = new TestDBContext();
            var data = testDBContext.Employees.ToList();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO StudentInformations (FirstName, LastName, StudentNo, Email, PhoneNumber) VALUES (@Name, @Surname, @StudentNo, @Email, @PhoneNumber)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", student.FirstName);
                    command.Parameters.AddWithValue("@Surname", student.LastName);
                    command.Parameters.AddWithValue("@StudentNo", student.StudentNo);
                    command.Parameters.AddWithValue("@Email", student.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        // veri ekleme başarısız oldu
                        return RedirectToAction("Create");
                    }
                }
            }
            //return RedirectToAction("Index", "Home");
        }

    }
}