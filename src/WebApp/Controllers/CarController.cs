using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApp.Model;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class CarController : Controller
    {

        private CarRepository _repository = new CarRepository();

        // GET: Car
        public ActionResult Index()
        {
            var cars = _repository.GetAll();
            return View(cars);
        }

        // GET: Car/Details/5
        public ActionResult Details(Guid id)
        {
            var car = _repository.GetById(id);
            return View(car);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var car = new Car();

            try
            {
                car.Name = collection["Name"];
                car.Model = collection["Model"];
                car.Year = Convert.ToInt16(collection["Year"]);

                _repository.Insert(car);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Edit(Guid id)
        {
            var car = _repository.GetById(id);
            return View(car);
        }

        // POST: Car/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var car = _repository.GetById(id);

                car.Name = collection["Name"];
                car.Model = collection["Model"];
                car.Year = Convert.ToInt16(collection["Year"]);

                _repository.Update(car);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public ActionResult Delete(Guid id)
        {
            var car = _repository.GetById(id);
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var car = _repository.GetById(id);

                _repository.Remove(car.ID);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}