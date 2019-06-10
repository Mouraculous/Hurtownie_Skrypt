using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurtownie_ETL_Support
{
    class Incident
    {
        public int IncidentId { get; set; }
        public DateTime Date { get; set; }
        public string State { get; set; }
        public string CityOrCounty { get; set; }
        public int NumberKilled { get; set; }
        public int NumberInjured { get; set; }
        public string GunStolen { get; set; }
        public string GunType { get; set; }
        public string IncidentCharacteristics { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int NumberGunsInvolved { get; set; }
        public string ParticipantAge { get; set; }
        public string ParticipantAgeGroup { get; set; }
        public string ParticipantGender { get; set; }
        public string ParticipantName { get; set; }
        public string ParticipantStatus { get; set; }
        public string ParticipantType { get; set; }
    }
}
