using Colleage.Constants;
using DataAccessLayer.DBContext;
using DataAccessLayer.Respository;
using DataAccessLayer.Respository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModelLayer;
using ModelLayer.ViewModel;
using NuGet.ProjectModel;
using NuGet.Protocol.Core.Types;
using System.Drawing;



namespace Colleage.Controllers
{
    [Authorize(Roles =Roles.role_Admin)]
    public class StudentController : Controller
    {

        //private IStudentRepository _objStuRepo;
        //private IDepartmentRepository _objDeptRepo;
        private IUnitofwork _unitofwork;

        public StudentController(IUnitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public IActionResult GetAllStudents()
        {
            List<Student> students = _unitofwork.stuRepo.GetAll("department").ToList();
            return View(students);
        }

        public IActionResult DeleteStudent(int id)
        {
            Student student = _unitofwork.stuRepo.Get(u=>u.StuId== id);
            _unitofwork.stuRepo.Delete(student);
            TempData["Success"] = student.StuName + " is deleted";
            _unitofwork.save();
            return RedirectToAction("GetAllStudents");
        }

        public IActionResult EditStudent(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            else
            {
                Student student = new Student();
                StudentVM stuVM = new()
                {

                    student = _unitofwork.stuRepo.Get(u => u.StuId == id),
                    departmentList = _unitofwork.deptRepo.GetAll(null).ToList().Select(
                        u => new SelectListItem
                        {
                            Text = u.DepName,
                            Value = u.DepId.ToString()
                        }
                        )
                };
                return View(stuVM);
            }
        }

        [HttpPost]
        public IActionResult EditStudent(StudentVM stuVM)
        {
            _unitofwork.stuRepo.Update(stuVM.student);
            _unitofwork.save();
            TempData["Success"] = stuVM.student.StuName + " is Updated";
            return RedirectToAction("GetAllStudents");
        }

        public IActionResult CreateStudent()
        {
            StudentVM stuVM = new()
            {
                student = new Student(),
                departmentList = _unitofwork.deptRepo.GetAll(null).ToList().Select(u => new SelectListItem
                {
                    Text = u.DepName,
                    Value = u.DepId.ToString()
                }
                )

            };

            return View(stuVM);

        }

        [HttpPost]
        public IActionResult CreateStudent(StudentVM stuVM)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.stuRepo.Add(stuVM.student);
                _unitofwork.save();
                TempData["Success"] = stuVM.student.StuName+ " is added";
                return RedirectToAction("GetAllStudents");
            }
            return View(stuVM);
            //return RedirectToAction("CreateStudent");
        }

        //public IActionResult GetAllStudents(string? includeProperties="department")
        //{

        //    IQueryable<Student> query = _dbObj.students;

        //    if (!string.IsNullOrEmpty(includeProperties))
        //    {
        //        foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(property);
        //        }
        //    }

        //    List<Student> students = query.ToList();


        //    return View(students);
        //}

        //public IActionResult EditStudent(int? id)
        //{
        //    if (id == 0 || id == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        Student stuent = new Student();
        //        StudentVM stuVM = new()
        //        {

        //            student = _dbObj.students.Find(id),
        //            departmentList = _dbObj.departments.ToList().Select(
        //                u => new SelectListItem
        //                {
        //                    Text = u.DepName,
        //                    Value = u.DepId.ToString()
        //                }
        //                )
        //        };
        //        return View(stuVM);
        //   }
        //}

        //[HttpPost]
        //public IActionResult EditStudent(StudentVM stuVM)
        //{
        //    _dbObj.students.Update(stuVM.student);
        //    _dbObj.SaveChanges();
        //    return RedirectToAction("GetAllStudents");
        //}


        //public IActionResult DeleteStudent(int id)
        //{
        //    _dbObj.students.Remove(_dbObj.students.Find(id));
        //    _dbObj.SaveChanges();
        //    return RedirectToAction("GetAllStudents");
        //}

        //public IActionResult CreateStudent()
        //{
        //    StudentVM stuVM = new()
        //    {
        //        student=new Student(),
        //        departmentList=_dbObj.departments.ToList().Select( u=>new SelectListItem
        //        {
        //         Text=u.DepName,
        //         Value=u.DepId.ToString()
        //        }
        //        )

        //    };

        //    return View (stuVM);

        //}
        //[HttpPost]
        //public IActionResult CreateStudent(StudentVM stuVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _dbObj.students.Add(stuVM.student);
        //        _dbObj.SaveChanges();
        //        return RedirectToAction("GetAllStudents");
        //    }
        //    return RedirectToAction("CreateStudent");
        //}
    }
}
