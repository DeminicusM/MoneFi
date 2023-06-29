using MoneFi.Models.Domain.BorrowerDebt;
using MoneFi.Models.Requests.BorrowerDebt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneFi.Services.Interfaces
{
    public interface IBorrowerDebtService
    {
        int Add(BorrowerDebtAddRequest model, int userId);

        void Update(BorrowerDebtUpdateRequest model, int userId);

        BorrowerDebt GetByCreatedBy(int createdBy);

        double TotalDebt(int createdBy);

        void Delete(int id);


    }
}
