using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Task_2.Models;

namespace Task_2.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> students = new List<Student>
        {
            new Student {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                DateOfBirth = new DateTime(2000, 5, 15),
                Address = "123 Main Street, NY",
                Phone = "123-456-7890",
                Email = "john.doe@example.com"
            },
            new Student {
                Id = Guid.NewGuid(),
                Name = "Jane Smith",
                DateOfBirth = new DateTime(1999, 8, 25),
                Address = "456 Elm Street, CA",
                Phone = "987-654-3210",
                Email = "jane.smith@example.com"
            },
            new Student {
                Id = Guid.NewGuid(),
                Name = "Mike Johnson",
                DateOfBirth = new DateTime(2001, 2, 10),
                Address = "789 Pine Avenue, TX",
                Phone = "555-123-4567",
                Email = "mike.johnson@example.com"
            }
        };

        // GET: Student/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/List (Returns Partial View)
        public ActionResult List()
        {
            return PartialView("_List", students);
        }

        // GET: Student/Create (Returns Partial View)
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: Student/Create (Handles Form Submission)
        [HttpPost]
        public ActionResult Create(Student student)
        {
            student.Id = Guid.NewGuid();
            students.Add(student);
            return PartialView("_List", students);
        }

        // GET: Student/Edit/{id} (Returns Partial View)
        public ActionResult Edit(Guid id)
        {
            var student = students.FirstOrDefault(s => s.Id.Equals(id));
            if (student == null) return HttpNotFound();
            return PartialView("_Edit", student);
        }

        // POST: Student/Edit
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id.Equals(student.Id));
            if (existingStudent == null) return HttpNotFound();

            existingStudent.Name = student.Name;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.Address = student.Address;
            existingStudent.Phone = student.Phone;
            existingStudent.Email = student.Email;

            return PartialView("_List", students);
        }

        // GET: Student/Delete/{id} (Returns Partial View)
        public ActionResult Delete(Guid id)
        {
            var student = students.FirstOrDefault(s => s.Id.Equals(id));
            if (student == null) return HttpNotFound();
            return PartialView("_Delete", student);
        }

        // POST: Student/DeleteConfirmed/{id}
        [HttpPost]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var student = students.FirstOrDefault(s => s.Id.Equals(id));
            if (student != null) students.Remove(student);

            return PartialView("_List", students);
        }

        // GET: Student/Details/{id} (Returns Partial View)
        public ActionResult Details(Guid id)
        {
            var student = students.FirstOrDefault(s => s.Id.Equals(id));
            if (student == null) return HttpNotFound();
            return PartialView("_Details", student);
        }
    }
}
