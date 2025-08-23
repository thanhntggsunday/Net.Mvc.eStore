using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetMvc.Cms.BL.ServiceImp;
using NetMvc.Cms.Common.Constants;

namespace NetMvc.Cms.Portal.Class
{
    public class Utils
    {
        public static bool CheckUserIsAdmin(string email)
        {
            var userService = new UserService();
            var roles = userService.GetUserRoles(email);

            for (int i = 0; i < roles.Length; i++)
            {
                var item = roles[i];

                if (item.ToUpper() == RoleConstants.ADMIN)
                {
                    return true;
                }
            }

            return false;
        }
    }
}