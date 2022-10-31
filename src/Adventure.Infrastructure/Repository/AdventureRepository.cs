using Adventure.Domain.DomainModels.AdventureAggregate;
using Adventure.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Adventure.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Adventure.Infrastructure.Repository
{
    public class AdventureRepository : IAdventureRepository
    {
        private readonly AdventureDbContext _context;

        public AdventureRepository(AdventureDbContext context)
        {
            _context = context;
        }

        public Task<Domain.DomainModels.AdventureAggregate.Adventure?> GetAdventureById(Guid adventureId)
        {
            return _context.Adventures.Include(x => x.Choices).FirstOrDefaultAsync(x => x.Id == adventureId);
        }

        public Task<AdventureSelection?> GetAdventureStep(Guid adventureId, byte code)
        {
            return _context.AdventureSelections.FirstOrDefaultAsync(x => x.Id == adventureId && x.Code == code);
        }

        public void Add(Domain.DomainModels.AdventureAggregate.Adventure adventure)
        {
            _context.Adventures.Add(adventure);
        }

        public void Update(Domain.DomainModels.AdventureAggregate.Adventure adventure)
        {
            _context.Adventures.Update(adventure);
        }

        #region From IRepository

        public Task<bool> AnyAsync(Expression<Func<Domain.DomainModels.AdventureAggregate.Adventure, bool>> exp)
        {
            return _context.Adventures.AnyAsync(exp);
        }

        public Task<List<Domain.DomainModels.AdventureAggregate.Adventure>> GetAllAsync()
        {
            return _context.Adventures.ToListAsync();
        }

        public Task<List<Domain.DomainModels.AdventureAggregate.Adventure>> GetAllAsync(Expression<Func<Domain.DomainModels.AdventureAggregate.Adventure, bool>> exp)
        {
            return _context.Adventures.Where(exp).ToListAsync();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        #endregion
    }
}
