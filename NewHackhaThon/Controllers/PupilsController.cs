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
    public class PupilsController : Controller
    {

        ApplicationDbContext db;

        public PupilsController(ApplicationDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Главная
        /// </summary>
        /// <param name="sortOrder">Сортировка</param>
        /// <param name="searchString">Поиск</param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["Name_SortParm"] = string.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewData["CourseSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewData["Pupils_SurnameSortParm"] = sortOrder == "Pupils_Surname" ? "date_desc" : "Pupils_Surname";
            ViewData["Pupils_CityParm"] = sortOrder == "Pupils_City" ? "date_desc" : "Pupils_City";
            ViewData["CurrentFilter"] = searchString;

            var pupil = from s in db.Pupil select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                pupil = pupil.Where(s => s.Pupils_Name.Contains(searchString) || s.Pupils_Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name":
                    pupil = pupil.OrderByDescending(s => s.Pupils_Surname);
                    break;
                case "Pupils_Surname":
                    pupil = pupil.OrderBy(s => s.Pupils_School);
                    break;
                case "Pupils_CityParm":
                    pupil = pupil.OrderBy(s => s.Pupils_City);
                    break;
                case "CourseSortParm":
                    pupil = pupil.OrderByDescending(s => s.Pupils_Summ);
                    break;
                case "date_desc":
                    pupil = pupil.OrderByDescending(s => s.Pupils_Class);
                    break;

            }
            return View(await pupil.AsNoTracking().ToListAsync());
        }



        /// <summary>
        /// переход в профиль 
        /// </summary>
        /// <param name="id">id школьника</param>
        /// <returns></returns>
        public async Task<IActionResult> About(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pupils = await db.Pupil
                .FirstOrDefaultAsync(m => m.PupilsId == id);
            if (pupils == null)
            {
                return NotFound();
            }
            return View(pupils);
        }

        /// <summary>
        /// переход на страницу редактирования инф. о школьнике
        /// </summary>
        /// <param name="id">id школьника</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupils = await db.Pupil.FindAsync(id);
            if (pupils == null)
            {
                return NotFound();
            }
            return View(pupils);
        }

        /// <summary>
        /// редактирования ифн. о школьнике
        /// </summary>
        /// <param name="id">id школьника</param>
        /// <returns></returns>
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var pupilToUpdate = await db.Pupil.SingleOrDefaultAsync(s => s.PupilsId == id);
            if (await TryUpdateModelAsync<Pupils>(
                pupilToUpdate,
                "",
                s => s.Pupils_Name, s => s.Pupils_Surname, s => s.Pupils_School, s => s.Pupils_Class))
            {
                try
                {
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes ");
                }
            }
            return View(pupilToUpdate);
        }

        /// <summary>
        /// переход на страницу удаления информации о школьнике
        /// </summary>
        /// <param name="id">id школьника</param>
        /// <param name="saveChangesError"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupils = await db.Pupil
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.PupilsId == id);
            if (pupils == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Uninstall failed";
            }

            return View(pupils);
        }


        /// <summary>
        /// удаление информации о школьнике
        /// </summary>
        /// <param name="id">id школьника</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pupils = await db.Pupil
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.PupilsId == id);
            if (pupils == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                db.Pupil.Remove(pupils);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}