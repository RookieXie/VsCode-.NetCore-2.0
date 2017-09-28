using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcDemo.Models;
using mvcDemo.Test;

namespace mvcDemo.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Test()
        {
            BFTest bf=new BFTest();
            // TestData model=new TestData();
            // model.FID="98756";
            // model.Name="测试VsCore";
            // bf.AddModel(model);
            // bf.Submit();

            var model=bf.GetByFID("98756");
            ViewData["Name"]=model.Name;
            return View();
        }
    }
}