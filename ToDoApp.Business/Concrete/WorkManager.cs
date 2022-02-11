using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Business.Abstract;
using ToDoApp.Business.Utilities.Constants;
using ToDoApp.Business.ValidationRules;
using ToDoApp.Dal.Repository;
using ToDoApp.Dal.Utilities.Results;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Business.Concrete
{
    public class WorkManager : IWorkService
    {
        WorkDal _workDal;
        IValidate<Work> _validator;

        public WorkManager(WorkDal workDal, IValidate<Work> validator)
        {
            _workDal = workDal;
            _validator = validator;
        }

        public async Task<IResult> Add(Work work)
        {
            var result = _validator.ExecuteValidation(work);
            if (result)
            {
                await _workDal.Add(work);
                return new SuccessResult(Messages.SuccesfullyAdded);
            }

            return new ErrorResult(Messages.FaultilyAdded);
            
        }

        public async Task<IDataResult<Work>> Get(int id)
        {
            var result = await _workDal.Get(work => work.Id == id);
            if(result != null)
            {
                return new SuccessDataResult<Work>(result,Messages.SuccesfullyPulled);
            }
            return new ErrorDataResult<Work>(Messages.FaultilyPulled);
        }

        public async Task<IDataResult<List<Work>>> GetAll(bool isTracking = false)
        {
            var result = await _workDal.GetAll(isTracking: isTracking);
            if(result != null)
            {
                return new SuccessDataResult<List<Work>>(result,Messages.SuccesfullyPulled);
            }
            return new ErrorDataResult<List<Work>>(Messages.FaultilyPulled);
        }

        public async Task<IResult> Remove(Work work)
        {
            await _workDal.Remove(work);
            return new SuccessResult(Messages.SuccessfullyRemoved);
        }

        public async Task<IResult> Update(Work work)
        {
            var result = _validator.ExecuteValidation(work);
            if (result)
            {
                await _workDal.Update(work);
                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            return new SuccessResult(Messages.FaultilyUpdated);
        }

        public async Task<IResult> Update(Work work, Work updatedWork)
        {
            var result = _validator.ExecuteValidation(updatedWork);
            if (result)
            {
                await _workDal.Update(work, updatedWork);
                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            return new SuccessResult(Messages.FaultilyUpdated);
        }
    }
}
