using System.Collections;
using System.Collections.Generic;

namespace Data.Entities
{
    public sealed class Card
    {
        public int Id { get; set; }
        public List<Doctor> Doctor;
        public List<string> DateTime;
        public List<string> Diagnosis;
        public List<string> Therapy;

        public int recordsCount { get; private set; }
    }
}