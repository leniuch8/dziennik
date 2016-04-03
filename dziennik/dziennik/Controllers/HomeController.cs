using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHtmlHelpers.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewData["Message"] = "Dodaj LoG do dziennika";
            ViewData["Message2"] = "Dodaj typ dziennika";
            ViewData["Message3"] = "Wybierz dziennik";
            List<string> LogTypList = new List<string>();
            //List<string> LogTypList = new List<string>();
            LogTypList.Add("Dog");
            LogTypList.Add("Cat");
            LogTypList.Add("Hamster");
            LogTypList.Add("Parrot");
            LogTypList.Add("Gold fish");
            LogTypList.Add("Mountain lion");
            LogTypList.Add("Elephant");
            string[] typylog = System.IO.File.ReadAllLines(@"C:\Users\leniuch8\dziennik\dziennik\log.txt");
            foreach (string typy in typylog)
            {
                LogTypList.Add(typy);
            }
            ViewData["Logtyp"] = new SelectList(LogTypList);

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult HandleForm(string zrodlo, string opis, string logtyp, string data)
        {
            zrodlo = zrodlo.Replace(" ", "");
            ViewData["zrodlo"] = zrodlo;
            ViewData["opis"] = opis;
            //ViewData["bookType"] = bookType;
            ViewData["LogTyp"] = logtyp;
            DateTime dt = DateTime.Now; 
            ViewData["data"] = dt.ToString("yyyy-MM-dd HH:mm:ss");

            System.IO.File.AppendAllText(@"C:\Users\leniuch8\dziennik\dziennik\logi\" + logtyp + ".txt", zrodlo+" "+logtyp+" "+ dt.ToString("yyyy-MM-dd HH:mm:ss") + " "+opis+"\n");



            return View("FormResults");
        }

        public ActionResult HandleForm2(string typ)
        {
            typ = typ.Replace(" ", "");
            typ = typ.Replace("/", "");
            typ = typ.Replace("*", "");
            typ = typ.Replace("?", "");
            ViewData["typ"] = typ;
            //LogTypList.Add("typ");
           // System.IO.File.Create(@"C:\Users\leniuch8\dziennik\dziennik\logi\" + typ + ".txt");
            System.IO.File.AppendAllText(@"C:\Users\leniuch8\dziennik\dziennik\log.txt", typ+"\n");
            return View("FormResults2");
           
        }
        public ActionResult LogViewer(string logtyp)
        {
        ViewData["LogTyp"] = logtyp;
        
            string[] logi = System.IO.File.ReadAllLines(@"C:\Users\leniuch8\dziennik\dziennik\logi\" + logtyp + ".txt");
            string result = "";
            result += "<table border>";
            result += "<tr><td>Ula wiersz pierwszy</td><td>Ula wiersz pierwszy</td><td>Ula wiersz pierwszy</td><td>Ula wiersz pierwszy</td><td>Ula wiersz pierwszy</td></tr>";
            foreach (string log in logi)
            {               
                string[] fragmnety_logu = log.Split(new char[] {' '},5);
                result += "<tr>";
                foreach(string fragment in fragmnety_logu)
                {
                    result += "<td>" + fragment + "</td>";
                }
                result += "</tr>";
            }
            result += "</table>";
            ViewData["tablica"] = result;
        return View("LogView");
    }
    }
}