using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.DTO
{
    public class userDTO
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string userName { get; set; }
        public string Email { get; set; }
        public DateTime addedDate { get; set; }
        public bool  isActive { get; set; }



    }
}
