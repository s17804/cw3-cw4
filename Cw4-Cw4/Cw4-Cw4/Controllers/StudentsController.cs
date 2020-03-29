using System;
using System.Linq;
using Cw4_Cw4.DAL;
using Cw4_Cw4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw4_Cw4.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        
        [HttpGet]
        public IActionResult GetStudent()
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var size =_dbService.GetStudents().Count();
            if (id > size)
            {
                return NotFound("Student not found");
            }

            return Ok(_dbService.GetStudents()
                .FirstOrDefault(s => s.IdStudent == id));
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            _dbService.GetStudents().Append(student);
            return Ok( _dbService.GetStudents());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            // get student from data base and update
            var studentOld = new Student
            {
                IdStudent = id, FirstName = "Alojzy", Lastname = "Arbuz", IndexNumber = "s15464"
            };
            Console.WriteLine("Before update: " + studentOld);
            studentOld = student;
            Console.WriteLine("After update: " + studentOld);

            return Ok("Student with id " + id + " was updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            // remove student from database
            return Ok("Student with id " + id + " was removed");
        }
    }
}