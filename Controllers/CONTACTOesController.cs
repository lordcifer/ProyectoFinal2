﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectFinal2.Models;

namespace ProyectFinal2.Controllers
{
    public class CONTACTOesController : Controller
    {
        private ExamenFinal2Entities1 db = new ExamenFinal2Entities1();

        // GET: CONTACTOes
        public ActionResult Index()
        {
            return View(db.CONTACTO.ToList());
        }

        // GET: CONTACTOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTO cONTACTO = db.CONTACTO.Find(id);
            if (cONTACTO == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTO);
        }

        // GET: CONTACTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CONTACTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NOMBRE,APELLIDO,DOCUMENTOS,FECHA_CREACION")] CONTACTO cONTACTO)
        {
            if (ModelState.IsValid)
            {
                db.CONTACTO.Add(cONTACTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cONTACTO);
        }

        // GET: CONTACTOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTO cONTACTO = db.CONTACTO.Find(id);
            if (cONTACTO == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTO);
        }

        // POST: CONTACTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NOMBRE,APELLIDO,DOCUMENTOS,FECHA_CREACION")] CONTACTO cONTACTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONTACTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cONTACTO);
        }

        // GET: CONTACTOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACTO cONTACTO = db.CONTACTO.Find(id);
            if (cONTACTO == null)
            {
                return HttpNotFound();
            }
            return View(cONTACTO);
        }

        // POST: CONTACTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CONTACTO cONTACTO = db.CONTACTO.Find(id);
            db.CONTACTO.Remove(cONTACTO);
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
