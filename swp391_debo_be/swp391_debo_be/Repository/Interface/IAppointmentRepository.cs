using Microsoft.AspNetCore.Mvc;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;

namespace swp391_debo_be.Repository.Interface
{
    public interface IAppointmentRepository
    {
        public List<Appointment> CreateAppointment(AppointmentDto appointment, Guid cusId);
        public object GetAppointmentByPagination(string page, string limit, Guid userId);
        public List<object> GetAppointmentsByStartDateAndEndDate(DateOnly startDate,DateOnly endDate ,Guid id);
        public int[][] GetApppointmentsByDentistIdAndDate(Guid dentistId, DateOnly date, int treatmentId);
        public Appointment CancelAppointment(Guid appointmentId);
        public Task<List<AppointmentHistoryDto>> GetHistoryAppointmentByUserID(Guid id);
        public Task<List<AppointmentHistoryDto>> ViewAllAppointment(int page, int limit);
        public List<object> GetAppointmentsByStartDateAndEndDateOfDentist(DateOnly startDate, DateOnly endDate, Guid id);
        public Task<List<AppointmentHistoryDto>> GetAppointmentByDentistId(int page, int limit, Guid dentistId);
        public Task<List<AppointmentDetailsDto>> GetAppointmentetail(Guid id, int page, int limit);
        public Task<AppointmentDetailsDto> ViewAppointmentDetail(Guid id);
    }
}
