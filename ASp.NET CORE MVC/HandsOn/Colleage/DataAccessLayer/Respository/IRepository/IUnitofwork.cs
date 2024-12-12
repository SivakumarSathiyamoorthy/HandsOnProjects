﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Respository.IRepository
{
    public interface IUnitofwork
    {
        IStudentRepository stuRepo { get; }
        IDepartmentRepository deptRepo { get; }
        void save();
    }
}
