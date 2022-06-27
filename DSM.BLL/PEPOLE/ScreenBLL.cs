using AutoMapper;
using DSM.COMMON.General;
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
        public IEnumerable<ImagesScreen> getAllScreen()
        {
            return screenRepo.GetAll().Include(s => s.Branch).ToList();
        }
        public IEnumerable<ScreenDTO> getAllScreens()
        {
            List<ScreenDTO> ss = new List<ScreenDTO>();
            List<ImagesScreen> im = screenRepo.GetAll().Include(s=>s.Branch).ToList();
            foreach (var screen in im)
            {
                var x = screen.Branch;
              
                if (x == null)
                {
                    ScreenDTO s = new ScreenDTO();
                    s.BranchName = "not asgin to Branch"; 
                    s.Name = screen.Name;
                    s.Notes = screen.Notes;
                    s.IsActive = screen.IsActive;
                    s.ScreenSize = screen.ScreenSize;
                    s.Code = screen.Code;
                    s.CreatedDate = screen.CreatedDate;
                    ss.Add(s);
                }
                else
                {
                    ScreenDTO s = new ScreenDTO();
                    s.BranchName = screen.Branch.Name;
                    s.Name = screen.Name;
                    s.Notes = screen.Notes;
                    s.IsActive = screen.IsActive;
                    s.ScreenSize = screen.ScreenSize;
                    s.Code = screen.Code;
                    s.CreatedDate = screen.CreatedDate;
                    ss.Add(s);
                }
               
            };
            return ss;
        }
        public ImagesScreen GetById(Guid? id)
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
                var scrs = screens.Where(s => s.ID != screen.ID);
                if (scrs.Any(s => s.Name == screen.Name))
                //    var ss = screens.Where(x => x.Name != screen.Name).FirstOrDefault();
                //if(ss!=null)
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
              //  var sc2 = screens.Where(h => h.ID != screen.ID).ToList();

              //  var xd = sc2.Any(y => y.Name != screen.Name);
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

        public resultDTO EditIsActive(Guid? Id,bool s)
        {
            resultDTO result = new resultDTO();
            List<ImagesScreen> sc = screenRepo.GetAll().ToList();
          var row=sc.Where(s=>s.ID == Id).FirstOrDefault();
            if (row != null)
            {
                var data = sc.Where(s => s.ID != Id);
                if (data.Any(s => s.Name != row.Name))
                {
                    row.IsActive = s;
                    screenRepo.Update(row);
                    screenRepo.SaveChange();
                    result.Status = true;
                    result.message = "Edit succese";
                }
                else
                {
                    result.Status = false;
                    result.message = "Edit faild";
                }
                return result;
            }
            result.message = "Branch Not Found";
            return result;
        }

        public resultDTO Delete(Guid b)
        {
            ImagesScreen  data = screenRepo.GetById(b);
            resultDTO r = new resultDTO();
            if (screenRepo.Delete(data))
            {
                r.message = "delete succes";
                r.Status = true;
                return r;
            }
            r.message = "delete faild";
            r.Status = false;
            return r;
        }



        public DataTableResponce loadData(DataTableRequest data)
        {
            var d = screenRepo.ExecuteStoredProcedure<ScreenTableDTO>("[dbo].[spscreens]", data.ToSqlParameter(),System.Data.CommandType.StoredProcedure);
            return new DataTableResponce() { AaData = d, ITotalRecords = d?.FirstOrDefault()?.TotalCount ?? 0 };
        }
    }
}
