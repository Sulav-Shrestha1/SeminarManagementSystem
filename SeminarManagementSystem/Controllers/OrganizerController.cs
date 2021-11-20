using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.DB.DBOperations;
using ManagementSystem.Model;

namespace SeminarManagementSystem.Controllers
{
    [Authorize]
    public class OrganizerController : Controller
    {
        OrganizerRespository repository;
        public OrganizerController()
        {
            repository = new OrganizerRespository();
        }

        public ActionResult Create()
        {
            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            return View();
        }

        [HttpPost]
        public ActionResult Create(OrganizerModel model)
        {
            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            ViewBag.JavaScriptFunction = "abc";

            if (ModelState.IsValid)
            {
                int id = repository.AddOrganizer(model);
                if (id > 0)
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

        public ActionResult GetAllOrganizer()
        {
            var result = repository.GetAllOrganizer();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var organizer = repository.GetOrganizer(id);
            return View(organizer);
        }

        public ActionResult Edit(int id)
        {
            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            var seminar = repository.GetOrganizer(id);
            return View(seminar);
        }

        [HttpPost]
        public ActionResult Edit(OrganizerModel model)
        {
            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            /*ViewBag.DuplicateMessage = "Duplicate Email Found";*/

            if (ModelState.IsValid)
            {
                repository.UpdateOrganizer(model.OrganizerID, model);

                return RedirectToAction("GetAllOrganizer");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (repository.DeleteOrganizer(id))
            {
                return RedirectToAction("GetAllOrganizer");
            }
            else
            {
                TempData["msg"] = "<script>alert('This data cannot be deleted');</script>";
                return RedirectToAction("GetAllOrganizer");
            }
            
        }
    }
}