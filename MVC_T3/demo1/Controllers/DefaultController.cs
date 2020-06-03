using demo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using demo1.Models;

namespace demo1.Controllers
{
    public class DefaultController : Controller
    {
        private StudentEntities studentEntities = new StudentEntities();

        public ActionResult Transfer()
        {
            return View(Select());
        }

        [HttpPost]
        public ActionResult Transfer(string StudentName, string StudentAge, string StudentSex)
        {
            Student_Data student = new Student_Data();
            student.StudentName = StudentName;
            student.StudentAge = int.Parse(StudentAge);
            student.StudentSex = StudentSex;
            InsertStudent(student);

            return View(Select());
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            //调用删除方法
            if (remove(id))
            {
                return Content("<script>alert('操作成功！');window.location.href='/Default/Transfer'</script>");
            }
            else
            {
                return Content("<script>alert('操作失败！');window.location.href='/Default/Transfer'</script>");
            }
        }

        public ActionResult Show(int id)
        {
            //调用根据ID查询的方法
            return View(SelectforID(id));
        }

        //编辑
        public ActionResult Redact(int id)
        {
            var student = SelectforID(id);

            return View(student);
        }

        public ActionResult Update(string StudentID, string StudentName, string StudentAge, string StudetnSex)
        {
            string s0 = StudentID;
            int i1 = Convert.ToInt32(StudentID);
            string s1 = StudentName;
            int i2 = Convert.ToInt32(StudentAge);
            string s2 = StudetnSex;

            if (UpStudent(Convert.ToInt32(StudentID), StudentName, Convert.ToInt32(StudentAge), StudetnSex))
            {
                return Content("<script>alert('操作成功！');window.location.href='/Default/Transfer'</script>");
            }
            else
            {
                return Content("<script>alert('操作失败！');window.location.href='/Default/Transfer'</script>");
            }
        }

        //查询所有学生方法
        private List<Student_Data> Select()
        {
            List<Student_Data> stuList = new List<Student_Data>();
            stuList = studentEntities.Student_Data.ToList();
            return stuList;
        }

        //删除方法
        private bool remove(int id)
        {
            var student = studentEntities.Student_Data.FirstOrDefault(x => x.StudentID == id);
            studentEntities.Student_Data.Remove(student);
            var result = studentEntities.SaveChanges();
            return result > 0;
        }

        //根据ID查询学生信息方法
        private Student_Data SelectforID(int id)
        {
            var student = studentEntities.Student_Data.FirstOrDefault(x => x.StudentID == id);
            return student;
        }

        //添加学生方法
        private bool InsertStudent(Student_Data student)
        {
            studentEntities.Student_Data.Add(student);
            var result = studentEntities.SaveChanges();
            return result > 0;
        }

        //更新学生信息
        private bool UpStudent(int StudentID, string StudentName, int StudentAge, string StudentSex)
        {
            var student = SelectforID(StudentID);
            student.StudentID = StudentID;
            student.StudentName = StudentName;
            student.StudentAge = StudentAge;
            student.StudentSex = StudentSex;
            var result = studentEntities.SaveChanges();
            return result > 0;
        }
    }
}