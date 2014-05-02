using System;


namespace RottenTomatoes
{
    public static class QueryStringExtensions
    {
        public static string AppendQueryParameter(this string url, string key, string value)
        {
            var newUrl = SanitizeUrl(url);

            newUrl = newUrl + BuildQueryParameter(key, value);
            
            return newUrl;
        }

        private static string SanitizeUrl(string url)
        {
            if (UrlContainsQueryParameters(url))
            {
                return url + "&";
            }

            return url + "?";
        }

        private static string BuildQueryParameter(string key, string value)
        {
            var queryParameter = string.Format("{0}={1}", key, value);
            return queryParameter;
        }

        private static bool UrlContainsQueryParameters(string url)
        {
            try
            {
                var newUrl = new Uri(url);
                if (!string.IsNullOrEmpty(newUrl.Query))
                {
                    return true;
                }
                return false;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
