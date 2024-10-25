using Microsoft.EntityFrameworkCore;
using swp391_debo_be.Dao.Implement;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Repository.Implement;
using swp391_debo_be.Repository.Interface;

namespace swp391_debo_be.Cores
{
    public class CTreatment
    {
        protected static readonly TreatmentRepository _treatmentRepo;

        static CTreatment()
        {
            var context = new DeboDev02Context(new DbContextOptions<DeboDev02Context>());
            _treatmentRepo = new TreatmentRepository(new TreatmentDao(context));
        }

        public static Task<int> addTreatmentAsync(TreatmentDto treatment)
        {
            return _treatmentRepo.addTreatmentAsync(treatment);
        }


        public static Task deleteTreatmentAsync(int id)
        {
            return _treatmentRepo.deleteTreatmentAsync(id);
        }

        public static Task activeTreatmentAsync(int id)
        {
            return _treatmentRepo.activeTreatmentAsync(id);
        }

        public static Task<List<TreatmentDto>> getAllTreatmentAsync(int page, int limit)
        {
            return _treatmentRepo.getAllTreatmentAsync(page, limit);
        }

        public static Task<TreatmentDto> getTreatmentAsync(int id)
        {
            return _treatmentRepo.getTreatmentAsync(id);
        }

        public static Task updateTreatmentAsync(int id, TreatmentDto treatment)
        {
            return _treatmentRepo.updateTreatmentAsync(id, treatment);
        }

        public static List<object> GetTreatmentsBasedBranchId(int branchId)
        {
            return _treatmentRepo.GetClinicTreatmentsBasedBranchId(branchId);
        }
    }
}
