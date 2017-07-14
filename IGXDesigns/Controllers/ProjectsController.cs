using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IGXDesigns.Models;
using Newtonsoft.Json;


namespace IGXDesigns.Controllers
{
    public class ProjectsController : Controller
    {
        private ProjectDBContext db = new ProjectDBContext();

        // GET: Projects
        public ActionResult Index(string searchString)
        {
            var projects = from p in db.Project
                         select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(s => s.Name.Contains(searchString));
            }

            return View(projects);
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,LiveLink,GitLink,GitLinkText,Designer")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Project.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,LiveLink,GitLink,GitLinkText,Designer")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Project.Find(id);
            db.Project.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public string getPosterURL(int? id)
        //{
        //    Project project = db.Project.Find(id);
        //    var plusTitle = project.Name.Replace(" ", "+");
        //    System.Diagnostics.Debug.WriteLine(plusTitle);
        //    var json = new WebClient().DownloadString("https://api.themoviedb.org/3/search/movie?api_key=efd3636a73f29caea4f872a3b84518f8&query=" + plusTitle);
        //    //List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
        //    RootObject parsedJson = JsonConvert.DeserializeObject<RootObject>(json);
        //    System.Diagnostics.Debug.WriteLine("total results: " + parsedJson.total_results);
        //    var imageString = "https://image.tmdb.org/t/p/w500" + parsedJson.results[0].poster_path;
        //    new WebClient().DownloadFile(imageString, "C:\\Users\\julian.reed\\Documents\\Visual Studio 2015\\Projects\\MvcMovie\\MvcMovie\\App_Data\\Posters\\" + movie.Title + ".jpg");
        //    return imageString;
        //}


    }
}
