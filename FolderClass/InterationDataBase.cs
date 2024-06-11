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

        public bool AddService(Service item)
        {
            RcdbEntities.Service.Add(item);

            return RcdbEntities.SaveChanges() >= 1 ? true : false;
        }

        public bool AddClient(Client item)
        {
            RcdbEntities.Client.Add(item);

            return RcdbEntities.SaveChanges() >= 1 ? true : false;
        }

        public bool AddClientService(ClientService  item)
        {
            RcdbEntities.ClientService.Add(item);

            return RcdbEntities.SaveChanges() >= 1 ? true : false;
        }
    }
}
