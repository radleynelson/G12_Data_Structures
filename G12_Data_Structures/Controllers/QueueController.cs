using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures.Controllers
{
    public class QueueController : Controller
    {
        public static Queue<int> myQueue = new Queue<int>();
        public static string SearchResults;
        public static int queueValue;

        public static double dTime = 0;
        public static bool DisplayModel = false;
        public ActionResult Index()
        {
            if(SearchResults != null)
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
            ViewBag.Queue = myQueue;
            return View();
        }
        public ActionResult AddOne()
        {
            myQueue.Enqueue(myQueue.Count + 1);
            return RedirectToAction("Index");
        }
        public ActionResult AddHugeList()
        {
            myQueue.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                
;                myQueue.Enqueue(myQueue.Count + 1);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Clear()
        {
            myQueue.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteFrom()
        {
            if (myQueue.Count > 0)
            {
                myQueue.Dequeue();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            //loop to do all the work
            if(myQueue.Contains(3))
            {
                SearchResults = "t";
                queueValue = 3;
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
