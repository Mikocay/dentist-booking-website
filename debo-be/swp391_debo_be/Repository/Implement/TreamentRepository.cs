using swp391_debo_be.Dao.Implement;
using swp391_debo_be.Dao.Interface;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Repository.Interface;

namespace swp391_debo_be.Repository.Implement
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly ITreatmentDao _treatmentDao;

        public TreatmentRepository(ITreatmentDao treatmentDao)
        {
            _treatmentDao = treatmentDao;
        }
        public Task<int> addTreatmentAsync(TreatmentDto treatment)
        {
            return _treatmentDao.addTreatmentAsync(treatment);
        }

        public Task deleteTreatmentAsync(int id)
        {
            return _treatmentDao.deleteTreatmentAsync(id);
        }

        public Task activeTreatmentAsync(int id)
        {
            return _treatmentDao.activeTreatmentAsync(id);
        }

        public Task<List<TreatmentDto>> getAllTreatmentAsync(int page, int limit)
        {
            return _treatmentDao.getAllTreatmentAsync(page, limit);
        }

        public List<object> GetClinicTreatmentsBasedBranchId(int branchId)
        {
            return _treatmentDao.GetTreatmentsBasedOnBranchId(branchId);
        }

        public Task<TreatmentDto> getTreatmentAsync(int id)
        {
            return _treatmentDao.getTreatmentAsync(id);
        }

        public Task updateTreatmentAsync(int id, TreatmentDto treatment)
        {
            return _treatmentDao.updateTreatmentAsync(id, treatment);
        }
    }
}
