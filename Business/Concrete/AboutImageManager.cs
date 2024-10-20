using Business.Abstract;
using Core.Helpers.Business;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutImageManager(IAboutImageDal aboutImageDal, IAddPhotoHelperService addPhotoHelperService) : IAboutImageService
    {
        private readonly IAboutImageDal _aboutImageDal = aboutImageDal;
        private readonly IAddPhotoHelperService _addPhotoHelperService = addPhotoHelperService;

        public IResult AddAboutImage(AboutImageAddDto aboutImageAddDto)
        {
            var guid = Guid.NewGuid() + "-" + aboutImageAddDto.Photo.FileName;
            _addPhotoHelperService.AddImage(aboutImageAddDto.Photo, guid);
            AboutImage aboutImage = new()
            {
                AboutId = aboutImageAddDto.AboutId,
                PhotoUrl = "/images/" + guid,
                IsDeleted = false,


            };
            Console.WriteLine(aboutImage.AboutId);
            Console.WriteLine(aboutImage.PhotoUrl);
            _aboutImageDal.Add(aboutImage);
            return new SuccessResult("Elave olundu");
        }

        public IDataResult<List<AboutImageToAboutsDto>> GetAllAboutByImages()
        {
             var result = _aboutImageDal.GetAllAboutsByImage();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<AboutImageToAboutsDto>>(result);
            }
            else return new ErrorDataResult<List<AboutImageToAboutsDto>>(result);
        }

        public IDataResult<List<AboutImageToAboutsDto>> GetAllAboutImagesByFeatured()
        {
            var result = _aboutImageDal.GetAllAboutsByFeatured();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<AboutImageToAboutsDto>>(result);
            }
            else return new ErrorDataResult<List<AboutImageToAboutsDto>>(result);
        }

       
    }

}
