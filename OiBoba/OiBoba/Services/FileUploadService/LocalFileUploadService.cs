
namespace OiBoba.Services.FileUploadService
{
    public class LocalFileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _environment;
        public LocalFileUploadService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var guidFileName = Guid.NewGuid() + file.FileName;
            var filePath = Path.Combine(_environment.ContentRootPath, @"wwwroot\files", guidFileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return guidFileName;
        }
    }
}
