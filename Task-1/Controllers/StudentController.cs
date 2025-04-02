using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public static List<Student> students = new List<Student>();
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            student.Id = Guid.NewGuid();
            students.Add(student);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var student = students.FirstOrDefault(s => s.Id.Equals(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id.Equals(student.Id));
            if (existingStudent == null)
            {
                return HttpNotFound();
            }
            existingStudent.Name = student.Name;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.Address = student.Address;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var student = students.FirstOrDefault(s => s.Id.Equals(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var student = students.FirstOrDefault(s => s.Id.Equals(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            students.Remove(student);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            return View(students);
        }
    }
}