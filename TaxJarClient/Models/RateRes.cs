using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace TaxJarClient.Models
{
    public class Rate
    {

        public string city { get; set; }
        public decimal city_rate { get; set; }
        public decimal combined_district_rate { get; set; }
        public decimal combined_rate { get; set; }
        public string country { get; set; }
        public decimal country_rate { get; set; }
        public string county { get; set; }
        public decimal county_rate { get; set; }
        public string state { get; set; }
        public decimal state_rate { get; set; }
        public string zip { get; set; }
        public bool freight_taxable { get; set; }
       // public RateMsg message {get;set;}

    }

    //public class RateMsg
    //{
    //    public HttpStatusCode http_status;
    //    public string message; 
    //}

    public class RateRes
    {
        public Rate rate { get; set; }
    }
}
