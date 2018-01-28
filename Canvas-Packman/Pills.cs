using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas_Packman
{

    class Pills
    {
        List<Pill> _Pills = new List<Pill>();

        public List<Pill> GetPills()
        {
            return _Pills;
        }

        public bool CheckAndRemovePill(int x, int y)
        {
            foreach(var pill in _Pills)
            {
                if(pill.X==x && pill.Y== y)
                {
                    _Pills.Remove(pill);
                    return true;
                }
            }
            return false;
        }

        public Pills()
        {
            for (int i=0;i<600;i+=50)
            {
                for(int j=0;j<600; j+=50)
                {
                    _Pills.Add(new Pill(i + 25, j + 25));
                }
            }
        }
    }
}
