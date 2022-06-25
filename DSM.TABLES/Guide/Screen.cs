using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSM.TABLES.Base;
using static DSM.COMMON.General.Enums;

namespace DSM.TABLES.Guide
{
    public class ImagesScreen:BaseEntity
    {
        
        public string Code { get; set; }
        public string Notes { get; set; }
       
       
        public float ScreenSize  { get; set; }
        public ScreenDirection ScreenDirection { get; set; }
        [ForeignKey("Branch")]
        public Guid? BranchId { get; set; }

        public virtual Branch Branch { get; set; }

       

    }
   
   
}
