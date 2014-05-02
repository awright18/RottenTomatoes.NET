using System.Collections.Generic;

namespace RottenTomatoes
{
    internal abstract class RottenTomatoesQuery<T>
    {
        private string url;

        internal string Url
        {
            get
            {
                var urlWithParameters = url;

                foreach (var param in QueryParameters)
                {
                    urlWithParameters = urlWithParameters.AppendQueryParameter(param.Key, param.Value);
                }

                return urlWithParameters;
            }

            set
            {
                if (this.url == null)
                {
                    url = value;
                }
            }
        }

        internal Dictionary<string, string> QueryParameters;

        internal RottenTomatoesQuery()
        {
            QueryParameters = new Dictionary<string, string>();
        }

        internal void AddStringParameter(string parameterName, string parameterValue)
        {
            AddParameter(parameterName, parameterValue);
        }

        internal void AddIntParameter(string parameterName, int? parameterValue)
        {
            AddParameter(parameterName, parameterValue);
        }

        internal void AddParameter(string parameterName, object parameterValue)
        {
            if (parameterName == null || parameterValue == null)
            {
                return;
            }

            if (QueryParameters.ContainsKey(parameterName))
            {
                return;
            }

            QueryParameters.Add(parameterName, parameterValue.ToString());
        }

    }
}
