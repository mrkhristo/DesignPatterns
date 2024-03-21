using Microsoft.AspNetCore.Mvc;
using Tools.Earn;

namespace DesingPatternsAsp.Controllers
{
    public class ProductDetailController : Controller
    {
        //factories
        private LocalEarnFactory _localEarnFactory;
        private ForeignEarnFactory _foreignEarnFactory;

        //Dependency Injection 
        public ProductDetailController(LocalEarnFactory localEarnFactory, ForeignEarnFactory foreignEarnFactory)
        {
            _localEarnFactory = localEarnFactory;
            _foreignEarnFactory = foreignEarnFactory;
        }

        public IActionResult Index(decimal total)
        {
            //product
            var localEarn = _localEarnFactory.GetEarn();
            var foreignEarn = _foreignEarnFactory.GetEarn();

            //total
            ViewBag.TotalLocal = total + localEarn.Earn(total);
            ViewBag.TotalForeing = total + foreignEarn.Earn(total);

            return View();
        }
    }
}
