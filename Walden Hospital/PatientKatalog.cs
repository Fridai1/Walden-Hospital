using System.Collections.Generic;

namespace Walden_Hospital
{
    public class PatientKatalog
    {
        private Dictionary<long, Patient> _PatientKatalog;
        
        public PatientKatalog()
        {
            _PatientKatalog = new Dictionary<long, Patient>();
        }

        

        public Dictionary<long, Patient> GetKatalog
        {
            get => _PatientKatalog;
        }
        public void OpretPatient(Patient newpatient)
        {
            
            _PatientKatalog.Add(newpatient.Cpr, newpatient);
        }

        public void DeletePatient(Patient patient)
        {
            _PatientKatalog.Remove(patient.Cpr);
        }


    }
}