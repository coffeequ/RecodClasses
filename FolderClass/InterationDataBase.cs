using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordClasses.FolderClass
{
    class InterationDataBase
    {
        public RcdbEntities RcdbEntities { get; set; }

        public InterationDataBase(RcdbEntities rcdbEntities)
        {
            RcdbEntities = rcdbEntities;
        }


    }
}
