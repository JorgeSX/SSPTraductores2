using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.Clases
{
    public class Lexico
    {
        private string fuente;
        private int ind;
        private bool continua;
        private char c;
        private int estado;

        public int tipo;
        public string simbolo;

        public Lexico(string f)
        {
            ind = 0;
            fuente = f;
        }

        public Lexico()
        {
            ind = 0;
            simbolo = "";
        }

        public void Entrada(string f)
        {
            ind = 0;
            fuente = f;
            simbolo = "";
        }

        public int SigSimbolo()
        {
            estado = 0;
            continua = true;
            simbolo = "";

            while (continua)
            {
                c = SigCaracter();
                switch (estado)
                {
                    case 0:
                        if (EsLetra(c))
                            SigEstado(1);
                        else if (EsDigito(c))
                            SigEstado(2);
                        else if (EsOpAd(c))
                            Aceptacion(5);
                        else if (EsOpMul(c))
                            Aceptacion(6);
                        else if (EsOpAsig(c))
                            SigEstado(7);
                        else if (EsOpRela(c))
                            SigEstado(9);
                        else if (EsOpAnd(c))
                            SigEstado(11);
                        else if (EsOpOr(c))
                            SigEstado(13);
                        else if (EsOpNot(c))
                            SigEstado(15);
                        else if (EsParenA(c))
                            Aceptacion(14);
                        else if (EsParenC(c))
                            Aceptacion(15);
                        else if (EsLlaveA(c))
                            Aceptacion(16);
                        else if (EsLlaveC(c))
                            Aceptacion(17);
                        else if (EsPuntoComa(c))
                            Aceptacion(12);
                        else if (EsComa(c))
                            Aceptacion(13);
                        else if (c == '$')
                            Aceptacion(23);
                        break;
                    case 1:
                        if (EsLetra(c))
                            SigEstado(1);
                        else if (EsDigito(c))
                            SigEstado(1);
                        else
                        {
                            Retroceso();
                            if (EsTipo())
                                AceptacionRetroceso(4);
                            else if (EsIf())
                                AceptacionRetroceso(19);
                            else if (EsWhile())
                                AceptacionRetroceso(20);
                            else if (EsReturn())
                                AceptacionRetroceso(21);
                            else if (EsElse())
                                AceptacionRetroceso(22);
                            else
                                AceptacionRetroceso(0);
                        }
                        break;
                    case 2:
                        if (EsDigito(c))
                            SigEstado(2);
                        else if (EsPunto(c))
                            SigEstado(3);
                        else
                        {
                            Retroceso();
                            AceptacionRetroceso(1);
                        }
                        break;
                    case 3:
                        if (EsDigito(c))
                            SigEstado(4);
                        else
                        {
                            Retroceso();
                            AceptacionRetroceso(-1);
                        }
                        break;
                    case 4:
                        if (EsDigito(c))
                            SigEstado(4);
                        else
                        {
                            Retroceso();
                            AceptacionRetroceso(2);
                        }
                        break;
                    case 5:
                        Aceptacion(5);
                        break;
                    case 6:
                        Aceptacion(6);
                        break;
                    case 7:
                        if (EsOpAsig(c))
                            Aceptacion(11);
                        else
                        {
                            Retroceso();
                            AceptacionRetroceso(18);
                        }
                        break;
                    case 8:
                        Aceptacion(11);
                        break;
                    case 9:
                        if (EsOpAsig(c))
                            Aceptacion(7);
                        else
                        {
                            Retroceso();
                            AceptacionRetroceso(7);
                        }
                        break;
                    case 10:
                        Aceptacion(7);
                        break;
                    case 11:
                        if (EsOpAnd(c))
                            Aceptacion(9);
                        else
                        {
                            Retroceso();
                            AceptacionRetroceso(-1);
                        }
                        break;
                    case 12:
                        Aceptacion(9);
                        break;
                    case 13:
                        if (EsOpOr(c))
                            Aceptacion(8);
                        else
                        {
                            Retroceso();
                            AceptacionRetroceso(-1);
                        }
                        break;
                    case 14:
                        Aceptacion(8);
                        break;
                    case 15:
                        if (EsOpAsig(c))
                            Aceptacion(11);
                        else
                        {
                            Retroceso();
                            AceptacionRetroceso(10);
                        }
                        break;
                    case 16:
                        Aceptacion(11);
                        break;
                    case 17:
                        Aceptacion(14);
                        break;
                    case 18:
                        Aceptacion(15);
                        break;
                    case 19:
                        Aceptacion(16);
                        break;
                    case 20:
                        Aceptacion(17);
                        break;
                    case 21:
                        Aceptacion(12);
                        break;
                    case 22:
                        Aceptacion(13);
                        break;
                    case 24:
                        Aceptacion(23);
                        break;

                }
            }

            switch (estado)
            {
                case -1:
                    tipo = TipoSimbolo.Error;
                    break;
                case 0:
                    tipo = TipoSimbolo.Identificador;
                    break;
                case 1:
                    tipo = TipoSimbolo.Entero;
                    break;
                case 2:
                    tipo = TipoSimbolo.Real;
                    break;
                case 3:
                    tipo = TipoSimbolo.Cadena;
                    break;
                case 4:
                    tipo = TipoSimbolo.Tipo;
                    break;
                case 5:
                    tipo = TipoSimbolo.OpSuma;
                    break;
                case 6:
                    tipo = TipoSimbolo.OpMul;
                    break;
                case 7:
                    tipo = TipoSimbolo.OpRelac;
                    break;
                case 8:
                    tipo = TipoSimbolo.OpOr;
                    break;
                case 9:
                    tipo = TipoSimbolo.OpAnd;
                    break;
                case 10:
                    tipo = TipoSimbolo.OpNot;
                    break;
                case 11:
                    tipo = TipoSimbolo.OpIgualdad;
                    break;
                case 12:
                    tipo = TipoSimbolo.PuntoComa;
                    break;
                case 13:
                    tipo = TipoSimbolo.Coma;
                    break;
                case 14:
                    tipo = TipoSimbolo.ParenA;
                    break;
                case 15:
                    tipo = TipoSimbolo.ParenC;
                    break;
                case 16:
                    tipo = TipoSimbolo.LlaveA;
                    break;
                case 17:
                    tipo = TipoSimbolo.LlaveC;
                    break;
                case 18:
                    tipo = TipoSimbolo.Igual;
                    break;
                case 19:
                    tipo = TipoSimbolo.Si;
                    break;
                case 20:
                    tipo = TipoSimbolo.Mientras;
                    break;
                case 21:
                    tipo = TipoSimbolo.Devuelve;
                    break;
                case 22:
                    tipo = TipoSimbolo.Sino;
                    break;
                case 23:
                    tipo = TipoSimbolo.Pesos;
                    break;
            }

            return tipo;
        }

        public char SigCaracter()
        {
            if (terminado())
                return '$';

            return fuente[ind++];
        }

        public string TipoEncontrado(int tipo)
        {
            string cad = "";

            switch (tipo)
            {
                case -1:
                    cad = "Error";
                    break;
                case 0:
                    cad = "Identificador";
                    break;
                case 1:
                    cad = "Entero";
                    break;
                case 2:
                    cad = "Real";
                    break;
                case 3:
                    cad = "Cadena";
                    break;
                case 4:
                    cad = "Tipo";
                    break;
                case 5:
                    cad = "Operador Suma";
                    break;
                case 6:
                    cad = "Operador Multiplicación";
                    break;
                case 7:
                    cad = "Operador Relacional";
                    break;
                case 8:
                    cad = "Operador Or";
                    break;
                case 9:
                    cad = "Operador  And";
                    break;
                case 10:
                    cad = "Operador Not";
                    break;
                case 11:
                    cad = "Operador Igualdad";
                    break;
                case 12:
                    cad = "Punto y Coma";
                    break;
                case 13:
                    cad = "Coma";
                    break;
                case 14:
                    cad = "Parentesis Apertura";
                    break;
                case 15:
                    cad = "Parentesis Cierre ";
                    break;
                case 16:
                    cad = "Llave Apertura";
                    break;
                case 17:
                    cad = "Llave Cierre";
                    break;
                case 18:
                    cad = "Igual ";
                    break;
                case 19:
                    cad = "If";
                    break;
                case 20:
                    cad = "While";
                    break;
                case 21:
                    cad = "Return";
                    break;
                case 22:
                    cad = "Else";
                    break;
                case 23:
                    cad = "Fin";
                    break;
            }

            return cad;
        }

        public void SigEstado(int est)
        {
            estado = est;
            simbolo += c;
        }

        public void Aceptacion(int est)
        {
            estado = est;
            simbolo += c;
            continua = false;
        }
        public void AceptacionRetroceso(int est)
        {
            estado = est;
            continua = false;
        }

        public bool terminado()
        {
            return ind >= fuente.Length;
        }

        public bool EsLetra(char c)
        {
            return char.IsLetter(c) || c == '_';
        }

        public bool EsDigito(char c)
        {
            return char.IsNumber(c);
        }

        public bool EsOpAd(char c)
        {
            return c == '+' || c == '-';
        }

        public bool EsOpMul(char c)
        {
            return c == '*' || c == '/';
        }

        public bool EsOpAsig(char c)
        {
            return c == '=';
        }

        public bool EsOpRela(char c)
        {
            return c == '<' || c == '>';
        }

        public bool EsOpAnd(char c)
        {
            return c == '&';
        }

        public bool EsOpOr(char c)
        {
            return c == '|';
        }

        public bool EsOpNot(char c)
        {
            return c == '!';
        }

        public bool EsParenA(char c)
        {
            return c == '(';
        }

        public bool EsParenC(char c)
        {
            return c == ')';
        }

        public bool EsLlaveA(char c)
        {
            return c == '{';
        }

        public bool EsLlaveC(char c)
        {
            return c == '}';
        }

        public bool EsPuntoComa(char c)
        {
            return c == ';';
        }

        public bool EsPunto(char c)
        {
            return c == '.';
        }

        public bool EsComa(char c)
        {
            return c == ',';
        }

        public bool EsEspacio(char c)
        {
            return c == ' ' || c == '\t';
        }

        public bool EsTipo()
        {
            return simbolo == "int" || simbolo == "float" || simbolo == "void";
        }

        public bool EsIf()
        {
            return simbolo == "if";
        }

        public bool EsWhile()
        {
            return simbolo == "while";
        }

        public bool EsReturn()
        {
            return simbolo == "return";
        }

        public bool EsElse()
        {
            return simbolo == "else";
        }

        public void Retroceso()
        {
            if (c != '$')
                ind--;
            continua = false;
        }
    }
}
