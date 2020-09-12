using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewHackhaThon.Controllers
{
    public class ChecksController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
    }
}