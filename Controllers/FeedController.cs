using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Instadev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_Instadev.Controllers
{
    [Route("Feed")]
    public class FeedController : Controller 
    {
        Feed feedmodel = new Feed();
        
        public IActionResult Index()
        {
            ViewBag.Feed = feedmodel.ReadAll();
            return View();
        }
    }
}