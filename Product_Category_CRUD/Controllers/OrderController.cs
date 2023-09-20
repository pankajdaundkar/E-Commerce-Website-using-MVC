using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Category_CRUD.Models;

namespace Product_Category_CRUD.Controllers
{
   

    public class OrderController : Controller
    {
        IConfiguration configuration;
        Product_CRUD p_crud;
        CartCURD cartrud;
        OrderCURD ordercurd;

        public OrderController(IConfiguration configuration)
        {
            this.configuration = configuration;
            p_crud = new Product_CRUD(this.configuration);
            ordercurd = new OrderCURD(this.configuration);
        }
        [HttpGet]
        public ActionResult ConfirmOrder(int id)
        {
            var model = p_crud.GetProductById(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult ConfirmOrders(int id)
        {

            try
            {
                Order ord = new Order();
                string uid = HttpContext.Session.GetString("uid");
                ord.Uid = Convert.ToInt32(uid);
                ord.Id = id;
                //ord.Quantity = 1;
                int result = ordercurd.AddOrder(ord);
                if (result == 1)
                    return RedirectToAction(nameof(GetMyOrder));
                else
                    return View();

            }
            catch (Exception ex)
            {
                return View();
            }
        }



        // GET: OrderController
        public ActionResult GetMyOrder()
        {
            string uid = HttpContext.Session.GetString("uid");

            var result = ordercurd.GetMyOrder(Convert.ToInt32(uid));

            return View(result);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
