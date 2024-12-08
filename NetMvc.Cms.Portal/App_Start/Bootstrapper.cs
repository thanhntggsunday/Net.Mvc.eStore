using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.BL.ServiceImp;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.Portal.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //Asp.net Identity
            //builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            //builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            //builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();

            #region service
            builder.RegisterType<BaseService>().As<IBaseService>();
            builder.RegisterType<AboutService>().As<IAboutService<AboutDto>>();
            builder.RegisterType<AlbumService>().As<IAlbumService<AlbumDto>>();
            builder.RegisterType<CategoryService>().As<ICategoryService<CategoryDto>>();
            builder.RegisterType<ContactService>().As<IContactService<ContactDto>>();
            builder.RegisterType<FeedbackService>().As<IFeedbackService<FeedbackDto>>();
            builder.RegisterType<FooterService>().As<IFooterService<FooterDto>>();
            builder.RegisterType<FunctionService>().As<IFunctionService<FunctionDto>>();
            builder.RegisterType<GroupSlideService>().As<IGroupSlideService<GroupSlideDto>>();
            builder.RegisterType<LanguageService>().As<ILanguageService<LanguageDto>>();
            builder.RegisterType<MenuService>().As<IMenuService<MenuDto>>();
            builder.RegisterType<MenuTypeService>().As<IMenuTypeService<MenuTypeDto>>();
            builder.RegisterType<NewsService>().As<INewsService<NewsDto>>();
            builder.RegisterType<PermissionService>().As<IPermissionService<PermissionDto>>();
            builder.RegisterType<PhotoService>().As<IPhotoService<PhotoDto>>();
            builder.RegisterType<ProductCategoryService>().As<IProductCategoryService<ProductCategoryDto>>();
            builder.RegisterType<SlideService>().As<ISlideService<SlideDto>>();
            builder.RegisterType<SystemService>().As<ISystemService<SystemConfigDto>>();
            builder.RegisterType<UserService>().As<IUserService<AppUserDto>>();
            builder.RegisterType<ProductService>().As<IProductService<ProductDto>>();
            builder.RegisterType<ShoppingCartBusinessService>().As<IShoppingCartBusinessService>();
            builder.RegisterType<OrderBusinessService>().As<IOrderBusinessService>();

            #endregion servie

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
