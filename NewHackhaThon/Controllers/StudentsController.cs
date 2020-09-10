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
    public class StudentsController : Controller
    {

        private readonly ApplicationDbContext db;

        public StudentsController(ApplicationDbContext context)
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
            ViewData["Student_SurnameSortParm"] = sortOrder == "Student_Surname" ? "date_desc" : "Student_Surname";
            ViewData["CurrentFilter"] = searchString;

            var student = from s in db.Student select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                student = student.Where(s => s.Student_Name.Contains(searchString) || s.Student_Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name":
                    student = student.OrderByDescending(s => s.Student_Surname);
                    break;
                case "Student_Surname":
                    student = student.OrderBy(s => s.Student_College);
                    break;
                case "Name_SortParm":
                    student = student.OrderBy(s => s.Student_City);
                    break;
                case "date_desc":
                    student = student.OrderByDescending(s => s.Student_Specialty);
                    break;
                default:
                    student = student.OrderBy(s => s.Student_Course);
                    break;
                case "CourseSortParm":
                    student = student.OrderByDescending(s => s.Student_Summ);
                    break;
            }
            return View(await student.AsNoTracking().ToListAsync());
        }

      
     
        /// <summary>
        /// переход в профиль
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public async Task<IActionResult> About(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var students = await db.Student
                .FirstOrDefaultAsync(m => m.StudentsId == id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        /// <summary>
        /// переходит на страницу редактирования
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await db.Student.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        /// <summary>
        /// Редактирует инфо студента
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await db.Student.SingleOrDefaultAsync(s => s.StudentsId == id);
            if (await TryUpdateModelAsync<Students>(
                studentToUpdate,
                "",
                s => s.Student_Name, s => s.Student_Surname, s => s.Student_College, s => s.Student_Specialty, s => s.Student_Course))
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
            return View(studentToUpdate);
        }


        /// <summary>
        /// переходит на стрницу удаления
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="saveChangesError">ошибка при сохранении итог.рез.</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await db.Student
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.StudentsId == id);
            if (student == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Uninstall failed";
            }

            return View(student);
        }


        /// <summary>
        /// удаляет студента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await db.Student
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.StudentsId == id);
            if (student == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                db.Student.Remove(student);
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