using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Ef
{
    public class EfCertificateDal : BaseRepository<Certificate, BaseProjectContext>, ICertificateDal
    {
        public EfCertificateDal(BaseProjectContext context) : base(context)
        {
        }
    }
}
