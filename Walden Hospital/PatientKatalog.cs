using System.Collections.Generic;

namespace Walden_Hospital
{
    public class PatientKatalog
    {
        private Dictionary<long, Patient> _PatientKatalog;
        private static PatientKatalog _instance = null;
        
        public PatientKatalog()
        {
            _PatientKatalog = new Dictionary<long, Patient>();
        }

        public static PatientKatalog Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = new PatientKatalog();
                return _instance;
            }
        }

        public Dictionary<long, Patient> GetKatalog
        {
            get => _PatientKatalog;
        }
        public void OpretPatient(Patient newpatient)
        {
            
            Instance._PatientKatalog.Add(newpatient.Cpr, newpatient);
        }

        public void DeletePatient(Patient patient)
        {
            Instance._PatientKatalog.Remove(patient.Cpr);
        }


    }
}