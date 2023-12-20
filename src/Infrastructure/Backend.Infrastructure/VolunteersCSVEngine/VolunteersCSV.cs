using Backend.Domain.Entities.WorkEntities;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Backend.Infrastructure.VolunteersCSVEngine
{
    public class VolunteersCSV : IVolunteersCSV
    {
        public async Task<List<Volunteers>> ReadCSVAsync(string filePath) 
        {
            List<Volunteers> data = new List<Volunteers>();

            using (var reader = new StreamReader(filePath)) 
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                };

                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<VolunteerMap>();

                    await foreach (var record in csv.GetRecordsAsync<Volunteers>())
                    {
                        record.Regions = null;
                        data.Add(record);
                    }
                }
            }

            return data;
        }
    }
}
