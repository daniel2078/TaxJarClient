﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxJarClient.Models
{
    public class OrderTaxReq
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        //public string from_city { get; set; }
        //public string from_street { get; set; }
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        //public string to_city { get; set; }
        //public string to_street { get; set; }
        public decimal amount { get; set; }
        public decimal shipping { get; set; }
       // public string customer_id { get; set; }
        public List<LineItemReq> line_items { get; set; }
    }
    public class LineItemReq
    {
        public int quantity { get; set; }
        public decimal unit_price { get; set; }
        public string product_tax_code { get; set; }
    }
}
