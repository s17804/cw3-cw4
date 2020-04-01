using Cw4_Cw4.DAO;
using Cw4_Cw4.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Cw4_Cw4.Controllers
{
    [ApiController]
    [Route("api/enrollment")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentDao _enrollmentDao;

        public EnrollmentController(IEnrollmentDao enrollmentDao)
        {
            _enrollmentDao = enrollmentDao;
        }

        [HttpGet]
        [Route("getEnrollmentByStudentIndexSqlInjectionVulnerable")]
        public IActionResult GetEnrollmentByStudentIndexSqlInjectionVulnerable(string indexNumber)
        {
            var enrollment = _enrollmentDao.GetEnrollmentByStudentIndexSqlInjectionVulnerable(indexNumber);

            if (ValidationUtils.CheckIfEnrollmentNotEmpty(enrollment))
            {
                return Ok(enrollment);
            }

            return NotFound($"Enrollment for Student with indexNumber = {indexNumber} not found");
        }
    }
}