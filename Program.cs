using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Multiplicar(3.1416m, 6.9745m));
            //Console.WriteLine(Dividir(3.1416m, 6.97457m));

            /*Console.WriteLine(string.Join(',', ordenar(6,9,7,4,5,9,7,0,6,9,7)));
            Console.WriteLine(string.Join(';', fibonacci(10)));
            Console.WriteLine(isPalindrome("anita lava la tina", true));
            tablaMultiplicar(89);
            Console.WriteLine(string.Join('-', primeNumbers(7)));
            Console.WriteLine(recursiveSum(9, 4));
            Console.WriteLine(recursiveSubstraction(500, 3));*/
            Console.WriteLine(numberToHex(7817768));
            Console.WriteLine(numberToBinary(600));
        }

        public static decimal Multiplicar(decimal a, decimal b)
        {
            // Caso base
            if (b == 0)
            {
                return 0;
            }
            // Caso recursivo
            decimal resultado = Multiplicar(a, decimal.Floor(b / 2));
            resultado += resultado;
            if (b % 2 == 1)
            {
                resultado += a;
            }
            return resultado;
        }

        public static decimal Dividir(decimal dividendo, decimal divisor)
        {
            // Casos base
            if (divisor == 0)
            {
                throw new DivideByZeroException("No se puede dividir por cero.");
            }
            if (dividendo == 0 || dividendo < divisor)
            {
                return 0;
            }
            // Caso recursivo
            return 1 + Dividir(dividendo - divisor, divisor);
        }

        public static int[] ordenar(params int[] numeros)
        {
            for(int i = 0; i <= numeros.Length; i++)
            {
                for(int current_index = 0; current_index <= numeros.Length - 1; current_index++)
                {
                    int next_index = current_index + 1;
                    if(next_index == numeros.Length) break;
                    if(numeros[current_index] > numeros[next_index])
                    {
                        int temp = numeros[current_index];
                        numeros[current_index] = numeros[next_index];
                        numeros[next_index] = temp;
                    }
                }
            }
            return numeros;
        }

        public static List<int> fibonacci(int limite)
        {
            int sum = 0;
            int old = 1;
            List<int> sucesion = new List<int>();
            for(int i = 0; i <= limite; i++)
            {
                int temp = old;
                old = sum;
                sum = sum + temp;
                sucesion.Add(sum);
            }
            return sucesion;
        }

        public static bool isPalindrome(string word, bool removeWhiteSpace = false)
        {
            word = removeWhiteSpace ? word.Replace(" ", ""):word.Trim();
            string word_reverse = "";
            for(int i = word.Length - 1; i >= 0; i--)
            {
                word_reverse += word[i];
            }
            return word.Equals(word_reverse);
        }

        public static void tablaMultiplicar(int numero)
        {
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{numero} x {i} = {numero*i}");
            }
        }

        public static List<int> primeNumbers(int limit, bool onlyLimit = false)
        {
            List<int> primes = new List<int>();
            for(int i = onlyLimit ? limit:0; i <= limit; i++)
            {
                bool isPrime = false;
                for(int j = 2; j < i; j++)
                {
                    if(i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    isPrime = true;
                }
                if(isPrime) primes.Add(i);
            }
            return primes;
        }

        public static int recursiveSum(int a, int b)
        {
            int product = 0;
            for(int i = 1; i <= b; i++)
            {
                product += a;
            }
            return product;
        }

        public static int recursiveSubstraction(int a, int b)
        {
            if(b == 0) return 0;
            int cociente = 0;
            while(a > b)
            {
                a = a - b;
                cociente++;
            }
            return cociente;
        }

        public static string numberToHex(int number)
        {
            Dictionary<int, string> hex = new Dictionary<int, string>(){
                {15, "F"},
                {14, "E"},
                {13, "D"},
                {12, "C"},
                {11, "B"},
                {10, "A"},
                {9, "9"},
                {8, "8"},
                {7, "7"},
                {6, "6"},
                {5, "5"},
                {4, "4"},
                {3, "3"},
                {2, "2"},
                {1, "1"},
                {0, "0"},
            };
            string result = "";
            while(number > 0)
            {
                int residuo = number % 16;
                result = hex[residuo] + result;
                number /= 16;
            }
            return result;
        }

        public static string numberToBinary(int number)
        {
            string result = "";
            while(number > 0)
            {
                int cociente = number % 2;
                number /= 2;
                result = cociente.ToString() + result;
            }
            return result;
        }
    }
}