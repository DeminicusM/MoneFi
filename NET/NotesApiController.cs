using Google.Apis.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.Extensions.Logging;
using MoneFi.Models.Domain.Notes;
using MoneFi.Models.Requests.Notes;
using MoneFi.Services;
using MoneFi.Services.Interfaces;
using MoneFi.Web.Controllers;
using MoneFi.Web.Models.Responses;
using sib_api_v3_sdk.Api;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MoneFi.Web.Api.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesApiController : BaseApiController
    {
        private INotesService _service = null;
        private IAuthenticationService<int> _authService = null;

        public NotesApiController(INotesService service
            , ILogger<NotesApiController> logger
            , IAuthenticationService<int> authService) : base(logger)
        {
            _service = service;
            _authService = authService;
        }

        [HttpPost]
        public ActionResult<ItemResponse<int>> Create(NotesAddRequest model)
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
        public ActionResult<SuccessResponse> Update(NotesUpdateRequest model)
        {
            int code = 200;
            BaseResponse response = null;
            try
            {
                int userId = _authService.GetCurrentUserId();
                _service.Update(model);
                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
            }
            return StatusCode(code, response);
        }

        [HttpGet("{lectureId:int}/current")]
        public ActionResult<ItemsResponse<Note>> Get(int lectureId)
        {
            int iCode = 200;
            BaseResponse response = null;
            try
            {
                int userId = _authService.GetCurrentUserId();
                List<Note> notes = _service.GetByLectureIdByCreatedBy(lectureId, userId);
                if (notes == null)
                {
                    iCode = 404;
                    response = new ErrorResponse($"Lecture Id {lectureId} not found for user {userId}");
                }
                else
                {
                    response = new ItemsResponse<Note> { Items = notes };
                }
            }
            catch (SqlException sqlEx)
            {
                iCode = 500;
                response = new ErrorResponse($"SqlException Error: {sqlEx.Message}");
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
            catch (SqlException sqlEx)
            {
                code = 500;
                response = new ErrorResponse($"SqlException Error: {sqlEx.Message}");
                base.Logger.LogError(sqlEx.ToString());            
            }
            return StatusCode(code, response);
        }

    }
}
