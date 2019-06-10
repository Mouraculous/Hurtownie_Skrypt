using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurtownie_ETL_Support
{
    class Participant
    {
        public int ParticipantId { get; set; }
        public int IncidentId { get; set; }
        public string ParticipantType { get; set; }
        public string ParticipantStatus { get; set; }
        public string ParticipantGender { get; set; }
        public string ParticipantAge { get; set; }

    }
}
