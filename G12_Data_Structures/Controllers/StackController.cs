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
        public static Stack<int> myStack = new Stack<int>();
        public static string SearchResults;
        public static int stackValue;

        public static bool DisplayModel = false;

        public static double dTime = 0;
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
            ViewBag.Stack = myStack;
            return View();
        }
        public ActionResult AddOne()
        {
            myStack.Push(myStack.Count + 1);
            return RedirectToAction("Index");
        }
        public ActionResult AddHugeList()
        {
            myStack.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {

                ; myStack.Push(myStack.Count + 1);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Clear()
        {
            myStack.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteFrom()
        {
            if (myStack.Count > 0)
            {
                myStack.Pop();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

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
