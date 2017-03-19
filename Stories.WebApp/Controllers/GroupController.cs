using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac.Extras.NLog;
using AutoMapper;
using Stories.WebApp.ActionFilters;
using System.Threading.Tasks;
using Stories.ServiceLayer.Abstract;
using Stories.DataModels.Entities;
using Stories.WebApp.Models;
using Stories.WebApp.Helpers;

namespace Stories.WebApp.Controllers
{
    public class GroupController : BaseController
    {
        private readonly IGroupService GroupService;
        public GroupController(MapperConfiguration mapperConfiguration, ILogger logger,
            IGroupService groupService)
            : base(mapperConfiguration, logger)
        {
            GroupService = groupService;
        }


        [CheckAutorization]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [CheckAutorization]
        public async Task<ActionResult> GetAllGroups(int first, int pagesize)
        {
            try
            {
                var _groups = Mapper.Map<IList<Group>, IList<GroupViewModel>>(await GroupService.GetAllGroups(SessionManager.CurrentUser.Id, first, pagesize));
                return Json(new ResponseData { Data = _groups }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(ResponseData.ErrorDefault);
            }
        }

        [HttpPost]
        [CheckAutorization]
        public async Task<ActionResult> JoinOrLeaveGroup(int groupId, bool join)
        {
            try
            {
                return Json(new ResponseData { Data = await GroupService.JoinOrLeaveGroup(SessionManager.CurrentUser.Id, groupId, join) });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(ResponseData.ErrorDefault);
            }
        }

        [HttpPost]
        [CheckAutorization]
        public async Task<ActionResult> SaveGroup(GroupViewModel group)
        {
            try
            {
                return Json(new ResponseData { Data = await GroupService.CreateGroup(Mapper.Map<GroupViewModel, Group>(group)) });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(ResponseData.ErrorDefault);
            }
        }

        [HttpGet]
        [CheckAutorization]
        public async Task<ActionResult> SearchGroups(string searchText)
        {
            try
            {
                return Json(new ResponseData { Data = Mapper.Map<IList<Group>, IList<KeyValueItem>>(
                    await GroupService.SearchGroup(searchText)) },
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(ResponseData.ErrorDefault);
            }
        }

    }
}