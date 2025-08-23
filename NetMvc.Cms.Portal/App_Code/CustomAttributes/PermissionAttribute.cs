using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NetMvc.Cms.BL.ServiceImp;

namespace NetMvc.Cms.Portal.App_Code.CustomAttributes
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        // Custom property
        /// <summary>
        /// Gets or sets the AccessLevel
        /// </summary>
        public string AccessLevel { get; set; }

        /// <summary>
        /// The AuthorizeCore
        /// </summary>
        /// <param name="httpContext">The httpContext<see cref="HttpContextBase"/></param>
        /// <returns>The <see cref="bool"/></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            string[] privilegeLevels = GetUserRights();
            string[] arrAccessLevel = AccessLevel.Split(',');

            for (int i = 0; i < privilegeLevels.Length; i++)
            {
                for (int j = 0; j < arrAccessLevel.Length; j++)
                {
                    if (privilegeLevels[i].Trim().ToLower() == arrAccessLevel[j].Trim().ToLower())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// The GetUserRights
        /// </summary>
        /// <returns>The <see cref="string[]"/></returns>
        private string[] GetUserRights()
        {
            var userService = new UserService();

            return userService.GetUserRoles();
        }

        /// <summary>
        /// The HandleUnauthorizedRequest
        /// </summary>
        /// <param name="filterContext">The filterContext<see cref="AuthorizationContext"/></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Account",
                                action = "Login"
                            })
                        );
        }

        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //}
    }
}