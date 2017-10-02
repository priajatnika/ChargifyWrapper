using Chargify.Wrapper.Model;
using Chargify.Wrapper.Request;
using Chargify.Wrapper.Response;
using System;
using System.Collections.Generic;
using System.Text;
using static Chargify.Wrapper.Configuration;

namespace Chargify.Wrapper.API
{
    public interface IChargifyService
    {
        ProductsResponse GetProducts();

        ProductResponse GetProduct(string productHandle);

        ComponentsResponse GetComponents();

        ComponentResponse GetComponent(int componentId);

        PricePointsResponse GetPricePoints(int componentId);

        CustomerResponse CreateCustomer(Customer request);

        CustomerResponse UpdateCustomer(Customer request);

        CustomerResponse DeleteCustomer(int customerId);

        CustomerResponse GetCustomer(int customerId);

        CustomersResponse GetCustomers();

        PaymentProfileResponse CreatePaymentProfile(PaymentProfile profile);

        PaymentProfileResponse UpdatePaymentProfile(PaymentProfile profile);

        PaymentProfileResponse GetPaymentProfile(int profileId);

        PaymentProfilesResponse GetPaymentProfiles(int customerId);

        //SubscriptionResponse CreateSubscription(CreateSubscriptionRequest request);

        //SubscriptionResponse CancelSubscription(int subscriptionId);

        //SubscriptionResponse GetSubscription(int subscriptionId);



        //TODO:
        //UpdateSubscriptionDefaultPaymentProfile

        //GetSubscriptionLineItem / Components

        //CreateAllocation // multiple allocation API

        //PreviewAllocation (to preview changes before submit // might be useful)

        //GetStatements(subscriptionId)

        //GetInvoices(subscriptionId)

        //DownloadInvoice(invoiceId) (download a pdf)

        //GetInvoice(invoiceId)

        //GetReceipts(subscriptionId)

        //GetReceipt(receiptId)

        //GetTransactions (for audit purpose)

        //GetEvents (for audit purpose)

        //Webhook

    }
}
