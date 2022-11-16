using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using WebAPI.Data;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        public DBEscuelaAPIContext Context { get; set; }
        public AlumnoController(DBEscuelaAPIContext context)
        {
            Context = context;
        }
        [HttpGet]
        public List<Alumno> Get()
        {
            List<Alumno> alumnos = Context.Alumnos.ToList();
            return alumnos;
        }
        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            Alumno alumno = Context.Alumnos.Find(id);
            return alumno;
        }
        [HttpPost]
        public ActionResult Post(Alumno alumno)
        {
            //EF Memoria
            Context.Alumnos.Add(alumno);
            //Agregamos en la base
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }
            Context.Entry(alumno).State = EntityState.Modified;
            Context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Alumno> Delete(int id)
        {
            // EF
            var alumno = Context.Alumnos.Find(id);
            if (alumno == null)
            {
                return NotFound();
            }
            Context.Alumnos.Remove(alumno);
            Context.SaveChanges();

            return alumno;
        }
    }
}
