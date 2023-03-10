using Entitiees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CurrencyConsole
{

    public class SourceCurrency
    {
        List<Currency> forexList;
        public List<Currency> currencysource()
        {

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
                var forex = new Currency()
                {
                    ID = Guid.NewGuid(),
                    CurrencyCode = node.Attributes["CurrencyCode"].Value,
                    Unit = node["Unit"].InnerText,
                    CurrencyName = node["CurrencyName"].InnerText,
                    ForexBuying = node["ForexBuying"].InnerText,
                    ForexSelling = node["ForexSelling"].InnerText,
                    BanknoteBuying = node["BanknoteBuying"].InnerText,
                    BanknoteSelling = node["BanknoteSelling"].InnerText,
                };
                forexList = new List<Currency>();
                forexList.Add(forex);
            }
            return forexList;
        }
    }
}
