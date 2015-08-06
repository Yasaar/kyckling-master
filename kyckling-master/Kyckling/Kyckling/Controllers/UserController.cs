using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Kyckling.Domain;
using Kyckling.Domain.Infrastructure.Services;
using Kyckling.Domain.Models;

namespace Kyckling.WebUI.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        private readonly IUserService _userService;
        public UserController(IUserService userservice)
        {
            _userService = userservice;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserModel user)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

     
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }

}

