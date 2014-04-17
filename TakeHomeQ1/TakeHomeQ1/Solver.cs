using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TakeHomeQ1
{
    /// <summary>
    /// Contains methods for solving Question 1.1 and Question 1.2
    /// </summary>
    class Solver
    {
        public Solver() { }

        public enum triangleType
        {
            isoceles,
            scalene,
            equilateral,
            unknown
        }

        /// <summary>
        /// Determines the triangle's type from the length of its sides
        /// </summary>
        /// <param name="sideA">The length of side A</param>
        /// <param name="sideB">The length of side B</param>
        /// <param name="sideC">The length of side C</param>
        /// <returns></returns>
        public static triangleType getTriangleType(int sideA, int sideB, int sideC)
        {
            triangleType ret = triangleType.unknown;

            //equilateral: all sides the same
            //isoceles: two sides the same
            //scalene: no sides the same

            //to avoid a krufty if/else statement I add the values to an array and use Distinct()
            int[] myInts = new int[3] { sideA, sideB, sideC };
            if (myInts.Distinct().Count() == 1)
            {
                ret = triangleType.equilateral;
            }
            if (myInts.Distinct().Count() == 2)
            {
                ret = triangleType.isoceles;
            }
            if (myInts.Distinct().Count() == 3)
            {
                ret = triangleType.scalene;
            }
            return ret;
        }

        public void solvePart1()
        {
            int sideA = -1;
            int sideB = -1;
            int sideC = -1;

            Console.WriteLine("Take Home Question 1, Part 1");
            Console.WriteLine("Provide the lengths of a triangle's three sides to determine its type:");
            Console.WriteLine("Input side A length:");
            while (!int.TryParse(Console.ReadLine(), out sideA))
            {
                Console.WriteLine("Invalid input. Input side A length:");
            }
            Console.WriteLine("Input Side B length:");
            while (!int.TryParse(Console.ReadLine(), out sideB))
            {
                Console.WriteLine("Invalid input. Input side B length:");
            }
            Console.WriteLine("Input Side C length:");
            while (!int.TryParse(Console.ReadLine(), out sideC))
            {
                Console.WriteLine("Invalid input. Input side C length:");
            }

            triangleType myTriangleType = getTriangleType(sideA, sideB, sideC);

            StringBuilder myResultString = new StringBuilder();
            myResultString.Append("The triangle with those side lengths ");
            myResultString.Append("(" + sideA.ToString() + ", " + sideB.ToString() + ", " + sideC.ToString() + ")");
            myResultString.Append(" is a(n) " + myTriangleType.ToString() + " triangle");

            Console.WriteLine(myResultString.ToString());
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        public void solvePart2()
        {
            SinglyLinkedList myList = new SinglyLinkedList();

            Console.WriteLine("Take Home Question 1, Part 2");
            Console.WriteLine("Given a singly linked list of integers, get the fifth element from the end in one pass.");
            Console.WriteLine("Enter a list of integers separated by commas (e.g., 4,2,10,6):");
            string userInputString = Console.ReadLine();

            //split the input into an array and build the list 
            bool success = true;
            do
            {
                success = true;
                string[] myUserInputs = userInputString.Split(',');
                foreach (var myUserInput in myUserInputs)
                {
                    int k = -1;
                    if (!int.TryParse(myUserInput.Trim(), out k))
                    {
                        success = false;
                        Console.WriteLine("Invalid input.");
                        Console.WriteLine("Enter a list of integers separated by commas (e.g. 4,2,10,6):");
                        userInputString = Console.ReadLine();
                        break;
                    }
                    else
                    {
                        myList.Add(k);
                    }
                }
            } while (success == false);

            
            //Now for some assumptions about this problem statement:
            //1) Must get 5th element from last in one pass. I define a pass to be a full loop through whole list, meaning I'm not violating the problem by using myList.Get(5)
            //2) 5th element from last: does it include that fifth element, or is it literally 5 elements BEFORE the last one. I assume it includes the last
            var myCurrentNode = myList.headNode;
            var myLookAheadNode = myList.GetNode(5);
            if (myLookAheadNode == null) { Console.WriteLine("Error: The list does not contain at least 5 elements."); Console.ReadLine(); }
            while (true) //have to use infinite loop b/c problem states we can't use list's length
            {
                if (myLookAheadNode == null) { break; }
                myCurrentNode = myCurrentNode.Next;
                

            }
        }
    }

    [TestFixture]
    public class Part1Tests
    {
        [Test]
        public void Test_GetTriangleType()
        {
            //The Solver will not allow illegal inputs and will not compute the triangle type until it has 3 integers
            //This is why we don't need to test for anything except proper output
            Assert.AreEqual(Solver.triangleType.equilateral, Solver.getTriangleType(1, 1, 1), "getTriangleType(1,1,1) did not return equilateral");
            Assert.AreEqual(Solver.triangleType.isoceles, Solver.getTriangleType(0, 1, 1), "getTriangleType(0,1,1) did not return isoceles");
            Assert.AreEqual(Solver.triangleType.scalene, Solver.getTriangleType(0, 1, 2), "getTriangleType(0,1,2) did not return scalene");
        }
    }
}
