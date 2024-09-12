using FluentValidation;
using NTierArchitecture.DAL.Entities;

namespace NTierArchitecture.BLL.Validations
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(employee => employee.Name).NotEmpty();
            RuleFor(employee => employee.DateOfBirth).Must(BeAValidAge).WithMessage("Invalid Date of Birth");
            RuleFor(employee => employee.Address).Length(20, 250);
        }

        protected bool BeAValidAge(DateTime date)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            var span = DateTime.Now - date;
            int years = (zeroTime + span).Year - 1;
            if (years >= 18)
            {
                return true;
            }
            return false;
        }
    }
}