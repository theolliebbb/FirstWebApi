using System;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
	public class LiveRepository : ILiveRepository
	{
        private readonly LiveContext _context;
		public LiveRepository(LiveContext context)
		{
            _context = context;
		}

        public async Task<Live> Create(Live live)
        {
            _context.Lives.Add(live);
            await _context.SaveChangesAsync();

            return live;
        }

        public async Task Delete(int Id)
        {
            var liveToDelete = await _context.Lives.FindAsync(Id);
            _context.Lives.Remove(liveToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Live>> Get()
        {
            return await _context.Lives.ToListAsync();
        }

        public async Task<Live> Get(int Id)
        {
            return await _context.Lives.FindAsync(Id);
        }

        public async Task Update(Live live)
        {
            _context.Entry(live).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

