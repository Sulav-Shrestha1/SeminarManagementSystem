using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeminarManagementSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "All Attendee",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "GetAllAttendee", id = UrlParameter.Optional }
            );
            


            routes.MapRoute(
                name: "Seminar",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Seminar", action = "Create", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "All Seminar",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Seminar", action = "GetAllSeminar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Attendance",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Attendance", action = "Create", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "All Attendance",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Attendance", action = "GetAllAttendance", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Organizer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Organizer", action = "Create", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "All Organizer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Organizer", action = "GetAllOrganizer", id = UrlParameter.Optional }
            );
        }
    }
}
