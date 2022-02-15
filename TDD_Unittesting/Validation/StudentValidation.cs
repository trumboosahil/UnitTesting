using Domain;
using FluentValidation;

namespace TDD_Unittesting.Validation
{
    public class StudentValidation : AbstractValidator<Student>
    {
        public StudentValidation()
        {
            RuleFor(x => x.Name).NotNull();
        }
    }
}
