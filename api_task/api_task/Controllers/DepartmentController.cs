using api_task.IRepositry;
using api_task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentRepositry departmentRepositry;

        public DepartmentController(IDepartmentRepositry departmentRepositry)
        {
            this.departmentRepositry = departmentRepositry;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = departmentRepositry.GetAll();

            return Ok(departments);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var department = departmentRepositry.GetById(id);

            if(department!=null)
            {
               
            return Ok(department);

            }
            return BadRequest();    
        }


        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentRepositry.Add(department);
                return Created($"http://localhost:5256/api/Department/{department.Id}", department);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {  
               var updatedDepartment= departmentRepositry.Update(department);
                if(updatedDepartment)
                         return Ok();
                else return NotFound();
            }
            return BadRequest();


        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
             var department = departmentRepositry.Delete(id);
              if (department) return Ok(); //deleted
              return NotFound();

        }
        


    }
}
