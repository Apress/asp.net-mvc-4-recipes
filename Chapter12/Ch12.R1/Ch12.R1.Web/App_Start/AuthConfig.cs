using Microsoft.Web.WebPages.OAuth;

namespace Ch12.R1.Web
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "122844301209074",
                appSecret: "21f37502f363da9bbc0ae0a2a59d5509");
            

        }
    }
}
