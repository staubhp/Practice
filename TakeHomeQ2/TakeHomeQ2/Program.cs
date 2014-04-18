using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Just like Q1 I encapsulate all the logic in a Solver class, which seems a little cleaner than throwing it all in Program.cs
            Solver mySolver = new Solver();
            mySolver.solvePart1();
        }
    }
}
