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
using iwContactManager.Services;

namespace iwContactManager.Controllers
{
    public class ValidatorsController : Controller
    {
        private IValidatorService service;
        public ValidatorsController(IValidatorService service)
        {
            this.service = service;

        }



        // GET: Validators
        public ActionResult Index()
        {

            IList<AValidator> list = service.GetValidators();
            return View(list);
        }

        // GET: Validators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AValidator aValidator = service.GetValidator((int)id);
            
            if (aValidator == null)
            {
                return HttpNotFound();
            }
            ValidatorViewModel model = new ValidatorViewModel();
            model.aValidator = aValidator;
            model.ValidatorType = aValidator.GetType().BaseType.Name;
            return View(model);

        }



        public ActionResult SelectValidatorType()
        {
            return View();
        }

        // GET: Validators/Create
        public ActionResult Create(string validatorType)
        {

            if (String.IsNullOrEmpty(validatorType))
                return RedirectToAction("SelectValidatorType");
            //ViewBag.ListIDList = new SelectList(db.Lists, "ID", "ListName");
            //PopulateValidatorTypeDropDownList();

            ValidatorViewModel model = new ValidatorViewModel();
            model.ValidatorType = validatorType;
            model.aValidator = (AValidator)Activator.CreateInstance("iwContactManager", "iwContactManager.Models.Validators." + validatorType).Unwrap();
            
            //model.ListIDSelectList = new SelectList(db.Lists, "ID", "ListName");
            //model.ValidatorTypeSelectList = GetValidatorTypeSelectList();
            return View(model);
        }

        // POST: Validators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ValidatorId,Description,ValueToValidate")] AValidator aValidator)
        //public ActionResult Create([ModelBinder(typeof(ValidatorModelBinder))] AValidator aValidator)
        public ActionResult Create(ValidatorViewModel model)
        {

            if (ModelState.IsValid)
            {
                service.InsertValidator(model.aValidator);

                //db.Validators.Add(model.aValidator);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }



        public ActionResult CreateDynamic()
        {

            ValidatorViewModel model = new ValidatorViewModel();
            return View(model);
        }




        // GET: Validators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AValidator aValidator = service.GetValidator((int)id);
            if (aValidator == null)
            {
                return HttpNotFound();
            }
            ValidatorViewModel model = new ValidatorViewModel();
            model.aValidator = aValidator;
            model.ValidatorType = aValidator.GetType().BaseType.Name;
            return View(model);
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
                //db.Entry(aValidator).State = EntityState.Modified;
                //db.SaveChanges();
                service.UpdateValidator(aValidator);
                return RedirectToAction("Index");
            }
            //ViewBag.ListIDList = new SelectList(db.Lists, "ID", "ListName", aValidator.ListID);
            return View(aValidator);
        }

        // GET: Validators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AValidator aValidator = service.GetValidator((int)id);
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
            AValidator aValidator = service.GetValidator((int)id);
            //db.Validators.Remove(aValidator);
            //db.SaveChanges();

            service.DeleteValidator(aValidator);
            return RedirectToAction("Index");
        }


        public ActionResult EditValidator(string validatorType)
        {

            AValidator model = (AValidator)Activator.CreateInstance("iwContactManager", "iwContactManager.Models.Validators." + validatorType).Unwrap();

            ViewData.TemplateInfo.HtmlFieldPrefix = "aValidator";
            return PartialView(string.Format("_{0}Dynamic", validatorType), model);
            
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
