using NTDShop.Data.Infrastructure;
using NTDShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace NTDShop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from P in DbContext.Posts
                        join PT in DbContext.PostTags
                        on P.ID equals PT.PostID
                        where PT.TagID == tag && P.Status == true
                        orderby P.CreatedDate descending
                        select P;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}