using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.Model;
using ManagementSystem.DB.DBOperations;
using ManagementSystem.DB;

namespace SeminarManagementSystem.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        SeminarDBEntities db = new SeminarDBEntities();

        SeminarRespository repository;
        public SeminarController()
        {
            repository = new SeminarRespository();
        }
        
        public List<Organizer> GetOrganizers()
        {
            List<Organizer> organizerList = db.Organizer.ToList();
            return organizerList;
        }
        public ActionResult Create()
        {
            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            ViewBag.organizerList = new SelectList(GetOrganizers(), "OrganizerID", "OrganizerName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(SeminarModel model)
        {
            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;
            

            ViewBag.organizerList = new SelectList(GetOrganizers(), "OrganizerID", "OrganizerName");

            ViewBag.JavaScriptFunction = "abc";

            if (ModelState.IsValid)
            {
                int id = repository.AddSeminar(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    TempData["msg"] = "<script>alert('Data Successfully Added');</script>";
                }
                else
                {
                    ViewBag.DuplicateMessage = "Duplicate Title Found";
                    return View();
                }
            }
            return View();
        }

        public ActionResult GetAllSeminar()
        {
            var result = repository.GetAllSeminar();
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var seminar = repository.GetSeminar(id);
            return View(seminar);
        }

        public ActionResult Edit(int id)
        {
            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            ViewBag.organizerList = new SelectList(GetOrganizers(), "OrganizerID", "OrganizerName");

            var seminar = repository.GetSeminar(id);
            return View(seminar);
        }

        [HttpPost]
        public ActionResult Edit(SeminarModel model)
        {
            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            ViewBag.organizerList = new SelectList(GetOrganizers(), "OrganizerID", "OrganizerName");
            if (ModelState.IsValid)
            {
                repository.UpdateSeminar(model.SeminarID, model);

                return RedirectToAction("GetAllSeminar");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (repository.DeleteSeminar(id))
            {
                return RedirectToAction("GetAllSeminar");
            }
            else
            {
                TempData["msg"] = "<script>alert('This data cannot be deleted');</script>";
                return RedirectToAction("GetAllSeminar");
            }
        }
    }
}