using System.Collections.Generic;
using System.ServiceModel;
using Windows.UI.Xaml.Controls;

namespace Walden_Hospital
{
    public class IDCardKatalog
    {
        private static Dictionary<long, IDCard> _IDCardKatalog;

        public IDCardKatalog()
        {
            
        }

        public static Dictionary<long, IDCard> Instance()
        {
            if (_IDCardKatalog == null)
            {
                _IDCardKatalog = new Dictionary<long, IDCard>();
            }

            return _IDCardKatalog;
        }

        public void OpretIDCard(IDCard IDCard)
        {
            Instance().Add(IDCard.CardID, IDCard);
        }

        public void DeleteIDCard(IDCard IDCard)
        {
            if (Instance().ContainsKey(IDCard.CardID))
            {
                Instance().Remove(IDCard.CardID);
            }
        }
    }
}