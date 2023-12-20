using Microsoft.AspNetCore.Hosting;

namespace Backend.Infrastructure.ExportFile
{
    public class ExportSMP : IExportFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ExportSMP(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Stream> Download(string competenceCode, string championshipName) 
        {
            string fileName = "SMP " + competenceCode + " " + championshipName + ".pdf";
            string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "SMP", fileName);

            if (File.Exists(filePath))
            {
                var fileStream = new FileStream(filePath, FileMode.Open);
                var streamContent = new StreamContent(fileStream);
                var content = await streamContent.ReadAsStreamAsync();

                return content;
            }
            else 
            {
                return new MemoryStream();
            }

        }
    }
}
