using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using NUnit.Framework;

namespace TakeHomeQ2.Helpers
{
    class MathHelpers
    {
        public static bool isPrime(int n)
        {
            int max = (int)Math.Floor(Math.Sqrt(n));

            if (n == 1) return false;

            for (int i = 2; i <= max; ++i)
            {
                if (n % i == 0) return false;
            }

            return true;

        }

        /// <summary>
        /// Uses the sieve of Eratosthenes to return a list of prime numbers less than or equal to max
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        private static List<int> sieve(int max)
        {
            //http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes#Incremental_sieve

            List<int> myPrimeNumbers = new List<int>();

            if (max <= 1) { return myPrimeNumbers; }

            //create a bit array from 2 to max
            BitArray ba = new BitArray(max+1 , true);

            //0 and 1 aren't prime, so mark them as false
            ba[0] = false;
            ba[1] = false;

            int j = 2;
            int index = 2;

            while ((j * j) <= ba.Length)
            {
                while ((index += j) <= max)
                {
                    ba[index] = false;
                }
                j += 1;
                index = j;
            }

            for (int i = 0; i < ba.Length; i++)
            {
                if (ba[i]) { myPrimeNumbers.Add(i); } //anything marked true at this point is prime
            }

            return myPrimeNumbers;
        }

        /// <summary>
        /// Find the prime numbers less than or equal to the given number
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static List<int> getPrimeNumbers(int max)
        {
            return sieve(max);
        }
    }

    [TestFixture]
    public class MathHelperTests
    {
        [Test]
        public void Test_getPrimeNumbers()
        {
            //http://www.datedial.com/List_Prime_Numbers_Between_Numbers.asp

            List<int> myPrimes1 = new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
            int myMax1 = 100;
            Assert.AreEqual(myPrimes1, MathHelpers.getPrimeNumbers(myMax1), "getPrimeNumbers() returned an incorrect value");

            List<int> myPrimes2 = new List<int>() { };
            int myMax2 = 1;
            Assert.AreEqual(myPrimes2, MathHelpers.getPrimeNumbers(myMax2), "getPrimeNumbers() returned an incorrect value");

            List<int> myPrimes3 = new List<int>() { };
            int myMax3 = 0;
            Assert.AreEqual(myPrimes3, MathHelpers.getPrimeNumbers(myMax3), "getPrimeNumbers() returned an incorrect value");

            List<int> myPrimes4 = new List<int>() { 2, 3, 5, 7 };
            int myMax4 = 7;
            Assert.AreEqual(myPrimes4, MathHelpers.getPrimeNumbers(myMax4), "getPrimeNumbers() returned an incorrect value");

            List<int> myPrimes5 = new List<int>() { 2,3,5,7,11,13,17,19,23,29,31,37,41,43,
                                                    47,53,59,61,67,71,73,79,83,89,97,101,103,107,109,
                                                    113,127,131,137,139,149,151,157,163,167,173,179,181,191,193,
                                                    197,199,211,223,227,229,233,239,241,251,257,263,269,271,277,
                                                    281,283,293,307,311,313,317,331,337,347,349,353,359,367,373,
                                                    379,383,389,397,401,409,419,421,431,433,439,443,449,457,461,
                                                    463,467,479,487,491,499,503,509,521,523,541,547,557,563,569,
                                                    571,577,587,593,599,601,607,613,617,619,631,641,643,647,653,
                                                    659,661,673,677,683,691,701,709,719,727,733,739,743,751,757,
                                                    761,769,773,787,797,809,811,821,823,827,829,839,853,857,859,
                                                    863,877,881,883,887,907,911,919,929,937,941,947,953,967,971,
                                                    977,983,991,997,1009,1013,1019,1021,1031,1033,1039,1049,1051};
            int myMax5 = 1059;
            Assert.AreEqual(myPrimes5, MathHelpers.getPrimeNumbers(myMax5), "getPrimeNumbers() returned an incorrect value");
        }


    }
}
