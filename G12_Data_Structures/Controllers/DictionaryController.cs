using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G12_Data_Structures.Controllers
{
    public class DictionaryController : Controller
    {
        //declare variables
        public static Dictionary<string, int> myDicitonary = new Dictionary<string, int>();
        public static string SearchResults;
        public static int dictValue;

        public static double dTime = 0;

        public static bool DisplayModel = false;
        
        //Index Method that directs to Index View.
        public ActionResult Index()
        {
            //If we have added a searh results thorugh the Search Method we want to add them to the View Bag
            if (SearchResults != null)
            {
                ViewBag.Search = SearchResults;
            }
            //If  the Display Method is called then we want to add something to the ViewBag to show the modal
            if (DisplayModel)
            {
                ViewBag.DisplayModel = true;
            }
            //Pass in the time it took to Search
            ViewBag.StopWatch = dTime;
            DisplayModel = false;
            SearchResults = null;
            //Add Dictionary to View
            ViewBag.Dictionary = myDicitonary;
            return View();
        }
        //Method to add one to the view
        public ActionResult AddOne()
        {
            int iCount = 1;
            bool bAdd = false;
            string searchKey = "";
            foreach (KeyValuePair<string, int> entry in myDicitonary)
            {
                if (!myDicitonary.ContainsValue(iCount))
                {
                    searchKey = "New Entry" + (iCount);
                    myDicitonary.Add(searchKey, iCount);
                    bAdd = true;
                    break;
                }
                iCount++;
            }
            if (bAdd == false)
            {
                string sKey = "New Entry" + (myDicitonary.Count + 1);
                myDicitonary.Add(sKey, myDicitonary.Count + 1);
            }
           
            return RedirectToAction("Index");
        }
        //Method that adds 2000 items to the Dictionary
        public ActionResult AddHugeList()
        {
            myDicitonary.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                string sKey = "New Entry" + (myDicitonary.Count + 1);
                int iValue = (myDicitonary.Count + 1);
                myDicitonary.Add(sKey, iValue);
            }
            return RedirectToAction("Index");
        }
        //Method to Clear out the entire Dictionary
        public ActionResult Clear()
        {
            myDicitonary.Clear();
            return RedirectToAction("Index");
        }
        //Method that deletes an item from the Dictionary
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
        //Searches for a Static Value of 3 in the Dictionary
        public ActionResult Search()
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            //Start Stop Watc
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

            //Stopp Stopwatch
            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            dTime = ts.TotalSeconds;

            return RedirectToAction("Index");


        }

        //Method to display modal on show Dictionary
        public ActionResult Display()
        {
            DisplayModel = true;
            return RedirectToAction("Index");
        }
    }
}