using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac.Extras.NLog;
using AutoMapper;
using System.Threading.Tasks;
using Stories.ServiceLayer.Abstract;
using Stories.DataModels.Entities;
using Stories.WebApp.Models;
using Stories.WebApp.Helpers;
using Stories.WebApp.Exceptions;

namespace Stories.WebApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService UserService;
        public UserController(MapperConfiguration mapperConfiguration, ILogger logger,
            IUserService userService)
            : base(mapperConfiguration, logger)
        {
            UserService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(string name)
        {
            try
            {
                var _user = Mapper.Map<User, UserViewModel>(await UserService.Login(name));
                if (_user == null)
                {
                    throw new UserNotFoundException();
                }
                SessionManager.CurrentUser = _user;
                return Json(new ResponseData { Data = _user });
            }
            catch (UserNotFoundException ex)
            {
                Logger.Error(ex);
                return Json(new ResponseData { Status = 500, Error = ex.Message });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(ResponseData.ErrorDefault);
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            SessionManager.CurrentUser = null;
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }
    }
}