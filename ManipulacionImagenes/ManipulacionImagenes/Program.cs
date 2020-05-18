using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulacionImagenes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Punto> puntos = ListarPuntoSimulacion(5, 0.05);
            int l = puntos.Count;
            for(int i = 0; i < l; i++)
            {
                Console.WriteLine(puntos[i].ToString());
            }

            Console.ReadLine();
        }
        static void Test1()
        {
            FuncionTest funcion = new FuncionTest();
            Simulador simulador = new Simulador();
            double ans = simulador.Runge_Kutta(0, Math.E, funcion, 0.01, 1);
            Console.WriteLine(ans);
        }
        static List<Punto> ListarPuntoSimulacion(double limx, double paso)
        {
            double h = paso;
            double pasos = 0;
            double x = 0;
            double y = 0;
            double cuadx;
            double sinx;
            List<double> estados = new List<double> { 0, 0, 0 };
            List<double> ans;
            List<List<double>> A = new List<List<double>>();
            A.Add(new List<double>());
            A.Add(new List<double>());
            A.Add(new List<double>());
            A[0].Add(0);
            A[0].Add(1);
            A[0].Add(0);
            A[1].Add(0);
            A[1].Add(0);
            A[1].Add(1);
            A[2].Add(0);
            A[2].Add(0);
            A[2].Add(0);
            List<Punto> puntos = new List<Punto>();
            Punto primer = new Punto(x, y);
            puntos.Add(primer);
            while (pasos < limx)
            {
                cuadx = x * x;
                sinx = Math.Sin(x);
                RecalcularMatrix(x, sinx, A);
                ans = MultiplicarMatrix(estados, A);
                SumarTerminoIndependiente(ans, cuadx);
                estados = NuevoEstado(ans, h, estados);
                x = x + paso;
                Punto otro = new Punto(x, estados[0]);
                puntos.Add(otro);
                pasos = pasos + h;
            }
            return puntos;
        }
        static void RecalcularMatrix(double _x, double _senx, List<List<double>> _matrizA)
        {
            _matrizA[1][2] = _x*(-1);
            _matrizA[2][2] = _senx;

        }
        static List<double> MultiplicarMatrix(List<double> estados, List<List<double>> _matrizA)
        {
            List<double> ans = new List<double> { 0, 0, 0 };
            ans[0] = estados[0] * _matrizA[0][0] + estados[1] * _matrizA[0][1] + estados[2] * _matrizA[0][2];
            ans[1] = estados[0] * _matrizA[1][0] + estados[1] * _matrizA[1][1] + estados[2] * _matrizA[1][2];
            ans[2] = estados[0] * _matrizA[2][0] + estados[1] * _matrizA[2][1] + estados[2] * _matrizA[2][2];
            return ans;
        }
        static void SumarTerminoIndependiente(List<double> ans, double _cuadx)
        {
            ans[2] = ans[2] + _cuadx;
        }
        static List<double> NuevoEstado(List<double> _ans, double paso,List<double> oldestados)
        {
            List<double> nuevosEstados = new List<double>();
            nuevosEstados.Add(oldestados[0] + paso * _ans[0]);
            nuevosEstados.Add(oldestados[1] + paso * _ans[1]);
            nuevosEstados.Add(oldestados[2] + paso * _ans[2]);
            return nuevosEstados;
        }
        
    }
    class Punto
    {
        double x;
        double y;
        public Punto(double _x,double _y) { x = _x; y = _y; }
        public override string ToString()
        {
            string m = "x: ";
            m += x.ToString() + " y: " + y.ToString();
            return m;
        }
    }
}
