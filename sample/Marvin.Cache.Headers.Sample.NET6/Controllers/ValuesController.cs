using Microsoft.AspNetCore.Mvc;

namespace Marvin.Cache.Headers.Sample.NET6.Controllers
{

    [Route("api/values")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly DataService _dataService;

        public ValuesController(ILogger<ValuesController> logger, DataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }
        // GET api/values
        [HttpGet]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 99999)]
        [HttpCacheValidation(MustRevalidate = true)]
        public IEnumerable<Person> Get()
        {
            return _dataService.Persons;
        }

        [HttpGet("TestGet")]
        public IEnumerable<Person> GetAllPersons()
        {
            return _dataService.Persons;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Private, MaxAge = 1337)]
        [HttpCacheValidation]
        public Person Get(int id)
        {
            return _dataService.Persons.Find(x=>x.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Person value)
        {
            _dataService.Persons.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _dataService.Persons[id].Name = value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var p = _dataService.Persons.Find(x => x.Id == id);
            _dataService.Persons.Remove(p);
        }
    }
}