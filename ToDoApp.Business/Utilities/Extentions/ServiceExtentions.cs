using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Business.Abstract;
using ToDoApp.Business.Concrete;
using ToDoApp.Business.ValidationRules;
using ToDoApp.Business.ValidationRules.FluentValidation;
using ToDoApp.Dal.Contexts;
using ToDoApp.Dal.Repository;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Business.Utilities.Extentions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection SetConfigrations(this IServiceCollection serviceDescriptors)
        {
            
            serviceDescriptors.AddScoped<WorkDal, WorkDal>();
            serviceDescriptors.AddScoped<IWorkService, WorkManager>();
            serviceDescriptors.AddSingleton<IValidate<Work>,WorkValidator>();

            return serviceDescriptors;
        }
    }
}
