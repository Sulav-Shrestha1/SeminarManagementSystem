using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.Model;
using ManagementSystem.DB.DBOperations;
using System.Windows;

namespace SeminarManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        AttendeeRepository repository;

        public HomeController()
        {
            repository = new AttendeeRepository();
        }
        // GET: Home
        public ActionResult Create()
        {
            var gender = new List<string>() { "Male", "Female", "Others" };
            ViewBag.Gender = gender;

            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            return View();
        }

        [HttpPost]
        public ActionResult Create(AttendeeModel model)
        {
            var gender = new List<string>() { "Male", "Female", "Others"};
            ViewBag.Gender = gender;

            var availability = new List<string>() { "True", "False"};
            ViewBag.Availability = availability;

            ViewBag.JavaScriptFunction = "abc";

            if (ModelState.IsValid)
            {
                int id = repository.AddAttendee(model);
                if(id > 0)
                {
                    ModelState.Clear();
                    TempData["msg"] = "<script>alert('Data Successfully Added');</script>";
                }
                else
                {
                    ViewBag.DuplicateMessage = "Duplicate Email Found";
                    return View();
                }
            }
            return View();
        }

        public ActionResult GetAllAttendee()
        {
            var result = repository.GetAllAttendee();
            return View(result);
        }
        
        public ActionResult Details(int id)
        {
            var Attendee = repository.GetAttendee(id);
            return View(Attendee);
        }
        
        public ActionResult Edit(int id)
        {
            var gender = new List<string>() { "Male", "Female", "Others" };
            ViewBag.Gender = gender;

            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            var Attendee = repository.GetAttendee(id);
            return View(Attendee);
        }
        
        [HttpPost]
        public ActionResult Edit(AttendeeModel model)
        {
            var gender = new List<string>() { "Male", "Female", "Others" };
            ViewBag.Gender = gender;

            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            if (ModelState.IsValid)
            {
                repository.UpdateAttendee(model.AttendeeID,model);
                /*ViewBag.DuplicateMessage = "Duplicate Email Found";*/
                return RedirectToAction("GetAllAttendee");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (repository.DeleteAttendee(id))
            {
                return RedirectToAction("GetAllAttendee");
            }
            else
            {
                TempData["msg"] = "<script>alert('This data cannot be deleted');</script>";
                return RedirectToAction("GetAllAttendee");
            }
        }

        
    }
}