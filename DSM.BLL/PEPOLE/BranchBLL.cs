using AutoMapper;
using DSM.DAL;
using DSM.DTO;
using DSM.TABLES.Guide;
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

        public BranchBLL(IRepository<Branch> branchRepo,IMapper mapper)
        {
            this.branchRepo = branchRepo;
            this.mapper = mapper;
        }


        #region Get

        public resultDTO GetBranches()
        {
            resultDTO result = new resultDTO();
            List<Branch> Branchs = branchRepo.GetAllAsNoTracking().ToList();

            result.data = Branchs;
            return result;
        }
        public Branch GetBranchById(Guid b)
        {
            Branch bb=branchRepo.GetById(b);
            return bb;
        }
        #endregion

        public resultDTO EditBrabch(Guid ID,BranchDTO branch)
        {
            resultDTO result = new resultDTO();
            List<Branch> branches = branchRepo.GetAll().ToList();
            var br = branches.Where(r => r.ID == branch.ID).FirstOrDefault();
            if(br != null)
            {
                var brs = branches.Where(s => s.ID != branch.ID);
                if(brs.Any(s=>s.Name != branch.Name))
                {
                    br.Name=branch.Name;
                    br.CreatedDate=branch.CreatedDate;
                    br.Poster=branch.Poster;
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
        public resultDTO SaveAdd(BranchDTO branch)
        {


           Branch b= mapper.Map<Branch>(branch);
            branchRepo.Insert(b);
            resultDTO r = new resultDTO {
                message="no no no",
            };
            return r;
        }
    }
}
