using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Helpers.Business;
using Core.Helpers.Interceptors;
using Core.Helpers.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.Ef;
using DataAccess.Concrete.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dependency.autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MessageManager>().As<IMessageService>().SingleInstance();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>().SingleInstance();



            builder.RegisterType<EfProductImageDal>().As<IProductImageDal>().SingleInstance();
            builder.RegisterType<ProductImageManager>().As<IProductImageService>().SingleInstance();

            builder.RegisterType<EfAboutImageDal>().As<IAboutImageDal>().SingleInstance();
            builder.RegisterType<AboutImageManager>().As<IAboutImageService>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>().SingleInstance();

            builder.RegisterType<CertificateManager>().As<ISertificateService>().SingleInstance();
            builder.RegisterType<EfCertificateDal>().As<ICertificateDal>().SingleInstance();

            builder.RegisterType<SkillsManager>().As<ISkillsService>().SingleInstance();
            builder.RegisterType<EfSkillsDal>().As<ISkillsDal>().SingleInstance();

            builder.RegisterType<EducationManager>().As<IEducationService>().SingleInstance();
            builder.RegisterType<EfEducationDal>().As<IEducationDal>().SingleInstance();

            builder.RegisterType<EmployementManager>().As<IEmployementService>().SingleInstance();
            builder.RegisterType<EfEmployementDal>().As<IEmployementDal>().SingleInstance();

            builder.RegisterType<AddPhotoHelper>().As<IAddPhotoHelperService>().SingleInstance();
			builder.RegisterType<BaseProjectContext>().As<BaseProjectContext>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();







            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }


    }
}
