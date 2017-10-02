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

            //todo: handle when success with no response body
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
                        var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseBody);
                        if (errorResponse != null && errorResponse.Errors != null)
                        {
                            result.IsError = true;
                            foreach (var detail in errorResponse.Errors)
                            {
                                result.Message += $"{Environment.NewLine}- {detail}";
                            }
                        }
                        else
                        {
                            result.Model = (T)JsonConvert.DeserializeObject(responseBody, typeof(T));
                        }
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
    }
}
