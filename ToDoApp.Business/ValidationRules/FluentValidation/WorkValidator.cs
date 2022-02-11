using ToDoApp.Entities.Concrete;

namespace ToDoApp.Business.ValidationRules.FluentValidation
{
    public class WorkValidator : IValidate<Work>
    {
        public bool ExecuteValidation(Work work)
        {
            var validator = new WorkValidationRules();
            var result = validator.Validate(work);
            return result.IsValid;
        }
    }
}
