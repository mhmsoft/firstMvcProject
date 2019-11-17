using firstMvcProject.Models.DBModel;
using firstMvcProject.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace firstMvcProject.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository PR = new ProductRepository(new Models.DBModel.NorthwindEntities());
        CategoryRepository CR = new CategoryRepository(new Models.DBModel.NorthwindEntities());
        // GET: Product
        public ActionResult Index()
        {
            return View(PR.getAll());
        }
        public ActionResult Create()
        {
            ViewBag.Kategoriler = CR.getAll();
            ViewBag.Tedarikciler = PR.GetSuppliers() ;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Urunler model)
        {
            if (ModelState.IsValid)
            {
                PR.save(model);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            //var selectedCategory= PR.get(id).KategoriID;
            //var selectedSupplier = PR.get(id).TedarikciID;

            //ViewBag.Kategoriler = new SelectList(CR.getAll(), "KategoriID", "KategoriAdi", selectedCategory);
            //ViewBag.Tedarikciler = new SelectList(PR.GetSuppliers(), "TedarikciID", "SirketAdi", selectedSupplier);
            ViewBag.Kategoriler = CR.getAll();
            ViewBag.Tedarikciler = PR.GetSuppliers();
            return View(PR.get(id));
        }
        [HttpPost]
        public ActionResult Edit(Urunler model)
        {
            if (ModelState.IsValid)
            {
                PR.update(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(PR.get(id));
        }
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteCategory(int id)
        {
            if (ModelState.IsValid)
                PR.delete(PR.get(id));

            return RedirectToAction("Index");
        }
    }
}