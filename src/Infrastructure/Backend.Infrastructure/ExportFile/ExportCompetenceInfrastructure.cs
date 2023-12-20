using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.ExportFile
{
    public class ExportCompetenceInfrastructure : IExportFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ExportCompetenceInfrastructure(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Stream> Download(string competenceCode, string championshipName)
        {
            string fileName = "Infrastructure " + competenceCode + " " + championshipName + ".xlsx";
            string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Infrastructure", fileName);

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
