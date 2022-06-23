using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.DTO
{
    public class BranchDTO
    {
       public Guid? ID { get; set; }

        public string Poster { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }



    }
}
