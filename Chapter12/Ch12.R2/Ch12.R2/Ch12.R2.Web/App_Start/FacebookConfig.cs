using System;
using System.Web.Mvc;
using Microsoft.AspNet.Mvc.Facebook;
using Microsoft.AspNet.Mvc.Facebook.Authorization;

namespace Ch12.R2.Web
{
    public static class FacebookConfig
    {
        public static void Register(FacebookConfiguration configuration)
        {
            // Loads the settings from web.config using the following app setting keys:
            // Facebook:AppId, Facebook:AppSecret, Facebook:AppNamespace
            configuration.LoadFromAppSettings();

            // Adding the authorization filter to check for Facebook signed requests and permissions
            GlobalFilters.Filters.Add(new FacebookAuthorizeFilter(configuration));
        }
    }
}
