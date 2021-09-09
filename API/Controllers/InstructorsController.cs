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
    //[Authorize]
    public class InstructorsController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;
        public InstructorsController(ApiDbContext context)
        {
            _dbContext = context;
        }

        //--- GET: Instructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instructor>>> GetInstructors()
        {
            var instructors = await _dbContext?.Instructors?.ToListAsync();
            if (instructors == null)
                return NotFound(new { message = ErrorCode.RecordNotFound.ToMessage() });
            return instructors;
        }

        //--- GET: instructors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instructor>> GetInstructors(int id)
        {
            var instructor = await Find(id);
            if (instructor == null)
                return NotFound(new { message = ErrorCode.RecordNotFound.ToMessage() });
            return instructor;
        }

        //--- PUT: instructors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstructors(int id, [FromBody] Instructor instructor)
        {
            if (id != instructor.Id)
                return BadRequest();

            _dbContext.Entry(instructor).State = EntityState.Modified;

            try
            {
                await Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructorsExists(id))
                    return NotFound(new { message = ErrorCode.RecordNotFound.ToMessage() });
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //--- POST: Instructors
        [HttpPost]
        public async Task<ActionResult<Instructor>> PostInstructors(Instructor Instructors)
        {
            _dbContext?.Instructors?.Add(Instructors);
            await Save();

            return CreatedAtAction("GetInstructors", new { id = Instructors.Id }, Instructors);
        }

        //--- DELETE: Instructors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Instructor>> DeleteInstructors(int id)
        {
            var instructor = await Find(id);
            if (instructor == null)
                return NotFound();

            _dbContext.Instructors.Remove(instructor);
            await Save();

            return instructor;
        }
        

        //--- GET: instructors/5/exams
        [HttpGet("{id}/exams")]
        public ActionResult<IEnumerable<Exam>> GetInstructorExams(int id)
        {
            var exams =  _dbContext.Exams.Where(x => x.InstructorId == id)?.ToArray();
            if (exams == null)
                return NotFound(new { message = ErrorCode.RecordNotFound.ToMessage() });
            return exams;
        }

        [HttpPost("{id}/exams")]
        public async Task<ActionResult<Exam>> CreateExam(int id, [FromBody] Exam exam)
        {
            exam.InstructorId = id;
            
            if(!exam.IsValid())
                return BadRequest(new { message = ErrorCode.InvalidExam.ToMessage() });

            _dbContext?.Exams?.Add(exam);
            await Save();

            return CreatedAtAction("GetInstructorExams", new { id = id }, exam);
        }

        [HttpPut("{id}/exams")]
        public async Task<IActionResult> PutExams(int id, [FromBody] Exam exam)
        {
            var selectedExam = await _dbContext.Exams.FirstOrDefaultAsync(x => x.InstructorId == id && x.Id == exam.Id );
            if (selectedExam == null)
                return BadRequest();

            if (!exam.IsValid())
                return BadRequest(new { message = ErrorCode.InvalidExam.ToMessage() });

            selectedExam.DurationMinutes = exam.DurationMinutes;
            selectedExam.Topic = exam?.Topic;
            selectedExam.DateOfTest = exam.DateOfTest;

            _dbContext.Entry(selectedExam).State = EntityState.Modified;

            try
            {
                await Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructorsExists(id))
                    return NotFound(new { message = ErrorCode.RecordNotFound.ToMessage() });
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        private bool InstructorsExists(int id) => _dbContext.Instructors.Any(e => e.Id == id);
        private async Task Save() => await _dbContext?.SaveChangesAsync();
        private async Task<Instructor> Find(int id) => await _dbContext.Instructors.FindAsync(id);

    }
}
