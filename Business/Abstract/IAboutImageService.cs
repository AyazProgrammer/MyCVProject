using Core.Helpers.Results.Abstract;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutImageService
    {
        IResult AddAboutImage(AboutImageAddDto aboutImageAddDto);

        IDataResult<List<AboutImageToAboutsDto>> GetAllAboutImagesByFeatured();

        IDataResult<List<AboutImageToAboutsDto>> GetAllAboutByImages();
    }
}
