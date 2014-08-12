using Autofac;
using Autofac.Integration.Mvc;
using ATU.Domain.Abstract;
using ATU.Domain.Concrete;
using ATU.Domain.Data.Repository.Abstract;
using ATU.Web.Domain.Abstract;
using ATU.Web.Domain.Concrete;
using ATU.Web.Interface.Controllers;
using System.Web.Mvc;
using ModelMapper = ATU.Web.Domain.Concrete.ModelMapper;

namespace ATU.Web.Interface
{
    public class IocConfig
    {
        private static IocConfig _autofac;

        public static IocConfig Instance
        {
            get { return _autofac ?? (_autofac = new IocConfig()); }
        }

        public IContainer Build()
        {
            var builder = new ContainerBuilder();

            // Mappers
            builder.RegisterType<ModelMapper>();
            builder.RegisterType<RequestXRowMapper>().As<IRequestXRowMapper>().SingleInstance();
            builder.RegisterType<QuestionXRowMapper>().As<IQuestionXRowMapper>().SingleInstance();

            // Repositories
            builder.RegisterType<ATU.Domain.Data.Repository.Concrete.ATURepository>().As<IRepository>().SingleInstance();

            // Controllers
            builder.RegisterType<AnswerController>();
            builder.RegisterType<AccountController>();
            builder.RegisterType<HomeController>();
            builder.RegisterType<RequestController>();
            builder.RegisterType<QuestionController>();

            // Services
            builder.RegisterType<AnswerService>().As<IAnswerService>().SingleInstance();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<InMemoryCache>().As<ICacheService>().SingleInstance();
            builder.RegisterType<ConfigurationService>().As<IConfigurationService>().SingleInstance();
            builder.RegisterType<MembershipCreateStatusToErroMapper>().As<IMembershipCreateStatusToErroMapper>().SingleInstance();
            builder.RegisterType<MembershipService>().As<IMembershipService>().SingleInstance();
            builder.RegisterType<QuestionService>().As<IQuestionService>().SingleInstance();
            builder.RegisterType<RegistrationService>().As<IRegistrationService>().SingleInstance();
            builder.RegisterType<RequestService>().As<IRequestService>().SingleInstance();
            builder.RegisterType<PasswordGenerator>().As<IPasswordGenerator>().SingleInstance();
            builder.RegisterType<SearchService>().As<ISearchService>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();

            // Factories
            builder.RegisterType<BreadcrumbFactory>().As<IBreadcrumbFactory>().SingleInstance();
            builder.RegisterType<LeftNavFactory>().As<ILeftNavFactory>().SingleInstance();
            builder.RegisterType<TopNavFactory>().As<ITopNavFactory>().SingleInstance();
            builder.RegisterType<TableFactory>().As<ITableFactory>().SingleInstance();
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();

            // Validators
            builder.RegisterType<FileUploadValidator>().As<IFileUploadValidator>().SingleInstance();

            return builder.Build();
        }

        public static IContainer Initialise()
        {
            var container = Instance.Build();
            var resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);

            return container;
        }
    }
}