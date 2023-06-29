using MoneFi.Data;
using MoneFi.Data.Extensions;
using MoneFi.Data.Providers;
using MoneFi.Models.Domain.BorrowerDebt;
using MoneFi.Models.Domain.Users;
using MoneFi.Models.Requests.BorrowerDebt;
using MoneFi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoneFi.Services
{
    public class BorrowerDebtService : IBorrowerDebtService
    {
        IDataProvider _data = null;

        public BorrowerDebtService(IDataProvider data) 
        {
            _data = data;
        }


        public int Add(BorrowerDebtAddRequest model, int userId)
        {
            int id = 0;

            string procName = "[dbo].[BorrowerDebt_Insert]";
            _data.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection col)
            {
                SqlParameter idOut = new SqlParameter("@Id", SqlDbType.Int);
                idOut.Direction = ParameterDirection.Output;

                col.Add(idOut);
                AddCommonParams(model, col);
                col.AddWithValue("@CreatedBy", userId);
                col.AddWithValue("@ModifiedBy", userId);
            },
            returnParameters: delegate (SqlParameterCollection returnCol)
            {
                object old = returnCol["@Id"].Value;

                int.TryParse(old.ToString(), out id);
            });
            return id;
        }

        public void Update(BorrowerDebtUpdateRequest model, int userId)
        {
            string procName = "[dbo].[BorrowerDebt_Update]";
            _data.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection col)
            {
                AddCommonParams(model, col);
                col.AddWithValue("@Id", model.Id);
                col.AddWithValue("@CreatedBy", userId);
                col.AddWithValue("@ModifiedBy", userId);
            },
            returnParameters: null);
        }

        public BorrowerDebt GetByCreatedBy(int createdBy)
        {
            string procName = "[dbo].[BorrowerDebt_Select_ByCreatedBy]";

            BorrowerDebt borrowerDebt = null;

            _data.ExecuteCmd(procName, delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@CreatedBy", createdBy);

            }, delegate (IDataReader reader, short set)
            {
                borrowerDebt = MapSingleBorrowerDebt(reader);
            });
            return borrowerDebt;
        }


        public double TotalDebt(int createdBy)
        {
            double totaldebt = 0;

            string procName = "[dbo].[BorrowerDebt_TotalDebt]";
            _data.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection col)
            {
                SqlParameter totalDebtOut = new SqlParameter("@TotalDebt", SqlDbType.Int);
                totalDebtOut.Direction = ParameterDirection.Output;

                col.Add(totalDebtOut);
                col.AddWithValue("@CreatedBy", createdBy);
            },
            returnParameters: delegate (SqlParameterCollection returnCol)
            {
                object oTotalDebt = returnCol["@TotalDebt"].Value;

                double.TryParse(oTotalDebt.ToString(), out totaldebt);
            });
            return totaldebt;
        }


        public void Delete (int id)
        {
            string procName = "[dbo].[BorrowerDebt_DeleteById]";
            _data.ExecuteNonQuery(procName, inputParamMapper: delegate (SqlParameterCollection col)
            {
                col.AddWithValue("@Id", id);
            },
            returnParameters: null);
        }



        private static BorrowerDebt MapSingleBorrowerDebt(IDataReader reader)
        {
            BorrowerDebt aBorrowerDebt = new BorrowerDebt();

            int startingIndex = 0;

            aBorrowerDebt.Id = reader.GetInt32(startingIndex++);
            aBorrowerDebt.HomeMortgage = reader.GetSafeDecimal(startingIndex++);
            aBorrowerDebt.CarPayments = reader.GetSafeDecimal(startingIndex++);
            aBorrowerDebt.CreditCard = reader.GetSafeDecimal(startingIndex++);
            aBorrowerDebt.OtherLoans = reader.GetSafeDecimal(startingIndex++);
            aBorrowerDebt.DateCreated = reader.GetSafeDateTime(startingIndex++);
            aBorrowerDebt.DateModified = reader.GetSafeDateTime(startingIndex++);
            aBorrowerDebt.CreatedBy = reader.GetSafeInt32(startingIndex++);
            aBorrowerDebt.ModifiedBy = reader.GetSafeInt32(startingIndex++);
     
           

            return aBorrowerDebt;
        }

        private static void AddCommonParams(BorrowerDebtAddRequest model, SqlParameterCollection col)
        {
            col.AddWithValue("@HomeMortgage", model.HomeMortgage);
            col.AddWithValue("@CarPayments", model.CarPayments);
            col.AddWithValue("@CreditCard", model.CreditCard);
            col.AddWithValue("@OtherLoans", model.OtherLoans);
             
        }

    }
}
