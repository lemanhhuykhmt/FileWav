using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadAndPlay
{
    class Tools
    {
        public static double[] Linspace(double x1, double x2, int n)
        {
            if (x1 >= x2 || n < 1) return null;
            double space = (x2 - x1) / (n - 1);
            double[] y = new double[n];
            for(int i = 0; i < n; ++i)
            {
                y[i] = x1 + i * space;
            }
            return y;
        }
    }
}
