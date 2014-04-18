using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TakeHomeQ2
{
    class Solver
    {
        public Solver()
        { }

        public void solvePart1()
        {
            Console.WriteLine("Take Home Question 2");
            Console.WriteLine("Read an input file line by line, outputting the prime factors of the integer on each line.");

            var myListOfLines = getUserInputFile();            
            
            //get prime factors of integer
            processListOfLines(myListOfLines );

            Console.ReadLine();
        }

        private List<String> getUserInputFile()
        {
            Console.WriteLine("Enter text file's file path:");
            string myFilePath = Console.ReadLine();
            if (!System.IO.File.Exists(myFilePath))
            {
                Console.WriteLine("Error: File not found");
                return getUserInputFile();
            }
            else if (System.IO.Path.GetExtension(myFilePath).ToLower() != ".txt")
            {
                Console.WriteLine("Error: Only files with .txt extension are accepted");
               return getUserInputFile();

            }
            else
            {
                return System.IO.File.ReadLines(myFilePath).ToList(); //.NET file system stuff makes this easy 
            } 
        }

        private void processListOfLines(List<String> myLines)
        {         
            foreach (var myLine in myLines)
            {
                int i = -1;
                if (!int.TryParse(myLine, out i))
                {
                    Console.WriteLine("Input '" + myLine + "' is not an integer. Skipping..");
                    continue;
                }
                else
                {
                    int[] myPrimeFactors = i.getPrimeFactors();
                    Console.Write("Prime factors of " + myLine + ": ");
                    StringBuilder myOutput = new StringBuilder();
                    foreach (int p in myPrimeFactors)
                    {
                        myOutput.Append(p.ToString() + ", ");                        
                    }
                    Console.Write(myOutput.ToString().TrimEnd().TrimEnd(','));
                    Console.WriteLine("");
                }
            }            
        }


    }   
}
