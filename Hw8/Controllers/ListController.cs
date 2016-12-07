using Hw8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hw8.Controllers
{
    public class ListController : Controller
    {

        private Hw8Context db = new Hw8Context();

        // GET: Booty
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult Display()
        {
            
            var list = db.Crews.GroupBy(c => c.PirateID).Select(p => new { PNumber = p.Key, Total = p.Sum(b => b.Booty) }).OrderByDescending(c => c.Total).ToList();
            string[] name = new string[list.Count];
            decimal[] total = new decimal[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                name[i] = db.Pirates.Find(list[i].PNumber).Name;
                total[i] = list[i].Total;
            }
            var data = new
            {
                name = name,
                total = total,
                           };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}