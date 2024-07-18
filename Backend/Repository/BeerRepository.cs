
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class BeerRepository : IRepository<Beer>
    {
        //obtener el contexto de la base de datos y asignarlo a la variable _context
        private StoreContext _context;
        public BeerRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Beer>> Get() =>
            await _context.Beers.ToListAsync();

        public async Task<Beer> GetById(int id)
            => await _context.Beers.FindAsync(id);

        public async Task insert(Beer entity)
            => await _context.Beers.AddAsync(entity);
        public void Update(Beer entity)
        {
            _context.Beers.Attach(entity);
            //cambiar el estado de la entidad a modificado para que se actualice en la base de datos
            _context.Entry(entity).State = EntityState.Modified;
        }
        public async Task Save()
        => await _context.SaveChangesAsync();

        public void Delete(Beer beer)
            => _context.Beers.Remove(beer);

        public IEnumerable<Beer> Search(Func<Beer, bool> filter)
        => _context.Beers.Where(filter).ToList();


    }
}
