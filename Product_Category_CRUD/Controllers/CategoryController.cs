using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Category_CRUD.Models;

namespace Product_Category_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration configuration;
        private Category_CRUD crud;

        public CategoryController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new Category_CRUD(this.configuration);
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            var model = crud.GetAllCategory();
            return View(model);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var result = crud.GetCategoryById(id);
            return View(result);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {

            try
            {
                int result = crud.AddCategory(category);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = crud.GetCategoryById(id);
            return View(result);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                int result = crud.UpdateCategory(category);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = crud.GetCategoryById(id);
            return View(result);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteCategory(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}
