using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayMe.Service.Contract;
using PayMe.Service;
using PayMe.Service.Models;

namespace PayMe.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IOrderService _orderService;

        public ProductController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProductList()
        {
            var model = _productService.GetProductListData();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddOrderItem(OrderServiceAddEditModel model)
        {
            var result = _orderService.AddOrder(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}