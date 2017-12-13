using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface IPatientRegistry : IRegistry<PatientDTO>
    {
        IEnumerable<PatientDTO> Find(string name, string surname);
        void AddRecord(RecordDTO recordDTO);
        IEnumerable<RecordDTO> GetRecords(PatientDTO patient);
    }
}
