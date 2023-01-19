using Microsoft.EntityFrameworkCore;
using VisitsCounter.Interfaces;
using VisitsCounter.Models;

namespace VisitsCounter.Repository
{
    public class VisitorRepository : IVisitor
    {
        private ApplicationContext _context;

        public VisitorRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Visitor>> GetStatisticsByDate(DateTime startDate, DateTime endDate)
        {
            return await _context.Visitors.Where(e => e.Date >= startDate && e.Date <= endDate).ToListAsync();
        }

        public async Task IncrementViews()
        {
            if (_context.Visitors.Any(e => e.Date.Equals(DateTime.Today)))
            {
                await _context.Database.ExecuteSqlRawAsync($"UPDATE Visitors SET [Views] += 1 WHERE Date = '{DateTime.Today.ToString("yyyy/MM/dd")}'");
            }
            else
            {
                await _context.Visitors.AddAsync(new Visitor
                {
                    Date = DateTime.Today,
                    Visitors = 1,
                    Views = 1
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task IncrementVisitors()
        {
            if (_context.Visitors.Any(e => e.Date.Equals(DateTime.Today)))
            {
                await _context.Database.ExecuteSqlRawAsync($"UPDATE Visitors SET [Visitors] += 1, [Views] += 1 WHERE Date = '{DateTime.Today.ToString("yyyy/MM/dd")}'");
            }
            else
            {
                await _context.Visitors.AddAsync(new Visitor
                {
                    Date = DateTime.Today,
                    Visitors = 1,
                    Views = 1
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
