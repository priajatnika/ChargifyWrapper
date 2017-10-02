using Chargify.Wrapper.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Chargify.Wrapper
{
    public class Configuration
    {
        static Configuration() { }

        public const string CHARGIFY_ENDPOINT = @"https://%Site%.chargify.com/";
        public const string API_KEY_DEVELOPMENT = @"9oq6engPPmnXScKuwQ77pdngZSCvYlUvo2Oruq6LzQ";
        public const string API_KEY_STAGING = @"<<not set yet>>";
        public const string API_KEY_DEMO = @"<<not set yet>>";
        public const string API_KEY_LIVE = @"<<not set yet>>";

        public const string PRODUCT_FAMILY_HANDLE = "geekseat-billing-plans";
        public const int PRODUCT_FAMILY_ID_DEVELOPMENT = 1038894;
        public const int PRODUCT_FAMILY_ID_STAGING = 0;
        public const int PRODUCT_FAMILY_ID_DEMO = 0;
        public const int PRODUCT_FAMILY_ID_LIVE = 0;

        public static string GetSiteDomain(SiteDomainType site = SiteDomainType.Development)
        {
            return ReflectionUtils.GetEnumDescription(site);
        }

        public static string GetAPIKey(SiteDomainType site = SiteDomainType.Development)
        {
            switch(site)
            {
                case SiteDomainType.Development:
                    return API_KEY_DEVELOPMENT;
                case SiteDomainType.Staging:
                    return API_KEY_STAGING;
                case SiteDomainType.Demo:
                    return API_KEY_DEMO;
                case SiteDomainType.Live:
                    return API_KEY_LIVE;
                default:
                    return API_KEY_DEVELOPMENT;
            }
        }

        public static int GetProductFamilyId(SiteDomainType site = SiteDomainType.Development)
        {
            switch (site)
            {
                case SiteDomainType.Development:
                    return PRODUCT_FAMILY_ID_DEVELOPMENT;
                case SiteDomainType.Staging:
                    return PRODUCT_FAMILY_ID_STAGING;
                case SiteDomainType.Demo:
                    return PRODUCT_FAMILY_ID_DEMO;
                case SiteDomainType.Live:
                    return PRODUCT_FAMILY_ID_LIVE;
                default:
                    return PRODUCT_FAMILY_ID_DEVELOPMENT;
            }
        }

        public static string GetEndpoint(SiteDomainType site = SiteDomainType.Development)
        {
            return CHARGIFY_ENDPOINT.Replace(@"%Site%", GetSiteDomain(site));
        }

        #region enums
        public enum SiteDomainType
        {
            [Description("hub3c-dev")]
            Development = 0,
            [Description("hub3c-staging")]
            Staging = 2,
            [Description("hub3c-demo")]
            Demo = 3,
            [Description("hub3c")]
            Live = 4
        }

        public enum HttpMethodType
        {
            Get = 0,
            Post = 1,
            Put = 2,
            Delete = 3
        }
        #endregion
    }
}
