using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.ExportFile
{
    public class ExportFileFactory : IExportFileFactory
    {
        private readonly IEnumerable<IExportFile> _exportFiles;

        public ExportFileFactory(IEnumerable<IExportFile> exportFiles)
        {
            _exportFiles = exportFiles;
        }

        public IExportFile GetInstance(string token) 
        {
            return token switch
            {
                "SMP" => this.GetService(typeof(ExportSMP)),
                "Infrastructure" => this.GetService(typeof(ExportCompetenceInfrastructure)),
                _ => throw new InvalidOperationException()
            };
        }

        private IExportFile GetService(Type type) 
        {
            return _exportFiles.Where(a => a.GetType() == type).FirstOrDefault()!;
        }
    }
}
