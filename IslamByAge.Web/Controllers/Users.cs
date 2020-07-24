﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Type;
using IslamByAge.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IslamByAge.Web.Controllers
{
    [Authorize]
    public class Users : Controller
    {
        private readonly ApplicationDbContext db;
        public Users(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var users = db.Users;   
            return View(users.ToList());
        }
        public IActionResult ToggleStatus(string id)
        {
            var user = db.Users.Find(id);
            user.LockoutEnabled = !user.LockoutEnabled;
            user.LockoutEnd = DateTime.MaxValue;
            db.Users.Update(user);
            return RedirectToAction("Index");
        }
    }
}
