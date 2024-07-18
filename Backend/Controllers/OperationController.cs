using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    //entrar con api/nombrecontrolador sin controller
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
     
        //especificar post
        [HttpPost]
        //automaticamente detecta en el body, se desarializa y convierte en un objeto 
        //fromheader y decirle el nombre del parametro
        //formad de obtener content length variabke
        public decimal Add (Numbers numbers, [FromHeader]string Host, [FromHeader(Name ="Content-Length")]string ContentLength, [FromHeader(Name ="X-Some")]string Some)
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLength);
            Console.WriteLine(Some);
            return numbers.A-numbers.B;
        }
        //especificar put 
        [HttpPut]
        public decimal Edit(decimal a, decimal b)
        {
            return a - b;
        }
        //especificar put 
        [HttpDelete]
        public decimal Delete(decimal a, decimal b)
        {
            return a * b;
        }
    }
    public class Numbers
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
    }
}
