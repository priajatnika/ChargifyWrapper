using Chargify.Wrapper.API;
using System;
using static Chargify.Wrapper.Configuration;

namespace Chargify.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var svc = new ChargifyService(SiteDomainType.Development);

            var getProducts = svc.GetProducts();
            Console.WriteLine("GetProducts()");
            if (!getProducts.IsError)
            {
                foreach (var p in getProducts.Model)
                {
                    Console.WriteLine("-------------");
                    Console.WriteLine($"ProductID           : { p.ProductId }");
                    Console.WriteLine($"ProductName         : { p.Name }");
                    Console.WriteLine($"ProductFamilyName         : { p.ProductFamily.Name }");
                    Console.WriteLine("-------------");
                }
            }
            else
            {
                Console.WriteLine(getProducts.Message);
            }
            
            Console.ReadLine();
            Console.Clear();

            var getProduct = svc.GetProduct("heo");
            Console.WriteLine("GetProducts()");
            if (!getProduct.IsError)
            {

                Console.WriteLine("-------------");
                Console.WriteLine($"ProductID           : { getProduct.Model.ProductId }");
                Console.WriteLine($"ProductName         : { getProduct.Model.Name }");
                Console.WriteLine($"ProductFamilyName         : { getProduct.Model.ProductFamily.Name }");
                Console.WriteLine("-------------");
            }
            else
            {
                Console.WriteLine(getProduct.Message);
            }

            Console.ReadLine();
        }

    }
}
