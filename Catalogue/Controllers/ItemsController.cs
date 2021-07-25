using Catalogue.Entities;
using Catalogue.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly InMemoryItemsRepository _repository;
        public ItemsController()
        {
            _repository = new InMemoryItemsRepository();
        }

        /// <summary>
        ///  GET /api/items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = _repository.GetItems();
            return items;
        }

        /// <summary>
        /// GET /items/id from query
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);

            if (item is null) return NotFound();

            return item;
        }
    }
}
