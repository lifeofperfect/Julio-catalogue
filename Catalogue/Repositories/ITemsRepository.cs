using Catalogue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.Repositories
{
    public interface ITemsRepository
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItem(Guid id);
        Task CreateItem(Item item);
        Task UpdateItem(Item item);
        Task DeleteItem(Guid id);
    }
}
