using System;
using System.Linq;
using DataBase.Data;
using Microsoft.AspNetCore.Mvc;
using ServiceConsulting.Models;
using ServiceConsulting.Repository;

namespace ServiceConsulting.Controllers
{
    public class UserController : Controller
    {
        readonly UserRepository _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = (UserRepository) userRepository;
        }


        public IActionResult Index()
        {
            var model = _userRepository.FindAll().Select(x => new VmUser()
            {
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                MiddleName = x.MiddleName,
                BirthDay = x.BirthDay,
                Sex = x.Sex,
                Snils = x.Snils
            });
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public IActionResult Create(VmUser model)
        {
            if (ModelState.IsValid)
            {
                var consult = new User()
                {
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    MiddleName = model.MiddleName,
                    BirthDay = model.BirthDay,
                    Sex = model.Sex,
                    Snils = getSnils(model.Snils)
                };
                _userRepository.Add(consult);
                return RedirectToAction("Index");
            }
            return View(model);

        }

        // GET: /User/Edit/1
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User obj = _userRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            var model = new VmUser()
            {
                FirstName = obj.FirstName,
                SecondName = obj.SecondName,
                MiddleName = obj.MiddleName,
                BirthDay = obj.BirthDay,
                Sex = obj.Sex,
                Snils = obj.Snils
            };
            return View(model);

        }

        // POST: /User/Edit   
        [HttpPost]
        public IActionResult Edit(VmUser model)
        {

            if (ModelState.IsValid)
            {
                var obj = _userRepository.FindByID(model.Id);
                obj.FirstName = model.FirstName;
                obj.FirstName = model.FirstName;
                obj.SecondName = model.SecondName;
                obj.MiddleName = model.MiddleName;
                obj.BirthDay = model.BirthDay;
                obj.Sex = model.Sex;
                obj.Snils = getSnils(model.Snils);

                _userRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User obj = _userRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            var model = new VmUser()
            {
                FirstName = obj.FirstName,
                SecondName = obj.SecondName,
                MiddleName = obj.MiddleName,
                BirthDay = obj.BirthDay,
                Sex = obj.Sex,
                Snils = obj.Snils
            };
            return View(model);
        }

        // GET:/User/Delete/1
        public IActionResult Delete(long? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            _userRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }

        #region SNILS
        string getSnils(string enterSnils)
        {
            var snils = SNILSContolCalc(enterSnils).ToString();
            return snils;
        }

        int SNILSContolCalc(string workSnils)
        {

            if (workSnils.Length != 9 && workSnils.Length != 11)
            {
                throw new Exception(
                    $"Incorrect SNILS number. {workSnils.Length} digits! (it can only be 9 or 11 digits!)");
            }

            if (workSnils.Length == 11)
            {
                workSnils = workSnils.Substring(0, 9);
            }

            int totalSum = 0;
            for (int i = workSnils.Length - 1, j = 0; i >= 0; i--, j++)
            {
                int digit = int.Parse(workSnils[i].ToString());
                totalSum += digit * (j + 1);
            }

            return SNILSCheckControlSum(totalSum);
        }

        int SNILSCheckControlSum(int controlSum)
        {
            int result;
            if (controlSum < 100)
            {
                result = controlSum;
            }
            else if (controlSum <= 101)
            {
                result = 0;
            }
            else
            {
                int balance = controlSum % 101;
                result = SNILSCheckControlSum(balance);
            }
            return result;
        }
        #endregion

    }
}