using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskIntroductionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Task<int> carTask = Task.Factory.StartNew<int>(BookCar);
            Task<int> hotelTask = Task.Factory.StartNew<int>(BookHotel);
            Task<int> planeTask = Task.Factory.StartNew<int>(BookPlane);

            Task.WaitAll(carTask, hotelTask, planeTask);

            Console.WriteLine("Finished in {0} seconds.", sw.ElapsedMilliseconds / 1000.0);
        }

        static Random random = new Random();

        private static int BookPlane()
        {
            Console.WriteLine("Booking plane...");
            Thread.Sleep(4000);
            Console.WriteLine("Plane booked.");
            return random.Next(100);
        }

        private static int BookHotel()
        {
            Console.WriteLine("Booking hotel...");
            Thread.Sleep(6000);
            Console.WriteLine("Hotel booked.");
            return random.Next(100);
        }

        private static int BookCar()
        {
            Console.WriteLine("Booking car...");
            Thread.Sleep(3000);
            Console.WriteLine("Car booked.");
            return random.Next(100);
        }
    }
}
