using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate our Solver class, which contains all the business logic
            Solver mySolver = new Solver();

            //solve Part 1
            mySolver.solvePart1();
            mySolver.solvePart2();
        }        
    }    

}
