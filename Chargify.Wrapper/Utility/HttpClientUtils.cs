using Chargify.Wrapper.Model;
using Chargify.Wrapper.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Chargify.Wrapper.Utility
{
    public static class HttpClientUtils
    {
        public static bool IsValidJson(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;

            var strInput = input.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || (strInput.StartsWith("[") && strInput.EndsWith("]")))
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static GeneralResponse<T> ParseResponse<T>(HttpResponseMessage response) where T : class
        {
            var result = new GeneralResponse<T>();
            if (response == null)
            {
                result.Message = "Unexpected null response from Chargify API";
                return result;
            }

            var responseBody = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                if (string.IsNullOrEmpty(responseBody))
                {
                    result.Message = "No response body.";
                    return result;
                }
                else
                {
                    if (!IsValidJson(responseBody))
                    {
                        result.IsError = true;
                        result.Message = $"Unexpected response format from Chargify API: {responseBody}";
                    }
                    else
                    {
                        result.Model = JsonConvert.DeserializeObject<T>(JsonRemoveHeadProperty(responseBody));
                    }
                }
            }
            else
            {
                result.IsError = true;
                result.Message = $"Error {response.StatusCode} {response.ReasonPhrase}";
                if (!string.IsNullOrEmpty(responseBody))
                {
                    result.Message += $": {responseBody}";
                }
            }
            return result;
        }

        private static string JsonRemoveHeadProperty(string json)
        {
            var result = json;

            var Values = JToken.Parse(json);
            if (Values.Type == JTokenType.Array)
            {
                var records = new StringBuilder();
                records.Append("[");
                foreach (var v in Values)
                {
                    records.Append(v.SelectToken("*").ToString() + ",");
                }
                records.Append("]");

                result = records.ToString();
            }
            else
            {
                result = Values.SelectToken("*").ToString();
            }

            return result;
        }

        
    }
}
