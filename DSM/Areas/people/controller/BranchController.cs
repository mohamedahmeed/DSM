using AutoMapper;
using DSM.BLL.PEPOLE;
using DSM.DTO;
using DSM.TABLES.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
            resultDTO r=new resultDTO();
            var b = branch.GetBranches();
            
            return View(b);
        }
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var v = branch.GetBranchById(id);
            return View(v);
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BranchDTO branchDTO )
        {
           
                branch.EditBrabch(branchDTO.ID, branchDTO);
            return Redirect("http://localhost:4540/people/branch/index");
            
           
        }

        // GET: BranchController/Delete/5
        public ActionResult Delete(Branch b)
        {
            branch.Delete(b);
            return Redirect("http://localhost:4540/people/branch/index");
        }

        // POST: BranchController/Delete/5
        //[HttpPost]
        
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
