using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public interface ISocialConnect
    {
        public string Linkedin { get; set; }
        public string Website { get; set; }
        public string Github { get; set; }
    }
}
