using System;
using System.Collections.Generic;
using microservice_01.Entities;

namespace microservice_01.Repositories
{
    public interface IItemsRepository
    {
        IEnumerable<Item> GetItems();
        Item? GetItem(Guid id);
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}
