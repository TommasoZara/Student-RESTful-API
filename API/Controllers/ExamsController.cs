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
    [Authorize]
    public class ExamsController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;
        public ExamsController(ApiDbContext context)
        {
            _dbContext = context;
        }

        //--- GET: exams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
        {
            var exams = await _dbContext.Exams.ToListAsync();
            if (exams == null)
                return NotFound(new { message = ErrorCode.RecordNotFound.ToMessage() });
            return exams;
        }

        //--- DELETE: exams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Exam>> DeleteExams(int id)
        {
            var exam = await Find(id);
            if (exam == null)
                return NotFound();

            _dbContext.Exams.Remove(exam);
            await Save();

            return exam;
        }

        private async Task Save() => await _dbContext?.SaveChangesAsync();
        private async Task<Exam> Find(int id) => await _dbContext.Exams.FindAsync(id);
    }
}
