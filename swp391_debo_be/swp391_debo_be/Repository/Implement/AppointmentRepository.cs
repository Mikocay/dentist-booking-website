using Microsoft.AspNetCore.Mvc;
using swp391_debo_be.Dao.Implement;
using swp391_debo_be.Dao.Interface;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Repository.Interface;

namespace swp391_debo_be.Repository.Implement
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IAppointmentDao appointmentDao = new AppointmentDao();
        private readonly IAppointmentDao _appointmentDao;

        public AppointmentRepository()
        {
        }

        public AppointmentRepository(IAppointmentDao appointmentDao)
        {
            _appointmentDao = appointmentDao;
        }

        public List<Appointment> CreateAppointment(AppointmentDto appointment, Guid cusId)
        {
            return appointmentDao.CreateAppointment(appointment, cusId);
        }

        public object GetAppointmentByPagination(string page, string limit, Guid userId)
        {
            return appointmentDao.GetAppointmentByPagination(page, limit, userId);
        }

        public List<object> GetAppointmentsByStartDateAndEndDate(DateOnly startDate, DateOnly endDate, Guid Id)
        {
           return appointmentDao.GetAppointmentsByStartDateAndEndDate(startDate, endDate ,Id);
        }

        public int[][] GetApppointmentsByDentistIdAndDate(Guid dentistId, DateOnly date, int treatmentId)
        {
            return appointmentDao.GetApppointmentsByDentistIdAndDate(dentistId, date, treatmentId);
        }

        public Appointment CancelAppointment(Guid appointmentId)
        {
            return appointmentDao.CancelAppointment(appointmentId);
        }
        public Task<List<AppointmentHistoryDto>> GetHistoryAppointmentByUserID(Guid id)
        {
            return _appointmentDao.GetHistoryAppointmentByUserID (id);
        }

        public Task<List<AppointmentHistoryDto>> ViewAllAppointment(int page, int limit)
        {
            return _appointmentDao.ViewAllAppointment(page, limit);
        }

        public List<object> GetAppointmentsByStartDateAndEndDateOfDentist(DateOnly startDate, DateOnly endDate, Guid id)
        {
            return appointmentDao.GetAppointmentsByStartDateAndEndDateOfDentist (startDate, endDate, id);
        }

        public Task<List<AppointmentHistoryDto>> GetAppointmentByDentistId(int page, int limit, Guid dentistId)
        {
            return _appointmentDao.GetAppointmentByDentistId (page, limit, dentistId);
        }

        public Task<List<AppointmentDetailsDto>> GetAppointmentetail(Guid id, int page, int limit)
        {
            return _appointmentDao.GetAppointmentetail (id, page, limit);
        }

        public Task<AppointmentDetailsDto> ViewAppointmentDetail(Guid id)
        {
            return _appointmentDao.ViewAppointmentDetail (id);
        }
    }
}
