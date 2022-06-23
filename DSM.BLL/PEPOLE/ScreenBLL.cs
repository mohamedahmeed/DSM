using AutoMapper;
using DSM.DAL;
using DSM.DTO;
using DSM.TABLES.Guide;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.BLL.PEPOLE
{
    public class ScreenBLL
    {
        private readonly IRepository<ImagesScreen> screenRepo;
        private readonly IMapper mapper;

        public ScreenBLL(IRepository<ImagesScreen> screenRepo,IMapper mapper)
        {
            this.screenRepo = screenRepo;
            this.mapper = mapper;
        }

        public resultDTO GetAll()
        {
            resultDTO result = new resultDTO();
            List<ImagesScreen> s = screenRepo.GetAll().Include(s => s.Branch).ToList();
            result.data = s;
            return result;
        }
        public ImagesScreen GetById(Guid id)
        {
            return screenRepo.GetById(id);
        }
        public resultDTO Save(ScreenDTO screen)
        {
            resultDTO r = new resultDTO();
            var screens = screenRepo.GetAll();
            if (screens != null)
            {
                var s = screens.Where(s => s.Name == screen.Name).FirstOrDefault();
                if (s == null)
                {
                    ImagesScreen images = mapper.Map<ImagesScreen>(screen);

                   if(screenRepo.Insert(images))
                    {
                        r.message = "Add succes";
                        r.Status = true;
                    }
                    else
                    {
                        r.message = "Add Faild";
                        r.Status = false;
                    }
                    
                }
                else
                {
                    r.message = "Add Faild";
                    r.Status = false;
                }
            }
            return r;
        }
       
        public resultDTO Edit(Guid? id,ScreenDTO screen)
        {
            resultDTO r = new resultDTO();
            List<ImagesScreen> screens= screenRepo.GetAll().ToList();
            var sc= screens.Where(s => s.ID == screen.ID).FirstOrDefault();
            if (sc != null)
            {
                var ss = screens.Where(x => x.Name != screen.Name).Where(x => x.IsActive).FirstOrDefault();
                if(ss!=null)
                {
                    r.message = "Edit Faild";
                    r.Status = false;
                    return r;
                }
                else
                {
                    sc.Name = screen.Name;
                    sc.Notes = screen.Notes;
                    sc.Code = screen.Code;
                    sc.CreatedDate = screen.CreatedDate;
                    sc.ScreenSize = screen.ScreenSize;
                    sc.BranchId = screen.BranchId;
                    screenRepo.Update(sc);
                    screenRepo.SaveChange();
                    r.message = "Edit success";
                    r.Status = true;
                    return r;
                }
                var sc2 = screens.Where(h => h.ID != screen.ID).ToList();

                var xd = sc2.Any(y => y.Name != screen.Name);
            //  var sc2 = screens.Where(h => h.ID != screen.ID).ToList();

                //    if (sc2.Any(y => y.Name != screen.Name))
                //    {
                //        sc.Name=screen.Name;
                //        sc.Notes=screen.Notes;
                //        sc.Code=screen.Code;
                //        sc.CreatedDate=screen.CreatedDate;
                //        sc.ScreenSize=screen.ScreenSize;
                //        screenRepo.Update(sc);
                //        screenRepo.SaveChange();
                //        r.message = "Edit success";
                //        r.Status = true;
                //        return r;

                //    }
                //    else
                //    {
                //        r.message = "Edit Faild";
                //        r.Status = false;
                //        return r;
                //    }
            }
            return r;
        }

        public ImagesScreen Delete(ImagesScreen b)
        {
            screenRepo.Delete(b);
            return b;
        }
    }
}
