using Backend.Domain.Entities.WorkEntities;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.VolunteersCSVEngine
{
    public class VolunteerMap : ClassMap<Volunteers>
    {
        public VolunteerMap() 
        {
            Map(m => m.Id).Name("Id").Index(0);
            Map(m => m.FirstName).Name("FirstName").Index(1);
            Map(m => m.LastName).Name("LastName").Index(2);
            Map(m => m.RegionsId).Name("RegionsId").Index(3);
            Map(m => m.Gender).Name("Gender").Index(4);
        }
    }
}
