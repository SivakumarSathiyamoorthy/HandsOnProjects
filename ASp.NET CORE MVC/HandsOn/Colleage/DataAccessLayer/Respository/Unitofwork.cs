using DataAccessLayer.DBContext;
using DataAccessLayer.Respository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Respository
{
    public class Unitofwork : IUnitofwork
    {
        MyDBContext _dbContext;
        public IStudentRepository stuRepo { get; private set; }

        public IDepartmentRepository deptRepo { get; private set; }

        public Unitofwork(MyDBContext dbContext)
        {
            _dbContext= dbContext;
            stuRepo=new StudentRepository(dbContext);
            deptRepo=new DepartmentRepository(dbContext);
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }
    }
}
