using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoCompleteFilter;
using System.Collections;

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
        /// field for api cachemanager
        /// </summary>
        private readonly ICacheManager cacheManager;

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
        public HomeController(IFilterService filterService,ICacheManager cacheManager)
        {
            this.filterService = filterService;
            this.cacheManager = cacheManager;
        }

        [HttpGet]
        public JsonResult LookupinDictionaryWithLimit(string text,int limit)
        {
            var results = cacheManager.Get<List<string>>(text);
            if (results == null)
            {
                results = this.filterService.FilterWithLimit(text, limit);
                var cacheTime = ConfigurationManager.AppSettings["cacheTime"];
                cacheManager.Set(text, results, Convert.ToInt32(cacheTime));
            }

            return Json(results, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult LookupinDictionary(string text)
        {
            var results = cacheManager.Get<List<string>>(text);
            if (results == null)
            {
                results = this.filterService.Filter(text);
                var cacheTime = ConfigurationManager.AppSettings["cacheTime"];
                cacheManager.Set(text, results, Convert.ToInt32(cacheTime));
            }

            return Json(results, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}