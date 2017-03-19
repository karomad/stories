using Autofac;
using Autofac.Extras.NLog;
using Autofac.Integration.Mvc;
using AutoMapper;
using Stories.DataAccessLayer;
using Stories.DataAccessLayer.Abstract;
using Stories.DataAccessLayer.Impl;
using Stories.DataModels.Entities;
using Stories.ServiceLayer.Abstract;
using Stories.WebApp.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Stories.WebApp
{
    public class DIConfig
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbContextWrapper>().As<IDbContextWrapper>().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(IServiceBase).Assembly).Where(t => t.IsClass)
                .AsImplementedInterfaces()
                .InstancePerRequest();
            builder.Register(m => new MapperConfiguration
                                               (x =>
                                                  {
                                                      x.AddProfile<UserMappingProfile>();
                                                      x.AddProfile<StoryMappingProfile>();
                                                      x.AddProfile<GroupMappingProfile>();
                                                  })).AsSelf().SingleInstance();
            builder.RegisterModule<SimpleNLogModule>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}