using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac.Extras.NLog;
using AutoMapper;
using System.Threading.Tasks;
using Stories.WebApp.ActionFilters;
using Stories.WebApp.Helpers;
using Stories.ServiceLayer.Abstract;
using Stories.DataModels.Entities;
using Stories.WebApp.Models;
using Microsoft.AspNet.SignalR;
using Stories.WebApp.Signalr;

namespace Stories.WebApp.Controllers
{
    public class StoryController : BaseController
    {
        private readonly IStoryService StoryService;
        private readonly IGroupService GroupService;


        public StoryController(MapperConfiguration mapperConfiguration,
            ILogger logger,
            IStoryService storyService,
            IGroupService groupService)
            : base(mapperConfiguration, logger)
        {
            StoryService = storyService;
            GroupService = groupService;
        }


        [CheckAutorization]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [CheckAutorization]
        public async Task<ActionResult> GetUserStories(int first, int pagesize)
        {
            try
            {
                var _stories = Mapper.Map<IList<Story>, IList<StoryViewModel>>(
                    await StoryService.GetUserStories(SessionManager.CurrentUser.Id, first, pagesize));
                return Json(new ResponseData { Data = _stories }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(ResponseData.ErrorDefault);
            }
        }

        [HttpGet]
        [CheckAutorization]
        public ActionResult AddEditStory(int storyId)
        {
            return View(storyId);
        }

        [HttpGet]
        [CheckAutorization]
        public async Task<ActionResult> GetStoryDetails(int storyId)
        {
            try
            {
                var _story = storyId > 0 ? Mapper.Map<Story, StoryViewModel>(await StoryService.GetStoryDetails(storyId))
                    : new StoryViewModel();
                return Json(new ResponseData { Data = _story }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(ResponseData.ErrorDefault);
            }
        }
        [HttpPost]
        [CheckAutorization]
        public async Task<ActionResult> SaveStory(StoryViewModel story)
        {
            try
            {
                story.UserId = SessionManager.CurrentUser.Id;
                story.PostedOn = DateTime.Now;
                var _story = Mapper.Map<StoryViewModel, Story>(story);
                story.Id = await StoryService.AddOrEditStory(_story);
                
                try
                {
                    var _groupsUsers = await GroupService.GetGroupsUsers(story.Groups.Select(x => x.Id));
                    IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                    hubContext.Clients.Clients(NotificationHub.GetUsersConnections(_groupsUsers.Where(x => x != story.UserId).ToList())).notify(new Notification
                    {
                        FromUser = SessionManager.CurrentUser.Name,
                        StoryId = story.Id,
                        Body = $"Posted story in group(s) {string.Join(",", story.Groups.Select(x => x.Name))}"
                    });
                }
                catch(Exception exx)
                {
                    Logger.Error(exx);
                }
                return Json(new ResponseData { Data = story }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return Json(ResponseData.ErrorDefault);
            }
        }
    }
}