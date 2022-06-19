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

        public BranchBLL(IRepository<Branch> branchRepo)
        {
            this.branchRepo = branchRepo;
        }


        #region Get

        public resultDTO GetBranches()
        {
            resultDTO result = new resultDTO();
            result.data = new {
                Branchs = branchRepo.GetAllAsNoTracking().Select(s => new
                {
                    poster = s.Poster,
                    name = s.Name,
                    createdDate=s.CreatedDate,
                    isactive=s.IsActive,
                })
            };
            return result;
        }
        #endregion
    }
}
