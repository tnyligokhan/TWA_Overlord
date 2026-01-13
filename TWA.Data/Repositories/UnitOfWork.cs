using System.Collections;
using TWA.Core.Common;
using TWA.Core.Interfaces;
using TWA.Data.Context;
using System.Collections.Generic; // Added for Dictionary
using System; // Added for InvalidOperationException

namespace TWA.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TwaDbContext _context;
        private Dictionary<string, dynamic> _repositories = new Dictionary<string, dynamic>();

        public UnitOfWork(TwaDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            var type = typeof(T).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IRepository<T>)_repositories[type];
            }

            var repositoryType = typeof(Repository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
            if (repositoryInstance == null) throw new InvalidOperationException("Repository could not be created.");

            _repositories.Add(type, repositoryInstance);
            return (IRepository<T>)_repositories[type];
        }
    }
}
