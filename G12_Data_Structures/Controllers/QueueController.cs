using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures.Controllers
{
    public class QueueController : Controller
    {
        //Initalize Que Object and other Variables
        public static Queue<int> myQueue = new Queue<int>();
        public static string SearchResults;
        public static int queueValue;

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
            //Added Queue to the ViewBat
            ViewBag.Queue = myQueue;
            return View();
        }
        //Mehtod to Add one to queue
        public ActionResult AddOne()
        {
            myQueue.Enqueue(myQueue.Count + 1);
            return RedirectToAction("Index");
        }
        //Add 2000 to Queue
        public ActionResult AddHugeList()
        {
            myQueue.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                
;                myQueue.Enqueue(myQueue.Count + 1);
            }
            return RedirectToAction("Index");
        }

        //Clear out the Queue
        public ActionResult Clear()
        {
            myQueue.Clear();
            return RedirectToAction("Index");
        }
        //Delete form off the Top of the Queue
        public ActionResult DeleteFrom()
        {
            if (myQueue.Count > 0)
            {
                myQueue.Dequeue();
            }

            return RedirectToAction("Index");
        }
        //Search for the value 3 in the Queue
        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //Start Stop Watch
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
            //Stop Stopwatch
            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            dTime = ts.TotalSeconds;
            
            
            return RedirectToAction("Index");
            

        }
        //Display the Queue in the Modal
        public ActionResult Display()
        {
            DisplayModel = true;
            return RedirectToAction("Index");
        }
    }
}
