using System.Collections.Generic;
using Cw4_Cw4.Models;

namespace Cw4_Cw4.DAO
{
    public interface IStudentDao
    {
        IEnumerable<Student> GetAllStudents();

        Student GetStudentByIndexNumberSqlInjectionInVulnerable(string studentIndex);
    }
}