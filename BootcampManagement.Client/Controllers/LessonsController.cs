﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootcampManagement.Client.Controllers
{
    public class LessonsController : Controller
    {
        // GET: Lessons
        public ActionResult Index()
        {
            return View();
        }
    }
}