using System.Collections.Generic;

namespace Walden_Hospital
{
    public class RelativeKatalog
    {
        private static Dictionary<long, Relative> _relativeKatalog;
        public RelativeKatalog()
        {
            
        }

        public static Dictionary<long, Relative> Instance()
        {
            if (_relativeKatalog == null)
            {
                _relativeKatalog = new Dictionary<long, Relative>();
            }
            return _relativeKatalog;
        }

        public void OpretRelative(long CPR, Relative rel)
        {
            Instance().Add(CPR, rel);
        }

        public void DeleteRelative(long CPR)
        {
            if (Instance().ContainsKey(CPR))
            {
                Instance().Remove(CPR);
            }
        }
    }
}