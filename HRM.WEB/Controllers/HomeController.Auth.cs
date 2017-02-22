﻿using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web.Mvc;
using AutoMapper;
using HRM.Web;
using HRM.DAL.Models;
using HRM.Web.Manager;
using HRM.Web.ViewModel;
using HRM.DAL;

namespace HRM.Web.Controllers
{
	public partial class HomeController
	{
		public ActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
				if (User.IsInRole(Roles.User))
					return RedirectToAction(MVCManager.Controller.Main.Albums, MVCManager.Controller.Main.Name);
				else 
					return View("NotActivated");
			return View();

		}

		[HttpPost]
		public ActionResult Index(UserCredentialsVM userCredentialsVM)
		{	HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = userCredentialsVM.RememberMe }, identity);
			return RedirectToAction(MVCManager.Controller.Home.Index);
		}
		[Authorize]
		public ActionResult Logout()
		{
			HttpContext.GetOwinContext().Authentication.SignOut();
			return RedirectToAction(MVCManager.Controller.Home.Index);
		}
	}
}