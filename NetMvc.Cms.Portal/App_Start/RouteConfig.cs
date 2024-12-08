using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace NetMvc.Cms.Portal
{
    //public class RouteConfig
    //{
    //    public static void RegisterRoutes(RouteCollection routes)
    //    {
    //        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    //        routes.MapRoute(
    //            name: "Default",
    //            url: "{controller}/{action}/{id}",
    //            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    //        );
    //    }
    //}

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //default route

            //news index
            routes.MapRoute(name: "News Index", url: "news", defaults: new { controller = "News", action = "Index" }, namespaces: new[] { "NetMvc.Cms.Portal.Controllers" });
            //news list route
            routes.MapRouteLowercase(name: "News List", url: "news/{metatitle}-{id}", defaults: new { controller = "News", action = "NewsByCate", id = UrlParameter.Optional }, namespaces: new[] { "NetMvc.Cms.Portal.Controllers" });
            //news detail route
            routes.MapRouteLowercase(name: "News detail", url: "news-detail/{metatitle}-{id}", defaults: new { controller = "News", action = "Detail", id = UrlParameter.Optional }, namespaces: new[] { "NetMvc.Cms.Portal.Controllers" });

            routes.MapRouteLowercase(name: "About List", url: "about", defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "NetMvc.Cms.Portal.Controllers" });
            //news detail route
            routes.MapRouteLowercase(name: "About detail", url: "about/{metatitle}-{id}", defaults: new { controller = "About", action = "Details", id = UrlParameter.Optional }, namespaces: new[] { "NetMvc.Cms.Portal.Controllers" });

            //news index
            routes.MapRouteLowercase(name: "Product Index", url: "products", defaults: new { controller = "Product", action = "Index" }, namespaces: new[] { "NetMvc.Cms.Portal.Controllers" });
            //product list by cate route
            routes.MapRouteLowercase(name: "Product List", url: "product/{metatitle}-{id}", defaults: new { controller = "Product", action = "ProductByCate", metatitle = UrlParameter.Optional, id = UrlParameter.Optional }, namespaces: new[] { "NetMvc.Cms.Portal.Controllers" });
            //product detail route
            routes.MapRouteLowercase(name: "Product detail", url: "product-detail/{metatitle}-{id}", defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional }, namespaces: new[] { "NetMvc.Cms.Portal.Controllers" });

            routes.MapRouteLowercase(name: "Collection", url: "collection", defaults: new { controller = "Collection", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "NetMvc.Cms.Portal.Controllers" });
            routes.MapRouteLowercase(name: "Album", url: "Album", defaults: new { controller = "Album", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "NetMvc.Cms.Portal.Controllers" });
            //product detail route
            routes.MapRouteLowercase(name: "AlbumDetail", url: "AlbumDetail/{metatitle}-{id}", defaults: new { controller = "Album", action = "AlbumDetail", id = UrlParameter.Optional }, namespaces: new[] { "NetMvc.Cms.Portal.Controllers" });
            //contact
            routes.MapRouteLowercase(name: "Contact", url: "contact", defaults: new { controller = "Contact", action = "Index" }, namespaces: new[] { "NetMvc.Cms.Portal.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "NetMvc.Cms.Portal.Controllers" });
        }
    }

    public static class AreaRegistrationContextExtensions
    {
        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url)
        {
            return MapRouteLowercase(context, name, url, null, null, null);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults)
        {
            return MapRouteLowercase(context, name, url, defaults, null, null);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, string[] namespaces)
        {
            return MapRouteLowercase(context, name, url, null, null, namespaces);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults, object constraints)
        {
            return MapRouteLowercase(context, name, url, defaults, constraints, null);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults, string[] namespaces)
        {
            return MapRouteLowercase(context, name, url, defaults, null, namespaces);
        }

        public static Route MapRouteLowercase(this AreaRegistrationContext context, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (namespaces == null && context.Namespaces != null)
            {
                namespaces = context.Namespaces.ToArray();
            }

            Route route = context.Routes.MapRouteLowercase(name, url, defaults, constraints, namespaces);

            route.DataTokens["area"] = context.AreaName;
            route.DataTokens["UseNamespaceFallback"] = (namespaces == null || namespaces.Length == 0);

            return route;
        }
    }

    internal class LowercaseRoute : Route
    {
        public LowercaseRoute(string url, IRouteHandler routeHandler)
            : base(url, routeHandler)
        {
        }

        public LowercaseRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
        }

        public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler)
        {
        }

        public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler)
        {
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData path = base.GetVirtualPath(requestContext, values);

            if (path != null)
            {
                string virtualPath = path.VirtualPath;
                var lastIndexOf = virtualPath.LastIndexOf("?");

                if (lastIndexOf != 0)
                {
                    if (lastIndexOf > 0)
                    {
                        string leftPart = virtualPath.Substring(0, lastIndexOf).ToLowerInvariant();
                        string queryPart = virtualPath.Substring(lastIndexOf);
                        path.VirtualPath = leftPart + queryPart;
                    }
                    else
                    {
                        path.VirtualPath = path.VirtualPath.ToLowerInvariant();
                    }
                }
            }

            return path;
        }
    }

    public static class RouteCollectionExtensions
    {
        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url)
        {
            return MapRouteLowercase(routes, name, url, null, null, null);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults)
        {
            return MapRouteLowercase(routes, name, url, defaults, null, null);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, string[] namespaces)
        {
            return MapRouteLowercase(routes, name, url, null, null, namespaces);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            return MapRouteLowercase(routes, name, url, defaults, constraints, null);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, string[] namespaces)
        {
            return MapRouteLowercase(routes, name, url, defaults, null, namespaces);
        }

        public static Route MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }

            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            var route = new LowercaseRoute(url, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary(namespaces),
            };

            if (namespaces != null && namespaces.Length > 0)
            {
                route.DataTokens["Namespaces"] = namespaces;
            }

            routes.Add(name, route);

            return route;
        }
    }
}