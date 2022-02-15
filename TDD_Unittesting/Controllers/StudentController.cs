using Domain;
using FluentValidation;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TDD_Unittesting.Validation;

namespace TDD_Unittesting.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepositry studentRepositry;
        private readonly IValidator<Student> validator;

        public StudentController(IStudentRepositry studentRepositry, IValidator<Student> validator)
        {
            this.studentRepositry = studentRepositry;
            this.validator = validator;
        }
      
        [Route("Add")]
        [HttpPost]
        [ProducesResponseType(typeof(Student), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddStudentAsync(Student student)
        {
            
            var validationResult = validator.Validate(student);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

           var result = await studentRepositry.AddStudent(student);
           return Ok(result);           

        }
        [Route("{StudentId}")]
        [HttpGet]
        [ProducesResponseType(typeof(Student), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudentAsync(int studentid)
        {

            var result = await studentRepositry.GetStudentAsync(studentid);
           
            if (result==null)
            {
                return NotFound();
            }
            return Ok(result);

        }

    }
}
