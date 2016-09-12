namespace NTDShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private NTDShopDbContext dbContext;

        public NTDShopDbContext Init()
        {
            return dbContext ?? (dbContext = new NTDShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}