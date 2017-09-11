namespace Walden_Hospital
{
    public class Relative
    {
        private string _navn;
        private int _tlf;
        private string _forhold;
        public Relative(int tlf, string name, string forhold)
        {
            _tlf = tlf;
            _navn = name;
            _forhold = forhold;
        }

        public string Navn
        {
            get => _navn;
            set => _navn = value;
        }

        public int Tlf
        {
            get => _tlf;
            set => _tlf = value;
        }

        public string Forhold
        {
            get => _forhold;
            set => _forhold = value;
        }

        
        

    }
}