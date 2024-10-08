using System.Linq.Expressions;
using appInfo.api.common.models;
using appInfo.API.BLL.Interfaces;
using DnsClient.Protocol;
using Microsoft.AspNetCore.Mvc;

namespace appInfo.api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationDetailController : ControllerBase
    {
        private readonly IApplicationDetailBAL ObjBal;
        public ApplicationDetailController(IApplicationDetailBAL objBal)
        {
            ObjBal = objBal;
        }

        [HttpPost, Route("saveApplicationDataset")]
        public async Task<IActionResult> SaveApplicationDataSet([FromBody] ApplicationInfoDataSetWithDto requestPayload)
        {
            try
            {
                if (requestPayload == null)
                {
                    return BadRequest("Invalid data");
                }
                var result = await ObjBal.AddApplicationDetails(new ApplicationInfoDataSetWithDto
                {
                    ApplicationName = requestPayload.ApplicationName,
                    RolesName = requestPayload.RolesName,
                    ApplicationSMEName = requestPayload.ApplicationSMEName,
                    ApplicationType = requestPayload.ApplicationType,
                    Databases = requestPayload.Databases,
                    TechStack = requestPayload.TechStack,
                    GitRepoistoryPath = requestPayload.GitRepoistoryPath,
                    ApplicationURL = requestPayload.ApplicationURL,
                    SharepointLink = requestPayload.SharepointLink,
                    ExcelLink = requestPayload.ExcelLink
                });
                return Ok(new HttpResponse<object>
                {
                    IsSuccess = true,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet, Route("GetAllApplicationDetails")]
        public async Task<IActionResult> GetAllApplicationDetails()
        {
            try
            {
                var resultVal = await ObjBal.GetAllApplicationDetails();
                return this.Ok(new HttpResponse<List<ApplicationInfoDataSetWithDto>>
                {
                    Result = resultVal.Result,
                    IsSuccess = true,
                });

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, new HttpResponse<List<ApplicationInfoDataSetDto>>
                {
                    Result = null,
                    IsSuccess = false,
                    Errors = ex.Message
                });
            }
        }
    }

}