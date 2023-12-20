using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.ExportFile
{
    public interface IExportFileFactory
    {
        public IExportFile GetInstance(string token);
    }
}
