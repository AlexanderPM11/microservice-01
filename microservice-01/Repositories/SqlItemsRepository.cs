using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservice_01.Data;
using microservice_01.Entities;
using Microsoft.EntityFrameworkCore;

namespace microservice_01.Repositories
{
    public class SqlItemsRepository : IItemsRepository
    {
        private readonly CatalogDbContext _context;

        public SqlItemsRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task CreateItemAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var item = await GetItemAsync(id);
            if (item is not null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Item?> GetItemAsync(Guid id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
