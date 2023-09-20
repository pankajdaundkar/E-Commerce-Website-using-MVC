using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Category_CRUD.Models;

namespace Product_Category_CRUD.Controllers
{
    public class UserController : Controller
    {
        IConfiguration configuration;
        Product_CRUD pcrud;
        RegisterCrud ucrud;
        LoginCrud lcrud;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;

        public UserController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.configuration = configuration;
            pcrud = new Product_CRUD(this.configuration);
            ucrud = new RegisterCrud(this.configuration);
            lcrud = new LoginCrud(this.configuration);
            this.env = env;
        }

        public ActionResult Register(int id)
        {
            return View();
        }
        public ActionResult ProductList(int pg = 1)
        {
            
            
                var model = pcrud.GetProduct();
                const int pagesize = 8;
                if (pg < 1)
                {
                    pg = 1;
                }

                int recscount = model.Count();

                var pager = new Pager(recscount, pg, pagesize);

                int recskip = (pg - 1) * pagesize;

                var data = model.Skip(recskip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;
                return View(data);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register regs)
        {
            try
            {
                int res = ucrud.AddRegister(regs);
                if(res >= 1)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    return View();
                }
                
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public ActionResult Login(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Register reg)
        {
            try
            {

                var model = lcrud.GetLogin(reg.UserName, reg.Password);
                if (model.Uid>0)
                {
                    HttpContext.Session.SetString("roll_id", model.RollId.ToString());
                    HttpContext.Session.SetString("uid", model.Uid.ToString());
                    HttpContext.Session.SetString("user_name", model.UserName);

                    if (model.RollId == 1)
                    {
                        return RedirectToAction("Index","Product");
                    }
                    else if (model.RollId == 0)
                    {
                        return RedirectToAction("ProductList", "User");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();

            }
        }


        // GET: UserController
        public ActionResult Index()
        {
            return View(pcrud.GetProduct());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult ProductDescription(int id)
        {
            var model = pcrud.GetProductById(id);
            return View(model);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
