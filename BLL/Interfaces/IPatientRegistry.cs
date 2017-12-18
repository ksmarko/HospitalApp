using System.Collections.Generic;

using BLL.DTO;

namespace BLL.Interfaces
{
    interface IPatientRegistry : IRegistry<PatientDTO>
    {
        IEnumerable<PatientDTO> Find(string name, string surname);
        void AddRecord(RecordDTO recordDTO);
        IEnumerable<RecordDTO> GetRecords(PatientDTO patient);
    }
}
