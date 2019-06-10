using CsvHelper;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hurtownie_ETL_Support
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = File.OpenRead(@"C:\Users\Daniel\Desktop\Polibuda\Sem6\Hurtownie\projekt\crimeDataClean.csv");
            var text = new StreamReader(read);
            var reader = new CsvReader(text);
            var incidents = reader.GetRecords<Incident>().ToList();
            var i = 0;
            var guns = incidents
                .Select(s => new
                {
                    s.IncidentId,
                    GunTypes = s.GunType.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries),
                    GunStolen = s.GunStolen.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries)
                })
                .Where(w => w.GunStolen.Length != 0)
                .SelectMany(sm => sm.GunTypes
                    .Select(s => new Gun
                    {
                        GunId = i++,
                        IncidentId = sm.IncidentId,
                        GunType = s.Split(':').Last(),
                        GunStolen = sm.GunStolen[sm.GunTypes.IndexOf(s)].Split(':').Last()

                    })).ToList();

            i = 0;
            var participants = incidents
                .Select(s => new
                {
                    s.IncidentId,
                    ParticipantType =
                        s.ParticipantType.Split(new string[] {"||"}, StringSplitOptions.RemoveEmptyEntries),
                    ParticipantStatus =
                        s.ParticipantStatus.Split(new string[] {"||"}, StringSplitOptions.RemoveEmptyEntries),
                    ParticipantGender =
                        s.ParticipantGender.Split(new string[] {"||"}, StringSplitOptions.RemoveEmptyEntries),
                    ParticipantAge = s.ParticipantAge.Split(new string[] {"||"}, StringSplitOptions.RemoveEmptyEntries)
                })
                .Where(w => w.ParticipantType.Length != 0)
                .SelectMany(sm => sm.ParticipantType
                    .Select(s => new Participant
                    {
                        ParticipantId = i++,
                        IncidentId = sm.IncidentId,
                        ParticipantType = s.Split(':').Last(),
                        ParticipantGender = sm.ParticipantGender.Length > sm.ParticipantType.IndexOf(s) ? sm.ParticipantGender[sm.ParticipantType.IndexOf(s)].Split(':').Last() : string.Empty,
                        ParticipantStatus = sm.ParticipantStatus.Length > sm.ParticipantType.IndexOf(s) ? sm.ParticipantStatus[sm.ParticipantType.IndexOf(s)].Split(':').Last() : string.Empty,
                        ParticipantAge = sm.ParticipantAge.Length > sm.ParticipantType.IndexOf(s) ? sm.ParticipantAge[sm.ParticipantType.IndexOf(s)].Split(':').Last() : string.Empty

                    })).ToList();

            var gunsFileStream = File.OpenWrite(@"C:\Users\Daniel\Desktop\Polibuda\Sem6\Hurtownie\projekt\guns.csv");
            var participantsFileStream = File.OpenWrite(@"C:\Users\Daniel\Desktop\Polibuda\Sem6\Hurtownie\projekt\participants.csv");
            var gunsWriter = new CsvWriter(new StreamWriter(gunsFileStream));
            var participantsWriter = new CsvWriter(new StreamWriter(participantsFileStream));

            Task.Run(() => gunsWriter.WriteRecords(guns));
            Task.Run(() => participantsWriter.WriteRecords(participants));

            Console.WriteLine("Finished");
            Console.Read();
        }
    }
}
