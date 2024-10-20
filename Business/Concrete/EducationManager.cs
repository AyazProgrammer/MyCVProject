using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EducationManager(IEducationDal educationDal) : IEducationService
    {
        private readonly IEducationDal _educationDal = educationDal;
        public IResult Add(Education education)
        {
            _educationDal.Add(education);
            return new SuccessResult("education elave olundu");
        }

        public IResult Delete(int id)
        {
            Education deleteEducation = null;
            Education resultEducation = _educationDal.Get(m => m.IsDeleted == false && m.Id == id);
            if (resultEducation != null)
                deleteEducation = resultEducation;
            deleteEducation.IsDeleted = true;
            _educationDal.Delete(deleteEducation);
            return new SuccessResult();
        }

        public IDataResult<List<Education>> GetAllEducation()
        {
            var educations = _educationDal.GetAll(m => m.IsDeleted == false).ToList();
            if (educations.Count > 0)
                return new SuccessDataResult<List<Education>>(educations);
            else return new ErrorDataResult<List<Education>>("xeta bash verdi");
        }

        public IDataResult<Education> GetEducation(int id)
        {
            Education getEducation = _educationDal.Get(m => m.Id == id);

            if (getEducation != null)
                return new SuccessDataResult<Education>(getEducation, "get education loaded");
            else return new ErrorDataResult<Education>(getEducation, "education tapilmadi");
        }

        public IResult Update(Education education)
        {
            Education updateEducation;
            updateEducation = _educationDal.Get(m => m.Id == education.Id && m.IsDeleted == false);
            updateEducation.Id = education.Id;
            updateEducation.IsDeleted = education.IsDeleted;
            updateEducation.UniversityName = education.UniversityName;
            updateEducation.StartTime = education.StartTime;
            updateEducation.EndTime = education.EndTime;
            updateEducation.Speciality  = education.Speciality;
            _educationDal.Update(updateEducation);
            return new SuccessResult();
        }
    }
}
