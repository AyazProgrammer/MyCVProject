

using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.Ef;
using DataAccess.Concrete.EF;
using Entities.Abstract;
using Entities.Concrete;


////------------------------Education--------------------------------




IEducationService educationService = new EducationManager(new EfEducationDal(new BaseProjectContext()));

//Education education = new Education()
//{
//    StartTime= DateTime.Now,
//    EndTime= DateTime.Now,
//    Speciality = "Information Tecnology",
//    IsDeleted= false,
//    UniversityName = "Baku State Unibversitety"

//};
//educationService.Add(education);

/*var educations = educationService.GetAllEducation();
/*if (educations != null)
{
    foreach (var item in educations.Data)
    {
        Console.WriteLine(item.UniversityName +" "+ item.Speciality);
    }
}*/


//educationService.Delete(5);

//Education updateEducation = new Education()
//{
//    Id = 1,
//    StartTime = DateTime.Now,
//    EndTime = DateTime.Now,
//    Speciality = "Information Tecnologyaaa",
//    IsDeleted = false,
//    UniversityName = "Baku State Unibversitety"

//};
//educationService.Update(updateEducation);

//------------------------Certificate--------------------------------





