using Company.G02.BLL.Interfaces;
using Company.G02.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comapany.G02.Pl.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departments =await _departmentRepository.GetAllAsync();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                var count = _departmentRepository.Add(model);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
        
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? _id)
        {
            if (_id is null) return BadRequest();
            var deprtment = await _departmentRepository.GetAsync(_id.Value);
            return View(deprtment);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? _id)
        {
            if (_id is null) return BadRequest();
            var deprtment =await _departmentRepository.GetAsync(_id.Value);
            return View(deprtment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int? id,Department model)
        {
            try
            {
                if (id != model.Id) return BadRequest();
                if (ModelState.IsValid)
                {
                    var count = _departmentRepository.Update(model);
                    if (count > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? _id)
        {
            if (_id is null) return BadRequest();
            var deprtment =await _departmentRepository.GetAsync(_id.Value);
            return View(deprtment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int? id, Department model)
        {
            try 
            {
                if (id != model.Id) return BadRequest();
                if (ModelState.IsValid)
                {
                    var count = _departmentRepository.Delete(model);
                    if (count > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }
    }
}
