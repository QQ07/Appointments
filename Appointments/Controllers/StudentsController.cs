using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    // api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] StudentNames = new string[] { "Rohan", "Pandit", "Devesh", "Shruti", "Mrudula" };
            return Ok(StudentNames);
        }
    }
}
