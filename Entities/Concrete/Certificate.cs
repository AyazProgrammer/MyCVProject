using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Certificate:BaseEntity
    {
        public string CertificateName { get; set; }
        public string CertificateUrl { get; set; }
    }
}
