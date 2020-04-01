using Cw4_Cw4.Models;

namespace Cw4_Cw4.DAO
{
    public interface IEnrollmentDao
    {
        Enrollment GetEnrollmentByStudentIndexSqlInjectionVulnerable(string studentIndex);
    }
}