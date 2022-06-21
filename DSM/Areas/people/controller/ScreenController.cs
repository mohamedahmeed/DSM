using DSM.BLL.PEPOLE;
using DSM.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DSM.Areas.people.controller
{
    [Area("people")]
    public class ScreenController : Controller
    {
        private readonly ScreenBLL screen;

        public ScreenController(ScreenBLL screen)
        {
            this.screen = screen;
        }
        // GET: ScreenController
        public ActionResult Index()
        {
            var s = screen.GetAll();
            return View(s);
        }

        // GET: ScreenController/Details/5
        public ActionResult Details(Guid id)
        {
            var d=screen.GetById(id);
            return View(d);
        }

        // GET: ScreenController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: ScreenController/Create
        [HttpPost]   
        public ActionResult Add(ScreenDTO s)
        {
            return Json(screen.Save(s));
        }

        // GET: ScreenController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var s= screen.GetById(id);
            ScreenDTO r = new ScreenDTO()
            {
                Code = s.Code,
                Name = s.Name,
                CreatedDate = s.CreatedDate,
                ScreenSize = s.ScreenSize,
                Notes = s.Notes,
                IsActive= s.IsActive,
            };

            return View(r);
        }

        // POST: ScreenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScreenDTO s)
        {
            screen.Edit(s.ID,s);
            return Redirect("http://localhost:4540/people/screen/index");

        }

        // GET: ScreenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScreenController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
