using Cw4_Cw4.DAO;
using Cw4_Cw4.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Cw4_Cw4.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentDao _studentDao;

        public StudentsController(IStudentDao studentDao)
        {
            _studentDao = studentDao;
        }

        [HttpGet]
        [Route("getAllStudents")]
        public IActionResult GetAllStudents(string studentIndex)
        {
            return Ok(_studentDao.GetAllStudents());
        }

        [HttpGet]
        [Route("getStudentByIndexNumberSqlInjectionInVulnerable")]
        public IActionResult GetStudentByIndexNumberSqlInjectionInVulnerable(string indexNumber)
        {
            var student = _studentDao.GetStudentByIndexNumberSqlInjectionInVulnerable(indexNumber);

            if (ValidationUtils.CheckIfStudentNotEmpty(student))
            {
                return Ok(student);
            }

            return NotFound($"Student with indexNumber = {indexNumber} not found");
        }
    }
}