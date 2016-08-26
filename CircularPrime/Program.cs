using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularPrime
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(FindCircularPrimes(1, 1000000));
            Console.ReadLine();
        }

        private static int FindCircularPrimes(int from, int to)
        {
            ArrayList primes = new ArrayList();
            int cPrimeCount = 0;

            for (int i = from; i <= to; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            foreach (int number in primes)
            {
                if (IsCircularPrime(number, primes))
                {
                    cPrimeCount++;
                }
            }

            return cPrimeCount;
        }

        private static bool IsPrime(int number)
        {
            if (number == 0) return false;
            if (number == 1) return true;

            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        private static bool IsCircularPrime(int number, ArrayList primes)
        {
            int tenths = 1;
            int prime = number;
            int digitsCount = 0;
            int digit;

            //Check even numbers and count the digits:
            while (prime > 0)
            {
                digit = prime % 10;

                if ((digit % 2 == 0) || (digit == 5))
                {
                    return false;
                }

                prime /= 10;
                tenths *= 10;
                digitsCount++;
            }
            tenths /= 10;

            prime = number;
            //Check if the number is prime while rotating it:
            for (int i = 0; i < digitsCount; i++)
            {
                if (!primes.Contains(prime))
                {
                    return false;
                }

                digit = prime % 10;
                prime = digit * tenths + prime / 10;
            }

            return true;
        }
    }
}
