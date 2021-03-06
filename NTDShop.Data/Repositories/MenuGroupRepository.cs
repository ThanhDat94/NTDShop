﻿using NTDShop.Data.Infrastructure;
using NTDShop.Model.Models;

namespace NTDShop.Data.Repositories
{
   
        public interface IMenuGroupRepository : IRepository<MenuGroup>
        {
        }

        public class MenuGroupRepository : RepositoryBase<MenuGroup>, IMenuGroupRepository
        {
            public MenuGroupRepository(IDbFactory dbFactory)
                : base(dbFactory)
            {
            }
        }
    
}