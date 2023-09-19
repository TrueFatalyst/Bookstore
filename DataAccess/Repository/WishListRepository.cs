using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class WishListRepository : Repository<WishListProduct>, IWIshListRepository
    {
        public WishListRepository(ApplicationDbContext db) : base(db)
        {
        }
        public void Update(WishListProduct wishList)
        {
            _db.Update(wishList);
        }
    }
}
