using System;

namespace BklyOnboardingAPI.Domain.Shared.Constants
{
    public static class Constants
    {
        public static string DB_CONNECTION => Environment.GetEnvironmentVariable("DB_CONNECTION");

        public static string BANKLY_API_TOKEN => Environment.GetEnvironmentVariable("BANKLY_API_TOKEN");

        public static string BANKLY_TOKEN_KEY => "X-Bankly-Api-Token";

    }
}
