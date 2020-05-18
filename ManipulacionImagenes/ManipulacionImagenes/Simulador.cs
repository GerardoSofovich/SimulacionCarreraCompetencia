using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacionImagenes
{
    public class Simulador
    {
        
        public Simulador() { }
        public double Runge_Kutta(double xo,double yo, IFuncion funcion,double paso, double limitex)
        {
            double k1;
            double k2;
            double k3;
            double k4;
            double ks;
            double pasos = 0;
            double h = paso;
            double x = xo;
            double y = yo;
            double lim = limitex;
            while (pasos < lim)
            {
                k1 = funcion.CalcularResultado(x, y);
                k2 = funcion.CalcularResultado(x + h / 2, y + h*k1 / 2);
                k3 = funcion.CalcularResultado(x + h / 2, y + h*k2 / 2);
                k4 = funcion.CalcularResultado(x + h, y + k3 * h);
                ks = k1 + 2 * k2 + 2 * k3 + k4;
                y = y + ks * h / 6;
                x = x + h;
                pasos =pasos+ h;
            }
            return y;

        } 
        

    }
}
