using Generic_Repo_Pattern.Model;
using Generic_Repo_Pattern.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generic_Repo_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : GenericController<Student>
    {
        public StudentController(IGenericRepo<Student> genericRepo) : base (genericRepo)
        {
            
        }
    }
}
