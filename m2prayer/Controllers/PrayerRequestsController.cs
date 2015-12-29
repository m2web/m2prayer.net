using System.Net;
using System.Web.Mvc;
using m2prayer.Repository;
using m2prayer.Models;
using m2prayer.Services;

namespace m2prayer.Controllers
{
    public class PrayerRequestsController : Controller
    {
        private readonly IPrayerRequestService _prayerRequestService;

        public PrayerRequestsController()
        {
            _prayerRequestService = new PrayerRequestService(new PrayerRequestRepository(new PrayerContext()));
        }

        public PrayerRequestsController(IPrayerRequestService prayerRequestService)
        {
            _prayerRequestService = prayerRequestService;
        }

        // GET: PrayerRequests
        public ActionResult Index()
        {
            return View(_prayerRequestService.GetRequests());
        }

        // GET: PrayerRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrayerRequest prayerRequest = _prayerRequestService.GetRequestById(id);
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
               _prayerRequestService.InsertRequest(prayerRequest);
                _prayerRequestService.Save();
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
            PrayerRequest prayerRequest = _prayerRequestService.GetRequestById(id);
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
                _prayerRequestService.UpdateRequest(prayerRequest);
                _prayerRequestService.Save();
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
            PrayerRequest prayerRequest = _prayerRequestService.GetRequestById(id);
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
            _prayerRequestService.DeleteRequest(id);
            _prayerRequestService.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _prayerRequestService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
