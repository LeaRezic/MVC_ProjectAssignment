using RWA_MVC_LeaRezic.DAL.Domain.Repositories;
using RWA_MVC_LeaRezic.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_MVC_LeaRezic.BLL.DataManagers
{
    public abstract class ManagerBase
    {
        internal static IRepository _repository = RepositoryFactory.GetDefaultInstance();

    }
}