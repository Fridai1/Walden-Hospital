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
        private int _DOB;
        private long _CPR;
        private string _RName;
        private int _RTlf;
        private string _RRelation;
        private long _IDNR;
        private bool _Validity;
        private ObservableCollection<Patient> _PatientList;
        private RelayCommand CreateCommand;
        #endregion

        #region Constructor

        public OpretPatientViewModel()
        {
            // instancere katalogerne.
            _IdCarKatalog = new IDCardKatalog();
            _relativeKatalog = new RelativeKatalog();
            _PatientKatalog = new PatientKatalog();
            _PatientList = new ObservableCollection<Patient>();
            CreateCommand = new RelayCommand(opretPatientButton, () => true);

            _PatientList.Add(new Patient("hans", "skole", 13, 123231, 23232, new Relative(23223, "hans", "slapper"), new IDCard(333, true)));
            _PatientList.Add(new Patient("name", "vej", 13, 11, 1231123,new Relative(12312,"aaa", "gift"), new IDCard(111, true) ));
            _SelectedPatient = _PatientList[0];

            //_IDCardObj = IDCardObj;
            //_RelativeObj = RelativeObj;


        }
        #endregion

        #region Patient Properties

        

        
        public string PatientNavn
        {
            get {
                if (_SelectedPatient == null)
                {
                    return "";
                }
                return _SelectedPatient.Name;
                
            }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(PatientList));
            }

        }

        public int PatientTlf
        {
            get => _SelectedPatient.Tlf;
            set
            {
                _TLF = value; 
                OnPropertyChanged();
            }
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

        public int PatientDateOfBirth
        {
            get => _SelectedPatient.DateOfBirth;
            set => _DOB = value;
        }
        #endregion

        #region IDCard Properties

        

        
        public long IDCardNumber
        {
            get => _SelectedPatient.IDCard.CardID;
            set => _IDNR = value;
        }

        public bool IDCardValidity
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
            }
        }

        #endregion

        #region Buttons

        public void opretPatientButton()
        {
            _PatientKatalog.OpretPatient(new Patient(_Name,_Adresse, _DOB, _TLF, _CPR,new Relative(_TLF,_RName,_RRelation), new IDCard(_IDNR,_Validity) ));
        }

        public ICommand OpretPatientCommand
        {
            get => CreateCommand;
        }

        #endregion

        #region Observable list

        public ObservableCollection<Patient> PatientList
        {
            get {
                foreach (KeyValuePair<long, Patient> patient in _PatientKatalog.GetKatalog)
                {
                    _PatientList.Add(patient.Value);
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