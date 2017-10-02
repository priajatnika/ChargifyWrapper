using System;
using System.Collections.Generic;
using System.Text;
using Chargify.Wrapper.Model;
using Chargify.Wrapper.Request;
using Chargify.Wrapper.Response;
using static Chargify.Wrapper.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Chargify.Wrapper.Utility;
using System.Reflection;
using Newtonsoft.Json;

namespace Chargify.Wrapper.API
{
    public class ChargifyService : IChargifyService
    {
        private SiteDomainType _site;
        private int _productFamilyId;

        public ChargifyService(SiteDomainType site = SiteDomainType.Development)
        {
            _site = site;
            _productFamilyId = GetProductFamilyId(site);
        }

        private T RunRequest<T, Model>(string api, HttpMethodType method, HttpContent content = null) where T : IResponseBase<Model> where Model : class 
        {
            var result = Activator.CreateInstance<T>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.SetBasicAuthentication(GetSiteDomain(_site), GetAPIKey(_site));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var uri = new UriBuilder(new Uri(new Uri(GetEndpoint(_site)), api));

                    HttpResponseMessage httpResponse;
                    
                    switch(method)
                    {
                        case HttpMethodType.Get:
                            httpResponse = client.GetAsync(uri.Uri).Result;
                            break;
                        case HttpMethodType.Post:
                            if (content != null)
                            {
                                httpResponse = client.PostAsync(uri.Uri, content).Result;
                            }
                            else
                            {
                                //todo: create ChargifyException
                                throw new Exception("POST HTTP Content header is missing.");
                            }
                            break;
                        case HttpMethodType.Put:
                            if (content != null)
                            {
                                httpResponse = client.PutAsync(uri.Uri, content).Result;
                            }
                            else
                            {
                                //todo: create ChargifyException
                                throw new Exception("PUT HTTP Content header is missing.");
                            }
                            break;
                        case HttpMethodType.Delete:
                            httpResponse = client.DeleteAsync(uri.Uri).Result;
                            break;
                        default:
                            //todo: create ChargifyException
                            throw new Exception("Invalid Http method");
                    }

                    var response = HttpClientUtils.ParseResponse<Model>(httpResponse);
                    result.IsError = response.IsError;
                    result.Message = response.Message;
                    result.Model = response.Model;
                }
            }
            catch (Exception ex)
            {
                //todo: logger
                result.IsError = true;
                result.Message = ex.Message;
                throw;
            }
            return result;
        }

        public ProductsResponse GetProducts()
        {
            var api = @"product_families/" + _productFamilyId.ToString() + "/products.json";
            return RunRequest<ProductsResponse, List<Product>>(api, HttpMethodType.Get);
        }

        public ProductResponse GetProduct(string productHandle)
        {
            var api = @"products/handle/" + productHandle + ".json";
            return RunRequest<ProductResponse, Product>(api, HttpMethodType.Get);
        }

        public ComponentsResponse GetComponents()
        {
            var api = @"product_families/" + _productFamilyId.ToString() + "/components.json";
            return RunRequest<ComponentsResponse, List<Component>>(api, HttpMethodType.Get);
        }

        public ComponentResponse GetComponent(int componentId)
        {
            var api = @"product_families/" + _productFamilyId.ToString() + "/components/" + componentId.ToString() + ".json";
            return RunRequest<ComponentResponse, Component>(api, HttpMethodType.Get);
        }

        public PricePointsResponse GetPricePoints(int componentId)
        {
            var api = @"components/" + componentId.ToString() + "/price_points.json";
            return RunRequest<PricePointsResponse, List<PricePoint>>(api, HttpMethodType.Get);
        }

        public CustomerResponse CreateCustomer(Customer request)
        {
            var api = @"customers.json";
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            return RunRequest<CustomerResponse, Customer>(api, HttpMethodType.Post, content);
        }

        public CustomerResponse UpdateCustomer(Customer request)
        {
            var api = @"/customers/" + request.CustomerId.ToString() + ".json";
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            return RunRequest<CustomerResponse, Customer>(api, HttpMethodType.Put, content);
        }

        public CustomerResponse DeleteCustomer(int customerId)
        {
            var api = @"customers/" + customerId.ToString() + ".json";
            return RunRequest<CustomerResponse, Customer >(api, HttpMethodType.Delete);
        }

        public CustomerResponse GetCustomer(int customerId)
        {
            var api = @"customers/" + customerId.ToString() + ".json";
            return RunRequest<CustomerResponse, Customer>(api, HttpMethodType.Get);
        }

        public CustomersResponse GetCustomers()
        {
            var api = @"customers.json";
            return RunRequest<CustomersResponse, List<Customer>>(api, HttpMethodType.Get);
        }

        public PaymentProfileResponse CreatePaymentProfile(PaymentProfile profile)
        {
            var api = @"payment_profiles.json";
            var content = new StringContent(JsonConvert.SerializeObject(profile), Encoding.UTF8, "application/json");
            return RunRequest<PaymentProfileResponse, PaymentProfile>(api, HttpMethodType.Post, content);
        }
        
        public PaymentProfileResponse UpdatePaymentProfile(PaymentProfile profile)
        {
            var api = @"payment_profiles/" + profile.PaymentProfileId.ToString() + ".json";
            var content = new StringContent(JsonConvert.SerializeObject(profile), Encoding.UTF8, "application/json");
            return RunRequest<PaymentProfileResponse, PaymentProfile>(api, HttpMethodType.Post, content);
        }

        public PaymentProfileResponse GetPaymentProfile(int profileId)
        {
            var api = @"payment_profiles/" + profileId.ToString() + ".json";
            return RunRequest<PaymentProfileResponse, PaymentProfile>(api, HttpMethodType.Get);
        }

        public PaymentProfilesResponse GetPaymentProfiles(int customerId)
        {
            var api = @"payment_profiles.json?customer_id=" + customerId.ToString();
            return RunRequest<PaymentProfilesResponse, List<PaymentProfile>> (api, HttpMethodType.Get);
        }
    }
}
