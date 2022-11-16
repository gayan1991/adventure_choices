using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.Interface.Repository;
using Adventure.Infrastructure.Context;
using Adventure.Infrastructure.Util.InfraModel;

namespace Adventure.Infrastructure.Repository
{
    public class AuditRepository : IRepository<Audit>
    {
        private readonly InfraDbContext _context;

        public AuditRepository(InfraDbContext context)
        {
            _context = context;
        }

        public void Add(Audit obj)
        {
            _context.Audits.Add(obj);
        }

        public void Update(Audit obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<Audit, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Task<List<Audit>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Audit>> GetAllAsync(Expression<Func<Audit, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
