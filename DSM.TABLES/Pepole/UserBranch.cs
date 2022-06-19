using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSM.TABLES.Base;
using DSM.TABLES.Guide;

namespace DSM.TABLES.Pepole
{
    public class UserBranch:BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Branch")]
        public Guid BranchId { get; set; }
        public virtual User User { get; set; }
        public virtual Branch Branch { get; set; }

       
    }
}
