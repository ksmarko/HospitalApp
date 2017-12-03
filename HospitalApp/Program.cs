using System;
using Logic;

namespace HospitalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //DoctorRegistry.ResetDB();

            DoctorRegistry.AddDoctor("csc", "32sc", "22sc");

            string []data = new string[3] { "nqqme", "surn", "spec" };

            DoctorRegistry.EditDoctorData(2, data);

            foreach (var el in DoctorRegistry.GetDoctorList())
                Console.WriteLine(el);

            Console.ReadKey();

        }
    }
}
