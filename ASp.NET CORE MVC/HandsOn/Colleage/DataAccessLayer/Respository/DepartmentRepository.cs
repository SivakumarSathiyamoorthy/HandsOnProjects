using DataAccessLayer.DBContext;
using DataAccessLayer.Respository.IRepository;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Respository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {

        private MyDBContext _dbContext;
        public DepartmentRepository(MyDBContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
