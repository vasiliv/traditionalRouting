using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//adeed
using traditionalRouting.Models;

namespace traditionalRouting.Controllers
{
    [RoutePrefix("students")]
    public class StudentController : Controller
    {
        //[Route("students")]
        // tu RoutePrefix-s vikenebt:
        [Route("")]
        public ActionResult GetAllStudents()
        {
            var students = Students();
            return View(students);
        }
        //http://localhost:62507/Student/getstudent?id=1
        //[Route("students/{id}")]
        [Route("{id}")]
        public ActionResult GetStudent(int id) {
            var students = Students().FirstOrDefault(x => x.Id == id);
            return View(students);
        }
        //http://localhost:62507/Student/GetStudentAddress?id=1
        //[Route("students/{id}/address")]
        [Route("{id}/address")]
        public ActionResult GetStudentAddress(int id) {
            var studentAddress = Students().Where(x => x.Id == id).Select(x => x.Address).FirstOrDefault();
            return View(studentAddress);
        }
        private List<Student> Students() {
            return new List<Student>() {
             new Student() {
                Id = 1,
                Name = "1 student",
                Class = "First",
                Address = new Address() {
                    Address1 = "This is student 1 address",
                    City = "Tbilisi",
                    HomeNumber ="1234"
                }
            },
            new Student() {
                Id = 2,
                Name = "2 student",
                Class = "Second",
                Address = new Address() {
                    Address1 = "This is student 2 address",
                    City = "Tbilisi2",
                    HomeNumber = "1234456"
                }
            }
        };
            }
    }
}