﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tool.Calendar.BLL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tool.Calendar.Web.Controllers
{
    public class UserController : Controller
    {
        public BLL_User bLLUser = new BLL_User();
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult<string> GetAll()
        //{
        //    var names = "没有数据";
        //    var students = bLLUser.GetListByAll();

        //    if (students != null)
        //    {
        //        names = "";
        //        foreach (var s in students)
        //        {
        //            names += $"{s.UserName} \r\n{s.UserGuid}";
        //        }

        //    }

        //    return names;
        //}
    }
}