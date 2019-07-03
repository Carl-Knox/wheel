using System;       // MicroSoft Visual Studio Express 2015 for Windows Desktop
using System.Numerics;          // needed for Biginteger
using System.Windows.Forms;     // needed for Clipboard

namespace _210_Wheel_v2._00     // version 2.00 made to Incument from a starting number
{   class Program
    {   [STAThread]             // needed for Clipboard
        static void Main()
        {
            /* Declare Variables ***********************************************************/
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int index, reset;
            BigInteger a, n, remainder, ring, step, x;
            BigInteger[] wheel ={1,2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,
                                73,79,83,89,97,101,103,107,109,113,121,127,131,137,139,143,
                                149,151,157,163,167,169,173,179,181,187,191,193,197,199,209};
                                //* 46 Primes + 6 non-Primes(1,121,143,169,187,209) */

            /* Assign Variables ************************************************************/
            index = 0;
            reset = wheel.Length - 1;                       // spoke index
            step = 210;                                     // wheel dimension
            n = 339850094323758691;     // 764567807 444499613 (~854 ms)
            a = iSqrt(n);
            x = (a * 707) / 1000;                           // starting point (~2:1 ratio)
            remainder = x % step;
            ring = x - remainder;                           // integer of steps
            /* Identify the index of the first potential prime more than the Remainder */
            if (remainder > 0)  while (wheel[index] <= remainder) index++;
            Console.WriteLine("\t 210 Wheel Factoring v2.00\n\n {0}", n); // incumenting

            /* Algorithm *******************************************************************/
            for (; ring <= a; ring += step)                 // nested Loops
            {   for (; index < reset; index++)
                    if ((n % (ring + wheel[index])) == 0)   goto Factored;
                index = 0;
            }
            /* Output Messages *************************************************************/
            Console.WriteLine("\n - - - Failure - - -");    goto Exit;
Factored:   x = ring + wheel[index];
            Console.WriteLine("\n p = {0}\n q = {1}", n / x, x);
            Console.WriteLine(" Press <Enter> to write to Paste Buffer");
            Console.Read(); Console.Read();
            sb.Append(n / x + "\n"); sb.Append(x + "\n");   // store in a string
            Clipboard.SetText(sb.ToString());               // output to clipboard
Exit:       Console.Read();
        } // End Main()

          /* Methods ***********************************************************************/
        private static BigInteger iSqrt(BigInteger num)
        { // Finds the integer square root of a positive number
            if (0 == num)   return 0;                       // Avoid zero divide
            BigInteger n = (num / 2) + 1;                   // Initial estimate, never low
            BigInteger n1 = (n + (num / n)) >> 1;           // n1 = (n + (num / n)) / 2;
            while (n1 < n)
            {   n = n1;
                n1 = (n + (num / n)) >> 1;                  // n1 = (n + (num / n)) / 2;
            }
            return n;
        } // end iSqrt()
    } // End Program
} // End namespace
