using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using firstMvcProject.Models.Repository;
using System.Web.Mvc;
using firstMvcProject.Models.DBModel;

namespace firstMvcProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository CP = new CategoryRepository(new Models.DBModel.NorthwindEntities());
        // GET: Category
        public ActionResult Index()
        {
            return View(CP.getAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kategoriler model)
        {
            if(ModelState.IsValid)
            {
                CP.save(model);
            }
           
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(CP.get(id));
        }
        [HttpPost]
        public ActionResult Edit(Kategoriler model)
        {
            if (ModelState.IsValid)
            {
                CP.update(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(CP.get(id));
        }
        [HttpPost,ActionName("Delete")]

        public ActionResult DeleteCategory(int id)
        {
            if (ModelState.IsValid)
                CP.delete(CP.get(id));

            return RedirectToAction("Index");
        }
    
    }
}