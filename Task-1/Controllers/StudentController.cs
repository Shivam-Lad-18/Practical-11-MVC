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
        // In-memory list of students for demonstration purposes
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
        // GET: Student/Create
        // This action method returns a view for creating a new student
        public ActionResult Create()
        {
            return View();
        }
        // POST: Student/Create
        // This action method handles the form submission for creating a new student
        [HttpPost]
        public ActionResult Create(Student student)
        {
            student.Id = Guid.NewGuid();
            students.Add(student);
            return RedirectToAction("Index");
        }
        // GET: Student/Edit/
        // This action method returns a view for editing an existing student
        public ActionResult Edit(Guid id)
        {
            var student = students.FirstOrDefault(s => s.Id.Equals(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        // POST: Student/Edit/
        // This action method handles the form submission for editing an existing student
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
        // GET: Student/Delete/
        // This action method returns a view for confirming the deletion of a student
        public ActionResult Delete(Guid id)
        {
            var student = students.FirstOrDefault(s => s.Id.Equals(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        // POST: Student/Delete/
        // This action method handles the form submission for deleting a student
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
        // GET: Student/Index
        // This action method returns a view displaying the list of students
        public ActionResult Index()
        {
            return View(students);
        }
        // GET: Student/Details/
        // This action method returns a view displaying the details of a specific student
        [HttpGet, ActionName("Details")]
        public ActionResult Details(Guid id)
        {
            var student = students.FirstOrDefault(s => s.Id.Equals(id));
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
    }
}