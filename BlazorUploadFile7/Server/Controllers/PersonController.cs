using AutoMapper;
using BlazorUploadFile7.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BlazorUploadFile7.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        List<Person> persons = new List<Person>();
        private readonly IMapper _mapper;

        public PersonController(IMapper mapper)
        {
            persons = GeneratePersonList();
            _mapper = mapper;
        }

        [HttpGet("/dto")]
        public ActionResult<List<Person>> GetPeople()
        {
            return Ok(persons.Select(p => _mapper.Map<PersonDTO>(p)));
        }


        [HttpGet]
        public async Task<IActionResult> GetPersonList()
        {
            return Ok(persons);
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> GetPersonByID(int ID)
        {
            var person = new Person();
            person = persons.Find(x => x.ID == ID);
            if (person == null)
            {
                return BadRequest("No such person");
            }
            return Ok(person);
        }

        private List<Person> GeneratePersonList()
        {
            var persons = new List<Person>();
            for (int i = 0; i < 30; i++)
            {
                persons.Add(new Person
                {
                    ID = i,
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    Address = Faker.Address.City() + " " +Faker.Address.StreetName(),
                    BirthDate = Faker.Identification.DateOfBirth(),
                    isActive = Faker.Boolean.Random(),
                }) ;
            }
            return persons;
        }
    }
}
