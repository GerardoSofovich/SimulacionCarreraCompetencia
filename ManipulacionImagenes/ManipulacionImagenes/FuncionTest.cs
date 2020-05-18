using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacionImagenes
{
    public class FuncionTest:IFuncion
    { 
        public FuncionTest() { }
        public double CalcularResultado(double x, double y)
        {
            double ans = Math.Exp(x) * y;
            return ans;
        }
    }
}
