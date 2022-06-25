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
    public class BranchBLL
    {
        private readonly IRepository<Branch> branchRepo;
        private readonly IMapper mapper;

        public BranchBLL(IRepository<Branch> branchRepo, IMapper mapper)
        {
            this.branchRepo = branchRepo;
            this.mapper = mapper;
        }


        #region Get
        public List<Branch> Branches()
        {
         return  branchRepo.GetAll().ToList();
        } 

        public List<BranchDTO> GetDataBranches()
        {
            List<Branch> branches = branchRepo.GetAll().ToList();
            List<BranchDTO> result = new List<BranchDTO>();
            foreach (var item in branches)
            {
                BranchDTO branch = new BranchDTO();
                branch.ID = item.ID;
                branch.Name = item.Name;
                branch.CreatedDate=item.CreatedDate;
                branch.Poster=item.Poster;
                branch.IsActive=item.IsActive;
                result.Add(branch);

            }
            return result; 


        }
        public resultDTO GetBranches()
        {
            resultDTO result = new resultDTO();
            List<Branch> Branchs = branchRepo.GetAllAsNoTracking().ToList();
            
            result.data = Branchs;
            return result;
        }
        public Branch GetBranchById(Guid b)
        {
            Branch bb = branchRepo.GetById(b);
            return bb;
        }
        #endregion

        public resultDTO EditBrabch(Guid? ID, BranchDTO branch)
        {
            resultDTO result = new resultDTO();
            List<Branch> branches = branchRepo.GetAll().ToList();
            var br = branches.Where(r => r.ID == branch.ID).FirstOrDefault();
            if (br != null)
            {
                var brs = branches.Where(s => s.ID != branch.ID);
                if (brs.Any(s => s.Name != branch.Name))
                {
                    br.Name = branch.Name;
                    br.CreatedDate = branch.CreatedDate;
                    br.Poster = branch.Poster;
                    branchRepo.Update(br);
                    branchRepo.SaveChange();
                    result.message = "Edit Succes";
                    return result;
                }
                result.message = "Edit faild";
                return result;
            }
            result.message = "Can not Find The Branch";
            return result;

        }

        public resultDTO EditCheckedBrabch(Guid? ID,bool c)
        {
            resultDTO result = new resultDTO();
            List<Branch> branches = branchRepo.GetAll().ToList();
            var br = branches.Where(r => r.ID == ID).FirstOrDefault();
            if (br != null)
            {
                var brs = branches.Where(s => s.ID != ID);
                if (brs.Any(s => s.Name != br.Name))
                {

                    br.IsActive = c;
                  
                    branchRepo.Update(br);
                    branchRepo.SaveChange();
                    result.message = "Edit Succes";
                    result.Status = true;
                    return result;
                }
                result.Status = false;
                result.message = "Edit faild";
                return result;
            }
            result.Status = false;
            result.message = "Can not Find The Branch";
            return result;

        }
        public resultDTO SaveAdd(BranchDTO branch)
        {
            resultDTO r = new resultDTO();
            var br = branchRepo.GetAll();
            if (br != null)
            {
                var bb = br.Where(r => r.Name == branch.Name).FirstOrDefault();
                if (bb == null)
                {
                    Branch b = mapper.Map<Branch>(branch);
                    branchRepo.Insert(b);

                    r.message = "Add success";
                    r.Status = true;
                    return r;
                }
                else
                {
                    r.message = "Name Already Exists";
                    r.data = branch;
                    r.Status = false;
                    return r;
                }
                
            }
            return r;
        }

        public Branch Delete(Branch b)
        {
            branchRepo.Delete(b);
            return b;
        }
    }
}