using System.Net;
using System.Web.Mvc;
using m2prayer.Repository;
using m2prayer.Models;
using m2prayer.Services;

namespace m2prayer.Controllers
{
    public class WestminsterCatechismController : Controller
    {
        private readonly IWestminsterCatechismService _catechismService;

        public WestminsterCatechismController()
        {
            _catechismService = new WestminsterCatechismService(new WestminsterCatechismRepository(new PrayerContext()));
        }

        public WestminsterCatechismController(IWestminsterCatechismService catechismService)
        {
            _catechismService = catechismService;
        }

        // GET: WestminsterCatechism
        public ActionResult Index()
        {
            return View(_catechismService.GetCatechisms());
        }

        // GET: WestminsterCatechism/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WestminsterCatechism westminsterCatechism = _catechismService.GetCatechismById(id);
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
                _catechismService.InsertCatechism(westminsterCatechism);
                _catechismService.Save();
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
            WestminsterCatechism westminsterCatechism = _catechismService.GetCatechismById(id);
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
                _catechismService.UpdateCatechism(westminsterCatechism);
                _catechismService.Save();
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
            WestminsterCatechism westminsterCatechism = _catechismService.GetCatechismById(id);
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
            _catechismService.DeleteCatechism(id);
            _catechismService.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _catechismService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
