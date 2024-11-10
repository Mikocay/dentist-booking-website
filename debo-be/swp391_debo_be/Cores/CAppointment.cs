using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using swp391_debo_be.Dao.Implement;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Repository.Implement;
using swp391_debo_be.Repository.Interface;
using System.Collections.Generic;

namespace swp391_debo_be.Cores
{
    public class CAppointment
    {
        protected static IAppointmentRepository appointmentRepository = new AppointmentRepository();
        private static readonly AppointmentRepository _appointmentRepo;

        static CAppointment()
        {
            var context = new DeboDev02Context(new DbContextOptions<DeboDev02Context>());
            _appointmentRepo = new AppointmentRepository(new AppointmentDao(context));
        }

        public static List<object> GetAppointmentsByStartDateAndEndDate(DateOnly startDate,DateOnly end ,Guid Id)
        {
            try
            {
                return appointmentRepository.GetAppointmentsByStartDateAndEndDate(startDate, end ,Id);
            } catch 
            {
                throw;
            }
        }

        public static object GetAppointmentByPagination(string page, string limit, Guid userId)
        {
            try
            {
                return appointmentRepository.GetAppointmentByPagination(page, limit, userId);
            } catch
            {
                throw;
            }
        }
        
        public static int[][] GetApppointmentsByDentistIdAndDate(Guid dentistId, DateOnly date, int treatmentId)
        {
            try
            {
                return appointmentRepository.GetApppointmentsByDentistIdAndDate(dentistId, date, treatmentId);
            } catch
            {
                throw;
            }
        }

        public static List<Appointment> CreateAppointment(AppointmentDto dto, Guid cusId)
        {
            try
            {
                return appointmentRepository.CreateAppointment(dto, cusId);
            } catch
            {
                throw;
            }
        }

        public static Appointment CancelAppointment(Guid appointmentId)
        {
            try
            {
                return appointmentRepository.CancelAppointment(appointmentId);
            }
            catch
            {
                throw;
            }
        }
        public static Task<List<AppointmentHistoryDto>> GetHistoryAppointmentByUserID(Guid id)
        {
                return _appointmentRepo.GetHistoryAppointmentByUserID(id);
        }

        public static Task<List<AppointmentHistoryDto>> ViewAllAppointment(int page, int limit)
        {
            return _appointmentRepo.ViewAllAppointment(page, limit);
        }

        public static List<object> GetAppointmentsByStartDateAndEndDateOfDentist(DateOnly startDate, DateOnly endDate, Guid Id)
        {
            try
            {
                return appointmentRepository.GetAppointmentsByStartDateAndEndDateOfDentist(startDate, endDate, Id);
            }
            catch
            {
                throw;
            }
        }

        public static Task<List<AppointmentHistoryDto>> GetAppointmentByDentistId(int page, int limit, Guid dentistId)
        {
            return _appointmentRepo.GetAppointmentByDentistId(page, limit, dentistId);
        }

        public static Task<List<AppointmentDetailsDto>> GetAppointmentetail(Guid id, int page, int limit)
        {
            return _appointmentRepo.GetAppointmentetail(id, page, limit);
        }

        public static Task<AppointmentDetailsDto> ViewAppointmentDetail(Guid id)
        {
            return _appointmentRepo.ViewAppointmentDetail(id);
        }
    }
}
