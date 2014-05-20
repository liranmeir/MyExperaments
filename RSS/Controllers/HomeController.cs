using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using RSS.Models;

namespace RSS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private static string _blogURL = "http://www.ynet.co.il/Integration/StoryRss2.xml";

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetRSS()
        {
            var feeds = this.GetFeeds();

            return this.PartialView("_GetRSS", feeds);
        }

        public PartialViewResult GetRSSwithParams(int siteId)
        {
            switch (siteId)
            {
                case 1:
                    _blogURL = "http://www.ynet.co.il/Integration/StoryRss2.xml";
                    break;
                case 2:
                    _blogURL = "http://http://www.geektime.co.il/feed/";
                    break;
            }

            var feeds = GetFeeds();

            return PartialView("_GetRSS", feeds);
        }

        private IEnumerable<Rss> GetFeeds()
        {
            XDocument feedXml = XDocument.Load(_blogURL);
            var res = from feed in feedXml.Descendants("item")
                select new Rss
                {
                    Title = feed.Element("title").Value,
                    Link = feed.Element("link").Value,
                    Description = Regex.Match(feed.Element("description").Value, @"^.{1,180}\b(?<!\s)").Value

                };

            return res;
        }
    }
}
