using NTDShop.Data.Infrastructure;
using NTDShop.Model.Models;

namespace NTDShop.Data.Repositories
{
    public interface IProductTagRepository : IRepository<ProductTag>
    {
    }

    public class ProductTagRepository : RepositoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}