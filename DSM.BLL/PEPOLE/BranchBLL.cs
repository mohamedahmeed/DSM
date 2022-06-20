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

        #endregion

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
