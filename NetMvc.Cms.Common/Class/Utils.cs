using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NetMvc.Cms.Common.Class
{
    public class Utils
    {
        public static List<string> GetErrorListFromModelState(ModelStateDictionary modelState)
        {
            var query = from state in modelState.Values
                from error in state.Errors
                select error.ErrorMessage;

            var errorList = query.ToList();
            return errorList;
        }
    }
}