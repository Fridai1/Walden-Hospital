namespace Walden_Hospital
{
    public class Insurance
    {
        private long _Cpr;
        private string _case;
        private string _Dækning;
        
        public Insurance(long cpr)
        {
            _Cpr = cpr;
        }

        public string InsuranceCheck
        {
            get
            {
                switch (_Cpr)
                {
                    case 1:
                        _case = "Alka";
                        break;
                        
                    case 2:
                        _case = "DanSikring";
                        break;

                    case 3:
                        _case = "Codan";
                        break;
                    case 4:
                        _case = "Tryg";
                        break;
                    default:
                        _case = "Ingen Forsikring";
                        break;

                }
                return _case;
            }
        }

        public string InsuranceDækning
        {
            get
            {
                switch (_Cpr)
                {
                    case 1:
                        _Dækning = "100%";
                        break;

                    case 2:
                        _Dækning = "¨75%";
                        break;

                    case 3:
                        _Dækning = "50%";
                        break;
                    case 4:
                        _Dækning = "25%";
                        break;
                    default:
                        _Dækning = "Uklart ring til Udbyder";
                        break;

                }
                return _Dækning;
            }
        }
    }
}