using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController([FromKeyedServices("peopleService")]IPeopleService peopleService)
        {
            //esto ya no depende de la creacion del objeto 
            _peopleService = peopleService;
        }
        //se puede regresar objeto o lista de objetos
        [HttpGet("all")]
        //Retornar un objeto de lista people 
        public List<People> GetPeople()
        {
            return Repository.People;
        }
        //la rutaa viene con el id 
        [HttpGet("{id}")]
        //se define que se debe hacer, no de implementaciones
        public ActionResult <People> GetPeopleById(int id) {
            //first invoca y recorre todo el objeto y recibe otra funcion de segundo orden 
            //validar con firstordefault
            var people = Repository.People.FirstOrDefault(p => p.Id==id);
            if(people==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(people);
            }
            
        }
        //la rutaa viene con el search
        [HttpGet("search/{search}")]
        //return people by word
        public List<People> Get(string search) { 
            //recorrido de todos los objetos Where y recibe otra funcion 
            //evaluar y pasar a to upper
            return Repository.People.Where(p=>p.Name.ToUpper().Contains(search.ToUpper())).ToList();
        }
        //metodo con IAActionreuskt
        [HttpPost]
        public IActionResult Add(People people)
        {
            if(!_peopleService.Validate(people))
            {
                return BadRequest();
            }
            Repository.People.Add(people);
            return NoContent();
        }
    }
    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People()
            {
                Id = 1,Name="Pedro",Birthdate=new DateTime(1990,12,3)
            },
              new People()
            {
                Id = 2,Name="Ronal",Birthdate=new DateTime(1990,12,3)
            },
                new People()
            {
                Id = 3,Name="Walter",Birthdate=new DateTime(1990,12,3)
            }
        };
    }
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
    
}
