using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static DSM.COMMON.General.Enums;

namespace DSM.DTO
{
    public class ScreenDTO
    {
        public Guid? ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }
        public string Notes { get; set; }
        //  public ScreenDirection ScreenDirection { get; set; }
        public string BranchName { get; set; }
        public float ScreenSize { get; set; }
        
        public  Guid? BranchId { get; set; }
    }
}
