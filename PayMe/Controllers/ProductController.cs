using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayMe.Service.Contract;
using PayMe.Service;

namespace PayMe.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
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
    }
}