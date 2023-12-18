using Microsoft.AspNetCore.Mvc;
using ManageUsersApp.DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using ManageUsersApp.Model;

namespace ManageUsersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public PersonRepository _personRepository { get; set; }
        public PersonController(IConfiguration configuration)
        {
            _personRepository = new PersonRepository(configuration);
        }

        [HttpGet]
        public IActionResult getPersons()
        {
            var person = _personRepository.getAllPerson(); 
            return Ok(new { person});
        }

        [HttpGet("{id_number},{surname}")]
        public IActionResult getPersonsID(string id_number, string surname)
        {
            var personId = _personRepository.getPersonsId(id_number,surname);
            if(personId == null)
            {
                return NotFound();
            }
            return Ok(new { personId });
        }

        [HttpGet("{account_number}")]
        public IActionResult getPersonsAcc(string account_number)
        {
            var personsAcc = _personRepository.getPersonsAccount(account_number);
            if (personsAcc == null)
            {
                return NotFound();
            }
            return Ok(new { personsAcc });

        }

  
        [HttpPost("{id_number},{name},{surname}")]
        public IActionResult createPerson(string id_number, string name, string surname, PersonModel person)
        {

            var createPerson = _personRepository.createPerson(id_number, name, surname, person);

                return Ok(new {createPerson});

        }


    }
}
