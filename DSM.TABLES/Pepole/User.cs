using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSM.TABLES.Base;
using DSM.TABLES.Guide;

namespace DSM.TABLES.Pepole
{
    public class User :BaseEntity
    {

       
        public string Email { get; set; }

        public virtual ICollection<UserBranch> UserBranches { get; set; }









    }
}
