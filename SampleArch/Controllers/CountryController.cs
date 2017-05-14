using SampleArch.Model;
using SampleArch.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace SampleArch.Controllers
{
    public class CountryController : ApiController
    {
        //initialize service object
        ICountryService _CountryService;

        public CountryController(ICountryService CountryService)
        {
            _CountryService = CountryService;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok(_CountryService.GetAll().ToList());
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: /Country/Create
        [HttpPost]

        public IHttpActionResult Create(Country country)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                _CountryService.Create(country);
                return Ok();
            }
            return BadRequest();

        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task<IHttpActionResult> Put(Country country)
        {
            if (ModelState.IsValid)
            {
                await _CountryService.UpdateAsync(country);
            }
            return Ok(country);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Country country = _CountryService.GetById(id);
            if (country == null)
            {
                _CountryService.Delete(country);
            }
            return Ok(country);
        }

    }
}