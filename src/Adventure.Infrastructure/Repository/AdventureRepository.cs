using Adventure.Domain.DomainModels.AdventureModels;
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

        public Task<Domain.DomainModels.AdventureModels.Adventure?> GetAdventureById(Guid adventureId)
        {
            return _context.Adventures.Include(x => x.Choices).FirstOrDefaultAsync(x => x.Id == adventureId);
        }

        public Task<AdventureSelection?> GetAdventureStep(Guid adventureId, byte code)
        {
            return _context.AdventureSelections.FirstOrDefaultAsync(x => x.Id == adventureId && x.Code == code);
        }

        public void Add(Domain.DomainModels.AdventureModels.Adventure adventure)
        {
            _context.Adventures.Add(adventure);
        }

        public void Update(Domain.DomainModels.AdventureModels.Adventure adventure)
        {
            _context.Adventures.Update(adventure);
        }

        #region From IRepository

        public Task<bool> AnyAsync(Expression<Func<Domain.DomainModels.AdventureModels.Adventure, bool>> exp)
        {
            return _context.Adventures.AnyAsync(exp);
        }

        public Task<List<Domain.DomainModels.AdventureModels.Adventure>> GetAllAsync()
        {
            return _context.Adventures.ToListAsync();
        }

        public Task<List<Domain.DomainModels.AdventureModels.Adventure>> GetAllAsync(Expression<Func<Domain.DomainModels.AdventureModels.Adventure, bool>> exp)
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
