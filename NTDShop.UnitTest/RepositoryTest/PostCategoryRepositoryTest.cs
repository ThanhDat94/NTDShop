using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTDShop.Data.Infrastructure;
using NTDShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTDShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;
        [TestInitialize]
        public void Initalize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);

        }

        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();

        }
    }
}
