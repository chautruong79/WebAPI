using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ex2.Entities;
using Ex2.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ex2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskAssignmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<TaskAssignmentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            return Ok(await _unitOfWork.Employees.FindAll());
        }

        // GET api/<TaskAssignmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            return Ok(await _unitOfWork.Employees.FindById(id));
        }

        // POST api/<TaskAssignmentController>
        [HttpPost]
        public async Task<ActionResult<Entities.Task>> AddEmployeeToProject(int employeeID, int projectID, int hours)
        {
            try
            {
                if (!await _unitOfWork.Projects.IsExist(p => p.ProjectID == projectID) || !await _unitOfWork.Employees.IsExist(p => p.EmployeeID == employeeID))
                {
                    return NotFound();
                }
                Entities.Task task = new Entities.Task() { EmployeeID = employeeID, ProjectID = projectID, WorkingHours = hours };
                await _unitOfWork.Tasks.Create(task);
                await _unitOfWork.CommitAsync();
                return CreatedAtAction(nameof(AddEmployeeToProject), new { Id = task.TaskID }, task);
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }

        // PUT api/<TaskAssignmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, [FromBody] Project project)
        {
            try
            {
                if (id != project.ProjectID || project == null || project.ProjectID <= 0)
                {
                    return BadRequest();
                }
                if (!await _unitOfWork.Projects.IsExist(p => p.ProjectID == project.ProjectID))
                {
                    return NotFound();
                }
                else
                {
                    Project pj = await _unitOfWork.Projects.FindById(project.ProjectID);
                    pj.ProjectName = project.ProjectName;
                    pj.Description = project.Description;
                    pj.Note = project.Note;
                }
                await _unitOfWork.CommitAsync();
                return Ok();
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }

        // DELETE api/<TaskAssignmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                if (await _unitOfWork.Employees.IsExist(e => e.EmployeeID == id))
                {
                    Employee employee = await _unitOfWork.Employees.FindById(id);
                    IEnumerable<Entities.Task> listTask = await _unitOfWork.Tasks.Find(t => t.EmployeeID == employee.EmployeeID);
                    _unitOfWork.Tasks.DeleteRange(listTask);
                    _unitOfWork.Employees.Delete(employee);
                    await _unitOfWork.CommitAsync();
                    return Ok(employee);
                }
                return NotFound();
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }

        // GET: api/<TaskAssignmentController>/CalculateSalaries
        [HttpGet("CalculateSalaries")]
        public async Task<ActionResult<List<object>>> CalculateSalaries()
        {
            try
            {
                List<Employee> listEmployee = (List<Employee>)await _unitOfWork.Employees.FindAll();
                if (listEmployee.Count == 0)
                {
                    return NotFound();
                }
                List<object> salaries = new List<object>();
                listEmployee.ForEach(e =>
                {
                    IEnumerable<Entities.Task> listTask = _unitOfWork.Tasks.Find(t => t.EmployeeID == e.EmployeeID).Result;
                    float salary = (float)listTask.Sum(t => t.WorkingHours * 15 * e.PayRate);
                    var sal = new { e.FullName, Salary = salary };
                    salaries.Add(sal);
                }); 
                return Ok(salaries);
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }
    }
}
