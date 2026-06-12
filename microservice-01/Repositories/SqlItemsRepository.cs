using System;
using System.Collections.Generic;
using System.Linq;
using microservice_01.Data;
using microservice_01.Entities;

namespace microservice_01.Repositories
{
    public class SqlItemsRepository : IItemsRepository
    {
        private readonly CatalogDbContext _context;

        public SqlItemsRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public void CreateItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(Guid id)
        {
            var item = GetItem(id);
            if (item is not null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        public Item? GetItem(Guid id)
        {
            return _context.Items.Find(id);
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public void UpdateItem(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }
    }
}
