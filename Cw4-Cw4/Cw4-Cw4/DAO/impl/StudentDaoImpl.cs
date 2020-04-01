using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Cw4_Cw4.Models;
using Cw4_Cw4.Settings;
using static System.Int32;

namespace Cw4_Cw4.DAO.impl
{
    public class StudentDaoImpl : IStudentDao
    {
        public IEnumerable<Student> GetAllStudents()
        {
            const string sqlQuery = "SELECT S.FirstName, S.LastName, S.BirthDate, St.Name, E.Semester FROM Student S " +
                                    " LEFT JOIN Enrollment E ON S.IdEnrollment = E.IdEnrollment " +
                                    " LEFT JOIN Studies St ON E.IdStudy = St.IdStudy";
            var students = new List<Student>();
            using var connection =
                new SqlConnection(AppSettingsUtils.GetConnectionString());
            using var command = new SqlCommand
            {
                Connection = connection,
                CommandText = sqlQuery
            };
            connection.Open();
            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                var student = new Student
                {
                    FirstName = dataReader["FirstName"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    BirthDate = DateTime.Parse(dataReader["BirthDate"].ToString()).ToString("yyyy-MM-dd"),
                    StudiesName = dataReader["Name"].ToString(),
                    Semester = Parse(dataReader["Semester"].ToString())
                };
                students.Add(student);
            }

            return students;
        }

        public Student GetStudentByIndexNumberSqlInjectionInVulnerable(string indexNumber)
        {
            var sqlQuery = "SELECT S.FirstName, S.LastName, S.BirthDate, St.Name, E.Semester FROM Student S " +
                           "LEFT JOIN Enrollment E ON S.IdEnrollment = E.IdEnrollment " +
                           "LEFT JOIN Studies St ON E.IdStudy = St.IdStudy WHERE S.IndexNumber = @indexNumber";
            using var connection =
                new SqlConnection(
                    "server=localhost;database=students_apdb;User=sa;Password=nzR4eFSMIs^WUJlvqhS8r@Wu804g!3MX");
            using var command = new SqlCommand
            {
                Connection = connection, 
                CommandText = sqlQuery
            };
            command.Parameters.AddWithValue("indexNumber", indexNumber);
            
            connection.Open();
            var dataReader = command.ExecuteReader();
            var student = new Student();
            while (dataReader.Read())
            {
                {
                    student.FirstName = dataReader["FirstName"].ToString();
                    student.LastName = dataReader["LastName"].ToString();
                    student.BirthDate = DateTime.Parse(dataReader["BirthDate"]
                        .ToString()).ToString("yyyy-MM-dd");
                    student.StudiesName = dataReader["Name"].ToString();
                    student.Semester = Parse(dataReader["Semester"].ToString());
                }
            }

            return student;
        }
    }
}