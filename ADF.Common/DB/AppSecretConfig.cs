using ADF.Common.Helper;

namespace ADF.Common.DB
{
    public class AppSecretConfig
    {
        private static string Audience_Secret = Appsettings.app(new string[] { "Audience", "Secret" });

        public static string Audience_Secret_String => InitAudience_Secret();


        private static string InitAudience_Secret()
        {
            return Audience_Secret;
        }
    }
}
