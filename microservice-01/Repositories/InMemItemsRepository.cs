using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservice_01.Entities;

namespace microservice_01.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> _items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Description = "Restores 50 HP", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Description = "A sharp iron sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Description = "A sturdy bronze shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow }
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(_items);
        }

        public async Task<Item?> GetItemAsync(Guid id)
        {
            var item = _items.SingleOrDefault(item => item.Id == id);
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Item item)
        {
            _items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == item.Id);
            if (index != -1)
            {
                _items[index] = item;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == id);
            if (index != -1)
            {
                _items.RemoveAt(index);
            }
            await Task.CompletedTask;
        }
    }
}
