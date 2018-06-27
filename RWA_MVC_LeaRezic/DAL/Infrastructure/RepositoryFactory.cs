using RWA_MVC_LeaRezic.DAL.Domain.Repositories;

namespace RWA_MVC_LeaRezic.DAL.Infrastructure
{
    public class RepositoryFactory
    {
        public static IRepository GetDefaultInstance()
        {
            return new DBRepository.DBRepository();
        }
    }
}