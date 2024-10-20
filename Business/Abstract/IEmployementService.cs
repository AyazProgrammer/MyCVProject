using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployementService
    {
        IResult Add(Employment employement);
        IResult Update(Employment employement);
        IResult Delete(int id);
        IDataResult<List<Employment>> GetAllEmployment();
        IDataResult<Employment> GetEmployment(int id);
    }
}
