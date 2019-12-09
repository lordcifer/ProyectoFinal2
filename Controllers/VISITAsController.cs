using System;
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
    public class VISITAsController : Controller
    {
        private ExamenFinal2Entities1 db = new ExamenFinal2Entities1();

        // GET: VISITAs
        public ActionResult Index()
        {
            return View(db.VISITA.ToList());
        }

        // GET: VISITAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISITA vISITA = db.VISITA.Find(id);
            if (vISITA == null)
            {
                return HttpNotFound();
            }
            return View(vISITA);
        }

        // GET: VISITAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VISITAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MOTIVO_VISITA,FECHA_VISITA,HORA_ENTRADA,HORA_SALIDA,NOMBRE_COMPLETO,CONTACTO_RECIBIO")] VISITA vISITA)
        {
            if (ModelState.IsValid)
            {
                db.VISITA.Add(vISITA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vISITA);
        }

        // GET: VISITAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISITA vISITA = db.VISITA.Find(id);
            if (vISITA == null)
            {
                return HttpNotFound();
            }
            return View(vISITA);
        }

        // POST: VISITAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MOTIVO_VISITA,FECHA_VISITA,HORA_ENTRADA,HORA_SALIDA,NOMBRE_COMPLETO,CONTACTO_RECIBIO")] VISITA vISITA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vISITA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vISITA);
        }

        // GET: VISITAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VISITA vISITA = db.VISITA.Find(id);
            if (vISITA == null)
            {
                return HttpNotFound();
            }
            return View(vISITA);
        }

        // POST: VISITAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VISITA vISITA = db.VISITA.Find(id);
            db.VISITA.Remove(vISITA);
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
