using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutManager(IAboutDal aboutDal) : IAboutService
    {
        private readonly IAboutDal _aboutDal = aboutDal;
        public IResult Add(About about)
        {
            _aboutDal.Add(about);
            return new SuccessResult("about elave olundu");
        }

        public IResult Delete(int id)
        {
            About deleteAbout = null;
            About resultAbout = _aboutDal.Get(m => m.IsDeleted == false && m.Id == id);
            if (resultAbout != null)
                deleteAbout = resultAbout;
            deleteAbout.IsDeleted = true;
            _aboutDal.Delete(deleteAbout);
            return new SuccessResult();
        }

        public IDataResult<About> GetAbout(int id)
        {
            About getAbout = _aboutDal.Get(m => m.Id == id);

            if (getAbout != null)
                return new SuccessDataResult<About>(getAbout, "get message loaded");
            else return new ErrorDataResult<About>(getAbout, "message tapilmadi");
        }

        public IDataResult<List<About>> GetAllAbout()
        {
            var abouts = _aboutDal.GetAll(m => m.IsDeleted == false).ToList();
            if (abouts.Count > 0)
                return new SuccessDataResult<List<About>>(abouts);
            else return new ErrorDataResult<List<About>>("xeta bash verdi");
        }

        public IResult Update(About about)
        {
            About updateMessage;
            updateMessage = _aboutDal.Get(m => m.Id == about.Id && m.IsDeleted == false);
            updateMessage.Id = about.Id;
            updateMessage.IsDeleted = about.IsDeleted;
            updateMessage.Phone = about.Phone;
            updateMessage.Email =about.Email;
            _aboutDal.Update(about);
            return new SuccessResult();
        }
    }
}
