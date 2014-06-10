using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CRM.Models;

namespace CRM.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CRMDbContext db = new CRMDbContext();

        // GET: /Customer/
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult Notes(int id)
        {
            Customer customer = db.Customers.Single(c => (c.Id == id));

            if (customer == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(customer);
        }

        public ActionResult AddNote(int id)
        {
            Customer customer = db.Customers.Single(c => (c.Id == id));

            if (customer == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(new NoteViewModel {CustomerId = id});
        }

        [HttpPost]
        public ActionResult AddNote(int id, NoteViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            Customer customer = db.Customers.Single(c => (c.Id == id));

            if (customer == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            customer.Notes.Add(new Note {Body = model.Body, DateCreated = DateTime.Now, UserName = User.Identity.Name});

            db.SaveChanges();

            return RedirectToAction("Notes", new {id});
        }

        // GET: /Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: /Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(
                Include =
                "Id,AddressLine1,AddressLine2,City,CompanyName,EmailAddress,FirstName,LastName,PhoneNumber,PostalCode,State"
                )] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: /Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(
                Include =
                "Id,AddressLine1,AddressLine2,City,CompanyName,EmailAddress,FirstName,LastName,PhoneNumber,PostalCode,State"
                )] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: /Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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