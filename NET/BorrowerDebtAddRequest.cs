using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sabio.Models.Requests.BorrowerDebt
{
    public class BorrowerDebtAddRequest
    {
        [Required]
        [Range(.10, 9999999.99)]
        public decimal HomeMortgage { get; set; }

        [Required]
        [Range(.10, 9999999.99)]
        public decimal CarPayments { get; set; }

        [Required]
        [Range(.10, 9999999.99)]
        public decimal CreditCard { get; set; }

        [Required]
        [Range(.10, 9999999.99)]
        public decimal OtherLoans { get; set; }



    }
}
