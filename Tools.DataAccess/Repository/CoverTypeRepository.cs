using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.DataAccess.Repository.IRepository;
using Tools.Models;

namespace Tools.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    

        public void Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }
    }
}
