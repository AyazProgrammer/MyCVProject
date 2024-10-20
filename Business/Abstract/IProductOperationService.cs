using Core.Helpers.Results.Abstract;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductOperationService
    {
        IResult AddProductImage(ProductImageAddDto productImageAddDto);
    }
}
