using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;

namespace swp391_debo_be.Repository.Interface
{
    public interface ITreatmentRepository
    {
        public Task<List<TreatmentDto>> getAllTreatmentAsync(int page, int limit);
        public Task<TreatmentDto> getTreatmentAsync(int id);
        public Task<int> addTreatmentAsync(TreatmentDto treatment);
        public Task updateTreatmentAsync(int id, TreatmentDto treatment);
        public Task deleteTreatmentAsync(int id);

        public List<object> GetClinicTreatmentsBasedBranchId(int branchId);
    }
}
