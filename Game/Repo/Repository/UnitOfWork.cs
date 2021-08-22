using Game.Data;
using System;
using Game.Repo.IRepository;
using System.Threading.Tasks;

namespace Game.Repo.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<GameData> _gameData;

        public UnitOfWork(DatabaseContext context) => _context = context;

        public IGenericRepository<Country> Countries
            => _countries ??= new GenericRepository<Country>(_context);

        public IGenericRepository<GameData> GameData
            => _gameData ??= new GenericRepository<GameData>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task Save() => await _context.SaveChangesAsync();
    }

}
