using Backend.DTOs;

namespace Backend.Services
{
    public interface ICommonService<T, TI, TU>
    {
        public List<string> Errors { get; }
        //metodos que se van a implementar en el servicio
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Insert(TI beerInsertDto);
        Task<T> Update(int id, TU beerUpdateDto);
        Task<T> Delete(int id);
        bool Validate(TI dto);
        bool Validate(TU dto);

    }
}
