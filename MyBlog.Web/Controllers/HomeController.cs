﻿using MyBlog.Domain;
using MyBlog.Service.Contracts;
using MyBlog.Web.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace MyBlog.Web.Controllers
{
    [OutputCache(VaryByParam = "*", Duration = 60, Location = OutputCacheLocation.Client)]
    public class HomeController : Controller
    {
        private readonly Lazy<IContactMessageService> _contactMessageService;
        private readonly Lazy<IMailService> _mailService;
        private readonly Lazy<IPostService> _postService;
        private readonly Lazy<ITagService> _tagService;

        public HomeController()
        {
        }

        public HomeController(Lazy<IContactMessageService> contactMessageService, Lazy<IMailService> mailService,
            Lazy<IPostService> postService, Lazy<ITagService> tagService)
        {
            _contactMessageService = contactMessageService;
            _mailService = mailService;
            _postService = postService;
            _tagService = tagService;
        }

        // GET: Home
        public async Task<ActionResult> Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Posts = await _postService.Value.GetPostsAsync(p => p.IsEnabled, p => p.CreateDate, SortOrder.Descending, p => p.Tags),
                Tags = await _tagService.Value.GetTagsAsync(t => t.Posts.Any(p => p.IsEnabled))
            };

            return View(homeViewModel);
        }

        // GET: Home/About
        [OutputCache(Location = OutputCacheLocation.Client, Duration = 120, VaryByParam = "none")]
        public ActionResult About()
        {
            return View();
        }

        // GET: Home/Contact
        [OutputCache(Location = OutputCacheLocation.Client, Duration = 120, VaryByParam = "none")]
        public ActionResult Contact()
        {
            return View();
        }

        // POST: Home/Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactMessageEntity contactMessage)
        {
            if (!ModelState.IsValid)
                return View(contactMessage);

            _contactMessageService.Value.AddMessage(contactMessage);
            if (await _contactMessageService.Value.CommitAsync() == false)
            {
                ModelState.AddModelError("Create", "هنگام ثبت پیام خطایی رخ داده است. لطفا بعدا سعی نمایید.");
                return View(contactMessage);
            }

            await _mailService.Value.ContactMail(contactMessage.Name, contactMessage.Email, contactMessage.Message).SendAsync();
            TempData["Successful"] = true;
            ModelState.Clear();

            return View();
        }
    }
}