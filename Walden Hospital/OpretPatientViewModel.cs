using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Walden_Hospital.Annotations;

namespace Walden_Hospital
{
    public class OpretPatientViewModel : INotifyPropertyChanged
    {
        #region InstanceFields
        
        // instance fields til katalogerne
        private IDCardKatalog _IdCarKatalog;
        private PatientKatalog _PatientKatalog;
        private RelativeKatalog _relativeKatalog;
        private Patient _SelectedPatient;
        private string _Name;
        private string _Adresse;
        private int _TLF;
        private long _DOB;
        private long _CPR;
        private string _RName;
        private int _RTlf;
        private string _RRelation;
        private long _IDNR;
        private string _Validity;
        private string _Køn;
        private ObservableCollection<Patient> _PatientList;
        private RelayCommand _CreateCommand;
        private RelayCommand _deteCommand;
        private RelayCommand _CheckInsuranceCommand;
        private Insurance _CheckInsurance;
       
        #endregion

        #region Constructor

        public OpretPatientViewModel()
        {
            // instancere katalogerne.
            _IdCarKatalog = new IDCardKatalog();
            _relativeKatalog = new RelativeKatalog();
            _PatientKatalog = new PatientKatalog();
            _CheckInsurance = new Insurance(_CPR)
            
            ;
            _PatientList = new ObservableCollection<Patient>();
            _CreateCommand = new RelayCommand(opretPatientButton, () => true);
            _deteCommand = new RelayCommand(DeletePatientButton,() => true);
            _CheckInsuranceCommand = new RelayCommand(CheckInsuranceButton, () => true);

            _PatientList.Add(new Patient("hans", "skole", 12091982, 123231, 1, "mand", new Relative(23223, "hans", "slapper"), new IDCard(333, "19 12 1911")));
            _PatientList.Add(new Patient("name", "vej", 09022012, 11, 2, "Kvinde",new Relative(12312,"aaa", "gift"), new IDCard(111, "19 12 2012") ));
            _PatientKatalog.OpretPatient(new Patient("lars","adressevej", 19071032,2323232,666, "Mand",new Relative(123,"far","far"),new IDCard(876,"11 02 1988") ));
            _SelectedPatient = _PatientList[0];

            //_IDCardObj = IDCardObj;
            //_RelativeObj = RelativeObj;


        }
        #endregion

        #region Patient Properties

        

        
        public string PatientNavn
        {
            get => _SelectedPatient.Name;
            set => _Name = value;
        }

        public int PatientTlf
        {
            get => _SelectedPatient.Tlf;
            set => _TLF = value;
        }

        public string PatientAdresse
        {
            get => _SelectedPatient.Adresse;
            set => _Adresse = value;
        }

        public long PatientCPR
        {
            get => _SelectedPatient.Cpr;
            set => _CPR = value;
        }

        public long PatientDateOfBirth
        {
            get => _SelectedPatient.DateOfBirth;
            set => _DOB = value;
        }

        public string PatientKøn
        {
            get => _SelectedPatient.køn;
            set => _Køn = value;
        }
        #endregion

        #region IDCard Properties

        

        
        public long IDCardNumber
        {
            get => _SelectedPatient.IDCard.CardID;
            set => _IDNR = value;
        }

        public string IDCardValidity
        {
            get => _SelectedPatient.IDCard.Validity;
            set => _Validity = value;
        }
        #endregion

        #region Relative Properties

        public string RelativeName
        {
            get =>_SelectedPatient.Relative.Navn;
            set => _RName = value;
        }

        public int RelativeTlf
        {
            get => _SelectedPatient.Relative.Tlf;
            set => _RTlf = value;
        }

        public string RelativeForhold
        {
            get => _SelectedPatient.Relative.Forhold;
            set => _RRelation = value;
        }
        #endregion

        #region Insurance Properties

        public string InsuranceProvider
        {
            get => _CheckInsurance.InsuranceCheck;
        }

        public string InsuranceDækning
        {
            get => _CheckInsurance.InsuranceDækning;
        }

        #endregion

        #region List Properties

        public Patient SelectedItem
        {
            get => _SelectedPatient;
            set
            {
                _SelectedPatient = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PatientNavn));
                OnPropertyChanged(nameof(PatientAdresse));
                OnPropertyChanged(nameof(PatientCPR));
                OnPropertyChanged(nameof(IDCardNumber));
                OnPropertyChanged(nameof(IDCardValidity));
                OnPropertyChanged(nameof(RelativeForhold));
                OnPropertyChanged(nameof(RelativeName));
                OnPropertyChanged(nameof(RelativeTlf));
                OnPropertyChanged(nameof(PatientDateOfBirth));
                OnPropertyChanged(nameof(PatientKøn));
            }
        }

        #endregion

        #region Buttons

        public void opretPatientButton()
        {
            // Her tjekker vi om patienten er over 18. _DOB er en int, som kunne se sådanne ud: 12122000
            // det er et tal som er svært at tjekke om patienten er 18 eller ej, så vi converter det til en string
            // og tager de 4 sidste tegn og laver dem tilbage til en int - nu har vi istedet for 12122000 - 2000
            // som er et tal vi kan arbejde med.
            string str = _DOB.ToString();
            string last4 = str.Substring(4, 4);
            int last4Int = int.Parse(last4);

            // inde i patient er der 2 constructere en for hvis man er over 18 og en hvis man er under. her hvis patienten er under 18 bruger vi den tilsvarende.
            if (2017 - last4Int < 18)
            {
                _IdCarKatalog.OpretIDCard(new IDCard(_IDNR, _Validity));
                _relativeKatalog.OpretRelative(_CPR,new Relative(_RTlf,_RName,_RRelation));
                _PatientKatalog.OpretPatient(new Patient(_Name, _Adresse, _DOB, _TLF, _CPR, _Køn, new Relative(_TLF, _RName, _RRelation), new IDCard(_IDNR, _Validity)));
                OnPropertyChanged(nameof(PatientList));
            }
            else
            {
                _PatientKatalog.OpretPatient(new Patient(_Name, _Adresse, _DOB, _TLF, _CPR, _Køn, new IDCard(_IDNR, _Validity)));
                _IdCarKatalog.OpretIDCard(new IDCard(_IDNR, _Validity));
                OnPropertyChanged(nameof(PatientList));
            }

            
            
        }

        public void CheckInsuranceButton()
        {
            Insurance check = new Insurance(_CPR);
            OnPropertyChanged(nameof(InsuranceDækning));
            OnPropertyChanged(nameof(InsuranceProvider));
            
        }

        public void DeletePatientButton()
        {
            _PatientKatalog.DeletePatient(_SelectedPatient);
            OnPropertyChanged(nameof(PatientList));
        }

        public ICommand OpretPatientCommand
        {
            get => _CreateCommand;
        }

        public ICommand DeletePatientCommand
        {
            get => _deteCommand;
        }

        public ICommand CheckInsuranceCommand
        {
            get => _CheckInsuranceCommand;
        }
        #endregion

        #region Observable list

        public ObservableCollection<Patient> PatientList
        {
            get
            {
                
                foreach (KeyValuePair<long, Patient> patient in _PatientKatalog.GetKatalog)
                {
                    if (!_PatientList.Contains(patient.Value))
                    {
                        _PatientList.Add(patient.Value);
                    }
                   
                }
                return _PatientList;
            }
        }




        #endregion

        #region Interface stuff
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion

    }
}