namespace Walden_Hospital
{
    public class IDCard
    {
        private long _CardID;
        private bool _Validity;

        public IDCard(long IDnr, bool valid)
        {
            _CardID = IDnr;
            _Validity = valid;
        }

        public long CardID
        {
            get => _CardID;
            set => _CardID = value;
        }

        public bool Validity
        {
            get => _Validity;
            set => _Validity = value;
        }
    }
}