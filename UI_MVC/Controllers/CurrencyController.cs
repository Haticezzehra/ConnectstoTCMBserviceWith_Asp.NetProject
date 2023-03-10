//using DataAccess.Abstract;
using DataAccessLayer.Concrete;
using Entitiess;
using Microsoft.AspNetCore.Mvc;

namespace UI_MVC.Controllers
{
    public class CurrencyController : Controller
    {

        CurrencyDal currencydal=new CurrencyDal();

        

        public IActionResult GetAllCurrency()
        {
            // List<Currency> currency = currencydal.GetAll();
            List<Currency> currency = currencydal.GetAll();
            
            return View(currency);
        }
    }
}
