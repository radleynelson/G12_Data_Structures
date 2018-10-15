using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G12_Data_Structures.Controllers
{
    public class DictionaryController : Controller
    {
        public static Dictionary<string, int> myDicitonary = new Dictionary<string, int>();
        public static string SearchResults;
        public static int dictValue;

        public static double dTime = 0;

        public static bool DisplayModel = false;
        public ActionResult Index()
        {
            if (SearchResults != null)
            {
                ViewBag.Search = SearchResults;
            }
            if (DisplayModel)
            {
                ViewBag.DisplayModel = true;
            }
            ViewBag.StopWatch = dTime;
            DisplayModel = false;
            SearchResults = null;
            ViewBag.Dictionary = myDicitonary;
            return View();
        }
        public ActionResult AddOne()
        {
            string sKey = "New Entry" + (myDicitonary.Count + 1);
            myDicitonary.Add(sKey, myDicitonary.Count + 1);
            return RedirectToAction("Index");
        }
        public ActionResult AddHugeList()
        {
            myDicitonary.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                string sKey = "New Entry" + (myDicitonary.Count + 1);
                int iValue = (myDicitonary.Count + 1)
; myDicitonary.Add(sKey, iValue);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Clear()
        {
            myDicitonary.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteFrom()
        {
            int counter = 1;
            string key = "";
            if (myDicitonary.Count > 0)
            {
                foreach (KeyValuePair<string, int> entry in myDicitonary)
                {
                    if (counter == 1)
                    {
                        key = entry.Key;
                    }
                    counter++;
                }
                myDicitonary.Remove(key);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            //loop to do all the work
            if (myDicitonary.ContainsKey("New Entry3"))
            {
                SearchResults = "t";
                dictValue = myDicitonary["New Entry3"];
            }
            else
            {
                SearchResults = "f";
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            dTime = ts.TotalSeconds;

            return RedirectToAction("Index");


        }
        public ActionResult Display()
        {
            DisplayModel = true;
            return RedirectToAction("Index");
        }
    }
}