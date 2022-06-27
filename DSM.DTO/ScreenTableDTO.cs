using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.DTO
{
    public class ScreenTableDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }    
        public string BranchName { get; set; }
        public string Notes { get; set; }
        public string CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public int TotalCount { get; set; }
        public string Code { get; set; }
        public float ScreenSize { get; set; }
    }
}
