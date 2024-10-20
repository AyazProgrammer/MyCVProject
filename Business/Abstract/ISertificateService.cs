using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISertificateService
    {
        IResult Add(Certificate certificate);
        IResult Update(Certificate certificate);
        IResult Delete(int id);
        IDataResult<List<Certificate>> GetAllCertificate();
        IDataResult<Certificate> GetCertificate(int id);
    }
}

