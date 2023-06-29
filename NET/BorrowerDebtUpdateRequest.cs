using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFi.Models.Requests.BorrowerDebt
{
    public class BorrowerDebtUpdateRequest : BorrowerDebtAddRequest, IModelIdentifier
    {
        
        public int Id { get; set; }
    }
}
