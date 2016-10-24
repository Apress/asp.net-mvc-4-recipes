using Microsoft.AspNet.Mvc.Facebook.Services;

namespace Ch12.R9.Web
{
    public static class FacebookConfig
    {
        public static void Register()
        {
            // Loads the settings from web.config using the following app setting keys:
            // Facebook.AppId, Facebook.AppSecret, Facebook.AppNamespace, Facebook.RealtimeCallbackUrl
            FacebookSettings.LoadFromConfig();
        }
    }
}
