using DSM.BLL.PEPOLE;
using DSM.COMMON.General;
using DSM.DTO;
using DSM.TABLES.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DSM.Areas.people.controller
{
    [Area("people")]
    public class ScreenController : Controller
    {
        private readonly ScreenBLL screen;
        private readonly BranchBLL branch;

        public ScreenController(ScreenBLL screen,BranchBLL branch)
        {
            this.screen = screen;
            this.branch = branch;
        }
        // GET: ScreenController
        public ActionResult Index()
        {
          //  var s = screen.GetAll();
            return View();
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
        public ActionResult Edit(Guid? id)
        {
            
            List<Branch> b = branch.Branches();
            ViewBag.bb = b;
            var s = screen.GetById(id);
            ScreenDTO r = new ScreenDTO()
            {
                Code = s.Code,
                Name = s.Name,
                CreatedDate = s.CreatedDate,
                ScreenSize = s.ScreenSize,
                Notes = s.Notes,
                IsActive = s.IsActive,
                BranchId = s.BranchId,
            };
            return View(r);
            
        }
        public ActionResult EditActive(Guid? id,bool s)
        {
            return Json(screen.EditIsActive(id, s));
        }
        // POST: ScreenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScreenDTO s)
        {
            screen.Edit(s.ID,s);
            return Redirect("http://localhost:4540/people/screen/index");

        }
        [HttpPost]
        public IActionResult getDataTable()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            
            var ScreenData = from ImagesScreen in screen.getAllScreens() select ImagesScreen;
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            //{
            //    ScreenData = ScreenData..OrderBy(sortColumn + " " + sortColumnDirection);
            //}
            if (!string.IsNullOrEmpty(searchValue))
            {
                ScreenData = ScreenData.Where(m => m.Name.Contains(searchValue)
                                            || m.Code.Contains(searchValue));
                                           
            }
            recordsTotal = ScreenData.Count();
            var data = ScreenData.Skip(skip).Take(pageSize).ToList();
            var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Json(jsonData);
        }
        // GET: ScreenController/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid s)
        {
           // var x = screen.GetById(id);
         
            return Json(screen.Delete(s));
            
        }

        // POST: ScreenController/Delete/5
       
        public IActionResult loadTableData(DataTableRequest data) =>Json(screen.loadData(data));
    }
}
