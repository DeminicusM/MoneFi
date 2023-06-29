using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFi.Models.Domain.BorrowerDebt
{
    public class BorrowerDebt
    {

        public int Id { get; set; }

        public decimal HomeMortgage { get; set; }

        public decimal CarPayments { get; set; }

        public decimal CreditCard { get; set;}

        public decimal OtherLoans { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set;}
    }
}
