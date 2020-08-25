using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ex3.Entities;
using Ex3.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ex3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseManagementController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseManagementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            return Ok(await _unitOfWork.Courses.FindAll());
        }
        // POST api/<CourseManagementController>/CourseDate
        [HttpPost]
        [Route("CourseDate")]
        public async Task<ActionResult<CourseDate>> AddNewCourseDate([FromBody] CourseDate courseDate)
        {
            try
            {
                if (courseDate == null)
                {
                    return BadRequest();
                }
                if (!await _unitOfWork.Courses.IsExist(c => c.CourseID == courseDate.CourseID))
                {
                    return NotFound();
                }
                int countCourseDates = await _unitOfWork.CourseDates.CountCourseDate((int)courseDate.CourseID);
                if (countCourseDates >= 15)
                {
                    return BadRequest();
                }
                await _unitOfWork.CourseDates.Create(courseDate);
                await _unitOfWork.CommitAsync();
                return CreatedAtAction(nameof(AddNewCourseDate), new { Id = courseDate.CourseDateID }, courseDate);
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }

        // PUT api/<CourseManagementController>/Student/5
        [HttpPut("{id}")]
        [Route("Student/{id}")]
        public async Task<ActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            try
            {
                if (id != student.StudentID || student == null || student.StudentID <= 0)
                {
                    return BadRequest();
                }
                if (!await _unitOfWork.Students.IsExist(p => p.StudentID == student.StudentID) || !await _unitOfWork.Courses.IsExist(p => p.CourseID == student.CourseID))
                {
                    return NotFound();
                }
                else
                {
                    Student sd = await _unitOfWork.Students.FindById(student.StudentID);
                    sd.CourseID = student.CourseID;
                    sd.FullName = student.FullName;
                    sd.DOB = student.DOB;
                    sd.PlaceOfBirth = student.PlaceOfBirth;
                    sd.Address = student.Address;
                    sd.PhoneNumber = student.PhoneNumber;
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

        // DELETE api/<CourseManagementController>/Course/5
        [HttpDelete("{id}")]
        [Route("Course/{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                if (!await _unitOfWork.Courses.IsExist(c => c.CourseID == id))
                {
                    return NotFound();
                }
                if (await _unitOfWork.Students.IsExist(s => s.CourseID == id))
                {
                    IEnumerable<Student> listStudents = await _unitOfWork.Students.Find(s => s.CourseID == id);
                    _unitOfWork.Students.DeleteRange(listStudents);
                }
                if (await _unitOfWork.CourseDates.IsExist(s => s.CourseID == id))
                {
                    IEnumerable<CourseDate> listCourseDates = await _unitOfWork.CourseDates.Find(s => s.CourseID == id);
                    _unitOfWork.CourseDates.DeleteRange(listCourseDates);
                }
                Course course = await _unitOfWork.Courses.FindById(id);
                _unitOfWork.Courses.Delete(course);
                await _unitOfWork.CommitAsync();
                return Ok();
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }

        // GET: api/<CourseManagementController>/Student
        [HttpGet]
        [Route("Student")]
        public async Task<ActionResult<IEnumerable<Student>>> FindStudents(string name, int courseID)
        {
            try
            {
                if (courseID < 0)
                {
                    return BadRequest();
                }
                IEnumerable<Student> listStudents;
                if (courseID > 0)
                {
                    listStudents = await _unitOfWork.Students.Find(s => s.CourseID == courseID);
                }
                else
                {
                    listStudents = await _unitOfWork.Students.Find(s => s.FullName.ToLower().Contains(name.ToLower()));
                }
                if (listStudents.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(listStudents);
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }

        // GET: api/<CourseManagementController>/CalculateRevenue
        [HttpGet]
        [Route("CalculateRevenue")]
        public async Task<ActionResult<object>> CalculateRevenue(int month, int year)
        {
            try
            {
                if (year <= 2000 || year > DateTime.Now.Year || month < 1 || month > 12)
                {
                    return BadRequest();
                }
                List<Course> listCoursesByMonth = (List<Course>)await _unitOfWork.Courses.Find(c => c.StartDate.Value.Month == month && c.StartDate.Value.Year == year);
                double value = (double)listCoursesByMonth.Sum(c =>
                {
                    int count = _unitOfWork.Students.CountStudents(c.CourseID).Result;
                    return c.Tuition * count;
                });
                var revenue = new { Month = month, Year = year, Revenue = value };
                return Ok(revenue);
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }
    }
}
