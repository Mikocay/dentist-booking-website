using swp391_debo_be.Constants;
using swp391_debo_be.Cores;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Services.Interfaces;
using System.Net;

namespace swp391_debo_be.Services.Implements
{
    public class BranchService : IBranchService
    {
        private readonly CBranch _cBranch;

        public BranchService(CBranch cBranch)
        {
            _cBranch = cBranch;
        }

        public async Task<ApiRespone> activeBranchAsync(int id)
        {
            var response = new ApiRespone();
            try
            {
                var existingBranchs = await CBranch.getBranchAsync(id);
                if (existingBranchs != null)
                {
                    await CBranch.activeBranchAsync(id);
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = existingBranchs;
                    response.Success = true;
                    response.Message = "Branch data is activated successfully.";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "Branch not found.";
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

        public async Task<ApiRespone> addBranchAsync(BranchDto branch)
        {
            var response = new ApiRespone();
            try
            {
                var existingBranch = await CBranch.getAllBranchAsync(1, -1);
                if (existingBranch.Any(t => t.Id == branch.Id))
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = "ID cannot be duplicated";
                    return response;
                }
                var newBranch = await CBranch.addBranchAsync(branch);
                var branchs = await CBranch.getBranchAsync(newBranch);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = branchs;
                response.Success = true;
                response.Message = "Branch data is added successfully";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> deleteBranchAsync(int id)
        {
            var response = new ApiRespone();
            try
            {
                var existingBranch = await CBranch.getBranchAsync(id);
                if (existingBranch != null)
                {
                    await CBranch.deleteBranchAsync(id);
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = existingBranch;
                    response.Success = true;
                    response.Message = "Branch data is deleted successfully";
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "Branch not found";
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

        public async Task<ApiRespone> getAllBranchAsync(int page, int limit)
        {
            var response = new ApiRespone();
            try
            {
                var data = await CBranch.getAllBranchAsync(page, limit);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = new { list = data, total = data.Count };
                response.Success = true;
                response.Message = "Branch data is retrieved successfully";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> getBranchAsync(int id)
        {
            var response = new ApiRespone();
            try
            {
                var data = await CBranch.getBranchAsync(id);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = data;
                response.Success = true;
                response.Message = "Branch data retrieved successfully";
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ApiRespone> updateBranchAsync(int id, BranchDto branch)
        {
            var response = new ApiRespone();
            try
            {
                if (id != branch.Id)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "Branch ID mismatch";
                    return response;
                }
                var data = await CBranch.getBranchAsync(id);
                if (data == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "Branch not found or inactive.";
                    return response;
                }
                await CBranch.updateBranchAsync(id, branch);
                var updBranch = await CBranch.getBranchAsync(id);
                response.StatusCode = HttpStatusCode.OK;
                response.Data = updBranch;
                response.Success = true;
                response.Message = "Branch data updated successfully.";

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
