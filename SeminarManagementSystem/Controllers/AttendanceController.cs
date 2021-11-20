using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.DB;
using ManagementSystem.DB.DBOperations;
using ManagementSystem.Model;

namespace SeminarManagementSystem.Controllers
{
    [Authorize]
    public class AttendanceController : Controller
    {
        SeminarDBEntities db = new SeminarDBEntities();

        AttendanceRepository repository;
        public AttendanceController()
        {
            repository = new AttendanceRepository();
        }

        public List<Seminar> GetSeminar()
        {
            List<Seminar> seminarList = db.Seminar.ToList();
            return seminarList;
        }
        
        public List<Attendee> GetAttendee()
        {
            List<Attendee> attendeeList = db.Attendee.ToList();
            return attendeeList;
        }

        public ActionResult Create()
        {
            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            ViewBag.seminarList = new SelectList(GetSeminar(), "SeminarID", "SeminarTitle");
            
            ViewBag.attendeeList = new SelectList(GetAttendee(), "AttendeeID", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Create(AttendanceModel model)
        {
            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            ViewBag.seminarList = new SelectList(GetSeminar(), "SeminarID", "SeminarTitle");

            ViewBag.attendeeList = new SelectList(GetAttendee(), "AttendeeID", "Name");

            if (ModelState.IsValid)
            {
                int id = repository.AddAttendance(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    TempData["msg"] = "<script>alert('Data Successfully Added');</script>";
                }
            }
            return View();
        }

        public ActionResult GetAllAttendance()
        {
            var result = repository.GetAllAttendance();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var seminar = repository.GetAttendance(id);
            return View(seminar);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.seminarList = new SelectList(GetSeminar(), "SeminarID", "SeminarTitle");

            ViewBag.attendeeList = new SelectList(GetAttendee(), "AttendeeID", "Name");

            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            var seminar = repository.GetAttendance(id);
            return View(seminar);
        }

        [HttpPost]
        public ActionResult Edit(AttendanceModel model)
        {
            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            ViewBag.seminarList = new SelectList(GetSeminar(), "SeminarID", "SeminarTitle");

            ViewBag.attendeeList = new SelectList(GetAttendee(), "AttendeeID", "Name");

            if (ModelState.IsValid)
            {
                repository.UpdateAttendance(model.AttendanceID, model);

                return RedirectToAction("GetAllAttendance");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (repository.DeleteAttendance(id))
            {
                return RedirectToAction("GetAllAttendance");
            }
            else
            {
                TempData["msg"] = "<script>alert('This data cannot be deleted');</script>";
                return RedirectToAction("GetAllAttendance");
            }
        }
    }
}