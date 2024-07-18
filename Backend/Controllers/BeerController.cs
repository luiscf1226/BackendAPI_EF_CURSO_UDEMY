using Backend.DTOs;
using Backend.Migrations;
using Backend.Models;
using Backend.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {

        //obtener el validator 
        private IValidator<BeerInsertDto> _beerInsertValidator;
        private IValidator<BeerUpdateDto> _beerUpdateValidator;
        private ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto> _beerService;

        public BeerController(
            IValidator<BeerInsertDto> beerInsertValidator,
            IValidator<BeerUpdateDto> beerUpdateValidator,
            [FromKeyedServices("beerService")] ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto> beerService)
        {

            _beerInsertValidator = beerInsertValidator;
            _beerUpdateValidator = beerUpdateValidator;
            _beerService = beerService;
        }
        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get() =>
             //obtener la lista de cervezas
             await _beerService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            //obtener una cerveza por id
            var beerDto = await _beerService.GetById(id);
            if (beerDto == null)
            {
                return NotFound();
            }
            //retornar la cerveza
            return Ok(beerDto);
        }
        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
        {
            var validationResult = await _beerInsertValidator.ValidateAsync(beerInsertDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            if (!_beerService.Validate(beerInsertDto))
            {
                return BadRequest(_beerService.Errors);
            }
            var beerDto = await _beerService.Insert(beerInsertDto);
            //retorna el url de la cerveza creada
            //name of convierte a string el nombre del metodo  
            //enviar el dto de la cerveza creada
            return CreatedAtAction(nameof(GetById), new { id = beerDto.Id }, beerDto);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            //validar el dto
            var validationResult = await _beerUpdateValidator.ValidateAsync(beerUpdateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            if (!_beerService.Validate(beerUpdateDto))
            {
                return BadRequest(_beerService.Errors);
            }
            BeerDto beerDto = await _beerService.Update(id, beerUpdateDto);
            if (beerDto == null)
            {
                return NotFound();
            }
            //retornar el dto de la cerveza actualizada
            return Ok(beerDto);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<BeerDto>> Delete(int id)
        {
            var beerDto = await _beerService.Delete(id);
            //retornar un ok
            return Ok(beerDto);
        }

    }
}
