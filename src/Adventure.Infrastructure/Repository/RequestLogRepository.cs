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
    public class RequestLogRepository : IRepository<RequestResponseLog>
    {
        private readonly InfraDbContext _context;

        public RequestLogRepository(InfraDbContext context)
        {
            _context = context;
        }

        public void Add(RequestResponseLog obj)
        {
            _context.RequestResponseLogs.Add(obj);
        }

        public void Update(RequestResponseLog obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<RequestResponseLog, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Task<List<RequestResponseLog>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<RequestResponseLog>> GetAllAsync(Expression<Func<RequestResponseLog, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
