using DataAccessLayer.Concrete;
using Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Console
{
    public class SourceCurrency
    {

        public static void currencySource()
        {

            List<Currency> forexList;
            CurrencyDal currencyDal = new CurrencyDal();
            forexList = currencyDal.GetAll();
            // CurrencyManager manager = new CurrencyManager(currencyDal);
            // forexList = manager.GetAll();
            // build XML request
            var requestXml = new XmlDocument();
            var responseXml = new XmlDocument();
            var httpRequest = HttpWebRequest.Create("https://www.tcmb.gov.tr/kurlar/today.xml");
            // set appropriate headers
            httpRequest.Method = "POST";
            httpRequest.ContentType = "text/xml";
            using (var requestStream = httpRequest.GetRequestStream())
            {
                requestXml.Save(requestStream);
            }
            using (var response = (HttpWebResponse)httpRequest.GetResponse())
            using (var responseStream = response.GetResponseStream())
            {
                // may want to check response.StatusCode to
                // see if the request was successful

                responseXml = new XmlDocument();
                responseXml.Load(responseStream);
            }
            foreach (XmlNode node in responseXml.SelectNodes("Tarih_Date")[0].ChildNodes)
            {
                var rate = currencyDal.GetAll().FirstOrDefault(r => r.CurrencyCode == node.Attributes["CurrencyCode"].Value);

                if (rate == null)
                {
                    var currency = new Currency()
                    {

                        CurrencyCode = node.Attributes["CurrencyCode"].Value,
                        Unit = node["Unit"].InnerText,
                        CurrencyName = node["CurrencyName"].InnerText,
                        ForexBuying = node["ForexBuying"].InnerText,
                        ForexSelling = node["ForexSelling"].InnerText,
                        BanknoteBuying = node["BanknoteBuying"].InnerText,
                        BanknoteSelling = node["BanknoteSelling"].InnerText,
                        Time = DateTime.Now,

                    };
                    currencyDal.Add(currency);
                }
                else
                {
                    rate.CurrencyCode = node.Attributes["CurrencyCode"].Value;
                    rate.Unit = node["Unit"].InnerText;
                    rate.CurrencyName = node["CurrencyName"].InnerText;
                    rate.ForexBuying = node["ForexBuying"].InnerText;
                    rate.ForexSelling = node["ForexSelling"].InnerText;
                    rate.BanknoteBuying = node["BanknoteBuying"].InnerText;
                    rate.BanknoteSelling = node["BanknoteSelling"].InnerText;
                    rate.Time = DateTime.Now;
                    currencyDal.Update(rate);

                }


            }
        }
    }
}
