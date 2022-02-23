using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using TaxJarClient.Models;
using RestSharp;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace TaxJarClient.Services
{
    public class TaxService : ITaxService
    {
        private readonly IConfiguration _configuration;

        public TaxService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<RateRes> GetRateAsync(RateReq rate)
        {
            string reqUri = _configuration["EndpointSettings:TaxJarRateEndPoint"] + rate.postalcode;

            if (!string.IsNullOrWhiteSpace(rate.country))
            {
                reqUri = reqUri + "?country=" + rate.country;
            }
            if (!string.IsNullOrWhiteSpace(rate.city))
            {
                reqUri = reqUri + "&city=" + rate.city;
            }

            RateRes taxRate = new RateRes();
            RestClient client = new RestClient();

            var req = CreateRequest(reqUri, Method.Get);

            try
            {
                RestResponse res = await client.ExecuteAsync(req);

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    taxRate = JsonConvert.DeserializeObject<RateRes>(res.Content);
                }

                return taxRate;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                client.Dispose();
            }
        }

        public async Task<OrderTaxRes> GetOrderTaxAsync(OrderTaxReq order)
        {
            string reqUri = _configuration["EndpointSettings:TaxJarOrderTaxEndPoint"];
            var body = JsonConvert.SerializeObject(order);

            OrderTaxRes orderTaxRes = new OrderTaxRes();
            RestClient client = new RestClient();

            var req = CreateRequest(reqUri, Method.Post);
            //req.AddParameter("application/json", body, ParameterType.RequestBody);
            req.AddBody(body.ToString(), "application/json");
            try
            {
                RestResponse res = await client.ExecuteAsync(req);
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    orderTaxRes = JsonConvert.DeserializeObject<OrderTaxRes>(res.Content);
                }
                return orderTaxRes;
            }
            catch
            {
                return null;
            }
            finally
            {
                client.Dispose();
            }
        }



        private RestRequest CreateRequest(string endPoint, Method method)
        {
            var req = new RestRequest(endPoint, method);
            req.RequestFormat = DataFormat.Json;
            req.AddHeader("Content-Type", "application/json");
            req.AddHeader("Accept", "application/json");
            req.AddHeader("Authorization", "Bearer " + _configuration["EndpointSettings:TaxJarToken"]);
            return req;
        }


    }
}
