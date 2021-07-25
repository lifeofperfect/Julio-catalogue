using Catalogue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.Repositories
{
    public interface ITemsRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItem(Guid id);
    }
}
