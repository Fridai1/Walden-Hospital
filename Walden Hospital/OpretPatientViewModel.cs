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
        private string _Dækning = null;
        private string _Provider = null;
        
       
        #endregion

        #region Constructor

        public OpretPatientViewModel()
        {
            // instancere katalogerne.
            _IdCarKatalog = new IDCardKatalog();
            _relativeKatalog = new RelativeKatalog();
            _PatientKatalog = new PatientKatalog();
            _CheckInsurance = new Insurance();

            
            
            
            _PatientList = new ObservableCollection<Patient>();
            _CreateCommand = new RelayCommand(opretPatientButton, () => true);
            _deteCommand = new RelayCommand(DeletePatientButton,() => true);
            _CheckInsuranceCommand = new RelayCommand(CheckInsuranceButton, () => true);

            _PatientList.Add(new Patient("Hans Larsen", "Skolevej 1", 12091982, 123231, 1, "mand", new Relative(0, "", ""), new IDCard(333, "19 12 1911")));
            _PatientList.Add(new Patient("Grete Petersen", "Algade 54", 09022012, 11, 2, "Kvinde",new Relative(12312,"Jørgen", "Far"), new IDCard(111, "19 12 2012") ));
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
            get => _Provider;
        }

        public string InsuranceDækning
        {
            get => _Dækning;
        }

        #endregion

        #region List Properties

        public Patient SelectedItem
        {
            get => _SelectedPatient;
            set
            {
                _SelectedPatient = value;
                _Dækning = null;
                _Provider = null;
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
                OnPropertyChanged(nameof(InsuranceDækning));
                OnPropertyChanged(nameof(InsuranceProvider));
            }
        }

        #endregion

        #region Buttons

        public void opretPatientButton()
        {
           
            string str = _DOB.ToString();
            string last4 = str.Substring(4, 4);
            int last4Int = int.Parse(last4);

           
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
         //Knap for insurance
        public void CheckInsuranceButton()
        {
            _Provider = _CheckInsurance.InsuranceCheck(_SelectedPatient.Cpr);
            _Dækning = _CheckInsurance.InsuranceDækning(_SelectedPatient.Cpr);
            OnPropertyChanged(nameof(InsuranceDækning));
            OnPropertyChanged(nameof(InsuranceProvider));
            
        }
        // Delete knap - Virker ikke -
        public void DeletePatientButton()
        {
            _PatientKatalog.DeletePatient(_SelectedPatient);
            OnPropertyChanged(nameof(PatientList));
        }

        // Opret Patient Command
        public ICommand OpretPatientCommand
        {
            get => _CreateCommand;
        }
        // command for delete - virker ikke -
        public ICommand DeletePatientCommand
        {
            get => _deteCommand;
        }
        // command for check insurance
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