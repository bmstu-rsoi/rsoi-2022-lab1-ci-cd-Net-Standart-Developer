using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using firstlab.Models;

namespace firstlab.Controllers
{
    [Route("/api/v1/persons")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private DB db { get; }

        public PersonController(DB db)
        {
            this.db = db;
            Console.WriteLine("Current Port is " + Environment.GetEnvironmentVariable("PORT"));
        }

        [HttpGet]
        public IEnumerable<Person> GetPersons()
        {
            return db.Persons;
        }

        [HttpGet("{personId}")]
        public IActionResult GetPerson(int personId)
        {
            var person = db.Persons.FirstOrDefault(p => p.Id == personId);
            if(person != null)
            {
                return Ok(person);
            }

            return NotFound("Person " + personId + " not found");
        }

        [HttpPost]
        public IActionResult CreatePerson(Person person)
        {
            if(person.Name == null || person.Age == null)
            {
                return BadRequest("Invalid data");
            }

            db.Persons.Add(person);
            db.SaveChanges();
            return Created($"/api/v1/persons/{person.Id}", null);
        }

        [HttpPatch("{personId}")]
        public IActionResult UpdatePerson(int personId, Person person)
        {
            var dbPerson = db.Persons.FirstOrDefault(p => p.Id == personId);
            if (dbPerson != null)
            {
                if (person == null || person.Name == null || person.Age == null)
                {
                    return BadRequest("Invalid data");
                }

                dbPerson.Name = person.Name;
                dbPerson.Age = person.Age;
                dbPerson.Address = person.Address;
                dbPerson.Work = person.Work;

                db.SaveChanges();

                return Ok(dbPerson);
            }
            return NotFound("Not found person by id");
        }

        [HttpDelete("{personId}")]
        public IActionResult DeletePerson(int personId)
        {
            var dbPerson = db.Persons.FirstOrDefault(p => p.Id == personId);
            if (dbPerson != null)
            {
                db.Persons.Remove(dbPerson);
                db.SaveChanges();

                return NoContent();
            }

            return NotFound(personId);
        }
    }
}
