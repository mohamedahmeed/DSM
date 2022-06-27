using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.COMMON.General
{
    public class DataTableResponce
    {
        public DataTableResponce() { }

        public DataTableResponce(int ITotalRecords, object Data)
        {
            this.ITotalRecords = ITotalRecords;
            AaData = Data;
        }

        public int ITotalRecords { get; set; }

        public int ITotalDisplayRecords => ITotalRecords;

        public object AaData { get; set; }

        public object Data => AaData;

    }
}

