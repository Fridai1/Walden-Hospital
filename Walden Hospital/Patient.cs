﻿using Windows.UI.Xaml.Controls;

namespace Walden_Hospital
{
    public class Patient
    {
        private string _Name;
        private string _Adresse;
        private long _DateOfBirth;
        private int _Tlf;
        private long _CPR;
        private Relative _Relative;
        private IDCard _IdCard;
        private string _Køn;
        public Patient(string name, string adresse, long dateOfBirth, int tlf, long cpr, string køn, Relative Relative, IDCard Idcard)
        {
            _Name = name;
            _Adresse = adresse;
            _DateOfBirth = dateOfBirth;
            _Tlf = tlf;
            _CPR = cpr;
            _Relative = Relative;
            _IdCard = Idcard;
            _Køn = køn;
        }

        public Patient(string name, string adresse, long dateOfBirth, int tlf, long cpr, string køn, IDCard idcard)
        {
            _Name = name;
            _Adresse = adresse;
            _DateOfBirth = dateOfBirth;
            _Tlf = tlf;
            _CPR = cpr;
            _IdCard = idcard;
            _Køn = køn;
        }

        public string Name
        {
            get => _Name;
            set => _Name = value;
        }

        public string Adresse
        {
            get => _Adresse;
            set => _Adresse = value;
        }

        public long DateOfBirth
        {
            get => _DateOfBirth;
            set => _DateOfBirth = value;
        }

        public int Tlf
        {
            get => _Tlf;
            set => _Tlf = value;
        }

        public long Cpr
        {
            get => _CPR;
            set => _CPR = value;
        }

        public Relative Relative
        {
            get => _Relative;
            set => _Relative = value;
        }

        public IDCard IDCard
        {
            get => _IdCard;
            set => _IdCard = value;
        }

        public string køn
        {
            get => _Køn;
            set => _Køn = value;
        }

       
    }
}