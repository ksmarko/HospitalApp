using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Logic
{
    public abstract class PatientRegistry
    {
        List<Patient> patInfoCards = new List<Patient>();

        public void AddPatient(string name, string surname)
        {
            patInfoCards.Add(new Patient(name, surname));
        }

        public void RemovePatient(Patient patient)
        {
            patInfoCards.Remove(patInfoCards.Find(x => x == patient));
        }


    }
}
