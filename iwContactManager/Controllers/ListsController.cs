using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iwContactManager.Models;
using iwContactManager.Services;
using AutoMapper;
using iwContactManager.ViewModels;

namespace iwContactManager.Controllers
{
    /// <summary>
    /// Lists uses ListViewModel to separate the business objects from the viewModel (MVVM). 
    /// It uses AutoMapper to help (only really useful with large/complex objects)
    /// </summary>
    public class ListsController : Controller
    {
        private IListService service;
        public ListsController(IListService service)
        {
            this.service = service;
            // AutoMapper
            Mapper.CreateMap<List, ListViewModel>();
            Mapper.CreateMap<ListViewModel, List>();

        }

        // GET: Lists
        public ActionResult Index()
        {
            IList<List> model = service.GetLists();
            
            //Mapper.CreateMap<List, ListViewModel>();
            var viewModel = Mapper.Map<IList<ListViewModel>>(model);

            return View(viewModel);
        }

        // GET: Lists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List model = service.GetList((int)id);
            if (model == null)
            {
                return HttpNotFound();
            }

            ListViewModel viewModel = Mapper.Map<ListViewModel>(model);
            return View(viewModel);
        }

        // GET: Lists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListId,ListName,ListDescription")] ListViewModel list)
        {
            var model = Mapper.Map<List>(list);
            if (ModelState.IsValid)
            {
                service.InsertList(model);
                return RedirectToAction("Index");
            }

            return View(list);
        }

        // GET: Lists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = service.GetList((int)id);

            if (list == null)
            {
                return HttpNotFound();
            }
            ListViewModel viewModel = Mapper.Map<ListViewModel>(list);
            return View(viewModel);
        }

        // POST: Lists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ListName,ListDescription")] ListViewModel list)
        {
            var model = Mapper.Map<List>(list);
            if (ModelState.IsValid)
            {
                service.UpdateList(model);
                return RedirectToAction("Index");
            }
            return View(list);
        }

        // GET: Lists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = service.GetList((int)id);

            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: Lists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List list = service.GetList((int)id);

            service.DeleteList(list);
            return RedirectToAction("Index");
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
