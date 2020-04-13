using DataBase.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServiceConsulting.Repository;

namespace ServiceConsulting.Controllers
{
    public class ConsultationController : Controller
    {
        private readonly ConsultationRepository _consultationRepository;

        public ConsultationController(IConfiguration configuration)
        {
            _consultationRepository = new ConsultationRepository(configuration);
        }


        public IActionResult Index()
        {
            return View(_consultationRepository.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Consultation/Create
        [HttpPost]
        public IActionResult Create(Consultation consult)
        {
            if (ModelState.IsValid)
            {
                _consultationRepository.Add(consult);
                return RedirectToAction("Index");
            }
            return View(consult);

        }

        // GET: /Consultation/Edit/1
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Consultation obj = _consultationRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST: /Consultation/Edit   
        [HttpPost]
        public IActionResult Edit(Consultation obj)
        {

            if (ModelState.IsValid)
            {
                _consultationRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Consultation obj = _consultationRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // GET:/Consultation/Delete/1
        public IActionResult Delete(long? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            _consultationRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}