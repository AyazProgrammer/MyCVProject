using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResult Add(About about);
        IResult Update(About about);
        IResult Delete(int id);
        IDataResult<List<About>> GetAllAbout();
        IDataResult<About> GetAbout(int id);
       
    }
}
