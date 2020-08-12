using System;

namespace Web2020Project.Website.Model
{
    public class Constants
    {
        //    FACEBOOK
        public static String FACEBOOK_APP_ID = "342032196680168";
        public static String FACEBOOK_APP_SECRET = "7e5dbf02619b7d51758c6e587c54386a";
        public static String FACEBOOK_REDIRECT_URL = "https://localhost:8443/login-facebook";

        public static String FACEBOOK_LINK_GET_TOKEN =
            "https://graph.facebook.com/oauth/access_token?client_id=%s&client_secret=%s&redirect_uri=%s&code=%s";

        //GOOGLE
        public static String GOOGLE_CLIENT_ID =
            "323063773678-1389u94fu1vkj5a8nippm1hrit1ehkhn.apps.googleusercontent.com";

        public static String GOOGLE_CLIENT_SECRET = "RL42oXDX8otzFRR1I8eANy88";
        public static String GOOGLE_REDIRECT_URI = "http://localhost:8080/login-google";
        public static String GOOGLE_LINK_GET_TOKEN = "https://accounts.google.com/o/oauth2/token";
        public static String GOOGLE_LINK_GET_USER_INFO = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=";
        public static String GOOGLE_GRANT_TYPE = "authorization_code";
    }
}