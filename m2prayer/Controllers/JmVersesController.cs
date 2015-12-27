using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using m2prayer.Repository;
using m2prayer.Models;

namespace m2prayer.Controllers
{
    public class JmVersesController : Controller
    {
        private PrayerContext db = new PrayerContext();

        // GET: JmVerses
        public ActionResult Index()
        {
            return View(db.JmVerses.ToList().OrderBy(v => v.Month));
        }

        // GET: JmVerses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JmVerse jmVerse = db.JmVerses.Find(id);
            if (jmVerse == null)
            {
                return HttpNotFound();
            }
            return View(jmVerse);
        }

        // GET: JmVerses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JmVerses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Reference,Text,Year,Month,StartDate")] JmVerse jmVerse)
        {
            if (ModelState.IsValid)
            {
                db.JmVerses.Add(jmVerse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jmVerse);
        }

        // GET: JmVerses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JmVerse jmVerse = db.JmVerses.Find(id);
            if (jmVerse == null)
            {
                return HttpNotFound();
            }
            return View(jmVerse);
        }

        // POST: JmVerses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Reference,Text,Year,Month,StartDate")] JmVerse jmVerse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jmVerse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jmVerse);
        }

        // GET: JmVerses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JmVerse jmVerse = db.JmVerses.Find(id);
            if (jmVerse == null)
            {
                return HttpNotFound();
            }
            return View(jmVerse);
        }

        // POST: JmVerses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JmVerse jmVerse = db.JmVerses.Find(id);
            db.JmVerses.Remove(jmVerse);
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
    }
}
