using NDDD.Domain.Entities;


namespace NDDD.Domain.Repositories
{
    public interface IBlogRepository
    {
        public Blog? GetLatest();
    }
}
