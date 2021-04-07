using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : IColorDal
    {
        List<Car> _cars;  // Global değişkenleri gösteririz.

        public InMemoryCarDal()
        {
            //Bu bir veri tabanı simulasyonu, Yani Veri tabanında olan veriler
            _cars = new List<Car> {
                new Car{Id=1, BrandId=1, ColorId=1, CarName="116d", ModelYear=2010, DailyPrice=200, Description="2020 BMW 1 Serisi 1.5 116d"},
                new Car{Id=2, BrandId=2, ColorId=3, CarName="S90", ModelYear=2019, DailyPrice=180, Description="Volvo S90"},
                new Car{Id=3, BrandId=3, ColorId=1, CarName="E250", ModelYear=2020, DailyPrice=250, Description="Mercedes E250"},
                new Car{Id=4, BrandId=2, ColorId=1, CarName="Passat", ModelYear=2020, DailyPrice=350, Description="Wolkswagen Passat"}
            };
        }

        public InMemoryCarDal(List<Car> cars)
        {
            _cars = cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            // Göderilen ürün Id'sine sahip olan listedeki ürünü bulur.
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.CarName = car.CarName;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            // Bu kodu yazdığımızda Silme işlemi yapmaz.Çünkü referans tiptir.
            // _cars.Remove(car);

            // Bu durumu nasıl çözeriz.
            // 1. Yöntem

            //Burada Car Id'si ile Car referansını bulmak lazım önce Ondan dolayı foreach ile her bir bir car da 
            //ilgili referans numarası bulup sonra silme işlemi yaparız.
            /*Car carToDelete = null;
            foreach (var c in _cars)
            {
                if (car.Id == c.Id)
                {
                    carToDelete = c; Silinecek Id'e sahip car'ın referansı bulmak
                }
            }
            _cars.Remove(carToDelete);*/

            // 2. Yöntem
            // LINQ ile yapılabilir.
            // LINQ - Language Integrated Query
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id); // Car klasöründeki _cars referansındaki Bul.
            _cars.Remove(carToDelete);
        }



        public List<Car> GetAll()
        {
            return _cars; // veri tabanında olan bütün arabaları getirir.
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            // Where koşulu içinde belirtilen koşulu sağlayanları yeni bir liste haline getirir.
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public void GetById(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Add(Color entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Color entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Color entity)
        {
            throw new NotImplementedException();
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}