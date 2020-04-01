using System;
using System.Data.SqlClient;
using Cw4_Cw4.Models;
using Cw4_Cw4.Settings;
using static System.Int32;

namespace Cw4_Cw4.DAO.impl
{
    public class EnrollmentDaoImpl : IEnrollmentDao
    {
        public Enrollment GetEnrollmentByStudentIndexSqlInjectionVulnerable(string indexNumber)
        {
            var sqlQuery =
                "SELECT S.IndexNumber, E.Semester, E.StartDate, St.Name FROM Enrollment " +
                "E LEFT JOIN Student S on e.IdEnrollment = S.IdEnrollment " +
                "LEFT JOIN Studies St on E.IdStudy = St.IdStudy " +
                $"WHERE S.IndexNumber = {indexNumber}";

            using var connection = new SqlConnection(AppSettingsUtils.GetConnectionString());
            using var command = new SqlCommand
            {
                Connection = connection,
                CommandText = sqlQuery
            };
            connection.Open();
            var dataReader = command.ExecuteReader();
            var enrollment = new Enrollment();
            while (dataReader.Read())
            {
                {
                    enrollment.IndexNumber = dataReader["IndexNumber"].ToString();
                    enrollment.Semester = Parse(dataReader["Semester"].ToString());
                    enrollment.StartDate = DateTime.Parse(dataReader["StartDate"].ToString()).ToString("yyyy-MM-dd");
                    enrollment.StudiesName = dataReader["Name"].ToString();
                }
            }

            return enrollment;
        }
    }
}