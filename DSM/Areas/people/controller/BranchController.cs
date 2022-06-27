using AutoMapper;
using DSM.BLL.PEPOLE;
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
    public class BranchController : Controller
    {
        private readonly BranchBLL branch;

        public BranchController(BranchBLL branch)
        {
            this.branch = branch;
        }
        // GET: BranchController
        public ActionResult Index()
        {
           // resultDTO r=new resultDTO();
            var b = branch.GetBranches();
            
            return View(b);
        }
     
       
        [HttpPost]
        public ActionResult Details(Guid id)
        {
           return Json(branch.GetBranchById(id));
            
            }
        [HttpGet]
         public ActionResult Add()
        
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(BranchDTO bb)
        {

            return Json(branch.SaveAdd(bb));

        }
        // GET: BranchController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
       
        // GET: BranchController/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {    
            var v=branch.GetBranchById(id);
            BranchDTO bra = new BranchDTO()
            {
              CreatedDate=v.CreatedDate,
                Name=v.Name,
                 ID=v.ID,
                IsActive=v.IsActive,
                Poster=v.Poster,
            };
            return View(bra);
        }

        // POST: BranchController/Edit/5

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

            var ScreenData = from Branch in branch.GetDataBranches() select Branch;
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            //{
            //    ScreenData = ScreenData..OrderBy(sortColumn + " " + sortColumnDirection);
            //}
            if (!string.IsNullOrEmpty(searchValue))
            {
                ScreenData = ScreenData.Where(m => m.Name.Contains(searchValue));

            }
            recordsTotal = ScreenData.Count();
            var data = ScreenData.Skip(skip).Take(pageSize).ToList();
            var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };

            return Json(jsonData);
        }
        public ActionResult Edit(BranchDTO branchDTO )
        {
           
                branch.EditBrabch(branchDTO.ID, branchDTO);
            return Redirect("http://localhost:4540/people/branch/index");
            
           
        }
        [HttpPost]
        public ActionResult EditChecked(Guid? id,bool d)
        {

           
            return Json(branch.EditCheckedBrabch(id, d)) ;
           // return Redirect("http://localhost:4540/people/branch/index");


        }

        // GET: BranchController/Delete/5
      

       // POST: BranchController/Delete/5
        [HttpPost]

        public ActionResult Delete(Guid id)
        {
           
            return Json(branch.Delete(id));
        }
    }
}
