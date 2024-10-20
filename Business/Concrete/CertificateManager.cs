using Business.Abstract;
using Business.BusinessAspect.Autofac;
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
    public class CertificateManager(ICertificateDal certificateDal) : ISertificateService
    {
        private readonly ICertificateDal _certificateDal = certificateDal;
        public IResult Add(Certificate certificate)
        {
            _certificateDal.Add(certificate);
            return new SuccessResult("certificate elave olundu");
        }
       // [SecuredOperation("admin,moderator")]
        public IResult Delete(int id)
        {
            Certificate deleteCertificate = null;
            Certificate resultCertificate = _certificateDal.Get(m => m.IsDeleted == false && m.Id == id);
            if (resultCertificate != null)
                deleteCertificate = resultCertificate;
            deleteCertificate.IsDeleted = true;
            _certificateDal.Delete(deleteCertificate);
            return new SuccessResult();
        }
        
        public IDataResult<List<Certificate>> GetAllCertificate()
        {
            var certificates = _certificateDal.GetAll(m => m.IsDeleted == false).ToList();
            if (certificates.Count > 0)
                return new SuccessDataResult<List<Certificate>>(certificates);
            else return new ErrorDataResult<List<Certificate>>("xeta bash verdi");
        }

        public IDataResult<Certificate> GetCertificate(int id)
        {
            Certificate getCertificate = _certificateDal.Get(m => m.Id == id);

            if (getCertificate != null)
                return new SuccessDataResult<Certificate>(getCertificate, "get Certificate loaded");
            else return new ErrorDataResult<Certificate>(getCertificate, "Certificate tapilmadi");
        }

        public IResult Update(Certificate certificate)
        {
            Certificate updateCertificate;
            updateCertificate = _certificateDal.Get(m => m.Id == certificate.Id && m.IsDeleted == false);
            updateCertificate.Id = certificate.Id;
            updateCertificate.IsDeleted = certificate.IsDeleted;
            updateCertificate.CertificateName = certificate.CertificateName;
            updateCertificate.CertificateUrl = certificate.CertificateUrl;

            _certificateDal.Update(updateCertificate);
            return new SuccessResult();
        }
    }
}
