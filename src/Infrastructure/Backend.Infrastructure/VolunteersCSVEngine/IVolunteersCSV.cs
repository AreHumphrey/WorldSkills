using Backend.Domain.Entities.WorkEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.VolunteersCSVEngine
{
    public interface IVolunteersCSV
    {
        public Task<List<Volunteers>> ReadCSVAsync(string filePath);
    }
}
