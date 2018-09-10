using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaris.Entities
{

    public class Policy
    {
        public string id { get; set; }
        public decimal amountInsured { get; set; }
        public string email { get; set; }
        public DateTime inceptionDate { get; set; }
        public bool installmentPayment { get; set; }
        public string clientId { get; set; }

    }

    public class Policies
    {
        public List<Policy> policies { get; set; }
    }


}