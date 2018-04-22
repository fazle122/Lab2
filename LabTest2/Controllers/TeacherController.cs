using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
using RequestModel;
using Service;

namespace LabTest2.Controllers
{
    [Produces("application/json")]
    [Route("api/Teacher")]
    public class TeacherController : Controller
    {
        private MyDbContext Db;
        private TeacherService service;

        public TeacherController(MyDbContext db,IBaseRepository<Teacher> repository)
        {
            Db = db;
            service = new TeacherService(repository);
        }

        [HttpPost]
        [Route("Search")]
        public async Task<IActionResult> GetTeachers([FromBody] TeacherRequestModel request)
        {
            return Ok(await service.SearchAsync(request));
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddTeacher([FromBody] Teacher teacher)
        {
            teacher.Id = Guid.NewGuid().ToString();
            teacher.Created = DateTime.Now;
            teacher.CreatedBy = "admin";
            teacher.Modified = DateTime.Now;
            teacher.ModifiedBy = "admin";
            teacher.IsActive = true;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool addTeacher = service.Add(teacher);
            if (addTeacher)
            {
                return Ok(teacher.Name);
            }

            return BadRequest("Please try again");
        }
    }
}