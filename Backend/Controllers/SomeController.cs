using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        //Ejemplo de un metodo sincrono 
        public IActionResult GetSync()
        {
            //clase para cronometo
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Conexion a Db termindo");
            Thread.Sleep(1000);
            Console.WriteLine("Envio de email terminado");
            Console.WriteLine("Todo termino");
            sw.Stop();
            return Ok(sw.Elapsed);
        }

        [HttpGet("async")]
        public async Task<IActionResult>GetAsync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Conexion a Db termindo");
                return 1;
            });
            var task2 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envio de correo");
                return 2;
            });
            task1.Start();
            task2.Start();
            //esperar que terminen los task
            var result1=await task1;
            var result2 = await task2;
            Console.WriteLine("Todo terminado");
            sw.Stop();
            return Ok(sw.Elapsed);
        }
    }
}
