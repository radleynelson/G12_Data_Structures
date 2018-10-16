using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G12_Data_Structures.Controllers
{
    public class StackController : Controller
    {
        // GET: Stack
        //Initalize Stack and other Variables
        public static Stack<int> myStack = new Stack<int>();
        public static string SearchResults;
        public static int stackValue;

        public static bool DisplayModel = false;

        public static double dTime = 0;
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
            //Pass Stack into the ViewBag
            ViewBag.Stack = myStack;
            return View();
        }
        //Add one to the Stack
        public ActionResult AddOne()
        {
            myStack.Push(myStack.Count + 1);
            return RedirectToAction("Index");
        }
        //Add 2000 items to the Stack
        public ActionResult AddHugeList()
        {
            myStack.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {

                ; myStack.Push(myStack.Count + 1);
            }
            return RedirectToAction("Index");
        }
        //Clear out the Stack
        public ActionResult Clear()
        {
            myStack.Clear();
            return RedirectToAction("Index");
        }
        //Delete one from the Stack
        public ActionResult DeleteFrom()
        {
            if (myStack.Count > 0)
            {
                myStack.Pop();
            }

            return RedirectToAction("Index");
        }
        //Search for the Value 3 in the Stack
        public ActionResult Search()
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //Start Stop Watch
            sw.Start();

            //loop to do all the work
            if (myStack.Contains(3))
            {
                SearchResults = "t";
                stackValue = 3;
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
        //Display Stack in Modal
        public ActionResult Display()
        {
            DisplayModel = true;
            return RedirectToAction("Index");
        }
    }
}
