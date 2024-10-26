using ASPGTRTraining.DataAccess.Repositories;
using ASPGTRTraining.DataAccess.Repositories.Interface;
using ASPGTRTraining.Model.DTO;
using ASPGTRTraining.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASPGTRTraining.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeController(IUnitOfWork unitofWork)
        {
            unitOfWork = unitofWork;
        }

        public async Task<IActionResult> Privacy()
        {
            var employees = await unitOfWork.EmployeeRepo.GetIncludeDept();
            return View(employees);
        }

        public async Task<IActionResult> TotalEmployeeCount()
        {
            var total = (await unitOfWork.EmployeeRepo.GetAll()).Count;
            return Ok(total);
        }

        public async Task<IActionResult> GetByEmpID(string id)
        {
            var employee = await unitOfWork.EmployeeRepo.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeSave(string id)
        {
            ViewBag.Departments = await unitOfWork.DepartmentRepo.GetAll();
            ViewBag.Designations = await unitOfWork.DesignationRepo.GetAll();

            if (string.IsNullOrEmpty(id))
            {
                return View();
            }

            var employee = await unitOfWork.EmployeeRepo.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeSave(EmpListDTO model)
        {
            var department = await unitOfWork.DepartmentRepo.GetById(model.DeptId);
            if (department == null)
            {
                ModelState.AddModelError("DeptId", "The selected department does not exist.");
                return View(model);
            }


            if (!string.IsNullOrEmpty(model.DesigID) &&
                await unitOfWork.DesignationRepo.GetById(model.DesigID) is null)
            {
                ModelState.AddModelError("DesignationId", "The selected designation does not exist.");
                return View(model);
            }

            if (!string.IsNullOrEmpty(model.Id))
            {
                var employee = await unitOfWork.EmployeeRepo.GetById(model.Id);
                if (employee is null)
                {
                    return NotFound();
                }

                employee.Name = model.Name;
                employee.Address = model.Address;
                employee.City = model.City;
                employee.Phone = model.Phone;
                employee.DeptId = model.DeptId;
                employee.DesigID = model.DesigID;

                unitOfWork.EmployeeRepo.Edit(employee);
            }
            else
            {
                var newEmployee = new Employee
                {
                    Name = model.Name,
                    Address = model.Address,
                    City = model.City,
                    Phone = model.Phone,
                    DeptId = model.DeptId,
                    DesigID = model.DesigID
                };

                unitOfWork.EmployeeRepo.Add(newEmployee);
            }

            await unitOfWork.EmployeeRepo.Save();
            return RedirectToAction(nameof(Privacy));
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeDelete(string Id)
        {
            var employee = await unitOfWork.EmployeeRepo.GetById(Id);
            if (employee is null)
            {
                return NotFound();
            }

            unitOfWork.EmployeeRepo.Delete(employee);
            await unitOfWork.EmployeeRepo.Save();

            return RedirectToAction(nameof(Privacy));
        }

    }
}
