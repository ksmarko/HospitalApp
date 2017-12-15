using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services;

namespace BLL.Utilits
{
    public class ModelCreator
    {
        public static DoctorDTO CreteDoctor(string name, string surname, string specialization)
        {
            DoctorDTO doctor = new DoctorDTO
            {
                Name = name,
                Surname = surname,
                Specialization = specialization
            };

            return doctor;
        }

        public static PatientDTO CreatePatient(string name, string surname)
        {
            PatientDTO patient = new PatientDTO
            {
                Name = name,
                Surname = surname,
            };

            return patient;
        }

        public static RecordDTO CreateRecord(PatientDTO patient, DoctorDTO doctor, string diagnosis, string therapy, string addition)
        {
            RecordDTO record = new RecordDTO
            {
                Date = DateTime.Now.ToShortDateString(),
                PatientId = patient.Id,
                DoctorId = doctor.Id,
                Diagnosis = diagnosis,
                Therapy = therapy,
                Addition = addition
            };

            return record;
        }

        public static ScheduleDTO CreateSchedule(int doctorId, DateTime date, string time)
        {
            ScheduleDTO schedule = new ScheduleDTO
            {
                DoctorId = doctorId,
                Date = date,
                Time = time
            };

            return schedule;
        }
    }
}
