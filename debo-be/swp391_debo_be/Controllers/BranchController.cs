using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using swp391_debo_be.Dto.Implement;
using swp391_debo_be.Entity.Implement;
using swp391_debo_be.Services.Implements;
using swp391_debo_be.Services.Interfaces;

namespace swp391_debo_be.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/branch")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly BranchService _branchService;
        private readonly IAmazonS3 _s3Client;

        public BranchController(BranchService branchService, IAmazonS3 s3Client) 
        {
            _branchService = branchService;
            _s3Client = s3Client;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBranch([FromQuery] int page , [FromQuery] int limit )
        {
            var response = await _branchService.getAllBranchAsync(page, limit);
            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranchByID(int id)
        {
            var response = await _branchService.getBranchAsync(id);
            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddNewBranch(IFormFile? file, [FromForm] BranchDto model)
        {
            string bucketName = "swp391-bucket";

            // Check if bucket exists
            var bucketExists = await _s3Client.DoesS3BucketExistAsync(bucketName);
            if (!bucketExists) return NotFound($"Bucket {bucketName} does not exist.");
            if (file != null && file.Length > 0)
            {
                // Upload the file to S3
                var request = new PutObjectRequest()
                {
                    BucketName = bucketName,
                    Key = file.FileName,
                    InputStream = file.OpenReadStream(),
                    ContentType = file.ContentType
                };
                await _s3Client.PutObjectAsync(request);

                // Generate the URL for the uploaded file
                string fileUrl = $"https://{bucketName}.s3.amazonaws.com/{file.FileName}";

                // Set the avatar URL in the branch DTO
                model.Avt = fileUrl;
            }
            var response = await _branchService.addBranchAsync(model);
            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var response = await _branchService.deleteBranchAsync(id);
            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(int id, [FromBody] BranchDto model)
        {
            var response = await _branchService.updateBranchAsync(id, model);
            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };

        }
    }
}
