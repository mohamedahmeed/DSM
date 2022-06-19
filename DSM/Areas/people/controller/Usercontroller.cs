using System.Collections.Generic;
using DSM.BLL.PEPOLE;
using DSM.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSM.Areas.people.controller
{
    [Area("people")]
    public class UserController : Controller
    {
        private readonly UserBLL bll;

        public UserController(UserBLL bll)
        {
            this.bll = bll;
        }
        // GET: Usercontroller
        public ActionResult Index()
        {
            return View();
            //List<userDTO> users = bll.getusers().data.tolist();
        }

        // GET: Usercontroller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usercontroller/Create
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult save(userDTO user) => Ok(bll.saveuser(user));
       

        // POST: Usercontroller/Create
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

        // GET: Usercontroller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usercontroller/Edit/5
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

        // GET: Usercontroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usercontroller/Delete/5
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
