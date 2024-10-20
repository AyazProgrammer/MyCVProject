using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEducationService
    {
        IResult Add(Education education);
        IResult Update(Education education);
        IResult Delete(int id);
        IDataResult<List<Education>> GetAllEducation();
        IDataResult<Education> GetEducation(int id);
    }
}
