using MvcMasterDetail.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMasterDetail.Controllers
{
    public class FacultyController : Controller
    {
        FacultyContext db = new FacultyContext();
        // GET: Faculty
        public ActionResult Index()
        {
            return View(db.Faculties.ToList());
        }
        public ActionResult Create()
        {
            Faculty faculty = new Faculty();
            faculty.Students.Add(new Student()
            {
                StudentName = "",
                Address = ""
            });
            return View(faculty);
        }
        [HttpPost]
        public ActionResult Create(Faculty faculty, string btn)
        {
            if (btn == "ADD")
            {
                faculty.Students.Add(new Student());
            }
            if (btn == "Create")
            {
                if (ModelState.IsValid)
                {
                    if (faculty.Picture != null)
                    {
                        var rootPath = Server.MapPath("~");
                        var saveToPath = Path.Combine(rootPath, "Pictures", faculty.Picture.FileName);
                        faculty.Picture.SaveAs(saveToPath);
                        faculty.PicPath = "~/Pictures/" + faculty.Picture.FileName;
                        db.Faculties.Add(faculty);
                        if (db.SaveChanges() > 0)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Provide a valid Picture");
                        return View(faculty);
                    }
                }
            }
            return View(faculty);
        }
        public ActionResult Edit(int id)
        {
            return View(db.Faculties.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Faculty faculty, string btn)
        {
            if (btn == "ADD")
            {
                faculty.Students.Add(new Student());
            }
            if (btn == "Update")
            {
                var oldFaculty = db.Faculties.Find(faculty.ID);
                if (faculty.Picture != null)
                {
                    var rootPath = Server.MapPath("~");
                    var saveToPath = Path.Combine(rootPath, "Pictures", faculty.Picture.FileName);
                    faculty.Picture.SaveAs(saveToPath);
                    oldFaculty.PicPath = "~/Pictures/" + faculty.Picture.FileName;
                }
                else
                {
                    oldFaculty.PicPath = oldFaculty.PicPath;
                }
                oldFaculty.FacultyName = faculty.FacultyName;
                oldFaculty.CourseName = faculty.CourseName;
                oldFaculty.CourseStartDate = faculty.CourseStartDate;
                db.Students.RemoveRange(db.Students.Where(s => s.FacultyID == faculty.ID));
                db.SaveChanges();
                oldFaculty.Students = faculty.Students;
                db.Entry(oldFaculty).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(faculty);
        }
        public ActionResult Delete(int id)
        {
            db.Faculties.Remove(db.Faculties.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}