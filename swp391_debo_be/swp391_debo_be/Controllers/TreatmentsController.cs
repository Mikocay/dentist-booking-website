using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using swp391_debo_be.Constants;
using swp391_debo_be.Cores;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Repository.Interface;
using swp391_debo_be.Services.Implements;
using swp391_debo_be.Services.Interfaces;
using System.Net;
using System.Runtime.CompilerServices;

namespace swp391_debo_be.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/treatments")]
    [ApiController]
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentService _treatService;

        public TreatmentsController(ITreatmentService treatService)
        {
            _treatService = treatService;
        }

        [HttpGet]
        //[Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetAllTreatment([FromQuery] int page = 0, [FromQuery] int limit = 5)
        {
            var response = await _treatService.getAllTreatmentAsync(page, limit);
            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTreatmentByID(int id)
        {
            var response = await _treatService.getTreatmentAsync(id);
            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTreatment(TreatmentDto model)
        {
            var response = await _treatService.addTreatmentAsync(model);
            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreatment(int id)
        {
            var response = await _treatService.deleteTreatmentAsync(id);
            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTreatment(int id, [FromBody] TreatmentDto model)
        {
            var response = await _treatService.updateTreatmentAsync(id, model);
            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };

        }

        [HttpGet("branch/{branchId}")]
        public ActionResult<ApiRespone> GetTreatmentBasedBranchId(int branchId)
        {
            var response = _treatService.GetTreatmentsBasedBranchId(branchId);
            return response;
        }
    }
}
