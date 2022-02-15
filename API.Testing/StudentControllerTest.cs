using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_Unittesting.Controllers;
using Xunit;
using FluentAssertions;
using System.Net;
using Domain;
using TDD_Unittesting.Validation;
using FluentValidation.Results;

namespace API.Testing
{
    public class StudentControllerTest
    {
        // UnitOfWork_StateUnderTest_ExpectedBehaviour
        [Fact]
        public  async Task GetItemAsync_WithNonExistintItem_ReturnNotfound()
        {
            // Arrange
            var studentrepo = Substitute.For<IStudentRepositry>();
           
            var studentcontroller = new StudentController(studentrepo, null);
            // Act
            var studentresukt =  (NotFoundResult) await studentcontroller.GetStudentAsync(1);
            // Assert
            studentresukt.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task AddStudentAsync_WithInvalidModel_ReturnBadRequest()
        {
            // Arrange          
            var validation = new StudentValidation();
            var studentrepo = Substitute.For<IStudentRepositry>();
            var studentcontroller = new StudentController(studentrepo, validation);
            Student student = new Student();
            student.StudentId = 1;            
            // Act
            var studentresukt = (BadRequestObjectResult)await studentcontroller.AddStudentAsync(student);
            // Assert
            
            studentresukt.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }
        [Fact]
        
        public async Task AddStudentAsync_WithInvalidModel_ReturnNameNotPresentmessage()
        {
            // Arrange          
            var validation = new StudentValidation();
            var studentrepo = Substitute.For<IStudentRepositry>();
            var studentcontroller = new StudentController(studentrepo, validation);
            Student student = new Student();
            student.StudentId = 1;
            // Act
            var studentresukt = (BadRequestObjectResult)await studentcontroller.AddStudentAsync(student);
            // Assert

            var errors =  (List<ValidationFailure>) studentresukt.Value;
            Assert.Single(errors);
            var error = errors.Single();        
           
            Assert.True(error.PropertyName == "Name");
            
        }
    }
}
