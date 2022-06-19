using DSM.BLL.PEPOLE;
using DSM.DTO;
using DSM.TABLES.Guide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DSM.Areas.people.controller
{
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
            var b = branch.GetBranches().data;
            List<Branch> branches =b.
            return View();
        }

        // GET: BranchController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BranchController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BranchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: BranchController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BranchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: BranchController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BranchController/Delete/5
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
