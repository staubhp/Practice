using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace IOC
{
    class Program
    {
        static void Main(string[] args)
        {
            //constructor injection by hand
            Car myCar = new Car(new Gasoline());

            //injection using ninject
            IKernel k = new StandardKernel();
            k.Bind<IFuel>().To<RocketFuel >();
            var myCar2 = k.Get<Car>();
            myCar2.startEngine();
        }
    }

    class Car
    {
        private readonly IFuel fuel;
        public Car (IFuel _fuel)
        {
            fuel = _fuel;
        }

        public void startEngine()
        {
            while (!fuel.ignite())
            {
                fuel.ignite();
            }

            if (fuel.type == "Gasoline")
            {
                Console.WriteLine("The engine sputters to life");
            }
            else if (fuel.type == "RocketFuel")
            {
                Console.WriteLine("A violent explosion occurs");
            }
                        
            Console.ReadLine();
        }
    }

    class Gasoline:IFuel
    {
        private string _type = "Gasoline";
        public Gasoline()
        { 
        }
        public bool ignite()
        {
            Random myRand = new Random();
            int randomInt = myRand.Next(0, 2);
            return (randomInt %2 == 0);
        }


        string IFuel.type
        {
            get
            {
                return _type;
            }
            
        }
    }

    class RocketFuel : IFuel 
    {
        private string _type = "RocketFuel";
        public RocketFuel()
        {}
        public bool ignite()
        {
            Random myRand = new Random();
            int randomInt = myRand.Next(0, 2);
            return (randomInt % 2 == 0);
        }


        public string type
        {
            get
            {
                return _type;
            }            
        }
    }

    interface IFuel
    {
        bool ignite();
        string type { get; }
    }

}
