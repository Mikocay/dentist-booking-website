using Microsoft.AspNetCore.Mvc;
using swp391_debo_be.Constants;
using swp391_debo_be.Cores;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Repository.Implement;
using swp391_debo_be.Services.Interfaces;
using System.Collections.Generic;
using System.Net;

namespace swp391_debo_be.Services.Implements
{
    public class TreatmentService : ITreatmentService
    {
        public async Task<ApiRespone> addTreatmentAsync(TreatmentDto treatment)
        {
            var response = new ApiRespone();
            try
            {
                // -1 mean get all treatment 
                var existingTreatments = await CTreatment.getAllTreatmentAsync(1, -1);

                // Check if the treatment ID already exists
                if (existingTreatments.Any(t => t.Id == treatment.Id))
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = "ID cannot be duplicated";
                    return response;
                }
                var newTreat = await CTreatment.addTreatmentAsync(treatment);
                var treat = await CTreatment.getTreatmentAsync(newTreat);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = treat;
                response.Success = true;
                response.Message = "Treatment data is added successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> deleteTreatmentAsync(int id)
        {
            var response = new ApiRespone();
            try
            {
                var existingTreatments = await CTreatment.getTreatmentAsync(id);
                if (existingTreatments != null)
                {
                    await CTreatment.deleteTreatmentAsync(id);
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = existingTreatments;
                    response.Success = true;
                    response.Message = "Treatment data is deleted successfully.";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "Treatment not found.";
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> activeTreatmentAsync(int id)
        {
            var response = new ApiRespone();
            try
            {
                var existingTreatments = await CTreatment.getTreatmentAsync(id);
                if (existingTreatments != null)
                {
                    await CTreatment.activeTreatmentAsync(id);
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = existingTreatments;
                    response.Success = true;
                    response.Message = "Treatment data is activated successfully.";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "Treatment not found.";
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> getAllTreatmentAsync(int page, int limit)
        {
            var response = new ApiRespone();
            try
            {
                var data = await CTreatment.getAllTreatmentAsync(page, limit);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = new { list = data, total = data.Count };
                response.Success = true;
                response.Message = "Treatment data retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> getTreatmentAsync(int id)
        {
            var response = new ApiRespone();
            try
            {
                var existingTreatments = await CTreatment.getTreatmentAsync(id);
                if (existingTreatments != null)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = existingTreatments;
                    response.Success = true;
                    response.Message = "Treatment data retrieved successfully.";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "Treatment not found.";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ActionResult<ApiRespone> GetTreatmentsBasedBranchId(int branchId)
        {
            try
            {
                var data = CTreatment.GetTreatmentsBasedBranchId(branchId);

                if (data == null)
                {
                    return new ApiRespone { StatusCode = HttpStatusCode.NotFound, Data = null, Success = false, Message = "This branch does not have any treatments" };
                }

                return new ApiRespone { StatusCode = HttpStatusCode.OK, Data = data, Success = true, Message = "Fetched treatments within constraints successfully" };

            }
            catch (Exception ex)
            {
                return new ApiRespone { StatusCode = HttpStatusCode.BadRequest, Message = ex.Message, Success = false };
            }
        }

        public async Task<ApiRespone> updateTreatmentAsync(int id, TreatmentDto treatment)
        {
            var response = new ApiRespone();
            try
            {
                if (id != treatment.Id)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "Treatment ID mismatch";
                    return response;
                }
                var data = await CTreatment.getTreatmentAsync(id);
                if (data == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "Treatment not found or inactive.";
                    return response;
                }
                await CTreatment.updateTreatmentAsync(id, treatment);
                var updTreat = await CTreatment.getTreatmentAsync(id);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = updTreat;
                response.Success = true;
                response.Message = "Treatment data updated successfully.";

            }
            catch (InvalidOperationException ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

    }
}
