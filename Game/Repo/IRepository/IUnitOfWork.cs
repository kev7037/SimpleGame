using Game.Data;
using System;
using System.Threading.Tasks;

namespace Game.Repo.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<GameData> GameData { get; }
        Task Save();
    }
}
