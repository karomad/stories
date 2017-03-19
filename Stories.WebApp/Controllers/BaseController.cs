using Autofac.Extras.NLog;
using AutoMapper;
using Stories.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stories.WebApp.Controllers
{
    public class BaseController: Controller
    {
        private readonly MapperConfiguration _mapperConfiguration;
        protected IMapper Mapper => _mapperConfiguration.CreateMapper();
        protected readonly ILogger Logger;
        public BaseController(MapperConfiguration mapperConfiguration, ILogger logger)
        {
            _mapperConfiguration = mapperConfiguration;
            Logger = logger;
        }

    }
}