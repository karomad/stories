using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stories.DataAccessLayer;
using System.Threading.Tasks;
using Stories.ServiceLayer.Abstract;
using AutoMapper;
using Stories.WebApp.Models;
using Stories.DataModels.Entities;
using Autofac.Extras.NLog;
using Stories.WebApp.ActionFilters;

namespace Stories.WebApp.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(MapperConfiguration mapperConfiguration, ILogger logger) : base(mapperConfiguration, logger)
        {
        }

        [CheckAutorization]
        public ActionResult Index()
        {
            return View();
        }

    }
}