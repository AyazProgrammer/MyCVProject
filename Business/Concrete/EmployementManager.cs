using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Ef;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployementManager(IEmployementDal employementDal) : IEmployementService
    {
        private readonly IEmployementDal _employementDal = employementDal;
        public IResult Add(Employment employement)
        {
            _employementDal.Add(employement);
            return new SuccessResult("education elave olundu");
        }

        public IResult Delete(int id)
        {
            Employment deleteEmployement = null;
            Employment resultEmployement = _employementDal.Get(m => m.IsDeleted == false && m.Id == id);
            if (resultEmployement != null)
                deleteEmployement = resultEmployement;
            deleteEmployement.IsDeleted = true;
            _employementDal.Delete(deleteEmployement);
            return new SuccessResult();
        }

        public IDataResult<List<Employment>> GetAllEmployment()
        {
            var employements = _employementDal.GetAll(m => m.IsDeleted == false).Take(2).ToList();
            if (employements.Count > 0)
                return new SuccessDataResult<List<Employment>>(employements);
            else return new ErrorDataResult<List<Employment>>("xeta bash verdi");
        }

        public IDataResult<Employment> GetEmployment(int id)
        {
            Employment getEmployments = _employementDal.Get(m => m.Id == id);

            if (getEmployments != null)
                return new SuccessDataResult<Employment>(getEmployments, "get education loaded");
            else return new ErrorDataResult<Employment>(getEmployments, "education tapilmadi");
        }

        public IResult Update(Employment employement)
        {
            Employment updateEmployment;
            updateEmployment = _employementDal.Get(m => m.Id == employement.Id && m.IsDeleted == false);
            updateEmployment.Id = employement.Id;
            updateEmployment.IsDeleted = employement.IsDeleted;
            updateEmployment.WorkOfficeName = employement.WorkOfficeName;
            updateEmployment.WorkName = employement.WorkName;
            updateEmployment.StartTime = employement.StartTime;
            updateEmployment.EndTime = employement.EndTime;


            _employementDal.Update(updateEmployment);
            return new SuccessResult();
        }
    }
}
