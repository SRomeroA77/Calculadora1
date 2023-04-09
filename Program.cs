using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Program
    {

        public static List<char> operaciones =  new List<char> {'+', '-', '*', '/', '^'};

        public static double Sumar(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double Restar(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Multiplicar(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double Dividir(double num1, double num2)
        {
            if (num2 == 0){
                return 0;
            }
            return num1 / num2;
        }

        public static double Potenciar(double num1, double num2)
        {
            double temp = 1;
            for (int i = 0; i < num2; i++)
            {
                temp *= num1;
            }
            return temp;
        }
        public static void Calcular(string operacion, double num1, double num2)
        {
            switch (operacion)
            {
                case string operador when operador == "+":
                    Console.WriteLine($"La suma de {num1} + {num2} =" + Sumar(num1, num2));
                    break;
                case string operador when operador == "-":
                    Console.WriteLine($"La resta de {num1} - {num2} = " + Restar(num1, num2));
                    break;
                case string operador when operador == "*":
                    Console.WriteLine($"La multiplicación de {num1} * {num2} = " + Multiplicar(num1, num2));
                    break;
                case string operador when operador == "/":
                    Console.WriteLine($"La división de {num1} / {num2} = " + Dividir(num1, num2));
                    break;
                case string operador when operador == "^":
                    Console.WriteLine($"La potencia de {num1} ^ {num2} = " + Potenciar(num1, num2));
                    break;
                default:
                    Console.WriteLine("No se puede hacer este tipo de operación, intente de nuevo");
                    break;
            }

        }

        public static int PreguntarModoCalcular()
        {
            int seleccion = -1;
            Console.WriteLine("Modo de calcular:\n" +
                                "1 - Modo manual.\n" +
                                "2 - Modo Automático.\n" +
                                "0 - Salir.");
            
            try
            {
                seleccion = int.Parse(Console.ReadLine());
                if (seleccion < -1 | seleccion > 4)
                {
                    Console.WriteLine("Número incorrecto.");
                    PreguntarModoCalcular();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Número incorrecto.");
                PreguntarModoCalcular();
            }
            return seleccion;
        }
        public static string PreguntarOperacion()
        {
            Console.WriteLine("¿qué operacion desea hacer sumar(+), restar(-), ,multiplicar(*), dividir(/) o potencia(^)?");
            string operacion = Console.ReadLine();
            if (operacion != "+" & operacion != "-" & operacion != "*" & operacion != "/" & operacion != "^")
            {
                Console.WriteLine("no es una operación válida");
                PreguntarOperacion();
            }
            return operacion;
        }

        public static double PedirNumero1()
            
        {
            double num1 = 0;
            Console.WriteLine("seleccione el primer número:");
            try
            {
                num1 = double.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("no es un número válido");
                PedirNumero1();
            }
            return num1;
        }

        public static double PedirNumero2()
            
        {
            double num2 = 0;
            Console.WriteLine("seleccione el primer número:");
            try
            {
                num2 = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("no es un número válido");
                PedirNumero2();
            }
            return num2;
        }
        public static void ModoAutomatico()
        {
            Console.WriteLine("Indique la operación que desea hacer:");
            string operacion = Console.ReadLine();
            Console.WriteLine(ExisteOperando(operacion));
            if (ExisteOperando(operacion))
            {
                var numeros = SepararNumerosDeCadena(operacion);
                Calcular(numeros[1], Convert.ToDouble(numeros[0]), Convert.ToDouble(numeros[2]));
            }
            else
            {
                Console.WriteLine("No se puede hacer esa operación.");
                ModoAutomatico();
            }

        }

        public static bool ExisteOperando(string cadena)
        {
            foreach (var caracter in operaciones){
                if (cadena.Contains(caracter))
                {
                    return cadena.Contains(caracter);
                }
            }
            return false;
        }
        public static string[] SepararNumerosDeCadena(string cadena)
        {
            string[] numeros = { };
            string nuevaCadena = "";
            foreach (var caracter in operaciones)
            {
                if (cadena.Contains(caracter))
                {
                    nuevaCadena = cadena.Replace(" ", "");
                    nuevaCadena = nuevaCadena.Replace(Convert.ToString(caracter), " " + Convert.ToString(caracter) + " ");
                    
                    numeros = nuevaCadena.Split(' ');
                }
            }
            return numeros;
        }

        public static void RealizarOperacion(string[] operacion)
        {
        }

        static void Main(string[] args)
        {
            int fin = 0;
            do
            {
                int seleccion = PreguntarModoCalcular();
                if (seleccion == 1)
                {
                    string operacion = PreguntarOperacion();
                    double num1 = PedirNumero1();
                    double num2 = PedirNumero2();
                    Calcular(operacion, num1, num2);
                }
                if (seleccion == 2)
                {
                    ModoAutomatico();
                }
                if (seleccion == 0)
                {
                    fin++;
                }
            } while (fin == 0);
            

        }

    }
}
