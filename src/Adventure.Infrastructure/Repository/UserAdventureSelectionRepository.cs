using Adventure.Domain.DomainModels.AdventureModels;
using Adventure.Domain.DomainModels.SelectionModels;
using Adventure.Domain.Interface.Repository;
using Adventure.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Infrastructure.Repository
{
    public class UserAdventureSelectionRepository : IUserAdventureSelectionRepository
    {
        private readonly AdventureDbContext _context;

        public UserAdventureSelectionRepository(AdventureDbContext context)
        {
            _context = context;
        }

        public Task<List<UserAdventureSelection>> GetAdventureListByUser(Guid userId)
        {
            return _context.UserAdventureSelections.Where(x => x.UserId == userId).ToListAsync();
        }

        public Task<UserAdventureSelection?> GetAdventure(Guid userId, Guid adventureId)
        {
            return _context.UserAdventureSelections.Where(x => x.UserId == userId && x.AdventureId == adventureId && !x.IsCompleted).FirstOrDefaultAsync();
        }

        public Task<UserAdventureSelection?> GetAdventureDetails(Guid userId, Guid adventureId)
        {
            return _context.UserAdventureSelections.Include(x => x.Steps)
                                        .Where(x => x.UserId == userId && x.AdventureId == adventureId && !x.IsCompleted).FirstOrDefaultAsync();
        }

        public void Add(UserAdventureSelection obj)
        {
            _context.UserAdventureSelections.Add(obj);
        }

        public void Update(UserAdventureSelection obj)
        {
            _context.UserAdventureSelections.Update(obj);
        }

        #region From IRepository

        public Task<bool> AnyAsync(Expression<Func<UserAdventureSelection, bool>> exp)
        {
            return _context.UserAdventureSelections.AnyAsync(exp);
        }

        public Task<List<UserAdventureSelection>> GetAllAsync()
        {
            return _context.UserAdventureSelections.ToListAsync();
        }

        public Task<List<UserAdventureSelection>> GetAllAsync(Expression<Func<UserAdventureSelection, bool>> exp)
        {
            return _context.UserAdventureSelections.Where(exp).ToListAsync();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        #endregion
    }
}
