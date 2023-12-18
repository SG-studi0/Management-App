using ManageUsersApp.DataAccessLayer;
using ManageUsersApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace ManageUsersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetialsController : ControllerBase
    {

        public PersonDetailsRepository _personDetailsRepository { get; set; }
        public PersonDetialsController(IConfiguration configuration)
        {
                _personDetailsRepository = new PersonDetailsRepository(configuration);  
        }

        [HttpGet("{name},{surname}")]
        public IActionResult getPersonAccounts(string name, string surname)
        {
            var personAccounts = _personDetailsRepository.getAccounts(name, surname);
            if(personAccounts == null)
            {
                return NotFound();
            }
            return Ok(new { personAccounts });
        }


        [HttpPost("{id_number},{account_number}")]
        public IActionResult createAccount(string id_number, string account_number)
        {
            var createAccount = _personDetailsRepository.createAccount(id_number, account_number);

            if (createAccount == null)
            {
                return NotFound();
            }
            return Ok(new { createAccount });
        }

        [HttpPut("{id_number},{name},{surname}")]
        public IActionResult updatePersonDetails(string id_number, string name ,string surname)
        {

            var updatePersonDetials = _personDetailsRepository.updatePersonDetials( id_number , name, surname);
            if (updatePersonDetials == null)
            {
                return NotFound();
            }
            return Ok(new { updatePersonDetials });
        }
       
    }
}
