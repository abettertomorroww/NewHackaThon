using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewHackhaThon.Data;
using NewHackhaThon.Models;

namespace NewHackhaThon.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProfilesController(ApplicationDbContext context)
        {
            db = context;
        }

        public ActionResult Index()
        {
            return View();
        }

      

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profiles profiles)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.Add(profiles);
                        await db.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Невозможно сохранить изменения. " +
                                       "Повторите попытку, и если проблема не устранена, " +
                "обратитесь к системному администратору.");
                }

            }

            return View(profiles);
        }


    }
}