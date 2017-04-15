using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoCompleteFilter;

namespace AutoCompleteApplication.Controllers
{
    /// <summary>
    /// Home Controller class
    /// </summary>
    public class HomeController : Controller
    {
        ///<summary>
        /// filter service
        ///</summary>
        private readonly IFilterService filterService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public HomeController()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="filterService">filterService interface</param>
        public HomeController(IFilterService filterService)
        {
            this.filterService = filterService;
        }

        [HttpGet]
        public JsonResult LookupinDictionary(string text,int limit)
        {
         return Json(this.filterService.Filter(text,limit), JsonRequestBehavior.AllowGet);

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}