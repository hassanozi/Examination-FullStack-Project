using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using examinationAPI.Data;
using examinationAPI.Services;

namespace examinationAPI.Repositories
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           // DbContext
        builder.RegisterType<Context>()
            .AsSelf()
            .InstancePerLifetimeScope();

        // Repository
        builder.RegisterGeneric(typeof(Repository<>))
            .As(typeof(IRepository<>))
            .InstancePerLifetimeScope();

        // Services
        builder.RegisterType<CourseService>().InstancePerLifetimeScope();
        builder.RegisterType<ExamService>().InstancePerLifetimeScope();
        builder.RegisterType<QuestionService>().InstancePerLifetimeScope();
        builder.RegisterType<UserService>().InstancePerLifetimeScope();

        // 🔥 AutoMapper (THIS is what was missing)
        builder.Register(context =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });

            return config.CreateMapper(context.Resolve);
        })
        .As<IMapper>()
        .InstancePerLifetimeScope();
           



            // builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            // builder.Services.AddScoped<CourseService>();
            // builder.Services.AddScoped<ExamService>();
            // builder.Services.AddScoped<QuestionService>();
            // builder.Services.AddScoped<UserService>();
        }
    }
}