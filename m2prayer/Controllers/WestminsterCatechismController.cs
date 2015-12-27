using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using m2prayer.DAL;
using m2prayer.Models;

namespace m2prayer.Controllers
{
    public class WestminsterCatechismController : Controller
    {
        private PrayerContext db = new PrayerContext();

        // GET: WestminsterCatechism
        public ActionResult Index()
        {
            return View(db.WestminsterCatechisms.ToList().OrderBy(q => q.Number));
        }

        // GET: WestminsterCatechism/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WestminsterCatechism westminsterCatechism = db.WestminsterCatechisms.Find(id);
            if (westminsterCatechism == null)
            {
                return HttpNotFound();
            }
            return View(westminsterCatechism);
        }

        // GET: WestminsterCatechism/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WestminsterCatechism/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Question,Answer")] WestminsterCatechism westminsterCatechism)
        {
            if (ModelState.IsValid)
            {
                db.WestminsterCatechisms.Add(westminsterCatechism);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(westminsterCatechism);
        }

        // GET: WestminsterCatechism/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WestminsterCatechism westminsterCatechism = db.WestminsterCatechisms.Find(id);
            if (westminsterCatechism == null)
            {
                return HttpNotFound();
            }
            return View(westminsterCatechism);
        }

        // POST: WestminsterCatechism/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Question,Answer")] WestminsterCatechism westminsterCatechism)
        {
            if (ModelState.IsValid)
            {
                db.Entry(westminsterCatechism).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(westminsterCatechism);
        }

        // GET: WestminsterCatechism/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WestminsterCatechism westminsterCatechism = db.WestminsterCatechisms.Find(id);
            if (westminsterCatechism == null)
            {
                return HttpNotFound();
            }
            return View(westminsterCatechism);
        }

        // POST: WestminsterCatechism/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WestminsterCatechism westminsterCatechism = db.WestminsterCatechisms.Find(id);
            db.WestminsterCatechisms.Remove(westminsterCatechism);
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
