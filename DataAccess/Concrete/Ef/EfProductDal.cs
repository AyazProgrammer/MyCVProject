using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Ef
{
    public class EfProductDal : BaseRepository<Product, BaseProjectContext>, IProductDal
    {
        public EfProductDal(BaseProjectContext context) : base(context)
        {
        }

        
    }

 
                                        
}
