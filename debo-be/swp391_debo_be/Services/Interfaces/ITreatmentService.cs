using Microsoft.AspNetCore.Mvc;
using swp391_debo_be.Constants;
using swp391_debo_be.Dto.Implement;

namespace swp391_debo_be.Services.Interfaces
{
    public interface ITreatmentService
    {
        public Task<ApiRespone> getAllTreatmentAsync(int page, int limit);
        public Task<ApiRespone> getTreatmentAsync(int id);
        public Task<ApiRespone> addTreatmentAsync(TreatmentDto treatment);
        public Task<ApiRespone> updateTreatmentAsync(int id, TreatmentDto treatment);
        public Task<ApiRespone> deleteTreatmentAsync(int id);
        public Task<ApiRespone> activeTreatmentAsync(int id);
        public ActionResult<ApiRespone> GetTreatmentsBasedBranchId(int branchId);
    }
}
