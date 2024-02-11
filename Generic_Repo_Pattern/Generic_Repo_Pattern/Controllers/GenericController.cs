using Generic_Repo_Pattern.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Generic_Repo_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : Controller where T : class 
    {
        private IGenericRepo<T> _repository;

        public GenericController(IGenericRepo<T> repository)
        {
            _repository = repository;
        }



        // GET: api/<GenericController>
        [HttpGet]
        public List<T> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<GenericController>/5
        [HttpGet("{id}")]
        public T Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/<GenericController>
        [HttpPost]
        public List<T> Post([FromBody] T value)
        {
            return _repository.Insert(value);
        }

        // PUT api/<GenericController>/5
        [HttpPut("{id}")]
        public List<T> Put(int id, [FromBody] T value)
        {
            var extInfo = _repository.GetById(id);
            if (extInfo != null)
            {
                return new List<T>();
            }
            return _repository.Update(value);
        }

        // DELETE api/<GenericController>/5
        [HttpDelete("{id}")]
        public List<T> Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
