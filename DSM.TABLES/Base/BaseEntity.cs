using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSM.TABLES.Pepole;

namespace DSM.TABLES.Base
{
    public class BaseEntity
    {
        #region prop
        [Key]
        public Guid? ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }
       
        

       

        #endregion







    }
}
