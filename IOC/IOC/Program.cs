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
            /*
             * A sexist and pointless implementation of dependency injection.             
             */

            //constructor injection by hand
            Car myCar = new Car(new Gasoline(), new Driver("petite female"));
            myCar.startEngine();
            myCar.drive();

            Console.WriteLine("----");

            //injection using ninject
            IKernel k = new StandardKernel();
            k.Bind<IFuel>().To<RocketFuel>();
            k.Bind<IDriver>().To<Driver>().WithConstructorArgument("myType", "angry male");            
            var myCar2 = k.Get<Car>();            
            myCar2.startEngine();
            myCar2.drive();

            Console.WriteLine("----");

            IKernel k2 = new StandardKernel();
            k2.Bind<IFuel>().To<Gasoline>();
            k2.Bind<IDriver>().To<Driver>().WithConstructorArgument("myType", "even-tempered male");
            var myCar3 = k2.Get<Car>();
            myCar3.startEngine();
            myCar3.drive();

            Console.ReadLine();
        }
    }

    class Car
    {
        private readonly IFuel fuel;
        private readonly IDriver driver;
        private int _hp = 100;

        public int hp
        {
            get
            {
                return _hp;
            }
            set 
            {
                _hp = hp;
            }       
        }

        public Car (IFuel _fuel, IDriver _driver)
        {
            fuel = _fuel;
            driver = _driver;
            Console.WriteLine("A new car, piloted by {0} and fueled with {1} is created", driver.type.ToLower(), fuel.type.ToLower());
        }

        public void startEngine()
        {
            Console.WriteLine("The engine is started");
            while (!fuel.ignite())
            {
                fuel.ignite();
            }

            if (fuel.type == "Gasoline")
            {
                Console.WriteLine("The engine sputters to life");
            }
            else if (fuel.type == "Rocket Fuel")
            {
                Console.WriteLine("A violent explosion occurs");
                Console.WriteLine("The {0} driver is incinerated", driver.type);
                _hp = 0;
                driver.hp = 0;
            }                                 
        }

        public void drive()
        {
            Console.WriteLine("Time to drive!");
            if (this.hp ==100 && driver.hp ==100)           
            {
                driver.drive();
                
            }
            else
            {
                string message = "Driving is impossible: ";
                if (this.hp < 100) { message += "The car is too badly damaged, "; }
                if (driver.hp < 100) { message += "The driver is too badly damaged, "; }
                message = message.TrimEnd().Trim(',');
                Console.WriteLine(message);
            }
            
        }
    }

    interface IDriver
    {
        int hp { get; set; }
        string type { get; set; }
        void drive();
    }

    class Driver:IDriver
    {
        string _type;
        int _hp = 100;
        private void drive()
        { }

        public Driver(string myType)
        {
            _type = myType;
        }

        public string type 
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        void IDriver.drive()
        {
            if (_type.Contains("female"))
            {
                Console.WriteLine("The {0} driver careens into a ditch", _type);
            }
            else if (_type.Contains("male"))
            {
                Console.WriteLine("The {0} driver sets off", _type);                
            }
            else 
            {
                Console.WriteLine("The {0} driver has no idea how to operate a vehicle", _type);
            }

        }

        public int hp
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
            }
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
        private string _type = "Rocket Fuel";
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
