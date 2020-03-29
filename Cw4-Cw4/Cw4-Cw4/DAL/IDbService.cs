using System.Collections;
using System.Collections.Generic;
using Cw4_Cw4.Models;

namespace Cw4_Cw4.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}