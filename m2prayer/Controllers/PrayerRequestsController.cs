using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using m2prayer.DAL;
using m2prayer.Models;

namespace m2prayer.Controllers
{
    public class PrayerRequestsController : Controller
    {
        private PrayerContext db = new PrayerContext();

        // GET: PrayerRequests
        public ActionResult Index()
        {
            return View(db.PrayerRequests.ToList().OrderBy(r => r.Category));
        }

        // GET: PrayerRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrayerRequest prayerRequest = db.PrayerRequests.Find(id);
            if (prayerRequest == null)
            {
                return HttpNotFound();
            }
            return View(prayerRequest);
        }

        // GET: PrayerRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrayerRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category,Request")] PrayerRequest prayerRequest)
        {
            if (ModelState.IsValid)
            {
                db.PrayerRequests.Add(prayerRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prayerRequest);
        }

        // GET: PrayerRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrayerRequest prayerRequest = db.PrayerRequests.Find(id);
            if (prayerRequest == null)
            {
                return HttpNotFound();
            }
            return View(prayerRequest);
        }

        // POST: PrayerRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Request")] PrayerRequest prayerRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prayerRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prayerRequest);
        }

        // GET: PrayerRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrayerRequest prayerRequest = db.PrayerRequests.Find(id);
            if (prayerRequest == null)
            {
                return HttpNotFound();
            }
            return View(prayerRequest);
        }

        // POST: PrayerRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrayerRequest prayerRequest = db.PrayerRequests.Find(id);
            db.PrayerRequests.Remove(prayerRequest);
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
