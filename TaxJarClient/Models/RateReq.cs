using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxJarClient.Models
{
    public class RateReq
    {
        [Required]
        public string postalcode { get; set; }
#nullable enable
        public string? country { get; set; }
#nullable enable
        public string? city { get; set; }

    }
}
