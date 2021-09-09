using API.Data;
using API.Entities;
using API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API.Enums;

namespace API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;
        public StudentsController(ApiDbContext context)
        {
            _dbContext = context;
        }

        //--- GET: students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _dbContext.Students.ToListAsync();
            if(students == null)
                return NotFound(new { message = ErrorCode.RecordNotFound.ToMessage() });
            return students;
        }

        //--- GET: students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudents(int id)
        {
            var student = await Find(id);
            if (student == null)
                return NotFound(new { message = ErrorCode.RecordNotFound.ToMessage() });
            return student;
        }

        //--- PUT: students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudents(int id, [FromBody]Student student)
        {
            if (id != student.Id)
                return BadRequest();

            _dbContext.Entry(student).State = EntityState.Modified;

            try
            {
                await Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
                    return NotFound(new { message = ErrorCode.RecordNotFound.ToMessage() });
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //--- POST: Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudents(Student Students)
        {
            _dbContext.Students.Add(Students);
            await Save();

            return CreatedAtAction("GetStudents", new { id = Students.Id }, Students);
        }

        //--- DELETE: Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudents(int id)
        {
            var Students = await Find(id);
            if (Students == null)
            {
                return NotFound();
            }

            _dbContext.Students.Remove(Students);
            await Save();

            return Students;
        }


        //--- GET: students/5
        [HttpGet("{id}/exams")]
        public async Task<ActionResult<IEnumerable<Exam>>> GetStudentsExams(int id)
        {
            var exams = await _dbContext.Students
                                ?.Include(student => student.Exams)
                                ?.ThenInclude(x => x.Exam)
                                ?.Where(x => x.Id == id)
                                ?.SelectMany(x => x.Exams)
                                ?.Select(x => x.Exam)
                                ?.ToListAsync();

            if (exams == null)
                return NotFound(new { message = ErrorCode.RecordNotFound.ToMessage() });
            return exams;
        }


        private bool StudentsExists(int id) => _dbContext.Students.Any(e => e.Id == id);
        private async Task Save() => await _dbContext?.SaveChangesAsync();
        private async Task<Student> Find(int id) => await Find(id);

    }
}
