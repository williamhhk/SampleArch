using SampleArch.Events;
using SampleArch.Helpers.Domain;
using SampleArch.Model;
using SampleArch.Service;
using System.Threading.Tasks;
using System.Web.Http;

namespace SampleArch.Controllers
{
    [RoutePrefix("api/Person")]
    public class PersonController : ApiController
    {
        IPersonService _PersonService;
        ICountryService _CountryService;
        public PersonController(IPersonService PersonService, ICountryService CountryService)
        {
            _PersonService = PersonService;
            _CountryService = CountryService;
        }

        // GET api/<controller>
        public IHttpActionResult GetAll()
        {
            return Ok(_PersonService.GetAll());
        }

        // GET api/<controller>/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Person person = _PersonService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpGet]
        [Route("GetAsync/{id}", Name="GetAsync")]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            Person person = await _PersonService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _PersonService.Create(person);
            DomainEvents.Raise(new PersonCreated { _person = person });
            return CreatedAtRoute("Get", new { id = person.Id }, person);
        }


        [HttpPost]
        [Route("CreateAsync")]
        public async Task<IHttpActionResult> CreateAsync(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _PersonService.CreateAsync(person);
            DomainEvents.Raise(new PersonCreated { _person = person } );
            return CreatedAtRoute("GetAsync", new { id = person.Id }, person);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/<controller>/5
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            Person person = await _PersonService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            await _PersonService.DeleteAsync(person);

            return Ok(person);
        }

    }
}