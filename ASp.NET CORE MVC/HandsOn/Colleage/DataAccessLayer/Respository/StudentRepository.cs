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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private MyDBContext _dbContext;
        public StudentRepository(MyDBContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
