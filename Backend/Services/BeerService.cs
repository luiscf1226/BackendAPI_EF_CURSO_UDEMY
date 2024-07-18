using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
    {
        public List<string> Errors { get; }
        private IRepository<Beer> _beerRepository;
        public IMapper _mapper;
        public BeerService(IRepository<Beer> beerRepository, IMapper mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }
        //obtener la lista de cervezas de la base de datos
        public async Task<IEnumerable<BeerDto>> Get()
        {
            var beers = await _beerRepository.Get();
            return beers.Select(beer => new BeerDto
            {
                Id = beer.BeerID,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID
            });
        }
        public async Task<BeerDto> GetById(int id)
        {
            var beer = await _beerRepository.GetById(id);

            if (beer == null)
            {
                return null;
            }
            return new BeerDto
            {
                Id = beer.BeerID,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID
            };
        }
        public async Task<BeerDto> Insert(BeerInsertDto beerInsertDto)
        {
            //crear un objeto cerveza con los datos del dto para beer de la db
            var beer = _mapper.Map<Beer>(beerInsertDto);
            /*var beer = new Beer()
            {
                Name = beerInsertDto.Name,
                BrandID = beerInsertDto.BrandID,
                Alcohol = beerInsertDto.Alcohol
            };*/
            //agregar la cerveza a la base de datos
            await _beerRepository.insert(beer);
            //guardar los cambios
            await _beerRepository.Save();
            //mapear la cerveza a un dto
            var beerDto = _mapper.Map<BeerDto>(beer);
            /*var beerDto = new BeerDto
            {
                Id = beer.BeerID,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID
            };*/
            return beerDto;
        }

        public async Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            //obtener la cerveza por id
            var beer = await _beerRepository.GetById(id);
            if (beer == null)
            {
                return null;
            }
            //actualizar los datos de la cerveza
            //beer.Name = beerUpdateDto.Name;
            // beer.BrandID = beerUpdateDto.BrandID;
            //beer.Alcohol = beerUpdateDto.Alcohol;
            //guardar los cambios
            beer = _mapper.Map(beerUpdateDto, beer);

            _beerRepository.Update(beer);
            await _beerRepository.Save();
            //mapear la cerveza a un dto
            var beerDto = new BeerDto
            {
                Id = beer.BeerID,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID
            };
            return beerDto;
        }
        public async Task<BeerDto> Delete(int id)
        {
            //obtener la cerveza por id
            var beer = await _beerRepository.GetById(id);
            if (beer == null)
            {
                return null;
            }
            //eliminar la cerveza
            _beerRepository.Delete(beer);
            //guardar los cambios
            await _beerRepository.Save();
            //llenar el dto de la cerveza eliminada
            var beerDto = new BeerDto
            {
                Id = beer.BeerID,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandID = beer.BrandID
            };
            return beerDto;
        }
        public bool Validate(BeerInsertDto beerInsertDto)
        {
            if (_beerRepository.Search(beer => beer.Name == beerInsertDto.Name).Any())
            {
                Errors.Add("Ya existe una cerveza con ese nombre");
                return false;
            }
            return true;
        }
        public bool Validate(BeerUpdateDto beerUpdateDto)
        {
            if (_beerRepository.Search(beer => beer.Name == beerUpdateDto.Name && beer.BeerID != beerUpdateDto.Id).Any())
            {
                Errors.Add("Ya existe una cerveza con ese nombre");
                return false;
            }
            return true;
        }
    }
}
