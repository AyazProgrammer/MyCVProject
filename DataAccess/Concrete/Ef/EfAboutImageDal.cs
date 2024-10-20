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
    public class EfAboutImageDal(BaseProjectContext context) : BaseRepository<AboutImage, BaseProjectContext>(context), IAboutImageDal
    {
        public List<AboutImageToAboutsDto> GetAllAboutsByFeatured()
        {
            BaseProjectContext baseContext = new BaseProjectContext();
            var result = from i in baseContext.AboutImages
                         where i.IsFutured == true
                         join p in baseContext.Abouts
                         on i.AboutId equals p.Id
                         select new AboutImageToAboutsDto
                         {
                             
                             AboutId = i.AboutId,
                             IsFeatured = i.IsFutured,
                             Name = p.Name,
                             LastName = p.LastName,
                             Email = p.Email,
                             Birthday=p.Birthday,

                             PhotoUrl = i.PhotoUrl,
                             AboutImageId=i.Id,
                             Adress=p.Adress,
                             Description=p.Description,
                             Phone=p.Phone,
                             Website=p.Website,
                             Github=p.Github,
                             Linkedin=p.Linkedin,

                         };
            return result.Where(p => p.IsFeatured == true).Take(3).ToList();
        }

        public List<AboutImageToAboutsDto> GetAllAboutsByImage()
        {
            BaseProjectContext baseContext = new BaseProjectContext();
            var result = from i in baseContext.AboutImages
                         where i.IsDeleted == false
                         join p in baseContext.Abouts
                         on i.AboutId equals p.Id
                         select new AboutImageToAboutsDto
                         {
                             AboutId = i.AboutId,
                             IsFeatured = i.IsFutured,
                             Name = p.Name,
                             LastName = p.LastName,
                             Email = p.Email,
                             Birthday = p.Birthday,

                             PhotoUrl = i.PhotoUrl,
                             AboutImageId = i.Id,
                             Adress = p.Adress,
                             Description = p.Description,
                             Phone = p.Phone,
                             Website = p.Website,
                             Github = p.Github,
                             Linkedin = p.Linkedin,

                         };
            return result.Where(p => p.IsFeatured == true).Take(3).ToList();
        }


        public List<AboutDto> GetAllAboutWithAllImages()
        {
            BaseProjectContext context = new BaseProjectContext();

            var result = from i in context.AboutImages
                         where !i.IsDeleted
                         join p in context.Abouts on i.AboutId equals p.Id
                         select new AboutDto
                         {
                             AboutId = p.Id,
                             Name = p.Name,
                             LastName = p.LastName,
                             Email = p.Email,
                             Birthday = p.Birthday,
                             PhotoUrl = i.PhotoUrl,
                             Adress = p.Adress,
                             Description = p.Description,
                             Phone = p.Phone,
                             Website = p.Website,
                             Github = p.Github,
                             Linkedin = p.Linkedin,
                             AboutImages = (from img in context.AboutImages
                                            where img.AboutId == p.Id && !img.IsDeleted
                                            select new AboutWithImageDto
                                            {
                                                AboutId = img.AboutId,
                                                Photo = img.PhotoUrl,
                                                IsFeatured = img.IsFutured
                                            }).ToList()
                         };

                return result.ToList();

        }

    }
}
