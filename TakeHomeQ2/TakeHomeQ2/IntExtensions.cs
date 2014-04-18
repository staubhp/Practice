using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeHomeQ2.Helpers;
using NUnit.Framework;

namespace TakeHomeQ2
{
    static class IntExtensions
    {
        //normally I'd put an extension like this in its own namespace, but this will work for this small problem
        public static int[] getPrimeFactors(this int value)
        {
            //getting prime factors is a non-trivial programming and math problem
            //there are tons of algorithms, some very complicated
            //for this problem i use the Sieve of Erastothenes to get a list of prime numbers, then use basic trial division to find factors
            List<int> myPrimeFactors = new List<int>();
            List<int> myPrimeNumbers = MathHelpers.getPrimeNumbers(value);

            if (value <= 1) { return myPrimeFactors.ToArray(); }

            while (true)
            {
                if (MathHelpers.isPrime(value)) //if the value itself is prime then we've arrived at the final factor
                {
                    myPrimeFactors.Add(value);
                    break;
                }

                foreach (var myPrimeNumber in myPrimeNumbers)
                {
                    if (value % myPrimeNumber == 0) //is a prime factor of our number
                    {
                        myPrimeFactors.Add(myPrimeNumber);
                        value = value / myPrimeNumber; //after discovering a factor, divide our value by it
                        break;
                    }
                }
            }

            return myPrimeFactors.ToArray();
        }
    }

    [TestFixture]
    public class IntExtensionTests
    {
        //Some might object to putting tests in the same class like this because it will be deployed with production code
        //I like the convenience of grouping tests with their class, but you can put it in another project depending on preference

        [Test]
        public void Test_getPrimeFactors()
        {
            //http://www.mathwarehouse.com/arithmetic/numbers/prime-number/prime-factorization.php?number=547841#primeFactorization

            List<int> myPrimes1 = new List<int> (){7, 61, 1283};
            int myInt1 = 547841;
            Assert.AreEqual(myPrimes1, myInt1.getPrimeFactors(), "Extension method getPrimeFactors() returned incorrect value");

            List<int> myPrimes2 = new List<int>() {  };
            int myInt2 = 1;
            Assert.AreEqual(myPrimes2, myInt2.getPrimeFactors(), "Extension method getPrimeFactors() returned incorrect value");

            List<int> myPrimes3 = new List<int>() { };
            int myInt3 = 0;
            Assert.AreEqual(myPrimes3, myInt3.getPrimeFactors(), "Extension method getPrimeFactors() returned incorrect value");

            List<int> myPrimes4 = new List<int>() { 5,7,587,2371 };
            int myInt4 = 48712195;
            Assert.AreEqual(myPrimes4, myInt4.getPrimeFactors(), "Extension method getPrimeFactors() returned incorrect value");

            List<int> myPrimes5 = new List<int>() { 2, 3, 167 };
            int myInt5 = 1002;
            Assert.AreEqual(myPrimes5, myInt5.getPrimeFactors(), "Extension method getPrimeFactors() returned incorrect value");

            List<int> myPrimes6 = new List<int>() { 2, 3, 7, 251  };
            int myInt6 = 10542;
            Assert.AreEqual(myPrimes6, myInt6.getPrimeFactors(), "Extension method getPrimeFactors() returned incorrect value");
        }

        [Test]
        public void Test_factorsMultiply()
        {
            int myInt1 = 1589;
            var myPrimeFactors1 = myInt1.getPrimeFactors();
            var myProduct1 = 1;
            foreach (var myPrimeFactor in myPrimeFactors1) { myProduct1 *= myPrimeFactor; }
            Assert.AreEqual(myInt1, myProduct1, "The product of the prime factors did not equal the input value");

            int myInt2 = 40754;
            var myPrimeFactors2 = myInt2.getPrimeFactors();
            var myProduct2 = 1;
            foreach (var myPrimeFactor in myPrimeFactors2) { myProduct2 *= myPrimeFactor; }
            Assert.AreEqual(myInt2, myProduct2, "The product of the prime factors did not equal the input value");

            int myInt3 = 1;
            var myPrimeFactors3 = myInt3.getPrimeFactors();
            var myProduct3 = 1;
            foreach (var myPrimeFactor in myPrimeFactors3) { myProduct3 *= myPrimeFactor; }
            Assert.AreEqual(myInt3, myProduct3, "The product of the prime factors did not equal the input value");

            int myInt4 = 987456;
            var myPrimeFactors4 = myInt4.getPrimeFactors();
            var myProduct4 = 1;
            foreach (var myPrimeFactor in myPrimeFactors4) { myProduct4 *= myPrimeFactor; }
            Assert.AreEqual(myInt4, myProduct4, "The product of the prime factors did not equal the input value");
        }
      

    }
}
