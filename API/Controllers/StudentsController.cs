using API.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class StudentsController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;
        public StudentsController(ApiDbContext context)
        {
            _dbContext = context;
        }




    }
}
