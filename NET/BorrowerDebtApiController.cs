using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using MoneFi.Models.Domain.BorrowerDebt;
using MoneFi.Models.Requests.BorrowerDebt;
using MoneFi.Services;
using MoneFi.Services.Interfaces;
using MoneFi.Web.Controllers;
using MoneFi.Web.Models.Responses;
using System;
using System.Data.SqlClient;

namespace MoneFi.Web.Api.Controllers
{
    [Route("api/borrowerdebts")]
    [ApiController]
    public class BorrowerDebtApiController : BaseApiController
    {
        private IBorrowerDebtService _service = null;
        private IAuthenticationService<int> _authService = null;
        public BorrowerDebtApiController(IBorrowerDebtService service
            , ILogger<BorrowerDebtApiController> logger
            , IAuthenticationService<int> authService) : base(logger)
        {
            _service = service;
            _authService = authService;
        }

        [HttpPost]
        public ActionResult<ItemResponse<int>> Create(BorrowerDebtAddRequest model)
        {
            ObjectResult result = null;
            try
            {
                int userId = _authService.GetCurrentUserId();
                int id = _service.Add(model, userId);
                ItemResponse<int> response = new ItemResponse<int>() { Item = id };
                result = Created201(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                ErrorResponse response = new ErrorResponse(ex.Message);
                result = StatusCode(500, response);
            }
            return result;
        }

        [HttpPut("{id:int}")]
        public ActionResult<SuccessResponse> Update(BorrowerDebtUpdateRequest model)
        {
            int code = 200;
            BaseResponse response = null;
            try
            {
                int userId = _authService.GetCurrentUserId();
                _service.Update(model, userId);
                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
            }
            return StatusCode(code, response);
        }


        [HttpGet("{CreatedBy:int}")]
        public ActionResult<ItemResponse<BorrowerDebt>> Get(int createdBy)
        {
            int iCode = 200;
            BaseResponse response = null;
            try
            {
                BorrowerDebt borrowerDebt = _service.GetByCreatedBy(createdBy);
                if (borrowerDebt == null)
                {
                    iCode = 404;
                    response = new ErrorResponse("Application Resource not found");
                }
                else
                {
                    response = new ItemResponse<BorrowerDebt> { Item = borrowerDebt };
                }
            }
            catch (SqlException sqlEx)
            {
                iCode = 500;
                response = new ErrorResponse($"SqlExeption Error: {sqlEx.Message}");
            }
            return StatusCode(iCode, response);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<SuccessResponse> Delete(int id)
        {
            int code = 200;
            BaseResponse response = null;
            try
            {
                _service.Delete(id);
                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse($"SqlExeption Error: {ex.Message}");
                base.Logger.LogError(ex.ToString());
            }
            return StatusCode(code, response);
        }


        [HttpGet("totaldebt/{createdBy:int}")]
        public ActionResult<ItemResponse<double>> TotalDebt(int createdBy)
        {
            int iCode = 200;
            BaseResponse response = null;
            try
            {
               double borrowerDebt = _service.TotalDebt(createdBy);
                if (borrowerDebt == 0)
                {
                    iCode = 404;
                    response = new ErrorResponse("Application Resource not found");
                }
                else
                {
                    response = new ItemResponse<double> { Item = borrowerDebt };
                }
            }
            catch (SqlException sqlEx)
            {
                iCode = 500;
                response = new ErrorResponse($"SqlExeption Error: {sqlEx.Message}");
            }
            return StatusCode(iCode, response);
        }





    }
}
