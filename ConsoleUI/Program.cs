using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            CarMethodTest();
            ColorMethodTest();

            System.Console.WriteLine("--------------------------");
            System.Console.WriteLine("Çalışıyorum FAKAT DATABASE YOK,  BANA DATABASE VER YER YERİNDEN OYNASIN");
        }

        private static void CarMethodTest()
        {
            CarManager carmanager = new CarManager(new EfCarDal()); // ben in memory çalışıyorum demek

            foreach (var car in carmanager.GetAll().Data)
            {
                System.Console.WriteLine(car.CarName);
            }
        }

        private static void ColorMethodTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal()); // ben in memory çalışıyorum demek

            foreach (var color in colorManager.GetAll().Data)
            {
                System.Console.WriteLine(color.ColorName);
            }
        }
    } 
}
