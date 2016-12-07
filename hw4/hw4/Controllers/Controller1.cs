using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //return "Hello MVC!";
            return View();
        }
        // Send data to the view and the client
        public ActionResult Page1()
        {
            Debug.WriteLine(Request.RawUrl);
            Debug.WriteLine(Request.HttpMethod);
            Debug.WriteLine(Request.QueryString);
            Debug.WriteLine(Request.QueryString["itemA"]);
            return View();
        }
        // send data from the client to the server/controller, GET
       
             [HttpGet]
        public ActionResult Page2()
        {
            Debug.WriteLine("In GET Page2");
            ShowRequest();
            return View();
        }

        // POST: /Home/Page3
        /*        [HttpPost]
                public ActionResult Page3(FormCollection form)
                {
                    Debug.WriteLine("In POST Page3");
                    ShowRequest();
                    Debug.WriteLine("username = " + form["username"]);
                    Debug.WriteLine("password = " + form["password"]);
                    ViewBag.message = "Hey, thanks!";
                    return View();
                }*/ // commented out to show the version below that uses model binding, i.e. parameter binding

        // When you put parameters in controller action methods, MVC will try to bind them to 
        // query string or posted form data values.  It will do this by name.  Watch out when
        // one or more is empty coming from the browser.  What happens?  Remember to try out Postman
        // https://www.getpostman.com/ to try out POST with arbitrary form values
        [HttpPost]
        public ActionResult Page2(string username, string password)
        {
            Debug.WriteLine("In POST Page2");
            ShowRequest();
            Debug.WriteLine("username = " + username);
            Debug.WriteLine("password = " + password);
            ViewBag.message = username + password ;
            return View();
        }

        private void ShowRequest()
        {
            Debug.WriteLine("\t" + Request.RawUrl);
            Debug.WriteLine("\t" + Request.HttpMethod);
            // See if there is form data
            Debug.WriteLine("\tForm Data:");
            NameValueCollection d = Request.Form;
            foreach (string key in d.AllKeys)        // AllKeys returns an empty string array if d is empty
            {
                Debug.WriteLine("\t {0} : {1}", key, d[key]);
            }
        }
    

        // Sending data from the client to the server/controller, using POST
        // GET: /Home/Page3
        [HttpGet]
        public ActionResult Page3()
        {
            Debug.WriteLine("In GET Page3");
            ShowRequest();
            return View();
        }

        // POST: /Home/Page3
        /*        [HttpPost]
                public ActionResult Page3(FormCollection form)
                {
                    Debug.WriteLine("In POST Page3");
                    ShowRequest();
                    Debug.WriteLine("username = " + form["username"]);
                    Debug.WriteLine("password = " + form["password"]);
                    ViewBag.message = "Hey, thanks!";
                    return View();
                }*/ // commented out to show the version below that uses model binding, i.e. parameter binding

        // When you put parameters in controller action methods, MVC will try to bind them to 
        // query string or posted form data values.  It will do this by name.  Watch out when
        // one or more is empty coming from the browser.  What happens?  Remember to try out Postman
        // https://www.getpostman.com/ to try out POST with arbitrary form values
        [HttpPost]
        public ActionResult Page3(string username, string password)
        {
            Debug.WriteLine("In POST Page3");
            ShowRequest();
            Debug.WriteLine("username = " + username);
            Debug.WriteLine("password = " + password);
            ViewBag.message = "Hey, thanks!";
            return View();
        }


        [HttpGet]
        public ActionResult View1()
        {
            Debug.WriteLine("In GET Page4");
            ShowRequest();
            return View();
        }

        // POST: /Home/Page3
        /*        [HttpPost]
                public ActionResult Page3(FormCollection form)
                {
                    Debug.WriteLine("In POST Page3");
                    ShowRequest();
                    Debug.WriteLine("username = " + form["username"]);
                    Debug.WriteLine("password = " + form["password"]);
                    ViewBag.message = "Hey, thanks!";
                    return View();
                }*/ // commented out to show the version below that uses model binding, i.e. parameter binding

        // When you put parameters in controller action methods, MVC will try to bind them to 
        // query string or posted form data values.  It will do this by name.  Watch out when
        // one or more is empty coming from the browser.  What happens?  Remember to try out Postman
        // https://www.getpostman.com/ to try out POST with arbitrary form values
        [HttpPost]
        public ActionResult View1(FormCollection form)
        {
            Debug.WriteLine("In POST Page2");
            ShowRequest();
            double monthly = Convert.ToDouble(form["borrow"]) * Convert.ToDouble(form["monthrate"]) * Math.Pow((Convert.ToDouble(form["monthrate"]) + 1), Convert.ToDouble(form["length"])) / (Math.Pow((Convert.ToDouble(form["monthrate"]) + 1), Convert.ToDouble(form["length"])) - 1);
            double sum = monthly * Convert.ToDouble(form["length"]);
            ViewBag.message = "The monthly payment is " + String.Format("{0:F}", monthly) + " and the sum of payments is " + String.Format("{0:F}", sum) + ".";
            return View();
        }
        

        
    }
}