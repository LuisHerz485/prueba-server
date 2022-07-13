using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlumnoController(ApplicationDbContext context)
        {
            _context = context; 
        }


        // GET: api/<AlumnoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listAlumno = await _context.Alumno.ToListAsync();
                return Ok(listAlumno);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AlumnoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlumnoController>
        [HttpPost]
        public async  Task<IActionResult> Post([FromBody] Alumno alumno)
        {
            try
            {
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                return Ok(alumno);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AlumnoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Alumno alumno)
        {
            try
            {
                if(id != alumno.Id)
                {
                    return NotFound();
                }

                _context.Update(alumno);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El alumno fue actualiazdo con exito" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var alumno = await _context.Alumno.FindAsync(id);

                if(alumno == null)
                {
                    return NotFound();
                };

                _context.Alumno.Remove(alumno);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Se elimino corrrectamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
