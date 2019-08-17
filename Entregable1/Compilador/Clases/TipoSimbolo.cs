using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.Clases
{
    public class TipoSimbolo
    {
        const int error = -1;
        const int identificador = 0;
        const int entero = 1;
        const int real = 2;
        const int cadena = 3;
        const int tipo = 4;
        const int opSuma = 5;
        const int opMul = 6;
        const int opRelac = 7;
        const int opOr = 8;
        const int opAnd = 9;
        const int opNot = 10;
        const int opIgualdad = 11;
        const int puntoComa = 12;
        const int coma = 13;
        const int parenA = 14;
        const int parenC = 15;
        const int llaveA = 16;
        const int llaveC = 17;
        const int igual = 18;
        const int si = 19;
        const int mientras = 20;
        const int devuelve = 21;
        const int sino = 22;
        const int pesos = 23;

        public static int Identificador => identificador;
        public static int Entero => entero;
        public static int Real => real;
        public static int Cadena => cadena;
        public static int Tipo => tipo;
        public static int OpSuma => opSuma;
        public static int OpMul => opMul;
        public static int OpRelac => opRelac;
        public static int OpOr => opOr;
        public static int OpAnd => opAnd;
        public static int OpNot => opNot;
        public static int OpIgualdad => opIgualdad;
        public static int PuntoComa => puntoComa;
        public static int Coma => coma;
        public static int ParenA => parenA;
        public static int ParenC => parenC;
        public static int LlaveA => llaveA;
        public static int LlaveC => llaveC;
        public static int Igual => igual;
        public static int Si => si;
        public static int Mientras => mientras;
        public static int Devuelve => devuelve;
        public static int Sino => sino;
        public static int Pesos => pesos;
        public static int Error => error;
    }
}
