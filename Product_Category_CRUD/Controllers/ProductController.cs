using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Category_CRUD.Models;

namespace Product_Category_CRUD.Controllers
{
    public class ProductController : Controller
    {
        IConfiguration configuration;
        Product_CRUD p_Crud;
        Category_CRUD categoryCrud;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;
        public ProductController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.configuration = configuration;
            p_Crud = new Product_CRUD(this.configuration);
            categoryCrud = new Category_CRUD(this.configuration);
            this.env = env;
        }



        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(p_Crud.GetProduct());
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View(p_Crud.GetProductById(id));
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.Category = categoryCrud.GetAllCategory();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p, IFormFile file)
        {
            try
            {
                using (var fs = new FileStream(env.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fs);
                }
                p.Imageurl = "~/images/" + file.FileName;
                var result = p_Crud.AddProduct(p);
                if (result >= 1)
                    return RedirectToAction(nameof(Index));
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }

        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {

            var p = p_Crud.GetProductById(id);
            ViewBag.Category = categoryCrud.GetAllCategory();
            HttpContext.Session.SetString("oldImageUrl", p.Imageurl);

            return View(p);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product p, IFormFile file)
        {

            try
            {
                string oldimageurl = HttpContext.Session.GetString("oldImageUrl");
                if (file != null)
                {
                    using (var fs = new FileStream(env.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fs);
                    }
                    p.Imageurl = "~/images/" + file.FileName;


                    string[] str = oldimageurl.Split("/");
                    string str1 = (str[str.Length - 1]);
                    string path = env.WebRootPath + "\\images\\" + str1;
                    System.IO.File.Delete(path);
                }
                else
                {
                    p.Imageurl = oldimageurl;
                }
                var result = p_Crud.UpdateProduct(p);
                if (result >= 1)
                    return RedirectToAction(nameof(Index));
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                return View(ex);
            }

        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(p_Crud.GetProductById(id));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var p = p_Crud.GetProductById(id);
                string[] str = p.Imageurl.Split("/");
                string str1 = (str[str.Length - 1]);
                string path = env.WebRootPath + "\\images\\" + str1;
                System.IO.File.Delete(path);
                var result = p_Crud.DeleteProduct(id);
                if (result >= 1)
                    return RedirectToAction(nameof(Index));
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }
    }
}
