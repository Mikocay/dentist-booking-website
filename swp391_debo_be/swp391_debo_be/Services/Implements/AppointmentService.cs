using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using swp391_debo_be.Constants;
using swp391_debo_be.Cores;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Services.Interfaces;
using System.Net;

namespace swp391_debo_be.Services.Implements
{
    public class AppointmentService : IAppointmentService
    {
        public ApiRespone CancelAppointment(string id)
        {
            try
            {
                if (Guid.TryParse(id, out Guid Id))
                {
                    var result = CAppointment.CancelAppointment(Id);

                    return result != null ? new ApiRespone { StatusCode = System.Net.HttpStatusCode.OK, Data = result, Message = "Deleted Appointment successfully", Success = true }
                    : new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = "Failed to cancel appointment", Success = false };
                }
                else
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = "Invalid appointment id", Success = false };
                }
            }
            catch (System.Exception ex)
            {
                return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = ex.Message, Success = false };
            }
        }

        public ApiRespone CreateAppointment(AppointmentDto dto, string userId, string role)
        {
            try
            {
                if (role != "Customer")
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.Unauthorized, Data = null, Message = "You are not allowed to create appointment", Success = false };
                }

                if (Guid.TryParse(userId, out var id)  && DateOnly.TryParse(dto.Date, out DateOnly startDate))
                {
        
                    var result = CAppointment.CreateAppointment(dto, id);

                    return result != null ? new ApiRespone { StatusCode = System.Net.HttpStatusCode.Created, Data = result, Message = "Created appointment successfully", Success = true }
                    : new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = "Failed to create appointment", Success = false };
                }
                else
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = "Invalid user id", Success = false };
                }
            }
            catch (System.Exception ex)
            {
                return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = ex.Message, Success = false };
            }
        }

        public async Task<ApiRespone> GetAppointmentByDentistId(int page, int limit, Guid dentistId)
        {
            var response = new ApiRespone();
            try
            {
                var data = await CAppointment.GetAppointmentByDentistId(page, limit, dentistId);
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.Data = new { list = data, total = data.Count };
                response.Success = true;
                response.Message = "Fetched appointment list successfully";
                return response;
            }
            catch (System.Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        //public ActionResult<ApiRespone> CreateAppointment(AppointmentDto dto, object result)
        //{
        //    //return //AppointmentDto.CreateAppointment(dto, result);
        //}

        public ApiRespone GetAppointmentByPagination(string page, string limit, string userId)
        {
            try
            {
                if (Guid.TryParse(userId, out Guid Id))
                {
                    var result = CAppointment.GetAppointmentByPagination(page, limit, Id);

                    if (result == null)
                    {
                        return new ApiRespone { StatusCode = System.Net.HttpStatusCode.NotFound, Data = null, Message = "No appointment found", Success = false };
                    }

                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.OK, Data = result, Message = "Fetched appointment list successfully", Success = true };
                }
                else
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = "Invalid user id", Success = false };
                }

            }
            catch (Exception ex)
            {
                return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = ex.Message, Success = false };
            }
        }

        public async Task<ApiRespone> GetAppointmentetail(Guid id, int page, int limit)
        {
            var response = new ApiRespone();
            try
            {
                var data = await CAppointment.GetAppointmentetail(id, page, limit);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = new { list = data, total = data.Count };
                response.Success = true;
                response.Message = "Appointment data retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ApiRespone GetAppointmentsByStartDateAndEndDate(string startDate, string endDate, string userId)
        {
            try
            {
                if (DateOnly.TryParse(startDate, out DateOnly start) && DateOnly.TryParse(endDate, out DateOnly end) && Guid.TryParse(userId, out Guid Id))
                {

                    ActionResult<List<object>> appointments = CAppointment.GetAppointmentsByStartDateAndEndDate(start, end, Id);


                    if (appointments.Value.Count == 0)
                    {
                        return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = "No appointment found", Success = false };
                    }

                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.OK, Data = appointments, Message = "Get appointments successfully", Success = true };
                }
                else
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = "Invalid date format", Success = false };
                }
            }
            catch (Exception ex)
            {
                return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = ex.Message, Success = false };
            }
        }

        public ApiRespone GetAppointmentsByStartDateAndEndDateOfDentist(string startDate, string endDate, string userId)
        {
            try
            {
                if (DateOnly.TryParse(startDate, out DateOnly start) && DateOnly.TryParse(endDate, out DateOnly end) && Guid.TryParse(userId, out Guid Id))
                {

                    ActionResult<List<object>> appointments = CAppointment.GetAppointmentsByStartDateAndEndDateOfDentist(start, end, Id);


                    if (appointments.Value.Count == 0)
                    {
                        return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = "No appointment found", Success = false };
                    }

                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.OK, Data = appointments, Message = "Get appointments successfully", Success = true };
                }
                else
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = "Invalid date format", Success = false };
                }
            }
            catch (Exception ex)
            {
                return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = ex.Message, Success = false };
            }
        }

        public ApiRespone GetApppointmentsByDentistIdAndDate(string dentistId, string date, string treatmentId)
        {
            try
            {
                if (Guid.TryParse(dentistId, out Guid dentist) && DateOnly.TryParse(date, out DateOnly dateOnly) && int.TryParse(treatmentId, out int treatId))
                {
                    var result = CAppointment.GetApppointmentsByDentistIdAndDate(dentist, dateOnly,treatId);

                    if (result == null)
                    {
                        return new ApiRespone { StatusCode = System.Net.HttpStatusCode.NotFound, Data = null, Message = "No slots found", Success = false };
                    }

                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.OK, Data = result, Message = "Fetched slots successfully.", Success = true };
                }
                else
                {
                    return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = "Invalid dentist id or date", Success = false };
                }

            }
            catch (Exception ex)
            {
                return new ApiRespone { StatusCode = System.Net.HttpStatusCode.BadRequest, Data = null, Message = ex.Message, Success = false };
            }
        }
        public async Task<ApiRespone> GetHistoryAppointmentByUserID(Guid userId)
        {
            var response = new ApiRespone();
            try
            {
                var data = await CAppointment.GetHistoryAppointmentByUserID(userId);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = data;
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

        public async Task<ApiRespone> ViewAllAppointment(int page, int limit)
        {
            var response = new ApiRespone();
            try
            {
                var data = await CAppointment.ViewAllAppointment(page, limit);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = new { list = data, total = data.Count };
                response.Success = true;
                response.Message = "Appointment data retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> ViewAppointmentDetail(Guid id)
        {
            var response = new ApiRespone();
            try
            {
                var data = await CAppointment.ViewAppointmentDetail(id);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = data;
                response.Success = true;
                response.Message = "Appointment data retrieved successfully.";
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
