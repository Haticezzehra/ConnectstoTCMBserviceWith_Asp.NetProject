using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Entitiess;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using UI_MVC.Models.Domain;
using UI_MVC.Models;


namespace UI_MVC.Controllers
{
    public class CurrencyController : Controller
    {
        CurrencyDal currencydal = new CurrencyDal();


        public IActionResult GetAllCurrency()
        {
            List<Forex> forex = new List<Forex>();
            foreach (Currency temp in currencydal.GetAll())
            {
                Forex fore = new Forex()
                {
                    ID = temp.ID,
                    BanknoteBuying = temp.BanknoteBuying,
                    BanknoteSelling = temp.BanknoteSelling,
                    CurrencyCode = temp.CurrencyCode,
                    CurrencyName = temp.CurrencyName,
                    ForexBuying = temp.ForexBuying,
                    ForexSelling = temp.ForexSelling,
                    Time = temp.Time,
                    Unit = temp.Unit

                };
                forex.Add(fore);
            }

            return View(forex);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Forex forex)
        {
            var currency = new Currency()
            {
                CurrencyCode = forex.CurrencyCode,
                Unit = forex.Unit,
                CurrencyName = forex.CurrencyName,
                BanknoteBuying = forex.BanknoteBuying,
                BanknoteSelling = forex.BanknoteSelling,
                ForexBuying = forex.ForexBuying,
                ForexSelling = forex.ForexSelling,
                Time = DateTime.Now,
            };
            var rate = currencydal.GetAll().FirstOrDefault(r => r.CurrencyCode == currency.CurrencyCode);
            if (rate == null)
            {
                currencydal.Add(currency);
            }
            else
            {
                rate.CurrencyCode = currency.CurrencyCode;
                rate.Unit = currency.Unit;
                rate.CurrencyName = currency.CurrencyName;
                rate.ForexBuying = currency.ForexBuying;
                rate.ForexSelling = currency.ForexSelling;
                rate.BanknoteBuying = currency.BanknoteBuying;
                rate.BanknoteSelling = currency.BanknoteSelling;
                rate.Time = DateTime.Now;
                currencydal.Update(rate);
            }

            return RedirectToAction("GetAllCurrency");
        }



        [HttpGet]
        public async Task<IActionResult> View(int id)
        {

            var forex = currencydal.GetAll().FirstOrDefault(r => r.ID == id);
            if (forex != null)
            {
                var viewModel = new UpdateCurrencyViewModel()
                {
                    ID = forex.ID,
                    CurrencyCode = forex.CurrencyCode,
                    Unit = forex.Unit,
                    CurrencyName = forex.CurrencyName,
                    BanknoteBuying = forex.BanknoteBuying,
                    BanknoteSelling = forex.BanknoteSelling,
                    ForexBuying = forex.ForexBuying,
                    ForexSelling = forex.ForexSelling,
                    Time = forex.Time,


                };

                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");

        }


        [HttpPost]
        public async Task<IActionResult> View(UpdateCurrencyViewModel model)
        {
            var currency = currencydal.GetAll().FirstOrDefault(r => r.ID == model.ID);

            if (currency != null)
            {
                currency.CurrencyName = model.CurrencyName;
                currency.CurrencyCode = model.CurrencyCode;
                currency.Unit = model.Unit;
                currency.BanknoteBuying = model.BanknoteBuying;
                currency.BanknoteSelling = model.BanknoteSelling;
                currency.ForexBuying = model.ForexBuying;
                currency.ForexSelling = model.ForexSelling;
                currency.Time = DateTime.Now;
                currencydal.Update(currency);


                return RedirectToAction("GetAllCurrency");

            }
            return RedirectToAction("GetAllCurrency");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(UpdateCurrencyViewModel model)
        {
            var currency = currencydal.GetAll().FirstOrDefault(r => r.ID == model.ID);
            if (currency != null)
            {
                currencydal.Delete(currency);
                return RedirectToAction("GetAllCurrency");
            }
            return RedirectToAction("GetAllCurrency");
        }
    }

}
