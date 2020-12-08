using Ecraft.Api.Data.Repositories.UnitsOfWork;
using Ecraft.Api.Models;
using Ecraft.Api.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecraft.Api.Controllers
{
    [Route("api/home")]
    [ApiController]
    //[Authorize]
    public class HomeController : ControllerBase
    {

        private readonly UnitOfWorkProjetos _unitProjeto;
        private readonly UnitOfWorkReceitas _unitReceita;

        public HomeController(UnitOfWorkProjetos unitProj, UnitOfWorkReceitas unitRec)
        {
            _unitProjeto = unitProj;
            _unitReceita = unitRec;
        }

        [HttpGet]
        [Route("feed")]
        public async Task<List<FeedViewModel>> Feed()
        {
            //var projetos = await _unitProjeto.Projetos.GetAsync();
            //var receitas = await _unitReceita.Receitas.GetAsync();
            var feed = new FeedViewModel();
            var feedTeste = feed.ItensTeste();
            return feedTeste;

        }

        [HttpGet]
        [Route("user/{name}")]
        public async Task<UserViewModel> GetUserInfo(string name)
        {
            var userTeste = new UserViewModel();
            return userTeste;
        }

        [HttpGet]
        [Route("posts/user/{name}")]
        public async Task<List<FeedViewModel>> UserPosts(string name)
        {
            var feed = new FeedViewModel();
            var feedTeste = feed.ItensTeste();
            return feedTeste;
        }

        [HttpGet]
        [Route("notifications")]
        public async Task<NotificationsViewModel> UserNotifications()
        {
            var notificationsInstante = new Notifications();
            var notification = new NotificationsViewModel(notificationsInstante.NotificationsTeste());
            return notification;
        }

    }
}
