using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iwContactManager.Models;
using iwContactManager.Models.Validators;
using iwContactManager.ViewModels;

namespace iwContactManager.Controllers
{
    public class ValidatorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Validators
        public ActionResult Index()
        {
            return View(db.Validators.ToList());
        }

        // GET: Validators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AValidator aValidator = db.Validators.Find(id);
            if (aValidator == null)
            {
                return HttpNotFound();
            }
            return View(aValidator);
        }


        public ActionResult Create2()
        {
            ViewBag.ListIDList = new SelectList(db.Lists, "ID", "ListName");
            PopulateValidatorTypeDropDownList();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2(AValidator aValidator)
        {
            PopulateValidatorTypeDropDownList(ViewBag.ValidatorType);

            if (ModelState.IsValid)
            {
                db.Validators.Add(aValidator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListID = new SelectList(db.Lists, "ID", "ListName", aValidator.ListID);
            return View(aValidator);
        }


        // GET: Validators/Create
        public ActionResult Create()
        {
            ViewBag.ListIDList = new SelectList(db.Lists, "ID", "ListName");
            PopulateValidatorTypeDropDownList();
            ValidatorViewModel model = new ValidatorViewModel();
            return View(model);
        }

        // POST: Validators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ValidatorId,Description,ValueToValidate")] AValidator aValidator)
        //public ActionResult Create([ModelBinder(typeof(ValidatorModelBinder))] AValidator aValidator)
        //public ActionResult Create(AValidator aValidator)
        public ActionResult Create(ValidatorViewModel model)
        {
            //AValidator aValidator = new AgeValidator();

            PopulateValidatorTypeDropDownList(model.ValidatorType);

            if (ModelState.IsValid)
            {
                db.Validators.Add(model.aValidator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListIDList = new SelectList(db.Lists, "ID", "ListName", model.aValidator.ListID);
            return View(model);
        }

        // GET: Validators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AValidator aValidator = db.Validators.Find(id);
            if (aValidator == null)
            {
                return HttpNotFound();
            }
            ViewBag.ValidatorType = aValidator.GetType().Name;
            ViewBag.ListIDList = new SelectList(db.Lists, "ID", "ListName", aValidator.ListID);
            return View(aValidator);
        }

        // POST: Validators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ValidatorId,Description,ValueToValidate")] AValidator aValidator)
        public ActionResult Edit(AValidator aValidator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aValidator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListIDList = new SelectList(db.Lists, "ID", "ListName", aValidator.ListID);
            return View(aValidator);
        }

        // GET: Validators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AValidator aValidator = db.Validators.Find(id);
            if (aValidator == null)
            {
                return HttpNotFound();
            }
            return View(aValidator);
        }

        // POST: Validators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AValidator aValidator = db.Validators.Find(id);
            db.Validators.Remove(aValidator);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult EditValidator(string validatorType)
        {
         
            return PartialView(string.Format("_{0}", validatorType));
            
        }

        private void PopulateValidatorTypeDropDownList(object validatorType = null)
        {
        
            List<SelectListItem> types = new List<SelectListItem>();
            types.Add(new SelectListItem() { Text = "Select One", Value = "" });
            types.Add(new SelectListItem() { Text = "AgeValidator", Value = "AgeValidator" });
            types.Add(new SelectListItem() { Text = "DupeListValidator", Value = "DupeListValidator" });
            types.Add(new SelectListItem() { Text = "FilterValidator", Value = "FilterValidator" });

            ViewBag.ValidatorTypeList = new SelectList(types, "Text", "Value");

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
