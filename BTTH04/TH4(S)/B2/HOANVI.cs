using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2
{
    class HOANVI
    {
        double _a, _b;
        public HOANVI(double a, double b)
        {
            _a = a;
            _b = b;
        }
        
        public double A
        {
            get { return _a; }
        }

        public double B
        {
            get { return _b; }
        }

        public void warp()
        {
            double temp = _a;
            _a = _b;
            _b = temp;
        }
    }
}
