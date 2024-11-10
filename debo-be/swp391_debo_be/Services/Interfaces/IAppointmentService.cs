using Microsoft.AspNetCore.Mvc;
using swp391_debo_be.Constants;
using swp391_debo_be.Dto.Implement;

namespace swp391_debo_be.Services.Interfaces
{
    public interface IAppointmentService
    {
        public ApiRespone CancelAppointment(string id);
        public ApiRespone CreateAppointment(AppointmentDto dto, string userId, string role);
        public ApiRespone GetAppointmentByPagination(string page, string limit, string userId);
        public ApiRespone GetAppointmentsByStartDateAndEndDate(string startDate,string endDate ,string userId);
        public ApiRespone GetApppointmentsByDentistIdAndDate(string dentistId, string date, string treatmentId);
        public Task<ApiRespone> GetHistoryAppointmentByUserID(Guid userId);
        public Task<ApiRespone> ViewAllAppointment(int page, int limit);
        public ApiRespone GetAppointmentsByStartDateAndEndDateOfDentist(string startDate, string endDate, string userId);
        public Task<ApiRespone> GetAppointmentByDentistId(int page, int limit, Guid dentistId);
        public Task<ApiRespone> GetAppointmentetail(Guid id, int page, int limit);
        public Task<ApiRespone> ViewAppointmentDetail(Guid id);
    }
}
