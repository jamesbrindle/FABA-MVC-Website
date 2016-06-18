using System.Web.Mvc;
using System.Web.Routing;

namespace IR_BackOffice.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // HOME

            routes.MapRoute("Home", "", new { controller = "Home", action = "Index" }
               );

            routes.MapRoute("News", "news", new { controller = "Home", action = "News" }
               );
            
            routes.MapRoute("LiveScores", "live-scores", new { controller = "Home", action = "LiveScores" }
               );

            routes.MapRoute("Tips", "betting-tips", new { controller = "Home", action = "Tips" }
               );

            routes.MapRoute("FreeBets", "free-bets", new { controller = "Home", action = "FreeBets" }
               );

            routes.MapRoute("TermsAndConditions", "terms-and-conditions", new { controller = "Home", action = "TermsAndConditions" }
               );

            routes.MapRoute("Sitemap", "sitemap", new { controller = "Home", action = "Sitemap" }
               );

            routes.MapRoute("PrivacyPolicy", "privacy-policy", new { controller = "Home", action = "PrivacyPolicy" }
               );

            routes.MapRoute("Contact", "contact", new { controller = "Home", action = "Contact" }
               );
            
            // ADMIN

            routes.MapRoute("NewsAdmin", "news-admin", new { controller = "News", action = "Index" }
               );

            routes.MapRoute("NewsItemAdmin", "news-admin/{id}", new { controller = "News", action = "NewsItem", id = UrlParameter.Optional }
               );

            routes.MapRoute("TipsAdmin", "tips-admin", new { controller = "Tips", action = "Index" }
               );

            routes.MapRoute("TipsItemAdmin", "tips-admin/{id}", new { controller = "Tips", action = "TipsItem", id = UrlParameter.Optional }
               );

            routes.MapRoute("BookmakersAdmin", "bookmakers-admin", new { controller = "Bookmaker", action = "Index" }
               );

            routes.MapRoute("BookmakerItemAdmin", "bookmakers-admin/{id}", new { controller = "Bookmaker", action = "BookmakerItem", id = UrlParameter.Optional }
               );

            routes.MapRoute("LeagueCodesAdmin", "league-codes-admin", new { controller = "LeagueCodes", action = "Index" }
               );

            routes.MapRoute("LeagueCodeItemAdmin", "bookmakers-codes-admin/{id}", new { controller = "LeagueCodes", action = "LeagueCodes", id = UrlParameter.Optional }
               );

            // MISC
            
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}