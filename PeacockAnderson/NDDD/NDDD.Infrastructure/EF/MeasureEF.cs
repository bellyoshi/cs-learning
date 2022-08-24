using NDDD.Domain.Repositories;
using NDDD.Domain.Entities;
namespace NDDD.Infrastructure.EF;

public class MeasureEF : IBlogRepository
{
    private readonly NdddDbContext _context;


    public MeasureEF(NdddDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Blog? GetLatest()
    {
        return _context.Blogs.OrderByDescending(m => m.BlogId).FirstOrDefault();
    }
    
}
