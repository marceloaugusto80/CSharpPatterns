using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPatterns
{

    public enum Terrains
    {
        LAND,
        SEA,
        AIR
    }

    public interface IVehicle
    {
        void Run();
    }

    public interface IVehicleFactory
    {
        IVehicle Create();
    }

    //

    public class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("I'm a car! Vrummm! Vrummmm!");
        }
    }


    public class Ship : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("I'm a ship! Fuuuuu! Fuuuuuu!");
        }
    }

    public class Plane : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("I'm a plane! Zoommmmmmmm!");
        }
    }


    public class SimpleVehicleFactory : IVehicleFactory
    {
        private object _terrain;

        public SimpleVehicleFactory(Terrains terrain)
        {
            this._terrain = terrain;
        }

        public IVehicle Create()
        {
            IVehicle vehicle;

            switch (_terrain)
            {
                case Terrains.AIR:
                    vehicle = new Plane();
                    break;

                case Terrains.LAND:
                    vehicle = new Car();
                    break;

                case Terrains.SEA:
                    vehicle = new Ship();
                    break;

                default:
                    vehicle = null;
                    break;
            }

            return vehicle;
        }
    }



}
