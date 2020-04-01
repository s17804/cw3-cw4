using Cw4_Cw4.Models;

namespace Cw4_Cw4.Utils
{
    public static class ValidationUtils
    {
        private static readonly string Empty = string.Empty;


        public static bool CheckIfStudentNotEmpty(Student student)
        {
            return !(student.FirstName == null
                     && student.LastName == null
                     && student.BirthDate == null
                     && student.StudiesName == null
                     && student.Semester.Equals(0));
        }

        public static bool CheckIfEnrollmentNotEmpty(Enrollment enrollment)
        {
            return !(enrollment.IndexNumber == null
                     && enrollment.StartDate == null
                     && enrollment.StudiesName == null
                     && enrollment.Semester.Equals(0));
        }
    }
}