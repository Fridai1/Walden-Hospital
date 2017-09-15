namespace Walden_Hospital
{
    public class IDCard
    {
        private long _CardID;
        private string _Validity;

        public IDCard(long IDnr, string valid)
        {
            _CardID = IDnr;
            _Validity = valid;
        }

        public long CardID
        {
            get => _CardID;
            set => _CardID = value;
        }

        public string Validity
        {
            get => _Validity;
            set => _Validity = value;
        }
    }
}