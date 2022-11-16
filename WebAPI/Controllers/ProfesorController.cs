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
    public class ProfesorController : ControllerBase
    {
        public DBEscuelaAPIContext Context { get; set; }
        public ProfesorController(DBEscuelaAPIContext context)
        {
            Context = context;
        }
        [HttpGet]
        public List<Profesor> Get()
        {
            List<Profesor> profesores = Context.Profesores.ToList();
            return profesores;
        }
        [HttpGet("{id}")]
        public Profesor Get(int id)
        {
            Profesor profesor = Context.Profesores.Find(id);
            return profesor;
        }
        [HttpPost]
        public ActionResult Post(Profesor profesor)
        {
            //EF Memoria
            Context.Profesores.Add(profesor);
            //Agregamos en la base
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Profesor profesor)
        {
            if (id != profesor.Id) 
            {
                return BadRequest();
            }
            Context.Entry(profesor).State = EntityState.Modified;
            Context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Profesor> Delete(int id)
        {
            // EF
            var profesor = Context.Profesores.Find(id);
            if(profesor == null)
            {
                return NotFound();
            }
            Context.Profesores.Remove(profesor);
            Context.SaveChanges();

            return profesor;
        }
    }
}
